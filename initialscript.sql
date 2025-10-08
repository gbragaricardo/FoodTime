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

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(32) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Customer] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(64) NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Restaurant] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(32) NOT NULL,
    [Address] nvarchar(max) NULL,
    [Status] nvarchar(16) NOT NULL,
    CONSTRAINT [PK_Restaurant] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Product] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(32) NOT NULL,
    [Description] NVARCHAR(128) NOT NULL,
    [Price] decimal(18,2) NOT NULL DEFAULT 0.0,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Order] (
    [Id] int NOT NULL IDENTITY,
    [CreationDate] datetime2 NOT NULL DEFAULT (GETUTCDATE()),
    [Status] nvarchar(16) NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL DEFAULT 0.0,
    [SubTotal] decimal(18,2) NOT NULL DEFAULT 0.0,
    [CustomerId] int NOT NULL,
    [RestaurantId] int NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Order_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderProduct] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL DEFAULT 0,
    [UnitPrice] decimal(18,2) NOT NULL DEFAULT 0.0,
    [OrderId] int NOT NULL,
    [ProductId] int NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Payment] (
    [Id] int NOT NULL IDENTITY,
    [Method] nvarchar(16) NOT NULL,
    [Value] decimal(18,2) NOT NULL DEFAULT 0.0,
    [Status] nvarchar(16) NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payment_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_CustomerEmail] ON [Customer] ([Email]);
GO

CREATE INDEX [IX_Order_CustomerId] ON [Order] ([CustomerId]);
GO

CREATE INDEX [IX_Order_RestaurantId] ON [Order] ([RestaurantId]);
GO

CREATE INDEX [IX_OrderProduct_OrderId] ON [OrderProduct] ([OrderId]);
GO

CREATE INDEX [IX_OrderProduct_ProductId] ON [OrderProduct] ([ProductId]);
GO

CREATE INDEX [IX_Payment_OrderId] ON [Payment] ([OrderId]);
GO

CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251008133554_InitialCreate', N'7.0.20');
GO

COMMIT;
GO

