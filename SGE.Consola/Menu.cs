
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

public class Menu
{
    public string? Name { get; set; }

    public Menu(string name)
    {
        Name = name;
    }
    
    public virtual async Task Run(){
        Console.Clear();
        Console.WriteLine(this.Name);
    }

    public virtual int subMenu(string titulo, List<string> options){
        Console.WriteLine($"\n{titulo}");
        for(int i = 0; i < options.Count; i++){
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.Write("Seleccione una opcion: ");
        return int.Parse(Console.ReadLine()!);
    }
}

public class CrearExpediente : Menu{

    public CrearExpediente() : base("Crear Expediente")
    {
    }
        
    public override async Task Run(){
        await base.Run();
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

    public override async Task Run(){
        await base.Run();
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

    public override async Task Run(){
        await base.Run();
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

    public override async Task Run(){
        await base.Run();
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

    public override async Task Run(){
        await base.Run();
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

    public override async Task Run(){
        await base.Run();
        Console.Write("Ingrese el id del tramite: ");
        int id = int.Parse(Console.ReadLine()!);
        Tramite? tramite = ConsultaTramite.ConsultarPorId(id);
        if(tramite != null){
            Console.WriteLine($"Id: {tramite.Id}");
            Console.WriteLine($"Contenido: {tramite.Contenido}");
            Console.WriteLine($"Fecha de creacion: {tramite.FechaCreacion}");
            Console.WriteLine($"Fecha de modificacion: {tramite.FechaModificacion}");
            Console.WriteLine($"Usuario de modificacion: {tramite.UsuarioModificacionId}");
            Console.WriteLine($"Etiqueta: {tramite.Etiqueta}");
        }else{
            Console.WriteLine($"No fue posible encontrar el tramite con id: {id}");
        }
    }
}

public class ConsultarTramitesPorExpediente : Menu{

    public ConsultarTramitesPorExpediente() : base("Consultar tramites por expediente"){}

    public override async Task Run(){
        await base.Run();
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
                Console.WriteLine($"Etiqueta: {tramite.Etiqueta}");
                Console.WriteLine("-------------------------------------------------");
            }
        }else{
            Console.WriteLine("No hay tramites registrados para el expediente");
        }
    }
}

public class ConsultaTodosTramites : Menu{
    public ConsultaTodosTramites(string name = "Consultar Tramites") : base("Consultar todos los tramites"){}
    
    public override async Task Run(){
        await base.Run();
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
                Console.WriteLine($"---------------------------------------------------------");
            }
        }else{
            Console.WriteLine("No fue encontrado nungun tramite");
        }
    }
}

public class ModificarExpediente : Menu{
    public ModificarExpediente() : base("Modificar Expediente"){}

    public override async Task Run(){
        await base.Run();
        List<string> options = new();
        options.Add("Modificar caratula");
        options.Add("Modificar estado");
        int option = base.subMenu("Seleccione una opcion", options);

        Console.Write("Ingrese el id del expediente: ");
        int id = int.Parse(Console.ReadLine()!);
        int usuarioId = 1;

        switch(option){
            case 1:
                await this.ModificacionCaratula(id, usuarioId);
                break;
            case 2:
                await this.ModificacionEstado(id, usuarioId);
                break;
            default:
                Console.WriteLine("Opcion invalida");
                await this.Run();
                break;
        }
    }

    async private Task ModificacionEstado(int id, int usuarioId)
    {
         Console.Write("Ingrese el nuevo estado: ");
        List<string> estados = new();
        foreach (var item in Enum.GetValues(typeof(EstadoExpediente)))
        {
            estados.Add(item.ToString()!);
        }
        int estadoIndex = base.subMenu("Seleccione un estado", estados);
        EstadoExpediente estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), estados[estadoIndex]);

        try{
            await ModificacionExpedienteRepositorio.ModificarEstado(estado, id, usuarioId);
            Console.WriteLine("Estado modificado con exito");
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }
    }

    async private Task ModificacionCaratula(int id, int usuarioId)
    {
        Console.Write("Ingrese la nueva caratula: ");
        string caratula = Console.ReadLine()!;
        try{
            await ModificacionExpedienteRepositorio.ModificarCaratula(caratula, id, usuarioId);
            Console.WriteLine("Caratula modificada con exito");
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }
    }
}

public class ModificarTramite : Menu{
    public ModificarTramite() : base("Modificar Tramite"){}

    public override async Task Run(){
        await base.Run();
        Console.Write("Ingrese el id del tramite: ");
        int id = int.Parse(Console.ReadLine()!);
        int usuarioId = 1;
        List<string> options = new();
        options.Add("Modificar contenido");
        options.Add("Modificar etiqueta");

        int option = base.subMenu("Seleccione una opcion", options);

        switch(option){
            case 1:
                await this.ModificacionContenido(id, usuarioId);
                break;
            case 2:
                await this.ModificacionEtiqueta(id, usuarioId);
                break;
            default:
                Console.WriteLine("Opcion invalida");
                await this.Run();
                break;
        }
    }

    async private Task ModificacionEtiqueta(int id, int usuarioId)
    {
        Console.Write("Ingrese la nueva etiqueta: ");
        List<string> etiquetas = new();
        foreach (var item in Enum.GetValues(typeof(EtiquetaTramite)))
        {
            etiquetas.Add(item.ToString()!);
        }
        int etiquetaIndex = base.subMenu("Seleccione una etiqueta", etiquetas);
        EtiquetaTramite etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), etiquetas[etiquetaIndex]);
        try{
            await ModificacionTramiteRepositorio.ModificarEtiqueta(etiqueta, id, usuarioId);
            Console.WriteLine("Etiqueta modificada con exito");
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }
    }

    async private Task ModificacionContenido(int id, int usuarioId)
    {
        Console.Write("Ingrese el nuevo contenido: ");
        string contenido = Console.ReadLine()!;
        try{
            await ModificacionTramiteRepositorio.ModificarContenido(contenido, id, usuarioId);
            Console.WriteLine("Contenido modificado con exito");
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }

    }
}

public class BajaExpediente : Menu{
    public BajaExpediente() : base("Baja Expediente"){}

    public override async Task Run(){
        await base.Run();
        Console.Write("Ingrese el id del expediente: ");
        int id = int.Parse(Console.ReadLine()!);
        int usuarioId = 1;
        try{
            await BajaExpedienteRepositorio.DeleteExpediente(id, usuarioId);
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }
    }
}

public class BajaTramite : Menu{
    public BajaTramite() : base("Baja Tramite"){}

    public override async Task Run(){
        await base.Run();
        Console.Write("Ingrese el id del tramite: ");
        int id = int.Parse(Console.ReadLine()!);
        int usuarioId = 1;
        try{
            await BajaTramiteRepositorio.DeleteTramite(id, usuarioId);
        }catch(Exception e){
            Console.WriteLine($"Oops, algo salió mal. Error: {e.Message}");
        }
    }
}
