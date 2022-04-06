using MasterMind.data;

namespace MasterMind
{
    /// <summary>
    /// instrucciones para ejecutar MasterMind
    /// </summary>
    public static class RunMm
    {
        /// <summary>
        /// método principal para ejecutar MasterMind y definir directorios
        /// </summary>
        public static void FirstRunMasterMind()
        {
            FilesAndDirectorysMm.SetDirectoryMyDocs();
            FilesAndDirectorysMm.CreateFileJson("ranking.json");
            StartMenu();
        }
        
        /// <summary>
        /// Método para iniciar el menu
        /// </summary>
        public static void StartMenu()
        {
            var exit = true;
            do
            {
                string[] options = {"Play", "Rules", "Exit"};
                var menu = new Menu(options);
                OutputMm.Head();
                menu.PrintOptions();
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        MasterMind();
                        break;
                    case 1:
                        OutputMm.RulesGame();
                        menu.Run();
                        break;
                    case 2:
                        exit = false;
                        break;
                }
            } while (exit);
        }
        
        /// <summary>
        /// método principal para ejecutar MasterMind
        /// </summary>
        private static void MasterMind()
        {
            var secret = UtilitiesMm.NewStringSecret();
            var rightposition = 0;
            var attempts = 12; 
            OutputMm.Head();
            for (; rightposition != 4 && attempts !=0 ; attempts--)
            {
                rightposition = UtilitiesMm.RightAndWrongPosition(attempts, secret);
            }
            FinalMastermind(rightposition, attempts);
            if (InputMm.PlayAgain() == "si") MasterMind();
        }

        private static void FinalMastermind(int rightposition, int attempts)
        {
            var boolWinOrLose = UtilitiesMm.WinOrLose(rightposition);
            OutputMm.WinOrLose(boolWinOrLose);
            var optionRanking = UtilitiesMm.OptionRanking(boolWinOrLose);
            UtilitiesMm.CreateRankingPosition(optionRanking, boolWinOrLose, attempts);
            OutputMm.ShowRanking();
        }
    }
}