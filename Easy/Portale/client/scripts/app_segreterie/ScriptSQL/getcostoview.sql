
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


-- CREAZIONE VISTA getcostoview
IF EXISTS(select * from sysobjects where id = object_id(N'[getcostoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcostoview]
GO



CREATE VIEW [amministrazione].[getcostoview]
AS

SELECT        expense.idexp, expenseyear.amount, expenseyear.idupb, expense.doc, expense.docdate, 
                         banktransaction.transactiondate, expense.description, expense.ymov, expense.nmov, dbo.accmotivedetail.idaccmotive, 
                         dbo.accmotive.title AS accmotive_title, dbo.registry.title AS registry_title, dbo.registry.cf, dbo.registry.p_iva, payment.adate AS payment_adate, expense.adate, 
                         paymenttransmission.transmissiondate
FROM            dbo.registry INNER JOIN
                         expense ON dbo.registry.idreg = expense.idreg INNER JOIN
                         expenselast ON expense.idexp = expenselast.idexp INNER JOIN
                         dbo.accmotivedetail ON dbo.accmotivedetail.idacc = expenselast.idaccdebit AND dbo.accmotivedetail.ayear = expense.ymov INNER JOIN
                         dbo.accmotive ON dbo.accmotivedetail.idaccmotive = dbo.accmotive.idaccmotive INNER JOIN
                         payment ON expenselast.kpay = payment.kpay INNER JOIN
                         paymenttransmission ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission LEFT OUTER JOIN
                         banktransaction RIGHT OUTER JOIN
                         expenseyear ON banktransaction.yban = expenseyear.ayear ON expense.idexp = expenseyear.idexp AND 
                         expense.idexp = banktransaction.idexp
						 AND expenselast.idpay = banktransaction.idpay

GO

-- VERIFICA DI getcostoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcostoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','varchar(150)','assistenza','accmotive_title','150','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','date','assistenza','adate','3','S','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','decimal(19,2)','assistenza','amount','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','varchar(16)','assistenza','cf','16','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','varchar(150)','assistenza','description','150','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','varchar(36)','assistenza','idaccmotive','36','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','int','assistenza','idexp','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','varchar(36)','assistenza','idupb','36','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','int','assistenza','nmov','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','varchar(15)','assistenza','p_iva','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','date','assistenza','payment_adate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','varchar(101)','assistenza','registry_title','101','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','date','assistenza','transactiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostoview','date','assistenza','transmissiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostoview','smallint','assistenza','ymov','2','S','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI getcostoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcostoview')
UPDATE customobject set isreal = 'N' where objectname = 'getcostoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcostoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

