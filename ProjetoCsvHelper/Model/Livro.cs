using CsvHelper.Configuration.Attributes;
public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public decimal Preco { get; set; }
    public DateOnly Lancamento { get; set; }
}
