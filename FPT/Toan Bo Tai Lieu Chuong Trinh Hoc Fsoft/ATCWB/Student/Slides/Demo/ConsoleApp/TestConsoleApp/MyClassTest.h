#pragma once
#include "MyClass.h"
#include <cppunit\TestFixture.h>
#include <cppunit\extensions\HelperMacros.h>

class MyClassTest : public CPPUNIT_NS::TestFixture {
    CPPUNIT_TEST_SUITE(MyClassTest);
    CPPUNIT_TEST(testAdd);
    CPPUNIT_TEST_SUITE_END();
public:
    MyClassTest(void);
    ~MyClassTest(void);

    void testAdd();
};

