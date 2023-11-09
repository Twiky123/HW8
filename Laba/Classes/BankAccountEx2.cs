using System.Collections.Generic;

namespace labatym9
{
   
    class BankAccountEx2
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

      
        public Queue<BankTransaction> TransactionList
        {
            get
            {
                return transactionList;
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

        
        public bool TransferringMoney(BankAccountEx2 withdrawalAccount, decimal withdrawalAmount)
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
        #endregion

        #region Конструкторы
        
        public BankAccountEx2(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        
        public BankAccountEx2(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        
        public BankAccountEx2(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}