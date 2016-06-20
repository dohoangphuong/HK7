#pragma once
#include "stdafx.h"
#include "conio.h"
#include "stdio.h"
#include <iostream>
#include <string>
#include <sstream>
using namespace std;

class Customer
{
private:
	int nCustID;
	string sName;
	
public:
	Customer(int nCustID,string sName); 

	int getCustID();
	string getName();
	void InsertCard();
	void EnterPIN();
	
	void setCustInfo(int nCustID,string sName);
	
};
