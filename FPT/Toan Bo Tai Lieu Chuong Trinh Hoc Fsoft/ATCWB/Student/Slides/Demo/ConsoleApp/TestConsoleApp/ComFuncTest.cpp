#include "StdAfx.h"
#include "ComFuncTest.h"

CPPUNIT_TEST_SUITE_REGISTRATION(CComFuncTest);

CComFuncTest::CComFuncTest(void)
{
}


CComFuncTest::~CComFuncTest(void)
{
}

void CComFuncTest::testAdd_N_1() {
	CComFunc comFunc;
	int nResult = comFunc.Add(1, 2);
	CPPUNIT_ASSERT_EQUAL(3, nResult);
}