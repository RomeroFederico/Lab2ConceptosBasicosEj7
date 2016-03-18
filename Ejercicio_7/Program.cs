using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio_7
{

    /*
    07.  Hacer un programa que pida por pantalla la fecha de nacimiento de 
    una persona (día, mes y año) y calcule el número de días vividos 
    por esa persona hasta la fecha actual (tomar la fecha del sistema 
    con DateTime.Now).  
 
    Nota: Utilizar estructuras selectivas. Tener en cuenta los años 
    bisiestos.
    */

    class Ejercicio_7
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro. 7";

            int[] year = new int[2];
            int[] month = new int[2];
            int[] day = new int[2];

            int[] total = new int[2];

            Console.Write("Ingrese el año de su nacimiento: ");

            while (!int.TryParse(Console.ReadLine(), out year[0]))
            {
                Console.Clear();
                Console.Write("Error!!! Ingrese el año de su nacimiento: ");
            }

            Console.Clear();
            Console.Write("Ingrese el mes de su nacimiento: ");

            do
            {
                while (!int.TryParse(Console.ReadLine(), out month[0]))
                {
                    Console.Clear();
                    Console.Write("Error!!! Ingrese el año de su nacimiento: ");
                }

                if (month[0] > 12 || month[0] < 1)
                {
                    Console.Clear();
                    Console.Write("Error!!! Ingrese un mes valido de su nacimiento: ");
                }
            } while (month[0] > 12 || month[0] < 1);

            Console.Clear();
            Console.Write("Ingrese el dia de su nacimiento: ");

            do
            {
                while (!int.TryParse(Console.ReadLine(), out day[0]))
                {
                    Console.Clear();
                    Console.Write("Error!!! Ingrese el dia de su nacimiento: ");
                }

                if (day[0] >= 1 && day[0] <= 31)
                {
                    if (month[0] == 2 && day[0] == 29 && (year[0] % 4 == 0 && year[0] % 100 != 0 || year[0] % 400 == 0))
                        break;
                    else if (month[0] == 2 && day[0] <= 28)
                        break;
                    else if ((month[0] == 1 || month[0] == 3 || month[0] == 5 || month[0] == 7 || month[0] == 8 || month[0] == 10 || month[0] == 12) && day[0] == 31)
                        break;
                    else if (month[0] != 2 && day[0] <= 30)
                        break;
                }

                Console.Clear();
                Console.Write("Error!!! Dia no valido. Ingrese el dia de su nacimiento: ");

            } while (true);

            year[1] = DateTime.Now.Year;
            month[1] = DateTime.Now.Month;
            day[1] = DateTime.Now.Day;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < year[j]; i++)
                {
                    if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0)
                        total[j] += 1;
                    total[j] += 365;
                }

                for (int i = 0; i < month[j]; i++)
                {
                    if (i == 2)
                    {
                        if (year[j] % 4 == 0 && year[j] % 100 != 0 || year[j] % 400 == 0)
                            total[j] += 1;
                        total[j] += 28;
                    }
                    else if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10)
                        total[j] += 31;
                    else
                        total[j] += 30;
                }

                total[j] += day[j];
            }

            Console.Clear();
            Console.WriteLine("El total de dias vividos es de {0} dias. ", total[1] - total[0]);

            Console.ReadKey();
        }
    }
}
