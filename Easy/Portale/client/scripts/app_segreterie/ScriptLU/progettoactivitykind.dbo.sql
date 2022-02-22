
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


-- CREAZIONE TABELLA progettoactivitykind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoactivitykind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoactivitykind] (
idprogettoactivitykind int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettoactivitykind PRIMARY KEY (idprogettoactivitykind
)
)
END
GO

-- VERIFICA STRUTTURA progettoactivitykind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'idprogettoactivitykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD idprogettoactivitykind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoactivitykind') and col.name = 'idprogettoactivitykind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoactivitykind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoactivitykind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoactivitykind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoactivitykind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoactivitykind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoactivitykind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoactivitykind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoactivitykind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoactivitykind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoactivitykind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoactivitykind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoactivitykind] ALTER COLUMN title nvarchar(2048) NULL
GO


-- GENERAZIONE DATI PER progettoactivitykind --
IF exists(SELECT * FROM [progettoactivitykind] WHERE idprogettoactivitykind = '1')
UPDATE [progettoactivitykind] SET active = 'S',ct = {d '2019-12-23'},cu = 'ferdinando',description = 'Progetti di ricerca istituzionali finalizzati a svolgere attività di ricerca.',lt = {ts '2020-06-12 10:19:13.077'},lu = 'riccardotest{0001}',sortcode = '1',title = 'Progetti di ricerca istituzionali' WHERE idprogettoactivitykind = '1'
ELSE
INSERT INTO [progettoactivitykind] (idprogettoactivitykind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('1','S',{d '2019-12-23'},'ferdinando','Progetti di ricerca istituzionali finalizzati a svolgere attività di ricerca.',{ts '2020-06-12 10:19:13.077'},'riccardotest{0001}','1','Progetti di ricerca istituzionali')
GO

IF exists(SELECT * FROM [progettoactivitykind] WHERE idprogettoactivitykind = '2')
UPDATE [progettoactivitykind] SET active = 'S',ct = {d '2019-12-23'},cu = 'ferdinando',description = 'Attività svolte dall''istituto per le quali è necessaria una pianificazione economica e strumentale.',lt = {ts '2020-07-14 10:16:17.117'},lu = 'riccardotest{DIRETTORI}',sortcode = '2',title = 'Attività istituzionali' WHERE idprogettoactivitykind = '2'
ELSE
INSERT INTO [progettoactivitykind] (idprogettoactivitykind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('2','S',{d '2019-12-23'},'ferdinando','Attività svolte dall''istituto per le quali è necessaria una pianificazione economica e strumentale.',{ts '2020-07-14 10:16:17.117'},'riccardotest{DIRETTORI}','2','Attività istituzionali')
GO

IF exists(SELECT * FROM [progettoactivitykind] WHERE idprogettoactivitykind = '3')
UPDATE [progettoactivitykind] SET active = 'S',ct = {d '2019-12-23'},cu = 'ferdinando',description = 'Master o altre didattiche finanziate da enti pubblici o privati diversi dal MIUR.',lt = {ts '2020-07-14 10:16:24.757'},lu = 'riccardotest{DIRETTORI}',sortcode = '3',title = 'Attività didattiche' WHERE idprogettoactivitykind = '3'
ELSE
INSERT INTO [progettoactivitykind] (idprogettoactivitykind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('3','S',{d '2019-12-23'},'ferdinando','Master o altre didattiche finanziate da enti pubblici o privati diversi dal MIUR.',{ts '2020-07-14 10:16:24.757'},'riccardotest{DIRETTORI}','3','Attività didattiche')
GO

IF exists(SELECT * FROM [progettoactivitykind] WHERE idprogettoactivitykind = '4')
UPDATE [progettoactivitykind] SET active = 'S',ct = {d '2019-12-23'},cu = 'ferdinando',description = 'Progetti di ricerca finalizzati a svolgere attività comerciali.',lt = {ts '2020-06-12 10:19:38.757'},lu = 'riccardotest{0001}',sortcode = '4',title = 'Progetti di ricerca commerciali' WHERE idprogettoactivitykind = '4'
ELSE
INSERT INTO [progettoactivitykind] (idprogettoactivitykind,active,ct,cu,description,lt,lu,sortcode,title) VALUES ('4','S',{d '2019-12-23'},'ferdinando','Progetti di ricerca finalizzati a svolgere attività comerciali.',{ts '2020-06-12 10:19:38.757'},'riccardotest{0001}','4','Progetti di ricerca commerciali')
GO

