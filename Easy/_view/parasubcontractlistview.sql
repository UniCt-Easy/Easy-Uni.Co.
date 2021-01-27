
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA parasubcontractlistview
IF EXISTS(select * from sysobjects where id = object_id(N'[parasubcontractlistview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [parasubcontractlistview]
GO

 --setuser 'amm'
CREATE  VIEW [parasubcontractlistview]
(
	ayear,
	idcon,
	iddbdepartment,
	idreg,
	balanced,
	linked,
	transmittedbalance,
	transmissiondate
)
AS SELECT
parasubcontractlist.ayear,
parasubcontractlist.idcon,
parasubcontractlist.iddbdepartment,
parasubcontractlist.idreg,
parasubcontractlist.balanced,
parasubcontractlist.linked,
CASE WHEN payment.kpaymenttransmission IS NOT NULL THEN 'S' ELSE 'N' END, --- transmittedbalance,
paymenttransmission.transmissiondate 
FROM parasubcontractlist
LEFT OUTER JOIN  payroll 
	ON payroll.idcon = parasubcontractlist.idcon
	AND payroll.fiscalyear = parasubcontractlist.ayear
	AND payroll.npayroll = (select max(npayroll) FROM payroll cedconguaglio where 
								cedconguaglio.idcon=parasubcontractlist.idcon 
							AND cedconguaglio.fiscalyear = parasubcontractlist.ayear  
						    AND cedconguaglio.flagbalance = 'S' )	
	AND payroll.flagbalance = 'N' 
	LEFT OUTER JOIN expensepayroll ON payroll.idpayroll=expensepayroll.idpayroll
	LEFT OUTER JOIN expenselast ON expenselast.idexp in
   (select expenselink.idchild from expenselink with (nolock)  where expenselink.idparent=expensepayroll.idexp)
	LEFT OUTER JOIN payment on payment.kpay=expenselast.kpay
	LEFT OUTER JOIN paymenttransmission on paymenttransmission.kpaymenttransmission=payment.kpaymenttransmission
	AND paymenttransmission.ypaymenttransmission = parasubcontractlist.ayear 
	GO
