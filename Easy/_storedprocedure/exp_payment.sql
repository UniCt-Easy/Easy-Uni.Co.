
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE            PROCEDURE [exp_payment]
@ayear int,
@start datetime,
@stop  datetime,
@idupb varchar(36),
@showchildupb char(1),
@codefin varchar(50),
@idman int
AS BEGIN 

SET @codefin = ISNULL(@codefin,'')+'%'
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb+'%' 
END

DECLARE @maxphase tinyint
SELECT @maxphase =  MAX(nphase) FROM expensephase
SELECT 
    MAN.title AS Responsabile,
	F.codefin AS 'Codice Bilancio',
	F.title AS 'Denom. Bilancio' ,
	PHASE.description AS Fase,
	EX.ymov  AS 'Eserc. Movimento',
	EX.nmov AS 'Num. Movimento',
	EX.description AS Descrizione,
	EXY.amount AS 'Importo Originale',
	EXT.curramount AS 'Importo Corrente',
	EX.doc AS 'Documento collegato',
	EX.docdate AS 'Data Documento collegato',
	EX.adate AS 'Data Contabile Movimento',
	EX.expiration AS 'Data Scadenza',
	REG.title AS Percipiente,	
	U.codeupb AS 'Codice UPB',
	U.title AS UPB,
	SER.description AS Prestazione,
	EXL.servicestart AS 'Data Inizio Prest.',
	EXL.servicestop AS 'Data Fine Prest.',
   	CASE
		when (( EXT.flag & 1)=0) then 'C/Residui'
		when (( EXT.flag & 1)=1) then 'C/Competenza' 
	End AS Competenza,
	PAY.ypay AS 'Eserc. Mandato',
	PAY.npay AS 'Num. Mandato',
	PAY.adate AS 'Data Contabile Mandato',
    PAY.printdate AS 'Data Stampa Mandato',
    TX.transmissiondate AS 'Data Trasm. Mandato',
	TX.ypaymenttransmission AS 'Eserc. Elenco Trasm.',
	TX.npaymenttransmission AS 'Num. Elenco Trasm.'
FROM expense EX (NOLOCK)
JOIN expensephase PHASE (NOLOCK)
	ON PHASE.nphase = EX.nphase
JOIN expenseyear EXY(NOLOCK)
	ON EXY.idexp = EX.idexp
JOIN expensetotal EXT(NOLOCK)
	ON EXT.idexp = EX.idexp
	AND EXT.ayear = EXY.ayear
JOIN expenselast EXL(NOLOCK)
	ON EXL.idexp = EX.idexp
LEFT OUTER JOIN fin F (NOLOCK)
	ON F.idfin = EXY.idfin
LEFT OUTER JOIN upb U(NOLOCK)
	ON U.idupb = EXY.idupb
LEFT OUTER JOIN registry REG(NOLOCK)
	ON REG.idreg = EX.idreg
LEFT OUTER JOIN manager MAN(NOLOCK) 
	ON MAN.idman = EX.idman
LEFT OUTER JOIN service SER(NOLOCK)
	ON SER.idser = EXL.idser
LEFT OUTER JOIN payment PAY(NOLOCK)
	ON EXL.kpay = PAY.kpay 
LEFT OUTER JOIN paymenttransmission TX(NOLOCK)
	ON PAY.kpaymenttransmission = TX.kpaymenttransmission 
WHERE EX.adate BETWEEN @start AND @stop 
	AND EX.nphase = @maxphase	
	AND EXY.ayear = @ayear 
	AND F.codefin LIKE @codefin 
	AND (EX.idman = @idman or @idman is null)
	AND (EXY.idupb LIKE @idupb)
ORDER BY EX.idman, F.codefin, EX.nmov
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
