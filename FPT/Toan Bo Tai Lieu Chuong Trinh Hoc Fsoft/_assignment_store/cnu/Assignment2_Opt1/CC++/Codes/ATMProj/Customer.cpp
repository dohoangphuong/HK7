/*********************************************************************************
*++
*Author: HongLTB
*Module Name: Customer.cpp
*Description: Source file for class Customer
*Mod.History:
*            + 30.07.2012 - Created 
*
*
*
*********************************************************************************/
#include "StdAfx.h"
#include "Customer.h"

Customer::Customer(int nCustID,string sName)
{
	this->nCustID = nCustID;
	this->sName = sName;
}

int Customer::getCustID()
{
	return nCustID;
}

string Customer::getName(){

	return sName;
}

void Customer::InsertCard(){
	
	cout<<"Please insert your Card Number (6 digits): ";
}

void Customer::EnterPIN(){

	cout<<"Please enter your PIN: ";
}

void Customer::setCustInfo(int CustID,string Name){

	nCustID=CustID;
	sName=Name;
}