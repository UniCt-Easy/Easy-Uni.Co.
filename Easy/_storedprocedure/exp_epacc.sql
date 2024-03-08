
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_epacc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_epacc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
--exec exp_epacc 2023, {d '2023-01-01'}, {d '2023-07-16'}, null, null, '%', 'S', 'S', null, 'N'
--exec exp_epacc 2023, 2022, null, null, null, null, '%', 'S', 'S', 'N'
CREATE PROCEDURE [exp_epacc]
(
	@ayear			int,
	@yepacc			int,
	@nphase			int,
	--@start			datetime,
	--@stop			datetime,
	@idreg     int,
	@idman int,
	@codeacc varchar(50),
	@idupb		varchar(36),
	@showupb	char(1),
	@showchildupb	char(1),
	--@idaccmotive int,
	@suppressifblank varchar(1) = 'N',
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
)
AS
BEGIN
DECLARE @lista_id dbo.idrelated_list
DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
BEGIN
	SET @idupb=@idupb+'%' 
END

CREATE TABLE #epacc (
	idepacc int,
	yepacc smallint,
	nepacc int,
	nphase smallint,
	phase varchar(15),
	flagvariation char(1),
	description varchar(150),
	amount decimal(19, 2),
	amount2 decimal(19, 2),
	amount3 decimal(19, 2),
	amount4 decimal(19, 2),
	amount5 decimal(19, 2),
	amountwithsign decimal(19,2),
	amountwithsign2 decimal(19,2),
	amountwithsign3 decimal(19,2),
	amountwithsign4 decimal(19,2),
	amountwithsign5 decimal(19,2),
	totamount decimal(19,2),
	curramount decimal(19,2),
	curramount2 decimal(19,2),
	curramount3 decimal(19, 2),
	curramount4 decimal(19,2),
	curramount5 decimal(19,2),
	totcurramount decimal(19, 2),
	available decimal(19, 2),
	available2 decimal(19, 2),
	available3 decimal(19, 2),
	available4 decimal(19, 2),
	available5 decimal(19, 2),
	totavailable decimal(19, 2),
	totalrevenue decimal(19, 2), 
	revenueavailable decimal(19, 2),
	totalcredit decimal(19, 2),
	ayear smallint,
	idacc varchar(38),
	codeacc varchar(50),
	account varchar(150),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	paridepacc int, 
	parentyepacc smallint,
	parentnepacc int,
	yliv1 smallint,
	nliv1 int,
	start date, 
	stop date, 
	adate date,
	idreg int,
	registry varchar(100),
	doc varchar(50),
	docdate date,
	idman int,
	manager varchar(150),
	idrelated varchar(100),
	flagaccountusage int,
	rateiattivi varchar(1),
	rateipassivi varchar(1),
	riscontiattivi varchar(1), 
	riscontipassivi varchar(1),
	debit varchar(1),
	credit varchar(1),
	cost varchar(1),
	revenue varchar(1),
	fixedassets varchar(1),
	freeusesurplus varchar(1),
	captiveusesurplus varchar(1),
	reserve varchar(1),
	provision varchar(1),
	idaccmotive varchar(36),
	codemotive varchar(50),
	idsor01 int,
	idsor02 int,
	idsor03 int,
	idsor04 int,
	idsor05 int, 
	cf varchar(16), 
	p_iva varchar(15)
)

INSERT INTO #epacc (
	idepacc,yepacc,nepacc,nphase,phase,
	flagvariation,
	description,
	amount,amount2,amount3,amount4,amount5,
	amountwithsign,amountwithsign2,amountwithsign3,amountwithsign4,amountwithsign5,
	totamount,
	curramount,curramount2,curramount3,curramount4,curramount5,totcurramount,
	available,available2,available3,available4,available5,totavailable,
	totalrevenue, revenueavailable,
	totalcredit,
	ayear,
	idacc,codeacc,account,
	idupb,codeupb,upb,
	paridepacc, parentyepacc,parentnepacc,
	yliv1,nliv1,
	start, stop, adate,
	idreg,registry,
	doc,docdate,
	idman,manager,
	idrelated,
	flagaccountusage,
	rateiattivi,rateipassivi,
	riscontiattivi, riscontipassivi,
	debit,credit,
	cost,revenue,
	fixedassets,freeusesurplus,captiveusesurplus,reserve,provision,
	idaccmotive,
	codemotive,
	idsor01,idsor02,idsor03,idsor04,idsor05, cf, p_iva
)
SELECT 
	epacc.idepacc,epacc.yepacc,epacc.nepacc,epacc.nphase,
	case when epacc.nphase = 1 then 'Preaccertamento'
		else 'Accertamento'
	end,
	epacc.flagvariation,
	epacc.description,
	EY.amount,EY.amount2,EY.amount3,EY.amount4,EY.amount5,
	--amountwithsign
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount,0)
					else -ISNULL(EY.amount,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount2,0)
					else -ISNULL(EY.amount2,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount3,0)
					else -ISNULL(EY.amount3,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount4,0)
					else -ISNULL(EY.amount4,0)
	end,
	case when epacc.flagvariation ='N' 
					then ISNULL(EY.amount5,0)
					else -ISNULL(EY.amount5,0)
	end,
	-- totamount:
	isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0),

	ET.curramount,ET.curramount2,ET.curramount3,ET.curramount4,ET.curramount5,
	-- totcurramount :
	isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0),
	case when epacc.nphase = 1 then ET.available else null end,
	case when epacc.nphase = 1 then ET.available2 else null end,
	case when epacc.nphase = 1 then ET.available3 else null end,
	case when epacc.nphase = 1 then ET.available4 else null end,
	case when epacc.nphase = 1 then ET.available5 else null end,
	-- totavailable :
	case when epacc.nphase = 1 then
			isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
		else 
			null
	end,	
	-- totalrevenue:
	case when epacc.nphase = 2 then
		case when epacc.flagvariation ='N' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
		end	
		else null
	end,
	-- revenueavailable
	case when epacc.nphase = 2 then
		isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
			case when epacc.flagvariation ='N' 
					then ISNULL(ET.revenue,0)
					else -ISNULL(ET.revenue,0)
			end	
		else null
	end,

	 -- totalcredit:
	case when epacc.flagvariation ='N' 
					then ISNULL(ET.credit,0)
					else -ISNULL(ET.credit,0)
			end	,
	EY.ayear,
	A.idacc, A.codeacc, A.title,
	U.idupb, U.codeupb, U.title,
	epacc.paridepacc,par.yepacc,par.nepacc,
	isnull(par.yepacc,epacc.yepacc),isnull(par.nepacc,epacc.nepacc),
	epacc.start,epacc.stop,epacc.adate,
	registry.idreg,registry.title,
	epacc.doc,epacc.docdate,
	manager.idman,manager.title,
	epacc.idrelated,
	A.flagaccountusage,
	CASE	when (( A.flagaccountusage & 1) = 0)  then 'N'	ELSE 'S'END,	/* Ratei attivi*/ 
	CASE	when (( A.flagaccountusage & 2) = 0)  then 'N'	ELSE 'S'END,	/* Ratei Passivi*/
	CASE	when (( A.flagaccountusage & 4) = 0)  then 'N'	ELSE 'S'END,	/* Risconti Attivi*/
	CASE	when (( A.flagaccountusage & 8) = 0)  then 'N'	ELSE 'S'END,	/* Risconti Passivi */
	CASE	when (( A.flagaccountusage & 16) = 0) then 'N' ELSE 'S'END,	/* Debito  */
	CASE	when (( A.flagaccountusage & 32) = 0) then 'N' ELSE 'S'	END,	/* Credito */
	CASE	when (( A.flagaccountusage & 64) = 0) then 'N' ELSE 'S'	END,	/* Costi */
	CASE	when (( A.flagaccountusage & 128) = 0) then 'N' ELSE 'S'END,	/* Ricavi */
	CASE	when (( A.flagaccountusage & 256) = 0) then 'N' ELSE 'S'END,/*Immobilizzazioni*/
	CASE	when (( A.flagaccountusage & 512) = 0) then 'N' ELSE 'S'END, /* Avanzo libero */
	CASE 	when (( A.flagaccountusage & 1024) = 0) then 'N' ELSE 'S' END, /* Avanzo vincolato */ 
	CASE    when (( A.flagaccountusage & 2048) = 0) then 'N' ELSE 'S' END, /*Riserva*/
	CASE    when (( A.flagaccountusage & 4096) = 0) then 'N' ELSE 'N' END, /*Accantonamento*/
	accmotive.idaccmotive,
	accmotive.codemotive,
	U.idsor01,U.idsor02,U.idsor03,U.idsor04,U.idsor05, registry.cf, registry.p_iva
FROM epacc
left outer JOIN registry ON epacc.idreg= registry.idreg
join epaccyear EY on epacc.idepacc= EY.idepacc
join epacctotal ET on ET.idepacc= EY.idepacc and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epacc par on epacc.paridepacc=par.idepacc
left outer join manager on manager.idman= epacc.idman
LEFT OUTER JOIN accmotive   on accmotive.idaccmotive = epacc.idaccmotive
WHERE epacc.yepacc = @yepacc
AND EY.ayear = @ayear
AND (epacc.nphase = @nphase or @nphase is null)
AND (epacc.idreg = @idreg or @idreg is null)
AND (epacc.idman = @idman or @idman is null)
AND (U.idupb like @idupb or @idupb = '%')
AND (A.codeacc = @codeacc or @codeacc is null)
--AND (epacc.idaccmotive = @idaccmotive or @idaccmotive is null)
--AND (epacc.start >= @start or @start is null)
--AND (epacc.stop <= @stop or @stop is null)
AND (@idsor01 IS NULL OR U.idsor01=@idsor01)  
AND (@idsor02 IS NULL OR U.idsor02=@idsor02) 
AND (@idsor03 IS NULL OR U.idsor03=@idsor03) 
AND (@idsor04 IS NULL OR U.idsor04=@idsor04)  
AND (@idsor04 IS NULL OR U.idsor05=@idsor05) 


INSERT INTO @lista_id  select distinct idrelated from #epacc  where idrelated IS NOT NULL

CREATE  TABLE #Tdrel (
	idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),	
	kind varchar(max), 
	rifdoc varchar(max), 
	docdate datetime, 
	daterif datetime,
	col1 varchar(50), 
	col2 varchar(50), 
	col3 varchar(50), 
	col4 varchar(50), 
	col5 varchar(50), 
	col6 varchar(50), 
	col7 varchar(50),
	col8 varchar(50)
)

insert into #Tdrel
select * from [fn_decode_idrelated_tab_chiavi] (@lista_id)

update #Tdrel
set col2 = null,
col3 = null,
col4 = null,
col5 = null,
col6 = null,
col7 = null,
col8 = null
where col1 <> 'estim'

declare @ayear_text varchar(4)
declare @ayear2_text varchar(4)
declare @ayear3_text varchar(4)
declare @ayear4_text varchar(4)
declare @ayear5_text varchar(4)

set @ayear_text = CONVERT(nvarchar(4), @ayear)
set @ayear2_text = CONVERT(nvarchar(4), @ayear + 1)
set @ayear3_text = CONVERT(nvarchar(4), @ayear + 2)
set @ayear4_text = CONVERT(nvarchar(4), @ayear + 3)
set @ayear5_text = CONVERT(nvarchar(4), @ayear + 4)

declare @StringQuery nvarchar(max)

SET @StringQuery = 
'SELECT ' +
	'#epacc.phase as ''Fase'',' +
	'#epacc.yepacc as ''Esercizio'',' +
	'#epacc.nepacc as ''Numero'',' +
	'#epacc.description as ''Descrizione'',' +
	'#epacc.registry as ''Fornitore/Cliente'',' +
	'#epacc.cf as ''CF'',' +
	'#epacc.p_iva as ''p_iva'',' +
	'#epacc.codeacc as ''Codice Conto'',' +
	'#epacc.account as ''Conto'',' +
	case when (@showupb = 'S') then '#epacc.codeupb as ''Cod. U.P.B.'',' else '' end +
	case when (@showupb = 'S') then '#epacc.upb as ''U.P.B.'',' else '' end +
	'#epacc.curramount as ''' + @ayear_text + ''',' +
	'#epacc.available as ''Disp. ' + @ayear_text + ''',' +
	'#epacc.curramount2 as ''' + @ayear2_text + ''',' +
	'#epacc.available2 as ''Disp. ' + @ayear2_text + ''',' +
	'#epacc.curramount3 as ''' + @ayear3_text + ''',' +
	'#epacc.available3 as ''Disp. ' + @ayear3_text + ''',' +
	'#epacc.curramount4 as ''' + @ayear4_text + ''',' +
	'#epacc.available4 as ''Disp. ' + @ayear4_text + ''',' +
	'#epacc.curramount5 as ''' + @ayear5_text + ''',' +
	'#epacc.available5 as ''Disp. ' + @ayear5_text + ''',' +
	'#epacc.revenueavailable as ''Disp. per Ricavi'',' +
	'#epacc.adate as ''Data Contabile'',' +
	'#epacc.doc as ''Documento'',' +
	'#epacc.docdate as ''Data Documento'',' +
	'CASE WHEN (	#epacc.idrelated IS NOT NULL) THEN  #Tdrel.kind ELSE ''Imputazione generica'' END as ''Tipo documento di Riferimento'',' +
	'CASE WHEN (	E.nestim IS NOT NULL) THEN	E.description ELSE '''' END  as ''Descr. Documento di Riferimento'',' +
	'#epacc.flagvariation as ''Nota di Variazione'',' +
	'#epacc.totalrevenue as ''Ricavi Totali'',' +
	'#epacc.totalcredit as ''Crediti Totali'',' +
	'#epacc.totamount as ''Tolale Iniziale Pluriennale'',' +
	'#epacc.totavailable as ''Totale Disp. Pluriennale'',' +
	'#epacc.totcurramount as ''Totale Corrente Pluriennale'' ' +
'FROM #epacc ' +
'left join #Tdrel on #epacc.idrelated = #Tdrel.idrelated ' +
'left join estimate E  ON E.idestimkind =  isnull(#Tdrel.col2,'''') and E.yestim =isnull(#Tdrel.col3,'''') and E.nestim = isnull(#Tdrel.col4,'''')  ' +
'order by #epacc.yepacc desc, #epacc.nepacc desc'

--select @StringQuery


EXEC sp_executesql 
@stmt = @StringQuery


END
