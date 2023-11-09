namespace labatym9
{
   
    class BankAccountEx1
    {
        #region Поля
        private static int numberOfBankAccounts;
        private int accountNumber;
        private decimal accountBalance;
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
                return true;
            }

            return false;
        }

       
        public bool PutMoneyIntoAccount(decimal depositedAmoun)
        {
            if (depositedAmoun > 0)
            {
                accountBalance += depositedAmoun;
                return true;
            }

            return false;
        }

       
        public bool TransferringMoney(BankAccountEx1 withdrawalAccount, decimal withdrawalAmount)
        {
            if ((withdrawalAmount > 0) && (withdrawalAccount.AccountBalance - withdrawalAmount > 0))
            {
                accountBalance += withdrawalAmount;
                withdrawalAccount.accountBalance -= withdrawalAmount;
                return true;
            }

            return false;
        }
        #endregion

        #region Конструкторы
 
        public BankAccountEx1(decimal accountBalance)
        {
            this.accountBalance = accountBalance;
            bankAccountType = AccountType.Текущий_счет;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

        public BankAccountEx1(AccountType bankAccountType)
        {
            this.bankAccountType = bankAccountType;
            accountBalance = 0;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }

  
        public BankAccountEx1(decimal accountBalance, AccountType bankAccountType)
        {
            this.accountBalance = accountBalance;
            this.bankAccountType = bankAccountType;
            accountNumber = numberOfBankAccounts;
            ChangeNumberOfBankAccounts();
        }
        #endregion
    }
}