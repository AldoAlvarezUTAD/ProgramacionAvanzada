#pragma once
#include "PrintableData.h"
#include "InfoAsker.h"
#include "Date.h"

class PersonCharacteristics : public PrintableData, public InfoAsker
{
public:
	PersonCharacteristics();
	PersonCharacteristics(Date BirthDate);
	PersonCharacteristics(float Height, float Weight);
	PersonCharacteristics(Date BirthDate, float Height, float Weight);
	~PersonCharacteristics();

	void PrintData();
	void AskForInfo();

	unsigned int age;
	float height;
	float weight;
	Date birthDate;


private:
	void PrintValue(std::string label, float value);
	void InitAge();
};

