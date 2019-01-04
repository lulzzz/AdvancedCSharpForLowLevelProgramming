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
    strcpy(val->StringData, DefaultMsg);
    val->StringData[strlen(DefaultMsg)] = 0;
}

void SetDefaultMessage2(char* val)
{
    strcpy(val, DefaultMsg);
    val[strlen(DefaultMsg)] = 0;
}
