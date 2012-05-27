using System;

namespace ThrowHelper.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new Class1();

            Console.WriteLine("Must throw exception");
            try
            {
                class1.Abc(null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.WriteLine("\n==========================\n");
            Console.WriteLine("Should not throw exception");
            try
            {
                class1.Abc("This time will not throw exception");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
}