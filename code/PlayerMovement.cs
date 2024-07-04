using UnityEngine;
using System.IO;
using System.Threading.Tasks; // To use Task.Delay for retry mechanism

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    public string filePath = "C:/Users/anshu/OneDrive/Desktop/MPU/Flex.txt"; // Set the path to your text file
    public int threshold = 5; // Threshold for detecting a significant change

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput = 1f; // Automatically move right
    private int previousFlexValue;
    private int currentFlexValue;
    private const int maxRetries = 5; // Maximum number of retry attempts
    private const int retryDelay = 100; // Delay between retries in milliseconds

    private void Awake()
    {
        // Grab references for Rigidbody and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("Flex sensor data file not found: " + filePath);
        }
    }

    private void Update()
    {
        // Flip player when moving left-right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Set animator parameters
        anim.SetBool("run", true); // Always running when moving automatically
        anim.SetBool("grounded", isGrounded());

        // Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 7;
            }

            // Read flex sensor data from file
            ReadFlexSensorData();

            if (Mathf.Abs(currentFlexValue - previousFlexValue) > threshold)
            {
                Debug.Log(currentFlexValue - previousFlexValue);
                // Significant change detected
                previousFlexValue = currentFlexValue;
                Jump();
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private async void ReadFlexSensorData()
    {
        for (int i = 0; i < maxRetries; i++)
        {
            try
            {
                // Use FileStream with FileShare.ReadWrite to handle concurrent access
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader reader = new StreamReader(fs))
                {
                    string[] lines = reader.ReadToEnd().Split('\n');
                    Debug.Log("Total Lines: " + lines.Length); // Debug statement to check total lines read
                    Debug.Log("First Line: " + lines[0]); // Debug statement to check the first line read

                    // Find the last non-empty line
                    for (int j = lines.Length - 1; j >= 0; j--)
                    {
                        string latestLine = lines[j].Trim();
                        if (!string.IsNullOrEmpty(latestLine))
                        {
                            Debug.Log("Latest Line: " + latestLine); // Debug statement to check the latest line read
                            if (int.TryParse(latestLine, out currentFlexValue))
                            {
                                Debug.Log("Current Flex Value: " + currentFlexValue); // Debug statement to check the current flex value
                            }
                            else
                            {
                                Debug.LogError("Failed to parse flex value: " + latestLine); // Error if parsing fails
                            }
                            break; // Exit the loop after finding the latest non-empty line
                        }
                    }
                }
                break; // Exit the retry loop if reading is successful
            }
            catch (IOException e)
            {
                Debug.LogError("Error reading flex sensor data: " + e.Message);
                await Task.Delay(retryDelay); // Wait before retrying
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error parsing flex sensor data: " + e.Message);
                break; // Exit if a non-IO error occurs
            }
        }
    }


    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
