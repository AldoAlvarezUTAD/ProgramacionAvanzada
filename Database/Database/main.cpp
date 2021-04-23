#include "pch.h"
#include "DatabaseInterface.h"
#include "CommandInputs.h"

int main()
{
	Database * db = new Database();
	DatabaseInterface * interface = new DatabaseInterface(db);
	CommandInputs * inputManager = new CommandInputs(interface);

	while (true) {
		inputManager->AskCommand();
	}
	return 0;
}
