using static System.Net.Mime.MediaTypeNames;

namespace Entidades;

public class Usuario
{
    public int Id { get; set; }
    public int TipoUsuarioId { get; set; }
    public virtual TipoUsuario TipoUsuario { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public string ExibirDetalhes(TipoUsuario? tipoUsuario)
    {
        string detalhes = $"<----------------- USUÁRIO {Id} ----------------->" +
                          $"\nTipo de Usuário: {tipoUsuario.Tipo}" +
                          $"\nUsername: {Username}";
        return detalhes;
    }

    public string ExibirDetalhesCompleto(TipoUsuario? tipoUsuario)
    {
        string detalhes = $"<----------------- USUÁRIO {Id} ----------------->" +
                          $"\nTipo de Usuário: {tipoUsuario.Tipo}" +
                          $"\nUsername: {Username}" +
                          $"\nPassword: {Password}";
        return detalhes;
    }
}