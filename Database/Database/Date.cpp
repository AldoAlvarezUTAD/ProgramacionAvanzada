#include "pch.h"
#include "Date.h"
#include <stdlib.h> 

#define stringify( name ) # name
const char* ZodiacSignsNames[] =
{
stringify(CAPRICORN),
stringify(AQUARIUS),
stringify(PISCES),
stringify(ARIES),
stringify(TAURUS),
stringify(GEMINI),
stringify(CANCER),
stringify(LEO),
stringify(VIRGO),
stringify(LIBRA),
stringify(SCORPIO),
stringify(SAGITTARIUS)
};

const char* ChineseZodiacSignsNames[] =
{
stringify(RAT),
stringify(OX),
stringify(TIGER),
stringify(RABBIT),
stringify(DRAGON),
stringify(SNAKE),
stringify(HORSE),
stringify(GOAT),
stringify(MONKEY),
stringify(ROOSTER),
stringify(DOG),
stringify(PIG)
};


Date::Date()
{
	Init(1, 1, referenceYear);
}

Date::Date(unsigned int day, unsigned int month, unsigned int year)
{
	Init(day, month, year);
}

Date::Date(unsigned int day, Months month, unsigned int year)
{
	Init(day, (int)month, year);
}

Date::~Date()
{
}

int Date::YearDay()
{
	return yearDay;
}

int Date::YearDay(Months month, unsigned int day)
{
	int yd = 0;
	for (int m = 1; m < month; ++m)
		yd += DaysInMonth((Months)month);
	return yd += day;
}

ZodiacSigns Date::ZodiacSign()
{
	return sign;
}

int Date::DaysInMonth(Months month)
{
	switch (month) 
	{
	case Months::JAN:
	case Months::MAR:
	case Months::MAY:
	case Months::JUL:
	case Months::AUG:
	case Months::OCT:
	case Months::DEC:
		return 31;
	case FEB:return 28;
	default:return 30;
	}
}

void Date::PrintData()
{
	ValidateDate();
	SetYearDay();
	SetZodiac();
	SetChineseZodiac();

	std::cout << "\tdd/mm/yyyy:  " << day << "/" << month << "/" << year << std::endl;
	std::cout << "\tZodiac:  " << ZodiacSignsNames[sign-1] << std::endl;
	std::cout << "\tChinese Zodiac:  " << ChineseZodiacSignsNames[chineseSign] << std::endl;
}

Date Date::operator=(Date other)
{
	return Date(other.day, other.month, other.year);
}

void Date::ValidateDate()
{
	if (month <= 0)month = 1;
	else if (month > 12)month = 12;

	int maxDays = DaysInMonth((Months)month);
	if (day <= 0)day = 1;
	else if (day > maxDays)day = maxDays;
}

void Date::Init(unsigned int _day, unsigned int _month, unsigned int _year)
{
	day = _day;
	month = _month % 12;
	year = _year;
	ValidateDate();

	SetYearDay();
	SetZodiac();
	SetChineseZodiac();
}

void Date::SetYearDay()
{
	yearDay = YearDay((Months)month, day);
}

void Date::SetZodiac()
{
	sign = CAPRICORN;
	for (int m = 1; m <= 12; ++m) 
	{
		if (yearDay < YearDay((Months)m, 21)) {
			sign = (ZodiacSigns)m;
			return;
		}
	}
}

void Date::SetChineseZodiac()
{
	int y = year - referenceYear;
	y = abs(y) % 12;
	chineseSign = (ChineseZodiac)(12-y);
	if (chineseSign == 12)chineseSign = ChineseZodiac::RAT;
}
