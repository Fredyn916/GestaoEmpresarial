namespace Entidades;

public class Usuario
{
    public int Id { get; set; }
    public int TipoUsuarioId { get; set; }
    public virtual TipoUsuario TipoUsuario { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}