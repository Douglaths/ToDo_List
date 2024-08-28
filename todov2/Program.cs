using System;

namespace todov2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de TaskManager para gestionar las tareas
            var taskManager = new BLL.TaskManager();

            while (true) // Ciclo infinito para mantener el menú activo hasta que se seleccione salir
            {
                Console.Clear();
                Console.WriteLine("Lista de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Listar Tareas");
                Console.WriteLine("3. Marcar Tarea como Completada");
                Console.WriteLine("4. Eliminar Tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");

                // Leer la opción seleccionada por el usuario
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        // Agregar una nueva tarea
                        taskManager.AddTask();
                        Console.ReadKey(); // Pausar hasta que el usuario presione una tecla
                        break;
                    case "2":
                        // Listar todas las tareas
                        taskManager.ListTasks();
                        Console.WriteLine("Estas son las tareas que tienes. Presiona cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "3":
                        // Marcar una tarea como completada
                        taskManager.MarkTaskAsCompleted();
                        Console.ReadKey();
                        break;
                    case "4":
                        // Eliminar una tarea de la lista
                        taskManager.RemoveTask();
                        Console.ReadKey();
                        break;
                    case "5":
                        // Salir del programa
                        Console.WriteLine("¡Gracias por usar nuestro TO-DO LIST! ¡Esperamos verte pronto :)");
                        Console.ReadKey();
                        return;
                    default:
                        // Mensaje de error si el usuario selecciona una opción inválida
                        Console.WriteLine("Opción inválida. Presiona cualquier tecla para intentar nuevamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
