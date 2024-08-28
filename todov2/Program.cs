using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todov2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var taskManager = new BLL.TaskManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Todo List");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. List Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        taskManager.AddTask();
                        Console.ReadKey();
                        break;
                    case "2":
                        taskManager.ListTasks();
                        Console.WriteLine("Estas son las tareas que tienes. Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        taskManager.MarkTaskAsCompleted();
                        Console.ReadKey();
                        break;
                    case "4":
                        taskManager.RemoveTask();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("¡Gracias por usar nuestro TO-DO LIST! Esperamos verte pronto :)");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
