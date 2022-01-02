using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5
{
    class Operations 
    {
        private static double GreatesCommonFactor(double numerator, double denominator) // Вычисление наибольшего
                                                                                        // общего делителя (НОД).
        {
            if (numerator < 0)
                numerator = -numerator;
            if (denominator < 0)
                denominator = -denominator;
            // Алгоритм Евклида: 
            while (denominator > 0)
            {
                double temp = denominator;
                denominator = numerator % denominator;
                numerator = temp;
            }
            return numerator;
        }
       
        public static void FractionReduction(RationalNumber rationalNumber) // Сокращение переданной дроби.
        {
            double greatesCommonFactor = GreatesCommonFactor(rationalNumber.Numerator, rationalNumber.Denominator);
            rationalNumber.Numerator /= greatesCommonFactor;
            rationalNumber.Denominator /= greatesCommonFactor;
        }
       
        public static void BringingFractionsToCommonDenomitor(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)  // Приведение
                                                                                                                                 // дробей к общему
                                                                                                                                 // знаменателю.
        {
            double leastCommonMultiple = LeastCommonMultiple(rationalNumber_1.Denominator, rationalNumber_2.Denominator);
            rationalNumber_2.Denominator = leastCommonMultiple;
            rationalNumber_2.Denominator = leastCommonMultiple; 
            rationalNumber_1.Numerator *= leastCommonMultiple / rationalNumber_1.Numerator;
            rationalNumber_2.Numerator *= leastCommonMultiple / rationalNumber_1.Numerator;
        }
      
        private static double LeastCommonMultiple(double denominator_1, double denominator_2)   // Вычисление
                                                                                                // наименьшего общего
                                                                                                // кратного через НОД (НОК).
        {
            return Math.Abs(denominator_1 * denominator_2) / GreatesCommonFactor(denominator_1, denominator_2); 
        }
    }
}
