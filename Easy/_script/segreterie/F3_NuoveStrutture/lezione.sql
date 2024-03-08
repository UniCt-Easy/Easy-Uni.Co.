
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
-- CREAZIONE TABELLA lezione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[lezione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[lezione] (
idlezione int NOT NULL,
idaffidamento int NOT NULL,
idcanale int NOT NULL,
idattivform int NOT NULL,
iddidprogporzanno int NOT NULL,
iddidproganno int NOT NULL,
iddidprogori int NOT NULL,
iddidprogcurr int NOT NULL,
iddidprog int NOT NULL,
idaula int NOT NULL,
idsede int NOT NULL,
idedificio int NOT NULL,
idcorsostudio int NOT NULL,
aa varchar(9) NOT NULL,
idreg_docenti int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
nonsvolta char(1) NULL,
stage char(1) NULL,
start datetime NOT NULL,
stop datetime NOT NULL,
visita char(1) NULL,
 CONSTRAINT xpklezione PRIMARY KEY (idlezione,
idaffidamento,
idcanale,
idattivform,
iddidprogporzanno,
iddidproganno,
iddidprogori,
iddidprogcurr,
iddidprog,
idaula,
idsede,
idedificio,
idcorsostudio,
aa,
idreg_docenti
)
)
END
GO

-- VERIFICA STRUTTURA lezione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idlezione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idlezione int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idlezione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idaffidamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idaffidamento int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idaffidamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idcanale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idcanale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idcanale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idattivform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idattivform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'iddidprogporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD iddidprogporzanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'iddidprogporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'iddidproganno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD iddidproganno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'iddidproganno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD iddidprogori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'iddidprogori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idaula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idaula int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idaula' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idedificio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idedificio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idedificio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'nonsvolta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD nonsvolta char(1) NULL 
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN nonsvolta char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'stage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD stage char(1) NULL 
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN stage char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD start datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'start' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN start datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD stop datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('lezione') and col.name = 'stop' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [lezione] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN stop datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'lezione' and C.name = 'visita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [lezione] ADD visita char(1) NULL 
END
ELSE
	ALTER TABLE [lezione] ALTER COLUMN visita char(1) NULL
GO

-- VERIFICA DI lezione IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'lezione'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idaula','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idedificio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idlezione','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idreg_docenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','lezione','char(1)','ASSISTENZA','nonsvolta','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','lezione','char(1)','ASSISTENZA','stage','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','datetime','ASSISTENZA','start','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','lezione','datetime','ASSISTENZA','stop','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','lezione','char(1)','ASSISTENZA','visita','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI lezione IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'lezione')
UPDATE customobject set isreal = 'S' where objectname = 'lezione'
ELSE
INSERT INTO customobject (objectname, isreal) values('lezione', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'lezione')
UPDATE [tabledescr] SET description = '2.4.23 Lezione',idapplication = null,isdbo = 'N',lt = {ts '2019-01-02 16:18:03.747'},lu = 'assistenza',title = 'Lezioni' WHERE tablename = 'lezione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('lezione','2.4.23 Lezione',null,'N',{ts '2019-01-02 16:18:03.747'},'assistenza','Lezioni')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:42:44.093'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','lezione','9',null,null,null,'S',{ts '2019-09-24 15:42:44.093'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.480'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','lezione','8',null,null,null,'S',{ts '2018-07-19 18:37:24.480'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','lezione','64',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamento' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Affidamento',kind = 'S',lt = {ts '2019-04-11 12:55:51.217'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamento' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamento','lezione','4',null,null,'Affidamento','S',{ts '2019-04-11 12:55:51.217'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attivit? formativa',kind = 'S',lt = {ts '2019-09-20 19:56:45.107'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','lezione','4',null,null,'Attivit? formativa','S',{ts '2019-09-20 19:56:45.107'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaula' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaula' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaula','lezione','4',null,null,'Aula','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcanale' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Canale',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcanale' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcanale','lezione','4',null,null,'Canale','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-24 15:42:44.093'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','lezione','4',null,null,null,'S',{ts '2019-09-24 15:42:44.093'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica programmata',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','lezione','4',null,null,'Didattica programmata','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno di corso',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','lezione','4',null,null,'Anno di corso','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Curriculum',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','lezione','4',null,null,'Curriculum','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Orientamento',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','lezione','4',null,null,'Orientamento','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Porzione d''anno',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','lezione','4',null,null,'Porzione d''anno','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idedificio' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Edificio',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idedificio' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idedificio','lezione','4',null,null,'Edificio','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlezione' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-09-20 20:01:50.010'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlezione' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlezione','lezione','4',null,null,'Identificativo','S',{ts '2019-09-20 20:01:50.010'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idlocation_aula' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Aula',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idlocation_aula' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idlocation_aula','lezione','4',null,null,'Aula','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-10-16 13:08:45.253'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','lezione','4',null,null,'Docente','S',{ts '2019-10-16 13:08:45.253'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-09-24 15:43:09.710'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','lezione','4',null,null,'Sede','S',{ts '2019-09-24 15:43:09.710'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','lezione','8',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:37:24.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','lezione','64',null,null,null,'S',{ts '2018-07-19 18:37:24.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nonsvolta' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Non svolta',kind = 'S',lt = {ts '2019-10-15 15:36:06.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nonsvolta' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nonsvolta','lezione','1',null,null,'Non svolta','S',{ts '2019-10-15 15:36:06.680'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stage' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-15 15:35:38.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'stage' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stage','lezione','1',null,null,null,'S',{ts '2019-10-15 15:35:38.747'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora inizio',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','lezione','8',null,null,'Data e ora inizio','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data e ora fine',kind = 'S',lt = {ts '2019-02-26 11:15:34.077'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','lezione','8',null,null,'Data e ora fine','S',{ts '2019-02-26 11:15:34.077'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'visita' AND tablename = 'lezione')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-15 15:35:38.747'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'visita' AND tablename = 'lezione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('visita','lezione','1',null,null,null,'S',{ts '2019-10-15 15:35:38.747'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3301')
UPDATE [relation] SET childtable = 'lezione',description = 'affidamento (docente e materia) della lezione',lt = {ts '2018-07-19 18:38:16.837'},lu = 'assistenza',parenttable = 'affidamento',title = null WHERE idrelation = '3301'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3301','lezione','affidamento (docente e materia) della lezione',{ts '2018-07-19 18:38:16.837'},'assistenza','affidamento',null)
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3452')
UPDATE [relation] SET childtable = 'lezione',description = 'Lezioni',lt = {ts '2018-12-07 19:06:51.800'},lu = 'assistenza',parenttable = 'location_aula',title = '2.4.23 Lezione' WHERE idrelation = '3452'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3452','lezione','Lezioni',{ts '2018-12-07 19:06:51.800'},'assistenza','location_aula','2.4.23 Lezione')
GO

-- FINE GENERAZIONE SCRIPT --

