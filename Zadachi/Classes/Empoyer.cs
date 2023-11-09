using System;
using System.Threading.Tasks;

namespace Решение_задач
{

    class Employer
    {
        #region Поля
        private string employeeName;
        private object assignedTask;
        #endregion

        #region Свойства

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }


        public object AssignedTask
        {
            get
            {
                return assignedTask;
            }
        }
        #endregion

        #region Методы ответсвенного за проект

        public bool CreatingTask(string taskDescription, DateTime taskDeadline)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                ProjectTask projectTask = new ProjectTask(taskDescription, taskDeadline, this, project);
                project.AddingTaskToList(projectTask);

                return true;
            }

            return false;
        }


        public bool DistributeTheTask(ProjectTask projectTask, Employer tasPerformer, DateTime taskReportDate, DateTime taskStartDate)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (projectTask.TaskPerformer == null) && (tasPerformer.AssignedTask == null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                tasPerformer.AddTask(projectTask);
                projectTask.AddingTaskPerformer(tasPerformer);
                projectTask.SettingReportDate(taskReportDate, taskStartDate);

                return true;
            }

            return false;
        }


        public bool DeleteTask(ProjectTask projectTask)
        {
            Project project = assignedTask as Project;

            if ((project != null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                project.RemoveTaskFromList(projectTask);

                return true;
            }

            return false;
        }

        #endregion

        #region Методы всех работников

        public bool AddTask(object task)
        {
            Project project = task as Project;
            ProjectTask projectTask = task as ProjectTask;

            if ((project != null) && (assignedTask == null) && (project.TeamLead == null) && (project.ProjectStatus == ProjectStatuses.Проект))
            {
                assignedTask = project;

                return true;
            }
            else if ((projectTask != null) && (assignedTask == null) && (projectTask.TaskPerformer == null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                assignedTask = projectTask;

                return true;
            }

            return false;
        }


        public bool TakeTask()
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.TransitionToStatusWork();
                projectTask.ProjectToWhichItRelates.TransitionToExecutionStatus();

                return true;
            }

            return false;
        }


        public bool DelegateTask(Employer newTaskPerformer)
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.AddingTaskPerformer(newTaskPerformer);

                assignedTask = null;
                newTaskPerformer.assignedTask = projectTask;

                return true;
            }

            return false;
        }


        public bool AbandonTheTask()
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.ProjectToWhichItRelates != null) && (projectTask.ProjectToWhichItRelates.ProjectStatus == ProjectStatuses.Проект))
            {
                projectTask.RemovePerformer();
                assignedTask = null;

                return true;
            }

            return false;
        }


        public TaskReport CreatingReport(string reportText, DateTime dateAfterReport)
        {
            ProjectTask projectTask = assignedTask as ProjectTask;

            if ((projectTask != null) && (projectTask.TaskStatus == TaskStatuses.В_работе))
            {
                TaskReport taskReport = new TaskReport(reportText, this, projectTask);
                DateTime nextTaskReportDate = projectTask.NextTaskReportDate.Add(projectTask.NextTaskReportDate.Subtract(projectTask.StartDateAfterReport));

                if (nextTaskReportDate <= projectTask.TaskDeadline)
                {
                    projectTask.SettingReportDate(nextTaskReportDate, dateAfterReport);
                }
                else
                {
                    projectTask.SettingReportDate(projectTask.TaskDeadline, dateAfterReport);
                }

                return taskReport;
            }

            return null;
        }


        public bool CheckingTheReport(bool checkResult, TaskReport taskReport, DateTime date)
        {
            if (taskReport.TaskToWhichReportBelongs.TaskAssigner == this)
            {
                if (checkResult)
                {
                    taskReport.AddReportAcceptanceDate(date);
                    taskReport.TaskToWhichReportBelongs.AddTaskReportToList(taskReport);
                    return true;
                }
                else
                {
                    taskReport.RewriteTheTaskReport();
                    return false;
                }
            }

            return false;
        }
        #endregion

        #region Конструкторы

        public Employer(string employeeName)
        {
            this.employeeName = employeeName;
        }
        #endregion
    }
}