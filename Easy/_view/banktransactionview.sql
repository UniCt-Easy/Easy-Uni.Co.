
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


-- CREAZIONE VISTA banktransactionview
IF EXISTS(select * from sysobjects where id = object_id(N'[banktransactionview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [banktransactionview]
GO



CREATE  VIEW banktransactionview 
(
	yban,
	nban,
	kind,
	bankreference,
	transactiondate,
	valuedate,
	amount,
	kpay,
	ypay,
	npay,
	kpro,
	ypro,
	npro,
	income,
	expense,
	idexp,
	yexp,
	nexp,
	idinc,
	yinc,
	ninc,
	idpay,
	idpro,
	idbankimport,
	motive,
	nbill,
	cu,
	ct,
	lu,
	lt,
	idreg,
	registry,
	idupb,
	upb,
    idtreasurer 
)
AS SELECT
	banktransaction.yban,
	banktransaction.nban,
	banktransaction.kind,
	banktransaction.bankreference,
	banktransaction.transactiondate,
	banktransaction.valuedate,
	banktransaction.amount,
	banktransaction.kpay,
	payment.ypay,
	payment.npay,
	banktransaction.kpro,
	proceeds.ypro,
	proceeds.npro,
	CASE
		WHEN banktransaction.kind = 'C'
		THEN banktransaction.amount
		ELSE NULL
	END,
	CASE
		WHEN banktransaction.kind = 'D'
		THEN banktransaction.amount
		ELSE NULL		
	END,
	banktransaction.idexp,
	expense.ymov,
	expense.nmov,
	banktransaction.idinc,
	income.ymov,
	income.nmov,
	banktransaction.idpay,
	banktransaction.idpro,
	banktransaction.idbankimport,
	banktransaction.motive,
	banktransaction.nbill,
	banktransaction.cu,
	banktransaction.ct,
	banktransaction.lu,
	banktransaction.lt,
	registry.idreg,
	registry.title,
	upb.idupb,
	upb.title,
	ISNULL(payment.idtreasurer,proceeds.idtreasurer)
FROM banktransaction
LEFT OUTER JOIN payment			ON payment.kpay = banktransaction.kpay
LEFT OUTER JOIN proceeds		ON proceeds.kpro = banktransaction.kpro
LEFT OUTER JOIN expense			ON expense.idexp = banktransaction.idexp
LEFT OUTER JOIN expenseyear		ON expenseyear.idexp = banktransaction.idexp		AND expenseyear.ayear = banktransaction.yban
LEFT OUTER JOIN income			ON income.idinc = banktransaction.idinc		
LEFT OUTER JOIN incomeyear		ON incomeyear.idinc = banktransaction.idinc		AND incomeyear.ayear = banktransaction.yban
left outer join registry		on registry.idreg=ISNULL(expense.idreg,income.idreg)
left outer join upb				on upb.idupb=ISNULL(expenseyear.idupb,incomeyear.idupb)

GO

 
