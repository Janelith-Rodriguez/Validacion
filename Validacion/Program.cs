using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Validación de la patente
        Console.WriteLine("Ingrese la patente del vehículo:");
        string patente = Console.ReadLine();

        if (ValidarPatente(patente))
        {
            Console.WriteLine("La patente es válida.");
        }
        else
        {
            Console.WriteLine("La patente no es válida.");
        }

        // Extracción de DNI desde CUIL
        Console.WriteLine("\nIngrese el CUIL (formato N-NNNNNNNN-N):");
        string cuil = Console.ReadLine();

        string dni = ExtraerDniDeCuil(cuil);
        if (!string.IsNullOrEmpty(dni))
        {
            Console.WriteLine($"El DNI extraído es: {dni}");
        }
        else
        {
            Console.WriteLine("El formato de CUIL no es válido.");
        }
    }

    static bool ValidarPatente(string patente)
    {
        // Patentes actuales: "AANNNAA" o "AAANNN"
        string formato1 = @"^[A-Z]{2}\d{3}[A-Z]{2}$"; // AANNNAA
        string formato2 = @"^[A-Z]{3}\d{3}$";         // AAANNN

        return Regex.IsMatch(patente.ToUpper(), formato1) || Regex.IsMatch(patente.ToUpper(), formato2);
    }

    static string ExtraerDniDeCuil(string cuil)
    {
        // Validar el formato del CUIL N-NNNNNNNN-N
        string formatoCuil = @"^\d-\d{8}-\d$";

        if (Regex.IsMatch(cuil, formatoCuil))
        {
            // Extraer los 8 dígitos del DNI
            return cuil.Split('-')[1];
        }
        return null;
    }
}
