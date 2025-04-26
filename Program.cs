using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOCommon;
using TODODataService;
using TODOService;

namespace TaskUI
{
    internal class Program
    {
        static TODOService.TaskService taskService = new TODOService.TaskService();
        static string[] userOption =
            {
                "[1] to DISPLAY TASK",
                "[2] to DISPLAY IN PROGRESS TASK",
                "[3] to ADD TASK",
                "[4] to UPDATE TASK",
                "[5] to DELETE TASK",
                "[6] to EXIT"
            };
        static void Main(string[] args)
        {


            DisplayOptions();
            string userInput =GetUserInput();
            while (userInput != "6") 
            {
             
                switch (userInput)
                {
                    case "1":
                        DisplayTasks();
                        break;
                    case "2":
                        DisplayProgress();
                        break;
                    case "3":
                        AddTask();
                        break;
                    case "4":
                        UpdateTask();
                        break;
                    case "5":
                        deleteTask();
                        break;
                    case "6":
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                DisplayOptions();
                userInput = GetUserInput();

                Console.WriteLine("-----------------------");

            } 
            Console.WriteLine("Press any key to exit.");



            static void DisplayOptions()
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("\nChoose an option:");
                foreach (var choice in userOption)
                {
                    Console.WriteLine(choice);
                }
            }

            static string GetUserInput()
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Enter your choice:");
                string input = Console.ReadLine();
                return input;
            }


            static void DisplayTasks()
            {
                
                List<TODOCommon.Task> tasks = taskService.GetAllTasks();

                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.TaskId}, Description: {task.Description}, Status: {task.Status}");
                }
            }

            static void DisplayProgress()
            {
                
                List<TODOCommon.Task> tasks = taskService.GetAllTasksByStatus("In Progress");

                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.TaskId}, Description: {task.Description}, Status: {task.Status}");
                }
            }


            static void AddTask()
            {
                Console.WriteLine("Enter task:");
                string description = Console.ReadLine();
                
            }

            static void UpdateTask()
            {
                Console.WriteLine("Enter task ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter new task description:");

                string description = Console.ReadLine();

                Console.WriteLine("Enter new task status:");

                string status = Console.ReadLine();


                taskService.UpdateTaskDescription(id, description, status);

            }

            static void deleteTask()
            {
                Console.WriteLine("Enter task ID:");
                int id = int.Parse(Console.ReadLine());

                
                taskService.DeleteTask(id);
            }
        }
    }
}
