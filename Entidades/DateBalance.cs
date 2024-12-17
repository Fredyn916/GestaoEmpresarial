using static System.Net.Mime.MediaTypeNames;

namespace Entidades;

public class DateBalance
{
    public int Id { get; set; }
    public DateOnly Data { get; set; }

    public string ExibirDetalhes()
    {
        string detalhes = $"<------------------ DATA {Id} ------------------->" +
                          $"Dia/Mês/Ano: { Data.ToString("dd/MM/yyyy")}";
        return detalhes;
    }
}