/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿-- CREAZIONE TABELLA sortinglink --
IF NOT EXISTS(select * from sysobjects where id = object_id(N'[sortinglink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [sortinglink] (
idchild int NOT NULL,
nlevel tinyint NOT NULL,
idparent int NOT NULL,
 CONSTRAINT xpksortinglink PRIMARY KEY (idchild,
nlevel
)
)
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x2sortinglink' and id=object_id('sortinglink'))
BEGIN
     CREATE NONCLUSTERED INDEX x2sortinglink
     ON sortinglink
     (idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x2sortinglink
     ON sortinglink
     (idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

IF EXISTS (SELECT * FROM sysindexes where name='x3sortinglink' and id=object_id('sortinglink'))
BEGIN
     CREATE NONCLUSTERED INDEX x3sortinglink
     ON sortinglink
     (
     idchild, idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 , DROP_EXISTING ON [PRIMARY]
END
ELSE
BEGIN
     CREATE NONCLUSTERED INDEX x3sortinglink
     ON sortinglink
     (
     idchild, idparent     
)
 WITH PAD_INDEX, FILLFACTOR =90 ON [PRIMARY]
END
GO

-- VERIFICA STRUTTURA sortinglink --
IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglink' and C.name = 'idchild' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglink] ADD idchild int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sortinglink') and col.name = 'idchild' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sortinglink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglink' and C.name = 'nlevel' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglink] ADD nlevel tinyint NOT NULL DEFAULT ''
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sortinglink') and col.name = 'nlevel' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sortinglink] drop constraint '+@vincolo)
END
GO

IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortinglink' and C.name = 'idparent' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [sortinglink] ADD idparent int NOT NULL DEFAULT 0
	declare @vincolo varchar(100)
	select @vincolo = object_name(const.constid) from syscolumns col join sysconstraints const on const.id = col.id and const.colid = col.colid where col.id = object_id('sortinglink') and col.name = 'idparent' and objectproperty(const.constid, 'IsDefaultCnst')=1
	exec ('ALTER TABLE [sortinglink] drop constraint '+@vincolo)
END
ELSE
	ALTER TABLE [sortinglink] ALTER COLUMN idparent int NOT NULL
GO

-- VERIFICA DI sortinglink IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'sortinglink'
IF exists(SELECT * FROM columntypes WHERE tablename = 'sortinglink' AND field = 'idchild')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'S',tablename = 'sortinglink',denynull = 'S',format = '',col_len = '4',field = 'idchild',col_precision = '' where tablename = 'sortinglink' AND field = 'idchild'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','S','sortinglink','S','','4','idchild','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortinglink' AND field = 'nlevel')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'S',tablename = 'sortinglink',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'sortinglink' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','tinyint','','N','System.Byte','tinyint','S','sortinglink','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'sortinglink' AND field = 'idparent')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''NINO''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'sortinglink',denynull = 'S',format = '',col_len = '4',field = 'idparent',col_precision = '' where tablename = 'sortinglink' AND field = 'idparent'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','sortinglink','S','','4','idparent','')
GO

-- VERIFICA DI sortinglink IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'sortinglink')
UPDATE customobject set isreal = 'S' where objectname = 'sortinglink'
ELSE
INSERT INTO customobject (objectname, isreal) values('sortinglink', 'S')
GO
-- FINE GENERAZIONE SCRIPT --

	