
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


-- CREAZIONE TABELLA pagamentokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pagamentokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pagamentokind] (
idpagamentokind int NOT NULL,
active char(1) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkpagamentokind PRIMARY KEY (idpagamentokind
)
)
END
GO

-- VERIFICA STRUTTURA pagamentokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'idpagamentokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD idpagamentokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'idpagamentokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pagamentokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pagamentokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pagamentokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pagamentokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pagamentokind] ALTER COLUMN title varchar(50) NOT NULL
GO


-- GENERAZIONE DATI PER pagamentokind --
IF exists(SELECT * FROM [pagamentokind] WHERE idpagamentokind = '1')
UPDATE [pagamentokind] SET active = 'S',ct = {ts '2020-01-07 11:15:43.713'},cu = 'riccardotest',lt = {ts '2020-01-07 11:22:06.253'},lu = 'riccardotest',sortcode = '1',title = 'Pago-PA MyPay' WHERE idpagamentokind = '1'
ELSE
INSERT INTO [pagamentokind] (idpagamentokind,active,ct,cu,lt,lu,sortcode,title) VALUES ('1','S',{ts '2020-01-07 11:15:43.713'},'riccardotest',{ts '2020-01-07 11:22:06.253'},'riccardotest','1','Pago-PA MyPay')
GO

IF exists(SELECT * FROM [pagamentokind] WHERE idpagamentokind = '2')
UPDATE [pagamentokind] SET active = 'S',ct = {ts '2020-01-07 11:22:31.673'},cu = 'riccardotest',lt = {ts '2020-01-07 11:22:31.673'},lu = 'riccardotest',sortcode = '2',title = 'Pago-PA ESU Padova' WHERE idpagamentokind = '2'
ELSE
INSERT INTO [pagamentokind] (idpagamentokind,active,ct,cu,lt,lu,sortcode,title) VALUES ('2','S',{ts '2020-01-07 11:22:31.673'},'riccardotest',{ts '2020-01-07 11:22:31.673'},'riccardotest','2','Pago-PA ESU Padova')
GO

