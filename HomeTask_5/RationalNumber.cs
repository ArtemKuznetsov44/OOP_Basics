using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5
{
    class RationalNumber
    {
        private double _numerator; // Числитель
        private double _denominator; // Знаменатель

        #region // Конструкторы.
        private RationalNumber() { }
        public RationalNumber(int numerator, int denomerator) // Основной конструтор.
        {
            if (denomerator == 0)
                throw new Exception("Denominator cannot be zero.");
            this._numerator = numerator;
            this._denominator = denomerator;
        }
        #endregion

        #region // Свойства.
        public double Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public double Denominator
        {
            get { return _denominator; }
            set { _denominator = value; }
        }
        #endregion 
      
        #region // Переопределение операторов.
        public static RationalNumber operator *(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            RationalNumber rationalNumber_result = new();
            rationalNumber_result.Numerator = rationalNumber_1.Numerator * rationalNumber_2.Numerator;
            rationalNumber_result.Denominator = rationalNumber_1.Denominator * rationalNumber_2.Denominator;
            return rationalNumber_result;
        }
        public static RationalNumber operator /(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            RationalNumber rationalNumber_result = new();
            rationalNumber_result.Numerator = rationalNumber_1.Numerator * rationalNumber_2.Denominator;
            rationalNumber_result.Denominator = rationalNumber_1.Denominator * rationalNumber_2.Numerator;
            return rationalNumber_result;
        }
        public static double operator %(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 % value_2; 
        }

        public static bool operator >(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 > value_2;
        }
        public static bool operator >=(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 >= value_2;
        }
        public static bool operator <(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 < value_2;
        }
        public static bool operator <=(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 <= value_2;
        }
        public static bool operator ==(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 == value_2;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            RationalNumber rationalNumber = (RationalNumber)obj;
            if (Numerator == rationalNumber.Numerator && Denominator == rationalNumber.Denominator)
                return true;
            else
                return false;
        }
        public static bool operator !=(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            double value_1 = rationalNumber_1.Numerator / rationalNumber_1.Denominator;
            double value_2 = rationalNumber_2.Numerator / rationalNumber_2.Denominator;
            return value_1 != value_2;
        }
        public static RationalNumber operator +(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            if(rationalNumber_1.Denominator != rationalNumber_2.Denominator)
                Operations.BringingFractionsToCommonDenomitor(rationalNumber_1, rationalNumber_2);
            RationalNumber rationalNumber_result = new();
            rationalNumber_result.Denominator = rationalNumber_1.Denominator;
            rationalNumber_result.Numerator = rationalNumber_1.Numerator + rationalNumber_2.Numerator;
            Operations.FractionReduction(rationalNumber_result);
            return rationalNumber_result;
        }
        public static RationalNumber operator -(RationalNumber rationalNumber_1, RationalNumber rationalNumber_2)
        {
            //if (rationalNumber_1 == null || rationalNumber_2 == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            Operations.BringingFractionsToCommonDenomitor(rationalNumber_1, rationalNumber_2);
            RationalNumber rationalNumber_result = new();
            rationalNumber_result.Denominator = rationalNumber_1.Denominator;
            rationalNumber_result.Numerator = rationalNumber_1.Numerator - rationalNumber_2.Numerator;
            return rationalNumber_result;
        }
        public static RationalNumber operator ++(RationalNumber rationalNumber)
        {
            //if (rationalNumber == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            rationalNumber.Numerator += rationalNumber.Denominator;
            return rationalNumber;
        }
        public static RationalNumber operator --(RationalNumber rationalNumber)
        {
            //if (rationalNumber == null)
            //    throw new ArgumentNullException("Pass parameteres are not correct!");
            rationalNumber.Numerator -= rationalNumber.Denominator;
            return rationalNumber;
        }
        #endregion

        #region // Перегрузка операторов преобразования типов и метода ToString().
        public static explicit operator float(RationalNumber rationalNumber)
        {
            return (float)(rationalNumber.Numerator / rationalNumber.Denominator);
        }
        public static explicit operator int(RationalNumber rationalNumber)
        {
            return (int)(rationalNumber.Numerator / rationalNumber.Denominator);
        }
        public override string ToString()  // Переопределение метода ToString() для вывода дроби.
        {
            return $"{Numerator} / {Denominator}";
        }
        #endregion
    }
}
