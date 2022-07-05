using System;

namespace ErklaerBaer.TicTacToe
{
    internal class Feld
    {
        private readonly char[,] _feld = new char[3, 3]; // readonly kann man auch weg lassen, ist nur dafür da das man das Feld nicht überschreiben kann

        public Feld()
        {
            // Beim erstellen eines Feldes einmal alle Felder mit einem leeren Char (Leertaste) füllen
            for (var zeile = 0; zeile < 3; zeile++)
            {
                for (var spalte = 0; spalte < 3; spalte++)
                {
                    _feld[zeile, spalte] = ' ';
                }
            }
        }

        public bool SpielsteinSetzen(int zeile, int spalte, char zeichen)
        {
            if (_feld[zeile, spalte] != ' ') return false;

            _feld[zeile, spalte] = zeichen;
            return true;
        }

        public void Ausgeben()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("   0  1  2");
            for (var zeile = 0; zeile < 3; zeile++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{zeile} ");
                Console.ResetColor();
                for (var spalte = 0; spalte < 3; spalte++)
                {
                    // Ausgabe des Wertes im Array an der Stelle (Zeile, Spalte)
                    Console.Write($"[{_feld[zeile, spalte]}]"); // Console.Write("[" + _feld[zeile, spalte] + "]"); Macht das gleiche
                }
                Console.WriteLine(); // Absatz nach jeder Zeile
            }
        }
    }
}
