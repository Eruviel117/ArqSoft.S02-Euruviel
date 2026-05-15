using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            ["Arquitectura"] = new List<string>
            {
                "arquitectura", "componente", "descomposicion",
                "dependencia", "acoplamiento"
            },
            ["POO"] = new List<string>
            {
                "polimorfismo", "encapsulamiento", "herencia",
                "abstraccion", "clase"
            },
            [".NET"] = new List<string>
            {
                "ensamblado", "namespace", "interfaz",
                "delegado", "middleware"
            }
        };

        private readonly string _categoria;

        public PalabrasEnMemoria(string categoria)
        {
            _categoria = categoria;
        }

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();
            var palabras = _categorias[_categoria];
            return palabras[random.Next(palabras.Count)];
        }
    }
}