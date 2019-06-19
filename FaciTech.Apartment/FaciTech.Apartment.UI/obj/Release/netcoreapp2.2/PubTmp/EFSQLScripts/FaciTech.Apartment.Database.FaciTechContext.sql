IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Amenity] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Amenity] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [CommunityLocation] (
        [Id] uniqueidentifier NOT NULL,
        [Community] nvarchar(max) NULL,
        [Country] nvarchar(max) NULL,
        [CountryId] uniqueidentifier NOT NULL,
        [City] nvarchar(max) NULL,
        [CityId] uniqueidentifier NOT NULL,
        [Area] nvarchar(max) NULL,
        [AreaId] uniqueidentifier NOT NULL,
        [SubArea] nvarchar(max) NULL,
        [SubAreaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_CommunityLocation] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Contact] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [MobilePhone] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Country] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Country] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Feature] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Feature] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Group] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Group] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Role] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [User] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Username] nvarchar(max) NOT NULL,
        [Salt] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [ContactId] uniqueidentifier NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_User_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contact] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [State] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [CountryId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_State] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_State_Country_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Country] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [GroupRole] (
        [GroupId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_GroupRole] PRIMARY KEY ([GroupId], [RoleId]),
        CONSTRAINT [FK_GroupRole_Group_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Group] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_GroupRole_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [RoleFeature] (
        [RoleId] uniqueidentifier NOT NULL,
        [FeatureId] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_RoleFeature] PRIMARY KEY ([RoleId], [FeatureId]),
        CONSTRAINT [FK_RoleFeature_Feature_FeatureId] FOREIGN KEY ([FeatureId]) REFERENCES [Feature] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RoleFeature_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [UserGroup] (
        [UserId] uniqueidentifier NOT NULL,
        [GroupId] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        CONSTRAINT [PK_UserGroup] PRIMARY KEY ([UserId], [GroupId]),
        CONSTRAINT [FK_UserGroup_Group_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [Group] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserGroup_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [City] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [StateId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_City_State_StateId] FOREIGN KEY ([StateId]) REFERENCES [State] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Area] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [CityId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Area] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Area_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [SubArea] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [AreaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_SubArea] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SubArea_Area_AreaId] FOREIGN KEY ([AreaId]) REFERENCES [Area] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Community] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [BuilderName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NULL,
        [Landmark] nvarchar(max) NULL,
        [LocationLink] nvarchar(max) NULL,
        [AssociationName] nvarchar(max) NULL,
        [AssociationNumber] nvarchar(max) NULL,
        [AssociationBankName] nvarchar(max) NULL,
        [AssociationBankAccountNumber] nvarchar(max) NULL,
        [AssociationBankBranchAddress] nvarchar(max) NULL,
        [AssociationBankIFSC] nvarchar(max) NULL,
        [AmenityIds] nvarchar(max) NULL,
        [SubAreaId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Community] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Community_SubArea_SubAreaId] FOREIGN KEY ([SubAreaId]) REFERENCES [SubArea] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Block] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [Name] nvarchar(max) NOT NULL,
        [NoOfFloors] int NOT NULL,
        [CommunityId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Block] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Block_Community_CommunityId] FOREIGN KEY ([CommunityId]) REFERENCES [Community] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Unit] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [FloorNumber] int NOT NULL,
        [Number] nvarchar(max) NOT NULL,
        [Specification] nvarchar(max) NULL,
        [SectionId] uniqueidentifier NOT NULL,
        [OwnerContactId] uniqueidentifier NOT NULL,
        [OwnerId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Unit] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Unit_Contact_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Contact] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Unit_Block_SectionId] FOREIGN KEY ([SectionId]) REFERENCES [Block] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE TABLE [Tenant] (
        [Id] uniqueidentifier NOT NULL,
        [Comments] nvarchar(max) NULL,
        [Inactive] bit NOT NULL,
        [CreatedBy] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        [UpdatedBy] uniqueidentifier NOT NULL,
        [Updated] datetime2 NOT NULL,
        [ContactId] uniqueidentifier NOT NULL,
        [Primary] bit NOT NULL,
        [UnitId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Tenant] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Tenant_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Contact] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Tenant_Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [Unit] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Country]'))
        SET IDENTITY_INSERT [Country] ON;
    INSERT INTO [Country] ([Id], [Comments], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('f95c0b64-669a-494c-9b11-1b4241a33a94', NULL, '2019-06-18T18:03:56.8038348Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'India', '2019-06-18T18:03:56.8039089Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Country]'))
        SET IDENTITY_INSERT [Country] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'ContactId', N'Created', N'CreatedBy', N'Inactive', N'Password', N'Salt', N'Updated', N'UpdatedBy', N'Username') AND [object_id] = OBJECT_ID(N'[User]'))
        SET IDENTITY_INSERT [User] ON;
    INSERT INTO [User] ([Id], [Comments], [ContactId], [Created], [CreatedBy], [Inactive], [Password], [Salt], [Updated], [UpdatedBy], [Username])
    VALUES ('fa1c974f-70c3-4e8f-830f-3249380972a2', N'sys user record', NULL, '2019-06-18T18:03:56.8032153Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'Bi4Fi6tHEiF+Cv3Jh0V0MA==', N'123', '2019-06-18T18:03:56.8032985Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', N'system');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'ContactId', N'Created', N'CreatedBy', N'Inactive', N'Password', N'Salt', N'Updated', N'UpdatedBy', N'Username') AND [object_id] = OBJECT_ID(N'[User]'))
        SET IDENTITY_INSERT [User] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'CountryId', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[State]'))
        SET IDENTITY_INSERT [State] ON;
    INSERT INTO [State] ([Id], [Comments], [CountryId], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('06dbbab9-40bd-4a02-9b91-cbadbf136624', NULL, 'f95c0b64-669a-494c-9b11-1b4241a33a94', '2019-06-18T18:03:56.8041911Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'Karnataka', '2019-06-18T18:03:56.8042612Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'CountryId', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[State]'))
        SET IDENTITY_INSERT [State] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'StateId', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[City]'))
        SET IDENTITY_INSERT [City] ON;
    INSERT INTO [City] ([Id], [Comments], [Created], [CreatedBy], [Inactive], [Name], [StateId], [Updated], [UpdatedBy])
    VALUES ('8a4f5fa0-9935-4e18-b153-cf22a2deea78', NULL, '2019-06-18T18:03:56.8045275Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'Bangalore', '06dbbab9-40bd-4a02-9b91-cbadbf136624', '2019-06-18T18:03:56.8045969Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'StateId', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[City]'))
        SET IDENTITY_INSERT [City] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Area]'))
        SET IDENTITY_INSERT [Area] ON;
    INSERT INTO [Area] ([Id], [CityId], [Comments], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('e297c484-666d-4009-8dd6-d4eda26bae0c', '8a4f5fa0-9935-4e18-b153-cf22a2deea78', NULL, '2019-06-18T18:03:56.8048613Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'North', '2019-06-18T18:03:56.8049338Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Area]'))
        SET IDENTITY_INSERT [Area] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Area]'))
        SET IDENTITY_INSERT [Area] ON;
    INSERT INTO [Area] ([Id], [CityId], [Comments], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('b0ab2ec4-d093-43a5-ad6b-93b94d1341ad', '8a4f5fa0-9935-4e18-b153-cf22a2deea78', NULL, '2019-06-18T18:03:56.8050573Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'South', '2019-06-18T18:03:56.8050578Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[Area]'))
        SET IDENTITY_INSERT [Area] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[SubArea]'))
        SET IDENTITY_INSERT [SubArea] ON;
    INSERT INTO [SubArea] ([Id], [AreaId], [Comments], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('76887194-dbe6-42af-958f-7a8bf63a1045', 'e297c484-666d-4009-8dd6-d4eda26bae0c', NULL, '2019-06-18T18:03:56.8054136Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'Hebbal', '2019-06-18T18:03:56.8054141Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[SubArea]'))
        SET IDENTITY_INSERT [SubArea] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[SubArea]'))
        SET IDENTITY_INSERT [SubArea] ON;
    INSERT INTO [SubArea] ([Id], [AreaId], [Comments], [Created], [CreatedBy], [Inactive], [Name], [Updated], [UpdatedBy])
    VALUES ('19f3e783-32f5-441e-9004-c760f8d50cfc', 'b0ab2ec4-d093-43a5-ad6b-93b94d1341ad', NULL, '2019-06-18T18:03:56.8052149Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2', 0, N'Jayanagar', '2019-06-18T18:03:56.8052861Z', 'fa1c974f-70c3-4e8f-830f-3249380972a2');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AreaId', N'Comments', N'Created', N'CreatedBy', N'Inactive', N'Name', N'Updated', N'UpdatedBy') AND [object_id] = OBJECT_ID(N'[SubArea]'))
        SET IDENTITY_INSERT [SubArea] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Area_CityId] ON [Area] ([CityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Block_CommunityId] ON [Block] ([CommunityId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_City_StateId] ON [City] ([StateId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Community_SubAreaId] ON [Community] ([SubAreaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_GroupRole_RoleId] ON [GroupRole] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_RoleFeature_FeatureId] ON [RoleFeature] ([FeatureId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_State_CountryId] ON [State] ([CountryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_SubArea_AreaId] ON [SubArea] ([AreaId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Tenant_ContactId] ON [Tenant] ([ContactId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Tenant_UnitId] ON [Tenant] ([UnitId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Unit_OwnerId] ON [Unit] ([OwnerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_Unit_SectionId] ON [Unit] ([SectionId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_User_ContactId] ON [User] ([ContactId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    CREATE INDEX [IX_UserGroup_GroupId] ON [UserGroup] ([GroupId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190618180357_initalMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190618180357_initalMigration', N'2.2.4-servicing-10062');
END;

GO

