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
#include <cstdlib>
#include <fstream>
#include <vector>
#include <algorithm>
#include <functional>
#include <memory>
using namespace std;


class UI
{
private:
	int nScreenID;  // ID of message
	string sDescr;   // Decription of message
	//string sDispScreen;// The text to display
public:
    // This function is used to execute UI screen
	UI(int nScreenID,string sDescr); 
	// This function is used to get message ID
	int getScreenID();
	// This function is used to get description of message
	string getDescr();
	// This function is used to display welcome screen
	void DisplayWelcome();
	// This function is used to display welcome screen to specified customer
	void WelcomeCustomer(string sName);
	// This function is used to display main menu
	void DisplayMainMenu();
};
