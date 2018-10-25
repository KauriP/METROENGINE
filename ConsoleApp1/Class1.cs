using System;

namespace HelloWorld
{
    class Class1
    {
        static void Main()
        {
            Console.WriteLine("Hello World! Nyt siinä on huutomerkkikin. Anna jotain muuta, jonka perään voisi lisätä huutomerkin:");
            String input = Console.ReadLine();
            Console.WriteLine(input + "!");
            Console.ReadKey();
        }
    }

    
}