using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeProgramming
{
    /// <summary>
    /// dynamic : Removes compile time checking, uses Dynamic language runtime
    /// resolved at runtime, may throw error
    /// especially useful in dynamic loading (late binding) and COM programming 
    /// can be used as parameter type and return type
    /// </summary>
    class DynamicKeyword
    {
        public static void DynamicLoadAndCreateObject()
        {
            Console.WriteLine("Load TestLibrary at runtime, no reference added");

            Assembly asm = Assembly.LoadFrom(Directory.GetCurrentDirectory() + "\\TestLibrary");

            Console.WriteLine("Print assembly info");
            Console.WriteLine("Assembly name" + asm.FullName);

            Console.WriteLine("Identify types");
            foreach (var type in asm.GetTypes())
            {
                Console.WriteLine("Name : " + type.FullName);
                if (type.Name == "Car")
                {
                    foreach(var mi in type.GetMethods())
                    {
                        Console.WriteLine("Method name " + mi.Name + " " + "Method return type " + mi.ReturnType.Name);
                        foreach(var par in mi.GetParameters())
                        {
                            Console.WriteLine(par.Name);
                            Console.WriteLine(par.ParameterType.Name);
                        }
                        Console.WriteLine();
                    }


                    // this returns object, this assembly has no idea of type called Car at compile time
                    // Cannot even type case
                    // Object obj = Activator.CreateInstance(type, "Dummy", 100);
                    // dynamic respects encapsulation 
                    dynamic obj = Activator.CreateInstance(type, "Dummy", 100);

                    // Invoke method on the object, cannot case
                    // MethodInfo mi = type.GetMethod("Show");
                    Console.WriteLine("Calling method of dynamically loaded object");
                    // mi.Invoke(obj, null);
                    obj.Show();
                }
            }
        }
    }
}
