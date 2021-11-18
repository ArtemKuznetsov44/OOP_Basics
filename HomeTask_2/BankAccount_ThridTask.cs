using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2
{
    class BankAccount_ThridTask // Задание №3.
    {
        private static int Counter = 0; 
        private int _accountNumber { get; set;  }
        private double _balance { get; }
        private Enum _accountType { get; }

        public BankAccount_ThridTask()
        {
            SetAccountNumber(); 
        }
        public BankAccount_ThridTask(double balance)
        {
            SetAccountNumber(); 
            this._balance = balance; 
        }
        public BankAccount_ThridTask(Enum accountType)
        {
            SetAccountNumber();
            this._accountType = accountType; 
        }
        public BankAccount_ThridTask(double balance, Enum accountType)
        {
            SetAccountNumber();
            this._balance = balance;
            this._accountType = accountType;
        }
        private void SetAccountNumber() { this._accountNumber = ++Counter; }

        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public double Balance
        {
            get { return _balance; }
        }
        public Enum AccountType
        {
            get { return _accountType; }
        }
    }
}
