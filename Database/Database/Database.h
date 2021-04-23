#pragma once
#include "DatabaseElement.h"
#include <vector>

struct Database
{
	DatabaseElement * first;
	
	void EraseAll();
	void AddElement(DatabaseElement * element);
	void RemoveElement(DatabaseElement *element);
	void RemoveAt(int index);
	void Print();
	int FindElement(std::string firstName, std::string middleName="", std::string lastName="");

	template<typename T>
	DatabaseElement* FindElements(PersonData dataType, T searchValue);
	DatabaseElement* GetElement(std::string firstName, std::string middleName="", std::string lastName="");
	DatabaseElement* GetElement(int index);
	std::vector<int> GetElements(std::string firstName, std::string middleName="", std::string lastName="");
	
private:
	void PrintNext(DatabaseElement*element);
	bool isElement(DatabaseElement*element, std::string firstName, std::string middleName, std::string lastName);
	template<typename T>
	bool ElementHas(DatabaseElement* element, PersonData dataType, T searchValue);
	DatabaseElement * last;
	int count = 0;

};

template<typename T>
inline DatabaseElement * Database::FindElements(PersonData dataType, T searchValue)
{
	DatabaseElement*current = first;

	DatabaseElement*returnElement = nullptr;
	DatabaseElement*lastReturnElement = nullptr;

	while (current != nullptr)
	{
		if (ElementHas(current, dataType, searchValue)) {
			if (returnElement == nullptr) {
				returnElement = current;
				lastReturnElement = returnElement;
			}
			else {
				lastReturnElement->next = current;
				lastReturnElement = nullptr;
			}
		}
		current = current->next;
	}
	return NULL;
}

template<typename T>
inline bool Database::ElementHas(DatabaseElement* element, PersonData dataType, T searchValue)
{
	return element->GetData(dataType) == searchValue;
}
