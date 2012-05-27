using System;

namespace ThrowHelper.Inject.Tests
{
    public class TestClass
    {
        [Throw]
        public void TestMethod(string par)
        {
            Console.WriteLine(par);
        }

        [Throw]
        public void TestMethod2(string par, string par2)
        {
            Console.WriteLine(par);
        }

        public void TestMethod3([NotNull]string par, string par2)
        {
            Console.WriteLine(par);
        }

        public void TestMethod4([NotNull]string par, [NotNull]string par2)
        {
            Console.WriteLine(par);
        }
    }
}