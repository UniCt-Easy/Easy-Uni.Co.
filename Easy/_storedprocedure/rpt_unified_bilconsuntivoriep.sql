
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_bilconsuntivoriep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_bilconsuntivoriep]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure rpt_unified_bilconsuntivoriep
(
	@ayear int,
	@date datetime,
	@finpart char(1),
	@levelusable tinyint,
	@officialvar char(1),
	@suppressifblank char(1)
) as begin
	DECLARE @idupb varchar(36)
	SET @idupb = '0001' -- non deve filtrare su UPB

	-- lettura del livello di bilancio consolidato
	DECLARE @unifiedlevel tinyint

	SELECT @unifiedlevel = MIN(unifiedfinlevel) FROM commonconfig WHERE ayear = @ayear

	IF(@levelusable > @unifiedlevel)
	BEGIN
		SET @levelusable = @unifiedlevel
	END

	create table #bilconsuntivoriep (
		idfin int,
		code1 varchar(50),
		desc1 varchar(150),
		order1 varchar(50),
		codeupb varchar(50),
		idupb varchar(36),
		upb varchar(150),
		upbprintingorder varchar(50),
		initialprevision decimal(19,2),
		variation decimal(19,2),
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
		supposed_ff_jan01 decimal(19,2),
		supposed_aa_jan01 decimal(19,2),
		ff_jan01 decimal(19,2),
		aa_jan01 decimal(19,2),
		floatfund_01_jan_used decimal(19,2),
		supposed_aa_01_jan_used decimal(19,2),
		aa_01_jan_used decimal(19,2),
		supposed_ff_01_jan_used decimal(19,2),
		flagadvance char(1)
	)

	create table #department_result (
		idfin int,
		code1 varchar(50),
		desc1 varchar(150),
		order1 varchar(50),
		codeupb varchar(50),
		idupb varchar(36),
		upb varchar(150),
		upbprintingorder varchar(50),
		initialprevision decimal(19,2),
		variation decimal(19,2),
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
		supposed_ff_jan01 decimal(19,2),
		supposed_aa_jan01 decimal(19,2),
		ff_jan01 decimal(19,2),
		aa_jan01 decimal(19,2),
		floatfund_01_jan_used decimal(19,2),
		supposed_aa_01_jan_used decimal(19,2),
		aa_01_jan_used decimal(19,2),
		supposed_ff_01_jan_used decimal(19,2),
		flagadvance char(1)
	)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set @crsdepartment = cursor for select  iddbdepartment from dbdepartment
						 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open @crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		delete from #department_result
		declare @s varchar(300)
		set @s = @iddbdepartment + '.rpt_bilconsuntivo_riep'
		insert into #department_result 
			(idfin,	code1, desc1, order1,
			codeupb, idupb,	upb, upbprintingorder,
			initialprevision, variation, secondaryprevision, secondaryvariation,
			currentarrears,
			mov_finphase_C, var_finphase_C, mov_maxphase_C,	var_maxphase_C,
			mov_finphase_R,	var_finphase_R,	mov_maxphase_R,	var_maxphase_R,
			supposed_ff_jan01, supposed_aa_jan01,
			ff_jan01, aa_jan01,
			floatfund_01_jan_used, supposed_aa_01_jan_used,
			aa_01_jan_used,supposed_ff_01_jan_used,flagadvance)
			exec @s @ayear, @date, @finpart, @levelusable, @idupb, 'N', 'S',@officialvar, @suppressifblank
			
			insert into #bilconsuntivoriep
			(idfin,	code1, desc1, order1,
			codeupb, idupb,	upb, upbprintingorder,
			initialprevision, variation, secondaryprevision, secondaryvariation,
			currentarrears,
			mov_finphase_C, var_finphase_C, mov_maxphase_C,	var_maxphase_C,
			mov_finphase_R,	var_finphase_R,	mov_maxphase_R,	var_maxphase_R,
			supposed_ff_jan01, supposed_aa_jan01,
			ff_jan01, aa_jan01,
			floatfund_01_jan_used, supposed_aa_01_jan_used,
			aa_01_jan_used,supposed_ff_01_jan_used,flagadvance)

			select 
			idfin,	code1, desc1, order1,
			codeupb, idupb,	upb, upbprintingorder,
			sum(initialprevision), sum(variation), sum(secondaryprevision), sum(secondaryvariation),
			sum(currentarrears),
			sum(mov_finphase_C), sum(var_finphase_C), sum(mov_maxphase_C), sum(var_maxphase_C),
			sum(mov_finphase_R), sum(var_finphase_R),sum(mov_maxphase_R),sum(var_maxphase_R),
			isnull(supposed_ff_jan01,0), isnull(supposed_aa_jan01,0),
			isnull(ff_jan01,0), isnull(aa_jan01,0),
			isnull(floatfund_01_jan_used,0), isnull(supposed_aa_01_jan_used,0),
			isnull(aa_01_jan_used,0),isnull(supposed_ff_01_jan_used,0),flagadvance
			from #department_result
			group by idfin,
			codeupb, idupb,	upb, upbprintingorder,
			code1, desc1, order1, isnull(supposed_ff_jan01,0), isnull(supposed_aa_jan01,0),
			isnull(ff_jan01,0), isnull(aa_jan01,0),
			isnull(floatfund_01_jan_used,0), isnull(supposed_aa_01_jan_used,0),
			isnull(aa_01_jan_used,0),isnull(supposed_ff_01_jan_used,0),flagadvance
			

			fetch next from @crsdepartment into @iddbdepartment
	end
	select 
			1 as idfin,	code1, desc1, order1,
			null as codeupb, null as idupb, null as upb, null as upbprintingorder,
			sum(initialprevision) as initialprevision, 
			sum(variation) as variation, 
			sum(secondaryprevision) as secondaryprevision, 
			sum(secondaryvariation) as secondaryvariation,
			sum(currentarrears) as currentarrears,
			sum(mov_finphase_C) as mov_finphase_C, 
			sum(var_finphase_C) as var_finphase_C, 
			sum(mov_maxphase_C) as mov_maxphase_C,	
			sum(var_maxphase_C) as var_maxphase_C,
			sum(mov_finphase_R) as mov_finphase_R,	
			sum(var_finphase_R) as var_finphase_R,	
			sum(mov_maxphase_R) as mov_maxphase_R,	
			sum(var_maxphase_R) as var_maxphase_R,
			sum(supposed_ff_jan01) as supposed_ff_jan01, 
			sum(supposed_aa_jan01) as supposed_aa_jan01,
			sum(ff_jan01) as ff_jan01, 
			sum(aa_jan01) as aa_jan01,
			sum(floatfund_01_jan_used) as floatfund_01_jan_used, 
			sum(supposed_aa_01_jan_used) as supposed_aa_01_jan_used,
			sum(aa_01_jan_used) as aa_01_jan_used,
			sum(supposed_ff_01_jan_used) as  supposed_ff_01_jan_used,flagadvance
	from #bilconsuntivoriep
	group by 
	code1, desc1, order1,flagadvance
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

