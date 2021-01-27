
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_movforinps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_movforinps]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE             PROCEDURE [exp_movforinps]
(
	@ycommunication int,
	@startmonth int,
	@stopmonth int,
        @unified char(1)
)
AS BEGIN
/* Versione 1.0.1 del 18/11/2008 ultima modifica: SARA */

--         exec exp_movforinps 2008, 2,2,'S'


--- La data contabile per emens_daticollaboratore deve valere NULL, sarà valorizzata in futuro quando sarà implementato l'annullamento.
DECLARE @adate datetime
SET @adate = NULL

CREATE TABLE #main_employ
(
        departmentname varchar(500), 
	idreg int,
	cf_employ varchar(16),
	surname varchar(50),
	forename varchar(20),
	idemenscontractkind varchar(2),
	activitycode varchar(2),
	taxable decimal(19,2),
	rate double precision,
	idotherinsurance varchar(3),
	start datetime,
	stop datetime,
	calamitycode varchar(2),
	certificationcode varchar(3),
	taxcode int,
	idexp int,
	ycommunication int,
	mcommunication int,
        tax varchar(50),
        ymov int,
        nmov int, 
        expensephase varchar(50),
        idser int,
        service varchar(50),       
	ypay int,
        npay int,
	ypaymenttransmission int,
	npaymenttransmission int,
        competencydate datetime
)
DECLARE @parentsp char(1)
SET @parentsp = 'X'

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
							WHERE (start is null or start <= @ycommunication ) 
							AND ( stop is null or stop >= @ycommunication)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)

        IF (@unified='N') SET @iddbdepartment = user-- Se non deve consolidare, esegue la sp per 'user' ed esce dal WHILE tramite il BREAK.
	SET @dip_nomesp = @iddbdepartment + '.emens_daticollaboratore'

        INSERT INTO #main_employ
        (
                departmentname,
		idreg,
		cf_employ,
		surname,
		forename,
		idemenscontractkind,
		activitycode,
		taxable,
		rate,
		idotherinsurance,
		start,
		stop,
		calamitycode,
		certificationcode,
		taxcode,
		idexp,
		ycommunication,
		mcommunication,
                tax,
                ymov,
                nmov, 
                expensephase,
                idser,
                service,       
        	ypay,
	        npay,
        	ypaymenttransmission,
        	npaymenttransmission,
	        competencydate
        )
        EXEC @dip_nomesp @ycommunication,@startmonth,@stopmonth,@parentsp,@adate
        IF (@unified = 'N') BREAK -- Se non deve consolidare esegue solo la sp per 'user'.

        FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end

IF (@unified = 'N')
Begin
        SELECT 
        	surname AS 'Cognome',
        	forename AS 'Nome',
        	cf_employ AS 'Cod. Fisc.',
        	ymov AS 'Eserc. Mov.',
        	nmov AS 'Num. Mov.',
        	expensephase AS 'Fase',
        	taxable AS 'Imponibile',
        	rate AS 'Aliquota',
        	start AS 'Data Inizio',
        	stop AS 'Data Fine',
        	taxcode AS 'Cod. Riten.',
        	tax AS 'Ritenuta',
        	idser AS 'Cod. Prest.',
        	service AS 'Prestazione',
        	ycommunication AS 'Anno Rif.',
        	mcommunication AS 'Mese Rif.',
        	ypay AS 'Eserc. Mandato',
        	npay AS 'Num. Mandato',
        	ypaymenttransmission AS 'Eserc. Elenco Trasm.',
        	npaymenttransmission AS 'Num. Elenco Trasm.',
        	competencydate AS 'Data Trasmissione'
        FROM #main_employ
        ORDER BY ycommunication,mcommunication
End
ELSE
Begin
        SELECT 
                departmentname as 'Dipartimento',
        	surname AS 'Cognome',
        	forename AS 'Nome',
        	cf_employ AS 'Cod. Fisc.',
        	ymov AS 'Eserc. Mov.',
        	nmov AS 'Num. Mov.',
        	expensephase AS 'Fase',
        	taxable AS 'Imponibile',
        	rate AS 'Aliquota',
        	start AS 'Data Inizio',
        	stop AS 'Data Fine',
        	taxcode AS 'Cod. Riten.',
        	tax AS 'Ritenuta',
        	idser AS 'Cod. Prest.',
        	service AS 'Prestazione',
        	ycommunication AS 'Anno Rif.',
        	mcommunication AS 'Mese Rif.',
        	ypay AS 'Eserc. Mandato',
        	npay AS 'Num. Mandato',
        	ypaymenttransmission AS 'Eserc. Elenco Trasm.',
        	npaymenttransmission AS 'Num. Elenco Trasm.',
        	competencydate AS 'Data Trasmissione'
        FROM #main_employ
        ORDER BY departmentname,ycommunication,mcommunication
End


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
