using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_6
{
    class BankAccount
    {
        private static int _counter = 0;
        private int _accountNumber; // id.
        private decimal _balance;  // Баланс.
        private Enum _acountType; // Тип банковского счета.

        #region //Конструкторы.
        public BankAccount() // Без параметров - устанавливаем значение id по умолчанию.
        {
            this._accountNumber = GetDefNumber();
        }
        public BankAccount(int accountNumber) // При передаче id - устанавливаем переданное id.
        {
            this._accountNumber = accountNumber;
        }
        public BankAccount(decimal balance) : this() // При передаче баланаса - устанавливаем значение id по умолчанию и переданный баланс.
        {
            this._balance = balance;
        }
        public BankAccount(Enum type) : this() // При передаче типа счета - уставливаем значение id по умолчанию и преданный тип счета.
        {
            this._acountType = type;
        }
        public BankAccount(int accountNumber, decimal balance, Enum type) // Если переданы сразу три параметра.
        {
            this._accountNumber = accountNumber;
            this._balance = balance;
            this._acountType = type;
        }
        #endregion

        #region // Методы класса.
        public void MoneyTaransaction(BankAccount account, decimal sum) // Перевод средств с одного счета на другой.
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
        #endregion

        #region // Переопределение операторов, метода ToString() и метода GetHashCode().
        public static bool operator ==(BankAccount bankAccount_1, BankAccount bankAccount_2)
        {
            if (bankAccount_1.GetType() == null || bankAccount_2.GetType() == null)
                throw new ArgumentException(); 
            // Я немного не понял, почему если у меня у двух акаунтов указан тип BugetAccount, то при сравении без ToString()
            // мне выдает false...
            if (bankAccount_1.Balance == bankAccount_2.Balance && bankAccount_1.AccountType.ToString() == bankAccount_2.AccountType.ToString())
                return true;
            else 
                return false;   
        }
        public static bool operator !=(BankAccount bankAccount_1, BankAccount bankAccount_2)
        {
            if (bankAccount_1.GetType() == null || bankAccount_2.GetType() == null)
                throw new ArgumentException(); 
            // Таже история с ToStaring()...
            if (bankAccount_1.Balance != bankAccount_2.Balance && bankAccount_1.AccountType.ToString() != bankAccount_2.AccountType.ToString())
                return true;
            else 
                return false;
        }
        public override bool Equals(object obj) 
        {
            if (obj == null)
                return false;
            BankAccount bankAccount = (BankAccount)obj;
            if (this.Balance == bankAccount.Balance && this.AccountType.ToString() == bankAccount.AccountType.ToString())
                return true;
            else 
                return false; 
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AccountNumber, Balance, AccountType);  
        }
        public override string ToString()
        {
            if (GetType() == null)
                throw new ArgumentException();
            return $"AccountId: {AccountNumber} | Balance: {Balance} | AccountType: {AccountType}";
        }
        #endregion

        #region // Свойства.
        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public decimal Balance
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

