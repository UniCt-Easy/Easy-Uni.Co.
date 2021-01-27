
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA patrimonyview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[patrimonyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[patrimonyview]
GO



CREATE VIEW [dbo].[patrimonyview]
(
	idpatrimony,
	ayear,
	patpart,
	codepatrimony,
	nlevel,
	leveldescr,
	paridpatrimony,
	printingorder,
	title,
	active,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
	SELECT patrimony.idpatrimony, 
		patrimony.ayear, 
		patrimony.patpart,
		patrimony.codepatrimony, 
		patrimony.nlevel,
		patrimonylevel.description, 
		patrimony.paridpatrimony,
		patrimony.printingorder,
		patrimony.title,
		patrimony.active,
		patrimony.cu, 
		patrimony.ct, patrimony.lu, 
		patrimony.lt
	FROM patrimony 
	(NOLOCK) INNER JOIN patrimonylevel
	ON patrimonylevel.ayear = patrimony.ayear
	AND patrimonylevel.nlevel = patrimony.nlevel 








GO

-- VERIFICA DI patrimonyview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'patrimonyview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'active')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'patrimonyview',denynull = 'N',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'patrimonyview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','patrimonyview','N','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'ayear')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'patrimonyview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','patrimonyview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'codepatrimony')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '50',field = 'codepatrimony',col_precision = '' where tablename = 'patrimonyview' AND field = 'codepatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','patrimonyview','S','','50','codepatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'patrimonyview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','patrimonyview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'patrimonyview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','patrimonyview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'idpatrimony')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '31',field = 'idpatrimony',col_precision = '' where tablename = 'patrimonyview' AND field = 'idpatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(31)','N','patrimonyview','S','','31','idpatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'patrimonyview' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','patrimonyview','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'patrimonyview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','patrimonyview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'patrimonyview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','patrimonyview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'nlevel')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'patrimonyview' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','patrimonyview','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'paridpatrimony')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '31',field = 'paridpatrimony',col_precision = '' where tablename = 'patrimonyview' AND field = 'paridpatrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(31)','N','patrimonyview','S','','31','paridpatrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'patpart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '1',field = 'patpart',col_precision = '' where tablename = 'patrimonyview' AND field = 'patpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','patrimonyview','S','','1','patpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'printingorder')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'patrimonyview' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','patrimonyview','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'patrimonyview' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'patrimonyview',denynull = 'S',format = '',col_len = '200',field = 'title',col_precision = '' where tablename = 'patrimonyview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(200)','N','patrimonyview','S','','200','title','')
GO

-- VERIFICA DI patrimonyview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'patrimonyview')
UPDATE customobject set isreal = 'N' where objectname = 'patrimonyview'
ELSE
INSERT INTO customobject (objectname, isreal) values('patrimonyview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

