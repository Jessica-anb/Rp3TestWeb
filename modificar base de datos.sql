USE [Rp3Test]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbLogin]') AND type in (N'U'))
DROP TABLE [dbo].[tbLogin]
GO

CREATE TABLE [dbo].[tbLogin](
	[IdLogin] [int] NOT NULL,
	[User] [varchar](100) NOT NULL,
	[Password] [varchar](8) NOT NULL,
	[Names] [varchar](300) NOT NULL,
	[Surnames] [varchar](300) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
	[DateUpdate] [datetime] NULL,
	[IdRol] [int] NULL,
 CONSTRAINT [PK_tbLogin] PRIMARY KEY CLUSTERED 
(
	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[tbLogin]
           ([IdLogin]
           ,[User]
	     ,[Password]
           ,[Names]
           ,[Surnames]
           ,[RegisterDate]
           ,[DateUpdate]
           ,[IdRol])
     VALUES
           (1
           ,'jnavarrete'
		   ,'12345678'
           ,'Jessica'
           ,'Navarrete'
           ,GETDATE()
           ,NULL
           ,NULL)
GO

INSERT INTO [dbo].[tbLogin]
           ([IdLogin]
           ,[User]
           ,[Password]
           ,[Names]
           ,[Surnames]
           ,[RegisterDate]
           ,[DateUpdate]
           ,[IdRol])
     VALUES
           (2
           ,'vmacias'
           ,'12345678'
           ,'Victor'
           ,'Macias'
           ,GETDATE()
           ,NULL
           ,NULL)
GO

ALTER TABLE [dbo].[tbTransaction]
ADD [IdLogin] INT;
GO

UPDATE [dbo].[tbTransaction] SET [IdLogin] = 1
GO

UPDATE [dbo].[tbTransaction] SET [IdLogin] = 2 WHERE TransactionId IN (5,6,7,8,9,10,20,21,22,23,24,29,30)
GO

ALTER TABLE [dbo].[tbTransaction]  WITH CHECK ADD  CONSTRAINT [FK_tbTransaction_tbLogin] FOREIGN KEY([IdLogin])
REFERENCES [dbo].[tbLogin] ([IdLogin])
GO

ALTER TABLE [dbo].[tbTransaction] CHECK CONSTRAINT [FK_tbTransaction_tbLogin]
GO

CREATE PROCEDURE [dbo].[spGetBalance]
	@IdLogin int
AS
BEGIN
	
	SELECT c.[Name] Category, SUM(CASE WHEN [TransactionTypeId] = 2 THEN [Amount] * -1 ELSE [Amount] END) Amount
	FROM [dbo].[tbTransaction] t
		INNER JOIN [dbo].[tbCategory] c ON (t.[CategoryId] = c.[CategoryId])
	WHERE [IdLogin] = @IdLogin
	GROUP BY c.[Name]
	ORDER BY Case when SUM(CASE WHEN [TransactionTypeId] = 2 THEN [Amount] * -1 ELSE [Amount] END) <0 then 1 else 0 end, Amount desc

END
GO

