// CriarDiretoriosGlobo();
// CriarArquivo();
// var origem = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
// var destino = Path.Combine(Environment.CurrentDirectory,
//                                 "globo",
//                                 "América do Sul",
//                                 "Argentina",
//                                 "argentina.txt");
//MoverArquivo(origem, destino);
// CopiarArquivo(origem,destino);

var path = Path.Combine(Environment.CurrentDirectory,"globo");
//LerDiretorios(path);




static void LerDiretorios(string path)
{
   var diretorios = Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
   foreach (var diretorio in diretorios)
   {
       var dirInfo = new DirectoryInfo(diretorio);
       Console.WriteLine($"[Nome]:{dirInfo.Name}");
       Console.WriteLine($"[Raiz]:{dirInfo.Root}");
       if(dirInfo.Parent != null)
        Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");

        Console.WriteLine("---------------------");

   }
}


static void CopiarArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem não existe");
        return;
    }
    if (File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }
    File.Copy(pathOrigem,pathDestino);
}
static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem não existe");
        return;
    }
    if (File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo já existe na pasta de destino");
        return;
    }


    File.Move(pathOrigem, pathDestino);
}
static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brasil.txt");
    if (!File.Exists(path))
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("População: 213MM");
        sw.WriteLine("IDH: 0,901");
        sw.WriteLine("Dados atualizados em: 20/04/2018");
    }

}
static void CriarDiretoriosGlobo()
{

    var path = Path.Combine(Environment.CurrentDirectory, "globo");
    if (!Directory.Exists(path))
    {
        var dirGlogo = Directory.CreateDirectory(path);
        var dirAmNorte = dirGlogo.CreateSubdirectory("América do Norte");
        var dirAmCentral = dirGlogo.CreateSubdirectory("América Central");
        var dirAmSul = dirGlogo.CreateSubdirectory("América do Sul");

        dirAmNorte.CreateSubdirectory("USA");
        dirAmNorte.CreateSubdirectory("Mexico");
        dirAmNorte.CreateSubdirectory("Canada");

        dirAmCentral.CreateSubdirectory("Costa Rica");
        dirAmCentral.CreateSubdirectory("Panama");

        dirAmSul.CreateSubdirectory("Brasil");
        dirAmSul.CreateSubdirectory("Argentina");
        dirAmSul.CreateSubdirectory("Paraguai");
    }
}






