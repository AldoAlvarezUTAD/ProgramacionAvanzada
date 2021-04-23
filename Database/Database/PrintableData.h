#pragma once
#include <iostream>
class PrintableData
{
public:
	PrintableData();
	~PrintableData();
	virtual void PrintData() = 0;
};

