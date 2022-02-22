
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitpagamentidagirofondare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitpagamentidagirofondare]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE exp_sitpagamentidagirofondare
	@ayear int,
	@idtreasurersource   int=null,		 --> Cassiere del Dipartimento
	@showdetail char(1)
	AS
BEGIN
-- Deve essere specificato almeno un cassiere
DECLARE @Dettagli TABLE(
	idtreasurersource int, idtreasurerdest int,
	incassi decimal(19,2), yinc smallint, ninc int,
	pagamenti decimal(19,2), yexp smallint, nexp int,
	girofondi decimal(19,2),ytransfer smallint, ntransfer int
 )

-- Pagamenti
INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, pagamenti, yexp, nexp)
	SELECT 
		P.idtreasurer,	-- > è il Source, ossia il cassiere che ha pagato
		U.idtreasurer,
		EL.amount,
		EL.ymov,
		EL.nmov
	FROM  expenselastview EL
	join upb U
		on EL.idupb = U.idupb
	join payment P
		on P.kpay = EL.kpay
	WHERE P.ypay = @ayear 
	and U.idtreasurer <> P.idtreasurer
	and (P.idtreasurer = @idtreasurersource)


INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, pagamenti, yexp, nexp)
	SELECT 
		U.idtreasurer,
		P.idtreasurer,
		- EL.amount,
		EL.ymov,
		EL.nmov
	FROM  expenselastview EL
	join upb U
		on EL.idupb = U.idupb
	join payment P
		on P.kpay = EL.kpay
	WHERE P.ypay = @ayear 
	and U.idtreasurer <> P.idtreasurer
	and (U.idtreasurer = @idtreasurersource)


-- Incassi
INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, incassi, yinc, ninc)
	SELECT 
		P.idtreasurer,--> ho incassato su P, invece che su U, quindi P deve ridare i soldi a U
		U.idtreasurer,
		EL.amount,
		EL.ymov,
		EL.nmov
	FROM  incomelastview EL
	join upb U
		on EL.idupb = U.idupb
	join proceeds P
		on P.kpro = EL.kpro
	WHERE P.ypro = @ayear 
	and U.idtreasurer <> P.idtreasurer
	and (P.idtreasurer = @idtreasurersource)


INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, incassi, yinc, ninc)
	SELECT 
		U.idtreasurer,
		P.idtreasurer,
		- EL.amount,
		EL.ymov,
		EL.nmov
	FROM  incomelastview EL
	join upb U
		on EL.idupb = U.idupb
	join proceeds P
		on P.kpro = EL.kpro
	WHERE P.ypro = @ayear 
	and U.idtreasurer <> P.idtreasurer
	and (U.idtreasurer = @idtreasurersource)


INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, girofondi, ytransfer, ntransfer)
	SELECT 
		idtreasurersource,
		idtreasurerdest,
		amount,
		ytransfer, 
		ntransfer
	FROM moneytransfer 
	WHERE ytransfer  = @ayear
		and (idtreasurersource = @idtreasurersource) 
		and (transferkind = 'G')

	
INSERT INTO @Dettagli(idtreasurersource, idtreasurerdest, girofondi, ytransfer, ntransfer)
	SELECT 
		idtreasurerdest,
		idtreasurersource,
		- amount,
		ytransfer, 
		ntransfer
	FROM moneytransfer 
	WHERE ytransfer  = @ayear
		and (idtreasurerdest = @idtreasurersource) 
		and (transferkind = 'G')

if (@showdetail = 'S')
Begin
	SELECT 
		isnull(T1.header, T1.description) as 'Cassiere Principale',
		D.yexp as 'Eserc.Pagamento',
		D.nexp as 'Num.Pagamento',
		case when (D.pagamenti >0) then D.pagamenti else null end as 'Crediti per Pagamenti',
		case when (D.pagamenti <0) then -(D.pagamenti) else null end as 'Debiti per Pagamenti',
		D.yinc as 'Eserc.Incasso',
		D.ninc as 'Num.Incasso',
		case when (D.incassi<0) then -(D.incassi) else null end as 'Crediti per Incassi',
		case when (D.incassi>0) then D.incassi else null end as 'Debiti per Incassi',
		D.ytransfer as  'Eserc.Girofondo',
		D.ntransfer as  'Num.Girofondo',
		case when (D.girofondi>0) then D.girofondi else null end as 'Girofondi effettuati',
		case when (D.girofondi<0) then -(D.girofondi) else null end as 'Girofondi ricevuti',
		isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
	FROM  @Dettagli D
	JOIN treasurer T1
		on D.idtreasurersource = T1.idtreasurer 
	left outer JOIN treasurer T2
		on D.idtreasurerdest = T2.idtreasurer 
	order by isnull(T1.header, T1.description), isnull(T2.header, T2.description),D.nexp, D.ninc, D.ntransfer
End
Else
Begin
			
			SELECT 
				isnull(T1.header, T1.description) as 'Cassiere Principale',
				case when (sum(D.pagamenti) >0) then sum(D.pagamenti) else null end as 'Crediti per Pagamenti',
				case when (sum(D.pagamenti) <0) then -(sum(D.pagamenti)) else null end as 'Debiti per Pagamenti',
				case when (sum(D.incassi)<0) then -(sum(D.incassi)) else null end as 'Crediti per Incassi',
				case when (sum(D.incassi)>0) then sum(D.incassi) else null end as 'Debiti per Incassi',

				--case when (sum(D.girofondi) >0) then sum(D.girofondi)  else null end as 'Girofondi effettuati',
				(select sum(D1.girofondi) from @Dettagli D1
				where D1.idtreasurersource = D.idtreasurersource and D1.idtreasurerdest = D.idtreasurerdest
				group by D1.girofondi
				having D1.girofondi>0) as  'Girofondi effettuati',

				--case when (sum(D.girofondi) <0) then -(sum(D.girofondi) ) else null end as 'Girofondi ricevuti',				
				- (select sum(D1.girofondi) from @Dettagli D1
				where D1.idtreasurersource = D.idtreasurersource and D1.idtreasurerdest = D.idtreasurerdest
				group by D1.girofondi
				having D1.girofondi<0) as 'Girofondi ricevuti',

				case when (	sum(isnull(D.pagamenti,0)-isnull(D.incassi,0)+ isnull(D.girofondi,0))>0) 
					then sum(isnull(D.pagamenti,0)-isnull(D.incassi,0)+ isnull(D.girofondi,0))
					else null end
					as 'Girofondi da ricevere',
				case when (	sum(isnull(D.pagamenti,0)-isnull(D.incassi,0)+ isnull(D.girofondi,0))<0) 
					then -( sum(isnull(D.pagamenti,0)-isnull(D.incassi,0)+ isnull(D.girofondi,0)) )
					else null end
					as 'Girofondi da effettuare',
				isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
			FROM  @Dettagli D
			JOIN treasurer T1
				on D.idtreasurersource = T1.idtreasurer 
			left outer JOIN treasurer T2
				on D.idtreasurerdest = T2.idtreasurer 
			group by isnull(T1.header, T1.description),D.idtreasurerdest,  isnull(T2.header, T2.description),D.idtreasurersource
			order by isnull(T1.header, T1.description), isnull(T2.header, T2.description)

End



	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

	
