-- Criar a tabela Usuarios
CREATE TABLE Usuarios (
    Id_Usuario INT PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,

);

-- Criar a tabela Carteiras
CREATE TABLE Carteiras (
    Id_Carteira INT PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Saldo DECIMAL(18, 2) NOT NULL,


    -- Chave estrangeira para a tabela Usuarios
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario)
);

-- Criar a tabela Moedas
CREATE TABLE Moedas (
    Id_Moeda INT PRIMARY KEY,
    Nome NVARCHAR(50) NOT NULL,

);

-- Criar a tabela Ofertas
CREATE TABLE Ofertas (
    Id INT PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Carteira INT NOT NULL,
    Id_Moeda INT NOT NULL,
    Preco DECIMAL(18, 2) NOT NULL,
    Quantidade INT NOT NULL,
    Data_Criacao DATETIME NOT NULL, 
    Deletado BIT NOT NULL DEFAULT 0, 


    -- Chave estrangeira para a tabela Usuarios
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id_Usuario),

    -- Chave estrangeira para a tabela Carteiras
    FOREIGN KEY (Id_Carteira) REFERENCES Carteiras(Id_Carteira),

    -- Chave estrangeira para a tabela Moedas
    FOREIGN KEY (Id_Moeda) REFERENCES Moedas(Id_Moeda)
);


-- Inserir dados na tabela Usuarios
INSERT INTO Usuarios (Id_Usuario, Nome)
VALUES
    (1, 'João'),
    (2, 'Maria'),
    (3, 'Pedro');

-- Inserir dados na tabela Carteiras
INSERT INTO Carteiras (Id_Carteira, Id_Usuario, Saldo)
VALUES
    (1, 1, 1000.00),
    (2, 1, 500.00),
    (3, 2, 1500.00),
    (4, 3, 200.00);

-- Inserir dados na tabela Moedas
INSERT INTO Moedas (Id_Moeda, Nome)
VALUES
    (1, 'Bitcoin'),
    (2, 'Ethereum'),
    (3, 'Litecoin'),
    (4, 'Ripple');

-- Inserir dados na tabela Ofertas
INSERT INTO Ofertas (Id, Id_Usuario, Id_Carteira, Id_Moeda, Preco, Quantidade, Data_Criacao, Deletado)
VALUES
    (1, 1, 1, 1, 50000.00, 2, '2023-08-02 10:00:00', 0),
    (2, 1, 2, 2, 3000.00, 5, '2023-08-02 11:30:00', 0),
    (3, 2, 3, 1, 48000.00, 1, '2023-08-02 12:15:00', 0),
    (4, 3, 4, 3, 150.00, 10, '2023-08-02 13:00:00', 0),
    (5, 3, 4, 4, 0.80, 100, '2023-08-02 14:30:00', 0);

