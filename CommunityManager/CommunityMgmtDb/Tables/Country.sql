CREATE TABLE [dbo].[Country]
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
    [CurrencyCode] NCHAR(10) NULL, 
    [Timezone] NVARCHAR(100) NULL, 
    [TelephoneCode] INT NULL, 
    CONSTRAINT [FK_Country_ToCreatedBy] FOREIGN KEY ([_CreatedBy]) REFERENCES [User]([_Id]), 
    CONSTRAINT [FK_Country_ToUpdatedBy] FOREIGN KEY ([_UpdatedBy]) REFERENCES [User]([_Id])
)
