
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/03/2021 18:08:33
-- Generated from EDMX file: C:\Users\MahmoudNassar\source\repos\GetHair Egypt\Models\GHE.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GHE];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clinics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clinics];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clinics'
CREATE TABLE [dbo].[Clinics] (
    [CName] nvarchar(50)  NOT NULL,
    [Email] varchar(50)  NULL,
    [CUrl] varchar(150)  NULL,
    [Password] nchar(10)  NULL,
    [Address] nvarchar(50)  NULL,
    [CImage1] nvarchar(150)  NULL,
    [CImage2] nvarchar(150)  NULL,
    [CImage3] nvarchar(150)  NULL,
    [CImage4] nvarchar(150)  NULL,
    [CID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int  NOT NULL,
    [FName] nvarchar(50)  NOT NULL,
    [LName] nvarchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Password] nchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CName], [CID] in table 'Clinics'
ALTER TABLE [dbo].[Clinics]
ADD CONSTRAINT [PK_Clinics]
    PRIMARY KEY CLUSTERED ([CName], [CID] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------