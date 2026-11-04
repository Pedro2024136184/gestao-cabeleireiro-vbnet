-- =====================================================================
-- Script de Criação e Povoamento da Base de Dados BDcabeleireiro
-- Unidade Curricular: Linguagens de Programação (LP) - Ano 2023
-- Autor: Pedro Costa (2024136184)
-- =====================================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BDcabeleireiro')
BEGIN
    CREATE DATABASE BDcabeleireiro;
END
GO

USE BDcabeleireiro;
GO

-- 1. Tabela: Areas de Intervenção
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Area')
BEGIN
    CREATE TABLE Area (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(50) NOT NULL,
        Descricao NVARCHAR(200) NULL
    );
END
GO

-- 2. Tabela: Categorias de Produtos/Serviços
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categorias')
BEGIN
    CREATE TABLE Categorias (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(50) NOT NULL,
        Descricao NVARCHAR(200) NULL
    );
END
GO

-- 3. Tabela: Clientes
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clientes')
BEGIN
    CREATE TABLE Clientes (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Nif NVARCHAR(9) NULL,
        Email NVARCHAR(100) NULL,
        Telefone NVARCHAR(15) NULL,
        Endereco NVARCHAR(200) NULL,
        Codigo_postal NVARCHAR(10) NULL,
        Sexo CHAR(1) CHECK (Sexo IN ('M', 'F'))
    );
END
GO

-- 4. Tabela: Fornecedores
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Fornecedores')
BEGIN
    CREATE TABLE Fornecedores (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Contacto NVARCHAR(50) NULL,
        Email NVARCHAR(100) NULL,
        Telefone NVARCHAR(15) NULL,
        Nif NVARCHAR(9) NULL,
        Endereco NVARCHAR(200) NULL
    );
END
GO

-- 5. Tabela: Funcionários / Utilizadores
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Funcionarios')
BEGIN
    CREATE TABLE Funcionarios (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(100) NOT NULL,
        Nivel INT NOT NULL DEFAULT 1, -- 1: Normal, 2: Administrador
        Telefone NVARCHAR(15) NULL,
        Email NVARCHAR(100) NULL,
        Cargo NVARCHAR(50) NULL
    );
END
GO

-- 6. Tabela: Serviços
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Servicos')
BEGIN
    CREATE TABLE Servicos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Preco DECIMAL(10,2) NOT NULL,
        Duracao_min INT DEFAULT 30,
        Descricao NVARCHAR(200) NULL
    );
END
GO

-- 7. Tabela: Produtos
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Produtos')
BEGIN
    CREATE TABLE Produtos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(100) NOT NULL,
        Preco DECIMAL(10,2) NOT NULL,
        Stock INT DEFAULT 0,
        Id_categoria INT FOREIGN KEY REFERENCES Categorias(Id),
        Id_fornecedor INT FOREIGN KEY REFERENCES Fornecedores(Id)
    );
END
GO

-- 8. Tabela: Agendamentos de Serviços (Marcações)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Agendamentos')
BEGIN
    CREATE TABLE Agendamentos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Id_cliente INT NOT NULL FOREIGN KEY REFERENCES Clientes(Id),
        Id_servico INT NOT NULL FOREIGN KEY REFERENCES Servicos(Id),
        Id_funcionario INT NULL FOREIGN KEY REFERENCES Funcionarios(Id),
        Data_Hora DATETIME NOT NULL,
        Observacoes NVARCHAR(250) NULL,
        Estado NVARCHAR(20) DEFAULT 'Agendado'
    );
END
GO

-- Povoamento de Dados Iniciais (Seed Data)
IF NOT EXISTS (SELECT * FROM Funcionarios WHERE Username = 'admin')
BEGIN
    INSERT INTO Funcionarios (Nome, Username, Password, Nivel, Telefone, Email, Cargo)
    VALUES ('Administrador Geral', 'admin', 'admin123', 2, '912345678', 'admin@salao.pt', 'Gerente');
END

IF NOT EXISTS (SELECT * FROM Categorias WHERE Nome = 'Capilar')
BEGIN
    INSERT INTO Categorias (Nome, Descricao) VALUES 
    ('Capilar', 'Tratamentos de cabelo e couro cabeludo'),
    ('Coloração', 'Tintas, descolorações e reflexos'),
    ('Estética', 'Manicure, pedicure e depilação');
END

IF NOT EXISTS (SELECT * FROM Servicos WHERE Nome = 'Corte Cabelo Masculino')
BEGIN
    INSERT INTO Servicos (Nome, Preco, Duracao_min, Descricao) VALUES
    ('Corte Cabelo Masculino', 12.50, 30, 'Corte clássico ou degradê com lavagem'),
    ('Corte Cabelo Feminino', 22.00, 45, 'Corte estilizado com lavagem e secagem'),
    ('Coloração Completa', 35.00, 90, 'Aplicação de cor e hidratação profunda'),
    ('Barba Tradicional', 8.00, 20, 'Navalha e toalha quente');
END
GO
