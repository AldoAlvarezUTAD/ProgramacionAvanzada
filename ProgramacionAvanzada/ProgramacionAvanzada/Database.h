#pragma once
#include "DatabaseElement.h"
struct Database
{
	DatabaseElement * first;
	
	void EraseAll();
	void AddElement(DatabaseElement * element);
	void RemoveElement(DatabaseElement *element);
	void RemoveAt(int index);
	void Print();
private:
	void PrintNext(DatabaseElement*element);
	DatabaseElement * last;
	int count = 0;

};