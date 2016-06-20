#pragma once
#include "ComFunc.h"
#include <cppunit/TestFixture.h>
#include <cppunit/extensions/HelperMacros.h>

class CComFuncTest : public CppUnit::TestFixture {
	CPPUNIT_TEST_SUITE( CComFuncTest );
    CPPUNIT_TEST( testAdd_N_1 );
    CPPUNIT_TEST_SUITE_END();
public:
	CComFuncTest(void);
	~CComFuncTest(void);

	void testAdd_N_1();
};

