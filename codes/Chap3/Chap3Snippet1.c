#include <stdlib.h>
#include <stdint.h>

// Let's allocate 12 bytes, or 3 int32_t.
int32_t* MyPointer = (int32_t*)malloc(sizeof(int32_t) * 3);

// You can access pointer like an array
MyPointer[0] = 12;

// You can also dereference a pointer to read or write the data in memory directly
*MyPointer = 12;

// You can advance the pointer by 4 bytes or by Int32_t
// Compilter would advance the pointer to the size of type that is defined for our variable
MyPointer++;

// If you do this however...
MyPointer = (int32_t*)(((int16_t*)MyPointer)++);
// It would advance pointer by 2 bytes or size of int16_t instead of 4 bytes

// You however cannot do this:

MyPointer = (int32_t*)(((void*)MyPointer)++);

// Because no arithmetic operation can be done for void pointer.
// However if you have this instead...

MyPointer = (int32_t*)(((void**)MyPointer)++);

// That would become Pointer to Pointer to Void,
// it would increase by the size of pointer itself
