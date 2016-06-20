#pragma once
#include<iostream>
#include<fstream>
#include<iomanip>
#include<stdlib.h>
#include<ctype.h>
#include<conio.h>
#include <stdio.h>
#include <string>
using namespace std;

/**********************************************************
********
*++
* Author : C/C++ Team
* Module : ATM.h
* 
* Decription : Class ATM
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
struct ATM
{   
	string szBranch;  // Branch of the bank manage the ATM
	string szAdress;  // Address of the ATM
	string szName;    // Name of the ATM
	float  fW_Limit;  // Withdraw limit of the bank manage the ATM
	int*   nMoney ;   // Type of money bill in the ATM
	int    nATMID;    // ID of the ATM
};   
struct TypeACC
{   
	int   nTypeID;    // ID of the type of one account
	float fValue;     // Amount of momey in account
};
class CATM
{
private:
	ATM *m_A;
	TypeACC* m_Acc;
	int nCountMoney;
	int* pToTal;
	int* pValue;
	int nLogTypeID;
	int nLogID;
public:
	// This function used to read data file in database
	void ReadFile(char* FileName);
	// This function used to read Account in data file
	void ReadAcc(char* FileName);
	// This function used to read transaction type in data file
	string Readlog(int nLogTypeID,char* FileName);
	// This function confirm about print receipt
	bool PrintReceipt();
	// This function used to check validate of Card balance when withdraw money
	// This function used to write information into data file
	void WriteFile(char* FileName);
	// This function used to check validate of Card when withdraw money
	bool CheckCard(int nTypeAcc, float fBalance, int nMoney);
	// This function used to check validate of ATM when withdraw money
    void Check_ATM(int IDACC,int nIDATM, string CardID,int nAmount,int nCount ,int* nMoney,int* A);
	// This function used to choose ATM
	void ChoseATM(int IDACC,int nIDATM, string CardID,int nAmount, int nTypeAcc,float fBalance);
	// This function used to find min value money of the ATM
	int  CheckMin(int* A);
	// This function used to write transaction information into database
	void WriteLog(int nIDATM, string CardID,int nLogTypeID,int nAmount,char* FileName);
	CATM(void); // Constructor
	~CATM(void);// Destructor
	void DisplayWelcome();//this function used to creat welcome screen
	int ValidateCard();//this function used to check validation of Card
	int Authentication();//this function used to check authentication of PIN
	void MainMenu();//show menu screen as options to user choose
	int getCustName();/*this function used to get Customer's name and 
						write information of customer, ACC*/
	int getName();//Sub-function of getCustName() used to find Customer.txt file
	int AskToContinue();// Ask Customer if he/she wants to continue other transaction
	int getCardStatus(string sCardID);//Read file Card.txt to get infomation of a card
	int getLineCardInfo(string line,string sCardID);//Search for card infomation in each line
	int getLineAccInfo(string line);//Search for account infomation in each line
	int getLineCustInfo(string line);//Search for customer infomation in each line
	void Modifi(int szAcc, int nMoney,char* FileName);// This function used to fix information into database

};

