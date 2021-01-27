
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_incomegerarchico]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_incomegerarchico]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE  PROCEDURE  exp_incomegerarchico(
	@ymin int,
	@ymax int,
	@ayearmin int,
	@ayearmax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@nphaseparent tinyint,
	@ymovparent  int,
	@nmovparent  int,
	@idupb varchar(36),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
) 
as begin

-- exp_incomegerarchico '2008', '2015', '2008', '2015', null, {ts '2008-01-01 00:00:00.000'}, {ts '2015-12-31 00:00:00.000'}, '%', null, null, null, '%', null, null, null, null, null


declare @idinc int
IF (@nphaseparent IS NULL OR @ymovparent IS NULL OR @nmovparent IS NULL)
	BEGIN
		SET @idinc = null	
	END
Else
	BEGIN
	   	SET @idinc = (select idinc 
				from income 
				where ymov = @ymovparent 
				and nmov   = @nmovparent 
				and nphase = @nphaseparent) 
	END


declare @descrphase1 varchar(20)
declare @descrphase2 varchar(20)
declare @descrphase3 varchar(20)
declare @descrphase4 varchar(20)
declare @descrphase5 varchar(20)

select @descrphase1 = description from  incomephase where nphase = 1
select @descrphase2 = description from  incomephase where nphase = 2
select @descrphase3 = description from  incomephase where nphase = 3
select @descrphase4 = description from  incomephase where nphase = 4
select @descrphase5 = description from  incomephase where nphase = 5

declare @idsorkind01 int
declare @idsorkind02 int
declare @idsorkind03 int
declare @idsorkind04 int
declare @idsorkind05 int

declare @sortingkind01 varchar(50)
declare @sortingkind02 varchar(50)
declare @sortingkind03 varchar(50)
declare @sortingkind04 varchar(50)
declare @sortingkind05 varchar(50)

set @sortingkind01='no'
set @sortingkind02='no'
set @sortingkind03='no'
set @sortingkind04='no'
set @sortingkind05='no'

select @idsorkind01  = idsorkind01 from uniconfig
select @idsorkind02  = idsorkind02 from uniconfig
select @idsorkind03  = idsorkind03 from uniconfig
select @idsorkind04  = idsorkind04 from uniconfig
select @idsorkind05  = idsorkind05 from uniconfig

select @sortingkind01  = description  from sortingkind where idsorkind = @idsorkind01
select @sortingkind02  = description  from sortingkind where idsorkind = @idsorkind02
select @sortingkind03  = description  from sortingkind where idsorkind = @idsorkind03
select @sortingkind04  = description  from sortingkind where idsorkind = @idsorkind04
select @sortingkind05  = description  from sortingkind where idsorkind = @idsorkind05

SELECT 
	S01.sortcode as 'S01_code',
	S02.sortcode as 'S02_code',
	S03.sortcode as 'S03_code',
	S04.sortcode as 'S04_code',
	S05.sortcode as 'S05_code', 
	S01.description as 'S01',
	S02.description as 'S02',
	S03.description as 'S03',
	S04.description as 'S04',
	S05.description as 'S05',
	income.idinc, 
	incomeyear.ayear, 
	income.idreg, 
	incomeyear.idfin, 
	incomeyear.idupb 
INTO #prova
	FROM income
	join incomeyear 
		on incomeyear.idinc=income.idinc 
	left outer join registry 
		on income.idreg=registry.idreg 
	left outer join fin 
		on fin.idfin=incomeyear.idfin 
	left outer join upb 
		on upb.idupb = incomeyear.idupb  
	JOIN incomelink 
		ON incomelink.idchild = income.idinc  
		AND incomelink.idparent = ISNULL(@idinc,income.idinc) 
	LEFT OUTER JOIN sorting S01
				ON upb.idsor01 = S01.idsor
	LEFT OUTER JOIN sorting S02
				ON upb.idsor02 = S02.idsor
	LEFT OUTER JOIN sorting S03
				ON upb.idsor03 = S03.idsor
	LEFT OUTER JOIN sorting S04
				ON upb.idsor04 = S04.idsor
	LEFT OUTER JOIN sorting S05
				ON upb.idsor05 = S05.idsor
	WHERE (@adatemin is null or adate >= @adatemin) and (@adatemax is null or adate <= @adatemax)
	and (@ymin is null or income.ymov >= @ymin)
	and (@ymax is null or income.ymov <= @ymax)
	and (@ayearmin is null or incomeyear.ayear >= @ayearmin)
	and (@ayearmax is null or incomeyear.ayear <= @ayearmax)	

	and (@registry is null or registry.title like @registry)
	and (@codefin is null or codefin like @codefin)
	AND upb.idupb LIKE @idupb
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

declare @sqlcmd nvarchar(4000)

SET @sqlcmd = ' SELECT '

SET @sqlcmd= @sqlcmd+
'	#prova.ayear as ANNO,
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(10),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 1
			where ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase1+''','

if (@descrphase2 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(10),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 2
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase2+''','
if (@descrphase3 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(10),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 3
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase3+''','
if (@descrphase4 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(10),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 4
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase4+''','

if (@descrphase5 is not null)
SET @sqlcmd=@sqlcmd+'
	(select (convert(varchar(4),I1.ymov) + ''/'' + convert(varchar(10),I1.nmov))
		FROM  income I1					 
			JOIN incomelink ilk1
				ON ilk1.idparent = I1.idinc AND ilk1.nlevel = 5
			where  ilk1.idchild = #prova.idinc
	) 		
	AS '''+@descrphase5+''','

	
if (@idsorkind01 is not null)
SET @sqlcmd=@sqlcmd+
'   S01_code  + '' '' +' + '  S01' +  '	AS '''+@sortingkind01+''','

if (@idsorkind02 is not null)
SET @sqlcmd=@sqlcmd+
'   S02_code  + '' '' +' + '   S02' + '   AS '''+@sortingkind02+''','

if (@idsorkind03 is not null)
SET @sqlcmd=@sqlcmd+
'   S03_code  + '' '' +' + '   S03'  + '  AS '''+@sortingkind03+''','

if (@idsorkind04 is not null)
SET @sqlcmd= @sqlcmd+
'   S04_code  +  '' '' +' + '   S04' + '   AS '''+@sortingkind04+''','

if (@idsorkind05 is not null)
SET @sqlcmd=@sqlcmd+
'   S05_code  + '' '' +' + '   S05' + '	AS '''+@sortingkind05+''','


SET @sqlcmd=@sqlcmd+'
	(convert(varchar(4),proceeds.ypro) + ''/'' + convert(varchar(6),proceeds.npro)) as Reversale,
	codefin as ''Codice bilancio'',
	fin.title as ''Voce di bilancio'',
	codeupb as ''Codice UPB'',
	upb.title as ''UPB'',
	registry.title as ''Beneficiario'',
	income.description as ''Descrizione'',
	incometotal.curramount as ''Importo corrente'',
	case when incomelast.idinc is not null then null else incometotal.available end as ''Disponibile'',
	income.adate as ''Data contabile'',
	income.doc as ''Doc.'',
	income.docdate as ''Data Doc.''

FROM #prova
LEFT OUTER JOIN fin 
	on fin.idfin=#prova.idfin
LEFT OUTER JOIN upb 
	on upb.idupb=#prova.idupb
LEFT OUTER JOIN registry 
	on registry.idreg=#prova.idreg
LEFT OUTER JOIN income 
	on income.idinc=#prova.idinc
LEFT OUTER JOIN incomelast 
	on incomelast.idinc = #prova.idinc
LEFT OUTER JOIN proceeds 
	on incomelast.kpro = proceeds.kpro
LEFT OUTER JOIN incometotal 
	ON incometotal.idinc = #prova.idinc AND incometotal.ayear = #prova.ayear 
order by 1,2,3,4,5

'
--print @sqlcmd

EXECUTE sp_executesql  @sqlcmd

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

