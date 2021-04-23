#include "pch.h"
#include "Database.h"

void Database::EraseAll()
{
	first = nullptr;
	last = nullptr;
}

void Database::AddElement(DatabaseElement * element)
{
	if (first == nullptr)
		first = element;
	else
	{
		DatabaseElement * current = first;
		DatabaseElement * next = current->next;
		while (next != nullptr) 
		{
			next = current->next;
		}
		current->next = element;
	}
	last = element;
	count++;
}

void Database::RemoveElement(DatabaseElement * element)
{

	if (element == first) {
		first = first->next;
		count--;
	}
	else {
		DatabaseElement*current = first->next;
		DatabaseElement*previous = first;
		for (int i = 1; i < count; ++i)
		{
			if (current != element) {
				previous = current;
				current = current->next;
			}
			else {
				count--;
				break;
			}
		}
		previous->next = current->next;
	}
}

void Database::RemoveAt(int index)
{
	if (index < 0 || index >= count)return;

	if (index == 0) {
		first = first->next;
	}
	else {
		DatabaseElement*current = first->next;
		DatabaseElement*previous = first;
		for (int i = 1; i < index; ++i)
		{
			previous = current;
			current = current->next;
		}
		previous->next = current->next;
	}
	count--;
}

void Database::Print()
{
	PrintNext(first);
}

int Database::FindElement(std::string firstName, std::string middleName, std::string lastName)
{
	int index = 0;
	DatabaseElement*current = first;

	while (current != nullptr) 
	{
		if (isElement(current, firstName, middleName, lastName))
			return index;
		++index;
		current = current->next;
	}
	return -1;
}

DatabaseElement * Database::GetElement(std::string firstName, std::string middleName, std::string lastName)
{
	DatabaseElement*next = first->next;
	DatabaseElement*current = first;
	while (next != nullptr)
	{
		if (isElement(next, firstName, middleName, lastName))return next;
		current = next;
		next = current->next;
	}
	return nullptr;
}

DatabaseElement * Database::GetElement(int index)
{
	if (index < 0 || index >= count)return nullptr;

	DatabaseElement*current = first->next;
	DatabaseElement*previous = first;
	for (int i = 1; i < index; ++i)
	{
		previous = current;
		current = current->next;
	}
	return current;
}

std::vector<int> Database::GetElements(std::string firstName, std::string middleName, std::string lastName)
{
	std::vector<int>elements;
	DatabaseElement*next = first->next;
	DatabaseElement*current = first;
	int index = 0;
	while (current != nullptr)
	{
		next = current->next;
		if (isElement(current, firstName, middleName, lastName))
			elements.push_back(index);
		current = next;
		++index;
	}
	return elements;
}

void Database::PrintNext(DatabaseElement * element)
{
	if (element == nullptr)return;
	element->PrintData();
	std::cout << "\n++++++++++++++++++++++++++++++++++++++++++++++++++" << std::endl;
	PrintNext(element->next);
	std::cout << "\n__________________________________________________" << std::endl;
}

bool Database::isElement(DatabaseElement*element, std::string firstName, std::string middleName, std::string lastName)
{
	std::string name = element->GetData<std::string>(PersonData::Name);
	if (name != firstName)return false;
		if (middleName != "")
			if (element->GetData<std::string>(PersonData::MiddleName) != middleName)
				return false;
				
		if (lastName != "")
			if (element->GetData<std::string>(PersonData::LastName) != lastName)
				return false;
		return true;
	
}
