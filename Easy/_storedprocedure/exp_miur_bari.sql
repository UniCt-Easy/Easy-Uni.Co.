
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_miur_bari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_miur_bari]
GO



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE   PROCEDURE [exp_miur_bari] 
(
	@ayear int,
	@finpart char(1)
)
AS BEGIN

-- Per natura
DECLARE @iMIUR INT
DECLARE @eMIUR INT

DECLARE @iSIOPE INT
DECLARE @eSIOPE INT

DECLARE @eMIURprimafase INT

-- Per funzione
DECLARE @iFUNZ INT
DECLARE @eFUNZ INT

DECLARE @iFUNZlast INT
DECLARE @eFUNZlast INT
DECLARE @eFUNZprimafase INT


DECLARE @idsor_A_i int 
DECLARE @idsor_C_i int 
DECLARE @idsor_D_i int 
DECLARE @idsor_R_i int 
DECLARE @idsor_I_i int 

DECLARE @idsor_A_i_old int 
DECLARE @idsor_C_i_old int 
DECLARE @idsor_D_i_old int 
DECLARE @idsor_R_i_old int 
DECLARE @idsor_I_i_old int 

DECLARE @idsor_A_p int 
DECLARE @idsor_C_p int 
DECLARE @idsor_D_p int 
DECLARE @idsor_R_p int 
DECLARE @idsor_I_p int 



IF (@ayear <= 2006)
BEGIN
	SELECT @iMIUR = idsorkind from sortingkind where codesorkind = '06_MIUR'
	SELECT @eMIUR = idsorkind from sortingkind where codesorkind = '06_MIUR'

	SELECT @iFUNZ = idsorkind from sortingkind where codesorkind = '07_MIURFUNZ'
	SELECT @eFUNZ = idsoRkind from sortingkind where codesorkind = '07_MIURFUNZ'

	SELECT @iSIOPE = idsorkind from sortingkind where codesorkind = 'SIOPE'
	SELECT @eSIOPE = idsorkind from sortingkind where codesorkind = 'SIOPE'

	SELECT @iFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @iFUNZlast is null 
		SELECT @iFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'

	SELECT @eFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @eFUNZlast is null 
	SELECT @eFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'
	
	SELECT @eMIURprimafase = idsorkind FROM sortingkind WHERE codesorkind = '06_MIUR'
	SELECT @eFUNZprimafase = idsorkind FROM sortingkind WHERE codesorkind = '07_MIURFUNZ' -- L'ATTUALE CLASSIFICAZIONE SULLA PRIMA FASE
END
ELSE
BEGIN
	SELECT @iMIUR = idsorkind from sortingkind where codesorkind = '07E_MIUR'
	SELECT @eMIUR = idsorkind from sortingkind where codesorkind = '07U_MIUR_III_FASE'

	SELECT @iFUNZ = idsorkind from sortingkind where codesorkind = '07_MIURFUNZ'
	SELECT @eFUNZ = idsorkind from sortingkind where codesorkind = '07_MIURFUNZ_III_FASE'

	SELECT @iSIOPE = idsorkind from sortingkind where codesorkind = '07E_SIOPE'
	SELECT @eSIOPE = idsorkind from sortingkind where codesorkind = '07U_SIOPE'

	SELECT @iFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @iFUNZlast is null 
		SELECT @iFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'

	SELECT @eFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @eFUNZlast is null 
	
	SELECT @eFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'

	SELECT @eMIURprimafase = idsorkind FROM sortingkind WHERE codesorkind = '07U_MIUR'
	SELECT @eFUNZprimafase = idsorkind FROM sortingkind WHERE codesorkind = '07_MIURFUNZ' 
	-- L'ATTUALE CLASSIFICAZIONE SULLA TERZA FASE
END

--select * from sortingkind

if (@finpart='E')
begin

	SELECT @idsor_A_p =  idsor FROM sorting where idsorkind = @iFUNZlast and RTRIM(LTRIM(description)) like 'ASSISTENZ%'
	SELECT @idsor_C_p =  idsor FROM sorting where idsorkind = @iFUNZlast and description like '%SUPPORTO%'
	SELECT @idsor_D_p =  idsor FROM sorting where idsorkind = @iFUNZlast and description like '%FORMATIVI%ISTITUZIONALI%'
	SELECT @idsor_R_p =  idsor FROM sorting where idsorkind = @iFUNZlast and RTRIM(LTRIM(description)) = 'RICERCA'
	SELECT @idsor_I_p =  idsor FROM sorting where idsorkind = @iFUNZlast and description like '%INTERVENTI%'

	SELECT @idsor_A_i =  idsor FROM sorting where idsorkind = @iFUNZ and RTRIM(LTRIM(description)) like 'ASSISTENZ%'
	SELECT @idsor_C_i =  idsor FROM sorting where idsorkind = @iFUNZ and description like '%SUPPORTO%'
	SELECT @idsor_D_i =  idsor FROM sorting where idsorkind = @iFUNZ and description like '%FORMATIVI%ISTITUZIONALI%'
	SELECT @idsor_R_i =  idsor FROM sorting where idsorkind = @iFUNZ and RTRIM(LTRIM(description)) = 'RICERCA'
	SELECT @idsor_I_i =  idsor FROM sorting where idsorkind = @iFUNZ and description like '%INTERVENTI%'


end
else
begin
	SELECT @idsor_A_p =  idsor FROM sorting where idsorkind = @eFUNZlast and RTRIM(LTRIM(description)) like 'ASSISTENZ%'
	SELECT @idsor_C_p =  idsor FROM sorting where idsorkind = @eFUNZlast and description like '%SUPPORTO%'
	SELECT @idsor_D_p =  idsor FROM sorting where idsorkind = @eFUNZlast and description like '%FORMATIVI%ISTITUZIONALI%'
	SELECT @idsor_R_p =  idsor FROM sorting where idsorkind = @eFUNZlast and RTRIM(LTRIM(description)) = 'RICERCA'
	SELECT @idsor_I_p =  idsor FROM sorting where idsorkind = @eFUNZlast and description like '%INTERVENTI%'

	SELECT @idsor_A_i =  idsor FROM sorting where idsorkind = @eFUNZ and RTRIM(LTRIM(description)) like 'ASSISTENZ%'
	SELECT @idsor_C_i =  idsor FROM sorting where idsorkind = @eFUNZ and description like '%SUPPORTO%'
	SELECT @idsor_D_i =  idsor FROM sorting where idsorkind = @eFUNZ and description like '%FORMATIVI%ISTITUZIONALI%'
	SELECT @idsor_R_i =  idsor FROM sorting where idsorkind = @eFUNZ and RTRIM(LTRIM(description)) = 'RICERCA'
	SELECT @idsor_I_i =  idsor FROM sorting where idsorkind = @eFUNZ and description like '%INTERVENTI%'
	
	SELECT @idsor_A_i_old =  idsor FROM sorting where idsorkind = @eFUNZprimafase and RTRIM(LTRIM(description)) like 'ASSISTENZ%'
	SELECT @idsor_C_i_old =  idsor FROM sorting where idsorkind = @eFUNZprimafase and description like '%SUPPORTO%'
	SELECT @idsor_D_i_old =  idsor FROM sorting where idsorkind = @eFUNZprimafase and description like '%FORMATIVI%ISTITUZIONALI%'
	SELECT @idsor_R_i_old =  idsor FROM sorting where idsorkind = @eFUNZprimafase and RTRIM(LTRIM(description)) = 'RICERCA'
	SELECT @idsor_I_i_old =  idsor FROM sorting where idsorkind = @eFUNZprimafase and description like '%INTERVENTI%'

end

-- @iFUNZ = @eFUNZ
-- D-SERVIZI FORMATIVI ISTITUZIONALI
-- R-RICERCA
-- A-ASSISTENZIALE
-- I-INTERVENTI DIRITTO ALLO STUDIO
-- C-ALTRI SERVIZI DI SUPPORTO


-- Creazione della Tabella che visualizzerà il riepilogo dei dati su foglio Excel

CREATE TABLE #MIUR_balance
(
	sortcode varchar(20),
	description varchar(200),
	jan01arrear decimal(19,2),
	tot_FC decimal(19,2),
	tot_FR decimal(19,2), 
	tot_MC decimal(19,2),
	tot_MR decimal(19,2),
	ricerca_FC decimal(19,2),
	ricerca_FR decimal(19,2),
	ricerca_MC decimal(19,2),
	ricerca_MR decimal(19,2),
	didattica_FC decimal(19,2),
	didattica_FR decimal(19,2),
	didattica_MC decimal(19,2),
	didattica_MR decimal(19,2),
	assistenza_FC decimal(19,2),
	assistenza_FR decimal(19,2),
	assistenza_MC decimal(19,2),
	assistenza_MR decimal(19,2),
	congiunte_FC decimal(19,2),
	congiunte_FR decimal(19,2),
	congiunte_MC decimal(19,2),
	congiunte_MR decimal(19,2),
	studio_FC decimal(19,2),
	studio_FR decimal(19,2),
	studio_MC decimal(19,2),
	studio_MR decimal(19,2)
)

-- Creazione tabella per la classificazione MIURFUNZ
CREATE TABLE #tmp_FUNZ
(
	idmov varchar(40),
	idsorkind varchar(20),
	idsor varchar(31),
	sortcode varchar(50),
	description varchar(200),
	flagarrear tinyint,
	tot decimal(19,2),
	ric decimal(19,2),
	did decimal(19,2),
	ass decimal(19,2),
	con decimal(19,2),
	stu decimal(19,2),
	kind char(1)
)


CREATE TABLE #mov_res (idmov varchar(40), amount decimal(19,2), 
		       curramount decimal(19,2), varamount decimal(19,2), idsorkind int)
CREATE TABLE #var_res (idmov varchar(40), amount decimal(19,2))

CREATE TABLE #class
(
	idmov int,
	idsor int,
	amount decimal(19,2),
	sortcode varchar(30),
	rowkind char(1) -- Campo che vale 'P' = Movimento Principale, 'V' = Variazioni
)

DECLARE @phaseMIUR tinyint -- Fase di entrata/spesa associata alla classificazione MIUR
DECLARE @phaseFUNZ tinyint -- Fase di entrata/spesa associata alla classificazione MIURFUNZ

DECLARE @phaseSIOPE tinyint
DECLARE @phaseFUNZlast tinyint

DECLARE @MIUR int
DECLARE @SIOPE int
-- Codice per i movimenti di entrata 
IF @finpart = 'E'
BEGIN
	SELECT @phaseMIUR = nphaseincome FROM sortingkind WHERE idsorkind  = @iMIUR
	SELECT @phaseFUNZ = nphaseincome FROM sortingkind WHERE idsorkind  = @iFUNZ

	SET @MIUR = @iMIUR
	SET @SIOPE = @iSIOPE

	INSERT INTO #tmp_FUNZ
	(
		idmov, idsor, flagarrear, idsorkind, tot,
		ric,
		did,
		ass,
		con,
		stu
	)
	SELECT 	I1.idinc, C1.idsor, O1.flag&1, @iMIUR, SUM(C1.amount),
		CASE 
			WHEN c2.idsor = @idsor_R_i THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_D_i THEN  
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_A_i THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_C_i THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_I_i THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END
		FROM incomesorted C1		-- C1 imputazione a classificazione MIUR
		join sorting 
                        on sorting.idsor = c1.idsor
		JOIN incomeyear I1	-- I contiene il flag relativo alla competenza dell'impegno classificato MIUR
			ON C1.idinc = I1.idinc 
			AND C1.ayear = I1.ayear
		JOIN incometotal O1		-- O1 contiene l'finphase_C dell'impegno classificato MIUR
			ON C1.idinc = O1.idinc 
			AND C1.ayear = O1.ayear
		LEFT JOIN income S		-- S riga di entrata che contiene le liquidazioni dell'impegno di sopra 
			ON S.idinc = I1.idinc 
			AND  S.nphase = @phaseMIUR--@phaseFUNZ
		LEFT JOIN incometotal O2	-- O2 contiene l'finphase_C della liquidazione classificata FUNZ 
			ON S.idinc = O2.idinc 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idinc,idsorkind,cc2.idsor,sortcode,SUM(amount) AS amount
			FROM incomesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idinc,idsorkind,cc2.idsor,sortcode)	AS C2
		ON C2.idinc = S.idinc AND C2.idsorkind = @iFUNZ
		WHERE sorting.idsorkind = @iMIUR 
			AND S.nphase = @phaseMIUR 
--			AND ISNULL(O1.curramount,0)<>0 
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
		GROUP BY I1.idinc,C1.idsor,o1.flag&1,C2.idsor,c2.sortcode
		ORDER BY I1.idinc,C1.idsor

	SELECT @phaseSIOPE = nphaseincome FROM sortingkind WHERE idsorkind  = @iSIOPE
	SELECT @phaseFUNZlast = nphaseincome FROM sortingkind WHERE idsorkind  = @iFUNZlast

	INSERT INTO #tmp_FUNZ
	(
		idmov, idsor, flagarrear, idsorkind, tot, 
		ric,
		did,
		ass,
		con,
		stu
	)
	SELECT 	I1.idinc, C1.idsor, O1.flag&1, @iSIOPE, SUM(c1.amount),
		CASE 
			WHEN c2.idsor= @idsor_R_p  THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_D_p THEN  
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_A_p THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_C_p THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_I_p THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END
		FROM incomesorted C1		-- C1 imputazione a classificazione MIUR
		join sorting on sorting.idsor = c1.idsor
		JOIN incomeyear I1	-- I contiene il flag relativo alla competenza dell'impegno classificato MIUR
			ON C1.idinc = I1.idinc 
			AND C1.ayear = I1.ayear
		JOIN incometotal O1		-- O1 contiene l'finphase_C dell'impegno classificato MIUR
			ON C1.idinc = O1.idinc 
			AND C1.ayear = O1.ayear
		LEFT JOIN income S		-- S riga di entrata che contiene le liquidazioni dell'impegno di sopra 
			ON S.idinc = I1.idinc 
			AND  S.nphase = @phaseSIOPE--@phaseFUNZlast
		LEFT JOIN incometotal O2	-- O2 contiene l'finphase_C della liquidazione classificata FUNZ 
			ON S.idinc = O2.idinc 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idinc,idsorkind,cc2.idsor, sortcode, SUM(amount) AS amount
			FROM incomesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idinc,idsorkind,cc2.idsor, sortcode)	AS C2
		ON C2.idinc = S.idinc AND C2.idsorkind = @iFUNZlast
		WHERE sorting.idsorkind = @iSIOPE 
			AND S.nphase = @phaseSIOPE 
--			AND ISNULL(O1.curramount,0)<>0 
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
		GROUP BY I1.idinc,C1.idsor,O1.flag,C2.idsor, O1.flag, c2.sortcode
		ORDER BY I1.idinc,C1.idsor

	UPDATE #tmp_FUNZ SET #tmp_FUNZ.sortcode = sorting.sortcode, #tmp_FUNZ.description = sorting.description
	FROM sorting
	WHERE sorting.idsor = #tmp_FUNZ.idsor

	INSERT INTO #mov_res (idmov, amount, curramount, varamount)
	SELECT incomeyear.idinc, incomeyear.amount, incometotal.curramount, 
	ISNULL(
		(SELECT SUM(amount)
		FROM incomevar
		WHERE incomevar.idinc = incomeyear.idinc
		AND incomevar.yvar = incomeyear.ayear)
	,0)
	FROM incomeyear
	join income on income.idinc = incomeyear.idinc
	JOIN incometotal
		ON incomeyear.idinc = incometotal.idinc
		AND incomeyear.ayear = incometotal.ayear
	WHERE incomeyear.ayear = @ayear
		AND income.nphase = @phaseMIUR
		AND ((incometotal.flag&1)=1)   ---Residuo

	INSERT INTO #var_res (idmov, amount)
	SELECT incomeyear.idinc, SUM(incomevar.amount)
	FROM incomeyear
	join income on incomeyear.idinc = income.idinc
	join incometotal on incomeyear.idinc = incometotal.idinc and incomeyear.ayear = incometotal.ayear
	JOIN incomevar
		ON incomevar.idinc = incomeyear.idinc
		AND incomevar.yvar = incomeyear.ayear
	WHERE incomeyear.ayear = @ayear
		AND income.nphase = @phaseMIUR
		AND ((incometotal.flag&1)=1) ---Residuo
	GROUP BY incomeyear.idinc

	-- Caso 1. Movimento di Entrata senza trattenute
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, incomesorted.idsor, sorting.sortcode, SUM(incomesorted.amount), 'P'
	FROM #mov_res
	JOIN incomesorted
		ON #mov_res.idmov = incomesorted.idinc
	JOIN sorting
		ON sorting.idsor = incomesorted.idsor
	WHERE sorting.idsorkind = @iMIUR
		AND #mov_res.varamount = 0
		AND incomesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, incomesorted.idsor, sorting.sortcode
		
	-- Caso 2. Movimento di Entrata con variazioni
	-- Inserimento di dettagli SIOPE sul mov. principale riferito alle trattenute (calcolo per rapporto)
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, incomesorted.idsor, sorting.sortcode,
	CASE
		WHEN #mov_res.curramount = 0 THEN #var_res.amount
		ELSE (SUM(incomesorted.amount) / #mov_res.curramount) * #var_res.amount
	END, 'V'
--	(SUM(incomesorted.amount) - #var_res.amount) * #var_res.amount / #mov_res.amount, 'V'
	FROM #var_res
	JOIN #mov_res
		ON #var_res.idmov = #mov_res.idmov
	JOIN incomesorted
		ON #mov_res.idmov = incomesorted.idinc
	JOIN sorting
		ON sorting.idsor = incomesorted.idsor
	WHERE sorting.idsorkind = @iMIUR
		AND #mov_res.varamount <> 0
		AND incomesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, sorting.sortcode, #var_res.amount, #mov_res.curramount, incomesorted.idsor
		
	-- Inserimento dei dettagli SIOPE del movimento principale (calcolo per differenza)
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, incomesorted.idsor, sorting.sortcode,
	SUM(incomesorted.amount) - 
	ISNULL(
		(SELECT SUM(#class.amount)
		FROM #class
		WHERE #class.idmov = #mov_res.idmov
			AND #class.idsor = incomesorted.idsor
			AND #class.rowkind = 'V')
	,0), 'P'
	FROM #mov_res
	JOIN incomesorted
		ON #mov_res.idmov = incomesorted.idinc
	JOIN sorting
		ON sorting.idsor = incomesorted.idsor
	WHERE sorting.idsorkind = @iMIUR
		AND #mov_res.varamount <> 0
		AND incomesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, sorting.sortcode, incomesorted.idsor

END	-- Fine codice per i movimenti di entrata
ELSE
-- Codice per i movimenti di spesa
BEGIN	
	DECLARE @faseMIURprimafase tinyint
	-- per distinguere i movimenti in conto competenza dai movimenti in conto residui faremo
	-- sempre riferimento alla fase 1
	-- movimenti in conto competenza, la cui fase 1 è pari all'anno corrente della stampa @ayear
	-- movimenti in conto residui, si distinguono in due categorie
	-- 1) movimenti la cui fase 1 è anteriore al 2008 (<)
	-- 2) movimenti la cui fase 1 è compresa (>=) tra  2008 e @ayear - 1

	SELECT @phaseMIUR = nphaseexpense FROM sortingkind WHERE idsorkind  = @eMIUR
	SELECT @phaseFUNZ = nphaseexpense FROM sortingkind WHERE idsorkind  = @eFUNZ
	SELECT @faseMIURprimafase = nphaseexpense FROM sortingkind WHERE idsorkind  = @eMIURprimafase
	

	SET @MIUR = @eMIUR
	SET @SIOPE = @eSIOPE
	
	-- per i movimenti in conto competenza prenderemo sempre la MIUR nuova
	-- sulla terza fase

	-- per i movimenti in conto residui prenderemo la MIUR nuova oppure la 
	-- MIUR vecchia a seconda dell'anno di creazione della prima fase (ymov della fase 1)
 
	INSERT INTO #tmp_FUNZ
	(
		idmov, idsor, flagarrear, idsorkind, tot, 
		ric,
		did,
		ass,
		con,
		stu
	)
	SELECT 	I1.idexp, C1.idsor, O1.flag&1, @eMIUR, SUM(C1.amount),
		CASE 
			WHEN c2.idsor = @idsor_R_i THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_D_i THEN  
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor=@idsor_A_i THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor=@idsor_C_i THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_I_i THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END
		FROM expensesorted C1		
		join sorting on sorting.idsor = c1.idsor
		JOIN expenseyear I1
			ON C1.idexp = I1.idexp 
			AND C1.ayear = I1.ayear
		JOIN expensetotal O1		
			ON C1.idexp = O1.idexp 
			AND C1.ayear = O1.ayear
		LEFT JOIN expense S		 
			ON S.idexp = I1.idexp 
			AND  S.nphase = @phaseMIUR
		LEFT JOIN expenselink SL		 
			ON S.idexp = SL.idchild 
			AND  SL.nlevel = 1
		LEFT OUTER JOIN expense S1
			ON S1.idexp =  SL.idparent
		LEFT JOIN expensetotal O2	
			ON S.idexp = O2.idexp 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idexp,idsorkind,cc2.idsor,sortcode,SUM(amount) AS amount
			FROM expensesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idexp,idsorkind,cc2.idsor, sortcode)	AS C2
			ON C2.idexp = S.idexp AND C2.idsorkind = @eFUNZ
		WHERE sorting.idsorkind = @eMIUR 
			AND S.nphase = @phaseMIUR 
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
			AND ((S1.ymov  = @ayear) or (S1.ymov between 2008 AND (@ayear -1)))
		GROUP BY I1.idexp,C1.idsor,O1.flag,C2.idsor, O1.flag, c2.sortcode
		ORDER BY I1.idexp,C1.idsor

	
	INSERT INTO #tmp_FUNZ
	(
		idmov, idsor, flagarrear, idsorkind, tot, 
		ric,
		did,
		ass,
		con,
		stu
	)
	SELECT 	I1.idexp, sortinglkup.idsor, O1.flag&1, @eMIUR, SUM(C1.amount),
		CASE 
			WHEN c2.idsor = @idsor_R_i_old THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_D_i_old THEN  
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor=@idsor_A_i_old THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor=@idsor_C_i_old THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_I_i_old THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END
		FROM expensesorted C1		
		JOIN sorting on sorting.idsor = c1.idsor
		JOIN sorting sortinglkup on sorting.sortcode = sortinglkup.sortcode
		JOIN expenseyear I1
			ON C1.idexp = I1.idexp 
			AND C1.ayear = I1.ayear
		JOIN expensetotal O1		
			ON C1.idexp = O1.idexp 
			AND C1.ayear = O1.ayear
		LEFT JOIN expense S		 
			ON S.idexp = I1.idexp 
			AND  S.nphase = @faseMIURprimafase
		LEFT JOIN expenselink SL		 
			ON S.idexp = SL.idchild 
			AND  SL.nlevel = 1
		LEFT OUTER JOIN expense S1
			ON S1.idexp =  SL.idparent
		LEFT JOIN expensetotal O2	
			ON S.idexp = O2.idexp 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idexp,idsorkind,cc2.idsor,sortcode,SUM(amount) AS amount
			FROM expensesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idexp,idsorkind,cc2.idsor, sortcode)	AS C2
			ON C2.idexp = S.idexp AND C2.idsorkind = @eFUNZprimafase
		WHERE sorting.idsorkind = @eMIURprimafase 
			AND sortinglkup.idsorkind = @eMIUR
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
			AND (S1.ymov  < 2008)
		GROUP BY I1.idexp,sortinglkup.idsor, O1.flag,C2.idsor, O1.flag, c2.sortcode
		ORDER BY I1.idexp,sortinglkup.idsor
		
	--select '1',* from #tmp_FUNZ 

	SELECT @phaseSIOPE = nphaseexpense FROM sortingkind WHERE idsorkind  = @eSIOPE
	SELECT @phaseFUNZlast = nphaseexpense FROM sortingkind WHERE idsorkind  = @eFUNZlast
	
	INSERT INTO #tmp_FUNZ
	(
		idmov, idsor, flagarrear, idsorkind, tot,
		ric,
		did,
		ass,
		con,
		stu
	)
	SELECT 	I1.idexp, C1.idsor, O1.flag&1, @eSIOPE, SUM(C1.amount),
		CASE 
			WHEN c2.idsor = @idsor_R_p THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor= @idsor_D_p THEN  
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor=@idsor_A_p THEN 
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor = @idsor_C_p THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END,
		CASE 
			WHEN c2.idsor= @idsor_I_p THEN
				CASE
					WHEN SUM(O1.curramount) = 0 THEN 0
					ELSE 
					ISNULL(SUM(C1.amount)/
						SUM(O1.curramount) *SUM(C2.amount),0)
				END
			ELSE 0
		END
		FROM expensesorted C1		-- C1 imputazione a classificazione MIUR
		join sorting on sorting.idsor = c1.idsor
		JOIN expenseyear I1	-- I contiene il flag relativo alla competenza dell'impegno classificato MIUR
			ON C1.idexp = I1.idexp 
			AND C1.ayear = I1.ayear
		JOIN expensetotal O1		-- O1 contiene l'finphase_C dell'impegno classificato MIUR
			ON C1.idexp = O1.idexp 
			AND C1.ayear = O1.ayear
		LEFT JOIN expense S		-- S riga di entrata che contiene le liquidazioni dell'impegno di sopra 
			ON S.idexp = I1.idexp 
			AND  S.nphase = @phaseSIOPE--@phaseFUNZlast
		LEFT JOIN expensetotal O2	-- O2 contiene l'finphase_C della liquidazione classificata FUNZ 
			ON S.idexp = O2.idexp 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idexp,idsorkind,cc2.idsor,sortcode,SUM(amount) AS amount
			FROM expensesorted CC2
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idexp,idsorkind,cc2.idsor, sortcode)	AS C2
		ON C2.idexp = S.idexp AND C2.idsorkind = @eFUNZlast
		WHERE sorting.idsorkind = @eSIOPE 
			AND S.nphase = @phaseSIOPE 
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
		GROUP BY I1.idexp,C1.idsor,O1.flag,C2.idsor,O1.flag, c2.sortcode
		ORDER BY I1.idexp,C1.idsor
	
	--select '2',* from #tmp_FUNZ 

	UPDATE #tmp_FUNZ SET #tmp_FUNZ.sortcode = sorting.sortcode, #tmp_FUNZ.description = sorting.description
	FROM sorting
	WHERE sorting.idsorkind = #tmp_FUNZ.idsorkind
		AND sorting.idsor = #tmp_FUNZ.idsor

	INSERT INTO #mov_res (idmov, amount, curramount, varamount,idsorkind)
	SELECT expenseyear.idexp, expenseyear.amount, expensetotal.curramount, 
	ISNULL(
		(SELECT SUM(amount)
		FROM expensevar
		WHERE expensevar.idexp = expenseyear.idexp
		AND expensevar.yvar = expenseyear.ayear)
	,0),@eMIUR
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear
	JOIN expenselink
		ON expenselink.idchild = expense.idexp
		AND expenselink.nlevel = 1
	JOIN expense EXPPAR
		ON EXPPAR.idexp = expenselink.idparent
	WHERE expenseyear.ayear = @ayear
		AND expense.nphase = @phaseMIUR
		AND EXPPAR.ymov BETWEEN 2008 AND (@ayear -1)
		AND ((expensetotal.flag&1)=1)   --Residuo
	
	INSERT INTO #mov_res (idmov, amount, curramount, varamount, idsorkind)
	SELECT expenseyear.idexp, expenseyear.amount, expensetotal.curramount, 
	ISNULL(
		(SELECT SUM(amount)
		FROM expensevar
		WHERE expensevar.idexp = expenseyear.idexp
		AND expensevar.yvar = expenseyear.ayear)
	,0), @eMIURprimafase
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	JOIN expensetotal
		ON expenseyear.idexp = expensetotal.idexp
		AND expenseyear.ayear = expensetotal.ayear
	JOIN expenselink
		ON expenselink.idchild = expense.idexp
		AND expenselink.nlevel = 1
	JOIN expense EXPPAR
		ON EXPPAR.idexp = expenselink.idparent
	WHERE expenseyear.ayear = @ayear
		AND expense.nphase = @faseMIURprimafase
		AND EXPPAR.ymov < 2008
		AND ((expensetotal.flag&1)=1)   --Residuo

	INSERT INTO #var_res (idmov, amount)
	SELECT expensevar.idexp, SUM(expensevar.amount)
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	join expensetotal on expensetotal.idexp=expenseyear.idexp and expensetotal.ayear=expenseyear.ayear
	JOIN expensevar
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = expensevar.yvar
	JOIN expenselink
		ON expenselink.idchild = expense.idexp
		AND expenselink.nlevel = 1
	JOIN expense EXPPAR
		ON EXPPAR.idexp = expenselink.idparent
	WHERE expenseyear.ayear = @ayear
		AND EXPPAR.ymov BETWEEN 2008 AND (@ayear -1)
		AND ((expensetotal.flag&1)=1)  --Residuo
		AND expense.nphase = @phaseMIUR
	GROUP BY expensevar.idexp

	INSERT INTO #var_res (idmov, amount)
	SELECT expensevar.idexp, SUM(expensevar.amount)
	FROM expenseyear
	join expense on expense.idexp = expenseyear.idexp
	join expensetotal on expensetotal.idexp=expenseyear.idexp and expensetotal.ayear=expenseyear.ayear
	JOIN expensevar
		ON expenseyear.idexp = expensevar.idexp
		AND expenseyear.ayear = expensevar.yvar
	JOIN expenselink
		ON expenselink.idchild = expense.idexp
		AND expenselink.nlevel = 1
	JOIN expense EXPPAR
		ON EXPPAR.idexp = expenselink.idparent
	WHERE expenseyear.ayear = @ayear
		AND EXPPAR.ymov < 2008
		AND ((expensetotal.flag&1)=1)  --Residuo
		AND expense.nphase = @faseMIURprimafase
	GROUP BY expensevar.idexp

	-- Caso 1. Movimento di Spesa senza trattenute
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, sortinglkup.idsor, sortinglkup.sortcode, SUM(expensesorted.amount), 'P'
	FROM #mov_res
	JOIN expensesorted
		ON #mov_res.idmov = expensesorted.idexp
	JOIN sorting
		ON sorting.idsor = expensesorted.idsor
	JOIN sorting sortinglkup 
		ON sortinglkup.sortcode = sorting.sortcode
	WHERE sorting.idsorkind = #mov_res.idsorkind
		AND sortinglkup.idsorkind = @eMIUR 
		AND #mov_res.varamount = 0
		AND expensesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, sortinglkup.idsor, sortinglkup.sortcode
		
	-- Caso 2. Movimento di Spesa con variazioni
	-- Inserimento di dettagli SIOPE sul mov. principale riferito alle trattenute (calcolo per rapporto)
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, sortinglkup.idsor, sortinglkup.sortcode,
	CASE
		WHEN #mov_res.curramount = 0 THEN #var_res.amount
		ELSE (SUM(expensesorted.amount) / #mov_res.curramount) * #var_res.amount
	END, 
	'V'
	FROM #var_res
	JOIN #mov_res
		ON #var_res.idmov = #mov_res.idmov
	JOIN expensesorted
		ON #mov_res.idmov = expensesorted.idexp
	JOIN sorting
		ON sorting.idsor = expensesorted.idsor
	JOIN sorting sortinglkup 
		ON sortinglkup.sortcode = sorting.sortcode
	WHERE sorting.idsorkind = #mov_res.idsorkind
		AND sortinglkup.idsorkind = @eMIUR 
		AND #mov_res.varamount <> 0
		AND expensesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, sortinglkup.sortcode, #var_res.amount, #mov_res.curramount, sortinglkup.idsor

	-- Inserimento dei dettagli SIOPE del movimento principale (calcolo per differenza)
	INSERT INTO #class (idmov, idsor, sortcode, amount, rowkind)
	SELECT #mov_res.idmov, sortinglkup.idsor, sortinglkup.sortcode,
	SUM(expensesorted.amount) - 
	ISNULL(
		(SELECT SUM(#class.amount)
		FROM #class
		WHERE #class.idmov = #mov_res.idmov
			AND #class.idsor = sortinglkup.idsor
			AND #class.rowkind = 'V')
	,0), 'P'
	FROM #mov_res
	JOIN expensesorted
		ON #mov_res.idmov = expensesorted.idexp
	JOIN sorting
		ON sorting.idsor = expensesorted.idsor
	JOIN sorting sortinglkup 
		ON sortinglkup.sortcode = sorting.sortcode
	WHERE sorting.idsorkind = #mov_res.idsorkind
		AND sortinglkup.idsorkind = @eMIUR 
		AND #mov_res.varamount <> 0
		AND expensesorted.ayear = @ayear
	GROUP BY #mov_res.idmov, sortinglkup.sortcode, sortinglkup.idsor
END	-- Fine codice per i movimenti di spesa

-- righe accorpate, prende una che somma tutto ed elimina le rimamenti

INSERT INTO #tmp_FUNZ
(
	idmov, idsorkind, idsor, sortcode, description, flagarrear,
	tot, ric, did, ass, con, stu, kind
)
SELECT 
	idmov, idsorkind, idsor, sortcode, description, flagarrear,
	SUM(DISTINCT tot),
	SUM(ric), SUM(did), SUM(ass), SUM(con), SUM(stu), 'C'
FROM #tmp_FUNZ T1
WHERE 	(SELECT COUNT(*)
	FROM #tmp_FUNZ T2
	WHERE T2.idmov = T1.idmov
	AND T2.idsorkind = T1.idsorkind
	AND T2.idsor = T1.idsor
	AND T2.flagarrear = T1.flagarrear) > 1
GROUP BY idmov, idsorkind, idsor, sortcode, description, flagarrear

DELETE FROM #tmp_FUNZ
WHERE 
	(SELECT COUNT(*)
	FROM #tmp_FUNZ T2
	WHERE T2.idmov = #tmp_FUNZ.idmov
	AND T2.idsorkind = #tmp_FUNZ.idsorkind
	AND T2.idsor = #tmp_FUNZ.idsor
	AND T2.flagarrear = #tmp_FUNZ.flagarrear) > 1
AND kind IS NULL

INSERT INTO #MIUR_balance
(
	sortcode, description,
	jan01arrear,
	tot_FC, tot_FR, 
	tot_MC, tot_MR,
	ricerca_FC, ricerca_FR,
	ricerca_MC, ricerca_MR,
	didattica_FC, didattica_FR,
	didattica_MC, didattica_MR,
	assistenza_FC, assistenza_FR,
	assistenza_MC, assistenza_MR,
	congiunte_FC, congiunte_FR,
	congiunte_MC, congiunte_MR,
	studio_FC, studio_FR,
	studio_MC, studio_MR
) 
SELECT 	T.sortcode, T.description,
	ISNULL(SUM(#class.amount),0), 
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.tot ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.tot ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.tot ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.tot ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.ric ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.ric ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.ric ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.ric ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.did ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.did ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.did ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.did ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.ass ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.ass ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.ass ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.ass ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.con ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.con ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.con ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.con ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @MIUR THEN T.stu ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @MIUR THEN T.stu ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 0 AND T.idsorkind = @SIOPE THEN T.stu ELSE 0 END),0),
	ISNULL(SUM(CASE WHEN (T.flagarrear&1) = 1 AND T.idsorkind = @SIOPE THEN T.stu ELSE 0 END),0)
FROM #tmp_FUNZ T
LEFT OUTER JOIN #class
	ON T.idmov = #class.idmov
	AND T.idsor = #class.idsor
	AND #class.rowkind = 'P'
GROUP BY T.sortcode, T.description

INSERT INTO #MIUR_balance
(
	sortcode, description, 
	tot_FC, tot_FR,
	tot_MC, tot_MR,
	ricerca_FC, ricerca_FR,
	ricerca_MC, ricerca_MR,
	didattica_FC, didattica_FR,
	didattica_MC, didattica_MR,
	assistenza_FC, assistenza_FR,
	assistenza_MC, assistenza_MR,
	congiunte_FC, congiunte_FR,
	congiunte_MC, congiunte_MR,
	studio_FC, studio_FR,
	studio_MC, studio_MR
)
SELECT sortcode, description, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
FROM sortingusable
WHERE idsorkind = @MIUR
AND movkind = @finpart
AND (start IS NULL OR start <= @ayear) 
AND (stop IS NULL OR stop >= @ayear)
AND NOT EXISTS(SELECT sortcode FROM #MIUR_balance WHERE #MIUR_balance.sortcode = sortingusable.sortcode)

IF (@ayear <= 2006)
BEGIN
	UPDATE #MIUR_balance SET sortcode = SUBSTRING(sortcode, 2, LEN(sortcode))
END

-- Impostazioni delle variabili che daranno il nome alle colonne esportate in Excel
DECLARE @column_1 nvarchar(20) -- Variabile per nome della prima colonna in Excel
DECLARE @column_2 nvarchar(20) -- Variabile per nome della seconda colonna in Excel
DECLARE @column_3 nvarchar(20) -- Variabile per nome della terza colonna in Excel
DECLARE @column_4 nvarchar(20) -- Variabile per nome della quarta colonna in Excel
DECLARE @column_5 nvarchar(20) -- Variabile per nome della quarta colonna in Excel


--select * from #MIUR_balance
update #MIUR_balance
	set tot_FC=isnull(tot_FC,0),
	tot_FR=isnull(tot_FR,0),
	tot_MC=isnull(tot_MC,0),
	tot_MR=isnull(tot_MR,0),
	ricerca_FC=isnull(ricerca_FC,0), 
	ricerca_FR=isnull(ricerca_FR,0),
	ricerca_MC=isnull(ricerca_MC,0), 
	ricerca_MR=isnull(ricerca_MR,0),
	didattica_FC=isnull(didattica_FC,0), 
	didattica_FR=isnull(didattica_FR,0),
	didattica_MC=isnull(didattica_MC,0), 
	didattica_MR=isnull(didattica_MR,0),
	assistenza_FC=isnull(assistenza_FC,0),
	assistenza_FR=isnull(assistenza_FR,0),
	assistenza_MC=isnull(assistenza_MC,0),
	assistenza_MR=isnull(assistenza_MR,0),
	congiunte_FC=isnull(congiunte_FC,0), 
	congiunte_FR=isnull(congiunte_FR,0),
	congiunte_MC=isnull(congiunte_MC,0),
	congiunte_MR=isnull(congiunte_MR,0),
	studio_FC=isnull(studio_FC,0),
	studio_FR=isnull(studio_FR,0),
	studio_MC=isnull(studio_MC,0),
	studio_MR=isnull(studio_MR,0)


DECLARE @SQL nvarchar(3000)
IF @finpart = 'S'
BEGIN
	SELECT sortcode AS Codice, 
                description AS Descrizione, 
		(tot_fc + tot_fr) AS 'Tot. Imp.',
		tot_fc AS 'Tot. Imp. Comp.',
		(tot_mc + tot_mr) AS 'Tot. Pag.',
		tot_mc AS 'Tot. Pag. Comp.',
		(assistenza_fc + assistenza_fr) AS 'Tot. Imp.  ASSISTENZIALE', 
                assistenza_fc AS 'Tot. Imp. Comp. ASSISTENZIALE',
		(assistenza_mc + assistenza_mr) AS 'Tot. Pag. ASSISTENZIALE', 
                assistenza_mc AS 'Tot. Pag. Comp. ASSISTENZIALE',
		(congiunte_fc + congiunte_fr) AS 'Tot. Imp. ALTRI SERVIZI DI SUPPORTO', 
                congiunte_fc AS 'Tot. Imp. Comp. ALTRI SERVIZI DI SUPPORTO',
		(congiunte_mc + congiunte_mr) AS 'Tot. Pag.ALTRI SERVIZI DI SUPPORTO', 
                congiunte_mc AS 'Tot. Pag. Comp.ALTRI SERVIZI DI SUPPORTO',
                (didattica_fc + didattica_fr) AS 'Tot. Imp. SERVIZI FORMATIVI ISTITUZIONALI',
                didattica_fc AS 'Tot. Imp. Comp.SERVIZI FORMATIVI ISTITUZIONALI',
                (didattica_mc + didattica_mr) AS 'Tot. Pag.SERVIZI FORMATIVI ISTITUZIONALI',
                didattica_mc AS 'Tot. Pag. Comp. SERVIZI FORMATIVI ISTITUZIONALI',
                (ricerca_fc + ricerca_fr) AS 'Tot. Imp.RICERCA', 
                ricerca_fc AS 'Tot. Imp. Comp.RICERCA',
                (ricerca_mc + ricerca_mr) AS 'Tot. Pag.RICERCA ', 
                ricerca_mc AS 'Tot. Pag. Comp.RICERCA',
                (studio_fc + studio_fr) AS 'Tot. Imp.INTERVENTI DIRITTO ALLO STUDIO', 
                studio_fc AS 'Tot. Imp. Comp.INTERVENTI DIRITTO ALLO STUDIO',
                (studio_mc + studio_mr) AS 'Tot. Pag. INTERVENTI DIRITTO ALLO STUDIO', 
                studio_mc AS 'Tot. Pag. Comp. INTERVENTI DIRITTO ALLO STUDIO',
		jan01arrear AS 'Tot. Residui al 01/01', 
		(tot_fc + tot_fr) - (tot_mc + tot_mr) AS 'Tot. Residui al 31/12',
		(tot_fc + tot_fr) - (assistenza_fc + assistenza_fr + congiunte_fc + congiunte_fr 
                + didattica_fc + didattica_fr + ricerca_fc + ricerca_fr + studio_fc + studio_fr) 
                        AS 'Diff. Tot. Imp.',
		tot_fc - (assistenza_fc + congiunte_fc + didattica_fc + ricerca_fc + studio_fc ) 
                        AS 'Diff. Tot. Imp. Comp.',
		(tot_mc + tot_mr) - (assistenza_mc + assistenza_mr + congiunte_mc + congiunte_mr 
                + didattica_mc + didattica_mr + ricerca_mc + ricerca_mr + studio_mc + studio_mr) 
                        AS 'Diff. Tot. Pag.',
		tot_mc - (assistenza_mc + congiunte_mc + didattica_mc + ricerca_mc + studio_mc ) 
                        AS 'Diff. Tot. Pag. Comp.'
	FROM #MIUR_balance ORDER BY sortcode
END
ELSE
BEGIN

	SELECT sortcode AS Codice, description AS Descrizione, 
		(tot_fc + tot_fr) AS 'Tot. Acc.',
		tot_fc AS 'Tot. Acc. Comp.',
		(tot_mc + tot_mr) AS 'Tot. Inc.',
		tot_mc AS 'Tot. Inc. Comp.',
		(assistenza_fc + assistenza_fr) AS 'Tot. Acc. ASSISTENZIALE',
                assistenza_fc AS 'Tot. Acc. Comp.ASSISTENZIALE',
		(assistenza_mc + assistenza_mr) AS 'Tot. Inc.ASSISTENZIALE',
                 assistenza_mc AS 'Tot. Inc. Comp.ASSISTENZIALE',
		(congiunte_fc + congiunte_fr) AS 'Tot. Acc. ALTRI SERVIZI DI SUPPORTO', 
                congiunte_fc AS 'Tot. Acc. Comp.ALTRI SERVIZI DI SUPPORTO',
                (congiunte_mc + congiunte_mr) AS 'Tot. Inc.ALTRI SERVIZI DI SUPPORTO', 
                congiunte_mc AS 'Tot. Inc. Comp.ALTRI SERVIZI DI SUPPORTO',
                (didattica_fc + didattica_fr) AS 'Tot. Acc.SERVIZI FORMATIVI ISTITUZIONALI', 
                didattica_fc AS 'Tot. Acc. Comp.SERVIZI FORMATIVI ISTITUZIONALI',
                (didattica_mc + didattica_mr) AS 'Tot. Inc.SERVIZI FORMATIVI ISTITUZIONALI', 
                didattica_mc AS 'Tot. Inc. Comp.SERVIZI FORMATIVI ISTITUZIONALI',
                (ricerca_fc + ricerca_fr) AS 'Tot. Acc.RICERCA', 
                ricerca_fc AS 'Tot. Acc. Comp.RICERCA',
                (ricerca_mc + ricerca_mr) AS 'Tot. Inc.RICERCA',
                ricerca_mc AS 'Tot. Inc. Comp.RICERCA',
                (studio_fc + studio_fr) AS 'Tot. Acc.INTERVENTI DIRITTO ALLO STUDIO', 
                studio_fc AS 'Tot. Acc. Comp.INTERVENTI DIRITTO ALLO STUDIO',
                (studio_mc + studio_mr) AS 'Tot. Inc.INTERVENTI DIRITTO ALLO STUDIO', 
                studio_mc AS 'Tot. Inc. Comp.INTERVENTI DIRITTO ALLO STUDIO',
                jan01arrear AS 'Tot. Residui al 01/01',
		(tot_fc + tot_fr) - (tot_mc + tot_mr) AS 'Tot. Residui al 31/12',
		(tot_fc + tot_fr) - (assistenza_fc + assistenza_fr + congiunte_fc + congiunte_fr 
                + didattica_fc + didattica_fr + ricerca_fc + ricerca_fr + studio_fc + studio_fr) 
                        AS 'Diff. Tot. Acc.',
		tot_fc -(assistenza_fc + congiunte_fc + didattica_fc + ricerca_fc + studio_fc ) 
                        AS 'Diff. Tot. Acc. Comp.',
		(tot_mc + tot_mr) - (assistenza_mc + assistenza_mr + congiunte_mc + congiunte_mr 
                + didattica_mc + didattica_mr + ricerca_mc + ricerca_mr + studio_mc + studio_mr) 
                        AS 'Diff. Tot. Inc.',
		tot_mc - (assistenza_mc + congiunte_mc + didattica_mc + ricerca_mc + studio_mc ) 
                        AS 'Diff. Tot. Inc. Comp.'
	FROM #MIUR_balance ORDER BY sortcode

END

END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

