
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_miur]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_miur]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [exp_check_miur]
(
	@ayear int,
	@finpart char(1),
        @unified char(1)
)
AS BEGIN 

-- exec exp_check_miur 2009, 'E','N'
/* Versione 1.0.1 del 12/02/2007 ultima modifica: PINO */

	CREATE TABLE #err (msg varchar(1000))

	-- Per natura
	DECLARE @iMIUR int
	DECLARE @eMIUR int

	DECLARE @iSIOPE int
	DECLARE @eSIOPE int

	-- Per funzione
	DECLARE @iFUNZ int
	DECLARE @eFUNZ int

	DECLARE @iFUNZlast int
	DECLARE @eFUNZlast int
-- exp_check_miur '2009', 'S', 'S'
IF (@ayear <= 2006)
BEGIN
	SELECT @iMIUR = idsorkind from sortingkind WHERE codesorkind = '06_MIUR'
	SELECT @eMIUR = idsorkind from sortingkind WHERE codesorkind = '06_MIUR'

	SELECT @iFUNZ = idsorkind from sortingkind WHERE codesorkind = '07_MIURFUNZ'
	SELECT @eFUNZ = idsorkind from sortingkind WHERE codesorkind = '07_MIURFUNZ'

	SELECT @iSIOPE = idsorkind from sortingkind WHERE codesorkind = 'SIOPE'
	SELECT @eSIOPE = idsorkind from sortingkind WHERE codesorkind = 'SIOPE'

	SELECT @iFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @iFUNZlast is null 
		select @iFUNZlast from sortingkind where codesorkind = 'MIURFUNZ'

	SELECT @eFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	if @eFUNZlast is null 
		select @eFUNZlast from sortingkind where codesorkind = 'MIURFUNZ'
END
ELSE
BEGIN
	SELECT @iMIUR = idsorkind from sortingkind WHERE codesorkind = '07E_MIUR'
	SELECT @eMIUR = idsorkind from sortingkind WHERE codesorkind = '07U_MIUR'

	SELECT @iFUNZ = idsorkind from sortingkind WHERE codesorkind = '07_MIURFUNZ'
	SELECT @eFUNZ = idsorkind from sortingkind WHERE codesorkind = '07_MIURFUNZ'

	SELECT @iSIOPE = idsorkind from sortingkind WHERE codesorkind = '07E_SIOPE'
	SELECT @eSIOPE = idsorkind from sortingkind WHERE codesorkind = '07U_SIOPE'

	SELECT @iFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	IF @iFUNZlast is null
		SELECT @iFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'
		
	SELECT @eFUNZlast = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
	IF @eFUNZlast is null
		SELECT @eFUNZlast = idsorkind FROM sortingkind WHERE codesorkind = 'MIURFUNZ'
END

IF (@finpart = 'S')
BEGIN
	DECLARE @nphase_eMIUR int
	DECLARE @nphase_eSIOPE int
	DECLARE @nphase_eFUNZ int
	DECLARE @nphase_eFUNZlast int

	SELECT @nphase_eMIUR = nphaseexpense FROM sortingkind WHERE idsorkind = @eMIUR
	SELECT @nphase_eSIOPE = nphaseexpense FROM sortingkind WHERE idsorkind = @eSIOPE
	SELECT @nphase_eFUNZ = nphaseexpense FROM sortingkind WHERE idsorkind = @eFUNZ
	SELECT @nphase_eFUNZlast = nphaseexpense FROM sortingkind WHERE idsorkind = @eFUNZlast

	DECLARE @fase_eMIUR varchar(50)
	DECLARE @fase_eSIOPE varchar(50)
	DECLARE @fase_eFUNZ varchar(50)
	DECLARE @fase_eFUNZlast varchar(50)

	SELECT @fase_eMIUR = description FROM expensephase WHERE nphase = @nphase_eMIUR
	SELECT @fase_eSIOPE = description FROM expensephase WHERE nphase = @nphase_eSIOPE
	SELECT @fase_eFUNZ = description FROM expensephase WHERE nphase = @nphase_eFUNZ
	SELECT @fase_eFUNZlast = description FROM expensephase WHERE nphase = @nphase_eFUNZlast

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di spesa per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @eMIUR
		AND nphaseexpense IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di spesa per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @eFUNZ
		AND nphaseexpense IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di spesa per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @eSIOPE
		AND nphaseexpense IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di spesa per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @eFUNZlast
		AND nphaseexpense IS NULL

	IF (@nphase_eSIOPE = @nphase_eMIUR)
	BEGIN
		INSERT INTO #err VALUES('La classificazione SIOPE e MIUR devono essere associate a fasi di spesa differenti')
	END

	IF (@nphase_eFUNZ = @nphase_eFUNZlast)
	BEGIN
		INSERT INTO #err VALUES('La classificazione funzionali devono essere associati a fasi di spesa differenti')
	END

	INSERT INTO #err
	SELECT @fase_eMIUR + ' '+ CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' (residuo) non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @eMIUR)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eMIUR
		AND (ET.flag&1)=1 --Residuo
		--AND ET.curramount >0
		AND NOT EXISTS
		(SELECT ES.idexp
		FROM expensesorted ES
		join sorting on sorting.idsor = ES.idsor
		WHERE sorting.idsorkind = @eMIUR
			AND ES.ayear = @ayear
			AND E.idexp = ES.idexp)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_eSIOPE + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' (residuo) non è totalmente classificato secondo la classificazione per natura '
	+ (select codesorkind from sortingkind where idsorkind = @eSIOPE)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eSIOPE
		--AND ET.curramount>0
		AND (ET.flag&1)=1 --Residuo
		AND NOT EXISTS
		(SELECT ES.idexp
		FROM expensesorted ES
		join sorting on sorting.idsor = es.idsor
		WHERE sorting.idsorkind = @eSIOPE
			AND ES.ayear = @ayear
			AND E.idexp = ES.idexp)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_eMIUR + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per natura '
	+ (select codesorkind from sortingkind where idsorkind = @eMIUR)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eMIUR
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM expensesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @eMIUR
				AND ES.ayear = @ayear
				AND E.idexp = ES.idexp)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_eSIOPE + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @eSIOPE)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eSIOPE
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM expensesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @eSIOPE
				AND ES.ayear = @ayear
				AND E.idexp = ES.idexp)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_eFUNZ +' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @eFUNZ)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eFUNZ
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM expensesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @eFUNZ
				AND ES.ayear = @ayear
				AND E.idexp = ES.idexp)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_eFUNZlast + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @eFUNZLAST)
	+ ' sul bilancio ' + F.codefin
	FROM expense E
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN expensetotal ET
		ON E.idexp=ET.idexp
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_eFUNZlast
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM expensesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @eFUNZlast
				AND ES.ayear = @ayear
				AND E.idexp = ES.idexp)
		,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che la fase di impegno e l'ultima fase siano classificate in modo congruo (MIUR - SIOPE)
	INSERT INTO #err
	SELECT @fase_eMIUR + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non ha una classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @eMIUR)
	+ ' congrua con i suoi figli' +
	' in quanto il classificato sul codice ' + S_M.sortcode + ' é di €.' + CONVERT(varchar(15), SUM(MIUR.amount)) +
	' ed è inferiore al classificato dei figli pari a €.' + CONVERT(varchar(15),
	ISNULL(
		(SELECT SUM(SIOPE.amount)
		FROM expensesorted SIOPE
		JOIN expense E
			ON E.idexp = SIOPE.idexp 
		JOIN expenselink EL
			ON E.idexp = EL.idchild
		JOIN sorting S_S
			ON S_S.idsor = SIOPE.idsor
		WHERE EL.idparent=MIUR.idexp  
			AND S_S.idsorkind = @eSIOPE
			AND E.nphase = @nphase_eSIOPE
			AND S_M.sortcode = S_S.sortcode
			AND SIOPE.ayear = @ayear)
	,0))
	+ ' sul bilancio ' + F.codefin
	FROM expensesorted MIUR
	JOIN sorting S_M
		ON S_M.idsor = MIUR.idsor
	JOIN expense E
		ON E.idexp = MIUR.idexp
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S_M.idsorkind = @eMIUR
		AND MIUR.ayear = @ayear
		AND EY.ayear = @ayear
		AND E.nphase = @nphase_eMIUR
	GROUP BY MIUR.idexp, S_M.idsorkind, MIUR.idsor, S_M.sortcode, E.ymov, E.nmov, F.codefin
	HAVING SUM(MIUR.amount) < 
	ISNULL(
		(SELECT SUM(SIOPE.amount)
		FROM expensesorted SIOPE
		JOIN expense E
			ON E.idexp = SIOPE.idexp 
		JOIN expenselink EL
			ON E.idexp = EL.idchild
		JOIN sorting S_S
			ON S_S.idsor = SIOPE.idsor
		WHERE EL.idparent=MIUR.idexp  
			AND S_S.idsorkind = @eSIOPE
			AND E.nphase = @nphase_eSIOPE
			AND S_M.sortcode = S_S.sortcode
			AND SIOPE.ayear = @ayear)
	,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che la fase di impegno e l'ultima fase siano classificate in modo congruo (FUNZ - FUNZ)
	INSERT INTO #err
	SELECT @fase_eFUNZ+ ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non ha una classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @eFUNZ)
	+ ' congrua con i suoi figli' +
	' in quanto il classificato sul codice ' + S_M.sortcode + ' é di €.' + CONVERT(varchar(15), SUM(FUNZ.amount)) +
	' ed è inferiore al classificato dei figli pari a €.' + CONVERT(varchar(15),
	ISNULL(
		(SELECT SUM(FUNZLAST.amount)
		FROM expensesorted FUNZLAST
		JOIN expense E
			ON E.idexp = FUNZLAST.idexp 
		JOIN expenselink EL
			ON E.idexp = EL.idchild
		JOIN sorting S_S
			ON S_S.idsor = FUNZLAST.idsor
		WHERE EL.idparent=FUNZ.idexp 
		AND S_S.idsorkind = @eFUNZlast
			AND E.nphase = @nphase_eFUNZlast
			AND S_M.sortcode = S_S.sortcode
			AND FUNZLAST.ayear = @ayear)
	,0))
	+ ' sul bilancio ' + F.codefin
	FROM expensesorted FUNZ
	JOIN sorting S_M
		ON S_M.idsor = FUNZ.idsor
	JOIN expense E
		ON E.idexp = FUNZ.idexp
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S_M.idsorkind = @eFUNZ
		AND FUNZ.ayear = @ayear
		AND EY.ayear = @ayear
		AND E.nphase = @nphase_eFUNZ
	GROUP BY FUNZ.idexp, S_M.idsorkind, FUNZ.idsor, S_M.sortcode, E.ymov, E.nmov, F.codefin
	HAVING SUM(FUNZ.amount) < 
	ISNULL(
		(SELECT SUM(FUNZLAST.amount)
		FROM expensesorted FUNZLAST
		JOIN expense E
			ON E.idexp = FUNZLAST.idexp 
		JOIN expenselink EL
			ON E.idexp = EL.idchild
		JOIN sorting S_S
			ON S_S.idsor = FUNZLAST.idsor
		WHERE EL.idparent=FUNZ.idexp 
		AND S_S.idsorkind = @eFUNZlast
			AND E.nphase = @nphase_eFUNZlast
			AND S_M.sortcode = S_S.sortcode
			AND FUNZLAST.ayear = @ayear)
	,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che i pagamenti di un impegno non siano classificati su codici differenti da quelli dell'impegno (MIUR - SIOPE)
	INSERT INTO #err
	SELECT @fase_eSIOPE + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' è stato classificato per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @eSIOPE)
	+ ' con codice ' + S.sortcode + 
	' mentre il movimento padre ' + CONVERT(varchar(4), EPADRE.ymov) + '/' + CONVERT(varchar(10), EPADRE.nmov) +
	' non ha la stessa classificazione '
	+ ' sul bilancio ' + F.codefin
	FROM expensesorted ES
	JOIN sorting S
		ON ES.idsor = S.idsor and S.idsorkind = @eSIOPE
	JOIN expense E
		ON E.idexp = ES.idexp and E.nphase = @nphase_eSIOPE
	JOIN expenselink EL
		ON E.idexp=EL.idchild
		AND EL.nlevel=@nphase_eMIUR
	JOIN expense EPADRE
		ON EPADRE.idexp=EL.idparent
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	where ES.ayear = @ayear 
		AND EY.ayear = @ayear
		--and ES.amount>0
		AND S.sortcode NOT IN
	(SELECT MIUR.sortcode
	FROM sorting MIUR
	JOIN expensesorted ESM
		ON MIUR.idsor = ESM.idsor and ESM.ayear = @ayear
	WHERE MIUR.idsorkind = @eMIUR and ESM.idexp=EPADRE.idexp)
	ORDER BY E.ymov, E.nmov

	-- Controllo che i pagamenti di un impegno non siano classificati su codici differenti da quelli dell'impegno (FUNZ - FUNZ)
	INSERT INTO #err
	SELECT @fase_eFUNZlast+ ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' è stato classificato per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @eFUNZlast)
	+ ' con codice ' + S.sortcode + 
	' mentre il movimento padre ' + CONVERT(varchar(4), EPADRE.ymov) + '/' + CONVERT(varchar(10), EPADRE.nmov) +
	' non ha la stessa classificazione '
	+ ' sul bilancio ' + F.codefin
	FROM expensesorted ES
	JOIN sorting S
		ON ES.idsor = S.idsor
	JOIN expense E
		ON E.idexp = ES.idexp
	JOIN expenselink EL
		ON E.idexp=EL.idchild
		AND EL.nlevel=@nphase_eFUNZ
	JOIN expense EPADRE
		ON EPADRE.idexp=EL.idparent
	JOIN expenseyear EY
		ON EY.idexp = E.idexp
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S.idsorkind = @eFUNZlast
		AND ES.ayear = @ayear
		AND EY.ayear = @ayear
		--AND ES.amount>0
		AND E.nphase = @nphase_eFUNZlast
		AND S.sortcode NOT IN
	(SELECT FUNZ.sortcode
	FROM sorting FUNZ
	JOIN expensesorted ESM
		ON FUNZ.idsor = ESM.idsor
		and ESM.idexp = EPADRE.idexp
		AND ESM.ayear = @ayear
	WHERE FUNZ.idsorkind = @eFUNZ)
	ORDER BY E.ymov, E.nmov

END

IF (@finpart = 'E')
BEGIN
	DECLARE @nphase_iMIUR int
	DECLARE @nphase_iSIOPE int
	DECLARE @nphase_iFUNZ int
	DECLARE @nphase_iFUNZlast int

	SELECT @nphase_iMIUR = nphaseincome FROM sortingkind WHERE idsorkind = @iMIUR
	SELECT @nphase_iSIOPE = nphaseincome FROM sortingkind WHERE idsorkind = @iSIOPE
	SELECT @nphase_iFUNZ = nphaseincome FROM sortingkind WHERE idsorkind = @iFUNZ
	SELECT @nphase_iFUNZlast = nphaseincome FROM sortingkind WHERE idsorkind = @iFUNZlast

	DECLARE @fase_iMIUR varchar(50)
	DECLARE @fase_iSIOPE varchar(50)
	DECLARE @fase_iFUNZ varchar(50)
	DECLARE @fase_iFUNZlast varchar(50)

	SELECT @fase_iMIUR = description FROM incomephase WHERE nphase = @nphase_iMIUR
	SELECT @fase_iSIOPE = description FROM incomephase WHERE nphase = @nphase_iSIOPE
	SELECT @fase_iFUNZ = description FROM incomephase WHERE nphase = @nphase_iFUNZ
	SELECT @fase_iFUNZlast = description FROM incomephase WHERE nphase = @nphase_iFUNZlast

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di entrata per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @iMIUR
		AND nphaseincome IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di entrata per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @iFUNZ
		AND nphaseincome IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di entrata per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @iSIOPE
		AND nphaseincome IS NULL

	INSERT INTO #err
	SELECT 'Non è stata impostata la fase di entrata per la classificazione di codice ' + codesorkind
	FROM sortingkind
	WHERE idsorkind = @iFUNZlast
		AND nphaseincome IS NULL

	IF (@nphase_iSIOPE = @nphase_iMIUR)
	BEGIN
		INSERT INTO #err VALUES('La classificazione SIOPE e MIUR devono essere associate a fasi di entrata differenti')
	END

	IF (@nphase_iFUNZ = @nphase_iFUNZlast)
	BEGIN
		INSERT INTO #err VALUES('La classificazione funzionali devono essere associati a fasi di entrata differenti')
	END

	INSERT INTO #err
	SELECT @fase_iMIUR + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iMIUR)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE ET.ayear = @ayear
		AND E.nphase = @nphase_iMIUR
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM incomesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @iMIUR
				AND ES.ayear = @ayear
				AND E.idinc = ES.idinc)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_iMIUR + ' '+ CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' (residuo) non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iMIUR)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_iMIUR
		AND (ET.flag&1)=1    ---Residuo
		--AND ET.curramount>0
		AND NOT EXISTS
		(SELECT ES.idinc
		FROM incomesorted ES
		join sorting on sorting.idsor = es.idsor
		WHERE sorting.idsorkind = @iMIUR
			AND ES.ayear = @ayear
			AND E.idinc = ES.idinc)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_iSIOPE + ' ' +CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iSIOPE)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_iSIOPE
		AND (ET.flag&1)=1 ---Residuo
		--AND ET.curramount>0
		AND NOT EXISTS
		(SELECT ES.idinc
		FROM incomesorted ES
		join sorting on sorting.idsor = es.idsor
		WHERE sorting.idsorkind = @iSIOPE
			AND ES.ayear = @ayear
			AND E.idinc = ES.idinc)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_iSIOPE + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iSIOPE)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_iSIOPE
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM incomesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @iSIOPE
				AND ES.ayear = @ayear
				AND E.idinc = ES.idinc)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_iFUNZ + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @iFUNZ)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_iFUNZ
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM incomesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @iFUNZ
				AND ES.ayear = @ayear
				AND E.idinc = ES.idinc)
		,0)
	ORDER BY E.ymov, E.nmov

	INSERT INTO #err
	SELECT @fase_iFUNZlast + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non è totalmente classificato secondo la classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @iFUNZlast)
	+ ' sul bilancio ' + F.codefin
	FROM income E
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN incometotal ET
		ON E.idinc=ET.idinc
		AND ET.ayear=EY.ayear
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE EY.ayear = @ayear
		AND E.nphase = @nphase_iFUNZlast
		AND ET.curramount <>
		ISNULL(
			(SELECT SUM(amount)
			FROM incomesorted ES
			join sorting on sorting.idsor = es.idsor
			WHERE sorting.idsorkind = @iFUNZlast
				AND ES.ayear = @ayear
				AND E.idinc = ES.idinc)
		,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che la fase di accertamento e l'ultima fase siano classificate in modo congruo (MIUR - SIOPE)
	INSERT INTO #err
	SELECT @fase_iMIUR + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non ha una classificazione per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iMIUR)
	+ ' congrua con i suoi figli' +
	' in quanto il classificato sul codice ' + S_M.sortcode + ' é di €.' + CONVERT(varchar(15), SUM(MIUR.amount)) +
	' ed è inferiore al classificato dei figli pari a €.' + CONVERT(varchar(15),
	ISNULL(
		(SELECT SUM(SIOPE.amount)
		FROM incomesorted SIOPE
		JOIN income E
			ON E.idinc = SIOPE.idinc 
		JOIN incomelink IL
			ON E.idinc = IL.idchild
		JOIN sorting S_S
			ON S_S.idsor = SIOPE.idsor
		WHERE IL.idparent=MIUR.idinc  
			AND S_S.idsorkind = @iSIOPE
			AND E.nphase = @nphase_iSIOPE
			AND S_M.sortcode = S_S.sortcode
			AND SIOPE.ayear = @ayear)
	,0))
	+ ' sul bilancio ' + F.codefin
	FROM incomesorted MIUR
	JOIN sorting S_M
		ON S_M.idsor = MIUR.idsor
	JOIN income E
		ON E.idinc = MIUR.idinc
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S_M.idsorkind = @iMIUR
		AND MIUR.ayear = @ayear
		AND EY.ayear = @ayear
		AND E.nphase = @nphase_iMIUR
	GROUP BY MIUR.idinc, S_M.idsorkind, MIUR.idsor, S_M.sortcode, E.ymov, E.nmov, F.codefin
	HAVING SUM(MIUR.amount) < 
	ISNULL(
		(SELECT SUM(SIOPE.amount)
		FROM incomesorted SIOPE
		JOIN income E
			ON E.idinc = SIOPE.idinc 
		JOIN incomelink IL
			ON E.idinc = IL.idchild
		JOIN sorting S_S
			ON S_S.idsor = SIOPE.idsor
		WHERE IL.idparent=MIUR.idinc 
			AND S_S.idsorkind = @iSIOPE
			AND E.nphase = @nphase_iSIOPE
			AND S_M.sortcode = S_S.sortcode
			AND SIOPE.ayear = @ayear)
	,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che la fase di accertamento e l'ultima fase siano classificate in modo congruo (FUNZ - FUNZ)
	INSERT INTO #err
	SELECT @fase_iFUNZ + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' non ha una classificazione per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @iFUNZ)
	+ ' congrua con i suoi figli' +
	' in quanto il classificato sul codice ' + S_M.sortcode + ' é di €.' + CONVERT(varchar(15), SUM(FUNZ.amount)) +
	' ed è inferiore al classificato dei figli pari a €.' + CONVERT(varchar(15),
	ISNULL(
		(SELECT SUM(FUNZLAST.amount)
		FROM incomesorted FUNZLAST
		JOIN income E
			ON E.idinc = FUNZLAST.idinc 
		JOIN incomelink IL
			ON E.idinc = IL.idchild
		JOIN sorting S_S
			ON S_S.idsor = FUNZLAST.idsor
		WHERE IL.idparent=FUNZ.idinc 
		AND S_S.idsorkind = @iFUNZlast
			AND E.nphase = @nphase_iFUNZlast
			AND S_M.sortcode = S_S.sortcode
			AND FUNZLAST.ayear = @ayear)
	,0))
	+ ' sul bilancio ' + F.codefin
	FROM incomesorted FUNZ
	JOIN sorting S_M
		ON S_M.idsor = FUNZ.idsor
	JOIN income E
		ON E.idinc = FUNZ.idinc
	JOIN incomeyear EY
		ON E.idinc = EY.idinc
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S_M.idsorkind = @iFUNZ
		AND FUNZ.ayear = @ayear
		AND EY.ayear = @ayear
		AND E.nphase = @nphase_iFUNZ
	GROUP BY FUNZ.idinc, S_M.idsorkind, FUNZ.idsor, S_M.sortcode, E.ymov, E.nmov, F.codefin
	HAVING SUM(FUNZ.amount) < 
	ISNULL(
		(SELECT SUM(FUNZLAST.amount)
		FROM incomesorted FUNZLAST
		JOIN income E
			ON E.idinc = FUNZLAST.idinc 
		JOIN incomelink IL
			ON E.idinc = IL.idchild
		JOIN sorting S_S
			ON S_S.idsor = FUNZLAST.idsor
		WHERE IL.idparent=FUNZ.idinc 
		AND S_S.idsorkind = @iFUNZlast
			AND E.nphase = @nphase_iFUNZlast
			AND S_M.sortcode = S_S.sortcode
			AND FUNZLAST.ayear = @ayear)
	,0)
	ORDER BY E.ymov, E.nmov

	-- Controllo che gli incassi di un accertamento non siano classificati su codici differenti da quelli dell'accertamento (MIUR - SIOPE)
	INSERT INTO #err
	SELECT @fase_iSIOPE + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' è stato classificato per natura ' 
	+ (select codesorkind from sortingkind where idsorkind = @iSIOPE)
	+ ' con codice ' 
	+ S.sortcode
	+ ' mentre il movimento padre ' + CONVERT(varchar(4), EPADRE.ymov) + '/' + CONVERT(varchar(10), EPADRE.nmov) +
	' non ha la stessa classificazione '
	+ ' sul bilancio ' + F.codefin
	FROM incomesorted ES
	JOIN sorting S
		ON ES.idsor = S.idsor
	JOIN income E
		ON E.idinc = ES.idinc
	JOIN incomelink IL
		ON E.idinc=IL.idchild
		AND IL.nlevel=@nphase_iMIUR
	JOIN income EPADRE
		ON EPADRE.idinc=IL.idparent
	JOIN incomeyear EY
		ON EY.idinc = E.idinc
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S.idsorkind = @iSIOPE
		AND ES.ayear = @ayear
		AND EY.ayear = @ayear
		--AND ES.amount>0
		AND E.nphase = @nphase_iSIOPE
		AND S.sortcode NOT IN
	(SELECT MIUR.sortcode
	FROM sorting MIUR
	JOIN incomesorted ESM
		ON MIUR.idsor = ESM.idsor
	WHERE ESM.idinc = EPADRE.idinc
		AND	MIUR.idsorkind = @iMIUR
		AND S.sortcode = MIUR.sortcode
		AND ESM.ayear = @ayear)
	ORDER BY E.ymov, E.nmov

	-- Controllo che gli incassi di un accertamento non siano classificati su codici differenti da quelli dell'accertamento (FUNZ - FUNZ)
	INSERT INTO #err
	SELECT @fase_iFUNZlast + ' ' + CONVERT(varchar(4), E.ymov) + '/' + CONVERT(varchar(10), E.nmov) +
	' è stato classificato per funzione ' 
	+ (select codesorkind from sortingkind where idsorkind = @iFUNZlast)
	+ ' con codice ' + S.sortcode + 
	' mentre il movimento padre ' + CONVERT(varchar(4), EPADRE.ymov) + '/' + CONVERT(varchar(10), EPADRE.nmov) +
	' non ha la stessa classificazione '
	+ ' sul bilancio ' + F.codefin
	FROM incomesorted ES
	JOIN sorting S
		ON ES.idsor = S.idsor
	JOIN income E
		ON E.idinc = ES.idinc
	JOIN incomelink IL
		ON E.idinc=IL.idchild
		AND IL.nlevel=@nphase_iFUNZ
	JOIN income EPADRE
		ON EPADRE.idinc=IL.idparent

	JOIN incomeyear EY
		ON EY.idinc = E.idinc
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE S.idsorkind = @iFUNZlast
		AND ES.ayear = @ayear
		AND EY.ayear = @ayear
		--AND ES.amount>0
		AND E.nphase = @nphase_iFUNZlast
		AND S.sortcode NOT IN
	(SELECT FUNZ.sortcode
	FROM sorting FUNZ
	JOIN incomesorted ESM
		ON FUNZ.idsor = ESM.idsor
	WHERE ESM.idinc = EPADRE.idinc
	AND FUNZ.idsorkind = @iFUNZ
		AND S.sortcode = FUNZ.sortcode
		AND ESM.ayear = @ayear)
	ORDER BY E.ymov, E.nmov

END


DECLARE @nomedipartimento varchar(500)
SET  @nomedipartimento  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')



IF (@unified='S')
BEGIN
        SELECT msg, @nomedipartimento as department
        FROM #err
END
ELSE
BEGIN
        SELECT *
        FROM #err

END
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


