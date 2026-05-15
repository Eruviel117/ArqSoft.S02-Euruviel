# Tecnológico de Software
- **Arquitectura de Software**
- **Alumno:** Euruviel Marquez Martinez
- **Docente:** Jorge Pedrozo Romero
- **Fecha:** 15/05/2026
- **Actividad:** Actividad #06 – Práctica .NET: Refactorización

# Ahorcado & Viborita en C# — ArqSoft S02

Aplicación de consola desarrollada como actividad de la materia **Arquitectura de Software**.
Incluye dos juegos: el clásico **Ahorcado** y el juego de la **Viborita**, ambos construidos en C#
aplicando los principios **SOLID** y buenas prácticas de diseño.

---

## Descripción

Esta app permite elegir entre dos juegos desde la terminal:
- **Ahorcado:** adivina una palabra secreta letra por letra antes de quedarte sin intentos.
- **Viborita:** controla una serpiente que debe comer 10 frutas sin chocar con las paredes ni consigo misma.

El proyecto fue refactorizado progresivamente para eliminar violaciones SOLID
identificadas en la clase original (`Juego.cs`), y posteriormente se extendió
con el juego de Viborita usando una interfaz común `IMotorJuego`.

---

## Violaciones SOLID identificadas y corregidas

| Situación | Principio violado | Solución aplicada |
|---|---|---|
| `Juego` controlaba turnos, tablero, mensajes y palabras | SRP | Se separó en clases con una sola responsabilidad |
| Las palabras estaban hardcodeadas en el constructor | DIP | Se creó la interfaz `IRepositorioPalabras` |
| Agregar un nuevo juego requería modificar `Juego` | OCP | Se creó la interfaz `IMotorJuego` para ambos juegos |

---

## Tecnologías usadas

- **Lenguaje:** C# (.NET 10.0)
- **IDE:** Visual Studio 2022
- **Tipo de proyecto:** Console App
- **Control de versiones:** Git + GitHub

---

## Principios SOLID aplicados

| Principio | Aplicación |
|---|---|
| **SRP** | Cada clase tiene una sola responsabilidad: `MotorAhorcado` solo maneja lógica, `ConsolaUI` solo maneja presentación |
| **OCP** | Se puede agregar un nuevo juego implementando `IMotorJuego` sin modificar el código existente |
| **DIP** | `MotorAhorcado` depende de la abstracción `IRepositorioPalabras`, no de una implementación concreta |

---

## Estructura del proyecto

---

Ahorcado/
├── Program.cs                # Punto de entrada — menú para elegir juego
├── IMotorJuego.cs            # Interfaz común para los motores de juego
├── Juego.cs                  # Clase original del ahorcado (clase dios)
├── IRepositorioPalabras.cs   # Interfaz para el repositorio de palabras
├── PalabrasEnMemoria.cs      # Implementación del repositorio
├── MotorAhorcado.cs          # Lógica del juego ahorcado
├── ConsolaUI.cs              # UI del ahorcado con colores
├── MotorViborita.cs          # Lógica del juego viborita
├── ConsolaUIViborita.cs      # UI de la viborita con colores
└── README.md

---


---

## Funcionalidades

### Ahorcado
- Palabra secreta aleatoria de una lista predefinida
- Muestra el tablero con guiones y letras adivinadas
- Registra las letras ya usadas
- Cuenta los intentos restantes (máximo 6)
- Pista automática al llegar a 3 intentos restantes
- Muñeco ASCII que se completa con cada error
- Colores según estado del juego
- Pantalla de bienvenida
- Opción de jugar de nuevo al terminar

### Viborita
- Tablero de 20x15 con bordes
- Víbora controlada con las flechas del teclado
- Comida aleatoria que aparece en el tablero
- La víbora crece al comer
- Detección de colisión con paredes y consigo misma
- Gana al llegar a 10 puntos
- Colores: cabeza en cyan, cuerpo en verde, comida en rojo
- Pantalla de bienvenida

---

## Capturas del Juego 

