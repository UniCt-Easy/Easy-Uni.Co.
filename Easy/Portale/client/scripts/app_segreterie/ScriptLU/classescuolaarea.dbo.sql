
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


-- CREAZIONE TABELLA classescuolaarea --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[classescuolaarea]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[classescuolaarea] (
idclassescuolaarea int NOT NULL,
title nvarchar(50) NULL,
 CONSTRAINT xpkclassescuolaarea PRIMARY KEY (idclassescuolaarea
)
)
END
GO

-- VERIFICA STRUTTURA classescuolaarea --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolaarea' and C.name = 'idclassescuolaarea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolaarea] ADD idclassescuolaarea int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('classescuolaarea') and col.name = 'idclassescuolaarea' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [classescuolaarea] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'classescuolaarea' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [classescuolaarea] ADD title nvarchar(50) NULL 
END
ELSE
	ALTER TABLE [classescuolaarea] ALTER COLUMN title nvarchar(50) NULL
GO


-- GENERAZIONE DATI PER classescuolaarea --
IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '1')
UPDATE [classescuolaarea] SET title = 'Area Sanitaria' WHERE idclassescuolaarea = '1'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('1','Area Sanitaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '2')
UPDATE [classescuolaarea] SET title = 'Area Scientifica' WHERE idclassescuolaarea = '2'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('2','Area Scientifica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '3')
UPDATE [classescuolaarea] SET title = 'Area Sociale' WHERE idclassescuolaarea = '3'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('3','Area Sociale')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '4')
UPDATE [classescuolaarea] SET title = 'Area Umanistica' WHERE idclassescuolaarea = '4'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('4','Area Umanistica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '5')
UPDATE [classescuolaarea] SET title = 'Area Beni Culturali' WHERE idclassescuolaarea = '5'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('5','Area Beni Culturali')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '6')
UPDATE [classescuolaarea] SET title = 'Area Sanitaria' WHERE idclassescuolaarea = '6'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('6','Area Sanitaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '7')
UPDATE [classescuolaarea] SET title = 'Area Psicologica' WHERE idclassescuolaarea = '7'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('7','Area Psicologica')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '8')
UPDATE [classescuolaarea] SET title = 'Area Veterinaria' WHERE idclassescuolaarea = '8'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('8','Area Veterinaria')
GO

IF exists(SELECT * FROM [classescuolaarea] WHERE idclassescuolaarea = '9')
UPDATE [classescuolaarea] SET title = 'Area Reach' WHERE idclassescuolaarea = '9'
ELSE
INSERT INTO [classescuolaarea] (idclassescuolaarea,title) VALUES ('9','Area Reach')
GO

