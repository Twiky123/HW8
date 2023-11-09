using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Решение_задач
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("TaskManager");

            #region Создание сотрудников компании
            Console.WriteLine("Создание сотрудников компании");

            Employer Vitya = new Employer("Витя");
            Employer Maria = new Employer("Мария");
            Employer Anton = new Employer("Антон");
            Employer Volodya = new Employer("Володя");
            Employer Anna = new Employer("Анна");
            Employer Alina = new Employer("Алина");
            Employer Peter = new Employer("Петр");
            Employer Ivan = new Employer("Иван");
            Employer Ilya = new Employer("Илья");
            Employer Anastasia = new Employer("Анастасия");
            Employer Zhenya = new Employer("Женя");

            Console.WriteLine($"Сотрудники компании: {Vitya.EmployeeName}, {Maria.EmployeeName}, {Anton.EmployeeName}, {Volodya.EmployeeName}, {Anna.EmployeeName}, " +
                              $"{Alina.EmployeeName}, {Peter.EmployeeName}, {Ivan.EmployeeName}, {Ilya.EmployeeName}, {Anastasia.EmployeeName}, {Zhenya.EmployeeName}");

            Console.Write("Нажмите на любую кнопку");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Создание проекта и добавление ответсвенного.
            Console.WriteLine("Создание проекта и добавление ответсвенного");

            Project gameDevelopment = new Project("Построить дом", DateTime.Today.AddYears(1), "ООО Стройдом");
            gameDevelopment.AppointTeamLeader(Vitya);

            Console.WriteLine($"Описание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}");

            Console.Write("Нажмите на любую кнопку");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Создание задач
            Console.WriteLine("Создание задач");

            Vitya.CreatingTask("Определить дизайн", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Определить материал", DateTime.Today.AddMonths(2));
            Vitya.CreatingTask("Смоделировать структуру", DateTime.Today.AddMonths(4));
            Vitya.CreatingTask("Проверка ландшафта", DateTime.Today.AddMonths(1));
            Vitya.CreatingTask("Залить фундамент", DateTime.Today.AddMonths(7));
            Vitya.CreatingTask("Сделать цоколь", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Построить струтуру", DateTime.Today.AddMonths(6));
            Vitya.CreatingTask("Сделать ремонт", DateTime.Today.AddMonths(10));
            Vitya.CreatingTask("Проверка", DateTime.Today.AddMonths(9));
            Vitya.CreatingTask("Сдать заказ", DateTime.Today.AddMonths(11));

            List<ProjectTask> projectTasks = gameDevelopment.ProjectTasks;

            Console.WriteLine("Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Назначил", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskAssigner.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("Нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Распределение задач по работникам
            Console.WriteLine("Распределение задач");

            Vitya.DistributeTheTask(projectTasks[0], Maria, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[1], Anton, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[2], Volodya, DateTime.Today.AddDays(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[3], Anna, DateTime.Today.AddDays(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[4], Alina, DateTime.Today.AddMonths(2), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[5], Peter, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[6], Ivan, DateTime.Today.AddDays(7), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[7], Ilya, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[8], Anastasia, DateTime.Today.AddMonths(1), DateTime.Today);
            Vitya.DistributeTheTask(projectTasks[9], Zhenya, DateTime.Today.AddDays(7), DateTime.Today);

            projectTasks = gameDevelopment.ProjectTasks;

            Console.WriteLine("Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("Нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Решения сотрудников компании
            Console.WriteLine("Решения сотрудников компании\n");

            Maria.TakeTask();
            Anton.TakeTask();
            Volodya.TakeTask();
            Anna.TakeTask();
            Alina.DelegateTask(Ivan);
            Peter.TakeTask();
            Ivan.TakeTask();
            Ilya.AbandonTheTask();
            Anastasia.AbandonTheTask();
            Zhenya.TakeTask();

            Vitya.DistributeTheTask(projectTasks[8], Alina, DateTime.Today.AddMonths(1), DateTime.Today);
            Alina.TakeTask();

            Vitya.DistributeTheTask(projectTasks[6], Ilya, DateTime.Today.AddDays(7), DateTime.Today);
            Ilya.TakeTask();

            Vitya.DeleteTask(projectTasks[7]);
            Vitya.CreatingTask("Доработать задания", DateTime.Today.AddMonths(7));
            projectTasks = gameDevelopment.ProjectTasks;
            Vitya.DistributeTheTask(projectTasks[9], Anastasia, DateTime.Today.AddMonths(3), DateTime.Today);
            Anastasia.TakeTask();

            Console.WriteLine($"Описание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}\n");

            Console.WriteLine("Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }

            Console.Write("Нажмите на любую кнопку ");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Симуляция работы над проектом
            Console.WriteLine("Симуляция работы над проектом\n");

            Console.WriteLine("{0, 60}", "Отчеты");
            Console.WriteLine("{0, 40} {1, 45} {2, 30}", "Текст отчета", "Дата выполнения отчета", "Ответсвенный");

            for (DateTime date = DateTime.Today; date <= gameDevelopment.ProjectDeadline; date = date.AddDays(1))
            {
                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if ((projectTasks[i].NextTaskReportDate == date) && (projectTasks[i].TaskStatus == TaskStatuses.В_работе))
                    {
                        bool checkResult = false;
                        TaskReport taskReport = projectTasks[i].TaskPerformer.CreatingReport($"Отчет задачи {projectTasks[i].TaskDescription}", date);

                        do
                        {
                            bool result;
                            Random randomNumbers = new Random();
                            int randomNum = randomNumbers.Next(0, 2);

                            if (randomNum == 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                            }

                            checkResult = projectTasks[i].TaskAssigner.CheckingTheReport(result, taskReport, date);
                        } while (!checkResult);

                        if (checkResult)
                        {
                            if (date == projectTasks[i].TaskDeadline)
                            {
                                projectTasks[i].CheckingTask(Vitya);
                                projectTasks[i].ProjectToWhichItRelates.TransitionToClosedStatus();
                            }

                            Console.WriteLine("{0, 40} {1, 45} {2, 30}", $"{taskReport.ReportText}", $"{taskReport.DateAcceptanceTheReport.ToLongDateString()}", $"{taskReport.Executor.EmployeeName}");
                        }
                    }
                }
            }

            Console.WriteLine($"\nОписание проекта: {gameDevelopment.ProjectDescription}. Срок сдачи: {gameDevelopment.ProjectDeadline.ToLongDateString()}\n" +
                              $"Заказчик: {gameDevelopment.ProjectCustomer}. Ответсвенный: {gameDevelopment.TeamLead.EmployeeName}. Статус проекта: {gameDevelopment.ProjectStatus}\n");

            Console.WriteLine("Задачи проекта");
            Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", "Описание", "Срок", "Ответсвенный", "Статус");

            for (int i = 0; i < projectTasks.Count; i++)
            {
                Console.WriteLine("{0, 25} {1, 30} {2, 20} {3, 32}", $"{projectTasks[i].TaskDescription}", $"{projectTasks[i].TaskDeadline.ToLongDateString()}",
                                                                     $"{projectTasks[i].TaskPerformer.EmployeeName}", $"{projectTasks[i].TaskStatus}");
            }
            #endregion
        }
    }
}