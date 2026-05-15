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
