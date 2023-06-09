public class FonteService
{
    public static List<Fonte> lerDadosFonte(string caminhoArquivo)
    {
        List<Fonte> fontes = new List<Fonte>();
        
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
                        if (int.TryParse(partes[1].Trim(), out id))
                        {
                            string descricao = partes[0].Trim();
                            
                            Fonte fonte = new Fonte
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            fontes.Add(fonte);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return fontes;
    }
}