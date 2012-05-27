using System;

namespace ThrowHelper.Example
{
    public class Class1
    {
        [Throw]
        public void Abc(string parameter1)
        {
            Console.WriteLine(parameter1);
        }
    }
}
