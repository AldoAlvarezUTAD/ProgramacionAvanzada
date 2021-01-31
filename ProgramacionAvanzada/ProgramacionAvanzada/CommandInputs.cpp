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
	case CommandTypes::Close:exit(EXIT_SUCCESS); return;
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
	case CommandTypes::PrintDatabase: dbInterface->PrintDatabase(); return;
	case CommandTypes::EraseDatabase: 
		dbInterface->EraseDatabase(); return;
	case CommandTypes::AddNewElement:
		dbInterface->AddNewElementToDatabase(); return;
	case CommandTypes::DeleteElement:
	case CommandTypes::EditElement:
	case CommandTypes::FindElement:
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
	PrintCommand(CommandTypes::EditElement, "This action will allow you to edit an element from the current database.");
	PrintCommand(CommandTypes::PrintDatabase, "This action will print all the data for all the elements in the current database.");
	PrintCommand(CommandTypes::SortBy, "WARNING: work in progress");
}

void CommandInputs::PrintCommand(CommandTypes type, std::string description)
{
	std::cout << "command:\t" << inputs[(int)type] << std::endl;
	std::cout << "\t\t"<<description<<"\n" << std::endl;

}
