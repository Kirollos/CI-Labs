/*
 * timer.c
 *
 * Created: 13/04/2023 1:47:00 AM
 *  Author: Kirollos
 */ 



#include <avr/io.h>
#include <avr/interrupt.h>

void timer()
{
	TCCR0 = 1; // prescaler = 1
	TCNT0 = 256-8;  		/* Load TCNT0, count for 1ms */
	while((TIFR&0x01)==0);  /* Wait for TOV0 to roll over */
	TCCR0 = 0;
	TIFR = 0x1;  		/* Clear TOV0 flag */
}