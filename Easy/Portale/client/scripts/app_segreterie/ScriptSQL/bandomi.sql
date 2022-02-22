
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


-- CREAZIONE TABELLA bandomi --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[dbo].[bandomi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[bandomi] (
idbandomi int NOT NULL,
aa nvarchar(9) NULL,
cfminimi decimal(9,2) NULL,
codice varchar(50) NOT NULL,
ct datetime NOT NULL,
cu varchar(64) NOT NULL,
datariferimentorequisiti date NULL,
durata int NULL,
idaccordoscambiomi int NOT NULL,
idassicurazione int NULL,
idbandomobilitaintkind int NOT NULL,
idduratakind int NULL,
idgraduatoria int NULL,
idprogrammami int NOT NULL,
idresidence int NULL,
idstruttura int NOT NULL,
iscrittonellanno char(1) NULL,
lt datetime NOT NULL,
lu varchar(64) NOT NULL,
maxpreferenze int NULL,
mediaminima decimal(9,2) NULL,
nessundebito char(1) NULL,
numeroesamiminimo int NULL,
startcandidature datetime NOT NULL,
startgraduatoria datetime NOT NULL,
startpermanenza date NULL,
startpresentazione datetime NOT NULL,
stopcadidature datetime NOT NULL,
stopgraduatoria datetime NOT NULL,
stoppermanenza date NULL,
stoppresentazione datetime NOT NULL,
testodomanda varchar(max) NULL,
title varchar(max) NOT NULL,
titolodomanda varchar(max) NULL,
 CONSTRAINT xpkbandomi PRIMARY KEY (idbandomi
)
)
END
GO

-- VERIFICA STRUTTURA bandomi --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idbandomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idbandomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idbandomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'aa' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD aa nvarchar(9) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN aa nvarchar(9) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'cfminimi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD cfminimi decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN cfminimi decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'codice' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD codice varchar(50) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'codice' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN codice varchar(50) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'ct' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD ct datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'ct' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN ct datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'cu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD cu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'cu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN cu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'datariferimentorequisiti' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD datariferimentorequisiti date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN datariferimentorequisiti date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'durata' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD durata int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN durata int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idaccordoscambiomi' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idaccordoscambiomi int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idaccordoscambiomi' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idaccordoscambiomi int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idassicurazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idassicurazione int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idassicurazione int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idbandomobilitaintkind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idbandomobilitaintkind int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idbandomobilitaintkind' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idbandomobilitaintkind int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idduratakind' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idduratakind int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idduratakind int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idgraduatoria int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idgraduatoria int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idprogrammami' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idprogrammami int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idprogrammami' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idprogrammami int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idresidence' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idresidence int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idresidence int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'idstruttura' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD idstruttura int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'idstruttura' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN idstruttura int NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'iscrittonellanno' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD iscrittonellanno char(1) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN iscrittonellanno char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'lt' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD lt datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'lt' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN lt datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'lu' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD lu varchar(64) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'lu' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN lu varchar(64) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'maxpreferenze' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD maxpreferenze int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN maxpreferenze int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'mediaminima' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD mediaminima decimal(9,2) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN mediaminima decimal(9,2) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'nessundebito' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD nessundebito char(1) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN nessundebito char(1) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'numeroesamiminimo' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD numeroesamiminimo int NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN numeroesamiminimo int NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startcandidature' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startcandidature datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startcandidature' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startcandidature datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startgraduatoria datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startgraduatoria datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startpermanenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startpermanenza date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startpermanenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'startpresentazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD startpresentazione datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'startpresentazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN startpresentazione datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stopcadidature' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stopcadidature datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stopcadidature' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stopcadidature datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stopgraduatoria' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stopgraduatoria datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stopgraduatoria' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stopgraduatoria datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stoppermanenza' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stoppermanenza date NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stoppermanenza date NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'stoppresentazione' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD stoppresentazione datetime NOT NULL DEFAULT 01/01/1000
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'stoppresentazione' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN stoppresentazione datetime NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'testodomanda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD testodomanda varchar(max) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN testodomanda varchar(max) NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'title' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD title varchar(max) NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('bandomi') and col.name = 'title' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [bandomi] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN title varchar(max) NOT NULL
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'bandomi' and C.name = 'titolodomanda' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [bandomi] ADD titolodomanda varchar(max) NULL 
END
ELSE
	ALTER TABLE [bandomi] ALTER COLUMN titolodomanda varchar(max) NULL
GO

-- VERIFICA DI bandomi IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'bandomi'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','int','assistenza','idbandomi','4','S','int','System.Int32','','','''assistenza''','','S')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','nvarchar(9)','assistenza','aa','9','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','decimal(9,2)','assistenza','cfminimi','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','varchar(50)','assistenza','codice','50','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','date','assistenza','datariferimentorequisiti','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','durata','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','int','assistenza','idaccordoscambiomi','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','idassicurazione','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','int','assistenza','idbandomobilitaintkind','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','idduratakind','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','idgraduatoria','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','int','assistenza','idprogrammami','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','idresidence','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','int','assistenza','idstruttura','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','char(1)','assistenza','iscrittonellanno','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','maxpreferenze','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','decimal(9,2)','assistenza','mediaminima','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','char(1)','assistenza','nessundebito','1','N','char','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','int','assistenza','numeroesamiminimo','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','startcandidature','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','startgraduatoria','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','date','assistenza','startpermanenza','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','startpresentazione','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','stopcadidature','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','stopgraduatoria','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','date','assistenza','stoppermanenza','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','datetime','assistenza','stoppresentazione','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','varchar(max)','assistenza','testodomanda','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','bandomi','varchar(max)','assistenza','title','-1','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','bandomi','varchar(max)','assistenza','titolodomanda','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI bandomi IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'bandomi')
UPDATE customobject set isreal = 'S' where objectname = 'bandomi'
ELSE
INSERT INTO customobject (objectname, isreal) values('bandomi', 'S')
GO
-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'bandomi')
UPDATE [tabledescr] SET description = '2.5.15 Bandi per la mobilità internazionale',idapplication = null,isdbo = 'N',lt = {ts '2018-07-27 11:07:11.753'},lu = 'assistenza',title = 'Bandi per la mobilità internazionale' WHERE tablename = 'bandomi'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('bandomi','2.5.15 Bandi per la mobilità internazionale',null,'N',{ts '2018-07-27 11:07:11.753'},'assistenza','Bandi per la mobilità internazionale')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER coldescr --
IF exists(SELECT * FROM [coldescr] WHERE colname = 'aa' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '9',col_precision = null,col_scale = null,description = 'Anno Accademico',kind = 'S',lt = {ts '2021-06-28 11:38:20.610'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'nvarchar(9)',sql_type = 'nvarchar',system_type = 'System.String' WHERE colname = 'aa' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('aa','bandomi','9',null,null,'Anno Accademico','S',{ts '2021-06-28 11:38:20.610'},'assistenza','N','nvarchar(9)','nvarchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cfminimi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Crediti formativi minimi per l''accesso',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'cfminimi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cfminimi','bandomi','5','9','2','Crediti formativi minimi per l''accesso','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'codice' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '50',col_precision = null,col_scale = null,description = 'Codice identificativo',kind = 'S',lt = {ts '2020-09-07 12:19:11.053'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(50)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'codice' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('codice','bandomi','50',null,null,'Codice identificativo','S',{ts '2020-09-07 12:19:11.053'},'assistenza','N','varchar(50)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'ct' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'ct' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('ct','bandomi','8',null,null,null,'S',{ts '2019-02-26 11:24:37.080'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'cu' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.080'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'cu' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('cu','bandomi','64',null,null,null,'S',{ts '2019-02-26 11:24:37.080'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'datariferimentorequisiti' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di riferimento per il calcolo dei requisiti',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'datariferimentorequisiti' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('datariferimentorequisiti','bandomi','3',null,null,'Data di riferimento per il calcolo dei requisiti','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'durata' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:07:13.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'durata' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('durata','bandomi','4',null,null,null,'S',{ts '2018-07-27 11:07:13.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idaccordoscambiomi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Accordo di scambio per la mobilità internazionale',kind = 'S',lt = {ts '2019-11-28 16:49:48.917'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idaccordoscambiomi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idaccordoscambiomi','bandomi','4',null,null,'Accordo di scambio per la mobilità internazionale','S',{ts '2019-11-28 16:49:48.917'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idassicurazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Assicurazione',kind = 'S',lt = {ts '2019-02-26 12:42:34.307'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idassicurazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idassicurazione','bandomi','4',null,null,'Assicurazione','S',{ts '2019-02-26 12:42:34.307'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomi' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2018-07-27 11:07:13.613'},lu = 'assistenza',primarykey = 'S',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomi' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomi','bandomi','4',null,null,null,'S',{ts '2018-07-27 11:07:13.613'},'assistenza','S','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipologia',kind = 'S',lt = {ts '2019-02-26 11:24:35.843'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idbandomobilitaintkind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idbandomobilitaintkind','bandomi','4',null,null,'Tipologia','S',{ts '2019-02-26 11:24:35.843'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idduratakind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Durata',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idduratakind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idduratakind','bandomi','4',null,null,'Durata','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Graduatoria',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idgraduatoria','bandomi','4',null,null,'Graduatoria','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idprogrammami' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Programma per la mobilità di riferimento',kind = 'S',lt = {ts '2020-09-07 17:29:00.220'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idprogrammami' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idprogrammami','bandomi','4',null,null,'Programma per la mobilità di riferimento','S',{ts '2020-09-07 17:29:00.220'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idresidence' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Residenza',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idresidence' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idresidence','bandomi','4',null,null,'Residenza','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'idstruttura' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Struttura di riferimento',kind = 'S',lt = {ts '2021-06-28 11:38:20.613'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'idstruttura' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('idstruttura','bandomi','4',null,null,'Struttura di riferimento','S',{ts '2021-06-28 11:38:20.613'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iduratakind' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Tipo di durata',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'iduratakind' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iduratakind','bandomi','4',null,null,'Tipo di durata','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'iscrittonellanno' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Solo per iscritti nell''anno',kind = 'S',lt = {ts '2019-02-26 12:42:34.310'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'iscrittonellanno' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('iscrittonellanno','bandomi','1',null,null,'Solo per iscritti nell''anno','S',{ts '2019-02-26 12:42:34.310'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lt' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'lt' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lt','bandomi','8',null,null,null,'S',{ts '2019-02-26 11:24:37.083'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'lu' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '64',col_precision = null,col_scale = null,description = null,kind = 'S',lt = {ts '2019-02-26 11:24:37.083'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(64)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'lu' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('lu','bandomi','64',null,null,null,'S',{ts '2019-02-26 11:24:37.083'},'assistenza','N','varchar(64)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'maxpreferenze' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero massimo di preferenze',kind = 'S',lt = {ts '2019-02-26 12:49:31.170'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'maxpreferenze' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('maxpreferenze','bandomi','4',null,null,'Numero massimo di preferenze','S',{ts '2019-02-26 12:49:31.170'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'mediaminima' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '5',col_precision = '9',col_scale = '2',description = 'Mendia minima',kind = 'S',lt = {ts '2019-02-26 12:49:31.170'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'decimal(9,2)',sql_type = 'decimal',system_type = 'System.Decimal' WHERE colname = 'mediaminima' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('mediaminima','bandomi','5','9','2','Mendia minima','S',{ts '2019-02-26 12:49:31.170'},'assistenza','N','decimal(9,2)','decimal','System.Decimal')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'nessundebito' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '1',col_precision = null,col_scale = null,description = 'Nessun debito formativo',kind = 'S',lt = {ts '2019-02-26 12:49:31.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'char(1)',sql_type = 'char',system_type = 'System.String' WHERE colname = 'nessundebito' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('nessundebito','bandomi','1',null,null,'Nessun debito formativo','S',{ts '2019-02-26 12:49:31.173'},'assistenza','N','char(1)','char','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'numeroesamiminimo' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '4',col_precision = null,col_scale = null,description = 'Numero minimo di esami',kind = 'S',lt = {ts '2019-02-26 12:49:31.173'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'int',sql_type = 'int',system_type = 'System.Int32' WHERE colname = 'numeroesamiminimo' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('numeroesamiminimo','bandomi','4',null,null,'Numero minimo di esami','S',{ts '2019-02-26 12:49:31.173'},'assistenza','N','int','int','System.Int32')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startcandidature' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio delle candidature',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startcandidature' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startcandidature','bandomi','8',null,null,'Data di inizio delle candidature','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio della graduatoria',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startgraduatoria','bandomi','8',null,null,'Data di inizio della graduatoria','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startpermanenza' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di inizio del periodo all''estero',kind = 'S',lt = {ts '2019-02-26 12:49:31.177'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'startpermanenza' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startpermanenza','bandomi','3',null,null,'Data di inizio del periodo all''estero','S',{ts '2019-02-26 12:49:31.177'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'startpresentazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di inizio delle presentazioni dei Learning Agreement',kind = 'S',lt = {ts '2019-02-26 12:49:31.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'startpresentazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('startpresentazione','bandomi','8',null,null,'Data di inizio delle presentazioni dei Learning Agreement','S',{ts '2019-02-26 12:49:31.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stopcadidature' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine di presentazione delle candidature',kind = 'S',lt = {ts '2019-02-26 12:49:31.180'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stopcadidature' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stopcadidature','bandomi','8',null,null,'Data di fine di presentazione delle candidature','S',{ts '2019-02-26 12:49:31.180'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stopgraduatoria' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine della graduatoria',kind = 'S',lt = {ts '2019-02-26 12:49:31.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stopgraduatoria' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stopgraduatoria','bandomi','8',null,null,'Data di fine della graduatoria','S',{ts '2019-02-26 12:49:31.183'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stoppermanenza' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '3',col_precision = null,col_scale = null,description = 'Data di fine di permanenza all''estero',kind = 'S',lt = {ts '2019-02-26 12:49:31.183'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'date',sql_type = 'date',system_type = 'System.DateTime' WHERE colname = 'stoppermanenza' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stoppermanenza','bandomi','3',null,null,'Data di fine di permanenza all''estero','S',{ts '2019-02-26 12:49:31.183'},'assistenza','N','date','date','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'stoppresentazione' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '8',col_precision = null,col_scale = null,description = 'Data di fine delle presentazioni dei Learning Agreement',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'datetime',sql_type = 'datetime',system_type = 'System.DateTime' WHERE colname = 'stoppresentazione' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('stoppresentazione','bandomi','8',null,null,'Data di fine delle presentazioni dei Learning Agreement','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','datetime','datetime','System.DateTime')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'testodomanda' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Testo della intestazione della domanda di ammissione',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'testodomanda' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('testodomanda','bandomi','-1',null,null,'Testo della intestazione della domanda di ammissione','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'title' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo del bando',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'title' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('title','bandomi','-1',null,null,'Titolo del bando','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

IF exists(SELECT * FROM [coldescr] WHERE colname = 'titolodomanda' AND tablename = 'bandomi')
UPDATE [coldescr] SET col_len = '-1',col_precision = null,col_scale = null,description = 'Titolo della domanda di ammissione',kind = 'S',lt = {ts '2019-02-26 12:49:31.187'},lu = 'assistenza',primarykey = 'N',sql_declaration = 'varchar(max)',sql_type = 'varchar',system_type = 'System.String' WHERE colname = 'titolodomanda' AND tablename = 'bandomi'
ELSE
INSERT INTO [coldescr] (colname,tablename,col_len,col_precision,col_scale,description,kind,lt,lu,primarykey,sql_declaration,sql_type,system_type) VALUES ('titolodomanda','bandomi','-1',null,null,'Titolo della domanda di ammissione','S',{ts '2019-02-26 12:49:31.187'},'assistenza','N','varchar(max)','varchar','System.String')
GO

-- FINE GENERAZIONE SCRIPT --

