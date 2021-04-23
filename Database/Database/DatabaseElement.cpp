#include "pch.h"
#include "DatabaseElement.h"


DatabaseElement::~DatabaseElement()
{
}

DatabaseElement::DatabaseElement(PersonIdentificationData * Identification)
{
	if (Identification != nullptr)
		identification = Identification;
	else
		identification = new PersonIdentificationData();
	characteristics = new PersonCharacteristics();
}

DatabaseElement::DatabaseElement(PersonIdentificationData * Identification, PersonCharacteristics * Characteristics)
{
	if (Identification != nullptr) identification = Identification;
	else identification = new PersonIdentificationData();

	if (Characteristics != nullptr) characteristics = Characteristics;
	else characteristics = new PersonCharacteristics();
}

void DatabaseElement::PrintData()
{
	identification->PrintData();
	characteristics->PrintData();
}
