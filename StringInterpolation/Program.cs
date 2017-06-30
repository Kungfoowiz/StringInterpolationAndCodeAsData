using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ExtensionMethods;
using System.Data;


using System.Linq.Expressions; 


namespace StringInterpolation
{
    class Program
    {



        static void Main(string[] args)
        {


            //StringInterpolation(); 

            CodeAsData(); 

            Console.ReadLine();


        }

        private static void StringInterpolation()
        {
            int x = 1234;
            int y = 42;

            //int xDigits = 7;
            //int yDigits = 3;

            string Text =
                $"x = {x}, x.WithDigits(7) = {x.WithDigits(7)} \r\n" +
                $"y = {y}, y.WithDigits(3) = {y.WithDigits(3)} ";
            Console.WriteLine(Text);
            
        }


        private static void CodeAsData()
        {

            Expression<Func<int, int, int>> add = (x, y) => x + y;
            Expression<Func<int, int>> square = x => x * x;
            Expression<Action<int>> log = x => Console.WriteLine(x);

            var Add = add.Compile();
            var Square = square.Compile();
            var Log = log.Compile();

            Log(Square(Add(3, 5))); 

            // log(square(add(3, 5))); 

        }


        

    }
}




namespace ExtensionMethods {


    public static class MyExtensions
    {
        public static string WithDigits(this int Value, int Digits)
        {
            return Value.ToString(new string('0', Digits));
        }
    }


}