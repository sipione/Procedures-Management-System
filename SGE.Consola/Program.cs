using SGE.Aplicacion.Entidades;
using SGE.Repositorios;

List<Menu> menus = new();
menus.Add(new CrearUsuario());
menus.Add(new CrearTramite());
menus.Add(new CrearExpediente());
menus.Add(new ConsultaExpedientePorId());
menus.Add(new ConsultarTodosExpedientes());
menus.Add(new ConsultarTramitesPorId());
menus.Add(new ConsultarTramitesPorExpediente());
menus.Add(new ConsultaTodosTramites());

bool finish = false;
while(!finish){
    for(int i = 0; i < menus.Count; i++){
        Console.WriteLine($"{i + 1}. {menus[i].Name}");
    }
    Console.WriteLine($"{menus.Count + 1}. Salir");
    Console.Write("Seleccione una opcion: ");
    int option = int.Parse(Console.ReadLine()!);
    if(option == menus.Count + 1){
        finish = true;
    }
    
    if(option > 0 && option <= menus.Count){
        menus[option - 1].Run();
    }else{
        Console.WriteLine("Opcion invalida");
    }

    Console.WriteLine("\nPresione una tecla para continuar. Atencion, la consola se limpiará.");
    Console.Read();
    Console.Clear();
}
