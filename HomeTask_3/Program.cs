using System;

namespace HomeTask_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account_1 = new(23, 37500.00, AccountType.BudgetAccount); // Создаем первый аккаунт.
            BankAccount account_2 = new(2500.00); // Создаем второй аккаунт.

            account_2.AccountType = AccountType.SavingAccount; // Воспользуемся свойством, чтобы установить тип банковского счета.

            // Выводим инфорамацию:
            Console.WriteLine("===== First Account ====="); 
            account_1.GetInfo(); 
            Console.WriteLine(); 

            Console.WriteLine("===== Second Account =====");
            account_2.GetInfo();
            Console.WriteLine(); 

            // Транзакция:
            Console.WriteLine("Выполним перевод в размере 2500 с первого аккаунта на второй: "); 
            account_1.MoneyTaransaction(account_2, 2500);
            Console.WriteLine("Результат:");

            // Снова выводим информацию:
            Console.WriteLine("===== First Account =====");
            account_1.GetInfo();
            Console.WriteLine();

            Console.WriteLine("===== Second Account =====");
            account_2.GetInfo();
            Console.WriteLine();

            // Вызов метода переворота строки:
            Console.Write("Введите строку, котору следует перевернуть: ");
            string str = Console.ReadLine();
            Console.WriteLine($"Получим: {ReverseString(str)}");
        }
        static string ReverseString(string str) // Метод, переворачивающий входную строку.
        {
            string reversedSring = String.Empty;
            for (int i = str.Length-1; i >= 0; i--)
            {
                reversedSring += str[i];
            }
            return reversedSring;
        }
    }
}
