-- CREAZIONE VISTA mainivapayincomeview
IF EXISTS(select * from sysobjects where id = object_id(N'[mainivapayincomeview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [mainivapayincomeview]
GO






CREATE  VIEW [mainivapayincomeview]
	(
	ymainivapay,
	nmainivapay,
	idinc,
	nphase,
	phase,
	ymov,
	nmov,
	parentidinc,
	parentymov,
	parentnmov,
	ayear,
	idfin,
	codefin,
	finance,
	idupb,
	codeupb,
	upb,
	idreg,
	registry,
	idman,
	manager,
	kpro,
	ypro,
	npro,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	unpartitioned,
	flag,
	totflag,
	flagarrear,
  	autokind,
	idpayment,
	expiration,
	adate,
	cu,
	ct,
	lu,
	lt
	)
	AS SELECT
	mainivapayincome.ymainivapay,
	mainivapayincome.nmainivapay,
	mainivapayincome.idinc,
	income.nphase,
	incomephase.description,
	income.ymov,
	income.nmov,
	--income.ycreation,
	income.parentidinc,
	parentincome.ymov,
	parentincome.nmov,
	incomeyear.ayear,
	incomeyear.idfin,
	fin.codefin,
	fin.title,
	incomeyear.idupb,
	upb.codeupb,
	upb.title,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	--income.ypro,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	--income.amount,
	incomeyear_starting.amount,
	--incometotal.amount,
	incomeyear.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0)-ISNULL(incometotal.partitioned,0),
	--income.fulfilled,
	incomelast.flag,
	incometotal.flag,
	--incomeyear.flagarrear,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	--income.idproceeds,
	income.idpayment,
	income.expiration,
	income.adate,
	mainivapayincome.cu,
	mainivapayincome.ct,
	mainivapayincome.lu,
	mainivapayincome.lt
	FROM mainivapayincome (NOLOCK)
	JOIN income (NOLOCK)
		ON income.idinc = mainivapayincome.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb = incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON income.idinc = incomelast.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON proceeds.kpro = incomelast.kpro
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
	  	ON incometotal_firstyear.idinc = income.idinc
	  	AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
	  	AND incomeyear_starting.ayear = incometotal_firstyear.ayear


GO

-- VERIFICA DI mainivapayincomeview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'mainivapayincomeview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','N','System.DateTime','smalldatetime','N','mainivapayincomeview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapayincomeview','N','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','mainivapayincomeview','N','','1','autokind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapayincomeview','N','','9','available','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','mainivapayincomeview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapayincomeview','N','','9','ayearstartamount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','mainivapayincomeview','N','','50','codefin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','mainivapayincomeview','N','','50','codeupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','mainivapayincomeview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','mainivapayincomeview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','mainivapayincomeview','N','','9','curramount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(150)','N','mainivapayincomeview','S','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(35)','N','mainivapayincomeview','N','','35','doc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','mainivapayincomeview','N','','4','docdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smalldatetime','','S','System.DateTime','smalldatetime','N','mainivapayincomeview','N','','4','expiration','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','mainivapayincomeview','N','','150','finance','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','mainivapayincomeview','N','','1','flag','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(1)','N','mainivapayincomeview','N','','1','flagarrear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','idfin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapayincomeview','S','','4','idinc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','idman','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','idpayment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(36)','N','mainivapayincomeview','N','','36','idupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','kpro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','mainivapayincomeview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','mainivapayincomeview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','mainivapayincomeview','N','','150','manager','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapayincomeview','S','','4','nmainivapay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapayincomeview','S','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','mainivapayincomeview','S','','1','nphase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','npro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','parentidinc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','mainivapayincomeview','N','','4','parentnmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','mainivapayincomeview','N','','2','parentymov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(50)','N','mainivapayincomeview','S','','50','phase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','mainivapayincomeview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','N','System.Byte','tinyint','N','mainivapayincomeview','S','','1','totflag','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(20,2)','N','mainivapayincomeview','N','','13','unpartitioned','20')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','mainivapayincomeview','N','','150','upb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','N','System.Int32','int','N','mainivapayincomeview','S','','4','ymainivapay','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','mainivapayincomeview','S','','2','ymov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','mainivapayincomeview','N','','2','ypro','')
GO

-- VERIFICA DI mainivapayincomeview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'mainivapayincomeview')
UPDATE customobject set isreal = 'N' where objectname = 'mainivapayincomeview'
ELSE
INSERT INTO customobject (objectname, isreal) values('mainivapayincomeview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

