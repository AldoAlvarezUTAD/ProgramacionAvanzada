// ProgramacionAvanzada.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include "DatabaseInterface.h"
#include "CommandInputs.h"
//enum PersonCharacteristics { Name, LastName, Age, Height, Weight };

int main()
{
	Database * db = new Database();
	DatabaseInterface * interface = new DatabaseInterface(db);
	CommandInputs * inputManager = new CommandInputs(interface);

	std::string input;
	while (true) {
		inputManager->AskCommand();
	}
	return 0;
}