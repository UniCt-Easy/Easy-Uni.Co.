
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
-- CREAZIONE TABELLA affidamento --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamento]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[affidamento] (
idaffidamento int NOT NULL,
idcanale int NOT NULL,
idattivform int NOT NULL,
iddidprogporzanno int NOT NULL,
iddidproganno int NOT NULL,
iddidprogori int NOT NULL,
iddidprogcurr int NOT NULL,
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa varchar(9) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
freqobbl char(1) NULL,
frequenzaminima int NULL,
frequenzaminimadebito int NULL,
gratuito char(1) NOT NULL,
idaffidamentokind int NOT NULL,
iderogazkind int NULL,
idreg_docenti int NULL,
idsede int NOT NULL,
json nvarchar(max) NULL,
jsonancestor nvarchar(max) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orariric nvarchar(max) NULL,
orariric_en nvarchar(max) NULL,
paridaffidamento int NULL,
prog nvarchar(max) NULL,
prog_en nvarchar(max) NULL,
riferimento char(1) NOT NULL,
start date NULL,
stop date NULL,
testi nvarchar(max) NULL,
testi_en nvarchar(max) NULL,
title nvarchar(max) NULL,
urlcorso varchar(512) NULL,
 CONSTRAINT xpkaffidamento PRIMARY KEY (idaffidamento,
idcanale,
idattivform,
iddidprogporzanno,
iddidproganno,
iddidprogori,
iddidprogcurr,
iddidprog,
idcorsostudio,
aa
)
)
END
GO

-- VERIFICA STRUTTURA affidamento --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idaffidamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idaffidamento int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idaffidamento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idcanale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idcanale int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idcanale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idattivform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idattivform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iddidprogporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iddidprogporzanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'iddidprogporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iddidproganno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iddidproganno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'iddidproganno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iddidprogori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'iddidprogori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'freqobbl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD freqobbl char(1) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN freqobbl char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'frequenzaminima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD frequenzaminima int NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN frequenzaminima int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'frequenzaminimadebito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD frequenzaminimadebito int NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN frequenzaminimadebito int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'gratuito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD gratuito char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'gratuito' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN gratuito char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idaffidamentokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idaffidamentokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idaffidamentokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN idaffidamentokind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD iderogazkind int NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN iderogazkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN idsede int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'json' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD json nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN json nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'jsonancestor' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD jsonancestor nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN jsonancestor nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'orariric' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD orariric nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN orariric nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'orariric_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD orariric_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN orariric_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'paridaffidamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD paridaffidamento int NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN paridaffidamento int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'prog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD prog nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN prog nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'prog_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD prog_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN prog_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'riferimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD riferimento char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('affidamento') and col.name = 'riferimento' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [affidamento] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN riferimento char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD start date NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD stop date NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'testi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD testi nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN testi nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'testi_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD testi_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN testi_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD title nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN title nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'affidamento' and C.name = 'urlcorso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [affidamento] ADD urlcorso varchar(512) NULL 
END
ELSE
	ALTER TABLE [affidamento] ALTER COLUMN urlcorso varchar(512) NULL
GO

-- VERIFICA DI affidamento IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamento'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','char(1)','ASSISTENZA','freqobbl','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','int','ASSISTENZA','frequenzaminima','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','int','ASSISTENZA','frequenzaminimadebito','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','char(1)','ASSISTENZA','gratuito','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','int','ASSISTENZA','iderogazkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','json','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','jsonancestor','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','orariric','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','orariric_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','int','ASSISTENZA','paridaffidamento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','prog','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','prog_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamento','char(1)','ASSISTENZA','riferimento','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','date','ASSISTENZA','start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','date','ASSISTENZA','stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','testi','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','testi_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','nvarchar(max)','ASSISTENZA','title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamento','varchar(512)','ASSISTENZA','urlcorso','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamento IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamento')
UPDATE customobject set isreal = 'S' where objectname = 'affidamento'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamento', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'affidamento')
UPDATE [tabledescr] SET description = '2.4.18 Affidamento',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 15:50:01.773'},lu = 'assistenza',title = 'Affidamento' WHERE tablename = 'affidamento'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('affidamento','2.4.18 Affidamento',null,'N',{ts '2018-07-19 15:50:01.773'},'assistenza','Affidamento')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2020-10-22 12:50:41.043'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','affidamento','9',null,null,'Anno accademico','S',{ts '2020-10-22 12:50:41.043'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','affidamento','8',null,null,null,'S',{ts '2018-07-19 15:50:06.917'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','affidamento','64',null,null,null,'S',{ts '2018-07-19 15:50:06.917'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'freqobbl' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Frequenza obbligatoria',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'freqobbl' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('freqobbl','affidamento','1',null,null,'Frequenza obbligatoria','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'frequenzaminima' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Frequenza minima (%)',kind = 'S',lt = {ts '2020-02-21 17:47:34.117'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'frequenzaminima' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('frequenzaminima','affidamento','4',null,null,'Frequenza minima (%)','S',{ts '2020-02-21 17:47:34.117'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'frequenzaminimadebito' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Frequenza minima con debito (%)',kind = 'S',lt = {ts '2020-02-21 17:47:34.120'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'frequenzaminimadebito' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('frequenzaminimadebito','affidamento','4',null,null,'Frequenza minima con debito (%)','S',{ts '2020-02-21 17:47:34.120'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gratuito' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'gratuito' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gratuito','affidamento','1',null,null,null,'S',{ts '2018-07-19 15:50:06.917'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamento' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamento' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamento','affidamento','4',null,null,'Codice','S',{ts '2019-02-19 12:21:15.440'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaffidamentokind' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaffidamentokind' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaffidamentokind','affidamento','4',null,null,'Tipologia','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.243'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.243'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcanale' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Canale',kind = 'S',lt = {ts '2019-04-11 12:38:17.247'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcanale' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcanale','affidamento','4',null,null,'Canale','S',{ts '2019-04-11 12:38:17.247'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:10:15.997'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','affidamento','4',null,null,null,'S',{ts '2019-09-23 16:10:15.997'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.243'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.243'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.247'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.247'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.247'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.247'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.247'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.247'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:38:17.247'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','affidamento','4',null,null,null,'S',{ts '2019-04-11 12:38:17.247'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iderogazkind' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di erogazione',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iderogazkind' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iderogazkind','affidamento','4',null,null,'Tipo di erogazione','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Docente',kind = 'S',lt = {ts '2019-02-22 17:57:59.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','affidamento','4',null,null,'Docente','S',{ts '2019-02-22 17:57:59.187'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'json' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Affidamento',kind = 'S',lt = {ts '2020-05-12 12:04:43.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'json' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('json','affidamento','0',null,null,'Affidamento','S',{ts '2020-05-12 12:04:43.310'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'jsonancestor' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Didattica',kind = 'S',lt = {ts '2020-05-14 11:53:22.190'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'jsonancestor' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('jsonancestor','affidamento','0',null,null,'Didattica','S',{ts '2020-05-14 11:53:22.190'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','affidamento','8',null,null,null,'S',{ts '2018-07-19 15:50:06.917'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','affidamento','64',null,null,null,'S',{ts '2018-07-19 15:50:06.917'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orariric' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'orariric' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orariric','affidamento','0',null,null,'Orari di ricevimento','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orariric_en' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Oriari di ricevimento (EN)',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'orariric_en' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orariric_en','affidamento','0',null,null,'Oriari di ricevimento (EN)','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'paridaffidamento' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-19 12:29:11.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'paridaffidamento' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('paridaffidamento','affidamento','4',null,null,null,'S',{ts '2019-02-19 12:29:11.180'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prog' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Programma',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'prog' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prog','affidamento','0',null,null,'Programma','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prog_en' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Programma (EN)',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'prog_en' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prog_en','affidamento','0',null,null,'Programma (EN)','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'riferimento' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Docente di riferimento per il canale',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'riferimento' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('riferimento','affidamento','1',null,null,'Docente di riferimento per il canale','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Inizio',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','affidamento','3',null,null,'Inizio','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Fine',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','affidamento','3',null,null,'Fine','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testi' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 15:50:06.920'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'testi' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testi','affidamento','0',null,null,null,'S',{ts '2018-07-19 15:50:06.920'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testi_en' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Testi (EN)',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'testi_en' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testi_en','affidamento','0',null,null,'Testi (EN)','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-10-11 12:06:00.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','affidamento','0',null,null,null,'S',{ts '2019-10-11 12:06:00.257'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'urlcorso' AND tablename = 'affidamento')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Indirizzo web del corso',kind = 'S',lt = {ts '2019-02-19 12:21:15.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'urlcorso' AND tablename = 'affidamento'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('urlcorso','affidamento','512',null,null,'Indirizzo web del corso','S',{ts '2019-02-19 12:21:15.440'},'assistenza','N','varchar(512)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3297')
UPDATE [relation] SET childtable = 'affidamento',description = 'canale affidato al docente',lt = {ts '2018-07-19 18:24:47.403'},lu = 'assistenza',parenttable = 'canale',title = null WHERE idrelation = '3297'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3297','affidamento','canale affidato al docente',{ts '2018-07-19 18:24:47.403'},'assistenza','canale',null)
GO

-- FINE GENERAZIONE SCRIPT --

