using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Console.WriteLine("Path:");
        string assemblyPath = Console.ReadLine();

        try
        {
           
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine($"Class: {type.FullName}");

   
                MethodInfo[] methods = type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    Console.Write($"  Method: {method.ReturnType.Name} {method.Name}(");

                    ParameterInfo[] parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i < parameters.Length - 1)
                            Console.Write(", ");
                    }

                    Console.WriteLine(")");
                }

                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erorr: {ex.Message}");
        }

        Console.ReadLine();
    }
}
