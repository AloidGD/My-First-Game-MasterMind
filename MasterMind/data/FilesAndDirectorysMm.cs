using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace MasterMind.data
{
    /// <summary>
    /// Métodos para manejar ficheros y archivos
    /// </summary>
    public class FilesAndDirectorysMm
    {
        /// <summary>
        /// Método para mostrar el directorio actual
        /// </summary>
        public static void SetDirectoryMyDocs()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) Directory.SetCurrentDirectory(@"../../../../MyDocs");
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Directory.SetCurrentDirectory(@"..\..\..\..\MyDocs");
        }

        /// <summary>
        /// método para crear un archivo de texto
        /// </summary>
        /// <param name="fileJson">
        /// archivo Json
        /// </param>
        public static void CreateFileJson(string fileJson)
        {
            if (!File.Exists(fileJson))
            {
                File.Create(fileJson).Close();
                OutputMm.ShowFileTextCreated(fileJson);
                OutputMm.ReadKeyAndClean();
            }
        }
        
        /// <summary>
        /// Actualizar el archivo de ranking con un jugador nuevo
        /// </summary>
        /// <param name="namePlayer">
        /// Nombre Jugador
        /// </param>
        /// <param name="attempts">
        /// Número de intentos del jugador 
        /// </param>
        public static void UpdateFileRanking(string namePlayer, int attempts)
        {
            var players = new List<Players>();
            var pathJson = "ranking.json";
            var newPlayer = new Players { Name = namePlayer, Attempts = attempts};
            PlayerJsonToPlayerList(pathJson, players); 
            players.Add(newPlayer);
            players.Sort((x, y) => x.Attempts.CompareTo(y.Attempts));
            PlayerListToPlayerJson(pathJson, players);
        }

        private static void PlayerListToPlayerJson(string pathJson, List<Players> players)
        {
            using (StreamWriter sw = new StreamWriter(pathJson))
            {
                for (int i = 0; i < 10; i++)
                {                   
                    string json = JsonConvert.SerializeObject(players[i]);
                    sw.WriteLine(json);
                }
            }
        }

        private static void PlayerJsonToPlayerList(string pathJson, List<Players> players)
        {
            using (StreamReader jr = File.OpenText(pathJson))
            {
                string line;
                while ((line = jr.ReadLine()) != null)
                {
                    var varPlayer = JsonConvert.DeserializeObject<Players>(line);
                    players.Add(varPlayer);
                    
                }
            }
        }
    }
}