
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


setuser 'amministrazione'--[DBO]--
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

--[DBO]--
-- CREAZIONE TABELLA assetdiary --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[assetdiary] (
idassetdiary int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idasset int NOT NULL,
idpiece int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
idworkpackage int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkassetdiary PRIMARY KEY (idassetdiary
)
)
END
GO

-- VERIFICA STRUTTURA assetdiary --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idassetdiary' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idassetdiary int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idassetdiary' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idasset int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idpiece int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idpiece int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN idworkpackage int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('assetdiary') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [assetdiary] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetdiary' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [assetdiary] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [assetdiary] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI assetdiary IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiary'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idassetdiary','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idasset','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','idpiece','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiary','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiary','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assetdiary IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiary')
UPDATE customobject set isreal = 'S' where objectname = 'assetdiary'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiary', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'assetdiary')
UPDATE [tabledescr] SET description = 'Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',idapplication = null,isdbo = 'S',lt = {ts '2020-06-05 16:00:02.353'},lu = 'assistenza',title = 'Diari di utilizzo dei beni strumentali' WHERE tablename = 'assetdiary'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('assetdiary','Diari di utilizzo dei beni strumentali relativi al workpackage di un progetto',null,'S',{ts '2020-06-05 16:00:02.353'},'assistenza','Diari di utilizzo dei beni strumentali')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bene strumentale',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','assetdiary','4',null,null,'Bene strumentale','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassetdiary' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.140'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassetdiary' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassetdiary','assetdiary','4',null,null,null,'S',{ts '2020-06-05 15:58:18.140'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero parte',kind = 'S',lt = {ts '2020-06-18 10:33:39.790'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','assetdiary','4',null,null,'Numero parte','S',{ts '2020-06-18 10:33:39.790'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','assetdiary','4',null,null,'Progetto','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Operatore',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','assetdiary','4',null,null,'Operatore','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-16 17:27:29.270'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','assetdiary','4',null,null,'Workpackage','S',{ts '2020-06-16 17:27:29.270'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','assetdiary','8',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 15:58:18.143'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','assetdiary','64',null,null,null,'S',{ts '2020-06-05 15:58:18.143'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'assetdiary')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di utilizzo complessive preventivate',kind = 'S',lt = {ts '2020-06-18 10:33:39.793'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'assetdiary'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','assetdiary','4',null,null,'Ore di utilizzo complessive preventivate','S',{ts '2020-06-18 10:33:39.793'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA canale --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[canale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[canale] (
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
CUIN varchar(9) NULL,
idsede int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
numerostud int NULL,
sortcode int NULL,
title varchar(256) NULL,
 CONSTRAINT xpkcanale PRIMARY KEY (idcanale,
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

-- VERIFICA STRUTTURA canale --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'idcanale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD idcanale int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'idcanale' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'idattivform' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD idattivform int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'idattivform' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'iddidprogporzanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD iddidprogporzanno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'iddidprogporzanno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'iddidproganno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD iddidproganno int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'iddidproganno' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'iddidprogori' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD iddidprogori int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'iddidprogori' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'iddidprogcurr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD iddidprogcurr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'iddidprogcurr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'CUIN' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD CUIN varchar(9) NULL 
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN CUIN varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN idsede int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('canale') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [canale] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'numerostud' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD numerostud int NULL 
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN numerostud int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'canale' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [canale] ADD title varchar(256) NULL 
END
ELSE
	ALTER TABLE [canale] ALTER COLUMN title varchar(256) NULL
GO

-- VERIFICA DI canale IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'canale'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canale','varchar(9)','ASSISTENZA','CUIN','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canale','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canale','int','ASSISTENZA','numerostud','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canale','int','ASSISTENZA','sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canale','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI canale IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'canale')
UPDATE customobject set isreal = 'S' where objectname = 'canale'
ELSE
INSERT INTO customobject (objectname, isreal) values('canale', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'canale')
UPDATE [tabledescr] SET description = '2.4.17 Canale',idapplication = null,isdbo = 'N',lt = {ts '2018-07-19 18:22:37.190'},lu = 'assistenza',title = 'Canale (partizione di studenti)' WHERE tablename = 'canale'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('canale','2.4.17 Canale',null,'N',{ts '2018-07-19 18:22:37.190'},'assistenza','Canale (partizione di studenti)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:09:09.747'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','canale','9',null,null,null,'S',{ts '2019-09-23 16:09:09.747'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:22:39.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','canale','8',null,null,null,'S',{ts '2018-07-19 18:22:39.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:33:37.603'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','canale','64',null,null,null,'S',{ts '2019-04-11 12:33:37.603'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'CUIN' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:22:39.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'CUIN' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('CUIN','canale','9',null,null,null,'S',{ts '2018-07-19 18:22:39.177'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idattivform' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attività formativa',kind = 'S',lt = {ts '2020-09-29 17:58:31.287'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idattivform' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idattivform','canale','4',null,null,'Attività formativa','S',{ts '2020-09-29 17:58:31.287'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcanale' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Canale',kind = 'S',lt = {ts '2020-05-08 15:41:19.477'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcanale' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcanale','canale','4',null,null,'Canale','S',{ts '2020-05-08 15:41:19.477'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:09:09.747'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','canale','4',null,null,null,'S',{ts '2019-09-23 16:09:09.747'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-11 12:33:37.603'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','canale','4',null,null,null,'S',{ts '2019-04-11 12:33:37.603'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidproganno' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno',kind = 'S',lt = {ts '2020-05-08 15:41:19.477'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidproganno' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidproganno','canale','4',null,null,'Anno','S',{ts '2020-05-08 15:41:19.477'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogcurr' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Curriculum',kind = 'S',lt = {ts '2020-05-08 15:41:19.477'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogcurr' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogcurr','canale','4',null,null,'Curriculum','S',{ts '2020-05-08 15:41:19.477'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogori' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Orientamento',kind = 'S',lt = {ts '2020-05-08 15:41:19.477'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogori' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogori','canale','4',null,null,'Orientamento','S',{ts '2020-05-08 15:41:19.477'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogporzanno' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Porzione d''anno',kind = 'S',lt = {ts '2020-05-08 15:41:19.477'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogporzanno' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogporzanno','canale','4',null,null,'Porzione d''anno','S',{ts '2020-05-08 15:41:19.477'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:22:39.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','canale','8',null,null,null,'S',{ts '2018-07-19 18:22:39.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:22:39.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','canale','64',null,null,null,'S',{ts '2018-07-19 18:22:39.177'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numerostud' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di studenti',kind = 'S',lt = {ts '2019-09-10 17:28:45.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numerostud' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numerostud','canale','4',null,null,'Numero di studenti','S',{ts '2019-09-10 17:28:45.967'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Posizione',kind = 'S',lt = {ts '2019-09-10 17:28:45.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','canale','4',null,null,'Posizione','S',{ts '2019-09-10 17:28:45.967'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-10 17:28:45.970'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','canale','256',null,null,'Denominazione','S',{ts '2019-09-10 17:28:45.970'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'vu' AND tablename = 'canale')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-19 18:22:39.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'vu' AND tablename = 'canale'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('vu','canale','64',null,null,null,'S',{ts '2018-07-19 18:22:39.177'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '3296')
UPDATE [relation] SET childtable = 'canale',description = 'attivit? fromativa di cui si indica il partizionamento',lt = {ts '2018-07-19 18:23:31.267'},lu = 'assistenza',parenttable = 'attivform',title = null WHERE idrelation = '3296'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3296','canale','attivit? fromativa di cui si indica il partizionamento',{ts '2018-07-19 18:23:31.267'},'assistenza','attivform',null)
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA diderog --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[diderog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[diderog] (
idcorsostudio int NOT NULL,
aa varchar(9) NOT NULL,
idsede int NOT NULL,
inesaurimento char(1) NULL,
 CONSTRAINT xpkdiderog PRIMARY KEY (idcorsostudio,
aa,
idsede
)
)
END
GO

-- VERIFICA STRUTTURA diderog --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'diderog' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [diderog] ADD idcorsostudio int NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('diderog') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [diderog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'diderog' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [diderog] ADD aa varchar(9) NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('diderog') and col.name = 'aa' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [diderog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'diderog' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [diderog] ADD idsede int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('diderog') and col.name = 'idsede' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [diderog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'diderog' and C.name = 'inesaurimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [diderog] ADD inesaurimento char(1) NULL 
END
ELSE
	ALTER TABLE [diderog] ALTER COLUMN inesaurimento char(1) NULL
GO

-- VERIFICA DI diderog IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'diderog'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderog','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderog','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderog','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderog','char(1)','ASSISTENZA','inesaurimento','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI diderog IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'diderog')
UPDATE customobject set isreal = 'S' where objectname = 'diderog'
ELSE
INSERT INTO customobject (objectname, isreal) values('diderog', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'diderog')
UPDATE [tabledescr] SET description = '2.5.22 Didattica Erogata',idapplication = null,isdbo = 'N',lt = {ts '2019-09-23 16:12:08.580'},lu = 'assistenza',title = 'Didattica Erogata' WHERE tablename = 'diderog'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('diderog','2.5.22 Didattica Erogata',null,'N',{ts '2019-09-23 16:12:08.580'},'assistenza','Didattica Erogata')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'diderog')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:12:10.700'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'diderog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','diderog','9',null,null,null,'S',{ts '2019-09-23 16:12:10.700'},'assistenza','S','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'diderog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-23 16:12:10.703'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'diderog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','diderog','4',null,null,null,'S',{ts '2019-09-23 16:12:10.703'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'inesaurimento' AND tablename = 'diderog')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-09-25 10:53:34.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'inesaurimento' AND tablename = 'diderog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('inesaurimento','diderog','1',null,null,null,'S',{ts '2019-09-25 10:53:34.090'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progetto] (
idprogetto int NOT NULL,
budget decimal(14,2) NULL,
budgetcalcolato decimal(14,2) NULL,
budgetcalcolatodate datetime NULL,
capofilatxt nvarchar(2048) NULL,
codiceidentificativo varchar(2048) NULL,
contributo decimal(14,2) NULL,
contributoente decimal(14,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cup varchar(15) NULL,
data date NULL,
datacontabile date NULL,
description nvarchar(max) NULL,
durata int NULL,
finanziatoretxt nvarchar(2048) NULL,
idcorsostudio int NULL,
idcurrency int NULL,
idduratakind int NULL,
idprogettokind int NULL,
idprogettostatuskind int NULL,
idreg int NULL,
idreg_aziende int NULL,
idreg_aziende_fin int NULL,
idregistryprogfin int NULL,
idregistryprogfinbando int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
start date NULL,
stop date NULL,
title nvarchar(4000) NULL,
titolobreve nvarchar(2048) NULL,
totalbudget decimal(14,2) NULL,
totalcontributo decimal(14,2) NULL,
url varchar(1024) NULL,
 CONSTRAINT xpkprogetto PRIMARY KEY (idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolato decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolato decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'budgetcalcolatodate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD budgetcalcolatodate datetime NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN budgetcalcolatodate datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'capofilatxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD capofilatxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN capofilatxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'codiceidentificativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD codiceidentificativo varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN codiceidentificativo varchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'contributoente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD contributoente decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN contributoente decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'cup' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD cup varchar(15) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN cup varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD data date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'datacontabile' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD datacontabile date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN datacontabile date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD durata int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'finanziatoretxt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD finanziatoretxt nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN finanziatoretxt nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcorsostudio int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcorsostudio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idcurrency' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idcurrency int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idcurrency int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettokind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idprogettostatuskind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idprogettostatuskind int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idprogettostatuskind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idreg_aziende_fin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idreg_aziende_fin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idreg_aziende_fin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfin' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfin int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfin int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'idregistryprogfinbando' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD idregistryprogfinbando int NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN idregistryprogfinbando int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'start' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD start date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN start date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'stop' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD stop date NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN stop date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD title nvarchar(4000) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN title nvarchar(4000) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'titolobreve' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD titolobreve nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN titolobreve nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalbudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalbudget decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalbudget decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'totalcontributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD totalcontributo decimal(14,2) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN totalcontributo decimal(14,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progetto' and C.name = 'url' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progetto] ADD url varchar(1024) NULL 
END
ELSE
	ALTER TABLE [progetto] ALTER COLUMN url varchar(1024) NULL
GO

-- VERIFICA DI progetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','budgetcalcolato','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','datetime','assistenza','budgetcalcolatodate','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','capofilatxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(2048)','assistenza','codiceidentificativo','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','contributoente','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(15)','assistenza','cup','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','datacontabile','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','durata','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','finanziatoretxt','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcorsostudio','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idcurrency','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idduratakind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettokind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idprogettostatuskind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idreg_aziende_fin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfin','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','int','assistenza','idregistryprogfinbando','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progetto','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','start','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','date','assistenza','stop','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(4000)','assistenza','title','4000','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','nvarchar(2048)','assistenza','titolobreve','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalbudget','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','decimal(14,2)','assistenza','totalcontributo','9','N','decimal','System.Decimal','','2','''assistenza''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progetto','varchar(1024)','assistenza','url','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progetto')
UPDATE customobject set isreal = 'S' where objectname = 'progetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progetto')
UPDATE [tabledescr] SET description = 'Progetto di ricerca',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:00:37.623'},lu = 'assistenza',title = 'Progetto di ricerca' WHERE tablename = 'progetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progetto','Progetto di ricerca',null,'N',{ts '2020-05-20 14:00:37.623'},'assistenza','Progetto di ricerca')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progetto','9','14','2','Costo totale per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolato' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo totale effettivo per l''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budgetcalcolato' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolato','progetto','9','14','2','Costo totale effettivo per l''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Calcolato il',kind = 'S',lt = {ts '2020-10-26 10:44:21.677'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'budgetcalcolatodate' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budgetcalcolatodate','progetto','8',null,null,'Calcolato il','S',{ts '2020-10-26 10:44:21.677'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'capofilatxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente capofila non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'capofilatxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('capofilatxt','progetto','2048',null,null,'Ente capofila non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codiceidentificativo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-10-30 08:33:43.240'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codiceidentificativo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codiceidentificativo','progetto','2048',null,null,'Codice identificativo','S',{ts '2020-10-30 08:33:43.240'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Cofinanziamento richiesto all''ateneo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progetto','9','14','2','Cofinanziamento richiesto all''ateneo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributoente' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo totale richiesto dall''ateneo all’ente finanziatore',kind = 'S',lt = {ts '2020-11-04 16:51:02.247'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributoente' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributoente','progetto','9','14','2','Contributo totale richiesto dall''ateneo all’ente finanziatore','S',{ts '2020-11-04 16:51:02.247'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cup' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Codice univoco progetto (CUP)',kind = 'S',lt = {ts '2020-10-30 17:51:30.213'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cup' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cup','progetto','15',null,null,'Codice univoco progetto (CUP)','S',{ts '2020-10-30 17:51:30.213'},'assistenza','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di presentazione',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','progetto','3',null,null,'Data di presentazione','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datacontabile' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data chiusura contablile',kind = 'S',lt = {ts '2020-12-09 12:56:24.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datacontabile' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datacontabile','progetto','3',null,null,'Data chiusura contablile','S',{ts '2020-12-09 12:56:24.963'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:03:58.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progetto','0',null,null,'Descrizione','S',{ts '2020-05-20 14:03:58.150'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:11:44.723'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','progetto','4',null,null,null,'S',{ts '2020-05-25 13:11:44.723'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'finanziatoretxt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Ente finanziatore non censito',kind = 'S',lt = {ts '2020-10-26 10:22:18.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'finanziatoretxt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('finanziatoretxt','progetto','2048',null,null,'Ente finanziatore non censito','S',{ts '2020-10-26 10:22:18.617'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Didattica',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','progetto','4',null,null,'Didattica','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcurrency' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice valuta',kind = 'S',lt = {ts '2020-11-02 18:34:42.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcurrency' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcurrency','progetto','4',null,null,'Codice valuta','S',{ts '2020-11-02 18:34:42.180'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Espressa in',kind = 'S',lt = {ts '2020-05-25 13:14:10.947'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','progetto','4',null,null,'Espressa in','S',{ts '2020-05-25 13:14:10.947'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice interno',kind = 'S',lt = {ts '2020-10-30 08:33:16.517'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progetto','4',null,null,'Codice interno','S',{ts '2020-10-30 08:33:16.517'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di progetto o attività',kind = 'S',lt = {ts '2020-11-04 16:52:57.667'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progetto','4',null,null,'Tipo di progetto o attività','S',{ts '2020-11-04 16:52:57.667'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del progetto o attività',kind = 'S',lt = {ts '2020-09-30 16:14:37.087'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettostatuskind' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettostatuskind','progetto','4',null,null,'Stato del progetto o attività','S',{ts '2020-09-30 16:14:37.087'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Principal investigator / Responsabile di progetto ',kind = 'S',lt = {ts '2020-07-15 17:09:18.147'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progetto','4',null,null,'Principal investigator / Responsabile di progetto ','S',{ts '2020-07-15 17:09:18.147'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente capofila',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende','progetto','4',null,null,'Ente capofila','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ente finanziatore',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_aziende_fin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_aziende_fin','progetto','4',null,null,'Ente finanziatore','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfin' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma di finanziamento',kind = 'S',lt = {ts '2020-06-12 15:56:06.547'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfin' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfin','progetto','4',null,null,'Programma di finanziamento','S',{ts '2020-06-12 15:56:06.547'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bando di riferimento',kind = 'S',lt = {ts '2020-06-12 18:11:47.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistryprogfinbando' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryprogfinbando','progetto','4',null,null,'Bando di riferimento','S',{ts '2020-06-12 18:11:47.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progetto','8',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:00:40.020'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progetto','64',null,null,null,'S',{ts '2020-05-20 14:00:40.020'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'start' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'start' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('start','progetto','3',null,null,'Data di inizio','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stop' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine',kind = 'S',lt = {ts '2020-06-05 15:48:03.440'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stop' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stop','progetto','3',null,null,'Data di fine','S',{ts '2020-06-05 15:48:03.440'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '4000',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(4000)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progetto','4000',null,null,'Titolo','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','nvarchar(4000)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolobreve' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo breve o acronimo',kind = 'S',lt = {ts '2020-05-20 14:03:58.153'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'titolobreve' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolobreve','progetto','2048',null,null,'Titolo breve o acronimo','S',{ts '2020-05-20 14:03:58.153'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalbudget' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Costo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalbudget' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalbudget','progetto','9','14','2','Costo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totalcontributo' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '9',col_precision = '14',col_scale = '2',description = 'Contributo globale del progetto per tutto il partenariato',kind = 'S',lt = {ts '2020-10-30 08:32:49.150'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(14,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'totalcontributo' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totalcontributo','progetto','9','14','2','Contributo globale del progetto per tutto il partenariato','S',{ts '2020-10-30 08:32:49.150'},'assistenza','N','decimal(14,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'url' AND tablename = 'progetto')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'URL del sito del progetto',kind = 'S',lt = {ts '2020-11-02 18:28:26.997'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'url' AND tablename = 'progetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('url','progetto','1024',null,null,'URL del sito del progetto','S',{ts '2020-11-02 18:28:26.997'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoasset --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoasset]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoasset] (
idprogetto int NOT NULL,
idasset int NOT NULL,
idpiece int NOT NULL,
aggiunta char(1) NULL,
costoorario decimal(10,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
 CONSTRAINT xpkprogettoasset PRIMARY KEY (idprogetto,
idasset,
idpiece
)
)
END
GO

-- VERIFICA STRUTTURA progettoasset --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idasset' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idasset int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idasset' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'idpiece' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD idpiece int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'idpiece' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'aggiunta' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD aggiunta char(1) NULL 
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN aggiunta char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'costoorario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD costoorario decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN costoorario decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoasset' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoasset] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoasset') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoasset] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettoasset] ALTER COLUMN lu varchar(64) NOT NULL
GO

-- VERIFICA DI progettoasset IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoasset'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','int','assistenza','idasset','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','int','assistenza','idpiece','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoasset','char(1)','assistenza','aggiunta','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoasset','decimal(10,2)','assistenza','costoorario','9','N','decimal','System.Decimal','','2','''assistenza''','10','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoasset','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettoasset IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoasset')
UPDATE customobject set isreal = 'S' where objectname = 'progettoasset'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoasset', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoasset')
UPDATE [tabledescr] SET description = 'Beni strumentali in uso nel progetto o attivit?',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:52:45.760'},lu = 'assistenza',title = 'Beni strumentali in uso nel progetto o attivit?' WHERE tablename = 'progettoasset'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoasset','Beni strumentali in uso nel progetto o attivit?',null,'N',{ts '2020-06-18 12:52:45.760'},'assistenza','Beni strumentali in uso nel progetto o attivit?')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aggiunta' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Costo orario aggiuntivo o sostitutivo al costo di ammortamento',kind = 'S',lt = {ts '2020-11-17 13:02:52.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'aggiunta' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aggiunta','progettoasset','1',null,null,'Costo orario aggiuntivo o sostitutivo al costo di ammortamento','S',{ts '2020-11-17 13:02:52.377'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costoorario' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '9',col_precision = '10',col_scale = '2',description = 'Costo orario',kind = 'S',lt = {ts '2020-11-17 13:02:52.383'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(10,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costoorario' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costoorario','progettoasset','9','10','2','Costo orario','S',{ts '2020-11-17 13:02:52.383'},'assistenza','N','decimal(10,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:52:48.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoasset','8',null,null,null,'S',{ts '2020-06-18 12:52:48.613'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:52:48.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoasset','64',null,null,null,'S',{ts '2020-06-18 12:52:48.613'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idasset' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Bene',kind = 'S',lt = {ts '2020-06-18 13:03:11.497'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idasset' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idasset','progettoasset','4',null,null,'Bene','S',{ts '2020-06-18 13:03:11.497'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpiece' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Parte',kind = 'S',lt = {ts '2020-06-18 13:03:11.497'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpiece' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpiece','progettoasset','4',null,null,'Parte','S',{ts '2020-06-18 13:03:11.497'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-18 13:03:11.497'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettoasset','4',null,null,'Progetto','S',{ts '2020-06-18 13:03:11.497'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:52:48.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoasset','8',null,null,null,'S',{ts '2020-06-18 12:52:48.617'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoasset')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:52:48.617'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoasset'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoasset','64',null,null,null,'S',{ts '2020-06-18 12:52:48.617'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettobudget --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettobudget]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettobudget] (
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
budget decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
idprogettotipocosto int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
sortcode int NULL,
 CONSTRAINT xpkprogettobudget PRIMARY KEY (idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudget --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD budget decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN budget decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudget') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudget] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudget' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudget] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettobudget] ALTER COLUMN sortcode int NULL
GO

-- VERIFICA DI progettobudget IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettobudget'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','int','assistenza','idprogettobudget','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','decimal(9,2)','assistenza','budget','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idprogettotipocosto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','idworkpackage','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudget','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudget','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

-- VERIFICA DI progettobudget IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettobudget')
UPDATE customobject set isreal = 'S' where objectname = 'progettobudget'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettobudget', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudget')
UPDATE [tabledescr] SET description = 'Budget per le categorie di costo di un progetto ',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:14:40.277'},lu = 'assistenza',title = 'Budget per le categorie di costo di un progetto ' WHERE tablename = 'progettobudget'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudget','Budget per le categorie di costo di un progetto ',null,'N',{ts '2020-06-18 12:14:40.277'},'assistenza','Budget per le categorie di costo di un progetto ')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Budget iniziale',kind = 'S',lt = {ts '2020-12-09 16:32:07.130'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progettobudget','5','9','2','Budget iniziale','S',{ts '2020-12-09 16:32:07.130'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudget','4',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettobudget','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettobudget','4',null,null,'Workpackage','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudget','8',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:14:49.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudget','64',null,null,null,'S',{ts '2020-06-18 12:14:49.330'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettobudget')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordine di visualizzazione',kind = 'S',lt = {ts '2020-06-18 12:17:09.210'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettobudget'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettobudget','4',null,null,'Ordine di visualizzazione','S',{ts '2020-06-18 12:17:09.210'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettobudgetvariazione --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettobudgetvariazione]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettobudgetvariazione] (
idprogettobudgetvariazione int NOT NULL,
idprogettobudget int NOT NULL,
idprogetto int NOT NULL,
ct datetime NULL,
cu varchar(60) NULL,
idaccmotive varchar(36) NULL,
idupb varchar(36) NULL,
lt datetime NULL,
lu varchar(60) NULL,
newamount decimal(16,2) NULL,
 CONSTRAINT xpkprogettobudgetvariazione PRIMARY KEY (idprogettobudgetvariazione,
idprogettobudget,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettobudgetvariazione --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudgetvariazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudgetvariazione int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudgetvariazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogettobudget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogettobudget int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogettobudget' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettobudgetvariazione') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettobudgetvariazione] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD cu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN cu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idaccmotive' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idaccmotive varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idaccmotive varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'idupb' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD idupb varchar(36) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN idupb varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD lu varchar(60) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN lu varchar(60) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettobudgetvariazione' and C.name = 'newamount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettobudgetvariazione] ADD newamount decimal(16,2) NULL 
END
ELSE
	ALTER TABLE [progettobudgetvariazione] ALTER COLUMN newamount decimal(16,2) NULL
GO

-- VERIFICA DI progettobudgetvariazione IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettobudgetvariazione'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogetto','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogettobudget','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettobudgetvariazione','int','assistenza','idprogettobudgetvariazione','4','N','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(60)','assistenza','cu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(36)','assistenza','idaccmotive','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(36)','assistenza','idupb','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','varchar(60)','assistenza','lu','60','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettobudgetvariazione','decimal(16,2)','assistenza','newamount','9','N','decimal','System.Decimal','','2','''assistenza''','16','N')
GO

-- VERIFICA DI progettobudgetvariazione IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettobudgetvariazione')
UPDATE customobject set isreal = 'S' where objectname = 'progettobudgetvariazione'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettobudgetvariazione', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettobudgetvariazione')
UPDATE [tabledescr] SET description = 'Variazioni di budget del progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-11-30 10:50:04.907'},lu = 'assistenza',title = 'Variazioni di budget' WHERE tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettobudgetvariazione','Variazioni di budget del progetto',null,'N',{ts '2020-11-30 10:50:04.907'},'assistenza','Variazioni di budget')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettobudgetvariazione','8',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettobudgetvariazione','60',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotive' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Causale economico patrimoniale',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccmotive' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotive','progettobudgetvariazione','4',null,null,'Causale economico patrimoniale','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudget' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.963'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudget' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudget','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.963'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettobudgetvariazione' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettobudgetvariazione' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettobudgetvariazione','progettobudgetvariazione','4',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idupb' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','progettobudgetvariazione','4',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettobudgetvariazione','8',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '60',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-30 10:50:07.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(60)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettobudgetvariazione','60',null,null,null,'S',{ts '2020-11-30 10:50:07.967'},'assistenza','N','varchar(60)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'newamount' AND tablename = 'progettobudgetvariazione')
UPDATE [coldescr] SET col_len = '9',col_precision = '16',col_scale = '2',description = 'Nuovo budget',kind = 'S',lt = {ts '2020-11-30 10:54:15.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(16,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'newamount' AND tablename = 'progettobudgetvariazione'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('newamount','progettobudgetvariazione','9','16','2','Nuovo budget','S',{ts '2020-11-30 10:54:15.167'},'assistenza','N','decimal(16,2)','decimal','System.Decimal')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettocosto] (
idprogettocosto int NOT NULL,
idprogetto int NOT NULL,
amount decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
doc varchar(35) NULL,
docdate date NULL,
idcontrattokind int NULL,
idexp int NULL,
idpettycash int NULL,
idprogettotipocosto int NULL,
idrelated varchar(50) NULL,
idrendicontattivitaprogetto int NULL,
idsal int NULL,
idworkpackage int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
noperation int NULL,
yoperation smallint NULL,
 CONSTRAINT xpkprogettocosto PRIMARY KEY (idprogettocosto,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettocosto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogettocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogettocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'idprogettocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'amount' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD amount decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN amount decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'doc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD doc varchar(35) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN doc varchar(35) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'docdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD docdate date NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN docdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idexp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idexp int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idexp int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idpettycash' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idpettycash int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idpettycash int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idprogettotipocosto int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idprogettotipocosto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idrelated' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idrelated varchar(50) NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idrelated varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idrendicontattivitaprogetto int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idrendicontattivitaprogetto int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idsal int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idsal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD idworkpackage int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN idworkpackage int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettocosto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettocosto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'noperation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD noperation int NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN noperation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettocosto' and C.name = 'yoperation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettocosto] ADD yoperation smallint NULL 
END
ELSE
	ALTER TABLE [progettocosto] ALTER COLUMN yoperation smallint NULL
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1progettocosto' and id=object_id('progettocosto'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1progettocosto
     ON progettocosto (idexp, idrelated )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1progettocosto
     ON progettocosto (idexp, idrelated )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2progettocosto' and id=object_id('progettocosto'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2progettocosto
     ON progettocosto (idrelated, idpettycash, yoperation, noperation )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2progettocosto
     ON progettocosto (idrelated, idpettycash, yoperation, noperation )
ON [PRIMARY]
END
GO

-- VERIFICA DI progettocosto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettocosto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','int','ASSISTENZA','idprogettocosto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','decimal(9,2)','ASSISTENZA','amount','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','varchar(35)','ASSISTENZA','doc','35','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','date','ASSISTENZA','docdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idexp','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idpettycash','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idprogettotipocosto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','varchar(50)','ASSISTENZA','idrelated','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idrendicontattivitaprogetto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idsal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','idworkpackage','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettocosto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','int','ASSISTENZA','noperation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettocosto','smallint','ASSISTENZA','yoperation','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettocosto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettocosto')
UPDATE customobject set isreal = 'S' where objectname = 'progettocosto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettocosto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettocosto')
UPDATE [tabledescr] SET description = 'Costi per le categorie di costo di un progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:18:31.373'},lu = 'assistenza',title = 'Costi per le categorie di costo di un progetto' WHERE tablename = 'progettocosto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettocosto','Costi per le categorie di costo di un progetto',null,'N',{ts '2020-06-18 12:18:31.373'},'assistenza','Costi per le categorie di costo di un progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'amount' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Importo',kind = 'S',lt = {ts '2020-06-26 10:49:38.193'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'amount' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('amount','progettocosto','5','9','2','Importo','S',{ts '2020-06-26 10:49:38.193'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettocosto','8',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettocosto','64',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'doc' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '35',col_precision = null,col_scale = null,description = 'Documento collegato',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(35)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'doc' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('doc','progettocosto','35',null,null,'Documento collegato','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','varchar(35)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'docdate' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data del documento collegato',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'docdate' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('docdate','progettocosto','3',null,null,'Data del documento collegato','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di contratto',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','progettocosto','4',null,null,'Tipo di contratto','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexp' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Spesa',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexp' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexp','progettocosto','4',null,null,'Spesa','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idpettycash' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fondo economale',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idpettycash' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idpettycash','progettocosto','4',null,null,'Fondo economale','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettocosto','4',null,null,'Progetto','S',{ts '2020-06-26 10:49:38.197'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettocosto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.523'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettocosto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettocosto','progettocosto','4',null,null,null,'S',{ts '2020-06-18 12:18:33.523'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:19:18.350'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettocosto','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:19:18.350'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrelated' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Chiave economico patrimoniale',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idrelated' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrelated','progettocosto','50',null,null,'Chiave economico patrimoniale','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attività svolta',kind = 'S',lt = {ts '2020-10-02 18:12:48.977'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','progettocosto','4',null,null,'Attività svolta','S',{ts '2020-10-02 18:12:48.977'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato avanzamento lavori',kind = 'S',lt = {ts '2020-06-26 10:49:38.197'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','progettocosto','4',null,null,'Stato avanzamento lavori','S',{ts '2020-06-26 10:49:38.197'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-18 12:19:18.350'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','progettocosto','4',null,null,'Workpackage','S',{ts '2020-06-18 12:19:18.350'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettocosto','8',null,null,null,'S',{ts '2020-06-18 12:18:33.527'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:18:33.527'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettocosto','64',null,null,null,'S',{ts '2020-06-18 12:18:33.527'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'noperation' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero operazione',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'noperation' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('noperation','progettocosto','4',null,null,'Numero operazione','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'yoperation' AND tablename = 'progettocosto')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'Esercizio operazione',kind = 'S',lt = {ts '2020-06-26 15:24:47.113'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'smallint',sql_type = 'smallint',system_type = 'System.Int16' WHERE colname = 'yoperation' AND tablename = 'progettocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('yoperation','progettocosto','2',null,null,'Esercizio operazione','S',{ts '2020-06-26 15:24:47.113'},'assistenza','N','smallint','smallint','System.Int16')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettokind] (
idprogettokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(max) NULL,
idcorsostudio char(1) NULL,
idprogettoactivitykind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
oredivisionecostostipendio int NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettokind PRIMARY KEY (idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettokind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD idcorsostudio char(1) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN idcorsostudio char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'idprogettoactivitykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD idprogettoactivitykind int NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN idprogettoactivitykind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'oredivisionecostostipendio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD oredivisionecostostipendio int NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN oredivisionecostostipendio int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettokind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettokind] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokind','int','assistenza','idprogettokind','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','char(1)','assistenza','idcorsostudio','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','int','assistenza','idprogettoactivitykind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','int','assistenza','oredivisionecostostipendio','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokind','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettokind')
UPDATE customobject set isreal = 'S' where objectname = 'progettokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettokind')
UPDATE [tabledescr] SET description = 'Tipologie di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-22 12:54:10.557'},lu = 'assistenza',title = 'Tipologie di progetto' WHERE tablename = 'progettokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettokind','Tipologie di progetto',null,'N',{ts '2020-05-22 12:54:10.557'},'assistenza','Tipologie di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettokind','8',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettokind','64',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-22 12:55:03.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progettokind','0',null,null,'Descrizione','S',{ts '2020-05-22 12:55:03.843'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita il corso di studio',kind = 'S',lt = {ts '2020-11-18 12:20:50.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'idcorsostudio' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','progettokind','1',null,null,'Abilita il corso di studio','S',{ts '2020-11-18 12:20:50.907'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoactivitykind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-07-14 15:44:27.693'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoactivitykind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoactivitykind','progettokind','4',null,null,'Tipologia','S',{ts '2020-07-14 15:44:27.693'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-05 16:30:12.453'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettokind','4',null,null,null,'S',{ts '2020-06-05 16:30:12.453'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokindkind' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2020-06-05 16:30:12.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokindkind' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokindkind','progettokind','4',null,null,'Tipologia','S',{ts '2020-06-05 16:30:12.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettokind','8',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-07-14 15:42:22.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettokind','64',null,null,null,'S',{ts '2020-07-14 15:42:22.470'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oredivisionecostostipendio' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero ore lavorate in un anno dal personale',kind = 'S',lt = {ts '2020-07-14 15:44:27.693'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oredivisionecostostipendio' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oredivisionecostostipendio','progettokind','4',null,null,'Numero ore lavorate in un anno dal personale','S',{ts '2020-07-14 15:44:27.693'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettokind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-22 12:55:03.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettokind','2048',null,null,'Titolo','S',{ts '2020-05-22 12:55:03.843'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettotipocosto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotipocosto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotipocosto] (
idprogettotipocosto int NOT NULL,
idprogetto int NOT NULL,
ammissibilita decimal(5,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idprogettotipocostokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
sortcode int NULL,
title varchar(2048) NULL,
 CONSTRAINT xpkprogettotipocosto PRIMARY KEY (idprogettotipocosto,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocosto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogettotipocosto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogettotipocosto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocosto') and col.name = 'idprogettotipocosto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocosto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocosto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'ammissibilita' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD ammissibilita decimal(5,2) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN ammissibilita decimal(5,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'idprogettotipocostokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD idprogettotipocostokind int NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN idprogettotipocostokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD sortcode int NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN sortcode int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocosto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocosto] ADD title varchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotipocosto] ALTER COLUMN title varchar(2048) NULL
GO

-- VERIFICA DI progettotipocosto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotipocosto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocosto','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocosto','int','assistenza','idprogettotipocosto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','decimal(5,2)','assistenza','ammissibilita','5','N','decimal','System.Decimal','','2','''assistenza''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','int','assistenza','idprogettotipocostokind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','int','assistenza','sortcode','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocosto','varchar(2048)','assistenza','title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettotipocosto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotipocosto')
UPDATE customobject set isreal = 'S' where objectname = 'progettotipocosto'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotipocosto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotipocosto')
UPDATE [tabledescr] SET description = '2.7.4 Voce di costo',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:04:23.783'},lu = 'assistenza',title = 'Voce di costo' WHERE tablename = 'progettotipocosto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotipocosto','2.7.4 Voce di costo',null,'N',{ts '2020-06-18 12:04:23.783'},'assistenza','Voce di costo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ammissibilita' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Ammissibilità (%)',kind = 'S',lt = {ts '2020-11-02 18:41:54.357'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'ammissibilita' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ammissibilita','progettotipocosto','5','5','2','Ammissibilità (%)','S',{ts '2020-11-02 18:41:54.357'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotipocosto','8',null,null,null,'S',{ts '2020-06-18 12:04:28.390'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotipocosto','64',null,null,null,'S',{ts '2020-06-18 12:04:28.390'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.390'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettotipocosto','4',null,null,null,'S',{ts '2020-06-18 12:04:28.390'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.393'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocosto' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocosto','progettotipocosto','4',null,null,null,'S',{ts '2020-06-18 12:04:28.393'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Voce di costo',kind = 'S',lt = {ts '2020-06-18 12:07:21.417'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocostokind','progettotipocosto','4',null,null,'Voce di costo','S',{ts '2020-06-18 12:07:21.417'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotipocosto','8',null,null,null,'S',{ts '2020-06-18 12:04:28.393'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:04:28.393'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotipocosto','64',null,null,null,'S',{ts '2020-06-18 12:04:28.393'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ordinamento',kind = 'S',lt = {ts '2020-06-18 12:07:21.420'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','progettotipocosto','4',null,null,'Ordinamento','S',{ts '2020-06-18 12:07:21.420'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettotipocosto')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Voce',kind = 'S',lt = {ts '2020-11-04 17:14:46.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(2048)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettotipocosto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettotipocosto','2048',null,null,'Voce','S',{ts '2020-11-04 17:14:46.367'},'assistenza','N','varchar(2048)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettotipocostokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettotipocostokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettotipocostokind] (
idprogettotipocostokind int NOT NULL,
idprogettokind int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
description nvarchar(2048) NULL,
lt datetime NULL,
lu varchar(64) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettotipocostokind PRIMARY KEY (idprogettotipocostokind,
idprogettokind
)
)
END
GO

-- VERIFICA STRUTTURA progettotipocostokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'idprogettotipocostokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD idprogettotipocostokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostokind') and col.name = 'idprogettotipocostokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'idprogettokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD idprogettokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettotipocostokind') and col.name = 'idprogettokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettotipocostokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD description nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN description nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettotipocostokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettotipocostokind] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettotipocostokind] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettotipocostokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettotipocostokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocostokind','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettotipocostokind','int','ASSISTENZA','idprogettotipocostokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','nvarchar(2048)','ASSISTENZA','description','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettotipocostokind','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettotipocostokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettotipocostokind')
UPDATE customobject set isreal = 'S' where objectname = 'progettotipocostokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettotipocostokind', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettotipocostokind')
UPDATE [tabledescr] SET description = 'Configurazione delle voci di costo dei progetti',idapplication = null,isdbo = 'N',lt = {ts '2020-06-18 12:09:25.463'},lu = 'assistenza',title = 'Voci di costo' WHERE tablename = 'progettotipocostokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettotipocostokind','Configurazione delle voci di costo dei progetti',null,'N',{ts '2020-06-18 12:09:25.463'},'assistenza','Voci di costo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettotipocostokind','8',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettotipocostokind','64',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-18 12:10:05.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progettotipocostokind','2048',null,null,'Descrizione','S',{ts '2020-06-18 12:10:05.090'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettokind' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettokind' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettokind','progettotipocostokind','4',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettotipocostokind' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettotipocostokind','progettotipocostokind','4',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettotipocostokind','8',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-06-18 12:09:29.033'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettotipocostokind','64',null,null,null,'S',{ts '2020-06-18 12:09:29.033'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettotipocostokind')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Voce',kind = 'S',lt = {ts '2020-06-18 12:10:05.090'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettotipocostokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettotipocostokind','2048',null,null,'Voce','S',{ts '2020-06-18 12:10:05.090'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoudr --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoudr]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoudr] (
idprogettoudr int NOT NULL,
idprogetto int NOT NULL,
assegniricerca int NULL,
borsedottorati int NULL,
budget decimal(10,2) NULL,
contrattirtd int NULL,
contributo decimal(10,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
description varchar(max) NULL,
impegnototale int NULL,
lt datetime NULL,
lu varchar(64) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkprogettoudr PRIMARY KEY (idprogettoudr,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettoudr --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'idprogettoudr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD idprogettoudr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudr') and col.name = 'idprogettoudr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudr') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudr] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'assegniricerca' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD assegniricerca int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN assegniricerca int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'borsedottorati' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD borsedottorati int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN borsedottorati int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'budget' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD budget decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN budget decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'contrattirtd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD contrattirtd int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN contrattirtd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'contributo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD contributo decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN contributo decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'impegnototale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD impegnototale int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN impegnototale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN lu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI progettoudr IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoudr'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudr','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudr','int','ASSISTENZA','idprogettoudr','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','int','ASSISTENZA','assegniricerca','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','int','ASSISTENZA','borsedottorati','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','decimal(10,2)','ASSISTENZA','budget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','10','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','int','ASSISTENZA','contrattirtd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','decimal(10,2)','ASSISTENZA','contributo','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','10','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','int','ASSISTENZA','impegnototale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudr','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettoudr IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoudr')
UPDATE customobject set isreal = 'S' where objectname = 'progettoudr'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoudr', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoudr')
UPDATE [tabledescr] SET description = '2.7.7 Unit? di ricerca',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:19:18.160'},lu = 'assistenza',title = 'Unit? di ricerca' WHERE tablename = 'progettoudr'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoudr','2.7.7 Unit? di ricerca',null,'N',{ts '2020-05-25 13:19:18.160'},'assistenza','Unit? di ricerca')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegniricerca' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero assegni di ricerca previsti',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'assegniricerca' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegniricerca','progettoudr','4',null,null,'Numero assegni di ricerca previsti','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'borsedottorati' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero borse di dottorato previste',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'borsedottorati' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('borsedottorati','progettoudr','4',null,null,'Numero borse di dottorato previste','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'budget' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Costo complessivo',kind = 'S',lt = {ts '2020-06-08 18:40:28.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'budget' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('budget','progettoudr','5','5','2','Costo complessivo','S',{ts '2020-06-08 18:40:28.390'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contrattirtd' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero contratti RTD previsti',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'contrattirtd' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contrattirtd','progettoudr','4',null,null,'Numero contratti RTD previsti','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'contributo' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '5',col_precision = '5',col_scale = '2',description = 'Contributo richiesto ',kind = 'S',lt = {ts '2020-06-08 18:40:28.390'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(5,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'contributo' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('contributo','progettoudr','5','5','2','Contributo richiesto ','S',{ts '2020-06-08 18:40:28.390'},'assistenza','N','decimal(5,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoudr','8',null,null,null,'S',{ts '2020-05-25 13:19:20.470'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.470'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoudr','64',null,null,null,'S',{ts '2020-05-25 13:19:20.470'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','progettoudr','-1',null,null,'Descrizione','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.473'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettoudr','4',null,null,null,'S',{ts '2020-05-25 13:19:20.473'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoudr' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.473'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoudr' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoudr','progettoudr','4',null,null,null,'S',{ts '2020-05-25 13:19:20.473'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'impegnototale' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Impegno temporale complessivo prevedibile in mesi/uomo',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'impegnototale' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('impegnototale','progettoudr','4',null,null,'Impegno temporale complessivo prevedibile in mesi/uomo','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoudr','8',null,null,null,'S',{ts '2020-05-25 13:19:20.483'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:19:20.483'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoudr','64',null,null,null,'S',{ts '2020-05-25 13:19:20.483'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'progettoudr')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2020-05-25 13:21:53.137'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'progettoudr'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','progettoudr','2048',null,null,'Denominazione','S',{ts '2020-05-25 13:21:53.137'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA progettoudrmembro --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettoudrmembro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[progettoudrmembro] (
idprogettoudrmembro int NOT NULL,
idprogettoudr int NOT NULL,
idprogetto int NOT NULL,
costoorario decimal(10,2) NULL,
ct datetime NULL,
cu varchar(64) NULL,
idprogettoudrmembrokind int NULL,
idreg int NULL,
impegno int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkprogettoudrmembro PRIMARY KEY (idprogettoudrmembro,
idprogettoudr,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA progettoudrmembro --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudrmembro' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudrmembro int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogettoudrmembro' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudr int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogettoudr' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('progettoudrmembro') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [progettoudrmembro] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'costoorario' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD costoorario decimal(10,2) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN costoorario decimal(10,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idprogettoudrmembrokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idprogettoudrmembrokind int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN idprogettoudrmembrokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD idreg int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN idreg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'impegno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD impegno int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN impegno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI progettoudrmembro IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettoudrmembro'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembro','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembro','int','assistenza','idprogettoudr','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettoudrmembro','int','assistenza','idprogettoudrmembro','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','decimal(10,2)','assistenza','costoorario','9','N','decimal','System.Decimal','','2','''assistenza''','10','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','datetime','assistenza','ct','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','varchar(64)','assistenza','cu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','int','assistenza','idprogettoudrmembrokind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','int','assistenza','idreg','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','int','assistenza','impegno','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','datetime','assistenza','lt','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettoudrmembro','varchar(64)','assistenza','lu','64','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI progettoudrmembro IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettoudrmembro')
UPDATE customobject set isreal = 'S' where objectname = 'progettoudrmembro'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettoudrmembro', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'progettoudrmembro')
UPDATE [tabledescr] SET description = '2.7.9 Membro di una UdR',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:23:14.820'},lu = 'assistenza',title = 'Membri della UdR' WHERE tablename = 'progettoudrmembro'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('progettoudrmembro','2.7.9 Membro di una UdR',null,'N',{ts '2020-05-25 13:23:14.820'},'assistenza','Membri della UdR')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'costoorario' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '9',col_precision = '10',col_scale = '2',description = 'Costo orario',kind = 'S',lt = {ts '2020-11-10 15:26:00.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(10,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costoorario' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costoorario','progettoudrmembro','9','10','2','Costo orario','S',{ts '2020-11-10 15:26:00.810'},'assistenza','N','decimal(10,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.950'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','progettoudrmembro','8',null,null,null,'S',{ts '2020-05-25 13:23:18.950'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.950'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','progettoudrmembro','64',null,null,null,'S',{ts '2020-05-25 13:23:18.950'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.950'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','progettoudrmembro','4',null,null,null,'S',{ts '2020-05-25 13:23:18.950'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoudr' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.950'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoudr' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoudr','progettoudrmembro','4',null,null,null,'S',{ts '2020-05-25 13:23:18.950'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoudrmembro' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.950'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoudrmembro' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoudrmembro','progettoudrmembro','4',null,null,null,'S',{ts '2020-05-25 13:23:18.950'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogettoudrmembrokind' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ruolo',kind = 'S',lt = {ts '2020-11-17 13:06:26.967'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogettoudrmembrokind' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogettoudrmembrokind','progettoudrmembro','4',null,null,'Ruolo','S',{ts '2020-11-17 13:06:26.967'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Membro',kind = 'S',lt = {ts '2020-07-14 16:25:22.687'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','progettoudrmembro','4',null,null,'Membro','S',{ts '2020-07-14 16:25:22.687'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'impegno' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Mesi/uomo preventivati',kind = 'S',lt = {ts '2020-05-25 13:24:30.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'impegno' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('impegno','progettoudrmembro','4',null,null,'Mesi/uomo preventivati','S',{ts '2020-05-25 13:24:30.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','progettoudrmembro','8',null,null,null,'S',{ts '2020-05-25 13:23:18.953'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'progettoudrmembro')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:23:18.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'progettoudrmembro'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','progettoudrmembro','64',null,null,null,'S',{ts '2020-05-25 13:23:18.953'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA registry --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry] (
idreg int NOT NULL,
active char(1) NOT NULL,
annotation varchar(400) NULL,
authorization_free char(1) NULL,
badgecode varchar(20) NULL,
birthdate date NULL,
ccp varchar(12) NULL,
cf varchar(16) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
email_fe varchar(200) NULL,
extension varchar(200) NULL,
extmatricula varchar(40) NULL,
flag_pa char(1) NULL,
flagbankitaliaproceeds char(1) NULL,
foreigncf varchar(40) NULL,
forename varchar(50) NULL,
gender char(1) NULL,
idaccmotivecredit varchar(36) NULL,
idaccmotivedebit varchar(36) NULL,
idcategory varchar(2) NULL,
idcentralizedcategory varchar(20) NULL,
idcity int NULL,
idexternal int NULL,
idmaritalstatus varchar(20) NULL,
idnation int NULL,
idregistryclass varchar(2) NULL,
idregistrykind int NULL,
idtitle varchar(20) NULL,
ipa_fe varchar(7) NULL,
ipa_perlapa varchar(100) NULL,
location varchar(50) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maritalsurname varchar(50) NULL,
multi_cf char(1) NULL,
p_iva varchar(15) NULL,
pec_fe varchar(200) NULL,
residence int NOT NULL,
rtf image NULL,
sdi_defrifamm varchar(20) NULL,
sdi_norifamm char(1) NULL,
surname varchar(50) NULL,
title varchar(101) NOT NULL,
toredirect int NULL,
txt text NULL,
 CONSTRAINT xpkregistry PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'annotation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD annotation varchar(400) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN annotation varchar(400) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'authorization_free' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD authorization_free char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN authorization_free char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'badgecode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD badgecode varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN badgecode varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'birthdate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD birthdate date NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN birthdate date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ccp' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ccp varchar(12) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ccp varchar(12) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD cf varchar(16) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN cf varchar(16) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'email_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD email_fe varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN email_fe varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'extension' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD extension varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN extension varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'extmatricula' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD extmatricula varchar(40) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN extmatricula varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'flag_pa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD flag_pa char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN flag_pa char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'flagbankitaliaproceeds' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD flagbankitaliaproceeds char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN flagbankitaliaproceeds char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'foreigncf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD foreigncf varchar(40) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN foreigncf varchar(40) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'forename' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD forename varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN forename varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'gender' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD gender char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN gender char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idaccmotivecredit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idaccmotivecredit varchar(36) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idaccmotivecredit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idaccmotivedebit' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idaccmotivedebit varchar(36) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idaccmotivedebit varchar(36) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcategory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcategory varchar(2) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcategory varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcentralizedcategory' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcentralizedcategory varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcentralizedcategory varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idcity' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idcity int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idcity int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idexternal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idexternal int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idexternal int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idmaritalstatus' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idmaritalstatus varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idmaritalstatus varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idnation' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idnation int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idnation int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistryclass' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idregistryclass varchar(2) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idregistryclass varchar(2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idregistrykind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idregistrykind int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idregistrykind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'idtitle' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD idtitle varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN idtitle varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ipa_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ipa_fe varchar(7) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ipa_fe varchar(7) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'ipa_perlapa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD ipa_perlapa varchar(100) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN ipa_perlapa varchar(100) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'location' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD location varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN location varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'maritalsurname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD maritalsurname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN maritalsurname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'multi_cf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD multi_cf char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN multi_cf char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'p_iva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD p_iva varchar(15) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN p_iva varchar(15) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'pec_fe' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD pec_fe varchar(200) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN pec_fe varchar(200) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'residence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD residence int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'residence' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN residence int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'rtf' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD rtf image NULL 
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'sdi_defrifamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD sdi_defrifamm varchar(20) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN sdi_defrifamm varchar(20) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'sdi_norifamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD sdi_norifamm char(1) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN sdi_norifamm char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'surname' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD surname varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN surname varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD title varchar(101) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN title varchar(101) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'toredirect' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD toredirect int NULL 
END
ELSE
	ALTER TABLE [registry] ALTER COLUMN toredirect int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry' and C.name = 'txt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry] ADD txt text NULL 
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi1registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi1registry
     ON registry (p_iva )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi1registry
     ON registry (p_iva )
ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi2registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry (idregistrykind )
     WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi2registry
     ON registry (idregistrykind )
     WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='xi3registry' and id=object_id('registry'))
BEGIN
     CREATE NONCLUSTERED INDEX xi3registry
     ON registry (cf )
     WITH  DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX xi3registry
     ON registry (cf )
ON [PRIMARY]
END
GO

-- VERIFICA DI registry IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','int','nino','idreg','4','S','int','System.Int32','','','''nino''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','char(1)','nino','active','1','S','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(400)','nino','annotation','400','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','authorization_free','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','badgecode','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','date','nino','birthdate','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(12)','nino','ccp','12','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(16)','nino','cf','16','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','datetime','nino','ct','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(64)','nino','cu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','email_fe','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','extension','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(40)','nino','extmatricula','40','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','flag_pa','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','flagbankitaliaproceeds','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(40)','nino','foreigncf','40','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','forename','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','gender','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(36)','nino','idaccmotivecredit','36','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(36)','nino','idaccmotivedebit','36','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(2)','nino','idcategory','2','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idcentralizedcategory','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idcity','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idexternal','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idmaritalstatus','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idnation','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(2)','nino','idregistryclass','2','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','idregistrykind','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','idtitle','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(7)','nino','ipa_fe','7','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(100)','nino','ipa_perlapa','100','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','location','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','datetime','nino','lt','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(64)','nino','lu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','maritalsurname','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','multi_cf','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(15)','nino','p_iva','15','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(200)','nino','pec_fe','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','int','nino','residence','4','S','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','image','nino','rtf','16','N','image','System.Byte[]','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(20)','nino','sdi_defrifamm','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','char(1)','nino','sdi_norifamm','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','varchar(50)','nino','surname','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry','varchar(101)','nino','title','101','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','int','nino','toredirect','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry','text','nino','txt','16','N','text','System.String','','','''nino''','','N')
GO

-- VERIFICA DI registry IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry')
UPDATE customobject set isreal = 'S' where objectname = 'registry'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry')
UPDATE [tabledescr] SET description = 'Anagrafica',idapplication = null,isdbo = 'S',lt = {ts '1900-01-01 03:00:29.840'},lu = 'nino',title = 'Anagrafica' WHERE tablename = 'registry'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry','Anagrafica',null,'S',{ts '1900-01-01 03:00:29.840'},'nino','Anagrafica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'attivo',kind = 'S',lt = {ts '1900-01-01 02:59:57.380'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','registry','1',null,null,'attivo','S',{ts '1900-01-01 02:59:57.380'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annotation' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '400',col_precision = null,col_scale = null,description = 'Annotazioni',kind = 'S',lt = {ts '1900-01-01 03:00:15.987'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(400)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'annotation' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annotation','registry','400',null,null,'Annotazioni','S',{ts '1900-01-01 03:00:15.987'},'nino','N','varchar(400)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'authorization_free' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Esente ai fini dell''autorizzazione EQUITALIA. (S/N)',kind = 'C',lt = {ts '1900-01-01 02:59:04.323'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'authorization_free' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('authorization_free','registry','1',null,null,'Esente ai fini dell''autorizzazione EQUITALIA. (S/N)','C',{ts '1900-01-01 02:59:04.323'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'badgecode' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Codice badge',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'badgecode' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('badgecode','registry','20',null,null,'Codice badge','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'birthdate' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di nascita',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'birthdate' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('birthdate','registry','3',null,null,'Data di nascita','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ccp' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '12',col_precision = null,col_scale = null,description = 'Conto corrente postale di Riscossione',kind = 'S',lt = {ts '1900-01-01 02:59:04.333'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(12)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ccp' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ccp','registry','12',null,null,'Conto corrente postale di Riscossione','S',{ts '1900-01-01 02:59:04.333'},'nino','N','varchar(12)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'Codice fiscale',kind = 'S',lt = {ts '1900-01-01 03:00:10.587'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(16)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cf','registry','16',null,null,'Codice fiscale','S',{ts '1900-01-01 03:00:10.587'},'nino','N','varchar(16)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data creazione',kind = 'S',lt = {ts '1900-01-01 02:59:48.140'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry','8',null,null,'data creazione','S',{ts '1900-01-01 02:59:48.140'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome utente creazione',kind = 'S',lt = {ts '1900-01-01 02:59:45.573'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry','64',null,null,'nome utente creazione','S',{ts '1900-01-01 02:59:45.573'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'email_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-30 10:52:15.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'email_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('email_fe','registry','200',null,null,null,'S',{ts '2019-04-30 10:52:15.377'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extension' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = 'tabella che estende il record',kind = 'S',lt = {ts '2019-04-30 10:53:07.933'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extension' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extension','registry','200',null,null,'tabella che estende il record','S',{ts '2019-04-30 10:53:07.933'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'extmatricula' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'extmatricula' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('extmatricula','registry','40',null,null,'Matricola','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(40)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flag_pa' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Applica lo split payment  (per le fatture di vendita)',kind = 'C',lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flag_pa' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flag_pa','registry','1',null,null,'Applica lo split payment  (per le fatture di vendita)','C',{ts '2016-02-07 08:46:13.517'},'Nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Regolarizzazione Riscossioni presso  T.P.S. - Banca d''Italia',kind = 'C',lt = {ts '1900-01-01 02:59:04.353'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('flagbankitaliaproceeds','registry','1',null,null,'Regolarizzazione Riscossioni presso  T.P.S. - Banca d''Italia','C',{ts '1900-01-01 02:59:04.353'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'foreigncf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '40',col_precision = null,col_scale = null,description = 'Codice fiscale estero',kind = 'S',lt = {ts '1900-01-01 02:59:04.357'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(40)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'foreigncf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('foreigncf','registry','40',null,null,'Codice fiscale estero','S',{ts '1900-01-01 02:59:04.357'},'nino','N','varchar(40)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'forename' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Nome',kind = 'S',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'forename' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('forename','registry','50',null,null,'Nome','S',{ts '2016-02-03 09:45:20.063'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'gender' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Sesso (M/F)',kind = 'C',lt = {ts '1900-01-01 02:59:04.363'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'gender' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('gender','registry','1',null,null,'Sesso (M/F)','C',{ts '1900-01-01 02:59:04.363'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivecredit' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'ID Causale per i crediti (tabella accmotive)',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivecredit' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivecredit','registry','36',null,null,'ID Causale per i crediti (tabella accmotive)','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccmotivedebit' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '36',col_precision = null,col_scale = null,description = 'Id della causale di debito (tabella accmotive) ',kind = 'S',lt = {ts '1900-01-01 03:00:14.753'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(36)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idaccmotivedebit' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccmotivedebit','registry','36',null,null,'Id della causale di debito (tabella accmotive) ','S',{ts '1900-01-01 03:00:14.753'},'nino','N','varchar(36)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcategory' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'ID Categoria (tabella category)',kind = 'S',lt = {ts '1900-01-01 03:00:30.487'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcategory' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcategory','registry','2',null,null,'ID Categoria (tabella category)','S',{ts '1900-01-01 03:00:30.487'},'nino','N','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcentralizedcategory' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',kind = 'S',lt = {ts '1900-01-01 03:00:30.490'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idcentralizedcategory' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcentralizedcategory','registry','20',null,null,'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)','S',{ts '1900-01-01 03:00:30.490'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcity' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id citt? (tabella geo_city)',kind = 'S',lt = {ts '1900-01-01 03:00:02.247'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcity' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcity','registry','4',null,null,'id citt? (tabella geo_city)','S',{ts '1900-01-01 03:00:02.247'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idexternal' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id chiave in altri database, usato in migrazioni o simili',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idexternal' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idexternal','registry','4',null,null,'Id chiave in altri database, usato in migrazioni o simili','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idmaritalstatus' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Stato civile (tabella maritalstatus)',kind = 'S',lt = {ts '1900-01-01 03:00:30.697'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idmaritalstatus' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idmaritalstatus','registry','20',null,null,'ID Stato civile (tabella maritalstatus)','S',{ts '1900-01-01 03:00:30.697'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Id nazione (tabella geo_nation)',kind = 'S',lt = {ts '1900-01-01 03:00:14.990'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation','registry','4',null,null,'Id nazione (tabella geo_nation)','S',{ts '1900-01-01 03:00:14.990'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'id anagrafica (tabella registry)',kind = 'S',lt = {ts '1900-01-01 02:59:52.460'},lu = 'nino',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry','4',null,null,'id anagrafica (tabella registry)','S',{ts '1900-01-01 02:59:52.460'},'nino','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistryclass' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '2',col_precision = null,col_scale = null,description = 'ID Tipologie classificazione (tabella registryclass)',kind = 'S',lt = {ts '1900-01-01 03:00:30.737'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(2)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idregistryclass' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistryclass','registry','2',null,null,'ID Tipologie classificazione (tabella registryclass)','S',{ts '1900-01-01 03:00:30.737'},'nino','N','varchar(2)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idregistrykind' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'ID Classificazione Anagrafica (tabella registrykind)',kind = 'S',lt = {ts '1900-01-01 03:00:30.740'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idregistrykind' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idregistrykind','registry','4',null,null,'ID Classificazione Anagrafica (tabella registrykind)','S',{ts '1900-01-01 03:00:30.740'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtitle' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'ID Titolo (tabella title)',kind = 'S',lt = {ts '1900-01-01 03:00:30.837'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idtitle' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtitle','registry','20',null,null,'ID Titolo (tabella title)','S',{ts '1900-01-01 03:00:30.837'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ipa_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '7',col_precision = null,col_scale = null,description = 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(7)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'ipa_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ipa_fe','registry','7',null,null,'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','varchar(7)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'location' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'ubicazione',kind = 'S',lt = {ts '1900-01-01 03:00:11.413'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'location' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('location','registry','50',null,null,'ubicazione','S',{ts '1900-01-01 03:00:11.413'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'data ultima modifica',kind = 'S',lt = {ts '1900-01-01 02:59:42.897'},lu = 'nino',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry','8',null,null,'data ultima modifica','S',{ts '1900-01-01 02:59:42.897'},'nino','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = 'nome ultimo utente modifica',kind = 'S',lt = {ts '1900-01-01 02:59:39.927'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry','64',null,null,'nome ultimo utente modifica','S',{ts '1900-01-01 02:59:39.927'},'nino','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maritalsurname' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome acquisito',kind = 'S',lt = {ts '2016-02-03 09:51:28.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'maritalsurname' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maritalsurname','registry','50',null,null,'Cognome acquisito','S',{ts '2016-02-03 09:51:28.413'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'multi_cf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti duplicazione CF/P. IVA (S/N)',kind = 'C',lt = {ts '1900-01-01 02:59:04.423'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'multi_cf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('multi_cf','registry','1',null,null,'Consenti duplicazione CF/P. IVA (S/N)','C',{ts '1900-01-01 02:59:04.423'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'p_iva' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '15',col_precision = null,col_scale = null,description = 'Partita iva',kind = 'S',lt = {ts '1900-01-01 02:59:04.427'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(15)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'p_iva' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('p_iva','registry','15',null,null,'Partita iva','S',{ts '1900-01-01 02:59:04.427'},'nino','N','varchar(15)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'pec_fe' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '200',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-04-30 10:52:15.377'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(200)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'pec_fe' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('pec_fe','registry','200',null,null,null,'S',{ts '2019-04-30 10:52:15.377'},'assistenza','N','varchar(200)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'residence' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo residenza (chiave di tabella residence)',kind = 'C',lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'residence' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('residence','registry','4',null,null,'Tipo residenza (chiave di tabella residence)','C',{ts '2016-02-03 09:45:20.063'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'rtf' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'allegati',kind = 'S',lt = {ts '1900-01-01 02:59:58.567'},lu = 'nino',primarykey = 'N',sql_declaration = 'image',sql_type = 'image',system_type = 'System.Byte[]' WHERE colname = 'rtf' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('rtf','registry','16',null,null,'allegati','S',{ts '1900-01-01 02:59:58.567'},'nino','N','image','image','System.Byte[]')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sdi_defrifamm' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '20',col_precision = null,col_scale = null,description = 'Rif.Amministrazione di default per fattura elettronica',kind = 'S',lt = {ts '1900-01-01 02:59:04.437'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(20)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'sdi_defrifamm' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sdi_defrifamm','registry','20',null,null,'Rif.Amministrazione di default per fattura elettronica','S',{ts '1900-01-01 02:59:04.437'},'nino','N','varchar(20)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sdi_norifamm' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica',kind = 'S',lt = {ts '1900-01-01 02:59:04.440'},lu = 'nino',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'sdi_norifamm' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sdi_norifamm','registry','1',null,null,'Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica','S',{ts '1900-01-01 02:59:04.440'},'nino','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'surname' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Cognome',kind = 'S',lt = {ts '1900-01-01 03:00:15.383'},lu = 'nino',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'surname' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('surname','registry','50',null,null,'Cognome','S',{ts '1900-01-01 03:00:15.383'},'nino','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '101',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-09-02 17:25:36.273'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(101)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','registry','101',null,null,'Denominazione','S',{ts '2019-09-02 17:25:36.273'},'assistenza','N','varchar(101)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'toredirect' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'E'' stato usato in qualche migrazione',kind = 'S',lt = {ts '2016-10-09 09:46:41.937'},lu = 'nino',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'toredirect' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('toredirect','registry','4',null,null,'E'' stato usato in qualche migrazione','S',{ts '2016-10-09 09:46:41.937'},'nino','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'txt' AND tablename = 'registry')
UPDATE [coldescr] SET col_len = '16',col_precision = null,col_scale = null,description = 'note testuali',kind = 'S',lt = {ts '1900-01-01 02:59:58.263'},lu = 'nino',primarykey = 'N',sql_declaration = 'text',sql_type = 'text',system_type = 'System.String' WHERE colname = 'txt' AND tablename = 'registry'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('txt','registry','16',null,null,'note testuali','S',{ts '1900-01-01 02:59:58.263'},'nino','N','text','text','System.String')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER colvalue --
IF exists(SELECT * FROM [colvalue] WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Non esente ai fini dell''autorizzazione EQUITALIA.' WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('authorization_free','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','Non esente ai fini dell''autorizzazione EQUITALIA.')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Esente ai fini dell''autorizzazione EQUITALIA.' WHERE colname = 'authorization_free' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('authorization_free','registry','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Esente ai fini dell''autorizzazione EQUITALIA.')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',title = 'Non applicare lo split payment  (per le fatture di vendita)' WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flag_pa','registry','N',null,{ts '2016-02-07 08:46:13.517'},'Nino','Non applicare lo split payment  (per le fatture di vendita)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-07 08:46:13.517'},lu = 'Nino',title = 'Applica lo split payment  (per le fatture di vendita)' WHERE colname = 'flag_pa' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flag_pa','registry','S',null,{ts '2016-02-07 08:46:13.517'},'Nino','Applica lo split payment  (per le fatture di vendita)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'La regolarizzazione delle riscossioni avviene norm' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbankitaliaproceeds','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','La regolarizzazione delle riscossioni avviene norm')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = 'Si tratta presumibilmente di un ente  pubblico',lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Regolarizzazione riscoss. presso Banca d''Italia' WHERE colname = 'flagbankitaliaproceeds' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('flagbankitaliaproceeds','registry','S','Si tratta presumibilmente di un ente  pubblico',{ts '2016-01-29 14:10:19.543'},'lu','Regolarizzazione riscoss. presso Banca d''Italia')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'gender' AND tablename = 'registry' AND value = 'F')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Femmina' WHERE colname = 'gender' AND tablename = 'registry' AND value = 'F'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('gender','registry','F',null,{ts '2016-01-29 14:10:19.543'},'lu','Femmina')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'gender' AND tablename = 'registry' AND value = 'M')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Maschio' WHERE colname = 'gender' AND tablename = 'registry' AND value = 'M'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('gender','registry','M',null,{ts '2016-01-29 14:10:19.543'},'lu','Maschio')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'N')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Non consentire duplicazione cf/p.iva (la norma)' WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'N'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('multi_cf','registry','N',null,{ts '2016-01-29 14:10:19.543'},'lu','Non consentire duplicazione cf/p.iva (la norma)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'S')
UPDATE [colvalue] SET description = null,lt = {ts '2016-01-29 14:10:19.543'},lu = 'lu',title = 'Consenti duplicazione CF/P. IVA' WHERE colname = 'multi_cf' AND tablename = 'registry' AND value = 'S'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('multi_cf','registry','S',null,{ts '2016-01-29 14:10:19.543'},'lu','Consenti duplicazione CF/P. IVA')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '1')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente in Italia (coderesidence I)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '1'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','1',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente in Italia (coderesidence I)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '2')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente in altri paesi dell''UE (coderesidence J)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '2'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','2',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente in altri paesi dell''UE (coderesidence J)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '3')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Trasferimenti interni (code residence U)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '3'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','3',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Trasferimenti interni (code residence U)')
GO

IF exists(SELECT * FROM [colvalue] WHERE colname = 'residence' AND tablename = 'registry' AND value = '4')
UPDATE [colvalue] SET description = null,lt = {ts '2016-02-03 09:45:20.063'},lu = 'assistenza',title = 'Residente fuori dall''UE (coderesidence X)' WHERE colname = 'residence' AND tablename = 'registry' AND value = '4'
ELSE
INSERT INTO [colvalue] (colname,tablename,value,description,lt,lu,title) VALUES ('residence','registry','4',null,{ts '2016-02-03 09:45:20.063'},'assistenza','Residente fuori dall''UE (coderesidence X)')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relation --
IF exists(SELECT * FROM [relation] WHERE idrelation = '67')
UPDATE [relation] SET childtable = 'registry',description = 'ID Causale per i crediti (tabella accmotive)',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Anagrafica' WHERE idrelation = '67'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('67','registry','ID Causale per i crediti (tabella accmotive)',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '68')
UPDATE [relation] SET childtable = 'registry',description = 'Id della causale di debito (tabella accmotive) ',lt = {ts '2017-05-20 09:19:36.140'},lu = 'lu',parenttable = 'accmotive',title = 'Anagrafica' WHERE idrelation = '68'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('68','registry','Id della causale di debito (tabella accmotive) ',{ts '2017-05-20 09:19:36.140'},'lu','accmotive','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '351')
UPDATE [relation] SET childtable = 'registry',description = 'ID Categoria (tabella category)',lt = {ts '2017-05-20 09:19:42.160'},lu = 'lu',parenttable = 'category',title = 'Anagrafica' WHERE idrelation = '351'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('351','registry','ID Categoria (tabella category)',{ts '2017-05-20 09:19:42.160'},'lu','category','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '354')
UPDATE [relation] SET childtable = 'registry',description = 'ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',lt = {ts '2017-05-20 09:19:42.290'},lu = 'lu',parenttable = 'centralizedcategory',title = 'Anagrafica' WHERE idrelation = '354'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('354','registry','ID Classificazione centralizzata anagrafica (tabella centralizedcategory)',{ts '2017-05-20 09:19:42.290'},'lu','centralizedcategory','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '869')
UPDATE [relation] SET childtable = 'registry',description = 'id città (tabella geo_city)',lt = {ts '2017-05-20 09:19:52.420'},lu = 'lu',parenttable = 'geo_city',title = 'Anagrafica' WHERE idrelation = '869'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('869','registry','id città (tabella geo_city)',{ts '2017-05-20 09:19:52.420'},'lu','geo_city','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '893')
UPDATE [relation] SET childtable = 'registry',description = 'Id nazione (tabella geo_nation)',lt = {ts '2017-05-20 09:19:52.760'},lu = 'lu',parenttable = 'geo_nation',title = 'Anagrafica' WHERE idrelation = '893'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('893','registry','Id nazione (tabella geo_nation)',{ts '2017-05-20 09:19:52.760'},'lu','geo_nation','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1057')
UPDATE [relation] SET childtable = 'registry',description = 'Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',lt = {ts '2017-05-20 09:19:55.467'},lu = 'lu',parenttable = 'ipa',title = 'Anagrafica' WHERE idrelation = '1057'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1057','registry','Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.',{ts '2017-05-20 09:19:55.467'},'lu','ipa','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '1226')
UPDATE [relation] SET childtable = 'registry',description = 'ID Stato civile (tabella maritalstatus)',lt = {ts '2017-05-20 09:20:00.003'},lu = 'lu',parenttable = 'maritalstatus',title = 'Anagrafica' WHERE idrelation = '1226'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('1226','registry','ID Stato civile (tabella maritalstatus)',{ts '2017-05-20 09:20:00.003'},'lu','maritalstatus','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2111')
UPDATE [relation] SET childtable = 'registry',description = 'ID Tipologie classificazione (tabella registryclass)',lt = {ts '2017-05-20 09:20:06.217'},lu = 'lu',parenttable = 'registryclass',title = 'Anagrafica' WHERE idrelation = '2111'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2111','registry','ID Tipologie classificazione (tabella registryclass)',{ts '2017-05-20 09:20:06.217'},'lu','registryclass','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2113')
UPDATE [relation] SET childtable = 'registry',description = 'ID Classificazione Anagrafica (tabella registrykind)',lt = {ts '2017-05-20 09:20:06.390'},lu = 'lu',parenttable = 'registrykind',title = 'Anagrafica' WHERE idrelation = '2113'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2113','registry','ID Classificazione Anagrafica (tabella registrykind)',{ts '2017-05-20 09:20:06.390'},'lu','registrykind','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '2722')
UPDATE [relation] SET childtable = 'registry',description = 'ID Titolo (tabella title)',lt = {ts '2017-05-20 09:20:11.763'},lu = 'lu',parenttable = 'title',title = 'Anagrafica' WHERE idrelation = '2722'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('2722','registry','ID Titolo (tabella title)',{ts '2017-05-20 09:20:11.763'},'lu','title','Anagrafica')
GO

IF exists(SELECT * FROM [relation] WHERE idrelation = '3115')
UPDATE [relation] SET childtable = 'registry',description = 'Tipo residenza (chiave di tabella residence)',lt = {ts '2017-05-22 15:16:57.787'},lu = 'nino',parenttable = 'residence',title = 'Anagrafica' WHERE idrelation = '3115'
ELSE
INSERT INTO [relation] (idrelation,childtable,description,lt,lu,parenttable,title) VALUES ('3115','registry','Tipo residenza (chiave di tabella residence)',{ts '2017-05-22 15:16:57.787'},'nino','residence','Anagrafica')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER relationcol --
IF exists(SELECT * FROM [relationcol] WHERE idrelation = '67' AND parentcol = 'idaccmotive')
UPDATE [relationcol] SET childcol = 'idaccmotivecredit',lt = {ts '2017-05-20 09:19:36.287'},lu = 'lu' WHERE idrelation = '67' AND parentcol = 'idaccmotive'
ELSE
INSERT INTO [relationcol] (idrelation,parentcol,childcol,lt,lu) VALUES ('67','idaccmotive','idaccmotivecredit',{ts '2017-05-20 09:19:36.287'},'lu')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA registry_amministrativi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_amministrativi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_amministrativi] (
idreg int NOT NULL,
ct datetime NULL,
cu varchar(64) NULL,
cv nvarchar(max) NULL,
idcontrattokind int NULL,
lt datetime NULL,
lu varchar(64) NULL,
 CONSTRAINT xpkregistry_amministrativi PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_amministrativi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_amministrativi') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_amministrativi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD ct datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN ct datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cu varchar(64) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lt datetime NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lt datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_amministrativi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_amministrativi] ADD lu varchar(64) NULL 
END
ELSE
	ALTER TABLE [registry_amministrativi] ALTER COLUMN lu varchar(64) NULL
GO

-- VERIFICA DI registry_amministrativi IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_amministrativi'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_amministrativi','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','datetime','ASSISTENZA','lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_amministrativi','varchar(64)','ASSISTENZA','lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_amministrativi IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_amministrativi')
UPDATE customobject set isreal = 'S' where objectname = 'registry_amministrativi'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_amministrativi', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_amministrativi')
UPDATE [tabledescr] SET description = '2.7.8 Personale amministrativo',idapplication = null,isdbo = 'N',lt = {ts '2020-05-25 13:44:18.543'},lu = 'assistenza',title = 'Personale amministrativo' WHERE tablename = 'registry_amministrativi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_amministrativi','2.7.8 Personale amministrativo',null,'N',{ts '2020-05-25 13:44:18.543'},'assistenza','Personale amministrativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum vitae',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_amministrativi','0',null,null,'Curriculum vitae','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-25 13:44:54.460'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_amministrativi','4',null,null,'Tipo','S',{ts '2020-05-25 13:44:54.460'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_amministrativi','4',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_amministrativi','8',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_amministrativi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-25 13:44:21.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_amministrativi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_amministrativi','64',null,null,null,'S',{ts '2020-05-25 13:44:21.310'},'assistenza','N','varchar(64)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA registry_docenti --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registry_docenti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[registry_docenti] (
idreg int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
cv nvarchar(max) NULL,
idclassconsorsuale int NULL,
idcontrattokind int NULL,
idfonteindicebibliometrico int NULL,
idreg_istituti int NULL,
idsasd int NULL,
idstruttura int NULL,
indicebibliometrico int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
matricola varchar(50) NULL,
ricevimento nvarchar(max) NULL,
soggiorno varchar(255) NULL,
 CONSTRAINT xpkregistry_docenti PRIMARY KEY (idreg
)
)
END
GO

-- VERIFICA STRUTTURA registry_docenti --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'cv' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD cv nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN cv nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idclassconsorsuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idclassconsorsuale int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idclassconsorsuale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idcontrattokind int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idcontrattokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idfonteindicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idfonteindicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idfonteindicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idreg_istituti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idreg_istituti int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idreg_istituti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idsasd' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idsasd int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idsasd int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'indicebibliometrico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD indicebibliometrico int NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN indicebibliometrico int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('registry_docenti') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [registry_docenti] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'matricola' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD matricola varchar(50) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN matricola varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'ricevimento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD ricevimento nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN ricevimento nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registry_docenti' and C.name = 'soggiorno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [registry_docenti] ADD soggiorno varchar(255) NULL 
END
ELSE
	ALTER TABLE [registry_docenti] ALTER COLUMN soggiorno varchar(255) NULL
GO

-- VERIFICA DI registry_docenti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registry_docenti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','int','ASSISTENZA','indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registry_docenti','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(50)','ASSISTENZA','matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','nvarchar(max)','ASSISTENZA','ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registry_docenti','varchar(255)','ASSISTENZA','soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registry_docenti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registry_docenti')
UPDATE customobject set isreal = 'S' where objectname = 'registry_docenti'
ELSE
INSERT INTO customobject (objectname, isreal) values('registry_docenti', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'registry_docenti')
UPDATE [tabledescr] SET description = '2.4.20 docenti',idapplication = null,isdbo = 'N',lt = {ts '2018-11-29 16:25:52.000'},lu = 'Ferdinando',title = 'Docenti' WHERE tablename = 'registry_docenti'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('registry_docenti','2.4.20 docenti',null,'N',{ts '2018-11-29 16:25:52.000'},'Ferdinando','Docenti')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cv' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Curriculum Vitae',kind = 'S',lt = {ts '2018-11-27 13:37:14.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'cv' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cv','registry_docenti','0',null,null,'Curriculum Vitae','S',{ts '2018-11-27 13:37:14.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Classe consorsuale',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idclassconsorsuale' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idclassconsorsuale','registry_docenti','4',null,null,'Classe consorsuale','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo',kind = 'S',lt = {ts '2020-05-26 17:44:20.453'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','registry_docenti','4',null,null,'Tipo','S',{ts '2020-05-26 17:44:20.453'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Fonte',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idfonteindicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idfonteindicebibliometrico','registry_docenti','4',null,null,'Fonte','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Codice Istituto',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','registry_docenti','4',null,null,'Codice Istituto','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Istituto, Ente o Azienda',kind = 'S',lt = {ts '2019-02-15 17:21:00.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_istituti' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_istituti','registry_docenti','4',null,null,'Istituto, Ente o Azienda','S',{ts '2019-02-15 17:21:00.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsasd' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'SASD',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsasd' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsasd','registry_docenti','4',null,null,'SASD','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di afferenza',kind = 'S',lt = {ts '2019-09-09 18:32:55.953'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','registry_docenti','4',null,null,'Struttura di afferenza','S',{ts '2019-09-09 18:32:55.953'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Indice bibliometrico (H-Index)',kind = 'S',lt = {ts '2020-05-25 13:46:28.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'indicebibliometrico' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indicebibliometrico','registry_docenti','4',null,null,'Indice bibliometrico (H-Index)','S',{ts '2020-05-25 13:46:28.367'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','registry_docenti','8',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:12:08.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','registry_docenti','64',null,null,null,'S',{ts '2018-07-17 16:12:08.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'matricola' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Matricola',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'matricola' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('matricola','registry_docenti','50',null,null,'Matricola','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ricevimento' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Orari di ricevimento',kind = 'S',lt = {ts '2018-11-27 13:28:30.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'ricevimento' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ricevimento','registry_docenti','0',null,null,'Orari di ricevimento','S',{ts '2018-11-27 13:28:30.000'},'Ferdinando','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'soggiorno' AND tablename = 'registry_docenti')
UPDATE [coldescr] SET col_len = '255',col_precision = null,col_scale = null,description = 'Permesso di soggiorno',kind = 'S',lt = {ts '2018-11-27 13:17:34.000'},lu = 'Ferdinando',primarykey = 'N',sql_declaration = 'varchar(255)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'soggiorno' AND tablename = 'registry_docenti'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('soggiorno','registry_docenti','255',null,null,'Permesso di soggiorno','S',{ts '2018-11-27 13:17:34.000'},'Ferdinando','N','varchar(255)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA rendicontattivitaprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontattivitaprogetto] (
idrendicontattivitaprogetto int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datainizioprevista date NULL,
description varchar(max) NULL,
iditineration int NULL,
idprogetto int NOT NULL,
idreg int NOT NULL,
idworkpackage int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
orepreventivate int NULL,
 CONSTRAINT xpkrendicontattivitaprogetto PRIMARY KEY (idrendicontattivitaprogetto
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD datainizioprevista date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN datainizioprevista date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD description varchar(max) NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN description varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'iditineration' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD iditineration int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN iditineration int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idprogetto int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idreg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idreg int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idreg' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idreg int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN idworkpackage int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogetto' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogetto] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogetto] ALTER COLUMN orepreventivate int NULL
GO

-- VERIFICA DI rendicontattivitaprogetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','date','ASSISTENZA','datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogetto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogetto','int','ASSISTENZA','orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogetto')
UPDATE customobject set isreal = 'S' where objectname = 'rendicontattivitaprogetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogetto')
UPDATE [tabledescr] SET description = '2.7.3 Attivit? di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:12:22.837'},lu = 'assistenza',title = 'Attivit? di progetto' WHERE tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogetto','2.7.3 Attivit? di progetto',null,'N',{ts '2020-05-20 14:12:22.837'},'assistenza','Attivit? di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','rendicontattivitaprogetto','3',null,null,'Data inizio prevista','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','rendicontattivitaprogetto','-1',null,null,'Descrizione','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Missione',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iditineration' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iditineration','rendicontattivitaprogetto','4',null,null,'Missione','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','rendicontattivitaprogetto','4',null,null,'Progetto','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Partecipante',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg','rendicontattivitaprogetto','4',null,null,'Partecipante','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogetto','4',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Workpackage',kind = 'S',lt = {ts '2020-06-23 10:47:33.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','rendicontattivitaprogetto','4',null,null,'Workpackage','S',{ts '2020-06-23 10:47:33.167'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogetto','8',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:06:42.277'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogetto','64',null,null,null,'S',{ts '2020-05-20 14:06:42.277'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore preventivate',kind = 'S',lt = {ts '2020-06-23 10:48:50.413'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orepreventivate' AND tablename = 'rendicontattivitaprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orepreventivate','rendicontattivitaprogetto','4',null,null,'Numero di ore preventivate','S',{ts '2020-06-23 10:48:50.413'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA rendicontattivitaprogettoora --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettoora]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[rendicontattivitaprogettoora] (
idrendicontattivitaprogettoora int NOT NULL,
idrendicontattivitaprogetto int NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
data date NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore int NULL,
 CONSTRAINT xpkrendicontattivitaprogettoora PRIMARY KEY (idrendicontattivitaprogettoora,
idrendicontattivitaprogetto
)
)
END
GO

-- VERIFICA STRUTTURA rendicontattivitaprogettoora --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogettoora' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogettoora int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogettoora' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'idrendicontattivitaprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD idrendicontattivitaprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'idrendicontattivitaprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD data date NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN data date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('rendicontattivitaprogettoora') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [rendicontattivitaprogettoora] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'rendicontattivitaprogettoora' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [rendicontattivitaprogettoora] ADD ore int NULL 
END
ELSE
	ALTER TABLE [rendicontattivitaprogettoora] ALTER COLUMN ore int NULL
GO

-- VERIFICA DI rendicontattivitaprogettoora IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoora'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','int','ASSISTENZA','idrendicontattivitaprogettoora','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoora','date','ASSISTENZA','data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoora','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoora','int','ASSISTENZA','ore','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoora IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoora')
UPDATE customobject set isreal = 'S' where objectname = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoora', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'rendicontattivitaprogettoora')
UPDATE [tabledescr] SET description = 'Dettaglio giornaliero della 2.7.3 rendicontazione delle attivit? di progetto',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:11:37.107'},lu = 'assistenza',title = 'Dettaglio giornaliero della attivit? di progetto' WHERE tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('rendicontattivitaprogettoora','Dettaglio giornaliero della 2.7.3 rendicontazione delle attivit? di progetto',null,'N',{ts '2020-05-20 14:11:37.107'},'assistenza','Dettaglio giornaliero della attivit? di progetto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data',kind = 'S',lt = {ts '2020-05-20 14:11:37.110'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','rendicontattivitaprogettoora','3',null,null,'Data','S',{ts '2020-05-20 14:11:37.110'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Attivit? di progetto',kind = 'S',lt = {ts '2020-05-20 14:11:37.110'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogetto' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogetto','rendicontattivitaprogettoora','4',null,null,'Attivit? di progetto','S',{ts '2020-05-20 14:11:37.110'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 15:34:08.850'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idrendicontattivitaprogettoora' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idrendicontattivitaprogettoora','rendicontattivitaprogettoora','4',null,null,null,'S',{ts '2020-05-20 15:34:08.850'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','rendicontattivitaprogettoora','8',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:09:52.937'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','rendicontattivitaprogettoora','64',null,null,null,'S',{ts '2020-05-20 14:09:52.937'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero di ore',kind = 'S',lt = {ts '2020-05-20 14:11:57.517'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ore' AND tablename = 'rendicontattivitaprogettoora'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','rendicontattivitaprogettoora','4',null,null,'Numero di ore','S',{ts '2020-05-20 14:11:57.517'},'assistenza','N','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA sal --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[sal]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[sal] (
idsal int NOT NULL,
idprogetto int NOT NULL,
data date NULL,
 CONSTRAINT xpksal PRIMARY KEY (idsal,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA sal --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'idsal' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD idsal int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sal') and col.name = 'idsal' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sal] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sal') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sal] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sal' and C.name = 'data' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sal] ADD data date NULL 
END
ELSE
	ALTER TABLE [sal] ALTER COLUMN data date NULL
GO

-- VERIFICA DI sal IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sal'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sal','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','sal','int','assistenza','idsal','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','sal','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

-- VERIFICA DI sal IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sal')
UPDATE customobject set isreal = 'S' where objectname = 'sal'
ELSE
INSERT INTO customobject (objectname, isreal) values('sal', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'sal')
UPDATE [tabledescr] SET description = 'Stato avanzamento lavori',idapplication = null,isdbo = 'N',lt = {ts '2020-12-09 12:57:40.330'},lu = 'assistenza',title = 'Stato avanzamento lavori' WHERE tablename = 'sal'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('sal','Stato avanzamento lavori',null,'N',{ts '2020-12-09 12:57:40.330'},'assistenza','Stato avanzamento lavori')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'data' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-12-09 12:57:47.167'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'data' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('data','sal','3',null,null,null,'S',{ts '2020-12-09 12:57:47.167'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-12-09 12:57:47.167'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','sal','4',null,null,null,'S',{ts '2020-12-09 12:57:47.167'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsal' AND tablename = 'sal')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-12-09 12:57:47.167'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsal' AND tablename = 'sal'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsal','sal','4',null,null,null,'S',{ts '2020-12-09 12:57:47.167'},'assistenza','S','int','int','System.Int32')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE TABELLA workpackage --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workpackage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[workpackage] (
idworkpackage int NOT NULL,
idprogetto int NOT NULL,
acronimo nvarchar(2048) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description nvarchar(max) NULL,
idstruttura int NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
raggruppamento nvarchar(2048) NULL,
title nvarchar(2048) NULL,
 CONSTRAINT xpkworkpackage PRIMARY KEY (idworkpackage,
idprogetto
)
)
END
GO

-- VERIFICA STRUTTURA workpackage --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idworkpackage' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idworkpackage int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idworkpackage' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'idprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'acronimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD acronimo nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN acronimo nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD description nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN description nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD idstruttura int NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN idstruttura int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('workpackage') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [workpackage] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'raggruppamento' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD raggruppamento nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN raggruppamento nvarchar(2048) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'workpackage' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [workpackage] ADD title nvarchar(2048) NULL 
END
ELSE
	ALTER TABLE [workpackage] ALTER COLUMN title nvarchar(2048) NULL
GO

-- VERIFICA DI workpackage IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackage'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','int','assistenza','idworkpackage','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','acronimo','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(max)','assistenza','description','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','int','assistenza','idstruttura','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackage','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackage','nvarchar(2048)','assistenza','title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI workpackage IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackage')
UPDATE customobject set isreal = 'S' where objectname = 'workpackage'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackage', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'workpackage')
UPDATE [tabledescr] SET description = 'Workpackage',idapplication = null,isdbo = 'N',lt = {ts '2020-05-20 14:05:03.637'},lu = 'assistenza',title = 'Workpackage' WHERE tablename = 'workpackage'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('workpackage','Workpackage',null,'N',{ts '2020-05-20 14:05:03.637'},'assistenza','Workpackage')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'acronimo' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'acronimo' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('acronimo','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','workpackage','0',null,null,'Descrizione','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogetto' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Progetto',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogetto' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogetto','workpackage','4',null,null,'Progetto','S',{ts '2020-05-20 14:05:52.450'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Dipartimento',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','workpackage','4',null,null,'Dipartimento','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idupb' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Unità previsionale di base (UPB)',kind = 'S',lt = {ts '2020-11-02 18:25:36.680'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'idupb' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idupb','workpackage','50',null,null,'Unità previsionale di base (UPB)','S',{ts '2020-11-02 18:25:36.680'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idworkpackage' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.633'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idworkpackage' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idworkpackage','workpackage','4',null,null,null,'S',{ts '2020-05-20 14:05:05.633'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','workpackage','8',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-05-20 14:05:05.637'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','workpackage','64',null,null,null,'S',{ts '2020-05-20 14:05:05.637'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'raggruppamento' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-11-02 18:25:10.753'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'raggruppamento' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('raggruppamento','workpackage','2048',null,null,null,'S',{ts '2020-11-02 18:25:10.753'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'workpackage')
UPDATE [coldescr] SET col_len = '2048',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2020-05-20 14:05:52.450'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(2048)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'workpackage'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','workpackage','2048',null,null,'Titolo','S',{ts '2020-05-20 14:05:52.450'},'assistenza','N','nvarchar(2048)','nvarchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA affidamentodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodefaultview]
GO

CREATE VIEW [dbo].[affidamentodefaultview] AS SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento, affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno, erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind, registry_registry_docentidocenti.title AS registrydocenti_title, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title AS affidamento_title, affidamento.urlcorso AS affidamento_urlcorso, isnull('Affidamento: ' + affidamento.json + '; ','') as dropdown_title FROM affidamento WITH (NOLOCK)  LEFT OUTER JOIN affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = affidamentokind.idaffidamentokind LEFT OUTER JOIN erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = erogazkind.iderogazkind LEFT OUTER JOIN registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON affidamento.idreg_docenti = registry_docentidocenti.idreg LEFT OUTER JOIN registry AS registry_registry_docentidocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registry_registry_docentidocenti.idreg WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL 
GO

-- VERIFICA DI affidamentodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','datetime','ASSISTENZA','affidamento_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','varchar(64)','ASSISTENZA','affidamento_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(2)','ASSISTENZA','affidamento_freqobbl','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','int','ASSISTENZA','affidamento_frequenzaminima','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','int','ASSISTENZA','affidamento_frequenzaminimadebito','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(2)','ASSISTENZA','affidamento_gratuito','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','affidamento_idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','int','ASSISTENZA','affidamento_iderogazkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','','affidamento_idsede','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_jsonancestor','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','datetime','ASSISTENZA','affidamento_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','varchar(64)','ASSISTENZA','affidamento_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_orariric','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_orariric_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','int','ASSISTENZA','affidamento_paridaffidamento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_prog','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_prog_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(2)','ASSISTENZA','affidamento_riferimento','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','date','ASSISTENZA','affidamento_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','date','ASSISTENZA','affidamento_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_testi','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_testi_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','affidamento_title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(512)','ASSISTENZA','affidamento_urlcorso','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(50)','ASSISTENZA','affidamentokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(50)','ASSISTENZA','erogazkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodefaultview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','nvarchar(max)','ASSISTENZA','json','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodefaultview','varchar(101)','ASSISTENZA','registrydocenti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI affidamentodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'affidamentodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA affidamentodocview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[affidamentodocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[affidamentodocview]
GO

CREATE VIEW [dbo].[affidamentodocview] AS SELECT  affidamento.aa, affidamento.ct AS affidamento_ct, affidamento.cu AS affidamento_cu,CASE WHEN affidamento.freqobbl = 'S' THEN 'Si' WHEN affidamento.freqobbl = 'N' THEN 'No' END AS affidamento_freqobbl, affidamento.frequenzaminima AS affidamento_frequenzaminima, affidamento.frequenzaminimadebito AS affidamento_frequenzaminimadebito,CASE WHEN affidamento.gratuito = 'S' THEN 'Si' WHEN affidamento.gratuito = 'N' THEN 'No' END AS affidamento_gratuito, affidamento.idaffidamento, affidamentokind.title AS affidamentokind_title, affidamento.idaffidamentokind AS affidamento_idaffidamentokind, affidamento.idattivform, affidamento.idcanale, affidamento.idcorsostudio, affidamento.iddidprog, affidamento.iddidproganno, affidamento.iddidprogcurr, affidamento.iddidprogori, affidamento.iddidprogporzanno, erogazkind.title AS erogazkind_title, affidamento.iderogazkind AS affidamento_iderogazkind, affidamento.idreg_docenti, affidamento.idsede AS affidamento_idsede, affidamento.json AS affidamento_json, affidamento.jsonancestor AS affidamento_jsonancestor, affidamento.lt AS affidamento_lt, affidamento.lu AS affidamento_lu, affidamento.orariric AS affidamento_orariric, affidamento.orariric_en AS affidamento_orariric_en, affidamento.paridaffidamento AS affidamento_paridaffidamento, affidamento.prog AS affidamento_prog, affidamento.prog_en AS affidamento_prog_en,CASE WHEN affidamento.riferimento = 'S' THEN 'Si' WHEN affidamento.riferimento = 'N' THEN 'No' END AS affidamento_riferimento, affidamento.start AS affidamento_start, affidamento.stop AS affidamento_stop, affidamento.testi AS affidamento_testi, affidamento.testi_en AS affidamento_testi_en, affidamento.title, affidamento.urlcorso AS affidamento_urlcorso, isnull('Title: ' + affidamento.title + '; ','') as dropdown_title FROM affidamento WITH (NOLOCK)  LEFT OUTER JOIN affidamentokind WITH (NOLOCK) ON affidamento.idaffidamentokind = affidamentokind.idaffidamentokind LEFT OUTER JOIN erogazkind WITH (NOLOCK) ON affidamento.iderogazkind = erogazkind.iderogazkind WHERE  affidamento.aa IS NOT NULL  AND affidamento.idaffidamento IS NOT NULL  AND affidamento.idattivform IS NOT NULL  AND affidamento.idcanale IS NOT NULL  AND affidamento.idcorsostudio IS NOT NULL  AND affidamento.iddidprog IS NOT NULL  AND affidamento.iddidproganno IS NOT NULL  AND affidamento.iddidprogcurr IS NOT NULL  AND affidamento.iddidprogori IS NOT NULL  AND affidamento.iddidprogporzanno IS NOT NULL  AND affidamento.idreg_docenti IS NOT NULL 
GO

-- VERIFICA DI affidamentodocview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'affidamentodocview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','varchar(9)','','aa','9','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','datetime','','affidamento_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','varchar(64)','','affidamento_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(2)','','affidamento_freqobbl','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','int','','affidamento_frequenzaminima','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','int','','affidamento_frequenzaminimadebito','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(2)','','affidamento_gratuito','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','affidamento_idaffidamentokind','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','int','','affidamento_iderogazkind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','affidamento_idsede','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_json','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_jsonancestor','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','datetime','','affidamento_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','varchar(64)','','affidamento_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_orariric','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_orariric_en','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','int','','affidamento_paridaffidamento','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_prog','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_prog_en','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(2)','','affidamento_riferimento','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','date','','affidamento_start','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','date','','affidamento_stop','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_testi','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','affidamento_testi_en','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(512)','','affidamento_urlcorso','512','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(50)','','affidamentokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','nvarchar(max)','','dropdown_title','0','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','varchar(50)','','erogazkind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','idaffidamento','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','idattivform','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','idcanale','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','idcorsostudio','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','iddidprog','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','iddidproganno','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','iddidprogcurr','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','iddidprogori','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','affidamentodocview','int','','iddidprogporzanno','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','int','','idreg_docenti','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','affidamentodocview','nvarchar(max)','','title','0','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI affidamentodocview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'affidamentodocview')
UPDATE customobject set isreal = 'N' where objectname = 'affidamentodocview'
ELSE
INSERT INTO customobject (objectname, isreal) values('affidamentodocview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA assetdiarydocview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assetdiarydocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[assetdiarydocview]
GO

CREATE VIEW [dbo].[assetdiarydocview] AS SELECT  assetdiary.ct AS assetdiary_ct, assetdiary.cu AS assetdiary_cu, assetdiary.idasset AS assetdiary_idasset, assetdiary.idassetdiary, amministrazione.assetacquire.description AS assetacquire_description, amministrazione.assetacquire.idinv AS assetacquire_idinv, amministrazione.asset.idasset AS asset_idasset, amministrazione.asset.idpiece AS asset_idpiece, amministrazione.inventory.description AS inventory_description, amministrazione.asset.ninventory AS asset_ninventory, amministrazione.asset.rfid AS asset_rfid, assetdiary.idpiece, progetto.titolobreve AS progetto_titolobreve, assetdiary.idprogetto, assetdiary.idreg AS assetdiary_idreg, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, assetdiary.idworkpackage AS assetdiary_idworkpackage, assetdiary.lt AS assetdiary_lt, assetdiary.lu AS assetdiary_lu, assetdiary.orepreventivate AS assetdiary_orepreventivate, isnull('Descrizione Descrizione: ' + amministrazione.assetacquire.description + '; ','') + ' ' + isnull('Class. Inv. Descrizione: ' + CAST( amministrazione.assetacquire.idinv AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.idasset AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.idpiece AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + CAST( amministrazione.asset.ninventory AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Bene strumentale: ' + amministrazione.asset.rfid + '; ','') + ' ' + isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Descrizione Inventario: ' + amministrazione.inventory.description + '; ','') as dropdown_title FROM assetdiary WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.asset WITH (NOLOCK) ON assetdiary.idasset = amministrazione.asset.idasset AND assetdiary.idpiece = amministrazione.asset.idpiece LEFT OUTER JOIN amministrazione.assetacquire WITH (NOLOCK) ON asset.nassetacquire = amministrazione.assetacquire.nassetacquire LEFT OUTER JOIN amministrazione.inventory WITH (NOLOCK) ON asset.idinventory = amministrazione.inventory.idinventory LEFT OUTER JOIN progetto WITH (NOLOCK) ON assetdiary.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON assetdiary.idworkpackage = workpackage.idworkpackage WHERE  assetdiary.idassetdiary IS NOT NULL 
GO

-- VERIFICA DI assetdiarydocview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetdiarydocview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_idasset','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_idpiece','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','asset_ninventory','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(30)','','asset_rfid','30','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(150)','','assetacquire_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','assetacquire_idinv','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','datetime','','assetdiary_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','varchar(64)','','assetdiary_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idasset','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','assetdiary_idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','datetime','','assetdiary_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','varchar(64)','','assetdiary_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','assetdiary_orepreventivate','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','nvarchar(2713)','','dropdown_title','2713','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','idassetdiary','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','int','','idpiece','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assetdiarydocview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','varchar(50)','','inventory_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assetdiarydocview','nvarchar(2048)','','workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI assetdiarydocview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetdiarydocview')
UPDATE customobject set isreal = 'N' where objectname = 'assetdiarydocview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetdiarydocview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA canaleerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[canaleerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[canaleerogataview]
GO

CREATE VIEW [dbo].[canaleerogataview] AS SELECT  canale.aa, canale.ct AS canale_ct, canale.cu AS canale_cu, canale.CUIN AS canale_CUIN, attivform.title AS attivform_title, canale.idattivform, canale.idcanale, canale.idcorsostudio, canale.iddidprog, didproganno.title AS didproganno_title, canale.iddidproganno, didprogcurr.title AS didprogcurr_title, canale.iddidprogcurr, didprogori.title AS didprogori_title, canale.iddidprogori, didprogporzanno.title AS didprogporzanno_title, canale.iddidprogporzanno, canale.idsede AS canale_idsede, canale.lt AS canale_lt, canale.lu AS canale_lu, canale.numerostud AS canale_numerostud, canale.sortcode AS canale_sortcode, canale.title, isnull('Denominazione: ' + canale.title + '; ','') as dropdown_title FROM canale WITH (NOLOCK)  LEFT OUTER JOIN attivform WITH (NOLOCK) ON canale.idattivform = attivform.idattivform LEFT OUTER JOIN didproganno WITH (NOLOCK) ON canale.iddidproganno = didproganno.iddidproganno LEFT OUTER JOIN didprogcurr WITH (NOLOCK) ON canale.iddidprogcurr = didprogcurr.iddidprogcurr LEFT OUTER JOIN didprogori WITH (NOLOCK) ON canale.iddidprogori = didprogori.iddidprogori LEFT OUTER JOIN didprogporzanno WITH (NOLOCK) ON canale.iddidprogporzanno = didprogporzanno.iddidprogporzanno WHERE  canale.aa IS NOT NULL  AND canale.idattivform IS NOT NULL  AND canale.idcanale IS NOT NULL  AND canale.idcorsostudio IS NOT NULL  AND canale.iddidprog IS NOT NULL  AND canale.iddidproganno IS NOT NULL  AND canale.iddidprogcurr IS NOT NULL  AND canale.iddidprogori IS NOT NULL  AND canale.iddidprogporzanno IS NOT NULL 
GO

-- VERIFICA DI canaleerogataview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'canaleerogataview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','nvarchar(max)','ASSISTENZA','attivform_title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','datetime','ASSISTENZA','canale_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(64)','ASSISTENZA','canale_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(9)','ASSISTENZA','canale_CUIN','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','','canale_idsede','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','datetime','ASSISTENZA','canale_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(64)','ASSISTENZA','canale_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','int','ASSISTENZA','canale_numerostud','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','int','ASSISTENZA','canale_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(2048)','ASSISTENZA','didproganno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','didprogcurr_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','didprogori_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(2048)','ASSISTENZA','didprogporzanno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(273)','ASSISTENZA','dropdown_title','273','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI canaleerogataview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'canaleerogataview')
UPDATE customobject set isreal = 'N' where objectname = 'canaleerogataview'
ELSE
INSERT INTO customobject (objectname, isreal) values('canaleerogataview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA dichiarsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[dichiarsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[dichiarsegview]
GO

CREATE VIEW [dbo].[dichiarsegview] AS SELECT  dichiar.aa, dichiar.ct AS dichiar_ct, dichiar.cu AS dichiar_cu, dichiar.date AS dichiar_date, dichiar.extension AS dichiar_extension, dichiar.iddichiar, dichiarkind.title AS dichiarkind_title, dichiar.iddichiarkind, dichiar.idreg, dichiar.lt AS dichiar_lt, dichiar.lu AS dichiar_lu, dichiar.protanno AS dichiar_protanno, dichiar.protnumero AS dichiar_protnumero, isnull('Tipologia: ' + dichiarkind.title + '; ','') + ' ' + isnull('Anno Accademico: ' + dichiar.aa + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, dichiar.date, 103),'') as dropdown_title FROM dichiar WITH (NOLOCK)  LEFT OUTER JOIN dichiarkind WITH (NOLOCK) ON dichiar.iddichiarkind = dichiarkind.iddichiarkind WHERE  dichiar.iddichiar IS NOT NULL  AND dichiar.idreg IS NOT NULL 
GO

-- VERIFICA DI dichiarsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'dichiarsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','datetime','ASSISTENZA','dichiar_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(64)','ASSISTENZA','dichiar_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','date','ASSISTENZA','dichiar_date','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(200)','ASSISTENZA','dichiar_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','datetime','ASSISTENZA','dichiar_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(64)','ASSISTENZA','dichiar_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','int','ASSISTENZA','dichiar_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','int','ASSISTENZA','dichiar_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','dichiarsegview','varchar(50)','ASSISTENZA','dichiarkind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','varchar(127)','ASSISTENZA','dropdown_title','127','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','iddichiar','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','iddichiarkind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','dichiarsegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI dichiarsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'dichiarsegview')
UPDATE customobject set isreal = 'N' where objectname = 'dichiarsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('dichiarsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA diderogdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[diderogdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[diderogdefaultview]
GO

CREATE VIEW [dbo].[diderogdefaultview] AS SELECT  diderog.aa, corsostudio.title AS corsostudio_title, corsostudio.annoistituz AS corsostudio_annoistituz, diderog.idcorsostudio, sede.title AS sede_title, diderog.idsede,CASE WHEN diderog.inesaurimento = 'S' THEN 'Si' WHEN diderog.inesaurimento = 'N' THEN 'No' END AS diderog_inesaurimento, isnull('Corso di studio: ' + corsostudio.title + '; ','') + ' ' + isnull('Corso di studio: ' + CAST( corsostudio.annoistituz AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Anno Accademico: ' + diderog.aa + '; ','') + ' ' + isnull('Identificativo: ' + sede.title + '; ','') as dropdown_title FROM diderog WITH (NOLOCK)  LEFT OUTER JOIN corsostudio WITH (NOLOCK) ON diderog.idcorsostudio = corsostudio.idcorsostudio LEFT OUTER JOIN sede WITH (NOLOCK) ON diderog.idsede = sede.idsede WHERE  diderog.aa IS NOT NULL  AND diderog.idcorsostudio IS NOT NULL  AND diderog.idsede IS NOT NULL 
GO

-- VERIFICA DI diderogdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'diderogdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','varchar(2)','ASSISTENZA','diderog_inesaurimento','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','nvarchar(2199)','ASSISTENZA','dropdown_title','2199','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','diderogdefaultview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','diderogdefaultview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI diderogdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'diderogdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'diderogdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('diderogdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA casualcontractworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[casualcontractworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [casualcontractworkpackageview]
GO


CREATE VIEW [casualcontractworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	substring('Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon),1,35)  as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	--Calcola il pagato con i Mov. di spesa
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensecasualcontract EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	null as idpettycash, null as yoperation, null as noperation,
	null as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensecasualcontract EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.ycon, C.ncon, C.description as descriptioncasualcontract,
	'Contratto Occasionale '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	null as idexppayed,
	null AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	-- Calcola il pagato col fondo economale
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from casualcontract C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
LEFT OUTER join  pettycashoperationcasualcontract PCO ON PCO.ycon = C.ycon AND PCO.ncon = C.ncon
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'cascon' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 

GO

-- VERIFICA DI casualcontractworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'casualcontractworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptioncasualcontract','150','''assistenza''','varchar(150)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','37','''assistenza''','varchar(37)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','casualcontractworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','casualcontractworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','26','''assistenza''','varchar(26)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','casualcontractworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','casualcontractworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycashpayedamount','9','''assistenza''','decimal(19,2)','casualcontractworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','casualcontractworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','casualcontractworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','casualcontractworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','casualcontractworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI casualcontractworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'casualcontractworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'casualcontractworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('casualcontractworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA invoicedetailexpworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicedetailexpworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicedetailexpworkpackageview]
GO


-- Per invoicedetail è sufficiente che progettocosto vada in join con idrelated, perchè l'idrelated ha il rownum


CREATE        VIEW [invoicedetailexpworkpackageview]
as
select 
	I.idinvkind, I.yinv, I.ninv,
		CASE
			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
		END as flagbuysell, 
		CASE
			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		END as flagvariation ,
	I.description as descriptioninvoice,
	substring('Doc.IVA:' + I.doc,1,35) as doc,
	I.docdate,
	Idet.rownum,
	Idet.idupb,
	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	IDET.idexp_taxable,
	IDET.idexp_iva,
	-- Indica che la fattura è stata pagata col fondo economale.
	NULL AS idpettycash, NULL as yoperation, NULL as noperation,--PCI.idpettycash , PCI.yoperation, PCI.noperation,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
			 as iva_euro,
-- Calcola il pagato
		case 
			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS  NULL then 0
			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  not NULL 
					then CONVERT(decimal(19,2),
						ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
						CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2)) 
						+ CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idexp_taxable IS NULL and  IDET.idexp_iva IS not NULL then CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
			when IDET.idexp_taxable IS not NULL and  IDET.idexp_iva IS  NULL then CONVERT(decimal(19,2),
							ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
							CONVERT(DECIMAL(19,10),I.exchangerate) *	 (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
		end AS payedamount,
	PC.idprogettocosto
from invoice I 
JOIN invoicekind 		
	ON invoicekind.idinvkind = I.idinvkind
join invoicedetail IDET 
	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = Idet.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage

left outer join progettocosto PC
	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
UNION all
select 
	I.idinvkind, I.yinv, I.ninv,
		CASE
			WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((invoicekind.flag&1)<>0) THEN 'V'
		END as flagbuysell, 
		CASE
			WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
			WHEN ((invoicekind.flag&4)<>0) THEN 'S'
		END as flagvariation ,
	I.description as descriptioninvoice,
	I.doc,
	I.docdate,
	Idet.rownum,
	Idet.idupb,
	'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	NULL,--IDET.idexp_taxable,
	NULL,--IDET.idexp_iva,
	-- Indica che la fattura è stata pagata col fondo economale.
	PCI.idpettycash , PCI.yoperation, PCI.noperation,
	-- IMPONIBILE 
		CONVERT(decimal(19,2),
		ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
		  CONVERT(DECIMAL(19,10),I.exchangerate) *
		  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
		 ,2
		)) as taxable_euro,
	-- IVA
	CONVERT(decimal(19,2),ROUND(IDET.tax,2))
			 as iva_euro,
-- Calcola il pagato
			CONVERT(decimal(19,2),
				ROUND(IDET.taxable * ISNULL(IDET.npackage, IDET.number) * 
					CONVERT(DECIMAL(19,10),I.exchangerate) *	  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))) ,2))
				+
				CONVERT(decimal(19,2),ROUND(IDET.tax,2)	)
		AS payedamount,
	PC.idprogettocosto
from invoice I 
JOIN invoicekind 		
	ON invoicekind.idinvkind = I.idinvkind
join invoicedetail IDET 
	ON I.idinvkind = IDET.idinvkind  and I.yinv = IDET.yinv and I.ninv = IDET.ninv
join progettotipocostoaccmotive PM 	
	on PM.idaccmotive = Idet.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
join progetto P 
	on PM.idprogetto = P.idprogetto
join workpackageupb WPU 
	on WPU.idprogetto = P.idprogetto and WPU.idupb = IDET.idupb
join workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
join pettycashoperationinvoice PCI
	on  PCI.idinvkind = I.idinvkind and PCI.yinv = I.yinv and PCI.ninv = I.ninv
left outer join progettocosto PC
	on 'inv' + '§' + convert(varchar(4), IDET.idinvkind) + '§'  + convert(varchar(4), IDET.yinv) + '§'  + convert(varchar(14),IDET.ninv)+ '§'  + convert(varchar(10),IDET.rownum) = PC.idrelated
	and PCI.idpettycash = PC.idpettycash AND PCI.yoperation = PC.yoperation AND PCI.noperation = PC.noperation    	 



GO

-- VERIFICA DI invoicedetailexpworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'invoicedetailexpworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptioninvoice','150','''assistenza''','varchar(150)','invoicedetailexpworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','invoicedetailexpworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagbuysell','1','''assistenza''','varchar(1)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagvariation','1','''assistenza''','varchar(1)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp_iva','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexp_taxable','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idinvkind','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','39','''assistenza''','varchar(39)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','invoicedetailexpworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','iva_euro','9','''assistenza''','decimal(19,2)','invoicedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ninv','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','payedamount','13','''assistenza''','decimal(20,2)','invoicedetailexpworkpackageview','','20','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','rownum','4','''assistenza''','int','invoicedetailexpworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','taxable_euro','9','''assistenza''','decimal(19,2)','invoicedetailexpworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','invoicedetailexpworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yinv','2','''assistenza''','smallint','invoicedetailexpworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','invoicedetailexpworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI invoicedetailexpworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'invoicedetailexpworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'invoicedetailexpworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('invoicedetailexpworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA itinerationworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationworkpackageview]
GO


--select  * from itinerationworkpackageview

CREATE        VIEW [itinerationworkpackageview]
as
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	EL.idexp as idexppayed,
	isnull(EY.amount,0) AS exppayedamount,
	null as idpettycash, 
	null as yoperation, 
	null as noperation,
	null as  pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
-- Legge il pagato con i movimenti di spesa
left outer join expenseitineration EC on EC.iditineration = C.iditineration
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PC.idexp = EL.idexp	 
UNION all
select 
	C.iditineration,
	C.yitineration, C.nitineration, C.description as descriptionitineration,
	'Mis.  '+ convert(varchar(4), C.yitineration) + '/' + convert(varchar(10), C.nitineration) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.totalgross,
	NULL as idexppayed,
	NULL AS exppayedamount,
	PCO.idpettycash, PCO.yoperation, PCO.noperation,
	isnull(PO.amount,0)  as pettycashpayedamount,
	PC.idprogettocosto
from itineration C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--- Legge il pagato con la piccola spesa
LEFT OUTER join  pettycashoperationitineration PCO ON PCO.iditineration = C.iditineration
left outer JOIN pettycashoperation PO ON PCO.idpettycash = PO.idpettycash AND PCO.yoperation = PO.yoperation AND PCO.noperation = PO.noperation    
left outer join progettocosto PC
	on 'itineration' + '§' + convert(varchar(4),yitineration) + '§'  + 	convert(varchar(14),nitineration)= PC.idrelated
	and PCO.idpettycash = PC.idpettycash AND PCO.yoperation = PC.yoperation AND PCO.noperation = PC.noperation    	 

GO

-- VERIFICA DI itinerationworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionitineration','150','''assistenza''','varchar(150)','itinerationworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','21','''assistenza''','varchar(21)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','iditineration','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpettycash','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','31','''assistenza''','varchar(31)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','itinerationworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','nitineration','4','''assistenza''','int','itinerationworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','itinerationworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycashpayedamount','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','itinerationworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','itinerationworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','totalgross','9','''assistenza''','decimal(19,2)','itinerationworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','yitineration','2','''assistenza''','smallint','itinerationworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','itinerationworkpackageview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI itinerationworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA payrollworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[payrollworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrollworkpackageview]
GO

-- select  * from payrollworkpackageview
CREATE        VIEW [payrollworkpackageview]
as
select 
C.idpayroll,
	CC.ycon, CC.ncon,
	CC.duty as description,
	'Cedolino ' + convert(varchar(4), C.fiscalyear) + '/' + convert(varchar(10), C.npayroll) +
	' contr.' +	convert(varchar(4), CC.ycon) + '/' + convert(varchar(10), CC.ncon) 	 as doc,
	disbursementdate as docdate,
	C.start, C.stop,
	C.idupb,
	'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	-- Legge il pagato
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensepayroll EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from payroll C 
join parasubcontract CC ON C.idcon = CC.idcon and C.flagbalance='N'
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = CC.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensepayroll EC on EC.idpayroll= C.idpayroll
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'payroll' + '§' + convert(varchar(5),C.idpayroll) + '§'  + 	convert(varchar(4),C.fiscalyear) + '§'  + convert(varchar(14),C.npayroll) = PC.idrelated
	and PC.idexp = EL.idexp

	


GO

-- VERIFICA DI payrollworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payrollworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','150','''assistenza''','varchar(150)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','46','''assistenza''','varchar(46)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','payrollworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','payrollworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','payrollworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idpayroll','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','payrollworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','33','''assistenza''','varchar(33)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','38','''assistenza''','varchar(38)','payrollworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','20','''assistenza''','varchar(20)','payrollworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','payrollworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','payrollworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','payrollworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','payrollworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

-- VERIFICA DI payrollworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payrollworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'payrollworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payrollworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA rendicontattivitaprogettoworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettoworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettoworkpackageview]
GO


CREATE        VIEW [rendicontattivitaprogettoworkpackageview]
as
select	RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PK.oredivisionecostostipendio,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettocosto,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore,-- ore lavorate
		( select top 1 C.idcontrattokind from contratto C  where C.idreg = RA.idreg
			and RDETT.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontrattokind,
		RA.description,
		PUM.costoorario
		--------
		--,PUM.idprogettoudrmembro
		--,PUM.idprogettoudr
		--,PUM.idprogetto
		--,RA.idprogetto
		-- Mi leggo le ore lavorate e il Tipo contratto "corrente". Nella function farò la SUM ore lavorate di quel tipo contratto * costo orario
from rendicontattivitaprogetto RA
JOIN rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join registry_docenti R on RA.idreg = R.idreg --> DOCENTI
join progettotipocostocontrattokind PTC on PTC.idcontrattokind = R.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P on P.idprogetto = RA.idprogetto
join progettokind PK on P.idprogettokind = PK.idprogettokind
join progettoudrmembro PUM on PUM.idprogetto = P.idprogetto and PUM.idreg = R.idreg
left outer join progettocosto PC on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, RA.idworkpackage,RA.idprogetto, PTC.idprogettotipocosto, PC.idprogettocosto,	RA.idrendicontattivitaprogetto,	RDETT.idrendicontattivitaprogettoora, RDETT.data, RA.description, PK.oredivisionecostostipendio, PUM.costoorario
-------
--,PUM.idprogettoudrmembro
--,PUM.idprogettoudr
--,PUM.idprogetto
--,RA.idprogetto
UNION ALL	 

select	RA.idreg, 
		RA.idworkpackage, 
		RA.idprogetto,
		PK.oredivisionecostostipendio,
		PTC.idprogettotipocosto,
		null as amount,
		PC.idprogettocosto,
		RA.idrendicontattivitaprogetto,
		RDETT.idrendicontattivitaprogettoora,
		RDETT.data,--data in cui ha lavorato
		isnull(sum(RDETT.ore),0) as ore ,-- ore lavorate
		( select top 1 C.idcontrattokind from contratto C  where C.idreg = RA.idreg
			and RDETT.data between C.start and  isnull(C.stop,{d '2079-01-01'})
			order by C.start desc) as idcontrattokind,
		RA.description,
		PUM.costoorario
		-- Mi leggo le ore lavorate e il Tipo contratto "corrente". Nella function farò la SUM ore lavorate di quel tipo contratto * costo orario
from rendicontattivitaprogetto RA
JOIN  rendicontattivitaprogettoora RDETT on RA.idrendicontattivitaprogetto =RDETT.idrendicontattivitaprogetto
join registry_amministrativi R on RA.idreg = R.idreg  --> AMMINISTRATIVI
join progettotipocostocontrattokind PTC
	 on PTC.idcontrattokind = R.idcontrattokind and PTC.idprogetto = RA.idprogetto
join progetto P	on P.idprogetto = RA.idprogetto
join progettokind PK on P.idprogettokind = PK.idprogettokind
join progettoudrmembro PUM on PUM.idprogetto = P.idprogetto and PUM.idreg = R.idreg
left outer join progettocosto PC on PC.idrendicontattivitaprogetto = RA.idrendicontattivitaprogetto and PTC.idprogettotipocosto = PC.idprogettotipocosto
group by RA.idreg, RA.idworkpackage, RA.idprogetto, PTC.idprogettotipocosto, PC.idprogettocosto, RA.idrendicontattivitaprogetto, 
		RDETT.idrendicontattivitaprogettoora, RDETT.data, RA.description, PK.oredivisionecostostipendio, PUM.costoorario


GO

-- VERIFICA DI rendicontattivitaprogettoworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','data','3','''assistenza''','date','rendicontattivitaprogettoworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','-1','''assistenza''','varchar(max)','rendicontattivitaprogettoworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idcontrattokind','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idreg','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogetto','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogettoora','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ore','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','oredivisionecostostipendio','4','''assistenza''','int','rendicontattivitaprogettoworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','costoorario','10','''assistenza''','decimal','rendicontattivitaprogettoworkpackageview','','','','','S','N','decimal','assistenza','Decimal')
GO

-- VERIFICA DI rendicontattivitaprogettoworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA taxworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[taxworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [taxworkpackageview]
GO



CREATE        VIEW [taxworkpackageview]
as
select 
	T.taxcode, 
	expense.ymov,
	T.description as tax,
	expensetax.competencydate,
	expenseyear.idupb,
	null as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PTT.idprogettotipocosto as idprogettotipocosto,
	EL.idexp as idexppayed,
	expensetax.admintax,
	PC.idprogettocosto
from tax T 
JOIN progettotipocostotax PTT 	
	on T.taxcode = PTT.taxcode 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PTT.idprogetto   and  PTC.idprogettotipocosto = PTT.idprogettotipocosto
JOIN progetto P 
	on PTT.idprogetto = P.idprogetto

join expensetax  	ON T.taxcode = expensetax.taxcode
JOIN expense 	ON expensetax.idexp = expense.idexp
JOIN expenselast EL	ON expense.idexp = EL.idexp 
join expenseyear on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = expenseyear.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
left outer join progettocosto PC
	on expensetax.idexp = PC.idexp


GO

-- VERIFICA DI taxworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'taxworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','admintax','9','''assistenza''','decimal(19,2)','taxworkpackageview','','19','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','competencydate','3','''assistenza''','date','taxworkpackageview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idexppayed','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','4','''assistenza''','int','taxworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','taxworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','tax','50','''assistenza''','varchar(50)','taxworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','taxcode','4','''assistenza''','int','taxworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','taxworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ymov','2','''assistenza''','smallint','taxworkpackageview','','','','','N','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI taxworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'taxworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'taxworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('taxworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA wageadditionworkpackageview
IF EXISTS(select * from sysobjects where id = object_id(N'[wageadditionworkpackageview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [wageadditionworkpackageview]
GO



CREATE        VIEW [wageadditionworkpackageview]
as
select 
	C.ycon, C.ncon, C.description as descriptionwageaddition,
	'Altri Compensi '+ convert(varchar(4), C.ycon) + '/' + convert(varchar(10), C.ncon) as doc,
	C.adate as docdate,
	C.start, C.stop,
	C.adate,
	C.idupb,
	'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  +  convert(varchar(14), C.ncon) as idrelated,
	WP.idworkpackage,
	WP.title as titleworkpackage,
	WP.description as descriptionworkpackage,
	P.idprogetto,
	P.title as progetto,
	P.idprogettokind,
	PM.idprogettotipocosto as idprogettotipocosto,
	C.feegross,
	EL.idexp as idexppayed,
	-- Legge il pagato
	isnull(EY.amount,0) + 
		+
	   ISNULL((SELECT SUM(V1.amount)     FROM expensewageaddition EC1     
	   JOIN expenselink ELK1 ON ELK.idparent = EC1.idexp    
	   JOIN expenselast EL1       ON EL.idexp=ELK.idchild    
	   JOIN expensevar V1  ON V1.idexp = EL.idexp    
	   WHERE (ISNULL(v1.autokind,0)<> 4)  and EL1.idexp = EL.idexp
		),0) 
	AS exppayedamount,
	PC.idprogettocosto
from wageaddition C 
JOIN progettotipocostoaccmotive PM 	
	on PM.idaccmotive = C.idaccmotive 
join progettotipocosto PTC		/*Tipo voce costo*/
	on PTC.idprogetto = PM.idprogetto   and  PTC.idprogettotipocosto = PM.idprogettotipocosto
JOIN progetto P 
	on PM.idprogetto = P.idprogetto
JOIN workpackageupb WPU
	on WPU.idprogetto = P.idprogetto and WPU.idupb = C.idupb
JOIN workpackage WP 
	on WP.idprogetto = P.idprogetto and  WP.idworkpackage = WPU.idworkpackage
--Va in LEFT per mostrare anche il compenso non ancora pagato
left outer join expensewageaddition EC on EC.ncon= C.ncon AND EC.ycon=C.ycon
left outer	JOIN expenselink ELK   ON ELK.idparent = EC.idexp  and ELK.idchild <>elk.idparent
left outer JOIN expenselast EL    ON EL.idexp=ELK.idchild    
left outer JOIN expenseyear EY    ON EL.idexp=EY.idexp    
left outer join progettocosto PC
	on 'wageadd' + '§' + convert(varchar(4), C.ycon) + '§'  + convert(varchar(14), C.ncon) = PC.idrelated
	and PC.idexp = EL.idexp




GO

-- VERIFICA DI wageadditionworkpackageview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'wageadditionworkpackageview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','adate','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','descriptionwageaddition','150','''assistenza''','varchar(150)','wageadditionworkpackageview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descriptionworkpackage','0','''assistenza''','nvarchar(max)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','30','''assistenza''','varchar(30)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','docdate','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','exppayedamount','17','''assistenza''','decimal(38,2)','wageadditionworkpackageview','','38','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','feegross','9','''assistenza''','decimal(19,2)','wageadditionworkpackageview','','19','','2','N','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idexppayed','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettocosto','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idprogettokind','4','''assistenza''','int','wageadditionworkpackageview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogettotipocosto','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idrelated','27','''assistenza''','varchar(27)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idupb','36','''assistenza''','varchar(36)','wageadditionworkpackageview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idworkpackage','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ncon','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progetto','2048','''assistenza''','nvarchar(2048)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','start','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','stop','3','''assistenza''','date','wageadditionworkpackageview','','','','','N','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleworkpackage','2048','''assistenza''','nvarchar(2048)','wageadditionworkpackageview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ycon','4','''assistenza''','int','wageadditionworkpackageview','','','','','N','N','int','assistenza','System.Int32')
GO

-- VERIFICA DI wageadditionworkpackageview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'wageadditionworkpackageview')
UPDATE customobject set isreal = 'N' where objectname = 'wageadditionworkpackageview'
ELSE
INSERT INTO customobject (objectname, isreal) values('wageadditionworkpackageview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getoremaxgg]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getoremaxgg]
GO

CREATE VIEW [dbo].[getoremaxgg]
AS
SELECT        dbo.contratto.idreg, dbo.contratto.start, dbo.contratto.stop, dbo.contrattokind.oremaxgg, dbo.contrattokind.title
FROM            dbo.contratto INNER JOIN
                         dbo.contrattokind ON dbo.contratto.idcontrattokind = dbo.contrattokind.idcontrattokind
GO



--[DBO]--
-- CREAZIONE VISTA progettokindsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettokindsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettokindsegview]
GO

CREATE VIEW [dbo].[progettokindsegview] AS SELECT  progettokind.ct AS progettokind_ct, progettokind.cu AS progettokind_cu, progettokind.description AS progettokind_description,CASE WHEN progettokind.idcorsostudio = 'S' THEN 'Si' WHEN progettokind.idcorsostudio = 'N' THEN 'No' END AS progettokind_idcorsostudio, progettoactivitykind.title AS progettoactivitykind_title, progettokind.idprogettoactivitykind AS progettokind_idprogettoactivitykind, progettokind.idprogettokind, progettokind.lt AS progettokind_lt, progettokind.lu AS progettokind_lu, progettokind.oredivisionecostostipendio AS progettokind_oredivisionecostostipendio, progettokind.title, isnull('Titolo: ' + progettokind.title + '; ','') as dropdown_title FROM progettokind WITH (NOLOCK)  LEFT OUTER JOIN progettoactivitykind WITH (NOLOCK) ON progettokind.idprogettoactivitykind = progettoactivitykind.idprogettoactivitykind WHERE  progettokind.idprogettokind IS NOT NULL 
GO

-- VERIFICA DI progettokindsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettokindsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokindsegview','nvarchar(2058)','ASSISTENZA','dropdown_title','2058','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettokindsegview','int','ASSISTENZA','idprogettokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(2048)','ASSISTENZA','progettoactivitykind_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','datetime','ASSISTENZA','progettokind_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','varchar(64)','ASSISTENZA','progettokind_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(max)','ASSISTENZA','progettokind_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','varchar(2)','','progettokind_idcorsostudio','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','int','ASSISTENZA','progettokind_idprogettoactivitykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','datetime','ASSISTENZA','progettokind_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','varchar(64)','ASSISTENZA','progettokind_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','int','ASSISTENZA','progettokind_oredivisionecostostipendio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettokindsegview','nvarchar(2048)','ASSISTENZA','title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettokindsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettokindsegview')
UPDATE customobject set isreal = 'N' where objectname = 'progettokindsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettokindsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA progettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[progettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[progettosegview]
GO

CREATE VIEW [dbo].[progettosegview] AS SELECT  progetto.budget AS progetto_budget, progetto.budgetcalcolato AS progetto_budgetcalcolato, progetto.budgetcalcolatodate AS progetto_budgetcalcolatodate, progetto.capofilatxt AS progetto_capofilatxt, progetto.codiceidentificativo AS progetto_codiceidentificativo, progetto.contributo AS progetto_contributo, progetto.contributoente AS progetto_contributoente, progetto.ct AS progetto_ct, progetto.cu AS progetto_cu, progetto.cup AS progetto_cup, progetto.data AS progetto_data, progetto.datacontabile AS progetto_datacontabile, progetto.description AS progetto_description, progetto.durata AS progetto_durata, progetto.finanziatoretxt AS progetto_finanziatoretxt, corsostudio.title AS corsostudio_title, corsostudio.annoistituz AS corsostudio_annoistituz, progetto.idcorsostudio, currency.codecurrency AS currency_codecurrency, progetto.idcurrency, duratakind.title AS duratakind_title, progetto.idduratakind AS progetto_idduratakind, progetto.idprogetto, progettokind.title AS progettokind_title, progetto.idprogettokind AS progetto_idprogettokind, progettostatuskind.title AS progettostatuskind_title, progetto.idprogettostatuskind AS progetto_idprogettostatuskind, registry.title AS registry_title, progetto.idreg, registry_registry_aziendeaziende.title AS registryaziende_title, progetto.idreg_aziende, registry_registry_aziendeaziende_fin.title AS registryaziende_fin_title, progetto.idreg_aziende_fin, registryprogfin.title AS registryprogfin_title, registryprogfin.code AS registryprogfin_code, progetto.idregistryprogfin AS progetto_idregistryprogfin, registryprogfinbando.title AS registryprogfinbando_title, registryprogfinbando.number AS registryprogfinbando_number, registryprogfinbando.scadenza AS registryprogfinbando_scadenza, progetto.idregistryprogfinbando AS progetto_idregistryprogfinbando, progetto.lt AS progetto_lt, progetto.lu AS progetto_lu, progetto.start AS progetto_start, progetto.stop AS progetto_stop, progetto.title AS progetto_title, progetto.titolobreve, progetto.totalbudget AS progetto_totalbudget, progetto.totalcontributo AS progetto_totalcontributo, progetto.url AS progetto_url, isnull('Titolo breve o acronimo: ' + progetto.titolobreve + '; ','') as dropdown_title FROM progetto WITH (NOLOCK)  LEFT OUTER JOIN corsostudio WITH (NOLOCK) ON progetto.idcorsostudio = corsostudio.idcorsostudio LEFT OUTER JOIN currency WITH (NOLOCK) ON progetto.idcurrency = currency.idcurrency LEFT OUTER JOIN duratakind WITH (NOLOCK) ON progetto.idduratakind = duratakind.idduratakind LEFT OUTER JOIN progettokind WITH (NOLOCK) ON progetto.idprogettokind = progettokind.idprogettokind LEFT OUTER JOIN progettostatuskind WITH (NOLOCK) ON progetto.idprogettostatuskind = progettostatuskind.idprogettostatuskind LEFT OUTER JOIN registry WITH (NOLOCK) ON progetto.idreg = registry.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende WITH (NOLOCK) ON progetto.idreg_aziende = registry_aziendeaziende.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende WITH (NOLOCK) ON registry_aziendeaziende.idreg = registry_registry_aziendeaziende.idreg LEFT OUTER JOIN registry_aziende AS registry_aziendeaziende_fin WITH (NOLOCK) ON progetto.idreg_aziende_fin = registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registry AS registry_registry_aziendeaziende_fin WITH (NOLOCK) ON registry_aziendeaziende_fin.idreg = registry_registry_aziendeaziende_fin.idreg LEFT OUTER JOIN registryprogfin WITH (NOLOCK) ON progetto.idregistryprogfin = registryprogfin.idregistryprogfin LEFT OUTER JOIN registryprogfinbando WITH (NOLOCK) ON progetto.idregistryprogfinbando = registryprogfinbando.idregistryprogfinbando WHERE  progetto.idprogetto IS NOT NULL 
GO

-- VERIFICA DI progettosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'progettosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(20)','','currency_codecurrency','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','nvarchar(2075)','ASSISTENZA','dropdown_title','2075','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','duratakind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','','idcurrency','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','idreg_aziende_fin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_budgetcalcolato','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','datetime','ASSISTENZA','progetto_budgetcalcolatodate','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_capofilatxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(2048)','','progetto_codiceidentificativo','2048','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributo','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_contributoente','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(15)','ASSISTENZA','progetto_cup','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_data','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','','progetto_datacontabile','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(max)','ASSISTENZA','progetto_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progetto_finanziatoretxt','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idprogettostatuskind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','int','ASSISTENZA','progetto_idregistryprogfinbando','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','datetime','ASSISTENZA','progetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','progettosegview','varchar(64)','ASSISTENZA','progetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','progetto_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(4000)','ASSISTENZA','progetto_title','4000','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','ASSISTENZA','progetto_totalbudget','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','decimal(14,2)','','progetto_totalcontributo','9','N','decimal','System.Decimal','','2','','14','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(1024)','','progetto_url','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','progettokind_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(50)','ASSISTENZA','progettostatuskind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_fin_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','varchar(101)','ASSISTENZA','registryaziende_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_code','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfin_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_number','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','date','ASSISTENZA','registryprogfinbando_scadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','registryprogfinbando_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','progettosegview','nvarchar(2048)','ASSISTENZA','titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI progettosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'progettosegview')
UPDATE customobject set isreal = 'N' where objectname = 'progettosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('progettosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registryamministrativiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registryamministrativiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registryamministrativiview]
GO

CREATE VIEW [dbo].[registryamministrativiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, category.description AS category_description, registry.idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, registryclass.description AS registryclass_description, registry.idregistryclass, registrykind.description AS registrykind_description, registry.idregistrykind AS registry_idregistrykind, title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title AS registry_title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_amministrativi.ct AS registry_amministrativi_ct, registry_amministrativi.cu AS registry_amministrativi_cu, registry_amministrativi.cv AS registry_amministrativi_cv, contrattokind.title AS contrattokind_title, registry_amministrativi.idcontrattokind AS registry_amministrativi_idcontrattokind, registry_amministrativi.idreg AS registry_amministrativi_idreg, registry_amministrativi.lt AS registry_amministrativi_lt, registry_amministrativi.lu AS registry_amministrativi_lu, isnull('Titolo: ' + title.description + '; ','') + ' ' + isnull('Cognome: ' + registry.surname + '; ','') + ' ' + isnull('Nome: ' + registry.forename + '; ','') + ' ' + isnull('Codice fiscale: ' + registry.cf + '; ','') as dropdown_title FROM registry WITH (NOLOCK)  INNER JOIN registry_amministrativi WITH (NOLOCK) ON registry.idreg = registry_amministrativi.idreg LEFT OUTER JOIN category WITH (NOLOCK) ON registry.idcategory = category.idcategory LEFT OUTER JOIN geo_city WITH (NOLOCK) ON registry.idcity = geo_city.idcity LEFT OUTER JOIN maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = maritalstatus.idmaritalstatus LEFT OUTER JOIN geo_nation WITH (NOLOCK) ON registry.idnation = geo_nation.idnation LEFT OUTER JOIN registryclass WITH (NOLOCK) ON registry.idregistryclass = registryclass.idregistryclass LEFT OUTER JOIN registrykind WITH (NOLOCK) ON registry.idregistrykind = registrykind.idregistrykind LEFT OUTER JOIN title WITH (NOLOCK) ON registry.idtitle = title.idtitle LEFT OUTER JOIN residence WITH (NOLOCK) ON registry.residence = residence.idresidence LEFT OUTER JOIN contrattokind WITH (NOLOCK) ON registry_amministrativi.idcontrattokind = contrattokind.idcontrattokind WHERE  registry.idreg IS NOT NULL  AND registry_amministrativi.idreg IS NOT NULL 
GO

-- VERIFICA DI registryamministrativiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registryamministrativiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','category_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(216)','ASSISTENZA','dropdown_title','216','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_ct','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_cu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','nvarchar(max)','ASSISTENZA','registry_amministrativi_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','registry_amministrativi_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','datetime','ASSISTENZA','registry_amministrativi_lt','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(64)','ASSISTENZA','registry_amministrativi_lu','64','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','varchar(101)','ASSISTENZA','registry_title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','registrykind_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registryamministrativiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registryamministrativiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registryamministrativiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registryamministrativiview')
UPDATE customobject set isreal = 'N' where objectname = 'registryamministrativiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registryamministrativiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registrydocentiview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocentiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocentiview]
GO

CREATE VIEW [dbo].[registrydocentiview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, sasd.codice AS sasd_codice, sasd.title AS sasd_title, registry_docenti.idsasd, struttura.title AS struttura_title, strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + strutturakind.title + '; ','') as dropdown_title FROM registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN geo_city WITH (NOLOCK) ON registry.idcity = geo_city.idcity LEFT OUTER JOIN maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = maritalstatus.idmaritalstatus LEFT OUTER JOIN geo_nation WITH (NOLOCK) ON registry.idnation = geo_nation.idnation LEFT OUTER JOIN registryclass WITH (NOLOCK) ON registry.idregistryclass = registryclass.idregistryclass LEFT OUTER JOIN title WITH (NOLOCK) ON registry.idtitle = title.idtitle LEFT OUTER JOIN residence WITH (NOLOCK) ON registry.residence = residence.idresidence LEFT OUTER JOIN classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = classconsorsuale.idclassconsorsuale LEFT OUTER JOIN contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = contrattokind.idcontrattokind LEFT OUTER JOIN fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN sasd WITH (NOLOCK) ON registry_docenti.idsasd = sasd.idsasd LEFT OUTER JOIN struttura WITH (NOLOCK) ON registry_docenti.idstruttura = struttura.idstruttura LEFT OUTER JOIN strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- VERIFICA DI registrydocentiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrydocentiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','classconsorsuale_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(192)','ASSISTENZA','dropdown_title','192','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(1024)','ASSISTENZA','fonteindicebibliometrico_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_city_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(65)','ASSISTENZA','geo_nation_title','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idclassconsorsuale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idnation','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idreg_istituti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','idregistryclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idsasd','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','idtitle','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','maritalstatus_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(400)','ASSISTENZA','registry_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_authorization_free','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_badgecode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','date','ASSISTENZA','registry_birthdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(12)','ASSISTENZA','registry_ccp','12','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(16)','ASSISTENZA','registry_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_cv','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_idfonteindicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','registry_docenti_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_docenti_indicebibliometrico','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_docenti_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_docenti_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_docenti_matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','nvarchar(max)','ASSISTENZA','registry_docenti_ricevimento','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','registry_docenti_soggiorno','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_email_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_extmatricula','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flag_pa','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(40)','ASSISTENZA','registry_foreigncf','40','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_forename','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_gender','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_idcategory','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idcentralizedcategory','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idexternal','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_idmaritalstatus','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_idregistrykind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(7)','ASSISTENZA','registry_ipa_fe','7','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(100)','ASSISTENZA','registry_ipa_perlapa','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','datetime','ASSISTENZA','registry_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(64)','ASSISTENZA','registry_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_maritalsurname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_multi_cf','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(15)','ASSISTENZA','registry_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(200)','ASSISTENZA','registry_pec_fe','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','image','ASSISTENZA','registry_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(20)','ASSISTENZA','registry_sdi_defrifamm','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(2)','ASSISTENZA','registry_sdi_norifamm','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','registry_surname','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','int','ASSISTENZA','registry_toredirect','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','text','ASSISTENZA','registry_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(150)','ASSISTENZA','registryclass_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(101)','ASSISTENZA','registryistituti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','int','ASSISTENZA','residence','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(60)','ASSISTENZA','residence_description','60','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','sasd_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(255)','ASSISTENZA','sasd_title','255','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocentiview','varchar(101)','ASSISTENZA','title','101','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocentiview','varchar(50)','ASSISTENZA','title_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI registrydocentiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrydocentiview')
UPDATE customobject set isreal = 'N' where objectname = 'registrydocentiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrydocentiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA registrydocenti_docview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[registrydocenti_docview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[registrydocenti_docview]
GO

CREATE VIEW [dbo].[registrydocenti_docview] AS SELECT CASE WHEN registry.active = 'S' THEN 'Si' WHEN registry.active = 'N' THEN 'No' END AS registry_active, registry.annotation AS registry_annotation,CASE WHEN registry.authorization_free = 'S' THEN 'Si' WHEN registry.authorization_free = 'N' THEN 'No' END AS registry_authorization_free, registry.badgecode AS registry_badgecode, registry.birthdate AS registry_birthdate, registry.ccp AS registry_ccp, registry.cf AS registry_cf, registry.ct AS registry_ct, registry.cu AS registry_cu, registry.email_fe AS registry_email_fe, registry.extension AS registry_extension, registry.extmatricula AS registry_extmatricula,CASE WHEN registry.flag_pa = 'S' THEN 'Si' WHEN registry.flag_pa = 'N' THEN 'No' END AS registry_flag_pa,CASE WHEN registry.flagbankitaliaproceeds = 'S' THEN 'Si' WHEN registry.flagbankitaliaproceeds = 'N' THEN 'No' END AS registry_flagbankitaliaproceeds, registry.foreigncf AS registry_foreigncf, registry.forename AS registry_forename,CASE WHEN registry.gender = 'M' THEN 'Maschio' WHEN registry.gender = 'F' THEN 'Femmina' END AS registry_gender, registry.idcategory AS registry_idcategory, registry.idcentralizedcategory AS registry_idcentralizedcategory, geo_city.title AS geo_city_title, registry.idcity, registry.idexternal AS registry_idexternal, maritalstatus.description AS maritalstatus_description, registry.idmaritalstatus AS registry_idmaritalstatus, geo_nation.title AS geo_nation_title, registry.idnation, registry.idreg, registryclass.description AS registryclass_description, registry.idregistryclass, registry.idregistrykind AS registry_idregistrykind, title.description AS title_description, registry.idtitle, registry.ipa_fe AS registry_ipa_fe, registry.ipa_perlapa AS registry_ipa_perlapa, registry.location AS registry_location, registry.lt AS registry_lt, registry.lu AS registry_lu, registry.maritalsurname AS registry_maritalsurname,CASE WHEN registry.multi_cf = 'S' THEN 'Si' WHEN registry.multi_cf = 'N' THEN 'No' END AS registry_multi_cf, registry.p_iva AS registry_p_iva, registry.pec_fe AS registry_pec_fe, residence.description AS residence_description, registry.residence, registry.rtf AS registry_rtf, registry.sdi_defrifamm AS registry_sdi_defrifamm,CASE WHEN registry.sdi_norifamm = 'S' THEN 'Si' WHEN registry.sdi_norifamm = 'N' THEN 'No' END AS registry_sdi_norifamm, registry.surname AS registry_surname, registry.title, registry.toredirect AS registry_toredirect, registry.txt AS registry_txt, registry_docenti.ct AS registry_docenti_ct, registry_docenti.cu AS registry_docenti_cu, registry_docenti.cv AS registry_docenti_cv, classconsorsuale.title AS classconsorsuale_title, registry_docenti.idclassconsorsuale, contrattokind.title AS contrattokind_title, registry_docenti.idcontrattokind AS registry_docenti_idcontrattokind, fonteindicebibliometrico.title AS fonteindicebibliometrico_title, registry_docenti.idfonteindicebibliometrico AS registry_docenti_idfonteindicebibliometrico, registry_docenti.idreg AS registry_docenti_idreg, registry_registry_istitutiistituti.title AS registryistituti_title, registry_docenti.idreg_istituti, sasd.codice AS sasd_codice, sasd.title AS sasd_title, registry_docenti.idsasd, struttura.title AS struttura_title, strutturakind.title AS strutturakind_title, registry_docenti.idstruttura, registry_docenti.indicebibliometrico AS registry_docenti_indicebibliometrico, registry_docenti.lt AS registry_docenti_lt, registry_docenti.lu AS registry_docenti_lu, registry_docenti.matricola AS registry_docenti_matricola, registry_docenti.ricevimento AS registry_docenti_ricevimento, registry_docenti.soggiorno AS registry_docenti_soggiorno, isnull('Denominazione: ' + registry.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + strutturakind.title + '; ','') as dropdown_title FROM registry WITH (NOLOCK)  INNER JOIN registry_docenti WITH (NOLOCK) ON registry.idreg = registry_docenti.idreg LEFT OUTER JOIN geo_city WITH (NOLOCK) ON registry.idcity = geo_city.idcity LEFT OUTER JOIN maritalstatus WITH (NOLOCK) ON registry.idmaritalstatus = maritalstatus.idmaritalstatus LEFT OUTER JOIN geo_nation WITH (NOLOCK) ON registry.idnation = geo_nation.idnation LEFT OUTER JOIN registryclass WITH (NOLOCK) ON registry.idregistryclass = registryclass.idregistryclass LEFT OUTER JOIN title WITH (NOLOCK) ON registry.idtitle = title.idtitle LEFT OUTER JOIN residence WITH (NOLOCK) ON registry.residence = residence.idresidence LEFT OUTER JOIN classconsorsuale WITH (NOLOCK) ON registry_docenti.idclassconsorsuale = classconsorsuale.idclassconsorsuale LEFT OUTER JOIN contrattokind WITH (NOLOCK) ON registry_docenti.idcontrattokind = contrattokind.idcontrattokind LEFT OUTER JOIN fonteindicebibliometrico WITH (NOLOCK) ON registry_docenti.idfonteindicebibliometrico = fonteindicebibliometrico.idfonteindicebibliometrico LEFT OUTER JOIN registry_istituti AS registry_istitutiistituti WITH (NOLOCK) ON registry_docenti.idreg_istituti = registry_istitutiistituti.idreg LEFT OUTER JOIN registry AS registry_registry_istitutiistituti WITH (NOLOCK) ON registry_istitutiistituti.idreg = registry_registry_istitutiistituti.idreg LEFT OUTER JOIN sasd WITH (NOLOCK) ON registry_docenti.idsasd = sasd.idsasd LEFT OUTER JOIN struttura WITH (NOLOCK) ON registry_docenti.idstruttura = struttura.idstruttura LEFT OUTER JOIN strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = strutturakind.idstrutturakind WHERE  registry.idreg IS NOT NULL  AND registry_docenti.idreg IS NOT NULL 
GO

-- VERIFICA DI registrydocenti_docview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'registrydocenti_docview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','classconsorsuale_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','contrattokind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(192)','','dropdown_title','192','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','nvarchar(1024)','','fonteindicebibliometrico_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(65)','','geo_city_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(65)','','geo_nation_title','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idcity','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idclassconsorsuale','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idnation','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','int','','idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idreg_istituti','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','idregistryclass','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idsasd','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(20)','','idtitle','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','maritalstatus_description','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_active','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(400)','','registry_annotation','400','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_authorization_free','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(20)','','registry_badgecode','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','date','','registry_birthdate','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(12)','','registry_ccp','12','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(16)','','registry_cf','16','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','datetime','','registry_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(64)','','registry_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','datetime','','registry_docenti_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(64)','','registry_docenti_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','nvarchar(max)','','registry_docenti_cv','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_docenti_idcontrattokind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_docenti_idfonteindicebibliometrico','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','int','','registry_docenti_idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_docenti_indicebibliometrico','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','datetime','','registry_docenti_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(64)','','registry_docenti_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','registry_docenti_matricola','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','nvarchar(max)','','registry_docenti_ricevimento','0','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(255)','','registry_docenti_soggiorno','255','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(200)','','registry_email_fe','200','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(200)','','registry_extension','200','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(40)','','registry_extmatricula','40','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_flag_pa','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_flagbankitaliaproceeds','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(40)','','registry_foreigncf','40','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','registry_forename','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(7)','','registry_gender','7','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_idcategory','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(20)','','registry_idcentralizedcategory','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_idexternal','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(20)','','registry_idmaritalstatus','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_idregistrykind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(7)','','registry_ipa_fe','7','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(100)','','registry_ipa_perlapa','100','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','registry_location','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','datetime','','registry_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(64)','','registry_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','registry_maritalsurname','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_multi_cf','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(15)','','registry_p_iva','15','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(200)','','registry_pec_fe','200','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','image','','registry_rtf','16','N','image','System.Byte[]','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(20)','','registry_sdi_defrifamm','20','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(2)','','registry_sdi_norifamm','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','registry_surname','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','int','','registry_toredirect','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','text','','registry_txt','16','N','text','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(150)','','registryclass_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(101)','','registryistituti_title','101','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','int','','residence','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(60)','','residence_description','60','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','sasd_codice','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(255)','','sasd_title','255','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(1024)','','struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','registrydocenti_docview','varchar(101)','','title','101','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','registrydocenti_docview','varchar(50)','','title_description','50','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI registrydocenti_docview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'registrydocenti_docview')
UPDATE customobject set isreal = 'N' where objectname = 'registrydocenti_docview'
ELSE
INSERT INTO customobject (objectname, isreal) values('registrydocenti_docview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettoanagammview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettoanagammview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettoanagammview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettoanagammview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagammview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagammview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagammview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagammview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagammview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagammview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagammview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettoanagview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettoanagview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettoanagview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettoanagview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettoanagview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','nvarchar(max)','ASSISTENZA','dropdown_title','0','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','progetto_titolobreve','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','varchar(max)','ASSISTENZA','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettoanagview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettoanagview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettoanagview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettoanagview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettoanagview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettoanagview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettodocview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettodocview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettodocview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettodocview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, progetto.titolobreve AS progetto_titolobreve, rendicontattivitaprogetto.idprogetto, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, workpackage.raggruppamento AS workpackage_raggruppamento, workpackage.title AS workpackage_title, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Progetto: ' + progetto.titolobreve + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Workpackage: ' + workpackage.title + '; ','') + ' ' + isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN progetto WITH (NOLOCK) ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto LEFT OUTER JOIN workpackage WITH (NOLOCK) ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettodocview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettodocview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','nvarchar(max)','','dropdown_title','0','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','idrendicontattivitaprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(150)','','itineration_description','150','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(65)','','itineration_location','65','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','datetime','','itineration_starttime','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','datetime','','itineration_stoptime','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','progetto_titolobreve','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','datetime','','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','varchar(64)','','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','date','','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','varchar(max)','','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','datetime','','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettodocview','varchar(64)','','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','int','','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','workpackage_raggruppamento','2048','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettodocview','nvarchar(2048)','','workpackage_title','2048','N','nvarchar','System.String','','','','','N')
GO

-- VERIFICA DI rendicontattivitaprogettodocview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettodocview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettodocview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettodocview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA rendicontattivitaprogettosegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[rendicontattivitaprogettosegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[rendicontattivitaprogettosegview]
GO

CREATE VIEW [dbo].[rendicontattivitaprogettosegview] AS SELECT  rendicontattivitaprogetto.ct AS rendicontattivitaprogetto_ct, rendicontattivitaprogetto.cu AS rendicontattivitaprogetto_cu, rendicontattivitaprogetto.datainizioprevista AS rendicontattivitaprogetto_datainizioprevista, rendicontattivitaprogetto.description, amministrazione.itineration.description AS itineration_description, amministrazione.itineration.location AS itineration_location, amministrazione.itineration.starttime AS itineration_starttime, amministrazione.itineration.stoptime AS itineration_stoptime, rendicontattivitaprogetto.iditineration AS rendicontattivitaprogetto_iditineration, rendicontattivitaprogetto.idprogetto AS rendicontattivitaprogetto_idprogetto, registry.title AS registry_title, rendicontattivitaprogetto.idreg AS rendicontattivitaprogetto_idreg, rendicontattivitaprogetto.idrendicontattivitaprogetto, rendicontattivitaprogetto.idworkpackage AS rendicontattivitaprogetto_idworkpackage, rendicontattivitaprogetto.lt AS rendicontattivitaprogetto_lt, rendicontattivitaprogetto.lu AS rendicontattivitaprogetto_lu, rendicontattivitaprogetto.orepreventivate AS rendicontattivitaprogetto_orepreventivate, isnull('Descrizione: ' + rendicontattivitaprogetto.description + '; ','') as dropdown_title FROM rendicontattivitaprogetto WITH (NOLOCK)  LEFT OUTER JOIN amministrazione.itineration WITH (NOLOCK) ON rendicontattivitaprogetto.iditineration = amministrazione.itineration.iditineration LEFT OUTER JOIN registry WITH (NOLOCK) ON rendicontattivitaprogetto.idreg = registry.idreg WHERE  rendicontattivitaprogetto.idrendicontattivitaprogetto IS NOT NULL 
GO

-- VERIFICA DI rendicontattivitaprogettosegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettosegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(max)','ASSISTENZA','description','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(max)','ASSISTENZA','dropdown_title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(150)','ASSISTENZA','itineration_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(65)','ASSISTENZA','itineration_location','65','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','datetime','ASSISTENZA','itineration_starttime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','datetime','ASSISTENZA','itineration_stoptime','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','datetime','ASSISTENZA','rendicontattivitaprogetto_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','date','ASSISTENZA','rendicontattivitaprogetto_datainizioprevista','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_iditineration','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','datetime','ASSISTENZA','rendicontattivitaprogetto_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettosegview','varchar(64)','ASSISTENZA','rendicontattivitaprogetto_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettosegview','int','ASSISTENZA','rendicontattivitaprogetto_orepreventivate','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettosegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettosegview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettosegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettosegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA saldefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[saldefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[saldefaultview]
GO

CREATE VIEW [dbo].[saldefaultview] AS SELECT  sal.data AS sal_data, sal.idprogetto, sal.idsal, isnull('Identificativo: ' + CAST( sal.idsal AS NVARCHAR(64)) + '; ','') + ' ' + isnull('del ' + CONVERT(VARCHAR, sal.data, 103),'') as dropdown_title FROM sal WITH (NOLOCK)  WHERE  sal.idprogetto IS NOT NULL  AND sal.idsal IS NOT NULL 
GO

-- VERIFICA DI saldefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'saldefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','nvarchar(117)','','dropdown_title','117','S','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','int','','idprogetto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','saldefaultview','int','','idsal','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','saldefaultview','date','','sal_data','3','N','date','System.DateTime','','','','','N')
GO

-- VERIFICA DI saldefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'saldefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'saldefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('saldefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

--[DBO]--
-- CREAZIONE VISTA workpackagesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[workpackagesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[workpackagesegview]
GO

CREATE VIEW [dbo].[workpackagesegview] AS SELECT  workpackage.acronimo AS workpackage_acronimo, workpackage.ct AS workpackage_ct, workpackage.cu AS workpackage_cu, workpackage.description AS workpackage_description, workpackage.idprogetto, struttura.title AS struttura_title, strutturakind.title AS strutturakind_title, workpackage.idstruttura, workpackage.idworkpackage, workpackage.lt AS workpackage_lt, workpackage.lu AS workpackage_lu, workpackage.raggruppamento, workpackage.title AS workpackage_title, isnull('Raggruppamento: ' + workpackage.raggruppamento + '; ','') + ' ' + isnull('Titolo: ' + workpackage.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + strutturakind.title + '; ','') as dropdown_title FROM workpackage WITH (NOLOCK)  LEFT OUTER JOIN struttura WITH (NOLOCK) ON workpackage.idstruttura = struttura.idstruttura LEFT OUTER JOIN strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = strutturakind.idstrutturakind WHERE  workpackage.idprogetto IS NOT NULL  AND workpackage.idworkpackage IS NOT NULL 
GO

-- VERIFICA DI workpackagesegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'workpackagesegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','nvarchar(4000)','ASSISTENZA','dropdown_title','4000','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','int','','idstruttura','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','int','ASSISTENZA','idworkpackage','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','raggruppamento','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(1024)','','struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_acronimo','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(max)','ASSISTENZA','workpackage_description','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','datetime','ASSISTENZA','workpackage_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','workpackagesegview','varchar(64)','ASSISTENZA','workpackage_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','workpackagesegview','nvarchar(2048)','ASSISTENZA','workpackage_title','2048','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI workpackagesegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'workpackagesegview')
UPDATE customobject set isreal = 'N' where objectname = 'workpackagesegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('workpackagesegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

IF EXISTS(select * from sysobjects where id = object_id(N'[amministrazione].[compute_assetdiaryora]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [amministrazione].[compute_assetdiaryora]
GO

CREATE PROCEDURE [amministrazione].[compute_assetdiaryora] 
(
	@max_ayear int, 
	@max_mese int,
	@idprogetto int
)
as begin 
--185.56.8.51,5839
-- Per ogni mese si calcola la proporzione di ore di utilizzo dell'asset

	create table #oremesicespite(sommeore int, mese int, idasset int, idpiece int, ayear int)
	--sommeore : indica quante ore è stato usato il bene nel mese indicato @max_mese

	;WITH curr_asset (idassetdiary, idpiece) as
	(
	select idassetdiary, idpiece 
	from 	assetdiary
	where idprogetto = @idprogetto
	group by idassetdiary, idpiece 
	)
	insert into #oremesicespite(sommeore, idasset, idpiece , ayear, mese)
	select	sum(DATEDIFF(hour, ADETT.start, ADETT.stop)) as SommaOreDx,
			AD.idasset, 
			AD.idpiece, --, AD.idprogetto
			year(ADETT.start), month(ADETT.start)
	 from assetdiary AD 
	join  assetdiaryora ADETT 
		on AD.idassetdiary = ADETT.idassetdiary
	join asset A 
		on AD.idasset = A.idasset and AD.idpiece = A.idpiece
	join curr_asset CA
		on CA.idassetdiary = A.idasset and CA.idpiece = A.idpiece
		where month(ADETT.start) <= @max_mese 
		and year (ADETT.start) <= @max_ayear		
		-- Vanno considerati solo i cespiti che hanno una class. inventariale associata ad un Tipo costo
		and exists (select * from  assetacquire	
				JOIN inventorytree 		ON inventorytree.idinv = assetacquire.idinv
				join inventorytreelink  on  inventorytreelink.idchild = assetacquire.idinv
				join progettotipocostoinventorytree on progettotipocostoinventorytree.idinv = inventorytreelink.idparent
				where assetacquire.nassetacquire = A.nassetacquire
			)
	group by year(ADETT.start),month(ADETT.start), AD.idasset, AD.idpiece --, AD.idprogetto
	
	-- Per ogni cespite calcola l'ammortamento annuo e poi farà diviso 12
	DECLARE @dec_31 datetime
	declare @assetvalue_to_date decimal(19,2)
	declare @actualvalue_to_date decimal(19,2)

	DECLARE @idasset int
	DECLARE @idpiece int
	DECLARE @ayear int
	
	create table #ammortamenti(importo decimal(19,2), idasset int, idpiece int, ayear int)
	
	DECLARE amt_crs1 INSENSITIVE CURSOR FOR
	SELECT 
		idasset, idpiece, ayear
	FROM #oremesicespite
	FOR READ ONLY
	OPEN amt_crs1
	
	FETCH NEXT FROM amt_crs1 INTO @idasset, @idpiece, @ayear
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		SELECT  @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
		EXECUTE get_assetvalueatdate @idasset,@idpiece, @dec_31, @assetvalue_to_date OUTPUT, @actualvalue_to_date OUTPUT 
		if (@assetvalue_to_date>0)
		begin
			-- in questa tebella metterà tutti i valori dell'Ammortamento, così dopo potrà fare direttamente il JOIN piuttosto che fare l'UPDATE su #oremesicespite
			insert into #ammortamenti(importo, idasset, idpiece, ayear)
			values(@actualvalue_to_date, @idasset, @idpiece, @ayear) 
		end
	
		FETCH NEXT FROM amt_crs1 INTO  @idasset, @idpiece, @ayear
		END

	DEALLOCATE amt_crs1
	
	--Calcola il valore da scrivere in amount di assetdiaryora come:
	-- (ore dell'i-esima riga di assetdiaryora / Somma delle ore di quell'asset) * Ammortamento cespite
	select case when isnull(AMM.importo,0)>0
			then CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
									* ( isnull(AMM.importo,1)/12) 
			else  CONVERT(decimal(19,2), DATEDIFF(hour, ADETT.start, ADETT.stop)) /(convert(decimal(19,2),O.sommeore))  
			end	as amount ,
	ADETT.idassetdiary, ADETT.idassetdiaryora
	from assetdiary A 
	join  assetdiaryora ADETT 
		on A.idassetdiary = ADETT.idassetdiary and A.idprogetto = @idprogetto --> deve valorizzare solo le righe del progetto specificato.
	join #oremesicespite O
		on A.idasset = O.idasset and A.idpiece = O.idpiece
	LEFT OUTER join #ammortamenti AMM
		on AMM.idasset = O.idasset and AMM.idpiece = O.idpiece and AMM.ayear = O.ayear
	where O.sommeore<>0 and O.mese = month(ADETT.start) and O.ayear = year(ADETT.start)
	order by ADETT.idassetdiary, ADETT.idassetdiaryora

	drop table #oremesicespite

END 
GO
 
--[DBO]--
-- CREAZIONE PROCEDURE [dbo].[GenerateProgettoDetail]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[GenerateProgettoDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GenerateProgettoDetail]
GO
CREATE PROCEDURE [dbo].[GenerateProgettoDetail]
	@idprogettokind int ,
	@idprogetto int,
	@user varchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	-----------test-------------------------
	--declare @idprogettokind int = 2
	--declare @idprogetto int = 1
	--declare @user varchar(64) = 'utentetest'
	----------------------------------------
	
	--WORKPACKAGE
	INSERT INTO [dbo].[workpackage]
           ([idworkpackage]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idworkpackage),0)   from workpackage) + ROW_NUMBER() OVER(ORDER BY wpk.idworkpackagekind ASC) as idworkpackage,
		@idprogetto as idprogetto,
		wpk.title,
		'' as [description],
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM workpackagekind wpk
	WHERE idprogettokind = @idprogettokind and not exists (	select x.title 
															from workpackage x 
															where x.idprogetto = @idprogetto and x.title = wpk.title)

	--VOCI COSTO
	INSERT INTO [dbo].[progettotipocosto]
           ([idprogettotipocosto]
           ,[idprogettotipocostokind]
           ,[idprogetto]
           ,[sortcode]
           ,[ammissibilita]
		   ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotipocosto),0)   from progettotipocosto) + ROW_NUMBER() OVER(ORDER BY ptcck.idprogettotipocostokind ASC) as idprogettotipocosto,
		ptcck.idprogettotipocostokind,
		@idprogetto as idprogetto,
		null as sortcode,
		100 as ammissibilita,
		ptcck.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
		--,title
	FROM progettotipocostokind ptcck
	WHERE idprogettokind = @idprogettokind and not exists (	select x.idprogettotipocostokind 
															from progettotipocosto x 
															where x.idprogetto = @idprogetto and x.idprogettotipocostokind = ptcck.idprogettotipocostokind)

	--progettotipocostokindaccmotive: causali economico patrimoniali

	INSERT INTO [dbo].[progettotipocostoaccmotive]
           ([idprogetto]
           ,[idprogettotipocosto]
           ,[idaccmotive]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			@idprogetto as idprogetto
			,ptc.idprogettotipocosto
			,ptcka.idaccmotive
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindaccmotive ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoaccmotive x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idaccmotive = ptcka.idaccmotive)

	--progettotipocostokindcontrattokind: tipologia di contratti

	INSERT INTO [dbo].[progettotipocostocontrattokind]
           ([idprogettotipocosto]
           ,[idcontrattokind]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idcontrattokind
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindcontrattokind ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostocontrattokind x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idcontrattokind = ptcka.idcontrattokind)

	--progettotipocostokindinventorytree: classificazioni inventariali

	INSERT INTO [dbo].[progettotipocostoinventorytree]
           ([idprogettotipocosto]
           ,[idinv]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idinv
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindinventorytree ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoinventorytree x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idinv = ptcka.idinv)

	--progettotipocostokindtax: tipi di ritenuta

	INSERT INTO [dbo].[progettotipocostotax]
           ([idprogettotipocosto]
           ,[taxcode]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.taxcode
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindtax ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostotax x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.taxcode = ptcka.taxcode)

	--CATEGORIE COSTO
	INSERT INTO [dbo].[progettobudget]
           ([idprogettobudget]
           ,[idprogetto]
           ,[idworkpackage]
           ,[idprogettotipocosto]
           ,[budget]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettobudget),0) from [progettobudget]) + ROW_NUMBER() OVER(ORDER BY ptcc.idprogettotipocostokind ASC) as [idprogettobudget],
		@idprogetto as idprogetto,
		wp.idworkpackage,
		ptcc.idprogettotipocosto,
		0 as budget,
		ROW_NUMBER() OVER(ORDER BY ptcc.sortcode ASC) as sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	from workpackage wp inner join progettotipocosto ptcc on wp.idprogetto = ptcc.idprogetto
	where wp.idprogetto = @idprogetto and ptcc.idprogetto = @idprogetto and not exists (select x.idprogettobudget 
																						from progettobudget x 
																						where x.idprogetto = @idprogetto and x.idworkpackage = wp.idworkpackage and x.idprogettotipocosto = ptcc.idprogettotipocosto)
	order by wp.idworkpackage,ptcc.sortcode

	--TESTI
	INSERT INTO [dbo].[progettotesto]
           ([idprogettotesto]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotesto),0) from progettotesto) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettotestokind ASC) as idprogettotesto,
        @idprogetto as idprogetto,
        ptk.titolo,
        '' as [description],
        ptk.sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettotestokind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettotesto x 
																where x.idprogetto = @idprogetto and x.title = ptk.titolo)

	--ALLEGATI
	INSERT INTO [dbo].[progettoattach]
           ([idprogettoattach]
		   ,[idattach]
           ,[idprogetto]
           ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettoattach),0) from progettoattach) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettoattachkind ASC) as idprogettoattach,
		null as idattach,
        @idprogetto as idprogetto,
        ptk.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettoattachkind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettoattach x 
																where x.idprogetto = @idprogetto and x.title = ptk.title)


END
GO
IF EXISTS(select * from sysobjects where id = object_id(N'[amministrazione].[get_assetvalueatdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [amministrazione].[get_assetvalueatdate]
GO


CREATE    PROCEDURE [amministrazione].[get_assetvalueatdate]
(
	 @idasset int,
	 @idpiece int,
	 @date    datetime,
	 @originalvalue	decimal (19,2) OUTPUT,
	 @totale  decimal (19,2) OUTPUT
)
AS
BEGIN


----------------------------------------------------------------------------------
-------------------- Valore iniziale se cespite ----------------------------------
----------------------------------------------------------------------------------	
DECLARE @historical decimal(19,2) 
DECLARE @initialamount decimal(19,2) 
DECLARE @amortization decimal(19,2)
DECLARE @piece_posseduti_scaricati_original decimal(19,2)
DECLARE @piece_posseduti_scaricati_current decimal(19,2)

select @historical = historicalvalue from assetacquire AC 
				join asset A on A.nassetacquire=AC.nassetacquire
				where A.idasset=@idasset and A.idpiece=@idpiece
				
IF      (@idpiece = 1) --Cespite principale
	-- Per data intendiamo la data dell'ammortamento e calcoliamo la situazione alla data
	-- costruisco una sp che data una coppia idasset,idpiece e una data, calcoli il valore corrente 
	-- del cespite a quella data
	-- Calcolo valore alla data se cespite

BEGIN
       --print @idpiece
	SET @initialamount = ISNULL((
	SELECT 
	CASE	
		----------------------------------------------------------------------------------
		----------------- Considera i buoni di carico precedenti al 2005 -----------------
		----------------------------------------------------------------------------------
		WHEN 
	 	(((inventorykind.flag & 1)<> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR(
		assetacquire.idassetload IS NULL AND ((assetacquire.flag & 2) <> 0)))	
		THEN
		CONVERT(decimal(19,2),ROUND(
			ROUND(ISNULL(assetacquire.taxable, 0)
			* (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
			+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
			- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
		,2))
		----------------------------------------------------------------------------------
		------- Considera i buoni di carico del 2005 e i successivi  SENZA SCONTO --------
		----------------------------------------------------------------------------------			
		WHEN NOT (((inventorykind.flag & 1)<> 0) OR ISNULL(assetload.yassetload,2006)<2005 OR  
		(assetacquire.idassetload is null and ((assetacquire.flag & 2) <> 0)) )	
		THEN
		CONVERT(decimal(19,2),ROUND(
		ROUND(ISNULL(assetacquire.taxable, 0),2)
		+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
		- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
		,2))
		ELSE 0
		END
	FROM asset 
	JOIN assetacquire 
		ON assetacquire.nassetacquire = asset.nassetacquire
	LEFT OUTER JOIN assetload
		ON assetload.idassetload = assetacquire.idassetload
	JOIN inventory 
		ON inventory.idinventory = assetacquire.idinventory
	JOIN inventorykind
		ON inventory.idinventorykind= inventorykind.idinventorykind  
	WHERE asset.idasset = @idasset
		AND asset.idpiece = @idpiece),0.0);
		
/*
X  = X0 + AMM = X0 (1+ somma aliq.amm)
X0 = X  / (1+somma aliq. amm)
*/
   WITH PIECE_SCARICATI (X, somma_aliquote)
   AS ( SELECT 
			CONVERT(decimal(19,2),ROUND(ISNULL(B.taxable, 0)
				* (1 - CONVERT(decimal(19,6),ISNULL(B.discount, 0))),2)
				+ ROUND(ISNULL(B.tax,0) / B.number,2)
				- ROUND(ISNULL(B.abatable,0) / B.number,2)),
				
				(SELECT SUM(AA.amortizationquota)					
				FROM  assetamortization AA
					LEFT OUTER JOIN assetunload AAU		ON  AA.idassetunload = AAU.idassetunload
					LEFT OUTER JOIN assetload AAL		ON  AA.idassetload = AAL.idassetload
				WHERE AA.idasset = A.idasset	AND   AA.idpiece = 1  /* il cespite esterno alla subquery */
				--AND (
					AND  ( (ISNULL(AA.amortizationquota,0)<0) AND
					    	( ((AA.flag & 1 = 0) 	AND year(AA.adate) <= year(AU.adate)) 
						    OR 
						    ((AA.flag & 1 <> 0)    AND year(AAU.adate) <= year(AU.adate))
					     )
					  )
					  
				-- gli aumenti di valore non entrano in gioco negli accessori posseduti
				--	OR 
					--( (ISNULL(AA.amortizationquota,0)>0) AND 
					 --    ( ((AA.flag & 1 = 0) 	AND year(AA.adate) < year(AU.adate)) 
					 --     OR 
					 --     ((AA.flag & 1 <> 0)    AND year(AAL.adate) <= year(AU.adate))
					 --    )
					 --  )			            

				--	)
				) 				 
		 from  asset A	/* gli accessori posseduti del cespite in input alla SP */
			  JOIN assetacquire B	on B.nassetacquire = A.nassetacquire
			  /*LEFT OUTER */ JOIN  assetunload AU		ON A.idassetunload = AU.idassetunload				
		where A.idasset = @idasset
			and   A.idpiece >1
			and  ((B.flag & 1 = 0) AND (B.flag & 2 <> 0)) 
			AND (/*AU.adate is null OR*/ AU.adate < @date)				/*accessori  scaricati*/
	)
	SELECT 	@piece_posseduti_scaricati_original = SUM(  isnull(X,0)* ( 1+ isnull(somma_aliquote,0)) ),
			@piece_posseduti_scaricati_current  = SUM( X)
				from PIECE_SCARICATI


	-------------------------------------------------------------------------------------------------
END
ELSE
BEGIN
	-- Calcolo valore alla data se accessorio
	SET @initialamount = ISNULL((SELECT  CONVERT(decimal(19,2),ROUND(
				        ROUND(ISNULL(assetacquire.taxable, 0)
				        * (1 - CONVERT(decimal(19,6),ISNULL(assetacquire.discount, 0))),2)
					+ ROUND(ISNULL(assetacquire.tax,0) / assetacquire.number,2)
					- ROUND(ISNULL(assetacquire.abatable,0) / assetacquire.number,2) 
					,2))
				 FROM asset 
				 JOIN assetacquire 
				   ON assetacquire.nassetacquire = asset.nassetacquire
				 JOIN inventory 
				   ON inventory.idinventory = assetacquire.idinventory
				 JOIN inventorykind
				   ON inventory.idinventorykind= inventorykind.idinventorykind  
				WHERE asset.idasset = @idasset
				  AND asset.idpiece = @idpiece
				  AND asset.idpiece >1
				  AND (assetacquire.idassetload is  NOT NULL OR 
				      (((assetacquire.flag & 1) = 0) AND ((assetacquire.flag & 2) <> 0)))),0.0)


				
	
END

	SELECT  @amortization =
		SUM(ROUND(ISNULL(assetamortization.assetvalue,0) * 
		ISNULL(assetamortization.amortizationquota,0),2))
	FROM assetamortization
	JOIN asset
		ON  assetamortization.idasset=asset.idasset
		AND assetamortization.idpiece=asset.idpiece
	JOIN inventoryamortization
		ON assetamortization.idinventoryamortization=inventoryamortization.idinventoryamortization
	LEFT OUTER JOIN assetunload
		ON assetamortization.idassetunload = assetunload.idassetunload
	LEFT OUTER JOIN assetload 
					ON  assetamortization.idassetload = assetload.idassetload
	WHERE  (
				( (ISNULL(assetamortization.amortizationquota,0)>0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate <= @date) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND assetload.adate <= @date)
					)
			 	)
				OR 			            
				( (ISNULL(assetamortization.amortizationquota,0)<0) AND
					( ((assetamortization.flag & 1 = 0) 	AND assetamortization.adate <= @date) 
					  OR 
					  ((assetamortization.flag & 1 <> 0)    AND assetunload.adate <= @date)
					)
			 	)
				)
		AND ((inventoryamortization.flag & 2) <> 0)
		AND asset.idasset = @idasset
		AND asset.idpiece = @idpiece


if (@historical is null) set @historical=@initialamount 

IF ISNULL(@idpiece,0)= 1
BEGIN
	SET @originalvalue = ISNULL(@historical, 0) 	- ISNULL(@piece_posseduti_scaricati_original, 0)
	SET @totale = ISNULL(@initialamount, 0) 	+ ISNULL(@amortization, 0)
							 - ISNULL(@piece_posseduti_scaricati_current, 0)

END
ELSE
BEGIN
	SET @originalvalue = @historical
	SET @totale =  ISNULL(@initialamount, 0) + ISNULL(@amortization, 0)  
END



END


GO


exec menuweb_addentry @idmenuwebparent = NULL, @idx = 1, @tableName = null, @editType = null, @label = 'Tutti i Menù';
exec menuweb_addentry @idmenuwebparent = 1, @idx = 29, @tableName = null, @editType = null, @label = 'Menù dell''applicazione delle segreterie';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 400, @tableName = null, @editType = null, @label = 'Amministrazione';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 81, @tableName = null, @editType = null, @label = 'Segreteria didattica';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 83, @tableName = null, @editType = null, @label = 'Segreteria amministrativa';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 296, @tableName = null, @editType = null, @label = 'Progetti di ricerca e attività istituzionali';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 41, @tableName = null, @editType = null, @label = 'Elenchi';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 143, @tableName = null, @editType = null, @label = 'Configurazioni';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 177, @tableName = null, @editType = null, @label = 'Tipologie';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 244, @tableName = null, @editType = null, @label = 'Definizione delle tasse';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 57, @tableName = 'sasd', @editType = 'default', @label = 'Settori artistico-scientifico disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 72, @tableName = 'classconsorsuale', @editType = 'default', @label = 'Classi di concorso MIUR';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 145, @tableName = 'ccnl', @editType = 'default', @label = 'Contratti Collettivi Nazionali del Lavoro';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 170, @tableName = 'areadidattica', @editType = 'default', @label = 'Aeree didattiche';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 178, @tableName = 'istattitolistudio', @editType = 'default', @label = 'Titoli di studio ISTAT';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 180, @tableName = 'classescuola', @editType = 'default', @label = 'Scuole / Classi di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 186, @tableName = 'upb', @editType = 'default', @label = 'Unità previsionali di base';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 191, @tableName = 'geo_nation', @editType = 'seg', @label = 'Nazioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 193, @tableName = 'geo_continent', @editType = 'default', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 194, @tableName = 'geo_country', @editType = 'seg', @label = 'Province';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 195, @tableName = 'geo_region', @editType = 'seg', @label = 'Regioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 196, @tableName = 'geo_city', @editType = 'seg', @label = 'Comuni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 197, @tableName = 'corsostudionorma', @editType = 'default', @label = 'Normativa dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 213, @tableName = 'corsostudiolivello', @editType = 'default', @label = 'Livelli dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 239, @tableName = 'geo_continent', @editType = 'anagrafica_easyweb', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 270, @tableName = 'pianostudiostatus', @editType = 'default', @label = 'Stati dei piani di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 278, @tableName = 'nace', @editType = 'default', @label = 'Classificazione delle attività economiche nella Comunità Europea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 279, @tableName = 'ateco', @editType = 'default', @label = 'Classificazione ATECO';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 292, @tableName = 'sasdgruppo', @editType = 'default', @label = 'Gruppo';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 293, @tableName = 'classescuolaarea', @editType = 'default', @label = 'Area della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 294, @tableName = 'classescuolakind', @editType = 'default', @label = 'Tipologia della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 295, @tableName = 'ambitoareadisc', @editType = 'default', @label = 'Ambiti o aree disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 302, @tableName = 'progettostatuskind', @editType = 'default', @label = 'Stati delle attività o progetti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 303, @tableName = 'settoreerc', @editType = 'seg', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 304, @tableName = 'fonteindicebibliometrico', @editType = 'seg', @label = 'Fonti degli indici bibliometrici';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 306, @tableName = 'settoreerc', @editType = 'segprog', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 307, @tableName = 'tax', @editType = 'seg', @label = 'Tipi di ritenuta';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 310, @tableName = 'changes', @editType = 'default', @label = 'Cambiamento per learning agreement';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 311, @tableName = 'changeskind', @editType = 'default', @label = 'Tipo di cambiamenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 344, @tableName = 'stipendiokind', @editType = 'default', @label = 'Tabelle stipendiali';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 346, @tableName = 'naturagiur', @editType = 'default', @label = 'Natura giuridica';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 347, @tableName = 'numerodip', @editType = 'default', @label = 'Numero dipendenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 348, @tableName = 'inventorytree', @editType = 'seg', @label = 'Classificazione inventariale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 353, @tableName = 'isced2013', @editType = 'default', @label = 'International Standard Classification of Education (ISCED)';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 354, @tableName = 'cefr', @editType = 'default', @label = 'Quadro europeo comune di riferimento per le lingue';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 357, @tableName = 'bandomobilitaintkind', @editType = 'default', @label = 'Tipologa del bando di mobilità internanzionale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 397, @tableName = 'currency', @editType = 'default', @label = 'Valute';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 82, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 179, @tableName = null, @editType = null, @label = 'Didattica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 45, @tableName = 'location', @editType = 'aula', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 77, @tableName = 'registry', @editType = 'anagrafica', @label = 'Anagrafica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 79, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazione';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 182, @tableName = 'insegn', @editType = 'default', @label = 'Insegnamenti o Campi disciplinari';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 218, @tableName = 'aula', @editType = 'default', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 220, @tableName = 'edificio', @editType = 'default', @label = 'Edifici';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 84, @tableName = null, @editType = null, @label = 'Iscrizioni, rinnovi, conseguimenti e decadenze';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 86, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 280, @tableName = null, @editType = null, @label = 'Istanze e delibere';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 283, @tableName = null, @editType = null, @label = 'Protocollo';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 313, @tableName = null, @editType = null, @label = 'Tirocini';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 349, @tableName = null, @editType = null, @label = 'Mobilità internazionale';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 358, @tableName = null, @editType = null, @label = 'Diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 367, @tableName = null, @editType = null, @label = 'Dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 369, @tableName = null, @editType = null, @label = 'Contabilità studenti';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 274, @tableName = 'iscrizione', @editType = 'seg', @label = 'Iscrizioni';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 308, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 381, @tableName = 'sostenimento', @editType = 'segcons', @label = 'Conseguimento del titolo';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 42, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica Generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 51, @tableName = 'registry', @editType = 'aziende', @label = 'Enti e Aziende';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 52, @tableName = 'registry', @editType = 'istituti', @label = 'Istituti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 53, @tableName = 'registry', @editType = 'istitutiesteri', @label = 'Istituti esteri';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 174, @tableName = 'registry', @editType = 'studenti', @label = 'Studenti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 187, @tableName = 'aoo', @editType = 'default', @label = 'Aree organizzative interne';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 212, @tableName = 'sede', @editType = 'default', @label = 'Sedi';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 214, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 215, @tableName = 'struttura', @editType = 'default', @label = 'Struttura / Unità organizzativa';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 300, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 146, @tableName = 'menuweb', @editType = 'tree', @label = 'Menù';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 233, @tableName = 'registry', @editType = 'user', @label = 'Pagina di registrazione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 241, @tableName = 'questionario', @editType = 'default', @label = 'Questionari';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 242, @tableName = 'graduatoriavar', @editType = 'default', @label = 'Variabili delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 243, @tableName = 'registry', @editType = 'istituti_princ', @label = 'Istituto in gestione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 277, @tableName = 'graduatoria', @editType = 'default', @label = 'Definizioni delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 135, @tableName = 'contrattokind', @editType = 'default', @label = 'Tipologie di contratto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 137, @tableName = 'publicazkind', @editType = 'default', @label = 'Tipologie di pubblicazione ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 139, @tableName = 'rendicontaltrokind', @editType = 'default', @label = 'Tipologia delle attività da rendicontare oltre le lezioni ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 141, @tableName = 'studdirittokind', @editType = 'default', @label = 'Categoria dello studente per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 142, @tableName = 'studprenotkind', @editType = 'default', @label = 'Tipologia di studente durante la prenotazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 171, @tableName = 'corsostudiokind', @editType = 'default', @label = 'Tipologie dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 172, @tableName = 'istitutokind', @editType = 'default', @label = 'Tipologia di istituto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 176, @tableName = 'registryclass', @editType = 'default', @label = 'Tipologia fiscale';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 183, @tableName = 'valutazionekind', @editType = 'default', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 211, @tableName = 'strutturakind', @editType = 'default', @label = 'Tipologia delle strutture';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 217, @tableName = 'tipoattform', @editType = 'default', @label = 'Tipologia delle attività formative';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 221, @tableName = 'valutazionekind', @editType = 'seg_child', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 223, @tableName = 'aulakind', @editType = 'default', @label = 'Tipologie delle aule';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 225, @tableName = 'affidamentokind', @editType = 'default', @label = 'Tipologie di affidamento';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 227, @tableName = 'erogazkind', @editType = 'default', @label = 'Tipologie di erogazione della didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 229, @tableName = 'sessionekind', @editType = 'default', @label = 'Tipologie di sessione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 230, @tableName = 'appellokind', @editType = 'default', @label = 'Tipologie di appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 263, @tableName = 'istanzakind', @editType = 'default', @label = 'Tipologie di istanza';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 264, @tableName = 'ofakind', @editType = 'default', @label = 'Titologie di obblighi formativi aggiuntivi';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 265, @tableName = 'questionariodomkind', @editType = 'default', @label = 'Tipologie di  domande del questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 266, @tableName = 'questionariokind', @editType = 'default', @label = 'Tipologie di questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 267, @tableName = 'tirociniocandidaturakind', @editType = 'default', @label = 'Tipologia di candidatura ad un tirocinio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 268, @tableName = 'tirociniostato', @editType = 'default', @label = 'Stato dei tirocini';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 269, @tableName = 'appelloazionekind', @editType = 'default', @label = 'Titologie di azione in appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 271, @tableName = 'sostenimentoesito', @editType = 'default', @label = 'Esito';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 290, @tableName = 'dichiarkind', @editType = 'default', @label = 'Tipi di dichiarazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 298, @tableName = 'orakind', @editType = 'seg', @label = 'Tipologia di ore';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 305, @tableName = 'progettoactivitykind', @editType = 'default', @label = 'Tipo di attività o progetto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 345, @tableName = 'duratakind', @editType = 'default', @label = 'Tipo di durata';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 365, @tableName = 'accreditokind', @editType = 'default', @label = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 366, @tableName = 'convalidakind', @editType = 'default', @label = 'Tipologie di convalida';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 376, @tableName = 'dichiardisabilkind', @editType = 'default', @label = 'Tipologie di disabilità';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 377, @tableName = 'dichiardisabilsuppkind', @editType = 'default', @label = 'Tipologie dichiarazioni disabilita';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 382, @tableName = 'dichiaraltrekind', @editType = 'default', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 383, @tableName = 'dichiaraltrekind', @editType = 'elenchi', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 392, @tableName = 'bandodsiscresitokind', @editType = 'default', @label = 'Esito della partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 401, @tableName = 'progettoudrmembrokind', @editType = 'default', @label = 'Tipologia di membro delle unità di personale';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 181, @tableName = 'didprog', @editType = 'default', @label = 'Didattiche programmate';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 188, @tableName = 'corsostudio', @editType = 'default', @label = 'Corsi di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 219, @tableName = 'diderog', @editType = 'default', @label = 'Didattica Erogata';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 226, @tableName = 'appello', @editType = 'default', @label = 'Appelli';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 228, @tableName = 'sessione', @editType = 'default', @label = 'Sessioni di esami';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 232, @tableName = 'corsostudio', @editType = 'ingresso', @label = 'Prove di ammissione';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 272, @tableName = 'corsostudio', @editType = 'dotmas', @label = 'Master';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 273, @tableName = 'corsostudio', @editType = 'stato', @label = 'Esami di stato';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 276, @tableName = 'pianostudio', @editType = 'segstud', @label = 'Piani di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 312, @tableName = 'pratica', @editType = 'segstud', @label = 'Pratica di convalida/riconoscimento/dispensa';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 391, @tableName = 'getcostididattica', @editType = 'default', @label = 'Riepilogo dei costi degli affidamenti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 246, @tableName = 'costoscontodef', @editType = 'default', @label = 'Costi';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 247, @tableName = 'costoscontodef', @editType = 'sconti', @label = 'Sconti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 248, @tableName = 'costoscontodef', @editType = 'more', @label = 'Indennità / More';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 249, @tableName = 'costoscontodefdettagliokind', @editType = 'default', @label = 'Voci dei dettaglio debito';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 250, @tableName = 'esonero', @editType = 'default', @label = 'Definizione degli esoneri generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 251, @tableName = 'esonero', @editType = 'carriera', @label = 'Definizione degli esoneri  derivanti dalla carriera';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 252, @tableName = 'esonero', @editType = 'disabil', @label = 'Definizione degli esoneri di invalidità';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 253, @tableName = 'esonero', @editType = 'titolostudio', @label = 'Definizione degli esoneri per titoli di studio conseguiti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 254, @tableName = 'fasciaisee', @editType = 'default', @label = 'Fasce ISEE';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 255, @tableName = 'pagamentokind', @editType = 'default', @label = 'Tipologie di pagamento';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 256, @tableName = 'ratakind', @editType = 'default', @label = 'Rate';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 257, @tableName = 'tassaconf', @editType = 'default', @label = 'Definizione dei costi generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 258, @tableName = 'tassaconfkind', @editType = 'default', @label = 'Definizione delle tasse generiche';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 259, @tableName = 'tassacsingconf', @editType = 'default', @label = 'Definizione dei costi dei corsi singoli';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 260, @tableName = 'tassaiscrizioneconf', @editType = 'default', @label = 'Definizione delle tasse di iscrizione';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 261, @tableName = 'tassaistanzaconf', @editType = 'default', @label = 'Definizione dei costi delle istanze';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 262, @tableName = 'costoscontodefkind', @editType = 'default', @label = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 287, @tableName = 'istanza', @editType = 'imm_segpre', @label = 'Istanze di preimmatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 288, @tableName = 'istanza', @editType = 'imm_seg', @label = 'Istanze di immatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 289, @tableName = 'istanza', @editType = 'imm_segrin', @label = 'Istanze di rinnovo iscrizione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 385, @tableName = 'istanza', @editType = 'rin_seg', @label = 'Istanza di rinuncia agli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 386, @tableName = 'istanza', @editType = 'tru_seg', @label = 'Istanza di trasferimento in uscita';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 387, @tableName = 'istanza', @editType = 'eq_seg', @label = 'Istanza di equipollenza ';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 388, @tableName = 'istanza', @editType = 'cert_seg', @label = 'Richiesta di certificato';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 389, @tableName = 'istanza', @editType = 'sosp_seg', @label = 'Istanza di sospensione degli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 390, @tableName = 'delibera', @editType = 'seg', @label = 'Delibere';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 284, @tableName = 'protocollo', @editType = 'seg', @label = 'Registrazioni di protocollo';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 285, @tableName = 'protocollodockind', @editType = 'seg', @label = 'Tipo di documento protocollato';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 286, @tableName = 'protocollorifkind', @editType = 'seg', @label = 'Tipo di documento di riferimento';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Progetti e attività';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipi di progetto o attività';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 342, @tableName = 'convenzione', @editType = 'seg', @label = 'Convenzioni';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 343, @tableName = 'tirocinioproposto', @editType = 'seg', @label = 'Proposte di tirocinio';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 350, @tableName = 'programmami', @editType = 'seg', @label = 'Programmi di cooperazione';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 351, @tableName = 'accordoscambiomi', @editType = 'seg', @label = 'Accordi bilaterali';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 352, @tableName = 'bandomi', @editType = 'seg', @label = 'Bandi di mobilità';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 356, @tableName = 'assicurazione', @editType = 'default', @label = 'Assicurazione';
exec menuweb_addentry @idmenuwebparent = 358, @idx = 359, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 359, @idx = 360, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 371, @tableName = 'dichiar', @editType = 'altrititoli_seg', @label = 'Altri titoli';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 378, @tableName = 'dichiar', @editType = 'altre_seg', @label = 'Altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 379, @tableName = 'dichiar', @editType = 'disabil_seg', @label = 'Dichiarazione di disabilità';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 380, @tableName = 'dichiar', @editType = 'isee_seg', @label = 'Attestazione ISEE';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 384, @tableName = 'dichiar', @editType = 'titolo_seg', @label = 'Dichiarazione titoli di studio';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 408, @tableName = 'registry', @editType = 'admin', @label = 'Funzioni di amministrazione';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipo di progetto o attività';
--docenti
exec menuweb_addentry @idmenuwebparent = 29, @idx = 415, @tableName = null, @editType = null, @label = 'I miei dati';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 416, @tableName = null, @editType = null, @label = 'I miei corsi';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 421, @tableName = null, @editType = null, @label = 'Le mie attività di ricerca e istituzionali';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 417, @tableName = 'assetdiary', @editType = 'doc', @label = 'Diari di utilizzo di beni strumentali';
exec menuweb_addentry @idmenuwebparent = 416, @idx = 418, @tableName = 'affidamento', @editType = 'doc', @label = 'Affidamento';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 419, @tableName = 'rendicontattivitaprogetto', @editType = 'doc', @label = 'Attività di ricerca';
exec menuweb_addentry @idmenuwebparent = 415, @idx = 420, @tableName = 'registry', @editType = 'docenti_doc', @label = 'Dati personali';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Attività e progetti';
--menuï»¿
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[GenerateRule]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GenerateRule]
GO

CREATE PROCEDURE [dbo].[GenerateRule]
            @table varchar(1024)
           ,@code varchar(30)
           ,@message varchar(960)
           ,@post char(1)
           ,@warning char(1)
           ,@ins char(1)
           ,@upd char(1)
           ,@del char(1)
           ,@sql varchar(6000)
		   ,@executor varchar(60)				-- utente che sta eseguento la procedura (per il log)
	  AS
BEGIN

	IF NOT EXISTS(select [idaudit] from [amministrazione].[audit] where [idaudit] = @code) 
	BEGIN 
		INSERT INTO [amministrazione].[audit]
           ([idaudit]
           ,[consequence]
           ,[flagsystem]
           ,[lt]
           ,[lu]
           ,[severity]
           ,[title])
		VALUES
           (@code
           ,null
           ,'N'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,CASE WHEN @warning = 'B' THEN 'E' ELSE 'W' END --E bloccante W warning
           ,substring(@code + ' - ' + @message,0,127))
	END

	IF (@ins = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'I' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheck int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'I'
           ,@code
           ,@idcheck
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

	IF (@upd = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'U' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheckU int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'U'
           ,@code
           ,@idcheckU
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

	IF (@del = 'S' AND 
		NOT EXISTS(	select [idcheck] 
					from [amministrazione].[auditcheck] 
					where [opkind] = 'D' AND [idaudit] = @code AND [sqlcmd] = @sql AND [message] = @message))
	BEGIN 

		DECLARE @idcheckD int = (select isnull(max(idcheck),0) +1   from [amministrazione].[auditcheck] where [idaudit] = @code)    

		INSERT INTO [amministrazione].[auditcheck]
           ([tablename]
           ,[opkind]
           ,[idaudit]
           ,[idcheck]
           ,[flag_both]
           ,[flag_cash]
           ,[flag_comp]
           ,[lt]
           ,[lu]
           ,[message]
           ,[precheck]
           ,[sqlcmd]
           ,[flag_credit]
           ,[flag_proceeds])
		VALUES
           (@table
           ,'D'
           ,@code
           ,@idcheckD
           ,'S'
           ,'S'
           ,'S'
           ,CURRENT_TIMESTAMP
           ,@executor
           ,@message
           ,CASE WHEN @post = 'O' THEN 'N' ELSE 'S' END
           ,@sql
           ,'N'
           ,'N')
	END

END
GO

exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogettokind  
	from progettotipocostokindaccmotive
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idaccmotive, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogettokind  
	from progettotipocostokindcontrattokind
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idcontrattokind, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogettokind  
	from progettotipocostokindinventorytree
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idinv, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogettokind  
	from progettotipocostokindtax
	where idprogettokind = %<progettokind.idprogettokind>%
	group by taxcode, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogetto  
	from progettotipocostoaccmotive
	where idprogetto = %<progetto.idprogetto>%
	group by idaccmotive, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogetto  
	from progettotipocostocontrattokind
	where idprogetto = %<progetto.idprogetto>%
	group by idcontrattokind, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogetto  
	from progettotipocostoinventorytree
	where idprogetto = %<progetto.idprogetto>%
	group by idinv, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
--rule	--LANCIARE SOLO DOPO LO SCRIPT CHE GENERA IL MENU'!!!!!!!!!!!!!!!!!!!!!!!!

--query per la generazione dell'elenco delle variabili di sicurezza da associare
--select variablename  from [restrictedfunction] where idrestrictedfunction in (
--	select idrestrictedfunction 
--	from amministrazione.[FlowChartrestrictedfunction] 
--	where idflowchart = (select top 1 idflowchart from amministrazione.flowchart where codeflowchart = 'SEGDOC')
--	)
--order by variablename

--verifica esistenza nodi
--select * from [amministrazione].[flowchart] where idflowchart in ('202099','202098','20','202096')
IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202099')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202099'
           ,null
           ,2020
           ,null
           ,'SEGADM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202098')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202098'
           ,null
           ,2020
           ,null
           ,'SEGPRG'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Progetti Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202096')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202096'
           ,null
           ,2020
           ,null
           ,'SEGDOC'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Docenti'
           ,null
           ,null
           ,null)
GO

--diritti Docenti

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202096'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'
,'mr_416'
,'mr_417'
,'mr_418'
,'mr_419'
,'mr_420'
,'mr_421'
,'mw_417'
,'mw_418'
,'mw_419'
,'mw_420'
,'all_upb'
,'all_man'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202096' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)



--diritti Amministratori segreterie

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202099'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mandato'
,'reversale'
,'compensi'
,'bilancio'
,'upb'
,'spesa'
,'entrata'
,'ordine'
,'trasmissione'
,'esitazione'
,'fondoec'
,'annullamento'
,'cespiti'
,'iva'
,'anag_c'
,'anag_l'
,'econopatr'
,'liquidazione'
,'stampe'
,'classificazione'
,'contrattivo'
,'impegni'
,'accertamenti'
,'ordinegrande'
,'organigramma'
,'management'
,'dichiarazione'
,'imposta'
,'configurazione'
,'anagrafeprestazioni'
,'consolidamento'
,'man_ufficiale'
,'rev_ufficiale'
,'multiprint'
,'banca'
,'crediti'
,'incassi'
,'coana'
,'contcompensi'
,'contiva'
,'contcontratti'
,'previsione'
,'assestamento'
,'list_man'
,'responsabile'
,'contrattivogrande'
,'list_mfin'
,'list_mupb'
,'menu'
,'anagrafica'
,'sel_cp'
,'sel_ca'
,'bilancio_read'
,'anagrafica_read'
,'spesa_read'
,'entrata_read'
,'trasmissione_read'
,'fondoec_read'
,'adm_localconfig'
,'adm_backup'
,'adm_ondemand'
,'adm_menuupdate'
,'varspesa'
,'varentrata'
,'tax_clawback'
,'endofyear_entry'
,'all_fin'
,'all_upb'
,'all_man'
,'all_mandatekind'
,'all_estimatekind'
,'all_invoicekind'
,'all_pettycash'
,'list_estimatekind'
,'list_invoicekind'
,'list_pettycash'
,'list_mandatekind'
,'fattura'
,'del_invoice'
,'cespiti_read'
,'liquidazioneiva'
,'anag_d'
,'classificazione_mod'
,'anag_dis'
,'chiusura'
,'anag_config'
,'anag_procedure'
,'adm_magazzino'
,'ric_magazzino'
,'config_magazzino'
,'pre_accertamenti'
,'post_accertamenti'
,'pre_impegni'
,'post_impegni'
,'dipendenti'
,'missioni'
,'occasionali'
,'cococo'
,'professionali'
,'stipendi'
,'eco_entry'
,'all_authmodel'
,'list_authmodel'
,'crea_card'
,'admin_card'
,'var_bilancio'
,'asspendenti'
,'movimprotetta'
,'saldicassa'
,'finvarapproved'
,'manage_estimatekind'
,'manage_mandatekind'
,'manage_invoicekind'
,'storniapprove'
,'sitfinanziaria_read'
,'finanziamenti'
,'trasmissione_ap'
,'edit_limit'
,'stornimedesimocapitoloapprove'
,'finvarcredit'
,'sel_fatture'
,'trasmissione_abilita'
,'certificazionecrediti'
,'fe_ipa_rifamm'
,'fe_ipa'
,'fe_all'
,'manage_split_payment'
,'accetta_fe'
,'rifiuta_fe'
,'creaincontabilita_fe'
,'cambia_rifamm'
,'tipologiaincarichi_ap'
,'var_budget'
,'storno_budget'
,'storno_budget_approve'
,'var_budget_approve'
,'edit_epexpresidui'
,'flussostudenti'
,'flussomovimenti'
,'config_bil_sottosezionali'
,'mov_protettecomp'
,'ct_stornocompetenzaclass'
,'pat'
,'UPBsecurity'
,'edit_epaccresidui'
,'flag_escludidacu'
,'notcreacontabilita'
,'flag_authorizationfree'
,'config_stipendi'
,'stipendi_ct'
,'conf_classauto'
,'upd_paymentcompetency'
,'config_account'
,'mw_40'
,'mr_1'
,'mr_29'
,'mr_400'
,'mr_81'
,'mr_83'
,'mr_296'
,'mr_41'
,'mr_143'
,'mr_177'
,'mr_244'
,'mr_57'
,'mw_57'
,'mr_72'
,'mw_72'
,'mr_145'
,'mw_145'
,'mr_170'
,'mw_170'
,'mr_178'
,'mw_178'
,'mr_180'
,'mw_180'
,'mr_186'
,'mw_186'
,'mr_191'
,'mw_191'
,'mr_193'
,'mw_193'
,'mr_194'
,'mw_194'
,'mr_195'
,'mw_195'
,'mr_196'
,'mw_196'
,'mr_197'
,'mw_197'
,'mr_213'
,'mw_213'
,'mr_239'
,'mw_239'
,'mr_270'
,'mw_270'
,'mr_278'
,'mw_278'
,'mr_279'
,'mw_279'
,'mr_292'
,'mw_292'
,'mr_293'
,'mw_293'
,'mr_294'
,'mw_294'
,'mr_295'
,'mw_295'
,'mr_302'
,'mw_302'
,'mr_303'
,'mw_303'
,'mr_304'
,'mw_304'
,'mr_306'
,'mw_306'
,'mr_307'
,'mw_307'
,'mr_310'
,'mw_310'
,'mr_311'
,'mw_311'
,'mr_344'
,'mw_344'
,'mr_346'
,'mw_346'
,'mr_347'
,'mw_347'
,'mr_348'
,'mw_348'
,'mr_353'
,'mw_353'
,'mr_354'
,'mw_354'
,'mr_357'
,'mw_357'
,'mr_397'
,'mw_397'
,'mr_82'
,'mr_179'
,'mr_45'
,'mw_45'
,'mr_77'
,'mw_77'
,'mr_79'
,'mw_79'
,'mr_136'
,'mw_136'
,'mr_182'
,'mw_182'
,'mr_218'
,'mw_218'
,'mr_220'
,'mw_220'
,'mr_84'
,'mr_86'
,'mr_280'
,'mr_283'
,'mr_313'
,'mr_349'
,'mr_358'
,'mr_367'
,'mr_369'
,'mr_274'
,'mw_274'
,'mr_308'
,'mw_308'
,'mr_381'
,'mw_381'
,'mr_42'
,'mw_42'
,'mr_51'
,'mw_51'
,'mr_52'
,'mw_52'
,'mr_53'
,'mw_53'
,'mr_174'
,'mw_174'
,'mr_187'
,'mw_187'
,'mr_212'
,'mw_212'
,'mr_215'
,'mw_215'
,'mr_300'
,'mw_300'
,'mr_146'
,'mw_146'
,'mr_233'
,'mw_233'
,'mr_241'
,'mw_241'
,'mr_242'
,'mw_242'
,'mr_243'
,'mw_243'
,'mr_277'
,'mw_277'
,'mr_135'
,'mw_135'
,'mr_137'
,'mw_137'
,'mr_139'
,'mw_139'
,'mr_141'
,'mw_141'
,'mr_142'
,'mw_142'
,'mr_171'
,'mw_171'
,'mr_172'
,'mw_172'
,'mr_176'
,'mw_176'
,'mr_183'
,'mw_183'
,'mr_211'
,'mw_211'
,'mr_217'
,'mw_217'
,'mr_221'
,'mw_221'
,'mr_223'
,'mw_223'
,'mr_225'
,'mw_225'
,'mr_227'
,'mw_227'
,'mr_229'
,'mw_229'
,'mr_230'
,'mw_230'
,'mr_263'
,'mw_263'
,'mr_264'
,'mw_264'
,'mr_265'
,'mw_265'
,'mr_266'
,'mw_266'
,'mr_267'
,'mw_267'
,'mr_268'
,'mw_268'
,'mr_269'
,'mw_269'
,'mr_271'
,'mw_271'
,'mr_290'
,'mw_290'
,'mr_298'
,'mw_298'
,'mr_305'
,'mw_305'
,'mr_345'
,'mw_345'
,'mr_365'
,'mw_365'
,'mr_366'
,'mw_366'
,'mr_376'
,'mw_376'
,'mr_377'
,'mw_377'
,'mr_382'
,'mw_382'
,'mr_383'
,'mw_383'
,'mr_392'
,'mw_392'
,'mr_401'
,'mw_401'
,'mr_181'
,'mw_181'
,'mr_188'
,'mw_188'
,'mr_219'
,'mw_219'
,'mr_226'
,'mw_226'
,'mr_228'
,'mw_228'
,'mr_232'
,'mw_232'
,'mr_272'
,'mw_272'
,'mr_273'
,'mw_273'
,'mr_276'
,'mw_276'
,'mr_312'
,'mw_312'
,'mr_391'
,'mw_391'
,'mr_246'
,'mw_246'
,'mr_247'
,'mw_247'
,'mr_248'
,'mw_248'
,'mr_249'
,'mw_249'
,'mr_250'
,'mw_250'
,'mr_251'
,'mw_251'
,'mr_252'
,'mw_252'
,'mr_253'
,'mw_253'
,'mr_254'
,'mw_254'
,'mr_255'
,'mw_255'
,'mr_256'
,'mw_256'
,'mr_257'
,'mw_257'
,'mr_258'
,'mw_258'
,'mr_259'
,'mw_259'
,'mr_260'
,'mw_260'
,'mr_261'
,'mw_261'
,'mr_262'
,'mw_262'
,'mr_287'
,'mw_287'
,'mr_288'
,'mw_288'
,'mr_289'
,'mw_289'
,'mr_385'
,'mw_385'
,'mr_386'
,'mw_386'
,'mr_387'
,'mw_387'
,'mr_388'
,'mw_388'
,'mr_389'
,'mw_389'
,'mr_390'
,'mw_390'
,'mr_284'
,'mw_284'
,'mr_285'
,'mw_285'
,'mr_286'
,'mw_286'
,'mr_297'
,'mw_297'
,'mr_299'
,'mw_299'
,'mr_342'
,'mw_342'
,'mr_343'
,'mw_343'
,'mr_350'
,'mw_350'
,'mr_351'
,'mw_351'
,'mr_352'
,'mw_352'
,'mr_356'
,'mw_356'
,'mr_359'
,'mw_359'
,'mr_360'
,'mw_360'
,'mr_371'
,'mw_371'
,'mr_378'
,'mw_378'
,'mr_379'
,'mw_379'
,'mr_380'
,'mw_380'
,'mr_384'
,'mw_384'
,'mr_402'
,'mw_402'
,'mr_403'
,'mw_403'
,'mr_404'
,'mw_404'
,'mr_408'
,'mw_408'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202099' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diriti Amministratori progetti
INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202098'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'anag_config',
'anagrafica',
'anagrafica_read',
'all_upb',
'all_man',
'mr_135',
'mr_136',
'mr_137',
'mr_143',
'mr_176',
'mr_177',
'mr_179',
'mr_211',
'mr_212',
'mr_215',
'mr_272',
'mr_283',
'mr_284',
'mr_285',
'mr_286',
'mr_29',
'mr_296',
'mr_297',
'mr_299',
'mr_300',
'mr_302',
'mr_303',
'mr_304',
'mr_305',
'mr_306',
'mr_307',
'mr_344',
'mr_348',
'mr_397',
'mr_400',
'mr_401',
'mr_41',
'mr_51',
'mr_52',
'mr_53',
'mr_79',
'mr_81',
'mr_82',
'mr_83',
'mr_86',
'mw_135',
'mw_136',
'mw_137',
'mw_211',
'mw_212',
'mw_215',
'mw_284',
'mw_285',
'mw_286',
'mw_297',
'mw_299',
'mw_300',
'mw_302',
'mw_303',
'mw_304',
'mw_305',
'mw_306',
'mw_401',
'mw_51',
'mw_52',
'mw_53',
'mw_79'
,'mr_408'
,'mw_408'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202098' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)





 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seganagstu', 'istanzapas_seganagstuview', 'pas_seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettotipocosto', 'seg', 'progettotipocostosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassacsingconf', 'default', 'tassacsingconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefrlanglevel', 'default', 'cefrlangleveldefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmiattach', 'seg', 'iscrizionebmiattachsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipologiastudente', 'seg', 'tipologiastudentesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seganagstu', 'dichiarisee_seganagstuview', 'isee_seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seganagstu', 'dichiardisabil_seganagstuview', 'disabil_seganagstu', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rin_seg', 'istanzarin_segview', 'rin_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'segtitolo', 'titolostudiosegtitoloview', 'segtitolo', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'erogata', 'getcostididatticaerogataview', 'erogata', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoudrmembrokind', 'default', 'progettoudrmembrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoasset', 'default', 'progettoassetdefaultview', 'default', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'doc', 'affidamentodocview', 'doc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'doc', 'rendicontattivitaprogettodocview', 'doc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti_doc', 'registrydocenti_docview', 'docenti_doc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'doc', 'assetdiarydocview', 'doc', NULL, NULL, NULL, NULL)
 --INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sal', 'default', 'saldefaultview', 'default', NULL, NULL, NULL, NULL)
 --insert
