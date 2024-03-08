
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_listing_proceed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_listing_proceed]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE [exp_listing_proceed]
(
	@ayear int,
	@unified varchar(1)
)
AS BEGIN
/* Versione 1.0.1 del 12/09/2007 ultima modifica: PINO */

CREATE TABLE #proceeds
(
	npro int,
	adate datetime,
	printdate datetime,
	transmissiondate datetime,
	kind varchar(20),
	amount decimal(23,6),
	codefin varchar(50),
	finance varchar(150),
	codeupb varchar(50),
	upb varchar(150),
	description varchar(150),
  	registry varchar(100),
	nmov int
)

IF @unified = 'N'
BEGIN
	INSERT INTO #proceeds
	(
		npro, adate, printdate, transmissiondate,
		kind, amount, codefin,finance,codeupb, upb,
		description, registry, nmov
	)
	SELECT 
		P.npro, P.adate, P.printdate, PT.transmissiondate,
		CASE
			when (( IT.flag & 1)=0) then 'C'
			when (( IT.flag & 1)=1) then 'R'
		End,
		IY.amount,-- I.amount, 
		F.codefin,F.title, U.codeupb, U.title, 
		I.description, R.title, I.nmov
	FROM incomelast IL
	JOIN income I
		ON I.idinc = IL.idinc
	JOIN incomeyear IY
		ON IY.idinc = IL.idinc
	JOIN incometotal IT
		ON IT.idinc = I.idinc
	JOIN fin F
		ON F.idfin = IY.idfin 
	JOIN upb U
		ON U.idupb = IY.idupb 
	JOIN registry R
		ON R.idreg = I.idreg
	JOIN proceeds P
		ON IL.kpro = P.kpro
	LEFT OUTER JOIN proceedstransmission PT
		ON PT.kproceedstransmission = P.kproceedstransmission
	WHERE I.ymov = @ayear
END
ELSE
BEGIN
	INSERT INTO #proceeds
	(
		npro, adate, printdate, transmissiondate,
		kind, amount, codefin,finance,codeupb, upb, registry
	)
	SELECT 
		P.npro, P.adate, P.printdate, PT.transmissiondate,
		case P.flag&7 
			when 1 then 'C' 
			when 2 then 'R' 
			when 4 then 'M' 
		end,
		ISNULL(SUM(IY.amount),0),-- ISNULL(SUM(E.amount),0),
		F.codefin, F.title, U.codeupb, U.title, R.title
	FROM incomelast IL
	JOIN income I
		ON I.idinc = IL.idinc
	JOIN incomeyear IY
		ON IY.idinc = I.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN upb U
		ON U.idupb = IY.idupb 
	JOIN registry R
		ON R.idreg = I.idreg
	JOIN incometotal IT
		ON IT.idinc = I.idinc
	JOIN proceeds P
		ON IL.kpro = P.kpro
	LEFT OUTER JOIN proceedstransmission PT
		ON PT.kproceedstransmission = P.kproceedstransmission
	WHERE I.ymov = @ayear
	GROUP BY P.npro,P.adate,P.printdate,PT.transmissiondate,P.flag&7,
	F.codefin,F.title, R.title,U.codeupb, U.title

END
UPDATE #proceeds SET kind = 'RESIDUO' WHERE kind = 'R'
UPDATE #proceeds SET kind = 'COMPETENZA' WHERE kind = 'C'
SELECT 
	npro AS 'Numero Reversale',	 	
	adate AS 'Data Contabile',		
	printdate AS 'Data Stampa',        	
    	transmissiondate AS 'Data Trasmissione', 	
	kind AS 'Tipo Incasso',		
	amount AS 'Importo Lordo',	        
	codefin AS 'Cod. Capitolo',		
	finance as 'Capitolo',
	codeupb as 'Cod. UPB',
	upb as 'UPB',
    description AS 'Descrizione',             
	registry AS 'Versante',
	nmov AS 'Numero Movimento'
FROM #proceeds
ORDER BY npro
       	
END    


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
