CREATE TABLE [dbo].[Table]
(
	[KullanıcıAdi] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Sifre] VARCHAR(50) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [Admin] BIT NOT NULL, 
    [Led] BIT NOT NULL, 
    [RadyoIzmir] BIT NOT NULL, 
    [Muhasebe] BIT NOT NULL, 
    [Reji] BIT NOT NULL
)
