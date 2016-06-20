/*********************************************************************************
*++
*Author: HongLTB
*Module Name: ATM.cpp
*Description: Source file for class ATM
*Mod.History:
*            + 30.07.2012 - Created 
*
*
*
*********************************************************************************/
#include "StdAfx.h"
#include "ATM.h"

ATM::ATM(int nATMID,string sBranch,float fWithdrawLimit,float fBalance)
{
	this->nATMID = nATMID;
	this->sBranch = sBranch;
	this->fWithdrawLimit = fWithdrawLimit;
	this->fBalance = fBalance;
}

int ATM::getATMID()
{
	return nATMID;
}

string ATM::getBranch(){

	return sBranch;
}

float ATM::getWithdrawLimit(){

	return fWithdrawLimit;
}

float ATM::getBalance(){

	return fBalance;
}

void ATM::ejectCard(){
	
	cout<<"Please receive your card!\n";
}