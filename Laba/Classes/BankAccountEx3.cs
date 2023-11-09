using System.Collections.Generic;
using System;
using System.IO;

namespace labatym9
{
    
    class BankAccountEx3
    {
        #region Поля
        private static int numberOfBankAccounts;
        private int accountNumber;
        private decimal accountBalance;
        private Queue<BankTransaction> transactionList = new Queue<BankTransaction>();
        private AccountType bankAccountType;
        #endregion

        #region Свойства
        
        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }

        
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
        }

        
        public AccountType BankAccountType
        {
            get
            {
                return bankAccountType;
            }
        }
        #endregion

        #region Методы
        
        private void ChangeNumberOfBankAccounts()
        {
            numberOfBankAccounts++;
        }

       
        public bool WithdrawMoneyFromAccount(decimal withdrawalAmount)
        {
            if ((accountBalance - withdrawalAmount > 0) && (withdrawalAmount > 0))
            {
                accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(-withdrawalAmount);
                transactionList.Enqueue(bankTransaction);
                return true;
            }

            return false;
        }

       
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                BankTransaction bankTransaction = new BankTransaction(depositedAmoun);
                transactionList.Enqueue(bankTransaction);
                return true;
            }

            return false;
        }

        
        public bool TransferringMoney(BankAccountEx3 withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                BankTransaction bankTransaction = new BankTransaction(-withdrawalAmount);
                transactionList.Enqueue(bankTransaction);
                return true;
            }

            return false;
        }

      
        public void Dispose(BankAccountEx3 bankAccount)
        {
            int count = transactionList.Count;

            for (int i = 0; i < count; i++)
            {
                BankTransaction transaction = transactionList.Dequeue();

                if (transaction.AmountChange < 0)
                {
                    File.AppendAllText("ProgramFiles/dispose.txt", $"Снятие {transaction.TransactionDate}, {-transaction.AmountChange} рублей".ToString() + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText("ProgramFiles/dispose.txt", $"Пополнение {transaction.TransactionDate}, {transaction.AmountChange} рублей".ToString() + Environment.NewLine);
                }
            }

            GC.SuppressFinalize(bankAccount);
        }
        #endregion

        #region Конструкторы
       
        public BankAccountEx3(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

       
        public BankAccountEx3(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

      
        public BankAccountEx3(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}