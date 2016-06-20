/**********************************************************
********
*++
* Author : C/C++ Team
* Module : Main Program
* 
* Decription : main function of ATM
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
*
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
* Mod.History : 31/07/2012 - Main program
*                            ATM Application
*                            Decription : design a ATM in 
*                                         condole 
*                                         application
***********************************************************
********/
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
#include "UI.h"
using namespace std;

// Set information of the Customer, Card, message, account
CATM atm;
UI ui1(0,"");
/**********************************************************

                       Main Program

**********************************************************/
int _tmain (int argc, _TCHAR* argv[])
{	
	int check = 0;
	int count =1;
	while (1)
    {
		ui1.DisplayWelcome();
		check = atm.ValidateCard();
		if (check==1)
		{
			check = atm.Authentication();
			while (check==0 && count<3){
				cout<<"PINCode is not matched! Please try again!\n";
				check = atm.Authentication();
				count++;
			}
		}
		if (check==0) 
		{
			getch();
		}
		else
		atm.MainMenu();
	}
	getch();
	return 0;
}

