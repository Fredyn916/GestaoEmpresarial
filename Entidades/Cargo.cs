using System.Runtime.ConstrainedExecution;

namespace Entidades;

public class Cargo
{
    public int Id { get; set; }
    public string Ocupacao { get; set; }
    public double Remuneracao { get; set; }
    public int Step { get; set; }

    public override string ToString()
    {
        return $"<----------------- CARGO {Id} ----------------->" +
               $"\nOcupação: {Ocupacao}" +
               $"\nRemuneração: R$ {Remuneracao}" +
               $"\nStep: {Step}";
    }
}