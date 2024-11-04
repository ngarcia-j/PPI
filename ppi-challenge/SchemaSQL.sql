CREATE DATABASE ppi_challenge;
GO

USE ppi_challenge;
GO

CREATE TABLE Activos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    PrecioBase DECIMAL(18,2)
);

CREATE TABLE Cuentas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Saldo DECIMAL(18,2)
);

CREATE TABLE Estados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DescripcionEstado VARCHAR(50) NOT NULL
);

CREATE TABLE Ordenes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCuenta INT FOREIGN KEY REFERENCES Cuentas(Id),
    FechaAlta DATETIME NOT NULL DEFAULT GETDATE(),
    IdActivo INT FOREIGN KEY REFERENCES Activos(Id),
    Cantidad INT,
    Precio DECIMAL(18,2),
    MontoTotal DECIMAL(18,2),
    IdEstado INT FOREIGN KEY REFERENCES Estados(Id)
);








