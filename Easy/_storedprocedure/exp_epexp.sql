
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_epexp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_epexp]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
--exec exp_epexp 2023, {d '2023-01-01'}, {d '2023-07-16'}, null, null, '%', 'S', 'S', null, 'N'
--exec exp_epexp 2023, 2022, null, null, null, null, '%', 'S', 'S', 'N'
CREATE PROCEDURE [exp_epexp]
(
	@ayear			int,
	@yepexp			int,
	@nphase			int,
	--@start			datetime,
	--@stop			datetime,
	@idreg     int,
	@idman int,
	@codeacc varchar(50),
	@idupb		varchar(36),
	@showupb	char(1),
	@showchildupb	char(1),
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

CREATE TABLE #epexp (
	idepexp int,
	yepexp smallint,
	nepexp int,
	nphase smallint,
	phase varchar(10),
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
	totalcost decimal(19, 2), 
	costavailable decimal(19, 2),
	totaldebit decimal(19, 2),
	ayear smallint,
	idacc varchar(38),
	codeacc varchar(50),
	account varchar(150),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	paridepexp int, 
	parentyepexp smallint,
	parentnepexp int,
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

INSERT INTO #epexp (
	idepexp,yepexp,nepexp,nphase,phase,
	flagvariation,
	description,
	amount,amount2,amount3,amount4,amount5,
	amountwithsign,amountwithsign2,amountwithsign3,amountwithsign4,amountwithsign5,
	totamount,
	curramount,curramount2,curramount3,curramount4,curramount5,totcurramount,
	available,available2,available3,available4,available5,totavailable,
	totalcost, costavailable,
	totaldebit,
	ayear,
	idacc,codeacc,account,
	idupb,codeupb,upb,
	paridepexp, parentyepexp,parentnepexp,
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
	epexp.idepexp,epexp.yepexp,epexp.nepexp,epexp.nphase,
	case when epexp.nphase = 1 then 'Preimpegno'
		else 'Impegno'
	end,
	epexp.flagvariation,
	epexp.description,
	EY.amount,EY.amount2,EY.amount3,EY.amount4,EY.amount5,
	--amountwithsign
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount,0)
					else -ISNULL(EY.amount,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount2,0)
					else -ISNULL(EY.amount2,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount3,0)
					else -ISNULL(EY.amount3,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount4,0)
					else -ISNULL(EY.amount4,0)
	end,
	case when epexp.flagvariation ='N' 
					then ISNULL(EY.amount5,0)
					else -ISNULL(EY.amount5,0)
	end,
	-- totamount:
	isnull(EY.amount,0)+isnull(EY.amount2,0)+isnull(EY.amount3,0)+isnull(EY.amount4,0)+isnull(EY.amount5,0),
	ET.curramount,ET.curramount2,ET.curramount3,ET.curramount4,ET.curramount5,
	-- totcurramount :
	isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0),
	case when epexp.nphase = 1 then ET.available else null end,
	case when epexp.nphase = 1 then ET.available2 else null end,
	case when epexp.nphase = 1 then ET.available3 else null end,
	case when epexp.nphase = 1 then ET.available4 else null end,
	case when epexp.nphase = 1 then ET.available5 else null end,
	-- totavailable :
	case when epexp.nphase = 1 then
			isnull(ET.available,0)+isnull(ET.available2,0)+isnull(ET.available3,0)+isnull(ET.available4,0)+isnull(ET.available5,0)
		else 
			null
	end
	,	
	-- totalcost:
	case when epexp.nphase = 2 then
			case when epexp.flagvariation ='N' 
					then ISNULL(ET.cost,0)
					else -ISNULL(ET.cost,0)
			end		 
		else null
	end,
	--costavailable
	case when epexp.nphase = 2 then
		isnull(ET.curramount,0)+isnull(ET.curramount2,0)+isnull(ET.curramount3,0)+isnull(ET.curramount4,0)+isnull(ET.curramount5,0)-
		(case when epexp.flagvariation ='N' 
					then ISNULL(ET.cost,0)
					else -ISNULL(ET.cost,0)
		end) 	
		else null
	end,

	 -- totaldebit:
	 case when epexp.nphase = 2 then
		case when epexp.flagvariation ='N' 
					then 	ISNULL(ISNULL(ET.debit,0),0)
					else 	-ISNULL(ET.debit,0)
		end 
		else null
	end,
	EY.ayear,
	A.idacc, A.codeacc, A.title,
	U.idupb, U.codeupb, U.title,
	epexp.paridepexp,par.yepexp,par.nepexp,
	isnull(par.yepexp,epexp.yepexp),isnull(par.nepexp,epexp.nepexp),
	epexp.start,epexp.stop,epexp.adate,
	registry.idreg,registry.title,
	epexp.doc,epexp.docdate,
	manager.idman,manager.title,
	epexp.idrelated,
	A.flagaccountusage,
	CASE	when (( A.flagaccountusage & 1) = 0)  then 'N'	ELSE 'S' END,	/* Ratei attivi*/ 
	CASE	when (( A.flagaccountusage & 2) = 0)  then 'N'	ELSE 'S' END,	/* Ratei Passivi*/
	CASE	when (( A.flagaccountusage & 4) = 0)  then 'N'	ELSE 'S' END,	/* Risconti Attivi*/
	CASE	when (( A.flagaccountusage & 8) = 0)  then 'N'	ELSE 'S' END,	/* Risconti Passivi */
	CASE	when (( A.flagaccountusage & 16) = 0) then 'N' ELSE 'S' END,	/* Debito  */
	CASE	when (( A.flagaccountusage & 32) = 0) then 'N' ELSE 'S'	END,	/* Credito */
	CASE	when (( A.flagaccountusage & 64) = 0) then 'N' ELSE  'S' END,	/* Costi */
	CASE	when (( A.flagaccountusage & 128) = 0) then 'N' ELSE 'S' END,	/* Ricavi */
	CASE	when (( A.flagaccountusage & 256) = 0) then 'N' ELSE 'S' END,/*Immobilizzazioni*/
	CASE	when (( A.flagaccountusage & 512) = 0) then 'N' ELSE 'S' END, /* Avanzo libero */
	CASE 	when (( A.flagaccountusage & 1024) = 0) then 'N' ELSE 'S' END, /* Avanzo vincolato */ 
	CASE    when (( A.flagaccountusage & 2048) = 0) then 'N' ELSE 'S' END, /*Riserva*/
	CASE    when (( A.flagaccountusage & 4096) = 0) then 'N' ELSE 'S' END, /*Accantonamento*/
	accmotive.idaccmotive,
	accmotive.codemotive,
	U.idsor01,U.idsor02,U.idsor03,U.idsor04,U.idsor05, registry.cf, registry.p_iva
FROM epexp
left outer JOIN registry ON epexp.idreg= registry.idreg
join epexpyear EY on epexp.idepexp= EY.idepexp
join epexptotal ET on ET.idepexp= EY.idepexp and EY.ayear=ET.ayear
join account A on EY.idacc=A.idacc
join upb U on U.idupb=EY.idupb
left outer join epexp par on epexp.paridepexp=par.idepexp
left outer join manager on manager.idman= epexp.idman
LEFT OUTER JOIN accmotive  ON accmotive.idaccmotive = epexp.idaccmotive
WHERE epexp.yepexp = @yepexp
AND EY.ayear = @ayear
AND (epexp.nphase = @nphase or @nphase is null)
AND (epexp.idreg = @idreg or @idreg is null)
AND (epexp.idman = @idman or @idman is null)
AND (U.idupb like @idupb or @idupb = '%')
AND (A.codeacc = @codeacc or @codeacc is null)
--AND (epexp.idaccmotive = @idaccmotive or @idaccmotive is null)
--AND (epexp.start >= @start or @start is null)
--AND (epexp.stop <= @stop or @stop is null)
AND (@idsor01 IS NULL OR U.idsor01=@idsor01)  
AND (@idsor02 IS NULL OR U.idsor02=@idsor02) 
AND (@idsor03 IS NULL OR U.idsor03=@idsor03) 
AND (@idsor04 IS NULL OR U.idsor04=@idsor04)  
AND (@idsor05 IS NULL OR U.idsor05=@idsor05) 


INSERT INTO @lista_id  select distinct idrelated from #epexp  where idrelated IS NOT NULL

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

--select * from #Tdrel

update #Tdrel
set col2 = null,
col3 = null,
col4 = null,
col5 = null,
col6 = null,
col7 = null,
col8 = null
where col1 <> 'man'

--select * from #Tdrel

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
	'#epexp.phase as ''Fase'',' +
	'#epexp.yepexp as ''Esercizio'',' +
	'#epexp.nepexp as ''Numero'',' +
	'#epexp.description as ''Descrizione'',' +
	'#epexp.registry as ''Fornitore/Cliente'',' +
	'#epexp.cf as ''CF'',' +
	'#epexp.p_iva as ''p_iva'',' +
	'#epexp.codeacc as ''Codice Conto'',' +
	'#epexp.account as ''Conto'',' +
	case when (@showupb = 'S') then '#epexp.codeupb as ''Cod. U.P.B.'',' else '' end +
	case when (@showupb = 'S') then '#epexp.upb as ''U.P.B.'',' else '' end +
	'#epexp.curramount as ''' + @ayear_text + ''',' +
	'#epexp.available as ''Disp. ' + @ayear_text + ''',' +
	'#epexp.curramount2 as ''' + @ayear2_text + ''',' +
	'#epexp.available2 as ''Disp. ' + @ayear2_text + ''',' +
	'#epexp.curramount3 as ''' + @ayear3_text + ''',' +
	'#epexp.available3 as ''Disp. ' + @ayear3_text + ''',' +
	'#epexp.curramount4 as ''' + @ayear4_text + ''',' +
	'#epexp.available4 as ''Disp. ' + @ayear4_text + ''',' +
	'#epexp.curramount5 as ''' + @ayear5_text + ''',' +
	'#epexp.available5 as ''Disp. ' + @ayear5_text + ''',' +
	'#epexp.costavailable as ''Disp. per Costi'',' +
	'#epexp.adate as ''Data Contabile'',' +
	'#epexp.doc as ''Documento'',' +
	'#epexp.docdate as ''Data Documento'',' +
	'CASE WHEN (	#epexp.idrelated IS NOT NULL) THEN  #Tdrel.kind ELSE ''Imputazione generica'' END as ''Tipo Documento di Riferimento'',' +
	'CASE WHEN (	M.nman IS NOT NULL) THEN	M.description ELSE '''' END  as ''Descr. Documento di Riferimento'',' +
	'#epexp.flagvariation as ''Nota di Variazione'',' +
	'#epexp.totalcost as ''Costi Totali'',' +
	'#epexp.totaldebit as ''Debiti Totali'',' +
	'#epexp.totamount as ''Tolale Iniziale Pluriennale'',' +
	'#epexp.totavailable as ''Totale Disp. Pluriennale'',' +
	'#epexp.totcurramount as ''Totale Corrente Pluriennale'' ' +
'FROM #epexp ' +
'left join #Tdrel on #epexp.idrelated = #Tdrel.idrelated ' +
'left join mandate M  ON M.idmankind =  isnull(#Tdrel.col2,'''') and M.yman =isnull(#Tdrel.col3,'''') and M.nman = isnull(#Tdrel.col4,'''') ' +
'order by #epexp.yepexp desc, #epexp.nepexp desc'

--select @StringQuery

EXEC sp_executesql 
@stmt = @StringQuery


END
