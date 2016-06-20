// TestConsoleApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ComFuncTest.h"
//#include <cppunit/CompilerOutputter.h>
//#include <cppunit/extensions/TestFactoryRegistry.h>
//#include <cppunit/ui/text/TestRunner.h>

#include <cppunit/BriefTestProgressListener.h>
#include <cppunit/CompilerOutputter.h>
#include <cppunit/extensions/TestFactoryRegistry.h>
#include <cppunit/TestResult.h>
#include <cppunit/TestResultCollector.h>
#include <cppunit/TestRunner.h>

int _tmain(int argc, _TCHAR* argv[])
{
	//// Get the top level suite from the registry
	//CPPUNIT_NS::Test *suite = CPPUNIT_NS::TestFactoryRegistry::getRegistry().makeTest();

	//// Adds the test to the list of test to run
	//CPPUNIT_NS::TextUi::TestRunner runner;
	//runner.addTest( suite );

	//// Change the default outputter to a compiler error format outputter
	//runner.setOutputter( new CPPUNIT_NS::CompilerOutputter( &runner.result(),
	//														CPPUNIT_NS::stdCOut() ) );
	//// Run the test.
	//bool wasSucessful = runner.run();

	//// Return error code 1 if the one of test failed.
	//return wasSucessful ? 0 : 1;

    // Create the event manager and test controller
    CPPUNIT_NS::TestResult controller;

    // Add a listener that colllects test result
    CPPUNIT_NS::TestResultCollector result;
    controller.addListener( &result );        

    // Add a listener that print dots as test run.
    CPPUNIT_NS::BriefTestProgressListener progress;
    controller.addListener( &progress );      

    // Add the top suite to the test runner
    CPPUNIT_NS::TestRunner runner;
    runner.addTest( CPPUNIT_NS::TestFactoryRegistry::getRegistry().makeTest() );
    runner.run( controller );

    // Print test in a compiler compatible format.
    CPPUNIT_NS::CompilerOutputter outputter( &result, CPPUNIT_NS::stdCOut() );
    outputter.write(); 

	// wait user to press any key
	system("pause");

    return result.wasSuccessful() ? 0 : 1;
}

