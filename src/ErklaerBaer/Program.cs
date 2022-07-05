using System;
using ErklaerBaer.TicTacToe;

namespace ErklaerBaer
{
    internal static class Program
    {
        private static char _aktuellerSpieler = 'X';
        public static void Main()
        {
            var feld = new Feld();

            var richtigeEingabe = false;
            do
            {
                Console.Clear();
                if (richtigeEingabe) // Wenn der Spieler eine richtige Eingabe getätigt hat kann der Spieler gewechselt werden
                    SpielerWechseln();

                feld.Ausgeben();

                Console.Write($"{_aktuellerSpieler} bitte geben Sie zuerst die ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Zeile");
                Console.ResetColor();
                Console.Write(" ein: ");
                var zeile = Convert.ToInt32(Console.ReadLine());

                Console.Write("Geben Sie nun die ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Spalte");
                Console.ResetColor();
                Console.Write(" ein: ");
                var spalte = Convert.ToInt32(Console.ReadLine());

                richtigeEingabe =
                    feld.SpielsteinSetzen(zeile, spalte, _aktuellerSpieler);

            } while (feld.WeitereZuegeMoeglich()); // Solange die Eingabe nicht korrekt ist frage den Nutzer nach einer Zeile und Spalte

            // \n bedeutet das man eine neue Zeile anfangen möchte innerhalb eines strings
            // man spart sich also ein neuen Console.WriteLine aufruf
            Console.WriteLine("\nDas Spiel ist vorbei jemand hat gewonnen oder es sind keine Felder mehr frei!");

            // Nur das man noch eine Taste nach durchlauf des Programms drücken muss, bis dies sich beendet.
            // Consolenausgabe lesen können
            Console.ReadLine();
        }

        private static void SpielerWechseln()
        {
            if (_aktuellerSpieler == 'X')
                _aktuellerSpieler = 'O';
            else
                _aktuellerSpieler = 'X';

            // _aktuellerSpieler = _aktuellerSpieler == 'X' ? 'O' : 'X'; kürzere Version der If Abfrage
        }
    }
}
