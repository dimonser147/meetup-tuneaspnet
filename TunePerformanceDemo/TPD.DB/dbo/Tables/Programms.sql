CREATE TABLE [dbo].[Programms]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1),
	[Title] nvarchar(100) not null,
	[BeginAt] datetime not null,
	[EndAt] datetime not null,
	constraint [CHK_END_LATER_THAN_BEGIN] check ([EndAt] > [BeginAt])
)
