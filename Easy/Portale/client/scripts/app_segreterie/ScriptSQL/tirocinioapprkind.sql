
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
-- CREAZIONE TABELLA tirocinioapprkind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirocinioapprkind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tirocinioapprkind] (
idtirocinioapprkind int NOT NULL,
active char(1) NULL,
ct datetime NULL,
cu varchar(60) NULL,
lt datetime NULL,
lu varchar(60) NULL,
sortcode int NULL,
title varchar(256) NULL,
 CONSTRAINT xpktirocinioapprkind PRIMARY KEY (idtirocinioapprkind
)
)
END
GO

-- VERIFICA STRUTTURA tirocinioapprkind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'idtirocinioapprkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD idtirocinioapprkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioapprkind') and col.name = 'idtirocinioapprkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioapprkind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD active char(1) NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN active char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioapprkind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioapprkind] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [tirocinioapprkind] ALTER COLUMN title varchar(256) NULL
GO

-- VERIFICA DI tirocinioapprkind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirocinioapprkind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioapprkind','int','assistenza','idtirocinioapprkind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','char(1)','assistenza','active','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioapprkind','varchar(256)','assistenza','title','256','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI tirocinioapprkind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirocinioapprkind')
UPDATE customobject set isreal = 'S' where objectname = 'tirocinioapprkind'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirocinioapprkind', 'S')
GO

-- GENERAZIONE DATI PER tirocinioapprkind --
IF exists(SELECT * FROM [tirocinioapprkind] WHERE idtirocinioapprkind = '1')
UPDATE [tirocinioapprkind] SET active = 'S',ct = {ts '2020-09-03 18:35:02.530'},cu = 'ferdinando',lt = {ts '2020-09-03 18:35:02.530'},lu = 'ferdinando',sortcode = '1',title = 'Approvazione da parte dello studente' WHERE idtirocinioapprkind = '1'
ELSE
INSERT INTO [tirocinioapprkind] (idtirocinioapprkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('1','S',{ts '2020-09-03 18:35:02.530'},'ferdinando',{ts '2020-09-03 18:35:02.530'},'ferdinando','1','Approvazione da parte dello studente')
GO

IF exists(SELECT * FROM [tirocinioapprkind] WHERE idtirocinioapprkind = '2')
UPDATE [tirocinioapprkind] SET active = 'S',ct = {ts '2020-09-03 18:35:02.530'},cu = 'ferdinando',lt = {ts '2020-09-03 18:35:02.530'},lu = 'ferdinando',sortcode = '2',title = 'Approvazione da parte del tutor di ateneo' WHERE idtirocinioapprkind = '2'
ELSE
INSERT INTO [tirocinioapprkind] (idtirocinioapprkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('2','S',{ts '2020-09-03 18:35:02.530'},'ferdinando',{ts '2020-09-03 18:35:02.530'},'ferdinando','2','Approvazione da parte del tutor di ateneo')
GO

IF exists(SELECT * FROM [tirocinioapprkind] WHERE idtirocinioapprkind = '3')
UPDATE [tirocinioapprkind] SET active = 's',ct = {ts '2020-09-03 18:35:02.530'},cu = 'ferdinando',lt = {ts '2020-09-03 18:35:02.530'},lu = 'ferdinando',sortcode = '3',title = 'Approvazione da parte del tutor aziendale' WHERE idtirocinioapprkind = '3'
ELSE
INSERT INTO [tirocinioapprkind] (idtirocinioapprkind,active,ct,cu,lt,lu,sortcode,title) VALUES ('3','s',{ts '2020-09-03 18:35:02.530'},'ferdinando',{ts '2020-09-03 18:35:02.530'},'ferdinando','3','Approvazione da parte del tutor aziendale')
GO

-- FINE GENERAZIONE SCRIPT --

