
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


-- CREAZIONE TABELLA progettoudrmembrokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoudrmembrokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoudrmembrokind] (
idprogettoudrmembrokind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(2048) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title varchar(50) NULL,
 CONSTRAINT xpkprogettoudrmembrokind PRIMARY KEY (idprogettoudrmembrokind
)
)
END
GO

-- VERIFICA STRUTTURA progettoudrmembrokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'idprogettoudrmembrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD idprogettoudrmembrokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'idprogettoudrmembrokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD description varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN description varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembrokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembrokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembrokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembrokind] ADD title varchar(50) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembrokind] ALTER COLUMN title varchar(50) NULL
GO


-- GENERAZIONE DATI PER progettoudrmembrokind --
IF exists(SELECT * FROM [progettoudrmembrokind] WHERE idprogettoudrmembrokind = '1')
UPDATE [progettoudrmembrokind] SET active = 'S',ct = {ts '2020-06-02 21:49:48.130'},cu = 'ferdinando',description = null,lt = {ts '2020-06-02 21:49:48.130'},lu = 'ferdinando',sortcode = '1',title = 'Membro' WHERE idprogettoudrmembrokind = '1'
ELSE
INSERT INTO [progettoudrmembrokind] (idprogettoudrmembrokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{ts '2020-06-02 21:49:48.130'},'ferdinando',null,{ts '2020-06-02 21:49:48.130'},'ferdinando','1','Membro')
GO

IF exists(SELECT * FROM [progettoudrmembrokind] WHERE idprogettoudrmembrokind = '2')
UPDATE [progettoudrmembrokind] SET active = 'S',ct = {ts '2020-06-02 21:49:48.130'},cu = 'ferdinando',description = null,lt = {ts '2020-06-02 21:49:48.130'},lu = 'ferdinando',sortcode = '2',title = 'Responsabile scientifico' WHERE idprogettoudrmembrokind = '2'
ELSE
INSERT INTO [progettoudrmembrokind] (idprogettoudrmembrokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{ts '2020-06-02 21:49:48.130'},'ferdinando',null,{ts '2020-06-02 21:49:48.130'},'ferdinando','2','Responsabile scientifico')
GO

IF exists(SELECT * FROM [progettoudrmembrokind] WHERE idprogettoudrmembrokind = '3')
UPDATE [progettoudrmembrokind] SET active = 'S',ct = {ts '2020-06-02 21:49:48.130'},cu = 'ferdinando',description = null,lt = {ts '2020-06-02 21:49:48.130'},lu = 'ferdinando',sortcode = '3',title = 'Responsabile amministrativo' WHERE idprogettoudrmembrokind = '3'
ELSE
INSERT INTO [progettoudrmembrokind] (idprogettoudrmembrokind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{ts '2020-06-02 21:49:48.130'},'ferdinando',null,{ts '2020-06-02 21:49:48.130'},'ferdinando','3','Responsabile amministrativo')
GO

