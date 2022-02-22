
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


-- CREAZIONE VISTA expenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseview]
GO

--setuser 'amministrazione' 
--setuser 'amm'
--select * from expenseview
--select * from autokind
--clear_table_info 'expenseview'

CREATE      VIEW expenseview
(
	idexp,
	nphase,
	phase,
	ymov,
	nmov,
	parentidexp,
	parentymov,
	parentnmov,
	idformerexpense,
	formerymov,
	formernmov,
	ayear,
	idfin,
	codefin,
	finance,
	finflag,
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
	cf,
	p_iva,
	idman,
	manager,
	kpay,
	ypay,
	npay,
	paymentadate,
	doc,
	docdate,
	description,
	amount,
	ayearstartamount,
	curramount,
	available,
	idregistrypaymethod,
	idpaymethod,
	iban,
	cin,
	idbank,
	idcab,
	cc,
	biccode,
	paymethod_allowdeputy,
	paymethod_flag,
	extracode,
	idchargehandling,
	iddeputy,
	deputy,
	refexternaldoc,
	paymentdescr,
	idser,
	service,
	codeser,
	servicestart,
	servicestop,
	ivaamount,
	flag,
	totflag,
	flagarrear,
	autokind,
	idpayment,
	expiration,
	adate,
	autocode,
	idclawback,
	clawback,
	clawbackref,
	nbill,
	idpay,
	kpaymenttransmission,
	npaymenttransmission,
	transmissiondate,
	idaccdebit, 
	codeaccdebit,
	accountdebit,
	cigcode,	
	cupcode,
	txt,
	cu,
	ct,
	lu,
	lt,
	external_reference,
	netamount,
	pagopanoticenum,
	idinc_linked,
	yinc_linked,
	ninc_linked
)
AS SELECT
	expense.idexp,
	expense.nphase,
	expensephase.description,
	expense.ymov,
	expense.nmov,
	expense.parentidexp,
	parentexpense.ymov,
	parentexpense.nmov,
	expense.idformerexpense,
	former.ymov,
	former.nmov,
	expenseyear.ayear,
	expenseyear.idfin,
	fin.codefin,
	fin.title,
	fin.flag,
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	expense.idreg,
	registry.title,
	registry.cf,
	registry.p_iva,
	expense.idman,
	manager.title,
	payment.kpay,
	payment.ypay,
	payment.npay,
	payment.adate,
	expense.doc,
	expense.docdate,
	expense.description,
	expenseyear_starting.amount,
	expenseyear.amount,
	expensetotal.curramount,
	expensetotal.available,
	expenselast.idregistrypaymethod,
	expenselast.idpaymethod,
	expenselast.iban,
	expenselast.cin,
	expenselast.idbank,
	expenselast.idcab,
	expenselast.cc,
	expenselast.biccode,
	expenselast.paymethod_allowdeputy,
	expenselast.paymethod_flag,
	extracode,
	expenselast.idchargehandling,
	expenselast.iddeputy,  
	deputy.title,
	expenselast.refexternaldoc,
	expenselast.paymentdescr,
	expenselast.idser,
	service.description,
	service.codeser,
	expenselast.servicestart,
	expenselast.servicestop,
	expenselast.ivaamount,
	expenselast.flag,
	expensetotal.flag,
	CASE
		WHEN ((expensetotal.flag&1)=0) THEN 'C'
		WHEN ((expensetotal.flag&1)=1) THEN 'R'
	END, 
	expense.autokind,
	expense.idpayment,
	expense.expiration,
	expense.adate,
	expense.autocode,
	expense.idclawback,
	clawback.description,
	clawback.clawbackref,
	expenselast.nbill,
	expenselast.idpay,
	paymenttransmission.kpaymenttransmission,
	paymenttransmission.npaymenttransmission,
	paymenttransmission.transmissiondate,
	expenselast.idaccdebit,
	account.codeacc,
	account.title,
	expense.cigcode,	
	expense.cupcode,
	expense.txt,
	expense.cu,
	expense.ct,
	expense.lu,
	expense.lt,
	expense.external_reference,
	expensetotal.curramount
		- isnull( (SELECT sum(IIT.curramount) from income II with (nolock) 
				join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=expense.ymov	
				join incomelast IL with (nolock) on IL.idinc=II.idinc 
		WHERE expenselast.idexp=II.idpayment and 
						((II.autokind=4 and II.idreg = expense.idreg ) or II.autokind in (6,7,14,20,21,30,31))
									--ritenute pari anagrafica, recuperi,generico,csariten,csalordi, NCSALORDI,NCSARITEN, reintegro fondo economale e chiusura
		  
         ),0),
	expenselast.pagopanoticenum,
	income.idinc,income.ymov,income.nmov

FROM expense
JOIN expensephase with(nolock)		ON expensephase.nphase = expense.nphase
JOIN expenseyear with(nolock)		ON expenseyear.idexp = expense.idexp
JOIN expensetotal with(nolock)		ON expensetotal.idexp = expense.idexp
							AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense with(nolock)	ON parentexpense.idexp = expense.parentidexp
LEFT OUTER JOIN expense former	with(nolock)	ON expense.idformerexpense = former.idexp
LEFT OUTER JOIN expenselast	with(nolock)	ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin	with(nolock)	ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb	with(nolock)	on upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry	with(nolock)	ON registry.idreg = expense.idreg
LEFT OUTER JOIN manager	with(nolock)		ON manager.idman = expense.idman
LEFT OUTER JOIN service	with(nolock)	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment with(nolock)	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy with(nolock)	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback with(nolock)	ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expensetotal expensetotal_firstyear with(nolock)  	ON expensetotal_firstyear.idexp = expense.idexp
  									and (expensetotal_firstyear.ayear=expense.ymov)
									--AND ((expensetotal_firstyear.flag & 2) <> 0 )
LEFT OUTER JOIN expenseyear expenseyear_starting with(nolock) 	ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  										AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
LEFT OUTER JOIN paymenttransmission with(nolock) 	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
LEFT OUTER JOIN account			ON account.idacc =  expenselast.idaccdebit
LEFT OUTER JOIN income (nolock)			ON expense.idinc_linked =  income.idinc





GO

-- VERIFICA DI expenseview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenseview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(150)','nino','accountdebit','150','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','date','nino','adate','3','S','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(19,2)','nino','amount','9','N','decimal','System.Decimal','','2','''nino''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','autocode','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','tinyint','nino','autokind','1','N','tinyint','System.Byte','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(19,2)','nino','available','9','N','decimal','System.Decimal','','2','''nino''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','smallint','nino','ayear','2','S','smallint','System.Int16','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(19,2)','nino','ayearstartamount','9','N','decimal','System.Decimal','','2','''nino''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(20)','nino','biccode','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(30)','nino','cc','30','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(16)','nino','cf','16','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(10)','nino','cigcode','10','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(2)','nino','cin','2','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','clawback','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(20)','nino','clawbackref','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','codeaccdebit','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','codefin','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(20)','nino','codeser','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','codeupb','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','datetime','nino','ct','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','varchar(64)','nino','cu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(15)','nino','cupcode','15','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(19,2)','nino','curramount','9','N','decimal','System.Decimal','','2','''nino''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(101)','nino','deputy','101','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','varchar(150)','nino','description','150','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(35)','nino','doc','35','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','docdate','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','expiration','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(200)','nino','external_reference','200','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(10)','nino','extracode','10','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(150)','nino','finance','150','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','tinyint','nino','finflag','1','N','tinyint','System.Byte','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','tinyint','nino','flag','1','N','tinyint','System.Byte','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(1)','nino','flagarrear','1','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','formernmov','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','smallint','nino','formerymov','2','N','smallint','System.Int16','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','iban','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(38)','nino','idaccdebit','38','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(20)','nino','idbank','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(20)','nino','idcab','20','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idchargehandling','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idclawback','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','iddeputy','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','int','nino','idexp','4','S','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idfin','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idformerexpense','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idinc_linked','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idman','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idpay','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idpayment','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idpaymethod','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idreg','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idregistrypaymethod','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idser','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idsor01','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idsor02','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idsor03','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idsor04','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','idsor05','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(36)','nino','idupb','36','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(19,2)','nino','ivaamount','9','N','decimal','System.Decimal','','2','''nino''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','kpay','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','kpaymenttransmission','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','datetime','nino','lt','8','S','datetime','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','varchar(64)','nino','lu','64','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(150)','nino','manager','150','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','nbill','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','decimal(38,2)','nino','netamount','17','N','decimal','System.Decimal','','2','''nino''','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','ninc_linked','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','int','nino','nmov','4','S','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','npay','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','npaymenttransmission','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','tinyint','nino','nphase','1','S','tinyint','System.Byte','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(15)','nino','p_iva','15','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(30)','nino','pagopanoticenum','30','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','parentidexp','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','parentnmov','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','smallint','nino','parentymov','2','N','smallint','System.Int16','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','paymentadate','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(150)','nino','paymentdescr','150','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','char(1)','nino','paymethod_allowdeputy','1','N','char','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','int','nino','paymethod_flag','4','N','int','System.Int32','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','varchar(50)','nino','phase','50','S','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','refexternaldoc','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(101)','nino','registry','101','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(50)','nino','service','50','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','servicestart','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','servicestop','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','tinyint','nino','totflag','1','N','tinyint','System.Byte','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','date','nino','transmissiondate','3','N','date','System.DateTime','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','text','nino','txt','16','N','text','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','varchar(150)','nino','upb','150','N','varchar','System.String','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','smallint','nino','yinc_linked','2','N','smallint','System.Int16','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseview','smallint','nino','ymov','2','S','smallint','System.Int16','','','''nino''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseview','smallint','nino','ypay','2','N','smallint','System.Int16','','','''nino''','','N')
GO

-- VERIFICA DI expenseview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenseview')
UPDATE customobject set isreal = 'N' where objectname = 'expenseview'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenseview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

