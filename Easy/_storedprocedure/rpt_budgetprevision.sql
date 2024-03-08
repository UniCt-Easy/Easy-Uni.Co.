
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_budgetprevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_budgetprevision]
GO
 
/****** Object:  StoredProcedure [amministrazione].[rpt_budgetprevision]    Script Date: 31/10/2014 16.42.20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec  rpt_budgetprevision 2016, 62, '%', 'N', 'S', 'S', NULL, NULL, NULL, NULL, NULL

CREATE  PROCEDURE [rpt_budgetprevision]
(
	@ayear smallint,
	@idsorkind int,
	@idupb varchar(36)='%',
	@showupb char(1)='N',
	@showchildupb char(1)='N',
	@suppressifblank char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN
--	exec rpt_budgetprevision 2013, 21, '%','S','S',3,null,null,null,null,null
-- exec rpt_budgetprevision 2013, 23, '00010013','N','N', 'S',null,null,null,null,null
/*
Ultima modifica
Gianni per adeguamento alla classificazione pilota della Sun

*/


DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb
declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'
IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END
DECLARE @MostraTutteVoci char(1)
SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'
DECLARE @oplevel tinyint
SELECT @oplevel = MAX(nlevel) --> Prendiamo il max perchè le prev. vengono messe sui nodi foglia, enon sui capitolo come avviene per il bilancio.
FROM sortinglevel
WHERE  (flag&2)<>0 and idsorkind = @idsorkind
	
CREATE TABLE #data
(
	idsor int,
	idupb varchar(36),
	prevision decimal(19,2),
	previousprevision decimal(19,2),
	tosuppress char(1)
)
insert into #data (
	idsor,
	idupb,
	prevision,
	previousprevision
)
select budgetprevision.idsor, budgetprevision.idupb,
		ISNULL(SUM(budgetprevision.prevision),0),
		isnull(sum(budgetprevision.previousprevision),0)
from budgetprevision 
join sorting 
	on budgetprevision.idsor = sorting.idsor
join sortingkind K
	ON sorting.idsorkind = K.idsorkind
JOIN upb U
	ON budgetprevision.idupb = U.idupb
JOIN sortinglevel 
	ON sorting.nlevel = sortinglevel.nlevel 
where budgetprevision.ayear = @ayear
		and K.idsorkind = @idsorkind
		and sortinglevel.idsorkind = @idsorkind
		AND (budgetprevision.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND (sorting.nlevel = @oplevel
			OR (sorting.nlevel < @oplevel		
				AND not EXISTS (SELECT * FROM sorting S2 WHERE S2.paridsor = sorting.idsor and S2.idsorkind=@idsorkind)
				AND (sortinglevel.flag&2)<>0
			   )
			)
			
group by budgetprevision.idsor, budgetprevision.idupb

--select budgetprevision.idsor, sorting.nlevel, budgetprevision.idupb,
--		ISNULL(SUM(budgetprevision.prevision),0),
--		isnull(sum(budgetprevision.previousprevision),0)
--from budgetprevision 
--join sorting 
--	on budgetprevision.idsor = sorting.idsor
--join sortingkind K
--	ON sorting.idsorkind = K.idsorkind
--JOIN upb U
--	ON budgetprevision.idupb = U.idupb
--JOIN sortinglevel 
--	ON sorting.nlevel = sortinglevel.nlevel 
--where budgetprevision.ayear = @ayear
--		and K.idsorkind = @idsorkind
--		and sortinglevel.idsorkind = @idsorkind
--		AND (budgetprevision.idupb LIKE @idupb)	
--		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
--		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
--		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
--		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
--		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
--		AND (sorting.nlevel = @oplevel
--			OR (sorting.nlevel < @oplevel		
--				AND not EXISTS (SELECT * FROM sorting S2 WHERE S2.paridsor = sorting.idsor and S2.idsorkind=@idsorkind)
--				AND (sortinglevel.flag&2)<>0
--			   )
--			)
--and budgetprevision.idsor = 1973			
--group by budgetprevision.idsor, budgetprevision.idupb,sorting.nlevel


UPDATE #data SET tosuppress = 'N'
/* Poichè la classificazione è nota imposto manualmente la lunghezza*/
DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = 1--flag / 256 FROM sortinglevel WHERE nlevel = 1 and idsorkind = @idsorkind
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = 1 --flag / 256 FROM sortinglevel WHERE nlevel = 2 and idsorkind = @idsorkind
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = 1--flag / 256 FROM sortinglevel WHERE  nlevel = 3 and idsorkind = @idsorkind
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = 1 --flag / 256 FROM sortinglevel WHERE nlevel = 4 and idsorkind = @idsorkind
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = 2 --flag / 256 FROM sortinglevel WHERE nlevel = 5 and idsorkind = @idsorkind
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
DECLARE @lencod_lev6 int 
SELECT @lencod_lev6 = 1 --flag / 256 FROM sortinglevel WHERE nlevel = 6 and idsorkind = @idsorkind
DECLARE @startpos6 int 
SELECT @startpos6 = @startpos5 + @lencod_lev5
DECLARE @lencod_lev7 int 
SELECT @lencod_lev7 = 2 --flag / 256 FROM sortinglevel WHERE nlevel = 6 and idsorkind = @idsorkind
DECLARE @startpos7 int 
SELECT @startpos7 = @startpos6 + @lencod_lev6

DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM sortinglevel WHERE nlevel = 1 and idsorkind = @idsorkind
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM sortinglevel WHERE nlevel = 2 and idsorkind = @idsorkind
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM sortinglevel WHERE nlevel = 3 and idsorkind = @idsorkind
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM sortinglevel WHERE nlevel = 4 and idsorkind = @idsorkind
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM sortinglevel WHERE nlevel = 5 and idsorkind = @idsorkind
DECLARE @lev_desc6 varchar(50)
SELECT @lev_desc6 = description FROM sortinglevel WHERE nlevel = 6 and idsorkind = @idsorkind
DECLARE @lev_desc7 varchar(50)
SELECT @lev_desc7 = description FROM sortinglevel WHERE nlevel = 7 and idsorkind = @idsorkind

if (@oplevel<7) 
	set @lev_desc7='liv7'
	
if (@oplevel<6) 
	set @lev_desc6='liv6'

if (@oplevel<5) 
	set @lev_desc5='liv5'
if (@oplevel<4) 
	set @lev_desc4='liv4'
if (@oplevel<3) 
	set @lev_desc3='liv3'

if (@oplevel<2) 
	set @lev_desc2='liv2'
	
--select * from #data
IF (@showupb ='S')
BEGIN
 SELECT 
	isnull(#data.tosuppress, @suppressifblank) AS tosuppress,	
	K.codesorkind, 
	K.description as sortingkind,
	S.idsor,S.sortcode,
	SUBSTRING(S.sortcode, @startpos1, @lencod_lev1) as code1,
	S1.description AS desc1,
	@lev_desc1 AS descliv1,

	--SUBSTRING(S.printingorder, @startpos1, @lencod_lev1) 
	S1.printingorder as order1,
	
	CASE when (S2.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos2, @lencod_lev2) 
	end	as code2,
	S2.description AS desc2,
	@lev_desc2 AS descliv2,
	
	--SUBSTRING(S.printingorder, @startpos2, @lencod_lev2) 
	S2.printingorder as order2,
	
	case when (S3.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos3, @lencod_lev3)
	end	 as code3,
	S3.description as desc3,
	@lev_desc3 as descliv3,
	
	--SUBSTRING(S.printingorder, @startpos3, @lencod_lev3) 
	S3.printingorder as order3,
	case when (S4.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos4, @lencod_lev4)
	end	as code4,
	S4.description AS desc4,
	@lev_desc4 AS descliv4,
	
	--SUBSTRING(S.printingorder, @startpos4, @lencod_lev4) 
	S4.printingorder as order4,
	
	case when (S5.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos5, @lencod_lev5) 
	end	as code5,
	S5.description AS desc5,
	@lev_desc5 AS descliv5,
	
	--SUBSTRING(S.printingorder, @startpos5, @lencod_lev5) 
	S5.printingorder as order5,
	
	case when (S6.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos6, @lencod_lev6) 
	end	as code6,
	S6.description AS desc6,
	@lev_desc6 AS descliv6,
	
	--SUBSTRING(S.printingorder, @startpos6, @lencod_lev6) 
	S6.printingorder as order6,
	
	case when (S7.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos7, @lencod_lev7) 
	end	as code7,
	S7.description AS desc7,
	@lev_desc7 AS descliv7,
	
	--SUBSTRING(S.printingorder, @startpos6, @lencod_lev6) 
	S7.printingorder as order7,
	upb.codeupb,
	upb.idupb as idupb,
	upb.title as upb,
	upb.printingorder as upbprintingorder,
	
	S.nlevel,
	ISNULL(SUM(prevision),0) AS prevision,
	ISNULL(SUM(previousprevision),0) AS previousprevision,
	@oplevel AS oplevel
FROM sorting S
JOIN sortinglevel SL
	ON S.nlevel = SL.nlevel and SL.idsorkind = S.idsorkind
join sortingkind K
	on S.idsorkind = K.idsorkind
cross join upb 
left outer join #data on #data.idsor = S.idsor and #data.idupb=upb.idupb
LEFT OUTER JOIN sortinglink slk1
	ON slk1.idchild = S.idsor AND slk1.nlevel = 1
LEFT OUTER JOIN sorting	S1	
	ON slk1.idparent = S1.idsor and S1.idsorkind = @idsorkind
LEFT OUTER JOIN sortinglink slk2
	ON slk2.idchild = S.idsor AND slk2.nlevel = 2
LEFT OUTER JOIN sorting S2 
	ON slk2.idparent = S2.idsor and S2.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk3
	ON slk3.idchild = S.idsor AND slk3.nlevel = 3
LEFT OUTER JOIN sorting S3
	ON slk3.idparent = S3.idsor and S3.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk4
	ON slk4.idchild = S.idsor AND slk4.nlevel = 4
LEFT OUTER JOIN sorting S4
	ON slk4.idparent = S4.idsor and S4.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk5
	ON slk5.idchild = S.idsor AND slk5.nlevel = 5
LEFT OUTER JOIN sorting S5
	ON slk5.idparent = S5.idsor  and S5.idsorkind = @idsorkind
LEFT OUTER JOIN sortinglink slk6
	ON slk6.idchild = S.idsor AND slk6.nlevel = 6
LEFT OUTER JOIN sorting S6
	ON slk6.idparent = S6.idsor  and S6.idsorkind = @idsorkind	
LEFT OUTER JOIN sortinglink slk7
	ON slk7.idchild = S.idsor AND slk7.nlevel = 7
LEFT OUTER JOIN sorting S7
	ON slk7.idparent = S7.idsor  and S7.idsorkind = @idsorkind	
where   ( @MostraTutteVoci = 'S'  or @suppressifblank='N' or isnull(#data.tosuppress, 'S')='N' OR  upb.idupb='0001')
	and	(S.nlevel = @oplevel 
			OR (S.nlevel < @oplevel
				AND not EXISTS (SELECT * FROM sorting SS WHERE SS.paridsor = S.idsor and SS.idsorkind=@idsorkind)
				AND (SL.flag&2)<>0
			   )
			 )
	   and upb.idupb like @idupb
	   and S.idsorkind = @idsorkind
	   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
GROUP BY K.codesorkind, K.description,
	S.idsor, S.sortcode,upb.printingorder,upb.idupb,upb.title,upb.codeupb,
	upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05,
	SUBSTRING(S.sortcode, @startpos1, @lencod_lev1),
	SUBSTRING(S.sortcode, @startpos2, @lencod_lev2),S2.sortcode,
	SUBSTRING(S.sortcode, @startpos3, @lencod_lev3),S3.sortcode,
	SUBSTRING(S.sortcode, @startpos4, @lencod_lev4),S4.sortcode,
	SUBSTRING(S.sortcode, @startpos5, @lencod_lev5),S5.sortcode,
	SUBSTRING(S.sortcode, @startpos6, @lencod_lev6),S6.sortcode,
	SUBSTRING(S.sortcode, @startpos7, @lencod_lev7),S7.sortcode,
	SUBSTRING(S.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(S.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(S.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(S.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(S.printingorder, @startpos5, @lencod_lev5),
	SUBSTRING(S.printingorder, @startpos6, @lencod_lev6),
	SUBSTRING(S.printingorder, @startpos7, @lencod_lev7), 
	S1.printingorder, S2.printingorder,S3.printingorder,S4.printingorder,S5.printingorder,S6.printingorder,S7.printingorder,
	S1.description,S2.description,S3.description,S4.description,S5.description,S6.description,S7.description, S.printingorder,
	S.nlevel,isnull(#data.tosuppress, @suppressifblank)
	
 ORDER BY upb.printingorder ASC,S.printingorder ASC
END
IF (@showupb ='N')
BEGIN
	declare 	@codeupb varchar(50)
	declare		@upb varchar(150)
	declare		@upbprintingorder varchar(50)
	declare		@ext_idupb varchar(50)
	if (@idupboriginal='%')
	begin
		set @codeupb= null
		set @upb= null
		set @upbprintingorder= null
		set @ext_idupb= null
	end
	else
	begin
		SET @upbprintingorder =
			(SELECT TOP 1 printingorder
			FROM upb
			WHERE idupb = @idupboriginal)
		SET  @upb =
			(SELECT TOP 1 title
			FROM upb
			WHERE idupb = @idupboriginal)
		SET  @ext_idupb =	@idupboriginal
		SET  @codeupb =
			(SELECT TOP 1 codeupb
			FROM upb	
			WHERE idupb = @idupboriginal)
	end
 SELECT 
	isnull(#data.tosuppress, @suppressifblank) AS tosuppress,	
	K.codesorkind, 
	K.description as sortingkind,
	S.idsor,S.sortcode,
	SUBSTRING(S.sortcode, @startpos1, @lencod_lev1) as code1,
	S1.description AS desc1,
	@lev_desc1 AS descliv1,
	--SUBSTRING(S.printingorder, @startpos1, @lencod_lev1) as order1,
	S1.printingorder as order1,
	CASE when (S2.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos2, @lencod_lev2) 
	end	as code2,
	S2.description AS desc2,
	@lev_desc2 AS descliv2,
	--SUBSTRING(S.printingorder, @startpos2, @lencod_lev2) as order2,
	S2.printingorder as order2,
	case when (S3.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos3, @lencod_lev3)
	end	 as code3,
	S3.description as desc3,
	@lev_desc3 as descliv3,
	--SUBSTRING(S.printingorder, @startpos3, @lencod_lev3) as order3,
	S3.printingorder as order3,
	case when (S4.sortcode is null) then null
		else	SUBSTRING(S.sortcode, @startpos4, @lencod_lev4)
	end	as code4,
	S4.description AS desc4,
	@lev_desc4 AS descliv4,
	--SUBSTRING(S.printingorder, @startpos4, @lencod_lev4) as order4,
	S4.printingorder as order4,
	case when (S5.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos5, @lencod_lev5)
	end	as code5,
	S5.description AS desc5,
	@lev_desc5 AS descliv5,
	--SUBSTRING(S.printingorder, @startpos5, @lencod_lev5 ) as order5,
	S5.printingorder as order5,
	case when (S6.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos6, @lencod_lev6) 
	end	as code6,
	S6.description AS desc6,
	@lev_desc6 AS descliv6,
	S6.printingorder as order6,
		case when (S7.sortcode is null) then null
		else SUBSTRING(S.sortcode, @startpos7, @lencod_lev7) 
	end	as code7,
	S7.description AS desc7,
	@lev_desc7 AS descliv7,
	S7.printingorder as order7,
	@codeupb as codeupb,
	@ext_idupb as idupb,
	@upb as upb,
	@upbprintingorder as upbprintingorder,
	S.nlevel,
	ISNULL(SUM(prevision),0) AS prevision,
	ISNULL(SUM(previousprevision),0) AS previousprevision,
	@oplevel AS oplevel
FROM sorting S
JOIN sortinglevel SL
	ON S.nlevel = SL.nlevel and SL.idsorkind = S.idsorkind
join sortingkind K
	on S.idsorkind = K.idsorkind
left outer join #data on #data.idsor = S.idsor
LEFT OUTER JOIN sortinglink slk1
	ON slk1.idchild = S.idsor AND slk1.nlevel = 1
LEFT OUTER JOIN sorting	S1	
	ON slk1.idparent = S1.idsor and S1.idsorkind = @idsorkind
LEFT OUTER JOIN sortinglink slk2
	ON slk2.idchild = S.idsor AND slk2.nlevel = 2
LEFT OUTER JOIN sorting S2 
	ON slk2.idparent = S2.idsor and S2.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk3
	ON slk3.idchild = S.idsor AND slk3.nlevel = 3
LEFT OUTER JOIN sorting S3
	ON slk3.idparent = S3.idsor and S3.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk4
	ON slk4.idchild = S.idsor AND slk4.nlevel = 4
LEFT OUTER JOIN sorting S4
	ON slk4.idparent = S4.idsor and S4.idsorkind = @idsorkind 
LEFT OUTER JOIN sortinglink slk5
	ON slk5.idchild = S.idsor AND slk5.nlevel = 5
LEFT OUTER JOIN sorting S5
	ON slk5.idparent = S5.idsor  and S5.idsorkind = @idsorkind
LEFT OUTER JOIN sortinglink slk6
	ON slk6.idchild = S.idsor AND slk6.nlevel = 6
LEFT OUTER JOIN sorting S6
	ON slk6.idparent = S6.idsor  and S6.idsorkind = @idsorkind	
LEFT OUTER JOIN sortinglink slk7
	ON slk7.idchild = S.idsor AND slk7.nlevel = 7
LEFT OUTER JOIN sorting S7
	ON slk7.idparent = S7.idsor  and S7.idsorkind = @idsorkind	
where   ( @MostraTutteVoci = 'S' or @suppressifblank='N' or isnull(#data.tosuppress, 'S')='N' OR  #data.idupb='0001')
	and	(S.nlevel = @oplevel 
			OR (S.nlevel < @oplevel
				AND not EXISTS (SELECT * FROM sorting SS WHERE SS.paridsor = S.idsor and SS.idsorkind=@idsorkind)
				AND (SL.flag&2)<>0
			   )
			 )
	   and S.idsorkind = @idsorkind
GROUP BY K.codesorkind, K.description,
	S.idsor, S.sortcode,
	SUBSTRING(S.sortcode, @startpos1, @lencod_lev1),
	SUBSTRING(S.sortcode, @startpos2, @lencod_lev2),S2.sortcode,
	SUBSTRING(S.sortcode, @startpos3, @lencod_lev3),S3.sortcode,
	SUBSTRING(S.sortcode, @startpos4, @lencod_lev4),S4.sortcode,
	SUBSTRING(S.sortcode, @startpos5, @lencod_lev5),S5.sortcode,
	SUBSTRING(S.sortcode, @startpos6, @lencod_lev6),S6.sortcode,
	SUBSTRING(S.sortcode, @startpos7, @lencod_lev7),S7.sortcode,
	SUBSTRING(S.printingorder, @startpos1, @lencod_lev1),
	SUBSTRING(S.printingorder, @startpos2, @lencod_lev2),
	SUBSTRING(S.printingorder, @startpos3, @lencod_lev3),
	SUBSTRING(S.printingorder, @startpos4, @lencod_lev4),
	SUBSTRING(S.printingorder, @startpos5, @lencod_lev5),
	SUBSTRING(S.printingorder, @startpos6, @lencod_lev6),
	SUBSTRING(S.printingorder, @startpos7, @lencod_lev7),
	S1.printingorder, S2.printingorder,S3.printingorder,S4.printingorder,S5.printingorder,S6.printingorder,S7.printingorder,
	S1.description,S2.description,S3.description,S4.description,S5.description,S6.description,S7.description,S.printingorder,
	S.nlevel,isnull(#data.tosuppress, @suppressifblank)
	
 ORDER BY S.printingorder ASC
END	


END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
