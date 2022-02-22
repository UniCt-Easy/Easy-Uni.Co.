
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


IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'codelen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [inventorysortinglevel] ALTER COLUMN codelen tinyint NOT NULL 
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorysortinglevel' and C.name = 'codelen' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [locationlevel] ALTER COLUMN codelen tinyint NOT NULL 
END
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'inventorysortinglevel' AND field = 'codelen')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-25 09:18:45.187'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-25 09:18:45.187'} WHERE tablename = 'inventorysortinglevel' AND field = 'codelen'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('inventorysortinglevel','codelen','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-25 09:18:45.187'},'''NINO''','NINO',{ts '2007-10-25 09:18:45.187'})
GO

IF exists(SELECT * FROM [columntypes] WHERE tablename = 'locationlevel' AND field = 'codelen')
UPDATE [columntypes] SET iskey = 'N',sqltype = 'tinyint',col_len = '1',col_precision = null,col_scale = null,systemtype = 'System.Byte',sqldeclaration = 'tinyint',allownull = 'N',defaultvalue = '',format = null,denynull = 'S',lastmodtimestamp = {ts '2007-10-25 09:18:36.627'},lastmoduser = '''NINO''',createuser = 'NINO',createtimestamp = {ts '2007-10-25 09:18:36.627'} WHERE tablename = 'locationlevel' AND field = 'codelen'
ELSE
INSERT INTO [columntypes] (tablename,field,iskey,sqltype,col_len,col_precision,col_scale,systemtype,sqldeclaration,allownull,defaultvalue,format,denynull,lastmodtimestamp,lastmoduser,createuser,createtimestamp) VALUES ('locationlevel','codelen','N','tinyint','1',null,null,'System.Byte','tinyint','N','',null,'S',{ts '2007-10-25 09:18:36.627'},'''NINO''','NINO',{ts '2007-10-25 09:18:36.627'})
GO
