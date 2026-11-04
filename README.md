# Sistema de Gestão de Salão de Cabeleireiro - VB.NET Windows Forms (2023)

![VB.NET](https://img.shields.io/badge/VB.NET-.NET_Framework_4.5-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/GUI-Windows_Forms-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![SQL Server](https://img.shields.io/badge/Database-LocalDB_/_MSSQL-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Visual Studio](https://img.shields.io/badge/IDE-Visual_Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Status](https://img.shields.io/badge/Versão-Melhorada-success?style=for-the-badge)

---

## 📌 Enquadramento Académico
* **Cadeira:** Linguagens de Programação (LP)
* **Ano Letivo / Realização:** 2023
* **Tecnologia Principal:** Visual Basic .NET (VB.NET) / ADO.NET / SQL Server
* **Arquitetura:** MDI (Multiple Document Interface) Desktop Windows Forms

---

## 💇 Descrição do Sistema
Aplicação desktop completa desenvolvida em **Visual Basic .NET (VB.NET)** com interface gráfica em **Windows Forms**, concebida para a gestão integrada e agendamento de atendimentos num salão de cabeleireiro e estética.

### Módulos Funcionais:
1. **Gestão de Clientes e Ficha Pessoal:** Registo de clientes com validação de formato de dados (Nome, NIF, E-mail, Contacto telefónico, Morada, Código Postal e Sexo).
2. **Gestão de Funcionários e Acessos:** Controlo de operadores com níveis de privilégio (Operador vs. Administrador).
3. **Agendamento de Serviços:** Marcação de horários associando cliente, funcionário e serviço a prestar, calculando tempos e valores.
4. **Catálogo de Serviços e Áreas:** Gestão de preços, durações e tipologias de cuidados capilares e estética.
5. **Gestão de Stock e Fornecedores:** Controlo de produtos cosméticos, quantidades disponíveis em stock e dados de fornecedores parceiros.

---

## 🚀 Comparação de Versões: Original vs. Versão Melhorada

| Componente / Mecanismo | Versão Original (Ramo `main`) | Versão Melhorada (Ramo `versao-melhorada`) |
| :--- | :--- | :--- |
| **String de Ligação à BD (*Connection String*)** | Caminho absoluto fixado no código (*hardcoded*): `"C:\Users\Mattson\Desktop\PROJETO LP\BDcabeleireiro.mdf"`. Qualquer tentativa de executar noutra máquina falhava com erro de ficheiro não encontrado. | **Propriedade Dinâmica e Resiliente (`Module1.vb`)**: Resolve o caminho do ficheiro `.mdf` relativamente ao diretório do executável (`AppDomain.CurrentDomain.BaseDirectory` / `|DataDirectory|`), permitindo execução imediata e portabilidade em qualquer computador. |
| **Ficheiro de Configuração (`App.config`)** | Apontava igualmente para a diretoria local fixa do utilizador. | Atualizado para usar a macro `|DataDirectory|\BDcabeleireiro.mdf` padronizada pelo ecossistema .NET. |
| **Script de Povoamento e DDL de Base de Dados** | Inexistente no repositório; o projeto dependia de ficheiro binário local externo não versionado. | Criado **`schema_database.sql` completo**, permitindo criar instantaneamente todas as tabelas, chaves primárias, relacionamentos de chave forasteira e dados de teste (*seed data* com utilizador `admin`). |
| **Segurança e Consultas SQL** | Concatenação direta de strings com substituições rudimentares de aspas (`Replace(..., "'", "´")`). | Documentação das melhores práticas para migração para **Consultas Parametrizadas (`SqlCommand.Parameters`)**, eliminando riscos de SQL Injection. |

---

## 📂 Estrutura de Ficheiros

```text
gestao-cabeleireiro-vbnet/
├── Project_Cabeleireiro.sln      # Solução principal do Visual Studio
├── schema_database.sql           # Script SQL para criação de tabelas e dados iniciais
├── README.md                     # Documentação completa do projeto
└── Project_Cabeleireiro/         # Código-fonte da aplicação Windows Forms
    ├── App.config                # Configuração de ligação à BD portável
    ├── Module1.vb                # Variáveis globais e connection string dinâmica
    ├── MDIParent2.vb             # Formulário contentor MDI principal
    ├── agendarservico.vb         # Formulário de marcação de atendimentos
    ├── inserircliente.vb         # Registo de clientes
    ├── inserirfuncionario.vb     # Registo de funcionários
    ├── inserirservico.vb         # Registo de serviços
    └── ...                       # Formulários de listagem, atualização e remoção
```

---

## 💻 Como Configurar e Executar

1. **Clonar e aceder ao repositório:**
   ```cmd
   git clone https://github.com/Pedro2024136184/gestao-cabeleireiro-vbnet.git
   cd gestao-cabeleireiro-vbnet
   ```

2. **Alternar entre as versões:**
   * Para a versão original:
     ```cmd
     git checkout main
     ```
   * Para a versão melhorada:
     ```cmd
     git checkout versao-melhorada
     ```

3. **Configurar a Base de Dados:**
   * Abra o SQL Server Management Studio (SSMS) ou a janela *SQL Server Object Explorer* no Visual Studio.
   * Execute o script `schema_database.sql` para criar a base de dados `BDcabeleireiro`.

4. **Compilar e Executar:**
   * Abra `Project_Cabeleireiro.sln` no Visual Studio 2019/2022.
   * Prima **F5** para compilar e iniciar a aplicação.
   * **Credenciais de teste predefinidas:**
     * Utilizador: `admin`
     * Palavra-passe: `admin123`

---

## 👨‍💻 Autor
* **Pedro Costa** (Nº 2024136184) – Licenciatura em Engenharia Informática, ISEC.
