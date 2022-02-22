
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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



if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_tree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_tree]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [rpt_statopatrimoniale_tree]
(
@ayear int,
@start datetime,
@stop datetime
)
AS BEGIN

CREATE TABLE #patrimonylookup (oldidpatrimony varchar(31), newidpatrimony varchar(31))
INSERT #patrimonylookup
EXECUTE closeyear_fillpatrimonylookup @ayear

-- Conto Economico Anno Precedente
DECLARE @firstdayPY datetime
DECLARE @lastdayPY datetime
SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
DECLARE @sk_prec char(2)
SET @sk_prec = SUBSTRING(CONVERT(varchar(4),@ayear-1),3,2)

create table #dati(idpatrimony varchar(38), amountprec decimal(19,2), amountcurr decimal(19,2))
insert into #dati(idpatrimony, amountprec)
select PLK.newidpatrimony, - sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN patrimony
		ON patrimony.idpatrimony = account.idpatrimony
	join #patrimonylookup PLK
		on PLK.oldidpatrimony = patrimony.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND patrimony.patpart = 'A'
	group by PLK.newidpatrimony
	
insert into #dati(idpatrimony, amountprec)
select PLK.newidpatrimony,  sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN patrimony
		ON patrimony.idpatrimony = account.idpatrimony
	join #patrimonylookup PLK
		on PLK.oldidpatrimony = patrimony.idpatrimony
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND patrimony.patpart = 'P'
	group by PLK.newidpatrimony

insert into #dati(idpatrimony, amountcurr)
select patrimony.idpatrimony, - sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN patrimony
		ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND patrimony.patpart = 'A'
	group by patrimony.idpatrimony		
	
insert into #dati(idpatrimony, amountcurr)
select patrimony.idpatrimony,  sum(entrydetail.amount)
	FROM entrydetail
	JOIN entry
		ON entry.yentry = entrydetail.yentry
		AND entry.nentry = entrydetail.nentry
	JOIN account
		ON account.idacc = entrydetail.idacc
	JOIN patrimony
		ON patrimony.idpatrimony = account.idpatrimony
	WHERE entry.adate BETWEEN @start AND @stop
		AND entry.identrykind not in (6,11,12)	 -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
		AND patrimony.patpart = 'P'
	group by patrimony.idpatrimony	
	
	--insert into #dati(idpatrimony, amountprec, amountcurr) values ('19R000200010001', 100, 200)
	--insert into #dati(idpatrimony, amountprec, amountcurr) values ('19R0002000200010001',10, 300)
	
	--insert into #dati(idpatrimony, amountprec, amountcurr) values ('19C000200010001', -30, -100)
	--insert into #dati(idpatrimony, amountprec, amountcurr) values ('19R00020003', -20, -50)
		
select patrimony.nlevel,

	substring (patrimony.idpatrimony, 1, 7) as 'gruppo_lev1',
	substring (patrimony.idpatrimony, 1, 11) as 'gruppo_lev2',
	case
		when patrimony.nlevel = 2 then replicate(' ',2) + patrimony.codepatrimony
	 	when patrimony.nlevel = 3 then replicate(' ',4) + patrimony.codepatrimony
		when patrimony.nlevel = 3 then replicate(' ',6) + patrimony.codepatrimony
		when patrimony.nlevel = 4 then replicate(' ',8) + patrimony.codepatrimony
	else patrimony.codepatrimony
	end as codepatrimony,
	patrimony.title, 
	patrimony.patpart, 
	isnull(sum(OLD.amountprec),0) AS amountprec,
	isnull(sum(CURR.amountcurr),0) AS amountcurr,
	isnull(sum(CURR.amountcurr),0) - isnull(sum(OLD.amountprec),0) AS DIFFERENZA,
case 
	when patrimony.patpart ='A' and patrimony.codepatrimony like 'A)%' then 'A) CREDITI V/SOCI PER VERSAMENTI ANCORA DOVUTI'
	when patrimony.patpart ='A' and patrimony.codepatrimony like 'B)%' then 'B) IMMOBILIZZAZIONI'
	when patrimony.patpart ='A' AND  patrimony.codepatrimony like 'C)%' then 'C) ATTIVO CIRCOLANTE'
	when patrimony.patpart ='A' AND  patrimony.codepatrimony like 'D)%' then 'D) RATEI E RISCONTRI'


	when patrimony.patpart ='P' and patrimony.codepatrimony like 'A)%' then 'A) PATRIMONIO NETTO'
	when patrimony.patpart ='P' and patrimony.codepatrimony like 'B)%' then 'B) FONDI PER RISCHI E ONERI'
	when patrimony.patpart ='P' AND patrimony.codepatrimony like 'C)%' then 'C) TRATTAMENTO DI FINE RAPPORTO DI LAVORO SUBORDINATO'
	when patrimony.patpart ='P' AND patrimony.codepatrimony like 'D)%' then 'D) DEBITI'
	when patrimony.patpart ='P' AND patrimony.codepatrimony like 'E)%' then 'E) RATEI E RISCONTI'
	ELSE 'x SENZA NOME x'
 END AS 'CAPO_GRUPPO',
 patrimony.printingorder	
from patrimony
left outer join #dati CURR 
	ON patrimony.idpatrimony = CURR.idpatrimony
left outer join  #dati OLD
	on patrimony.idpatrimony = OLD.idpatrimony 
where patrimony.ayear = @ayear
group by patrimony.patpart, patrimony.nlevel, patrimony.idpatrimony, patrimony.codepatrimony,patrimony.nlevel, patrimony.printingorder, patrimony.title
ORDER BY patrimony.patpart, patrimony.printingorder


	drop table #patrimonylookup
	drop table #dati

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec rpt_statopatrimoniale_tree 2020, {ts '2020-01-01 00:00:00'}, {ts '2020-12-31 00:00:00'}
--go
--exec rpt_statopatrimoniale_tree 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-12-31 00:00:00'}
--exec rpt_contoeconomico 2020, {ts '2020-01-01 00:00:00'}, {ts '2020-12-31 00:00:00'}
