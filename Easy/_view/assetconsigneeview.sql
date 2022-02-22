
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


-- CREAZIONE VISTA assetconsigneeview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetconsigneeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetconsigneeview]
GO



CREATE VIEW [assetconsigneeview]
AS
SELECT     
	assetconsignee.idinventoryagency, 
	inventoryagency.description AS agency, 
	assetconsignee.start, 
	assetconsignee.qualification, 
	assetconsignee.title, 
	assetconsignee.lu, 
	assetconsignee.lt
FROM assetconsignee
JOIN inventoryagency
	ON assetconsignee.idinventoryagency = inventoryagency.idinventoryagency



GO

-- VERIFICA DI assetconsigneeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetconsigneeview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'agency')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'S',format = '',col_len = '150',field = 'agency',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'agency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetconsigneeview','S','','150','agency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'idinventoryagency')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'S',format = '',col_len = '4',field = 'idinventoryagency',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'idinventoryagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetconsigneeview','S','','4','idinventoryagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'N',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','S','System.DateTime','datetime','N','assetconsigneeview','N','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'N',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(64)','N','assetconsigneeview','N','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'qualification')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'N',format = '',col_len = '50',field = 'qualification',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'qualification'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(50)','N','assetconsigneeview','N','','50','qualification','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'start')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'S',format = '',col_len = '4',field = 'start',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','assetconsigneeview','S','','4','start','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetconsigneeview' AND field = 'title')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetconsigneeview',denynull = 'N',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'assetconsigneeview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(150)','N','assetconsigneeview','N','','150','title','')
GO

-- VERIFICA DI assetconsigneeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetconsigneeview')
UPDATE customobject set isreal = 'N' where objectname = 'assetconsigneeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetconsigneeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

