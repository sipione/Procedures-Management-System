
public class SGESqlite
{
    public static void Inicializar(SGEContexto context)
    {
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }
}