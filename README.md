# Tecnológico de Software
- **Arquitectura de Software**
- **Alumno:** [Tu nombre aquí]
- **Docente:** Jorge Pedrozo Romero
- **Fecha:** 14/05/2026
- **Actividad:** Actividad #02 – Práctica .NET: Juego del Ahorcado

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

Ahorcado/
├── Program.cs               # Punto de entrada con inyección de dependencias
├── Juego.cs                 # Clase original (clase dios - versión inicial)
├── IRepositorioPalabras.cs  # Interfaz para el repositorio de palabras
├── PalabrasEnMemoria.cs     # Implementación del repositorio
├── MotorAhorcado.cs         # Lógica del juego
├── ConsolaUI.cs             # Interfaz de usuario en consola
└── README.md

---

## Funcionalidades

- Palabra secreta aleatoria de una lista predefinida
- Muestra el tablero con guiones y letras adivinadas
- Registra las letras ya usadas
- Cuenta los intentos restantes (máximo 6)
- Detecta victoria o derrota automáticamente
- Opción de jugar de nuevo al terminar

---
