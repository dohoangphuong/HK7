#pragma once
#include "stdafx.h"
#include "conio.h"
#include "stdio.h"
#include <iostream>
#include <string>
#include <sstream>
using namespace std;

class ATM
{
private:
	int nATMID;
	string sBranch;
	float fWithdrawLimit;
	float fBalance;
	
public:
	ATM(int nATMID,string sBranch,float fWithdrawLimit,float fBalance); 

	int getATMID();

	string getBranch();

	float getWithdrawLimit();

	float getBalance();

	void ejectCard();

};