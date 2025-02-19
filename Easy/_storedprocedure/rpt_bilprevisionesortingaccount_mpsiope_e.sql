
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilprevisionesortingaccount_mpsiope_e]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilprevisionesortingaccount_mpsiope_e]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 
-- exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 69,3,'%','S','N','S', null, null, null, null, null
---exec "UNITUS_test"."amministrazione"."rpt_bilprevisionesortingaccount_mpsiope_e";1 2018, 27, 4, '%', 'N', 'N', 'S', NULL, NULL, NULL, NULL, NULL
-- exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 27, 4, '%', 'S', 'S', 'N', NULL, NULL, NULL, NULL, NULL
-- exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 27, 3, '0001', 'S', 'S', 'S', NULL, NULL, NULL, NULL, NULL
CREATE    PROCEDURE [rpt_bilprevisionesortingaccount_mpsiope_e]
(
	@ayear smallint,
	@idsorkindfin int, --	=> Classificazione Siope DI_394_08.06.17 Entrate
	@levelusable tinyint,
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

DECLARE @idupboriginal varchar(36)
SET @idupboriginal = @idupb

declare @fixedidupb varchar(36)
set @fixedidupb= null
if (@showupb='N') set @fixedidupb='0001'

IF (@showchildupb = 'S')
BEGIN
	SET @idupb = @idupb + '%' 
END



DECLARE	@finpart_bit  tinyint  -- Parte del bilancio (Entrata / Spesa)
set @finpart_bit = 0

DECLARE @MostraTutteVoci char(1)
--SELECT @MostraTutteVoci = isnull(paramvalue,'N') 
--FROM generalreportparameter WHERE idparam = 'MostraTutteVoci'
SET @MostraTutteVoci = 'N' -- Forziamo questo parametro a N perch� non si desidera vedere le voci a importo 0
DECLARE @MAXoplevel tinyint
SELECT @MAXoplevel = MAX(nlevel)
FROM sortinglevel
WHERE idsorkind = @idsorkindfin

-- SE non � stato selezionato il livello, prende l'ultimo livello operativo
if(isnull(@levelusable,0)=0 )
Begin
	set @levelusable = @MAXoplevel
End
	
DECLARE @levelusable_original tinyint	
SET @levelusable_original = @levelusable

IF(@levelusable < @MAXoplevel)-- se decidi di fare la stampa per categoria
begin
	SET @levelusable = @MAXoplevel
end

CREATE TABLE #data
(
	idsor int,
	idupb varchar(36),
	prevision_curr decimal(19,2),
	tosuppress char(1)
)


insert into #data (
	idsor,
	idupb,
	prevision_curr
)
select	isnull(SLK.idparent, sorFin.idsor),
		isnull(@fixedidupb,accountvardetail.idupb),
		ISNULL(SUM(accountvardetail.prevcassa*ISNULL(FS.quota,0)),0)
from accountvardetail 
	join account f5 on accountvardetail.idacc = f5.idacc
--join finlast	
--	on finlast.idfin = f5.idfin
JOIN upb U
	ON accountvardetail.idupb = U.idupb
JOIN accountsorting FS
	ON FS.idacc = f5.idacc	
JOIN sorting sorFin
	ON sorFin.idsor = FS.idsor				
JOIN sortinglevel sl
	ON sorFin.nlevel = sl.nlevel 
join placcount
	on f5.idplaccount = placcount.idplaccount
LEFT OUTER JOIN sortinglink SLK on SLK.idchild = sorFin.idsor and SLK.nlevel = @levelusable_original
where f5.ayear = @ayear
		AND sl.idsorkind = @idsorkindfin
		AND sorFin.idsorkind = @idsorkindfin
		AND (accountvardetail.idupb LIKE @idupb)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
		AND ((f5.flag & 1)= @finpart_bit) 
		AND (sorFin.nlevel = @levelusable
			OR (sorFin.nlevel < @levelusable
				and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = sorFin.idsor)=0
				AND (sl.flag&2)<>0
			   )
			)
		and placcount.placcpart='R'
		and U.active = 'S'	

 group by isnull(SLK.idparent, sorFin.idsor),isnull(@fixedidupb,accountvardetail.idupb)
 
--select * from #data where idsor in (6134, 6133, 6118)
UPDATE #data SET tosuppress = 'N'
if(@suppressifblank='S')
Begin
	delete from #data where isnull(prevision_curr,0)=0
	--UPDATE #data SET tosuppress = 'S' where isnull(prevision_curr,0)=0
End

DECLARE @lencod_lev1 int
SELECT @lencod_lev1 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 1
DECLARE @startpos1 int
SELECT @startpos1 = 1
DECLARE @lencod_lev2 int
SELECT @lencod_lev2 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 2
DECLARE @startpos2 int
SELECT @startpos2 = @startpos1 + @lencod_lev1
DECLARE @lencod_lev3 int
SELECT @lencod_lev3 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 3
DECLARE @startpos3 int
SELECT @startpos3 = @startpos2 + @lencod_lev2
DECLARE @lencod_lev4 int
SELECT @lencod_lev4 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 4
DECLARE @startpos4 int
SELECT @startpos4 = @startpos3 + @lencod_lev3
DECLARE @lencod_lev5 int 
SELECT @lencod_lev5 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 5
DECLARE @startpos5 int 
SELECT @startpos5 = @startpos4 + @lencod_lev4
DECLARE @lencod_lev6 int 
SELECT @lencod_lev6 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 6
DECLARE @startpos6 int 
SELECT @startpos6 = @startpos5 + @lencod_lev5

DECLARE @lencod_lev7 int 
SELECT @lencod_lev7 = flag / 256 FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 7

DECLARE @startpos7 int 
SELECT @startpos7 = @startpos6 + @lencod_lev6

DECLARE @lev_desc1 varchar(50)
SELECT @lev_desc1 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 1
DECLARE @lev_desc2 varchar(50)
SELECT @lev_desc2 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 2
DECLARE @lev_desc3 varchar(50)
SELECT @lev_desc3 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 3
DECLARE @lev_desc4 varchar(50)
SELECT @lev_desc4 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 4
DECLARE @lev_desc5 varchar(50)
SELECT @lev_desc5 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 5
DECLARE @lev_desc6 varchar(50)
SELECT @lev_desc6 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 6
DECLARE @lev_desc7 varchar(50)
SELECT @lev_desc7 = description FROM sortinglevel WHERE idsorkind = @idsorkindfin AND nlevel = 7


if (@levelusable_original<7) 
	set @lev_desc6='liv7'

if (@levelusable_original<6) 
	set @lev_desc6='liv6'

if (@levelusable_original<5) 
	set @lev_desc5='liv5'

if (@levelusable_original<4) 
	set @lev_desc4='liv4'

if (@levelusable_original<3) 
	set @lev_desc3='liv3'

if (@levelusable_original<2) 
	set @lev_desc2='liv2'

declare @sortingkind varchar(50)
select @sortingkind = description from sortingkind where idsorkind = @idsorkindfin

-------------------------------- Controlla che vi siano solo 2 nodi di livello 1 ---------------------

declare @CountRoot int 
select @CountRoot = count(distinct s.sortcode) from sorting s
	JOIN sortinglink flk1
			ON flk1.idparent = s.idsor AND flk1.nlevel = 1 
	join #data
		on flk1.idchild = #data.idsor
	where s.idsorkind = @idsorkindfin 

declare @Root varchar(50)

if (@CountRoot=1)
begin
	SET @Root = (select top 1 s.sortcode from sorting s
	JOIN sortinglink flk1
			ON flk1.idparent = s.idsor AND flk1.nlevel = 1 
	join #data
		on flk1.idchild = #data.idsor
	where s.idsorkind = @idsorkindfin )

	SET @Root = @Root + '%'
end
else
begin
	SET @Root = '%'
End
 
------------------------------------------------------------------------------------------------------
--SELECT * FROM #DATA  WHERE IDUPB='0001000300010022' 
IF (@showupb ='S')
BEGIN

		SELECT 
			@sortingkind as 'sortingkind',
			f.idsor, 
			SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
			f1.description AS desc1,
			@lev_desc1 AS descliv1,
			SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
			CASE when (f2.sortcode is null) then null
				else SUBSTRING(f.sortcode, @startpos2, @lencod_lev2) 
			end	as code2,
			f2.description AS desc2,
			@lev_desc2 AS descliv2,
			SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
			case when (f3.sortcode is null) then null
				else SUBSTRING(f.sortcode, @startpos3, @lencod_lev3)
			end	 as code3,
			f3.description as desc3,
			@lev_desc3 as descliv3,
			SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
			case when (f4.sortcode is null) then null
				else	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4)
			end	as code4,
			f4.description AS desc4,
			@lev_desc4 AS descliv4,
			SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
			case when (f5.sortcode is null) then null
				else SUBSTRING(f.sortcode, @startpos5, @lencod_lev5) 
			end	as code5,
			f5.description AS desc5,
			@lev_desc5 AS descliv5,
			SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
			case when (f6.sortcode is null) then null
				else SUBSTRING(f.sortcode, @startpos6, @lencod_lev6) 
			end	as code6,
			f6.description AS desc6,
			@lev_desc6 AS descliv6,
			SUBSTRING(f.printingorder, @startpos6, @lencod_lev6) as order6,
			
			case when (f7.sortcode is null) then null
				else SUBSTRING(f.sortcode, @startpos7, @lencod_lev7) 
			end	as code7,
			f7.description AS desc7,
			@lev_desc7 AS descliv7,
			SUBSTRING(f.printingorder, @startpos7, @lencod_lev7) as order7,

			upb.codeupb,
			upb.idupb as idupb,
			upb.title as upb,
			upb.printingorder as upbprintingorder,
	
			f.nlevel,
			isnull(sum(prevision_curr),0) as prevision_curr,
			@MAXoplevel AS minoplevel,
			isnull(#data.tosuppress, @suppressifblank) AS tosuppress	
		FROM sorting f
			JOIN sortinglevel fl
				ON f.nlevel = fl.nlevel AND fl.idsorkind = @idsorkindfin
		cross join  upb 
		left outer join #data on #data.idsor = f.idsor and #data.idupb=upb.idupb
		--FROM #data
		--join sorting f on #data.idsor = f.idsor
		--join  upb on  #data.idupb=upb.idupb
		--	JOIN sortinglevel fl
		--		ON f.nlevel = fl.nlevel AND fl.idsorkind = @idsorkindfin

		LEFT OUTER JOIN sortinglink flk1
			ON flk1.idchild = f.idsor AND flk1.nlevel = 1
		LEFT OUTER JOIN sorting f1
			ON flk1.idparent = f1.idsor  and f1.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk2
			ON flk2.idchild = f.idsor AND flk2.nlevel = 2
		LEFT OUTER JOIN sorting f2
			ON flk2.idparent = f2.idsor  and f2.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk3
			ON flk3.idchild = f.idsor AND flk3.nlevel = 3
		LEFT OUTER JOIN sorting f3
			ON flk3.idparent = f3.idsor  and f3.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk4
			ON flk4.idchild = f.idsor AND flk4.nlevel = 4
		LEFT OUTER JOIN sorting f4
			ON flk4.idparent = f4.idsor  and f4.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk5
			ON flk5.idchild = f.idsor AND flk5.nlevel = 5
		LEFT OUTER JOIN sorting f5
			ON flk5.idparent = f5.idsor  and f5.idsorkind = @idsorkindfin
		LEFT OUTER JOIN sortinglink flk6
			ON flk6.idchild = f.idsor AND flk6.nlevel = 6
		LEFT OUTER JOIN sorting f6
			ON flk6.idparent = f6.idsor  and f6.idsorkind = @idsorkindfin	
		LEFT OUTER JOIN sortinglink flk7
			ON flk6.idchild = f.idsor AND flk6.nlevel = 7
		LEFT OUTER JOIN sorting f7
			ON flk7.idparent = f7.idsor  and f7.idsorkind = @idsorkindfin	
		where  ( (@MostraTutteVoci = 'S'  or @suppressifblank='N') OR  (/*upb.idupb='0001' or */isnull(#data.tosuppress, 'S')='N')) and
				f.idsorkind = @idsorkindfin
				and f.sortcode like @Root
				AND (f.nlevel = @levelusable_original
					OR (f.nlevel < @levelusable_original
						and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = f.idsor)=0
						AND (fl.flag&2)<>0
					   )
					)
			   and upb.idupb like @idupb
			   AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			   AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			   AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			   AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			   AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)	
			   and upb.active = 'S'	
		GROUP BY F.idsor,f.sortcode, upb.printingorder,upb.idupb,upb.title,upb.codeupb,
			upb.idsor01,  upb.idsor02,  upb.idsor03, upb.idsor04, upb.idsor05,
			SUBSTRING(f.sortcode, @startpos1, @lencod_lev1),
			SUBSTRING(f.sortcode, @startpos2, @lencod_lev2),f2.sortcode,
			SUBSTRING(f.sortcode, @startpos3, @lencod_lev3),f3.sortcode,
			SUBSTRING(f.sortcode, @startpos4, @lencod_lev4),f4.sortcode,
			SUBSTRING(f.sortcode, @startpos5, @lencod_lev5),f5.sortcode,
			SUBSTRING(f.sortcode, @startpos6, @lencod_lev6),f6.sortcode,
			SUBSTRING(f.sortcode, @startpos7, @lencod_lev7),f7.sortcode,
			SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
			SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
			SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
			SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
			SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
			SUBSTRING(f.printingorder, @startpos6, @lencod_lev6),
			SUBSTRING(f.printingorder, @startpos7, @lencod_lev7),
			f1.description,f2.description,f3.description,f4.description,f5.description,f6.description,f.description,
			f7.description,f.printingorder,
			f.nlevel,isnull(#data.tosuppress, @suppressifblank)
		ORDER BY upb.printingorder ASC,
			f.printingorder ASC
	
	
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
		@sortingkind as 'sortingkind',
		f.idsor, 
		SUBSTRING(f.sortcode, @startpos1, @lencod_lev1) as code1,
		f1.description AS desc1,
		@lev_desc1 AS descliv1,
		SUBSTRING(f.printingorder, @startpos1, @lencod_lev1) as order1,
	
		CASE when (f2.sortcode is null) then null
			else SUBSTRING(f.sortcode, @startpos2, @lencod_lev2) 
		end	as code2,
		f2.description AS desc2,
		@lev_desc2 AS descliv2,
		SUBSTRING(f.printingorder, @startpos2, @lencod_lev2) as order2,
	
		case when (f3.sortcode is null) then null
			else SUBSTRING(f.sortcode, @startpos3, @lencod_lev3)
		end	 as code3,
		f3.description as desc3,
		@lev_desc3 as descliv3,
		SUBSTRING(f.printingorder, @startpos3, @lencod_lev3) as order3,
	
		case when (f4.sortcode is null) then null
			else	SUBSTRING(f.sortcode, @startpos4, @lencod_lev4)
		end	as code4,
		f4.description AS desc4,
		@lev_desc4 AS descliv4,
		SUBSTRING(f.printingorder, @startpos4, @lencod_lev4) as order4,
	
		case when (f5.sortcode is null) then null
			else SUBSTRING(f.sortcode, @startpos5, @lencod_lev5) 
		end	as code5,
		f5.description AS desc5,
		@lev_desc5 AS descliv5,
		SUBSTRING(f.printingorder, @startpos5, @lencod_lev5) as order5,
	
		case when (f6.sortcode is null) then null
			else SUBSTRING(f.sortcode, @startpos6, @lencod_lev6) 
		end	as code6,
		f6.description AS desc6,
		@lev_desc6 AS descliv6,
		SUBSTRING(f.printingorder, @startpos6, @lencod_lev6) as order6,

		case when (f7.sortcode is null) then null
			else SUBSTRING(f.sortcode, @startpos7, @lencod_lev7) 
		end	as code7,
		f7.description AS desc7,
		@lev_desc7 AS descliv7,
		SUBSTRING(f.printingorder, @startpos7, @lencod_lev7) as order7,

		@codeupb as codeupb,
		@ext_idupb as idupb,
		@upb as upb,
		@upbprintingorder as upbprintingorder,
		f.nlevel,
		isnull(sum(prevision_curr),0) as prevision_curr,
		@MAXoplevel AS minoplevel,
		isnull(#data.tosuppress, @suppressifblank) AS tosuppress	
	
				
	FROM sorting f
		JOIN sortinglevel fl
			ON f.nlevel = fl.nlevel AND  fl.idsorkind = @idsorkindfin
	left outer join #data on #data.idsor=f.idsor 
	LEFT OUTER JOIN sortinglink flk1
		ON flk1.idchild = f.idsor AND flk1.nlevel = 1
	LEFT OUTER JOIN sorting f1
		ON flk1.idparent = f1.idsor and f1.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk2
		ON flk2.idchild = f.idsor AND flk2.nlevel = 2
	LEFT OUTER JOIN sorting f2
		ON flk2.idparent = f2.idsor and f2.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk3
		ON flk3.idchild = f.idsor AND flk3.nlevel = 3
	LEFT OUTER JOIN sorting f3
		ON flk3.idparent = f3.idsor  and f3.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk4
		ON flk4.idchild = f.idsor AND flk4.nlevel = 4
	LEFT OUTER JOIN sorting f4
		ON flk4.idparent = f4.idsor  and f4.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk5
		ON flk5.idchild = f.idsor AND flk5.nlevel = 5
	LEFT OUTER JOIN sorting f5
		ON flk5.idparent = f5.idsor  and f5.idsorkind = @idsorkindfin
	LEFT OUTER JOIN sortinglink flk6
		ON flk6.idchild = f.idsor AND flk6.nlevel = 6
	LEFT OUTER JOIN sorting f6
		ON flk6.idparent = f6.idsor  and f6.idsorkind = @idsorkindfin	
	LEFT OUTER JOIN sortinglink flk7
			ON flk7.idchild = f.idsor AND flk7.nlevel = 7
	LEFT OUTER JOIN sorting f7
			ON flk7.idparent = f7.idsor  and f7.idsorkind = @idsorkindfin	
	where ((@MostraTutteVoci = 'S'  or @suppressifblank='N')  OR  (#data.idupb='0001' or isnull(#data.tosuppress, 'S')='N')) AND
			f.idsorkind = @idsorkindfin
			and f.sortcode like @Root
			--AND ((f.flag & 1)= @finpart_bit) 
			AND (f.nlevel = @levelusable_original
				OR (f.nlevel < @levelusable_original
					and (select count(*) from sorting S where S.idsorkind = @idsorkindfin and S.paridsor = f.idsor)=0
					AND (fl.flag&2)<>0
				   )
				)


  	GROUP BY F.idsor,f.sortcode,
		SUBSTRING(f.sortcode, @startpos1, @lencod_lev1),
		SUBSTRING(f.sortcode, @startpos2, @lencod_lev2),f2.sortcode,
		SUBSTRING(f.sortcode, @startpos3, @lencod_lev3),f3.sortcode,
		SUBSTRING(f.sortcode, @startpos4, @lencod_lev4),f4.sortcode,
		SUBSTRING(f.sortcode, @startpos5, @lencod_lev5),f5.sortcode,
		SUBSTRING(f.sortcode, @startpos6, @lencod_lev6),f6.sortcode,
		SUBSTRING(f.sortcode, @startpos7, @lencod_lev7),f7.sortcode,
		SUBSTRING(f.printingorder, @startpos1, @lencod_lev1),
		SUBSTRING(f.printingorder, @startpos2, @lencod_lev2),
		SUBSTRING(f.printingorder, @startpos3, @lencod_lev3),
		SUBSTRING(f.printingorder, @startpos4, @lencod_lev4),
		SUBSTRING(f.printingorder, @startpos5, @lencod_lev5),
		SUBSTRING(f.printingorder, @startpos6, @lencod_lev6),
		SUBSTRING(f.printingorder, @startpos7, @lencod_lev7),
		f1.description,f2.description,f3.description,f4.description,f.description,
		f5.description,f6.description,f7.description,f.printingorder,
		f.nlevel,isnull(#data.tosuppress, @suppressifblank)
	ORDER BY 
		f.printingorder ASC


END




END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 

 --exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 27, 3, '0001000300010022', 'S', 'N', 'N', NULL, NULL, NULL, NULL, NULL
  --exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 27, 3, '%', 'S', 'S', 'S', NULL, NULL, NULL, NULL, NULL
  -- exec rpt_bilprevisionesortingaccount_mpsiope_e 2018, 27, 3, '0001', 'S', 'S', 'S', NULL, NULL, NULL, NULL, NULL

   
