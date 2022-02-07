CREATE TABLE [dbo].[Products]
(
    [Id]    INT           NOT NULL PRIMARY KEY CLUSTERED, -- IDENTITY is not used to insert values manually
    [Name]  NVARCHAR(255) NOT NULL,
    [Price] MONEY         NOT NULL,
    [Stock] INT           NOT NULL
);

CREATE TABLE [dbo].[Categories]
(
    [Id]   INT           NOT NULL PRIMARY KEY CLUSTERED, -- IDENTITY is not used to insert values manually
    [Name] NVARCHAR(100) NOT NULL,
);

CREATE TABLE [dbo].[ProductsCategories]
(
    [ProductId]  INT NOT NULL,
    [CategoryId] INT NOT NULL,
    CONSTRAINT PK_ProductsCategories PRIMARY KEY CLUSTERED (ProductId, CategoryId),
    CONSTRAINT FK_ProductId FOREIGN KEY (ProductId) REFERENCES [dbo].Products (Id) ON DELETE CASCADE,
    CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES [dbo].Categories (Id) ON DELETE CASCADE
);

INSERT INTO [dbo].Products([Id], Name, Price, Stock)
VALUES (1, 'iPhone 13 Pro', 99999, 100),
       (2, 'MacBook Pro 13 M1/8/256', 119999, 14),
       (3, 'AirPods Max', 48799, 30),
       (4, 'Apple TV 4K 32Gb', 16990, 12);

INSERT INTO [dbo].Categories(Id, Name)
VALUES (1, N'Телефоны'),
       (2, N'Ноутбуки'),
       (3, N'Наушники'),
       (4, N'Техника');

INSERT INTO [dbo].ProductsCategories(ProductId, CategoryId)
VALUES (1, 1),
       (2, 2),
       (3, 3),
       (1, 4),
       (2, 4),
       (3, 4);