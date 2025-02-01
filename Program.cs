class Program 
{
    static void Main()
    {
        Console.WriteLine("Digite o caminho da pasta para ser organizada: ");
        string caminhoDaPasta = PegarCaminhoDaPasta();
        string pastaOrganizada = Path.Combine(caminhoDaPasta, "Arquivos Organizados");

        string[] arquivos = Directory.GetFiles(caminhoDaPasta);

        
        LoopPrincipal(pastaOrganizada, arquivos);
    }


    static void LoopPrincipal(string caminhoDaPastaOrganizada, string[] arquivos)
    {
        foreach (string arquivo in arquivos)
        {
            var extensao = Path.GetExtension(arquivo).ToLower();
            var nomeArquivo = Path.GetFileName(arquivo);
            string pastaDestino = Path.Combine(caminhoDaPastaOrganizada, extensao);

            VerificarPastaExiste(pastaDestino);

            MoverArquivos(arquivo, pastaDestino, nomeArquivo, extensao);

        }
    }


    static string PegarCaminhoDaPasta()
    {
        string caminho = Console.ReadLine();

        while (!Directory.Exists(caminho)) 
        {
            Console.WriteLine("A pasta não existe." + Environment.NewLine + "Digite novamente:");
            caminho = Console.ReadLine();
        }

        return caminho;
    }


    static void VerificarPastaExiste(string caminhoDaPasta)
    {
        if (!Directory.Exists(caminhoDaPasta))
            Directory.CreateDirectory(caminhoDaPasta);
    }


    static void MoverArquivos(string arquivo, string pastaDestino, string nomeArquivo, string extensao)
    {
        string destino = Path.Combine(pastaDestino, nomeArquivo);
        string destinoFinal = VerificarArquivoExiste(destino, extensao);
        try
        {
            File.Move(arquivo, destinoFinal);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Não foi possível mover o arquivo {nomeArquivo}");
            Console.ReadLine();
        }
    }

    static string VerificarArquivoExiste(string destino, string extensao)
    {
        int i = 0;
        string novoNome = "";

        if (!File.Exists(destino))
        {
            return destino;
        }
        else
        {
            while (File.Exists(destino))
            {
                i++;
                novoNome = destino.TrimEnd(extensao.ToCharArray());
                destino = novoNome + $"({i})" + extensao;
            }
        }

        return destino;
    }

}