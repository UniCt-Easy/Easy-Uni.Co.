
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


-- CREAZIONE TABELLA appelloazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[appelloazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[appelloazionekind] (
idappelloazionekind int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(250) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkappelloazionekind PRIMARY KEY (idappelloazionekind
)
)
END
GO

-- VERIFICA STRUTTURA appelloazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'idappelloazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD idappelloazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'idappelloazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD description varchar(250) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN description varchar(250) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'appelloazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [appelloazionekind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('appelloazionekind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [appelloazionekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [appelloazionekind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER appelloazionekind --
IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '1')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello normale',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'Ordinario' WHERE idappelloazionekind = '1'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello normale',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','Ordinario')
GO

IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '2')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello utilizzato per la modifica di un voto',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Correttivo' WHERE idappelloazionekind = '2'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello utilizzato per la modifica di un voto',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Correttivo')
GO

IF exists(SELECT * FROM [appelloazionekind] WHERE idappelloazionekind = '3')
UPDATE [appelloazionekind] SET active = 'S',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Appello utilizzato per aggiungere votazioni mancanti di studenti',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Integrativo' WHERE idappelloazionekind = '3'
ELSE
INSERT INTO [appelloazionekind] (idappelloazionekind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2018-06-11 11:35:00.653'},'ferdinando','Appello utilizzato per aggiungere votazioni mancanti di studenti',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Integrativo')
GO

