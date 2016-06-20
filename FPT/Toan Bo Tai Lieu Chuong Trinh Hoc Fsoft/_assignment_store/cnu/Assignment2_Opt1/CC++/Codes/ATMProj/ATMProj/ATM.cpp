/**********************************************************
********
*++
* Author : C/C++ Team
* Module : ATM.cpp
* 
* Decription :Source file for class ATM
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
#include "ATM.h"
#include <time.h>
#include "stdafx.h"
#include "conio.h"
#include "stdio.h"
#include <iostream>
#include <string>
#include <sstream>
#include <cstdlib>
#include <fstream>
#include <vector>
#include <algorithm>
#include <functional>
#include <memory>
#include "Account.h"
#include "Card.h"
#include "Message.h"
#include "Customer.h"
#include "UI.h"
using namespace std;

#define __PATH__Card "Card.txt"
#define __PATH__Account "Account.txt"
#define __PATH__Customer "Customer.txt"
#define __PATH__Atm "ATM.txt"
#define __PATH__LogType "LogType.txt"
#define __PATH__CheckingAcc "CheckingACC.txt"
#define __PATH__SavingAcc "SavingACC.txt"
#define __PATH__Log "Log.txt"
// Set information of the Customer, Card, message, account
Customer cust(0,"");
Card card("","","",0);
Message message(0,"","");
Account acc(0,0,0,0);
UI ui(0,"");
string sCardID;
int nAccountID;

// Contructor
CATM::CATM(void)
{
	nCountMoney = 4;
	pToTal = new int[nCountMoney];
	for(int i=0;i<nCountMoney;i++)
	{
		pToTal[i] = 0; 
	}
	pValue = new int[nCountMoney];
	for(int i=0;i<nCountMoney;i++)
	{
		pValue[i] = 0; 
	}
	nLogTypeID = 1;
	nLogID = 0;
}
// Destructor
CATM::~CATM(void)
{
}
/**********************************************************
********
*++
* Method name : CATM::ReadFile
* Decription  : This method used to read data file
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : FileName
* Global available : no
* Return value : no 
*               
*--
***********************************************************
********/
void CATM::ReadFile(char* FileName)
{
	ifstream f;
	f.open(FileName);
	if(f.bad())
	{
		cout<<"file is nor valid";
		getch();
		exit(1);
	}
	f.seekg(0);
	string szTitle;
	getline(f,szTitle,'\n');
	string tem;
	m_A = new ATM[5];
	for(int i=0;i<5;i++)
	{
		m_A[i].nMoney = new int[3];
	}
	int j = 0;
	while(1)
	{
		f>>m_A[j].nATMID;
		getline(f,tem,'	');
		getline(f,m_A[j].szBranch,'	');
		getline(f,m_A[j].szAdress,'	');
		getline(f,m_A[j].szName,'	');
		f>>m_A[j].fW_Limit;
		for(int k=0;k<nCountMoney;k++)
		{
			f>>m_A[j].nMoney[k];
		}

		if(f.eof()) break;
		j++;
	}

	f.close();
	
}
/**********************************************************
********
*++
* Method name : CATM::CheckMin
* Decription  : This method used to find min value of money
*               in the ATM 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : A 
* Global available : no
* Return value : Min 
*               
*--
***********************************************************
********/
int CATM::CheckMin(int* A)
{
	int Min;
	Min = A[0];
	for(int i = 1;i<nCountMoney;i++)
	if(Min > A[i]) Min = A[i];
	return Min;
}
/**********************************************************************
* Name function: Readlog
* Description  : This function used to read transaction type in data file
* Input        : char *FileName -  name of file is read 
*				 int nLogTypeID -  type of transaction
* Output       : string         -  description of type transaction  
***********************************************************************/
string CATM::Readlog(int nLogTypeID,char* FileName)
{
	ifstream fL; // read file LogType
	fL.open("LogType.txt");
	if(fL.bad())
	{
		cout<<"file is nor valid";
		getch();
		exit(1);
	}
	fL.seekg(0);
	string* szTitle;
	szTitle = new string[2];
	for(int i = 0; i<2 ; i++)
	{
		getline(fL,szTitle[i],'	');
	}
	string szTemString;
	int    nTemInt;
	int	   j = 0;
	while(1)
	{
		fL>>nTemInt;
		if(nTemInt == nLogTypeID)
		{
			fL>>szTemString;
			break;
		}
		else
		getline(fL,szTemString,'\n');
		if(fL.eof()) break;
	}
	fL.close();
	delete[]szTitle;
	return szTemString;
}
/**********************************************************************
* Name function: WriteLog
* Description  : This function write transaction into database
* Input        : int nIDATM    -  ID of ATM
*				 string CardID -  ID of customer 's card
*				 int nLogTypeID- type transaction
*				 int nAmount   -  The money which customer chose withdraw
*				 int *FileName -  name of file is read 
* Output       :None
***********************************************************************/
void CATM::WriteLog(int nIDATM, string CardID,int nLogTypeID,int nAmount,char* FileName)
{
	ofstream f;
	f.open(FileName,ios::out | ios::app);
	time_t rawtime;
    struct tm * timeinfo;
    time ( &rawtime );
    timeinfo = localtime ( &rawtime );
	f<<nLogID<<'\t'<<timeinfo[0].tm_hour<<'\t'<<timeinfo[0].tm_mday<<'\t'<<timeinfo[0].tm_mon<<'\t'<<nAmount<<'\t'<<Readlog(nLogTypeID,"LogType.txt")<<'\t'<<nLogTypeID<<'\t'<<nIDATM<<'\t'<<CardID<<'\t'<<'\n';
	nLogID++;
}
/**********************************************************
********
*++
* Method name : CATM::PrintReceipt
* Decription  : This function confirm about print receipt 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : bool     1 - customer want to print receipt  
*                         0 - customer don't want to print receipt
*--
***********************************************************
********/
bool CATM::PrintReceipt()
{
	char sConfirm;
	cout<<"Do you want to print receipt? Y/N"<<endl;
	cin>>sConfirm;
	if (sConfirm == 'Y' || sConfirm == 'y')
	{
		return 1;
	}
	else
		return 0;
}
/**********************************************************
********
*++
* Method name : CATM::Check_ATM
* Decription  : This method used to check valid of the ATM 
*               to withdraw money
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : nAmount, nCount, nMoney, A[4] 
* Global available : no
* Return value : no 
*               
*--
***********************************************************
********/
void CATM::Check_ATM(int IDACC,int nIDATM, string CardID,int nAmount,int nCount ,int* nMoney,int* A)
{
		int nTotalMoney = 0;
		int nW_Money;
		int nReMain;
		int nIntPart;
		char sConfirm;
		nReMain = nAmount % A[nCount];   
		nIntPart = nAmount / A[nCount];	
		nW_Money = nAmount;
		if(nW_Money == 0) 
		{
			if(PrintReceipt()) cout<<"Please get receipt"<<endl;
			cout<<"Please get card"<<endl;
			cout<<"Please get"<<endl;
			for(int i=0;i<nCountMoney;i++)
			{
				if(pToTal[i]!= 0)
				cout<<pToTal[i]<<"*"<<pValue[i]<<endl;
				nTotalMoney = nTotalMoney + pToTal[i]*pValue[i];
			};
			nLogTypeID =2;
			WriteLog(nIDATM, CardID,nLogTypeID,nAmount,__PATH__Log);
			Modifi(IDACC,nTotalMoney,"Account.txt");
		}
		else
		{
			if(nIntPart <= nMoney[nCount] && nIntPart!= 0)
 			{
				pToTal[nCount] = nIntPart;
				pValue[nCount] = A[nCount];
				nW_Money = nW_Money - (nIntPart)*A[nCount];
				nMoney[nCount] = nMoney[nCount] - (nIntPart);
				nCount++;
				Check_ATM(IDACC,nIDATM, CardID,nW_Money ,nCount, nMoney,A);
			}
			else
			{
				if(A[nCount] == CheckMin(A) ) cout<<"can not withdraw money";		
				else
				{
					if(nW_Money<A[nCount])
					{
						nCount++;
						Check_ATM(IDACC,nIDATM, CardID,nW_Money ,nCount, nMoney,A);
					}
					else
					{
						pToTal[nCount] = nMoney[nCount];
						pValue[nCount] = A[nCount];
						nW_Money = nW_Money - (pToTal[nCount])*A[nCount];
						nMoney[nCount] = 0;
						nCount++;
						Check_ATM(IDACC,nIDATM, CardID,nW_Money ,nCount, nMoney,A);
					}
				}
			}
		}
}
/**********************************************************
********
*++
* Method name : CATM::ReadAcc
* Decription  : This method used to read account 
*              
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : FileName 
* Global available : no
* Return value : no 
*               
*--
***********************************************************
********/
void CATM::ReadAcc(char* FileName)
{
	ifstream f;
	f.open(FileName);
	if(f.bad())
	{
		cout<<"file is nor valid";
		getch();
		exit(1);
	}
	f.seekg(0);
	string* szTitle;
	szTitle = new string[2];
	for(int i = 0; i<2 ; i++)
	{
		getline(f,szTitle[i],'	');
	}
	string tem;
	m_Acc= new TypeACC[5];
	int j = 0;
	while(1)
	{
		f>>m_Acc[j].nTypeID;
		getline(f,tem,'	');
		f>>m_Acc[j].fValue;
		if(f.eof()) break;
		j++;
	}
	f.close();
}

/**********************************************************
********
*++
* Method name : CATM::CheckCard
* Decription  : This method used to check valid of Card 
*               to withdraw money
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : nTypeAcc,  fBalance, nMoney
* Global available : no
* Return value : 1 if withdraw successful 
*                0 if no successful
*--
***********************************************************
********/
bool CATM::CheckCard(int nTypeAcc, float fBalance, int nMoney)
{
	float nValueFromFile;
	m_Acc = new TypeACC[5];
	if(0 <= nTypeAcc && nTypeAcc <= 3)
	{
		ReadAcc("CheckingACC.txt");

	}
	else
		ReadAcc("SavingACC.txt");
	for(int i=0;i<5;i++)
	{
		if(m_Acc[i].nTypeID == nTypeAcc)
		{
			nValueFromFile = m_Acc[i].fValue;
		}
	}
	if(0 <= nTypeAcc && nTypeAcc <= 3)
	{
		if(nMoney <= fBalance + nValueFromFile)
			return 1;
		else return 0;

	}
	else
		if(nMoney <= nValueFromFile && nMoney <= fBalance)
			return 1;
		else return 0;
		delete []m_Acc;
}

/******************************************************************
* Name function: ChoseATM
* Description  : This function get information of ATM to check valid withdraw
* Input        : int nIDATM    -  ID ATM
*				 int nAmount   -  The money which customer withdraw
*				 int nTypeAcc  -  Type account is checking account or saving account
*				 float fBalance-  Balance of customize
* Output       : None
*******************************************************************/
void CATM::ChoseATM(int IDACC,int nIDATM, string CardID, int nAmount, int nTypeAcc,float fBalance)
{
	int* A;
	A = new int[nCountMoney];
	A[0] = 500;
	A[1] = 200;
	A[2] = 100;
	A[3] = 50;
	if(CheckCard(nTypeAcc, fBalance, nAmount))
	{
		m_A = new ATM[5];
		ReadFile(__PATH__Atm);
		for(int i= 0;i<5;i++)
		{
			if(m_A[i].nATMID == nIDATM)
			{
				Check_ATM(IDACC,nIDATM, CardID,nAmount,0 ,m_A[i].nMoney,A);

				break;
			}
		}
	}
	else
		cout<<"ERROR! Amount is not valid";
	delete[]A;
}

/**********************************************************
********
*++
* Function name : ValidateCard()
* Decription  : This function used to check validation 
*               of the Card
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : char c
*             int len
*             int check
* Global available : no
* Return value : 1 if validation successful
*                0 if no successful
*--
***********************************************************
********/
int CATM::ValidateCard()
{
	char c;
	int len;
	int found;
	c = getchar();
	if (c!='\0')
	{
		do
		   {
			    cust.InsertCard();
			    sCardID = card.readCard();
			    len = sCardID.length();
			    if(len!=6) 
				{
					//Length not valid
					message.DispMessage(1);
				}
			}
		while (len!=6);

		found = getCardStatus(sCardID);
		if (found==0)	{
			//Card infomation not found
			message.DispMessage(5);
		}
		if (found==3)	{
			//Permanently blocked card
			message.DispMessage(3);
		}
		if (found==4)	{
			//Temporarily blocked card
			message.DispMessage(4);
		}
		if (found==1) return 1; //Card is valid
	}
	return 0;
}
/**********************************************************
********
*++
* Function name : Authentication()
* Decription  : This function used to check authentication 
*               of the Card
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : string sPIN
* Global available : no
* Return value : 1 if validation successful
*                0 if no successful
*--
***********************************************************
********/
int CATM::Authentication()
{
	string sPIN;
	cust.EnterPIN();
	cin>>sPIN;
	if(sPIN.compare(card.getPIN())==0){
	return 1;
	}
	return 0;
}
/**********************************************************
********
*++
* Function name : MainMenu()
* Decription  : This function used to create main menu screen 
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	int c
	            int check
* Global available : no
* Return value : no
*--
***********************************************************
********/
void CATM::MainMenu()
{
	int c;
	int check;
	while (1)
	{
		ui.DisplayMainMenu();
		cin>>c;
		if (c==1)
		{
			cust.WithdrawMoney(acc.getAccountID(),card.getCardID(),acc.getTypeID(),acc.getBalance());
			getch();
			break;
		}
		else if (c==2)
		{
			cust.ChangePIN(card,acc);
			check=AskToContinue();
			if (check==0) break;
		}
		else if(c==3)
		{
			check = cust.ViewBalance(card,acc);
			check=AskToContinue();
			if (check==0) break;
		}
		else if(c==4)
		{
			break;
		}
		else
		{
			cout<<"Input is not valid!\nPress Enter to try again!\n";
			getch();
		}
	}
}
/**********************************************************
********
*++
* Function name : getCustName()
* Decription  : This function used to get customer's name
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string line
	            size_t found
	            int check
* Global available : 1 if get successful
* Return value :     0 if no successful
*--
***********************************************************
********/
int CATM::getCustName()
{
	string line;
	int found;
	ifstream readfile(__PATH__Account);
	if (!readfile) 
	{
		message.DispMessage(2);
		system("pause");
		return -1;
	}
	do
	{
		getline(readfile,line,'\n');
		found=getLineAccInfo(line);
		if (found==1) return 1;
	}
	while(!readfile.eof());
	message.DispMessage(6);
	return 0;
}

/**********************************************************
********
*++
* Function name : getLineAccInfo()
* Decription  : This function used to search for account in a line
*				and set data to account variable if valid
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string line
* Global available : 
* Return value :   1 if account is found
*                  0 if account is not found
*--
***********************************************************
********/
int CATM::getLineAccInfo(string line)
{
	string sStatus;
	string sAccountID;
	string sCustID;
	int nCustID;
	string sTypeID;
	int nTypeID;
	string sBalance;
	float fBalance;
	int begin=0;
	int end;
	int check;
	
	end = line.find('\t',begin+1);
	sAccountID=line.substr(begin+1,end-begin-1);
	nAccountID = atoi(sAccountID.c_str());
	if (nAccountID == card.getAccountID())
	{
		begin=end;
		end = line.find('\t',begin+1);
		sCustID=line.substr(begin+1,end-begin-1);
		nCustID = atoi(sCustID.c_str());
		begin=end;
		end = line.find('\t',begin+1);
		sTypeID=line.substr(begin+1,end-begin-1);
		nTypeID = atoi(sTypeID.c_str());
		begin=end;
		end = line.find('\t',begin+1);
		sBalance=line.substr(begin+1,end-begin-1);
		fBalance = atof(sBalance.c_str());
		acc.setAccountInfo(nAccountID,nCustID,nTypeID,fBalance);
		check = getName();
		return 1;
	}
	return 0;
}

/**********************************************************
********
*++
* Function name : getName()
* Decription  : This function used to get customer's name
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string line
	            size_t found
	            int check
* Global available : 
* Return value :   1 if get successful  
                   0 if no successful
*--
***********************************************************
********/
int CATM::getName()
{
	string line;
	int found;
	//int check;
	ifstream readfile(__PATH__Customer);
	if (!readfile) {
			//message 2: can not open data file
			message.DispMessage(2);
			system("pause");
			return -1;// system error
	}
	do
	{
		getline(readfile,line,'\n');
		found = getLineCustInfo(line);
		if (found==1) return 1;
	}
	while(!readfile.eof());
	//message 07: Customer is not exist in database
	message.DispMessage(7);
	return 0;
}

/**********************************************************
********
*++
* Function name : getLineCustInfo()
* Decription  : This function used to search for cust in a line
*				and set data to customer variable if valid
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string line
* Global available : 
* Return value :   1 if customer is found
*                  0 if customer is not found
*--
***********************************************************
********/
int CATM::getLineCustInfo(string line)
{
	string sCustID;
	int nCustID;
	string sName;
	int begin = 0;
	int end;

	end = line.find('\t',begin+1);
	sCustID=line.substr(begin+1,end-begin-1);
	nCustID = atoi(sCustID.c_str());
	if(nCustID == acc.getCustID())
	{
		begin=end;
		end = line.find('\t',begin+1);
		sName=line.substr(begin+1,end-begin-1);
		cust.setCustInfo(nCustID,sName);
		return 1;
		
	}
	return 0;
}

/**********************************************************
********
*++
* Function name : AskToContinue()
* Decription  : This function used to get customer's dicision
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string Continue
* Global available : 
* Return value :   1 if Customer wants to continue  
                   0 if Customer doesnt want to continue
*--
***********************************************************
********/
int CATM::AskToContinue(){
	char Continue;
	cout<<"\n\n\n Do you want any action if yes press Y else press N: ";
	cin>>Continue;
	if (Continue=='N'||Continue=='n')
			return 0;
	return 1;
}

/**********************************************************
********
*++
* Function name : getCardData()
* Decription  : This function used to search for card in file
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string sCardID
* Global available : 
* Return value :   1 if card is valid
*				   3 if card is blocked permanently
*				   4 if card is blocked temporarily
*                  0 if card is not found
*--
***********************************************************
********/
int CATM::getCardStatus(string sCardID){
	int found;
	string line;

	ifstream readfile(__PATH__Card);
	if (!readfile) 
	{
		message.DispMessage(2);
		system("pause");
		return -1;
	}
	do
	{
		getline(readfile,line,'\n');
		found = getLineCardInfo(line,sCardID);
		if (found!=0) return found;
	}
	while (!readfile.eof());
	return 0;
}

/**********************************************************
********
*++
* Function name : getLineCardInfo()
* Decription  : This function used to search for card in a line
*				and set data to card variable if valid
*               
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : 	string line, string sCardID
* Global available : 
* Return value :   1 if card is valid
*				   3 if card is blocked permanently
*				   4 if card is blocked temporarily
*                  0 if card is not found
*--
***********************************************************
********/
int CATM::getLineCardInfo(string line, string sCardID)
{
	int check;
	size_t found;
	string sPIN;
	string sStatus;
	string sAccountID;
	string sCustName;
	int begin;
	int end;

	found=line.find(sCardID);
	if (found!=string::npos && int(found)==0)
	{
		begin=line.find('\t');
		end = line.find('\t',begin+1);
		sStatus=line.substr(begin+1,end-begin-1);
		if (sStatus.compare("Valid")==0)
		{				
			begin=end;
			end = line.find('\t',begin+1);
			sAccountID=line.substr(begin+1,end-begin-1);
			nAccountID = atoi(sAccountID.c_str());
			begin=end;
			end = line.find('\t',begin+1);
			sPIN=line.substr(begin+1,end-begin-1);
			card.setCardInfo(sCardID,sPIN,sStatus,nAccountID);
			check = getCustName();
			ui.WelcomeCustomer(cust.getName());
			return 1;
		 }
		else if (sStatus.compare("PerBlock")==0){
			return 3;
		}
		else if (sStatus.compare("TemBlock")==0){
			return 4;
		} 		
	}
	return 0;
}
void  CATM::Modifi(int szAcc,int nMoney, char* FileName)
{
	fstream f; 
	int len;
	int nTemint ;
	f.open(FileName,ios::in|ios::out);
	if(f.bad())
	{
		cout<<"file is nor valid";
		getch();
		exit(1);
	}
	f.seekg(0);
	string* szTitle;
	szTitle = new string[4];
	for(int i = 0; i<4 ; i++)
	{
		getline(f,szTitle[i],'	');
	}
	string szTemString;
	int	   j = 0;
	string Acc;
	int cus;
	int type;
	int balan;
	while(1)
	{
		f>>szTemString;
		nTemint = atoi(szTemString.c_str());
		if(szAcc == nTemint)
		{
			f>>cus;
			getline(f,szTemString,'	');
			f>>type;
			getline(f,szTemString,'	');
			f.seekg(0,ios::cur);
			len = f.tellg();
			f>>balan;
			nMoney = balan - nMoney;
			f.seekg(len);
			f<<nMoney<<'\t'<<'\n';
			f.close();
			break;
		}
		else
		getline(f,szTemString,'\n');
		if(f.eof()) break;
	}
	f.close();
}
