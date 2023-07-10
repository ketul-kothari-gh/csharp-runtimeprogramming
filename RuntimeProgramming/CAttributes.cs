[assembly: CLSCompliant(true)]

namespace RunTimeProgramming
{
    /// <summary>
    /// All attributes derive from abstract System.Attribute class
    /// They embed details into meta data 
    /// which is generally not useful unless clients reflects over it
    /// ex: intellisense reflects to find Obsolte marked class/methods etc and show warning
    /// ex: compiler reflects over CLSCompliant and show warning if any class is not compliant compliant
    /// </summary>
    /// 

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class CAttributes : Attribute
    {
        public string Message { get; set; }

        public CAttributes()
        {

        }

        public CAttributes(string message)
        {
            this.Message = message;
        }
    }

    public class NonCLSCompliant
    {
        public ulong NonCompilant { get; set; }
    }
}
