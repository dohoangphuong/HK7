/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Card.h
* 
* Decription : Class Card
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
class Card
{
private:
	string sCardID;  // ID of the Card
	string sPIN;     // PIN of the Card
	string sStatus;  // Status of the card
	int nAccountID;  // ID of the account owned Card
public:
	// This function used to set parameter for Card
	Card(string sCardID,string sPIN,string sStatus,int nAccountID); 
	// This function used to get ID of the Card
	string getCardID();
	// This function used to get PIN of the Card
	string getPIN();
	// This function used to get Status of the Card
	string getStatus();
	// This function used to account owned Card
	int getAccountID();
	// This function used to read Card
	string readCard();
	// This function used to change Card's ID
	void changeCardID(string s);
	// This function used to set information of the Card
	void setCardInfo(string sCardID,string sPIN,string sStatus,int nAccountID);
};
