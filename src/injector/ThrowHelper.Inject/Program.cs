namespace ThrowHelper.Inject
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) return;

            var injector = new ThrowHelperIilInjector(args[0]);
            injector.Inject();
            injector.Save();
        }
    }
}
