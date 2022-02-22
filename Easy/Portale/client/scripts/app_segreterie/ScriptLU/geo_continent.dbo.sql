
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


-- CREAZIONE TABELLA geo_continent --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[geo_continent]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[geo_continent] (
idcontinent int NOT NULL,
title nvarchar(50) NULL,
title_EN nvarchar(50) NULL,
 CONSTRAINT xpkgeo_continent PRIMARY KEY (idcontinent
)
)
END
GO

-- VERIFICA STRUTTURA geo_continent --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_continent' and C.name = 'idcontinent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_continent] ADD idcontinent int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('geo_continent') and col.name = 'idcontinent' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [geo_continent] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_continent' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_continent] ADD title nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [geo_continent] ALTER COLUMN title nvarchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'geo_continent' and C.name = 'title_EN' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [geo_continent] ADD title_EN nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [geo_continent] ALTER COLUMN title_EN nvarchar(50) NULL
GO


-- GENERAZIONE DATI PER geo_continent --
IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '1')
UPDATE [geo_continent] SET title = 'Europa',title_EN = 'Europe' WHERE idcontinent = '1'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('1','Europa','Europe')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '2')
UPDATE [geo_continent] SET title = 'Asia',title_EN = 'Asia' WHERE idcontinent = '2'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('2','Asia','Asia')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '3')
UPDATE [geo_continent] SET title = 'Africa',title_EN = 'Africa' WHERE idcontinent = '3'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('3','Africa','Africa')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '4')
UPDATE [geo_continent] SET title = 'America del nord',title_EN = 'North America' WHERE idcontinent = '4'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('4','America del nord','North America')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '5')
UPDATE [geo_continent] SET title = 'America centrale',title_EN = 'Central America' WHERE idcontinent = '5'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('5','America centrale','Central America')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '6')
UPDATE [geo_continent] SET title = 'America del sud',title_EN = 'South America' WHERE idcontinent = '6'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('6','America del sud','South America')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '7')
UPDATE [geo_continent] SET title = 'Oceania',title_EN = 'Oceania' WHERE idcontinent = '7'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('7','Oceania','Oceania')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '8')
UPDATE [geo_continent] SET title = 'Dipendenze 1',title_EN = 'Dependence
 1' WHERE idcontinent = '8'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('8','Dipendenze 1','Dependence
 1')
GO

IF exists(SELECT * FROM [geo_continent] WHERE idcontinent = '9')
UPDATE [geo_continent] SET title = 'Dipendenze 2',title_EN = 'Dependence
 2' WHERE idcontinent = '9'
ELSE
INSERT INTO [geo_continent] (idcontinent,title,title_EN) VALUES ('9','Dipendenze 2','Dependence
 2')
GO

