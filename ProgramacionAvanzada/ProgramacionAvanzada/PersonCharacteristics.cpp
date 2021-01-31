#include "pch.h"
#include "PersonCharacteristics.h"


PersonCharacteristics::PersonCharacteristics()
{
	age = 0;
	weight = 0;
	height = 0;
}

PersonCharacteristics::PersonCharacteristics(int Age)
{
	age = Age;
	weight = 0;
	height = 0;
}

PersonCharacteristics::PersonCharacteristics(float Height, float Weight)
{
	age = 0;
	weight = Weight;
	height = Height;
}

PersonCharacteristics::PersonCharacteristics(int Age, float Height, float Weight)
{
	age = Age;
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
}

void PersonCharacteristics::PrintValue(std::string label, float value)
{
	std::cout << label << value << std::endl;
}