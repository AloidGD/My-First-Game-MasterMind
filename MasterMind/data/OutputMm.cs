using System;
using System.IO;
using Newtonsoft.Json;

namespace MasterMind.data
{
    /// <summary>
    /// métodos para mostrar por consola información
    /// </summary>
    public class OutputMm
    {
        /// <summary>
        ///  método para preguntar si el jugador quiere entrar en el ranking
        /// </summary>
        /// <returns>
        /// variable para comprobar si modificar el ranking
        /// </returns>
        public static void ShowRanking()
        {
            Console.Write("\n\n\tMEJORES JUGADORES DE MASTERMIND [CLASIFICACIÓN POR INTENTOS]\n");
            using (StreamReader jr = File.OpenText("ranking.json"))
            {
                string line;
                for (var position = 1; (line = jr.ReadLine()) != null; position++)
                {
                    var player = JsonConvert.DeserializeObject<Players>(line);
                    if (player != null) Console.Write("\n · {0}: {1}", position, player);
                }
            } 
        }
        
        /// <summary>
        /// mostrar el nombre del archivo de texto creado
        /// </summary>
        public static void ReadKeyAndClean()
        {
            Console.ReadKey();
            Console.Clear();
        }
        
        /// <summary>
        /// mostrar el nombre del archivo de texto creado
        /// </summary>
        /// <param name="fileText">
        /// archivo de texto
        /// </param>
        public static void ShowFileTextCreated(string fileText)
        {
            Console.Write("\n Se ha creado el archivo de texto: {0}", fileText);
        }

        /// <summary>
        /// Muestra por consola cuantos intentos quedan para finalizar el juego
        /// </summary>
        /// <param name="intentos">
        /// Número entero y positivo que representa los intentos del juego
        /// </param>
        public static void WriteHowManyAttempts(int intentos)
        {
            Console.Write("\n\n Tienes {0} intentos." +
                          "\n Escribe una combinación: ", intentos);
        }
        
        /// <summary>
        /// Pregunta por consola si el jugador quiere jugar otra vez
        /// </summary>
        public static void WriteQuestionPlayAgain()
        {
            Console.Write("\n\n ¿Quieres jugar otra vez? ");
        }

        
        /// <summary>
        /// Muestra por consola que la combinación debe ser de 4 carácteres
        /// </summary>
        public static void ShowErrorOnly4Chars()
        {
            Console.Write("\nError!! La combinación debe ser de 4 carácteres.\n");
        }
        
        /// <summary>
        /// método para mostrar número de carácteres adivinados, además si están en posición o no
        /// </summary>
        /// <param name="rightposition">
        /// número entero que represanta el número de carácteres adivinados en su posición correcta
        /// </param>
        /// <param name="wrongposition">
        /// número entero que represanta el número de carácteres adivinados, pero en una posición erronea
        /// </param>
        public static void ShowStats(int rightposition, int wrongposition)
        {
            Console.Write("\n RightPosition: " + rightposition +
                          "\n WrongPosition: " + wrongposition+ "\n");
        }
        
        /// <summary>
        /// Pregunta por consola un nombre
        /// </summary>
        public static void WriteInsertName()
        {
            Console.Write("\n Introduce tu nombre: ");
        }

        /// <summary>
        /// Pregunta por consola para guardar resultados
        /// </summary>
        public static void WriteQuestionSafeResults()
        {
            Console.Write("\n¿Quieres guardar tu resultado en el ranking? ");
        }
        
        /// <summary>
        /// Pregunta por consola si quieres ver el ranking
        /// </summary>
        public static void WriteQuestionLookRanking()
        {
            Console.Write("\n¿Quieres ver en ranking? ");
        }
        
        /// <summary>
        /// mostrar cabecera del juego y sus instrucciones
        /// </summary>
        public static void Head()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(
                "\n" + "  __  __               _____   _______   ______   _____    __  __   _____   _   _   _____    " +
                "\n" + @" |  \/  |     /\      / ____| |__   __| |  ____| |  __ \  |  \/  | |_   _| | \ | | |  __ \  " +
                "\n" + @" | \  / |    /  \    | (___      | |    | |__    | |__) | | \  / |   | |   |  \| | | |  | | " +
                "\n" + @" | |\/| |   / /\ \    \___ \     | |    |  __|   |  _  /  | |\/| |   | |   | . ` | | |  | | " +
                "\n" + @" | |  | |  / ____ \   ____) |    | |    | |____  | | \ \  | |  | |  _| |_  | |\  | | |__| | " +
                "\n" + @" |_|  |_| /_/    \_\ |_____/     |_|    |______| |_|  \_\ |_|  |_| |_____| |_| \_| |_____/ ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        /// <summary>
        /// Método para mostrar por consola las reglas del juego
        /// </summary>
        public static void RulesGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(
                "\n\n Adivina la combinación aleatoria de 4 letras:" +
                "\n - Posibles letras: A B C D E F" +
                "\n - RightPosition: Indica que hay una letra correcta y en su posición." +
                "\n - WrongPosition: Indica que hay una letra correcta, pero su posición es erronea." +
                "\n - Si quieres salir durante el juego escribe Exit.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// mostrar resultado del juego
        /// </summary>
        /// <param name="boolWinOrLose">
        /// variable que representa si el jugador ha ganado o ha perdido
        /// </param>
        public static void WinOrLose(bool boolWinOrLose)
        {
            if (boolWinOrLose)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n ¡ FELICIDADES, HAS ACERTADO ! ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n░░░░░░░░░░░░░░░░░░░░░░░░░░█▄" +
                                  "\n░▄▄▄▄▄▄░░░░░░░░░░░░░▄▄▄▄▄░░█▄" +
                                  "\n░▀▀▀▀▀███▄░░░░░░░▄███▀▀▀▀░░░█▄" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█" +
                                  "\n░▄▀▀▀▀▀▄░░░░░░░░░░▄▀▀▀▀▀▄░░░░█" +
                                  "\n█▄████▄░▀▄░░░░░░▄█░▄████▄▀▄░░█▄" +
                                  "\n████▀▀██░▀▄░░░░▄▀▄██▀█▄▄█░█▄░░█" +
                                  "\n██▀██████░█░░░░█░████▀█▀██░█░░█" +
                                  "\n████▀▄▀█▀░█░░░░█░█████▄██▀▄▀░░█" +
                                  "\n███████▀░█░░░░░░█░█████▀░▄▀░░░█" +
                                  "\n░▀▄▄▄▄▄▀▀░░░░░░░░▀▀▄▄▄▄▀▀░░░░░█" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█" +
                                  "\n░░▓▓▓▓▓▓▓░░░░░░░░░░▓▓▓▓▓▓▓░░░░█" +
                                  "\n░░░▓▓▓▓▓░░░░░░░░░░░░▓▓▓▓▓░░░░░█" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█▀" +
                                  "\n░░░░░░░░░▄▄███████▄▄░░░░░░░░░█" +
                                  "\n░░░░░░░░█████████████░░░░░░░█▀" +
                                  "\n░░░░░░░░░▀█████████▀░░░░░░░█▀" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░░█▀" +
                                  "\n░░░░░░░░░░░░░░░░░░░░░░░░░█▀");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n Has perdido, ponte a estudiar... \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n░░░░░░░░░░░░▄▄▄█▀▀▀▀▀▀▀▀█▄▄▄░░░░░░░░░░░░" +
                                  "\n░░░░░░░░▄▄█▀▀░░░░░░░░░░░░░░▀▀█▄▄░░░░░░░░" +
                                  "\n░░░░░░▄█▀░░░░▄▄▄▄▄▄▄░░░░░░░░░░░▀█▄░░░░░░" +
                                  "\n░░░░▄█▀░░░▄██▄▄▄▄▄▄▄██▄░░░░▄█▀▀▀▀██▄░░░░" +
                                  "\n░░░█▀░░░░█▀▀▀░░▄██░░▄▄█░░░██▀▀▀███▄██░░░" +
                                  "\n░░█░░░░░░▀█▀▀▀▀▀▀▀▀▀██▀░░░▀█▀▀▀▀███▄▄█░░" +
                                  "\n░█░░░░░░░░░▀▀█▄▄██▀▀░░░░░░░░▀▄▄▄░░░▄▄▀█░" +
                                  "\n█▀░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▀▀▀▀▀░░▀█" +
                                  "\n█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▄░░░░█" +
                                  "\n█░░░░░░░░░░░░░░░░░░░░░░░░▄▄▄▄▄██░░▀█░░░█" +
                                  "\n█░░░░░░░░░░░░░░█░░░▄▄▄█▀▀▀░░░▄█▀░░░░░░░█" +
                                  "\n█░░░░░░░░░░░░░░░░░░▀░░░░░░░░█▀░░░░░░░░░█" +
                                  "\n█▄░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▄█" +
                                  "\n░█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░" +
                                  "\n░░█░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█░░" +
                                  "\n░░░█▄░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▄█░░░" +
                                  "\n░░░░▀█▄░░░░░░░░░░░░░░░░░░░░░░░░░░▄█▀░░░░" +
                                  "\n░░░░░░▀█▄░░░░░░░░░░░░░░░░░░░░░░▄█▀░░░░░░" +
                                  "\n░░░░░░░░░▀███████████████████▀█▀░░░░░░░░");
            }
        }
    }
}