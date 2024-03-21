static partial class Control
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to MyProgram!");
        Setup();
        Run(2);
   
        
     
      
        




        while (true)
        {
            Console.Write("Enter a function call  or 'change variable' command: ");
    string input = Console.ReadLine();

    if (input.StartsWith("change variable"))
    {
        Console.Write("Enter the variable name: ");
        string variableName = Console.ReadLine();
        Console.Write("Enter the new value: ");
        string newValue = Console.ReadLine();

        ChangeVariable(variableName, newValue);
    }
    else
    {
        // Parse the function call and invoke the function (your existing code)
        if (TryParseFunctionCall(input, out string functionName, out object[] arguments))
        {
            InvokeFunction(functionName, arguments);
        }
        else
        {
            Console.WriteLine("Invalid function call or command. Try again.");
        }
    }
          
        }
    }

}