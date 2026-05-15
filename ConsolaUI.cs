using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }
        public void MostrarBienvenida()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║        JUEGO DEL AHORCADO        ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  Adivina la palabra antes de que");
            Console.WriteLine("  se complete el ahorcado...");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n  Tienes 6 intentos. ¡Buena suerte!");
            Console.ResetColor();

            Console.WriteLine("\nPresiona cualquier tecla para comenzar...");
            Console.ReadKey();
        }

        public void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();

            // Intentos en color según cuántos quedan
            if (_motor.IntentosRestantes <= 2)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (_motor.IntentosRestantes <= 4)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");
            Console.ResetColor();

            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
            {
                if (_motor.LetrasUsadas.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write('_');
                }
                Console.Write(' ');
            }
            Console.ResetColor();
            Console.WriteLine();

            if (_motor.MostrarPista)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");
                Console.ResetColor();
            }
        }

        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            return Console.ReadLine()[0];
        }

        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);

        public bool PreguntarOtraVez()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            return Console.ReadLine()?.ToLower() == "s";
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
        "  -----\n  |   |\n      |\n      |\n      |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
        "  -----\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
            };
            Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
        }
    }
}
