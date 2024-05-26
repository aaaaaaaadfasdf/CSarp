using System.Reflection;
// Lisens to user input.


static partial class Control
{


static void ChangeVariable(string variableName, string newValueStr)
{
    // Get the type of the Control class
    Type controlType = typeof(Control);

    // Find the field with the given name
    FieldInfo fieldInfo = controlType.GetField(variableName, BindingFlags.Static | BindingFlags.Public);

    if (fieldInfo != null)
    {
        // Get the type of the field
        Type fieldType = fieldInfo.FieldType;

        // Convert the new value to the appropriate type
        object newValue;
        if (fieldType == typeof(int))
        {
            newValue = int.Parse(newValueStr);
        }
        else if (fieldType == typeof(float))
        {
            newValue = float.Parse(newValueStr);
        }
        else if (fieldType == typeof(double))
        {
            newValue = double.Parse(newValueStr);
        }
        else if (fieldType == typeof(bool))
        {
            newValue = bool.Parse(newValueStr);
        }
        else
        {
            newValue = newValueStr;
        }

        // Set the new value for the field
        fieldInfo.SetValue(null, newValue);
        Console.WriteLine($"Variable '{variableName}' has been set to '{newValue}'.");
    }
    else
    {
        Console.WriteLine($"Variable '{variableName}' not found.");
    }
}
    static bool TryParseFunctionCall(string input, out string functionName, out object[] arguments)
    {
        functionName = null;
        arguments = null;

        try
        {
            // Remove any whitespace and split the input into function name and arguments
            input = input.Replace(" ", "");
            int openParenIndex = input.IndexOf('(');
            int closeParenIndex = input.LastIndexOf(')');

            functionName = input.Substring(0, openParenIndex);
            string argumentsStr = input.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1);
            string[] args = argumentsStr.Split(',');

            arguments = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                arguments[i] = int.Parse(args[i]); // Assuming all arguments are integers for simplicity
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

static void InvokeFunction(string functionName, object[] arguments)
    {
        try
        {
            // Get the method info of the function
            MethodInfo methodInfo = typeof(Control).GetMethod(functionName, BindingFlags.Static | BindingFlags.NonPublic);

            // Invoke the method with the provided arguments
            if (methodInfo != null)
            {
                methodInfo.Invoke(null, arguments);
            }
            else
            {
                Console.WriteLine($"Function '{functionName}' not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing function '{functionName}': {ex.Message}");
        }
    }
    


}