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
	int nAccountID;
	int nCustID;
	int nTypeID;
	float fBalance;

public:
	Account(int nAccountID,int nCustID,int nTypeID,float fBalance); 

	int getAccountID();
	int getCustID();
	int getTypeID();
	float getBalance();

	void setAccountInfo(int nAccountID,int nCustID,int nTypeID,float fBalance);
	
};
