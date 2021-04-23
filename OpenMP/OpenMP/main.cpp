#include "pch.h"
#include <omp.h>
#include "TimeController.h"
#include <vector>

#ifdef _WIN32
#include <Windows.h>
#else
#include <unistd.h>
#endif

void Ejercicio1(TimeController*timer) {
	unsigned int N=0;
	while (N < 10) {
	std::cout << "introduce el tamaño del vector" << std::endl;
	std::cin >> N;
	}
	double timeIni, timeFin;
	std::vector<int> x(N), y(N);
	double delta = N / 10.0f;
	//Secuencial
	
	//for (int i = 1; i < N; i++) {
	//	x[i] = y[i - 1] * 2;
	//	y[i] = y[i] + i;
	//}

	timer->StartTime();
	omp_set_num_threads(10);
#pragma omp parallel shared(delta, x, y)
	{
		int id = omp_get_thread_num();
		int start = (delta*id);
		int end = (id + 1) * delta;
		if (id == 0)start += 1;

		y[start - 1] = y[start - 1] + start - 1;
#pragma omp barrier
		for (int i = start; i < end; ++i)
		{
			x[i] = y[i - 1] * 2;
			if(i<(end-1))
				y[i] = y[i] + i;
		}
	}
	timer->StopTime();
	timer->PrintTotalTime();
}

void Ejercicio2(TimeController*timer)
{
	const int rows=5;
	const int columns=5;
	int matrixSize = rows * columns;
	const int totalThreads = 10;
	double sum = 0;

	double matrix[rows][columns];
	for (int row = 0; row < rows; ++row)
		for (int col = 0; col < columns; ++col)
			matrix[row][col] = row + (col * 10);

	timer->StartTime();
	omp_set_num_threads(10);
#pragma omp parallel shared(sum,matrix)
	{
	int threadID = omp_get_thread_num();
	int _srows = ((double)rows / (double)totalThreads)*threadID;
	int _erows = ((double)rows / (double)totalThreads)*(threadID+1);

	int _cols = columns;
#pragma omp barrier
#pragma omp parallel for reduction(+:sum)
	for (int row = _srows; row < _erows; ++row) 
	{
		for (int col = 0; col < _cols; ++col) {
			sum += matrix[row][col];
		}
	}
	}
	double avg = sum / matrixSize;
	std::cout << "Matrix average: " << avg << std::endl;
	timer->StopTime();
	timer->PrintTotalTime();
}

double PiAprox(int x) 
{
	return 4 / (1 + pow(x, 2));
}
void Ejercicio3() {
	int n = 1000;
	int a = 0, b = 1;
	double h = (double)(b - a) / (double)n;
	double dx = h / 2.0;

	const int totalThreads = 10;
	int deltaN = n / totalThreads;

	double sum = 0;
	sum += PiAprox(a);
	sum += PiAprox(b);

	omp_set_num_threads(totalThreads);
#pragma omp parallel shared(sum,h,n, deltaN, a)
	{
		int id = omp_get_thread_num();
		int start = 0;
		int end = 0;
		if (id == 0)start = 1;
		else start = id * deltaN;

		if (id == 9)end = n-1;
		else end = (id + 1)*deltaN;

#pragma omp barrier
		double value = 0;
		for (int i = start; i < end; ++i) {
			value= 2 * PiAprox(a + (h*i));
			sum += value;
		}
#pragma omp barrier
	}
	//ITERACION SIN OMP
	//for (int i = 1; i < n-1; ++i) 
	//{
	//	sum += 2 * PiAprox(a + (h*i));
	//}
	std::cout << "Suma pi: " << (sum*dx) << std::endl;
}

int main()
{
	TimeController *timer = new TimeController();
	std::cout << "Ejercicio 1...................." << std::endl;
	Ejercicio1(timer);
	std::cout << "\n\nEjercicio 2...................." << std::endl;
	Ejercicio2(timer);
	std::cout << "\n\nEjercicio 3...................." << std::endl;
	Ejercicio3();
	getchar();
	return 0;
}
