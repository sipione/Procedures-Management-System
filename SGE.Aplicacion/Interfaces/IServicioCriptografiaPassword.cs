public interface IServicioCriptografiaPassword
{
    string EncriptarPassword(string texto);
    bool VerificarPassword(string passwordEncriptado, string password);
}