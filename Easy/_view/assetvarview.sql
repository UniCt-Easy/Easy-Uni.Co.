
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


-- CREAZIONE VISTA assetvarview
IF EXISTS(select * from sysobjects where id = object_id(N'[assetvarview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [assetvarview]
GO




CREATE VIEW assetvarview
(
	idassetvar,
	yvar,
	nvar,
	idinventoryagency,
	codeinventoryagency,
	inventoryagency,
	description,
	enactment,
	flag,
	variationkind,
	nenactment,
	enactmentdate,
	adate,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	assetvar.idassetvar,
	assetvar.yvar,
	assetvar.nvar,
	assetvar.idinventoryagency,
	inventoryagency.codeinventoryagency,
	inventoryagency.description,
	assetvar.description,
	assetvar.enactment,
	assetvar.flag,
	CASE 
		WHEN flag & 1 <> 0 THEN 'N'
		ELSE 'I'
	END,
	assetvar.nenactment,
	assetvar.enactmentdate,
	assetvar.adate,
	assetvar.cu,
	assetvar.ct,
	assetvar.lu,
	assetvar.lt
FROM assetvar
JOIN inventoryagency
	ON inventoryagency.idinventoryagency = assetvar.idinventoryagency







GO

-- VERIFICA DI assetvarview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assetvarview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'adate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '4',field = 'adate',col_precision = '' where tablename = 'assetvarview' AND field = 'adate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','assetvarview','S','','4','adate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'codeinventoryagency')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '20',field = 'codeinventoryagency',col_precision = '' where tablename = 'assetvarview' AND field = 'codeinventoryagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(20)','N','assetvarview','S','','20','codeinventoryagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'ct')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'assetvarview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetvarview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'cu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'assetvarview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetvarview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'description')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'assetvarview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetvarview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'enactment')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetvarview',denynull = 'N',format = '',col_len = '150',field = 'enactment',col_precision = '' where tablename = 'assetvarview' AND field = 'enactment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(150)','N','assetvarview','N','','150','enactment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'enactmentdate')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'assetvarview',denynull = 'N',format = '',col_len = '4',field = 'enactmentdate',col_precision = '' where tablename = 'assetvarview' AND field = 'enactmentdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','assetvarview','N','','4','enactmentdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'flag')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'N',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '1',field = 'flag',col_precision = '' where tablename = 'assetvarview' AND field = 'flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','tinyint','','N','System.Byte','tinyint','N','assetvarview','S','','1','flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'idassetvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '4',field = 'idassetvar',col_precision = '' where tablename = 'assetvarview' AND field = 'idassetvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvarview','S','','4','idassetvar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'idinventoryagency')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '4',field = 'idinventoryagency',col_precision = '' where tablename = 'assetvarview' AND field = 'idinventoryagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvarview','S','','4','idinventoryagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'inventoryagency')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '150',field = 'inventoryagency',col_precision = '' where tablename = 'assetvarview' AND field = 'inventoryagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(150)','N','assetvarview','S','','150','inventoryagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'lt')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'assetvarview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','datetime','','N','System.DateTime','datetime','N','assetvarview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'lu')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'assetvarview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(64)','N','assetvarview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'nenactment')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(15)',iskey = 'N',tablename = 'assetvarview',denynull = 'N',format = '',col_len = '15',field = 'nenactment',col_precision = '' where tablename = 'assetvarview' AND field = 'nenactment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','S','System.String','varchar(15)','N','assetvarview','N','','15','nenactment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'nvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '4',field = 'nvar',col_precision = '' where tablename = 'assetvarview' AND field = 'nvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','int','','N','System.Int32','int','N','assetvarview','S','','4','nvar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'variationkind')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(1)',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '1',field = 'variationkind',col_precision = '' where tablename = 'assetvarview' AND field = 'variationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','varchar','','N','System.String','varchar(1)','N','assetvarview','S','','1','variationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'assetvarview' AND field = 'yvar')
UPDATE columntypes set createuser = 'NINO',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'assetvarview',denynull = 'S',format = '',col_len = '2',field = 'yvar',col_precision = '' where tablename = 'assetvarview' AND field = 'yvar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''SARA''','','smallint','','N','System.Int16','smallint','N','assetvarview','S','','2','yvar','')
GO

-- VERIFICA DI assetvarview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assetvarview')
UPDATE customobject set isreal = 'N' where objectname = 'assetvarview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assetvarview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

