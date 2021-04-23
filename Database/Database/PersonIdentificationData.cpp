#include "pch.h"
#include "PersonIdentificationData.h"


PersonIdentificationData::PersonIdentificationData()
{
	firstName = "";
	middleName = "";
	lastName = "";
}

PersonIdentificationData::PersonIdentificationData(std::string FirstName, std::string LastName)
{
	firstName = FirstName;
	middleName = "";
	lastName = LastName;
}
PersonIdentificationData::PersonIdentificationData(std::string FirstName, std::string MiddleName, std::string LastName)
{
	firstName = FirstName;
	middleName = MiddleName;
	lastName = LastName;
}

void PersonIdentificationData::PrintData()
{
	PrintString("\tFirst Name:\t", firstName);
	PrintString("\tMiddle Name:\t", middleName);
	PrintString("\tLast Name:\t", lastName);
}

void PersonIdentificationData::AskForInfo()
{
	firstName = PrintInstruction("Type the person's first name:");
	middleName = PrintInstruction("Type the person's middle name:");
	lastName = PrintInstruction("Type the person's last name:");
}

std::string PersonIdentificationData::GetFullName()
{
	if (middleName.length() <= 0)
		return firstName + " " + lastName;
	return firstName + " " + middleName + " " + lastName;
}

void PersonIdentificationData::PrintString(std::string label, std::string value)
{
	std::cout << label << value << std::endl;
}