CREATE TABLE [dbo].Quests
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [EstimatedCompletionTime] INT NULL, 
    [Completed] BIT NULL
)
