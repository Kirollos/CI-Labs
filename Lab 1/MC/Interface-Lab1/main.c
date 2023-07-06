/*
 * main.c
 *
 * Created: 21/02/2023 10:20:03 PM
 *  Author: Kirollos, Marwa, Ramadan
 */ 
#define F_CPU 1000000
#include <avr/io.h>
#include <util/delay.h>

#define get_bit(reg,bitnum) ((reg & (1<<bitnum))>>bitnum)
int main() {
	float duty_cycle = 0;

	DDRA=0b11110000; // Set the first 2 pins of PORTA as inputs to read push buttons
	DDRB=0b11111111; // Set Pin3 (OC0) in Port B as output
	DDRD=0b11111111;

	TCCR0=0b01110101; // Configure TCCR0 as explained in the article
	OCR0=255; // Set OCR0 to 255 for initial duty cycle = 0 and the motor is not rotating
	while(1) {
		if ((get_bit(PINA,0) == 1)) {
			// Place your code here (Increase the duty cycle)
			if(duty_cycle < 1.0) {
				duty_cycle += 0.1;
			}
			else
				duty_cycle = 1;
		}
		if ((get_bit(PINA,1) == 1)) {
			// Place your code here (Decrease the duty cycle)
			if(duty_cycle > 0) {
				duty_cycle -= 0.1;
			}
			else
				duty_cycle = 0;
		}
		if ((get_bit(PINA,2) == 1)) {
			PORTD = 1;
		}
		if ((get_bit(PINA,3) == 1)) {
			PORTD = 2;
		}
		// Place your code here (Apply the change in duty cycle to OCR0)
		OCR0 = 255 - 255*duty_cycle; // d = (255-OCR0)/255  // 255 - d*255
		_delay_ms(250);
	}
	return 0;
}