#pragma once
#include "PersonIdentificationData.h"
#include "PersonCharacteristics.h"

enum PersonData { Name, MiddleName, LastName, Age, Height, Weight };

class DatabaseElement : public PrintableData{
public:
	DatabaseElement*next;
	DatabaseElement(PersonIdentificationData *Identification);
	DatabaseElement(PersonIdentificationData *Identification, PersonCharacteristics *characteristics);
	~DatabaseElement();


	template<typename T>
	T GetData(PersonData dataType);
	template<typename T>
	void SetData(PersonData dataType, T value);

	void PrintData();
private:
	PersonIdentificationData * identification;
	PersonCharacteristics * characteristics;

};

template<typename T>
inline T DatabaseElement::GetData(PersonData dataType)
{
	switch (dataType)
	{
	case PersonData::Name:return identification->firstName;
	case PersonData::MiddleName:return identification->middleName;
	case PersonData::LastName:return identification->lastName;
	default:
		return T();
	}
}

template<typename T>
inline void DatabaseElement::SetData(PersonData dataType, T value)
{
}
