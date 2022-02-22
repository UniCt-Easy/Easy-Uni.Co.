
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_atto_amministrativo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_atto_amministrativo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [exp_riepilogo_atto_amministrativo]
	@yvar          	int, 
	@nenactment		int,
	@reportkind    	varchar(20),  --PREVISIONE 
	@showbudget_uff varchar(20)
	AS
	BEGIN
	
	DECLARE @idsorkind int
	SELECT  @idsorkind = idsorkind from sortingkind where codesorkind = 'BUDGET_UFF'
 --select * from enactment
	-- exec [exp_riepilogo_atto_amministrativo] 2016, 1, 'PRINCIPALE','S'
	DECLARE @yenactment   	int
	DECLARE @idenactment	int
	
	SET 	@yenactment = @yvar
	SET     @idenactment = 
			 (SELECT idenactment
			    FROM enactment 
			   WHERE enactment.yenactment = @yenactment
	   		     AND enactment.nenactment = @nenactment)
	
	CREATE TABLE #detail
	(
		idfin int,
		finpart char(1),
		codefin varchar(50),
		title varchar(150),
		amount decimal(19,2),
		nvar int,
		variationkind int
	)
	
	insert into #detail(
		idfin,
		finpart ,
		codefin ,
		title ,
		amount ,
		variationkind
	)
	SELECT   	
		fin.idfin,
		CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
		End,
		fin.codefin,
		fin.title,
		finvardetail.amount,
		finvar.variationkind  -- 1:normale 4:storno 2:ripartizione
	FROM finvardetail
	JOIN finvar ON finvardetail.yvar = finvar.yvar AND finvardetail.nvar = finvar.nvar
	JOIN fin
		ON fin.idfin = finvardetail.idfin
	WHERE finvardetail.yvar = @yvar
		AND (finvar.idenactment = @idenactment)
		AND ((@reportkind  = 'PRINCIPALE' AND flagprevision = 'S'AND finvar.variationkind <> 5) OR
			 (@reportkind  = 'SECONDARIA' AND flagsecondaryprev = 'S'AND finvar.variationkind <> 5))
	ORDER BY finvardetail.nvar, fin.flag, fin.codefin


CREATE TABLE #totenactment
	(
		kind char(10),	   -- kind MAGEN --> Maggiore Entrata MAGSP --> Maggiore Spesa    MINEN --> Minore Entrata  
					       -- MINSP --> Minore spesa     STAUM --> Storni in Aumento  STDIM  --> Storni in Diminuzione APPAVAUM --> Applicazione Avanzo AUM
						   -- APPAVDIM --> Applicazione Avanzo DIM
		idfin int,
		finpart char(1),
		codefin varchar(50),
		title varchar(150),
		amount decimal(19,2),
		printorder int, -- dispari: dettagli, pari: totali sezione
	)

INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
)
SELECT
	'MAGEN',	idfin,	finpart,	codefin,	title,	SUM(amount),	1
FROM #detail
WHERE ISNULL(#detail.amount,0) > 0
AND variationkind  = 1 --- variazioni normali
AND finpart = 'E'
GROUP BY idfin, finpart, codefin, title

INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
)
SELECT
	'MAGSP',	idfin,	finpart,	codefin,	title,	SUM(amount),	3
FROM #detail
WHERE ISNULL(#detail.amount,0) > 0
AND variationkind  = 1 --- variazioni normali
AND finpart = 'S'
GROUP BY idfin, finpart, codefin, title

INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
)
SELECT
	'MINEN',	idfin,	finpart,	codefin,	title,	SUM(amount),	5
FROM #detail
WHERE ISNULL(#detail.amount,0) < 0
AND variationkind  = 1 --- variazioni normali
AND finpart = 'E'
GROUP BY idfin, finpart, codefin, title


INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
)
SELECT
	'MINSP',	idfin,	finpart,	codefin,	title,	SUM(amount),	7
FROM #detail
WHERE ISNULL(#detail.amount,0) < 0
AND variationkind  = 1 --- variazioni normali
AND finpart = 'S'
GROUP BY idfin, finpart, codefin, title

INSERT INTO #totenactment
(
	kind,
	idfin,
	finpart,
	codefin,
	title,
	amount,
	printorder
)
SELECT
	'STAUM',	idfin,	finpart,	codefin,	title,	SUM(amount),	9
FROM #detail
WHERE ISNULL(#detail.amount,0) > 0
AND variationkind  = 4 --- variazioni storno
AND finpart = 'S'
GROUP BY idfin, finpart, codefin, title


INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder)
SELECT
	'STDIM',	idfin,	finpart,	codefin,	title,	SUM(amount),	11
FROM #detail
WHERE ISNULL(#detail.amount,0) < 0
AND variationkind  = 4 --- variazioni storno
AND finpart = 'S'
GROUP BY idfin, finpart, codefin, title


INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
	
)
SELECT
	'APPAVEN',	idfin,	finpart,	codefin,	title,	SUM(amount),	13
FROM #detail
WHERE variationkind  = 2 --- variazioni di ripartizione
AND finpart = 'E'
GROUP BY idfin, finpart, codefin, title


INSERT INTO #totenactment
(
	kind,	idfin,	finpart,	codefin,	title,	amount,	printorder
)
SELECT
	'APPAVSP',	idfin,	finpart,	codefin,	title,	SUM(amount),	15
FROM #detail
WHERE variationkind  = 2 --- variazioni di ripartizione
AND finpart = 'S'
GROUP BY idfin, finpart, codefin, title


-- calcolo i totali 
DECLARE @totmagen decimal(19,2)
DECLARE @totmagsp decimal(19,2)
DECLARE @totminen decimal(19,2)
DECLARE @totminsp decimal(19,2)
DECLARE @totstaum decimal(19,2)
DECLARE @totstdim decimal(19,2)
DECLARE @totappaven decimal(19,2)
DECLARE @totappsp decimal(19,2)

SELECT  @totmagen = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'MAGEN'
SELECT  @totmagsp = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'MAGSP'
SELECT  @totminen = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'MINEN'
SELECT  @totminsp = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'MINSP'
SELECT  @totstaum = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'STAUM'
SELECT  @totstdim = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'STDIM'
SELECT  @totappaven = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'APPAVEN'
SELECT  @totappsp = ISNULL(SUM(amount),0)  FROM #totenactment WHERE kind = 'APPAVSP'

INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'E',@totmagen,2
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'S',@totmagsp,4
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'E',@totminen,6
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'S',@totminsp,8
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'S',@totstaum,10
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'S',@totstdim,12
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'E',@totappaven,14
INSERT INTO #totenactment ( kind, finpart, amount, printorder) SELECT 'TOT', 'S',@totappsp,16
--select * from #totenactment
if (ISNULL(@showbudget_uff,'N') = 'S')
BEGIN
	SELECT 	
			CASE #totenactment.kind
				WHEN 'MAGEN' THEN 'Maggiore entrata'
				WHEN 'MAGSP' THEN 'Maggiore spesa'
				WHEN 'MINEN' THEN 'Minore Entrata'
				WHEN 'MINSP' THEN 'Minore Spesa'
				WHEN 'STDIM' THEN 'Storni in diminuzione'
				WHEN 'STAUM' THEN 'Storni in aumento'
				WHEN 'APPAVEN' THEN 'Applicazione Avanzo'
				WHEN 'APPAVSP' THEN 'Applicazione Avanzo'
				WHEN 'TOT' THEN 'Totale'
			END as 'Tipo',
			#totenactment.codefin as 'Codice Capitolo',
			#totenactment.title as 'Denominazione Capitolo',
			CASE #totenactment.finpart
				 WHEN 'E' THEN isnull(#totenactment.amount,0) 
				 ELSE 0 
			END AS  'E',
			CASE #totenactment.finpart
				 WHEN 'S' THEN isnull(#totenactment.amount,0) 
				 ELSE 0 
			END AS  'U',
			finsortingview.sortcode as 'Codice Budget',
			finsortingview.sorting as 'Denominazione Budget'
	FROM	#totenactment
	LEFT OUTER JOIN finsortingview 
	ON finsortingview.idfin = #totenactment.idfin
	AND finsortingview.idsorkind = @idsorkind
	WHERE   isnull(amount,0) <> 0
	ORDER BY printorder
END
ELSE
BEGIN
	SELECT 	
			CASE kind
				WHEN 'MAGEN' THEN 'Maggiore entrata'
				WHEN 'MAGSP' THEN 'Maggiore spesa'
				WHEN 'MINEN' THEN 'Minore Entrata'
				WHEN 'MINSP' THEN 'Minore Spesa'
				WHEN 'STDIM' THEN 'Storni in diminuzione'
				WHEN 'STAUM' THEN 'Storni in aumento'
				WHEN 'APPAVEN' THEN 'Applicazione Avanzo'
				WHEN 'APPAVSP' THEN 'Applicazione Avanzo'
				WHEN 'TOT' THEN 'Totale'
			END as 'Tipo',
			codefin as 'Codice Capitolo',
			title as 'Denominazione Capitolo',
			CASE finpart
				 WHEN 'E' THEN isnull(amount,0) 
				 ELSE 0 
			END AS  'E',
			CASE finpart
				 WHEN 'S' THEN isnull(amount,0) 
				 ELSE 0 
			END AS  'U'
	FROM	#totenactment
	WHERE   isnull(amount,0) <> 0
	ORDER BY printorder
END
	 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
