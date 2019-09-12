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