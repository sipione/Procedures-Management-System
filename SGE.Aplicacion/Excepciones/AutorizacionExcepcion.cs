namespace SGE.Aplicacion;

public class AutorizacionExcepcion
{
    public static Exception NotAuthorizedException(string msg){
        return new Exception($"User not authorized. {msg}");
    }
}
