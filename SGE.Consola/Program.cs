// See https://aka.ms/new-console-template for more information

using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

void Menu(){
    Console.Clear();
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
    string opcion = Console.ReadLine()!;
    switch (opcion)
    {
        case "1":
            CrearExpediente();
            break;
        case "2":
            CrearUsuario();
            break;
        case "3":
            CrearTramite();
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
}

Menu();

async void CrearExpediente(){
    Console.Clear();
    Console.WriteLine("Crear Expediente");
    Console.Write("Ingrese la caratula: ");
    string caratula = Console.ReadLine()!;
    Console.Write("Ingrese el id del usuario: ");
    int usuarioId = int.Parse(Console.ReadLine()!);
    AltaExpedienteRepositorio altaExpedienteRepositorio = new();
    string result = await altaExpedienteRepositorio.CrearExpediente(caratula, usuarioId);
    Console.WriteLine(result);
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

async void CrearUsuario(){
    Console.Clear();
    Console.WriteLine("Registrar Usuario");
    Console.Write("Ingrese el nombre: ");
    string nombre = Console.ReadLine()!;
    Console.Write("Ingrese el apellido: ");
    string apellido = Console.ReadLine()!;
    Console.Write("Ingrese el email: ");
    string email = Console.ReadLine()!;
    Console.Write("Ingrese la contraseña: ");
    string password = Console.ReadLine()!;
    Console.Write("Ingrese el rol: ");
    string role = Console.ReadLine()!;

    AltaUsuarioRepositorio altaUsuarioRepositorio = new();
    string result = await altaUsuarioRepositorio.CrearUsuario(nombre, apellido, email, password, role);
    Console.WriteLine(result);
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

async void CrearTramite(){
    Console.Clear();
    Console.WriteLine("Crear Tramite");
    Console.Write("Ingrese el id del expediente: ");
    string idExpediente = Console.ReadLine()!;
    Console.Write("Ingrese el contenido: ");
    string contenido = Console.ReadLine()!;
    Console.Write("Ingrese el id del usuario: ");
    int usuarioId = int.Parse(Console.ReadLine()!);

    AltaTramiteRepositorio altaTramiteRepositorio = new();
    string rsult = await altaTramiteRepositorio.CrearTramite(idExpediente, contenido, usuarioId);
    Console.WriteLine("Tramite creado con exito");
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}