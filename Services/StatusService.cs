public class StatusService
{
    public static List<Status> lerDadosStatus(string caminhoArquivo)
    {
        List<Status> status = new List<Status>();
        
        try
        {
            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] partes = linha.Split(';');
                    if (partes.Length >= 2)
                    {
                        int id;
                        if (int.TryParse(partes[0].Trim(), out id))
                        {
                            string descricao = partes[2].Trim();
                            
                            Status sts = new Status
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            status.Add(sts);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return status;
    }
}