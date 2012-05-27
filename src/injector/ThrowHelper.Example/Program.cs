using System;

namespace ThrowHelper.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var class1 = new TestClass();
            
            Console.WriteLine("For TestMethod method");
            Console.WriteLine("Must throw exception");
            try
            {
                class1.TestMethod(null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            Console.WriteLine("\n==========================\n");
            Console.WriteLine("Should not throw exception");
            try
            {
                class1.TestMethod("This time will not throw exception");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\nFor TestMethod2 method");
            Console.WriteLine("Must throw exception");
            try
            {
                class1.TestMethod2(null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\n==========================\n");
            Console.WriteLine("Should not throw exception");
            try
            {
                class1.TestMethod2("This time will not throw exception");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }
    }
}