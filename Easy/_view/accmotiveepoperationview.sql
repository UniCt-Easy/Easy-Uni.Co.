
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


-- CREAZIONE VISTA accmotiveepoperationview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accmotiveepoperationview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accmotiveepoperationview]
GO


CREATE  VIEW [dbo].[accmotiveepoperationview]
(
	idaccmotive,
	codemotive,
	motive,
	idepoperation,
	epoperation,
	cu,
	ct,
	lu,
	lt
)
AS
SELECT
accmotiveepoperation.idaccmotive,
accmotive.codemotive,
accmotive.title,
accmotiveepoperation.idepoperation,
epoperation.title,
accmotiveepoperation.cu,
accmotiveepoperation.ct,
accmotiveepoperation.lu,
accmotiveepoperation.lt
FROM accmotiveepoperation
JOIN accmotive
ON accmotive.idaccmotive = accmotiveepoperation.idaccmotive
JOIN epoperation
ON epoperation.idepoperation = accmotiveepoperation.idepoperation





GO

-- VERIFICA DI accmotiveepoperationview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'accmotiveepoperationview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'codemotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '50',field = 'codemotive',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'codemotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(50)','N','accmotiveepoperationview','S','','50','codemotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'ct')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotiveepoperationview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'cu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotiveepoperationview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'epoperation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'N',format = '',col_len = '50',field = 'epoperation',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'epoperation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','S','System.String','varchar(50)','N','accmotiveepoperationview','N','','50','epoperation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'idaccmotive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '36',field = 'idaccmotive',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'idaccmotive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(36)','N','accmotiveepoperationview','S','','36','idaccmotive','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'idepoperation')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '20',field = 'idepoperation',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'idepoperation'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(20)','N','accmotiveepoperationview','S','','20','idepoperation','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'lt')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','datetime','','N','System.DateTime','datetime','N','accmotiveepoperationview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'lu')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(64)','N','accmotiveepoperationview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'accmotiveepoperationview' AND field = 'motive')
UPDATE columntypes set createuser = 'VISTA',lastmoduser = '''SA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'accmotiveepoperationview',denynull = 'S',format = '',col_len = '150',field = 'motive',col_precision = '' where tablename = 'accmotiveepoperationview' AND field = 'motive'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('VISTA','''SA''','','varchar','','N','System.String','varchar(150)','N','accmotiveepoperationview','S','','150','motive','')
GO

-- VERIFICA DI accmotiveepoperationview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'accmotiveepoperationview')
UPDATE customobject set isreal = 'N' where objectname = 'accmotiveepoperationview'
ELSE
INSERT INTO customobject (objectname, isreal) values('accmotiveepoperationview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

