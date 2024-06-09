using System.Security.Cryptography;
using System.Text;
public class ServicioCriptografiaPassword : IServicioCriptografiaPassword{
    public string EncriptarPassword(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Encoding.UTF8.GetString(bytes);
    }

    //funcion para verificar password fornecido por el usuario con el password encriptado en la base de datos
    public bool VerificarPassword(string passwordEncriptado, string password)
    {
        return EncriptarPassword(password) == passwordEncriptado;
    }
}