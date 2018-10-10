
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/10/2018 10:28:55
-- Generated from EDMX file: C:\Users\ar2\Source\Repos\AndreRRR\KW41_EF_DUS\EF_ModelFirst\EF_ModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EfModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KundeMitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Kunde] DROP CONSTRAINT [FK_KundeMitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_AbteilungMitarbeiter_Abteilung]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbteilungMitarbeiter] DROP CONSTRAINT [FK_AbteilungMitarbeiter_Abteilung];
GO
IF OBJECT_ID(N'[dbo].[FK_AbteilungMitarbeiter_Mitarbeiter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbteilungMitarbeiter] DROP CONSTRAINT [FK_AbteilungMitarbeiter_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[FK_Kunde_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Kunde] DROP CONSTRAINT [FK_Kunde_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Mitarbeiter_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet_Mitarbeiter] DROP CONSTRAINT [FK_Mitarbeiter_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[AbteilungSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbteilungSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Kunde]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Kunde];
GO
IF OBJECT_ID(N'[dbo].[PersonSet_Mitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet_Mitarbeiter];
GO
IF OBJECT_ID(N'[dbo].[AbteilungMitarbeiter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbteilungMitarbeiter];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GebDatum] datetime  NULL
);
GO

-- Creating table 'AbteilungSet'
CREATE TABLE [dbo].[AbteilungSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Bezeichnung] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonSet_Kunde'
CREATE TABLE [dbo].[PersonSet_Kunde] (
    [KdNr] nvarchar(max)  NOT NULL,
    [Schuhgröße_LinkerFuß] int  NOT NULL,
    [Schuhgröße_RechterFuß] float  NOT NULL,
    [Id] int  NOT NULL,
    [Mitarbeiter_Id] int  NULL
);
GO

-- Creating table 'PersonSet_Mitarbeiter'
CREATE TABLE [dbo].[PersonSet_Mitarbeiter] (
    [Beruf] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'AbteilungMitarbeiter'
CREATE TABLE [dbo].[AbteilungMitarbeiter] (
    [Abteilung_Id] int  NOT NULL,
    [Mitarbeiter_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AbteilungSet'
ALTER TABLE [dbo].[AbteilungSet]
ADD CONSTRAINT [PK_AbteilungSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [PK_PersonSet_Kunde]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet_Mitarbeiter'
ALTER TABLE [dbo].[PersonSet_Mitarbeiter]
ADD CONSTRAINT [PK_PersonSet_Mitarbeiter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Abteilung_Id], [Mitarbeiter_Id] in table 'AbteilungMitarbeiter'
ALTER TABLE [dbo].[AbteilungMitarbeiter]
ADD CONSTRAINT [PK_AbteilungMitarbeiter]
    PRIMARY KEY CLUSTERED ([Abteilung_Id], [Mitarbeiter_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Mitarbeiter_Id] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [FK_KundeMitarbeiter]
    FOREIGN KEY ([Mitarbeiter_Id])
    REFERENCES [dbo].[PersonSet_Mitarbeiter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KundeMitarbeiter'
CREATE INDEX [IX_FK_KundeMitarbeiter]
ON [dbo].[PersonSet_Kunde]
    ([Mitarbeiter_Id]);
GO

-- Creating foreign key on [Abteilung_Id] in table 'AbteilungMitarbeiter'
ALTER TABLE [dbo].[AbteilungMitarbeiter]
ADD CONSTRAINT [FK_AbteilungMitarbeiter_Abteilung]
    FOREIGN KEY ([Abteilung_Id])
    REFERENCES [dbo].[AbteilungSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Mitarbeiter_Id] in table 'AbteilungMitarbeiter'
ALTER TABLE [dbo].[AbteilungMitarbeiter]
ADD CONSTRAINT [FK_AbteilungMitarbeiter_Mitarbeiter]
    FOREIGN KEY ([Mitarbeiter_Id])
    REFERENCES [dbo].[PersonSet_Mitarbeiter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AbteilungMitarbeiter_Mitarbeiter'
CREATE INDEX [IX_FK_AbteilungMitarbeiter_Mitarbeiter]
ON [dbo].[AbteilungMitarbeiter]
    ([Mitarbeiter_Id]);
GO

-- Creating foreign key on [Id] in table 'PersonSet_Kunde'
ALTER TABLE [dbo].[PersonSet_Kunde]
ADD CONSTRAINT [FK_Kunde_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'PersonSet_Mitarbeiter'
ALTER TABLE [dbo].[PersonSet_Mitarbeiter]
ADD CONSTRAINT [FK_Mitarbeiter_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------