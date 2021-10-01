CREATE PROCEDURE [dbo].[QuestCreate]
	@name varchar(max),
	@description varchar(max) = null,
	@estimatedCompletionTime int = 0,
	@completed bit = 1

AS
	INSERT INTO Quests(Name, Description, EstimatedCompletionTime, Completed)
	VALUES(@name,@description, @estimatedCompletionTime, @completed)
