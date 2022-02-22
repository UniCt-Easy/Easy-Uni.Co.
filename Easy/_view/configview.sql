
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


-- CREAZIONE VISTA configview
IF EXISTS(select * from sysobjects where id = object_id(N'[configview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [configview]
GO





CREATE VIEW configview
(
	ayear,
	appropriationphasecode,
	appropriationphase,
	assessmentphasecode,
	assessmentphase,
	asset_flagnumbering,
	asset_flagrestart,
	assetload_flag,
	previsionkind,
	secprevisionkind,
	cashvaliditykind,
	boxpartitiontitle,
	currpartitiontitle,
	prevpartitiontitle,
	deferredexpensephase,
	deferredincomephase,
	electronictrasmission,
	electronicimport,
	appname,
	importappname,
	admintaxkind,
	employtaxkind,
	clawbackkind,
	expense_expiringdays,
	income_expiringdays,
	expensephase,
	expensephasedescr,
	incomephase,
	incmephasedescr,
	idacc_accruedcost,
	codeacc_accruedcost,
	accruedcost_acc,
	idacc_accruedrevenue,
	codeacc_accruedrevenue,
	accruedrevenue_acc,
	idacc_customer,
	codeacc_customer,
	customer_acc,
	idacc_deferredcost,
	codeacc_deferredcost,
	deferredcost_acc,
	idacc_deferredrevenue,
	codeacc_deferredrevenue,
	deferredrevenue_acc,
	idacc_ivapayment,
	codeacc_ivapayment,
	ivapayment_acc,
	idacc_ivarefund,
	codeacc_ivarefund,
	ivarefund_acc,
	idacc_patrimony,
	codeacc_patrimony,
	patrimony_acc,
	idacc_pl,
	codeacc_pl,
	pl_acc,
	idacc_supplier,
	codeacc_supplier,
	supplier_acc,
	idaccmotive_admincar,
	codemotive_admincar,
	admincar,
	idaccmotive_foot,
	codemotive_foot,
	foot,
	idaccmotive_owncar,
	codemotive_owncar,
	owncar,
	foreignhours,
	idclawback,
	clawback,
	idfinexpense,
	codefinexpense,
	finexpense,
	idfinexpensesurplus,
	codefinexpensesurplus,
	finexpensesurplus,
	idfinincomesurplus,
	codefinincomesurplus,
	finincomesurplus,
	idfinivapayment,
	codefinivapayment,
	ivapayment,
	idfinivarefund,
	codefinivarefund,
	finivarefund,
	idivapayperiodicity,
	ivapayperiodicity,
	idregauto,
	registry,
	idsortingkind1,
	sorting1,
	idsortingkind2,
	sorting2,
	idsortingkind3,
	sorting3,
	linktoinvoice,
	minpayment,
	minrefund,
	motivelen,
	motiveprefix,
	motiveseparator,
	payment_finlevel,
	pay_finleveldescr,
	payment_flag,
	payment_flagautoprintdate,
	paymentagency,
	paymentagency_title,
	proceeds_finlevel,
	pro_finleveldescr,
	proceeds_flag,
	proceeds_flagautoprintdate,
	refundagency,
	refundagency_title,
	flagadmintax,
	flagarrearsadmintax,
	flagautopayment,
	flagautoproceeds,
	flagclawback,
	flagcredit,
	flagepexp,
	flagfruitful,
	flagpayment,
	flagproceeds,
	flagrefund,
	flagtax,
	flagtaxcompetency,
	payments_groupingkind,
	proceeds_groupingkind,
	estimate_numerationkind,
	mandate_numerationkind,
	invoice_numerationkind,
	casualcontract_flagnumbering,
	casualcontract_flagrestart,
	parasubcontract_numerationkind,
	profservice_flagnumbering,
	profservice_flagrestart,
	wageaddition_flagnumbering,
	wageaddition_flagrestart,
	ct, cu, lt, lu
)
AS SELECT
	C.ayear,
	C.appropriationphasecode,
	APP.description,
	C.assessmentphasecode,
	ASS.description,
	C.asset_flagnumbering,
	C.asset_flagrestart,
	C.assetload_flag,
	C.previsionkind,
	C.secprevisionkind,
	C.cashvaliditykind,
	C.boxpartitiontitle,
	C.currpartitiontitle,
	C.prevpartitiontitle,
	C.deferredexpensephase,
	C.deferredincomephase,
	C.electronictrasmission,
	C.electronicimport,
	C.appname,
	C.importappname,
	C.admintaxkind,
	C.employtaxkind,
	C.clawbackkind,
	C.expense_expiringdays,
	C.income_expiringdays,
	C.expensephase,
	EXP_CONT.description,
	C.incomephase,
	INC_CONT.description,
	C.idacc_accruedcost,
	ACCRUEDCOST.codeacc,
	ACCRUEDCOST.title,
	C.idacc_accruedrevenue,
	ACCRUEDREVENUE.codeacc,
	ACCRUEDREVENUE.title,
	C.idacc_customer,
	CUSTOMER.codeacc,
	CUSTOMER.title,
	C.idacc_deferredcost,
	DEFERREDCOST.codeacc,
	DEFERREDCOST.title,
	C.idacc_deferredrevenue,
	DEFERREDREVENUE.codeacc,
	DEFERREDREVENUE.title,
	C.idacc_ivapayment,
	IVAPAYMENT.codeacc,
	IVAPAYMENT.title,
	C.idacc_ivarefund,
	IVAREFUND.codeacc,
	IVAREFUND.title,
	C.idacc_patrimony,
	PAT.codeacc,
	PAT.title,
	C.idacc_pl,
	PL.codeacc,
	PL.title,
	C.idacc_supplier,
	SUPPLIER.codeacc,
	SUPPLIER.title,
	C.idaccmotive_admincar,
	ADMINCAR.codemotive,
	ADMINCAR.title,
	C.idaccmotive_foot,
	FOOT.codemotive,
	FOOT.title,
	C.idaccmotive_owncar,
	OWNCAR.codemotive,
	OWNCAR.title,
	C.foreignhours,
	C.idclawback,
	clawback.description,
	C.idfinexpense,
	FINEXPENSE.codefin,
	FINEXPENSE.title,
	C.idfinexpensesurplus,
	E_SURPLUS.codefin,
	E_SURPLUS.title,
	C.idfinincomesurplus,
	I_SURPLUS.codefin,
	I_SURPLUS.title,
	C.idfinivapayment,
	FIN_IVAPAYMENT.codefin,
	FIN_IVAPAYMENT.title,
	C.idfinivarefund,
	FIN_IVAREFUND.codefin,
	FIN_IVAREFUND.title,
	C.idivapayperiodicity,
	IPP.description,
	C.idregauto,
	R.title,
	C.idsortingkind1,
	S1.description,
	C.idsortingkind2,
	S2.description,
	C.idsortingkind3,
	S3.description,
	C.linktoinvoice,
	C.minpayment,
	C.minrefund,
	C.motivelen,
	C.motiveprefix,
	C.motiveseparator,
	C.payment_finlevel,
	FL_PA.description,
	C.payment_flag,
	C.payment_flagautoprintdate,
	C.paymentagency,
	PAYAGENCY.title,
	C.proceeds_finlevel,
	FL_PR.description,
	C.proceeds_flag,
	C.proceeds_flagautoprintdate,
	C.refundagency,
	REFAGENCY.title,
	C.flagadmintax,
	C.flagarrearsadmintax,
	C.flagautopayment,
	C.flagautoproceeds,
	C.flagclawback,
	C.flagcredit,
	C.flagepexp,
	C.flagfruitful,
	C.flagpayment,
	C.flagproceeds,
	C.flagrefund,
	C.flagtax,
	C.flagtaxcompetency,
	C.payments_groupingkind,
	C.proceeds_groupingkind,
	C.estimate_numerationkind,
	C.mandate_numerationkind,
	C.invoice_numerationkind,
	C.casualcontract_flagnumbering,
	C.casualcontract_flagrestart,
	C.parasubcontract_numerationkind,
	C.profservice_flagnumbering,
	C.profservice_flagrestart,
	C.wageaddition_flagnumbering,
	C.wageaddition_flagrestart,
	C.ct, C.cu, C.lt, C.lu
FROM config C
LEFT OUTER JOIN expensephase APP
	ON C.appropriationphasecode = APP.nphase
LEFT OUTER JOIN incomephase ASS
	ON C.assessmentphasecode = ASS.nphase
LEFT OUTER JOIN expensephase EXP_CONT
	ON C.expensephase = EXP_CONT.nphase
LEFT OUTER JOIN incomephase INC_CONT
	ON C.incomephase = INC_CONT.nphase
LEFT OUTER JOIN account ACCRUEDCOST
	ON C.idacc_accruedcost = ACCRUEDCOST.idacc
LEFT OUTER JOIN account ACCRUEDREVENUE
	ON C.idacc_accruedrevenue = ACCRUEDREVENUE.idacc
LEFT OUTER JOIN account CUSTOMER
	ON C.idacc_customer = CUSTOMER.idacc
LEFT OUTER JOIN account DEFERREDCOST
	ON C.idacc_deferredcost = DEFERREDCOST.idacc
LEFT OUTER JOIN account DEFERREDREVENUE
	ON C.idacc_deferredrevenue = DEFERREDREVENUE.idacc
LEFT OUTER JOIN account IVAPAYMENT
	ON C.idacc_ivapayment = IVAPAYMENT.idacc
LEFT OUTER JOIN account IVAREFUND
	ON C.idacc_ivarefund = IVAREFUND.idacc
LEFT OUTER JOIN account PAT
	ON C.idacc_patrimony = PAT.idacc
LEFT OUTER JOIN account PL
	ON C.idacc_pl = PL.idacc
LEFT OUTER JOIN account SUPPLIER
	ON C.idacc_supplier = SUPPLIER.idacc
LEFT OUTER JOIN accmotive ADMINCAR
	ON C.idaccmotive_admincar = ADMINCAR.idaccmotive
LEFT OUTER JOIN accmotive FOOT
	ON C.idaccmotive_foot = FOOT.idaccmotive
LEFT OUTER JOIN accmotive OWNCAR
	ON C.idaccmotive_owncar = OWNCAR.idaccmotive
LEFT OUTER JOIN clawback
	ON C.idclawback = clawback.idclawback
LEFT OUTER JOIN fin FINEXPENSE
	ON C.idfinexpense = FINEXPENSE.idfin
LEFT OUTER JOIN fin E_SURPLUS
	ON C.idfinexpensesurplus = E_SURPLUS.idfin
LEFT OUTER JOIN fin I_SURPLUS
	ON C.idfinincomesurplus = I_SURPLUS.idfin
LEFT OUTER JOIN fin FIN_IVAPAYMENT
	ON C.idfinivapayment = FIN_IVAPAYMENT.idfin
LEFT OUTER JOIN fin FIN_IVAREFUND
	ON C.idfinivarefund = FIN_IVAREFUND.idfin
LEFT OUTER JOIN ivapayperiodicity IPP
	ON C.idivapayperiodicity = IPP.idivapayperiodicity
LEFT OUTER JOIN registry R
	ON C.idregauto = R.idreg
LEFT OUTER JOIN sortingkind S1
	ON C.idsortingkind1 = S1.idsorkind
LEFT OUTER JOIN sortingkind S2
	ON C.idsortingkind2 = S2.idsorkind
LEFT OUTER JOIN sortingkind S3
	ON C.idsortingkind3 = S3.idsorkind
LEFT OUTER JOIN finlevel FL_PA
	ON C.ayear = FL_PA.ayear
	AND C.payment_finlevel = FL_PA.nlevel
LEFT OUTER JOIN finlevel FL_PR
	ON C.ayear = FL_PR.ayear
	AND C.payment_finlevel = FL_PR.nlevel
LEFT OUTER JOIN registry PAYAGENCY
	ON C.paymentagency = PAYAGENCY.idreg
LEFT OUTER JOIN registry REFAGENCY
	ON C.refundagency = REFAGENCY.idreg





GO

-- VERIFICA DI configview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'configview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'accruedcost_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'accruedcost_acc',col_precision = '' where tablename = 'configview' AND field = 'accruedcost_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','accruedcost_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'accruedrevenue_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'accruedrevenue_acc',col_precision = '' where tablename = 'configview' AND field = 'accruedrevenue_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','accruedrevenue_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'admincar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'admincar',col_precision = '' where tablename = 'configview' AND field = 'admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'admintaxkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'admintaxkind',col_precision = '' where tablename = 'configview' AND field = 'admintaxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','admintaxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'appname')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(255)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '255',field = 'appname',col_precision = '' where tablename = 'configview' AND field = 'appname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(255)','N','configview','N','','255','appname','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'appropriationphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'appropriationphase',col_precision = '' where tablename = 'configview' AND field = 'appropriationphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','appropriationphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'appropriationphasecode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'appropriationphasecode',col_precision = '' where tablename = 'configview' AND field = 'appropriationphasecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','appropriationphasecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'assessmentphase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'assessmentphase',col_precision = '' where tablename = 'configview' AND field = 'assessmentphase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','assessmentphase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'assessmentphasecode')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'assessmentphasecode',col_precision = '' where tablename = 'configview' AND field = 'assessmentphasecode'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','assessmentphasecode','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'asset_flagnumbering')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'asset_flagnumbering',col_precision = '' where tablename = 'configview' AND field = 'asset_flagnumbering'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','asset_flagnumbering','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'asset_flagrestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'asset_flagrestart',col_precision = '' where tablename = 'configview' AND field = 'asset_flagrestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','asset_flagrestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'assetload_flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'assetload_flag',col_precision = '' where tablename = 'configview' AND field = 'assetload_flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','assetload_flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'configview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'configview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','configview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'boxpartitiontitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'boxpartitiontitle',col_precision = '' where tablename = 'configview' AND field = 'boxpartitiontitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','boxpartitiontitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'cashvaliditykind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'cashvaliditykind',col_precision = '' where tablename = 'configview' AND field = 'cashvaliditykind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','cashvaliditykind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'casualcontract_flagnumbering')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'casualcontract_flagnumbering',col_precision = '' where tablename = 'configview' AND field = 'casualcontract_flagnumbering'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','casualcontract_flagnumbering','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'casualcontract_flagrestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'casualcontract_flagrestart',col_precision = '' where tablename = 'configview' AND field = 'casualcontract_flagrestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','casualcontract_flagrestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'clawback')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'clawback',col_precision = '' where tablename = 'configview' AND field = 'clawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','clawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'clawbackkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'clawbackkind',col_precision = '' where tablename = 'configview' AND field = 'clawbackkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','clawbackkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_accruedcost')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_accruedcost',col_precision = '' where tablename = 'configview' AND field = 'codeacc_accruedcost'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_accruedcost','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_accruedrevenue')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_accruedrevenue',col_precision = '' where tablename = 'configview' AND field = 'codeacc_accruedrevenue'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_accruedrevenue','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_customer')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_customer',col_precision = '' where tablename = 'configview' AND field = 'codeacc_customer'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_customer','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_deferredcost')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_deferredcost',col_precision = '' where tablename = 'configview' AND field = 'codeacc_deferredcost'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_deferredcost','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_deferredrevenue')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_deferredrevenue',col_precision = '' where tablename = 'configview' AND field = 'codeacc_deferredrevenue'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_deferredrevenue','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_ivapayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_ivapayment',col_precision = '' where tablename = 'configview' AND field = 'codeacc_ivapayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_ivapayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_ivarefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_ivarefund',col_precision = '' where tablename = 'configview' AND field = 'codeacc_ivarefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_ivarefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_patrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_patrimony',col_precision = '' where tablename = 'configview' AND field = 'codeacc_patrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_patrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_pl')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_pl',col_precision = '' where tablename = 'configview' AND field = 'codeacc_pl'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_pl','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codeacc_supplier')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codeacc_supplier',col_precision = '' where tablename = 'configview' AND field = 'codeacc_supplier'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codeacc_supplier','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codefinexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codefinexpense',col_precision = '' where tablename = 'configview' AND field = 'codefinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codefinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codefinexpensesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codefinexpensesurplus',col_precision = '' where tablename = 'configview' AND field = 'codefinexpensesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codefinexpensesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codefinincomesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codefinincomesurplus',col_precision = '' where tablename = 'configview' AND field = 'codefinincomesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codefinincomesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codefinivapayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codefinivapayment',col_precision = '' where tablename = 'configview' AND field = 'codefinivapayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codefinivapayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codefinivarefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codefinivarefund',col_precision = '' where tablename = 'configview' AND field = 'codefinivarefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codefinivarefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codemotive_admincar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_admincar',col_precision = '' where tablename = 'configview' AND field = 'codemotive_admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codemotive_admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codemotive_foot')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_foot',col_precision = '' where tablename = 'configview' AND field = 'codemotive_foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codemotive_foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'codemotive_owncar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'codemotive_owncar',col_precision = '' where tablename = 'configview' AND field = 'codemotive_owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','codemotive_owncar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ct')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'configview',denynull = 'S',format = '',col_len = '8',field = 'ct',col_precision = '' where tablename = 'configview' AND field = 'ct'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','configview','S','','8','ct','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'cu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'configview',denynull = 'S',format = '',col_len = '64',field = 'cu',col_precision = '' where tablename = 'configview' AND field = 'cu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','configview','S','','64','cu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'currpartitiontitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '20',field = 'currpartitiontitle',col_precision = '' where tablename = 'configview' AND field = 'currpartitiontitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','configview','N','','20','currpartitiontitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'customer_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'customer_acc',col_precision = '' where tablename = 'configview' AND field = 'customer_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','customer_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'deferredcost_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'deferredcost_acc',col_precision = '' where tablename = 'configview' AND field = 'deferredcost_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','deferredcost_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'deferredexpensephase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'deferredexpensephase',col_precision = '' where tablename = 'configview' AND field = 'deferredexpensephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','deferredexpensephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'deferredincomephase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'deferredincomephase',col_precision = '' where tablename = 'configview' AND field = 'deferredincomephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','deferredincomephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'deferredrevenue_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'deferredrevenue_acc',col_precision = '' where tablename = 'configview' AND field = 'deferredrevenue_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','deferredrevenue_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'electronicimport')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'electronicimport',col_precision = '' where tablename = 'configview' AND field = 'electronicimport'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','electronicimport','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'electronictrasmission')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'electronictrasmission',col_precision = '' where tablename = 'configview' AND field = 'electronictrasmission'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','electronictrasmission','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'employtaxkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'employtaxkind',col_precision = '' where tablename = 'configview' AND field = 'employtaxkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','employtaxkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'estimate_numerationkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'estimate_numerationkind',col_precision = '' where tablename = 'configview' AND field = 'estimate_numerationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','estimate_numerationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'expense_expiringdays')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '2',field = 'expense_expiringdays',col_precision = '' where tablename = 'configview' AND field = 'expense_expiringdays'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','configview','N','','2','expense_expiringdays','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'expensephase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'expensephase',col_precision = '' where tablename = 'configview' AND field = 'expensephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','expensephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'expensephasedescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'expensephasedescr',col_precision = '' where tablename = 'configview' AND field = 'expensephasedescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','expensephasedescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'finexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'finexpense',col_precision = '' where tablename = 'configview' AND field = 'finexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','finexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'finexpensesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'finexpensesurplus',col_precision = '' where tablename = 'configview' AND field = 'finexpensesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','finexpensesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'finincomesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'finincomesurplus',col_precision = '' where tablename = 'configview' AND field = 'finincomesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','finincomesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'finivarefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'finivarefund',col_precision = '' where tablename = 'configview' AND field = 'finivarefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','finivarefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagadmintax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagadmintax',col_precision = '' where tablename = 'configview' AND field = 'flagadmintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagadmintax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagarrearsadmintax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagarrearsadmintax',col_precision = '' where tablename = 'configview' AND field = 'flagarrearsadmintax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagarrearsadmintax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagautopayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagautopayment',col_precision = '' where tablename = 'configview' AND field = 'flagautopayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagautopayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagautoproceeds')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagautoproceeds',col_precision = '' where tablename = 'configview' AND field = 'flagautoproceeds'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagautoproceeds','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagclawback')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagclawback',col_precision = '' where tablename = 'configview' AND field = 'flagclawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagclawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagcredit')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagcredit',col_precision = '' where tablename = 'configview' AND field = 'flagcredit'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagcredit','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagepexp')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagepexp',col_precision = '' where tablename = 'configview' AND field = 'flagepexp'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagepexp','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagfruitful')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagfruitful',col_precision = '' where tablename = 'configview' AND field = 'flagfruitful'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagfruitful','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagpayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagpayment',col_precision = '' where tablename = 'configview' AND field = 'flagpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagpayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagproceeds')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagproceeds',col_precision = '' where tablename = 'configview' AND field = 'flagproceeds'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagproceeds','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagrefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagrefund',col_precision = '' where tablename = 'configview' AND field = 'flagrefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagrefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagtax')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagtax',col_precision = '' where tablename = 'configview' AND field = 'flagtax'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagtax','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'flagtaxcompetency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'flagtaxcompetency',col_precision = '' where tablename = 'configview' AND field = 'flagtaxcompetency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','flagtaxcompetency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'foot')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'foot',col_precision = '' where tablename = 'configview' AND field = 'foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'foreignhours')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'foreignhours',col_precision = '' where tablename = 'configview' AND field = 'foreignhours'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','foreignhours','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_accruedcost')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_accruedcost',col_precision = '' where tablename = 'configview' AND field = 'idacc_accruedcost'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_accruedcost','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_accruedrevenue')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_accruedrevenue',col_precision = '' where tablename = 'configview' AND field = 'idacc_accruedrevenue'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_accruedrevenue','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_customer')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_customer',col_precision = '' where tablename = 'configview' AND field = 'idacc_customer'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_customer','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_deferredcost')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_deferredcost',col_precision = '' where tablename = 'configview' AND field = 'idacc_deferredcost'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_deferredcost','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_deferredrevenue')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_deferredrevenue',col_precision = '' where tablename = 'configview' AND field = 'idacc_deferredrevenue'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_deferredrevenue','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_ivapayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_ivapayment',col_precision = '' where tablename = 'configview' AND field = 'idacc_ivapayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_ivapayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_ivarefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_ivarefund',col_precision = '' where tablename = 'configview' AND field = 'idacc_ivarefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_ivarefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_patrimony')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_patrimony',col_precision = '' where tablename = 'configview' AND field = 'idacc_patrimony'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_patrimony','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_pl')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_pl',col_precision = '' where tablename = 'configview' AND field = 'idacc_pl'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_pl','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idacc_supplier')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(38)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '38',field = 'idacc_supplier',col_precision = '' where tablename = 'configview' AND field = 'idacc_supplier'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(38)','N','configview','N','','38','idacc_supplier','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idaccmotive_admincar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_admincar',col_precision = '' where tablename = 'configview' AND field = 'idaccmotive_admincar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(36)','N','configview','N','','36','idaccmotive_admincar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idaccmotive_foot')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_foot',col_precision = '' where tablename = 'configview' AND field = 'idaccmotive_foot'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(36)','N','configview','N','','36','idaccmotive_foot','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idaccmotive_owncar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(36)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '36',field = 'idaccmotive_owncar',col_precision = '' where tablename = 'configview' AND field = 'idaccmotive_owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(36)','N','configview','N','','36','idaccmotive_owncar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idclawback')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idclawback',col_precision = '' where tablename = 'configview' AND field = 'idclawback'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idclawback','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idfinexpense')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idfinexpense',col_precision = '' where tablename = 'configview' AND field = 'idfinexpense'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idfinexpense','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idfinexpensesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idfinexpensesurplus',col_precision = '' where tablename = 'configview' AND field = 'idfinexpensesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idfinexpensesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idfinincomesurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idfinincomesurplus',col_precision = '' where tablename = 'configview' AND field = 'idfinincomesurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idfinincomesurplus','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idfinivapayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idfinivapayment',col_precision = '' where tablename = 'configview' AND field = 'idfinivapayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idfinivapayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idfinivarefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idfinivarefund',col_precision = '' where tablename = 'configview' AND field = 'idfinivarefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idfinivarefund','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idivapayperiodicity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idivapayperiodicity',col_precision = '' where tablename = 'configview' AND field = 'idivapayperiodicity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idivapayperiodicity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idregauto')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'idregauto',col_precision = '' where tablename = 'configview' AND field = 'idregauto'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','idregauto','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idsortingkind1')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '20',field = 'idsortingkind1',col_precision = '' where tablename = 'configview' AND field = 'idsortingkind1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','configview','N','','20','idsortingkind1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idsortingkind2')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '20',field = 'idsortingkind2',col_precision = '' where tablename = 'configview' AND field = 'idsortingkind2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','configview','N','','20','idsortingkind2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'idsortingkind3')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '20',field = 'idsortingkind3',col_precision = '' where tablename = 'configview' AND field = 'idsortingkind3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','configview','N','','20','idsortingkind3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'importappname')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(255)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '255',field = 'importappname',col_precision = '' where tablename = 'configview' AND field = 'importappname'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(255)','N','configview','N','','255','importappname','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'incmephasedescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'incmephasedescr',col_precision = '' where tablename = 'configview' AND field = 'incmephasedescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','incmephasedescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'income_expiringdays')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '2',field = 'income_expiringdays',col_precision = '' where tablename = 'configview' AND field = 'income_expiringdays'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','configview','N','','2','income_expiringdays','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'incomephase')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'incomephase',col_precision = '' where tablename = 'configview' AND field = 'incomephase'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','incomephase','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'invoice_numerationkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'invoice_numerationkind',col_precision = '' where tablename = 'configview' AND field = 'invoice_numerationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','invoice_numerationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ivapayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'ivapayment',col_precision = '' where tablename = 'configview' AND field = 'ivapayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','ivapayment','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ivapayment_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'ivapayment_acc',col_precision = '' where tablename = 'configview' AND field = 'ivapayment_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','ivapayment_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ivapayperiodicity')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'ivapayperiodicity',col_precision = '' where tablename = 'configview' AND field = 'ivapayperiodicity'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','ivapayperiodicity','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'ivarefund_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'ivarefund_acc',col_precision = '' where tablename = 'configview' AND field = 'ivarefund_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','ivarefund_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'linktoinvoice')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'linktoinvoice',col_precision = '' where tablename = 'configview' AND field = 'linktoinvoice'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','linktoinvoice','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'lt')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'datetime',defaultvalue = '',allownull = 'N',systemtype = 'System.DateTime',sqldeclaration = 'datetime',iskey = 'N',tablename = 'configview',denynull = 'S',format = '',col_len = '8',field = 'lt',col_precision = '' where tablename = 'configview' AND field = 'lt'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','datetime','','N','System.DateTime','datetime','N','configview','S','','8','lt','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'lu')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'N',systemtype = 'System.String',sqldeclaration = 'varchar(64)',iskey = 'N',tablename = 'configview',denynull = 'S',format = '',col_len = '64',field = 'lu',col_precision = '' where tablename = 'configview' AND field = 'lu'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','N','System.String','varchar(64)','N','configview','S','','64','lu','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'mandate_numerationkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'mandate_numerationkind',col_precision = '' where tablename = 'configview' AND field = 'mandate_numerationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','mandate_numerationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'minpayment')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '9',field = 'minpayment',col_precision = '19' where tablename = 'configview' AND field = 'minpayment'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','configview','N','','9','minpayment','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'minrefund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(19,2)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '9',field = 'minrefund',col_precision = '19' where tablename = 'configview' AND field = 'minrefund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(19,2)','N','configview','N','','9','minrefund','19')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'motivelen')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'S',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '2',field = 'motivelen',col_precision = '' where tablename = 'configview' AND field = 'motivelen'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','S','System.Int16','smallint','N','configview','N','','2','motivelen','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'motiveprefix')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(20)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '20',field = 'motiveprefix',col_precision = '' where tablename = 'configview' AND field = 'motiveprefix'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(20)','N','configview','N','','20','motiveprefix','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'motiveseparator')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'motiveseparator',col_precision = '' where tablename = 'configview' AND field = 'motiveseparator'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','motiveseparator','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'owncar')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'owncar',col_precision = '' where tablename = 'configview' AND field = 'owncar'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','owncar','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'parasubcontract_numerationkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'parasubcontract_numerationkind',col_precision = '' where tablename = 'configview' AND field = 'parasubcontract_numerationkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','parasubcontract_numerationkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'patrimony_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'patrimony_acc',col_precision = '' where tablename = 'configview' AND field = 'patrimony_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','patrimony_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'pay_finleveldescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'pay_finleveldescr',col_precision = '' where tablename = 'configview' AND field = 'pay_finleveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','pay_finleveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'payment_finlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'payment_finlevel',col_precision = '' where tablename = 'configview' AND field = 'payment_finlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','payment_finlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'payment_flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'payment_flag',col_precision = '' where tablename = 'configview' AND field = 'payment_flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','payment_flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'payment_flagautoprintdate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'payment_flagautoprintdate',col_precision = '' where tablename = 'configview' AND field = 'payment_flagautoprintdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','payment_flagautoprintdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'paymentagency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'paymentagency',col_precision = '' where tablename = 'configview' AND field = 'paymentagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','paymentagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'paymentagency_title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '100',field = 'paymentagency_title',col_precision = '' where tablename = 'configview' AND field = 'paymentagency_title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','configview','N','','100','paymentagency_title','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'payments_groupingkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'payments_groupingkind',col_precision = '' where tablename = 'configview' AND field = 'payments_groupingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','payments_groupingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'pl_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'pl_acc',col_precision = '' where tablename = 'configview' AND field = 'pl_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','pl_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'previsionkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'previsionkind',col_precision = '' where tablename = 'configview' AND field = 'previsionkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','previsionkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'prevpartitiontitle')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'prevpartitiontitle',col_precision = '' where tablename = 'configview' AND field = 'prevpartitiontitle'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','prevpartitiontitle','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'pro_finleveldescr')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'pro_finleveldescr',col_precision = '' where tablename = 'configview' AND field = 'pro_finleveldescr'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','pro_finleveldescr','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'proceeds_finlevel')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'proceeds_finlevel',col_precision = '' where tablename = 'configview' AND field = 'proceeds_finlevel'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','proceeds_finlevel','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'proceeds_flag')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'tinyint',defaultvalue = '',allownull = 'S',systemtype = 'System.Byte',sqldeclaration = 'tinyint',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'proceeds_flag',col_precision = '' where tablename = 'configview' AND field = 'proceeds_flag'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','tinyint','','S','System.Byte','tinyint','N','configview','N','','1','proceeds_flag','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'proceeds_flagautoprintdate')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'proceeds_flagautoprintdate',col_precision = '' where tablename = 'configview' AND field = 'proceeds_flagautoprintdate'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','proceeds_flagautoprintdate','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'proceeds_groupingkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'proceeds_groupingkind',col_precision = '' where tablename = 'configview' AND field = 'proceeds_groupingkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','proceeds_groupingkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'profservice_flagnumbering')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'profservice_flagnumbering',col_precision = '' where tablename = 'configview' AND field = 'profservice_flagnumbering'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','profservice_flagnumbering','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'profservice_flagrestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'profservice_flagrestart',col_precision = '' where tablename = 'configview' AND field = 'profservice_flagrestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','profservice_flagrestart','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'refundagency')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'int',defaultvalue = '',allownull = 'S',systemtype = 'System.Int32',sqldeclaration = 'int',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '4',field = 'refundagency',col_precision = '' where tablename = 'configview' AND field = 'refundagency'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','int','','S','System.Int32','int','N','configview','N','','4','refundagency','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'refundagency_title')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '100',field = 'refundagency_title',col_precision = '' where tablename = 'configview' AND field = 'refundagency_title'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','configview','N','','100','refundagency_title','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'registry')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(100)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '100',field = 'registry',col_precision = '' where tablename = 'configview' AND field = 'registry'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(100)','N','configview','N','','100','registry','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'secprevisionkind')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'secprevisionkind',col_precision = '' where tablename = 'configview' AND field = 'secprevisionkind'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','secprevisionkind','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'sorting1')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'sorting1',col_precision = '' where tablename = 'configview' AND field = 'sorting1'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','sorting1','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'sorting2')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'sorting2',col_precision = '' where tablename = 'configview' AND field = 'sorting2'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','sorting2','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'sorting3')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(50)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '50',field = 'sorting3',col_precision = '' where tablename = 'configview' AND field = 'sorting3'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(50)','N','configview','N','','50','sorting3','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'supplier_acc')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'varchar',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'varchar(150)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '150',field = 'supplier_acc',col_precision = '' where tablename = 'configview' AND field = 'supplier_acc'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','varchar','','S','System.String','varchar(150)','N','configview','N','','150','supplier_acc','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'wageaddition_flagnumbering')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'wageaddition_flagnumbering',col_precision = '' where tablename = 'configview' AND field = 'wageaddition_flagnumbering'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','wageaddition_flagnumbering','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'configview' AND field = 'wageaddition_flagrestart')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'char',defaultvalue = '',allownull = 'S',systemtype = 'System.String',sqldeclaration = 'char(1)',iskey = 'N',tablename = 'configview',denynull = 'N',format = '',col_len = '1',field = 'wageaddition_flagrestart',col_precision = '' where tablename = 'configview' AND field = 'wageaddition_flagrestart'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','char','','S','System.String','char(1)','N','configview','N','','1','wageaddition_flagrestart','')
GO

-- VERIFICA DI configview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'configview')
UPDATE customobject set isreal = 'N' where objectname = 'configview'
ELSE
INSERT INTO customobject (objectname, isreal) values('configview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

