using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_number
{

    class Program
    {
        public static int score = 0,highScore=0;
         public static Random random = new Random();
        public static void StarGame()
        {
            Console.WriteLine("Guess the number");
            Console.WriteLine();
            Console.Write("Hola, Como te llamas?:");
            string nombre = Console.ReadLine();
            
            
            int numAdivinar = random.Next(1, 10);
            IngJuego(nombre,numAdivinar);
        }
        
        public static void IngJuego(string nombre, int numAdivinar, bool jugador2 = false)
        {
            if(!jugador2)
                Console.Write($"Hola, {nombre} estas listo para jugar/si/no?");
            else
                Console.Write($"{nombre} estas listo para jugar otra vez?/si/no?");

            string respuesta = Console.ReadLine();

            switch (respuesta?.ToLower().Trim())
            {
                case "si":
                    Jugar(numAdivinar, nombre);
                    break;
                case "no":
                    Console.WriteLine("Gracias por jugar.");
                    break;
                default:
                    Console.WriteLine("Por favor escoja una opcion entre si y no.");
                    IngJuego(nombre, numAdivinar);
                    break;
            }
        }

        public static void Jugar(int numAdivinar,string nombre)
        {
            int input;

            try
            {
                Console.Write($"Ingresa un numero del 1 al 10:");
                input = int.Parse(Console.ReadLine());

            //Asegurar que lo que ingreso el usuario no sea ni nulo ni un numero menor al 1 o mayor al 10
                if (input.ToString() is null)
                    throw new Exception("Debe ingresar un numero.");

                if (input < 1 || input > 10)
                    throw new Exception("El numero a ingresar debe ser del 1 al 10.");

            //Indicarle al usuario que tan cerca o lejos esta de la respuesta.
                    if (input < numAdivinar)
                    {
                        Console.WriteLine($"Ingresa un numero mas alto.");
                        score++;
                        Jugar(numAdivinar,nombre);
                    }

                    else if (input > numAdivinar)
                    {
                        Console.WriteLine($"Ingresa un numero mas bajo.");
                        score++;
                        Jugar(numAdivinar, nombre);
                    }

                    else
                    {
                        VolverJugar(nombre,numAdivinar);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                Jugar(numAdivinar, nombre);
            }
            //contador++
            //Console.WriteLine($"Lo lograste en {contador} intentos.");
        }

        public static void VolverJugar(string nombre, int numAdivinar)
        {
            Console.WriteLine($"Felicidades,el numero era {numAdivinar}.");
            score++;

            if (highScore == 0 || score < highScore)
                highScore = score;

            Console.WriteLine($"Lo lograste en {score} intentos.");
            PuntajeMasAlto();
            score = 0;

            numAdivinar = random.Next(1, 10);
            IngJuego(nombre, numAdivinar, true);
        }

        public static void PuntajeMasAlto()
        {
            if(highScore == 0)
                Console.WriteLine("No hay registros de puntajes.");
            else
                Console.WriteLine($"El puntaje a batir es:{highScore} intentos.");
        }

        static void Main(string[] args)
        {
            
            Program.StarGame();
        }
    }
}