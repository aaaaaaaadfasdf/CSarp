static partial class Control
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to MyProgram!");
        Setup();










        // look for functions
        while (true)
        {
            Console.Write("Enter a function call  or change variable var or Type Info ");
            string input = Console.ReadLine();

            // give Info
            if (input == "Info")
            {
                Console.WriteLine("");
                Console.WriteLine("functions");
                Console.WriteLine("Run(index)     takes how many genration it should run");
                Console.WriteLine("Animate(index) takes which generaiton to animate");
                Console.WriteLine("");
                Console.WriteLine("change variables");
                Console.WriteLine("1. type var");
                Console.WriteLine("2. type variable name");
                Console.WriteLine("3. enter new variable value");
                Console.WriteLine("");
                Console.WriteLine("variables");
                Console.WriteLine("folderDirectory      give it the directory of the disired folder in which the generations are stored, in which you can then continue to Run() or Animate()");
                Console.WriteLine("generationLength     says how many steps occure in a generation");
                Console.WriteLine("");

                continue;
            }

            


            if (input.StartsWith("var"))
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