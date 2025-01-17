CREATE TABLE dbo.ClassRoom (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(255) NOT NULL,
    UpdatedBy NVARCHAR(255) NOT NULL
);