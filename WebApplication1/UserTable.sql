CREATE TABLE [dbo].[User]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
	[Email] NVARCHAR(50) NOT NULL,
    [SubscribedDate] DATETIME2 NOT NULL
)

INSERT INTO [dbo].[User]
SELECT 1,'Victor Scheidecker','chefard59@hotmail.com', GETDATE()

SELECT * FROM dbo.[User]

CREATE TABLE [dbo].[Bar]
(
	[BarID] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
	[Address] NVARCHAR(200) NOT NULL,
	[LogoPath] NVARCHAR(200) NULL,
	[Hours] NVARCHAR(200) NULL,
)

INSERT INTO dbo.[Bar]
SELECT 1,'Point Bar','600, Bloor Street West, Toronto, ON, M6G 1K4', NULL, NULL

