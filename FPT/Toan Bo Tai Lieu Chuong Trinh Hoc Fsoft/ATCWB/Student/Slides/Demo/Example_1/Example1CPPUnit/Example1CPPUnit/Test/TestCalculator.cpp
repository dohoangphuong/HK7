#include "TestCalculator.h"
#include "Calculator.h"
#include "Calculator.cpp"
CTestCalculator::CTestCalculator(void)
{
}
/* Test case 01 : Positive + Positive */
void CTestCalculator::UTCID01()
{
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(1,2) == 3);
}
/* Test case 02 : Zero + Zero */
void CTestCalculator::UTCID02()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(0,0) == 0);
}
/* Test case 03 : Positive + Zero */
void CTestCalculator::UTCID03()
{
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(10,0) == 10);
}
/* Test case 04 : Negative + Zero */
void CTestCalculator::UTCID04()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-8,0) == -8);
}
/* Test case 05 : Positive + Negative */
void CTestCalculator::UTCID05()
{
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(5,-5) == 0);
}
/* Test case 06 : Negative + Positive */
void CTestCalculator::UTCID06()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-5,2) == -3);
}
/* Test case 07 : Negative + Negative */
void CTestCalculator::UTCID07()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-4,-1) == -5);
}

CTestCalculator::~CTestCalculator(void)
{
}

