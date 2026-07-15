/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_piano_annuale_flussi_cassa_all4]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_piano_annuale_flussi_cassa_all4]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_piano_annuale_flussi_cassa_all4]
(
	@ayear int, -- esercizio dell'esportazione
	@date_rif datetime, ---data di riferimento,
	@budgetpuro char(1) = null, --- Budget puro o derivato da finanziaria 
	@idsorkindfin_E int, --	=> Classificazione Siope DI_394_08.06.17 Entrate
	@idsorkindfin_S int --	=> Classificazione Siope DI_394_08.06.17 Spese
)
--- setuser 'amministrazione'
AS BEGIN
--- exec exp_piano_annuale_flussi_cassa_all4_new 2025, {ts '2025-09-04 00:00:00'} , 'S', 103,104
DECLARE @levelusable INT
DECLARE @MAXoplevel tinyint
SELECT  @MAXoplevel = MAX(nlevel)
FROM    sortinglevel
WHERE   idsorkind = @idsorkindfin_E
 
DECLARE @startfloatfund  decimal(19,2)
-- Fondo cassa al 01/01/anno corrente
SELECT 	@startfloatfund = ISNULL(startfloatfund, 0) 
FROM surplus
WHERE ayear = @ayear 

declare @date datetime 
SET @date  = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)


DECLARE @31dicCurr datetime
SET @31dicCurr = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear),105)

DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)

DECLARE  @nodelen int
SELECT   @nodelen = 2  --- LUNGHEZZA CODICE SPECIFICO DI LIVELLO  
--SELECT  idsorkind,* from sortingkind where  ( codesorkind in ('E_DI_394_08.06.17') )   --idsorkind = 8
--SELECT   @idsorkindfin = idsorkind from sortingkind where  ( codesorkind in ('E_DI_394_08.06.17') )   --idsorkind = 8
--SELECT  * from sortinglevel where  idsorkind = @idsorkindfin  
--SE non è stato selezionato il livello, prende l'ultimo livello operativo


declare @fin_kind tinyint
SELECT  @fin_kind = isnull(fin_kind,0) FROM config WHERE ayear = @ayear
DECLARE @infoadvance char(1)
SELECT  @infoadvance = paramvalue
FROM    generalreportparameter
WHERE   idparam = 'MostraAvanzo';

select @date_rif = isnull(@date_rif,GetDate())

DECLARE @trimestre int 
SELECT  @trimestre = 
	    CASE 
			WHEN @31dicCurr = @date_rif THEN 4
			WHEN @ayear = year(@date_rif) THEN ((DATEPART(q,@date_rif)) - 1) 
			ELSE 4 
	    END 

--SELECT @trimestre = 4
IF OBJECT_ID('tempdb..#mappatura_E') IS NOT NULL
DROP TABLE #mappatura_E

IF OBJECT_ID('tempdb..#mappatura_S') IS NOT NULL
DROP TABLE #mappatura_S

IF OBJECT_ID('tempdb..#OUTPUT_DATA') IS NOT NULL
DROP TABLE #OUTPUT_DATA

IF OBJECT_ID('tempdb..#PERCENTUALI') IS NOT NULL
DROP TABLE #PERCENTUALI

IF OBJECT_ID('tempdb..#PERCENTUALI_RICALCOLATE') IS NOT NULL
DROP TABLE #PERCENTUALI_RICALCOLATE

--- le voci di classificazione Entrate mancanti in mappatura si intendono per convenzione associate a una generica etichetta   (Altri incassi)
CREATE TABLE #mappatura_E
(
	sortcode varchar(50), nlevel int, description varchar(200), label varchar(200), printingorder varchar(10) 
)
INSERT INTO #mappatura_E
SELECT	sortcode , nlevel , description  , 'ETICHETTA',null
FROM    sorting  
WHERE   idsorkind = @idsorkindfin_E 
AND     sortcode IN ('1'
,'2'
,'5'
,'6'
,'402'
,'301'
,'501'
,'303'
,'40401'
,'40403'
)
 
update #mappatura_E set printingorder = 'B11',label = 'Proventi da tributi' where sortcode ='1'
update #mappatura_E set printingorder = 'B12',label = 'Trasferimenti in conto esercizio' where sortcode ='2'
update #mappatura_E set printingorder = 'B13',label = 'Trasferimenti in conto investimenti' where sortcode ='402'

update #mappatura_E set printingorder = 'B14',label = 'Ricavi delle vendite e prestazioni e proventi da servizi pubblici' where sortcode ='301'
update #mappatura_E set printingorder = 'B15',label = 'Ricavi da partecipazioni' where sortcode ='501'
update #mappatura_E set printingorder = 'B16',label = 'Interessi attivi' where sortcode ='303'
update #mappatura_E set printingorder = 'B17',label = '(Altri incassi)' where sortcode NOT IN ('1', '2','402', '301', '501', '303', '40403',  '40401', '5', '6')

update #mappatura_E set printingorder = 'B30',label = 'Disinvestimenti Attività immateriali' where sortcode ='40403'
update #mappatura_E set printingorder = 'B34',label = 'Disinvestimenti Attività materiali' where sortcode ='40401'
update #mappatura_E set printingorder = 'B38',label = 'Disinvestimenti Attività finanziarie' where sortcode ='5'
update #mappatura_E set printingorder = 'B43',label = 'Accensione prestiti' where sortcode ='6'

--select * from #mappatura_E
 
CREATE TABLE #mappatura_S
(
	sortcode varchar(50), nlevel int, description varchar(200), label varchar(200), printingorder VARCHAR(10) 
)

--- le voci di classificazione Uscite mancanti nella seguente mappatura si intendono per convenzione associate a una generica etichetta   (Altri pagamenti)
INSERT INTO #mappatura_S
SELECT	sortcode , nlevel , description  , 'ETICHETTA',null
FROM    sorting  
WHERE   idsorkind = @idsorkindfin_S
AND     sortcode IN ( 
'3',
'4',
'103',
'104',
'101',
'107',
'20201','20202','20203', '20204'
)


update #mappatura_S set printingorder = 'B20', label = '(Beni e servizi)'  where sortcode ='103'
update #mappatura_S set printingorder = 'B21', label = '(Trasferimenti)'   where sortcode ='104'
update #mappatura_S set printingorder = 'B22', label = '(Personale)'       where sortcode ='101'
update #mappatura_S set printingorder = 'B23', label = '(Interessi passivi)' where sortcode ='107'
update #mappatura_S set printingorder = 'B24', label = '(Altri pagamenti)' where sortcode NOT IN('103','104','101','107','20201','20202','20203','20204', '3','4')

update #mappatura_S set printingorder = 'B29', label = '(Investimenti) Attività immateriali'  where sortcode = '20203'
update #mappatura_S set printingorder = 'B33', label = '(Investimenti) Attività materiali' where sortcode IN ('20201','20202','20204') 
update #mappatura_S set printingorder = 'B37', label = '(Investimenti) Attività finanziarie' where sortcode ='3'
update #mappatura_S set printingorder = 'B44', label = '(Rimborso prestiti)' where sortcode ='4'
;


if(isnull(@levelusable,0)=0 )
Begin
	set @levelusable = @MAXoplevel
End;

DECLARE @cashvaliditykind 	tinyint
SELECT	@cashvaliditykind = cashvaliditykind
FROM 	config
WHERE 	ayear = @ayear

SET @finpart_bit = 0 --@finpart='E'

---- PER CHI USA BUDGET PURO PER OTTENERE INCASSATO E PAGATO
---- USO LA MAPPATURA BASATA SU 'SIOPE_E_18'  'SIOPE_U_18' 
DECLARE @codesorkind_siopeentrate varchar(20)
SET @codesorkind_siopeentrate   = 'SIOPE_E_18'
 
declare @idsorkind_siopeentrate int
select  @idsorkind_siopeentrate = idsorkind from sortingkind where codesorkind=@codesorkind_siopeentrate

DECLARE @codesorkind_siopespese varchar(20)
SET @codesorkind_siopespese   = 'SIOPE_U_18'
 
declare @idsorkind_siopespese int
select  @idsorkind_siopespese = idsorkind from sortingkind where codesorkind=@codesorkind_siopespese


DECLARE @levelusable_siopeentrate INT
 
SELECT  @levelusable_siopeentrate = MIN(nlevel) 
FROM 	sortinglevel WHERE idsorkind = @idsorkind_siopeentrate
AND 	  (flag&2)<>0

DECLARE @MAXoplevel_siopeentrate tinyint
SELECT  @MAXoplevel_siopeentrate = MAX(nlevel)
FROM    sortinglevel
WHERE   idsorkind = @idsorkind_siopeentrate


DECLARE @levelusable_siopespese INT
SELECT  @levelusable_siopespese = MIN(nlevel) 
FROM 	sortinglevel WHERE idsorkind = @idsorkind_siopespese
AND 	(flag&2)<>0

DECLARE @MAXoplevel_siopespese tinyint
SELECT  @MAXoplevel_siopespese = MAX(nlevel)
FROM    sortinglevel
WHERE   idsorkind = @idsorkind_siopespese

if(isnull(@levelusable_siopeentrate,0)=0 )
Begin
	set @levelusable_siopeentrate = @MAXoplevel_siopeentrate
End;

if(isnull(@levelusable_siopespese,0)=0 )
Begin
	set @levelusable_siopespese = @MAXoplevel_siopespese
End;


--SELECT '@MAXoplevel ENTRATE',@MAXoplevel
--SELECT '@levelusable ENTRATE',@levelusable
CREATE TABLE #OUTPUT_DATA
(
	kind varchar(20), label varchar(200), printingorder varchar(10), 
	curramount  decimal(19,2),
	trimestre_1 int, curramount_1 decimal(19,2),
	trimestre_2 int, curramount_2 decimal(19,2),
	trimestre_3 int, curramount_3 decimal(19,2), 
	trimestre_4 int, curramount_4 decimal(19,2)  
);

if (isnull(@budgetpuro, 'N') = 'N')
BEGIN
WITH FL_ENTRATE AS
(
SELECT	'ENTRATE' as kind,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
		substring(sorFin.sortcode, 1, 1)  as sortcode_1,
		substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
		substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		sorFin.sortcode,
		(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
		SUM(HPV.curramount*ISNULL(FS.quota,0)) as curramount
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date or (year(HPV.competencydate) = @ayear and   @cashvaliditykind = 4 )  ) 
		AND sl.idsorkind = @idsorkindfin_E
		AND sorFin.idsorkind = @idsorkindfin_E
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear -1 
		AND HPV.ymov = @ayear -1 
		AND @trimestre <> 4
	GROUP BY  sorFin.sortcode, HPV.competencydate,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
	--ORDER BY  sorFin.sortcode, month(HPV.competencydate)
    ) 
 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1 AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
	2 AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
	3 AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
	4 AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
	FROM FL_ENTRATE
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder   
	;

WITH FL_ENTRATE_ESERCIZIO AS
(
SELECT	'ENTRATE_ESERCIZIO' as kind,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
		substring(sorFin.sortcode, 1, 1)  as sortcode_1,
		substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
		substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		sorFin.sortcode,
		(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear +1 and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear +1 and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
		SUM(HPV.curramount*ISNULL(FS.quota,0)) as curramount
	FROM historyproceedsview HPV
	JOIN incomeyear IY
		ON IY.idinc = HPV.idinc
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl
		ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	--- anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date_rif or (year(HPV.competencydate) = (@ayear +1) and @cashvaliditykind = 4 )  ) 
		AND sl.idsorkind = @idsorkindfin_E
		AND sorFin.idsorkind = @idsorkindfin_E
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear  
		AND HPV.ymov = @ayear 
		AND @trimestre >0 
	GROUP BY  sorFin.sortcode, HPV.competencydate,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
	--ORDER BY  sorFin.sortcode, month(HPV.competencydate)
    ) 
 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1 AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
	2 AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
	3 AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
	4 AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
	FROM FL_ENTRATE_ESERCIZIO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder;

	END	
ELSE
BEGIN
WITH FL_ENTRATE_BUDGETPURO AS

(
			SELECT	'ENTRATE' as kind,
					coalesce(M5.label,M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
					coalesce(M5.printingorder,M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
					substring(sortInc.sortcode, 1, 1)  as sortcode_1,
					substring(sortInc.sortcode, 1,  @nodelen +1) as sortcode_2,
					substring(sortInc.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
					substring(sortInc.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
					substring(sortInc.sortcode, 1, 4*@nodelen +1+1 ) as sortcode_5,
					sortInc.sortcode,
					(len(sortInc.sortcode)-1)/ 2 + 1  as level, 
					CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
					CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
					SUM(INS.amount) as curramount
				FROM historyproceedsview HPV
				JOIN incomeyear IY
					ON IY.idinc = HPV.idinc
				JOIN incomesorted INS
					ON INS.idinc = HPV.idinc	
				JOIN sorting sortInc
					ON sortInc.idsor = INS.idsor				
				JOIN sortinglevel sl
					ON sl.idsorkind = sortInc.idsorkind and sortInc.nlevel = sl.nlevel 
				LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sortInc.sortcode, 1, 1)   and M1.nlevel = 1
				LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sortInc.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
				LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sortInc.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
				LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sortInc.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
				LEFT OUTER JOIN #mappatura_E M5 ON M5.sortcode = substring(sortInc.sortcode, 1, 4* @nodelen + 1 +1)    and M5.nlevel = 5
				--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
				WHERE (HPV.competencydate <= @date or (year(HPV.competencydate) = @ayear and   @cashvaliditykind = 4 )  ) 
					AND sl.idsorkind = @idsorkind_siopeentrate
					AND sortInc.idsorkind = @idsorkind_siopeentrate
					AND (sortInc.nlevel >= @levelusable_siopeentrate
						OR (sortInc.nlevel < @levelusable_siopeentrate
							and (select count(*) from sorting S where S.idsorkind = @idsorkind_siopeentrate 
							and S.paridsor = sortInc.idsor)=0
							AND (sl.flag&2)<>0
						   )
						)
					AND IY.ayear = @ayear -1 
					AND HPV.ymov = @ayear -1 
					AND @trimestre <> 4
				GROUP BY  sortInc.sortcode, HPV.competencydate,
					coalesce(M5.label,M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
					coalesce(M5.printingorder,M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
				--ORDER BY  sorFin.sortcode, month(HPV.competencydate)
				--ORDER BY  sorFin.sortcode, month(HPV.competencydate)
				) 
 
				INSERT INTO #OUTPUT_DATA
				(
					kind , label , printingorder, curramount,
					trimestre_1 , curramount_1 ,
					trimestre_2 , curramount_2 ,
					trimestre_3 , curramount_3 , 
					trimestre_4 , curramount_4 
				)

				SELECT kind, label, printingorder, SUM(curramount),
				1 AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
				2 AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
				3 AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
				4 AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
				FROM FL_ENTRATE_BUDGETPURO
				GROUP BY kind, label, printingorder 
				ORDER BY  printingorder   
				;

			WITH FL_ENTRATE_ESERCIZIO_BUDGETPURO AS
			(
			SELECT	'ENTRATE_ESERCIZIO' as kind,
					coalesce(M5.label,M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
					coalesce(M5.printingorder, M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
					substring(sortInc.sortcode, 1, 1)  as sortcode_1,
					substring(sortInc.sortcode, 1,  @nodelen +1) as sortcode_2,
					substring(sortInc.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
					substring(sortInc.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
					substring(sortInc.sortcode, 1, 4*@nodelen +1 +1  ) as sortcode_5,
					sortInc.sortcode,
					(len(sortInc.sortcode)-1)/ 2 + 1  as level, 
					CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear +1 and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
					CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear +1 and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
					SUM(INS.amount) as curramount
				FROM historyproceedsview HPV
				JOIN incomeyear IY
					ON IY.idinc = HPV.idinc
				JOIN incomesorted INS
					ON INS.idinc = HPV.idinc	
				JOIN sorting sortInc
					ON sortInc.idsor = INS.idsor				
				JOIN sortinglevel sl
					ON sl.idsorkind = sortInc.idsorkind and sortInc.nlevel = sl.nlevel 
				LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sortInc.sortcode, 1, 1)   and M1.nlevel = 1
				LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sortInc.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
				LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sortInc.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
				LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sortInc.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
				LEFT OUTER JOIN #mappatura_E M5 ON M5.sortcode = substring(sortInc.sortcode, 1, 4* @nodelen +1 +1)    and M5.nlevel = 5
			
				--- anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
				WHERE (HPV.competencydate <= @date_rif or (year(HPV.competencydate) = (@ayear +1) and @cashvaliditykind = 4 )  ) 
					AND sl.idsorkind = @idsorkind_siopeentrate
					AND sortInc.idsorkind = @idsorkind_siopeentrate
					AND (sortInc.nlevel >= @levelusable_siopeentrate
						OR (sortInc.nlevel < @levelusable_siopeentrate
							and (select count(*) from sorting S where S.idsorkind = @idsorkind_siopeentrate and S.paridsor = sortInc.idsor)=0
							AND (sl.flag&2)<>0
						   )
						)
					AND IY.ayear = @ayear  
					AND HPV.ymov = @ayear 
					AND @trimestre >0 
				GROUP BY  sortInc.sortcode, HPV.competencydate,
			coalesce(M5.label,M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
			coalesce(M5.printingorder,M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
				--ORDER BY  sorFin.sortcode, month(HPV.competencydate)
				) 
 
				INSERT INTO #OUTPUT_DATA
				(
					kind , label , printingorder, curramount,
					trimestre_1 , curramount_1 ,
					trimestre_2 , curramount_2 ,
					trimestre_3 , curramount_3 , 
					trimestre_4 , curramount_4 
				)

				SELECT kind, label, printingorder, SUM(curramount),
				1 AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
				2 AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
				3 AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
				4 AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
				FROM FL_ENTRATE_ESERCIZIO_BUDGETPURO
				GROUP BY kind, label, printingorder 
				ORDER BY  printingorder;
END;
-------------------------------------------------------- 
----- lettura previsioni finanziarie parte entrate -----
-------------------------------------------------------- 
if (isnull(@budgetpuro, 'N') = 'N')
BEGIN
		WITH FL_PREVENTRATE AS
		(
		SELECT	'PREV_ENTRATE' as kind,
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
				substring(sorFin.sortcode, 1, 1)  as sortcode_1,
				substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
				substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
				substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
				sorFin.sortcode,
				(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
				NULL as mese,  --- prendo importo corrente per tenere conto già delle variazioni
				NULL as trimestre,

				case	when @fin_kind = 3 then ISNULL(SUM(finyear.secondaryprev*ISNULL(FS.quota,0)),0) 
						when @fin_kind in (1,2) then ISNULL(SUM(finyear.prevision*ISNULL(FS.quota,0)),0)  + 
													 ISNULL(SUM(finyear.currentarrears*ISNULL(FS.quota,0)),0)
			   end as curramount 
 
			FROM  finyear 
			join fin f5 on finyear.idfin=f5.idfin
			join finlast	
			on finlast.idfin = f5.idfin
			JOIN upb U
			ON finyear.idupb = U.idupb
			JOIN finsorting FS
			ON FS.idfin = f5.idfin	
			JOIN sorting sorFin
				ON sorFin.idsor = FS.idsor				
			JOIN sortinglevel sl
				ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
			LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
			LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
			LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
			LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
			WHERE f5.ayear = @ayear --- previsioni anno corrente
				AND ((f5.flag & 1 ) = @finpart_bit) 
				AND sl.idsorkind = @idsorkindfin_E
				AND sorFin.idsorkind = @idsorkindfin_E
				AND (sorFin.nlevel = @levelusable
					OR (sorFin.nlevel < @levelusable
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
						AND (sl.flag&2)<>0
					   )
					)
				AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f5.flag & 16 =0) )
				AND @trimestre <> 4
			GROUP BY  sorFin.sortcode, 
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
			) 
			INSERT INTO #OUTPUT_DATA
			(
				kind , label , printingorder, curramount,
				trimestre_1 , curramount_1 ,
				trimestre_2 , curramount_2 ,
				trimestre_3 , curramount_3 , 
				trimestre_4 , curramount_4 
			)
			SELECT kind, label, printingorder, SUM(curramount),
			1 AS trimestre_1, round(sum(curramount / 4),2)   AS curramount_1,
			2 AS trimestre_2, round(sum(curramount / 4),2)   AS curramount_2,
			3 AS trimestre_3, round(sum(curramount / 4),2)   AS curramount_3,
			4 AS trimestre_4, round(sum(curramount / 4),2)   AS curramount_4
			FROM FL_PREVENTRATE
			GROUP BY kind, label, printingorder 
			ORDER BY  printingorder  ; 

		----- lettura variazione previsioni finanziarie parte entrate
		WITH FL_VAR_PREV_ENTRATE AS
		(
					SELECT
						'PREV_ENTRATE' as kind,
						coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
						coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
						substring(sorFin.sortcode, 1, 1)  as sortcode_1,
						substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
						substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
						substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
						sorFin.sortcode,
						(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
						month(FV.adate) as mese,   
						DATEPART(q,FV.adate)  as trimestre,
						SUM(FVD.amount*ISNULL(FS.quota,0)) as curramount 
				FROM finvardetail FVD
				JOIN finvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
				JOIN fin F				ON FVD.idfin = F.idfin
				JOIN upb U				ON FVD.idupb = U.idupb
				JOIN finsorting FS		ON FS.idfin = F.idfin	
				JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
				JOIN sortinglevel sl	ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel
				LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
				LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
				LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)  and M3.nlevel = 3
				LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)  and M4.nlevel = 4
				WHERE FV.yvar = @ayear
					AND FV.adate <= @date_rif --@date
					AND FV.flagprevision = 'S'
					AND FV.idfinvarstatus = 5
					AND FV.variationkind <> 5
					AND ((F.flag & 1 ) = @finpart_bit) 
					AND  F.ayear = @ayear
					AND sl.idsorkind = @idsorkindfin_E
					AND sorFin.idsorkind = @idsorkindfin_E
					AND (sorFin.nlevel = @levelusable
					OR (sorFin.nlevel < @levelusable
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
						AND (sl.flag&2)<>0
					   )
					)
				AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
				AND @trimestre >0 AND @trimestre <> 4
 				GROUP BY  sorFin.sortcode, FV.adate,
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
		) 
			INSERT INTO #OUTPUT_DATA
			(
				kind , label , printingorder, curramount,
				trimestre_1 , curramount_1 ,
				trimestre_2 , curramount_2 ,
				trimestre_3 , curramount_3 , 
				trimestre_4 , curramount_4 
			)
			SELECT kind, label, printingorder, SUM(curramount),
			1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
			2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
			3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
			4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
			FROM FL_VAR_PREV_ENTRATE
			GROUP BY kind, label, printingorder 
			ORDER BY  printingorder   
END
-------------------------------------------------------- 
--- lettura previsioni budget (puro) parte entrate -----
-------------------------------------------------------- 
ELSE
BEGIN
	WITH FL_PREVENTRATE_BUDGETPURO AS
(
SELECT	'PREV_ENTRATE' as kind,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
		substring(sorFin.sortcode, 1, 1)  as sortcode_1,
		substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
		substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		sorFin.sortcode,
		(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
		NULL as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		NULL as trimestre,

	   ISNULL(SUM(accountyear.prevision*ISNULL(FS.quota,0)),0) as curramount 
 
	FROM  accountyear 
	join account f5 on accountyear.idacc=f5.idacc
	JOIN accountsorting FS
		ON FS.idacc = f5.idacc	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl	ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
	LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	WHERE f5.ayear = @ayear --- previsioni anno corrente
		AND sl.idsorkind = @idsorkindfin_E
		AND sorFin.idsorkind = @idsorkindfin_E
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (f5.flag & 16 =0) )
		AND @trimestre <> 4
	GROUP BY  sorFin.sortcode, 
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
    ) 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)
	SELECT kind, label, printingorder, SUM(curramount),
	1 AS trimestre_1, round(sum(curramount / 4),2)   AS curramount_1,
	2 AS trimestre_2, round(sum(curramount / 4),2)   AS curramount_2,
	3 AS trimestre_3, round(sum(curramount / 4),2)   AS curramount_3,
	4 AS trimestre_4, round(sum(curramount / 4),2)   AS curramount_4
	FROM FL_PREVENTRATE_BUDGETPURO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder  ; 

------------------------------------------------------------------- 
--- lettura variazioni previsioni budget (puro) parte entrate -----
------------------------------------------------------------------- 
WITH FL_VAR_PREV_ENTRATE_BUDGETPURO AS
(
			SELECT
				'PREV_ENTRATE' as kind,
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi') as label,
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17') as printingorder,
				substring(sorFin.sortcode, 1, 1)  as sortcode_1,
				substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
				substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
				substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
				sorFin.sortcode,
				(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
				month(FV.adate) as mese,   
				DATEPART(q,FV.adate)  as trimestre,
				SUM(FVD.amount*ISNULL(FS.quota,0)) as curramount 
		FROM accountvardetail FVD
		JOIN accountvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
		JOIN account F				ON FVD.idacc = F.idacc
		JOIN accountsorting FS		ON FS.idacc = F.idacc	
		JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl	ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel
		LEFT OUTER JOIN #mappatura_E M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)   and M1.nlevel = 1
		LEFT OUTER JOIN #mappatura_E M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
		LEFT OUTER JOIN #mappatura_E M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)  and M3.nlevel = 3
		LEFT OUTER JOIN #mappatura_E M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)  and M4.nlevel = 4
		WHERE FV.yvar = @ayear
			AND FV.adate <= @date_rif --@date
			AND FV.idaccountvarstatus = 5
			AND FV.variationkind <> 5
			AND F.ayear = @ayear
			AND sl.idsorkind = @idsorkindfin_E
			AND sorFin.idsorkind = @idsorkindfin_E
			AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND @trimestre >0 AND @trimestre <> 4
 		GROUP BY  sorFin.sortcode, FV.adate,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri incassi'),
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B17')
) 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)
	SELECT kind, label, printingorder, SUM(curramount),
	1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
	2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
	3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
	4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
	FROM FL_VAR_PREV_ENTRATE_BUDGETPURO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder   
END

 --SELECT * FROM #OUTPUT_DATA

----------------------------------------------------------------------------------------------------------------------------
---------------------------------------------   PARTE SPESE ----------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
set @finpart_bit = 1  --@finpart='S' 
--SELECT  @idsorkindfin = idsorkind from sortingkind where  (codesorkind in ('U_DI_394_08.06.17'))   
SELECT  @MAXoplevel = MAX(nlevel)
FROM    sortinglevel
WHERE   idsorkind = @idsorkindfin_S
SET		@levelusable = @MAXoplevel;

--SELECT '@MAXoplevel USCITE',@MAXoplevel
--SELECT '@levelusable USCITE',@levelusable
if (isnull(@budgetpuro, 'N') = 'N')
BEGIN
WITH FL_USCITE AS
(
SELECT 'USCITE' as kind,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
		substring(sorFin.sortcode, 1, 1)  as sortcode_1,
		substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3,
		substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		sorFin.sortcode,
		(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
	SUM(HPV.curramount*ISNULL(FS.quota,0)) as curramount
	FROM historypaymentview HPV
	JOIN expenseyear IY
		ON IY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl	ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel
	LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)  and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date or (year(HPV.competencydate) = @ayear and   @cashvaliditykind = 4 ))  
		AND sl.idsorkind = @idsorkindfin_S
		AND sorFin.idsorkind = @idsorkindfin_S
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_S and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear -1 
		AND HPV.ymov = @ayear -1 
		AND @trimestre <> 4
	GROUP BY  sorFin.sortcode,  HPV.competencydate ,
	coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
	coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
	--order by   sorFin.sortcode, month(HPV.competencydate)
	) 
	INSERT INTO #OUTPUT_DATA
	(
	kind , label , printingorder, curramount,
	trimestre_1 , curramount_1 ,
	trimestre_2 , curramount_2 ,
	trimestre_3 , curramount_3 , 
	trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1  AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
	2  AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
	3  AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
	4  AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
	FROM FL_USCITE
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder ;


WITH FL_USCITE_ESERCIZIO AS
(
SELECT 'USCITE_ESERCIZIO' as kind,
		coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
		coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
		substring(sorFin.sortcode, 1, 1)  as sortcode_1,
		substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3,
		substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		sorFin.sortcode,
		(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear+1 and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear+1 and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
	SUM(HPV.curramount*ISNULL(FS.quota,0)) as curramount
	FROM historypaymentview HPV
	JOIN expenseyear IY
		ON IY.idexp = HPV.idexp
	JOIN fin F
		ON F.idfin = IY.idfin
	JOIN finsorting FS
		ON FS.idfin = HPV.idfin	
	JOIN sorting sorFin
		ON sorFin.idsor = FS.idsor				
	JOIN sortinglevel sl	
		ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel
	LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1)  and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date_rif or (year(HPV.competencydate) = @ayear +1  and   @cashvaliditykind = 4 ))  
		AND sl.idsorkind = @idsorkindfin_S
		AND sorFin.idsorkind = @idsorkindfin_S
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_S and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear 
		AND HPV.ymov = @ayear 
		AND @trimestre >0
	GROUP BY  sorFin.sortcode,  HPV.competencydate ,
	coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
	coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
	--order by   sorFin.sortcode, month(HPV.competencydate)
	) 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
	2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
	3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
	4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
	FROM FL_USCITE_ESERCIZIO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder ;
END
ELSE
BEGIN
WITH FL_USCITE_BUDGETPURO AS
(
SELECT 'USCITE' as kind,
		coalesce(M5.label,M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
		coalesce(M5.printingorder,M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
		substring(sortExp.sortcode, 1, 1)  as sortcode_1,
		substring(sortExp.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sortExp.sortcode, 1, 2*@nodelen +1 ) as sortcode_3,
		substring(sortExp.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		substring(sortExp.sortcode, 1, 3*@nodelen +1 +1 ) as sortcode_5,
		sortExp.sortcode,
		(len(sortExp.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
		SUM(ES.amount) as curramount
	FROM historypaymentview HPV
	JOIN expenseyear IY
		ON IY.idexp = HPV.idexp
	JOIN expensesorted ES
		ON ES.idexp = HPV.idexp	
	JOIN sorting sortExp
		ON sortExp.idsor = ES.idsor						
	JOIN sortinglevel sl	
		ON sl.idsorkind = sortExp.idsorkind and sortExp.nlevel = sl.nlevel 
	LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sortExp.sortcode, 1, 1)  and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sortExp.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sortExp.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sortExp.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	LEFT OUTER JOIN #mappatura_S M5 ON M5.sortcode = substring(sortExp.sortcode, 1, 3* @nodelen +1 +1)  and M5.nlevel = 5
	--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date or (year(HPV.competencydate) = @ayear and   @cashvaliditykind = 4 ))  
		AND sl.idsorkind = @idsorkind_siopespese
		AND sortExp.idsorkind = @idsorkind_siopespese
		AND (sortExp.nlevel >= @levelusable_siopespese
			OR (sortExp.nlevel < @levelusable_siopespese
				and (select count(*) from sorting S where S.idsorkind = @idsorkind_siopespese and S.paridsor = sortExp.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear -1 
		AND HPV.ymov = @ayear -1 
		AND @trimestre <> 4
	GROUP BY  sortExp.sortcode,  HPV.competencydate ,
	coalesce(M5.label, M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
	coalesce(M5.printingorder, M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
	--order by   sorFin.sortcode, month(HPV.competencydate)
	) 
	INSERT INTO #OUTPUT_DATA
	(
	kind , label , printingorder, curramount,
	trimestre_1 , curramount_1 ,
	trimestre_2 , curramount_2 ,
	trimestre_3 , curramount_3 , 
	trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1  AS trimestre_1, sum(case when trimestre = 1 then curramount else 0 end)   AS curramount_1,
	2  AS trimestre_2, sum(case when trimestre = 2 then curramount else 0 end)   AS curramount_2,
	3  AS trimestre_3, sum(case when trimestre = 3 then curramount else 0 end)   AS curramount_3,
	4  AS trimestre_4, sum(case when trimestre = 4 then curramount else 0 end)   AS curramount_4
	FROM FL_USCITE_BUDGETPURO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder ;
WITH FL_USCITE_ESERCIZIO_BUDGETPURO AS
(
SELECT 'USCITE_ESERCIZIO' as kind,
		coalesce(M5.label, M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
		coalesce(M5.printingorder, M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
		substring(sortExp.sortcode, 1, 1)  as sortcode_1,
		substring(sortExp.sortcode, 1,  @nodelen +1) as sortcode_2,
		substring(sortExp.sortcode, 1, 2*@nodelen +1 ) as sortcode_3,
		substring(sortExp.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
		substring(sortExp.sortcode, 1, 4*@nodelen +1 +1 ) as sortcode_5,
		sortExp.sortcode,
		(len(sortExp.sortcode)-1)/ 2 + 1  as level, 
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear+1 and (@cashvaliditykind = 4)) THEN 12 ELSE month(HPV.competencydate) END as mese,  --- prendo importo corrente per tenere conto già delle variazioni
		CASE WHEN (month(HPV.competencydate) = 1 and year(HPV.competencydate) = @ayear+1 and (@cashvaliditykind = 4)) THEN 4 ELSE DATEPART(q,HPV.competencydate) END  as trimestre,
		SUM(ES.amount) as curramount
	FROM historypaymentview HPV
	JOIN expenseyear IY
		ON IY.idexp = HPV.idexp
	JOIN expensesorted ES
		ON ES.idexp = HPV.idexp	
	JOIN sorting sortExp
		ON sortExp.idsor = ES.idsor					
	JOIN sortinglevel sl	
		ON sl.idsorkind = sortExp.idsorkind and sortExp.nlevel = sl.nlevel 
	LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sortExp.sortcode, 1, 1)  and M1.nlevel = 1
	LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sortExp.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
	LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sortExp.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
	LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sortExp.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
	LEFT OUTER JOIN #mappatura_S M5 ON M5.sortcode = substring(sortExp.sortcode, 1, 4* @nodelen +1 +1 )    and M5.nlevel = 5

	--- entro 31/12/ anno precedente o anno corrente per le esitazioni di inizio anno solo per chi ha la configurazione di cassa basata su esitato
	WHERE (HPV.competencydate <= @date_rif or (year(HPV.competencydate) = @ayear +1  and   @cashvaliditykind = 4 ))  
		AND sl.idsorkind = @idsorkind_siopespese
		AND sortExp.idsorkind = @idsorkind_siopespese
		AND (sortExp.nlevel >= @levelusable_siopespese
			OR (sortExp.nlevel < @levelusable_siopespese
				and (select count(*) from sorting S where S.idsorkind = @idsorkind_siopespese and S.paridsor = sortExp.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		AND IY.ayear = @ayear 
		AND HPV.ymov = @ayear 
		AND @trimestre >0
	GROUP BY  sortExp.sortcode,  HPV.competencydate ,
	coalesce(M5.label, M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
	coalesce(M5.printingorder,M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
	--order by   sorFin.sortcode, month(HPV.competencydate)
	) 
	INSERT INTO #OUTPUT_DATA
	(
		kind , label , printingorder, curramount,
		trimestre_1 , curramount_1 ,
		trimestre_2 , curramount_2 ,
		trimestre_3 , curramount_3 , 
		trimestre_4 , curramount_4 
	)

	SELECT kind, label, printingorder, SUM(curramount),
	1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
	2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
	3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
	4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
	FROM FL_USCITE_ESERCIZIO_BUDGETPURO
	GROUP BY kind, label, printingorder 
	ORDER BY  printingorder ;
END
	 --select * from #mappatura_S
	 --select * from #mappatura_E
	
------------------------------------------------------ 
--- lettura previsioni finanziarie parte spese -------
------------------------------------------------------ 

if (isnull(@budgetpuro,'N') = 'N')
BEGIN
	WITH FL_PREVUSCITE AS
	(
	SELECT	'PREV_USCITE' as kind,
			coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
			coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
			substring(sorFin.sortcode, 1, 1)  as sortcode_1,
			substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
			substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
			substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
			sorFin.sortcode,
			(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
			NULL as mese,  
			NULL as trimestre,
			case	when @fin_kind = 3 then ISNULL(SUM(finyear.secondaryprev*ISNULL(FS.quota,0)),0) 
					when @fin_kind in (1,2) then ISNULL(SUM(finyear.prevision*ISNULL(FS.quota,0)),0)  + 
					ISNULL(SUM(finyear.currentarrears*ISNULL(FS.quota,0)),0)
			end as curramount
		FROM  finyear 
		join fin f5 on finyear.idfin=f5.idfin
		join finlast	
		on finlast.idfin = f5.idfin
		JOIN upb U
		ON finyear.idupb = U.idupb
		JOIN finsorting FS
		ON FS.idfin = f5.idfin	
		JOIN sorting sorFin
			ON sorFin.idsor = FS.idsor				
		JOIN sortinglevel sl
			ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
		LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1) and M1.nlevel = 1
		LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
		LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
		LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
		WHERE f5.ayear = @ayear -- previsioni anno corrente
			AND ((f5.flag & 1 ) = @finpart_bit) 
			AND sl.idsorkind = @idsorkindfin_S
			AND sorFin.idsorkind = @idsorkindfin_S
			AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_S and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
				   )
				)
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F5.flag & 16 =0) )
			AND @trimestre <> 4
		GROUP BY  sorFin.sortcode, 
			coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
			coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
		) 
		INSERT INTO #OUTPUT_DATA
		(
			kind , label , printingorder, curramount,
			trimestre_1 , curramount_1 ,
			trimestre_2 , curramount_2 ,
			trimestre_3 , curramount_3 , 
			trimestre_4 , curramount_4 
		)
		SELECT kind, label, printingorder, SUM(curramount),
		1 AS trimestre_1, round(sum(curramount / 4),2)   AS curramount_1,
		2 AS trimestre_2, round(sum(curramount / 4),2)   AS curramount_2,
		3 AS trimestre_3, round(sum(curramount / 4),2)   AS curramount_3,
		4 AS trimestre_4, round(sum(curramount / 4),2)   AS curramount_4
		FROM FL_PREVUSCITE
		GROUP BY kind, label, printingorder 
		ORDER BY  printingorder   
		;

	----- lettura variazione previsioni finanziarie parte uscite
	WITH FL_VAR_PREV_USCITE AS
	(
				SELECT
					'PREV_USCITE' as kind,
					coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
					coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
					substring(sorFin.sortcode, 1, 1)  as sortcode_1,
					substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
					substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
					substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
					sorFin.sortcode,
					(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
					month(FV.adate) as mese,   
					DATEPART(q,FV.adate)  as trimestre,
					SUM(FVD.amount*ISNULL(FS.quota,0)) as curramount 
			FROM finvardetail FVD
			JOIN finvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
			JOIN fin F				ON FVD.idfin = F.idfin
			JOIN finsorting FS		ON FS.idfin = F.idfin	
			JOIN sorting sorFin		ON sorFin.idsor = FS.idsor				
			JOIN sortinglevel sl    ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
			LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1) and M1.nlevel = 1
			LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
			LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)  and M3.nlevel = 3
			LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)  and M4.nlevel = 4
			WHERE FV.yvar = @ayear
				AND FV.adate <= @date_rif-- @date
				AND FV.flagprevision = 'S'
				AND FV.idfinvarstatus = 5
				AND FV.variationkind <> 5
				AND ((F.flag & 1 ) = @finpart_bit) 
				AND  F.ayear = @ayear
				AND sl.idsorkind = @idsorkindfin_S
				AND sorFin.idsorkind = @idsorkindfin_S
				AND (sorFin.nlevel = @levelusable
				OR (sorFin.nlevel < @levelusable
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
					AND (sl.flag&2)<>0
				   )
				)
			AND (@infoadvance = 'N' OR @infoadvance = 'B' OR (F.flag & 16 =0) )
			AND @trimestre >0 AND @trimestre <> 4
			GROUP BY  sorFin.sortcode, FV.adate,
			coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
			coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
	) 
		INSERT INTO #OUTPUT_DATA
		(
			kind , label , printingorder, curramount,
			trimestre_1 , curramount_1 ,
			trimestre_2 , curramount_2 ,
			trimestre_3 , curramount_3 , 
			trimestre_4 , curramount_4 
		)
		SELECT kind, label, printingorder, SUM(curramount),
		1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
		2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
		3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
		4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
		FROM FL_VAR_PREV_USCITE
		GROUP BY kind, label, printingorder 
		ORDER BY  printingorder;   
END
ELSE
BEGIN
--------------------------------------------------------- 
--- lettura  previsioni budget (puro) parte spese -------
---------------------------------------------------------  
		WITH FL_PREVUSCITE_BUDGETPURO AS
		(
		SELECT	'PREV_USCITE' as kind,
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
				substring(sorFin.sortcode, 1, 1)  as sortcode_1,
				substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
				substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
				substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
				sorFin.sortcode,
				(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
				NULL as mese,  
				NULL as trimestre,
				ISNULL(SUM(accountyear.prevision*ISNULL(FS.quota,0)),0) as curramount 
			FROM  accountyear 
			join account f5 on accountyear.idacc=f5.idacc
			JOIN accountsorting FS
			ON FS.idacc = f5.idacc	
			JOIN sorting sorFin
				ON sorFin.idsor = FS.idsor				
			JOIN sortinglevel sl    
				ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
			LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1) and M1.nlevel = 1
			LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
			LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)    and M3.nlevel = 3
			LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)    and M4.nlevel = 4
			WHERE f5.ayear = @ayear -- previsioni anno corrente
				AND sl.idsorkind = @idsorkindfin_S
				AND sorFin.idsorkind = @idsorkindfin_S
				AND (sorFin.nlevel = @levelusable
					OR (sorFin.nlevel < @levelusable
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_S and S.paridsor = sorFin.idsor)=0
						AND (sl.flag&2)<>0
					   )
					)
				AND @trimestre <> 4
			GROUP BY  sorFin.sortcode, 
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
			) 
			INSERT INTO #OUTPUT_DATA
			(
				kind , label , printingorder, curramount,
				trimestre_1 , curramount_1 ,
				trimestre_2 , curramount_2 ,
				trimestre_3 , curramount_3 , 
				trimestre_4 , curramount_4 
			)
			SELECT kind, label, printingorder, SUM(curramount),
			1 AS trimestre_1, round(sum(curramount / 4),2)   AS curramount_1,
			2 AS trimestre_2, round(sum(curramount / 4),2)   AS curramount_2,
			3 AS trimestre_3, round(sum(curramount / 4),2)   AS curramount_3,
			4 AS trimestre_4, round(sum(curramount / 4),2)   AS curramount_4
			FROM FL_PREVUSCITE_BUDGETPURO 
			GROUP BY kind, label, printingorder 
			ORDER BY  printingorder   
			;

------------------------------------------------------------------- 
--- lettura variazioni previsioni budget (puro) parte spese -------
------------------------------------------------------------------- 
WITH FL_VAR_PREV_USCITE_BUDGETPURO AS
		(
					SELECT
						'PREV_USCITE' as kind,
						coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti') as label,
						coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')as printingorder,
						substring(sorFin.sortcode, 1, 1)  as sortcode_1,
						substring(sorFin.sortcode, 1,  @nodelen +1) as sortcode_2,
						substring(sorFin.sortcode, 1, 2*@nodelen +1 ) as sortcode_3, 
						substring(sorFin.sortcode, 1, 3*@nodelen +1 ) as sortcode_4,
						sorFin.sortcode,
						(len(sorFin.sortcode)-1)/ 2 + 1  as level, 
						month(FV.adate) as mese,   
						DATEPART(q,FV.adate)  as trimestre,
						SUM(FVD.amount*ISNULL(FS.quota,0)) as curramount 
				FROM accountvardetail FVD
				JOIN accountvar FV			ON FV.yvar = FVD.yvar	AND FV.nvar = FVD.nvar
				JOIN account F				ON FVD.idacc = F.idacc
				JOIN accountsorting FS		ON FS.idacc = F.idacc	
				JOIN sorting sorFin			ON sorFin.idsor = FS.idsor				
				JOIN sortinglevel sl		ON sl.idsorkind = sorFin.idsorkind and sorFin.nlevel = sl.nlevel 
				LEFT OUTER JOIN #mappatura_S M1 ON M1.sortcode = substring(sorFin.sortcode, 1, 1) and M1.nlevel = 1
				LEFT OUTER JOIN #mappatura_S M2 ON M2.sortcode = substring(sorFin.sortcode, 1,  @nodelen +1)    and M2.nlevel = 2
				LEFT OUTER JOIN #mappatura_S M3 ON M3.sortcode = substring(sorFin.sortcode, 1, 2* @nodelen +1)  and M3.nlevel = 3
				LEFT OUTER JOIN #mappatura_S M4 ON M4.sortcode = substring(sorFin.sortcode, 1, 3* @nodelen +1)  and M4.nlevel = 4
				WHERE FV.yvar = @ayear
					AND FV.adate <= @date_rif-- @date
					AND FV.idaccountvarstatus = 5
					AND FV.variationkind <> 5
					AND  F.ayear = @ayear
					AND sl.idsorkind = @idsorkindfin_S
					AND sorFin.idsorkind = @idsorkindfin_S
					AND (sorFin.nlevel = @levelusable
					OR (sorFin.nlevel < @levelusable
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin_E and S.paridsor = sorFin.idsor)=0
						AND (sl.flag&2)<>0
					   )
					)
				AND @trimestre >0 AND @trimestre <> 4
				GROUP BY  sorFin.sortcode, FV.adate,
				coalesce(M4.label, M3.Label,M2.Label,M1.Label,'Altri pagamenti'),
				coalesce(M4.printingorder, M3.printingorder,M2.printingorder,M1.printingorder, 'B24')
		) 
			INSERT INTO #OUTPUT_DATA
			(
				kind , label , printingorder, curramount,
				trimestre_1 , curramount_1 ,
				trimestre_2 , curramount_2 ,
				trimestre_3 , curramount_3 , 
				trimestre_4 , curramount_4 
			)
			SELECT kind, label, printingorder, SUM(curramount),
			1  AS trimestre_1, round(sum(case when trimestre = 1 then curramount else 0 end),2)   AS curramount_1,
			2  AS trimestre_2, round(sum(case when trimestre = 2 then curramount else 0 end),2)   AS curramount_2,
			3  AS trimestre_3, round(sum(case when trimestre = 3 then curramount else 0 end),2)   AS curramount_3,
			4  AS trimestre_4, round(sum(case when trimestre = 4 then curramount else 0 end),2)   AS curramount_4
			FROM FL_VAR_PREV_USCITE_BUDGETPURO
			GROUP BY kind, label, printingorder 
			ORDER BY  printingorder   
END
--SELECT * FROM #OUTPUT_DATA

	--- Ottengo la tabella di ripartizione delle percentuali delle previsioni in base ai flussi di cassa anno precedente
	CREATE TABLE #PERCENTUALI 
	(
		kind varchar(20), label varchar(200), printingorder varchar(10), 
		trimestre_1 int, perc_1 decimal(19,2),
		trimestre_2 int, perc_2 decimal(19,2),
		trimestre_3 int, perc_3 decimal(19,2), 
		trimestre_4 int, perc_4 decimal(19,2)  
	)

	IF ( @trimestre <> 4)
	BEGIN
		INSERT INTO #PERCENTUALI
		(
			 kind, label,printingorder,
			 trimestre_1 , perc_1 ,
			 trimestre_2 , perc_2 ,
			 trimestre_3 , perc_3 , 
			 trimestre_4 , perc_4 
		)
		SELECT 
			T.kind, T.label,T.printingorder,
			T.trimestre_1,
			100*round(sum(T.curramount_1)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2)  as perc_1,
			T.trimestre_2,
			100*round(sum(T.curramount_2)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2)  as perc_2,
			T.trimestre_3,
			100*round(sum(T.curramount_3)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2)  as perc_3,
			T.trimestre_4,
			/*ultimo trimestre chiude la percentuale 100% per differenza dagli importi degli altri tre trimestri*/
			100 -  
			(100*round(sum(T.curramount_1)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2) +
			 100*round(sum(T.curramount_2)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2) + 
			 100*round(sum(T.curramount_3)/(case when sum(T.curramount) = 0 then 1 else sum(T.curramount) end ),2))
		as perc_4 
		FROM #OUTPUT_DATA T
		WHERE kind = 'ENTRATE' OR kind = 'USCITE' 
		GROUP BY T.kind, T.label,T.printingorder, T.trimestre_1,T.trimestre_2,T.trimestre_3, T.trimestre_4
		UNION ALL
		--- 2) IN  ASSENZA DI DATI STORICI RELATIVI AI FLUSSI DI CASSA ANNO PRECEDENTE RIPARTISCO LA PREVISIONE INIZIALE AL 25% SU OGNI TRIMESTRE
		SELECT 
		CASE T2.kind 
			WHEN 'PREV_ENTRATE' THEN 'ENTRATE'
			WHEN 'PREV_USCITE' THEN 'USCITE' 
		END, T2.label, T2.printingorder,  
		1 as trimestre_1, 25 as perc_1,
		2 as trimestre_2, 25 as perc_2,
		3 as trimestre_3, 25 as perc_3, 
		4 as trimestre_4, 25 as perc_4 
		FROM (select distinct printingorder, kind, label from #OUTPUT_DATA) T2  
		WHERE (T2.kind = 'PREV_ENTRATE' OR T2.kind = 'PREV_USCITE') AND
		NOT EXISTS (SELECT * FROM #OUTPUT_DATA WHERE #OUTPUT_DATA.printingorder = T2.printingorder  AND 
		(#OUTPUT_DATA.kind = 'ENTRATE' OR #OUTPUT_DATA.kind = 'USCITE' ))
		order by printingorder

	END
	ELSE
	BEGIN
	INSERT INTO #PERCENTUALI
		(
			 kind, label,printingorder,
			 trimestre_1 , perc_1 ,
			 trimestre_2 , perc_2 ,
			 trimestre_3 , perc_3 , 
			 trimestre_4 , perc_4 
		)
		SELECT 
		CASE T2.kind 
			WHEN 'ENTRATE_ESERCIZIO' THEN 'ENTRATE'
			WHEN 'USCITE_ESERCIZIO' THEN 'USCITE' 
		END, T2.label, T2.printingorder,  
		1, 0,
		2, 0,
		3, 0, 
		4, 0 
		FROM (select distinct printingorder, kind, label from #OUTPUT_DATA) T2  
		WHERE (T2.kind = 'ENTRATE_ESERCIZIO' OR T2.kind = 'USCITE_ESERCIZIO') 
		order by printingorder

	END

	--SELECT '#PERCENTUALI', * FROM #PERCENTUALI
	CREATE TABLE #PERCENTUALI_RICALCOLATE
	(
		TrimestreRif	int,
		kind			VARCHAR(20),
		label		    varchar(100) , -- label indicante la voce di riferimento nello schema Excel
		printingorder	varchar(5)	 , -- sigla indicante la cella di riferimento nello schema Excel
		CorrPercTr1		decimal(19,2), -- correzione applicata Trimestre 1 per ottenere NuovaPercTr1 in caso di ricalcolo previsione del trimestre
		CorrPercTr2		decimal(19,2), -- correzione applicata Trimestre 2 per ottenere NuovaPercTr2 in caso di ricalcolo previsione del trimestre
		CorrPercTr3		decimal(19,2), -- correzione applicata Trimestre 3 per ottenere NuovaPercTr3 in caso di ricalcolo previsione del trimestre
		CorrPercTr4		decimal(19,2), -- correzione applicata Trimestre 4 per ottenere NuovaPercTr4 in caso di ricalcolo previsione del trimestre
		PercRealeTr1	decimal(19,2), -- percentuale effettiva ricalcolata da flussi di cassa reali al termine del Trimestre 1
		PercRealeTr2	decimal(19,2), -- percentuale effettiva ricalcolata da flussi di cassa reali al termine del Trimestre 2
		PercRealeTr3	decimal(19,2), -- percentuale effettiva ricalcolata da flussi di cassa reali al termine del Trimestre 3
		PercRealeTr4	decimal(19,2), -- percentuale effettiva ricalcolata da flussi di cassa reali al termine del Trimestre 4
		PrevisioneTotale decimal(19,2), -- previsione iniziale annua da ripartire, per i trimestri successivi al primo è comprensiva anche delle variazioni
		ImportoRealeTr1  decimal(19,2), -- importo effettivo flussi di cassa al termine del Trimestre 1
		ImportoRealeTr2  decimal(19,2), -- importo effettivo flussi di cassa al termine del Trimestre 2
		ImportoRealeTr3  decimal(19,2), -- importo effettivo flussi di cassa al termine del Trimestre 3
		ImportoRealeTr4  decimal(19,2), -- importo effettivo flussi di cassa al termine del Trimestre 4
		NuovaPercTr1 decimal(19,2), -- nuova percentuale cassa effettiva/previsione ricalcolata  al termine del Trimestre 1
		NuovaPrevTr1 decimal(19,2), -- nuovo importo cassa effettiva/previsione ricalcolata al termine del Trimestre 1
		NuovaPercTr2 decimal(19,2), -- nuova cassa effettiva/previsione ricalcolata  al termine del Trimestre 2
		NuovaPrevTr2 decimal(19,2), -- nuovo importo cassa effettiva/previsione ricalcolata  al termine del Trimestre 2
		NuovaPercTr3 decimal(19,2), -- nuova percentuale cassa effettiva/previsione ricalcolata  al termine del Trimestre 3
		NuovaPrevTr3 decimal(19,2), -- nuovo importo cassa effettiva/previsione ricalcolata  al termine del Trimestre 3
		NuovaPercTr4 decimal(19,2), -- nuova percentuale cassa effettiva/previsione ricalcolata  al termine del Trimestre 4
		NuovaPrevTr4 decimal(19,2)  -- nuovo importo cassa effettiva/previsione ricalcolata  al termine del Trimestre 4
	)

	----RICALCOLO DELLE PERCENTUALI DI RIPARTIZIONE SULLA BASE DEI FLUSSI DI CASSA EFFETTIVI DEL TRIMESTRE PRECEDENTE
	-- STORED  PROCEDURE [exp_flussi_cassa_all4_ricalcola_percentuali]
		
	DECLARE @ID varchar(5)
	DECLARE @kind VARCHAR(20)
	DECLARE @label VARCHAR(100)
	DECLARE @PrevisioneTotale DECIMAL(19, 2) 
	DECLARE @PercOrigTr1 DECIMAL(19, 2) 
	DECLARE @PercOrigTr2 DECIMAL(19, 2) 
	DECLARE @PercOrigTr3 DECIMAL(19, 2) 
	DECLARE @PercOrigTr4 DECIMAL(19, 2) 
	DECLARE @ImportoRealeTr1 DECIMAL(19, 2) 
	DECLARE @ImportoRealeTr2 DECIMAL(19, 2) 
	DECLARE @ImportoRealeTr3 DECIMAL(19, 2) 
	DECLARE @ImportoRealeTr4 DECIMAL(19, 2)

	/*
	SELECT 'CICLO DI RICALCOLO',
		isnull(perc.printingorder,flussi_cassa.printingorder) as printingorder,
		isnull(perc.kind,flussi_cassa.kind) as kind, 
		isnull(perc.label,flussi_cassa.label) as label,
		ISNULL(prev.curramount,0) AS curramount,
		perc.perc_1,
		perc.perc_2,
		perc.perc_3, 
		perc.perc_4,
		isnull(flussi_cassa.curramount_1,0) as curramount_1,
		isnull(flussi_cassa.curramount_2,0) as curramount_2,
		isnull(flussi_cassa.curramount_3,0) as curramount_3, 
		isnull(flussi_cassa.curramount_4,0) as curramount_4
	FROM #PERCENTUALI perc
	LEFT OUTER JOIN #OUTPUT_DATA flussi_cassa
	ON perc.printingorder = flussi_cassa.printingorder
	AND flussi_cassa.kind IN ('ENTRATE_ESERCIZIO', 'USCITE_ESERCIZIO')
	LEFT OUTER JOIN (SELECT previsioni.printingorder, previsioni.kind, previsioni.label,  
	sum(curramount) as curramount
	from #OUTPUT_DATA  previsioni where previsioni.kind IN ('PREV_ENTRATE', 'PREV_USCITE') 
	GROUP BY previsioni.printingorder, previsioni.kind, previsioni.label)  as prev
	ON perc.printingorder = prev.printingorder
	WHERE
		ISNULL(prev.curramount,0) <> 0 OR 
		isnull(flussi_cassa.curramount_1,0) <> 0 OR 
		isnull(flussi_cassa.curramount_2,0) <> 0 OR 
		isnull(flussi_cassa.curramount_3,0) <> 0 OR 
		isnull(flussi_cassa.curramount_4,0) <> 0 
		*/

	-- Dichiarazione cursore per allineamento dati previsionali con dati effettivi
	DECLARE correction_cursor CURSOR STATIC FOR
	SELECT 
		isnull(perc.printingorder,flussi_cassa.printingorder) as printingorder,
		isnull(perc.kind,flussi_cassa.kind) as kind, 
		isnull(perc.label,flussi_cassa.label) as label,
		ISNULL(prev.curramount,0) AS curramount,
		perc.perc_1,
		perc.perc_2,
		perc.perc_3, 
		perc.perc_4,
		isnull(flussi_cassa.curramount_1,0) as curramount_1,
		isnull(flussi_cassa.curramount_2,0) as curramount_2,
		isnull(flussi_cassa.curramount_3,0) as curramount_3, 
		isnull(flussi_cassa.curramount_4,0) as curramount_4
	FROM #PERCENTUALI perc
	LEFT OUTER JOIN #OUTPUT_DATA flussi_cassa
	ON perc.printingorder = flussi_cassa.printingorder
	AND flussi_cassa.kind IN ('ENTRATE_ESERCIZIO', 'USCITE_ESERCIZIO')
	LEFT OUTER JOIN (SELECT previsioni.printingorder, previsioni.kind, previsioni.label,  
	SUM(curramount) as curramount
	from #OUTPUT_DATA  previsioni where previsioni.kind IN ('PREV_ENTRATE', 'PREV_USCITE') 
	GROUP BY previsioni.printingorder, previsioni.kind, previsioni.label) as prev
	ON perc.printingorder = prev.printingorder
	WHERE
		ISNULL(prev.curramount,0) <> 0 OR 
		isnull(flussi_cassa.curramount_1,0) <> 0 OR 
		isnull(flussi_cassa.curramount_2,0) <> 0 OR 
		isnull(flussi_cassa.curramount_3,0) <> 0 OR 
		isnull(flussi_cassa.curramount_4,0) <> 0 
 
	OPEN correction_cursor;
	FETCH NEXT FROM correction_cursor INTO @ID, @kind, @label,  @PrevisioneTotale, 
												@PercOrigTr1, @PercOrigTr2, @PercOrigTr3, @PercOrigTr4,
												@ImportoRealeTr1,@ImportoRealeTr2, @ImportoRealeTr3,@ImportoRealeTr4;
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Chiamata alla stored procedure di correzione
		INSERT INTO #PERCENTUALI_RICALCOLATE
		(
			TrimestreRif	,
			kind			,
			label			, -- label indicante la voce di riferimento nello schema Excel
			printingorder	, -- sigla indicante la cella di riferimento nello schema Excel
			CorrPercTr1		, -- correzione applicata Trimestre 1 per ottenere NuovaPercTr1 in caso di ricalcolo previsione del trimestre
			CorrPercTr2		, -- correzione applicata Trimestre 2 per ottenere NuovaPercTr2 in caso di ricalcolo previsione del trimestre
			CorrPercTr3		, -- correzione applicata Trimestre 3 per ottenere NuovaPercTr3 in caso di ricalcolo previsione del trimestre
			CorrPercTr4		, -- correzione applicata Trimestre 4 per ottenere NuovaPercTr4 in caso di ricalcolo previsione del trimestre
			PercRealeTr1	, -- percentuale effettiva calcolata da flussi di cassa reali al termine del Trimestre 1
			PercRealeTr2	, -- percentuale effettiva calcolata da flussi di cassa reali al termine del Trimestre 2
			PercRealeTr3	, -- percentuale effettiva calcolata da flussi di cassa reali al termine del Trimestre 3
			PercRealeTr4	, -- percentuale effettiva calcolata da flussi di cassa reali al termine del Trimestre 4
			PrevisioneTotale , -- previsione iniziale annua da ripartire, per i trimestri successivi al primo è comprensiva delle variazioni successive
			ImportoRealeTr1  , -- importo effettivo flussi di cassa al termine del Trimestre 1
			ImportoRealeTr2  , -- importo effettivo flussi di cassa al termine del Trimestre 2
			ImportoRealeTr3  , -- importo effettivo flussi di cassa al termine del Trimestre 3
			ImportoRealeTr4  , -- importo effettivo flussi di cassa al termine del Trimestre 4
			NuovaPercTr1 , -- nuova percentuale cassa effettiva/previsione ricalcolata al termine del Trimestre 1
			NuovaPrevTr1 , -- nuovo importo cassa effettiva/previsione ricalcolata al termine del Trimestre 1
			NuovaPercTr2 , -- nuova percentuale cassa effettiva/previsione ricalcolata al termine del Trimestre 2
			NuovaPrevTr2 , -- nuovo importo cassa effettiva/previsione ricalcolata al termine del Trimestre 2
			NuovaPercTr3 , -- nuova percentuale cassa effettiva/previsione ricalcolata al termine del Trimestre 3
			NuovaPrevTr3 , -- nuovo importo  cassa effettiva/previsione ricalcolata al termine del Trimestre 3
			NuovaPercTr4 , -- nuova percentuale cassa effettiva/previsione ricalcolata del Trimestre 4
			NuovaPrevTr4   -- nuovo importo  cassa effettiva/previsione ricalcolata al termine del Trimestre 4
		)
		EXEC [exp_flussi_cassa_all4_ricalcola_percentuali] @ayear, @date_rif,@kind, @ID, @label, @PrevisioneTotale, 
													@PercOrigTr1, @PercOrigTr2, @PercOrigTr3, @PercOrigTr4,
													@ImportoRealeTr1,@ImportoRealeTr2, @ImportoRealeTr3,@ImportoRealeTr4

	 FETCH NEXT FROM correction_cursor INTO @ID, @kind, @label, @PrevisioneTotale, 
											@PercOrigTr1, @PercOrigTr2, @PercOrigTr3, @PercOrigTr4,
											@ImportoRealeTr1,@ImportoRealeTr2, @ImportoRealeTr3,@ImportoRealeTr4;
	END
CLOSE correction_cursor;
DEALLOCATE correction_cursor;

--SELECT '#PERCENTUALI_RICALCOLATE', * FROM #PERCENTUALI_RICALCOLATE

	

 
	--SELECT CASE  
	--		WHEN (@fin_kind = 1)  THEN 'COMPETENZA'
	--		WHEN (@fin_kind = 2)  THEN 'CASSA'
	--		WHEN (@fin_kind = 3)  THEN 'COMPETENZA E CASSA '
 --   END  AS 'Conf. Bilancio'
 
  
	--SELECT 'FLUSSI DI CASSA ANNO PREC.', * FROM #OUTPUT_DATA T2 WHERE T2.kind = 'ENTRATE' OR T2.kind = 'USCITE' ORDER BY printingorder

	--SELECT '% di RIPARTIZIONE FLUSSI DI CASSA ANNO PREC.' AS TIPO,* FROM #PERCENTUALI order by  printingorder
	--- calcolo della ripartizione delle previsioni INIZIALI in trimestri
	--- con percentuali ottenute  in modo differenziato 
--	"(1) Al termine di ciascun trimestre, le previsioni sono sostituite 
--	con l'importo degli incassi/pagamenti effettivi e sono aggiornate le previsioni dei trimestri successivi. 
--	La descrizione delle colonne che riportano gli incassi e i pagamenti effettivi dell'esercizio è ridenominata ""Incassi effettivi""/""Pagamenti effettivi"".
--"				


	--select (19.5*3/5) as num, convert(decimal(19,2),(19.4/3))
	IF ( @trimestre) = 0  -- solo previsioni
		BEGIN
		--- 1) IN PRESENZA DI DATI STORICI RELATIVI AI FLUSSI DI CASSA ANNO PRECEDENTE RIPARTISCO IN TRIMESTRI SECONDO QUELLE PERCENTUALI
		--- 2) IN ASSENZA DI DATI STORICI RELATIVI AI FLUSSI DI CASSA ANNO PRECEDENTE RIPARTISCO LA PREVISIONE INIZIALE AL 25% SU OGNI TRIMESTRE
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
			T2.kind as tipo , T2.label as descrizione, T2.printingorder as ordinestampa, T2.curramount  as previsione,
			T2.trimestre_1, perc_1, convert(decimal(19,2),round((perc_1*T2.curramount/100),2)) as previsioni_1, 
			T2.trimestre_2, perc_2, convert(decimal(19,2),round((perc_2*T2.curramount/100),2)) as previsioni_2,
			T2.trimestre_3, perc_3, convert(decimal(19,2),round((perc_3*T2.curramount)/100,2)) as previsioni_3,
			/*ultimo trimestre chiude la percentuale 100% per differenza dagli importi degli altri tre trimestri*/
			T2.trimestre_4,perc_4, 
			convert(decimal(19,2),round(T2.curramount,2)) - convert(decimal(19,2),round((perc_1*T2.curramount)/100,2)) - 
			convert(decimal(19,2),round((perc_2*T2.curramount)/100,2)) -convert(decimal(19,2),round((perc_3*T2.curramount)/100,2)) as previsioni_4

			FROM #PERCENTUALI PERC
			JOIN #OUTPUT_DATA T2 ON PERC.printingorder = T2.printingorder
			WHERE (T2.kind = 'PREV_ENTRATE' OR T2.kind = 'PREV_USCITE')
			ORDER BY 6 /*PRINTINGORDER*/
	END

	--DECLARE @trimestre int =  DATEPART(q,isnull(@date_rif,GetDate())) -1 
	--SET @trimestre = 2

	IF (@trimestre = 1)
		BEGIN
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
			T2.kind as tipo, T2.label as descrizione, T2.printingorder as ordinestampa, T2.PrevisioneTotale  as previsione,
			1 as trimestre_1, T2.NuovaPercTr1, T2.NuovaPrevTr1 as incassi_pagamenti_effettivi_1, 
			2 as trimestre_2, T2.NuovaPercTr2, T2.NuovaPrevTr2 as previsioni_2,
			3 as trimestre_3, T2.NuovaPercTr3, T2.NuovaPrevTr3 as previsioni_3,
			4 as trimestre_4, T2.NuovaPercTr4, T2.NuovaPrevTr4 as previsioni_4
			FROM #PERCENTUALI_RICALCOLATE  T2
			UNION 
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
			T3.kind as tipo, T3.label as descrizione, T3.printingorder as ordinestampa,0 as previsione,
			1 as trimestre_1, T3.perc_1 as  NuovaPercTr1, 0 as incassi_pagamenti_effettivi_1, 
			2 as trimestre_2, T3.perc_2 as  NuovaPercTr2, 0 as previsioni_2,
			3 as trimestre_3, T3.perc_3 as  NuovaPercTr3, 0 as previsioni_3,
			4 as trimestre_4, T3.perc_4 as  NuovaPercTr4, 0 as previsioni_4
			FROM #PERCENTUALI   T3 
			WHERE NOT EXISTS (SELECT * FROM #PERCENTUALI_RICALCOLATE T2 WHERE  T2.printingorder= T3.printingorder)
			ORDER BY 6 /*PRINTINGORDER*/
		END

	IF (@trimestre = 2)
		BEGIN
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
				T2.kind as tipo , T2.label as descrizione, T2.printingorder as ordinestampa, T2.PrevisioneTotale  as previsione,
				1 as trimestre_1, T2.NuovaPercTr1, T2.NuovaPrevTr1 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T2.NuovaPercTr2, T2.NuovaPrevTr2 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T2.NuovaPercTr3, T2.NuovaPrevTr3 as previsioni_3,
				4 as trimestre_4, T2.NuovaPercTr4, T2.NuovaPrevTr4 as previsioni_4
			FROM #PERCENTUALI_RICALCOLATE  T2
			UNION 
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio , @trimestre as trimestre,
				T3.kind as tipo, T3.label as descrizione, T3.printingorder as ordinestampa, 0  as previsione,
				1 as trimestre_1, T3.perc_1 as  NuovaPercTr1, 0 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T3.perc_2 as  NuovaPercTr2, 0 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T3.perc_3 as  NuovaPercTr3, 0 as previsioni_3,
				4 as trimestre_4, T3.perc_4 as  NuovaPercTr4, 0 as previsioni_4
				FROM #PERCENTUALI   T3 
				WHERE NOT EXISTS (SELECT * FROM #PERCENTUALI_RICALCOLATE T2 WHERE T2.printingorder= T3.printingorder)
				ORDER BY 6 /*PRINTINGORDER*/
		END
	IF (/*DATEPART(q,isnull(@date_rif,GetDate())) -1)*/ @trimestre  = 3)
		BEGIN
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
				T2.kind as tipo, T2.label as descrizione, T2.printingorder as ordinestampa, T2.PrevisioneTotale  as previsione,
				1 as trimestre_1, T2.NuovaPercTr1, T2.NuovaPrevTr1 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T2.NuovaPercTr2, T2.NuovaPrevTr2 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T2.NuovaPercTr3, T2.NuovaPrevTr3 as incassi_pagamenti_effettivi_3,
				4 as trimestre_4, T2.NuovaPercTr4, T2.NuovaPrevTr4 as previsioni_4
			FROM #PERCENTUALI_RICALCOLATE  T2
			UNION 
			SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
				T3.kind as tipo, T3.label as descrizione, T3.printingorder as ordinestampa, 0  as previsione,
				1 as trimestre_1, T3.perc_1 as  NuovaPercTr1, 0 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T3.perc_2 as  NuovaPercTr2, 0 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T3.perc_3 as  NuovaPercTr3, 0 as incassi_pagamenti_effettivi_3,
				4 as trimestre_4, T3.perc_4 as  NuovaPercTr4, 0 as previsioni_4
				FROM #PERCENTUALI   T3 
				WHERE NOT EXISTS (SELECT * FROM #PERCENTUALI_RICALCOLATE T2 WHERE T2.printingorder= T3.printingorder)
				ORDER BY 6 /*PRINTINGORDER*/
		END
	IF (@trimestre  = 4)   
		BEGIN
				SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
				T2.kind as tipo, T2.label as descrizione, T2.printingorder as ordinestampa, T2.PrevisioneTotale  as previsione,
				1 as trimestre_1, T2.NuovaPercTr1, T2.NuovaPrevTr1 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T2.NuovaPercTr2, T2.NuovaPrevTr2 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T2.NuovaPercTr3, T2.NuovaPrevTr3 as incassi_pagamenti_effettivi_3,
				4 as trimestre_4, T2.NuovaPercTr4, T2.NuovaPrevTr4 as incassi_pagamenti_effettivi_4
			FROM #PERCENTUALI_RICALCOLATE  T2
			UNION 
				SELECT @startfloatfund as fondocassainiziale, @ayear as esercizio, @trimestre as trimestre,
				T3.kind as tipo, T3.label as descrizione, T3.printingorder as ordinestampa, 0 as previsione,
				1 as trimestre_1, T3.perc_1 as  NuovaPercTr1, 0 as incassi_pagamenti_effettivi_1, 
				2 as trimestre_2, T3.perc_2 as  NuovaPercTr2, 0 as incassi_pagamenti_effettivi_2,
				3 as trimestre_3, T3.perc_3 as  NuovaPercTr3, 0 as incassi_pagamenti_effettivi_3,
				4 as trimestre_4, T3.perc_4 as  NuovaPercTr4, 0 as incassi_pagamenti_effettivi_4
				FROM #PERCENTUALI   T3 
				WHERE NOT EXISTS (SELECT * FROM #PERCENTUALI_RICALCOLATE T2 WHERE T2.printingorder= T3.printingorder)
				ORDER BY 6 /*PRINTINGORDER*/
		END
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--exec exp_piano_annuale_flussi_cassa_all4_sql 2025,   {ts '2025-10-25 00:00:00'} , NULL, 29,30  --unisalento
--go
--exec exp_piano_annuale_flussi_cassa_all4 2025,  {ts '2025-03-25 00:00:00'}, 'S', 29,30	  --unisalento
--go
--exec exp_piano_annuale_flussi_cassa_all4 2025,  {ts '2025-03-25 00:00:00'},NULL, 31,32    --unicampania
--go
--exec exp_piano_annuale_flussi_cassa_all4 2025,  {ts '2025-12-31 00:00:00'},NULL, 26,27   --- unirc

 