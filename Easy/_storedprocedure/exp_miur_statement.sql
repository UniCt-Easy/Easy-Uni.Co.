
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_miur_statement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_miur_statement]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [exp_miur_statement] 
(
	@ayear int,
	@movkind char(1)
)
AS BEGIN

/* Versione 1.0.0 del 17/09/2007 ultima modifica: PIERO */

-- Recupero codici delle classificazioni corrispondenti a MIUR e a MIURFUNZ tramite la tabella persmiur
DECLARE @codeMIUR int -- Variabile per indivisuare la classificazione MIUR
SELECT @codeMIUR = sortcode FROM miursetup WHERE internalcode = 'MIUR'
if @codeMIUR is null select @codeMIUR=idsorkind from sortingkind where codesorkind='MIUR'
	
DECLARE @codeFUNZ int -- Variabile per indivisuare la classificazione MIURFUNZ
SELECT @codeFUNZ = sortcode FROM miursetup WHERE internalcode = 'MIURFUNZ'
if @codeFUNZ is null select @codeFUNZ=idsorkind from sortingkind where codesorkind='MIURFUNZ'

-- Creazione della Tabella che visualizzerà il riepilogo dei dati su foglio Excel
CREATE TABLE #MIUR_balance
(
	idsor varchar(31), 
	sortcode varchar(20),
	description varchar(200),
	finphase_C decimal(20,2), -- importo corrente alla fase di bilancio parte competenza
	maxphase_C decimal(20,2), -- importo corrente alla fase di maxphase_C parte competenza
	finphase_R decimal(20,2), -- importo corrente alla fase di bilancio parte residui
	maxphase_R decimal(20,2), -- importo corrente alla fase di maxphase_C parte residui
	ricerca decimal(20,2), -- IPOTESI FONDAMENTALE:	idsor della MIURFUNZ 0001 S riferita a ricerca
	didattica decimal(20,2), --			idsor della MIURFUNZ 0002 S riferita a didattica
	assistenza decimal(20,2), --			idsor della MIURFUNZ 0003 S riferita a assistenza
	congiunte decimal(20,2)  --			idsor della MIURFUNZ 0004 S riferita a congiunte
)
-- Creazione tabella per la classificazione MIUR
CREATE TABLE #tmp_MIUR
(
	idmov int,
	idsor varchar(31),
	finphase_C decimal(20,2), -- importo corrente alla fase di bilancio parte competenza 
	finphase_R decimal(20,2)  -- importo corrente alla fase di bilancio parte residui 
)
-- Creazione tabella per la classificazione MIURFUNZ
CREATE TABLE #tmp_FUNZ
(
	idmov int,
	idsor varchar(31),
	finphase_C decimal(20,2), -- importo corrente alla fase di bilancio parte competenza 
	maxphase_C decimal(20,4), -- importo corrente alla fase di maxphase_C parte competenza    
	finphase_R decimal(20,2), -- importo corrente alla fase di bilancio parte residui 
	maxphase_R decimal(20,4), -- importo corrente alla fase di maxphase_C parte residui    
	ricerca decimal(20,4),
	didattica decimal(20,4),
	assistenza decimal(20,4),
	congiunte decimal(20,4)
)
DECLARE @phaseMIUR tinyint -- Fase di entrata/spesa associata alla classificazione MIUR
DECLARE @phaseFUNZ tinyint -- Fase di entrata/spesa associata alla classificazione MIURFUNZ
DECLARE @phasemax tinyint	    -- la massima fase di spesa/entrata
-- Codice per i movimenti di entrata 
IF @movkind = 'E'
BEGIN
	SELECT @phaseMIUR = nphaseincome FROM sortingkind WHERE idsorkind  = @codeMIUR
	-- E'  I M P O R T A N T I S S I M O che la fase sia l'ultima
	SELECT @phaseFUNZ = nphaseincome FROM sortingkind WHERE idsorkind  = @codeFUNZ
	SELECT @phasemax = (SELECT MAX(nphase) FROM incomephase )	-- eventualmente controllare se @fasemax <> @faseMIUR
--------------------------------------------------------------------------------------------------
	INSERT INTO #tmp_FUNZ (idmov, idsor,finphase_C,maxphase_C,finphase_R,maxphase_R,ricerca,didattica,assistenza,congiunte)
	SELECT 	I1.idinc,
		C1.idsor,
		CASE 
			WHEN  ((O1.flag&1) = 0) THEN ISNULL(SUM(C1.amount),0)		--somma dell'importo classificato al livello MIUR
			ELSE 0
		END AS finphase_C,
		CASE 
			WHEN  ((O1.flag&1) = 0)   THEN ISNULL(SUM(CONVERT(float,C1.amount))/SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0																			 
		END AS maxphase_C,																		 
		CASE 																				 
			WHEN  ((O1.flag&1) = 1) THEN ISNULL(SUM(C1.amount),0)
			ELSE 0
		END AS finphase_R,
		CASE 
			WHEN  ((O1.flag&1) = 1) THEN ISNULL(SUM(CONVERT(float,C1.amount))/SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS maxphase_R,
		CASE 
			WHEN C2.idsor = '0004'   THEN 
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS ricerca,
		CASE 
			WHEN C2.idsor = '0003' THEN  
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS didattica,
		CASE 
			WHEN C2.idsor = '0001' THEN 
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS assistenza,
		CASE 
			WHEN C2.idsor = '0002' THEN
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) * SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS congiunte
		FROM incomesorted C1		-- C1 imputazione a classificazione MIUR
		join sorting sorc1 on sorc1.idsor=c1.idsor
		JOIN incomeyear I1	-- I contiene il flagcompetenza dell'impegno classificato MIUR
			ON C1.idinc = I1.idinc 
		JOIN incometotal O1		-- O1 contiene l'finphase_C dell'impegno classificato MIUR
			ON C1.idinc = O1.idinc 
		JOIN income I
			ON I.idinc = I1.idinc
		LEFT OUTER JOIN incomelast S 	-- S riga di entrata che contiene le liquidazioni dell'impegno di sopra 
			ON S.idinc =  I1.idinc 
		LEFT JOIN incometotal O2	-- O2 contiene l'finphase_C della liquidazione classificata FUNZ 
			ON S.idinc = O2.idinc 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idinc,idsorkind,cc2.idsor,SUM(amount) AS amount
			FROM incomesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			WHERE CC2.ayear = @ayear
			GROUP BY idinc,idsorkind,cc2.idsor)	AS C2
		
		ON C2.idinc = S.idinc AND C2.idsorkind = @codeFUNZ
		WHERE sorC1.idsorkind = @codeMIUR 
			AND I.nphase = @phaseMIUR 
			AND ISNULL(O1.curramount,0)<>0 
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear					
			AND C1.ayear = @ayear
		GROUP BY I1.idinc,C1.idsor,O1.flag,C2.idsor,S.idinc
		ORDER BY I1.idinc,C1.idsor

	INSERT INTO #MIUR_balance
		(	idsor,			
			maxphase_C,			
			maxphase_R,			
			ricerca,			
			didattica,			
			assistenza,			
			congiunte				
		) 
	SELECT 
		idsor,
		ISNULL(SUM(maxphase_C),0),
		ISNULL(SUM(maxphase_R),0),
		ISNULL(SUM(ricerca),0),
		ISNULL(SUM(didattica),0),
		ISNULL(SUM(assistenza),0),
		ISNULL(SUM(congiunte),0)
	FROM #tmp_FUNZ
	GROUP BY idsor
	INSERT INTO #tmp_MIUR (idmov,idsor,finphase_C)
	SELECT DISTINCT idmov,idsor,finphase_C
		FROM #tmp_FUNZ ORDER BY idsor,idmov
	UPDATE #MIUR_balance
		SET finphase_C = (SELECT ISNULL(SUM(M.finphase_C),0) FROM #tmp_MIUR M WHERE M.idsor = #MIUR_balance.idsor)
	DELETE #tmp_MIUR
	INSERT INTO #tmp_MIUR (idmov,idsor,finphase_R)
	SELECT DISTINCT idmov,idsor,finphase_R
		FROM #tmp_FUNZ ORDER BY idsor,idmov
	UPDATE #MIUR_balance
		SET finphase_R = (SELECT ISNULL(SUM(M.finphase_R),0) FROM #tmp_MIUR M WHERE M.idsor = #MIUR_balance.idsor)
END	-- Fine codice per i movimenti di entrata
ELSE
-- Codice per i movimenti di spesa
BEGIN	
	SELECT @phaseMIUR = nphaseexpense		
		FROM sortingkind
		WHERE idsorkind  = @codeMIUR
	SELECT @phaseFUNZ = nphaseexpense		-- E'  I M P O R T A N T I S S I M O che la fase sia l'ultima
		FROM sortingkind
		WHERE idsorkind  = @codeFUNZ
	SELECT @phasemax = (SELECT MAX(nphase) FROM expensephase)	-- eventualmente controllare se @fasemax <> @faseMIUR
	INSERT INTO #tmp_FUNZ (idmov,idsor,finphase_C,maxphase_C,finphase_R,maxphase_R,ricerca,didattica,assistenza,congiunte)
	SELECT 	I1.idexp,
		C1.idsor,
		CASE 
			WHEN  ((O1.flag&1)=0) THEN ISNULL(SUM(C1.amount),0)		--somma dell'importo classificato al livello MIUR
			ELSE 0
		END AS finphase_C,
		CASE 
			WHEN  ((O1.flag&1)=0)   THEN ISNULL(SUM(CONVERT(float,C1.amount))/SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0																			 
		END AS maxphase_C,																		 
		CASE 																				 
			WHEN  ((O1.flag&1)=1) THEN ISNULL(SUM(C1.amount),0)
			ELSE 0
		END AS finphase_R,
		CASE 
			WHEN  ((O1.flag&1)=1)  THEN ISNULL(SUM(CONVERT(float,C1.amount))/SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS maxphase_R,
		CASE 
			WHEN C2.idsor = '0004'   THEN 
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) *SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS ricerca,
		CASE 
			WHEN C2.idsor = '0003' THEN  
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) * SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS didattica,
		CASE 
			WHEN C2.idsor = '0001' THEN 
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) * SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS assistenza,
		CASE 
			WHEN C2.idsor = '0002' THEN
				ISNULL(SUM(CONVERT(float,C1.amount))/
					SUM(CONVERT(float,O1.curramount)) * SUM(CONVERT(float,C2.amount)),0)
			ELSE 0
		END AS congiunte
		FROM expensesorted C1		-- C1 imputazione a classificazione MIUR
		join sorting sorc1 on sorc1.idsor = c1.idsor
		JOIN expenseyear I1	-- I contiene il flagcompetenza dell'impegno classificato MIUR
			ON C1.idexp = I1.idexp 
		JOIN expensetotal O1		-- O1 contiene l'finphase_C dell'impegno classificato MIUR
			ON C1.idexp = O1.idexp 
		JOIN expense E	
			ON E.idexp = I1.idexp
		LEFT JOIN expenselast S		-- S riga di spesa che contiene le liquidazioni dell'impegno di sopra 
			ON S.idexp = I1.idexp 

		LEFT JOIN expensetotal O2	-- O2 contiene l'importo corrente della liquidazione classificata FUNZ 
			ON S.idexp = O2.idexp 
			AND O2.ayear = @ayear
		LEFT JOIN
			(SELECT idexp,idsorkind,cc2.idsor, SUM(amount) AS amount
			FROM expensesorted CC2 
			join sorting on sorting.idsor = cc2.idsor
			where CC2.ayear=@ayear 
			GROUP BY idexp,idsorkind,cc2.idsor)	AS  C2
		ON C2.idexp = S.idexp AND C2.idsorkind = @codeFUNZ
		WHERE sorC1.idsorkind = @codeMIUR AND E.nphase = @phaseMIUR 
			AND ISNULL(O1.curramount,0)<>0
			AND I1.ayear = @ayear
			AND O1.ayear = @ayear
			AND C1.ayear=@ayear
		GROUP BY I1.idexp,C1.idsor, O1.flag, C2.idsor,S.idexp
		ORDER BY I1.idexp,C1.idsor
	INSERT INTO #MIUR_balance
		(	idsor,			
			maxphase_C,			
			maxphase_R,			
			ricerca,
			didattica,
			assistenza,
			congiunte
		) 
	SELECT 
		idsor,
		ISNULL(SUM(maxphase_C),0),
		ISNULL(SUM(maxphase_R),0),
		ISNULL(SUM(ricerca),0),
		ISNULL(SUM(didattica),0),
		ISNULL(SUM(assistenza),0),
		ISNULL(SUM(congiunte),0)
	FROM #tmp_FUNZ
	GROUP BY idsor
	INSERT INTO #tmp_MIUR (idmov,idsor,finphase_C)
	SELECT DISTINCT idmov,idsor,finphase_C
		FROM #tmp_FUNZ ORDER BY idsor,idmov
	UPDATE #MIUR_balance
		SET finphase_C = (SELECT ISNULL(SUM(M.finphase_C),0) FROM #tmp_MIUR M WHERE M.idsor = #MIUR_balance.idsor)
	DELETE #tmp_MIUR
	INSERT INTO #tmp_MIUR (idmov,idsor,finphase_R)
	SELECT DISTINCT idmov,idsor,finphase_R
		FROM #tmp_FUNZ ORDER BY idsor,idmov
	UPDATE #MIUR_balance
		SET finphase_R = (SELECT ISNULL(SUM(M.finphase_R),0) FROM #tmp_MIUR M WHERE M.idsor = #MIUR_balance.idsor)
END	-- Fine codice per i movimenti di spesa
UPDATE #MIUR_balance
	SET sortcode = (SELECT sortcode FROM sorting WHERE sorting.idsorkind = @codeMIUR and sorting.idsor = #MIUR_balance.idsor),
 	   description = (SELECT description FROM sorting WHERE sorting.idsorkind = @codeMIUR and sorting.idsor = #MIUR_balance.idsor)
INSERT INTO #MIUR_balance (idsor,sortcode,description)
SELECT idsor,sortcode,description FROM sortingusable 
WHERE idsorkind = @codeMIUR 
	AND (movkind IS NULL OR movkind like @movkind + '%')
	AND sortingusable.idsor NOT IN (SELECT idsor FROM #MIUR_balance)
DECLARE @fin_kind tinyint 
SELECT @fin_kind = fin_kind FROM config where ayear = @ayear
-- Impostazioni delle variabili che daranno il nome alle colonne esportate in Excel
DECLARE @column_1 nvarchar(20) -- Variabile per nome della prima colonna in Excel
SET @column_1 = (SELECT description FROM sorting WHERE idsorkind = @codeFUNZ AND idsor = '0001')
set @column_1=REPLACE(@column_1,'''','''''')
set @column_1=quotename(@column_1,'''')
DECLARE @column_2 nvarchar(50) -- Variabile per nome della seconda colonna in Excel
SET @column_2 = (SELECT description FROM sorting WHERE idsorkind = @codeFUNZ AND idsor = '0002')
set @column_2=REPLACE(@column_2,'''','''''')
set @column_2=quotename(@column_2,'''')
DECLARE @column_3 nvarchar(50) -- Variabile per nome della terza colonna in Excel
SET @column_3 = (SELECT description FROM sorting WHERE idsorkind = @codeFUNZ AND idsor = '0003')
set @column_3=REPLACE(@column_3,'''','''''')
set @column_3=quotename(@column_3,'''')
DECLARE @column_4 nvarchar(50) -- Variabile per nome della quarta colonna in Excel
SET @column_4 = (SELECT description FROM sorting WHERE idsorkind = @codeFUNZ AND idsor = '0004')
set @column_4=REPLACE(@column_4,'''','''''')
set @column_4=quotename(@column_4,'''')
DECLARE @SQL_string nvarchar(500) -- Variabile che immagazzina la stringa di comando SQL
IF @fin_kind = 1
BEGIN
select  @column_3, @column_4, @column_1, @column_2
select  N'SELECT '+
			'''Codice Miur'' = sortcode,description as Descrizione,Didattica ' + 
			@column_3 + ',Ricerca '+ @column_4 + 
			',Assistenza ' + @column_1 + ',Congiunte ' + @column_2 + 
			',''Impegnato competenza''=finphase_C, ''Pagato competenza''=maxphase_C, '+
			'''Impegnato residui''=finphase_R, ''Pagato residui''=maxphase_R '+
			' FROM #MIUR_balance ORDER BY idsor'

	IF @movkind = 'S'
	BEGIN
		SET @SQL_string = N'SELECT '+
			'''Codice Miur'' = sortcode,description as Descrizione,Didattica ' + 
			@column_3 + ',Ricerca '+ @column_4 + 
			',Assistenza ' + @column_1 + ',Congiunte ' + @column_2 + 
			',''Impegnato competenza''=finphase_C, ''Pagato competenza''=maxphase_C, '+
			'''Impegnato residui''=finphase_R, ''Pagato residui''=maxphase_R '+
			' FROM #MIUR_balance ORDER BY idsor'
	END
	ELSE
	BEGIN
		SET @SQL_string = N'SELECT '+
			'''Codice Miur'' = sortcode,description as Descrizione,Didattica ' + @column_3 + 
			',Ricerca ' + @column_4 + ',Assistenza ' + @column_1 + ',Congiunte ' + @column_2 + 
			',''Accertato competenza'' = finphase_C, ''Incassato competenza'' = maxphase_C, '+
			'''Accertato residui'' = finphase_R,''Incassato residui'' = maxphase_R '+
			' FROM #MIUR_balance ORDER BY idsor'
	END
	EXEC sp_executesql @SQL_string
END
ELSE
BEGIN
	IF @movkind = 'S'
	BEGIN
		SET @SQL_string = N'SELECT '+
			'''Codice Miur'' = sortcode,description as Descrizione,Didattica ' + @column_3 + 
			',Ricerca ' + @column_4 + ',Assistenza ' + @column_1 + ',Congiunte ' + @column_2 + 
			',''Pagato'' = maxphase_C + maxphase_R FROM #MIUR_balance ORDER BY idsor '
	END
	ELSE
	BEGIN
		SET @SQL_string = N'SELECT '+
			'''Codice Miur'' = sortcode,description as Descrizione,Didattica ' + @column_3 + 
			',Ricerca ' + @column_4 + ',Assistenza ' + @column_1 + ',Congiunte ' + @column_2 + 
			',''Incassato'' = maxphase_C + maxphase_R FROM #MIUR_balance ORDER BY idsor '
	END
	EXEC sp_executesql @SQL_string
END
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

exec exp_miur_statement 2007, 'S'






select parasubcontract.* from payroll  
join parasubcontract on parasubcontract.idcon=payroll.idcon  
JOIN service ON service.idser = parasubcontract.idser  
where parasubcontract.idreg='130' AND ISNULL(service.certificatekind,'') = 'U'  
and not exists (select * from exhibitedcud where exhibitedcud.idlinkedcon=payroll.idcon) and flagbalance='S' and disbursementdate is not null and fiscalyear='2007' and payroll.idcon<>'06000059' and not exists (select * from exhibitedcud where idcon=parasubcontract.idcon and idlinkedcon='06000059' and fiscalyear='2007')
