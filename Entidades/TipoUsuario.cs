using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades;

public class TipoUsuario
{
    public int Id { get; set; }
    public string Tipo { get; set; }
}