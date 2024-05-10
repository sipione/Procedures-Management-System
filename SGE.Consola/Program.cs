using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

void Menu(){
    Console.Clear();
    Console.WriteLine("Sistema de Tramites y Expedientes de la SGE");
    Console.WriteLine("Ingrese la opcion del Menu");
    Console.WriteLine("1. Crear Expediente");
    Console.WriteLine("2. Registrar Usuario");
    Console.WriteLine("3. Crear Tramites");
    Console.WriteLine("4. Consultar Expediente por Id");
    Console.WriteLine("5. Consultar Tramites por id");
    Console.WriteLine("6. Consultar Tramites por Expediente");
    Console.WriteLine("7. Consultar todos los Expedientes");
    Console.WriteLine("8. Consultar todos los Tramites");
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
            ConsultaExpedientePorId();
            break;
        case "5":
            ConsultarTramitesPorId();
            break;
        case "6":
            ConsultarTramitesPorExpediente();
            break;
        case "7":
            ConsultarTodosExpedientes();
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
    int idExpediente = int.Parse(Console.ReadLine()!);
    Console.Write("Ingrese el contenido: ");
    string contenido = Console.ReadLine()!;
    Console.Write("Ingrese el id del usuario: ");
    int usuarioId = int.Parse(Console.ReadLine()!);

    AltaTramiteRepositorio altaTramiteRepositorio = new();
    string rsult = await AltaTramiteRepositorio.CrearTramite(idExpediente, contenido, usuarioId);
    Console.WriteLine("Tramite creado con exito");
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

void ConsultaExpedientePorId(){
    Console.Clear();
    Console.WriteLine("Consultar Expediente");
    Console.Write("Ingrese el id del expediente: ");
    int id = int.Parse(Console.ReadLine()!);
    Expediente? expediente = ConsultaExpediente.ConsultarPorId(id);
    if(expediente != null){
        Console.WriteLine($"Id: {expediente.Id}");
        Console.WriteLine($"Caratula: {expediente.Caratula}");
        Console.WriteLine($"Fecha de creacion: {expediente.FechaCreacion}");
        Console.WriteLine($"Fecha de modificacion: {expediente.FechaModificacion}");
        Console.WriteLine($"Usuario de modificacion: {expediente.UsuarioModificacionId}");
        Console.WriteLine($"Estado: {expediente.Estado}");
    }else{
        Console.WriteLine($"No fue posible encontrar el expediente con id: {id}");
    }
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

void ConsultarTodosExpedientes(){
    Console.Clear();
    Console.WriteLine("Consultar todos los Expedientes");
    List<Expediente> expedientes = ConsultaExpediente.ConsultarTodos();
    if(expedientes.Count > 0){
        foreach (var expediente in expedientes)
        {
            Console.WriteLine($"Id: {expediente.Id}");
            Console.WriteLine($"Caratula: {expediente.Caratula}");
            Console.WriteLine($"Fecha de creacion: {expediente.FechaCreacion}");
            Console.WriteLine($"Fecha de modificacion: {expediente.FechaModificacion}");
            Console.WriteLine($"Usuario de modificacion: {expediente.UsuarioModificacionId}");
            Console.WriteLine($"Estado: {expediente.Estado}");
            Console.WriteLine("-------------------------------------------------");
        }
    }else{
        Console.WriteLine("No hay expedientes registrados");
    }
}

void ConsultarTramitesPorId(){
    Console.Clear();
    Console.WriteLine("Consultar Tramites por Id");
    Console.Write("Ingrese el id del tramite: ");
    int id = int.Parse(Console.ReadLine()!);
    Tramite? tramite = ConsultaTramite.ConsultarPorId(id);
    if(tramite != null){
        Console.WriteLine($"Id: {tramite.Id}");
        Console.WriteLine($"Contenido: {tramite.Contenido}");
        Console.WriteLine($"Fecha de creacion: {tramite.FechaCreacion}");
        Console.WriteLine($"Fecha de modificacion: {tramite.FechaModificacion}");
        Console.WriteLine($"Usuario de modificacion: {tramite.UsuarioModificacionId}");
        Console.WriteLine($"Estado: {tramite.Estado}");
    }else{
        Console.WriteLine($"No fue posible encontrar el tramite con id: {id}");
    }
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

void ConsultarTramitesPorExpediente(){
    Console.Clear();
    Console.WriteLine("Consultar Tramites por Expediente");
    Console.Write("Ingrese el id del expediente: ");
    int id = int.Parse(Console.ReadLine()!);
    List<Tramite> tramites = ConsultaTramite.ConsultarPorExpediente(id);
    if(tramites.Count > 0){
        foreach (var tramite in tramites)
        {
            Console.WriteLine($"Id: {tramite.Id}");
            Console.WriteLine($"Contenido: {tramite.Contenido}");
            Console.WriteLine($"Fecha de creacion: {tramite.FechaCreacion}");
            Console.WriteLine($"Fecha de modificacion: {tramite.FechaModificacion}");
            Console.WriteLine($"Usuario de modificacion: {tramite.UsuarioModificacionId}");
            Console.WriteLine($"Estado: {tramite.Estado}");
            Console.WriteLine("-------------------------------------------------");
        }
    }else{
        Console.WriteLine("No hay tramites registrados para el expediente");
    }
    Console.WriteLine("Presione una tecla para continuar");
    Console.Read();
    Menu();
}

