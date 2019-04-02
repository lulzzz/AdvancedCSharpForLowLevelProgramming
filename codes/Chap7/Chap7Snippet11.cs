var index = 0;
goto condition;
body:
Console.WriteLine(index);
++index;
condition:
if (index < 10) goto body;
