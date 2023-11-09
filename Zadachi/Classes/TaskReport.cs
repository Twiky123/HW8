using System;

namespace Решение_задач
{
    class TaskReport
    {
        #region Поля
        private string reportText;
        private DateTime dateAcceptanceTheReport;
        private Employer executor;
        private ProjectTask taskToWhichReportBelongs;
        #endregion

        #region Свойства
     
        public string ReportText
        {
            get
            {
                return reportText;
            }
        }

   
        public DateTime DateAcceptanceTheReport
        {
            get
            {
                return dateAcceptanceTheReport;
            }
        }

  
        public Employer Executor
        {
            get
            {
                return executor;
            }
        }

  
        public ProjectTask TaskToWhichReportBelongs
        {
            get
            {
                return taskToWhichReportBelongs;
            }
        }
        #endregion

        #region Методы
      
        public void AddReportAcceptanceDate(DateTime dateCompletionReport)
        {
            dateAcceptanceTheReport = dateCompletionReport;

        }

       
        public void RewriteTheTaskReport()
        {
            reportText = $"Отчет на тему {taskToWhichReportBelongs.TaskDescription}";
        }
        #endregion

        #region Конструкторы

        public TaskReport(string reportText, Employer executor, ProjectTask taskToWhichReportBelongs)
        {
            this.reportText = reportText;
            this.executor = executor;
            this.taskToWhichReportBelongs = taskToWhichReportBelongs;
        }
        #endregion
    }
}