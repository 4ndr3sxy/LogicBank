
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/10/2020 15:49:44
-- Generated from EDMX file: C:\Users\EKS-UAI\source\repos\BluBank\ConnectDataBase\db_blue_bank.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_blue_bank];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__accounts__fk_use__1367E606]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[accounts] DROP CONSTRAINT [FK__accounts__fk_use__1367E606];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[accounts];
GO
IF OBJECT_ID(N'[dbo].[users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'accounts'
CREATE TABLE [dbo].[accounts] (
    [id] varchar(max)  NOT NULL,
    [balance] int  NOT NULL,
    [fk_user_id] varchar(128)  NOT NULL,
    [date_created] datetime  NULL,
    [date_updated] datetime  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] varchar(128)  NOT NULL,
    [name] varchar(64)  NOT NULL,
    [last_name] varchar(64)  NULL,
    [addres] varchar(128)  NOT NULL,
    [phone] varchar(64)  NOT NULL,
    [city] varchar(128)  NOT NULL,
    [country] varchar(64)  NOT NULL,
    [user_login] varchar(32)  NOT NULL,
    [password_login] nvarchar(max)  NOT NULL,
    [date_created] datetime  NULL,
    [date_updated] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'accounts'
ALTER TABLE [dbo].[accounts]
ADD CONSTRAINT [PK_accounts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [fk_user_id] in table 'accounts'
ALTER TABLE [dbo].[accounts]
ADD CONSTRAINT [FK__accounts__fk_use__1367E606]
    FOREIGN KEY ([fk_user_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__accounts__fk_use__1367E606'
CREATE INDEX [IX_FK__accounts__fk_use__1367E606]
ON [dbo].[accounts]
    ([fk_user_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------