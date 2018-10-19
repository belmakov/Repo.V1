CREATE TABLE [dbo].[Tenant]
(
	[_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [_CreatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Created] DATETIME NOT NULL, 
    [_Updated] DATETIME NOT NULL, 
    [_UpdatedBy] UNIQUEIDENTIFIER NOT NULL, 
    [_Active] BIT NOT NULL, 
    [_Tags] NVARCHAR(MAX) NULL, 
    [_Comments] NVARCHAR(MAX) NULL, 
    [Primary] BIT NOT NULL, 
    [ContactId] UNIQUEIDENTIFIER NOT NULL, 
    [UnitId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Tenant_ToContact] FOREIGN KEY ([ContactId]) REFERENCES [Contact]([_Id]), 
    CONSTRAINT [FK_Tenant_ToUnit] FOREIGN KEY ([UnitId]) REFERENCES [Unit]([_Id]), 
    CONSTRAINT [FK_Tenant_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Tenant_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
