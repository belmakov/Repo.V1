CREATE TABLE [dbo].[Area]
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
    [SupervisorId] UNIQUEIDENTIFIER NOT NULL, 
    [CityId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Area_ToSupervisor] FOREIGN KEY ([SupervisorId]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Area_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Area_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Area_ToCity] FOREIGN KEY ([CityId]) REFERENCES [City]([_Id])
)
