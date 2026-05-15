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
