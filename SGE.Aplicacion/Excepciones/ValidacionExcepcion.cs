internal class ValidacionExcepcion{

    internal static Exception AltaExpedienteNotValid(string msg){
        return new Exception($"The expediente is not valid. {msg}");
    }

    internal static Exception AltaUsuarioNotValid(string msg){
        return new Exception($"The user is not valid. {msg}");
    }
}