using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunTimeProgramming
{
    /// <summary>
    /// Dynnamic Load here reflects - dynamic loading assemblies of which no reference is available
    /// Creating objecta of types available in such assemblies 
    /// </summary>
    class DynamicLoad
    {
        public static void DynamicLoadAndCreateObject()
        {
            Console.WriteLine("Load TestLibrary at runtime, no reference added");

            Assembly asm = Assembly.LoadFrom(Directory.GetCurrentDirectory() + "\\TestLibrary");

            Console.WriteLine("Print assembly info");
            Console.WriteLine("Assembly name" + asm.FullName);

            Console.WriteLine("Identify types");
            foreach(var type in asm.GetTypes())
            {
                Console.WriteLine("Name : " + type.FullName);
                if(type.Name == "Car")
                {
                    // this returns object, this assembly has no idea of type called Car at compile time
                    // Cannot even type cast
                    Object obj = Activator.CreateInstance(type, "Dummy", 100);

                    // Invoke method on the object, cannot case
                    MethodInfo mi = type.GetMethod("Show");
                    Console.WriteLine("Calling method of dynamically loaded object");
                    mi.Invoke(obj, null);
                }
            }
        }
    }
}
