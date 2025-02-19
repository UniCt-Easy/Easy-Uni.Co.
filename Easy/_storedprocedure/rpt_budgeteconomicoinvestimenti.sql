
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgeteconomicoinvestimenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgeteconomicoinvestimenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE      PROCEDURE [rpt_budgeteconomicoinvestimenti](
	@ayear int,--> anno del bilancio di previsione
	@idsorkindfin1 int,--Entrate
	@idsorkindfin2 int,--Uscite
	@kind char(1), -- I = Budget degli Investimenti, E = Budget Economico, R = Riclassificato Finanziario SUN Entrate e Riclassificato Finanziario SUN Spese
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
declare @treasurer varchar(150)
if(@idupb = '%') 
Begin
	select @treasurer = null
end
Else
Begin
	select @treasurer = isnull(T.header, T.description) from upb U
						join treasurer T
							ON T.idtreasurer = U.idtreasurer
						where U.idupb = @idupb
End

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END



CREATE TABLE #data(
	idsorkind int,
	idsor int,
	paridsor int,
	sortcode varchar(50),
	sorting varchar(200),
	nlevel tinyint,
	printingorder varchar(50),
	myprintingorder varchar(150),
	finpart char(1),
	initialprevision decimal(19,2),
	articolato char(1)
)

insert into #data (
	idsorkind,
	idsor,
	paridsor,
	sortcode,
	sorting,
	nlevel,
	printingorder,
	finpart,
	initialprevision)
SELECT 
	sorFin.idsorkind,
	sorFin.idsor,
	sorFin.paridsor,
	sorFin.sortcode,
	sorFin.description,
	sorFin.nlevel,
	sorFin.printingorder,
	CASE
		when (( fin.flag & 1)=0) then 'E'
		when (( fin.flag & 1)=1) then 'S'
	End,
	ISNULL(SUM(isnull(FS.quota,1)*finyear.prevision),0)	
FROM finyear 
JOIN upb U
	ON finyear.idupb = U.idupb
join fin
	on finyear.idfin = fin.idfin
JOIN finlast 
	ON finyear.idfin = finlast.idfin
LEFT OUTER JOIN finsorting FS
	ON FS.idfin = finlast.idfin	 AND FS.idsor in (select idsor from sorting where idsorkind in (@idsorkindfin1, @idsorkindfin2))
LEFT OUTER JOIN sorting sorFin
	ON sorFin.idsor = FS.idsor				
WHERE finyear.ayear = @ayear
	AND U.idupb like @idupb
	AND ( sorFin.idsorkind  in (@idsorkindfin1, @idsorkindfin2))
	AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by sorFin.idsorkind, sorFin.idsor, sorFin.paridsor, sorFin.nlevel, 
	sorFin.printingorder, sorFin.sortcode, sorFin.description,(fin.flag & 1)

-- Inserisce i livelli mancanti
insert into #data (
	idsorkind,
	idsor,
	paridsor,
	sortcode,
	sorting,
	nlevel,
	printingorder,
	finpart,
	initialprevision)
SELECT 
	S.idsorkind,
	S.idsor,
	S.paridsor,
	S.sortcode,
	S.description,
	S.nlevel,
	S.printingorder,
	case 
		when S.idsorkind = @idsorkindfin1 then 'E'
		when S.idsorkind = @idsorkindfin2 then 'S' 
	end,
	null
from sorting S
where S.idsorkind in (@idsorkindfin1, @idsorkindfin2)
	and not exists (select * from #data D2 where D2.idsor = S.idsor)

-- Totalizza i padri
update #data set initialprevision = (select SUM(initialprevision) from #data D2
						where #data.idsor = D2.paridsor)
where initialprevision is null			

update #data set initialprevision = (select SUM(initialprevision) from #data D2
						where #data.idsor = D2.paridsor)
where initialprevision is null

update #data set initialprevision = (select SUM(initialprevision) from #data D2
						where #data.idsor = D2.paridsor)
where initialprevision is null
			
-- va grassetto se articolato, o se ha fratelli articolati
update #data set articolato = 'S' where exists (select * from #data D2 where D2.paridsor = #data.idsor)				
update #data set articolato = 'S' where exists (select * from #data D2 
											where  D2.paridsor = #data.paridsor and  D2.articolato='S')				
update #data set articolato = 'S' where nlevel = 1

if (@kind = 'E')
Begin
	update #data set finpart = null
	update #data set myprintingorder = '1' where printingorder like 'P%'
	update #data set myprintingorder = '2' where printingorder like 'C%'
	update #data set myprintingorder = '21' where printingorder like 'CS%'
	update #data set myprintingorder = '22' where printingorder like 'CG%'
	update #data set myprintingorder = '4' where printingorder like 'O%'
	update #data set myprintingorder = '5' where printingorder like 'F%'
	update #data set myprintingorder = '6' where printingorder like 'R%'
	update #data set myprintingorder = '7' where printingorder like 'S%'
	update #data set myprintingorder = '8' where printingorder like 'I%'
	update #data set myprintingorder = D2.myprintingorder from #data D2 where D2.printingorder like printingorder

	insert into #data (sortcode,sorting,nlevel,printingorder,myprintingorder,finpart,initialprevision,articolato)
	select
		null, 'DIFFERENZA TRA PROVENTI E COSTI OPERATIVI',1, null,3,null,
		(select sum(initialprevision)from #data where sortcode = 'P')-(select sum(initialprevision)from #data where sortcode = 'C'),
		'S'

	update #data set sortcode= replace(replace(replace(replace(replace(replace(replace(sortcode, 'R',''), 'F',''), 'O',''), 'S',''), 'G',''), 'C',''), 'P','')
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%1%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%2%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%3%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%4%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%5%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%6%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%7%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%8%',sortcode)<>0
	update #data set sortcode= replace(replace(sortcode, 'V',''),'I','') where PATINDEX('%9%',sortcode)<>0
End

if (@kind = 'I')
Begin
	update #data set finpart = null
	update #data set sortcode = substring(sortcode,3,len(sortcode)) where nlevel <>2
	update #data set sortcode = case when sortcode = '11' then 'I'
								when sortcode = '12' then 'II'
								when sortcode = '13' then 'III'
								when sortcode = '14' then 'IV'
								when sortcode = '15' then 'V'
								end
	where nlevel = 2
End

if (@kind = 'R')
Begin
		-- COOREGGE printingorder C'E' UN 1 IN PIU'!!!! Altrimenti "da Miur a altre Amministrazioni centrali" viene in coda
		update #data set printingorder= replace(printingorder, 'B1','B') where PATINDEX('%B1%',printingorder)<>0

		update #data set sortcode = null where nlevel = 1
		update #data set sortcode = substring(sortcode,2,len(sortcode)) where nlevel =2
		update #data set sortcode = substring(sortcode,3,len(sortcode)) where nlevel =3
		update #data set sortcode = substring(sortcode,4,len(sortcode)) where nlevel =4
		update #data set myprintingorder = '1' where finpart='E'
		insert into #data (sortcode,sorting,nlevel,printingorder,myprintingorder,finpart,initialprevision,articolato)
		select null, 'TOTALE ENTRATE',1, null,'2','E',
			sum(initialprevision),
			'S'
		from #data where nlevel = 1 and finpart ='E'
		update #data set myprintingorder = '3' where finpart='S'
		insert into #data (sortcode,sorting,nlevel,printingorder,myprintingorder,finpart,initialprevision,articolato)
		select null, 'TOTALE USCITE',1, null,'4','S',
			sum(initialprevision),
			'S'
		from #data where nlevel = 1 and finpart='S'	

End

	SELECT 
		@treasurer as department,
		idsorkind,
		myprintingorder,
		sorting,
		sortcode,
		nlevel,
		printingorder,
		initialprevision,
		isnull(articolato,'N') as articolato
	FROM #data
	order by finpart,myprintingorder,printingorder
				
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


