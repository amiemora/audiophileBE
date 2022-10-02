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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE TABLE [Users] (
        [UserID] int NOT NULL,
        [username] varchar(50) NOT NULL,
        [name] varchar(50) NOT NULL,
        [email] varchar(200) NULL,
        [password] varchar(100) NOT NULL,
        [profilepic] varchar(500) NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE TABLE [Post] (
        [PostID] int NOT NULL,
        [UserID] int NOT NULL,
        [song_title] varchar(100) NOT NULL,
        [album] varchar(500) NOT NULL,
        [artist] varchar(100) NOT NULL,
        [genre] varchar(50) NOT NULL,
        [likes] int NOT NULL,
        [created_at] datetime NOT NULL,
        [updated_at] datetime NOT NULL,
        CONSTRAINT [PK_Post] PRIMARY KEY ([PostID]),
        CONSTRAINT [FK_Post_User] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE TABLE [Comment] (
        [CommentID] int NOT NULL,
        [PostID] int NOT NULL,
        [UserID] int NOT NULL,
        [comment_body] varchar(200) NOT NULL,
        [created_at] datetime NOT NULL,
        [likes] int NOT NULL,
        CONSTRAINT [PK_Comment] PRIMARY KEY ([CommentID]),
        CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostID]) REFERENCES [Post] ([PostID]),
        CONSTRAINT [FK_Comment_User] FOREIGN KEY ([UserID]) REFERENCES [Users] ([UserID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE INDEX [IX_Comment_PostID] ON [Comment] ([PostID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE INDEX [IX_Comment_UserID] ON [Comment] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    CREATE INDEX [IX_Post_UserID] ON [Post] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220928223858_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220928223858_initial', N'6.0.9');
END;
GO

COMMIT;
GO

