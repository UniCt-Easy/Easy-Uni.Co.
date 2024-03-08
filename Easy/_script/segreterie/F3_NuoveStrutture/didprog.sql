
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
-- CREAZIONE TABELLA didprog --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[didprog] (
iddidprog int NOT NULL,
idcorsostudio int NOT NULL,
aa varchar(9) NULL,
annosolare int NULL,
attribdebiti nvarchar(max) NULL,
ciclo int NULL,
codice varchar(50) NULL,
codicemiur varchar(50) NULL,
dataconsmaxiscr date NULL,
freqobbl char(1) NULL,
idareadidattica int NULL,
idconvenzione int NULL,
iddidprognumchiusokind int NULL,
iddidprogsuddannokind int NULL,
iderogazkind int NULL,
idgraduatoria int NULL,
idnation_lang int NULL,
idnation_lang2 int NULL,
idnation_langvis int NULL,
idreg_docenti int NULL,
idsede int NULL,
idsessione int NULL,
idtitolokind int NULL,
immatoltreauth char(1) NULL,
modaccesso nvarchar(max) NULL,
modaccesso_en nvarchar(max) NULL,
obbformativi nvarchar(max) NULL,
obbformativi_en nvarchar(max) NULL,
preimmatoltreauth char(1) NULL,
progesamamm nvarchar(max) NULL,
prospoccupaz nvarchar(max) NULL,
provafinaledesc nvarchar(max) NULL,
regolamentotax nvarchar(max) NULL,
regolamentotaxurl varchar(512) NULL,
startiscrizioni datetime NULL,
stopiscrizioni datetime NULL,
title varchar(1024) NULL,
title_en varchar(1024) NULL,
utenzasost int NULL,
website varchar(512) NULL,
 CONSTRAINT xpkdidprog PRIMARY KEY (iddidprog,
idcorsostudio
)
)
END
GO

-- VERIFICA STRUTTURA didprog --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprog' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprog int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'iddidprog' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idcorsostudio' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idcorsostudio int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('didprog') and col.name = 'idcorsostudio' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [didprog] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD aa varchar(9) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN aa varchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'annosolare' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD annosolare int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN annosolare int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'attribdebiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD attribdebiti nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN attribdebiti nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'ciclo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD ciclo int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN ciclo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codice varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codice varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'codicemiur' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD codicemiur varchar(50) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN codicemiur varchar(50) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'dataconsmaxiscr' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD dataconsmaxiscr date NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN dataconsmaxiscr date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'freqobbl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD freqobbl char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN freqobbl char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idareadidattica' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idareadidattica int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idareadidattica int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idconvenzione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idconvenzione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idconvenzione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprognumchiusokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprognumchiusokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprognumchiusokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iddidprogsuddannokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iddidprogsuddannokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iddidprogsuddannokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'iderogazkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD iderogazkind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN iderogazkind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idgraduatoria int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idgraduatoria int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_lang2' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_lang2 int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_lang2 int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idnation_langvis' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idnation_langvis int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idnation_langvis int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idreg_docenti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idreg_docenti int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idreg_docenti int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsede' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsede int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsede int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idsessione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idsessione int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idsessione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'idtitolokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD idtitolokind int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN idtitolokind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'immatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD immatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN immatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'modaccesso_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD modaccesso_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN modaccesso_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'obbformativi_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD obbformativi_en nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN obbformativi_en nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'preimmatoltreauth' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD preimmatoltreauth char(1) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN preimmatoltreauth char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'progesamamm' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD progesamamm nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN progesamamm nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'prospoccupaz' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD prospoccupaz nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN prospoccupaz nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'provafinaledesc' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD provafinaledesc nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN provafinaledesc nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotax nvarchar(max) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotax nvarchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'regolamentotaxurl' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD regolamentotaxurl varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN regolamentotaxurl varchar(512) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'startiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD startiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN startiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'stopiscrizioni' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD stopiscrizioni datetime NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN stopiscrizioni datetime NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'title_en' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD title_en varchar(1024) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN title_en varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'utenzasost' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD utenzasost int NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN utenzasost int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'didprog' and C.name = 'website' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [didprog] ADD website varchar(512) NULL 
END
ELSE
	ALTER TABLE [didprog] ALTER COLUMN website varchar(512) NULL
GO

-- VERIFICA DI didprog IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprog'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprog','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprog','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(9)','ASSISTENZA','aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','annosolare','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','attribdebiti','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','ciclo','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(50)','ASSISTENZA','codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(50)','ASSISTENZA','codicemiur','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','date','ASSISTENZA','dataconsmaxiscr','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','char(1)','ASSISTENZA','freqobbl','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idareadidattica','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idconvenzione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','iddidprognumchiusokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','iddidprogsuddannokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','iderogazkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idgraduatoria','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idnation_lang','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idnation_lang2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idnation_langvis','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idsessione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','idtitolokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','char(1)','ASSISTENZA','immatoltreauth','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','modaccesso','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','modaccesso_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','obbformativi','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','obbformativi_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','char(1)','ASSISTENZA','preimmatoltreauth','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','progesamamm','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','prospoccupaz','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','provafinaledesc','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','nvarchar(max)','ASSISTENZA','regolamentotax','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(512)','ASSISTENZA','regolamentotaxurl','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','datetime','ASSISTENZA','startiscrizioni','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','datetime','ASSISTENZA','stopiscrizioni','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(1024)','ASSISTENZA','title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','int','ASSISTENZA','utenzasost','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprog','varchar(512)','ASSISTENZA','website','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprog IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprog')
UPDATE customobject set isreal = 'S' where objectname = 'didprog'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprog', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'didprog')
UPDATE [tabledescr] SET description = '2.4.1 Didattica programmata per un anno accademico di un corso di studio',idapplication = null,isdbo = 'N',lt = {ts '2018-07-17 17:28:39.120'},lu = 'assistenza',title = 'Didattica programmata per un anno accademico di un corso di studio' WHERE tablename = 'didprog'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('didprog','2.4.1 Didattica programmata per un anno accademico di un corso di studio',null,'N',{ts '2018-07-17 17:28:39.120'},'assistenza','Didattica programmata per un anno accademico di un corso di studio')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno accademico',kind = 'S',lt = {ts '2019-02-22 17:48:16.807'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(9)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','didprog','9',null,null,'Anno accademico','S',{ts '2019-02-22 17:48:16.807'},'assistenza','N','varchar(9)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'annosolare' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Anno solare',kind = 'S',lt = {ts '2019-02-22 17:48:16.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'annosolare' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('annosolare','didprog','4',null,null,'Anno solare','S',{ts '2019-02-22 17:48:16.810'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'attribdebiti' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Attribuzione eventuali crediti o debiti formativi',kind = 'S',lt = {ts '2019-02-22 17:48:16.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'attribdebiti' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('attribdebiti','didprog','0',null,null,'Attribuzione eventuali crediti o debiti formativi','S',{ts '2019-02-22 17:48:16.810'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ciclo' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-22 17:29:28.343'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'ciclo' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ciclo','didprog','4',null,null,null,'S',{ts '2019-02-22 17:29:28.343'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-22 17:29:28.343'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','didprog','50',null,null,null,'S',{ts '2019-02-22 17:29:28.343'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codicemiur' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice MIUR',kind = 'S',lt = {ts '2019-02-22 17:48:16.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codicemiur' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codicemiur','didprog','50',null,null,'Codice MIUR','S',{ts '2019-02-22 17:48:16.810'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'dataconsmaxiscr' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data del conseguimento massima per il quale è consentito iscriversi',kind = 'S',lt = {ts '2020-09-29 18:09:05.570'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'dataconsmaxiscr' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('dataconsmaxiscr','didprog','3',null,null,'Data del conseguimento massima per il quale è consentito iscriversi','S',{ts '2020-09-29 18:09:05.570'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'freqobbl' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Frequenza Obbligatoria',kind = 'S',lt = {ts '2019-02-22 17:48:16.810'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'freqobbl' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('freqobbl','didprog','1',null,null,'Frequenza Obbligatoria','S',{ts '2019-02-22 17:48:16.810'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idareadidattica' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Area didattica',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idareadidattica' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idareadidattica','didprog','4',null,null,'Area didattica','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idconvenzione' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Convenzione',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idconvenzione' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idconvenzione','didprog','4',null,null,'Convenzione','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcorsostudio' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Corso di studi',kind = 'S',lt = {ts '2019-09-23 16:06:30.787'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcorsostudio' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcorsostudio','didprog','4',null,null,'Corso di studi','S',{ts '2019-09-23 16:06:30.787'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprog' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Identificativo',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprog' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprog','didprog','4',null,null,'Identificativo','S',{ts '2019-02-22 17:48:16.813'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprognumchiusokind' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero chiuso',kind = 'S',lt = {ts '2019-03-13 18:24:59.253'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprognumchiusokind' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprognumchiusokind','didprog','4',null,null,'Numero chiuso','S',{ts '2019-03-13 18:24:59.253'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iddidprogsuddannokind' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Suddivisioni dell''anno',kind = 'S',lt = {ts '2019-03-13 18:24:59.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iddidprogsuddannokind' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iddidprogsuddannokind','didprog','4',null,null,'Suddivisioni dell''anno','S',{ts '2019-03-13 18:24:59.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iderogazkind' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Erogazione',kind = 'S',lt = {ts '2019-03-13 18:24:59.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iderogazkind' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iderogazkind','didprog','4',null,null,'Erogazione','S',{ts '2019-03-13 18:24:59.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoria' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Graduatoria',kind = 'S',lt = {ts '2019-03-13 18:24:59.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoria' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoria','didprog','4',null,null,'Graduatoria','S',{ts '2019-03-13 18:24:59.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_lang' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua di erogazione',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_lang' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_lang','didprog','4',null,null,'Lingua di erogazione','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_lang2' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Seconda lingua di erogazione',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_lang2' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_lang2','didprog','4',null,null,'Seconda lingua di erogazione','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idnation_langvis' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Lingua di visualizzazione',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idnation_langvis' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idnation_langvis','didprog','4',null,null,'Lingua di visualizzazione','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idreg_docenti' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Referente',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idreg_docenti' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idreg_docenti','didprog','4',null,null,'Referente','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsede' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sede',kind = 'S',lt = {ts '2019-08-30 15:47:58.267'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsede' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsede','didprog','4',null,null,'Sede','S',{ts '2019-08-30 15:47:58.267'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idsessione' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Sessione',kind = 'S',lt = {ts '2019-03-13 18:24:59.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idsessione' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idsessione','didprog','4',null,null,'Sessione','S',{ts '2019-03-13 18:24:59.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idtitolokind' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Titolo di studi',kind = 'S',lt = {ts '2019-03-13 18:24:59.257'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idtitolokind' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idtitolokind','didprog','4',null,null,'Titolo di studi','S',{ts '2019-03-13 18:24:59.257'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'immatoltreauth' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti l''immatricolazione oltre i termini',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'immatoltreauth' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('immatoltreauth','didprog','1',null,null,'Consenti l''immatricolazione oltre i termini','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'modaccesso' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Modalità e conoscenze per l''accesso',kind = 'S',lt = {ts '2020-09-29 18:09:05.570'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'modaccesso' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('modaccesso','didprog','0',null,null,'Modalità e conoscenze per l''accesso','S',{ts '2020-09-29 18:09:05.570'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'modaccesso_en' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Modalità e conoscenze per l''accesso (EN)',kind = 'S',lt = {ts '2020-09-29 18:09:05.570'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'modaccesso_en' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('modaccesso_en','didprog','0',null,null,'Modalità e conoscenze per l''accesso (EN)','S',{ts '2020-09-29 18:09:05.570'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obbformativi' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Obiettivi formativi',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'obbformativi' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obbformativi','didprog','0',null,null,'Obiettivi formativi','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'obbformativi_en' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Obiettivi formativi (EN)',kind = 'S',lt = {ts '2019-02-22 17:48:16.813'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'obbformativi_en' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('obbformativi_en','didprog','0',null,null,'Obiettivi formativi (EN)','S',{ts '2019-02-22 17:48:16.813'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'preimmatoltreauth' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Consenti la pre-immatricolazione oltre i termini',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'preimmatoltreauth' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('preimmatoltreauth','didprog','1',null,null,'Consenti la pre-immatricolazione oltre i termini','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'progesamamm' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Programma dell''esame di ammissione',kind = 'S',lt = {ts '2019-02-26 12:50:07.557'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'progesamamm' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('progesamamm','didprog','0',null,null,'Programma dell''esame di ammissione','S',{ts '2019-02-26 12:50:07.557'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'prospoccupaz' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Prospettive occupazionali',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'prospoccupaz' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('prospoccupaz','didprog','0',null,null,'Prospettive occupazionali','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'provafinaledesc' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Caratteristiche della prova finale',kind = 'S',lt = {ts '2019-02-26 12:50:42.157'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'provafinaledesc' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('provafinaledesc','didprog','0',null,null,'Caratteristiche della prova finale','S',{ts '2019-02-26 12:50:42.157'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'regolamentotax' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '0',col_precision = null,col_scale = null,description = 'Regolamento delle tasse',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(max)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'regolamentotax' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('regolamentotax','didprog','0',null,null,'Regolamento delle tasse','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','nvarchar(max)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'regolamentotaxurl' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Indirizzo WEB del regolamento delle tasse',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'regolamentotaxurl' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('regolamentotaxurl','didprog','512',null,null,'Indirizzo WEB del regolamento delle tasse','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','varchar(512)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startiscrizioni' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio delle iscrizioni',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startiscrizioni' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startiscrizioni','didprog','8',null,null,'Data di inizio delle iscrizioni','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stopiscrizioni' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine delle Iscrizioni',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stopiscrizioni' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stopiscrizioni','didprog','8',null,null,'Data di fine delle Iscrizioni','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','didprog','1024',null,null,'Denominazione','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title_en' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '1024',col_precision = null,col_scale = null,description = 'Denominazione (EN)',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(1024)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title_en' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title_en','didprog','1024',null,null,'Denominazione (EN)','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','varchar(1024)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'utenzasost' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Utenza sostenibile',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'utenzasost' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('utenzasost','didprog','4',null,null,'Utenza sostenibile','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'website' AND tablename = 'didprog')
UPDATE [coldescr] SET col_len = '512',col_precision = null,col_scale = null,description = 'Sito WEB del corso',kind = 'S',lt = {ts '2019-02-22 17:56:09.647'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(512)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'website' AND tablename = 'didprog'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('website','didprog','512',null,null,'Sito WEB del corso','S',{ts '2019-02-22 17:56:09.647'},'assistenza','N','varchar(512)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

