#include "conio.h"
#include <string>
#include <iostream>
#include <cppunit/CompilerOutputter.h>
#include <cppunit/extensions/TestFactoryRegistry.h>
#include <cppunit/TestResult.h>
#include <cppunit/TestResultCollector.h>
#include <cppunit/TestRunner.h>
#include <cppunit/BriefTestProgressListener.h>
#include <cppunit/XmlOutputter.h>
using namespace std;

int main()
{
    CPPUNIT_NS :: TestResult TestedResult;

    // register listener for collecting the test-results
    CPPUNIT_NS :: TestResultCollector CollectedResults;
    TestedResult.addListener(&CollectedResults);

    // register listener for per-test progress output
    CPPUNIT_NS :: BriefTestProgressListener progress;
    TestedResult.addListener(&progress);

    // insert test-suite at test-runner by registry
    CPPUNIT_NS :: TestRunner Runner;
    Runner.addTest(CPPUNIT_NS :: TestFactoryRegistry :: getRegistry().makeTest());
    Runner.run(TestedResult);

    // output results in compiler-format
    CPPUNIT_NS :: CompilerOutputter Outputter(&CollectedResults, std::cerr);
    Outputter.write();

	// writing result on a XML file
std::ofstream xmlFileOut("testresults.xml");
	CppUnit::XmlOutputter xmlOut(&CollectedResults, xmlFileOut);
	xmlOut.write();

	/* wait user to press any key */
	system("pause");
// return 0 if tests were successful
    	return CollectedResults.wasSuccessful () ? 0: 1;
	
} 
