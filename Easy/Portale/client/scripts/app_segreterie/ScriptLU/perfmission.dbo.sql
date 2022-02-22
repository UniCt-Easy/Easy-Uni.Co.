
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


-- CREAZIONE TABELLA perfmission --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfmission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[perfmission] (
idperfmission int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkperfmission PRIMARY KEY (idperfmission
)
)
END
GO

-- VERIFICA STRUTTURA perfmission --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'idperfmission' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD idperfmission int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('perfmission') and col.name = 'idperfmission' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [perfmission] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'perfmission' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [perfmission] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [perfmission] ALTER COLUMN title varchar(2048) NULL
GO


-- GENERAZIONE DATI PER perfmission --
IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '1')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:09.143'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:27.050'},lu = 'seg_fcaprilli{SEGADM}',title = 'Didattica' WHERE idperfmission = '1'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('1',{ts '2021-05-31 14:28:09.143'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:27.050'},'seg_fcaprilli{SEGADM}','Didattica')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '2')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:36.273'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:36.273'},lu = 'seg_fcaprilli{SEGADM}',title = 'Ricerca' WHERE idperfmission = '2'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('2',{ts '2021-05-31 14:28:36.273'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:36.273'},'seg_fcaprilli{SEGADM}','Ricerca')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '3')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:28:51.353'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:28:51.353'},lu = 'seg_fcaprilli{SEGADM}',title = 'Amministrazione e finanza' WHERE idperfmission = '3'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('3',{ts '2021-05-31 14:28:51.353'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:28:51.353'},'seg_fcaprilli{SEGADM}','Amministrazione e finanza')
GO

IF exists(SELECT * FROM [perfmission] WHERE idperfmission = '4')
UPDATE [perfmission] SET ct = {ts '2021-05-31 14:29:05.007'},cu = 'seg_fcaprilli{SEGADM}',lt = {ts '2021-05-31 14:29:05.007'},lu = 'seg_fcaprilli{SEGADM}',title = 'Trasparenza e anticorruzione' WHERE idperfmission = '4'
ELSE
INSERT INTO [perfmission] (idperfmission,ct,cu,lt,lu,title) VALUES ('4',{ts '2021-05-31 14:29:05.007'},'seg_fcaprilli{SEGADM}',{ts '2021-05-31 14:29:05.007'},'seg_fcaprilli{SEGADM}','Trasparenza e anticorruzione')
GO

