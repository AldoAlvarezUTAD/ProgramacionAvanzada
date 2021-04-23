#include "pch.h"
#include "InfoAsker.h"


InfoAsker::InfoAsker()
{
}


InfoAsker::~InfoAsker()
{
}

std::string InfoAsker::PrintInstruction(std::string instruction)
{
	std::string value;
	std::cout << instruction << "   ";
	std::cin >> value;
	return value;
}
