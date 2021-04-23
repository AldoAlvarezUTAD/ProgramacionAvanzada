#pragma once
#include <string>
#include"DatabaseInterface.h"
#include "CommandTypes.h"

class CommandInputs
{
public:
	CommandInputs(DatabaseInterface *db);
	~CommandInputs();

	void AskCommand();
	void CheckCommand(std::string command);
private:
	const int totalCommands = 9;
	std::string inputs[9]{ "close", "cleanConsole", "sortBy", "findElement", "editElement", "printDatabase", "eraseDatabase", "deleteElement", "addElement" };
	DatabaseInterface * dbInterface;
	CommandTypes commandType = CommandTypes::NONE;

	bool isCommand(std::string input);
	void ExecuteDatabaseOrder();
	void ClearConsole();
	void PrintCommands();
	void PrintCommand(CommandTypes type, std::string description);
	void CloseApp();
	bool ConfirmAction(std::string warningLabel);
};

