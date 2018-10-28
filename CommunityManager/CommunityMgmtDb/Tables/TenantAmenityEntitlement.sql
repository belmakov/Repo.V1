CREATE TABLE [dbo].[TenantAmenityEntitlement]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [TenantId] UNIQUEIDENTIFIER NOT NULL, 
    [AmenityId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_TenantAmenityEntitlement_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_TenantAmenityEntitlement_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_TenantAmenityEntitlement_ToTenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([_Id]), 
    CONSTRAINT [FK_TenantAmenityEntitlement_ToAmenity] FOREIGN KEY ([AmenityId]) REFERENCES [Amenity]([_Id])
)
