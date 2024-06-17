public interface IServicioAutenticacion
{
    string EncriptarPassword(string texto);
    bool VerificarPassword(string passwordEncriptado, string password);
}