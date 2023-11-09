using System.Collections.Generic;
using System;


namespace labatym9
{

    public enum AccountType
    {
        Текущий_счет,
        Сберегательный_счет
    }

    class Program
    {
        static void Main()
        {
            bool tasksEnd = false;
            string taskNumber;

            do
            {
                Console.WriteLine("Лаборатоная работа№9 Тумакова");
                Console.WriteLine("Подсказка:\n" +
                                  "Упражнение 9.1. -   цифра 1\n" +
                                  "Упражнения 9.2. -   цифра 2\n" +
                                  "Упражнение 9.3. -   цифра 3\n" +
                                  "Домашнее задание 9.1. -   цифра 4\n" +
                                  "Закончить выполнение заданий. -   цифра 0\n");

                Console.Write("Введите номер задания: ");
                taskNumber = Console.ReadLine();

                switch (taskNumber)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Упражнение 9.1");

                        BankAccountEx1 firstBankAccount = new BankAccountEx1(1000000);
                        BankAccountEx1 secondBankAccount = new BankAccountEx1(AccountType.Сберегательный_счет);
                        BankAccountEx1 thirdBankAccount = new BankAccountEx1(5789545745, AccountType.Сберегательный_счет);

                        Console.WriteLine($"{firstBankAccount.BankAccountType} №{firstBankAccount.AccountNumber:D4}, баланс: {firstBankAccount.AccountBalance} рублей\n" +
                                          $"{secondBankAccount.BankAccountType} №{secondBankAccount.AccountNumber:D4}, баланс: {secondBankAccount.AccountBalance} рублей\n" +
                                          $"{thirdBankAccount.BankAccountType} №{thirdBankAccount.AccountNumber:D4}, баланс: {thirdBankAccount.AccountBalance} рублей");

                        Console.Write("Чтобы продолжить нажмите на любую кнопку");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Упражнение 9.2");

                        BankAccountEx2 fourthBankAccount = new BankAccountEx2(2456479, AccountType.Сберегательный_счет);
                        Queue<BankTransaction> transactionList;
                        int count;

                        fourthBankAccount.PutMoneyIntoAccount(150);
                        fourthBankAccount.PutMoneyIntoAccount(1000);
                        fourthBankAccount.WithdrawMoneyFromAccount(578);

                        transactionList = fourthBankAccount.TransactionList;
                        count = transactionList.Count;

                        for (int i = 0; i < count; i++)
                        {
                            BankTransaction transaction = transactionList.Dequeue();
                            if (transaction.AmountChange < 0)
                            {
                                Console.WriteLine($"Снятие {transaction.TransactionDate}, {-transaction.AmountChange} рублей");
                            }
                            else
                            {
                                Console.WriteLine($"Пополнение {transaction.TransactionDate}, {transaction.AmountChange} рублей");
                            }
                        }

                        Console.Write("Чтобы продолжить нажмите на любую кнопку");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Упражнение 9.3");

                        BankAccountEx3 fifthBankAccount = new BankAccountEx3(545465465, AccountType.Сберегательный_счет);

                        fifthBankAccount.PutMoneyIntoAccount(1587);
                        fifthBankAccount.PutMoneyIntoAccount(10360);
                        fifthBankAccount.WithdrawMoneyFromAccount(78);
                        fifthBankAccount.WithdrawMoneyFromAccount(7461);

                        fifthBankAccount.Dispose(fifthBankAccount);

                        Console.Write("Чтобы продолжить нажмите на любую кнопку");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Домашенее упражнение 9.1");

                        Song firstSong = new Song("", "");
                        Song secondSong = new Song("", "", firstSong);
                        Song thirdSong = new Song();

                        Console.WriteLine($"{firstSong.Title}, {secondSong.Title}, {thirdSong.Title}");

                        Console.Write("Чтобы продолжить нажмите на любую кнопку");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Вы вышли");
                        tasksEnd = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такого задания не существует");
                        break;
                }
            } while (!tasksEnd);
        }
    }
}