
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


-- CREAZIONE TABELLA validatori --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[validatori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[validatori] (
idvalidatori int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkvalidatori PRIMARY KEY (idvalidatori
)
)
END
GO

-- VERIFICA STRUTTURA validatori --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'idvalidatori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD idvalidatori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('validatori') and col.name = 'idvalidatori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [validatori] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [validatori] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [validatori] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [validatori] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [validatori] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'validatori' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [validatori] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [validatori] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER validatori --
IF exists(SELECT * FROM [validatori] WHERE idvalidatori = '1')
UPDATE [validatori] SET ct = {ts '2021-06-01 10:58:32.637'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-06-01 10:58:32.637'},lu = 'seg_fcaprilli{SEGADM}',title = 'Nucleo di valutazione' WHERE idvalidatori = '1'
ELSE
INSERT INTO [validatori] (idvalidatori,ct,cu,lt,lu,title) VALUES ('1',{ts '2021-06-01 10:58:32.637'},'seg_fcaprilli{SEGADM}',{ts '2021-06-01 10:58:32.637'},'seg_fcaprilli{SEGADM}','Nucleo di valutazione')
GO

IF exists(SELECT * FROM [validatori] WHERE idvalidatori = '2')
UPDATE [validatori] SET ct = {ts '2021-06-01 11:16:33.077'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-06-01 11:16:33.077'},lu = 'seg_fcaprilli{SEGADM}',title = 'Collegio dei revisori' WHERE idvalidatori = '2'
ELSE
INSERT INTO [validatori] (idvalidatori,ct,cu,lt,lu,title) VALUES ('2',{ts '2021-06-01 11:16:33.077'},'seg_fcaprilli{SEGADM}',{ts '2021-06-01 11:16:33.077'},'seg_fcaprilli{SEGADM}','Collegio dei revisori')
GO

