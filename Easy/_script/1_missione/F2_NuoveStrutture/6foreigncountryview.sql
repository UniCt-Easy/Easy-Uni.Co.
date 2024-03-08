
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA foreignallowanceruledetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreignallowanceruledetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[foreignallowanceruledetailview]
GO



CREATE  VIEW DBO.foreignallowanceruledetailview
(
	idforeignallowancerule,
	iddetail,
	idforeigncountry,
	codeforeigncountry,
	foreigncountry,
	start,
	minforeigngroupnumber,
	maxforeigngroupnumber,
	amount,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idforeignallowancerule,
	DET.iddetail,
	F.idforeigncountry,
	FC.codeforeigncountry,
	FC.description,
	F.start,
	DET.minforeigngroupnumber,
	DET.maxforeigngroupnumber,
	DET.amount,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM foreignallowanceruledetail DET
JOIN foreignallowancerule F
	ON F.idforeignallowancerule = DET.idforeignallowancerule
JOIN foreigncountry FC
	ON FC.idforeigncountry = F.idforeigncountry



GO

-- VERIFICA DI foreignallowanceruledetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'foreignallowanceruledetailview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'advancepercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '6',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,6)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '9',field = 'advancepercentage',col_precision = '19' where tablename = 'foreignallowanceruledetailview' AND field = 'advancepercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','N','System.Decimal','decimal(19,6)','N','foreignallowanceruledetailview','S','','9','advancepercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'amount')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'N',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '9',field = 'amount',col_precision = '19' where tablename = 'foreignallowanceruledetailview' AND field = 'amount'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(19,2)','N','foreignallowanceruledetailview','S','','9','amount','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'codeforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '20',field = 'codeforeigncountry',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'codeforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','foreignallowanceruledetailview','S','','20','codeforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreignallowanceruledetailview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','foreignallowanceruledetailview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'foreigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '50',field = 'foreigncountry',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'foreigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','foreignallowanceruledetailview','S','','50','foreigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'iddetail')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'iddetail',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'iddetail'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruledetailview','S','','4','iddetail','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'idforeignallowancerule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idforeignallowancerule',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'idforeignallowancerule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruledetailview','S','','4','idforeignallowancerule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'idforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '4',field = 'idforeigncountry',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'idforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruledetailview','S','','4','idforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreignallowanceruledetailview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','foreignallowanceruledetailview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'maxforeigngroupnumber')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '2',field = 'maxforeigngroupnumber',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'maxforeigngroupnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','foreignallowanceruledetailview','S','','2','maxforeigngroupnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'minforeigngroupnumber')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '2',field = 'minforeigngroupnumber',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'minforeigngroupnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','foreignallowanceruledetailview','S','','2','minforeigngroupnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruledetailview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreignallowanceruledetailview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'foreignallowanceruledetailview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreignallowanceruledetailview','S','','8','start','')
GO

-- VERIFICA DI foreignallowanceruledetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'foreignallowanceruledetailview')
UPDATE customobject set isreal = 'N' where objectname = 'foreignallowanceruledetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('foreignallowanceruledetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA foreignallowanceruleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[foreignallowanceruleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[foreignallowanceruleview]
GO



CREATE  VIEW dbo.foreignallowanceruleview
AS
SELECT     dbo.foreignallowancerule.idforeignallowancerule, dbo.foreignallowancerule.idforeigncountry, 
 dbo.foreigncountry.codeforeigncountry,

	dbo.foreigncountry.description AS foreigncountry, 
                      dbo.foreignallowancerule.start
FROM         dbo.foreignallowancerule INNER JOIN
                      dbo.foreigncountry ON dbo.foreignallowancerule.idforeigncountry = dbo.foreigncountry.idforeigncountry



GO

-- VERIFICA DI foreignallowanceruleview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'foreignallowanceruleview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'codeforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '20',field = 'codeforeigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'codeforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','foreignallowanceruleview','S','','20','codeforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'foreigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '50',field = 'foreigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'foreigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','foreignallowanceruleview','S','','50','foreigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'idforeignallowancerule')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '4',field = 'idforeignallowancerule',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'idforeignallowancerule'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruleview','S','','4','idforeignallowancerule','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'idforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '4',field = 'idforeigncountry',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'idforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','foreignallowanceruleview','S','','4','idforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'foreignallowanceruleview' AND field = 'start')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'foreignallowanceruleview',denynull = 'S',format = '',col_len = '8',field = 'start',col_precision = '' where tablename = 'foreignallowanceruleview' AND field = 'start'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','foreignallowanceruleview','S','','8','start','')
GO

-- VERIFICA DI foreignallowanceruleview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'foreignallowanceruleview')
UPDATE customobject set isreal = 'N' where objectname = 'foreignallowanceruleview'
ELSE
INSERT INTO customobject (objectname, isreal) values('foreignallowanceruleview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

-- CREAZIONE VISTA itinerationlapview
IF EXISTS(select * from sysobjects where id = object_id(N'[itinerationlapview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [itinerationlapview]
GO


CREATE  VIEW itinerationlapview 
(
	yitineration,
	nitineration,
	lapnumber,
	idforeigncountry,
	codeforeigncountry,
	location,
	flagitalian,
	description,
	starttime,
	stoptime,
	days,
	hours,
	idreduction,
	reduction,
	allowance,
	advancepercentage,
	ancereductionpercentage,
	cu, ct, lu, lt
)
AS SELECT
	itinerationlap.yitineration,
	itinerationlap.nitineration,
	itinerationlap.lapnumber,
	itinerationlap.idforeigncountry,
	foreigncountry.codeforeigncountry,
	foreigncountry.description,
	itinerationlap.flagitalian,
	itinerationlap.description,
	itinerationlap.starttime,
	itinerationlap.stoptime,
	itinerationlap.days,
	itinerationlap.hours,
	itinerationlap.idreduction,
	reduction.description,
	itinerationlap.allowance, 
	itinerationlap.advancepercentage, 
	itinerationlap.reductionpercentage,
	itinerationlap.cu, itinerationlap.ct, itinerationlap.lu, itinerationlap.lt
FROM itinerationlap
LEFT OUTER JOIN foreigncountry
ON foreigncountry.idforeigncountry = itinerationlap.idforeigncountry
LEFT OUTER JOIN reduction
ON reduction.idreduction = itinerationlap.idreduction




GO

-- VERIFICA DI itinerationlapview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'itinerationlapview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'advancepercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '9',field = 'advancepercentage',col_precision = '19' where tablename = 'itinerationlapview' AND field = 'advancepercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationlapview','N','','9','advancepercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'allowance')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '9',field = 'allowance',col_precision = '19' where tablename = 'itinerationlapview' AND field = 'allowance'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','itinerationlapview','N','','9','allowance','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'ancereductionpercentage')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '8',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,8)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '9',field = 'ancereductionpercentage',col_precision = '19' where tablename = 'itinerationlapview' AND field = 'ancereductionpercentage'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','8','decimal','','S','System.Decimal','decimal(19,8)','N','itinerationlapview','N','','9','ancereductionpercentage','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'codeforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '20',field = 'codeforeigncountry',col_precision = '' where tablename = 'itinerationlapview' AND field = 'codeforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','itinerationlapview','N','','20','codeforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'itinerationlapview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationlapview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'itinerationlapview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationlapview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'days')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'float',defaultvalue = '',allownull = 'N',systemtype = 'System.Double',sqldeclaration = 'float',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '8',field = 'days',col_precision = '' where tablename = 'itinerationlapview' AND field = 'days'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','float','','N','System.Double','float','N','itinerationlapview','S','','8','days','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'description')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '150',field = 'description',col_precision = '' where tablename = 'itinerationlapview' AND field = 'description'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','itinerationlapview','S','','150','description','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'flagitalian')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '1',field = 'flagitalian',col_precision = '' where tablename = 'itinerationlapview' AND field = 'flagitalian'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','itinerationlapview','S','','1','flagitalian','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'hours')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'float',defaultvalue = '',allownull = 'N',systemtype = 'System.Double',sqldeclaration = 'float',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '8',field = 'hours',col_precision = '' where tablename = 'itinerationlapview' AND field = 'hours'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','float','','N','System.Double','float','N','itinerationlapview','S','','8','hours','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'idforeigncountry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '4',field = 'idforeigncountry',col_precision = '' where tablename = 'itinerationlapview' AND field = 'idforeigncountry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','itinerationlapview','N','','4','idforeigncountry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'idreduction')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '20',field = 'idreduction',col_precision = '' where tablename = 'itinerationlapview' AND field = 'idreduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','itinerationlapview','N','','20','idreduction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'lapnumber')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '2',field = 'lapnumber',col_precision = '' where tablename = 'itinerationlapview' AND field = 'lapnumber'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','itinerationlapview','S','','2','lapnumber','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'location')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '50',field = 'location',col_precision = '' where tablename = 'itinerationlapview' AND field = 'location'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','itinerationlapview','N','','50','location','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'itinerationlapview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','itinerationlapview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'itinerationlapview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','itinerationlapview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'nitineration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'N',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '4',field = 'nitineration',col_precision = '' where tablename = 'itinerationlapview' AND field = 'nitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','itinerationlapview','S','','4','nitineration','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'reduction')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '50',field = 'reduction',col_precision = '' where tablename = 'itinerationlapview' AND field = 'reduction'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','itinerationlapview','N','','50','reduction','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'starttime')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '4',field = 'starttime',col_precision = '' where tablename = 'itinerationlapview' AND field = 'starttime'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','itinerationlapview','N','','4','starttime','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'stoptime')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smalldatetime',defaultvalue = '',allownull = 'S',systemtype = 'System.DateTime',sqldeclaration = 'smalldatetime',iskey = 'N',tablename = 'itinerationlapview',denynull = 'N',format = '',col_len = '4',field = 'stoptime',col_precision = '' where tablename = 'itinerationlapview' AND field = 'stoptime'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','itinerationlapview','N','','4','stoptime','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'itinerationlapview' AND field = 'yitineration')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'itinerationlapview',denynull = 'S',format = '',col_len = '2',field = 'yitineration',col_precision = '' where tablename = 'itinerationlapview' AND field = 'yitineration'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','itinerationlapview','S','','2','yitineration','')
GO

-- VERIFICA DI itinerationlapview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'itinerationlapview')
UPDATE customobject set isreal = 'N' where objectname = 'itinerationlapview'
ELSE
INSERT INTO customobject (objectname, isreal) values('itinerationlapview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --



