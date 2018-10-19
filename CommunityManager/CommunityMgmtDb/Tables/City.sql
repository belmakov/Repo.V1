CREATE TABLE [dbo].[City]
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
    [Code] NVARCHAR(10) NULL, 
    [TelephoneCode] INT NULL, 
    [Timezone] NVARCHAR(100) NOT NULL, 
    [RegionId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_City_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_City_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_City_ToRegion] FOREIGN KEY ([RegionId]) REFERENCES [Region]([_Id])
)
