
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA incomeinvoiceview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomeinvoiceview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomeinvoiceview]
GO



-- select * from incomeinvoiceview
CREATE  VIEW incomeinvoiceview 
	(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	movkind,
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
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
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
	incomelastflag,
	flag, 
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
	incomeinvoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	incomeinvoice.yinv,
	incomeinvoice.ninv,
	incomeinvoice.movkind,
	incomeinvoice.idinc,
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
	upb.idupb,	
	upb.codeupb,	
	upb.title,	
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	income.idreg,
	registry.title,
	income.idman,
	manager.title,
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	income.doc,
	income.docdate,
	income.description,
	incomeyear_starting.amount, --income.amount,
	incomeyear.amount,--incometotal.amount,
	incometotal.curramount,
	incometotal.available,
	ISNULL(incometotal.curramount,0) - ISNULL(incometotal.partitioned,0),
	incomelast.flag, --fulfilled
	incometotal.flag,
	CASE
		WHEN ((incometotal.flag&1)=0) THEN 'C'
		WHEN ((incometotal.flag&1)=1) THEN 'R'
	END, 
	income.autokind,
	income.idpayment,
	income.expiration,
	income.adate,
	incomeinvoice.cu,
	incomeinvoice.ct,
	incomeinvoice.lu,
	incomeinvoice.lt
	FROM incomeinvoice (NOLOCK)
	JOIN invoicekind (NOLOCK)
		ON invoicekind.idinvkind = incomeinvoice.idinvkind
	JOIN income (NOLOCK)
		ON income.idinc = incomeinvoice.idinc
	JOIN incomephase (NOLOCK)
		ON incomephase.nphase = income.nphase
	JOIN incomeyear (NOLOCK)
		ON incomeyear.idinc = income.idinc
	JOIN incometotal (NOLOCK)
		ON incometotal.idinc = incomeyear.idinc
		AND incometotal.ayear = incomeyear.ayear
	LEFT OUTER JOIN incometotal incometotal_firstyear(NOLOCK)
		ON incometotal_firstyear.idinc = income.idinc
		AND ((incometotal_firstyear.flag & 2) <> 0 )
	LEFT OUTER JOIN incomeyear incomeyear_starting(NOLOCK) 
		ON incomeyear_starting.idinc = incometotal_firstyear.idinc
		AND incomeyear_starting.ayear = incometotal_firstyear.ayear
	LEFT OUTER JOIN income parentincome (NOLOCK)
		ON income.parentidinc = parentincome.idinc
	LEFT OUTER JOIN incomelast  (NOLOCK)
		ON incomelast.idinc = income.idinc
	LEFT OUTER JOIN proceeds  (NOLOCK)
		ON incomelast.kpro = proceeds.kpro
	LEFT OUTER JOIN fin (NOLOCK)
		ON fin.idfin = incomeyear.idfin
	LEFT OUTER JOIN upb (NOLOCK)
		ON upb.idupb=incomeyear.idupb
	LEFT OUTER JOIN registry (NOLOCK)
		ON registry.idreg = income.idreg
	LEFT OUTER JOIN manager (NOLOCK)
		ON manager.idman = income.idman



GO

-- VERIFICA DI incomeinvoiceview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'incomeinvoiceview'
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smalldatetime','','N','System.DateTime','smalldatetime','N','incomeinvoiceview','S','','4','adate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','2','decimal','','S','System.Decimal','decimal(19,2)','N','incomeinvoiceview','N','','9','amount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','tinyint','','S','System.Byte','tinyint','N','incomeinvoiceview','N','','1','autokind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','2','decimal','','S','System.Decimal','decimal(19,2)','N','incomeinvoiceview','N','','9','available','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','N','System.Int16','smallint','N','incomeinvoiceview','S','','2','ayear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','2','decimal','','S','System.Decimal','decimal(19,2)','N','incomeinvoiceview','N','','9','ayearstartamount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(50)','N','incomeinvoiceview','N','','50','codefin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(20)','N','incomeinvoiceview','S','','20','codeinvkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(50)','N','incomeinvoiceview','N','','50','codeupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','datetime','','N','System.DateTime','datetime','N','incomeinvoiceview','S','','8','ct','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(64)','N','incomeinvoiceview','S','','64','cu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','2','decimal','','S','System.Decimal','decimal(19,2)','N','incomeinvoiceview','N','','9','curramount','19')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(150)','N','incomeinvoiceview','S','','150','description','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(35)','N','incomeinvoiceview','N','','35','doc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smalldatetime','','S','System.DateTime','smalldatetime','N','incomeinvoiceview','N','','4','docdate','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smalldatetime','','S','System.DateTime','smalldatetime','N','incomeinvoiceview','N','','4','expiration','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(150)','N','incomeinvoiceview','N','','150','finance','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','tinyint','','N','System.Byte','tinyint','N','incomeinvoiceview','S','','1','flag','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(1)','N','incomeinvoiceview','N','','1','flagarrear','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idfin','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','incomeinvoiceview','S','','4','idinc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','incomeinvoiceview','S','','4','idinvkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idman','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idpayment','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idreg','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idsor01','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idsor02','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idsor03','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idsor04','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','idsor05','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(36)','N','incomeinvoiceview','N','','36','idupb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','tinyint','','S','System.Byte','tinyint','N','incomeinvoiceview','N','','1','incomelastflag','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(50)','N','incomeinvoiceview','S','','50','invoicekind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','kpro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','datetime','','N','System.DateTime','datetime','N','incomeinvoiceview','S','','8','lt','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(64)','N','incomeinvoiceview','S','','64','lu','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(150)','N','incomeinvoiceview','N','','150','manager','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','N','System.Int16','smallint','N','incomeinvoiceview','S','','2','movkind','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','incomeinvoiceview','S','','4','ninv','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','N','System.Int32','int','N','incomeinvoiceview','S','','4','nmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','tinyint','','N','System.Byte','tinyint','N','incomeinvoiceview','S','','1','nphase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','npro','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','parentidinc','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','int','','S','System.Int32','int','N','incomeinvoiceview','N','','4','parentnmov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','S','System.Int16','smallint','N','incomeinvoiceview','N','','2','parentymov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','N','System.String','varchar(50)','N','incomeinvoiceview','S','','50','phase','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(100)','N','incomeinvoiceview','N','','100','registry','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','2','decimal','','S','System.Decimal','decimal(20,2)','N','incomeinvoiceview','N','','13','unpartitioned','20')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','varchar','','S','System.String','varchar(150)','N','incomeinvoiceview','N','','150','upb','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','N','System.Int16','smallint','N','incomeinvoiceview','S','','2','yinv','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','N','System.Int16','smallint','N','incomeinvoiceview','S','','2','ymov','')
GO

INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('sa','''sa''','','smallint','','S','System.Int16','smallint','N','incomeinvoiceview','N','','2','ypro','')
GO

-- VERIFICA DI incomeinvoiceview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'incomeinvoiceview')
UPDATE customobject set isreal = 'N' where objectname = 'incomeinvoiceview'
ELSE
INSERT INTO customobject (objectname, isreal) values('incomeinvoiceview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

