using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2
{
    class BankAccount_FirstTask // Первое задание. 
    {
        private int _accountNumber;
        private double _balance;
        private Enum _accountType;

        public void AccountNumberSetter(int accountNumber) { this._accountNumber = accountNumber; }
        public int AccountNumberGetter() { return this._accountNumber; }
        public void BalanceSetter(int accountNumber) { this._balance = accountNumber; }
        public double BalanceGetter() { return this._balance; }
        public void AccountTypeSetter(Enum accountType) { this._accountType = accountType; }
        public Enum AccountTypeGetter() { return this._accountType; }
        public void GetAllInfo()
        {
            if (this._accountNumber != default(int) && this._balance != default(double) && this._accountType != default(Enum))
            {
                Console.WriteLine("Информация:");
                Console.WriteLine($"Номер счета: {this._accountNumber}");
                Console.WriteLine($"Баланс: {this._balance}");
                Console.WriteLine($"Тип банковского счета: {this._accountType}");
            }
            else
                Console.WriteLine("Нет данных!");
        } // Метод вывода информации о банковском счете.
    }
}
