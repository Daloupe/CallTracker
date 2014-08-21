
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 08/22/2014 01:20:09
-- Generated from EDMX file: C:\Programming\CSharp\Projects\CallTracker\CallTracker\Source\Data\Contacts.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    ALTER TABLE [Contacts] DROP CONSTRAINT [FK_ContactsNames];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [Contacts];
GO
    DROP TABLE [Names];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [num] nvarchar(4000)  NOT NULL,
    [Name_Id] int  NOT NULL
);
GO

-- Creating table 'Names'
CREATE TABLE [Names] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(4000)  NOT NULL,
    [First] nvarchar(4000)  NOT NULL,
    [Initial] nvarchar(4000)  NOT NULL,
    [Last] nvarchar(4000)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'Names'
ALTER TABLE [Names]
ADD CONSTRAINT [PK_Names]
    PRIMARY KEY ([Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Name_Id] in table 'Contacts'
ALTER TABLE [Contacts]
ADD CONSTRAINT [FK_ContactsNames]
    FOREIGN KEY ([Name_Id])
    REFERENCES [Names]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactsNames'
CREATE INDEX [IX_FK_ContactsNames]
ON [Contacts]
    ([Name_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------