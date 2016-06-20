#pragma once
#include <cppunit/extensions/HelperMacros.h>
class CTestCalculator: public CPPUNIT_NS::TestFixture
{
	CPPUNIT_TEST_SUITE(CTestCalculator);	
	CPPUNIT_TEST(UTCID01);
	CPPUNIT_TEST(UTCID02);
	CPPUNIT_TEST(UTCID03);
	CPPUNIT_TEST(UTCID04);
	CPPUNIT_TEST(UTCID05);
	CPPUNIT_TEST(UTCID06);
	CPPUNIT_TEST(UTCID07);	
	CPPUNIT_TEST_SUITE_END ();

public:
	CTestCalculator(void);

	void UTCID01();
	void UTCID02();
	void UTCID03();
	void UTCID04();
	void UTCID05();
	void UTCID06();
	void UTCID07();
	
	~CTestCalculator(void);
};
CPPUNIT_TEST_SUITE_REGISTRATION (CTestCalculator);