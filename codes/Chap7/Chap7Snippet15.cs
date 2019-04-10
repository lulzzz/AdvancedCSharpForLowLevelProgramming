int DoAdd(int a)
{
    int variable = 0;
    try
    {
        variable = a + int.MaxValue;
        goto End;
    }
    fault
    {
        Console.WriteLine("Fault block called.");
        throw; // rethrow the exception
    }
    End:
    return variable;
}
