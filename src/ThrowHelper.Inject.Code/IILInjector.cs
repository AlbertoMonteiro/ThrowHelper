using System.Collections.Generic;
using Mono.Cecil;

namespace ThrowHelper.Inject
{
    public interface IILInjector
    {
        IEnumerable<MethodDefinition> methods { get; set; }
        void LoadAssemblyAndGetMethods();
        void Inject();
        void Save();
    }
}