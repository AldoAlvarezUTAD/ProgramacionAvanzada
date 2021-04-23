#pragma once
#include "Database.h"
class DatabaseInterface
{
public:
	DatabaseInterface(Database * db);
	~DatabaseInterface();
	void AddNewElementToDatabase();
	void EraseElementFromDatabase();
	void FindDatabaseElement();
	void EditDatabaseElement();
	void PrintDatabase();
	void EraseDatabase();
private:
	Database * database;
};

