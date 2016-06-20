/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Card.cpp
* 
* Decription :Source file for class Card
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
#include "Card.h"
/**********************************************************
********
*++
* Method name : Card::Card ()
* Decription  : This method used to set information for Card
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : sCardID, sPIN, sStatus, nAccountID
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
Card::Card(string sCardID,string sPIN,string sStatus,int nAccountID)
{
	this->sCardID = sCardID;
	this->sPIN = sPIN;
	this->sStatus = sStatus;
	this->nAccountID = nAccountID;
}
/**********************************************************
********
*++
* Method name : Card::getCardID()
* Decription  : This method used to get ID of the Card
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
string Card::getCardID() 
{
    return sCardID;
}
/**********************************************************
********
*++
* Method name : Card::getPIN()
* Decription  : This method used to get PIN of the Card
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
string Card::getPIN() 
{
	return sPIN;
}
/**********************************************************
********
*++
* Method name : Card::getStatus()
* Decription  : This method used to get Status of the Card
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
string Card::getStatus() 
{
	return sStatus;
}
int Card::getAccountID()
{
    return nAccountID;
}
/**********************************************************
********
*++
* Method name : Card::readCard()
* Decription  : This method used to read Card
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
string Card::readCard()
{
	cin>>sCardID;
	return sCardID;
}
/**********************************************************
********
*++
* Method name : Card::changeCardID
* Decription  : This method used to change ID of the Card
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : s
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
void Card::changeCardID(string s)
{
	sCardID=s;
}
/**********************************************************
********
*++
* Method name : Card::setCardInfo()
* Decription  : This method used to set information of the Card
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : CardID, PIN, AccountID
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
void Card::setCardInfo(string CardID,string PIN,string Status,int AccountID)
{
	sCardID = CardID;
	sPIN = PIN;
	sStatus = Status;
	nAccountID = AccountID;
}