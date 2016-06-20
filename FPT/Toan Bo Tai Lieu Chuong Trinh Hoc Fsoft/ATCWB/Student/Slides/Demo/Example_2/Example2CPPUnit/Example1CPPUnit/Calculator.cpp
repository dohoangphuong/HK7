#include "Calculator.h"
#include <stdio.h>
#include <limits.h>

CCalculator::CCalculator(void)
{
}
CCalculator::CCalculator(int a, int b)
{
	x = a;
	y = b;
}
int CCalculator::Addition(int a, int b)
{	
	/* check a is negative */
	if( a < 0 )
	{
		/* Check Min integer greater than b + a */
		if(INT_MIN - a > b) 
		{
			printf("Addition out off range\n");
			return INT_MIN;
		}
		return a + b;
	}	

	/* Check Max integer less than b + a */
	if(INT_MAX - a < b) 
	{
		printf("\nAddition out off range\n");
		return INT_MAX;
	}
	return a + b;	
}
CCalculator::~CCalculator(void)
{
}
