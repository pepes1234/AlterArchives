public class ModalidadeService
{
    public static List<Modalidade> lerDadosModalidade(string caminhoArquivo)
    {
        List<Modalidade> modalidades = new List<Modalidade>();
        
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
                            
                            Modalidade modalidade = new Modalidade
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            modalidades.Add(modalidade);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return modalidades;
    }
}