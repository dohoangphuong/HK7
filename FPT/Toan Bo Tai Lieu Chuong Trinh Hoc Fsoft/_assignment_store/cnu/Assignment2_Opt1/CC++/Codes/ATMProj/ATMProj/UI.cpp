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
	 cout<<"\n\n\nPress enter to start using service...";
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
* Function name : DisplayMainMenu()
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

/**********************************************************
********
*++
* Function name : DisplayWithdraw()
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
void UI::DisplayWithdraw(){
	system("cls"); 
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n|                                                                |";
	cout<<"\n|                     Please enter the amount                    |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n|                                                                |";
	cout<<"\n|        1)100 000                   2)500 000                   |";
	cout<<"\n|                                                                |";
	cout<<"\n|        3)1 000 000                 4)2 000 000                 |";
	cout<<"\n|                                                                |";
	cout<<"\n|        5)3 000 000                 6)4 000 000                 |";
	cout<<"\n|                                                                |";
	cout<<"\n|        7)Other                     8)Exit                      |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|"<<endl;
}
/**********************************************************
********
*++
* Function name : DisplayCheckPIN()
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
void UI::DisplayCheckPIN(){
    system("cls");
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n|                                                                |";
	cout<<"\n|                          Change PIN                            |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|";
}

/**********************************************************
********
*++
* Function name : DisplayViewBalance()
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
void UI::DisplayViewBalance(){
    system("cls"); 
	cout<<"\n|                                                                |";
	cout<<"\n|                        View Balance                            |";
	cout<<"\n|                                                                |";
	cout<<"\n|----------------------------------------------------------------|";
	cout<<"\n|                                                                |";
	cout<<"\n|                                                                |";
}