using System.Reflection;

namespace RunTimeProgramming
{
    class Reflection
    {
        public static void ObtainTypeAtRuntime()
        {
            // GetType fetches type at runtime
            SampleClass cls = new SampleClass();
            Type type = cls.GetType();
            Console.WriteLine("------------- Base class ref and actual object is also of SampleClass type -------------");
            Console.WriteLine(type.FullName);

            cls = new ChildSampleClass();
            type = cls.GetType();
            Console.WriteLine("------------- Base class ref but actual object is ChildSampleClass (child) type -------------");
            Console.WriteLine(type.FullName);

            // type of fetches type at compile time
            type = typeof(SampleClass);
            Console.WriteLine("------------- typeof(SampleClass) -------------");
            Console.WriteLine(type.FullName);

            type = typeof(ChildSampleClass);
            Console.WriteLine("------------- typeof(ChildSampleClass) -------------");
            Console.WriteLine(type.FullName);
        }

        public static void GatherInformationOfType()
        {
            Console.WriteLine("------------- Fethcing information of ChildSampleClass -------------");
            // will print details of all the parents class methods and props as well
            // but not constucotrs as they are not inherited

            ChildSampleClass cls = new ChildSampleClass();
            Type type = cls.GetType();

            ConstructorInfo[] cnsInfo = type.GetConstructors();
            Console.WriteLine("------------- Constructors -------------");
            foreach (var cns in cnsInfo)
            {
                Console.WriteLine("Constructor Name :  " + cns.Name);
                Console.WriteLine("Is constructor Public : " + cns.IsPublic);
                ParameterInfo[] pars = cns.GetParameters();

                foreach(var par in pars)
                {
                    Console.WriteLine("Parameter Name : " + par.Name);
                    Console.WriteLine("Parameter Type : " + par.ParameterType.Name);
                }
                Console.WriteLine();
            }

            // Will return implicit created methods - properties implemented using getter and setter
            MethodInfo[] methodInfos = type.GetMethods();
            Console.WriteLine("------------- Methods -------------");
            foreach (var method in methodInfos)
            {
                Console.WriteLine("Method Name :  " + method.Name);
                Console.WriteLine("Is method Public : " + method.IsPublic);
                ParameterInfo[] pars = method.GetParameters();

                foreach (var par in pars)
                {
                    Console.WriteLine("Parameter Name : " + par.Name);
                    Console.WriteLine("Parameter Type : " + par.ParameterType.Name);
                }
                Console.WriteLine();
            }

            PropertyInfo[] propInfos = type.GetProperties();
            Console.WriteLine("------------- Properties -------------");
            foreach (var prop in propInfos)
            {
                Console.WriteLine("Property Name :  " + prop.Name);
                Console.WriteLine("Can Read : " + prop.CanRead);
                Console.WriteLine("Can Write : " + prop.CanWrite);

                Console.WriteLine();
            }

            Console.WriteLine("------------- Base Class -------------");
            Type? baseType = type.BaseType;
            // returns null if the base type is object 
            if (baseType != null)
            {
                Console.WriteLine("Base type class : " + baseType.Name);
            }

            // Reflection can even break encapsulation.. dynamic cannot
            SampleClass sampleClass = new SampleClass();
            Console.WriteLine("------------- Invoke private methods --> break encapsulation -------------");
            MethodInfo mi = sampleClass.GetType().GetMethod("PrivateSampleMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            mi.Invoke(sampleClass, null);


        }
    }
}
