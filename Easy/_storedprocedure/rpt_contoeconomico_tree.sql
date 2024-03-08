
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico_tree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico_tree]
GO
--setuser'amm'
--setuser 'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--exec  rpt_contoeconomico_tree 2023, {ts '2023-01-01 00:00:00'}, {ts '2023-07-03 00:00:00'}
CREATE PROCEDURE [rpt_contoeconomico_tree]
(
@ayear int,
@start datetime,
@stop datetime
)
AS BEGIN
DECLARE @ayearprec int
SET @ayearprec = @ayear -1
CREATE TABLE #placcountlookup (oldidplaccount varchar(31), newidplaccount varchar(31))
INSERT #placcountlookup
EXECUTE closeyear_fillplaccountlookup @ayearprec

-- Conto Economico Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)

create table #dati(idplaccount varchar(38), amountprec decimal(19,2), amountcurr decimal(19,2))
insert into #dati(idplaccount, amountprec)
select PLK.newidplaccount, - sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN placcount
		ON placcount.idplaccount = account.idplaccount
	join #placcountlookup PLK
		on PLK.oldidplaccount = placcount.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND placcount.placcpart = 'C'
	group by PLK.newidplaccount
	
insert into #dati(idplaccount, amountprec)
select PLK.newidplaccount,  sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN placcount
		ON placcount.idplaccount = account.idplaccount
	join #placcountlookup PLK
		on PLK.oldidplaccount = placcount.idplaccount
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND placcount.placcpart = 'R'
	group by PLK.newidplaccount

insert into #dati(idplaccount, amountcurr)
select placcount.idplaccount, - sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN placcount
		ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND placcount.placcpart = 'C'
	group by placcount.idplaccount		
	
insert into #dati(idplaccount, amountcurr)
select placcount.idplaccount,  sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN placcount
		ON placcount.idplaccount = account.idplaccount
	WHERE entry.adate BETWEEN @start AND @stop
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND placcount.placcpart = 'R'
	group by placcount.idplaccount	
	
	--insert into #dati(idplaccount, amountprec, amountcurr) values ('19R000200010001', 100, 200)
	--insert into #dati(idplaccount, amountprec, amountcurr) values ('19R0002000200010001',10, 300)
	
	--insert into #dati(idplaccount, amountprec, amountcurr) values ('19C000200010001', -30, -100)
	--insert into #dati(idplaccount, amountprec, amountcurr) values ('19R00020003', -20, -50)
	
--select * from #dati
--	NumberVar diff;

--if (Not IsNull({rpt_contoeconomico_dm2012.TOTRICAVI})) THEN
-- diff := {rpt_contoeconomico_dm2012.TOTRICAVI};

--if (Not IsNull({rpt_contoeconomico_dm2012.TOTCOSTI})) THEN
-- diff := diff - {rpt_contoeconomico_dm2012.TOTCOSTI};

--diff;
 

select --placcount.idplaccount,
	case when placcount.codeplaccount like '%20%' then '999999' + placcount.printingorder
	when placcount.codeplaccount like '%21%' then '999999' + placcount.printingorder
	else  placcount.printingorder end as capogruppo_printingorder,
	case
		when placcount.nlevel = 2 then replicate(' ',2) + placcount.codeplaccount
	 	when placcount.nlevel = 3 then replicate(' ',4) + placcount.codeplaccount
		when placcount.nlevel = 3 then replicate(' ',6) + placcount.codeplaccount
	else placcount.codeplaccount
	end as codeplaccount, 
	placcount.title, placcount.placcpart, 
	isnull(sum(dati_compatta.amountprec),0)  AS amountprec,
	isnull(sum(dati_compatta.amountcurr),0)  AS amountcurr,
	isnull(sum(dati_compatta.amountcurr),0)  -  isnull(sum(dati_compatta.amountprec),0)  AS DIFFERENZA,
case 
	when placcount.placcpart ='R' and placcount.codeplaccount like 'A)%' then 'A) VALORE DELLA PRODUZIONE'
	when placcount.placcpart ='C' and placcount.codeplaccount like 'B)%' then 'B) COSTI DELLA PRODUZIONE'
	when placcount.codeplaccount like 'C)%' then 'C) PROVENTI ONERI FINANZIARI'
	when placcount.codeplaccount like 'D)%' then 'D) RETTIFICHE DI VALORE DI ATTIVITA FINANZIARIE'
	when placcount.codeplaccount like 'E)%' then 'E) PROVENTI ED ONERI STRAORDINARI'
	when placcount.codeplaccount like 'F)%' then 'F) IMPOSTE SUL REDDITO DELL''ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE'
	when placcount.codeplaccount like '%I)%' then 'I) IMPOSTE SUL REDDITO DELL''ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE'
	when placcount.placcpart ='C' and (placcount.codeplaccount like '%20%'  or placcount.codeplaccount  like '%.%' ) then 'IMPOSTE SUL REDDITO DELL''ESERCIZIO'
	when placcount.placcpart ='R' and (placcount.codeplaccount like '%21%' or placcount.codeplaccount  like '%.%' )  then 'UTILE(PERDITE) DELL''ESERCIZIO'
	ELSE 'x SENZA NOME x'
 END AS 'CAPO_GRUPPO',
 placcount.printingorder	
from placcount
left outer join ( SELECT idplaccount, ISNULL(SUM(amountprec),0) as amountprec,ISNULL(SUM(amountcurr),0) as amountcurr FROM #dati group by idplaccount ) as dati_compatta
on placcount.idplaccount = dati_compatta.idplaccount
where placcount.ayear = @ayear and placcount.codeplaccount <> '.'
group by placcount.idplaccount,placcount.codeplaccount,placcount.nlevel, placcount.printingorder, placcount.title, placcount.placcpart
ORDER BY case when placcount.codeplaccount like '%20%' then '999999' + placcount.printingorder
	when placcount.codeplaccount like '%21%' then '999999' + placcount.printingorder
	else  placcount.printingorder	  end  

	drop table #placcountlookup
	drop table #dati

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_contoeconomico_tree 2020, {ts '2020-01-01 00:00:00'}, {ts '2020-12-31 00:00:00'}
--go
--exec rpt_contoeconomico_tree 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'}
--exec rpt_contoeconomico 2020, {ts '2020-01-01 00:00:00'}, {ts '2020-12-31 00:00:00'}
