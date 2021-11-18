using System;

namespace HomeTask_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tЗадание №1 ");
            BankAccount_FirstTask firstTask = new();
            firstTask.AccountNumberSetter(1);
            firstTask.BalanceSetter(1000);
            firstTask.AccountTypeSetter(AccountTypes.SavingAccount);
            firstTask.GetAllInfo();
            Console.WriteLine(); 

            Console.WriteLine("\tЗадание №2"); 

            BankAccount_SecondTask secondTask_1 = new();
            secondTask_1.AccountNumberSetter();
            secondTask_1.BalanceSetter(4001.12);
            secondTask_1.AccountTypeSetter(AccountTypes.BudgetAccount);
            secondTask_1.GetAllInfo();

            Console.WriteLine(); 

            BankAccount_SecondTask secondTask_2 = new();
            secondTask_2.AccountNumberSetter();
            secondTask_2.BalanceSetter(12241.88);
            secondTask_2.AccountTypeSetter(AccountTypes.SavingAccount);
            secondTask_2.GetAllInfo();

            Console.WriteLine();

            BankAccount_SecondTask secondTask_3 = new();
            secondTask_3.AccountNumberSetter();
            secondTask_3.BalanceSetter(5321.37);
            secondTask_3.AccountTypeSetter(AccountTypes.SavingAccount);
            secondTask_3.GetAllInfo();
            Console.WriteLine(); 

            Console.WriteLine("\tЗадание №3");
            BankAccount_ThridTask thirdTask_1 = new();
            BankAccount_ThridTask thirdTask_2 = new(54002.13);
            BankAccount_ThridTask thirdTask_3 = new(73222.00,  AccountTypes.BudgetAccount);
            Console.WriteLine($"Первый конструктор: {thirdTask_1.AccountNumber}");
            Console.WriteLine($"Второй конструктор: {thirdTask_2.AccountNumber} | {thirdTask_2.Balance}");
            Console.WriteLine($"Третий конструктор: {thirdTask_3.AccountNumber} | {thirdTask_3.Balance} | {thirdTask_3.AccountType}");
            Console.WriteLine();

            Console.WriteLine("\tЗадание №4");
            BankAccount_FourthTask fourthTask = new();
            fourthTask.AccountNumber = 38;
            fourthTask.Balance = 135000.50;
            fourthTask.AccountType = AccountTypes.SavingAccount;
            Console.WriteLine($"Номер счета: {fourthTask.AccountNumber}");
            Console.WriteLine($"Баланс: {fourthTask.Balance}");
            Console.WriteLine($"Тип счета: {fourthTask.AccountType}");

        }
    }
}
