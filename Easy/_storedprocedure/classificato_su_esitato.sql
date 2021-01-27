
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


if exists (select * from dbo.sysobjects where id = object_id(N'[classificato_su_esitato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [classificato_su_esitato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE classificato_su_esitato
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idsorkind int,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@finpart char(1)
)
AS BEGIN
/* Versione 1.0.0 del 04/09/2007 ultima modifica: SARA */

-- Caso 1: showupb = 'N' => consolida senza UPB
-- Caso 2: showupb = 'S' => controlla UPB
-- Caso 2.1: UPB non specificato => visualizza tutti gli UPB
-- Caso 2.2: UPB specificato => vedi showchildupb
-- Caso 2.1.1: showchildupb = 'N' => consolida rispetto all'UPB selezionato
-- Caso 2.1.2: showchildupb = 'S' => visualizza tutti gli UPB figli di quello scelto, oltre che quello scelto
CREATE TABLE #class
(
	idfin int,
	idupb varchar(36),
	idsorkind int,
	idsor varchar(32),
	amount decimal(19,2)
)

IF (@idupb IS NULL)
BEGIN
	SET @idupb = '%'
END

DECLARE @originalidupb varchar(36)
SET @originalidupb = @idupb

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%'
END

IF (@finpart = 'S')
BEGIN
	INSERT INTO #class
	(
		idfin,
		idupb,
		idsorkind,
		idsor,
		amount
	)
	SELECT
		EY.idfin, 
		EY.idupb, 
		@idsorkind,
		FS.idsor,
		SUM(B.amount * ISNULL(FS.quota,0)) 
	FROM banktransaction B
	JOIN expense E
		ON B.idexp = E.idexp
	JOIN expenseyear EY
		ON E.idexp = EY.idexp
	JOIN finsorting FS
		ON FS.idfin = EY.idfin
	join sorting on fs.idsor = sorting.idsor
	JOIN fin F
		ON F.idfin = EY.idfin
	WHERE sorting.idsorkind = @idsorkind
		AND F.ayear = @ayear
		AND B.transactiondate BETWEEN @start AND @stop
		AND EY.idupb LIKE @idupb
	GROUP BY EY.idfin, EY.idupb, FS.idsor
END

IF (@finpart = 'E')
BEGIN
	INSERT INTO #class
	(
		idfin,
		idupb,
		idsorkind,
		idsor,
		amount
	)
	SELECT
		IY.idfin,
		IY.idupb,
		@idsorkind,
		FS.idsor, 
		SUM(B.amount * ISNULL(FS.quota,0)) 
	FROM banktransaction B
	JOIN income I
		ON B.idinc = I.idinc
	JOIN incomeyear IY
		ON I.idinc = IY.idinc
	JOIN finsorting FS
		ON FS.idfin = IY.idfin
	join sorting on fs.idsor=sorting.idsor
	JOIN fin F
		ON F.idfin = IY.idfin
	WHERE sorting.idsorkind = @idsorkind
		AND F.ayear = @ayear
		AND B.transactiondate BETWEEN @start AND @stop
		AND IY.idupb LIKE @idupb
	GROUP BY IY.idfin, IY.idupb, FS.idsor
END

IF (@showupb = 'S') AND (@showchildupb = 'S') AND (@originalidupb = '%')
BEGIN
	SELECT 
		U.codeupb AS 'Cod. UPB',
		F.codefin AS 'Cod. Bilancio',
		sortcode AS 'Voce Class.',
		amount AS 'Importo'
	FROM #class
	JOIN upb U
		ON U.idupb = #class.idupb
	JOIN fin F
		ON F.idfin = #class.idfin
	JOIN sorting S
		ON S.idsorkind = #class.idsorkind
		AND S.idsor = #class.idsor
	ORDER BY U.printingorder, F.printingorder, S.sortcode
END
IF (@showupb = 'S') AND (@showchildupb = 'N') AND (@originalidupb <> '%')
BEGIN
	SELECT 
		U.codeupb AS 'Cod. UPB',
		F.codefin AS 'Cod. Bilancio',
		S.sortcode AS 'Voce Class.',
		SUM(amount) AS 'Importo'
	FROM #class
	JOIN upb U
		ON U.idupb = SUBSTRING(#class.idupb,1,LEN(@originalidupb))
	JOIN fin F
		ON F.idfin = #class.idfin
	JOIN sorting S
		ON S.idsorkind = #class.idsorkind
		AND S.idsor = #class.idsor
	GROUP BY U.codeupb, F.codefin, S.sortcode, SUBSTRING(#class.idupb,1,LEN(@originalidupb)), F.printingorder
	ORDER BY F.printingorder, S.sortcode
END
-- Se non voglio visualizzare l'UPB oppure l'upb di input non è specificato e non voglio mostrare i figli
-- allora consolido
IF (@showupb = 'N') OR ((@originalidupb = '%') AND (@showchildupb = 'N'))
BEGIN
	SELECT 
		F.codefin AS 'Cod. Bilancio',
		S.sortcode AS 'Voce Classificazione',
		SUM(amount) AS 'Importo'
	FROM #class
	JOIN fin F
		ON F.idfin = #class.idfin
	JOIN sorting S
		ON S.idsorkind = #class.idsorkind
		AND S.idsor = #class.idsor
	GROUP BY #class.idfin, #class.idsor, F.codefin, S.sortcode, F.printingorder
	ORDER BY F.printingorder, S.sortcode
END

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
