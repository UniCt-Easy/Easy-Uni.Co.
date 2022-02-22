
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
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','adate','3','''assistenza''','date','getprogettocostoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ammissibilita','5','''assistenza''','decimal(5,2)','getprogettocostoview','','5','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','amount','5','''assistenza''','decimal(9,2)','getprogettocostoview','','9','','2','S','N','decimal','assistenza','System.Decimal')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','cf','16','''assistenza''','varchar(16)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','contrattokind_title','50','''assistenza''','varchar(50)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','description','150','''assistenza''','varchar(150)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','doc','35','''assistenza''','varchar(35)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','docdate','3','''assistenza''','date','getprogettocostoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idgetprogettocostoview','4','''assistenza''','int','getprogettocostoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idprogetto','4','''assistenza''','int','getprogettocostoview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','nmov','4','''assistenza''','int','getprogettocostoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','noperation','4','''assistenza''','int','getprogettocostoview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','p_iva','15','''assistenza''','varchar(15)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','payment_adate','3','''assistenza''','date','getprogettocostoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycash_description','50','''assistenza''','varchar(50)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','pettycash_pettycode','20','''assistenza''','varchar(20)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','progettotipocosto_title','2048','''assistenza''','varchar(2048)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','raggruppamento','2048','''assistenza''','nvarchar(2048)','getprogettocostoview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','registry_title','101','''assistenza''','varchar(101)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','rendicontattivitaprogetto_description','-1','''assistenza''','varchar(max)','getprogettocostoview','','','','','S','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','transactiondate','3','''assistenza''','date','getprogettocostoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','transmissiondate','3','''assistenza''','date','getprogettocostoview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','workpackage_title','2048','''assistenza''','nvarchar(2048)','getprogettocostoview','','','','','S','N','nvarchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ymov','2','''assistenza''','smallint','getprogettocostoview','','','','','S','N','smallint','assistenza','System.Int16')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','yoperation','2','''assistenza''','smallint','getprogettocostoview','','','','','S','N','smallint','assistenza','System.Int16')
GO

-- VERIFICA DI getprogettocostoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getprogettocostoview')
UPDATE customobject set isreal = 'N' where objectname = 'getprogettocostoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getprogettocostoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

