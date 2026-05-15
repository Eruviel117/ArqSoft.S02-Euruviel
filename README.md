# Tecnológico de Software
- **Arquitectura de Software**
- **Alumno:** Euruviel Marquez Martinez 
- **Docente:** Jorge Pedrozo Romero
- **Fecha:** 14/05/2026
- **Actividad:** Actividad #06 – Práctica .NET: Refactorización

# Ahorcado en C# — ArqSoft S02

Aplicación de consola desarrollada como actividad de la materia **Arquitectura de Software**.
Es un juego del Ahorcado construido en C# aplicando los principios **SOLID** y buenas prácticas de diseño.

---

## Descripción

Esta app permite jugar al clásico juego del Ahorcado desde la terminal.
El jugador debe adivinar una palabra secreta letra por letra antes de quedarse sin intentos.
El proyecto fue refactorizado progresivamente para eliminar violaciones SOLID
identificadas en la clase original (`Juego.cs`).

---

| Situación | Principio violado |
|---|---|
| `Juego` controla turnos, dibuja el tablero, muestra mensajes y elige la palabra | SRP — Single Responsibility Principle |
| Las palabras están hardcodeadas dentro del constructor | DIP — Dependency Inversion Principle |
| Para agregar un segundo juego habría que modificar `Juego` directamente | OCP — Open/Closed Principle |

---

## Tecnologías usadas

- **Lenguaje:** C# (.NET 10.0)
- **IDE:** Visual Studio 2022
- **Tipo de proyecto:** Console App
- **Control de versiones:** Git + GitHub

---

## Principios SOLID aplicados

| Situación | Principio violado | Solución aplicada |
|---|---|---|
| `Juego` controlaba turnos, tablero, mensajes y palabras | SRP | Se separó en clases con una sola responsabilidad |
| Las palabras estaban hardcodeadas en el constructor | DIP | Se creó la interfaz `IRepositorioPalabras` |
| Agregar un nuevo juego requería modificar `Juego` | OCP | Se extrajeron `MotorAhorcado` y `ConsolaUI` |

---

## Estructura del proyecto

```
Ahorcado/
├── Program.cs               # Punto de entrada con inyección de dependencias
├── Juego.cs                 # Clase original (clase dios - versión inicial)
├── IRepositorioPalabras.cs  # Interfaz para el repositorio de palabras
├── PalabrasEnMemoria.cs     # Implementación del repositorio
├── MotorAhorcado.cs         # Lógica del juego
├── ConsolaUI.cs             # Interfaz de usuario en consola
└── README.md
```

## Funcionalidades

- Palabra secreta aleatoria de una lista predefinida
- Muestra el tablero con guiones y letras adivinadas
- Registra las letras ya usadas
- Cuenta los intentos restantes (máximo 6)
- Detecta victoria o derrota automáticamente
- Opción de jugar de nuevo al terminar

---

## Capturas de pantalla


### Juego en ejecución
<img width="1361" height="766" alt="Captura de pantalla 2026-05-15 115323" src="https://github.com/user-attachments/assets/a0bdde7a-0417-483a-9603-c164b63671bb" />



### Pantalla de carga 
<img width="1362" height="761" alt="Captura de pantalla 2026-05-15 115337" src="https://github.com/user-attachments/assets/3747199c-886f-4ae3-a35a-20598b106940" />



## Partida termiada 
<img width="1365" height="759" alt="Captura de pantalla 2026-05-15 115416" src="https://github.com/user-attachments/assets/9c116272-f437-4718-a7ae-431d2b7786f2" />



---

## Declaración de uso de Inteligencia Artificial

| Campo | Detalle |
|---|---|
| **Nombre del estudiante** | Euruviel Marquez |
| **IA utilizada** | Claude  |
| **Fecha de uso** | 13/05/2026 |
| **Propósito** | Arreglar errores a la hora de pegar el código |

### Prompt utilizado:
"Okey me dieron este codigo pero me marca error puedes estructurarlo mejor para que ya no me marque error"

### Respuesta en crudo (raw):

Paso 1 —  Crear la clase Juego
Clic derecho en el proyecto Ahorcado → Agregar → Clase → nombre: Juego.cs
Pega este código:
csharpnamespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo",
            "encapsulamiento", "herencia"
        };
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");

            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    Console.Write("¿Jugar otra vez? (s/n): ");
                    if (Console.ReadLine()?ToLower() == "s")
                        new Juego().Jugar();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                char letra = Console.ReadLine()[0];
                if (Console.ReadLine()?[0] != null)
                    ProcesarLetra(letra);
            }

            Console.WriteLine($"\n¡Perdiste! La palabra era: {_palabraSecreta}");
        }

        private void MostrarTablero()
        {
            // Dibujar el ahorcado según intentos restantes
            Console.WriteLine($"\nIntentos restantes: {_intentosRestantes}");
            
            // Mostrar palabra con guiones
            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(c) ? c + " " : "_ ");
            }

            Console.WriteLine($"\nLetras usadas: {string.Join(", ", _letrasUsadas)}");
        }

        private bool VerificarVictoria()
        {
            return _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        }

        private void ProcesarLetra(char letra)
        {
            letra = char.ToLower(letra);
            if (_letrasUsadas.Contains(letra))
            {
                Console.WriteLine("Ya usaste esa letra.");
                return;
            }

            _letrasUsadas.Add(letra);

            if (!_palabraSecreta.Contains(letra))
                _intentosRestantes--;
        }
    }
}

Paso 2 — Modificar Program.cs
Reemplaza el contenido de Program.cs con:
csharpusing Ahorcado;

new Juego().Jugar();


