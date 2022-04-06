using System;
namespace MasterMind.data
{
    /// <summary>
    /// Métodos para introducir datos por consola
    /// </summary>
    public class InputMm
    {
        /// <summary>
        /// Método para introducir una combinación 
        /// </summary>
        /// <param name="intentos">
        /// Número entero y positivo que representa los intentos del juego
        /// </param>
        /// <returns>
        /// string combinación de carácteres
        /// </returns>
        public static string InsertGuess(int intentos)
        {
            string guess;
            do
            {
                OutputMm.WriteHowManyAttempts(intentos);
                guess = Console.ReadLine();
                if (guess != null) guess = guess.ToUpper();
                if (guess is "EXIT" or "E" or "SALIR" or "S") Environment.Exit(0);
                if (guess != null && guess.Length != 4) OutputMm.ShowErrorOnly4Chars();
            } while (guess is not {Length: 4});
            return guess;
        }
        
        /// <summary>
        /// Método para introducir una opción (jugar de nuevo)
        /// </summary>
        /// <returns>
        /// string puede ser "si" o "no"
        /// </returns>
        public static string PlayAgain()
        {
            string option;
            do
            {
                OutputMm.WriteQuestionPlayAgain();
                option = Console.ReadLine();
                if (option != null) option = option.ToLower();
            } while (option is not ("si" or "no"));
            return option;
        }
        
        /// <summary>
        /// Método para introducir una opción (guardar los resultados)
        /// </summary>
        /// <returns>
        /// string puede ser "si" o "no"
        /// </returns>
        public static bool OptionSafeResults()
        {
            string option;
            do
            {
                OutputMm.WriteQuestionSafeResults();
                option = Console.ReadLine();
                if (option != null) option = option.ToLower();
            } while (option is not ("si" or "no"));
            
            if (option == "si") return true;
            return false;
        }
        
        /// <summary>
        /// Método para introducir una opción (ver ranking)
        /// </summary>
        /// <returns>
        /// string puede ser "si" o "no"
        /// </returns>
        public static bool OptionShowRanking()
        {
            string option;
            do
            {
                OutputMm.WriteQuestionLookRanking();
                option = Console.ReadLine();
                if (option != null) option = option.ToLower();
            } while (option is not ("si" or "no"));

            if (option == "si") return true;
            return false;
        }
        
        /// <summary>
        /// Método para introducir el nombre del jugador
        /// </summary>
        /// <returns>
        /// string Nombre del jugador
        /// </returns>
        public static string InsertName()
        {
            string name;
            do
            {
                OutputMm.WriteInsertName();
                name = Console.ReadLine();
            } while (name == "null");
            return name;
        }
    }
}