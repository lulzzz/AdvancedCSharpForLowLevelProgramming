Stack<string> originalStack;
Stack<string> tempStack = new Stack<string>(originalStack);
originalStack.Clear();

while (tempStack.Count != 0){
    originalStack.Push(tempStack.Pop());
}