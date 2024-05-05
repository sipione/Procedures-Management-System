namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Rol { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int UsuarioModificacionId { get; set; }

    public Usuario(string nombre, string apellido, string email, string password, string rol, int Id)
    {
        this.Id = Id;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Password = password;
        this.Rol = rol;
        this.Activo = true;
        this.FechaCreacion = DateTime.Now;
        this.FechaModificacion = DateTime.Now;
        this.UsuarioModificacionId = 0;
    }
}
