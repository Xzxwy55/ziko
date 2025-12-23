USE DB;

CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Code NVARCHAR(50) NOT NULL,
    ParentDepartmentId INT NULL
);

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50) NULL,
    Position NVARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    HireDate DATE NOT NULL,
    Phone NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL
);

CREATE TABLE EquipmentTypes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL
);

CREATE TABLE Equipment (
    Id INT PRIMARY KEY IDENTITY(1,1),
    InventoryNumber NVARCHAR(50) NOT NULL UNIQUE,
    Name NVARCHAR(200) NOT NULL,
    EquipmentTypeId INT NOT NULL,
    PurchaseDate DATE NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CurrentOwnerId INT NULL,
    Location NVARCHAR(200) NULL
);

CREATE TABLE EquipmentHistory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EquipmentId INT NOT NULL,
    FromEmployeeId INT NULL,
    ToEmployeeId INT NULL,
    TransferDate DATETIME NOT NULL,
    Reason NVARCHAR(500) NULL
);