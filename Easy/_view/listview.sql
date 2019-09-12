-- CREAZIONE VISTA listview
IF EXISTS(select * from sysobjects where id = object_id(N'[listview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [listview]
GO




 
 --select * from [listview]
 
CREATE VIEW [listview](
	idlist,
	description,
	intcode,
	intbarcode,
	extcode,
	extbarcode,
	validitystop,
	active,
	idpackage,
	package,
	idunit,
	unit,
	unitsforpackage,
	has_expiry,
	idlistclass,
	codelistclass,
	listclass,
	pic,
	timesupply,
	nmaxorder,
	authrequired,
	assetkind,
	assetkinddescr,
	flagvisiblekind,
	idinv,
	codeinv,
	inventorytree,
	codemotive,
	accmotive,
	price,
	insinfo,
	descrforuser
)
AS 
SELECT 
	list.idlist,
	list.description,
	list.intcode,
	list.intbarcode,
	list.extcode,
	list.extbarcode,
	list.validitystop,
	list.active,
	list.idpackage,
	package.description,
	list.idunit,
	unit.description,
	list.unitsforpackage,
	list.has_expiry,
	list.idlistclass,
	listclass.codelistclass,
	listclass.title,
	list.pic,
	list.timesupply,
	list.nmaxorder,
	listclass.authrequired,
	listclass.assetkind,
	CASE listclass.assetkind
		WHEN 'A' THEN 'Inventariabile'
		WHEN 'P' THEN 'Aumento di Valore'
		WHEN 'S'  THEN 'Servizi'
		WHEN 'M' THEN 'Magazzino'
		WHEN 'O' THEN 'Altro'
	END,
	listclass.flagvisiblekind,
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.description,
	accmotive.codemotive,
	accmotive.title,
	list.price,
	list.insinfo,
	list.descrforuser         
FROM list
JOIN listclass
	ON list.idlistclass = listclass.idlistclass
LEFT OUTER JOIN unit
	ON list.idunit = unit.idunit
LEFT OUTER JOIN package
	ON list.idpackage = package.idpackage
LEFT OUTER JOIN accmotive   --codemotive title
	ON accmotive.idaccmotive = listclass.idaccmotive
LEFT OUTER JOIN inventorytree
	ON listclass.idinv = inventorytree.idinv
 



GO

-- VERIFICA DI listview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'listview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','accmotive','150','''nino''','varchar(150)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','active','1','''nino''','char(1)','listview','','','','','N','N','char','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','assetkind','1','''nino''','char(1)','listview','','','','','S','N','char','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','assetkinddescr','17','''nino''','varchar(17)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','authrequired','1','''nino''','char(1)','listview','','','','','S','N','char','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codeinv','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','codelistclass','50','''nino''','varchar(50)','listview','','','','','N','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','codemotive','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','descrforuser','150','''nino''','varchar(150)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','description','150','''nino''','varchar(150)','listview','','','','','N','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','extbarcode','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','extcode','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','flagvisiblekind','1','''nino''','tinyint','listview','','','','','S','N','tinyint','nino','System.Byte')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','has_expiry','1','''nino''','char(1)','listview','','','','','N','N','char','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idinv','4','''nino''','int','listview','','','','','S','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlist','4','''nino''','int','listview','','','','','N','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idlistclass','36','''nino''','varchar(36)','listview','','','','','N','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idpackage','4','''nino''','int','listview','','','','','S','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','idunit','4','''nino''','int','listview','','','','','S','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','insinfo','1','''nino''','char(1)','listview','','','','','S','N','char','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','intbarcode','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','intcode','50','''nino''','varchar(50)','listview','','','','','N','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','inventorytree','150','''nino''','varchar(150)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','listclass','150','''nino''','varchar(150)','listview','','','','','N','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','nmaxorder','9','''nino''','decimal(19,2)','listview','','19','','2','S','N','decimal','nino','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','package','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pic','16','''nino''','image','listview','','','','','S','N','image','nino','System.Byte[]')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','price','9','''nino''','decimal(19,2)','listview','','19','','2','S','N','decimal','nino','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','timesupply','4','''nino''','int','listview','','','','','S','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','unit','50','''nino''','varchar(50)','listview','','','','','S','N','varchar','nino','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','unitsforpackage','4','''nino''','int','listview','','','','','S','N','int','nino','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','validitystop','3','''nino''','date','listview','','','','','S','N','date','nino','System.DateTime')
GO

-- VERIFICA DI listview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'listview')
UPDATE customobject set isreal = 'N' where objectname = 'listview'
ELSE
INSERT INTO customobject (objectname, isreal) values('listview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

