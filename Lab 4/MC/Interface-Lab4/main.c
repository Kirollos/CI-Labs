/*
 * main.c
 *
 * Created: 12/04/2023 10:22:03 PM
 *  Author: Kirollos
 */ 

#define BAUD_RATE 9600
#define F_CPU 8000000

#include <avr/io.h>
#include <avr/interrupt.h>
#include <stdlib.h>
#include <util/delay.h>
#include <math.h>
#include "UART.h"
#include "timer.h"
#define _CMD_START_CNT 1
#define _CMD_END_CNT 1
#define _CMD_WAVE_CNT 1
#define _CMD_AMP_CNT 2
#define _CMD_FRQ_CNT 3
#define FULL_CMD_CNT (_CMD_START_CNT + _CMD_WAVE_CNT + _CMD_AMP_CNT + _CMD_FRQ_CNT + _CMD_END_CNT)
#define WAVE_OFFSET (_CMD_START_CNT)
#define AMP_OFFSET (_CMD_START_CNT + _CMD_WAVE_CNT)
#define FREQ_OFFSET (_CMD_START_CNT + _CMD_WAVE_CNT + _CMD_AMP_CNT)
#define MARKER_END (_CMD_START_CNT + _CMD_WAVE_CNT + _CMD_AMP_CNT + _CMD_FRQ_CNT)
#define MARKER_START (0)

#define WAVEFORM_NUM 4
#define DAC_DDR DDRB
#define DAC_PORT PORTB
typedef enum {GENERATE_WAVE, UPDATE_WAVE} states_t;
static uint8_t cmd_buffer[FULL_CMD_CNT];
static void (*waveform[WAVEFORM_NUM])(uint8_t amp, uint16_t freq);
static states_t currentState = GENERATE_WAVE;
static uint8_t amp_value = 0;
static uint16_t freq_value = 0;
static uint8_t waveform_index = WAVEFORM_NUM;
void WAVE_Init(void);
void WAVE_MainFunction(void);
void squareWave(uint8_t amp, uint16_t freq);
void staircaseWave(uint8_t amp, uint16_t freq);
void sineWave(uint8_t amp, uint16_t freq);
void triangleWave(uint8_t amp, uint16_t freq);
void delay(long double time);

volatile double sine_values[180];

int main(void) {
	WAVE_Init();
	sei();
	for(int i = 0; i < 180; i++)
	{
		sine_values[i] = sin(i*M_PI/180.0);
	}
	while(1) {
		WAVE_MainFunction();
	}
	return 0;
}
void WAVE_Init(void)
{
	uint8_t i;
	/* Init UART driver. */
	UART_cfg my_uart_cfg;
	/* Set USART mode. */
	my_uart_cfg.UBRRL_cfg = (BAUD_RATE_VALUE)&0x00FF;
	my_uart_cfg.UBRRH_cfg = (((BAUD_RATE_VALUE)&0xFF00)>>8);
	my_uart_cfg.UCSRA_cfg = 0;
	my_uart_cfg.UCSRB_cfg = (1<<RXEN) | (1<<TXEN) | (1<<TXCIE) | (1<<RXCIE);
	my_uart_cfg.UCSRC_cfg = (1<<URSEL) | (3<<UCSZ0);
	UART_Init(&my_uart_cfg);

	/* Clear cmd_buffer. */
	for(i = 0; i < FULL_CMD_CNT; i += 1)
	{
		cmd_buffer[i] = 0;
	}
	/* Initialize waveform array. */
	waveform[0] = squareWave;
	waveform[1] = staircaseWave;
	waveform[2] = sineWave;
	waveform[3] = triangleWave;
	/* Start with getting which wave to generate. */
	currentState = UPDATE_WAVE;
}

void WAVE_MainFunction() {
	// Main function must have two states,
	// First state is command parsing and waveform selection.
	// second state is waveform executing.
	switch(currentState)
	{
		case UPDATE_WAVE:
		{
			if ((cmd_buffer[MARKER_START] == 0) && (cmd_buffer[MARKER_END] == 0))

			{
				/* Receive the full buffer command. */
				UART_ReceivePayload(cmd_buffer, FULL_CMD_CNT);
				/* Poll until reception is complete. */
				while(0 == UART_IsRxComplete());
			}
			/* Check if the cmd is valid. */
			if((cmd_buffer[MARKER_START] == '@') && (cmd_buffer[MARKER_END] == ';'))
			{
				// Extract amplitude and freq values before sending them to the waveform generator.

				/* Compute amplitude. */
				{
					char _buffer[_CMD_AMP_CNT];
					for(uint8_t i = 0; i < _CMD_AMP_CNT; ++i) { _buffer[i] = cmd_buffer[AMP_OFFSET+i]; }

					amp_value = atoi(_buffer);
				}
				/* Compute frequency. */
				{
					char _buffer[_CMD_FRQ_CNT];
					for(uint8_t i = 0; i < _CMD_FRQ_CNT; ++i) { _buffer[i] = cmd_buffer[FREQ_OFFSET+i]; }

					freq_value = atoi(_buffer);
				}
				/* Compute waveform. */
				{
					waveform_index = cmd_buffer[WAVE_OFFSET] - '0';
				}
			}
			/* Clear cmd_buffer. */
			for(uint8_t i = 0; i < FULL_CMD_CNT; i += 1)
			{
				cmd_buffer[i] = 0;
			}

			// Trigger a new reception.
			UART_ReceivePayload(cmd_buffer, FULL_CMD_CNT);
		}
		case GENERATE_WAVE:
		{
			// Execute waveform..
			if(waveform_index < WAVEFORM_NUM)
			{
				DDRA = 255;
				//PORTA = freq_value;
				waveform[waveform_index](amp_value, freq_value);
			}
			// Keep in generate wave if no command is received.
			currentState = (1 == UART_IsRxComplete()) ? UPDATE_WAVE : GENERATE_WAVE;
			break;
		}
		default: {/* Do nothing.*/}
	}
}

void squareWave(uint8_t amp, uint16_t freq) {
	// TODO: Place your code here
	DAC_DDR = 255;
	float a_f = amp/12.0;
	if(a_f > 1)
		a_f = 1;
	uint8_t a = a_f * 255;
	DAC_PORT = a;
	long double d = 1.0/(freq*2.0);
	delay(d);
	DAC_PORT = 0;
	delay(d);
	
}
void staircaseWave(uint8_t amp, uint16_t freq) {
	// Refresh DAC DDR to be output.
	DAC_DDR = 255;
	// Generate waveform.
	float a_f = amp/12.0;
	if(a_f > 1)
		a_f = 1;
	double d = 1.0/(freq*6.0);
	for(uint16_t x = 0; x <= 0xFF; x += 0x33)
	{
		float v = a_f * (float)x;
		DAC_PORT = (uint8_t)v;
		delay(d);
	}
	/*DAC_PORT = 0;
	delay(d);
	DAC_PORT = 0x33 * a_f;
	delay(d);
	DAC_PORT = 0x66 * a_f;
	delay(d);
	DAC_PORT = 0x99 * a_f;
	delay(d);
	DAC_PORT = 0xcc * a_f;
	delay(d);
	DAC_PORT = 0xff * a_f;
	delay(d);
	DAC_PORT = 0;*/
}
//float sine[] = {0, 0.5, 0.866, 1.0, 0.866, 0.5, 0};
void sineWave(uint8_t amp, uint16_t freq) {
	// TODO: Place your code here
	//double s[180];
	//for(int i = 0; i < 180; i++)
		//s[i] = sin(i*M_PI/180.0);
	DAC_DDR = 255;
	//DAC_PORT = 3;
	float a_f = amp/12.0;
	if(a_f > 1)
		a_f = 1;
	long double f = freq * 90.0;
	//long double d = 1.0/(freq*180.0);
	long double d = 1.0 / f;
	
	for(int i = 0; i < 180; i+=4)
	{
		//double s = a_f * sin(i*M_PI/180.0);
		double s = a_f * sine_values[i];
		DAC_PORT = 128 + (double)(127.0 * s);
		delay(d);
	}
	for(int i = 0; i < 180; i+=4)
	{
		//double s = a_f * sin(i*M_PI/180.0);
		double s = a_f * sine_values[i];
		DAC_PORT = 128 - (double)(128.0 * s);
		delay(d);
	}
}
void triangleWave(uint8_t amp, uint16_t freq) {
	// TODO: Place your code here
	DAC_DDR = 255;
	float a_f = amp/12.0;
	if(a_f > 1)
	a_f = 1;
	double d = 1.0/(freq*512.0);
	DAC_PORT = 0;
	for(uint16_t x = 0; x <= 0xFF; x += 1)
	{
		float v = a_f * x;
		//DAC_PORT = (uint8_t)v;
		//if(x >= 255) {
		//	DAC_PORT = 255;
		//	delay(d);
		//	break;
		//}
		DAC_PORT = (uint8_t)v;
		delay(d);
	}
	
	for(uint16_t x = 0; x <= 0xFF; x += 1)
	{
		float v = a_f * (255-x);
		//DAC_PORT = (uint8_t)v;
		//if(x >= 255)
		//{
		//	DAC_PORT = 0;
		//	delay(d);
		//	break;
		//}
		DAC_PORT = (uint8_t)v;
		delay(d);
	}
}

void delay(long double time) {
	long double f = time * 1000000.0;
	//uint32_t usTime = time * 1000000UL;
	uint32_t usTime = f;
	PORTA = usTime;
	//usTime = usTime/10;
	usTime = usTime /5;
	while (usTime--)
	{
		//_delay_us(10);
		//_delay_us(1);
		timer();
	}
}