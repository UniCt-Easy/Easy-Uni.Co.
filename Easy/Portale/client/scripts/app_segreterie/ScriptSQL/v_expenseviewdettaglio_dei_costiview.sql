
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


-- CREAZIONE VISTA expenseviewdettaglio_dei_costiview
IF EXISTS(select * from sysobjects where id = object_id(N'[expenseviewdettaglio_dei_costiview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expenseviewdettaglio_dei_costiview]
GO

CREATE VIEW [expenseviewdettaglio_dei_costiview] AS SELECT  expenseview.accountdebit AS expenseview_accountdebit, expenseview.adate AS expenseview_adate, expenseview.amount AS expenseview_amount, expenseview.autocode AS expenseview_autocode, expenseview.autokind AS expenseview_autokind, expenseview.available AS expenseview_available, expenseview.ayear AS expenseview_ayear, expenseview.ayearstartamount AS expenseview_ayearstartamount, expenseview.biccode AS expenseview_biccode, expenseview.cc AS expenseview_cc, expenseview.cf AS expenseview_cf, expenseview.cigcode AS expenseview_cigcode, expenseview.cin AS expenseview_cin, expenseview.clawback AS expenseview_clawback, expenseview.clawbackref AS expenseview_clawbackref, expenseview.codeaccdebit AS expenseview_codeaccdebit, expenseview.codefin AS expenseview_codefin, expenseview.codeser AS expenseview_codeser, expenseview.codeupb AS expenseview_codeupb, expenseview.ct AS expenseview_ct, expenseview.cu AS expenseview_cu, expenseview.cupcode AS expenseview_cupcode, expenseview.curramount AS expenseview_curramount, expenseview.deputy AS expenseview_deputy, expenseview.description, expenseview.doc AS expenseview_doc, expenseview.docdate AS expenseview_docdate, expenseview.expiration AS expenseview_expiration, expenseview.external_reference AS expenseview_external_reference, expenseview.extracode AS expenseview_extracode, expenseview.finance AS expenseview_finance, expenseview.finflag AS expenseview_finflag, expenseview.flag AS expenseview_flag, expenseview.flagarrear AS expenseview_flagarrear, expenseview.formernmov AS expenseview_formernmov, expenseview.formerymov AS expenseview_formerymov, expenseview.iban AS expenseview_iban, expenseview.idaccdebit AS expenseview_idaccdebit, [dbo].bank.description AS bank_description, expenseview.idbank, [dbo].cab.description AS cab_description, expenseview.idcab, [dbo].chargehandling.description AS chargehandling_description, expenseview.idchargehandling, clawback.description AS clawback_description, expenseview.idclawback, expenseview.iddeputy AS expenseview_iddeputy, expense.description AS expense_description, expense.ymov AS expense_ymov, expense.nmov AS expense_nmov, expenseview.idexp, fin.title AS fin_title, expenseview.idfin, expenseview.idformerexpense AS expenseview_idformerexpense, expenseview.idinc_linked AS expenseview_idinc_linked, expenseview.idpay AS expenseview_idpay, expenseview.idpayment AS expenseview_idpayment, [dbo].paymethod.description AS paymethod_description, expenseview.idpaymethod, [dbo].registry.title AS registry_title, expenseview.idreg, [dbo].registrypaymethod.regmodcode AS registrypaymethod_regmodcode, expenseview.idregistrypaymethod, expenseview.idser AS expenseview_idser, upb.title AS upb_title, expenseview.idupb, expenseview.ivaamount AS expenseview_ivaamount, expenseview.kpay AS expenseview_kpay, expenseview.kpaymenttransmission AS expenseview_kpaymenttransmission, expenseview.lt AS expenseview_lt, expenseview.lu AS expenseview_lu, expenseview.manager AS expenseview_manager, expenseview.nbill AS expenseview_nbill, expenseview.netamount AS expenseview_netamount, expenseview.ninc_linked AS expenseview_ninc_linked, expenseview.nmov AS expenseview_nmov, expenseview.npay AS expenseview_npay, expenseview.npaymenttransmission AS expenseview_npaymenttransmission, expenseview.nphase AS expenseview_nphase, expenseview.p_iva AS expenseview_p_iva, expenseview.pagopanoticenum AS expenseview_pagopanoticenum, expenseview.parentidexp AS expenseview_parentidexp, expenseview.parentnmov AS expenseview_parentnmov, expenseview.parentymov AS expenseview_parentymov, expenseview.paymentadate AS expenseview_paymentadate, expenseview.paymentdescr AS expenseview_paymentdescr,CASE WHEN expenseview.paymethod_allowdeputy = 'S' THEN 'Si' WHEN expenseview.paymethod_allowdeputy = 'N' THEN 'No' END AS expenseview_paymethod_allowdeputy, expenseview.paymethod_flag AS expenseview_paymethod_flag, expenseview.phase AS expenseview_phase, expenseview.refexternaldoc AS expenseview_refexternaldoc, expenseview.registry AS expenseview_registry, expenseview.service AS expenseview_service, expenseview.servicestart AS expenseview_servicestart, expenseview.servicestop AS expenseview_servicestop, expenseview.totflag AS expenseview_totflag, expenseview.transmissiondate AS expenseview_transmissiondate, expenseview.txt AS expenseview_txt, expenseview.upb AS expenseview_upb, expenseview.yinc_linked AS expenseview_yinc_linked, expenseview.ymov AS expenseview_ymov, expenseview.ypay AS expenseview_ypay FROM expenseview WITH (NOLOCK)  LEFT OUTER JOIN [dbo].bank WITH (NOLOCK) ON expenseview.idbank = [dbo].bank.idbank LEFT OUTER JOIN [dbo].cab WITH (NOLOCK) ON expenseview.idcab = [dbo].cab.idcab LEFT OUTER JOIN [dbo].chargehandling WITH (NOLOCK) ON expenseview.idchargehandling = [dbo].chargehandling.idchargehandling LEFT OUTER JOIN clawback WITH (NOLOCK) ON expenseview.idclawback = clawback.idclawback LEFT OUTER JOIN expense WITH (NOLOCK) ON expenseview.idexp = expense.idexp LEFT OUTER JOIN fin WITH (NOLOCK) ON expenseview.idfin = fin.idfin LEFT OUTER JOIN [dbo].paymethod WITH (NOLOCK) ON expenseview.idpaymethod = [dbo].paymethod.idpaymethod LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON expenseview.idreg = [dbo].registry.idreg LEFT OUTER JOIN [dbo].registrypaymethod WITH (NOLOCK) ON expenseview.idregistrypaymethod = [dbo].registrypaymethod.idregistrypaymethod LEFT OUTER JOIN upb WITH (NOLOCK) ON expenseview.idupb = upb.idupb
GO

-- VERIFICA DI expenseviewdettaglio_dei_costiview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'expenseviewdettaglio_dei_costiview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','bank_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','cab_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','chargehandling_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','clawback_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','description','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expense_description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expense_nmov','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expense_ymov','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expenseview_accountdebit','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_adate','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(19,2)','ASSISTENZA','expenseview_amount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_autocode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','tinyint','ASSISTENZA','expenseview_autokind','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(19,2)','ASSISTENZA','expenseview_available','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_ayear','2','S','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(19,2)','ASSISTENZA','expenseview_ayearstartamount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(20)','ASSISTENZA','expenseview_biccode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(30)','ASSISTENZA','expenseview_cc','30','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(16)','ASSISTENZA','expenseview_cf','16','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(10)','ASSISTENZA','expenseview_cigcode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(2)','ASSISTENZA','expenseview_cin','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_clawback','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(20)','ASSISTENZA','expenseview_clawbackref','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_codeaccdebit','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_codefin','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(20)','ASSISTENZA','expenseview_codeser','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_codeupb','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','datetime','ASSISTENZA','expenseview_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','varchar(64)','ASSISTENZA','expenseview_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(15)','ASSISTENZA','expenseview_cupcode','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(19,2)','ASSISTENZA','expenseview_curramount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(101)','ASSISTENZA','expenseview_deputy','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(35)','ASSISTENZA','expenseview_doc','35','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_docdate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_expiration','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(200)','ASSISTENZA','expenseview_external_reference','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(10)','ASSISTENZA','expenseview_extracode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expenseview_finance','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','tinyint','ASSISTENZA','expenseview_finflag','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','tinyint','ASSISTENZA','expenseview_flag','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(1)','ASSISTENZA','expenseview_flagarrear','1','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_formernmov','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_formerymov','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_iban','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(38)','ASSISTENZA','expenseview_idaccdebit','38','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_iddeputy','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_idformerexpense','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_idinc_linked','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_idpay','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_idpayment','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_idser','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(19,2)','ASSISTENZA','expenseview_ivaamount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_kpay','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_kpaymenttransmission','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','datetime','ASSISTENZA','expenseview_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','varchar(64)','ASSISTENZA','expenseview_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expenseview_manager','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_nbill','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','decimal(38,2)','ASSISTENZA','expenseview_netamount','17','N','decimal','System.Decimal','','2','''ASSISTENZA''','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_ninc_linked','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_nmov','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_npay','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_npaymenttransmission','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','tinyint','ASSISTENZA','expenseview_nphase','1','S','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(15)','ASSISTENZA','expenseview_p_iva','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(30)','ASSISTENZA','expenseview_pagopanoticenum','30','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_parentidexp','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_parentnmov','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_parentymov','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_paymentadate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expenseview_paymentdescr','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(2)','ASSISTENZA','expenseview_paymethod_allowdeputy','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','expenseview_paymethod_flag','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_phase','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_refexternaldoc','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(101)','ASSISTENZA','expenseview_registry','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','expenseview_service','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_servicestart','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_servicestop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','tinyint','ASSISTENZA','expenseview_totflag','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','date','ASSISTENZA','expenseview_transmissiondate','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','text','ASSISTENZA','expenseview_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','expenseview_upb','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_yinc_linked','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_ymov','2','S','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','smallint','ASSISTENZA','expenseview_ypay','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','fin_title','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(20)','ASSISTENZA','idbank','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(20)','ASSISTENZA','idcab','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idchargehandling','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idclawback','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idexp','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idfin','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idpaymethod','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idreg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','int','ASSISTENZA','idregistrypaymethod','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(36)','ASSISTENZA','idupb','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','paymethod_description','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(101)','ASSISTENZA','registry_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(50)','ASSISTENZA','registrypaymethod_regmodcode','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','expenseviewdettaglio_dei_costiview','varchar(150)','ASSISTENZA','upb_title','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI expenseviewdettaglio_dei_costiview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'expenseviewdettaglio_dei_costiview')
UPDATE customobject set isreal = 'N' where objectname = 'expenseviewdettaglio_dei_costiview'
ELSE
INSERT INTO customobject (objectname, isreal) values('expenseviewdettaglio_dei_costiview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

