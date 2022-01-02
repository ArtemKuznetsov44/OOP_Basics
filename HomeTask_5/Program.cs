using System;

namespace HomeTask_5
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rationalNumber = new(4, 5);
            RationalNumber rationalNumber1 = new(8, 10);
            Console.WriteLine(rationalNumber1.ToString());
            Operations.FractionReduction(rationalNumber1);
            Console.WriteLine(rationalNumber1.ToString());
            RationalNumber rationalNumber_result = rationalNumber + rationalNumber1;
            Console.WriteLine(rationalNumber_result.ToString()); 
            Console.Read(); 

        }
    }
}
