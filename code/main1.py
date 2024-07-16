from machine import Pin, UART
import utime

# Initialize UART for communication
uart = UART(0, 9600)

# GPIO pins for motor control (AIN1 and AIN2 for each finger)
motor_pins = [
    (Pin(3, Pin.OUT), Pin(4, Pin.OUT)),   # Finger 1
    (Pin(5, Pin.OUT), Pin(6, Pin.OUT)),   # Finger 2
    (Pin(7, Pin.OUT), Pin(8, Pin.OUT)),   # Finger 3
    (Pin(9, Pin.OUT), Pin(10, Pin.OUT)),  # Finger 4
    (Pin(11, Pin.OUT), Pin(12, Pin.OUT))  # Finger 5
]

# Function to initialize motor pins
def setup():
    for ain1, ain2 in motor_pins:
        ain1.low()
        ain2.low()

# Function to close all fingers
def close_fingers():
    for ain1, ain2 in motor_pins:
        ain1.low()
        ain2.high()
    uart.write("Fingers are closing\n")

# Function to open all fingers
def open_fingers():
    for ain1, ain2 in motor_pins:
        ain1.high()
        ain2.low()
    uart.write("Fingers are opening\n")

# Function to stop all finger movements
def stop_fingers():
    for ain1, ain2 in motor_pins:
        ain1.low()
        ain2.low()
    uart.write("Fingers are stopped\n")

# Main loop to run the finger movements for 10 seconds
def loop():
    start_time = utime.time()
    while utime.time() - start_time < 10:
        close_fingers()
        utime.sleep(1)  # Keep fingers closed for 1 second
        open_fingers()
        utime.sleep(1)  # Keep fingers open for 1 second
    stop_fingers()

setup()
loop()
