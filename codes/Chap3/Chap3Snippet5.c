#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>

int32_t (*Sum)(int32_t, int32_t);

int32_t ActualSumFunction(int32_t a, int32_t b)
{
	return a + b;
}

int32_t FalseSumFunction(int32_t a, int32_t b)
{
	return a - b;
}

int main()
{
	int A = 1;
	int B = 2;
	
	Sum = ActualSumFunction;
	
	printf("Let's try ActualSumFunction: %i\n", Sum(A, B));
	
	Sum = FalseSumFunction;
	
	printf("Let's try FalseSumFunction: %i\n", Sum(A, B));
}
