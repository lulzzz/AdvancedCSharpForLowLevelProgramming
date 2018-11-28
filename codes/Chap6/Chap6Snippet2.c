#include <stdlib.h>
#include <stdio.h>
#include <string.h>

static char* DefaultMsg = "Hello, this is from native code";

void AnsiString(char* str)
{
    printf("%s\n", str);
}

typedef struct
{
    char StringData[128];
} ByValString;

ByValString* Initialize()
{
    return (ByValString*)malloc(sizeof(ByValString));
}

void SetDefaultMessage(ByValString* val)
{
    strcpy(DefaultMsg, val->StringData);
    val->StringData[strlen(DefaultMsg)] = 0;
}
