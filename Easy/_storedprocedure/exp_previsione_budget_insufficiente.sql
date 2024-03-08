
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


 --setuser'amministrazione'
 
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_previsione_budget_insufficiente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_previsione_budget_insufficiente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [exp_previsione_budget_insufficiente] (
	@ayear int, 
	@kind  char(1), --- N solo differenze con valori reali, T --> Tutti
	@idupb varchar(36) = null,
	@codeacc varchar(38) = null
)
AS BEGIN
-- [exp_previsione_budget_insufficiente] 2022 , 'N'
-- CONTROLLO DA EFFETTUARE
-- La previsione di budget (del padre di livello minimo livello operativo)
-- del Conto %<account.codeacc>%  e  UPB  %<upb.codeupb>%  è INSUFFICIENTE!
-- DECLARE @ayear INT
-- SET @ayear = 2020
DECLARE @minlevelop INT 
SELECT  @minlevelop =  MIN(nlevel) FROM accountlevel WHERE ayear = @ayear and (flagusable='S')

--SELECT  @minlevelop
--SETUSER 'amministrazione'

CREATE TABLE #upbepexptotal
(idupb varchar(36), codeupb varchar(50), upb varchar(150), idacc varchar(38), 
							  codeacc varchar(50), account varchar(150),nphase int , total decimal(19,2))
CREATE INDEX index1 ON #upbepexptotal (idupb, idacc);
INSERT INTO  #upbepexptotal 
	(
		idupb, codeupb, upb, idacc, codeacc, account, nphase, total 
	)
	SELECT /*substring(F.idacc, 1, 4* @minlevelop),*/
		EY.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, E.nphase,
		ISNULL(
			(SELECT SUM(EY1.amount *
				    CASE WHEN isnull(E1.flagvariation,'N')='N' THEN 1 ELSE (-1) END)
			FROM epexpyear EY1 				
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				
			AND E1.nphase = E.nphase  ) 				
		,0) 
		 
		+ ISNULL(
			(SELECT SUM(EV1.amount*
				    CASE WHEN isnull(E1.flagvariation,'N')='N' THEN 1 ELSE (-1) END)
			FROM epexpyear EY1 				
			JOIN epexpvar EV1				ON EV1.idepexp= EY1.idepexp			and EV1.yvar =EY1.ayear
			JOIN epexp E1					ON E1.idepexp = EY1.idepexp
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				AND E1.nphase = E.nphase ) 				 				
		,0) 
	 
	FROM epexpyear EY
	JOIN epexp E
		ON E.idepexp = EY.idepexp
	LEFT OUTER JOIN epexptotal ET
		ON ET.idepexp = EY.idepexp
		AND ET.ayear = EY.ayear
	JOIN account  F
				ON EY.idacc LIKE F.idacc +'%' --substring(F.idacc, 1, 4* @minlevelop)
	JOIN upb  U
				ON EY.idupb = U.idupb   
	where 
			F.ayear = @ayear
			AND EY.ayear = @ayear 
			AND F.nlevel =  @minlevelop
			AND (F.codeacc =  @codeacc   or @codeacc IS NULL)
			AND (U.idupb = @idupb or @idupb IS NULL)
	GROUP BY EY.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, E.nphase

CREATE TABLE #upbepacctotal
(idupb varchar(36), codeupb varchar(50), upb varchar(150), idacc varchar(38), 
							  codeacc varchar(50), account varchar(150),nphase int,  total decimal(19,2))
CREATE INDEX index2 ON #upbepexptotal (idupb, idacc);
INSERT INTO  #upbepacctotal 
	(
		idupb, codeupb, upb, idacc, codeacc, account, nphase, total 
	)
	SELECT /*substring(F.idacc, 1, 4* @minlevelop),*/
	EY.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, E.nphase,
		ISNULL(
			(SELECT SUM(EY1.amount *
				    CASE WHEN isnull(E1.flagvariation,'N')='N' THEN 1 ELSE (-1) END)
			FROM epaccyear EY1 				
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				
			AND E1.nphase = E.nphase  ) 				
		,0) 
	
		+ ISNULL(
			(SELECT SUM(EV1.amount *  CASE WHEN isnull(E1.flagvariation,'N')='N' THEN 1 ELSE (-1) END)
			FROM epaccyear EY1 				
			JOIN epaccvar EV1				ON EV1.idepacc= EY1.idepacc			
			and EV1.yvar =EY1.ayear
			JOIN epacc E1					ON E1.idepacc = EY1.idepacc
			JOIN account FL					ON EY1.idacc LIKE FL.idacc+'%'
			WHERE EY1.idupb = EY.idupb 		AND F.idacc = FL.idacc				
			AND E1.nphase = E.nphase ) 				 				
		,0) 
	FROM epaccyear EY
	JOIN epacc E
		ON E.idepacc = EY.idepacc
	LEFT OUTER JOIN epacctotal ET
		ON ET.idepacc = EY.idepacc
		AND ET.ayear = EY.ayear
	JOIN account  F
				ON EY.idacc LIKE F.idacc +'%' --substring(F.idacc, 1, 4* @minlevelop)
	JOIN upb  U
				ON EY.idupb = U.idupb   
	where 
			F.ayear = @ayear
			AND EY.ayear = @ayear 
			AND F.nlevel =  @minlevelop
			AND (F.codeacc =  @codeacc   or @codeacc IS NULL)
			AND (U.idupb = @idupb or @idupb IS NULL)
	GROUP BY EY.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, E.nphase

 CREATE TABLE #previsioni(idupb varchar(36), codeupb varchar(50), upb varchar(150), idacc varchar(38), 
							  codeacc varchar(50), account varchar(150),
							  currentprev decimal(19,2),previsionvariation decimal(19,2), nphase int)
CREATE INDEX index3 ON #previsioni (idupb, idacc);
INSERT INTO #previsioni (idupb, codeupb, upb, idacc ,codeacc, account, currentprev, previsionvariation /*, nphase, epexptotal*/)
SELECT upbaccounttotal.idupb,upb.codeupb, upb.title,  upbaccounttotal.idacc, account.codeacc, account.title, 
ISNULL(upbaccounttotal.currentprev,0), 
ISNULL(upbaccounttotal.previsionvariation,0)
FROM   upbaccounttotal
JOIN   account on upbaccounttotal.idacc = account.idacc
JOIN   upb  on upbaccounttotal.idupb = upb.idupb
WHERE account.nlevel =  @minlevelop
AND  account.ayear = @ayear
AND (account.codeacc =  @codeacc   or @codeacc IS NULL)
AND (upb.idupb = @idupb or @idupb IS NULL)


CREATE TABLE #upbepacctotalReale
(idupb varchar(36), codeupb varchar(50), upb varchar(150), idacc varchar(38), 
							  codeacc varchar(50), account varchar(150),nphase int,  total decimal(19,2))
 
INSERT INTO  #upbepacctotalReale 
	(
		idupb, codeupb, upb, idacc, codeacc, account, nphase, total 
	)
select EP.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, EP.nphase,  EP.total 
from upbepacctotal EP
JOIN  account  F
 ON F.idacc  =  EP.idacc  
JOIN upb  U
 ON U.idupb = EP.idupb
WHERE F.nlevel =  @minlevelop
AND  F.ayear = @ayear
AND (F.codeacc =  @codeacc   or @codeacc IS NULL)
AND (U.idupb = @idupb or @idupb IS NULL)
 

CREATE TABLE #upbepexptotalReale
(idupb varchar(36), codeupb varchar(50), upb varchar(150), idacc varchar(38), 
							  codeacc varchar(50), account varchar(150),nphase int,  total decimal(19,2))
 
INSERT INTO  #upbepexptotalReale 
	(
		idupb, codeupb, upb, idacc, codeacc, account, nphase, total 
	)
select EP.idupb, U.codeupb, U.title, F.idacc, F.codeacc, F.title, EP.nphase,  EP.total 
from upbepexptotal EP
JOIN account  F
 ON F.idacc  = EP.idacc  
JOIN upb  U
 ON U.idupb = EP.idupb
WHERE F.nlevel =  @minlevelop
AND  F.ayear = @ayear
AND (F.codeacc =  @codeacc   or @codeacc IS NULL)
AND (U.idupb = @idupb or @idupb IS NULL)
 

--SELECT * FROM #previsioni
--SELECT * FROM #upbepexptotal
--SELECT * FROM #upbepacctotal
--SELECT * FROM #upbepacctotalReale
--SELECT * FROM #upbepexptotalReale
if (@kind = 'N') --- solo differenze con valori reali
BEGIN 
		SELECT
		CASE  when U.nphase = 1 then 'PreImp'  else 'Imp.'  END as 'Tipo Mov Budget',
		U.idupb as #idupb, 
		U.codeupb as 'cod. UPB', 
		U.upb as 'UPB', 
		U.idacc as #idacc,
		U.codeacc as 'Cod. Conto',
		U.account as 'Conto',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0) as 'Prev. Corrente',
		ISNULL(U.total,0) as 'Totale fase (Reale) ',
		ISNULL(UTot.total,0) as 'Totale fase (Totalizzatore)',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(U.total,0) as 'Prev. disponibile su fase (Reale)', 
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(UTot.total,0) as 'Prev. disponibile su fase (Totalizzatore)', 
		U.nphase as 'Fase'
		from #upbepexptotal U
		LEFT OUTER JOIN #upbepexptotalReale UTot  on U.idupb = UTot.idupb and UTot.idacc like U.idacc + '%'   AND   U.nphase = UTot.nphase 
		LEFT OUTER JOIN #previsioni P ON P.idupb = U.idupb AND P.idacc = U.idacc 
		WHERE  ISNULL(U.total,0) - ISNULL(UTot.total,0) <> 0
		-- order by 	U.codeupb ,	U.codeacc , U.nphase
		UNION ALL
		SELECT
		CASE  when U.nphase = 1 then 'PreAcc'  else 'Acc.'  END as 'Tipo Mov Budget',
		U.idupb as #idupb, 
		U.codeupb as 'cod. UPB', 
		U.upb as 'UPB', 
		U.idacc as #idacc,
		U.codeacc as 'Cod. Conto',
		U.account as 'Conto',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0) as 'Prev. Corrente',
		ISNULL(U.total,0) as 'Totale fase (Reale)',
		ISNULL(UTot.total,0) as 'Totale fase (Totalizzatore)',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(U.total,0) as 'Prev. disponibile su fase (Reale)', 
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(UTot.total,0) as 'Prev. disponibile su fase (Totalizzatore)', 
		U.nphase as 'Fase'
		from #upbepacctotal U 
		LEFT OUTER JOIN  #upbepacctotalReale UTot  on U.idupb = UTot.idupb and UTot.idacc like U.idacc + '%' AND   U.nphase = UTot.nphase 
		LEFT OUTER JOIN #previsioni P ON P.idupb = U.idupb AND P.idacc = U.idacc 
		WHERE     ISNULL(U.total,0) - ISNULL(UTot.total,0) <> 0
		 order by 	U.codeupb ,	U.codeacc , U.nphase
END
ELSE   --TUTTI
BEGIN 
		SELECT
		CASE  when U.nphase = 1 then 'PreImp'  else 'Imp.'  END as 'Tipo Mov Budget',
		U.idupb as #idupb, 
		U.codeupb as 'cod. UPB', 
		U.upb as 'UPB', 
		U.idacc as #idacc,
		U.codeacc as 'Cod. Conto',
		U.account as 'Conto',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0) as 'Prev. Corrente', 
		ISNULL(U.total,0) as 'Totale fase (Reale)',
		ISNULL(UTot.total,0) as 'Totale fase (Totalizzatore)',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(U.total,0) as 'Prev. disponibile su fase (Reale)'  
		, 
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(UTot.total,0) as 'Prev. disponibile su fase (Totalizzatore)',
		U.nphase as 'Fase'
		from #upbepexptotal U
		LEFT OUTER JOIN  #upbepexptotalReale UTot  on U.idupb = UTot.idupb and UTot.idacc like U.idacc + '%' AND   U.nphase = UTot.nphase 
		LEFT OUTER JOIN #previsioni P ON P.idupb = U.idupb AND P.idacc = U.idacc 
		-- order by 	U.codeupb ,	U.codeacc , U.nphase
		UNION ALL
		SELECT
			CASE  when U.nphase = 1 then 'PreAcc'  else 'Acc.'  END as 'Tipo Mov Budget',
		U.idupb as #idupb, 
		U.codeupb as 'cod. UPB', 
		U.upb as 'UPB', 
		U.idacc as #idacc,
		U.codeacc as 'Cod. Conto',
		U.account as 'Conto',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0) as 'Prev. Corrente',
		ISNULL(U.total,0) as 'Totale fase (Reale)',
		ISNULL(UTot.total,0) as 'Totale fase (Totalizzatore)',
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(U.total,0) as 'Prev. disponibile su fase (Reale)', 
		ISNULL(P.currentprev,0) + ISNULL(P.previsionvariation,0)
		- ISNULL(UTot.total,0) as 'Prev. disponibile su fase (Totalizzatore)', 
		U.nphase as 'Fase'
		from #upbepacctotal U
		LEFT OUTER JOIN  #upbepacctotalReale UTot  on U.idupb = UTot.idupb and UTot.idacc like U.idacc + '%' AND   U.nphase = UTot.nphase 
		LEFT OUTER JOIN #previsioni P ON P.idupb = U.idupb AND P.idacc = U.idacc 
		 order by 	U.codeupb ,	U.codeacc , U.nphase
END
DROP TABLE #previsioni
DROP TABLE #upbepexptotal
DROP TABLE #upbepacctotal
DROP TABLE #upbepacctotalReale
DROP TABLE #upbepexptotalReale
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
