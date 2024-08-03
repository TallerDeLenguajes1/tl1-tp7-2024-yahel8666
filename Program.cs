// See https://aka.ms/new-console-template for more information
using espacioCalculadora;
using claseEmpleados; 

Console.WriteLine("\n CALCULADORA\n ");
Calculadora miCalculadora = new Calculadora();
int eleccion;
do
{
    Console.WriteLine("\nMENU");
    Console.WriteLine("1) Suma");
    Console.WriteLine("2) Resta");
    Console.WriteLine("3) Multiplicacion");
    Console.WriteLine("4) Division");
    Console.WriteLine("5) Limpiar");
    Console.WriteLine("0) Salir");
    Console.Write("Operacion a realizar: ");

    // Leer la opción del usuario y convertirla a entero
    if (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 0 || eleccion > 5)
    {
        Console.WriteLine("Operacion invalida. Por favor ingrese un numero entre 0 y 5.");
        continue;
    }

    double num = 0;
    string h;

    if (eleccion != 0 && eleccion != 5)
    {
        // Leer el número
        do
        {
            Console.Write("Ingrese el numero: ");
            h = Console.ReadLine();
        } while (!double.TryParse(h, out num));
    }

    switch (eleccion)
    {
        case 1:
            miCalculadora.Sumar(num);
            Console.WriteLine("\nLa suma de los numeros es " + miCalculadora.Resultado);
            break;
        case 2:
            miCalculadora.Restar(num);
            Console.WriteLine("\nLa diferencia de los numeros es " + miCalculadora.Resultado);
            break;
        case 3:
            miCalculadora.Multiplicar(num);
            Console.WriteLine("\nEl producto de los numeros es " + miCalculadora.Resultado);
            break;
        case 4:
            miCalculadora.Dividir(num);
            Console.WriteLine("\nEl cociente de los numeros es " + miCalculadora.Resultado);
            break;
        case 5:
            miCalculadora.Limpiar();
            Console.WriteLine("\nEl dato ha sido limpiado. Resultado: " + miCalculadora.Resultado);
            break;
    }

} while (eleccion != 0);

Console.WriteLine("\n miEmpleado \n ");

Empleado[] miEmpleado = new Empleado[3]; 
char estadoC;
string ingresa;
DateTime fechaNacim;
DateTime fechaIng;
double sueldoBasic;
int cargoDelEmpleado;

for (int i = 0; i < 3; i++)
{
    miEmpleado[i] = new Empleado();

    Console.WriteLine($"\n======Empleado NRO {i+1}======\n");
    Console.WriteLine("Nombre del empleado:\n");
    miEmpleado[i].Nombre = Console.ReadLine();

    Console.WriteLine("Apellido del empleado:\n");
    miEmpleado[i].Apellido = Console.ReadLine();

    Console.WriteLine("Fecha de nacimiento del empleado.\n");
    do
    {
        Console.WriteLine("\nFormato AAAA-MM-DD.");
        ingresa = Console.ReadLine();
    } while (!DateTime.TryParse(ingresa, out fechaNacim));
    miEmpleado[i].FechaNacimiento = fechaNacim;

    do
    {
        Console.WriteLine("Estado civil del empleado:\n");
        Console.WriteLine("[c]. Casado\n");
        Console.WriteLine("[s]. Soltero\n");
        ingresa = Console.ReadLine();
        
    } while (!char.TryParse(ingresa, out estadoC) || (estadoC != 'c' && estadoC != 's' && estadoC != 'C' && estadoC != 'S'));
    miEmpleado[i].EstadoCivil = estadoC;

    Console.WriteLine("Fecha de ingreso en la empresa del empleado:\n");
    do
    {
        Console.WriteLine("\nFormato AAAA-MM-DD.");
        ingresa = Console.ReadLine();
    } while (!DateTime.TryParse(ingresa, out fechaIng));
    miEmpleado[i].FechaIngreso = fechaIng;
    
    do
    {
        Console.WriteLine("Sueldo basico del empleado:\n");
        ingresa = Console.ReadLine();
    } while (!double.TryParse(ingresa, out sueldoBasic) || sueldoBasic < 0);
    miEmpleado[i].SueldoBasico = sueldoBasic;

    do
    {
        Console.WriteLine("Cargo del empleado.\n");
        Console.WriteLine("[1]. Auxiliar\n");
        Console.WriteLine("[2]. Administrativo\n");
        Console.WriteLine("[3]. Ingeniero\n");
        Console.WriteLine("[4]. Especialista\n");
        Console.WriteLine("[5]. Investigador\n");
        ingresa = Console.ReadLine();
    } while (!int.TryParse(ingresa, out cargoDelEmpleado) || cargoDelEmpleado >= 6 || cargoDelEmpleado <= 0);

    switch (cargoDelEmpleado)
    {
        case 1:
        miEmpleado[i].Cargo = Cargo.Auxiliar;
             break;
        case 2:
        miEmpleado[i].Cargo = Cargo.Administrativo;
             break;
        case 3:
        miEmpleado[i].Cargo = Cargo.Ingeniero;
             break;
        case 4:
        miEmpleado[i].Cargo = Cargo.Especialista;
             break;
        case 5:
        miEmpleado[i].Cargo = Cargo.Investigador;
             break;
    }
}


double totalSalarios = 0;
for (int i = 0; i < 3; i++)
{
    totalSalarios = totalSalarios + miEmpleado[i].CalcularSalario();
}
Console.WriteLine($"\n El total pagado en concepto de salarios es: ${totalSalarios}\n");

int limite = 65;
for (int i = 0; i < 3; i++)
{
    if (miEmpleado[i].AñosFaltantesParaJubilarse() <= limite)
    {
        limite = miEmpleado[i].AñosFaltantesParaJubilarse();
    }
}

Console.WriteLine("EMPLEADOS PROXIMOS A JUBILARSE:\n");

for (int i = 0; i < 3; i++)
{
    int edadEmpleado = miEmpleado[i].CalcularEdad();
    int antiguedadEmpleado = miEmpleado[i].CalcularAntigüedad();
    double salarioEmp = miEmpleado[i].CalcularSalario();
    int aniosFaltantes = miEmpleado[i].AñosFaltantesParaJubilarse();
    string fechaIngreso = miEmpleado[i].FechaIngreso.ToShortDateString();
    string fechaNacEmp = miEmpleado[i].FechaNacimiento.ToShortDateString();
    if (miEmpleado[i].AñosFaltantesParaJubilarse() == limite)
    {
        Console.WriteLine($"\nEMPLEADO: {i+1}------\n");
        Console.WriteLine($"--Apellido: {miEmpleado[i].Apellido}\n");
        Console.WriteLine($"--Nombre: {miEmpleado[i].Nombre}\n");
        Console.WriteLine($"--Fecha de nacimiento: {fechaNacEmp}\n");
        Console.WriteLine($"--Edad: {edadEmpleado} anios\n");
        Console.Write("--Estado civil: ");
        if (miEmpleado[i].EstadoCivil == 'c')
        {
            Console.Write("Casado\n\n");
        } else
        {
            Console.Write("Soltero\n\n");
        }
        Console.WriteLine($"--Fecha de ingreso a la empresa: {fechaIngreso}\n");
        Console.WriteLine($"--Antiguedad: {antiguedadEmpleado} anios\n");
        Console.WriteLine($"--Cargo: {miEmpleado[i].Cargo}\n");
        Console.WriteLine($"--Sueldo basico: ${miEmpleado[i].SueldoBasico}\n");
        Console.WriteLine($"--Salario: ${salarioEmp}\n");
        Console.WriteLine($"--Cantidad de anios faltantes para poder jubilarse: {aniosFaltantes}\n");
    }

}