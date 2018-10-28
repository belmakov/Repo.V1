CREATE TABLE [dbo].[Unit]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [Identifier] NVARCHAR(50) NOT NULL, 
    [BlockId] UNIQUEIDENTIFIER NOT NULL, 
    [OwnerId] UNIQUEIDENTIFIER NOT NULL, 
    [MaintainenceFeePaid] BIT NOT NULL, 
    CONSTRAINT [FK_Unit_ToBlock] FOREIGN KEY ([BlockId]) REFERENCES [Block]([_Id]), 
    CONSTRAINT [FK_Unit_ToOwner] FOREIGN KEY ([OwnerId]) REFERENCES [Contact]([_Id]), 
    CONSTRAINT [FK_Unit_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Unit_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
