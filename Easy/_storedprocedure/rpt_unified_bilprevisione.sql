
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_bilprevisione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_bilprevisione]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  procedure rpt_unified_bilprevisione(
	@ayear 				int,
	@finpart 			char(1),
	@levelusable 		tinyint,
	@suppressifblank 	char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) as begin
	create table #bilprevisione (
		idfin int,
		code1 varchar(50), desc1 varchar(150), descliv1 varchar(50), printorder1 varchar(50), 
		code2 varchar(50), desc2 varchar(150), descliv2 varchar(50), printorder2 varchar(50), 
		code3 varchar(50), desc3 varchar(150), descliv3 varchar(50), printorder3 varchar(50),
		code4 varchar(50), desc4 varchar(150), descliv4 varchar(50), printorder4 varchar(50),
		code5 varchar(50), desc5 varchar(150), descliv5 varchar(50), printorder5 varchar(50),
		code6 varchar(50), desc6 varchar(150), descliv6 varchar(50), printorder6 varchar(50),
		codeupb			varchar(50),
		idupb 			varchar(36),
		upb   			varchar(100),
		upbprintingorder	varchar(50),
		nlevel char,
		prevision		decimal(19,2),
		previousprevision	decimal(19,2),
		secondaryprev		decimal(19,2),
		previoussecondaryprev	decimal(19,2),
		currentarrears		decimal(19,2),
		previousarrears		decimal(19,2),
		minlevelusable char,
		tosuppress char,
		previsionkind char,
		supposed_ff		decimal(19,2),
		supposed_aa		decimal(19,2),
		supposed_ff_prec	decimal(19,2),
		supposed_aa_prec	decimal(19,2)
	)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
					 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		set @s = @iddbdepartment + '.rpt_bilprevisione'
		insert into #bilprevisione 
			(idfin,
			code1, desc1, descliv1, printorder1,
			code2, desc2, descliv2, printorder2,
			code3, desc3, descliv3, printorder3,
			code4, desc4, descliv4, printorder4,
			code5, desc5, descliv5, printorder5,
			code6, desc6, descliv6, printorder6,
			codeupb, idupb,	upb, upbprintingorder, nlevel,
			prevision, previousprevision, secondaryprev, 
			previoussecondaryprev, currentarrears, previousarrears,
			minlevelusable, tosuppress,
			previsionkind, supposed_ff, supposed_aa, supposed_ff_prec, supposed_aa_prec
			)
			exec @s @ayear, @finpart, @levelusable, '%', 'N', 'N', @suppressifblank, @idsor01 , @idsor02 , @idsor03 , @idsor04 , @idsor05
		fetch next from @crsdepartment into @iddbdepartment
	end
	select 
		idfin,
		code1, desc1, descliv1, printorder1, 
		code2, desc2, descliv2, printorder2, 
		code3, desc3, descliv3, printorder3,
		code4, desc4, descliv4, printorder4,
		code5, desc5, descliv5, printorder5,
		code6, desc6, descliv6, printorder6,
		null 				'codeupb',
		null   				'idupb',
		null   				'upb',
		null   				'upbprintingorder',
		nlevel,
		sum(prevision)  		'prevision',
		sum(previousprevision)  	'previousprevision',
		sum(secondaryprev)  		'secondaryprev',
		sum(previoussecondaryprev)  	'previoussecondaryprev',
		sum(currentarrears)  		'currentarrears',
		sum(previousarrears)  		'previousarrears',
		minlevelusable,
		tosuppress,
		previsionkind,
		sum(supposed_ff)  		'supposed_ff',
		sum(supposed_aa)  		'supposed_aa',
		sum(supposed_ff_prec)  		'supposed_ff_prec',
		sum(supposed_aa_prec)  		'supposed_aa_prec'
	from #bilprevisione
	group by idfin, nlevel, minlevelusable, tosuppress, previsionkind,
		code1, desc1, descliv1, printorder1, 
		code2, desc2, descliv2, printorder2, 
		code3, desc3, descliv3, printorder3,
		code4, desc4, descliv4, printorder4,
		code5, desc5, descliv5, printorder5,
		code6, desc6, descliv6, printorder6

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
