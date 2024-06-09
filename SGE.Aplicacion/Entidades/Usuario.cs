public class Usuario{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required List<Permiso> Permisos { get; set; }

    public override string ToString() =>
        $"Usuario(Id: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email})";
}