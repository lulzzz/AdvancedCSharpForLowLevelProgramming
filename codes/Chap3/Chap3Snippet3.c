#include <stdlib.h>
#include <stdio.h>
#include <stdint.h>

int main()
{
	int32_t* buffer = (int32_t*)malloc(sizeof(int32_t)*20);
	// Let's do some math on our buffer!
	for (int32_t I = 0; I < 20; ++I)
	{
		buffer[I] = I * 2;
	}
	
	// Now let's print what our buffer is going to look like:
	for (int32_t I = 0; I < 20; ++I)
	{
		printf("Buffer[%i] = %i\n", I, buffer[I]);
	}
	
	free(buffer);
}
