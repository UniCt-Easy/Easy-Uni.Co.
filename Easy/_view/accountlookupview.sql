
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


-- CREAZIONE VISTA accountlookupview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountlookupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accountlookupview]
GO



--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE  VIEW [dbo].[accountlookupview] 
	(
	oldidacc,
	oldayear,
	oldcodeacc,
	oldtitle,
	newidacc,
	newayear,
	newcodeacc,
	newtitle,
	cu, 
	ct, 
	lu, 
	lt
	)
	AS SELECT
	accountlookup.oldidacc,
	oldconto.ayear,
	oldconto.codeacc,
	oldconto.title,
	accountlookup.newidacc,
	newconto.ayear,
	newconto.codeacc,
	newconto.title,
	accountlookup.cu,
	accountlookup.ct,
	accountlookup.lu,
	accountlookup.lt
	FROM accountlookup (NOLOCK)
	JOIN account oldconto (NOLOCK)
	ON oldconto.idacc = accountlookup.oldidacc
	JOIN account newconto (NOLOCK)
	ON newconto.idacc = accountlookup.newidacc






GO

-- VERIFICA DI accountlookupview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accountlookupview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'accountlookupview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','accountlookupview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'accountlookupview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','accountlookupview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'accountlookupview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','accountlookupview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accountlookupview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'accountlookupview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','accountlookupview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'newayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '2',field = 'newayear',col_precision = '' where tablename = 'accountlookupview' AND field = 'newayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','accountlookupview','S','','2','newayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'newcodeacc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '50',field = 'newcodeacc',col_precision = '' where tablename = 'accountlookupview' AND field = 'newcodeacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','accountlookupview','S','','50','newcodeacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'newidacc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '38',field = 'newidacc',col_precision = '' where tablename = 'accountlookupview' AND field = 'newidacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(38)','N','accountlookupview','S','','38','newidacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'newtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '150',field = 'newtitle',col_precision = '' where tablename = 'accountlookupview' AND field = 'newtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','accountlookupview','S','','150','newtitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'oldayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '2',field = 'oldayear',col_precision = '' where tablename = 'accountlookupview' AND field = 'oldayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','accountlookupview','S','','2','oldayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'oldcodeacc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '50',field = 'oldcodeacc',col_precision = '' where tablename = 'accountlookupview' AND field = 'oldcodeacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','accountlookupview','S','','50','oldcodeacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'oldidacc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '38',field = 'oldidacc',col_precision = '' where tablename = 'accountlookupview' AND field = 'oldidacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(38)','N','accountlookupview','S','','38','oldidacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountlookupview' AND field = 'oldtitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accountlookupview',denynull = 'S',format = '',col_len = '150',field = 'oldtitle',col_precision = '' where tablename = 'accountlookupview' AND field = 'oldtitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','accountlookupview','S','','150','oldtitle','')
GO

-- VERIFICA DI accountlookupview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accountlookupview')
UPDATE customobject set isreal = 'N' where objectname = 'accountlookupview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accountlookupview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

