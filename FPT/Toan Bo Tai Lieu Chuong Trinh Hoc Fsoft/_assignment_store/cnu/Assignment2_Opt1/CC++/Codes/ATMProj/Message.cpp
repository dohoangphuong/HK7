/*********************************************************************************
*++
*Author: HongLTB
*Module Name: Message.cpp
*Description: Source file for class Message
*Mod.History:
*            + 30.07.2012 - Created 
*
*
*
*********************************************************************************/
#include "StdAfx.h"
#include "Message.h"

Message::Message(int nMessageID,string sDescr,string sDispText)
{
	this->nMessageID = nMessageID;
	this->sDescr = sDescr;
	this->sDispText = sDispText;
	
}

int Message::getMessageID()
{
	return nMessageID;
}

string Message::getDescr()
{
	return sDescr;
}

string Message::getDispText()
{
	return sDispText;
}

void Message::ShowMessage(){
	cout<<sDispText<<endl;
}

void Message::setMessage(int nMessageID){

	if(nMessageID==1){
		nMessageID = nMessageID;
		sDescr = "Error in Validate Card Process";
		sDispText = " Your Card Number is not valid\n";
	}
	if(nMessageID==2){
		nMessageID = nMessageID;
		sDescr = "Error in interaction with file";
		sDispText = " Our system is out of service now\nPlease try again later\n";
	}
	if(nMessageID==3){
		nMessageID = nMessageID;
		sDescr = "Blocked Permanently Card";
		sDispText = " Your Card Number is blocked permanently!\nThe card will be swallowed\n";
	}
	if(nMessageID==4){
		nMessageID = nMessageID;
		sDescr = "Blocked Temporarily Card";
		sDispText = " Your Card Number is blocked temporarily!\nThe card will be ejected\n";
	}
	if(nMessageID==5){
		nMessageID = nMessageID;
		sDescr = "Card Number not exist in Database";
		sDispText = " Your Card Number is not valid\n";
	}
	if(nMessageID==6){
		nMessageID = nMessageID;
		sDescr = "AccountID not exist in Database";
		sDispText = " Your Card Number is not valid\n";
	}
	if(nMessageID==7){
		nMessageID = nMessageID;
		sDescr = "Customer not exist in Database";
		sDispText = " Your Card Number is not valid\n";
	}
}