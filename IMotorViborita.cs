using Ahorcado;
using System;
using System.Collections.Generic;

namespace Ahorcado
{
    public class MotorViborita : IMotorJuego
    {
        public int Ancho { get; } = 20;
        public int Alto { get; } = 15;

        private readonly LinkedList<(int x, int y)> _cuerpo = new();
        private (int x, int y) _direccion = (1, 0);
        private (int x, int y) _comida;
        private bool _perdido = false;

        public int Puntos { get; private set; } = 0;

        public IEnumerable<(int x, int y)> Cuerpo => _cuerpo;
        public (int x, int y) Comida => _comida;

        public MotorViborita()
        {
            _cuerpo.AddFirst((Ancho / 2, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 1, Alto / 2));
            _cuerpo.AddFirst((Ancho / 2 + 2, Alto / 2));
            GenerarComida();
        }

        public void CambiarDireccion(ConsoleKey tecla)
        {
            _direccion = tecla switch
            {
                ConsoleKey.UpArrow when _direccion.y != 1 => (0, -1),
                ConsoleKey.DownArrow when _direccion.y != -1 => (0, 1),
                ConsoleKey.LeftArrow when _direccion.x != 1 => (-1, 0),
                ConsoleKey.RightArrow when _direccion.x != -1 => (1, 0),
                _ => _direccion
            };
        }

        public void Avanzar()
        {
            var cabeza = _cuerpo.First!.Value;
            var nueva = (cabeza.x + _direccion.x,
                         cabeza.y + _direccion.y);

            if (nueva.Item1 < 0 || nueva.Item1 >= Ancho ||
                nueva.Item2 < 0 || nueva.Item2 >= Alto)
            {
                _perdido = true;
                return;
            }

            if (_cuerpo.Contains(nueva))
            {
                _perdido = true;
                return;
            }

            _cuerpo.AddFirst(nueva);

            if (nueva == _comida)
            {
                Puntos++;
                GenerarComida();
            }
            else
            {
                _cuerpo.RemoveLast();
            }
        }

        private void GenerarComida()
        {
            var random = new Random();
            do
            {
                _comida = (random.Next(Ancho), random.Next(Alto));
            }
            while (_cuerpo.Contains(_comida));
        }

        public bool Ganado() => Puntos >= 10;
        public bool Perdido() => _perdido;
    }
}