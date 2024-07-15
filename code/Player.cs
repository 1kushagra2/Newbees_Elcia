using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 6f;
    [SerializeField]
    private Laser laser = null;
    [SerializeField]
    private float healthPoints = 100f;
    [SerializeField]
    private float fireRate = .5f;
    private float nextFire = -1f;
    private SpawnManager spawnManager = null;

    public string filePath = "C:/Users/anshu/OneDrive/Desktop/MPU/Flex.txt"; // Set the path to your text file
    public int threshold = 5; // Threshold for detecting a significant change
    private int previousFlexValue;
    private int currentFlexValue;
    private const int maxRetries = 5; // Maximum number of retry attempts
    private const int retryDelay = 100; // Delay between retries in milliseconds

    // Start is called before the first frame update
    void Start()
    {
        this.spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (this.spawnManager == null)
        {
            Debug.LogError("The spawnManager is NULL.");
        }
        this.transform.position = new Vector3(-7f, 0f, 0f);
        this.transform.eulerAngles = new Vector3(0f, 0f, -90f);

        if (!File.Exists(filePath))
        {
            Debug.LogError("Flex sensor data file not found: " + filePath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.MakeMovement();

        ReadFlexSensorData();

        if (this.FireEnabled())
        {
            this.FireLaser();
            previousFlexValue = currentFlexValue; // Update previousFlexValue only after firing
        }
    }

    bool FireEnabled()
    {
        // Check if the difference in flex sensor value is greater than the threshold
        if (Mathf.Abs(currentFlexValue - previousFlexValue) > threshold && Time.time > this.nextFire)
        {
            Debug.Log("Firing Laser. Current Flex Value: " + currentFlexValue + ", Previous Flex Value: " + previousFlexValue);
            return true;
        }
        return false;
    }

    void FireLaser()
    {
        Instantiate(laser, this.transform.position + new Vector3(1.044f, 0f, 0f), Quaternion.identity);
        this.nextFire = Time.time + this.fireRate;
    }

    private void MakeMovement()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(-horizontalInput, verticalInput, 0f);
        this.transform.Translate(direction * speed * Time.deltaTime);

        float horizontalPos = this.transform.position.x;
        float verticalPos = this.transform.position.y;
        float horizontalBounds = Mathf.Clamp(this.transform.position.x, -9.42f, 9.454f);
        this.transform.position = new Vector3(horizontalBounds, verticalPos, 0f);
        if (verticalPos <= -6f)
        {
            this.transform.position = new Vector3(horizontalPos, 6f, 0f);
        }
        else if (verticalPos >= 6f)
        {
            this.transform.position = new Vector3(horizontalPos, -6f, 0f);
        }
    }

    public void AbsorbEnemyDamage(float damageAmount)
    {
        this.SetHealthPoints(this.GetHealthPoints() - damageAmount);
        if (this.GetHealthPoints() <= 0f)
        {
            if (this.spawnManager != null)
            {
                this.spawnManager.SetIsPlayerAlive(false);
            }
            Destroy(this.gameObject);
            Debug.LogError("***GAME OVER***");
        }
    }

    public float GetHealthPoints()
    {
        return this.healthPoints;
    }

    public void SetHealthPoints(float hp)
    {
        this.healthPoints = hp;
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
}
