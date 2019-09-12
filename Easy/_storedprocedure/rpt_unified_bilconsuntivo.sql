if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_bilconsuntivo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_bilconsuntivo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure rpt_unified_bilconsuntivo
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@suppressifblank char(1),
	@officialvar  char(1)
) as begin
	DECLARE @idupb varchar(36)
	SET @idupb = '%' -- non deve filtrare su UPB

	-- lettura del livello di bilancio consolidato
	DECLARE @unifiedlevel tinyint

	SELECT @unifiedlevel = MIN(unifiedfinlevel) FROM commonconfig WHERE ayear = @ayear 

	IF(@levelusable > @unifiedlevel)
	BEGIN
		SET @levelusable = @unifiedlevel
	END

	create table #bilconsuntivo (
		code1 varchar(50), desc1 varchar(150), descliv1 varchar(50), order1 varchar(50), 
		code2 varchar(50), desc2 varchar(150), descliv2 varchar(50), order2 varchar(50), 
		code3 varchar(50), desc3 varchar(150), descliv3 varchar(50), order3 varchar(50),
		code4 varchar(50), desc4 varchar(150), descliv4 varchar(50), order4 varchar(50),
		code5 varchar(50), desc5 varchar(150), descliv5 varchar(50), order5 varchar(50),
		codeupb			varchar(50),
		idupb 			varchar(36),
		upb   			varchar(150),
		upbprintingorder	varchar(50),
		initialprevision	decimal(19,2),
		variation	decimal(19,2),
		secondaryprevision decimal(19,2),
		secondaryvariation decimal(19,2),
		currentarrears decimal(19,2),
		mov_finphase_C decimal(19,2),
		var_finphase_C decimal(19,2),
		mov_maxphase_C decimal(19,2),
		var_maxphase_C decimal(19,2),
		mov_finphase_R decimal(19,2),
		var_finphase_R decimal(19,2),
		mov_maxphase_R decimal(19,2),
		var_maxphase_R decimal(19,2),
		previsionkind char(1),
		showincomesurplus char(1),
		flagadvance char(1),
		supposed_ff_jan01 decimal(19,2),
		supposed_aa_jan01 decimal(19,2),
		ff_jan01 decimal(19,2),
		aa_jan01 decimal(19,2),
		tosuppress char,
		nlevel tinyint,
		floatfund_01_jan_used decimal(19,2),
		supposed_aa_01_jan_used decimal(19,2),
		aa_01_jan_used decimal(19,2),
		supposed_ff_01_jan_used decimal(19,2)
	)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set @crsdepartment = cursor for select  iddbdepartment from dbdepartment
						 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open @crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(400)
		set @s = @iddbdepartment + '.rpt_bilconsuntivo'
		insert into #bilconsuntivo 
			(
			code1, desc1, descliv1, order1, 
			code2, desc2, descliv2, order2, 
			code3, desc3, descliv3, order3,
			code4, desc4, descliv4, order4,
			code5, desc5, descliv5, order5,
			codeupb, idupb,	upb, upbprintingorder,
			initialprevision, variation,
			secondaryprevision, secondaryvariation,
			currentarrears,
			mov_finphase_C,	var_finphase_C,	mov_maxphase_C,
			var_maxphase_C,	mov_finphase_R,	var_finphase_R,	mov_maxphase_R,	var_maxphase_R,
			previsionkind, showincomesurplus, flagadvance,supposed_ff_jan01, supposed_aa_jan01,
			ff_jan01, aa_jan01, tosuppress,	nlevel,
			floatfund_01_jan_used, supposed_aa_01_jan_used,
			aa_01_jan_used,supposed_ff_01_jan_used
			)
			exec @s @ayear,	@date, @finpart, @levelusable, @idupb, 'N', 'S', @suppressifblank, @officialvar
		fetch next from @crsdepartment into @iddbdepartment
	end
	select 
		code1, desc1, descliv1, order1, 
		code2, desc2, descliv2, order2, 
		code3, desc3, descliv3, order3,
		code4, desc4, descliv4, order4,
		code5, desc5, descliv5, order5,
		null as codeupb, null as idupb,	null as upb, null as upbprintingorder,
		sum(initialprevision) as initialprevision, sum(variation) as variation,
		sum(secondaryprevision) as secondaryprevision, sum(secondaryvariation) as secondaryvariation,
		sum(currentarrears) as currentarrears,
		sum(mov_finphase_C) as mov_finphase_C, sum(var_finphase_C) as var_finphase_C, 
		sum(mov_maxphase_C) as mov_maxphase_C,
		sum(var_maxphase_C) as var_maxphase_C , sum(mov_finphase_R) as mov_finphase_R,
		sum(var_finphase_R) as var_finphase_R, sum(mov_maxphase_R) as mov_maxphase_R, 
		sum(var_maxphase_R) as var_maxphase_R,
		previsionkind, showincomesurplus, flagadvance,
		sum(supposed_ff_jan01) as supposed_ff_jan01, sum(supposed_aa_jan01) as supposed_aa_jan01,
		sum(ff_jan01) as ff_jan01, sum(aa_jan01) as aa_jan01, 
		tosuppress, nlevel,
		sum(floatfund_01_jan_used) as floatfund_01_jan_used,
		sum(supposed_aa_01_jan_used) as supposed_aa_01_jan_used,
		sum(aa_01_jan_used) as aa_01_jan_used,
		sum(supposed_ff_01_jan_used) as supposed_ff_01_jan_used
		from #bilconsuntivo
		group by
		code1, desc1, descliv1, order1, 
		code2, desc2, descliv2, order2, 
		code3, desc3, descliv3, order3,
		code4, desc4, descliv4, order4,
		code5, desc5, descliv5, order5,
		previsionkind, showincomesurplus, flagadvance,
		tosuppress, nlevel
end		




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO