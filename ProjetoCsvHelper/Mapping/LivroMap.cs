using System.Globalization;
using CsvHelper.Configuration;
public class LivroMap : ClassMap<Livro>
{
    public LivroMap()
    {
        Map(x=> x.Titulo)
            .Validate(field=> field.ToString()?.Length < 10)
            .Name("titulo");
        Map(x=> x.Preco)
            .Name("preço")
            .TypeConverterOption
            .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
        Map(x=> x.Autor).Name("autor");
        Map(x=> x.Lancamento)
            .Name("lançamento")
            .TypeConverterOption
            .Format(new [] {"dd/MM/yyyy"});
    
    }

}
