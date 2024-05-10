public class GeneralExcepcion : Exception
{
    public static Exception NotFoundExcepcion(string message)
    {
        return new Exception($"Error 404. {message}");
    }
}