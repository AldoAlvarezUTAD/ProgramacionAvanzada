#include "pch.h"
#include "DatabaseInterface.h"
#include <vector>

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
	identificationData->AskForInfo();
	characteristics->AskForInfo();

	database->AddElement(new DatabaseElement(identificationData, characteristics));

	std::cout << "\nSuccessfully added " << identificationData->GetFullName() + " to the database.\n" << std::endl;
	std::cout << "_____________________________________________________\n" << std::endl;
}

void DatabaseInterface::EraseElementFromDatabase()
{
	std::string fName="", mName="", lName="";
	std::cout << "\nType the FIRST NAME of the element you want to delete." << std::endl;
	std::cin >> fName;
	std::cout << "\nType the MIDDLE NAME of the element you want to delete.\n*You can leave this field empty." << std::endl;
	std::cin >> mName;
	std::cout << "\nType the LAST NAME of the element you want to delete.\n*You can leave this field empty." << std::endl;
	std::cin >> lName;
	int dbIndex = database->FindElement(fName, mName, lName);
	database->RemoveAt(dbIndex);
	if(dbIndex>-1)	
		std::cout << "\nSuccessfully deleated the element.\n" << std::endl;
	else
		std::cout << "\nThe element could not be found.\n" << std::endl;
}

void DatabaseInterface::FindDatabaseElement()
{
	std::string fName = "", mName = "", lName = "";
	std::cout << "\nType the FIRST NAME of the element to find." << std::endl;
	std::cin >> fName;
	std::cout << "\nType the MIDDLE NAME of the element to find." << std::endl;
	std::cin >> mName;
	std::cout << "\nType the LAST NAME of the element to find." << std::endl;
	std::cin >> lName;
	std::vector<int> elements = database->GetElements(fName, mName, lName);
	for (int element = 0; element < elements.size(); ++element)
	{
		std::cout << "\n++++++++++++++++++++++++++++++++++++++++++++++++++" << std::endl;
		database->GetElement(elements.at(element))->PrintData();
	}
	std::cout << "\n__________________________________________________" << std::endl;
}

void DatabaseInterface::EditDatabaseElement()
{
}

void DatabaseInterface::PrintDatabase()
{
	database->Print();
}

void DatabaseInterface::EraseDatabase()
{
	database->EraseAll();
}
