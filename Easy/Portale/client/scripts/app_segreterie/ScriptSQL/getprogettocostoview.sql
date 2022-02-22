
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


-- CREAZIONE VISTA getprogettocostoview
IF EXISTS(select * from sysobjects where id = object_id(N'[getprogettocostoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getprogettocostoview]
GO




CREATE VIEW [getprogettocostoview]
AS
SELECT        progettocosto.idprogettocosto AS idgetprogettocostoview, progettocosto.idprogetto, workpackage.raggruppamento, workpackage.title AS workpackage_title, progettotipocosto.title AS progettotipocosto_title, 
                         progettotipocosto.ammissibilita, progettocosto.amount, dbo.contrattokind.title AS contrattokind_title, rendicontattivitaprogetto.description AS rendicontattivitaprogetto_description, progettocosto.doc, 
                         progettocosto.docdate, banktransaction.transactiondate, expense.description, expense.ymov, expense.nmov, pettycash.description AS pettycash_description, 
                         pettycash.pettycode AS pettycash_pettycode, progettocosto.yoperation, progettocosto.noperation, dbo.registry.title AS registry_title, dbo.registry.cf, dbo.registry.p_iva, 
                         payment.adate AS payment_adate, expense.adate, paymenttransmission.transmissiondate
FROM            pettycash RIGHT OUTER JOIN
                         rendicontattivitaprogetto RIGHT OUTER JOIN
                         dbo.registry INNER JOIN
                         expense ON dbo.registry.idreg = expense.idreg INNER JOIN
                         expenselast INNER JOIN
                         payment ON expenselast.kpay = payment.kpay ON expense.idexp = expenselast.idexp INNER JOIN
                         paymenttransmission ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission RIGHT OUTER JOIN
                         dbo.contrattokind RIGHT OUTER JOIN
                         progettocosto INNER JOIN
                         workpackage ON progettocosto.idworkpackage = workpackage.idworkpackage INNER JOIN
                         progettotipocosto ON progettocosto.idprogettotipocosto = progettotipocosto.idprogettotipocosto ON dbo.contrattokind.idcontrattokind = progettocosto.idcontrattokind ON 
                         expense.idexp = progettocosto.idexp ON rendicontattivitaprogetto.idrendicontattivitaprogetto = progettocosto.idrendicontattivitaprogetto ON 
                         pettycash.idpettycash = progettocosto.idpettycash LEFT OUTER JOIN
                         banktransaction RIGHT OUTER JOIN
                         expenseyear ON banktransaction.yban = expenseyear.ayear ON expense.idexp = expenseyear.idexp AND 
                         expense.idexp = banktransaction.idexp


GO

-- VERIFICA DI getprogettocostoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getprogettocostoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','adate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','decimal(5,2)','assistenza','ammissibilita','5','N','decimal','System.Decimal','','2','''assistenza''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','decimal(9,2)','assistenza','amount','5','N','decimal','System.Decimal','','2','''assistenza''','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(16)','assistenza','cf','16','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(50)','assistenza','contrattokind_title','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(150)','assistenza','description','150','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(35)','assistenza','doc','35','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','docdate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoview','int','assistenza','idgetprogettocostoview','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getprogettocostoview','int','assistenza','idprogetto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','int','assistenza','nmov','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','int','assistenza','noperation','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(15)','assistenza','p_iva','15','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','payment_adate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(50)','assistenza','pettycash_description','50','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(20)','assistenza','pettycash_pettycode','20','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(2048)','assistenza','progettotipocosto_title','2048','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','nvarchar(2048)','assistenza','raggruppamento','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(101)','assistenza','registry_title','101','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','varchar(max)','assistenza','rendicontattivitaprogetto_description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','transactiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','date','assistenza','transmissiondate','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','nvarchar(2048)','assistenza','workpackage_title','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','smallint','assistenza','ymov','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getprogettocostoview','smallint','assistenza','yoperation','2','N','smallint','System.Int16','','','''assistenza''','','N')
GO

-- VERIFICA DI getprogettocostoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

