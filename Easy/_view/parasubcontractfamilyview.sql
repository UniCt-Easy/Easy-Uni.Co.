-- CREAZIONE VISTA parasubcontractfamilyview
IF EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractfamilyview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [parasubcontractfamilyview]
GO




CREATE VIEW [parasubcontractfamilyview]
(
	idcon,
	idreg,
	ayear,
	idfamily,
	surname,
	forename,
	idaffinity,
	affinity,
	idcitybirth,
	city,
	province,
	idnation,
	nation,
	birthdate,
	flagforeign,
	gender,
	cf,
	startapplication,
	stopapplication,
	appliancepercentage,
	starthandicap,
	foreignresident,
	flagdependent,
	amount,
	childasparent,
	ct, cu, lt, lu
)
AS
SELECT
	f.idcon,
	c.idreg,
	f.ayear,
	f.idfamily,
	f.surname,
	f.forename,
	f.idaffinity,
	tp.description,
	f.idcitybirth,
	gc.title,
	gp.province,
	f.idnation,
	gn.title,
	f.birthdate,
	f.flagforeign,
	f.gender,
	f.cf,
	f.startapplication,
	f.stopapplication,
	f.appliancepercentage,
	f.starthandicap,
	f.foreignresident,
	f.flagdependent,
	f.amount,
	f.childasparent,
	f.ct, f.cu, f.lt, f.lu
FROM parasubcontractfamily f
LEFT JOIN parasubcontract c
	ON f.idcon = c.idcon
LEFT OUTER JOIN registry cd
	ON c.idreg = cd.idreg
LEFT OUTER JOIN geo_city gc
	ON f.idcitybirth = gc.idcity
LEFT OUTER JOIN geo_country gp
	ON gc.idcountry = gp.idcountry
LEFT OUTER JOIN geo_nation gn
	ON f.idnation = gn.idnation
JOIN affinity tp
	ON f.idaffinity = tp.idaffinity




GO

-- VERIFICA DI parasubcontractfamilyview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'parasubcontractfamilyview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(50)','N','parasubcontractfamilyview','S','','50','affinity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','2','decimal','','S','System.Decimal','decimal(19,2)','N','parasubcontractfamilyview','N','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','6','decimal','','S','System.Decimal','decimal(19,6)','N','parasubcontractfamilyview','N','','9','appliancepercentage','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','parasubcontractfamilyview','S','','4','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','birthdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(16)','N','parasubcontractfamilyview','N','','16','cf','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','parasubcontractfamilyview','N','','1','childasparent','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','parasubcontractfamilyview','N','','65','city','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','parasubcontractfamilyview','N','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','parasubcontractfamilyview','S','','1','flagdependent','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','parasubcontractfamilyview','N','','1','flagforeign','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','parasubcontractfamilyview','S','','1','foreignresident','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','parasubcontractfamilyview','N','','50','forename','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(1)','N','parasubcontractfamilyview','N','','1','gender','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','N','System.String','char(1)','N','parasubcontractfamilyview','S','','1','idaffinity','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','parasubcontractfamilyview','N','','4','idcitybirth','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','N','System.String','varchar(8)','N','parasubcontractfamilyview','S','','8','idcon','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','N','System.Int32','int','N','parasubcontractfamilyview','S','','4','idfamily','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','parasubcontractfamilyview','N','','4','idnation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','int','','S','System.Int32','int','N','parasubcontractfamilyview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(64)','N','parasubcontractfamilyview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(65)','N','parasubcontractfamilyview','N','','65','nation','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','char','','S','System.String','char(2)','N','parasubcontractfamilyview','N','','2','province','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','startapplication','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','starthandicap','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','datetime','','S','System.DateTime','datetime','N','parasubcontractfamilyview','N','','8','stopapplication','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('NINO','''NINO''','','varchar','','S','System.String','varchar(50)','N','parasubcontractfamilyview','N','','50','surname','')
GO

-- VERIFICA DI parasubcontractfamilyview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'parasubcontractfamilyview')
UPDATE customobject set isreal = 'N' where objectname = 'parasubcontractfamilyview'
ELSE
INSERT INTO customobject (objectname, isreal) values('parasubcontractfamilyview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

