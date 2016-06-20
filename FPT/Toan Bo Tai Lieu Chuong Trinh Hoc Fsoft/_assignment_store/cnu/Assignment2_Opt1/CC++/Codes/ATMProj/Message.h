#pragma once
#include "stdafx.h"
#include "conio.h"
#include "stdio.h"
#include <iostream>
#include <string>
#include <sstream>
using namespace std;

class Message
{
private:
	int nMessageID;
	string sDescr;
	string sDispText;
public:
	Message(int wMessageID,string sDescr,string sDispText); 

	int getMessageID();

	string getDescr();

	string getDispText();

	void ShowMessage();

	void setMessage(int nMessageID);
};
