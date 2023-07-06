/*
 * main.c
 *
 * Created: 03/03/2023 10:23:33 PM
 *  Author: Kirollos
 */ 
#define BAUD_RATE 9600
#define F_CPU 1000000
#include <avr/io.h>
#include <avr/interrupt.h>
#include <util/delay.h>
#include "UART.h"

#define MOTOR_INC 'I'
#define MOTOR_DEC 'D'
#define MOTOR_FWD 'F'
#define MOTOR_REV 'R'
#define MOTOR_STOP 'S'

#define LED_ON 'o'
#define LED_OFF 'f'

const float stepsize = 0.1;
int main(void) {
	float duty_cycle = 0;
	TCCR0=0b01110101; // Configure TCCR0 as explained in the article
	OCR0=255; // Set OCR0 to 255 for initial duty cycle = 0 and the motor is not rotating
	DDRB |= 1<<3;
	DDRA = 1;
	DDRD |= 1<<2 | 1<<3;
	PORTA |= 1;
	static volatile uint8_t cmd_buffer[1];
	/* Init UART driver. */
	UART_cfg my_uart_cfg;
	/* Set USART mode. */
	my_uart_cfg.UBRRL_cfg = (BAUD_RATE_VALUE)&0x00FF;
	my_uart_cfg.UBRRH_cfg = (((BAUD_RATE_VALUE)&0xFF00)>>8);
	my_uart_cfg.UCSRA_cfg = 0;
	my_uart_cfg.UCSRB_cfg = (1<<RXEN) | (1<<TXEN) | (1<<TXCIE) | (1<<RXCIE);
	my_uart_cfg.UCSRC_cfg = (1<<URSEL) | (3<<UCSZ0);
	UART_Init(&my_uart_cfg);
	sei();
	while(1) {
		/* Receive the full buffer command. */
		UART_ReceivePayload(cmd_buffer, 1);
		/* Poll until reception is complete. */
		while(0 == UART_IsRxComplete());
		/* Parse command buffer. */
		switch(cmd_buffer[0]) {
			case LED_ON: {
				PORTA |= 1;
				break;
			}
			case LED_OFF: {
				PORTA &= ~1;
				break;
			}
			case MOTOR_INC: {
				if((duty_cycle+stepsize) < 1.0) {
					duty_cycle += stepsize;
				}
				else
				duty_cycle = 1;
				break;
			}
			case MOTOR_DEC: {
				if((duty_cycle-stepsize) > 0) {
					duty_cycle -= stepsize;
				}
				else
				duty_cycle = 0;
				break;
			}
			case MOTOR_FWD: {
				PORTD |= 1<<2;
				PORTD &= ~(1<<3);
				break;
			}
			case MOTOR_REV: {
				PORTD |= 1<<3;
				PORTD &= ~(1<<2);
				break;
			}
			case MOTOR_STOP: {
				PORTD &= ~(1<<2);
				PORTD &= ~(1<<3);
				break;
			}
			default: {
				/* Do nothing. */
			}
		}
		OCR0 = 255 - 255*duty_cycle; // d = (255-OCR0)/255  // 255 - d*255
		//_delay_ms(100);
	}
	return 0;
}