using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Segundo_parcial
{
    class Program
    {
        // Crear un sistema de votacion en el que se muestre un ganador calculando los votos validos y los votos nulos
          public static void Menu()
          {
            string[] nombres = { "Roberto Gomez", "Miguel Medrano", "Anabel Correa", "Avelino Figueroa" };
            string[] partido = { "Partido Cuaderno", "Partido Familia", " Partido Heretics", "Partido Gris" };
            int[] fecha = { 1965, 2001, 2000, 2003 };
            string[] sigla = { "PC", "PF", "PH", "PG" };
            string[] puesto = { "Presidente", "Presidente", "Presidente", "Presidente" +
                        "" };
            double[] votos = new double[4];
            double[] Porcentajes = new double[4];
            int votosValidos = 0;
            int VotosNulos = 0;

            Console.WriteLine("----> SISTEMA DE VOTACIÓN <----");
            Console.WriteLine();
            Console.WriteLine(" (1) Ver datos de los candidatos ");
            Console.WriteLine();
            Console.WriteLine(" (2) Ver sistema de votación ");

            Console.Write("Ingrese el numero entre parentesis () para seleccionar una opcion ");
            int decision = int.Parse(Console.ReadLine());

            switch (decision)
            {
                case 1:
                    Console.Clear();
                    VerDatos(nombres, partido, puesto, fecha, sigla);
                    break;
                case 2:
                    Console.Clear();
                    SistemaVotacion(nombres, partido, puesto, votos, Porcentajes, votosValidos, VotosNulos);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ERROR");
                    Console.WriteLine("DATO INCORRECTO INGRESADO...");
                    Menu();
                    break;
            }
        }

        public static void SistemaVotacion(string[] nombres,string[] partido, string [] puesto,
            double [] votos,double [] Porcentajes,int votosvalidos,int VotosNulos)
        {
            int votosEmitidos = 0;
            double aux = 0;
            string aux2 = "";
            Random aleatorio = new Random();
            for (int voto = 1; voto <= 1000; voto++)
            {
                votosEmitidos = aleatorio.Next(0, 5);
                

                switch (votosEmitidos)
                {
                    case 0:
                       votos [0]++;
                        votosvalidos++;
                        break;
                    case 1:
                        votos[1]++;
                        votosvalidos++;
                        break;
                    case 2:
                        votos[2]++;
                        votosvalidos++;
                        break;
                    case 3:
                        votos[3]++;
                        votosvalidos++;
                        break;
                    default:
                        VotosNulos++;
                        break;
                }
            }
           
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (votos[j]<votos[j+1])
                    {
                        aux = votos[j];
                        votos[j] = votos[j + 1];
                        votos[j + 1] = aux;

                        aux2 = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = aux2;

                        aux2 = partido[j];
                        partido[j] = partido[j + 1];
                        partido[j + 1] = aux2;
                    }
                }
            }
            Console.WriteLine("----> SISTEMA DE VOTACIONES PRESIDENCIALES <----");
            Console.WriteLine();
            Console.WriteLine("Los Resultados son: ");
            Console.WriteLine();
            Console.WriteLine("Cantidad de votos validos: " + votosvalidos);
            Console.WriteLine();
            Console.WriteLine("Cantidad de votos nulos: " + VotosNulos);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(i + 1);
                Console.WriteLine("Nombre: " + nombres[i]);
                Console.WriteLine("Partido: " + partido[i]);
                Porcentajes[i] = votos[i] / votosvalidos;
                Porcentajes[i] = Porcentajes[i] * 100;
                Console.WriteLine("Porcentaje: "+Porcentajes[i].ToString("0.0")+"%");
                Console.WriteLine();
            }
            Console.Write("Ingrese (1) para volver al menu principal  de lo contrario el programa se va a cerrar: ");
            int decision = int.Parse(Console.ReadLine());

            if (decision == 1)
            {
                Console.Clear();
                Menu();
            }
        }
       
        public static void VerDatos(string[] nombre,string[] partido,string[] puesto,int[] fecha,string[] sigla)
        {
            int decision = 0;
            Console.WriteLine("----> VISUALIZACION DE DATOS <----");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("Primer candidato...");
                        break;
                    case 1:
                        Console.WriteLine("Segundo candidato...");
                        break;
                    case 2:
                        Console.WriteLine("Tercer candidato...");
                        break;
                    case 3:
                        Console.WriteLine("Cuarto candidato...");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Nombre: " + nombre[i]);
                Console.WriteLine("Partido: " +partido[i]);
                Console.WriteLine("Fecha de creacion del partido: " + fecha[i]);
                Console.WriteLine("Siglas: " + sigla[i]);
                Console.WriteLine("Puesto: " +puesto[i]);
                Console.WriteLine();
            }
            Console.Write("Ingrese (1) para volver al menu principal  de lo contrario el programa se va a cerrar: ");
            decision = int.Parse(Console.ReadLine());

            if (decision==1)
            {
                Console.Clear();
                Menu();
            }


        }
        static void Main(string[] args)
        {
                Menu();
               
                Console.ReadKey();
        }
    }
}
