IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [AttachmentBlobs] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Body] varbinary(max) NULL,
        CONSTRAINT [PK_AttachmentBlobs] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Attachments] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [FileName] nvarchar(max) NULL,
        [FileExtension] nvarchar(max) NULL,
        [FileSize] int NOT NULL,
        CONSTRAINT [PK_Attachments] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [GateKeeper] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_GateKeeper] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [PersonalHelper] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Role] nvarchar(max) NULL,
        CONSTRAINT [PK_PersonalHelper] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [States] (
        [StateId] int NOT NULL IDENTITY,
        [Country] nvarchar(max) NULL,
        [StateName] nvarchar(max) NULL,
        CONSTRAINT [PK_States] PRIMARY KEY ([StateId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Vendor] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Purpose] nvarchar(max) NULL,
        [Schedule] datetime2 NOT NULL,
        CONSTRAINT [PK_Vendor] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Cities] (
        [CityId] int NOT NULL IDENTITY,
        [CityName] nvarchar(max) NULL,
        [StateId] int NOT NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId]),
        CONSTRAINT [FK_Cities_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([StateId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Location] (
        [Id] int NOT NULL IDENTITY,
        [ApartmentName] nvarchar(max) NULL,
        [Street] nvarchar(max) NULL,
        [LocationOrArea] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [State] nvarchar(max) NULL,
        [PinCode] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [PersonalHelperForeignKey] int NULL,
        [GateKeeperForeignKey] int NULL,
        [VendorForeignKey] int NULL,
        CONSTRAINT [PK_Location] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Location_GateKeeper_GateKeeperForeignKey] FOREIGN KEY ([GateKeeperForeignKey]) REFERENCES [GateKeeper] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Location_PersonalHelper_PersonalHelperForeignKey] FOREIGN KEY ([PersonalHelperForeignKey]) REFERENCES [PersonalHelper] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Location_Vendor_VendorForeignKey] FOREIGN KEY ([VendorForeignKey]) REFERENCES [Vendor] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Areas] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [AreaName] nvarchar(max) NULL,
        [CityId] int NOT NULL,
        CONSTRAINT [PK_Areas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Areas_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([CityId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [SubAreas] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [SubAreaName] nvarchar(max) NULL,
        [AreaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_SubAreas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubAreas_Areas_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Areas] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Communities] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [SubAreaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Communities] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Communities_SubAreas_SubAreaId] FOREIGN KEY ([SubAreaId]) REFERENCES [SubAreas] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Blocks] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [CommunityId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Blocks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Blocks_Communities_CommunityId] FOREIGN KEY ([CommunityId]) REFERENCES [Communities] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Members] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [PersonId] uniqueidentifier NULL,
        [Name] nvarchar(50) NOT NULL,
        [IsAssociationMember] bit NOT NULL,
        [ApartmentId] uniqueidentifier NULL,
        [AssociationId] int NULL,
        [AssociationId1] int NULL,
        CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Associations] (
        [Id] int NOT NULL IDENTITY,
        [PresidentId] uniqueidentifier NULL,
        [SecretaryId] uniqueidentifier NULL,
        [CommunityId] uniqueidentifier NULL,
        CONSTRAINT [PK_Associations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Associations_Communities_CommunityId] FOREIGN KEY ([CommunityId]) REFERENCES [Communities] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Associations_Members_PresidentId] FOREIGN KEY ([PresidentId]) REFERENCES [Members] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Associations_Members_SecretaryId] FOREIGN KEY ([SecretaryId]) REFERENCES [Members] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Contacts] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [AddressId] int NULL,
        [Phone] nvarchar(max) NULL,
        [Mobile] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [ImageId] uniqueidentifier NULL,
        [ApartmentId] uniqueidentifier NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Contacts_Location_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Location] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Contacts_Attachments_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [Attachments] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Flats] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Number] nvarchar(50) NOT NULL,
        [OwnerId] uniqueidentifier NULL,
        [IsRented] bit NOT NULL,
        [BlockId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Flats] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Flats_Blocks_BlockId] FOREIGN KEY ([BlockId]) REFERENCES [Blocks] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Flats_Contacts_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Contacts] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Username] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [UserContactId] uniqueidentifier NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Contacts_UserContactId] FOREIGN KEY ([UserContactId]) REFERENCES [Contacts] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Areas_CityId] ON [Areas] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Associations_CommunityId] ON [Associations] ([CommunityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Associations_PresidentId] ON [Associations] ([PresidentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Associations_SecretaryId] ON [Associations] ([SecretaryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Blocks_CommunityId] ON [Blocks] ([CommunityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Cities_StateId] ON [Cities] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Communities_SubAreaId] ON [Communities] ([SubAreaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Contacts_AddressId] ON [Contacts] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Contacts_ApartmentId] ON [Contacts] ([ApartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Contacts_ImageId] ON [Contacts] ([ImageId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Flats_BlockId] ON [Flats] ([BlockId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Flats_OwnerId] ON [Flats] ([OwnerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE UNIQUE INDEX [IX_Location_GateKeeperForeignKey] ON [Location] ([GateKeeperForeignKey]) WHERE [GateKeeperForeignKey] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE UNIQUE INDEX [IX_Location_PersonalHelperForeignKey] ON [Location] ([PersonalHelperForeignKey]) WHERE [PersonalHelperForeignKey] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE UNIQUE INDEX [IX_Location_VendorForeignKey] ON [Location] ([VendorForeignKey]) WHERE [VendorForeignKey] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Members_ApartmentId] ON [Members] ([ApartmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Members_AssociationId] ON [Members] ([AssociationId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Members_AssociationId1] ON [Members] ([AssociationId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Members_PersonId] ON [Members] ([PersonId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_SubAreas_AreaId] ON [SubAreas] ([AreaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    CREATE INDEX [IX_Users_UserContactId] ON [Users] ([UserContactId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Flats_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [Flats] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Contacts_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Contacts] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Associations_AssociationId] FOREIGN KEY ([AssociationId]) REFERENCES [Associations] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    ALTER TABLE [Members] ADD CONSTRAINT [FK_Members_Associations_AssociationId1] FOREIGN KEY ([AssociationId1]) REFERENCES [Associations] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_Flats_ApartmentId] FOREIGN KEY ([ApartmentId]) REFERENCES [Flats] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190421202847_CreateCommunityDB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190421202847_CreateCommunityDB', N'2.2.4-servicing-10062');
END;

GO

