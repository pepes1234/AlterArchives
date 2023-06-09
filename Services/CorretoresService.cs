public class CorretorService
{
    public static List<Corretores> lerDadosCorretor(string caminhoArquivo)
    {
        List<Corretores> corretores = new List<Corretores>();
        
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
                            string descricao = partes[1].Trim();
                            
                            Corretores corretor = new Corretores
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            corretores.Add(corretor);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return corretores;
    }
}