using System;
using System.Collections.Generic;

namespace Решение_задач
{
    /// <summary>
    /// Перечислимый тип, содержащий статусы выполнения задачи.
    /// </summary>
    enum TaskStatuses
    {
        Не_назначена,
        Назначена,
        В_работе,
        На_проверке,
        Выполнена
    }

    /// <summary>
    /// Класс, описывающий задачу проекта.
    /// </summary>
    class ProjectTask
    {
        #region Поля
        private string taskDescription;
        private DateTime taskDeadline;
        private DateTime startDateAfterReport;
        private DateTime nextTaskReportDate;
        private Employer taskAssigner;
        private Employer taskPerformer;
        private TaskStatuses taskStatus;
        private Project projectToWhichItRelates;
        private List<TaskReport> taskReports = new List<TaskReport>();
        #endregion

        #region Свойства
  
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
        }

 
        public DateTime TaskDeadline
        {
            get
            {
                return taskDeadline;
            }
        }

     
        public DateTime StartDateAfterReport
        {
            get
            {
                return startDateAfterReport;
            }
        }

      
        public DateTime NextTaskReportDate
        {
            get
            {
                return nextTaskReportDate;
            }
        }

     
        public Employer  TaskAssigner
        {
            get
            {
                return taskAssigner;
            }
        }

    
        public Employer TaskPerformer
        {
            get
            {
                return taskPerformer;
            }
        }

   
        public TaskStatuses TaskStatus
        {
            get
            {
                return taskStatus;
            }
        }

   
        public Project ProjectToWhichItRelates
        {
            get
            {
                return projectToWhichItRelates;
            }
        }

     
        public List<TaskReport> TaskReports
        {
            get
            {
                return taskReports;
            }
        }
        #endregion

        #region Методы
   
        public void AddingTaskPerformer(Employer newTaskPerformer)
        {
            ProjectTask projectTask = newTaskPerformer.AssignedTask as ProjectTask;

            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                if (projectTask != null)
                {
                    projectTask.taskPerformer = null;
                    projectTask.taskStatus = TaskStatuses.Не_назначена;
                }

                taskPerformer = newTaskPerformer;
                taskStatus = TaskStatuses.Назначена;
            }
        }

 
        public void TransitionToStatusWork()
        {
            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                taskStatus = TaskStatuses.В_работе;
            }
        }

    
        public void SettingReportDate(DateTime taskReportDate, DateTime dateAfterReport)
        {
            startDateAfterReport = dateAfterReport;
            nextTaskReportDate = taskReportDate;
        }

    
        public void RemovePerformer()
        {
            if (projectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект)
            {
                taskPerformer = null;
                taskStatus = TaskStatuses.Не_назначена;
            }
        }

 
        public void AddTaskReportToList(TaskReport taskReport)
        {
            if (taskStatus == TaskStatuses.В_работе)
            {
                taskReports.Add(taskReport);
            }
        }

       
        public void CheckingTask(Employer taskAssigner)
        {
            if (this.taskAssigner == TaskAssigner)
            {
                taskStatus = TaskStatuses.На_проверке;
                TransitionToStageCompleted();
            }
        }

   
        private void TransitionToStageCompleted()
        {
            if (taskStatus == TaskStatuses.На_проверке)
            {
                taskStatus = TaskStatuses.Выполнена;
            }
        }
        #endregion

        #region Конструкторы
  
        public ProjectTask(string taskDescription, DateTime taskDeadline, Employer taskAssigner, Project projectToWhichItRelates)
        {
            this.taskDescription = taskDescription;
            this.taskDeadline = taskDeadline;
            this.taskAssigner = taskAssigner;
            this.projectToWhichItRelates = projectToWhichItRelates;
            taskStatus = TaskStatuses.Не_назначена;
            taskPerformer = null;
        }
        #endregion
    }
}