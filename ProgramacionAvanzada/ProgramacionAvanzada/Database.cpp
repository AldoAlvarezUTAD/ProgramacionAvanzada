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
		DatabaseElement * next = first->next;
		while (next != nullptr) 
		{
			next = first->next;
		}
		next->next = element;
	}
	last = element;
	count++;
}

void Database::RemoveElement(DatabaseElement * element)
{

	if (element == first) {
		first = first->next;
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
			else break;
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
}

void Database::Print()
{
	PrintNext(first);
}

void Database::PrintNext(DatabaseElement * element)
{
	if (element == nullptr)return;
	element->PrintData();
	PrintNext(element->next);
	std::cout << "\n__________________________________________________" << std::endl;
}
