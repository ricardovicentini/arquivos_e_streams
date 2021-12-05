string textReaderText = "TextReader é a classe base abstrata " +
              "de StreamReader e StringReader, que lê caracteres " +
              "de streams e strings, respectivamente.\n\n" +

              "Crie uma instância de TextReader para abrir um arquivo de texto " +
              "para ler um intervalo especificado de caracteres " +
              "ou para criar um leitor baseado em um fluxo existente.\n\n" +

              "Você também pode usar uma instância de TextReader para ler " +
              "texto de um armazenamento de suporte personalizado usando as mesmas " +
              "APIs que você usaria para uma string ou um fluxo.\n\n";

Console.WriteLine($"Texto original: {textReaderText}");

string linha, paragrafo = null;
var sr = new StringReader(textReaderText);
while(true)
{
    linha = sr.ReadLine();
    if(linha != null)
    {
        paragrafo +=  linha + " ";
    }
    else
    {
        paragrafo += '\n';
        break;
    }
}

Console.WriteLine($"Texto modificado: {paragrafo}");
int caractereLido;
char caracterConvertido;

var sw = new StringWriter();
sr = new StringReader(paragrafo);

while(true)
{
    caractereLido = sr.Read();
    if(caractereLido == -1) break;

    caracterConvertido = Convert.ToChar(caractereLido);

    if(caracterConvertido == '.')
    {
        sw.Write("\n\n");

        sr.Read();
        sr.Read();
    }
    else
    {
        sw.Write(caracterConvertido);
    }
    
    
}

Console.WriteLine($"Texto armazenado no StringWriter: {sw.ToString()}");
Console.WriteLine("\n\nDigite [enter] para finalizar...");
Console.ReadLine();