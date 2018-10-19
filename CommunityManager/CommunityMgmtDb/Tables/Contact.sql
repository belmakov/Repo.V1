CREATE TABLE [dbo].[Contact]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [MiddleName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Title] NVARCHAR(15) NOT NULL, 
    [LocationId] UNIQUEIDENTIFIER NOT NULL, 
    [ImageId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_Contact_ToLocation] FOREIGN KEY ([LocationId]) REFERENCES [Location]([_Id]), 
    CONSTRAINT [FK_Contact_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Contact_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Contact_ToImage] FOREIGN KEY ([ImageId]) REFERENCES [Image]([_Id])
)

GO
