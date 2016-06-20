/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Message.h
* 
* Decription : Class Message
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Mod.History : 31/07/2012 - Created
*                            ATM Application
*                            Decription : design a ATM in 
*                                         condole 
*                                         application
***********************************************************
********/
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
	int nMessageID;  // ID of message
	string sDescr;   // Decription of message
	string sDispText;// The text to display
public:
    // This function used to execute message
	Message(int nMessageID,string sDescr,string sDispText); 
	// This function used to get message ID
	int getMessageID();
	// This function used to get description of message
	string getDescr();
	// This function used to get display of message
	string getDispText();
	// This function used to show message
	void ShowMessage();
	// This function used to set message
	void setMessage(int nMessageID);
	// This function used to set and display message
	void DispMessage(int nMessageID);
};
