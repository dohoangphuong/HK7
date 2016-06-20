#include "TestCalculator.h"
#include "Calculator.h"
#include "Calculator.cpp"
#include <limits.h>

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
	CPPUNIT_ASSERT(cal.Addition(-5,3) == -2);
}
/* Test case 07 : Negative + Negative */
void CTestCalculator::UTCID07()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-4,-1) == -5);
}
/* Test case 08 : Negative + Negative -> check case Addition out of range Negative */
void CTestCalculator::UTCID08()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-2147483648,-5) == -2147483648);	
}
/* Test case 09 : Positive + Positive -> check case Addition out of range Positive */
void CTestCalculator::UTCID09()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(2147483647,10) == 2147483647);	
}
/* Test case 10 : n + zero -> check case Addition Negative Boundary (n) */
void CTestCalculator::UTCID10()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-2147483648,0) == -2147483648);	
}

/* Test case 11 : Negative + Negative -> check case Addition Negative Boundary (n) */
void CTestCalculator::UTCID11()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-2147483645,-3) == -2147483648);	
}
/* Test case 12 : n + Zero -> check case Addition Positive Boundary (n) */
void CTestCalculator::UTCID12()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(2147483647,0) == 2147483647);	
}
/* Test case 13 : Positive + Positive -> check case Addition Positive Boundary (n) */
void CTestCalculator::UTCID13()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(2147483640,7) == 2147483647);	
}
/* Test case 14 : n + n. */
void CTestCalculator::UTCID14()
{	
	CCalculator cal;
	CPPUNIT_ASSERT(cal.Addition(-2147483648,2147483647) == -1);	
}

CTestCalculator::~CTestCalculator(void)
{
}

