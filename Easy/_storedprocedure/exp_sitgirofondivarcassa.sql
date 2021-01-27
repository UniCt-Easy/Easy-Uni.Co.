
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitgirofondivarcassa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitgirofondivarcassa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE exp_sitgirofondivarcassa
	@ayear int,
	@idtreasurersource   int = null, --> Cassiere del Dipartimento
	@showdetail char(1)
	AS
BEGIN
	
-- Deve essere specificato almeno un cassiere
DECLARE @Dettagli TABLE(
		idtreasurersource int, 
		idtreasurerdest int, 
		finvaramount decimal(19,2), nvar int, finvardate datetime,
		amount_in decimal(19,2), 
		amount_out decimal(19,2),
		ntransfer int, transferadate datetime
		)

	-- Storni di cassa
	INSERT INTO @dettagli(idtreasurersource, idtreasurerdest, finvaramount, nvar, finvardate)
		SELECT 
			( select top 1 FVD2.idtreasurer from finvardetailview FVD2
				where FVD2.yvar = FVD.yvar 
					and FVD2.nvar = FVD.nvar 
					and FVD2.amount<0
					) ,
			U.idtreasurer,
			FVD.amount,
			FV.nvar,
			FV.adate
		FROM finvar FV
		join finvardetail FVD
			on FV.yvar = FVD.yvar and FV.nvar = FVD.nvar
		join upb U
			on FVD.idupb = U.idupb
		WHERE FVD.yvar = @ayear 
		and FVD.amount >0
		and isnull(FV.moneytransfer,'N') = 'S'
		and FV.idfinvarstatus  = 5
		--and (U.idtreasurer = @idtreasurersource)
		and (select top 1 FVD2.idtreasurer from finvardetailview FVD2
			where FVD2.yvar = FVD.yvar and FVD2.nvar = FVD.nvar 
				and FVD2.amount<0) = @idtreasurersource


INSERT INTO @dettagli(idtreasurersource, idtreasurerdest, finvaramount,nvar, finvardate)
SELECT 
	U.idtreasurer,
	( select top 1 FVD2.idtreasurer from finvardetailview FVD2
		where FVD2.yvar = FVD.yvar 
			and FVD2.nvar = FVD.nvar 
			and FVD2.amount<0
			) ,
	- FVD.amount,
	FV.nvar,
	FV.adate
FROM finvar FV
join finvardetail FVD
	on FV.yvar = FVD.yvar and FV.nvar = FVD.nvar
join upb U
	on FVD.idupb = U.idupb
WHERE FVD.yvar = @ayear 
and FVD.amount >0
and isnull(FV.moneytransfer,'N') = 'S'
and FV.idfinvarstatus  = 5
and (U.idtreasurer = @idtreasurersource)
/*	and (select top 1 FVD2.idtreasurer from finvardetailview FVD2
		where FVD2.yvar = FVD.yvar and FVD2.nvar = FVD.nvar 
			and FVD2.amount<0) = @idtreasurersource*/
					


INSERT INTO @dettagli(idtreasurersource, idtreasurerdest, amount_out, ntransfer, transferadate)
	SELECT 
		idtreasurersource,
		idtreasurerdest,
		amount, 
		ntransfer,
		adate
	FROM moneytransfer 
	WHERE ytransfer  = @ayear
		and (idtreasurersource = @idtreasurersource) 
		and (transferkind = 'V')


INSERT INTO @dettagli(idtreasurersource, idtreasurerdest, amount_in, ntransfer, transferadate)
	SELECT 
		idtreasurerdest,
		idtreasurersource,
		- amount, 
		ntransfer,
		adate
	FROM moneytransfer 
	WHERE ytransfer  = @ayear
		and (idtreasurerdest = @idtreasurersource) 
		and (transferkind = 'V')

if (@showdetail = 'S')
Begin
	SELECT 
		@ayear as 'Esercizio',
		isnull(T1.header, T1.description) as 'Cassiere Principale',
		D.finvardate as 'Data Storno',
		D.nvar as 'Num.Variazione',
		D.finvaramount as 'Importo Stornato',
		D.transferadate as 'Data Girofondo',
		D.ntransfer as 'Num.Girofondo',
		D.amount_out as 'Girofondi effettuati',
		- D.amount_in as 'Girofondi ricevuti', -- > Va cambiato di segno quando viene visualizzato
		isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
	FROM  @dettagli D
	JOIN treasurer T1
		on D.idtreasurersource = T1.idtreasurer 
	JOIN treasurer T2
		on D.idtreasurerdest = T2.idtreasurer 
	order by isnull(T1.header, T1.description), isnull(T2.header, T2.description),D.finvardate, D.transferadate, D.nvar, D.ntransfer
End
Else
Begin
	SELECT 
			@ayear as 'Esercizio',
			isnull(T1.header, T1.description) as 'Cassiere Principale',
			sum(D.finvaramount) as 'Importo Stornato',
			sum(D.amount_out) as 'Girofondi effettuati',
			- sum(D.amount_in) as 'Girofondi ricevuti',	-- > Va cambiato di segno quando viene visualizzato
			case when (sum(isnull(D.finvaramount,0) - (  isnull(D.amount_out,0) + isnull(D.amount_in,0) )		)) > 0 then
					(sum(isnull(D.finvaramount,0) -  (  isnull(D.amount_out,0) + isnull(D.amount_in,0) )	)) else 0 end
					as 'Girofondi da effettuare',
			case when (sum(isnull(D.finvaramount,0) -  (  isnull(D.amount_out,0) + isnull(D.amount_in,0) )	)) < 0 then
					-(sum(isnull(D.finvaramount,0) -  (  isnull(D.amount_out,0) + isnull(D.amount_in,0) )	)) else 0 end
					as 'Girofondi da ricevere',
			isnull(T2.header, T2.description) as 'Cassiere di Riferimento'
		FROM  @dettagli D
		JOIN treasurer T1
			on D.idtreasurersource = T1.idtreasurer 
		JOIN treasurer T2
			on D.idtreasurerdest = T2.idtreasurer 
		group by isnull(T1.header, T1.description), isnull(T2.header, T2.description)
		order by isnull(T1.header, T1.description), isnull(T2.header, T2.description)

End
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
	
	
