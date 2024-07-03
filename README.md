# Smart Hand Mobility Assistive Device for Enhanced Rehabilitation and Daily Assistance

## Table of Contents
1. [Introduction](#introduction)
2. [Overview](#overview)
3. [Components Required with Bill of Materials](#components-required-with-bill-of-materials)
4. [Table for Pin Connections](#table-for-pin-connections)
5. [Pinout Diagram](#pinout-diagram)
6. [Working Code](#working-code)
7. [Demo Video](#demo-video)
8. [Acknowledgements](#acknowledgements)

## Introduction
Millions of individuals suffer from impaired hand mobility due to conditions such as stroke, spinal cord injuries, muscular dystrophy, and other neuro-muscular disorders. This loss of hand function significantly impacts their ability to perform everyday tasks, leading to decreased independence and quality of life. Current rehabilitation methods are often slow, lack real-time feedback, and do not provide the necessary assistance for daily activities. There is a crucial need for an innovative solution that aids in both daily tasks and rehabilitation exercises.

## Overview
Our proposed solution is a Smart Hand Mobility Assistive Device designed to detect minimal muscle signals and slight finger movements, amplifying them to facilitate complete and controlled hand motions. This device not only assists users in performing daily activities but also serves as an advanced physiotherapy tool. It leverages cutting-edge sensor technology, real-time data processing, and adaptive actuation to provide personalized assistance and rehabilitation, making it a transformative tool for individuals with hand mobility impairments.

## Components Required with Bill of Materials
- Flex Sensors (5 units): ₹1500
- MG996R Servo Motors (5 units): ₹1,500
- Raspberry Pi Pico M (1 unit): ₹600
- Total Estimated Budget: ₹3600

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
![Pinout Diagram](path_to_pinout_diagram)

## Working Code
The working code for the Smart Hand Mobility Assistive Device can be found in the `code` directory of this repository. Please refer to the `main.py` file for the implementation details.

## Demo Video
A demo video showcasing the functionality of the Smart Hand Mobility Assistive Device is available [here](path_to_demo_video).

## Acknowledgements
We would like to thank everyone who supported and contributed to this project. Special thanks to the physiotherapists and healthcare providers for their invaluable insights and feedback.
