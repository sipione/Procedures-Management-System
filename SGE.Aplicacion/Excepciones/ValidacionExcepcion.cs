internal class ValidacionExcepcion{

    internal static Exception ExpedienteNotValid(string msg){
        return new Exception($"The expediente is not valid. {msg}");
    }

    internal static Exception UsuarioNotValid(string msg){
        return new Exception($"The user is not valid. {msg}");
    }

    internal static Exception TramiteNotValid(string msg){
        return new Exception($"The tramite is not valid. {msg}");
    }
}