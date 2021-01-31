#pragma once
#include "PrintableData.h"
#include <string>

class PersonIdentificationData:public PrintableData{
public:
	PersonIdentificationData();
	PersonIdentificationData(std::string FirstName, std::string LastName);
	PersonIdentificationData(std::string FirstName, std::string MiddleName, std::string LastName);

	std::string firstName;
	std::string middleName;
	std::string lastName;

	void PrintData();
	std::string GetFullName();

private:
	void PrintString(std::string label, std::string value);
};