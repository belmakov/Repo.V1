CREATE TABLE [dbo].[Amenity]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [Name] NVARCHAR(100) NULL, 
    [AmenityTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL, 
    CONSTRAINT [FK_Amenity_ToAmenityType] FOREIGN KEY ([AmenityTypeId]) REFERENCES [AmenityType]([_Id]), 
    CONSTRAINT [FK_Amenity_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Amenity_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
