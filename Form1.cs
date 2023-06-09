namespace AlterArchives;
using OfficeOpenXml;
using System.Linq;
using System.Globalization;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            openFileDialog1.ShowDialog();
            string dados = richTextBox1.Text;

            string caminhoArquivo = "data/Corretores.txt";

            using (StreamWriter arquivo = new StreamWriter(caminhoArquivo))
            {
                arquivo.Write(dados);
            }

            List<Formulario> excel = FinalExcel(ListExcel(openFileDialog1.FileName));
            
            FileInfo file = new FileInfo($@"C:\Users\Lucas\Documents\GitHub\AlterArchives\{textbox1.Text}.xlsx");

            if(File.Exists(file.ToString()))
                MessageBox.Show("Arquivo Existente", "Já existe um arquivo no caminho desejado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Formularios");
                
                worksheet.Cells[1, 1].Value = "active";
                worksheet.Cells[1, 2].Value = "age";
                worksheet.Cells[1, 3].Value = "city";
                worksheet.Cells[1, 4].Value = "client_email";
                worksheet.Cells[1, 5].Value = "client_name";
                worksheet.Cells[1, 6].Value = "comment";
                worksheet.Cells[1, 7].Value = "commercial_phone";
                worksheet.Cells[1, 8].Value = "created_at";
                worksheet.Cells[1, 9].Value = "life_amount";
                worksheet.Cells[1, 10].Value = "main_phone";
                worksheet.Cells[1, 11].Value = "mobile_phone";
                worksheet.Cells[1, 12].Value = "order_date";
                worksheet.Cells[1, 13].Value = "overdue";
                worksheet.Cells[1, 14].Value = "return_date";
                worksheet.Cells[1, 15].Value = "deny_id";
                worksheet.Cells[1, 16].Value = "modality_type";
                worksheet.Cells[1, 17].Value = "product_id";
                worksheet.Cells[1, 18].Value = "provider_id";
                worksheet.Cells[1, 19].Value = "status_id";
                worksheet.Cells[1, 20].Value = "user_id";
                worksheet.Cells[1, 21].Value = "sale_price";

                // Dados dos formulários
                for (int i = 0; i < excel.Count; i++)
                {
                    Formulario formulario = excel[i];
                    
                    worksheet.Cells[i + 2, 1].Value = "true";
                    worksheet.Cells[i + 2, 2].Value = formulario.Idade;
                    worksheet.Cells[i + 2, 3].Value = formulario.Cidade;
                    worksheet.Cells[i + 2, 4].Value = formulario.Email;
                    worksheet.Cells[i + 2, 5].Value = formulario.Nome;
                    worksheet.Cells[i + 2, 6].Value = formulario.Observacao;
                    worksheet.Cells[i + 2, 7].Value = formulario.Comercial;
                    worksheet.Cells[i + 2, 8].Value = formulario.Inclusao.ToString("MM/dd/yy HH:mm");
                    worksheet.Cells[i + 2, 9].Value = formulario.qtdVidas;
                    worksheet.Cells[i + 2, 10].Value = formulario.Principal; //wefpokogwpokgkPOEFEE olha isso
                    worksheet.Cells[i + 2, 11].Value = formulario.Celular;
                    worksheet.Cells[i + 2, 12].Value = formulario.Solicitacao.ToString("MM/dd/yy HH:mm");
                    worksheet.Cells[i + 2, 13].Value = (formulario.EmAtraso == "Não") ? "false" : "true";
                    worksheet.Cells[i + 2, 14].Value = formulario.Retorno.ToString("MM/dd/yy HH:mm");
                    worksheet.Cells[i + 2, 15].Value = formulario.StatusMotivo; //NTA CERTO PF N ENVIA
                    worksheet.Cells[i + 2, 16].Value = formulario.Modalidade;
                    worksheet.Cells[i + 2, 17].Value = formulario.Produto;
                    worksheet.Cells[i + 2, 18].Value = formulario.Fonte;
                    worksheet.Cells[i + 2, 19].Value = formulario.Status;
                    worksheet.Cells[i + 2, 20].Value = formulario.Corretor;
                    worksheet.Cells[i + 2, 21].Value = formulario.ValorPrevisto;
                }

                package.Save();
            }
            MessageBox.Show("Sucesso!", "Arquivo gerado com sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch(Exception ex)
        {
            MessageBox.Show("Erro" + ex, "Erro ao gerar arquivo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
    private List<Formulario> FinalExcel(List<Formulario> data)
    {
        List<string> modality = AlterModality(data);
        List<string> status = AlterStatus(data);
        List<string> statusMotivo = AlterStatusMotivo(data);
        List<string> produto = AlterProduto(data);
        List<string> fonte = AlterFonte(data);
        List<string> corretores = AlterCorretores(data);
        int counter = -1;
        foreach(var x in data)
        {
            counter ++;
            x.Modalidade = modality[counter];
            x.Status = status[counter];
            x.StatusMotivo = statusMotivo[counter];
            x.Produto = produto[counter];
            x.Fonte = fonte[counter];
            x.Corretor = corretores[counter];
            x.Observacao = x.Observacao + "---" + x.Codigo;
        }
        return data;
    }
    private List<string> AlterCorretores(List<Formulario> data)
    {
        var corretores = data.Select(f => f.Corretor).ToList();
        var filter = CorretorService.lerDadosCorretor("data//Corretores.txt");
        var counter = -1;
        var newList = data.Select(f => f.Corretor).ToList();

        foreach(var x in corretores)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }

    private List<string> AlterFonte(List<Formulario> data)
    {
        var fontes = data.Select(f => f.Fonte).ToList();
        var filter = FonteService.lerDadosFonte("data//Fonte.txt");
        var counter = -1;
        var newList = data.Select(f => f.Fonte).ToList();

        foreach(var x in fontes)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }
    private List<string> AlterProduto(List<Formulario> data)
    {
        var produtos = data.Select(f => f.Produto).ToList();
        var filter = StatusService.lerDadosStatus("data//Produto.txt");
        var counter = -1;
        var newList = data.Select(f => f.Produto).ToList();

        foreach(var x in produtos)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }
    private List<string> AlterStatusMotivo(List<Formulario> data)
    {
        var statusMotivo = data.Select(f => f.StatusMotivo).ToList();
        var filter = StatusService.lerDadosStatus("data//StatusMotivo.txt");
        var counter = -1;
        var newList = data.Select(f => f.StatusMotivo).ToList();

        foreach(var x in statusMotivo)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }

    private List<string> AlterStatus(List<Formulario> data)
    {
        var status = data.Select(f => f.Status).ToList();
        var filter = StatusService.lerDadosStatus("data//Status.txt");
        var counter = -1;
        var newList = data.Select(f => f.Status).ToList();

        foreach(var x in status)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }
    private List<string> AlterModality(List<Formulario> data)
    {
        var modality = data.Select(f => f.Modalidade).ToList();
        var filter = ModalidadeService.lerDadosModalidade("data//Modalidade.txt");
        var counter = -1;
        var newList = data.Select(f => f.Modalidade).ToList();

        foreach(var x in modality)
        {
            counter++;
            foreach(var y in filter)
            {
                if(x == y.Descricao)
                {
                    newList[counter] = y.Id.ToString();
                }
                else
                {
                    newList[counter] = "";
                }
            }
        }
        return newList;
    }
    private static List<Formulario> ListExcel(string path)
    {

        var response = new List<Formulario>();

        FileInfo existingFile = new FileInfo(path);
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using(ExcelPackage package = new ExcelPackage(existingFile))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            int colCount = worksheet.Dimension.End.Column;
            int rowCount = worksheet.Dimension.End.Row;

            for(int row = 2; row <= rowCount; row++)
            {
                var pessoa = new Formulario();
                
                pessoa.Codigo = Convert.ToString(worksheet.Cells[row, 1].Value) ?? string.Empty;
                pessoa.Nome = Convert.ToString(worksheet.Cells[row, 2].Value) ?? string.Empty;
                pessoa.Email = Convert.ToString(worksheet.Cells[row, 3].Value) ?? string.Empty;
                pessoa.Principal = Convert.ToString(worksheet.Cells[row, 4].Value) ?? string.Empty;
                pessoa.Celular = Convert.ToString(worksheet.Cells[row, 5].Value) ?? string.Empty;
                pessoa.Comercial = Convert.ToString(worksheet.Cells[row, 6].Value) ?? string.Empty;
                pessoa.Cidade = Convert.ToString(worksheet.Cells[row, 7].Value) ?? string.Empty;
                pessoa.Fonte = Convert.ToString(worksheet.Cells[row, 8].Value) ?? string.Empty;
                pessoa.Produto = Convert.ToString(worksheet.Cells[row, 9].Value) ?? string.Empty;
                pessoa.CodCorretor = Convert.ToString(worksheet.Cells[row, 10].Value) ?? string.Empty;
                pessoa.Corretor = Convert.ToString(worksheet.Cells[row, 11].Value) ?? string.Empty;
                pessoa.PlanoAnterior = Convert.ToString(worksheet.Cells[row, 12].Value) ?? string.Empty;
                pessoa.PeriodoPlano = Convert.ToString(worksheet.Cells[row, 13].Value) ?? string.Empty;
                pessoa.PreferenciaHospitalar = Convert.ToString(worksheet.Cells[row, 14].Value) ?? string.Empty;
                pessoa.UsuarioInclusao = Convert.ToString(worksheet.Cells[row, 15].Value) ?? string.Empty;
                pessoa.Proposta = Convert.ToString(worksheet.Cells[row, 16].Value) ?? string.Empty;
                pessoa.Observacao = Convert.ToString(worksheet.Cells[row, 17].Value) ?? string.Empty;
                pessoa.CEP = Convert.ToString(worksheet.Cells[row, 18].Value) ?? string.Empty;
                pessoa.Idade = Convert.ToString(worksheet.Cells[row, 19].Value) ?? string.Empty;
                pessoa.EmAtraso = Convert.ToString(worksheet.Cells[row, 20].Value) ?? string.Empty;
                pessoa.ValorPrevisto = Convert.ToString(worksheet.Cells[row, 21].Value) ?? string.Empty;
                pessoa.qtdVidas = Convert.ToString(worksheet.Cells[row, 22].Value) ?? string.Empty;
                pessoa.Inclusao = (System.DateTime)worksheet.Cells[row, 23].Value;
                pessoa.Solicitacao = (System.DateTime)worksheet.Cells[row, 24].Value;
                pessoa.Retorno =  (System.DateTime)worksheet.Cells[row, 25].Value;
                pessoa.Modalidade = Convert.ToString(worksheet.Cells[row, 26].Value) ?? string.Empty;
                pessoa.Status = Convert.ToString(worksheet.Cells[row, 27].Value) ?? string.Empty;
                pessoa.Origem = Convert.ToString(worksheet.Cells[row, 28].Value) ?? string.Empty;
                pessoa.Assistente = Convert.ToString(worksheet.Cells[row, 29].Value) ?? string.Empty;
                pessoa.codCliente = Convert.ToString(worksheet.Cells[row, 30].Value) ?? string.Empty;
                pessoa.StatusMotivo = Convert.ToString(worksheet.Cells[row, 31].Value) ?? string.Empty;

                response.Add(pessoa);
            }
            return response;
        }
    }
}
