/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Account.h
* 
* Decription : Class Account
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
class Account
{
private:
	int nAccountID; // ID of the account
	int nCustID;    // ID of the customer who owned account
	int nTypeID;    // ID of the type of the account
	float fBalance; // Balance of the account
public:
	// This function used to set information of the account
	Account(int nAccountID,int nCustID,int nTypeID,float fBalance); 
	// This function used to get ID of the account
	int getAccountID();
	// This function used to get ID of the customer who owned the account
	int getCustID();
	// This function used to get ID of the type of the account
	int getTypeID();
	// This function used to get balance of the account
	float getBalance();
	// This function used to set information of the account
	void setAccountInfo(int nAccountID,int nCustID,int nTypeID,float fBalance);
};
