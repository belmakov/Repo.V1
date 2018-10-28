CREATE TABLE [dbo].[Block]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [CommunityId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Block_ToCommunity] FOREIGN KEY ([CommunityId]) REFERENCES [Community]([_Id]), 
    CONSTRAINT [FK_Block_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Block_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
