CREATE TABLE [dbo].[Region]
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
    [Code] NCHAR(10) NULL, 
    [Timezone] NVARCHAR(100) NULL, 
    [RegionTypeId] UNIQUEIDENTIFIER NOT NULL, 
    [CountryId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Regions_ToRegionType] FOREIGN KEY ([RegionTypeId]) REFERENCES [RegionType]([_Id]), 
    CONSTRAINT [FK_Regions_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Regions_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Regions_ToCountry] FOREIGN KEY ([CountryId]) REFERENCES [Country]([_Id])
)
