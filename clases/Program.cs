// See https://aka.ms/new-console-template for more information
Console.Write("Ingresa tu numero natural : ");
int numerodelusuario = int.Parse(Console.ReadLine());

NumerosNaturales numero = new NumerosNaturales(numerodelusuario);
numero.Mostrar();
if (numero.EsPrimo())
{
    Console.WriteLine("El número es primo.");
}
else Console.WriteLine("El numero es no primo");


int cantdigitos = numero.cantdigitos();
if (cantdigitos > 1)
{
    Console.WriteLine("El numero tiene " + cantdigitos + " digitos");

}
else Console.WriteLine("El numero tiene " + cantdigitos + " digito");


string transcripcion = numero.TranscripcionFinal();


    Console.WriteLine("La transcripción del número es: " + transcripcion);

Console.Write("Ingrese el numero que quiere que se introduzca y la posicion para dicho numero :");
int numeroinsertar = int.Parse(Console.ReadLine());
int posicion = int.Parse(Console.ReadLine());

numero.insertarnumero(numeroinsertar,posicion);

Console.WriteLine("");



numero.Mostrar();