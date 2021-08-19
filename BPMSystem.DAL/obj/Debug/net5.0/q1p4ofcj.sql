IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210819124635_Initial')
BEGIN
    CREATE TABLE [BaseEntity] (
        [Id] uniqueidentifier NOT NULL,
        [BaseEntityId] uniqueidentifier NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [Name] nvarchar(max) NULL,
        [ExtensionNumber] int NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [DateOfBirth] datetime2 NULL,
        [WorkExperience] float NULL,
        [PersonNumber] int NULL,
        [PositionId] uniqueidentifier NULL,
        [Position_Name] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        CONSTRAINT [PK_BaseEntity] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BaseEntity_BaseEntity_BaseEntityId] FOREIGN KEY ([BaseEntityId]) REFERENCES [BaseEntity] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BaseEntity_BaseEntity_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [BaseEntity] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210819124635_Initial')
BEGIN
    CREATE INDEX [IX_BaseEntity_BaseEntityId] ON [BaseEntity] ([BaseEntityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210819124635_Initial')
BEGIN
    CREATE INDEX [IX_BaseEntity_PositionId] ON [BaseEntity] ([PositionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210819124635_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210819124635_Initial', N'5.0.9');
END;
GO

COMMIT;
GO

