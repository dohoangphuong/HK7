/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Customer.cpp
* 
* Decription :Source file for class Customer
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
#include "Customer.h"
#include "Card.h"
#include "Account.h"
#include "ATM.h"
#include "UI.h"
#include "windows.h"
/**********************************************************
********
*++
* Method name : Customer::Customer
* Decription  : This method used to set information of the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : nCustID, sName
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
Customer::Customer(int nCustID,string sName)
{
	this->nCustID = nCustID;
	this->sName = sName;
}
/**********************************************************
********
*++
* Method name : Customer::getCustID()
* Decription  : This method used to get ID of the
*               customer
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
int Customer::getCustID()
{
	return nCustID;
}
/**********************************************************
********
*++
* Method name : Customer::getName()
* Decription  : This method used to get name of the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : no
* Global available : no
* Return value : sName
*               
*--
***********************************************************
********/
string Customer::getName()
{
	return sName;
}
/**********************************************************
********
*++
* Method name : Customer::InsertCard()
* Decription  : This method used to insert Card of the
*               customer
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
void Customer::InsertCard()
{
	cout<<"\n\n\nPlease insert your Card Number (6 characters): ";
}
/**********************************************************
********
*++
* Method name : Customer::EnterPIN()
* Decription  : This method used to enter PIN of the
*               customer
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
void Customer::EnterPIN()
{
	cout<<"\n\nPlease enter your PIN: ";
}
/**********************************************************
********
*++
* Method name : Customer::setCustInfo()
* Decription  : This method used to set information of the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : CustID, Name
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
void Customer::setCustInfo(int CustID,string Name)
{
	nCustID=CustID;
	sName=Name;
}
/**********************************************************
********
*++
* Method name : Write_file
* Decription  : This method used to save new PIN of the
*               customer to database
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : sCardID, sPin,FileName
* Global available : no
* Return value : 
*                
*--
***********************************************************
********/
void Customer::Write_file(string sCardID,string sPin, char *FileName)
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
	for(int i = 0; i<3 ; i++)
	{
		getline(f,szTitle[i],'	');
	}
	string szTemString;
	int	   j = 0;
	string CardID;
	string Status;
	int AccountID;
	string PIN;
	while(1)
	{
		f>>szTemString;
		if(sCardID == szTemString)
		{
			f>>Status;
			getline(f,szTemString,'	');
			f>>AccountID;
			getline(f,szTemString,'	');
			f.seekg(0,ios::cur);
			len = f.tellg();
			f.seekg(len);
			f<<sPin<<'\t'<<'\n';
			f.close();
			break;
		}
		else
		getline(f,szTemString,'\n');
		if(f.eof()) break;
	}
	f.close();
}
/**********************************************************
********
*++
* Method name : Customer::ChangePIN
* Decription  : This method used to change PIN of the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : Card, Acc
* Global available : no
* Return value :  0 if successful
*                -1 if no successful
*--
***********************************************************
********/
int Customer::ChangePIN(Card card,Account Acc){
	string sPin=card.getPIN();
	string sCardID=card.getCardID();
    int n=1;
	int length;
	string sOldPINCode,sNewPINCode,sPINCode;
	UI ui(0,"");
	ui.DisplayCheckPIN();
	do
	{
		cout<<"\n\n\nEnter Old PIN Code: ";
		cin.ignore(1);
		cin>>sOldPINCode;
		if(sOldPINCode!=sPin)
		  {
			cout<<"\n\nIncorect Old Pin\n";
			n=n+1;
          }
        else
		  {
		       do
               {	
        	        cout<<"\nPlease enter new PIN Code...Note!"<<endl;
					cout<<"New PIN must be defferent old PIN and length =6\n";
					cout<<"New PIN code: ";
        	        cin>>sNewPINCode;
	                //cout<<"Length of PINCode:"<<sNewPINCode.length()<<endl;
                    if (sNewPINCode.length()==6&&sOldPINCode!=sNewPINCode)
	                {
                       do
				            {
								cout<<"Re-enter new PIN code: ";
								cin>>sPINCode;
								//cout<<"Length of PINCode:"<<sPINCode.length()<<endl;
								if (sPINCode==sNewPINCode)
								{
									sPin=sPINCode;
									cout<<"\nYour PIN code changed succesfully!\n";
									Write_file(sCardID,sPin,"Card.txt");
									return 0;
									break;
								}
							}
                        while (true); 
		                cout<<"\nIncorect new PIN\n";	
					}			
				 }	 
			 while (true);
			 cout<<"\nIncorect length\n";
	    }
     }	    
	while (n<=3);
    n=1;    
    return -1;		
}
/**********************************************************
********
*++
* Method name : Customer::ViewBalance()
* Decription  : This method used to view balance of the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : card, Acc
* Global available : no
* Return value :  0 if successful
*                -1 if no successful
*--
***********************************************************
********/
int Customer::ViewBalance(Card card,Account Acc){
	string sPin=card.getPIN();
	float fBalance=Acc.getBalance();
	UI ui(0,"");
	ui.DisplayCheckPIN();
    cout<<"\n              Acount ID      :  "<<nCustID<<"                                |";
	cout<<"\n|             Customer name  :   "<<sName<<"                            |";
	cout<<"\n              Acount balance :   "<<fBalance<<"                            |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|";
	return 0;	
}
/**********************************************************
********
*++
* Method name : Customer::WithdrawMoney()
* Decription  : This method used to withdraw money for the
*               customer
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : IDCard, nTypeAcc, fBalance
* Global available : no
* Return value :  no
*                
*--
***********************************************************
********/
void Customer::WithdrawMoney(int IDACC,string IDCard, int nTypeAcc,float fBalance)
{
	int nATMID;//Assuming you withdraw at ATMID = 1
	CATM m_ATM;
	nATMID = 1;
	int nChoseMoney;
	int nOtherMoney;
	UI ui(0,"");
	
	int solutionTime = 100; // 5 seconds
	int timer;
	int counter = 0;
	DWORD interval = 20;	// 10th of a second
	DWORD start = GetTickCount(); // program starts
	timer = 0;
	ui.DisplayWithdraw();
	cin>>nChoseMoney;
	DWORD EndTime = GetTickCount();
	if (EndTime - start > 5000) cout<<"reject";
	switch (nChoseMoney)
	{
		case 1: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 100, nTypeAcc,fBalance);
			break;
		case 2: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 500, nTypeAcc,fBalance);
			break;
		case 3: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 1000, nTypeAcc,fBalance);
			break;
		case 4: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 2000, nTypeAcc,fBalance);
			break;
		case 5: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 3000, nTypeAcc,fBalance);
			break;
		case 6: m_ATM.ChoseATM(IDACC,nATMID,IDCard, 4000, nTypeAcc,fBalance);
			break;
		case 7: 
			{
				cout<<"\n|----------------------------------------------------------------|";
                cout<<"\n|                                                                |";
				cout<<"\n|                   Please enter the amount : ";
				cin>>nOtherMoney ;
				m_ATM.ChoseATM(IDACC,nATMID,IDCard,nOtherMoney, nTypeAcc,fBalance);
			};
			break;
		case 8:
			break;
	}
}