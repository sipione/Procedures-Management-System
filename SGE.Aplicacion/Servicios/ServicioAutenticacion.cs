using System.Security.Cryptography;
using System.Text;
using System.Web;



public class ServicioAutenticacion : IServicioAutenticacion{
    public string EncriptarPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Encoding.UTF8.GetString(bytes);
    }

    public bool VerificarPassword(string passwordEncriptado, string password)
    {
        return EncriptarPassword(password) == passwordEncriptado;
    }
}