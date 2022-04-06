using System;
using MasterMind.data;

namespace MasterMind
{
    /// <summary>
    /// métodos de utilidad
    /// </summary>
    public static class UtilitiesMm
    {

        /// <summary>
        /// Método para comprobar si el jugador ha ganado
        /// </summary>
        /// <param name="rightposition">
        /// Número entero que representa los aciertos del jugador
        /// </param>
        /// <returns>
        /// bool que representa si el jugador ha ganado o perdido
        /// </returns>
        public static bool WinOrLose(int rightposition)
        {
            return rightposition == 4;
        }
        
        /// <summary>
        /// Método para comprobar el número de aciertos del jugador de carácteres pero no de posición
        /// </summary>
        /// <param name="secret">
        /// combinación secreta de carácteres para adivinar
        /// </param>
        /// <param name="guess">
        /// combinación de carácteres del jugador 
        /// </param>
        /// <param name="wrongposition">
        /// Número que indica que hay una letra correcta, pero su posición es erronea
        /// </param>
        /// <param name="adivinado">
        /// String de carácteres adivinados por el jugador, es util para hallar el número de wrongposition y rightposition
        /// </param>
        /// <returns>
        /// wrongposition
        /// </returns>
        public static int CheckWrongPosition(string secret, string guess, int wrongposition, string adivinado)
        {
            for (var i = 0; i < 4; i++)
            {
                if (secret.Contains(guess[i]) && !adivinado.Contains(guess[i]) || secret.Contains(guess[i]) && adivinado.Length < 4 ) 
                {
                    wrongposition++;
                }

                if (secret[i] == guess[i])
                {
                    wrongposition--;
                }
            }
            return wrongposition;
        }

        /// <summary>
        /// Método para comprobar el número de aciertos del jugador de carácteres
        /// </summary>
        /// <param name="secret">
        /// combinación secreta de carácteres para adivinar
        /// </param>
        /// <param name="guess">
        /// combinación de carácteres del jugador 
        /// </param>
        /// <param name="rightposition">
        /// Número que indica que hay una letra correcta y en su posición
        /// </param>
        /// <param name="adivinado">
        /// String de carácteres adivinados por el jugador, es util para hallar el número de wrongposition y rightposition
        /// </param>
        /// <returns>
        /// rightposition
        /// </returns>
        public static int CheckRightPosition(string secret, string guess, int rightposition, ref string adivinado)
        {
            for (var i = 0; i < 4; i++)
            {
                if (secret[i] == guess[i])
                {
                    rightposition++;
                    adivinado += guess[i];
                }
            }
            return rightposition;
        }
        
        /// <summary>
        /// Método para ejecutar CheckRightPosition y CheckWrongPosition
        /// </summary>
        /// <param name="attempts">
        /// intentos de un jugador
        /// </param>
        /// <param name="secret">
        /// combinación secreta de carácteres para adivinar
        /// </param>
        /// <returns>
        /// rightposition Número que indica que hay una letra correcta y en su posición
        /// </returns>
        public static int RightAndWrongPosition(int attempts, string secret)
        {
            int rightposition;
            rightposition = 0;
            var wrongposition = 0;
            var guess = InputMm.InsertGuess(attempts);
            var adivinado = "";
            rightposition = CheckRightPosition(secret, guess, rightposition, ref adivinado);
            wrongposition = CheckWrongPosition(secret, guess, wrongposition, adivinado);
            if (wrongposition < 0) wrongposition = 0;
            OutputMm.ShowStats(rightposition, wrongposition);
            return rightposition;
        }
        
        /// <summary>
        /// Método para generar un string aleatorio de carácteres 4 carácteres entre [A,B,C,D,E,F]
        /// </summary>
        /// <returns>
        /// string aleatorio de carácteres 4 carácteres entre [A,B,C,D,E,F]
        /// </returns>
        public static string NewStringSecret()
        {
            string[] characters = {"A", "B", "C", "D", "E", "F"};
            var rnd = new Random();
            var secret = "";
            for (var j = 0; j < 4; j++)
            {
                var aux = rnd.Next(characters.Length);
                secret += characters[aux];
            }
            return secret;
        }

        /// <summary>
        /// crear o modificar el ranking del juego
        /// </summary>
        /// <param name="optionRanking">
        /// parametro para saber si quiere introducir un resultado
        /// </param>
        /// <param name="winOrLose">
        /// parametro para saber si ha ganado el juego
        /// </param>
        /// <param name="attempts">
        /// puntuación de un jugador
        /// </param>
        public static void CreateRankingPosition(bool optionRanking, bool winOrLose, int attempts) 
        {
            if (optionRanking && winOrLose)
                FilesAndDirectorysMm.UpdateFileRanking(InputMm.InsertName(), 12 - attempts);
        }
        
        /// <summary>
        /// método para dar la opción de ejecutar el ranking
        /// </summary>
        /// <param name="winOrLose">
        /// parametro para saber si ha ganado el juego
        /// </param>
        /// <returns>
        /// parametro para saber si ejecutar el ranking
        /// </returns>
        public static bool OptionRanking(bool winOrLose)
        {
            var optionRanking = false;
            if (winOrLose) optionRanking = InputMm.OptionSafeResults();
            return optionRanking;
        }
    }
}