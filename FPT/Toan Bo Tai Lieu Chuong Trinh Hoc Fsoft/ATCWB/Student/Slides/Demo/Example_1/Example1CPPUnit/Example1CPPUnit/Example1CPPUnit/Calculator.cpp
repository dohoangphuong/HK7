#include "Calculator.h"

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
	return a + b;
}
CCalculator::~CCalculator(void)
{
}
