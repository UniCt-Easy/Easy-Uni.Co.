
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


-- CREAZIONE TABELLA menuweb --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[menuweb]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[menuweb] (
idmenuweb int NOT NULL,
editType nvarchar(60) NULL,
idmenuwebparent int NULL,
label nvarchar(250) NOT NULL,
link nvarchar(250) NULL,
sort int NULL,
tableName nvarchar(60) NULL,
 CONSTRAINT xpkmenuweb PRIMARY KEY (idmenuweb
)
)
END
GO

-- VERIFICA STRUTTURA menuweb --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'idmenuweb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD idmenuweb int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('menuweb') and col.name = 'idmenuweb' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [menuweb] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'editType' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD editType nvarchar(60) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN editType nvarchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'idmenuwebparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD idmenuwebparent int NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN idmenuwebparent int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'label' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD label nvarchar(250) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('menuweb') and col.name = 'label' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [menuweb] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN label nvarchar(250) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'link' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD link nvarchar(250) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN link nvarchar(250) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'sort' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD sort int NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN sort int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'menuweb' and C.name = 'tableName' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [menuweb] ADD tableName nvarchar(60) NULL 
END
ELSE
	ALTER TABLE [menuweb] ALTER COLUMN tableName nvarchar(60) NULL
GO

