namespace espacioCalculadora;

public class Calculadora
{
    private double Dato; //este atributo es privado. Esto significa que solo los métodos dentro de la clase Calculadora pueden acceder a él y modificarlo
    public double Resultado { get => Dato; } 

    //metodos PUBLICOS - al ser publicos pueden ser llamados desde cualquier parte de mi programa 
    public void Sumar(double valor)
    {
        Dato = Dato + valor;
    }
    public void Restar(double valor)
    {
        Dato = Dato - valor;
    }
    public void Multiplicar(double valor)
    {
        Dato = Dato * valor;
    }
    public void Dividir(double valor)
    {
        if (valor != 0) {
            Dato= Dato / valor;
        } else {
            Console.WriteLine("No se puede dividir sobre 0");
        }
    }
    public void Limpiar()
    {
        Dato = 0;
    }
}