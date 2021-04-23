#pragma once
#include "PrintableData.h"
#include "InfoAsker.h"

class PersonIdentificationData:public PrintableData, public InfoAsker {
public:
	PersonIdentificationData();
	PersonIdentificationData(std::string FirstName, std::string LastName);
	PersonIdentificationData(std::string FirstName, std::string MiddleName, std::string LastName);

	std::string firstName;
	std::string middleName;
	std::string lastName;

	void PrintData();
	void AskForInfo();
	std::string GetFullName();

private:
	void PrintString(std::string label, std::string value);
};