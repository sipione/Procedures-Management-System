// See https://aka.ms/new-console-template for more information
Console.WriteLine("Sistema de Tramites y Expedientes de la SGE");
Console.WriteLine("Ingrese la opcion del Menu");
Console.WriteLine("1. Crear Expediente");
Console.WriteLine("2. Registrar Usuario");
Console.WriteLine("3. Crear Tramites");
Console.WriteLine("4. Consultar Expediente");
Console.WriteLine("5. Consultar Tramites");
Console.WriteLine("6. Baja de Tramites");
Console.WriteLine("7. Baja de Expediente");
Console.WriteLine("8. Modificar Expediente");
Console.WriteLine("9. Modificar Tramites");
Console.WriteLine("10. Consultar Usuarios");
Console.WriteLine("11. Salir");
Console.Write("Opcion: ");
string opcion = Console.ReadLine();
switch (opcion)
{
    case "1":
        Console.WriteLine("Crear Expediente");
        break;
    case "2":
        Console.WriteLine("Registrar Usuario");
        break;
    case "3":
        Console.WriteLine("Crear Tramites");
        break;
    case "4":
        Console.WriteLine("Consultar Expediente");
        break;
    case "5":
        Console.WriteLine("Consultar Tramites");
        break;
    case "6":
        Console.WriteLine("Baja de Tramites");
        break;
    case "7":
        Console.WriteLine("Baja de Expediente");
        break;
    case "8":
        Console.WriteLine("Modificar Expediente");
        break;
    case "9":
        Console.WriteLine("Modificar Tramites");
        break;
    case "10":
        Console.WriteLine("Consultar Usuarios");
        break;
    case "11":
        Console.WriteLine("Salir");
        break;
    default:
        Console.WriteLine("Opcion no valida");
        break;
}
