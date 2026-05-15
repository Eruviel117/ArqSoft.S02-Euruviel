using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;

        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }

        public void MostrarBienvenida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║         JUEGO VIBORITA           ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Come 10 frutas para ganar.");
            Console.WriteLine("  No choques con las paredes ni contigo mismo.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n  Flechas: mover  |  Q: salir");
            Console.ResetColor();

            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);

            // Título con puntos en color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("=== VIBORITA ===   ");
            Console.ResetColor();
            Console.Write("Puntos: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_motor.Puntos}/10");
            Console.ResetColor();

            // Borde superior
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.ResetColor();

            for (int y = 0; y < _motor.Alto; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|");
                Console.ResetColor();

                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);
                    if (_motor.Cuerpo.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@"); // cabeza
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("o"); // cuerpo
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*"); // comida
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Console.ResetColor();
            }

            // Borde inferior
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Flechas: mover   |   Q: salir");
            Console.ResetColor();
        }

        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;
            return ConsoleKey.NoName;
        }

        public void MostrarMensaje(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}