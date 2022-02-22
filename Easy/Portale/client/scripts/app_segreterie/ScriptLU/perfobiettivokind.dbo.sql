
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


-- CREAZIONE TABELLA perfobiettivokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfobiettivokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfobiettivokind] (
idperfobiettivokind int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(max) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(1024) NULL,
 CONSTRAINT xpkperfobiettivokind PRIMARY KEY (idperfobiettivokind
)
)
END
GO

-- VERIFICA STRUTTURA perfobiettivokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'idperfobiettivokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD idperfobiettivokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfobiettivokind') and col.name = 'idperfobiettivokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfobiettivokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfobiettivokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfobiettivokind] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [perfobiettivokind] ALTER COLUMN title varchar(1024) NULL
GO


-- GENERAZIONE DATI PER perfobiettivokind --
IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '1')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:54:28.633'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:55:01.710'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi strategici dei progetti' WHERE idperfobiettivokind = '1'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('1','S',{ts '2022-02-16 10:54:28.633'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:55:01.710'},'prima.div.1{PERFADM}','Obiettivi strategici dei progetti')
GO

IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '2')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:54:43.773'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:54:56.827'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi strategici di ateneo' WHERE idperfobiettivokind = '2'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('2','S',{ts '2022-02-16 10:54:43.773'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:54:56.827'},'prima.div.1{PERFADM}','Obiettivi strategici di ateneo')
GO

IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '3')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:55:18.513'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:55:58.230'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi comportamentali' WHERE idperfobiettivokind = '3'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('3','S',{ts '2022-02-16 10:55:18.513'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:55:58.230'},'prima.div.1{PERFADM}','Obiettivi comportamentali')
GO

IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '5')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:56:27.510'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:56:57.993'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi  organizzativi ' WHERE idperfobiettivokind = '5'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('5','S',{ts '2022-02-16 10:56:27.510'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:56:57.993'},'prima.div.1{PERFADM}','Obiettivi  organizzativi ')
GO

IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '6')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:56:44.970'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:56:44.970'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi individuali' WHERE idperfobiettivokind = '6'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('6','S',{ts '2022-02-16 10:56:44.970'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:56:44.970'},'prima.div.1{PERFADM}','Obiettivi individuali')
GO

IF exists(SELECT * FROM [perfobiettivokind] WHERE idperfobiettivokind = '7')
UPDATE [perfobiettivokind] SET active = 'S',ct = {ts '2022-02-16 10:57:37.907'},cu = 'prima.div.1{PERFADM}',description = null,lt = {ts '2022-02-16 10:57:37.907'},lu = 'prima.div.1{PERFADM}',title = 'Obiettivi una tantum' WHERE idperfobiettivokind = '7'
ELSE
INSERT INTO [perfobiettivokind] (idperfobiettivokind,active,ct,cu,description,lt,lu,title) VALUES ('7','S',{ts '2022-02-16 10:57:37.907'},'prima.div.1{PERFADM}',null,{ts '2022-02-16 10:57:37.907'},'prima.div.1{PERFADM}','Obiettivi una tantum')
GO

