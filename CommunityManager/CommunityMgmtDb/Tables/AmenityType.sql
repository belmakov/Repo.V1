CREATE TABLE [dbo].[AmenityType]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Code] NCHAR(25) NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL, 
    CONSTRAINT [FK_AmenityType_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_AmenityType_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
