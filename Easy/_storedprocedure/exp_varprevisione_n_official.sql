
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_varprevisione_n_official]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_varprevisione_n_official]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--sp_help enactment
--exec exp_varprevisione_n_official 2011, null,null,null,null,null,null

CREATE   PROCEDURE exp_varprevisione_n_official
(
	@yvar          	int,
    @nenactment		int, -- atto amministrativo contenente le variazioni (facoltativo)
	@idsor01		int, 
	@idsor02		int ,
	@idsor03		int, 
	@idsor04		int, 
	@idsor05		int 
)
AS BEGIN
DECLARE @yenactment  int
SET 	@yenactment = @yvar

DECLARE @idenactment	int

DECLARE @adate datetime
DECLARE @description varchar(150)

DECLARE @idenactmentstatus  int
--sp_help enactment
SELECT     
	@idenactment = idenactment,
	@adate = adate ,
	@description = description,
	@idenactmentstatus = idenactmentstatus
FROM  enactment 
WHERE enactment.yenactment = @yenactment
AND   enactment.nenactment = @nenactment
	  
--SELECT @idenactment
	
CREATE TABLE #printing
(
	nvar int,
	flagprevision char(1),
	flagsecondaryprev char(1)
)
	
INSERT INTO #printing (nvar,flagprevision,flagsecondaryprev) 
SELECT finvar.nvar ,
	   ISNULL(finvar.flagprevision,'N') ,
	   ISNULL(finvar.flagsecondaryprev, 'N')  
		FROM finvar 
		JOIN finvardetail
			ON finvar.yvar = finvardetail.yvar
			AND finvar.nvar = finvardetail.nvar
		JOIN upb
			ON finvardetail.idupb = upb.idupb		
		WHERE  
			finvar.yvar = @yvar
			AND finvar.variationkind <> 5
			AND (finvar.flagprevision = 'S' OR finvar.flagsecondaryprev = 'S') -- previsione principale o secondaria
			AND (finvar.idenactment = @idenactment OR @nenactment IS NULL)	-- atto amministrativo
	        AND (ISNULL(official,'N') = 'N') -- variazione non ufficiale
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		GROUP BY finvar.nvar ,ISNULL(finvar.flagprevision,'N') ,
	   ISNULL(finvar.flagsecondaryprev, 'N')  	
		
		
CREATE TABLE #detail
(
	nvar int,
	finpart char(1),
	codefin varchar(50),
	title varchar(150),
	--codeupb varchar(50),	
	--upb varchar(150),
	amount decimal(19,2)
)

insert into #detail(
	nvar,
	finpart ,
	codefin ,
	title ,
	--codeupb,	
	--upb ,
	amount
)
SELECT   	
	finvardetail.nvar,
	CASE
	when (( fin.flag & 1)=0) then 'E'
	when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin,
	fin.title,
	--upb.codeupb,
	--upb.title,
	SUM(finvardetail.amount) 
FROM finvardetail
JOIN fin
	ON fin.idfin = finvardetail.idfin
--LEFT OUTER JOIN upb
--	ON upb.idupb = finvardetail.idupb
WHERE finvardetail.yvar = @yvar
	AND finvardetail.nvar IN ( SELECT nvar FROM	#printing) 
GROUP BY 
	finvardetail.nvar,
	fin.idfin,
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	fin.codefin,
	fin.title --,
	--upb.idupb,
	--upb.codeupb,
	--upb.title
HAVING 	SUM(finvardetail.amount) > 0

	DECLARE @previsionkind char(1)
	DECLARE @secprevisionkind char(1)
	
	SELECT @previsionkind =  
	 
		CASE 
			WHEN fin_kind IN (1,3) THEN 'C'
			WHEN fin_kind = 2 THEN 'S'
		END
	FROM  config 
	WHERE config.ayear = @yvar

	SELECT @secprevisionkind =  
	 
		CASE 
			WHEN fin_kind = 3 THEN 'S'
			ELSE NULL
		END
	FROM config 
	WHERE config.ayear = @yvar
	
IF (@idenactment IS NULL) 
BEGIN
	SET @yenactment = NULL
	SET @nenactment = NULL
END 
	
--SELECT * FROM #printing
--SELECT * FROM #detail

 IF (@idenactment IS NOT NULL)
 SELECT   
	@yenactment AS 'Esercizio',
	@nenactment AS 'Num. Atto',
	CASE @idenactment
		WHEN 1 THEN 'In Attesa Approv.'
		WHEN 2 THEN 'Approvato'
		WHEN 3 THEN 'Annullato'
		ELSE NULL
	END AS 'Stato dell''Atto',
	@adate AS 'Data Atto',
	@description AS 'Descr. Atto',
	#detail.nvar as 'N. Prot. Variazione',	
	finpart AS 'Parte Bil.',
	codefin AS 'Cod. Bil.',
	title AS 'Bilancio',
	--codeupb AS 'Cod. UPB',	
	--upb AS 'UPB',
	amount AS 'Importo',
    CASE 
		WHEN (flagprevision = 'S'  AND @previsionkind  = 'C') THEN 'Competenza'
		WHEN (flagprevision = 'S'  AND @previsionkind  = 'S') THEN 'Cassa'
		ELSE null
	END	AS 'Tipo Prev. Princ.',
    CASE 
    	WHEN (flagsecondaryprev = 'S'  AND @secprevisionkind = 'C') THEN 'Competenza'
		WHEN (flagsecondaryprev = 'S'  AND @secprevisionkind = 'S') THEN 'Cassa'
		ELSE null
	END AS 'Tipo Prev. Sec..'
FROM #detail 
JOIN #printing ON  #detail.nvar =  #printing.nvar   
ORDER BY #detail.nvar,finpart, codefin -- , 
-- codeupb
ELSE 
	SELECT
	@yvar AS 'Esercizio',
	#detail.nvar as 'N. Prot. Variazione',	
	finpart AS 'Parte Bil.',
	codefin AS 'Cod. Bil.',
	title AS 'Bilancio',
	--codeupb AS 'Cod. UPB',	
	--upb AS 'UPB',
	amount AS 'Importo',
    CASE 
		WHEN (flagprevision = 'S'  AND @previsionkind  = 'C') THEN 'Competenza'
		WHEN (flagprevision = 'S'  AND @previsionkind  = 'S') THEN 'Cassa'
		ELSE null
	END	AS 'Tipo Prev. Princ.',
    CASE 
    	WHEN (flagsecondaryprev = 'S'  AND @secprevisionkind = 'C') THEN 'Competenza'
		WHEN (flagsecondaryprev = 'S'  AND @secprevisionkind = 'S') THEN 'Cassa'
		ELSE null
	END AS 'Tipo Prev. Sec..'
FROM #detail 
JOIN #printing ON  #detail.nvar =  #printing.nvar  
ORDER BY #detail.nvar,finpart, codefin
--, codeupb

DROP  TABLE #printing
DROP  TABLE #detail

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


