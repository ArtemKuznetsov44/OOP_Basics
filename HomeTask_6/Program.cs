using System;

namespace HomeTask_6
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new(100, 10200.08M, AccountType.BudgetAccount);
            BankAccount bankAccount2 = new(101, 10200.08M, AccountType.BudgetAccount);
            BankAccount bankAccount3 = new(102, 9999.99M, AccountType.SavingAccount);
            Console.WriteLine("============================== 1 ==============================");
            Console.WriteLine(bankAccount1.ToString());
            Console.WriteLine("============================== 2 ==============================");
            Console.WriteLine(bankAccount2.ToString());
            Console.WriteLine("============================== 3 ==============================");
            Console.WriteLine(bankAccount3.ToString());
            Console.WriteLine("===============================================================");
            Console.WriteLine(@"Oparator ""=="" test for 1st and 2nd accounts:");
            Console.WriteLine(bankAccount1 == bankAccount2);
            Console.WriteLine("===============================================================");
            Console.WriteLine("Equals() for 1st and 2nd accounts:"); 
            Console.WriteLine(bankAccount1.Equals(bankAccount2));
            Console.WriteLine("===============================================================");
            Console.WriteLine(@"Oparator ""!="" test for 1st and 2nd accounts:");
            Console.WriteLine(bankAccount1 != bankAccount2);
            Console.WriteLine("===============================================================");
            Console.WriteLine(@"Oparator ""!="" test for 1st and 3d accounts:");
            Console.WriteLine(bankAccount1 != bankAccount3);
            Console.WriteLine("===============================================================");
            Console.WriteLine($"1st account hashCode: {bankAccount1.GetHashCode()}");
            Console.WriteLine($"2st account hashCode: {bankAccount2.GetHashCode()}");
            Console.WriteLine($"3st account hashCode: {bankAccount3.GetHashCode()}");
            Console.WriteLine("===============================================================");
            Console.Read(); 
        }
    }
}
