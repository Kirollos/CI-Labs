/*
 * main.c
 *
 * Created: 21/03/2023 9:28:02 PM
 *  Author: Kirollos
 */ 

#define F_CPU 8000000
#define BAUD_RATE 9600

#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>
#include "UART.h"

/* Full command will be
* @ W/R AA DDD;
* Spaces will be ignored by the driver
* address AA and data DDD will be sent in decimal
*/

void SD_MainFunction();
static volatile uint8_t cmd_buffer[8];
volatile uint8_t *address;
volatile uint8_t tx_str[8] = {0};
int main(void) {
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
	DDRA = 255;
	while(1) {
		SD_MainFunction();
	}
	return 0;
}
void SD_MainFunction() {
	uint8_t value;
	/* Receive the full buffer command. */
	UART_ReceivePayload(cmd_buffer, 8);
	/* Poll until reception is complete. */
	while(0 == UART_IsRxComplete());
	if(!(cmd_buffer[0] == '@' && cmd_buffer[7] == ';')) return;
	// Parse Address
	char address_buffer[2];
	address_buffer[0] = cmd_buffer[2];
	address_buffer[1] = cmd_buffer[3];
	address = ((volatile uint8_t *)atoi(address_buffer));

	// Parse value
	char value_buffer[3];
	value_buffer[0] = cmd_buffer[4];
	value_buffer[1] = cmd_buffer[5];
	value_buffer[2] = cmd_buffer[6];
	value = (uint8_t)atoi(value_buffer);
	// Parse command buffer
	switch(cmd_buffer[1])
	{
		case 'w':
		case 'W':
		{
			// Write received value to received address.
			*(address) = value;
			//UART_SendPayload(cmd_buffer, 8);
			break;
		}
		//case 'r':
		case 'R':
		{
			uint8_t tx_value = *(address);
			//const uint8_t tx_str[] = "@RR:123;";
			sprintf(tx_str, "@RR:%.3i;", tx_value);
			UART_SendPayload(tx_str, 8);
			while(0 == UART_IsTxComplete());
			break;
		}
		default:
		{
			// Do nothing.
		}
	}
	//address = 0;
}