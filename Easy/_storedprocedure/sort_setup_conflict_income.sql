
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sort_setup_conflict_income]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sort_setup_conflict_income]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE         PROCEDURE [sort_setup_conflict_income] 
(
	@ayear int
)
AS
CREATE TABLE #tmp
(
	[idautosort1] [int] NOT NULL,
	[idfin1] [int] NULL,
	[idupb1] [varchar](36) NULL,
	[idsorkindreg1] [int] NULL,
	[idsorreg1] [int] NULL,
	[idman1][int] NULL,
	[idsorkind1] [int] NOT NULL ,
	[idsor1] [int] NOT NULL,
	[idautosort2] [int] NOT NULL,
	[idfin2] [int] NULL,
	[idupb2] [varchar](36) NULL,
	[idsorkindreg2] [int] NULL,
	[idsorreg2][int] NULL,
	[idman2][int] NULL,
	[idsorkind2] [int] NOT NULL ,
	[idsor2] [int] NOT NULL 
)
--Mette in #tmp le righe di autoclass che hanno sottoinsiemi in comune con altre righe
-- filtra per (A.idsor < B.idsor) per non prendere due volte lo stesso sottoinsieme
INSERT INTO #tmp
(
	idautosort1,idfin1,idupb1,idsorkindreg1,idsorreg1,idman1,idsorkind1,idsor1,
	idautosort2, idfin2,idupb2,idsorkindreg2,idsorreg2,idman2,idsorkind2,idsor2)
SELECT
	A.idautosort, FA.idparent, A.idupb, A.idsorkindreg, A.idsorreg, A.idman, A.idsorkind, A.idsor,
	B.idautosort, FB.idparent, B.idupb, B.idsorkindreg, B.idsorreg, B.idman, B.idsorkind, A.idsor 
FROM autoincomesorting A
JOIN autoincomesorting B
	ON A.idsorkind=B.idsorkind
LEFT OUTER JOIN finlink FA
	ON FA.idparent = A.idfin
LEFT OUTER JOIN finlink FB
	ON FB.idparent = B.idfin
LEFT OUTER JOIN sortinglink SA
	ON SA.idparent = A.idsorreg
LEFT OUTER JOIN sortinglink SB
	ON SB.idparent = B.idsorreg
WHERE (A.idsor < B.idsor)
	AND (A.ayear = @ayear)
	AND ((A.idupb IS NULL) OR (B.idupb IS NULL) OR (B.idupb LIKE A.idupb+'%') OR (A.idupb LIKE B.idupb+'%'))
	AND ((A.idfin IS NULL) OR (B.idfin IS NULL) OR (B.idfin = FA.idchild) OR (A.idfin = FB.idchild)) 
	AND ((A.idman IS NULL) OR (B.idman IS NULL) OR (B.idman = A.idman) )
	AND ((A.idsorkindreg IS NULL) OR (B.idsorkindreg IS NULL) OR 
	   ( (A.idsorkindreg = B.idsorkindreg) AND
	     ((A.idsorreg IS NULL) or (B.idsorreg IS NULL) or (B.idsorreg = SA.idchild) or (A.idsorreg = SB.idchild))
	   )
	)
--Estrae i sottoinsiemi effettivi ricalcolando le prime coordinate prendendo la più restrittiva tra la 1a e la 2a coordinata. Ossia
--  null -- null -------> null
--  A   --  null -------> A
--  null --  A   -------> A
-- AB  ---  A   -------> AB
UPDATE #tmp SET idfin1 = idfin2 
 	 from #tmp T
 	 JOIN finlink K
  		ON T.idfin1 = K.idparent  
   		AND T.idfin2 = K.idchild

UPDATE #tmp SET idfin1 = idfin2 WHERE idfin1 IS NULL
UPDATE #tmp SET idman1 = idman2 WHERE idman1 IS NULL
UPDATE #tmp SET idupb1 = idupb2 WHERE (idupb2 IS NOT NULL) AND (idupb2 IS NOT NULL) AND (idupb1 LIKE idupb2+'%')
UPDATE #tmp SET idupb1 = idupb2 WHERE idupb1 IS NULL


UPDATE #tmp SET idsorreg1 = idsorreg2
FROM #tmp T
JOIN sortinglink S
	ON T.idsorreg1 = S.idparent
	AND T.idsorreg2 = S.idchild
WHERE T.idsorkindreg1=T.idsorkindreg2

UPDATE #tmp SET idsorreg1= idsorreg2 WHERE (idsorkindreg1=idsorkindreg2) AND (idsorreg1 IS NULL) 
		
--Ora che ha tutti i sottoinsiemi, deve eliminare i sottoinsiemi che sono già presenti così come sono stati ricalcolati. Es.
-- A    null   B
-- null  C    null 
--- risultato A C B che è già (per esempio) presente come terna  ---> lo elimino
DELETE FROM #tmp
WHERE (
	SELECT COUNT(*)
	FROM autoincomesorting A
	WHERE (#tmp.idsorkind1 = A.idsorkind)
		AND (A.ayear= @ayear)
		AND (((A.idfin IS NULL) AND ( #tmp.idfin1 IS NULL)) or (A.idfin=#tmp.idfin1))
		AND (((A.idman IS NULL)and( #tmp.idman1 IS NULL)) or (A.idfin=#tmp.idman1))
		AND (((A.idupb IS NULL)and( #tmp.idupb1 IS NULL)) or (A.idupb=#tmp.idupb1))
		AND (((A.idsorkindreg IS NULL)and( #tmp.idsorkindreg1 IS NULL)) or (A.idsorkindreg=#tmp.idsorkindreg1))
		AND (((A.idsorreg IS NULL)and( #tmp.idsorreg1 IS NULL)) or (A.idsorreg=#tmp.idsorreg1)) 
			) >1
SELECT
	@ayear as 'Esercizio',
	b1.codefin as 'Cod.Bil.',
	u1.codeupb as 'Cod. U.P.B.',
	tc1.description as 'Tipo class Anagrafica',
	cc1.sortcode as 'Cod.Class. Anagrafica',
	T.idsorkind1 as 'Tipo Class. Movimenti'
FROM #tmp T
LEFT OUTER JOIN fin b1
	ON b1.idfin = T.idfin1
LEFT OUTER JOIN upb u1
	ON u1.idupb = T.idupb1
LEFT OUTER JOIN sortingkind tc1
	ON tc1.idsorkind = T.idsorkindreg1  
LEFT OUTER JOIN sorting cc1
	ON cc1.idsorkind = T.idsorkindreg1
	AND cc1.idsor= T.idsorreg1 
GROUP BY b1.codefin, u1.codeupb, idsorkind1, tc1.description,cc1.sortcode



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

