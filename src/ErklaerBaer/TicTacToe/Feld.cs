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
            if (zeile > 2 || spalte > 2) return false;
            if (_feld[zeile, spalte] != ' ') return false;

            _feld[zeile, spalte] = zeichen;
            return true;
        }

        public bool SpielerGewonnen(char zeichen)
        {
            for (var index = 0; index < 3; index++)
            {
                // Vertikal
                if (_feld[0, index] == zeichen &&
                    _feld[1, index] == zeichen &&
                    _feld[2, index] == zeichen)
                    return true;

                // Horizontal
                if (_feld[index, 0] == zeichen &&
                    _feld[index, 1] == zeichen &&
                    _feld[index, 2] == zeichen)
                    return true;
            }

            // Diagonal: oben Links => unten Rechts
            if (_feld[0, 0] == zeichen &&
                _feld[1, 1] == zeichen &&
                _feld[2, 2] == zeichen)
                return true;

            // Diagonal: unten Links => oben Rechts
            if (_feld[0, 2] == zeichen &&
                _feld[1, 1] == zeichen &&
                _feld[2, 0] == zeichen)
                return true;

            return false;
        }

        public bool WeitereZuegeMoeglich()
        {
            if (SpielerGewonnen('X') || SpielerGewonnen('O'))
                return false; // Wenn irgend ein Spieler schon gewonnen hat sind keine Züge mehr möglich

            for (var zeile = 0; zeile < 3; zeile++)
            {
                for (var spalte = 0; spalte < 3; spalte++)
                {
                    if (_feld[zeile, spalte] == ' ') return true; // Wenn noch keiner Gewonnen hat und noch ein Feld frei ist, ist auch noch ein Zug möglich
                }
            }

            return false; // Wenn keiner Gewonnen hat aber alle Felder belegt sind ist es ein Unentschieden und keine Züge sind mehr möglich
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
