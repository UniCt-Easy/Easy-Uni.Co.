
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


-- CREAZIONE TABELLA protocollodockind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[protocollodockind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[protocollodockind] (
idprotocollodockind int NOT NULL,
active char(1) NOT NULL,
description varchar(256) NOT NULL,
kind varchar(50) NOT NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkprotocollodockind PRIMARY KEY (idprotocollodockind
)
)
END
GO

-- VERIFICA STRUTTURA protocollodockind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'idprotocollodockind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD idprotocollodockind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'idprotocollodockind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD description varchar(256) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN description varchar(256) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'kind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD kind varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'kind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN kind varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'protocollodockind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [protocollodockind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('protocollodockind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [protocollodockind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [protocollodockind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER protocollodockind --
IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '0')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Ingresso',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Documento di riconoscimento' WHERE idprotocollodockind = '0'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('0','S','','Ingresso',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Documento di riconoscimento')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '1')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Ingresso',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Dichiarazione' WHERE idprotocollodockind = '1'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('1','S','','Ingresso',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Dichiarazione')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '2')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Ingresso',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Istanza' WHERE idprotocollodockind = '2'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('2','S','','Ingresso',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Istanza')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '3')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Ingresso',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '4',title = 'Documento' WHERE idprotocollodockind = '3'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('3','S','','Ingresso',{ts '2019-02-28 18:02:19.867'},'Ferdinando','4','Documento')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '4')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Interno',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Delibera' WHERE idprotocollodockind = '4'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('4','S','','Interno',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Delibera')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '5')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Interno',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Documento' WHERE idprotocollodockind = '5'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('5','S','','Interno',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Documento')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '6')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Uscita',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '1',title = 'Nullaosta' WHERE idprotocollodockind = '6'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('6','S','','Uscita',{ts '2019-02-28 18:02:19.867'},'Ferdinando','1','Nullaosta')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '7')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Uscita',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '2',title = 'Diniego' WHERE idprotocollodockind = '7'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('7','S','','Uscita',{ts '2019-02-28 18:02:19.867'},'Ferdinando','2','Diniego')
GO

IF exists(SELECT * FROM [protocollodockind] WHERE idprotocollodockind = '8')
UPDATE [protocollodockind] SET active = 'S',description = '',kind = 'Uscita',lt = {ts '2019-02-28 18:02:19.867'},lu = 'Ferdinando',sortcode = '3',title = 'Documento' WHERE idprotocollodockind = '8'
ELSE
INSERT INTO [protocollodockind] (idprotocollodockind,active,description,kind,lt,lu,sortcode,title) VALUES ('8','S','','Uscita',{ts '2019-02-28 18:02:19.867'},'Ferdinando','3','Documento')
GO

