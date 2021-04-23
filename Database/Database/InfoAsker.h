#pragma once
#include <iostream>
#include <string>
#include <stdlib.h>

class InfoAsker
{
public:
	InfoAsker();
	~InfoAsker();
	virtual void AskForInfo() = 0;
protected:
	std::string PrintInstruction(std::string instruction);
};

