using System.Linq;
using Mono.Cecil;
using FluentIL.Cecil;

namespace ThrowHelper.Inject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null)
            {
                var assembly = AssemblyDefinition.ReadAssembly(args[0]);
                var methods = assembly.MainModule.Types.
                    SelectMany(type => type.Methods).
                    Where(HaveThrowAttribute);

                foreach (var method in methods)
                {
                    var type = typeof (Throw);
                    var methodInfo = type.GetMethod("IfArgumentNull");
                    foreach (var parameter in method.Parameters)
                    {
                        method.InsertBefore().
                            Ldarg(parameter.Name).
                            Ldstr(parameter.Name).
                            Ldnull().
                            Call(methodInfo);
                    }
                }
                assembly.Write(args[0]);
            }
        }

        private static bool HaveThrowAttribute(MethodDefinition method)
        {
            return method.CustomAttributes.Any(attribute => attribute.AttributeType.Name == "ThrowAttribute");
        }
    }
}
