using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace todov2
{
    internal class BLL
    {
        // Clase para representar una tarea
        public class Task
        {
            public string Description { get; set; } // Descripción de la tarea
            public DateTime? DueDate { get; set; }  // Fecha límite opcional para completar la tarea
            public bool IsCompleted { get; set; }   // Indica si la tarea está completada
        }

        // Clase que gestiona las tareas y contiene la lógica de negocio
        public class TaskManager
        {
            // Lista privada para almacenar las tareas
            private readonly List<Task> _tasks = new List<Task>();

            // Método para agregar una nueva tarea
            public void AddTask()
            {
                Console.Write("Ingrese la descripción de la tarea: ");
                var description = Console.ReadLine();
                Console.Write("Ingrese la fecha límite (formato AAAA-MM-DD): ");
                var dueDateInput = Console.ReadLine();
                DateTime? dueDate = null;

                // Validación de la fecha límite proporcionada
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
                        Console.Write("Ingrese la fecha límite (formato AAAA-MM-DD): ");
                        dueDateInput = Console.ReadLine(); //En este fragmento esperamos que se introduzca una fecha o, en su defecto, se deje vacio/null
                    }
                }

                // Creación de una nueva tarea y adición a la lista
                var task = new Task
                {
                    Description = description,
                    DueDate = dueDate,
                    IsCompleted = false
                };

                _tasks.Add(task);
                Console.WriteLine("Tarea agregada. Presiona cualquier tecla para continuar...");
            }

            // Método para listar todas las tareas
            public void ListTasks()
            {
                Console.WriteLine("Tareas:");
                foreach (var task in _tasks.Select((t, i) => new { Task = t, Index = i })) //Se usa el foreach para listar cada una de las tareas de la TO DO list
                {
                    Console.WriteLine($"{task.Index + 1}. {task.Task.Description} (Fecha límite: {task.Task.DueDate?.ToShortDateString() ?? "N/A"}) - {(task.Task.IsCompleted ? "Completada" : "Pendiente")}");
                }
            }

            // Método para marcar una tarea como completada
            public void MarkTaskAsCompleted()
            {
                ListTasks();
                Console.Write("Ingrese el número de la tarea para marcar como completada: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _tasks.Count)
                {
                    _tasks[index - 1].IsCompleted = true;
                    Console.WriteLine("Tarea marcada como completada. Presiona cualquier tecla para continuar...");
                }
                else
                {
                    Console.WriteLine("Número de tarea inválido. Presiona cualquier tecla para continuar...");
                }
            }

            // Método para eliminar una tarea
            public void RemoveTask()
            {
                ListTasks();
                Console.Write("Ingrese el número de la tarea para eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _tasks.Count)
                {
                    _tasks.RemoveAt(index - 1);
                    Console.WriteLine("Tarea eliminada. Presiona cualquier tecla para continuar...");
                }
                else
                {
                    Console.WriteLine("Número de tarea inválido. Presiona cualquier tecla para continuar...");
                }
            }
        }
    }
}