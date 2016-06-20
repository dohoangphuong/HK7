/*********************************************************************************
*++
*Author: HongLTB
*Module Name: ATMProj.cpp
*Description: Main program for ATM project
*Mod.History:
*            + 30.07.2012 - Created 
*
*
*
*********************************************************************************/

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
#include "ATM.h"
#include "Customer.h"

using namespace std;

#define __PATH__Card "Card.txt"
#define __PATH__Account "Account.txt"
#define __PATH__Customer "Customer.txt"

void Welcome();//tao man hinh welcome
int ValidateCard();//ham nham ktra tai khoan co valid khong
int Authentication();//ham kiem tra ma PIN khach hang nhap vao co dung k
//int CheckPassword(Account User);//Kiem tra PIN co trung khop khong
void MainMenu();//hien ra cac menu de lua chon
int getCustName();//ham lay ten khach hang va ghi cac thong tin ve KH,acc
int getName();//Ham con cua getCustName dung de tim trong file Customer.txt



Customer cust(0,"");
Card card("","","",0);
Message message(0,"","");
Account acc(0,0,0,0);
ATM atm(0,"",0,0);

string sCardID;
int nAccountID;
//string sCustID;


int _tmain(int argc, _TCHAR* argv[])
{	
	//int CardID;
	int check = 0;
	int count =1;

	//Customer cust(0,"");
	//Card card("","","",0);
	//string sCardID;

	Welcome();
	check = ValidateCard();
	//cout<<card.getCardID()<<endl;
	if(check==1){
		check = Authentication();

		while(check==0 && count<3){
			cout<<"PINCode is not matched! Please try again!\n";
			check = Authentication();
			count++;
		}
	}

	if(check==0) {
		atm.ejectCard();
		getch();
		return 0;
	}

	MainMenu();

	getch();

	return 0;
	
}

void Welcome(){
	cout<<"-------------------------------------------\n";
	cout<<"+++Welcome to ATM service of C/C++ Group+++\n";
	cout<<"-------------------------------------------\n";
	cout<<"\nPress any key to start using service...";
}

int ValidateCard(){
	char c;
	int len;
	int check;
	//Account User("","","","","","","");

	c = getchar();
	if(c!='\0'){
		do{
			cust.InsertCard();
			sCardID = card.readCard();
			//card.changeCardID(sCardID);
			//cout<<card.getCardID()<<endl;
			
			//Kiem tra do dai CardID
			len = sCardID.length();
			if(len!=6) {
				//message1: do dai cua Card ID khac 6
				message.setMessage(1);
				cout<<message.getMessageID()<<message.getDispText()<<endl;
				}
			}
		while(len!=6);
	
		//Tim kiem CardID trong CSDL
		ifstream readfile(__PATH__Card);
		//Always test the file open.
		if(!readfile) {
			//message 2: khong mo duoc file data
			message.setMessage(2);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
			//cout<<"Error opening output file"<<endl;
			system("pause");
			return -1;//loi nay se phai dung he thong
		 }
		string line;
		size_t found;
		string sPIN;
		string sStatus;
		string sAccountID;
		string sCustName;
		int begin;
		int end;
		do{
			getline(readfile,line,'\n');
			//cout<<line<<endl;
			found=line.find(card.getCardID());
			if (found!=string::npos && int(found)==0){
				begin=line.find('\t');
				end = line.find('\t',begin+1);
				sStatus=line.substr(begin+1,end-begin-1);
				cout<<"Status: "<<sStatus<<endl;
				//Kiem tra Status
				if (sStatus.compare("Valid")==0){				
					begin=end;
					end = line.find('\t',begin+1);
					sAccountID=line.substr(begin+1,end-begin-1);
					//cout<<sAccountID<<endl;
					nAccountID = atoi(sAccountID.c_str());
					cout<<"AccountID: "<<nAccountID<<endl;

					begin=end;
					end = line.find('\t',begin+1);
					sPIN=line.substr(begin+1,end-begin-1);
					cout<<"PIN: "<<sPIN<<endl;
				
					//set gia tri vao bien card
					card.setCardInfo(sCardID,sPIN,sStatus,nAccountID);
					//cout<<"thongtin Card: "<<card.getCardID()<<"-"<<card.getAccountID()<<endl;
					//cout << "CardID found at: " << int(found) << endl;
					check = getCustName();
					cout<< "+++Welcome "<<cust.getName()<<"+++"<<endl;
					return 1;
				}
				else if (sStatus.compare("PerBlock")==0){
					message.setMessage(3);
					cout<<message.getMessageID()<<message.getDispText()<<endl;
					//cout<<"khoa vinh vien"<<endl;
					//message 03: the bi khoa vinh vien nen se nuot the
					return 0;
				}
				else if (sStatus.compare("TemBlock")==0){
					message.setMessage(4);
					cout<<message.getMessageID()<<message.getDispText()<<endl;
					//cout<<"khoa tam thoi"<<endl;
					//message 04: the bi khoa tham thoi
					return 0;
				} 	
							
			}
		}
		while(!readfile.eof());
		if (int(found!=0))	{
			message.setMessage(5);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
			//cout<<"khong tim thay"<<endl;
			//message 05: ma the khong co trong CSDL
		}
	}
	return 0;
}


int Authentication(){
	string sPIN;
	
	cust.EnterPIN();
	cin>>sPIN;
	if(sPIN.compare(card.getPIN())==0){
		cout<<"PINCode is matched!\n";
		return 1;
	}
	return 0;
}



void MainMenu(){
	int c;

	cout<<"Please choose one of follwing options:\n";
	cout<<"1.Withdraw Money\n";
	cout<<"2.Change PIN\n";
	cout<<"3.View balance\n";
	cout<<"4.Cancle\n";
	cout<<"Please input your choice: ";

	cin>>c;
	if(c==1){
		cout<<"Option 1\n";
	}
	else if(c==2){
		cout<<"Option 2\n";
	}
	else if(c==3){
		cout<<"Option 3\n";
	}
	else if(c==4){
		cout<<"Option 4\n";
	}
	else {
		cout<<"Input is not valid!\n";
	}
}

int getCustName(){
	string line;
	size_t found;
	int check;

	ifstream readfile(__PATH__Account);
	//Always test the file open.
	if(!readfile) {
			//message 2: khong mo duoc file data
			message.setMessage(2);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
			//cout<<"Error opening output file"<<endl;
			system("pause");
			return -1;//loi nay se phai dung he thong
	}

		string sStatus;
		string sAccountID;
		string sCustID;
		int nCustID;
		string sTypeID;
		int nTypeID;
		string sBalance;
		float fBalance;
		int begin;
		int end;
		do{
			getline(readfile,line,'\n');
			begin=0;
			end = line.find('\t',begin+1);
			sAccountID=line.substr(begin+1,end-begin-1);
			nAccountID = atoi(sAccountID.c_str());
			cout<<"AccountID: "<<nAccountID<<endl;
			if(nAccountID == card.getAccountID()){
				begin=end;
				end = line.find('\t',begin+1);
				sCustID=line.substr(begin+1,end-begin-1);
				nCustID = atoi(sCustID.c_str());
				cout<<"CustID: "<<nCustID<<endl;
					
				begin=end;
				end = line.find('\t',begin+1);
				sTypeID=line.substr(begin+1,end-begin-1);
				//cout<<sAccountID<<endl;
				nTypeID = atoi(sTypeID.c_str());
				cout<<"TypeID: "<<nTypeID<<endl;

				begin=end;
				end = line.find('\t',begin+1);
				sBalance=line.substr(begin+1,end-begin-1);
				fBalance = atof(sBalance.c_str());
				cout<<"Balance: "<<fBalance<<endl;
				
				//set gia tri vao bien account
				acc.setAccountInfo(nAccountID,nCustID,nTypeID,fBalance);
				//cout<<"thongtin Card: "<<card.getCardID()<<"-"<<card.getAccountID()<<endl;
				//cout << "CardID found at: " << int(found) << endl;
				check = getName();
				return 1;
				
			}
		}
		while(!readfile.eof());
		if (int(found!=0))	{
			//cout<<"khong tim thay"<<endl;
			//message 06: ma Account khong co trong CSDL
			message.setMessage(6);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
		}
		
		return 0;

}

int getName(){

	string line;
	size_t found;
	int check;

	ifstream readfile(__PATH__Customer);
	//Always test the file open.
	if(!readfile) {
			//message 2: khong mo duoc file data
			message.setMessage(2);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
			//cout<<"Error opening output file"<<endl;
			system("pause");
			return -1;//loi nay se phai dung he thong
	}
		string sCustID;
		int nCustID;
		string sName;
		int begin;
		int end;

	do{
			getline(readfile,line,'\n');
			begin=0;
			end = line.find('\t',begin+1);
			sCustID=line.substr(begin+1,end-begin-1);
			nCustID = atoi(sCustID.c_str());
			cout<<"CustID: "<<nCustID<<endl;
			if(nCustID == acc.getCustID()){
				begin=end;
				end = line.find('\t',begin+1);
				sName=line.substr(begin+1,end-begin-1);
				
				cout<<"Cust Name: "<<sName<<endl;

				cust.setCustInfo(nCustID,sName);
				return 1;
				
			}
		}
	while(!readfile.eof());
	if (int(found!=0))	{
			//cout<<"khong tim thay"<<endl;
			//message 07: ma Cust khong co trong CSDL
			message.setMessage(7);
			cout<<message.getMessageID()<<message.getDispText()<<endl;
	}
		
	return 0;
}