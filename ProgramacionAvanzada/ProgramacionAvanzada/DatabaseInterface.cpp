#include "pch.h"
#include "DatabaseInterface.h"

DatabaseInterface::DatabaseInterface(Database * db)
{
	database = db;
}


DatabaseInterface::~DatabaseInterface()
{
}

void DatabaseInterface::AddNewElementToDatabase()
{
	PersonCharacteristics *characteristics = new PersonCharacteristics();
	PersonIdentificationData *identificationData = new PersonIdentificationData();
	identificationData->firstName = PrintInstruction("Type the person's first name:");
	identificationData->middleName = PrintInstruction("Type the person's middle name:");
	identificationData->lastName = PrintInstruction("Type the person's last name:");

	characteristics->age = stoi(PrintInstruction("Type the person's age as an integer number:"));
	characteristics->height = stof(PrintInstruction("Type the person's height as a decimal number (meters) :"));
	characteristics->weight = stof(PrintInstruction("Type the person's weight as a decimal number (kilograms):"));
	database->AddElement(new DatabaseElement(identificationData, characteristics));

	std::cout << "\nSuccessfully added " << identificationData->GetFullName() + " to the database.\n" << std::endl;
	std::cout << "\n_____________________________________________________" << std::endl;
}

void DatabaseInterface::PrintDatabase()
{
	database->Print();
}

void DatabaseInterface::EraseDatabase()
{
	database->EraseAll();
}

std::string DatabaseInterface::PrintInstruction(std::string instruction)
{
	std::string value;
	std::cout << instruction << "   ";
	std::cin >> value;
	return value;
}
