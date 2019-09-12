if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interventisostitutivi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interventisostitutivi]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE exp_interventisostitutivi(
	@ayear 			int
	) 
AS BEGIN

select  
	E.ymov as 'Eserc.Pagamento',
	E.nmov as 'Num.Pagamento',
	P.npay as 'Num.Mandato',
	ET.curramount as 'Importo pagamento',
	isnull(T.header, T.description) as 'Cassiere',
	PT.transmissiondate as 'Data trasmissione mandato',
	I.nmov as 'Num.Incasso',
	C.npro as 'Num.Reversale',
	F.idf24ep as 'Num.F24EP',
	DATENAME(month,F.nmonth) as 'Mese dichiarazione F24EP'
from	expense E
join expenselast EL
	on E.idexp = EL.idexp
join expenseclawbackview R
	on E.idexp = R.idexp
join payment P
	on P.kpay = EL.kpay
join paymenttransmission PT
	on P.kpaymenttransmission = PT.kpaymenttransmission
join treasurer T
	on P.idtreasurer = T.idtreasurer
join expensetotal ET
	on E.idexp = ET.idexp
join income I
	on I.idpayment = R.idexp
join incomelast IL
	on I.idinc = IL.idinc
join f24ep F 
	on F.idf24ep = R.idf24ep
left outer join proceeds C
	on C.kpro = IL.kpro
left outer join proceedstransmission CT
	on C.kproceedstransmission = CT.kproceedstransmission
where E.ymov = @ayear
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


