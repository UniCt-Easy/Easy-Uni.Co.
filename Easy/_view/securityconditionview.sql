
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


-- CREAZIONE VISTA securityconditionview
IF EXISTS(select * from sysobjects where id = object_id(N'[securityconditionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [securityconditionview]
GO


CREATE VIEW securityconditionview
(
	idsecuritycondition,
	idrestrictedfunction,
	restrictedfunction,
	tablename,
	operation,
	idcustomgroup,
	customgroup,
	groupname,
	allowcondition,
	denycondition,
	defaultisdeny,
	ct, cu, lt, lu
)
AS SELECT
	SC.idsecuritycondition,
	SC.idrestrictedfunction,
	RF.description,
	SC.tablename,
	SC.operation,
	SC.idcustomgroup,
	CG.description,
	CG.groupname,
	SC.allowcondition,
	SC.denycondition,
	SC.defaultisdeny,
	SC.ct, SC.cu, SC.lt, SC.lu
FROM securitycondition SC
JOIN restrictedfunction RF
	ON RF.idrestrictedfunction = SC.idrestrictedfunction
JOIN customgroup CG
	ON CG.idcustomgroup = SC.idcustomgroup


GO

-- VERIFICA DI securityconditionview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'securityconditionview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'allowcondition')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'securityconditionview',denynull = 'N',format = '',col_len = '16',field = 'allowcondition',col_precision = '' where tablename = 'securityconditionview' AND field = 'allowcondition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','text','','S','System.String','text','N','securityconditionview','N','','16','allowcondition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'securityconditionview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','securityconditionview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'securityconditionview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','securityconditionview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'customgroup')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(200)',iskey = 'N',tablename = 'securityconditionview',denynull = 'N',format = '',col_len = '200',field = 'customgroup',col_precision = '' where tablename = 'securityconditionview' AND field = 'customgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(200)','N','securityconditionview','N','','200','customgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'defaultisdeny')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '1',field = 'defaultisdeny',col_precision = '' where tablename = 'securityconditionview' AND field = 'defaultisdeny'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','char','','N','System.String','char(1)','N','securityconditionview','S','','1','defaultisdeny','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'denycondition')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'text',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'text',iskey = 'N',tablename = 'securityconditionview',denynull = 'N',format = '',col_len = '16',field = 'denycondition',col_precision = '' where tablename = 'securityconditionview' AND field = 'denycondition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','text','','S','System.String','text','N','securityconditionview','N','','16','denycondition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'groupname')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(80)',iskey = 'N',tablename = 'securityconditionview',denynull = 'N',format = '',col_len = '80',field = 'groupname',col_precision = '' where tablename = 'securityconditionview' AND field = 'groupname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(80)','N','securityconditionview','N','','80','groupname','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'idcustomgroup')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '50',field = 'idcustomgroup',col_precision = '' where tablename = 'securityconditionview' AND field = 'idcustomgroup'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','securityconditionview','S','','50','idcustomgroup','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'idrestrictedfunction')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '4',field = 'idrestrictedfunction',col_precision = '' where tablename = 'securityconditionview' AND field = 'idrestrictedfunction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','securityconditionview','S','','4','idrestrictedfunction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'idsecuritycondition')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '4',field = 'idsecuritycondition',col_precision = '' where tablename = 'securityconditionview' AND field = 'idsecuritycondition'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','securityconditionview','S','','4','idsecuritycondition','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'securityconditionview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','securityconditionview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'securityconditionview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','securityconditionview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'operation')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '1',field = 'operation',col_precision = '' where tablename = 'securityconditionview' AND field = 'operation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','char','','N','System.String','char(1)','N','securityconditionview','S','','1','operation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'restrictedfunction')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '100',field = 'restrictedfunction',col_precision = '' where tablename = 'securityconditionview' AND field = 'restrictedfunction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(100)','N','securityconditionview','S','','100','restrictedfunction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'securityconditionview' AND field = 'tablename')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'securityconditionview',denynull = 'S',format = '',col_len = '50',field = 'tablename',col_precision = '' where tablename = 'securityconditionview' AND field = 'tablename'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(50)','N','securityconditionview','S','','50','tablename','')
GO

-- VERIFICA DI securityconditionview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'securityconditionview')
UPDATE customobject set isreal = 'N' where objectname = 'securityconditionview'
ELSE
INSERT INTO customobject (objectname, isreal) values('securityconditionview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

