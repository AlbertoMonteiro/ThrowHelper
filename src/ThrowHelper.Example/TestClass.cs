using System;

namespace ThrowHelper.Example
{
    public class TestClass
    {
        [Throw]
        public void TestMethod(string param1)
        {
            Console.WriteLine(param1);
        }
        
        public void TestMethod2([NotNull]string paramNotNull)
        {
            Console.WriteLine(paramNotNull);
        }
    }
}
