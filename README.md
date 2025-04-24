## Descrição do Projeto

AlterArchives é uma aplicação desktop desenvolvida em C# utilizando Windows Forms e .NET 7. Seu principal objetivo é atuar como um conector entre dois sistemas que não possuem integração direta via API. A ferramenta extrai dados de um arquivo Excel de origem, aplica regras de transformação e mapeamento com base em arquivos de referência, e gera um novo arquivo Excel compatível com o sistema de destino.

## Sumário

- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

## Funcionalidades

- **Leitura de Excel de origem:** importa dados da primeira planilha de um arquivo `.xlsx`.
- **Transformação de dados:** converte colunas, formata datas e aplica lógica de negócio (ex.: cálculo de flags, concatenação de campos).
- **Mapeamento por referência:** substitui descrições por IDs usando arquivos de texto (`.txt`) na pasta `data/`.
- **Geração de Excel de destino:** cria um novo arquivo `.xlsx` com cabeçalhos padronizados e linhas de dados transformados.
- **Interface gráfica amigável:** permite ao usuário inserir o nome do arquivo de saída, colar lista de corretores e selecionar o Excel de origem.
- **Tratamento de erros:** exibe mensagens de sucesso ou falha durante o processo.

## Tecnologias Utilizadas

- [.NET 7.0 SDK](https://dotnet.microsoft.com)  
- C# 10  
- Windows Forms  
- [EPPlus](https://github.com/EPPlusSoftware/EPPlus) para manipulação de planilhas Excel

## Pré-requisitos

1. Sistema operacional Windows 10 ou superior
2. [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
3. Editor de código (Visual Studio 2022 ou Visual Studio Code)

## Instalação

```bash
# Clone este repositório
git clone https://github.com/pepes1234/AlterArchives.git
cd AlterArchives

# Abra a solução no Visual Studio e restaure os pacotes NuGet
# Ou, via .NET CLI:
dotnet restore AlterArchives.sln
```

## Configuração

1. **Pasta `data/`**: deve conter os arquivos de mapeamento:
   - `Corretores.txt`
   - `Fonte.txt`
   - `Modalidade.txt`
   - `Produto.txt`
   - `Status.txt`
   - `StatusMotivo.txt`

2. **Formato dos arquivos `.txt`** (sem cabeçalho): cada linha deve seguir o padrão:
   ```txt
   <ID>;<Descrição>;<Ativo>
   ```
   - **ID**: inteiro que identificará a entidade no sistema de destino
   - **Descrição**: texto usado no Excel de origem
   - **Ativo**: flag `true` ou `false` (atualmente ignorada pela aplicação)

3. **Planilha de origem**: deve ter no mínimo 31 colunas, na ordem esperada pela classe `Formulario`:
   1. Código
   2. Nome
   3. Email
   4. Principal
   5. Celular
   6. Comercial
   7. Cidade
   8. Fonte
   9. Produto
   10. CodCorretor
   11. Corretor
   12. PlanoAnterior
   13. PeriodoPlano
   14. PreferenciaHospitalar
   15. UsuarioInclusao
   16. Proposta
   17. Observacao
   18. CEP
   19. Idade
   20. EmAtraso
   21. ValorPrevisto
   22. qtdVidas
   23. Inclusao (DateTime)
   24. Solicitacao (DateTime)
   25. Retorno (DateTime)
   26. Modalidade
   27. Status
   28. Origem
   29. Assistente
   30. codCliente
   31. StatusMotivo

## Uso

1. Execute o aplicativo (`AlterArchives.exe`) ou rode pelo Visual Studio.
2. No campo **"Nome arquivo"**, digite o nome desejado para o arquivo de saída (sem extensão).
3. No campo **"Nomes"**, cole a lista de descrições de corretores (um por linha) e clique em **"Abrir arquivo"**.
4. Na janela de diálogo, selecione o arquivo Excel de origem.
5. Aguarde a mensagem de **Sucesso!** indicando que o arquivo foi gerado na raiz do projeto.

## Estrutura do Projeto

```
AlterArchives/
├── data/                   # Arquivos de mapeamento (.txt)
├── Model/                  # Entidades de domínio (classes)
│   ├── Formulario.cs
│   ├── Corretores.cs
│   └── ...
├── Services/               # Serviços de leitura dos .txt
│   ├── ModalidadeService.cs
│   └── ...
├── Form1.cs                # Lógica da interface gráfica
├── Form1.Designer.cs       # Layout do formulário
├── Program.cs              # Ponto de entrada
├── AlterArchives.sln       # Solução do Visual Studio
└── README.md               # Este arquivo
```

## Contribuindo

1. Faça um fork do repositório.  
2. Crie uma branch com a feature (`git checkout -b feature/nova-funcionalidade`).  
3. Faça commit de suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).  
4. Envie para o branch principal (`git push origin feature/nova-funcionalidade`).  
5. Abra um Pull Request explicando suas mudanças.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

