
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

