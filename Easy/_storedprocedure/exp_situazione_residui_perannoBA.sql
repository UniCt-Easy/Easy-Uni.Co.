
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazione_residui_perannoBA]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazione_residui_perannoBA]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE         PROCEDURE [exp_situazione_residui_perannoBA]
(
	@ayear int,
	@date datetime,
	@levelusable tinyint
)
AS BEGIN   

-- exec exp_situazione_residui_perannoBA 2010,{ts '2010-12-31 00:00:00'},3

DECLARE	@idupb varchar(36)
SET @idupb = '%'	


DECLARE @cashvaliditykind tinyint
SELECT @cashvaliditykind = cashvaliditykind FROM config WHERE ayear = @ayear
DECLARE @finphase1 tinyint -- fase dello stanziamento
DECLARE @finphase tinyint
DECLARE @maxphase tinyint
DECLARE @finphase2 tinyint
declare @fin_kind tinyint
select @fin_kind = fin_kind
FROM config 
WHERE ayear = @ayear

-- L'ipotesi fondamentale di questo report è che la fase del residuo di stanziamento è la 1
-- Quella del residuo giuridico è la 3
-- Quella dello stanziamento è 1
SELECT @finphase1 = 1
SELECT @finphase2 = 2
SELECT @finphase = 3  ---<<== IPOTESI DEL REPORT
SELECT @maxphase = MAX(nphase) FROM expensephase

DECLARE @minlevelusable tinyint
SELECT  @minlevelusable = min(nlevel) FROM finlevel WHERE ayear = @ayear and (flag&2) <> 0

DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @minlevelusable)
begin
	SET @levelusable = @minlevelusable
end


CREATE TABLE #mov_Fase1_R (ayear1 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_Fase1_R (ayear1 int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #mov_finphase_R (ayear1 int, ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_finphase_R (ayear1 int, ayear3 int, idfin int, idupb varchar(36), total decimal(19,2))

CREATE TABLE #mov_maxphase_R (ayear1 int, ayear3 int, ayear5 int, idfin int, idupb varchar(36), total decimal(19,2))
CREATE TABLE #var_maxphase_R (ayear1 int, ayear3 int, ayear5 int, idfin int, idupb varchar(36), total decimal(19,2))

-- ayear1 contiene l'anno di creazione della fase 1
-- ayear3 contiene l'anno di creazione della fase 3



-- Creo anche la tabella per contenere la Fase 2 ai fini del calcolo dei Residui di Stanziamento. 
-- Stanziamenti = Residui di Stanziamento (Colonna 1):
-- disp F1 + F2 tutto ove F1>=2008, F1 < @ayear, F2< @ayear
INSERT INTO #mov_Fase1_R
(
	ayear1,
	idfin,
	idupb,
	total
)
	SELECT 
		E.ymov, 		-- anno del residuo di stanziamento (fase 1)
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb ,
		ISNULL(SUM(EY.amount),0) -- importo dello stanziamento  (fase 1)
	FROM expenseyear EY
	JOIN expense E
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp
		AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	WHERE EY.ayear = @ayear
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E.nphase = @finphase1
		AND E.adate <= @date
		AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)




INSERT INTO #var_Fase1_R
(	ayear1,
	idfin,
	idupb,
	total
)
SELECT  E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND ((ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase1
	AND EV.adate <= @date 
	AND EY.idupb like @idupb
GROUP BY E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)


INSERT INTO #mov_finphase_R
(
	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
	SELECT 
		E1.ymov, 		-- anno del residuo di stanziamento (fase 1)
		E3.ymov,		-- anno del residuo proprio
		ISNULL(FLK.idparent,EY.idfin),
		EY.idupb ,
		ISNULL(SUM(EY.amount),0) -- importo dell'impegno  (fase 3)
	FROM expenseyear EY
	JOIN expense E3
		ON E3.idexp = EY.idexp
	JOIN expensetotal ET
		ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	LEFT OUTER JOIN finlink FLK
		ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
	JOIN expenselink EL
		ON EL.idchild = E3.idexp
	JOIN expense E1
		ON E1.idexp = EL.idparent
	JOIN expenseyear EY1
		ON E1.idexp = EY1.idexp
	JOIN expensetotal ET1
		ON ET1.idexp = EY1.idexp AND ET1.ayear = EY1.ayear
	WHERE EY.ayear = @ayear
		AND EY1.ayear = @ayear
		AND ( (ET1.flag & 1) = 1) -- Residuo
		AND ( (ET.flag & 1) = 1) -- Residuo
		AND E3.nphase = @finphase
		AND EL.nlevel = @finphase1
		AND E3.adate <= @date
		AND EY.idupb like @idupb
GROUP BY E1.ymov,E3.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #var_finphase_R
(
	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
SELECT  E1.ymov,
	E.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	ISNULL(SUM(EV.amount),0)
FROM expensevar EV
JOIN expenseyear EY
	ON EY.idexp = EV.idexp
JOIN expensetotal ET
	ON ET.idexp = EY.idexp
	AND ET.ayear = EY.ayear
JOIN expense E
	ON EV.idexp = E.idexp	
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
JOIN expenselink EL
	ON EL.idchild = E.idexp
JOIN expense E1
	ON E1.idexp = EL.idparent
JOIN expenseyear EY1
	ON E1.idexp = EY1.idexp
JOIN expensetotal ET1
	ON ET1.idexp = EY1.idexp
	AND ET1.ayear = EY1.ayear
WHERE EV.yvar = @ayear
	AND EY.ayear = @ayear
	AND EY1.ayear = @ayear
	AND ( (ET1.flag & 1) = 1) -- Residuo
	AND ( (ET.flag & 1) = 1) -- Residuo
	AND E.nphase = @finphase
	AND EL.nlevel = @finphase1
	AND EV.adate <= @date 
	AND EY.idupb like @idupb
GROUP BY E1.ymov,E.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)

INSERT INTO #mov_maxphase_R(

	ayear1,
	ayear3,
	idfin,
	idupb,
	total
)
SELECT
	E1.ymov, E3.ymov,
	ISNULL(FLK.idparent,EY.idfin),
	EY.idupb,
	SUM(HPV.amount)
FROM historypaymentview HPV
JOIN expenseyear EY
	ON EY.idexp = HPV.idexp
LEFT OUTER JOIN finlink FLK
	ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
JOIN expenselink EL1
	ON EL1.idchild = HPV.idexp
JOIN expense E1
	ON E1.idexp = EL1.idparent
JOIN expenseyear EY1
	ON E1.idexp = EY1.idexp
	AND EY1.ayear = EY.ayear
JOIN expensetotal ET1
	ON ET1.idexp = EY1.idexp
	AND ET1.ayear = EY1.ayear
JOIN expenselink EL3
	ON EL3.idchild = HPV.idexp
JOIN expense E3
	ON E3.idexp = EL3.idparent
JOIN expenseyear EY3
	ON E3.idexp = EY3.idexp
	AND EY3.ayear = EY.ayear
WHERE HPV.competencydate <= @date
	AND EY.ayear = @ayear
	AND EL1.nlevel = @finphase1
	AND EL3.nlevel = @finphase
	AND ( (ET1.flag & 1) = 1) -- Residuo
	AND ( (HPV.totflag & 1) = 1)--  Residuo
	AND HPV.ymov = @ayear
	AND EY.idupb like @idupb
GROUP BY E1.ymov, E3.ymov, HPV.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)
	
IF @cashvaliditykind <> 4
	BEGIN
		INSERT INTO #var_maxphase_R
		(
			ayear1,
			ayear3,
			idfin,
			idupb,
			total
		)
		SELECT
			E1.ymov, 
			E3.ymov,
			ISNULL(FLK.idparent,EY.idfin),
			EY.idupb,
		SUM(EV.amount)
		FROM expensevar EV
		JOIN expenseyear EY
			ON EY.idexp = EV.idexp
		JOIN historypaymentview HPV
			ON HPV.idexp = EV.idexp
		LEFT OUTER JOIN finlink FLK
			ON FLK.idchild = EY.idfin AND FLK.nlevel = @levelusable
		JOIN expenselink EL1
			ON EL1.idchild = HPV.idexp
		JOIN expense E1
			ON E1.idexp = EL1.idparent
		JOIN expenseyear EY1
			ON E1.idexp = EY1.idexp
			AND EY1.ayear = EY.ayear
		JOIN expensetotal ET1
			ON ET1.idexp = EY1.idexp
			AND ET1.ayear = EY1.ayear
		JOIN expenselink EL3
			ON EL3.idchild = HPV.idexp
		JOIN expense E3
			ON E3.idexp = EL3.idparent
		JOIN expenseyear EY3
			ON E3.idexp = EY3.idexp
			AND EY3.ayear = EY.ayear
		WHERE HPV.competencydate <= @date
			AND EY.ayear = @ayear
			AND EV.yvar = @ayear
			AND EV.adate <= @date
			AND EL1.nlevel = @finphase1
			AND EL3.nlevel = @finphase
			AND ( (ET1.flag & 1) = 1) -- Residuo
			AND ( (HPV.totflag & 1) = 1)--  Residuo
			AND HPV.ymov = @ayear
			AND EY.idupb like @idupb
		GROUP BY E1.ymov, E3.ymov, HPV.ymov,EY.idupb,ISNULL(FLK.idparent,EY.idfin)
END


CREATE TABLE #residual(
		ayear int, 
		idfin int, 
		idupb varchar(36), 
		codeupb varchar(50),  upbprintingorder varchar(50), upb varchar(150), 
		Impegni_Propri decimal(19,2),
		var_Impegni_Propri decimal(19,2),
		Pag_Residui_Propri decimal (19,2),
		Imp_Propri_da_stanziamenti decimal(19,2),
		Pag_da_Stanziamenti decimal(19,2)
		)


--- IMPEGNI PROPRI 
-- Gli impegni propri  li voglio vedere sulla riga con anno = @year

-- Sara, Sono i Res. Propri al 01/01. Calcolati come:
-- F1, ove F1<=2007 (<2008), F1<@ayear
--	+
-- F3, ove F1 <@ayear, F3 < @ayear, F1 >= 2008
INSERT INTO #residual(ayear, idfin, idupb, Impegni_Propri)
SELECT  ayear1,
		idfin, 
		idupb,
		SUM(#mov_Fase1_R.total)
FROM #mov_Fase1_R
WHERE  #mov_Fase1_R.ayear1 < 2008
		AND #mov_Fase1_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb

-- Ora, aggiungo tutta la Fase 3
INSERT INTO #residual(ayear, idfin, idupb, Impegni_Propri)
SELECT ayear3,
		idfin,
		idupb, 
		SUM(#mov_finphase_R.total)
FROM #mov_finphase_R
WHERE #mov_finphase_R.ayear1 >= 2008
		AND #mov_finphase_R.ayear1 < @ayear
		AND #mov_finphase_R.ayear3 < @ayear
GROUP BY ayear3, idfin, idupb

--- VARIAZIONI IMPEGNI PROPRI 

-- Variazioni F3:
-- Var. RP:
-- var. F3, F1 <@ayear, F1>= 2008, F3 <=@ayear
-- +
-- var. F1, F1<2008, F1 <@ayear
INSERT INTO #residual(ayear, idfin, idupb, var_Impegni_Propri)
SELECT ayear3, 
		idfin, 
		idupb, 
		SUM(#var_finphase_R.total) 
FROM #var_finphase_R
WHERE #var_finphase_R.ayear3 < @ayear
		AND #var_finphase_R.ayear1 < @ayear 
		AND #var_finphase_R.ayear1 >= 2008
GROUP BY ayear3, idfin, idupb

INSERT INTO #residual(ayear, idfin, idupb, var_Impegni_Propri)
SELECT ayear1,
		idfin, 
		idupb,
		SUM(#var_Fase1_R.total) 
FROM #var_Fase1_R
WHERE #var_Fase1_R.ayear1 < 2008
		AND #var_Fase1_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb

--- PAGAMENTI RESIDUI PROPRI
INSERT INTO #residual(ayear, idfin, idupb, Pag_Residui_Propri) 
SELECT ayear1, 
		idfin, 
		idupb,
		SUM(#mov_maxphase_R.total) 
FROM #mov_maxphase_R
WHERE #mov_maxphase_R.ayear1 < 2008
		AND #mov_maxphase_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb

INSERT INTO #residual(ayear, idfin, idupb, Pag_Residui_Propri) 
SELECT ayear3,
		idfin,
		idupb,
		SUM(#mov_maxphase_R.total) 
FROM #mov_maxphase_R
WHERE #mov_maxphase_R.ayear1>= 2008
		AND #mov_maxphase_R.ayear3 < @ayear
GROUP BY  ayear3, idfin, idupb

--- VAR. PAGAMENTI RESIDUI PROPRI
-->>>> al netto delle variazioni
INSERT INTO #residual(ayear, idfin, idupb, Pag_Residui_Propri) 
SELECT ayear1, 
		idfin, 
		idupb,
		SUM(total) 
FROM #var_maxphase_R
WHERE #var_maxphase_R.ayear1 < 2008
		AND #var_maxphase_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb

INSERT INTO #residual(ayear, idfin, idupb, Pag_Residui_Propri) 
SELECT ayear3, 
		idfin, 
		idupb,
		SUM(total) 
FROM #var_maxphase_R
WHERE #var_maxphase_R.ayear1>= 2008
		AND #var_maxphase_R.ayear3 < @ayear
GROUP BY ayear3, idfin, idupb


-- Sara: Ix propri da Sx, o anche detti Residui divenuti propri (COLONNA 3). Calcolati come:
-- tutta F3, ove F3 = @ayear e F1 >= 2008 e F1< @ayear

-- Gli impegni propri  creati da stanziamenti vecchi
-- per esigenze di disegno dei report questi impegni si devono trovare sulla corrispondente riga di ayear1 

INSERT INTO #residual(ayear, idfin, idupb, Imp_Propri_da_stanziamenti) 
SELECT ayear1,---- DA CONTROLLATRE SE VA BENE 3 O VA MESSO 1
		idfin,
		idupb,
		SUM(total) 
FROM #mov_finphase_R
WHERE #mov_finphase_R.ayear3 = @ayear
		AND #mov_finphase_R.ayear1 >= 2008
		AND #mov_finphase_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb

-- Ci servono anche le variazioni degli Impegni propri da stanziamento -- Aggiunto da  Sara
INSERT INTO #residual(ayear, idfin, idupb, Imp_Propri_da_stanziamenti) 
SELECT ayear1, 
		idfin, 
		idupb, 
		SUM(#var_finphase_R.total) 
FROM #var_finphase_R
WHERE #var_finphase_R.ayear3 = @ayear
		AND #var_finphase_R.ayear1 > 2008 
		AND #var_finphase_R.ayear1 < @ayear
GROUP BY ayear1, idfin, idupb
 
INSERT INTO #residual(ayear, idfin, idupb, Pag_da_Stanziamenti) 
SELECT ayear1, 
		idfin, 
		idupb,
		SUM(#mov_maxphase_R.total) 
FROM #mov_maxphase_R
WHERE  #mov_maxphase_R.ayear1>=2008
	AND #mov_maxphase_R.ayear1 <@ayear
	AND #mov_maxphase_R.ayear3 =@ayear
GROUP BY ayear1, idfin, idupb

-- al netto delle variazioni
INSERT INTO #residual(ayear, idfin, idupb, Pag_da_Stanziamenti) 
SELECT ayear1, 
		idfin, 
		idupb,
		SUM(#var_maxphase_R.total) 
FROM #var_maxphase_R
WHERE #var_maxphase_R.ayear1>=2008
	AND #var_maxphase_R.ayear1 < @ayear
	AND #var_maxphase_R.ayear3 = @ayear
GROUP BY ayear1, idfin, idupb



/*
TABELLA DI OUT
1. Anno: si riferisce all’anno del residuo proprio, considerando che dal 2007, incluso, anche la prima e seconda fase è un residuo proprio, devono essere presi l’esercizio della fase 1 fino al 2007 incluso e l’esercizio della fase 3 dal 2008 in poi.

2. Voce di Bilancio: codice di bilancio del residuo proprio.

3. Denominazione: descrizione della voce di bilancio del residuo proprio.

4. Situazione Iniziale: situazione iniziale dei residui propri. Quindi Fase 1 e 2 fino al 2007 incluso non pagata, più fase 3 del 2008 non pagata. Naturalmente la fase 3 del 2008  non deve dipendere da una fase 1 e 2 fino al 2007 incluso. COLONNA 2
   * Impegni_Propri

5. Residui Propri pagati nell’esercizio: pagamenti effettuati sui residui del punto 4. COLONNA 4
	* Pag_Residui_Propri
	
6. Variazione dei residui propri: variazione dei residui inclusi nel punto 4. COLONNA 5/6
	* var_Impegni_Propri

7. Residui di stanziamento impegnati nell’esercizio e rimasti da pagare: ammontare non pagato della fase 3 effettuata su fase 1 del 2008. COLANNA 3 – COLONNA 4
	* Imp_Propri_da_stanziamenti - Pag_da_Stanziamenti

8. Totale dei residui propri al termine dell’esercizio:  4 – 5  + 6  + 7.   (n.b. 6 valore negativo).

*/

CREATE TABLE #output(
		ayear int, 
		idfin int, 
		idupb varchar(36), 
		Impegni_Propri decimal(19,2),
		var_Impegni_Propri decimal(19,2),
		Pag_Residui_Propri decimal (19,2),

		ResiduiStanziamento_RimstiDaPagare decimal(19,2),
		TotResiduiPropri decimal(19,2)
)

INSERT INTO #output(ayear,  idfin)
SELECT DISTINCT ayear,  idfin
FROM #residual

UPDATE #output --(4) situazione iniziale
SET Impegni_Propri = ISNULL((SELECT SUM(#residual.Impegni_Propri) FROM #residual
		WHERE #residual.idfin = #output.idfin
		AND #residual.ayear = #output.ayear), 0.0)


UPDATE #output  --(5)Residui Propri pagati nell’esercizio
SET Pag_Residui_Propri = ISNULL((SELECT SUM(#residual.Pag_Residui_Propri) FROM #residual
		WHERE #residual.idfin = #output.idfin
		AND #residual.ayear = #output.ayear), 0.0)

UPDATE #output  --(6)Variazione dei residui propri
SET var_Impegni_Propri = ISNULL((SELECT SUM(#residual.var_Impegni_Propri) FROM #residual
		WHERE #residual.idfin = #output.idfin
		AND #residual.ayear = #output.ayear), 0.0)


UPDATE #output --(7)Residui di stanziamento impegnati nell’esercizio e rimasti da pagare
SET ResiduiStanziamento_RimstiDaPagare = ISNULL((SELECT SUM(isnull(#residual.Imp_Propri_da_stanziamenti,0) - isnull(#residual.Pag_da_Stanziamenti,0)) FROM #residual
		WHERE #residual.idfin = #output.idfin
		AND #residual.ayear = #output.ayear), 0.0)



UPDATE #output 
SET TotResiduiPropri = Impegni_Propri - Pag_Residui_Propri + var_Impegni_Propri + ResiduiStanziamento_RimstiDaPagare


delete from #output where Impegni_Propri=0 and Pag_Residui_Propri=0 
			and var_Impegni_Propri=0 and ResiduiStanziamento_RimstiDaPagare=0

SELECT
		#output.ayear as 'Anno', 
		fin.codefin as 'Voce di Bilancio', 
		fin.title as 'Denominazione',
		-- idupb varchar(36),  MI SA CHE NON E' RICHIESTO
		Impegni_Propri as '(4)Situazione Iniziale',
		Pag_Residui_Propri as '(5)Residui Propri pagati nell’esercizio',
		var_Impegni_Propri as '(6)Variazione dei residui propri',
		ResiduiStanziamento_RimstiDaPagare as '(7)Residui di stanziamento impegnati nell’esercizio e rimasti da pagare',
		TotResiduiPropri as 'Totale dei residui propri al termine dell’esercizio( 4 – 5  + 6  + 7) '
FROM #output
JOIN fin
	ON #output.idfin = fin.idfin
order by fin.codefin,#output.ayear


END
/*

se fase1 < 2008 è tutto proprio
se fase 1 = 2008 allora stiamo almeno nel consuntivo 2009
	- se fase 3 = 2008 allora impegno proprio 
Quindi se fase 1 < 2008 allora porre = 2008
se fase 3 < 2008 porre uguale a 2008

CONSUNTIVO 2009 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno di stanziamento divenuto proprio nel 2009
CONSUNTIVO 2009 -------------------

CONSUNTIVO 2010 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno di stanziamento divenuto proprio nel 2010

se fase 1 = 2009 
	- se fase 3 = 2009 allora impegno proprio
CONSUNTIVO 2010 --------------------

CONSUNTIVO 2011 -------------------
se fase 1 = 2008 
	- se fase 3 = 2008 allora impegno proprio 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011

se fase 1 = 2009 
	- se fase 3 = 2009 allora impegno proprio
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011

se fase 1 = 2010 
	- se fase 3 = 2010 allora impegno proprio
	- se fase 3 = 2011 allora impegno di stanziamento divenuto proprio nel 2011
CONSUNTIVO 2010 --------------------

Quindi:
- se fase 3 = <esercizio consuntivo> allora è un residuo divenuto proprio
- se fase 3 < <esercizio consuntivo> è un residuo proprio

Inoltre 
è residuo di stanziamento:
Somma Fase1 - Somma di tutti gli impegni propri ovvero
 Somma Fase1 - Somma Fase3 < <esercizio consuntivo>
*/


GO
