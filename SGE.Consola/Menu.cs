
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

public class Menu
{
    public string? Name { get; set; }

    public Menu(string name)
    {
        Name = name;
    }
    
    public virtual void Run(){
        Console.Clear();
        Console.WriteLine(this.Name);
    }
}

public class CrearExpediente : Menu{

    public CrearExpediente() : base("Crear Expediente")
    {
    }
        
    public override async void Run(){
        base.Run();
        Console.Write("Ingrese la caratula: ");
        string caratula = Console.ReadLine()!;
        Console.Write("Ingrese el id del usuario: ");
        int usuarioId = int.Parse(Console.ReadLine()!);
        AltaExpedienteRepositorio altaExpedienteRepositorio = new();
        string result = await altaExpedienteRepositorio.CrearExpediente(caratula, usuarioId);
        Console.WriteLine(result);
    }
}

public class CrearUsuario : Menu{

    public CrearUsuario() : base("Crear Usuario"){}

    public override async void Run(){
        base.Run();
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
    }
}

public class CrearTramite : Menu{

    public CrearTramite() : base("Crear Tramite"){}

    async public override void Run(){
        base.Run();
        Console.Write("Ingrese el id del expediente: ");
        int idExpediente = int.Parse(Console.ReadLine()!);
        Console.Write("Ingrese el contenido: ");
        string contenido = Console.ReadLine()!;
        Console.Write("Ingrese el id del usuario: ");
        int usuarioId = int.Parse(Console.ReadLine()!);

        AltaTramiteRepositorio altaTramiteRepositorio = new();
        string rsult = await AltaTramiteRepositorio.CrearTramite(idExpediente, contenido, usuarioId);
        Console.WriteLine("Tramite creado con exito");
    }
}

public class ConsultaExpedientePorId : Menu{

    public ConsultaExpedientePorId() : base("Consultar Expediente Por Id"){}

    public override void Run(){
        base.Run();
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
    }
}

public class ConsultarTodosExpedientes : Menu{

    public ConsultarTodosExpedientes() : base("Consultar Todos los expedientes"){}

    public override void Run(){
        base.Run();
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
}

public class ConsultarTramitesPorId : Menu{

    public ConsultarTramitesPorId() : base("Consultar tramites por Id"){}

    public override void Run(){
        base.Run();
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
    }
}

public class ConsultarTramitesPorExpediente : Menu{

    public ConsultarTramitesPorExpediente() : base("Consultar tramites por expediente"){}

    public override void Run(){
        base.Run();
        Console.Write("Ingrese el id del expediente: ");
        int id = int.Parse(Console.ReadLine()!);
        List<Tramite>? tramites = ConsultaTramite.ConsultarPorExpediente(id);
        if(tramites != null && tramites.Count > 0){
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
    }
}

public class ConsultaTodosTramites : Menu{
    public ConsultaTodosTramites(string name = "Consultar Tramites") : base("Consultar todos los tramites"){}
    
    public override void Run(){
        base.Run();
        List<Tramite>? tramites = ConsultaTramite.ConsultaTodosTramites();
        if(tramites != null){
            foreach(Tramite tramite in tramites){
                Console.WriteLine($"Id: {tramite.Id}");
                Console.WriteLine($"IdExpediente: {tramite.IdExpediente}");
                Console.WriteLine($"Etiqueta: {tramite.Etiqueta}");
                Console.WriteLine($"Contenido: {tramite.Contenido}");
                Console.WriteLine($"FechaCreacion: {tramite.FechaCreacion}");
                Console.WriteLine($"FechaModificacion: {tramite.FechaModificacion}");
                Console.WriteLine($"UsuarioModificacionId: {tramite.UsuarioModificacionId}");
                Console.WriteLine($"Estado: {tramite.Estado}");
                Console.WriteLine($"---------------------------------------------------------");
            }
        }else{
            Console.WriteLine("No fue encontrado nungun tramite");
        }
    }
}

