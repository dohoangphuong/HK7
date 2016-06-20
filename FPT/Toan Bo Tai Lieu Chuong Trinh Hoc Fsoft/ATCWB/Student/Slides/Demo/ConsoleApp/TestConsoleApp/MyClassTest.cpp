#include "StdAfx.h"
#include "MyClassTest.h"

CPPUNIT_TEST_SUITE_REGISTRATION( MyClassTest );

MyClassTest::MyClassTest(void)
{
}


MyClassTest::~MyClassTest(void)
{
}

void MyClassTest::testAdd() {
    MyClass obj;
    int nResult = obj.Add(1, 2);
    CPPUNIT_ASSERT_EQUAL(3, nResult);
}