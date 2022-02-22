
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


-- CREAZIONE VISTA flowchartview
IF EXISTS(select * from sysobjects where id = object_id(N'[flowchartview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flowchartview]
GO


CREATE VIEW flowchartview
(
	idflowchart,
	paridflowchart,
	codeflowchart,
	printingorder,
	ayear,
	title,
	nlevel,
	leveldescr,
	fax,
	phone,
	address,
	idcity,
	city,
	cap,
	location,
	ct, cu, lt, lu
)
AS SELECT
	F.idflowchart,
	F.paridflowchart,
	F.codeflowchart,
	F.printingorder,
	F.ayear,
	F.title,
	F.nlevel,
	L.description,
	F.fax,
	F.phone,
	F.address,
	F.idcity,
	G.title,
	F.cap,
	F.location,
	F.ct, F.cu, F.lt, F.lu
FROM flowchart F
JOIN flowchartlevel L
	ON L.ayear = F.ayear
	AND L.nlevel = F.nlevel
LEFT OUTER JOIN geo_city G
	ON G.idcity = F.idcity


GO

-- VERIFICA DI flowchartview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'flowchartview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'address')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '100',field = 'address',col_precision = '' where tablename = 'flowchartview' AND field = 'address'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','flowchartview','N','','100','address','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '4',field = 'ayear',col_precision = '' where tablename = 'flowchartview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','flowchartview','N','','4','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'cap')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '20',field = 'cap',col_precision = '' where tablename = 'flowchartview' AND field = 'cap'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','flowchartview','N','','20','cap','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'city')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(65)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '65',field = 'city',col_precision = '' where tablename = 'flowchartview' AND field = 'city'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(65)','N','flowchartview','N','','65','city','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'codeflowchart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '50',field = 'codeflowchart',col_precision = '' where tablename = 'flowchartview' AND field = 'codeflowchart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','flowchartview','S','','50','codeflowchart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'flowchartview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','flowchartview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'flowchartview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','flowchartview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'fax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(75)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '75',field = 'fax',col_precision = '' where tablename = 'flowchartview' AND field = 'fax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(75)','N','flowchartview','N','','75','fax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'idcity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '4',field = 'idcity',col_precision = '' where tablename = 'flowchartview' AND field = 'idcity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','flowchartview','N','','4','idcity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'idflowchart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(34)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '34',field = 'idflowchart',col_precision = '' where tablename = 'flowchartview' AND field = 'idflowchart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(34)','N','flowchartview','S','','34','idflowchart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'leveldescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '50',field = 'leveldescr',col_precision = '' where tablename = 'flowchartview' AND field = 'leveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','flowchartview','S','','50','leveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'location')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'flowchartview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','flowchartview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'flowchartview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','flowchartview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'flowchartview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','flowchartview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'nlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '4',field = 'nlevel',col_precision = '' where tablename = 'flowchartview' AND field = 'nlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','flowchartview','S','','4','nlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'paridflowchart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(34)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '34',field = 'paridflowchart',col_precision = '' where tablename = 'flowchartview' AND field = 'paridflowchart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(34)','N','flowchartview','S','','34','paridflowchart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'phone')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(55)',iskey = 'N',tablename = 'flowchartview',denynull = 'N',format = '',col_len = '55',field = 'phone',col_precision = '' where tablename = 'flowchartview' AND field = 'phone'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(55)','N','flowchartview','N','','55','phone','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'printingorder')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '50',field = 'printingorder',col_precision = '' where tablename = 'flowchartview' AND field = 'printingorder'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','flowchartview','S','','50','printingorder','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'flowchartview' AND field = 'title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'flowchartview',denynull = 'S',format = '',col_len = '150',field = 'title',col_precision = '' where tablename = 'flowchartview' AND field = 'title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','flowchartview','S','','150','title','')
GO

-- VERIFICA DI flowchartview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'flowchartview')
UPDATE customobject set isreal = 'N' where objectname = 'flowchartview'
ELSE
INSERT INTO customobject (objectname, isreal) values('flowchartview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

