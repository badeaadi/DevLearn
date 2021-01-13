CREATE TABLE [dbo].[Item]
(
	[IdItem] INT NOT NULL PRIMARY KEY,
	[ItemInformation] VARCHAR(50) NOT NULL, 
    [Variants] NCHAR(10) NULL, 
    [RightVariant] INT NULL 

)
