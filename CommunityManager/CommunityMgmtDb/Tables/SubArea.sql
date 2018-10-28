CREATE TABLE [dbo].[SubArea]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [AreaId] UNIQUEIDENTIFIER NOT NULL, 
    [SupervisorId] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_SubArea_ToArea] FOREIGN KEY (AreaId) REFERENCES [Area]([_Id]), 
    CONSTRAINT [FK_SubArea_ToSupervisor] FOREIGN KEY ([SupervisorId]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_SubArea_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_SubArea_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
