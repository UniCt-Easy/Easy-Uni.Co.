
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_dipendentiassimilato_singlecheck]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_dipendentiassimilato_singlecheck]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_interscambio_csa_dipendentiassimilato_singlecheck(
	@ayear int,
	@start datetime,
	@stop datetime
)
AS 
/*
exec exp_interscambio_csa_dipendentiassimilato_singlecheck 2009

 */
BEGIN

DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento'  
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe nel dip.'+user)


create table #Compensi(
	ycon int,
	ncon int,
	idreg int,
	kind varchar(50)
)
	
insert into #Compensi( 
	ycon, ncon, idreg, kind
)	
	SELECT C.ycon, C.ncon, C.idreg, 'co.co.co./Borsisti'
	FROM expensepayroll EP
		JOIN payroll P
			on P.idpayroll = EP.idpayroll
		JOIN parasubcontract C
			ON C.idcon = P.idcon
		JOIN parasubcontractyear CY
			ON C.idcon = CY.idcon AND CY.ayear = @ayear
		JOIN expenselink ELK
			ON ELK.idparent = EP.idexp
		JOIN expenselast EL
			on EL.idexp = ELK.idchild
		JOIN payment 
			on payment.kpay = EL.kpay
		JOIN service S
			ON S.idser = C.idser
		WHERE payment.ypay = @ayear
			AND C.idregistrylegalstatus IS NULL
			AND payment.kpaymenttransmission IS NOT NULL
			AND payment.adate between @start and @stop
			AND S.voce8000 is not null
			AND 
			((select count(R2.csa_role) 
			FROM registrylegalstatus R2
			where isnull(R2.active, 'S')='S'
				and R2.idreg = C.idreg
				and R2.csa_compartment is not null
				and R2.csa_role is not null) >= 1)
		GROUP BY C.ycon, C.ncon, C.idreg	

INSERT INTO #Compensi(ycon, ncon, idreg, kind)
SELECT W.ycon, W.ncon, W.idreg, 'c/Terzi'
		FROM wageaddition W
		JOIN wageadditionyear WY
			ON W.ycon = WY.ycon AND W.ncon = WY.ncon 
		JOIN expensewageaddition EW
			ON EW.ncon = W.ncon	AND EW.ycon = W.ycon 
		join expenselink ELK
			ON ELK.idparent = EW.idexp
		join expenselast EL
			on EL.idexp = ELK.idchild
		join payment P
			on P.kpay = EL.kpay
		JOIN service S
			ON S.idser = W.idser
		WHERE  P.ypay = @ayear
			AND W.idregistrylegalstatus IS NULL
			AND P.kpaymenttransmission IS NOT NULL
			AND P.adate between @start and @stop
			AND S.voce8000 is not null
			AND idregistrylegalstatus is null and 
			((SELECT count(R2.csa_role) 
				FROM registrylegalstatus R2
				where isnull(R2.active, 'S')='S'
					and R2.idreg = W.idreg
					and R2.csa_compartment is not null
					and R2.csa_role is not null) >= 1)





SELECT 
		@departmentname as departmentname,
		idreg,
		ncon,
		ycon,
		kind
FROM #Compensi






END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




