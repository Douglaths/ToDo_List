using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todov2
{
    internal class BLL
    {

        public class Task
        {
            public string Description { get; set; }
            public DateTime? DueDate { get; set; }
            public bool IsCompleted { get; set; }
        }


        public class TaskManager
        {

            private readonly List<Task> _tasks = new List<Task>();

            public void AddTask()
            {
                Console.Write("Enter task description: ");
                var description = Console.ReadLine();
                Console.Write("Enter due date (format YYYY-MM-DD): ");
                var dueDateInput = Console.ReadLine();
                DateTime? dueDate = null;

                while (!string.IsNullOrEmpty(dueDateInput))
                {
                    if (DateTime.TryParse(dueDateInput, out DateTime parsedDate))
                    {
                        dueDate = parsedDate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fecha no válida proporcionada.");
                        Console.Write("Enter due date (format YYYY-MM-DD): ");
                        dueDateInput = Console.ReadLine();
                    }
                }
                var task = new Task
                {
                    Description = description,
                    DueDate = dueDate,
                    IsCompleted = false
                };

                _tasks.Add(task);
                Console.WriteLine("Task added. Press any key to continue...");
                
            }

            public void ListTasks()
            {
                Console.WriteLine("Tasks:");
                foreach (var task in _tasks.Select((t, i) => new { Task = t, Index = i }))
                {
                    Console.WriteLine($"{task.Index + 1}. {task.Task.Description} (Due: {task.Task.DueDate?.ToShortDateString() ?? "N/A"}) - {(task.Task.IsCompleted ? "Completed" : "Pending")}");
                }
               
                
            }

            public void MarkTaskAsCompleted()
            {
                ListTasks();
                Console.Write("Enter the number of the task to mark as completed: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _tasks.Count)
                {
                    _tasks[index - 1].IsCompleted = true;
                    Console.WriteLine("Task marked as completed. Press any key to continue...");
                }
                else
                {
                    Console.WriteLine("Invalid task number. Press any key to continue...");
                }
                
            }

            public void RemoveTask()
            {
                ListTasks();
                Console.Write("Enter the number of the task to remove: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _tasks.Count)
                {
                    _tasks.RemoveAt(index - 1);
                    Console.WriteLine("Task removed. Press any key to continue...");
                }
                else
                {
                    Console.WriteLine("Invalid task number. Press any key to continue...");
                }
                
            }
        }
    }
}
