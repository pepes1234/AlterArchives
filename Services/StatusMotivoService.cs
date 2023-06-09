public class StatusMotivoService
{
    public static List<StatusMotivo> lerDadosStatusMotivo(string caminhoArquivo)
    {
        List<StatusMotivo> statusMotivos = new List<StatusMotivo>();
        
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
                            
                            StatusMotivo stsMot = new StatusMotivo
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            statusMotivos.Add(stsMot);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return statusMotivos;
    }
}