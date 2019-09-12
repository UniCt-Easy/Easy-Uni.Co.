-- CREAZIONE VISTA underwritingpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[underwritingpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [underwritingpaymentview]
GO







CREATE      VIEW [underwritingpaymentview]
(
	idexp,
	nphase,
	expensephase,
	ymov,
	nmov,
	idreg,
	registry,
	idman,
	manager,
	doc,
	docdate,
	description,
	adate,
	idunderwriting,
	codeunderwriting,
	underwriting,
	amount,
	idfin,
	codefin,
	fin,
	idupb,
	codeupb,
	upb,
	cu,
	ct,
	lu,
	lt
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.idreg,
	registry.title,
	expense.idman,
	manager.title,
	expense.doc,
	expense.docdate,
	expense.description,
	expense.adate,
	underwriting.idunderwriting,
	underwriting.codeunderwriting,
	underwriting.title,
	underwritingpayment.amount,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	expenseyear.idupb,
	upb.idupb,
	upb.codeupb,
	underwritingpayment.cu,
	underwritingpayment.ct,
	underwritingpayment.lu,
	underwritingpayment.lt
FROM underwritingpayment
JOIN expense
	ON underwritingpayment.idexp = expense.idexp
JOIN expenseyear
	ON expenseyear.idexp = expense.idexp	
JOIN underwriting
	ON underwritingpayment.idunderwriting = underwriting.idunderwriting
JOIN expensephase
	ON expensephase.nphase = expense.nphase
LEFT OUTER JOIN manager
	ON manager.idman = expense.idman
LEFT OUTER JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN fin
	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb
	on upb.idupb = expenseyear.idupb




GO

-- VERIFICA DI underwritingpaymentview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'underwritingpaymentview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','smalldatetime','','N','System.DateTime','smalldatetime','N','underwritingpaymentview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','2','decimal','','N','System.Decimal','decimal(19,2)','N','underwritingpaymentview','S','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(50)','N','underwritingpaymentview','N','','50','codefin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(50)','N','underwritingpaymentview','N','','50','codeunderwriting','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(36)','N','underwritingpaymentview','N','','36','codeupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','datetime','','N','System.DateTime','datetime','N','underwritingpaymentview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','N','System.String','varchar(64)','N','underwritingpaymentview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','N','System.String','varchar(150)','N','underwritingpaymentview','S','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(35)','N','underwritingpaymentview','N','','35','doc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','smalldatetime','','S','System.DateTime','smalldatetime','N','underwritingpaymentview','N','','4','docdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','N','System.String','varchar(50)','N','underwritingpaymentview','S','','50','expensephase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(150)','N','underwritingpaymentview','N','','150','fin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','N','System.Int32','int','N','underwritingpaymentview','S','','4','idexp','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','S','System.Int32','int','N','underwritingpaymentview','N','','4','idfin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','S','System.Int32','int','N','underwritingpaymentview','N','','4','idman','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','S','System.Int32','int','N','underwritingpaymentview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','N','System.Int32','int','N','underwritingpaymentview','S','','4','idunderwriting','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(36)','N','underwritingpaymentview','N','','36','idupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','datetime','','N','System.DateTime','datetime','N','underwritingpaymentview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','N','System.String','varchar(64)','N','underwritingpaymentview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(150)','N','underwritingpaymentview','N','','150','manager','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','int','','N','System.Int32','int','N','underwritingpaymentview','S','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','tinyint','','N','System.Byte','tinyint','N','underwritingpaymentview','S','','1','nphase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(100)','N','underwritingpaymentview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','N','System.String','varchar(150)','N','underwritingpaymentview','S','','150','underwriting','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','varchar','','S','System.String','varchar(50)','N','underwritingpaymentview','N','','50','upb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('nino','''nino''','','smallint','','N','System.Int16','smallint','N','underwritingpaymentview','S','','2','ymov','')
GO

-- VERIFICA DI underwritingpaymentview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'underwritingpaymentview')
UPDATE customobject set isreal = 'N' where objectname = 'underwritingpaymentview'
ELSE
INSERT INTO customobject (objectname, isreal) values('underwritingpaymentview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

