#include "pch.h"
#include "PersonCharacteristics.h"


PersonCharacteristics::PersonCharacteristics()
{
	age = 1;
	weight = 0;
	height = 0;
}

PersonCharacteristics::PersonCharacteristics(Date BirthDate)
{
	birthDate = BirthDate;
	InitAge();
	weight = 0;
	height = 0;
}

PersonCharacteristics::PersonCharacteristics(float Height, float Weight)
{
	age = 1;
	weight = Weight;
	height = Height;
}

PersonCharacteristics::PersonCharacteristics(Date BirthDate, float Height, float Weight)
{
	birthDate = BirthDate;
	InitAge();
	weight = Weight;
	height = Height;
}


PersonCharacteristics::~PersonCharacteristics()
{
}

void PersonCharacteristics::PrintData()
{
	PrintValue("\tAge:\t", age);
	PrintValue("\tHeight:\t", height);
	PrintValue("\tWeight:\t", weight);
	birthDate.PrintData();
}

void PersonCharacteristics::AskForInfo()
{
	//age = stoi(PrintInstruction("Type the person's age as an integer number:"));
	//date format dd/mm/yyyy
	birthDate.day = stoi(PrintInstruction("Type the DAY of the month of the birth date as an integer number:  "));
	birthDate.month = stoi(PrintInstruction("Type the MONTH of the birth date as an integer number:  "));
	birthDate.year = stoi(PrintInstruction("Type the YEAR of the birth date as an integer number:  "));

	height = stof(PrintInstruction("Type the person's height as a decimal number (meters) :"));
	weight = stof(PrintInstruction("Type the person's weight as a decimal number (kilograms):"));

	InitAge();
}

void PersonCharacteristics::PrintValue(std::string label, float value)
{
	std::cout << label << value << std::endl;
}

void PersonCharacteristics::InitAge()
{
	age = Date::currentYear - birthDate.year;
}
