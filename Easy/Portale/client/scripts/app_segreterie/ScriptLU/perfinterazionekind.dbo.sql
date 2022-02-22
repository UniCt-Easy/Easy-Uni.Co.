
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


-- CREAZIONE TABELLA perfinterazionekind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfinterazionekind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfinterazionekind] (
idperfinterazionekind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkperfinterazionekind PRIMARY KEY (idperfinterazionekind
)
)
END
GO

-- VERIFICA STRUTTURA perfinterazionekind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'idperfinterazionekind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD idperfinterazionekind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfinterazionekind') and col.name = 'idperfinterazionekind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfinterazionekind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfinterazionekind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfinterazionekind] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfinterazionekind] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER perfinterazionekind --
IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '1')
UPDATE [perfinterazionekind] SET ct = {ts '2021-07-23 12:58:47.030'},cu = 'seg_psuma{SEGADM}',lt = {ts '2021-07-23 12:58:47.030'},lu = 'seg_psuma{SEGADM}',title = 'Colloquio' WHERE idperfinterazionekind = '1'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('1',{ts '2021-07-23 12:58:47.030'},'seg_psuma{SEGADM}',{ts '2021-07-23 12:58:47.030'},'seg_psuma{SEGADM}','Colloquio')
GO

IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '2')
UPDATE [perfinterazionekind] SET ct = {ts '2021-07-23 12:59:01.033'},cu = 'seg_psuma{SEGADM}',lt = {ts '2021-07-23 12:59:01.033'},lu = 'seg_psuma{SEGADM}',title = 'Risposta' WHERE idperfinterazionekind = '2'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('2',{ts '2021-07-23 12:59:01.033'},'seg_psuma{SEGADM}',{ts '2021-07-23 12:59:01.033'},'seg_psuma{SEGADM}','Risposta')
GO

IF exists(SELECT * FROM [perfinterazionekind] WHERE idperfinterazionekind = '3')
UPDATE [perfinterazionekind] SET ct = {ts '2021-10-01 15:33:45.147'},cu = 'seg_psuma{PERFADM}',lt = {ts '2021-10-01 15:33:45.147'},lu = 'seg_psuma{PERFADM}',title = 'Riunione' WHERE idperfinterazionekind = '3'
ELSE
INSERT INTO [perfinterazionekind] (idperfinterazionekind,ct,cu,lt,lu,title) VALUES ('3',{ts '2021-10-01 15:33:45.147'},'seg_psuma{PERFADM}',{ts '2021-10-01 15:33:45.147'},'seg_psuma{PERFADM}','Riunione')
GO

