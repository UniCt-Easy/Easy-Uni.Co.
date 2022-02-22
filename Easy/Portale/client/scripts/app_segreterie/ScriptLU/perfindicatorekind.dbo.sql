
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


-- CREAZIONE TABELLA perfindicatorekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfindicatorekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfindicatorekind] (
idperfindicatorekind int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfindicatorekind PRIMARY KEY (idperfindicatorekind
)
)
END
GO

-- VERIFICA STRUTTURA perfindicatorekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'idperfindicatorekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD idperfindicatorekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfindicatorekind') and col.name = 'idperfindicatorekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfindicatorekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfindicatorekind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfindicatorekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfindicatorekind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfindicatorekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfindicatorekind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfindicatorekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfindicatorekind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfindicatorekind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfindicatorekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfindicatorekind] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfindicatorekind] ALTER COLUMN title varchar(1024) NULL
GO


-- GENERAZIONE DATI PER perfindicatorekind --
IF exists(SELECT * FROM [perfindicatorekind] WHERE idperfindicatorekind = '1')
UPDATE [perfindicatorekind] SET ct = {ts '2021-06-10 11:57:00.280'},cu = 'seg_psuma{SEGADM}',description = 'Good Practices',lt = {ts '2021-06-10 11:57:50.357'},lu = 'seg_psuma{SEGADM}',title = 'Good Practices' WHERE idperfindicatorekind = '1'
ELSE
INSERT INTO [perfindicatorekind] (idperfindicatorekind,ct,cu,description,lt,lu,title) VALUES ('1',{ts '2021-06-10 11:57:00.280'},'seg_psuma{SEGADM}','Good Practices',{ts '2021-06-10 11:57:50.357'},'seg_psuma{SEGADM}','Good Practices')
GO

IF exists(SELECT * FROM [perfindicatorekind] WHERE idperfindicatorekind = '2')
UPDATE [perfindicatorekind] SET ct = {ts '2021-06-10 11:58:01.037'},cu = 'seg_psuma{SEGADM}',description = 'Nucleo di valutazione',lt = {ts '2021-06-10 11:58:01.037'},lu = 'seg_psuma{SEGADM}',title = 'Nucleo di valutazione' WHERE idperfindicatorekind = '2'
ELSE
INSERT INTO [perfindicatorekind] (idperfindicatorekind,ct,cu,description,lt,lu,title) VALUES ('2',{ts '2021-06-10 11:58:01.037'},'seg_psuma{SEGADM}','Nucleo di valutazione',{ts '2021-06-10 11:58:01.037'},'seg_psuma{SEGADM}','Nucleo di valutazione')
GO

