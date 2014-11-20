using System;

namespace ThrowHelper.Inject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) return;

            var injector = new ThrowHelperIilInjector(args[0]);
            Console.WriteLine("Injetando código");
            injector.Inject();
            Console.WriteLine("Código injetado");
            Console.WriteLine("Salvando");
            injector.Save();
            Console.WriteLine("Salvo");
        }
    }
}
