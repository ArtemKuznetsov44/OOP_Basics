using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3
{
    class BankAccount
    {
        private static int _counter = 0;
        private int _accountNumber { get; set; } // id.
        private double _balance { get; set; } // Баланс.
        private Enum _acountType { get; set; } // Тип банковского счета.

        #region //Конструкторы.
        public BankAccount() // Без параметров - устанавливаем значение id по умолчанию.
        {
            this._accountNumber = GetDefNumber();
        }
        public BankAccount(int accountNumber) // При передаче id - устанавливаем переданное id.
        {
            this._accountNumber = accountNumber; 
        }
        public BankAccount(double balance) : this() // При передаче баланаса - устанавливаем значение id по умолчанию и переданный баланс.
        {
            this._balance = balance; 
        }
        public BankAccount (Enum type): this() // При передаче типа счета - уставливаем значение id по умолчанию и преданный тип счета.
        {
            this._acountType = type; 
        }
        public BankAccount(int accountNumber, double balance, Enum type) // Если переданы сразу три параметра.
        {
            this._accountNumber = accountNumber;
            this._balance = balance;
            this._acountType = type;
        }
        #endregion

        public void MoneyTaransaction(BankAccount account, double sum) // Перевод средств с одного счета на другой.
        {
            if (sum <= this.Balance)
            {
                this._balance -= sum;
                account._balance += sum;
            }
            else
                Console.WriteLine("Недостаточно средств ! Транзакция отменена."); 
        }
        public void GetInfo()
        {
            Console.WriteLine($"Номер банковского счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип банковского счета: {AccountType}");
        }
        private int GetDefNumber() // Увеличиваем значение нашего счетчика (деффолтного id).
        {
            return ++_counter;
        }

        #region //Свойства полей.
        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public Enum AccountType
        {
            get { return _acountType; }
            set { _acountType = value; }
        }
        #endregion
    }
}
