
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


-- CREAZIONE TABELLA contrattokind --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[contrattokind]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[contrattokind] (
idcontrattokind int NOT NULL,
active char(1) NOT NULL,
assegnoaggiuntivo char(1) NULL,
costolordoannuo decimal(9,2) NULL,
costolordoannuooneri decimal(9,2) NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
description varchar(256) NULL,
elementoperequativo char(1) NULL,
indennitadiateneo char(1) NULL,
indennitadiposizione char(1) NULL,
indvacancacontrattuale char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
oremaxcompitididatempoparziale int NULL,
oremaxcompitididatempopieno int NULL,
oremaxdidatempoparziale int NULL,
oremaxdidatempopieno int NULL,
oremaxgg int NULL,
oremaxtempoparziale int NULL,
oremaxtempopieno int NULL,
oremincompitididatempoparziale int NULL,
oremincompitididatempopieno int NULL,
oremindidatempoparziale int NULL,
oremindidatempopieno int NULL,
oremintempoparziale int NULL,
oremintempopieno int NULL,
orestraordinariemax int NULL,
parttime char(1) NULL,
puntiorganico decimal(9,2) NULL,
scatto char(1) NULL,
siglaesportazione varchar(10) NULL,
siglaimportazione varchar(1024) NULL,
sortcode int NOT NULL,
tempdef char(1) NULL,
title varchar(50) NOT NULL,
totaletredicesima char(1) NULL,
tredicesimaindennitaintegrativaspeciale char(1) NULL,
 CONSTRAINT xpkcontrattokind PRIMARY KEY (idcontrattokind
)
)
END
GO

-- VERIFICA STRUTTURA contrattokind --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'idcontrattokind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD idcontrattokind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'idcontrattokind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'active' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD active char(1) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'active' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN active char(1) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'assegnoaggiuntivo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD assegnoaggiuntivo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN assegnoaggiuntivo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuo decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuo decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'costolordoannuooneri' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD costolordoannuooneri decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN costolordoannuooneri decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'description' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD description varchar(256) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN description varchar(256) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'elementoperequativo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD elementoperequativo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN elementoperequativo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiateneo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiateneo char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiateneo char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indennitadiposizione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indennitadiposizione char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indennitadiposizione char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'indvacancacontrattuale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD indvacancacontrattuale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN indvacancacontrattuale char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxcompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxcompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxcompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxdidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxdidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxdidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxgg' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxgg int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxgg int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremaxtempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremaxtempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremaxtempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremincompitididatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremincompitididatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremincompitididatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremindidatempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremindidatempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremindidatempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempoparziale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempoparziale int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempoparziale int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'oremintempopieno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD oremintempopieno int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN oremintempopieno int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'orestraordinariemax' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD orestraordinariemax int NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN orestraordinariemax int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'parttime' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD parttime char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN parttime char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'puntiorganico' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD puntiorganico decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN puntiorganico decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'scatto' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD scatto char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN scatto char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'siglaesportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD siglaesportazione varchar(10) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN siglaesportazione varchar(10) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'siglaimportazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD siglaimportazione varchar(1024) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN siglaimportazione varchar(1024) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'sortcode' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD sortcode int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'sortcode' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN sortcode int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tempdef' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tempdef char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tempdef char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD title varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('contrattokind') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [contrattokind] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN title varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'totaletredicesima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD totaletredicesima char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN totaletredicesima char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'contrattokind' and C.name = 'tredicesimaindennitaintegrativaspeciale' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [contrattokind] ADD tredicesimaindennitaintegrativaspeciale char(1) NULL 
END
ELSE
	ALTER TABLE [contrattokind] ALTER COLUMN tredicesimaindennitaintegrativaspeciale char(1) NULL
GO

-- VERIFICA DI contrattokind IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'contrattokind'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','char(1)','ASSISTENZA','active','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','assegnoaggiuntivo','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','decimal(9,2)','ASSISTENZA','costolordoannuo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','decimal(9,2)','ASSISTENZA','costolordoannuooneri','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','datetime','ASSISTENZA','ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','varchar(64)','ASSISTENZA','cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','varchar(256)','ASSISTENZA','description','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','elementoperequativo','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','indennitadiateneo','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','indennitadiposizione','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','indvacancacontrattuale','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','datetime','ASSISTENZA','lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','varchar(64)','ASSISTENZA','lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxcompitididatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxcompitididatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxdidatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxdidatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxgg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxtempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremaxtempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremincompitididatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremincompitididatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremindidatempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremindidatempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremintempoparziale','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','oremintempopieno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','int','ASSISTENZA','orestraordinariemax','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','parttime','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','decimal(9,2)','Generator','puntiorganico','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','scatto','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','varchar(10)','Generator','siglaesportazione','10','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','varchar(1024)','Generator','siglaimportazione','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','int','ASSISTENZA','sortcode','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','tempdef','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','contrattokind','varchar(50)','ASSISTENZA','title','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','totaletredicesima','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','contrattokind','char(1)','ASSISTENZA','tredicesimaindennitaintegrativaspeciale','1','N','char','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI contrattokind IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'contrattokind')
UPDATE customobject set isreal = 'S' where objectname = 'contrattokind'
ELSE
INSERT INTO customobject (objectname, isreal) values('contrattokind', 'S')
GO

-- GENERAZIONE DATI PER contrattokind --
IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '1')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '68371.12',costolordoannuooneri = '68371.12',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 13:14:30.117'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '8',oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1',scatto = null,siglaesportazione = 'PO',siglaimportazione = 'Professori Ordinari',sortcode = '1',tempdef = 'S',title = 'Professore di I fascia ordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '1'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('1','S',null,'68371.12','68371.12',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII);',null,null,null,null,{ts '2021-11-10 13:14:30.117'},'ferdinando.giannetti{SEGADM}',null,null,null,null,'8','1228','1720','250','350','90','120',null,null,null,'N','1',null,'PO','Professori Ordinari','1','S','Professore di I fascia ordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '2')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 13:04:36.273'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.7',scatto = null,siglaesportazione = 'PA',siglaimportazione = 'Professori Associati',sortcode = '4',tempdef = 'S',title = 'Professore di II fascia associato confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '2'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('2','S',null,'69','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2021-11-10 13:04:36.273'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','0.7',null,'PA','Professori Associati','4','S','Professore di II fascia associato confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '3')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:18.550'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '13',tempdef = 'N',title = 'Funzionario beni culturali',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '3'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('3','S',null,null,'40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Dirigente o funzionario tecnico-scientifico, scientifico o amministrativo delle amministrazioni preposte alla tutela dei beni culturali;',null,null,null,null,{ts '2020-04-29 18:44:18.550'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,null,null,null,'13','N','Funzionario beni culturali',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '4')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2018-06-11 17:35:00.653'},cu = 'ferdinando',description = 'Studioso o professionista di chiara fama',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-04-29 18:44:26.160'},lu = 'riccardotest',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '12',tempdef = 'N',title = 'Studioso o professionista di chiara fama',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '4'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('4','S',null,null,'40000',{ts '2018-06-11 17:35:00.653'},'ferdinando','Studioso o professionista di chiara fama',null,null,null,null,{ts '2020-04-29 18:44:26.160'},'riccardotest',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S',null,null,null,null,'12','N','Studioso o professionista di chiara fama',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '7')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo indeterminato (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:35:34.217'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '200',oremaxdidatempopieno = '350',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '200',oremincompitididatempopieno = '300',oremindidatempoparziale = '60',oremindidatempopieno = '80',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = 'RU',sortcode = '5',tempdef = 'S',title = 'Ricercatore Universitario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '7'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('7','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo indeterminato (ruolo ad esaurimento)',null,null,null,null,{ts '2020-05-21 10:35:34.217'},'riccardotest{0001}','200','350','200','350',null,'1228','1720','200','300','60','80',null,null,null,'N','0.5',null,'RU','RU','5','S','Ricercatore Universitario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '8')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2018-06-11 11:35:00.653'},cu = 'ferdinando',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:44:02.570'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = null,oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = '60',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = null,sortcode = '7',tempdef = 'N',title = 'Ricercatore a tempo determinato 240/2010 lett. b ',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '8'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('8','S',null,'40','40000',{ts '2018-06-11 11:35:00.653'},'ferdinando','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera b) Legge 240 del 2010. Si tratta di contratti triennali non rinnovabili al termine dei quali è possibile accedere direttamente al ruolo di Professore di II fascia.',null,null,null,null,{ts '2020-05-21 10:44:02.570'},'riccardotest{0001}',null,'350',null,'120',null,null,'1720',null,null,null,'60',null,null,null,'N','0.5',null,'RU',null,'7','N','Ricercatore a tempo determinato 240/2010 lett. b ',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '9')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:15:37.457'},cu = 'riccardotest',description = 'Assistenti universitari (ruolo ad esaurimento)',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2022-01-18 10:45:00.260'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'S',puntiorganico = '0.1',scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '9',tempdef = 'N',title = 'Assistenti universitari',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '9'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('9','S',null,null,'40000',{ts '2020-04-29 18:15:37.457'},'riccardotest','Assistenti universitari (ruolo ad esaurimento)',null,null,null,null,{ts '2022-01-18 10:45:00.260'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'S','0.1',null,null,null,'9','N','Assistenti universitari',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '10')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40',costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:20:27.437'},cu = 'riccardotest',description = 'Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:43:04.853'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = '200',oremaxcompitididatempopieno = '350',oremaxdidatempoparziale = '80',oremaxdidatempopieno = '120',oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = '20',oremindidatempopieno = '30',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.5',scatto = null,siglaesportazione = 'RU',siglaimportazione = null,sortcode = '6',tempdef = 'S',title = 'Ricercatore a tempo determinato 240/2010 lett. a',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '10'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('10','S',null,'40','40000',{ts '2020-04-29 18:20:27.437'},'riccardotest','Ricercatore a tempo determinato di cui all’articolo 24, comma 3, lettera a) Legge 240 del 2010. Si tratta di contratti della durata di 3 anni, rinnovabile per ulteriori due 2 anni.',null,null,null,null,{ts '2020-05-21 10:43:04.853'},'riccardotest{0001}','200','350','80','120',null,'1228','1720',null,null,'20','30',null,null,null,'N','0.5',null,'RU',null,'6','S','Ricercatore a tempo determinato 240/2010 lett. a',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '12')
UPDATE [contrattokind] SET active = 'N',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-04-29 18:40:30.430'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:28:50.070'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1',scatto = null,siglaesportazione = 'PO',siglaimportazione = null,sortcode = '2',tempdef = 'S',title = 'Professore di I fascia straordinario',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '12'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('12','N',null,null,'40000',{ts '2020-04-29 18:40:30.430'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonna 9 (ex livello VIII); Professore straordinario a tempo determinato prevista dall’articolo 1, comma 12 della Legge 230 del 2005.',null,null,null,null,{ts '2020-05-21 10:28:50.070'},'riccardotest{0001}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','1',null,'PO',null,'2','S','Professore di I fascia straordinario',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '13')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '69000',costolordoannuooneri = '69000',ct = {ts '2020-04-29 18:42:56.617'},cu = 'riccardotest',description = 'CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-07 11:39:45.057'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = '1228',oremaxtempopieno = '1720',oremincompitididatempoparziale = '250',oremincompitididatempopieno = '350',oremindidatempoparziale = '90',oremindidatempopieno = '120',oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.7',scatto = null,siglaesportazione = 'PA',siglaimportazione = null,sortcode = '3',tempdef = 'S',title = 'Professore di II fascia associato non confermato',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '13'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('13','S',null,'69000','69000',{ts '2020-04-29 18:42:56.617'},'riccardotest','CCNL 15.03.2001 del comparto Scuola, tabella A, colonne 8 e 6 (ex livello VII ed ex livello VI bis);',null,null,null,null,{ts '2020-10-07 11:39:45.057'},'riccardotest{ADMSEG1}',null,null,null,null,null,'1228','1720','250','350','90','120',null,null,null,'N','0.7',null,'PA',null,'3','S','Professore di II fascia associato non confermato',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '14')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = '40000',costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:32:07.807'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-10-21 15:27:32.890'},lu = 'riccardotest{ADMSEG1}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = '9',oremaxtempoparziale = null,oremaxtempopieno = '1512',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = '250',parttime = 'S',puntiorganico = '0.65',scatto = null,siglaesportazione = 'Dir.',siglaimportazione = 'Dir.',sortcode = '20',tempdef = 'N',title = 'Personale tecnico amministrativo - Dir.',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '14'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('14','S',null,'40000','40000',{ts '2020-05-20 11:32:07.807'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-10-21 15:27:32.890'},'riccardotest{ADMSEG1}',null,null,null,null,'9',null,'1512',null,null,null,null,null,null,'250','S','0.65',null,'Dir.','Dir.','20','N','Personale tecnico amministrativo - Dir.',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '15')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = null,costolordoannuo = null,costolordoannuooneri = '40000',ct = {ts '2020-05-20 11:33:03.170'},cu = 'riccardotest{0001}',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2020-05-21 10:33:16.633'},lu = 'riccardotest{0001}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = '40',oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = null,scatto = null,siglaesportazione = null,siglaimportazione = null,sortcode = '11',tempdef = 'N',title = 'Dottorandi di ricerca',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '15'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('15','S',null,null,'40000',{ts '2020-05-20 11:33:03.170'},'riccardotest{0001}',null,null,null,null,null,{ts '2020-05-21 10:33:16.633'},'riccardotest{0001}',null,'40',null,null,null,null,'1720',null,null,null,null,null,null,null,'N',null,null,null,null,'11','N','Dottorandi di ricerca',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '17')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2022-01-03 12:16:52.687'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.4',scatto = null,siglaesportazione = 'EP',siglaimportazione = 'EP',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - EP',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '17'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('17','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2022-01-03 12:16:52.687'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.4',null,'EP','EP','20',null,'Personale tecnico amministrativo - EP',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '18')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2022-01-03 12:16:34.797'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.3',scatto = null,siglaesportazione = 'D',siglaimportazione = 'D',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - D',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '18'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('18','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2022-01-03 12:16:34.797'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.3',null,'D','D','20',null,'Personale tecnico amministrativo - D',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '19')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 12:54:31.967'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.25',scatto = null,siglaesportazione = 'C',siglaimportazione = 'C',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - C',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '19'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('19','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2021-11-10 12:54:31.967'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.25',null,'C','C','20',null,'Personale tecnico amministrativo - C',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '20')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'S',costolordoannuo = null,costolordoannuooneri = null,ct = {d '2021-10-20'},cu = 'ferdinando',description = null,elementoperequativo = null,indennitadiateneo = null,indennitadiposizione = null,indvacancacontrattuale = null,lt = {ts '2021-11-10 12:56:51.460'},lu = 'ferdinando.giannetti{SEGADM}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = null,oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '0.2',scatto = null,siglaesportazione = 'B',siglaimportazione = 'B',sortcode = '20',tempdef = null,title = 'Personale tecnico amministrativo - B',totaletredicesima = null,tredicesimaindennitaintegrativaspeciale = null WHERE idcontrattokind = '20'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('20','S','S',null,null,{d '2021-10-20'},'ferdinando',null,null,null,null,null,{ts '2021-11-10 12:56:51.460'},'ferdinando.giannetti{SEGADM}',null,null,null,null,null,null,null,null,null,null,null,null,null,null,'N','0.2',null,'B','B','20',null,'Personale tecnico amministrativo - B',null,null)
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '21')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2022-01-24 16:49:29.983'},cu = 'ferdinando.giannetti{DIRGEN}',description = null,elementoperequativo = 'N',indennitadiateneo = 'N',indennitadiposizione = 'N',indvacancacontrattuale = 'N',lt = {ts '2022-01-24 16:49:29.983'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1.5',scatto = 'S',siglaesportazione = 'PC',siglaimportazione = 'PC',sortcode = '0',tempdef = 'N',title = 'Professore a contratto esterno',totaletredicesima = 'S',tredicesimaindennitaintegrativaspeciale = 'N' WHERE idcontrattokind = '21'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('21','S','N',null,null,{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,'N','N','N','N',{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,'1720',null,null,null,null,null,null,null,'N','1.5','S','PC','PC','0','N','Professore a contratto esterno','S','N')
GO


IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '22')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2022-01-24 16:49:29.983'},cu = 'ferdinando.giannetti{DIRGEN}',description = null,elementoperequativo = 'N',indennitadiateneo = 'N',indennitadiposizione = 'N',indvacancacontrattuale = 'N',lt = {ts '2022-01-24 16:49:29.983'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = '1.5',scatto = 'S',siglaesportazione = 'DG',siglaimportazione = 'DG',sortcode = '0',tempdef = 'N',title = 'Direttore generale',totaletredicesima = 'S',tredicesimaindennitaintegrativaspeciale = 'N' WHERE idcontrattokind = '22'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('22','S','N',null,null,{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,'N','N','N','N',{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,'1720',null,null,null,null,null,null,null,'N','1.5','S','DG','DG','0','N','Direttore generale','S','N')
GO

IF exists(SELECT * FROM [contrattokind] WHERE idcontrattokind = '23')
UPDATE [contrattokind] SET active = 'S',assegnoaggiuntivo = 'N',costolordoannuo = null,costolordoannuooneri = null,ct = {ts '2022-01-24 16:49:29.983'},cu = 'ferdinando.giannetti{DIRGEN}',description = null,elementoperequativo = 'N',indennitadiateneo = 'N',indennitadiposizione = 'N',indvacancacontrattuale = 'N',lt = {ts '2022-01-24 16:49:29.983'},lu = 'ferdinando.giannetti{DIRGEN}',oremaxcompitididatempoparziale = null,oremaxcompitididatempopieno = null,oremaxdidatempoparziale = null,oremaxdidatempopieno = null,oremaxgg = null,oremaxtempoparziale = null,oremaxtempopieno = '1720',oremincompitididatempoparziale = null,oremincompitididatempopieno = null,oremindidatempoparziale = null,oremindidatempopieno = null,oremintempoparziale = null,oremintempopieno = null,orestraordinariemax = null,parttime = 'N',puntiorganico = null,scatto = 'S',siglaesportazione = 'LC',siglaimportazione = 'LC',sortcode = '0',tempdef = 'N',title = 'Collaboratore esperto linguistico',totaletredicesima = 'S',tredicesimaindennitaintegrativaspeciale = 'N' WHERE idcontrattokind = '23'
ELSE
INSERT INTO [contrattokind] (idcontrattokind,active,assegnoaggiuntivo,costolordoannuo,costolordoannuooneri,ct,cu,description,elementoperequativo,indennitadiateneo,indennitadiposizione,indvacancacontrattuale,lt,lu,oremaxcompitididatempoparziale,oremaxcompitididatempopieno,oremaxdidatempoparziale,oremaxdidatempopieno,oremaxgg,oremaxtempoparziale,oremaxtempopieno,oremincompitididatempoparziale,oremincompitididatempopieno,oremindidatempoparziale,oremindidatempopieno,oremintempoparziale,oremintempopieno,orestraordinariemax,parttime,puntiorganico,scatto,siglaesportazione,siglaimportazione,sortcode,tempdef,title,totaletredicesima,tredicesimaindennitaintegrativaspeciale) VALUES ('23','S','N',null,null,{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,'N','N','N','N',{ts '2022-01-24 16:49:29.983'},'ferdinando.giannetti{DIRGEN}',null,null,null,null,null,null,'1720',null,null,null,null,null,null,null,'N',null,'S','LC','LC','0','N','Collaboratore esperto linguistico','S','N')
GO-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'contrattokind')
UPDATE [tabledescr] SET description = 'Tipologie di contratto',idapplication = '2',isdbo = 'S',lt = {ts '2021-11-10 11:08:57.020'},lu = 'Generator',title = 'Tipologie di contratto' WHERE tablename = 'contrattokind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('contrattokind','Tipologie di contratto','2','S',{ts '2021-11-10 11:08:57.020'},'Generator','Tipologie di contratto')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'active' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'active' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('active','contrattokind','1',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita assegno aggiuntivo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'assegnoaggiuntivo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('assegnoaggiuntivo','contrattokind','1',null,null,'Abilita assegno aggiuntivo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuo','contrattokind','5','9','2','Costo lordo annuo','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Costo lordo annuo e oneri',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'costolordoannuooneri' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('costolordoannuooneri','contrattokind','5','9','2','Costo lordo annuo e oneri','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'description' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '256',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.740'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(256)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'description' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('description','contrattokind','256',null,null,null,'S',{ts '2018-07-17 16:59:21.740'},'assistenza','N','varchar(256)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita elemento perequativo',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'elementoperequativo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('elementoperequativo','contrattokind','1',null,null,'Abilita elemento perequativo','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-12-04 13:18:56.727'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idcontrattokind' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idcontrattokind','contrattokind','4',null,null,null,'S',{ts '2018-12-04 13:18:56.727'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di ateneo',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiateneo' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiateneo','contrattokind','1',null,null,'Abilita indennità di ateneo','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita indennità di posizione',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indennitadiposizione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indennitadiposizione','contrattokind','1',null,null,'Abilita indennità di posizione','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita ind. vacanca contrattuale',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'indvacancacontrattuale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('indvacancacontrattuale','contrattokind','1',null,null,'Abilita ind. vacanca contrattuale','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','contrattokind','8',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','contrattokind','64',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempoparziale','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxcompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxcompitididatempopieno','contrattokind','4',null,null,'Ore massime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempoparziale','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo parziale','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime per didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:54:19.863'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxdidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxdidatempopieno','contrattokind','4',null,null,'Ore massime per didattica frontale a tempo pieno','S',{ts '2020-05-20 11:54:19.863'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxgg' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore di lavoro al giorno massime',kind = 'S',lt = {ts '2020-06-12 15:47:15.233'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxgg' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxgg','contrattokind','4',null,null,'Ore di lavoro al giorno massime','S',{ts '2020-06-12 15:47:15.233'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempoparziale','contrattokind','4',null,null,'Ore massime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremaxtempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremaxtempopieno','contrattokind','4',null,null,'Ore massime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo parziale',kind = 'S',lt = {ts '2020-05-20 12:57:57.880'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempoparziale','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo parziale','S',{ts '2020-05-20 12:57:57.880'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime per i compiti didattici a tempo pieno',kind = 'S',lt = {ts '2020-05-20 12:57:57.883'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremincompitididatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremincompitididatempopieno','contrattokind','4',null,null,'Ore minime per i compiti didattici a tempo pieno','S',{ts '2020-05-20 12:57:57.883'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo parziale',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempoparziale','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo parziale','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime di didattica frontale a tempo pieno',kind = 'S',lt = {ts '2020-05-20 11:48:33.983'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremindidatempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremindidatempopieno','contrattokind','4',null,null,'Ore minime di didattica frontale a tempo pieno','S',{ts '2020-05-20 11:48:33.983'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo parziale',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempoparziale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempoparziale','contrattokind','4',null,null,'Ore minime a tempo parziale','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore minime a tempo pieno',kind = 'S',lt = {ts '2020-04-29 18:54:48.057'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'oremintempopieno' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('oremintempopieno','contrattokind','4',null,null,'Ore minime a tempo pieno','S',{ts '2020-04-29 18:54:48.057'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Ore massime di straordinario rendicontabili',kind = 'S',lt = {ts '2020-05-21 10:06:18.870'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'orestraordinariemax' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('orestraordinariemax','contrattokind','4',null,null,'Ore massime di straordinario rendicontabili','S',{ts '2020-05-21 10:06:18.870'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'parttime' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita part-time',kind = 'S',lt = {ts '2020-05-21 10:50:04.330'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'parttime' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('parttime','contrattokind','1',null,null,'Abilita part-time','S',{ts '2020-05-21 10:50:04.330'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'puntiorganico' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'puntiorganico' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('puntiorganico','contrattokind','5','9','2','','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'scatto' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita scatti stipendio',kind = 'S',lt = {ts '2020-07-14 15:22:46.597'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'scatto' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('scatto','contrattokind','1',null,null,'Abilita scatti stipendio','S',{ts '2020-07-14 15:22:46.597'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaesportazione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaesportazione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaesportazione','contrattokind','10',null,null,'','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'siglaimportazione' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '10',col_precision = null,col_scale = null,description = '',kind = 'S',lt = {ts '2021-10-21 12:22:02.873'},lu = 'Generator',primarykey = 'N',sql_declaration = 'varchar(10)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'siglaimportazione' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('siglaimportazione','contrattokind','10',null,null,'','S',{ts '2021-10-21 12:22:02.873'},'Generator','N','varchar(10)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'sortcode' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'sortcode' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('sortcode','contrattokind','4',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tempdef' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tempo definito o parziale',kind = 'S',lt = {ts '2020-05-21 12:31:15.367'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tempdef' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tempdef','contrattokind','1',null,null,'Abilita tempo definito o parziale','S',{ts '2020-05-21 12:31:15.367'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-17 16:59:21.743'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','contrattokind','50',null,null,null,'S',{ts '2018-07-17 16:59:21.743'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita totale tredicesima',kind = 'S',lt = {ts '2020-07-14 15:26:20.580'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'totaletredicesima' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('totaletredicesima','contrattokind','1',null,null,'Abilita totale tredicesima','S',{ts '2020-07-14 15:26:20.580'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Abilita tredicesima indennità integrativa speciale',kind = 'S',lt = {ts '2021-02-23 09:01:10.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'tredicesimaindennitaintegrativaspeciale' AND tablename = 'contrattokind'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('tredicesimaindennitaintegrativaspeciale','contrattokind','1',null,null,'Abilita tredicesima indennità integrativa speciale','S',{ts '2021-02-23 09:01:10.173'},'assistenza','N','char(1)','char','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

