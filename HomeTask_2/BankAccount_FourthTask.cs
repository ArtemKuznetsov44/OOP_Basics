using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_2
{
    class BankAccount_FourthTask // Задание №4.
    {
        private int _accountNumber { get; set; }
        private double _balance { get; set; }
        private Enum _accountType { get; set; }

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
            get { return _accountType; }
            set { _accountType = value; }
        }
    }
}
