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
	string sCardID;
	string sPIN;
	string sStatus;
	int nAccountID;
	
public:
	Card(string sCardID,string sPIN,string sStatus,int nAccountID); 

	string getCardID();
	string getPIN();
	string getStatus();
	int getAccountID();

	string readCard();
	void changeCardID(string s);
	void setCardInfo(string sCardID,string sPIN,string sStatus,int nAccountID);
};
