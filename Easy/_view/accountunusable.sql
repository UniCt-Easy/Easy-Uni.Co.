
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


-- CREAZIONE VISTA accountunusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountunusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accountunusable]
GO


CREATE VIEW [dbo].[accountunusable]
(
	idacc,
	ayear,
	codeacc,
	paridacc,
	nlevel,
	printingorder,
	title,
	idaccountkind,
	accountkind,
	flagda,
	flagregistry,
	flagupb,
	flagtransitory,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	account.idacc,
	account.ayear,
	account.codeacc,
	account.paridacc,
	account.nlevel,
	account.printingorder,
	account.title,
	account.idaccountkind,
	accountkind.description,
	accountkind.flagda,
	account.flagregistry,
	account.flagupb,
	account.flagtransitory,
	account.cu,
	account.ct,
	account.lu,
	account.lt
	FROM account (NOLOCK)
	JOIN accountlevel (NOLOCK) 
	ON accountlevel.ayear = account.ayear
	AND accountlevel.nlevel = account.nlevel
	LEFT OUTER JOIN accountkind (NOLOCK) 
	on  accountkind.idaccountkind=account.idaccountkind
	WHERE accountlevel.flagusable = 'N'	OR
	(SELECT count(*) FROM account b1
	WHERE b1.paridacc = account.idacc )>0






GO

-- VERIFICA DI accountunusable IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accountunusable'
IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'accountkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '50',field = 'accountkind',col_precision = '' where tablename = 'accountunusable' AND field = 'accountkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','accountunusable','N','','50','accountkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'ayear')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'accountunusable' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','accountunusable','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'codeacc')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '50',field = 'codeacc',col_precision = '' where tablename = 'accountunusable' AND field = 'codeacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','accountunusable','S','','50','codeacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'accountunusable' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accountunusable','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'accountunusable' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accountunusable','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'flagda')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '1',field = 'flagda',col_precision = '' where tablename = 'accountunusable' AND field = 'flagda'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accountunusable','N','','1','flagda','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'flagregistry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '1',field = 'flagregistry',col_precision = '' where tablename = 'accountunusable' AND field = 'flagregistry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accountunusable','N','','1','flagregistry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'flagtransitory')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '1',field = 'flagtransitory',col_precision = '' where tablename = 'accountunusable' AND field = 'flagtransitory'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accountunusable','N','','1','flagtransitory','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'flagupb')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '1',field = 'flagupb',col_precision = '' where tablename = 'accountunusable' AND field = 'flagupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accountunusable','N','','1','flagupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'idacc')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '38',field = 'idacc',col_precision = '' where tablename = 'accountunusable' AND field = 'idacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(38)','N','accountunusable','S','','38','idacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'idaccountkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '20',field = 'idaccountkind',col_precision = '' where tablename = 'accountunusable' AND field = 'idaccountkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(20)','N','accountunusable','N','','20','idaccountkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'accountunusable' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accountunusable','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'accountunusable' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accountunusable','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'nlevel')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '1',field = 'nlevel',col_precision = '' where tablename = 'accountunusable' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','N','System.String','char(1)','N','accountunusable','S','','1','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'paridacc')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'accountunusable',denynull = 'N',format = '',col_len = '38',field = 'paridacc',col_precision = '' where tablename = 'accountunusable' AND field = 'paridacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(38)','N','accountunusable','N','','38','paridacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'printingorder')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'accountunusable' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','accountunusable','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accountunusable' AND field = 'title')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accountunusable',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'accountunusable' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(150)','N','accountunusable','S','','150','title','')
GO

-- VERIFICA DI accountunusable IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accountunusable')
UPDATE customobject set isreal = 'N' where objectname = 'accountunusable'
ELSE
INSERT INTO customobject (objectname, isreal) values('accountunusable', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

