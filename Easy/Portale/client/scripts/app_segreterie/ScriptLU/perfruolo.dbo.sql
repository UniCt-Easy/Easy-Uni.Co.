
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


-- CREAZIONE TABELLA perfruolo --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfruolo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfruolo] (
idperfruolo varchar(50) NOT NULL,
aggiorna char(1) NULL,
crea char(1) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
leggi char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oper char(1) NULL,
valuta char(1) NULL,
 CONSTRAINT xpkperfruolo PRIMARY KEY (idperfruolo
)
)
END
GO

-- VERIFICA STRUTTURA perfruolo --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'idperfruolo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD idperfruolo varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'idperfruolo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'aggiorna' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD aggiorna char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN aggiorna char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'crea' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD crea char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN crea char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'leggi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD leggi char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN leggi char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfruolo') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfruolo] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'oper' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD oper char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN oper char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfruolo' and C.name = 'valuta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfruolo] ADD valuta char(1) NULL 
END
ELSE
	ALTER TABLE [perfruolo] ALTER COLUMN valuta char(1) NULL
GO


-- GENERAZIONE DATI PER perfruolo --
IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Approvatore')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.023'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.023'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Approvatore'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Approvatore',null,null,{ts '2022-02-08 12:58:04.023'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.023'},'seg_psuma{SEGADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Responsabile')
UPDATE [perfruolo] SET aggiorna = 'S',crea = null,ct = {ts '2022-02-08 12:58:04.103'},cu = 'seg_psuma{SEGADM}',leggi = 'S',lt = {ts '2022-02-16 11:12:34.720'},lu = 'prima.div.1{PERFADM}',oper = null,valuta = null WHERE idperfruolo = 'Responsabile'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Responsabile','S',null,{ts '2022-02-08 12:58:04.103'},'seg_psuma{SEGADM}','S',{ts '2022-02-16 11:12:34.720'},'prima.div.1{PERFADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Valutato')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.107'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.107'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Valutato'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Valutato',null,null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,null)
GO

IF exists(SELECT * FROM [perfruolo] WHERE idperfruolo = 'Valutatore')
UPDATE [perfruolo] SET aggiorna = null,crea = null,ct = {ts '2022-02-08 12:58:04.107'},cu = 'seg_psuma{SEGADM}',leggi = null,lt = {ts '2022-02-08 12:58:04.107'},lu = 'seg_psuma{SEGADM}',oper = null,valuta = null WHERE idperfruolo = 'Valutatore'
ELSE
INSERT INTO [perfruolo] (idperfruolo,aggiorna,crea,ct,cu,leggi,lt,lu,oper,valuta) VALUES ('Valutatore',null,null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,{ts '2022-02-08 12:58:04.107'},'seg_psuma{SEGADM}',null,null)
GO

