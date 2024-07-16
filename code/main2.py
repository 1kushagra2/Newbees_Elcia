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

# Function to close a specific finger
def close_finger(index):
    motor_pins[index][0].low()
    motor_pins[index][1].high()
    uart.write("Finger {} is closing\n".format(index + 1))

# Function to open a specific finger
def open_finger(index):
    motor_pins[index][0].high()
    motor_pins[index][1].low()
    uart.write("Finger {} is opening\n".format(index + 1))

# Function to stop a specific finger
def stop_finger(index):
    motor_pins[index][0].low()
    motor_pins[index][1].low()
    uart.write("Finger {} is stopped\n".format(index + 1))

# Main loop to sequentially open and close each finger
def loop():
    for i in range(5):
        open_finger(i)
        utime.sleep(1)  # Keep finger open for 1 second
        close_finger(i)
        utime.sleep(1)  # Keep finger closed for 1 second
        stop_finger(i)
        utime.sleep(0.5)  # Small delay to ensure smooth transition

setup()
loop()
