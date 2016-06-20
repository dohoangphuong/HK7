/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Account.cpp
* 
* Decription : Source file for class Account
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
#include "StdAfx.h"
#include "Account.h"
/**********************************************************
********
*++
* Method name : Account::Account ()
* Decription  : This method used to set information of the account
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : nAccountID, nCustID, nTypeID, fBalance
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
Account::Account(int nAccountID,int nCustID,int nTypeID,float fBalance) 
{
	this->nAccountID = nAccountID;
	this->nCustID = nCustID;
	this->nTypeID = nTypeID;
	this->fBalance = fBalance;
}
/**********************************************************
********
*++
* Method name : Account::getAccountID()
* Decription  : This method used to get ID of the account
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
int Account::getAccountID()
{
	return nAccountID;
}
/**********************************************************
********
*++
* Method name : Account::getAccountID()
* Decription  : This method used to get ID of the Customer
*               who owned the account
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : nCustID
*               
*--
***********************************************************
********/
int Account::getCustID()
{
	return nCustID;
}
/**********************************************************
********
*++
* Method name : Account::getAccountID()
* Decription  : This method used to get ID of the type
*               of the account
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : nTypeID
*               
*--
***********************************************************
********/
int Account::getTypeID()
{
	return nTypeID;
}
/**********************************************************
********
*++
* Method name : Account::getBalance()
* Decription  : This method used to get balance
*               of the account
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : fBalance
*               
*--
***********************************************************
********/
float Account::getBalance()
{
	return fBalance;
}
/**********************************************************
********
*++
* Method name : Account::getBalance()
* Decription  : This method used to set information
*               of the account
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : AccountID, CustID, TypeID, Balance
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
void Account::setAccountInfo(int AccountID,int CustID,int TypeID,float Balance)
{
	nAccountID = AccountID;
	nCustID = CustID;
	nTypeID = TypeID;
	fBalance = Balance;
}