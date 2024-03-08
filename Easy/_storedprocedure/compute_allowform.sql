
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


--setuser 'amm'
--select user

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_allowform]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_allowform]
GO
--setuser 'amm'
--setuser 'amministrazione'
--compute_allowform 2023,1,10
CREATE PROCEDURE compute_allowform
(
	@ayear int,
	@iduser varchar(10),
	@idflowchart varchar(34),
	@varname varchar(30)=null
)
AS BEGIN

CREATE TABLE #outtable
(
	tablename varchar(100)
)

IF (@idflowchart IS NULL)
BEGIN
	INSERT INTO #outtable
	SELECT  metadata
	FROM menu
	WHERE metadata IS NOT NULL 

	SELECT tablename FROM #outtable where tablename <>'no_table'
	drop table #outtable

	RETURN
END

-- Vengono considerate solamente le funzioni di restrizione che agiscono sul menu (le individuiamo noi)
-- Per tutte le restrizioni (tranne che per configurazione) prendo i primi 2 livelli di menu

-- Gestione Spese
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart		AND RF.variablename in ( 'management') ) > 0 )
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock)
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode in ( 'codmanrules','codtransazioni')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode in ( 'codmanrules','codtransazioni')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codspese'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codspese'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Entrate
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('entrata','entrata_read')) > 0   )
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codentrate'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codentrate'
	and isnull(M2.menucode,'') <>'pagopa'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione IVA
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename ='iva')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codiva'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codiva'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END



-- Gestione Flusso studenti (flusso crediti)
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename ='flussostudenti')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('pagopa','creditdetgomp')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('pagopa','creditdetgomp')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('mod_bollettino') )) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('mod_bollettino','visualizzazioneflussiwebs')
	and M2.menucode not in ('pagopa','creditdetgomp') 
	AND M2.metadata IS NOT NULL

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('pagopa','mod_bollettino','visualizzazioneflussiwebs')
	and M3.menucode not in ('inviocreditiapagopa','elaborazioneflussiwebs','creditdetgomp')
	AND M3.metadata IS NOT NULL
END


-- Gestione Fatture OR Visualizza Fatture
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('fattura','sel_fatture'))) > 0
BEGIN
    INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN('invoice','invoicedetail','ivaregister')

--- aggiungo la visualizzazione delle fatture elettroniche di vendita 
--- e delle fatture elettroniche acquisto estere
--- sul menu di secondo livello del Menu IVA
	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codiva'
	AND (M3.metadata  IN ('sdi_vendita','sdi_acquistoestere'))
	AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Magazzino
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('adm_magazzino','config_magazzino'))) > 0
BEGIN
    INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN ('store','stock','list','listclass','bookingdetail','booking', 
						  'ddt_in','storeunload','showcase','stocklocation')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
END


-- Gestione Card Magazzino
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('admin_card','crea_card'))) > 0
BEGIN
    INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN ('lcard')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
END

-- Gestione Patrimoniale
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('cespiti','cespiti_read'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
	AND (M2.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS 	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
	AND (M3.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT  M4.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M4.metadata IS NOT NULL
	--AND NOT EXISTS 	(SELECT * FROM #outtable O	WHERE O.tablename = M4.metadata)
	AND (M4.metadata <> 'sortingkind')

	INSERT INTO #outtable
	SELECT  M5.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 		ON M3.idmenu = M4.paridmenu
	JOIN menu M5 (nolock) 		ON M4.idmenu = M5.paridmenu
	WHERE M.menucode IN ('codpatrimonio', 'codcons')
	AND M5.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M5.metadata)

	AND M5.metadata IS NOT NULL

END

-- Gestione E/P
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('econopatr','eco_entry'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('ep', 'scrittureEP')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('ep', 'scrittureEP')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS		(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Compensi (Riguarda la configurazione)
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'compensi')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ( 
	'codContratto')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ( 
	'codContratto')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END


-- Gestione Compensi : solo Missioni
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'missioni', 'missioni_read'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codmissioni')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

END

-- Gestione Compensi : solo COCOCO
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('cococo'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ( 'codcococo')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)


	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ( 
	'codcococo')
	AND M3.metadata IS NOT NULL
	AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)

END

-- Gestione Compensi : solo tabelle secondarie COCOCO (PAT ecc.)
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('pat'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ( 'codcococo')
	AND M2.menucode IN ('codtabseccococo')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

END


-- Gestione Compensi : solo Occasionali
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('occasionali'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codoccasionali')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS		(SELECT * FROM #outtable O		WHERE O.tablename = M2.metadata)

END

-- Gestione Compensi : solo Professionali
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('professionali'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ( 'codprofessionali')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
END

-- Gestione Compensi : solo Dipendenti
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'dipendenti'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ( 'coddipendente')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

END

-- Gestione Compensi : solo Da Ufficio Stipendi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('stipendi_ct'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codadmpay')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

END

-- Gestione Compensi : solo Anagrafe delle Prestazioni
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'anagrafeprestazioni'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('anagprest')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
	AND (M2.metadata <> 'servicetrasmission')
END


-- Gestione Compensi : solo Flusso Movimenti
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('flussomovimenti'))) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codflussomovimenti')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

END

-- Anagrafe delle Prestazioni: Trasmissione incarichi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'trasmissione_ap'))) > 0
BEGIN
    INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN ('servicetrasmission')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
END

-- Anagrafe delle Prestazioni: Tipologia incarichi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'tipologiaincarichi_ap'))) > 0
BEGIN
    INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN ('serviceregistrykind')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
END

-- Gestione Liquidazione IVA
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'liquidazioneiva')) > 0
BEGIN
	--INSERT INTO #outtable
	--SELECT  M2.metadata
	--FROM menu M
	--JOIN menu M2 (nolock) 
	--	ON M.idmenu = M2.paridmenu
	--WHERE M.menucode = 'codiva'
	--AND M2.metadata IS NOT NULL
	--AND NOT EXISTS
	--	(SELECT * FROM #outtable O
	--	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M2.menucode = 'codliquidiva'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Certificazione dei Crediti
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'certificazionecrediti')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codiva'
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
   AND (M2.metadata = 'pcc')

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codiva'
	---AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
	AND (M3.metadata = 'pcc')
END

-- Gestione IVA : solo Fattura Elettronica, Fatture Acquisto
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('accetta_fe','rifiuta_fe','creaincontabilita_fe',
				'fe_all', 	'fe_ipa', 	'fe_ipa_rifamm'
			)) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codiva'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
	AND (M2.metadata  IN ('sdi_acquisto'))
	
	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codiva'
	AND (M3.metadata  IN ('sdi_acquisto'))
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcompensi'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcompensi'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Dichiarazione
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'dichiarazione')) = 0
BEGIN
	DELETE FROM #outtable 
	WHERE tablename IN
	(
	SELECT M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('coddenunce','codmod770')
	AND M2.metadata IS NOT NULL)

	DELETE FROM #outtable 
	WHERE tablename IN
	(SELECT M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock)		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('coddenunce','codmod770')
	AND M3.metadata IS NOT NULL)
	
	-- cancellazione delle dichiarazioni F24 e f24EP dal menu
	DELETE FROM #outtable 
	WHERE tablename IN
	(
	SELECT M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE  M2.metadata IN('f24ep','unifiedf24ep','f24ordinario'))
END
ELSE
BEGIN
	INSERT INTO  #outtable
	SELECT  M2.metadata
		FROM menu M (nolock) 
		JOIN menu M2 (nolock) 
			ON M.idmenu = M2.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M2.metadata IS NOT NULL
		--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
	

	INSERT INTO  #outtable
	SELECT  M3.metadata
		FROM menu M (nolock) 
		JOIN menu M2 (nolock) 
			ON M.idmenu = M2.paridmenu
		JOIN menu M3 (nolock) 
			ON M2.idmenu = M3.paridmenu
		WHERE M.menucode IN ('coddenunce','codmod770')
		AND M3.metadata IS NOT NULL
		--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
	
	INSERT INTO #outtable 
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.metadata IN('f24ep','unifiedf24ep','f24ordinario')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END
-- Gestione Variazioni di Bilancio
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'var_bilancio') ) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M2.metadata in('finvar','finvardetail')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codbilancio'
	AND M3.metadata in('finvar','finvardetail')
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codpiccolespese'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codpiccolespese'	AND M3.metadata IS NOT NULL
END

-- Gestione Trasmissione (Cassiere)
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart		AND RF.variablename in ('trasmissione')) > 0)
BEGIN
	if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'bankdispositionsetup') begin
		INSERT INTO #outtable 	(tablename) values ('bankdispositionsetup')
	end

	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcassiere'	AND M2.metadata IS NOT NULL

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcassiere'	AND M3.metadata IS NOT NULL

END

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ('trasmissione_read')) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)			ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcassiere'	AND M2.metadata IS NOT NULL AND M2.metadata <> 'bankdispositionsetup'

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcassiere'		AND M3.metadata IS NOT NULL AND M3.metadata <> 'bankdispositionsetup'

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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock)			ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codclassificazioni', 'codImputazione', 'codVarBudget')
	AND M2.metadata IS NOT NULL

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codclassificazioni', 'codImputazione', 'codVarBudget')
	AND M3.metadata IS NOT NULL

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'sorting') begin
		INSERT INTO #outtable 	(tablename) values ('sorting')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'incomesorted') begin
		INSERT INTO #outtable 	(tablename) values ('incomesorted')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'expensesorted') begin
		INSERT INTO #outtable 	(tablename) values ('expensesorted')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'sortingprevincomevar') begin
		INSERT INTO #outtable 	(tablename) values ('sortingprevincomevar')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'sortingprevexpensevar') begin
		INSERT INTO #outtable 	(tablename) values ('sortingprevexpensevar')
	--end

	
	if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'finsorting') begin
		INSERT INTO #outtable 	(tablename) values ('finsorting')
	end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'registrysorting') begin
		INSERT INTO #outtable 	(tablename) values ('registrysorting')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'upbsorting') begin
		INSERT INTO #outtable 	(tablename) values ('upbsorting')
	--end


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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 
			     'codconfbilancio', 'confxx','codclassmovimenti','codprospetti',
			     'codpatrimoniobenimob','epCFG','codconfanag','codmagazzino')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O		WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 
			     'codconfbilancio', 'confxx','codclassmovimenti','codprospetti',
			     'codpatrimoniobenimob','epCFG','codconfanag','codmagazzino')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)

	INSERT INTO #outtable
	SELECT  M4.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode IN ('codconfentrate', 'codconfspese', 'codconfcassiere', 
			     'codconfbilancio', 'confxx','codclassmovimenti', 'codprospetti',
			     'codpatrimoniobenimob', 'epCFG','codconfanag','codmagazzino')
	AND M4.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M4.metadata)

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'sortinglevel') begin
		INSERT INTO #outtable 	(tablename) values ('sortinglevel')
	--end

	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'sorting') begin
		INSERT INTO #outtable 	(tablename) values ('sorting')
	--end



	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'budgetvar') begin
		INSERT INTO #outtable 	(tablename) values ('budgetvar')
	--end
	
	--if not exists( SELECT * FROM #outtable O 	WHERE O.tablename = 'budgetvardetail') begin
		INSERT INTO #outtable 	(tablename) values ('budgetvardetail')
	--end


	   

END

-- Gestione Configurazione Anagrafiche
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'anag_config')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codconfanag'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS		(SELECT * FROM #outtable O		WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codconfanag'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
	
	INSERT INTO #outtable
	SELECT  M4.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 
		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode = 'codconfanag'
	AND M4.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M4.metadata)
END

-- Gestione Configurazione Magazzino
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'config_magazzino')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codmagazzino'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codmagazzino'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS 		(SELECT * FROM #outtable O		WHERE O.tablename = M3.metadata)
END


-- Gestione Configurazione Stipendi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'config_stipendi')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codcsa'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS		(SELECT * FROM #outtable O		WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codcsa'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
	
	INSERT INTO #outtable
	SELECT  M4.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 
		ON M3.idmenu = M4.paridmenu
	WHERE M.menucode = 'codcsa'
	AND M4.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M4.metadata)
END

-- Gestione Configurazione Stipendi
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'stipendi')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT M4.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	JOIN menu M4 (nolock) 
		ON M3.idmenu = M4.paridmenu
	WHERE  M.menucode in ('codadmpay')
	AND M2.menucode in ('csastipendi')
	AND M3.menucode in ('csaelabora','csaelenchi')
	AND M4.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)
END

-- Gestione Chiusura
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'chiusura')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codchiusura'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codchiusura'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)

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
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode = 'codorganigramma'
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode = 'codorganigramma'
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS		(SELECT * FROM #outtable O		WHERE O.tablename = M3.metadata)
END

-- Gestione Anagrafica
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename in ( 'anagrafica','anagrafica_read') ) > 0)
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M.menucode IN ('codcreddeb', 'codtabelle','codlisteanag')
	AND M2.metadata IS NOT NULL
	--AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)

	INSERT INTO #outtable
	SELECT  M3.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	JOIN menu M3 (nolock) 
		ON M2.idmenu = M3.paridmenu
	WHERE M.menucode IN ('codcreddeb', 'codtabelle','codlisteanag')
	AND M3.metadata IS NOT NULL
	--AND NOT EXISTS 	(SELECT * FROM #outtable O	WHERE O.tablename = M3.metadata)



	IF (
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename in ( 'responsabile','list_man') ) = 0)
	BEGIN 
		DELETE FROM #outtable where tablename = 'manager'
	END


END

-- Gestione Contratto Passivo
DELETE FROM #outtable WHERE tablename = 'mandate'
DELETE FROM #outtable WHERE tablename = 'mandatedetail'

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('ordine', 'sel_cp') )) > 0
BEGIN
	INSERT INTO #outtable VALUES('mandate')
	INSERT INTO #outtable VALUES('mandatedetail')
END


-- Gestione Contratto Attivo
DELETE FROM #outtable WHERE tablename = 'estimate'
DELETE FROM #outtable WHERE tablename = 'estimatedetail'

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename IN ('contrattivo', 'sel_ca') )) > 0
BEGIN
	INSERT INTO #outtable VALUES('estimate')
	INSERT INTO #outtable VALUES('estimatedetail')
END

INSERT INTO #outtable VALUES('resultparameter')
INSERT INTO #outtable VALUES('export')


--Gestione elenchi su finview
DELETE FROM #outtable WHERE tablename = 'finview'
IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart		AND RF.variablename in ( 'bilancio','bilancio_read') ) > 0)
BEGIN
	INSERT INTO #outtable VALUES('finview')
END

-- Gestione Politiche riguardanti le credenziali
IF (
	(SELECT COUNT(*)

	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF
		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart
		AND RF.variablename = 'credentials_policies')) > 0
BEGIN
	INSERT INTO #outtable
	SELECT  M2.metadata
	FROM menu M (nolock) 
	JOIN menu M2 (nolock) 
		ON M.idmenu = M2.paridmenu
	WHERE M2.menucode = 'credentials_policies'
	AND M2.metadata IS NOT NULL
	AND NOT EXISTS	(SELECT * FROM #outtable O	WHERE O.tablename = M2.metadata)
 END

-- Gestione Situazione Finanziaria / Amministrativa
DELETE FROM #outtable WHERE tablename = 'surplus'

IF (
	(SELECT COUNT(*)
	FROM flowchartrestrictedfunction FF
	JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
	WHERE FF.idflowchart = @idflowchart		AND RF.variablename IN ('previsione', 'sitfinanziaria_read') )) > 0
BEGIN
	INSERT INTO #outtable VALUES('surplus')
END

IF ((SELECT COUNT(*) FROM #outtable) > 0)
BEGIN
	SELECT distinct tablename FROM #outtable where tablename <>'no_table' order by tablename 
	drop table #outtable
	RETURN
END


INSERT INTO #outtable VALUES('dummy')
SELECT DISTINCT tablename FROM #outtable order by tablename
drop table #outtable
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

