public class NumerosNaturales
{
    private int numero;

    public NumerosNaturales(int num)
    {
        if (num < 0)
        {
            Console.WriteLine("El número no puede ser negativo. Se establecerá en 0.");
            numero = 0;
            return;
        }
        numero = num;
    }

    public bool EsPrimo()
    {
        if (numero == 0 || numero == 1)
        {
            return false;
        }

        for (int i = 2; i <= (int)Math.Sqrt(numero); i++)
        {
            if (numero % i == 0)
            {
                return false;
            }
        }

        return true;
    }
    public int cantdigitos()
    {
        return (int)Math.Log10(numero) + 1;
    }

    public void Mostrar()
    {
        Console.WriteLine("El número natural es: " + numero);
    }

    public string transcripcionUDC(int numcop)
    {


        string[,] transcrip = new string[3, 10]
        {
    {"cero","uno","dos","tres","cuatro","cinco","seis","siete","ocho","nueve"},
    {"","diez","veinte","treinta","cuarenta","cincuenta","sesenta","setenta","ochenta","noventa"},
    {"","cien","doscientos","trescientos","cuatrocientos","quinientos","seiscientos","setecientos","ochocientos","novecientos"},
        };


        string[] especiales = new string[9] { "once", "doce", "trece", "catorce", "quince", "dieciseis", "diecisiete", "dieciocho", "diecinueve" };


        bool ver = false;
        int pos = 0, rest = 0, copia = 0;
        string result = "";

        while (numcop > 0)
        {
            rest = numcop % 10;


            if (rest == 2 && pos == 1 && result != "")
            {
                result = "veinti" + result;
                ver = true;
            }
            if (rest == 1 && pos == 2 && result != "")
            {
                result = "ciento " + result;
                ver = true;
            }
            if (rest == 1 && pos == 1 && copia >= 1)
            {
                result = especiales[copia - 1];
                ver = true;
            }
            if (rest >= 1 && pos == 1 && result != "" && ver == false)
            {
                result = transcrip[pos, rest] + " y " + result;
                ver = true;
            }


            if ((rest >= 1 && pos == 0) || (rest >= 1 && ver == false))
            {
                if (result == "")
                {
                    result = transcrip[pos, rest];
                    copia = rest;
                }
                else
                {
                    result = transcrip[pos, rest] + " " + result;
                }
            }
            numcop = numcop / 10;
            ver = false;
            ++pos;
        }
        return result;


    }

    public string TranscripcionFinal()
    {


        int numcop = numero;
        int rest = 0;
        int pos = 0;
        string result = "";


        if (numero == 0)
        {
            result = "CERO";
            return result;
        }

        string f = "";
        while (numcop > 0)
        {
            rest = numcop % 1000;
            f = transcripcionUDC(rest);


            if (pos == 3 && rest != 0)
            {
                if (f == "uno")
                    result = "un billon " + result;
                else
                    result = f + " billones " + result;
            }
            if (pos == 2 && rest != 0)
            {
                if (f == "uno")
                    result = "un millon " + result;
                else
                    result = f + " millones " + result;
            }
            if (pos == 1 && rest != 0)
            {
                if (f == "uno")
                    result = "mil " + result;
                else
                    result = f + " mil " + result;
            }
            if (pos == 0)
            {
                result = f;
            }

            numcop = numcop / 1000;
            ++pos;
        }
        return result;
    }

    public int estadodelnumero() // metodo para obtener el estado del numero
    {
        return numero;
    }

    public void modificar(int num)
    {
        if (num < 0)
        {
            Console.WriteLine("El número no puede ser negativo. No se realizará ningún cambio.");
            return;
        }
        numero = num;
    }

    public void insertarnumero(int numerous ,int usuario = 0)
    {
        int elcopias = numero , expo=-1 , residuo =0 , final =0 ;
        int pos = cantdigitos();
        if (numerous < 0) // no puede ser negativo
        {
            Console.Write("El numero que quieres insertar no puede ser negativo");
            return;
        }
        if(numerous==0 && usuario == 1) // no se puede insertar un 0 en la primera posicion de un numero entero
        {

            Console.WriteLine("No puedes agregar un 0 a la primera posicion de un numero entero");
            return;
        }
        if(usuario > pos+1 || usuario <=0) // validar la posicion que el usuario insertar 
        {
            Console.Write("Tu posicion que elegiste para el numero se pasa o es menor que los digitos que actualmente tiene tu numero natural");
            return;
        }
        
        if (numerous == 0) // caso para que el cero no anule todo
        {
            numerous = 1;
        }
        if(usuario == 1)
        {
            final = numero + (numerous * (int)Math.Pow(10, pos));
        }
        else if (usuario == pos+1)
        {
            final = numerous + (numero * (int)Math.Pow(10, 1));

        }
        else if (usuario >= 1) { 
        while (elcopias > 0)
        {
            residuo = elcopias % 10;
            elcopias = elcopias / 10;
            ++expo;
            final = final + (residuo * (int)Math.Pow(10, expo));
           
            if (usuario == pos)
            {
                    ++expo;
                    final = final + (numerous * (int)Math.Pow(10, expo));
                
             }
            

            --pos;
        }
        
    }

        modificar(final); // modificar el numero con la funcion modificar para que el numero se actualice con el nuevo numero insertado


    }

    }