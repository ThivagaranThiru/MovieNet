
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/22/2019 16:43:13
-- Generated from EDMX file: C:\Users\thiva\source\repos\MovieNet\MovieNet.Data\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
	[Civilite] nvarchar(max) NOT NULL, 
    [Nom] nvarchar(max) NOT NULL, 
    [Prenom] nvarchar(max) NOT NULL, 
    [DateNaissance] datetime NOT NULL
);
GO

-- Creating table 'Commentaire_NoteSet'
CREATE TABLE [dbo].[Commentaire_NoteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Commentaires] nvarchar(max)  NOT NULL,
    [Notes] decimal(18,0)  NOT NULL,
    [Film_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- Creating table 'FilmSet'
CREATE TABLE [dbo].[FilmSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Resume] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Commentaire_NoteSet'
ALTER TABLE [dbo].[Commentaire_NoteSet]
ADD CONSTRAINT [PK_Commentaire_NoteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [PK_FilmSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Film_Id] in table 'Commentaire_NoteSet'
ALTER TABLE [dbo].[Commentaire_NoteSet]
ADD CONSTRAINT [FK_FilmCommentaire_Note]
    FOREIGN KEY ([Film_Id])
    REFERENCES [dbo].[FilmSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmCommentaire_Note'
CREATE INDEX [IX_FK_FilmCommentaire_Note]
ON [dbo].[Commentaire_NoteSet]
    ([Film_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'Commentaire_NoteSet'
ALTER TABLE [dbo].[Commentaire_NoteSet]
ADD CONSTRAINT [FK_UsersCommentaire_Note]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersCommentaire_Note'
CREATE INDEX [IX_FK_UsersCommentaire_Note]
ON [dbo].[Commentaire_NoteSet]
    ([Users_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------