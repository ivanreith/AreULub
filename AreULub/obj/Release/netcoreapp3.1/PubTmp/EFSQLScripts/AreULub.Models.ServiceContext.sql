IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    CREATE TABLE [Comments] (
        [CommentsID] int NOT NULL IDENTITY,
        [CommentsUser] nvarchar(20) NOT NULL,
        [CommentTitle] nvarchar(25) NOT NULL,
        [CommentText] nvarchar(250) NOT NULL,
        [CommentDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Comments] PRIMARY KEY ([CommentsID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    CREATE TABLE [Users] (
        [UserId] nvarchar(450) NOT NULL,
        [UserName] nvarchar(max) NULL,
        [UserLast] nvarchar(max) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    CREATE TABLE [Services] (
        [ServiceID] int NOT NULL IDENTITY,
        [ServiceName] nvarchar(50) NOT NULL,
        [ServiceDescription] nvarchar(50) NOT NULL,
        [ServiceEstimated] nvarchar(25) NOT NULL,
        [ServicePrice] decimal(18,2) NOT NULL,
        [UserID] nvarchar(450) NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([ServiceID]),
        CONSTRAINT [FK_Services_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserId]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'UserLast', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    INSERT INTO [Users] ([UserId], [UserLast], [UserName])
    VALUES (N'1', N'FakeLast1', N'Johnny'),
    (N'2', N'FakeLast2', N'Tommy'),
    (N'3', N'FakeLast3', N'Danny'),
    (N'4', N'FakeLast4', N'Mannly'),
    (N'5', N'FakeLast5', N'Conny'),
    (N'6', N'FakeLast6', N'Sunny'),
    (N'7', N'FakeLast7', N'Diandra');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'UserLast', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] ON;
    INSERT INTO [Services] ([ServiceID], [ServiceDescription], [ServiceEstimated], [ServiceName], [ServicePrice], [UserID])
    VALUES (1, N'Fast and using the best oil', N'Around 30 minutes', N'Oil Change', 80.0, N'1');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] ON;
    INSERT INTO [Services] ([ServiceID], [ServiceDescription], [ServiceEstimated], [ServiceName], [ServicePrice], [UserID])
    VALUES (2, N'Reliable to get your car ready', N'Around 1 hour', N'General checkout', 140.0, N'5');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] ON;
    INSERT INTO [Services] ([ServiceID], [ServiceDescription], [ServiceEstimated], [ServiceName], [ServicePrice], [UserID])
    VALUES (3, N'Quick and using Duracell', N'Around 15 minutes', N'Battery change', 120.0, N'7');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ServiceID', N'ServiceDescription', N'ServiceEstimated', N'ServiceName', N'ServicePrice', N'UserID') AND [object_id] = OBJECT_ID(N'[Services]'))
        SET IDENTITY_INSERT [Services] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    CREATE INDEX [IX_Services_UserID] ON [Services] ([UserID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201206003433_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201206003433_Initial', N'3.1.9');
END;

GO

