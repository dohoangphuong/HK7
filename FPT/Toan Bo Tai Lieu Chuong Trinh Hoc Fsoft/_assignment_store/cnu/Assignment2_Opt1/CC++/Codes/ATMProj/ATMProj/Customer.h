/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Customer.h
* 
* Decription : Class Customer
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
#include "Card.h"
#include "Account.h"
using namespace std;
class Customer
{
private:
	int nCustID;  // ID of customer
	string sName; // Name of customer
	
public:
	// Customer function
	Customer(int nCustID,string sName); 
	// This function used to get ID of customer
	int getCustID();
	// This function used to name of customer
	string getName();
	// This function used to insert customer's card
	void InsertCard();
	// This function used for customer to enter PIN
	void EnterPIN();
	// This function used to set information of customer
	void setCustInfo(int nCustID,string sName);
	// This function used to change PIN
	int ChangePIN(Card card,Account Acc);
	//This function used to save new PIN to database
	void Write_file(string sCardID,string sPin,char* FileName);
	// This function used to view customer's balance
	int ViewBalance(Card card,Account Acc);
	// This function used to withdraw money
	void WithdrawMoney(int IDACC,string IDCard, int nTypeAcc,float fBalance);
};
