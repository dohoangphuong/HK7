/*********************************************************************************
*++
*Author: HongLTB
*Module Name: Card.cpp
*Description: Source file for class Card
*Mod.History:
*            + 30.07.2012 - Created 
*
*
*
*********************************************************************************/

#include "StdAfx.h"
#include "Card.h"

Card::Card(string sCardID,string sPIN,string sStatus,int nAccountID){

			this->sCardID = sCardID;
			this->sPIN = sPIN;
			this->sStatus = sStatus;
			this->nAccountID = nAccountID;

      }

string Card::getCardID() {

            return sCardID;
    }

string Card::getPIN() {

            return sPIN;
     }

string Card::getStatus() {

            return sStatus;
     }

int Card::getAccountID() {

            return nAccountID;
      }

string Card::readCard() {
	//cin.ignore(1);
	cin>>sCardID;
	cout<<sCardID<<endl;
	return sCardID;
}

void Card::changeCardID(string s){

	sCardID=s;
}

void Card::setCardInfo(string CardID,string PIN,string Status,int AccountID){
	sCardID = CardID;
	sPIN = PIN;
	sStatus = Status;
	nAccountID = AccountID;
}