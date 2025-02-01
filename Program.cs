class Program 
{
    static void Main()
    {
        Console.WriteLine("Digite o caminho da pasta para ser organizada: ");
        string caminhoDaPasta = Console.ReadLine();
        string pastaOrganizada = Path.Combine(caminhoDaPasta, "Arquivos Organizados");
        string[] arquivos = Directory.GetFiles(caminhoDaPasta).ToArray();
        MoverArquivos(pastaOrganizada, arquivos);
    }

    static void MoverArquivos(string caminhoDaPastaOrganizada, string[] arquivos)
    {
        foreach (string arquivo in arquivos)
        {
            var extensao = Path.GetExtension(arquivo).ToLower();
            var nomeArquivo = Path.GetFileName(arquivo);
            string pastaDestino = Path.Combine(caminhoDaPastaOrganizada, extensao);

            if (!Path.Exists(pastaDestino))
                Directory.CreateDirectory(pastaDestino);

            try
            {
                File.Move(arquivo, Path.Combine(pastaDestino, nomeArquivo + extensao));
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Não foi possível mover o arquivo {nomeArquivo}");
                Console.ReadLine();
            }

        }
    }
}