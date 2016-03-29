CREATE TABLE [dbo].[Speakers]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[Firstname] nvarchar(30) not null,
	[Lastname] nvarchar(50) not null,
	[Position] nvarchar(100) null,
	[Phone] nvarchar(50) null,
	[Email] nvarchar(100) null,
	[ImageUrl] nvarchar(max) not null,
	[QrCode] varbinary(max) null
)
