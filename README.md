<!-- Badges -->
<p align="center">
  <img src="https://img.shields.io/badge/.NET-7.0-blue" alt=".NET 7.0" />
  <img src="https://img.shields.io/badge/C%23-10-informational" alt="C#" />
  <img src="https://img.shields.io/badge/EPPlus-5.8.0-lightgrey" alt="EPPlus" />
  <img src="https://img.shields.io/badge/Windows%20Forms-UI-success" alt="Windows Forms" />
  <img src="https://img.shields.io/badge/License-MIT-brightgreen" alt="License" />
</p>

## ✨ Alterador de arquivos

**AlterArchives** é um conector de sistemas,desenvolvido em C# e Windows Forms .NET 7. Funcionalidade de transferencia de dados que não conversam via API: A partir um Excel, aplica transformações/mapeamentos e obtém um Excel pronto para o sistema destino.

---

## 🚀 Funcionalidades Principais

- 📥 **Importação de Excel**: lê a primeira planilha de arquivos `.xlsx`.
- 🔄 **Transformação de Dados**: formata colunas, datas e aplica regras de negócio (flags, concatenações).
- 📂 **Mapeamento**: usa arquivos `.txt` na pasta `data/` para converter descrições em IDs.
- 💾 **Geração de Excel**: cria `.xlsx` com cabeçalhos padronizados para o sistema destino.
- 🛠️ **Interface Intuitiva**: selecione origem, nome do arquivo e cole corretores.
- 🐞 **Tratamento de Erros**: mensagens de sucesso ❇️ ou falha ❌ durante o processo.

---

## ⚙️ Tecnologias

| Ferramenta      | Versão          |
|-----------------|-----------------|
| .NET SDK        | 7.0             |
| C#              | 10              |
| Windows Forms   | WinForms        |
| EPPlus          | 5.8.0           |

---

## 📋 Pré-requisitos

1. 💻 Windows 10 ou superior
2. 🔧 [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
3. 📝 Visual Studio 2022 ou VS Code

---

## 🏗️ Instalação

```bash
# 1. Clone o repositório
$ git clone https://github.com/pepes1234/AlterArchives.git
$ cd AlterArchives

# 2. Restaure pacotes via .NET CLI
$ dotnet restore AlterArchives.sln
# Ou abra no Visual Studio e restaure NuGet
```

---

## 🔧 Configuração

1. Crie a pasta `data/` com os arquivos de mapeamento:
   - `Corretores.txt`, `Fonte.txt`, `Modalidade.txt`, `Produto.txt`, `Status.txt`, `StatusMotivo.txt`
2. Formato dos `.txt` (sem cabeçalho):
   ```txt
   <ID>;<Descrição>;<Ativo>
   ```
3. Excel de origem: mínimo 31 colunas na ordem esperada pela classe `Formulario`.

---

## ▶️ Uso

1. Execute `AlterArchives.exe` ou rode pelo Visual Studio.
2. Em **Nome do arquivo**, digite o nome desejado (sem `.xlsx`).
3. Cole as descrições de corretores em **Nomes** e clique em **Abrir arquivo**.
4. Selecione o Excel de origem.
5. Aguarde a mensagem **Sucesso!** e encontre o arquivo gerado na raiz.

---

## 📁 Estrutura do Projeto

```
AlterArchives/
├── data/                   # Arquivos de mapeamento (.txt)
├── Model/                  # Entidades (Formulario, Corretores, ...)
├── Services/               # Leitura e lógica de mapeamento (.txt)
├── Form1.cs                # Lógica do Windows Form
├── Form1.Designer.cs       # Layout do formulário
├── Program.cs              # Ponto de entrada
└── AlterArchives.sln       # Solução
```

---
