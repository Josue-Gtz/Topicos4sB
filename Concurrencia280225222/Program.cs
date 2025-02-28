using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrencia280225222
{
    internal class Program
    {
        // Método que será ejecutado por los hilos
        static void Proceso(object id)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hilo {id}: Iteración {i}");
                Thread.Sleep(1000); // Simula un proceso que toma tiempo
            }
        }
        static void Main(string[] args)
        {
            // Inicio de codigo para el flujo unico
            Console.Write("Inicio del programa de flujo unico" + Environment.NewLine);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Creacion de hilos
            Proceso(1);
            Proceso(2);
            Proceso(3);

            sw.Stop();
            Console.WriteLine($"Tiempo de ejecución: " +
                $"{sw.ElapsedMilliseconds} ms" + Environment.NewLine);
            Console.Write("Fin de procesos hilo unico" + Environment.NewLine);
            // Fin de flujo unico

            // Inicio de flujo multiple
            // Crear tres hilos y asignarles la función 'Proceso'
            Thread hilo1 = new Thread(Proceso);
            Thread hilo2 = new Thread(Proceso);
            Thread hilo3 = new Thread(Proceso);

            // Inicio del programa, junto a su contador
            Console.WriteLine("Inicio del programa de flujo multiple");
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            // Iniciar los hilos con diferentes identificadores
            hilo1.Start(1);
            hilo2.Start(2);
            hilo3.Start(3);

            // Esperar a que los hilos terminen
            hilo1.Join();
            hilo2.Join();
            hilo3.Join();

            stopwatch2.Stop();
            Console.WriteLine($"Tiempo de ejecución: " +
                $"{stopwatch2.ElapsedMilliseconds} ms");

            Console.WriteLine("Fin del programa...");
            Console.ReadLine();
            // Fin de flujo multiple
        }
    }
}