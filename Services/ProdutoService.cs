public class ProdutoService
{
    public static List<Produto> lerDadosProduto(string caminhoArquivo)
    {
        List<Produto> produtos = new List<Produto>();
        
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
                            
                            Produto produto = new Produto
                            {
                                Id = id,
                                Descricao = descricao
                            };
                            
                            produtos.Add(produto);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }
        
        return produtos;
    }
}