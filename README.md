# Smart Hand Mobility Assistive Device for Enhanced Rehabilitation and Daily Assistance

## Table of Contents
1. [Introduction](#introduction)
2. [Overview](#overview)
3. [Components Required with Bill of Materials](#components-required-with-bill-of-materials)
4. [Table for Pin Connections](#table-for-pin-connections)
5. [Pinout Diagram](#pinout-diagram)
6. [Project Progress Status](#project-progress-status).
7. [Working Code](#working-code)
8. [Demo Images and Videos](#demo-images-and-videos)
9. [Conclusion](#conclusion)
10. [Acknowledgements](#acknowledgements)

## Introduction
### - Problem Statement
Millions of individuals suffer from impaired hand mobility due to conditions such as stroke, spinal cord injuries, muscular dystrophy, and other neuro-muscular disorders. This loss of hand function significantly impacts their ability to perform everyday tasks, leading to decreased independence and quality of life. Current rehabilitation methods are often slow, lack real-time feedback, and do not provide the necessary assistance for daily activities. There is a crucial need for an innovative solution that aids in both daily tasks and rehabilitation exercises.
### - Proposed Solution
Our proposed solution is a Smart Hand Mobility Assistive Device designed to detect slight finger movements, amplifying them to facilitate complete and controlled hand motions. This device not only assists users in performing daily activities but also serves as an advanced physiotherapy tool. It leverages cutting-edge sensor technology, real-time data processing, and adaptive actuation to provide personalized assistance and rehabilitation, making it a transformative tool for individuals with hand mobility impairments.

## Overview
### - Assistance and Mobility
The primary function of our device is to assist individuals with impaired hand mobility. By amplifying the detected finger movements, the device helps users perform daily tasks with greater ease and confidence. This improved grip and mobility enable users to regain a level of independence in their everyday activities, thus enhancing their quality of life.
### - Physiotherapy and Rehabilitation
Our device is also designed to serve as an advanced tool for physiotherapy. We are developing a simple and user-friendly mobile app that will offer a range of predefined physiotherapy exercises. Users can select these exercises from the app, and the device will execute them, such as opening and closing the hand at a controlled speed. This guided exercise routine ensures consistent and effective rehabilitation.

Additionally, the app will include interactive games that can be played based on finger movements detected by the device. These games are designed to improve hand eye and fine motor coordination and make the physiotherapy process more engaging and enjoyable. By incorporating these exercises and games, our device not only aids in physical rehabilitation but also enhances cognitive functions related to hand movements.
### Flow Chart
Flow chart to understand the fundamental working of our project

![FLow chart](https://github.com/1kushagra2/Newbees_Elcia/blob/main/flow%20chart.jpg)

## Components Required with Bill of Materials

| Item                        | Quantity | Description                                                   | Links to Products                                      |
|-----------------------------|----------|---------------------------------------------------------------|--------------------------------------------------------|
| Raspberry Pi Pico W         | 1 unit   | Microcontroller board with wireless capabilities              | [Raspberry Pi Pico W](https://robu.in/product/raspberry-pi-pico-w/?gad_source=1&gclid=Cj0KCQjw7ZO0BhDYARIsAFttkCiOdSAG-M2rP2H7bHVe7vGHQi-3c1n1Sug9RDFhG_kqAb2_s15yfvoaAoSyEALw_wcB)        |
| Flex Sensor - 2.2 inch      | 5 units  | Detects finger bending                                        | [Flex Sensor](https://www.electronicscomp.com/flex-sensor-2.2-inch?srsltid=AfmBOopR7z6Zs6t5TW5-ze4s0kOktSYDJWyzYXKNUTYlj3gBbFh7tCDjUqk)  |
| N20-6V-200 RPM Micro Metal Gear-box DC Motor | 5 units | Provides precise motor control                                | [N20 Motor](https://robu.in/product/n20-6v-100-rpm-micro-metal-gear-box-dc-motor-2/?gad_source=1&gclid=Cj0KCQjw7ZO0BhDYARIsAFttkChGNSYdhbZk3Be9WiX_V8mCS_95Z-uMBP6Zqxhf-Wwub9cNHNfHuDQaAp3jEALw_wcB)                 |
| DRV8833 2 Channel DC Motor Driver | 3 units | Motor driver for controlling DC motors                        | [DRV8833 Motor Driver](https://robu.in/product/raspberry-pi-pico-w/?gad_source=1&gclid=Cj0KCQjw7ZO0BhDYARIsAFttkCiOdSAG-M2rP2H7bHVe7vGHQi-3c1n1Sug9RDFhG_kqAb2_s15yfvoaAoSyEALw_wcB)       |
| Jumper Wires                | 1 set    | Male-to-male and female-to-male jumper wires                  | [Jumper Wires](https://amzn.in/d/abTh8bo)               |
| Micro USB Cable             | 1        | For programming and power supply                              | [Micro USB Cable](https://amzn.in/d/9b3ttSo)            |

- Flex Sensor - 2.2 inch (5 units): ₹285 * 5 = ₹1,425
- N20-6V-200 RPM Micro Metal Gear-box DC Motor (5 units): ₹270 * 5 = 1,350
- Raspberry Pi Pico W (1 unit): ₹539
- DRV8833 2 Channel DC Motor Driver (3 unit) = ₹97.2 * 3 = 291.6
- Total Estimated Budget: ₹3,605.6

## Table for Pin Connections

![image](https://github.com/1kushagra2/Newbees_Elcia/assets/141447943/31800966-d117-4484-ba17-dda29fa80ddc)

![image](https://github.com/1kushagra2/Newbees_Elcia/assets/141447943/7a22fc4c-760f-445e-a6c2-661a365c8f70)

![image](https://github.com/1kushagra2/Newbees_Elcia/assets/141447943/87fd8389-58d2-488f-8d48-96d05de74875)


## Pinout Diagram
![Pinout Diagram](https://github.com/1kushagra2/Newbees_Elcia/blob/main/hand_pinout%20diagram.jpg)

The following circuit diagram demonstrates the setup for one finger. This configuration is replicated for all five fingers for our assistive device as the final product.

## 3D design measurnment

![Measurnment](https://github.com/1kushagra2/Newbees_Elcia/blob/main/github_measurnment_elcia.png)


## Working Code
The working code for the Smart Hand Mobility Assistive Device. For now we have only implemented code for one finger. For the final product we will extend this code for all the five fingers.
### Code for used for micro-contorller(Raspberrypi pico W)
```py
from machine import Pin, ADC, UART
import utime


uart = UART(0, 9600)


flex_pin = ADC(26)  
AIN1 = Pin(3, Pin.OUT)
AIN2 = Pin(4, Pin.OUT)

threshold = 15


current_flex_value = 0
previous_flex_value = 0

def setup():
    AIN1.low()
    AIN2.low()

def loop():
    global previous_flex_value

    current_flex_value = flex_pin.read_u16()

    if abs(current_flex_value - previous_flex_value) > threshold:
        if current_flex_value > previous_flex_value:
            AIN1.low()
            AIN2.high()
        elif current_flex_value < previous_flex_value:

            AIN1.high()
            AIN2.low()
    else:
  
        AIN1.low()
        AIN2.low()

    previous_flex_value = current_flex_value

    uart.write("Flex Sensor Value: {}\n".format(current_flex_value))

    utime.sleep(0.5)

setup()
while True:
    loop()
```
### Codes used for making the game (C#)

### Character Movement code using flex sensor data to jump
```cs
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

```
### Camera Controller to move the camera with the character (cs)
```cs
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        //Follow player
        //transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
```
### Door Mechanism to move to the next level (cs)
```cs
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.MoveToNewRoom(nextRoom);
            else
                cam.MoveToNewRoom(previousRoom);
        }
    }
}
```
### Code For space shooter game
### Player Code for shooting lasers using flex sensor data read from text file
```cs
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

```
### Laser Mechanism for the space ship
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	[SerializeField]
	private float _speed = 5f;

	// Start is called before the first frame update
	void Start() {
		this.transform.eulerAngles = new Vector3( 0f, 0f, -90f );
	}

	// Update is called once per frame
	void Update() {
		this.MakeMovement( );
		this.DestroyLaser( );
	}

	void DestroyLaser() {
		if ( this.transform.position.x >= 11f ) {
			Destroy( this.gameObject );
		}
	}

	void MakeMovement() {
		this.transform.Translate( new Vector3( 0f, 5f, 0f ) * _speed * Time.deltaTime );
	}

}
```
### Asteroid Spawner
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	[SerializeField]
	private float speed = 4f;
	private SpawnManager spawnManager = null;

	// Start is called before the first frame update
	void Start() {
		spawnManager = GameObject.Find( "SpawnManager" ).GetComponent<SpawnManager>( );
		float randomY = this.GetRandomFloat( -5f, 5f );
		this.transform.position = new Vector3( 12f, 0f, 0f );
	}

	// Update is called once per frame
	void Update() {
		this.transform.Translate( Vector3.left * speed * Time.deltaTime );
		if ( this.transform.position.x <= -12f ) {
			float randomY = this.GetRandomFloat( -5f, 5f );
			this.transform.position = new Vector3( 12f, 0f, 0f );
		}
	}

	float GetRandomFloat( float min, float max ) {
		return Random.Range( min, max );
	}

	private void OnTriggerEnter2D( Collider2D other ) {
		switch ( other.tag ) {
			case "Laser":
				Destroy( other.transform.gameObject );
				break;
			case "Player":
				Player player = other.transform.GetComponent<Player>( );
				if ( player == null ) {
					break;
				}
				player.AbsorbEnemyDamage( GetRandomFloat( 1f, 10f ) );
				break;
		}
		Destroy( this.gameObject );
		this.DecreasseAsteroidAmountInSpawnManager( );
	}

	private void DecreasseAsteroidAmountInSpawnManager() {
		spawnManager.RemoveOneAsteroid( );
	}

}

```
### Kotlin Code for sending option number to raspberry pi pico w
```cs
package com.example.atry;

import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.namespace.R;

import org.java_websocket.client.WebSocketClient;
import org.java_websocket.handshake.ServerHandshake;
import java.net.URI;
import java.net.URISyntaxException;

public class MainActivity extends AppCompatActivity {

    private WebSocketClient mWebSocketClient;
    private Button button1, button2, button3;
    private TextView timerTextView;
    private boolean isTimerRunning = false;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        button1 = findViewById(R.id.button1);
        button2 = findViewById(R.id.button2);
        button3 = findViewById(R.id.button3);
        timerTextView = findViewById(R.id.timerTextView);

        button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=1");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        button2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=2");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        button3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isTimerRunning) {
                    sendWebSocketMessage("option=3");
                    startTimer(10000); // 10 seconds timer
                }
            }
        });

        connectWebSocket();
    }

    private void connectWebSocket() {
        URI uri;
        try {
            uri = new URI("ws://192.168.84.128:81");
        } catch (URISyntaxException e) {
            e.printStackTrace();
            return;
        }

        mWebSocketClient = new WebSocketClient(uri) {
            @Override
            public void onOpen(ServerHandshake handshakedata) {
                Log.i("WebSocket", "Opened");
            }

            @Override
            public void onMessage(String message) {
                Log.i("WebSocket", "Received: " + message);
            }

            @Override
            public void onClose(int code, String reason, boolean remote) {
                Log.i("WebSocket", "Closed: " + reason);
            }

            @Override
            public void onError(Exception ex) {
                Log.i("WebSocket", "Error: " + ex.getMessage());
            }
        };
        mWebSocketClient.connect();
    }

    private void sendWebSocketMessage(String message) {
        if (mWebSocketClient != null && mWebSocketClient.isOpen()) {
            mWebSocketClient.send(message);
        }
    }

    private void startTimer(long milliseconds) {
        isTimerRunning = true;
        disableButtons();
        new CountDownTimer(milliseconds, 1000) {

            public void onTick(long millisUntilFinished) {
                timerTextView.setText("seconds remaining: " + millisUntilFinished / 1000);
            }

            public void onFinish() {
                timerTextView.setText("Done!");
                isTimerRunning = false;
                enableButtons();
            }
        }.start();
    }

    private void disableButtons() {
        button1.setEnabled(false);
        button2.setEnabled(false);
        button3.setEnabled(false);
    }

    private void enableButtons() {
        button1.setEnabled(true);
        button2.setEnabled(true);
        button3.setEnabled(true);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (mWebSocketClient != null) {
            mWebSocketClient.close();
        }
    }
}

```
## Demo Images and Videos
### Images
![Wearable device image1](https://github.com/1kushagra2/Newbees_Elcia/blob/main/project_img_1.jpg)
<img src="https://github.com/1kushagra2/Newbees_Elcia/blob/main/project_img_2.jpg" alt="Wearable device image2" width="600" height="800"/>




### Videos
A demo video showcasing the functionality of the Smart Hand Mobility Assistive Device is available [here](https://www.youtube.com/watch?v=sWDcYhpI70U).
[![Watch the video](https://i9.ytimg.com/vi_webp/DBRHk1-JDbc/mq1.webp?sqp=CKSD1bQG-oaymwEmCMACELQB8quKqQMa8AEB-AH-CYAC0AWKAgwIABABGHIgVihBMA8=&rs=AOn4CLCR6LfPuU1UN-rbkbNlGbHPI8FQPw)](https://www.youtube.com/watch?v=sWDcYhpI70U)

A demo video showcasing the functionality of the Smart Hand Mobility Assistive Device for Physiotheraoy and Rehabilitation available [here](https://www.youtube.com/watch?v=VUKEUVhbraw).


2D Interactive jumping games for the rehabilitation process. [here](https://youtu.be/whzIk8NJf8A?si=46Dk8aPr_QfICc2L).

## How do we plan on taking this product further

## Conclusion
The “Smart Hand Mobility Assistive Device” project aims to revolutionize hand mobility assistance and rehabilitation. By combining advanced sensor technology, precise actuation, and real-time data processing, this device empowers individuals with impaired hand function to regain independence and enhance their quality of life. The device’s innovative approach not only aids in daily tasks but also accelerates rehabilitation, offering a comprehensive solution for both users and healthcare providers. With a focus on user comfort, safety, and adaptability, our solution promises to make a significant impact on the lives of those affected by hand mobility impairments.

## Acknowledgements

