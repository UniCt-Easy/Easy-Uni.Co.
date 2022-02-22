
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


-- CREAZIONE TABELLA tirocinioprogetto --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[tirocinioprogetto]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[tirocinioprogetto] (
idtirocinioprogetto int NOT NULL,
idtirociniocandidatura int NOT NULL,
idtirocinioproposto int NOT NULL,
idreg_studenti int NOT NULL,
idreg_referente int NOT NULL,
competenze varchar(max) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datafineeffettiva date NULL,
datafineprevista date NOT NULL,
datainizioeffettiva date NULL,
datainizioprevista date NOT NULL,
dataverbale date NULL,
description varchar(max) NOT NULL,
description_en varchar(max) NULL,
idaoo int NOT NULL,
idreg_docenti int NOT NULL,
idsede int NULL,
idstruttura int NOT NULL,
idtirociniostato int NOT NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
ore int NOT NULL,
protanno int NULL,
protnumero int NULL,
tempiaccesso varchar(max) NULL,
title varchar(max) NOT NULL,
title_en varchar(max) NULL,
 CONSTRAINT xpktirocinioprogetto PRIMARY KEY (idtirocinioprogetto,
idtirociniocandidatura,
idtirocinioproposto,
idreg_studenti,
idreg_referente
)
)
END
GO

-- VERIFICA STRUTTURA tirocinioprogetto --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirocinioprogetto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirocinioprogetto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirocinioprogetto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirociniocandidatura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirociniocandidatura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirociniocandidatura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirocinioproposto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirocinioproposto int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirocinioproposto' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_studenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_studenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_studenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_referente' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_referente int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_referente' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'competenze' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD competenze varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN competenze varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datafineeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datafineeffettiva date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datafineeffettiva date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datafineprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datafineprevista date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'datafineprevista' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datafineprevista date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datainizioeffettiva' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datainizioeffettiva date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datainizioeffettiva date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'datainizioprevista' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD datainizioprevista date NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'datainizioprevista' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN datainizioprevista date NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'dataverbale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD dataverbale date NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN dataverbale date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD description varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'description' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN description varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'description_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD description_en varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN description_en varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idaoo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idaoo int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idaoo' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idaoo int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idreg_docenti int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idreg_docenti' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idreg_docenti int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idstruttura int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'idtirociniostato' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD idtirociniostato int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'idtirociniostato' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN idtirociniostato int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'ore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD ore int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'ore' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN ore int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'protanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD protanno int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN protanno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'protnumero' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD protnumero int NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN protnumero int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'tempiaccesso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD tempiaccesso varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN tempiaccesso varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('tirocinioprogetto') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [tirocinioprogetto] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN title varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'tirocinioprogetto' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [tirocinioprogetto] ADD title_en varchar(max) NULL 
END
ELSE
	ALTER TABLE [tirocinioprogetto] ALTER COLUMN title_en varchar(max) NULL
GO

-- VERIFICA DI tirocinioprogetto IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'tirocinioprogetto'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idreg_referente','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idreg_studenti','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idtirociniocandidatura','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idtirocinioprogetto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idtirocinioproposto','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','varchar(max)','ASSISTENZA','competenze','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','date','ASSISTENZA','datafineeffettiva','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','date','ASSISTENZA','datafineprevista','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','date','ASSISTENZA','datainizioeffettiva','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','date','ASSISTENZA','datainizioprevista','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','date','ASSISTENZA','dataverbale','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','varchar(max)','ASSISTENZA','description','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','varchar(max)','ASSISTENZA','description_en','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idaoo','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idreg_docenti','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idstruttura','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','idtirociniostato','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','int','ASSISTENZA','ore','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','int','ASSISTENZA','protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','int','ASSISTENZA','protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','varchar(max)','ASSISTENZA','tempiaccesso','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','tirocinioprogetto','varchar(max)','ASSISTENZA','title','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','tirocinioprogetto','varchar(max)','ASSISTENZA','title_en','-1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI tirocinioprogetto IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'tirocinioprogetto')
UPDATE customobject set isreal = 'S' where objectname = 'tirocinioprogetto'
ELSE
INSERT INTO customobject (objectname, isreal) values('tirocinioprogetto', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'tirocinioprogetto')
UPDATE [tabledescr] SET description = '2.5.23 Progetto formativo
',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 13:28:06.157'},lu = 'assistenza',title = 'Progetto formativo' WHERE tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('tirocinioprogetto','2.5.23 Progetto formativo
',null,'N',{ts '2018-07-27 13:28:06.157'},'assistenza','Progetto formativo')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'competenze' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'competenze' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('competenze','tirocinioprogetto','-1',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','tirocinioprogetto','8',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.770'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','tirocinioprogetto','64',null,null,null,'S',{ts '2018-07-27 13:27:53.770'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineeffettiva' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine effettiva',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datafineeffettiva' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineeffettiva','tirocinioprogetto','3',null,null,'Data fine effettiva','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datafineprevista' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data fine prevista',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datafineprevista' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datafineprevista','tirocinioprogetto','3',null,null,'Data fine prevista','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioeffettiva' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio effettiva',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioeffettiva' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioeffettiva','tirocinioprogetto','3',null,null,'Data inizio effettiva','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datainizioprevista' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data inizio prevista',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datainizioprevista' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datainizioprevista','tirocinioprogetto','3',null,null,'Data inizio prevista','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataverbale' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data verbale',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataverbale' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataverbale','tirocinioprogetto','3',null,null,'Data verbale','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','tirocinioprogetto','-1',null,null,'Descrizione','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description_en' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Descrizione in inglese',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description_en' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description_en','tirocinioprogetto','-1',null,null,'Descrizione in inglese','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaoo' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area organizzativa omogenea',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaoo' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaoo','tirocinioprogetto','4',null,null,'Area organizzativa omogenea','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tutor',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','tirocinioprogetto','4',null,null,'Tutor','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_referente' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Referente dell''azienda',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_referente' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_referente','tirocinioprogetto','4',null,null,'Referente dell''azienda','S',{ts '2021-06-22 11:03:58.907'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_studenti' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = 'Studente',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'idreg_studenti' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_studenti','tirocinioprogetto','10',null,null,'Studente','S',{ts '2021-06-22 11:03:58.907'},'assistenza','S','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-08-30 16:52:39.457'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','tirocinioprogetto','4',null,null,'Sede','S',{ts '2019-08-30 16:52:39.457'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura didattica',kind = 'S',lt = {ts '2019-09-09 18:56:05.107'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','tirocinioprogetto','4',null,null,'Struttura didattica','S',{ts '2019-09-09 18:56:05.107'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 18:21:13.250'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniocandidatura' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniocandidatura','tirocinioprogetto','4',null,null,null,'S',{ts '2019-11-28 18:21:13.250'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniopoposto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-11-28 18:21:13.250'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'nchar(10)',sql_type = 'nchar',system_type = 'System.String' WHERE colname = 'idtirociniopoposto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniopoposto','tirocinioprogetto','10',null,null,null,'S',{ts '2019-11-28 18:21:13.250'},'assistenza','S','nchar(10)','nchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioprogetto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioprogetto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioprogetto','tirocinioprogetto','4',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirocinioproposto' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2020-09-03 17:32:39.030'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirocinioproposto' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirocinioproposto','tirocinioprogetto','4',null,null,null,'S',{ts '2020-09-03 17:32:39.030'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtirociniostato' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Stato del tirocinio',kind = 'S',lt = {ts '2021-06-22 11:15:06.500'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtirociniostato' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtirociniostato','tirocinioprogetto','4',null,null,'Stato del tirocinio','S',{ts '2021-06-22 11:15:06.500'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','tirocinioprogetto','8',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 13:27:53.773'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','tirocinioprogetto','64',null,null,null,'S',{ts '2018-07-27 13:27:53.773'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ore' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ore' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ore','tirocinioprogetto','4',null,null,'Ore','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protanno' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno protocollo',kind = 'S',lt = {ts '2020-07-06 16:19:38.337'},lu = 'mluisas',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protanno' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protanno','tirocinioprogetto','4',null,null,'Anno protocollo','S',{ts '2020-07-06 16:19:38.337'},'mluisas','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'protnumero' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero Protocollo',kind = 'S',lt = {ts '2020-07-06 16:19:55.930'},lu = 'mluisas',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'protnumero' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('protnumero','tirocinioprogetto','4',null,null,'Numero Protocollo','S',{ts '2020-07-06 16:19:55.930'},'mluisas','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempiaccesso' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Tempi di accesso',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'tempiaccesso' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempiaccesso','tirocinioprogetto','-1',null,null,'Tempi di accesso','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','tirocinioprogetto','-1',null,null,'Titolo','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'tirocinioprogetto')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo in inglese',kind = 'S',lt = {ts '2021-06-22 11:03:58.907'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'tirocinioprogetto'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','tirocinioprogetto','-1',null,null,'Titolo in inglese','S',{ts '2021-06-22 11:03:58.907'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

