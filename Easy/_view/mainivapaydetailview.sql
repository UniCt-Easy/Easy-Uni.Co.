-- CREAZIONE VISTA mainivapaydetailview
IF EXISTS(select * from sysobjects where id = object_id(N'[mainivapaydetailview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mainivapaydetailview]
GO



CREATE  VIEW [mainivapaydetailview]
(
	ymainivapay,
	nmainivapay,
	nmonth,
	referenceyear,
	idivaregisterkind,
	codeivaregisterkind,
	description,
	registerclass,
	iva,
	ivadeferred,
	ivatotal,
	unabatable,
	unabatabledeferred,
	unabatabletotal,
	prorata,
	mixed,
	ivanet,
	ivanetdeferred,
	iddbdepartment,
	department,
	flagactivity,
	cu, 
	ct, 
	lu, 
	lt
	)	
AS SELECT
	mainivapaydetail.ymainivapay,
	mainivapaydetail.nmainivapay,
	mainivapay.nmonth,
	mainivapay.referenceyear,
	mainivapaydetail.idivaregisterkind,
	ivaregisterkind.codeivaregisterkind,
	ivaregisterkind.description,
	ivaregisterkind.registerclass,
	mainivapaydetail.iva,
	mainivapaydetail.ivadeferred,
	ISNULL(mainivapaydetail.iva,0) + ISNULL(mainivapaydetail.ivadeferred,0),
	mainivapaydetail.unabatable,
	mainivapaydetail.unabatabledeferred,
	ISNULL(mainivapaydetail.unabatable,0) + ISNULL(mainivapaydetail.unabatabledeferred,0),
	mainivapaydetail.prorata,
	mainivapaydetail.mixed,
	mainivapaydetail.ivanet,
	mainivapaydetail.ivanetdeferred,
    mainivapaydetail.iddbdepartment,
    dbdepartment.description,
	ivaregisterkind.flagactivity,
	mainivapaydetail.cu, 
	mainivapaydetail.ct, 
	mainivapaydetail.lu,
	mainivapaydetail.lt 
	FROM mainivapaydetail (NOLOCK)
	JOIN ivaregisterkind (NOLOCK)
		ON ivaregisterkind.idivaregisterkind = mainivapaydetail.idivaregisterkind
	JOIN mainivapay (NOLOCK)
		ON mainivapay.nmainivapay = mainivapaydetail.nmainivapay
		AND mainivapay.ymainivapay = mainivapaydetail.ymainivapay
	LEFT OUTER JOIN dbdepartment
        ON mainivapaydetail.iddbdepartment = dbdepartment.iddbdepartment


GO

-- VERIFICA DI mainivapaydetailview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'mainivapaydetailview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(20)','N','mainivapaydetailview','S','','20','codeivaregisterkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','mainivapaydetailview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','mainivapaydetailview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','mainivapaydetailview','N','','150','department','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','mainivapaydetailview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','mainivapaydetailview','N','','2','flagactivity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','mainivapaydetailview','S','','50','iddbdepartment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapaydetailview','S','','4','idivaregisterkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','iva','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','ivadeferred','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','ivanet','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','ivanetdeferred','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','mainivapaydetailview','N','','13','ivatotal','20')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','mainivapaydetailview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','mainivapaydetailview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','mainivapaydetailview','N','','9','mixed','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapaydetailview','S','','4','nmainivapay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapaydetailview','N','','4','nmonth','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','6','decimal','','S','System.Decimal','decimal(19,6)','N','mainivapaydetailview','N','','9','prorata','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapaydetailview','N','','4','referenceyear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','N','System.String','char(1)','N','mainivapaydetailview','S','','1','registerclass','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','unabatable','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapaydetailview','N','','9','unabatabledeferred','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','mainivapaydetailview','N','','13','unabatabletotal','20')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapaydetailview','S','','4','ymainivapay','')
GO

-- VERIFICA DI mainivapaydetailview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'mainivapaydetailview')
UPDATE customobject set isreal = 'N' where objectname = 'mainivapaydetailview'
ELSE
INSERT INTO customobject (objectname, isreal) values('mainivapaydetailview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

