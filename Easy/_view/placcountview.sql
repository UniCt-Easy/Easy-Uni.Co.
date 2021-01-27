
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


-- CREAZIONE VISTA placcountview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[placcountview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[placcountview]
GO


CREATE  VIEW [dbo].[placcountview] 
(
	idplaccount,
	ayear,
	placcpart,
	codeplaccount,
	nlevel,
	leveldescr,
	paridplaccount,
	printingorder,
	title,
	active,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
	SELECT  placcount.idplaccount, 
		placcount.ayear, 
		placcount.placcpart,
		placcount.codeplaccount, 
		placcount.nlevel,
		placcountlevel.description, 
		placcount.paridplaccount,
		placcount.printingorder,
		placcount.title,
		placcount.active, 
		placcount.cu, 
		placcount.ct, 
		placcount.lu, 
		placcount.lt
	FROM placcount 
	(NOLOCK) INNER JOIN placcountlevel
	ON placcountlevel.ayear = placcount.ayear
	AND placcountlevel.nlevel = placcount.nlevel 




GO

-- VERIFICA DI placcountview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'placcountview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'active')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '1',field = 'active',col_precision = '' where tablename = 'placcountview' AND field = 'active'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','placcountview','S','','1','active','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'ayear')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'placcountview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','placcountview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'codeplaccount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '50',field = 'codeplaccount',col_precision = '' where tablename = 'placcountview' AND field = 'codeplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','placcountview','S','','50','codeplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'placcountview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','placcountview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'placcountview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','placcountview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'idplaccount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''NINO''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '31',field = 'idplaccount',col_precision = '' where tablename = 'placcountview' AND field = 'idplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''NINO''','','varchar','','N','System.String','varchar(31)','N','placcountview','S','','31','idplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'placcountview' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','placcountview','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'placcountview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','placcountview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'placcountview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','placcountview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'nlevel')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'placcountview' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','placcountview','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'paridplaccount')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '31',field = 'paridplaccount',col_precision = '' where tablename = 'placcountview' AND field = 'paridplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(31)','N','placcountview','S','','31','paridplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'placcpart')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '1',field = 'placcpart',col_precision = '' where tablename = 'placcountview' AND field = 'placcpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','placcountview','S','','1','placcpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'printingorder')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'placcountview' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','placcountview','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountview' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'placcountview',denynull = 'S',format = '',col_len = '200',field = 'title',col_precision = '' where tablename = 'placcountview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(200)','N','placcountview','S','','200','title','')
GO

-- VERIFICA DI placcountview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'placcountview')
UPDATE customobject set isreal = 'N' where objectname = 'placcountview'
ELSE
INSERT INTO customobject (objectname, isreal) values('placcountview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

