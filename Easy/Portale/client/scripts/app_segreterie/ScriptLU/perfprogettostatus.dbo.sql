
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


-- CREAZIONE TABELLA perfprogettostatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettostatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfprogettostatus] (
idperfprogettostatus int NOT NULL,
active char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfprogettostatus PRIMARY KEY (idperfprogettostatus
)
)
END
GO

-- VERIFICA STRUTTURA perfprogettostatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'idperfprogettostatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD idperfprogettostatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'idperfprogettostatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfprogettostatus') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfprogettostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfprogettostatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfprogettostatus] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfprogettostatus] ALTER COLUMN title varchar(1024) NULL
GO


-- GENERAZIONE DATI PER perfprogettostatus --
IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '1')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.607'},cu = 'seg_psuma',description = 'In corso',lt = {ts '2021-05-24 13:15:52.607'},lu = 'seg_psuma',title = 'In corso' WHERE idperfprogettostatus = '1'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('1','S',{ts '2021-05-24 13:15:52.607'},'seg_psuma','In corso',{ts '2021-05-24 13:15:52.607'},'seg_psuma','In corso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '2')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.687'},cu = 'seg_psuma',description = 'Concluso',lt = {ts '2021-05-24 13:15:52.687'},lu = 'seg_psuma',title = 'Concluso' WHERE idperfprogettostatus = '2'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('2','S',{ts '2021-05-24 13:15:52.687'},'seg_psuma','Concluso',{ts '2021-05-24 13:15:52.687'},'seg_psuma','Concluso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '3')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-05-24 13:15:52.763'},cu = 'seg_psuma',description = 'Sospeso',lt = {ts '2021-05-24 13:15:52.763'},lu = 'seg_psuma',title = 'Sospeso' WHERE idperfprogettostatus = '3'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('3','S',{ts '2021-05-24 13:15:52.763'},'seg_psuma','Sospeso',{ts '2021-05-24 13:15:52.763'},'seg_psuma','Sospeso')
GO

IF exists(SELECT * FROM [perfprogettostatus] WHERE idperfprogettostatus = '4')
UPDATE [perfprogettostatus] SET active = 'S',ct = {ts '2021-07-23 15:32:51.940'},cu = 'ferdinando.giannetti{SEGADM}',description = 'Da utilizzare come primo status in fase di ideazione del progetto strategico.',lt = {ts '2021-07-23 15:33:26.530'},lu = 'ferdinando.giannetti{SEGADM}',title = 'In bozza' WHERE idperfprogettostatus = '4'
ELSE
INSERT INTO [perfprogettostatus] (idperfprogettostatus,active,ct,cu,description,lt,lu,title) VALUES ('4','S',{ts '2021-07-23 15:32:51.940'},'ferdinando.giannetti{SEGADM}','Da utilizzare come primo status in fase di ideazione del progetto strategico.',{ts '2021-07-23 15:33:26.530'},'ferdinando.giannetti{SEGADM}','In bozza')
GO

