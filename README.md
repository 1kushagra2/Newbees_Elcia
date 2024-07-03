# Smart Hand Mobility Assistive Device for Enhanced Rehabilitation and Daily Assistance

## Table of Contents
1. [Introduction](#introduction)
2. [Overview](#overview)
3. [Components Required with Bill of Materials](#components-required-with-bill-of-materials)
4. [Table for Pin Connections](#table-for-pin-connections)
5. [Pinout Diagram](#pinout-diagram)
6. [Project Status](#project-status).
7. [Working Code](#working-code)
8. [Demo Images and Videos](#demo-images-and-videos)
9. [Acknowledgements](#acknowledgements)

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
| Component         | Pin on Raspberry Pi Pico M |
|-------------------|----------------------------|
| Flex Sensor 1     | GPIO X                     |
| Flex Sensor 2     | GPIO Y                     |
| Flex Sensor 3     | GPIO Z                     |
| Flex Sensor 4     | GPIO A                     |
| Flex Sensor 5     | GPIO B                     |
| Servo Motor 1     | GPIO C                     |
| Servo Motor 2     | GPIO D                     |
| Servo Motor 3     | GPIO E                     |
| Servo Motor 4     | GPIO F                     |
| Servo Motor 5     | GPIO G                     |
| Bluetooth Module  | GPIO H                     |
| Power Supply      | VCC, GND                   |

## Pinout Diagram
![Pinout Diagram](https://github.com/1kushagra2/Newbees_Elcia/blob/main/hand_pinout%20diagram.jpg)

The following circuit diagram demonstrates the setup for one finger. This configuration is replicated for all five fingers for our assistive device as the final product.

## Project Status
### Tasks Completed
#### Hardware Implementation:
- Developed the concept and idea for implementing our project.
- Started 3D printing the model for the wearable device.
- Implemented our product for one finger, including 3D printing the model, writing all necessary code, and assembling the flex sensor and motor driver for the finger's functionality and mobility.

#### Software Development:
- Developed an app featuring one 2-D game controlled by the motion of the finger.
- Established wireless communication between the app and the wearable device.
  
### Tasks to be Completed
#### Hardware Implementation:
- Replicate the implementation of one finger to the remaining four fingers.
- Sync and calibrate the readings of all five flex sensors for optimal results.
- Design a more efficient 3D case to house all five motor drivers and motors.

#### Software Development:
- Expand the app to include additional games.
- Implement a dedicated physiotherapy library with predefined exercises.
- Test these exercises on the wearable hand assistive system.

#### Debugging:
- Identify and resolve errors at both the hardware and software levels to ensure the smooth functioning of our product.
## Working Code
The working code for the Smart Hand Mobility Assistive Device can be found in the `code` directory of this repository. Please refer to the `main.py` file for the implementation details.

## Demo Images and Videos
### Images
<img src="https://github.com/1kushagra2/Newbees_Elcia/blob/main/setup%20image.jpg" alt="Wearable device image1" width="400" height="300"/>
<img src="https://github.com/1kushagra2/Newbees_Elcia/blob/main/setup%20image1.jpg" alt="Wearable device image2" width="400" height="300"/>

This image represents the current stage of our project. The final product will be a wearable device designed for all five fingers.

### Videos
A demo video showcasing the functionality of the Smart Hand Mobility Assistive Device is available [here](path_to_demo_video).

## Acknowledgements

