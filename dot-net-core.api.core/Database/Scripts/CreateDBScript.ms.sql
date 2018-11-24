-- mssql version

CREATE DATABASE [Content];
GO

USE [Content];
GO

IF NOT EXISTS(select * from [ContentItems])
CREATE TABLE [ContentItems] (
    [ContentKey] [int]IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
	[Value] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ContentKey] PRIMARY KEY ([ContentKey])
	);
GO

select * from [ContentItems];
GO
INSERT INTO [ContentItems] (Name, Value) VALUES
('sample google link','https://www.google.com'),
('sample mlb link','https://www.mlb.com')
GO

-- postgres version
-- CREATE DATABASE Content;

-- CREATE TABLE ContentItems (
--    ContentKey SERIAL PRIMARY KEY,
--    Name varchar,
--    Value varchar
-- );

-- INSERT INTO ContentItems (Name, Value) VALUES
-- ('sample google link','https://www.google.com'),
-- ('sample mlb link','https://www.mlb.com')

-- select * from contentitems;
