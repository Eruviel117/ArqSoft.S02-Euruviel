Console.WriteLine("Elige una categoría:");
Console.WriteLine("  1 — Arquitectura");
Console.WriteLine("  2 — POO");
Console.WriteLine("  3 — .NET");
Console.Write("Opción: ");
var cat = Console.ReadLine();

string categoria = cat switch
{
    "2" => "POO",
    "3" => ".NET",
    _ => "Arquitectura"
};

var repositorio = new Ahorcado.PalabrasEnMemoria(categoria);
var motor = new Ahorcado.MotorAhorcado(repositorio);
var ui = new Ahorcado.ConsolaUI(motor);

Console.WriteLine("=== AHORCADO ===");
ui.MostrarBienvenida();

Console.WriteLine("=== AHORCADO ===");

while (!motor.Ganado() && !motor.Perdido())

    while (!motor.Ganado() && !motor.Perdido())
{
    ui.MostrarTablero();
    char letra = ui.PedirLetra();

    if (motor.LetraYaUsada(letra))
    {
        ui.MostrarMensaje("Ya usaste esa letra.");
        continue;
    }

    motor.RegistrarLetra(letra);
}

ui.MostrarTablero();

if (motor.Ganado())
    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
else
    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

if (ui.PreguntarOtraVez())
{
    var nuevoRepositorio = new Ahorcado.PalabrasEnMemoria(categoria);
    var nuevoMotor = new Ahorcado.MotorAhorcado(nuevoRepositorio);
    var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
}