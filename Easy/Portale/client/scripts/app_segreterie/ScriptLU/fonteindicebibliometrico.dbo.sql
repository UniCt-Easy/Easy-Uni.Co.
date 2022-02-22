
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


-- CREAZIONE TABELLA fonteindicebibliometrico --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[fonteindicebibliometrico]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[fonteindicebibliometrico] (
idfonteindicebibliometrico int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(max) NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title nvarchar(1024) NULL,
 CONSTRAINT xpkfonteindicebibliometrico PRIMARY KEY (idfonteindicebibliometrico
)
)
END
GO

-- VERIFICA STRUTTURA fonteindicebibliometrico --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'idfonteindicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD idfonteindicebibliometrico int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('fonteindicebibliometrico') and col.name = 'idfonteindicebibliometrico' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [fonteindicebibliometrico] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'fonteindicebibliometrico' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [fonteindicebibliometrico] ADD title nvarchar(1024) NULL 
END
ELSE
	ALTER TABLE [fonteindicebibliometrico] ALTER COLUMN title nvarchar(1024) NULL
GO


-- GENERAZIONE DATI PER fonteindicebibliometrico --
IF exists(SELECT * FROM [fonteindicebibliometrico] WHERE idfonteindicebibliometrico = '1')
UPDATE [fonteindicebibliometrico] SET active = 'S',ct = {d '2003-11-20'},cu = 'ferdinando',description = null,lt = {d '2003-11-20'},lu = 'ferdinando',sortcode = '1',title = 'WoS' WHERE idfonteindicebibliometrico = '1'
ELSE
INSERT INTO [fonteindicebibliometrico] (idfonteindicebibliometrico,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{d '2003-11-20'},'ferdinando',null,{d '2003-11-20'},'ferdinando','1','WoS')
GO

IF exists(SELECT * FROM [fonteindicebibliometrico] WHERE idfonteindicebibliometrico = '2')
UPDATE [fonteindicebibliometrico] SET active = 'S',ct = {d '2003-11-20'},cu = 'ferdinando',description = null,lt = {d '2003-11-20'},lu = 'ferdinando',sortcode = '2',title = 'Scopus' WHERE idfonteindicebibliometrico = '2'
ELSE
INSERT INTO [fonteindicebibliometrico] (idfonteindicebibliometrico,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{d '2003-11-20'},'ferdinando',null,{d '2003-11-20'},'ferdinando','2','Scopus')
GO

