
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



CREATE VIEW [getcostoview]
AS

SELECT	expense.idexp, expenseyear.amount , expenseyear.idupb, expense.doc, expense.docdate,
			(select max(transactiondate) from banktransaction  where banktransaction.yban =expenseyear.ayear 
			AND   expense.idexp = banktransaction.idexp 	AND expenselast.idpay = banktransaction.idpay  ) as transactiondate,
			expense.description, expense.ymov, expense.nmov, dbo.accmotivedetail.idaccmotive, 
			dbo.accmotive.title AS accmotive_title, dbo.registry.title AS registry_title, dbo.registry.cf, dbo.registry.p_iva, payment.adate AS payment_adate,
			expense.adate, paymenttransmission.transmissiondate
FROM	dbo.registry INNER JOIN
			expense ON dbo.registry.idreg = expense.idreg INNER JOIN
			expenselast ON expense.idexp = expenselast.idexp INNER JOIN
			dbo.accmotivedetail ON dbo.accmotivedetail.idacc = expenselast.idaccdebit AND dbo.accmotivedetail.ayear = expense.ymov INNER JOIN
			dbo.accmotive ON dbo.accmotivedetail.idaccmotive = dbo.accmotive.idaccmotive INNER JOIN
			payment ON expenselast.kpay = payment.kpay INNER JOIN
			paymenttransmission ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission 	RIGHT OUTER JOIN 		
			expenseyear ON expense.idexp = expenseyear.idexp

GO

