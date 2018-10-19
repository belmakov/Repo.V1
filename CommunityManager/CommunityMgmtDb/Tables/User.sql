CREATE TABLE [dbo].[User]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [UserName] NVARCHAR(100) NOT NULL, 
    [ContactId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_User_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_User_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_User_ToContact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([_Id])
)
