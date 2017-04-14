CREATE TABLE [dbo].[Table]
(
	[LivroId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LivroTitulo] NVARCHAR(150) NOT NULL, 
    [LivroAutor] NVARCHAR(150) NOT NULL, 
    [LivroEditora] NVARCHAR(150) NULL, 
    [LivroAno] INT NULL
)
