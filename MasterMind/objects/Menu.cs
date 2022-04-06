using System;
using MasterMind.data;

namespace MasterMind
{
    class Menu
    {
        private int _selectedIndex ;
        private string[] _options;

        public Menu(string[] options)
        {
            _options = options;
            _selectedIndex = 0;
        }
        
        public void PrintOptions()
        {
            OutputMm.Head();
            for (int i = 0; i < _options.Length; i++)
            {
                var currentOption = _options[i];
                if (i == _selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else 
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }                Console.Write("\n\n\n\t[" + currentOption + "]");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                PrintOptions();

                var keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex < 0)
                        _selectedIndex = _options.Length - 1;
                }
                if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                        _selectedIndex = 0;
                }
            } while (keyPressed != ConsoleKey.Enter);
            return _selectedIndex;
        }
    }
}