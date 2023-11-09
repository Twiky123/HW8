using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Решение_задач
{
    /// <summary>
    /// Перечислимый тип, содержащий статусы выполнения проекта.
    /// </summary>
    enum ProjectStatuses
    {
        Проект,
        Исполнение,
        Закрыт
    }

    /// <summary>
    /// Класс, описывающий проект.
    /// </summary>
    class Project
    {
        #region Поля
        private string projectDescription;
        private DateTime projectDeadline;
        private string projectCustomer;
        private Employer teamLead;
        private ProjectStatuses projectStatus;
        private List<ProjectTask> projectTasks = new List<ProjectTask>();
        #endregion

        #region Свойства
  
        public string ProjectDescription
        {
            get
            {
                return projectDescription;
            }
        }

     
        public DateTime ProjectDeadline
        {
            get
            {
                return projectDeadline;
            }
        }

     
        public string ProjectCustomer
        {
            get
            {
                return projectCustomer;
            }
        }

   
        public Employer TeamLead
        {
            get
            {
                return teamLead;
            }
        }

   
        public ProjectStatuses ProjectStatus
        {
            get
            {
                return projectStatus;
            }
        }

       
        public List<ProjectTask> ProjectTasks
        {
            get
            {
                return projectTasks;
            }
        }
        #endregion

        #region Методы
      
        public bool AppointTeamLeader(Employer teamLead)
        {
            if ((teamLead.AssignedTask == null) && (this.teamLead == null) && (projectStatus == ProjectStatuses.Проект))
            {
                teamLead.AddTask(this);
                this.teamLead = teamLead;

                return true;
            }

            return false;
        }

  
        public bool AddingTaskToList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Add(projectTask);

                return true;
            }

            return false;
        }

    
        public bool RemoveTaskFromList(ProjectTask projectTask)
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                projectTasks.Remove(projectTask);

                return true;
            }

            return false;
        }

        public void TransitionToExecutionStatus()
        {
            if (projectStatus == ProjectStatuses.Проект)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.В_работе)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Исполнение;
                }
            }
        }


        public void TransitionToClosedStatus()
        {
            if (projectStatus == ProjectStatuses.Исполнение)
            {
                bool checkResult = true;

                for (int i = 0; i < projectTasks.Count; i++)
                {
                    if (projectTasks[i].TaskStatus != TaskStatuses.Выполнена)
                    {
                        checkResult = false;
                        break;
                    }
                }

                if (checkResult)
                {
                    projectStatus = ProjectStatuses.Закрыт;
                }
            }
        }

        #endregion

        #region Конструкторы

        public Project(string projectDescription, DateTime projectDeadline, string projectCustomer)
        {
            this.projectDescription = projectDescription;
            this.projectDeadline = projectDeadline;
            this.projectCustomer = projectCustomer;
            projectStatus = ProjectStatuses.Проект;
            teamLead = null;
        }
        #endregion
    }

}