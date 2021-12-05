using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using CsvHelper.TypeConversion;

//LerCSVComDynamic();
//LerCsvComClasse();
//LerCsvComOutroDelimitador();
EscreverCsv();

Console.WriteLine("Digite [enter] para finalizar");
Console.ReadLine();

static void EscreverCsv()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Saida");
    
    var di = new DirectoryInfo(path);

    if(!di.Exists)
        di.Create();
    
    path = Path.Combine(path,"usuarios.csv");

    var pessoas = new List<Pessoa>()
    {
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 456789,
        },
        new Pessoa()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 123456,
        },
        new Pessoa()
        {
            Nome = "Carla Moraes",
            Email = "cms@gmail.com",
            Telefone = 9987411,

        },
    };

    using var sr = new StreamWriter(path);
    var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
    {
        Delimiter = "|"
    };
    using var csvWriter = new CsvWriter(sr,csvConfig);
    csvWriter.WriteRecords(pessoas);

}
static void LerCsvComOutroDelimitador()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "Livros-preco-com-virgula.csv");
    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O aruivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };

    using var csvReader = new CsvReader(sr, csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();
    var registros = csvReader.GetRecords<Livro>().ToList();

    foreach (var registro in registros)
    {
        Console.WriteLine($"Título:{registro.Titulo}");
        Console.WriteLine($"Preço:{registro.Preco}");
        Console.WriteLine($"Autor:{registro.Autor}");
        Console.WriteLine($"Lançamento:{registro.Lancamento}");
        Console.WriteLine("--------");
    }
}
static void LerCsvComClasse()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "novos-usuarios.csv");
    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O aruivo {path} não existe!");
    
    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);
    
    var registros = csvReader.GetRecords<Usuario>().ToList();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome:{registro.Nome}");
        Console.WriteLine($"email:{registro.Email}");
        Console.WriteLine($"telefone:{registro.Telefone}");
        Console.WriteLine("--------");
    }
}
static void LerCSVComDynamic()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "Produtos.csv");

    var fi = new FileInfo(path);

    if (!fi.Exists)
        throw new FileNotFoundException($"O aruivo {path} não existe!");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr, csvConfig);
 
    var registros = csvReader.GetRecords<dynamic>();

    foreach (var registro in registros)
    {
        Console.WriteLine($"nome:{registro.produto}");
        Console.WriteLine($"marca:{registro.Marca}");
        Console.WriteLine($"preço:{registro.Preco}");
        Console.WriteLine("--------");
    }
}
