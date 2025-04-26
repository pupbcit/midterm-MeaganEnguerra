﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOCommon;
using TODODataService;

namespace TODOService
{
    public class TaskService
    {
        TaskDataService taskDataService = new TaskDataService();

        public TaskService()
        {
            taskDataService = new TaskDataService();
        }
        public List<TODOCommon.Task> GetAllTasks()
        {
            return taskDataService.GetTasks();
        }

        public List<TODOCommon.Task> GetAllTasksByStatus(string status)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();
            List<TODOCommon.Task> tasksByStatus = new List<TODOCommon.Task>();

            foreach (var task in tasks)
            {
                if (task.Status == status)
                {
                    tasksByStatus.Add(task);
                }
            }

            return tasksByStatus;
        }

        public void UpdateTaskStatus(int id, string newStatus)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.TaskId == id)
                {
                    taskDataService.UpdateTask(id, task.Description, newStatus);
                }

            }
        }

        public void UpdateTaskDescription(int id, string newDescription, string newStatus)
        {
            List<TODOCommon.Task> tasks = GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.TaskId == id)
                {
                    taskDataService.UpdateTask(id, newDescription, newStatus);
                }

            }
        }

        public void DeleteTask(int id)
        {
            taskDataService.DeleteTask(id);
        }
    }
}
