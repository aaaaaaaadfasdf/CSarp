static partial class Control
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to MyProgram!");
        Setup();
        Run(2);
      
        
     
      
        



// look for functions
        while (true)
        {
            Console.Write("Enter a function call  or change variable or Type Info ");
    string input = Console.ReadLine();

// give Info
    if(input == "Info"){
        Console.WriteLine("Functions");
        Console.WriteLine("Run(index)     takes how many gen it should run");
        Console.WriteLine("Animate(index)  takes which generaiton to run");
        Console.WriteLine("");
        Console.WriteLine("Variables");
        Console.WriteLine("1. type change variable");
        Console.WriteLine("2. type variable name");
        Console.WriteLine("2. enter new variable value");
        Console.WriteLine("folderDirectory      give it the directory of the disired folder in which you can continue Run() or Animate()");
        Console.WriteLine("generationLength     says how many steps occure in a generation");  
    }


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