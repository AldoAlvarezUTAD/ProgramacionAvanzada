#pragma once
#include <iostream>
#include <chrono>
using clk = std::chrono::high_resolution_clock;

 //Obtener una marca de tiempo :
 //auto t1 = clk::now();
 //Diferencias de tiempo :
 //auto diff = duration_cast<microseconds>(t2 - t1);
 //Obtención del valor de diferencia :
 //cout << diff.count();
class TimeController
{
public:
	TimeController();
	~TimeController();
	void StartTime();
	void StopTime();
	void PrintTotalTime();
	void PrintTimeElapsed();
private:
	clk::time_point start;
	clk::time_point end;
	std::chrono::microseconds delta;
};

