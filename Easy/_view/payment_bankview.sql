
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


-- CREAZIONE VISTA payment_bankview
IF EXISTS(select * from sysobjects where id = object_id(N'[payment_bankview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [payment_bankview]
GO
--setuser 'amministrazione'
--setuser'amm'
--select * from [payment_bankview] where notperformed <> 0 and ypay = 2020
--select * from [payment_bank] where notperformed <> 0 and ypay = 2020
 --clear_table_info payment_bankview
CREATE  VIEW payment_bankview
(
	ypay,
	npay,
	idpay,
	kpay,
	nmov,
	idreg,
	registry,
	description,
	amount,
	performed,
	notperformed,
	ct,
	cu,
	lt,
	lu
)
AS SELECT
	payment.ypay,
	payment.npay,
	PB.idpay,
	PB.kpay,
	E.nmov,
	PB.idreg,
	R.title,
	PB.description,
	PB.amount,
	-- ESITATO PERFORMED
	ISNULL((SELECT SUM(amount) from banktransaction P where
		P.kpay=PB.kpay  AND P.idpay=PB.idpay ),0),
	-- NON ESITATO NOT PERFORMED
	(SELECT SUM(curramount) from expensetotal I join expense S on I.idexp=S.idexp 
		JOIN expenselast EL ON EL.idexp = S.idexp
	  WHERE EL.kpay=PB.kpay AND EL.idpay=PB.idpay AND I.ayear = payment.ypay)
	  -ISNULL( (SELECT SUM(amount) from banktransaction P where
		P.kpay=PB.kpay  AND P.idpay=PB.idpay ),0),
	PB.ct,
	PB.cu,
	PB.lt,
	PB.lu
FROM payment_bank PB
JOIN payment ON PB.kpay = payment.kpay
left outer join expenselast EL on PB.idpay=EL.idpay and PB.kpay=EL.kpay
left outer join expense E on EL.idexp=E.idexp
JOIN registry R
	ON R.idreg = PB.idreg





GO

 
