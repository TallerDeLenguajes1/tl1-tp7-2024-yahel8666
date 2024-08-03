using System;
namespace claseEmpleados; 
public enum Cargo
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}

public class Empleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char EstadoCivil { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double SueldoBasico { get; set; }
    public Cargo Cargo { get; set; }

    public int CalcularAntigüedad()
    {
        TimeSpan antiguedad = DateTime.Now - FechaIngreso;
        return (int)antiguedad.TotalDays / 365;
    }
    public int CalcularEdad()
    {
        TimeSpan edad = DateTime.Now - FechaNacimiento;
        return (int)edad.TotalDays / 365;
    }
    public int AñosFaltantesParaJubilarse()
    {
        int edadActual = CalcularEdad();
        return 65 - edadActual;
    }

    public double CalcularAdicional()
    {
        int antiguedad = CalcularAntigüedad();
        double adicional = SueldoBasico * (antiguedad <= 20 ? antiguedad * 0.01 : 0.25);

        if (Cargo == Cargo.Ingeniero || Cargo == Cargo.Especialista)
        {
            adicional *= 1.5;
        }

        if (EstadoCivil == 'C')
        {
            adicional += 150000;
        }

        return adicional;
    }

    public double CalcularSalario()
    {
        return SueldoBasico + CalcularAdicional();
    }


}
