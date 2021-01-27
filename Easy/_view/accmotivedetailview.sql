
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


-- CREAZIONE VISTA accmotivedetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotivedetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotivedetailview]
GO

CREATE VIEW [dbo].[accmotivedetailview]
(
	idaccmotive,
	idacc,
	cu,
	ct,
	lu,
	lt,
	codeacc,
	account,
	ayear,
	idaccountkind,
	flagregistry,
	flagupb
	
)
	AS SELECT
	accmotivedetail.idaccmotive,
	accmotivedetail.idacc,
	accmotivedetail.cu,
	accmotivedetail.ct,
	accmotivedetail.lu,
	accmotivedetail.lt,
	account.codeacc,
	account.title,
	account.ayear,
	account.idaccountkind,
	account.flagregistry,
	account.flagupb
	FROM accmotivedetail (NOLOCK)
		JOIN account  on account.idacc= accmotivedetail.idacc
	





GO

-- VERIFICA DI accmotivedetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accmotivedetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'account')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '150',field = 'account',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'account'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(150)','N','accmotivedetailview','S','','150','account','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'ayear')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','smallint','','N','System.Int16','smallint','N','accmotivedetailview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'codeacc')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '50',field = 'codeacc',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'codeacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','accmotivedetailview','S','','50','codeacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotivedetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotivedetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'flagregistry')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'N',format = '',col_len = '1',field = 'flagregistry',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'flagregistry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accmotivedetailview','N','','1','flagregistry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'flagupb')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'N',format = '',col_len = '1',field = 'flagupb',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'flagupb'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','char','','S','System.String','char(1)','N','accmotivedetailview','N','','1','flagupb','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'idacc')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '38',field = 'idacc',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'idacc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(38)','N','accmotivedetailview','S','','38','idacc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'idaccmotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '36',field = 'idaccmotive',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'idaccmotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(36)','N','accmotivedetailview','S','','36','idaccmotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'idaccountkind')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'N',format = '',col_len = '20',field = 'idaccountkind',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'idaccountkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(20)','N','accmotivedetailview','N','','20','idaccountkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotivedetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotivedetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotivedetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'accmotivedetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotivedetailview','S','','64','lu','')
GO

-- VERIFICA DI accmotivedetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accmotivedetailview')
UPDATE customobject set isreal = 'N' where objectname = 'accmotivedetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accmotivedetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

