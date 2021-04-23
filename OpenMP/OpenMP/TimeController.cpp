#include "pch.h"
#include "TimeController.h"

TimeController::TimeController()
{
	
}


TimeController::~TimeController()
{
}

void TimeController::StartTime()
{
	start = clk::now();
}

void TimeController::StopTime()
{
	end = clk::now();
}

void TimeController::PrintTotalTime()
{
	delta = std::chrono::duration_cast<std::chrono::microseconds>(end - start);
	std::cout <<"Total time elapsed:  "<< delta.count() << std::endl;
}

void TimeController::PrintTimeElapsed()
{
	delta = std::chrono::duration_cast<std::chrono::microseconds>(clk::now() - start);
	std::cout << "Current elapsed time:  " << delta.count() << std::endl;
}
