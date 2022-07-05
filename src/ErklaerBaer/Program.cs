using System;
using ErklaerBaer.TicTacToe;

namespace ErklaerBaer
{
    internal static class Program
    {
        public static void Main()
        {
            var feld = new Feld();
            feld.Ausgeben();
            feld.SpielsteinSetzen(1, 0, 'X');
            feld.Ausgeben();
            feld.SpielsteinSetzen(1, 2, 'O');
            feld.Ausgeben();

            // Nur das man noch eine Taste nach durchlauf des Programms drücken muss, bis dies sich beendet.
            // Consolenausgabe lesen können
            Console.ReadLine();
        }
    }
}
