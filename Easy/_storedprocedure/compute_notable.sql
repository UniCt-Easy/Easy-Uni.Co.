
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_notable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_notable]
GO
--setuser 'amm'
--setuser 'amministrazione'
CREATE PROCEDURE compute_notable
(
	@ayear int,
	@iduser varchar(10),
	@idflowchart varchar(34),
	@varname varchar(30)
)
AS BEGIN

CREATE TABLE #outtable
(
	edittype varchar(100)
)

IF (@idflowchart IS NULL)
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT edittype
	FROM menu
	WHERE metadata = 'no_table'

	SELECT edittype FROM #outtable
	RETURN
END

-- Vengono considerate solamente le funzioni di restrizione che agiscono sul menu (le individuiamo noi)
-- Per tutte le restrizioni (tranne che per configurazione) prendo i primi 2 livelli di menu

-- Gestione Spese
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'spesa','spesa_read') ) > 0 )
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codspese'
	AND M2.metadata ='no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codspese'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Entrate
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('entrata','entrata_read') ) > 0   )
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codentrate'
	AND M2.metadata ='no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2	ON M.idmenu = M2.paridmenu
	JOIN menu M3	ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codentrate'
	AND M3.metadata = 'no_table'
	and isnull(M2.menucode ,'') <> 'pagopa'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione IVA
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'iva')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codiva'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codiva'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END



-- Gestione Flusso studenti
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'flussostudenti')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'pagopa'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'pagopa'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END



-- Gestione Patrimoniale
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('cespiti','cespiti_read'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)
	AND (M2.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
	AND (M3.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT DISTINCT M4.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4
		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M4.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M4.edittype)
	AND (M4.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT DISTINCT M5.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4
		ON M3.idmenu = M4.paridmenu
	JOIN menu M5
		ON M4.idmenu = M5.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M5.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M5.edittype)

	AND M5.metadata IS NOT NULL

END

-- Gestione E/P
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('econopatr', 'eco_entry'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('ep', 'scrittureEP')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('ep', 'scrittureEP')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Compensi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'compensi')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ( 
	'codContratto')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ( 
	'codContratto')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Dichiarazione
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'liquidazione')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcompensi'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcompensi'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'dichiarazione')) = 0
BEGIN
	DELETE FROM #outtable
	WHERE edittype IN
	(
		SELECT M2.edittype
		FROM menu M
		JOIN menu M2
			ON M.idmenu = M2.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M2.metadata = 'no_table'
	)

	DELETE FROM #outtable
	WHERE edittype IN
	(
		SELECT M3.edittype
		FROM menu M
		JOIN menu M2
			ON M.idmenu = M2.paridmenu
		JOIN menu M3
			ON M2.idmenu = M3.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M3.metadata = 'no_table'
	)
	
	
	-- cancellazione delle dichiarazioni CUD e raccolta ritenute per F24EP consolidato
	DELETE FROM #outtable 
	WHERE edittype IN
	(
	SELECT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata =  'no_table' 
	AND M2.edittype IN ('cud','fillunifiedtax'))
END
ELSE
BEGIN
	INSERT INTO  #outtable
	SELECT DISTINCT M2.edittype
		FROM menu M
		JOIN menu M2
			ON M.idmenu = M2.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M2.metadata = 'no_table'
		AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)
	

	INSERT INTO  #outtable
	SELECT DISTINCT M3.edittype
		FROM menu M
		JOIN menu M2
			ON M.idmenu = M2.paridmenu
		JOIN menu M3
			ON M2.idmenu = M3.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M3.metadata = 'no_table'
		AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
	
	
	-- dichiarazioni CUD e raccolta ritenute per F24EP consolidato
	INSERT INTO #outtable 
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata =  'no_table' 
	AND M2.edittype IN ('cud','fillunifiedtax') 
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)
END


-- Gestione Bilancio
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'bilancio','bilancio_read') ) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Fondo Economale
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('fondoec','fondoec_read')) > 0 )
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codpiccolespese'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codpiccolespese'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Trasmissione (Cassiere)
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('trasmissione','trasmissione_read')) > 0)
BEGIN
	if not exists( SELECT * FROM #outtable O 	WHERE O.edittype = 'expbank') begin
		INSERT INTO #outtable 	(edittype) values ('expbank')
	end
	
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcassiere'
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcassiere'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Classificazione
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'classificazione')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codclassificazioni', 'codImputazione', 'codVarBudget')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codclassificazioni', 'codImputazione', 'codVarBudget')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)

	if not exists( SELECT * FROM #outtable O 	WHERE O.edittype = 'transfprevinbudget') begin
		INSERT INTO #outtable 	(edittype) values ('transfprevinbudget')
	end
    
END

-- Gestione Configurazione
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'configurazione')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 'codconfbilancio', 'confxx')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 'codconfbilancio', 'confxx')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M4.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4
		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 'codconfbilancio', 'confxx')
	AND M4.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Scritture di Inizio e Fine Anno
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'endofyear_entry')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codchiusura')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codchiusura')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M4.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4
		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode IN ('codchiusura')
	AND M4.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END
-- Gestione Organigramma
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'organigramma')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codorganigramma'
	AND M2.metadata  = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codorganigramma'
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- Gestione Anagrafica
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'anagrafica' ) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT DISTINCT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codcreddeb', 'codtabelle','codlisteanag')
	AND M2.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M2.edittype)

	INSERT INTO #outtable
	SELECT DISTINCT M3.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	JOIN menu M3
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codcreddeb', 'codtabelle','codlisteanag')
	AND M3.metadata = 'no_table'
	AND NOT EXISTS
		(SELECT * FROM #outtable O
		WHERE O.edittype = M3.edittype)
END

-- se non è abilitata l'esecuzione dei wizard sulle anagrafiche rimuove i relativi edittype
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'anag_procedure')) = 0
BEGIN
	DELETE FROM #outtable 
	WHERE edittype IN
	(
	SELECT M2.edittype
	FROM menu M
	JOIN menu M2
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata =  'no_table' 
	AND M2.edittype IN ('wizanagrafiche','noduplicati','unificaanagrafiche','deleteunusable'))
END


-- la funzione di trasferimento degli organigrammi 
-- deve essere visibile solo a chi non è nell'organigramma
DELETE FROM #outtable WHERE edittype = 'trasflowchart'


IF ((SELECT COUNT(*) FROM #outtable) > 0)
BEGIN
	SELECT distinct edittype FROM #outtable order by edittype
	RETURN
END

INSERT INTO #outtable VALUES('dummy')
SELECT edittype FROM #outtable order by edittype
drop table #outtable

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

