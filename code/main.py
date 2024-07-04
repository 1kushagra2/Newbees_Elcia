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
