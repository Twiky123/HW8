using System;

namespace labatym9
{
    
    class BankTransaction
    {
        #region Поля
        private DateTime transactionDate;
        private decimal amountChange;
        #endregion

        #region Свойства
      
        public DateTime TransactionDate
        {
            get
            {
                return transactionDate;
            }
        }

        
        public decimal AmountChange
        {
            get
            {
                return amountChange;
            }
        }
        #endregion

        #region Конструкторы
        
        public BankTransaction(decimal amountChange)
        {
            this.amountChange = amountChange;
            transactionDate = DateTime.Now;
        }
        #endregion
    }
}