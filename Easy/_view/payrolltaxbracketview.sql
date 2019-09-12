-- CREAZIONE VISTA payrolltaxbracketview
IF EXISTS(select * from sysobjects where id = object_id(N'[payrolltaxbracketview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payrolltaxbracketview]
GO





CREATE VIEW [payrolltaxbracketview]
(
	taxcode,
	description,
	taxref,
	idcon,
	ycon,
	ncon,
	idpayroll,
	npayroll,
	fiscalyear,
	nbracket,
	adminrate,
	employrate,
	taxablegross,
	deduction,
	totaltaxablenet,
	taxablenet,
	admindenominator,
	employdenominator,
	taxabledenominator,
	adminnumerator,
	employnumerator,
	taxablenumerator,
	totaladmintax,
	totalemploytax,
	admintax,
	employtax,
	employtaxgross,
	abatements,
	taxkind,
	geoappliance,
	idcity,
	city,
	provincecode,
	idfiscaltaxregion,
	fiscaltaxregion,
	lu,
	lt
)
AS SELECT
	PRT.taxcode,
	TR.description,
	TR.taxref,
	PSC.idcon,
	PSC.ycon,
	PSC.ncon,
	PRT.idpayroll,
	PR.npayroll,
	PR.fiscalyear,
	PRTB.nbracket,
	PRTB.adminrate,
	PRTB.employrate,
	PRT.taxablegross,
	PRT.deduction,
	PRT.taxablenet,
	PRTB.taxable,
	PRT.admindenominator,
	PRT.employdenominator,
	PRT.taxabledenominator,
	PRT.adminnumerator,
	PRT.employnumerator,
	PRT.taxablenumerator,
	PRT.admintax,
	PRT.employtax,
	PRTB.admintax,
	PRTB.employtax,
	PRT.employtaxgross,
	PRT.abatements,
	TR.taxkind,
	TR.geoappliance,
	PRT.idcity,
	geo_city.title,
	geo_country.province,
	PRT.idfiscaltaxregion,
	fiscaltaxregion.title,
	PRTB.lu,
	PRTB.lt
FROM payrolltaxbracket PRTB
JOIN payrolltax PRT
	ON PRTB.idpayroll = PRT.idpayroll
	AND PRTB.idpayrolltax = PRT.idpayrolltax
JOIN payroll PR
	ON PR.idpayroll = PRT.idpayroll
JOIN parasubcontract PSC
	ON PSC.idcon = PR.idcon
JOIN tax TR
	ON PRT.taxcode = TR.taxcode
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = PRT.idcity
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
LEFT OUTER JOIN fiscaltaxregion
	ON fiscaltaxregion.idfiscaltaxregion = PRT.idfiscaltaxregion


GO

-- VERIFICA DI payrolltaxbracketview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'payrolltaxbracketview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','abatements','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','admindenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','adminnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','adminrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','admintax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','payrolltaxbracketview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','deduction','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','payrolltaxbracketview','S','','50','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','employdenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','employnumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','employrate','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','employtax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','employtaxgross','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','payrolltaxbracketview','N','','50','fiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','payrolltaxbracketview','S','','4','fiscalyear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','payrolltaxbracketview','N','','1','geoappliance','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','payrolltaxbracketview','N','','4','idcity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(8)','N','payrolltaxbracketview','S','','8','idcon','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(5)','N','payrolltaxbracketview','N','','5','idfiscaltaxregion','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','payrolltaxbracketview','S','','4','idpayroll','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','payrolltaxbracketview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','payrolltaxbracketview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','payrolltaxbracketview','S','','2','nbracket','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','payrolltaxbracketview','S','','20','ncon','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','payrolltaxbracketview','S','','4','npayroll','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(2)','N','payrolltaxbracketview','N','','2','provincecode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','taxabledenominator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','taxablegross','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','taxablenet','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','payrolltaxbracketview','N','','9','taxablenumerator','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','payrolltaxbracketview','N','','4','taxcode','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','smallint','','N','System.Int16','smallint','N','payrolltaxbracketview','S','','2','taxkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(20)','N','payrolltaxbracketview','S','','20','taxref','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','totaladmintax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','totalemploytax','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','payrolltaxbracketview','N','','9','totaltaxablenet','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','payrolltaxbracketview','S','','4','ycon','')
GO

-- VERIFICA DI payrolltaxbracketview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'payrolltaxbracketview')
UPDATE customobject set isreal = 'N' where objectname = 'payrolltaxbracketview'
ELSE
INSERT INTO customobject (objectname, isreal) values('payrolltaxbracketview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

