
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_listing_payment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_listing_payment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [exp_listing_payment]
(
	@ayear int,
	@unified varchar(1)
)
AS BEGIN

/* Versione 1.0.1 del 12/09/2007 ultima modifica: PINO */

CREATE TABLE #payment
(
	npay int,
	nmov int,
	kind varchar(20),
	adate datetime,
	printdate datetime,
	transmissiondate datetime,
	amount decimal(23,6),
	description varchar(150),
	codefin varchar(50),
	finance varchar(150),
	codeupb varchar(50),
	upb varchar(150),
	registry varchar(100)
)
IF @unified = 'N'
BEGIN
	INSERT INTO #payment
	(
		npay, adate, printdate, transmissiondate,
		kind, amount, codefin,finance,codeupb, upb,
		description, registry, nmov
	)
	SELECT 
		P.npay, P.adate, P.printdate, PT.transmissiondate,
		CASE
			when (( ET.flag & 1)=0) then 'C'
			when (( ET.flag & 1)=1) then 'R'
		End,
		EY.amount,-- E.amount, 
		F.codefin,F.title, U.codeupb, U.title, 
		E.description, R.title, E.nmov
	FROM expenselast EL
	JOIN expense E
		ON E.idexp = EL.idexp
	JOIN expenseyear EY
		ON EY.idexp = EL.idexp
	JOIN expensetotal ET
		ON ET.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin 
	JOIN upb U
		ON U.idupb = EY.idupb 
	JOIN registry R
		ON R.idreg = E.idreg
	JOIN payment P
		ON EL.kpay = P.kpay
	LEFT OUTER JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
	WHERE E.ymov = @ayear
END
ELSE
BEGIN
	INSERT INTO #payment
	(
		npay, adate, printdate, transmissiondate,
		kind, amount,codefin,finance,codeupb, upb, registry
	)
	SELECT 
		P.npay, P.adate, P.printdate, PT.transmissiondate,
		case p.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		ISNULL(SUM(EY.amount),0),-- ISNULL(SUM(E.amount),0),
		F.codefin,F.title, U.codeupb, U.title, R.title
	FROM expenselast EL
	JOIN expense E
		ON E.idexp = EL.idexp
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	JOIN upb U
		ON U.idupb = EY.idupb 
	JOIN registry R
		ON R.idreg = E.idreg
	JOIN expensetotal ET
		ON ET.idexp = E.idexp
	JOIN payment P
		ON EL.kpay = P.kpay
	LEFT OUTER JOIN paymenttransmission PT
		ON PT.kpaymenttransmission = P.kpaymenttransmission
	WHERE E.ymov = @ayear
	GROUP BY P.npay,P.adate,P.printdate,PT.transmissiondate,p.flag&7,
	F.codefin,F.title, R.title,U.codeupb, U.title

END

UPDATE #payment SET kind = 'RESIDUO' WHERE kind = 'R'
UPDATE #payment SET kind = 'COMPETENZA' WHERE kind = 'C'              	
SELECT 
	npay as 'Numero Mandato',
	adate as 'Data Contabile',
	printdate as 'Data Stampa',
    	transmissiondate as 'Data Trasmissione',
	kind as 'Tipo Pagamento',
	amount as 'Importo Lordo',
	codefin AS 'Cod. Capitolo',		
	finance as 'Capitolo',
	codeupb as 'Cod. UPB',
	upb as 'UPB',
    description as 'Descrizione',
	registry as 'Percipiente',
	nmov as 'Numero Movimento'
FROM #payment
ORDER BY npay
	       	
END    


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
