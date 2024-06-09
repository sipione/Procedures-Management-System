using SGE.Aplicacion.CasosDeUso;
using SGE.Repositorios;

namespace SGE.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var expedienteRepositorio = new ExpedienteRepositorioArchivo();
            var tramiteRepositorio = new TramiteRepositorioArchivo();
            var servicioAutorizacion = new ServicioAutorizacionProvisorio();

            while (true)
            {
                MostrarMenu();

                var opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        CrearExpediente(expedienteRepositorio, servicioAutorizacion);
                        break;
                    case "2":
                        ActualizarExpediente(expedienteRepositorio, servicioAutorizacion);
                        break;
                    case "3":
                        EliminarExpediente(expedienteRepositorio, servicioAutorizacion, tramiteRepositorio);
                        break;
                    case "4":
                        ConsultarExpediente(expedienteRepositorio);
                        break;
                    case "5":
                        ListarTodosLosExpedientes(expedienteRepositorio);
                        break;
                    case "6":
                        CrearTramite(tramiteRepositorio, servicioAutorizacion, expedienteRepositorio);
                        break;
                    case "7":
                        ActualizarTramite(tramiteRepositorio, servicioAutorizacion, expedienteRepositorio);
                        break;
                    case "8":
                        EliminarTramite(tramiteRepositorio, servicioAutorizacion);
                        break;
                    case "9":
                        ConsultarTramitesPorEtiqueta(tramiteRepositorio);
                        break;
                    case "10":
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear Expediente");
            Console.WriteLine("2. Actualizar Expediente");
            Console.WriteLine("3. Eliminar Expediente");
            Console.WriteLine("4. Consultar Expediente");
            Console.WriteLine("5. Listar Todos los Expedientes");
            Console.WriteLine("6. Crear Tramite");
            Console.WriteLine("7. Actualizar Tramite");
            Console.WriteLine("8. Eliminar Tramite");
            Console.WriteLine("9. Consultar Tramites por Etiqueta");
            Console.WriteLine("10. Salir");
        }

        static void CrearExpediente(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            Console.WriteLine("Ingrese el título del expediente:");
            var titulo = Console.ReadLine()!;
            Console.WriteLine("Ingrese la descripción del expediente:");
            var descripcion = Console.ReadLine()!;
            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            var expediente = new Expediente
            {
                Caratula = titulo,
                FechaCreacion = DateTime.Now,
                FechaUltimaModificacion = DateTime.Now,
                UsuarioUltimaModificacionId = usuarioId,
                Estado = EstadoExpediente.RecienIniciado
            };

            var casoDeUso = new CasoDeUsoExpedienteAlta(expedienteRepositorio, servicioAutorizacion);
            try
            {
                casoDeUso.Ejecutar(expediente, usuarioId);
                Console.WriteLine("Expediente creado con éxito.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ActualizarExpediente(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            Console.WriteLine("Ingrese el ID del expediente a actualizar:");
            var expedienteId = int.Parse(Console.ReadLine()!);

            var expediente = expedienteRepositorio.ObtenerPorId(expedienteId);

            if (expediente == null)
            {
                Console.WriteLine("Expediente no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione los campos a modificar:");
            Console.WriteLine("1. Título");
            Console.WriteLine("2. Estado");
            var opcion = Console.ReadLine()!;

            switch (opcion)
            {
            case "1":
                Console.WriteLine("Ingrese el nuevo título del expediente:");
                var titulo = Console.ReadLine()!;
                expediente.Caratula = titulo;
                break;
            case "2":
                Console.WriteLine("Ingrese el nuevo estado del expediente:");
                var estadoOptions = Enum.GetNames(typeof(EstadoExpediente));
                for (int i = 0; i < estadoOptions.Length; i++)
                {
                Console.WriteLine($"{i + 1}. {estadoOptions[i]}");
                }

                int estadoIndex;
                do
                {
                Console.WriteLine("Seleccione una opción:");
                } while (!int.TryParse(Console.ReadLine(), out estadoIndex) || estadoIndex < 1 || estadoIndex > estadoOptions.Length);

                var estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), estadoOptions[estadoIndex - 1]);
                expediente.Estado = estado;
                break;
            default:
                Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                break;
            }

            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            expediente.FechaUltimaModificacion = DateTime.Now;
            expediente.UsuarioUltimaModificacionId = usuarioId;

            var casoDeUso = new CasoDeUsoExpedienteModificacion(expedienteRepositorio, servicioAutorizacion);

            try
            {
                casoDeUso.Ejecutar(expediente, usuarioId);
                Console.WriteLine("Expediente actualizado con éxito.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
            
        static void EliminarExpediente(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacion, ITramiteRepositorio tramiteRepositorio)
        {
            Console.WriteLine("Ingrese el ID del expediente a eliminar:");
            var expedienteId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            var casoDeUso = new CasoDeUsoExpedienteBaja(expedienteRepositorio, servicioAutorizacion, tramiteRepositorio);

            try{
                casoDeUso.Ejecutar(expedienteId, usuarioId);
                Console.WriteLine("Expediente eliminado con éxito.");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return;
            }
        }

        static void ConsultarExpediente(IExpedienteRepositorio expedienteRepositorio)
        {
            Console.WriteLine("Ingrese el ID del expediente a consultar:");
            var expedienteId = int.Parse(Console.ReadLine()!);

            var casoDeUso = new CasoDeUsoExpedienteConsultaPorld(expedienteRepositorio);
            var expediente = casoDeUso.Ejecutar(expedienteId);

            if (expediente != null)
            {
                Console.WriteLine($"ID: {expediente.Id}");
                Console.WriteLine($"Título: {expediente.Caratula}");
                Console.WriteLine($"Fecha de Creación: {expediente.FechaCreacion}");
                Console.WriteLine($"Fecha de Última Modificación: {expediente.FechaUltimaModificacion}");
                Console.WriteLine($"ID de Usuario de Última Modificación: {expediente.UsuarioUltimaModificacionId}");
                Console.WriteLine($"Estado: {expediente.Estado}");
            }
            else
            {
                Console.WriteLine("Expediente no encontrado.");
            }
        }

        static void ListarTodosLosExpedientes(IExpedienteRepositorio expedienteRepositorio)
        {
            var casoDeUso = new CasoDeUsoExpedienteConsultaTodos(expedienteRepositorio);
            var expedientes = casoDeUso.Ejecutar();

            if (expedientes.Count() == 0)
            {
                Console.WriteLine("No se encontraron expedientes.");
                return;
            }

            foreach (var expediente in expedientes)
            {
                Console.WriteLine($"ID: {expediente.Id}, Título: {expediente.Caratula}, Estado: {expediente.Estado}");
            }
        }

        static void CrearTramite(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio)
        {
            Console.WriteLine("Ingrese el contenido del tramite:");
            var contenido = Console.ReadLine()!;
            Console.WriteLine("Ingrese el ID del expediente asociado:");
            var expedienteId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            var tramite = new Tramite
            {
                Contenido = contenido,
                ExpedienteId = expedienteId,
                FechaCreacion = DateTime.Now,
                FechaUltimaModificacion = DateTime.Now,
                UsuarioUltimaModificacionId = usuarioId,
                Etiqueta = EtiquetaTramite.EscritoPresentado
            };

            var casoDeUso = new CasoDeUsoTramiteAlta(tramiteRepositorio, servicioAutorizacion, expedienteRepositorio);

            try{
                casoDeUso.Ejecutar(tramite, usuarioId);
                Console.WriteLine("Tramite creado con éxito.");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return;
            }
        }

        static void ActualizarTramite(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion, IExpedienteRepositorio expedienteRepositorio)
        {
            Console.WriteLine("Ingrese el ID del tramite a actualizar:");
            var tramiteId = int.Parse(Console.ReadLine()!);

            var tramite = tramiteRepositorio.ObtenerPorId(tramiteId);

            if (tramite == null)
            {
                Console.WriteLine("Tramite no encontrado.");
                return;
            }

            Console.WriteLine("Seleccione el campo a modificar:");
            Console.WriteLine("1. Contenido");
            Console.WriteLine("2. Etiqueta");
            Console.WriteLine("3. Expediente ID");

            var opcion = Console.ReadLine()!;

            switch (opcion)
            {
            case "1":
                Console.WriteLine("Ingrese el nuevo contenido del tramite:");
                var contenido = Console.ReadLine()!;
                tramite.Contenido = contenido;
                break;
            case "2":
                Console.WriteLine("Seleccione las etiquetas separadas por coma:");
                var etiquetasOptions = Enum.GetNames(typeof(EtiquetaTramite));
                for (int i = 0; i < etiquetasOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {etiquetasOptions[i]}");
                }

                int etiquetasIndex;
                do
                {
                    Console.WriteLine("Seleccione una opción:");
                } while (!int.TryParse(Console.ReadLine(), out etiquetasIndex) || etiquetasIndex < 1 || etiquetasIndex > etiquetasOptions.Length);

                EtiquetaTramite etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), etiquetasOptions[etiquetasIndex - 1]);
                tramite.Etiqueta = etiqueta;
                break;
            case "3":
                Console.WriteLine("Ingrese el nuevo ID del expediente asociado:");
                var expedienteId = int.Parse(Console.ReadLine()!);
                tramite.ExpedienteId = expedienteId;
                break;
            default:
                Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                break;
            }

            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            tramite.FechaUltimaModificacion = DateTime.Now;
            tramite.UsuarioUltimaModificacionId = usuarioId;

            var casoDeUso = new CasoDeUsoTramiteModificacion(tramiteRepositorio, servicioAutorizacion, expedienteRepositorio);

            try{
                casoDeUso.Ejecutar(tramite, usuarioId);
                Console.WriteLine("Tramite actualizado con éxito.");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return;
            }
        }

        static void EliminarTramite(ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacion)
        {
            Console.WriteLine("Ingrese el ID del tramite a eliminar:");
            var tramiteId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Ingrese el ID del usuario:");
            var usuarioId = int.Parse(Console.ReadLine()!);

            var casoDeUso = new CasoDeUsoTramiteBaja(tramiteRepositorio, servicioAutorizacion);

            try{
                casoDeUso.Ejecutar(tramiteId, usuarioId);
                Console.WriteLine("Tramite eliminado con éxito.");
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return;
            }

        }
        
        static void ConsultarTramitesPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
        {
            Console.WriteLine("Seleccione las etiquetas separadas por coma:");
                var etiquetasOptions = Enum.GetNames(typeof(EtiquetaTramite));
                for (int i = 0; i < etiquetasOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {etiquetasOptions[i]}");
                }

                int etiquetasIndex;
                do
                {
                    Console.WriteLine("Seleccione una opción:");
                } while (!int.TryParse(Console.ReadLine(), out etiquetasIndex) || etiquetasIndex < 1 || etiquetasIndex > etiquetasOptions.Length);

            EtiquetaTramite etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), etiquetasOptions[etiquetasIndex - 1]);

            var casoDeUso = new CasoDeUsoTramiteConsultaPorEtiqueta(tramiteRepositorio);
            IEnumerable<Tramite> tramites = casoDeUso.Ejecutar(etiqueta);

            if (!tramites.Any())
            {
                Console.WriteLine("No se encontraron trámites con la etiqueta seleccionada.");
                return;
            }

            foreach (var tramite in tramites)
            {
                Console.WriteLine($"ID: {tramite.Id}, Contenido: {tramite.Contenido}, Etiqueta: {tramite.Etiqueta}");
            }
        }
    }
}
