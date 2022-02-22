
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


-- CREAZIONE VISTA placcountlookupview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[placcountlookupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[placcountlookupview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE  VIEW [dbo].[placcountlookupview] 
	(
	oldidplaccount,
	oldayear,
	oldcodeplaccount,
	oldtitle,
	oldplaccpart,
	newidplaccount,
	newayear,
	newcodeplaccount,
	newtitle,
	newplaccpart,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	placcountlookup.oldidplaccount,
	oldcontoecon.ayear,
	oldcontoecon.codeplaccount,
	oldcontoecon.title,
	oldcontoecon.placcpart,
	placcountlookup.newidplaccount,
	newcontoecon.ayear,
	newcontoecon.codeplaccount,
	newcontoecon.title,
	newcontoecon.placcpart,
	placcountlookup.cu,
	placcountlookup.ct,
	placcountlookup.lu,
	placcountlookup.lt
	FROM placcountlookup (NOLOCK)
	JOIN placcount oldcontoecon (NOLOCK)
	ON oldcontoecon.idplaccount = placcountlookup.oldidplaccount
	JOIN placcount newcontoecon (NOLOCK)
	ON newcontoecon.idplaccount = placcountlookup.newidplaccount




GO

-- VERIFICA DI placcountlookupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'placcountlookupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'placcountlookupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','placcountlookupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'placcountlookupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','placcountlookupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'placcountlookupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','placcountlookupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'placcountlookupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','placcountlookupview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'newayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '2',field = 'newayear',col_precision = '' where tablename = 'placcountlookupview' AND field = 'newayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','placcountlookupview','S','','2','newayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'newcodeplaccount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '50',field = 'newcodeplaccount',col_precision = '' where tablename = 'placcountlookupview' AND field = 'newcodeplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','placcountlookupview','S','','50','newcodeplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'newidplaccount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '31',field = 'newidplaccount',col_precision = '' where tablename = 'placcountlookupview' AND field = 'newidplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(31)','N','placcountlookupview','S','','31','newidplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'newplaccpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '1',field = 'newplaccpart',col_precision = '' where tablename = 'placcountlookupview' AND field = 'newplaccpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','placcountlookupview','S','','1','newplaccpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'newtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '200',field = 'newtitle',col_precision = '' where tablename = 'placcountlookupview' AND field = 'newtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','placcountlookupview','S','','200','newtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'oldayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '2',field = 'oldayear',col_precision = '' where tablename = 'placcountlookupview' AND field = 'oldayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','placcountlookupview','S','','2','oldayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'oldcodeplaccount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '50',field = 'oldcodeplaccount',col_precision = '' where tablename = 'placcountlookupview' AND field = 'oldcodeplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','placcountlookupview','S','','50','oldcodeplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'oldidplaccount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(31)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '31',field = 'oldidplaccount',col_precision = '' where tablename = 'placcountlookupview' AND field = 'oldidplaccount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(31)','N','placcountlookupview','S','','31','oldidplaccount','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'oldplaccpart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '1',field = 'oldplaccpart',col_precision = '' where tablename = 'placcountlookupview' AND field = 'oldplaccpart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','placcountlookupview','S','','1','oldplaccpart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'placcountlookupview' AND field = 'oldtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'placcountlookupview',denynull = 'S',format = '',col_len = '200',field = 'oldtitle',col_precision = '' where tablename = 'placcountlookupview' AND field = 'oldtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(200)','N','placcountlookupview','S','','200','oldtitle','')
GO

-- VERIFICA DI placcountlookupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'placcountlookupview')
UPDATE customobject set isreal = 'N' where objectname = 'placcountlookupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('placcountlookupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

