using System.Collections.Generic;
using System.Linq;
using FluentIL.Cecil;
using Mono.Cecil;

namespace ThrowHelper.Inject
{
    public class ThrowHelperIilInjector : IILInjector
    {
        private readonly string assemblyPath;
        private readonly string outputPath;
        private AssemblyDefinition assembly;

        public ThrowHelperIilInjector(string assemblyPath, string outputPath = null)
        {
            this.assemblyPath = assemblyPath;
            this.outputPath = outputPath ?? assemblyPath;
        }

        public void Inject()
        {
            LoadAssemblyAndGetMethods();

            foreach (var method in methods)
            {
                var type = typeof (Throw);
                var methodInfo = type.GetMethod("IfArgumentNull");
                IEnumerable<ParameterDefinition> parameters;
                if (HaveThrowAttribute(method))
                    parameters = method.Parameters;
                else
                    parameters = from parameter in method.Parameters
                                 where parameter.HasCustomAttributes
                                 from attribute in parameter.CustomAttributes
                                 where attribute.AttributeType.Name == "NotNullAttribute"
                                 select parameter;

                foreach (var parameter in parameters.Reverse())
                    method.InsertBefore().
                        Ldarg(parameter.Name).
                        Ldstr(parameter.Name).
                        Ldnull().
                        Call(methodInfo);
            }
        }

        public void Save()
        {
            if (!string.IsNullOrWhiteSpace(outputPath))
                assembly.Write(outputPath);
        }

        public IEnumerable<MethodDefinition> methods { get; set; }

        public void LoadAssemblyAndGetMethods()
        {
            assembly = AssemblyDefinition.ReadAssembly(assemblyPath);
            methods = assembly.MainModule.Types.
                SelectMany(type => type.Methods);
        }

        private static bool HaveThrowAttribute(MethodDefinition method)
        {
            return method.CustomAttributes.Any(attribute => attribute.AttributeType.Name == "ThrowAttribute");
        }
    }
}