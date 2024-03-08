
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_bilprevisioneriep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_bilprevisioneriep]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure rpt_unified_bilprevisioneriep
	@ayear 		int,
	@finpart 	char(1),
	@levelusable 	tinyint,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
as begin
	create table #bilprevisioneriep (
		idfin			int, 
		code1			varchar(50),
		desc1			varchar(150),
		printorder1 		varchar(50),
		codeupb			varchar(50)	,
		idupb 			varchar(36)	,
		upb   			varchar(150)	,
		upbprintingorder	varchar(50)	,
		prevision		decimal(19,2)	,
		previousprevision	decimal(19,2)	,
		secondaryprevision	decimal(19,2)	,
		previoussecprevision	decimal(19,2)	,
		currentarrears		decimal(19,2)	,
		previousarrears		decimal(19,2)	,
		accretion_var		decimal(19,2)	,
		diminution_var		decimal(19,2)	,
		sec_accretion_var	decimal(19,2)	,
		sec_diminution_var	decimal(19,2)	,
		rep_accretion_var	decimal(19,2)	,
		rep_diminution_var	decimal(19,2)	,
		previsionkind		char,
		display_aa		varchar(50),
		supposed_ff		decimal(19,2),
		supposed_aa		decimal(19,2),
		supposed_ff_prec	decimal(19,2),
		supposed_aa_prec	decimal(19,2)
	)
	
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set @crsdepartment = cursor for select  iddbdepartment from dbdepartment
							 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open @crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		set @s = @iddbdepartment + '.rpt_bilprevisione_riep'
		insert into #bilprevisioneriep
			(idfin, code1, desc1, printorder1, 
			codeupb, idupb,	upb, upbprintingorder,
			prevision, previousprevision, secondaryprevision, previoussecprevision,
			currentarrears,	previousarrears, 
			accretion_var, diminution_var, sec_accretion_var, sec_diminution_var,
			rep_accretion_var, rep_diminution_var,
			previsionkind, display_aa,
			supposed_ff, supposed_aa,
			supposed_ff_prec, supposed_aa_prec)
			exec @s @ayear, @finpart, @levelusable, '%', 'N', 'N', @idsor01, @idsor02 , @idsor03 , @idsor04 , @idsor05
		fetch next from @crsdepartment into @iddbdepartment
	end
	select * from #bilprevisioneriep
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

