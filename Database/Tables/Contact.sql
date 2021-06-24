CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LastName] NVARCHAR(75) NOT NULL, 
    [FirstName] NVARCHAR(75) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Contact_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [FK_Contact_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
