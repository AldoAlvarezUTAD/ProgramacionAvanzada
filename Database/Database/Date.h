#pragma once
#include "PrintableData.h"

enum ZodiacSigns { CAPRICORN = 1, AQUARIUS, PISCES, ARIES, TAURUS, GEMINI, CANCER, LEO, VIRGO, LIBRA, SCORPIO, SAGITTARIUS };
enum ChineseZodiac { RAT, OX, TIGER, RABBIT, DRAGON, SNAKE, HORSE, GOAT, MONKEY, ROOSTER, DOG, PIG };
enum Months { JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC };

class Date:PrintableData
{
public:
	Date();
	Date(unsigned int day, unsigned int month, unsigned int year);
	Date(unsigned int day, Months month, unsigned int year);
	~Date();

	int YearDay();
	int YearDay(Months month, unsigned int day);
	ZodiacSigns ZodiacSign();
	
	unsigned int day;
	unsigned int month;
	unsigned int year;

	int DaysInMonth(Months month);
	void PrintData();

	static const int currentYear = 2020;

	Date operator=(Date other);
private:
	unsigned int yearDay;
	ZodiacSigns sign;
	ChineseZodiac chineseSign;
	const int referenceYear = 2020;

	void ValidateDate();
	void Init(unsigned int day, unsigned int month, unsigned int year);
	void SetYearDay();
	void SetZodiac();
	void SetChineseZodiac();
};

