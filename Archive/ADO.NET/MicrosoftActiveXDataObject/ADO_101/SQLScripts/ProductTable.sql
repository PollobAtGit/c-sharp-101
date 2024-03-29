/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [ProductId]
		, [ProductName]
		,[QuantityAvailable]
FROM [Inventory].[dbo].[Product];

ALTER TABLE [dbo].[Product] DROP CONSTRAINT PK__Product__B40CC6CDDCE8A02F;
ALTER TABLE [dbo].[Product] DROP COLUMN [ProductId];

-- Poi: Column order can't be changed using T-SQL but only using Management Studio
ALTER TABLE [dbo].[Product] ADD [ProductId] INT IDENTITY(1, 1) PRIMARY KEY;

--UPDATE [dbo].[Product] SET [QuantityAvailable] = 10
--DELETE FROM [dbo].[Product] WHERE [ProductId] = (SELECT MIN([ProductId]) FROM [dbo].[Product]);

SELECT MIN([ProductId]) FROM [dbo].[Product];

USE [Inventory]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 3/23/2017 10:23:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Product];
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nchar](100) NOT NULL,
	[QuantityAvailable] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)) ON [PRIMARY];


INSERT INTO [dbo].[Product] ([ProductName], [QuantityAvailable])
VALUES('IPhone', 10), ('IPad', 50), ('HP Laptop', 100);
