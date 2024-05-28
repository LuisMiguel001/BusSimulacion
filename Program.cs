using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int personasEnBus = 0;
        int personasTransportadas = 0;
        int personasSinMontarse = 0;

        Random simulacionRandom = new Random();
        List<int> personasEnEspera = new List<int>();

        Dictionary<int, int> personasPorEstacion = new Dictionary<int, int>();

        for (int i = 1; i <= 2; i++)
        {
            personasPorEstacion[i] = 0;
            personasEnEspera.Add(0);
        }

        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------INFO STATION-------------------------------------");
            int personasLleganEstacion1 = simulacionRandom.Next(1, 32);
            personasEnEspera[0] += personasLleganEstacion1;
            Console.WriteLine($"Hora: {DateTime.Now} - Estación 1: Llegaron {personasLleganEstacion1} personas, Total en espera: {personasEnEspera[0]}");

            int subenEnEstacion1 = simulacionRandom.Next(0, personasEnEspera[0] + 1);
            personasEnBus += subenEnEstacion1;
            personasTransportadas += subenEnEstacion1;
            personasPorEstacion[1] += subenEnEstacion1;
            personasEnEspera[0] -= subenEnEstacion1;
            Console.WriteLine($"Hora: {DateTime.Now} - Estación 1: {subenEnEstacion1} personas se subieron, Personas en el bus: {personasEnBus}");

            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Comenzando viaje desde la Estación 1 a la Estación 2...");
            int tiempoViaje = 25; 
            for (int i = 1; i <= 6; i++)
            {
                bool semaforoVerde = simulacionRandom.Next(0, 2) == 1;
                if (!semaforoVerde)
                {
                    tiempoViaje += 10;
                }
                Console.WriteLine($"Semáforo {i}: {(semaforoVerde ? "Verde" : "Rojo")}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"Tiempo total de viaje: {tiempoViaje} minutos");
            Console.WriteLine("Llegada a la Estación 2");

            int personasBajanEstacion2 = simulacionRandom.Next(0, personasEnBus + 1);
            personasEnBus -= personasBajanEstacion2;
            personasSinMontarse += personasEnEspera[0];
            personasEnEspera[1] = 0;
            Console.WriteLine($"Hora: {DateTime.Now} - Estación 2: {personasBajanEstacion2} personas se bajaron, Personas en el bus: {personasEnBus}");

            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine("----------Estadísticas de la simulación actual----------");
            Console.WriteLine($"Personas transportadas en este viaje: {subenEnEstacion1}");
            Console.WriteLine($"Personas que se bajaron del bus en este viaje: {personasBajanEstacion2}");
            Console.WriteLine($"Personas en el bus ahora: {personasEnBus}");
            Console.WriteLine($"Personas que se quedaron en la estación 1: {personasEnEspera[0]}");
            Console.WriteLine($"Personas que se quedaron en la estación 2: {personasEnEspera[1]}");
            Console.WriteLine("----------------------------------------------------------");

            Console.Write("¿Desea continuar la simulación? (Si/No): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() != "si")
            {
                continuar = false;
            }
        }

        Console.WriteLine("\n----------Estadísticas finales----------");
        Console.WriteLine($"Total de personas transportadas: {personasTransportadas}");
        Console.WriteLine($"Personas que se quedaron en el bus: {personasEnBus}");
        Console.WriteLine("Total de personas transportadas por estación de origen:");
        foreach (var estacion in personasPorEstacion)
        {
            Console.WriteLine($"Estación {estacion.Key}: {estacion.Value}");
        }
        Console.WriteLine($"Total de personas que se quedaron sin montarse: {personasSinMontarse}");
        Console.WriteLine("-------------------------------------------");
    }
}
