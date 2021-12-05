// CriarArquivo();
// InserirMaisTexto();
LerArquivo();

static void LerArquivo()
{
    using var sr = new StreamReader("MeuArquivo.txt");
    var conteudo = sr.ReadToEnd();
    Console.Write(conteudo);
    Console.WriteLine("\n\nPressione [enter] para finalizar");
    Console.ReadLine();
}

static void InserirMaisTexto()
{
    string textReaderTexto = "Um novo paragrafo....\n\n";

    using var sw = new StreamWriter("MeuArquivo.txt",true);
    sw.Write(textReaderTexto);
}

static void CriarArquivo()
{
    string textReaderTexto = "TextReader é a classe base abstrata " +
              "de StreamReader e StringReader, que lê caracteres " +
              "de streams e strings, respectivamente.\n\n" +

              "Crie uma instância de TextReader para abrir um arquivo de texto " +
              "para ler um intervalo especificado de caracteres " +
              "ou para criar um leitor baseado em um fluxo existente.\n\n" +

              "Você também pode usar uma instância de TextReader para ler " +
              "texto de um armazenamento de suporte personalizado usando as mesmas " +
              "APIs que você usaria para uma string ou um fluxo.\n\n";

    using var sw = new StreamWriter("MeuArquivo.txt");
    sw.Write(textReaderTexto);
}
