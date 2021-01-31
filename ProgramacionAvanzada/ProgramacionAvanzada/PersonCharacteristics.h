#pragma once
#include "PrintableData.h"
#include <string>
class PersonCharacteristics : public PrintableData
{
public:
	PersonCharacteristics();
	PersonCharacteristics(int Age);
	PersonCharacteristics(float Height, float Weight);
	PersonCharacteristics(int Age, float Height, float Weight);
	~PersonCharacteristics();

	void PrintData();

	unsigned int age;
	float height;
	float weight;

private:
	void PrintValue(std::string label, float value);
};

