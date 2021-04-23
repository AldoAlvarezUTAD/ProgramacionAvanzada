#include "pch.h"
#include "CommandInputs.h"
#include <iostream>


CommandInputs::CommandInputs(DatabaseInterface *db)
{
	dbInterface = db;
}


CommandInputs::~CommandInputs()
{
}

void CommandInputs::AskCommand()
{
	std::cout << "Plese insert one of the following commands and follow their instructions." << std::endl;
	PrintCommands();
	std::string command;
	std::cin >> command;
	CheckCommand(command);
}

void CommandInputs::CheckCommand(std::string command)
{
	if (!isCommand(command))return;
	switch (commandType)
	{
	case CommandTypes::Close: CloseApp(); return;
	case CommandTypes::CleanConsole:ClearConsole(); return;
	case CommandTypes::PrintDatabase:
	case CommandTypes::EraseDatabase: 
	case CommandTypes::AddNewElement:
	case CommandTypes::DeleteElement:
	case CommandTypes::EditElement:
	case CommandTypes::FindElement:
	case CommandTypes::SortBy:
		ExecuteDatabaseOrder();
		return;
	default:
		return;
	}
}

bool CommandInputs::isCommand(std::string input)
{
	commandType = CommandTypes::NONE;
	for (int i = 0; i < totalCommands; ++i) {
		std::string compare = inputs[i];
		if (input == inputs[i]) {
			commandType = (CommandTypes)i;
			return true;
		}
	}
	return false;
}

void CommandInputs::ExecuteDatabaseOrder()
{
	if (dbInterface == nullptr)return;
	switch (commandType)
	{
	case CommandTypes::PrintDatabase:
		dbInterface->PrintDatabase(); return;
	case CommandTypes::EraseDatabase: 
		if (ConfirmAction("DELETE THE DATABSE"))
		dbInterface->EraseDatabase(); return;
	case CommandTypes::AddNewElement:
dbInterface->AddNewElementToDatabase(); return;
	case CommandTypes::DeleteElement:
		dbInterface->EraseElementFromDatabase(); return;
	case CommandTypes::EditElement:
	case CommandTypes::FindElement:
		dbInterface->FindDatabaseElement();
	case CommandTypes::SortBy:
		return;
	default:
		return;
	}
}

void CommandInputs::ClearConsole()
{
#if defined _WIN32
	system("cls");
#elif defined (__LINUX__) || defined(__gnu_linux__) || defined(__linux__)
	system("clear");
#elif defined (__APPLE__)
	system("clear");
#endif
}

void CommandInputs::PrintCommands()
{
	PrintCommand(CommandTypes::CleanConsole, "This action will clean the console and will leave only the commands.");
	PrintCommand(CommandTypes::EraseDatabase, "WARNING: This action will delete the current database.");
	PrintCommand(CommandTypes::AddNewElement, "This action will add a new element to the current database.");
	PrintCommand(CommandTypes::DeleteElement, "This action will delete an element from the database.\n\t\tThis element can be found either by its index or some characteristic.");
	PrintCommand(CommandTypes::FindElement, "This action will find and display an element from the current database if it exists.");
	PrintCommand(CommandTypes::EditElement, "WARNING: work in progress. To be delivered soon.");
	PrintCommand(CommandTypes::PrintDatabase, "This action will print all the data for all the elements in the current database.");
	PrintCommand(CommandTypes::SortBy, "WARNING: work in progress. To be delivered soon.");
	PrintCommand(CommandTypes::Close, "Closes the application and any databse will be deleted.");
}

void CommandInputs::PrintCommand(CommandTypes type, std::string description)
{
	std::cout << "command:\t" << inputs[(int)type] << std::endl;
	std::cout << "\t\t"<<description<<"\n" << std::endl;

}

void CommandInputs::CloseApp()
{
	std::string input;
	bool acceptedInput = false;
	if(ConfirmAction("close the application"))
		exit(EXIT_SUCCESS);
}

bool CommandInputs::ConfirmAction(std::string warningLabel)
{
	std::string input;
	bool acceptedInput = false;
	while (!acceptedInput)
	{
		std::cout << "Are you sure you want to "+warningLabel +"?\nType 'Y' to close it. Or type 'N' to cancel." << std::endl;
		std::cin >> input;
		if (input == "Y" || input == "N")
			acceptedInput = true;
		else
			ClearConsole();
	}
	if (input == "Y")
		return true;
	return false;
}
