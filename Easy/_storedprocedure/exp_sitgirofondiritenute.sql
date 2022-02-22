
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_sitgirofondiritenute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_sitgirofondiritenute]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE exp_sitgirofondiritenute
	@ayear int,
	@idtreasurersource   int = null, --> Cassiere del Dipartimento
	@showdetail char(1)
	--@idtreasurerdest     int  --> Cassiere dell'Amministrazione
	AS
BEGIN
declare @idtreasurerdest int
select @idtreasurerdest = idtreasurer from treasurer where flagdefault = 'S'

	DECLARE @Dettagli TABLE(
			idtreasurer int, 
			taxdescription varchar(50),
			employtax decimal(19,2), admintax decimal(19,2),
			ymov smallint, nmov int,
			ytaxpay smallint, ntaxpay int, datetaxpay datetime, 
			transferamount decimal(19,2), ntransfer int, transferadate datetime
			)
	INSERT INTO @Dettagli(idtreasurer, taxdescription, employtax, admintax, ymov, nmov, ytaxpay, ntaxpay, datetaxpay)
		SELECT 
			ET.idtreasurer,
			ET.description,
			isnull(ET.employtax,0),
			isnull(ET.admintax,0),
			E.ymov, E.nmov,
			ET.ytaxpay, ET.ntaxpay,
			ET.datetaxpay
		FROM  expensetaxview ET
		JOIN expense E
			on ET.idexp = E.idexp
		WHERE ET.ayear = @ayear 
			and (ET.idtreasurer = @idtreasurersource or @idtreasurersource is null)

	INSERT INTO @Dettagli(idtreasurer, transferamount, ntransfer, transferadate)
		SELECT idtreasurersource,
			isnull(amount,0),
			ntransfer,
			adate
		FROM moneytransfer 
		WHERE ytransfer  = @ayear
			and (idtreasurersource = @idtreasurersource or  @idtreasurersource is null) 
			and (idtreasurerdest = @idtreasurerdest) 
			and (transferkind = 'R')

	INSERT INTO @Dettagli(idtreasurer, transferamount, ntransfer, transferadate)
		SELECT idtreasurersource,
			- isnull(amount,0),
			ntransfer,
			adate
		FROM moneytransfer 
		WHERE ytransfer  = @ayear
			and (idtreasurersource = @idtreasurerdest or  @idtreasurersource is null) 
			and (idtreasurerdest = @idtreasurersource ) 
			and (transferkind = 'R')

if (@showdetail = 'S')
Begin
		SELECT 
			isnull(T.header, T.description) as 'Cassiere Dipartimento',
			D.ytaxpay as 'Eserc.Liquidazione Imposte',
			D.ntaxpay as 'Num.Liquidazione Imposte',
			D.datetaxpay as 'Data Liquidazione Imposte',
			taxdescription as 'Imposta',
			D.employtax as 'Imposta c/dip.',
			D.admintax as  'Imposta c/amm.',
			D.ntransfer as  'Num.Girofondo',
			D.transferadate as 'Data Girofondo',
			D.transferamount as 'Importo Girofondato'
		FROM  @Dettagli D
		JOIN treasurer T
			on D.idtreasurer = T.idtreasurer 
		order by isnull(T.header, T.description), isnull(D.datetaxpay, D.transferadate)

End
Else
Begin
		SELECT 
			isnull(T.header, T.description) as 'Cassiere Dipartimento',
			sum(isnull(D.admintax,0) + isnull(D.employtax,0)) as 'Imposte Liquidate',
			sum(D.transferamount) as 'Importo Girofondato dal Dipartimento',
			sum(isnull(D.admintax,0)+ isnull(D.employtax,0)- isnull(D.transferamount,0)) as 'Importo da Girofondare'
		FROM @Dettagli D
		JOIN treasurer T
			on D.idtreasurer = T.idtreasurer 
		group by isnull(T.header, T.description)
		order by isnull(T.header, T.description)
End
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec [exp_sitgirofondiritenute] 2014, null, 'S'
--go
--exec [exp_sitgirofondiritenute] 2014, 8, 'N'
--select * from treasurer where idtreasurer = 8
--go

