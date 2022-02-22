
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


--[DBO]--
-- CREAZIONE TABELLA pianostudiostatus --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pianostudiostatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[pianostudiostatus] (
idpianostudiostatus int NOT NULL,
active char(1) NOT NULL,
description nvarchar(256) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NOT NULL,
title varchar(50) NOT NULL,
 CONSTRAINT xpkpianostudiostatus PRIMARY KEY (idpianostudiostatus
)
)
END
GO

-- VERIFICA STRUTTURA pianostudiostatus --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'idpianostudiostatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD idpianostudiostatus int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'idpianostudiostatus' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD description nvarchar(256) NULL 
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN description nvarchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pianostudiostatus' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [pianostudiostatus] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('pianostudiostatus') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [pianostudiostatus] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [pianostudiostatus] ALTER COLUMN title varchar(50) NOT NULL
GO

-- VERIFICA DI pianostudiostatus IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pianostudiostatus'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','int','ASSISTENZA','idpianostudiostatus','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pianostudiostatus','nvarchar(256)','ASSISTENZA','description','256','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pianostudiostatus','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pianostudiostatus IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pianostudiostatus')
UPDATE customobject set isreal = 'S' where objectname = 'pianostudiostatus'
ELSE
INSERT INTO customobject (objectname, isreal) values('pianostudiostatus', 'S')
GO

-- GENERAZIONE DATI PER pianostudiostatus --
IF exists(SELECT * FROM [pianostudiostatus] WHERE idpianostudiostatus = '1')
UPDATE [pianostudiostatus] SET active = 'S',description = 'Il piano è stato salvato dallo studente in modo da poter concludere le modifiche successivamente.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '1',title = 'In bozza' WHERE idpianostudiostatus = '1'
ELSE
INSERT INTO [pianostudiostatus] (idpianostudiostatus,active,description,lt,lu,sortcode,title) VALUES ('1','S','Il piano è stato salvato dallo studente in modo da poter concludere le modifiche successivamente.',{ts '2018-06-11 11:35:00.653'},'ferdinando','1','In bozza')
GO

IF exists(SELECT * FROM [pianostudiostatus] WHERE idpianostudiostatus = '2')
UPDATE [pianostudiostatus] SET active = 'S',description = 'Il piano è stato compilato dallo studente, che ora ne chiade l’approvazione',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '2',title = 'Sottomesso alla approvazione' WHERE idpianostudiostatus = '2'
ELSE
INSERT INTO [pianostudiostatus] (idpianostudiostatus,active,description,lt,lu,sortcode,title) VALUES ('2','S','Il piano è stato compilato dallo studente, che ora ne chiade l’approvazione',{ts '2018-06-11 11:35:00.653'},'ferdinando','2','Sottomesso alla approvazione')
GO

IF exists(SELECT * FROM [pianostudiostatus] WHERE idpianostudiostatus = '3')
UPDATE [pianostudiostatus] SET active = 'S',description = 'Il piano di studio è stato approvato ed è il piano attualmente vigente per la carriera dello studente.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '3',title = 'Approvato' WHERE idpianostudiostatus = '3'
ELSE
INSERT INTO [pianostudiostatus] (idpianostudiostatus,active,description,lt,lu,sortcode,title) VALUES ('3','S','Il piano di studio è stato approvato ed è il piano attualmente vigente per la carriera dello studente.',{ts '2018-06-11 11:35:00.653'},'ferdinando','3','Approvato')
GO

IF exists(SELECT * FROM [pianostudiostatus] WHERE idpianostudiostatus = '4')
UPDATE [pianostudiostatus] SET active = 'S',description = 'Il piano di studi non è stato approvato ',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '4',title = 'Rifiutato' WHERE idpianostudiostatus = '4'
ELSE
INSERT INTO [pianostudiostatus] (idpianostudiostatus,active,description,lt,lu,sortcode,title) VALUES ('4','S','Il piano di studi non è stato approvato ',{ts '2018-06-11 11:35:00.653'},'ferdinando','4','Rifiutato')
GO

IF exists(SELECT * FROM [pianostudiostatus] WHERE idpianostudiostatus = '5')
UPDATE [pianostudiostatus] SET active = 'S',description = 'Il piano di studi è stato annullato successivamente alla sua approvazione e non è più valido per la carriera dello studente.',lt = {ts '2018-06-11 11:35:00.653'},lu = 'ferdinando',sortcode = '5',title = 'Annullato' WHERE idpianostudiostatus = '5'
ELSE
INSERT INTO [pianostudiostatus] (idpianostudiostatus,active,description,lt,lu,sortcode,title) VALUES ('5','S','Il piano di studi è stato annullato successivamente alla sua approvazione e non è più valido per la carriera dello studente.',{ts '2018-06-11 11:35:00.653'},'ferdinando','5','Annullato')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'pianostudiostatus')
UPDATE [tabledescr] SET description = 'VOCABOLARIO degli stati di un 2.2.3 Piano di studi',idapplication = null,isdbo = 'N',lt = {ts '2018-07-20 15:48:19.817'},lu = 'assistenza',title = 'Stati di un piano di studi' WHERE tablename = 'pianostudiostatus'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('pianostudiostatus','VOCABOLARIO degli stati di un 2.2.3 Piano di studi',null,'N',{ts '2018-07-20 15:48:19.817'},'assistenza','Stati di un piano di studi')
GO

-- FINE GENERAZIONE SCRIPT --

