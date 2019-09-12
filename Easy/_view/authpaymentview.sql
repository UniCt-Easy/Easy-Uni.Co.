-- CREAZIONE VISTA authpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[authpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [authpaymentview]
GO




CREATE   VIEW authpaymentview
(
	idauthpayment,
	sent_date,
	authorize_date,
	attach_amount,
	payable_amount,
	payed_amount,
	idauthstatus,
	authstatus,
	yauthpayment,
	nauthpayment,
	description,
	doc,
	docdate,
	idreg,
	registry,
	ct, cu, lt, lu
)
AS SELECT
	P.idauthpayment,
	P.sent_date,
	P.authorize_date,
	P.attach_amount,
	CASE
		WHEN ISNULL(P.attach_amount,0) -
		ISNULL(
			(SELECT SUM(E.curramount)
			FROM expensetotal E
			JOIN authpaymentexpense PE
				ON E.idexp = PE.idexp
			WHERE PE.idauthpayment = P.idauthpayment)
		,0) < 0 THEN 0
		ELSE
		ISNULL(P.attach_amount,0) -
		ISNULL(
			(SELECT SUM(E.curramount)
			FROM expensetotal E
			JOIN authpaymentexpense PE
				ON E.idexp = PE.idexp
			WHERE PE.idauthpayment = P.idauthpayment)
		,0)
	END,
	ISNULL(
		(SELECT SUM(E.curramount)
		FROM expensetotal E
		JOIN authpaymentexpense PE
			ON E.idexp = PE.idexp
		WHERE PE.idauthpayment = P.idauthpayment)
	,0),
	P.idauthstatus,
	S.description,
	P.yauthpayment,
	P.nauthpayment,
	P.description,
	P.doc,
	P.docdate,
	P.idreg,
	R.title,
	P.ct, P.cu, P.lt, P.lu
FROM authpayment P
JOIN authstatus S
	ON S.idauthstatus = P.idauthstatus
LEFT OUTER JOIN registry R
	ON R.idreg = P.idreg




GO

-- VERIFICA DI authpaymentview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'authpaymentview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','authpaymentview','N','','9','attach_amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','authpaymentview','N','','8','authorize_date','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','authpaymentview','S','','50','authstatus','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','authpaymentview','N','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','authpaymentview','N','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(200)','N','authpaymentview','N','','200','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(35)','N','authpaymentview','N','','35','doc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','authpaymentview','N','','8','docdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','authpaymentview','S','','4','idauthpayment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','authpaymentview','S','','4','idauthstatus','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','authpaymentview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','authpaymentview','N','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(64)','N','authpaymentview','N','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','authpaymentview','N','','2','nauthpayment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','authpaymentview','N','','17','payable_amount','38')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','N','System.Decimal','decimal(38,2)','N','authpaymentview','S','','17','payed_amount','38')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','authpaymentview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','S','System.DateTime','datetime','N','authpaymentview','N','','8','sent_date','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','authpaymentview','N','','4','yauthpayment','')
GO

-- VERIFICA DI authpaymentview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'authpaymentview')
UPDATE customobject set isreal = 'N' where objectname = 'authpaymentview'
ELSE
INSERT INTO customobject (objectname, isreal) values('authpaymentview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

