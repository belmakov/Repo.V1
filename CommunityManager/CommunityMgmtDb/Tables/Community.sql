CREATE TABLE [dbo].[Community]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [LocationId] UNIQUEIDENTIFIER NOT NULL, 
    [SubAreaId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Community_ToLocation] FOREIGN KEY ([LocationId]) REFERENCES [Location]([_Id]), 
    CONSTRAINT [FK_Community_ToSubArea] FOREIGN KEY ([SubAreaId]) REFERENCES [SubArea]([_Id]), 
    CONSTRAINT [FK_Community_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Community_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
