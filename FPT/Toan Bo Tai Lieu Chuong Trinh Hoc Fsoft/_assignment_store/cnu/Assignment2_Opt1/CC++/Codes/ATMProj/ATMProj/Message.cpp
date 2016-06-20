/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Message.cpp
* 
* Decription :Source file for class Message
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
#include "Message.h"
/**********************************************************
********
*++
* Method name : Message::Message ()
* Decription  : Set information for message
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : nMessageID, sDescr, sDispText
* Global available   : no
* Return value : no return              
*--
***********************************************************
********/
Message::Message(int nMessageID,string sDescr,string sDispText)
{
	this->nMessageID = nMessageID;
	this->sDescr = sDescr;
	this->sDispText = sDispText;
	
}
/**********************************************************
********
*++
* Method name : Message::getMessageID()
* Decription  : This method used to get ID of the message
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : ID of the message
*               
*--
***********************************************************
********/
int Message::getMessageID()
{
	return nMessageID;
}
/**********************************************************
********
*++
* Method name : Message::getDescr()
* Decription  : This method used to get description
*               about the message
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter :   no
* Global available : no
* Return value : sDescr
*               
*--
***********************************************************
********/
string Message::getDescr()
{
	return sDescr;
}
/**********************************************************
********
*++
* Method name : Message::getDispText()
* Decription  : This method used to get display of message
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : sDispText
*               
*--
***********************************************************
********/
string Message::getDispText()
{
	return sDispText;
}
/**********************************************************
********
*++
* Method name : Message::ShowMessage()
* Decription  : This method used to show message
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
void Message::ShowMessage()
{
	cout<<sDispText<<endl;
}
/**********************************************************
********
*++
* Method name : Message::setMessage
* Decription  : This method used to set message
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : MessageID
* Global available : no 
* Return value : no
*               
*--
***********************************************************
********/
void Message::setMessage(int MessageID){
nMessageID = MessageID;
	if (nMessageID==1)
	{
		nMessageID = nMessageID;
		sDescr = "Error in Validate Card Process";
		sDispText = "Your Card Number is not valid\n";
	}
	if (nMessageID==2)
	{
		nMessageID = nMessageID;
		sDescr = "Error in interaction with file";
		sDispText = "Our system is out of service now\nPlease try again later!\n";
	}
	if (nMessageID==3)
	{
		nMessageID = nMessageID;
		sDescr = "Blocked Permanently Card";
		sDispText = "Your Card is blocked permanently!\nThe card will be swallowed...\n";
	}
	if (nMessageID==4)
	{
		nMessageID = nMessageID;
		sDescr = "Blocked Temporarily Card";
		sDispText = "Your Card is blocked temporarily!\nThe card will be ejected...\n";
	}
	if (nMessageID==5)
	{
		nMessageID = nMessageID;
		sDescr = "Card Number not exist in Database";
		sDispText = "Your Card Number is not valid!\n";
	}
	if (nMessageID==6)
	{
		nMessageID = nMessageID;
		sDescr = "AccountID not exist in Database";
		sDispText = "Your Card Number is not valid!\n";
	}
	if(nMessageID==7)
	{
		nMessageID = nMessageID;
		sDescr = "Customer not exist in Database";
		sDispText = " our Card Number is not valid!\n";
	}
}

void Message::DispMessage(int nMessageID)
{
	setMessage(nMessageID);
	cout<<getDispText()<<endl;
}
