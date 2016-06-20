#include "StdAfx.h"
#include "UI.h"

UI::UI(int nMessageID,string sDescr)
{
	this->nScreenID = nScreenID;
	this->sDescr = sDescr;
}

int UI::getScreenID()
{
	return nScreenID;
}

string UI::getDescr()
{
	return sDescr;
}



/**********************************************************
********
*++
* Function name : DisplayWelcome()
* Decription  : This function used to create welcome screen
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
void UI::DisplayWelcome()
{
	 system("cls"); 
	 cout<<"\n|----------------------------------------------------------------|";
	 cout<<"\n|                                                                |";
     cout<<"\n|                       Welcome to C++ ATM                       |";
	 cout<<"\n|                                                                |";
	 cout<<"\n|----------------------------------------------------------------|";
	 cout<<"\n\n\nPress any key to start using service...";
}

/**********************************************************
********
*++
* Function name : WelcomeCustomer()
* Decription  : This function used to create welcome screen
*               to specified customer
* 
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Parameter : sName
* Global available : no
* Return value : no
*               
*--
***********************************************************
********/
void UI::WelcomeCustomer(string sName)
{
	system("cls"); 
    cout<<"\n|----------------------------------------------------------------|";
    cout<<"\n|                                                                |";
    cout<<"\n|                       Welcome     "<<sName<<"                         |";
    cout<<"\n|                                                                |";
    cout<<"\n|----------------------------------------------------------------|";
}

/**********************************************************
********
*++
* Function name : WelcomeCustomer()
* Decription  : This function used to create welcome screen
*               to specified customer
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
void UI::DisplayMainMenu()
{
	system("cls");
	cout<<"\nPlease choose one of follwing options:\n";
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n|                                                                |";
	cout<<"\n|                          Service of ATM                        |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|"; 
	cout<<"\n|                                                                |";
	cout<<"\n|  1.Withdraw money                  2.Change PIN                |";
	cout<<"\n|                                                                |";
	cout<<"\n|  3.View balance                    4.Exit                      |"; 
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n\n\nPlease input your choice: ";
}