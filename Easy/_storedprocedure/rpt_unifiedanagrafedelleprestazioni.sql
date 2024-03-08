
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unifiedanagrafedelleprestazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unifiedanagrafedelleprestazioni]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'

CREATE   PROCEDURE  [rpt_unifiedanagrafedelleprestazioni]
(
	@ayear smallint, 
	@idreg int, 
	@start datetime,
	@stop datetime,
	@show_addr_anagp char(1),
	@unified char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

IF (@unified <> 'S')
BEGIN

        EXEC rpt_anagrafedelleprestazioni @ayear, @idreg, @start, @stop, @show_addr_anagp,@idsor01,@idsor02,@idsor03,@idsor04,	@idsor05  
        RETURN
END 

CREATE TABLE #outtable(
		departmentname varchar(150),
		transmissiondate datetime,
		idexp int,
		idreg int,
		registry varchar(100),
		b_city varchar(120),
		birthdate datetime,
		b_province varchar(2),
		b_nation varchar(65),
		cf varchar(16),
		taxref varchar(20), 
		description varchar(50),
		service varchar(50),
		codeser varchar(20),
		upb varchar(150),
		fin varchar(150),
		codefin varchar(50),
		npay int,
		manager varchar(150),
		taxablenet decimal(19,2),
		grossamount decimal(19,2),
		employtax decimal(19,2),
		sent_office varchar(50),
		sent_agency varchar(50),
		sent_address varchar(100),
		sent_idaddresskind varchar(20), 
		sent_location varchar(120),
		sent_cap varchar(20),
		sent_province varchar(2),
		sent_nation varchar(65),
		residence_address varchar(100),
		residence_idaddresskind varchar(20),
		residence_location varchar(120),
		residence_cap varchar(20),
		residence_province varchar(2),
		residence_nation varchar(65),
		descriptioncontract varchar(150),
		start datetime,
		stop datetime,
		authdoc	varchar(35),
		authdocdate	datetime,
		authneeded	char(1),
		noauthreason varchar(1000)
)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.rpt_anagrafedelleprestazioni'
		print @dip_nomesp
		insert into #outtable 
			(
			departmentname,
			idexp ,
			transmissiondate,
			idreg ,
			registry,
			b_city,
			birthdate,
			b_province,
			b_nation,
			cf,
			taxref, 
			description,
			service,
			codeser,
			upb,
			fin,
			codefin,
			npay,
			manager,
			taxablenet,
			grossamount,
			employtax,
			sent_office,
			sent_agency,
			sent_address,
			sent_idaddresskind, 
			sent_location,
			sent_cap,
			sent_province,
			sent_nation,
			residence_address,
			residence_idaddresskind,
			residence_location,
			residence_cap,
			residence_province,
			residence_nation,
			descriptioncontract,
			start,
			stop,
			authdoc,
			authdocdate,
			authneeded,
			noauthreason
			)

			exec @dip_nomesp @ayear, @idreg, @start, @stop, @show_addr_anagp,@idsor01,@idsor02,	@idsor03,@idsor04,	@idsor05  
			
				fetch next from @crsdepartment into @iddbdepartment
	END

	
SELECT  	
			departmentname,
			transmissiondate,
			idexp ,
			idreg ,
			registry,
			b_city,
			birthdate,
			b_province,
			b_nation,
			cf,
			taxref, 
			description,
			service,
			codeser,
			upb,
			fin,
			codefin,
			npay,
			manager,
			taxablenet,
			grossamount,
			employtax,
			sent_office,
			sent_agency,
			sent_address,
			sent_idaddresskind, 
			sent_location,
			sent_cap,
			sent_province,
			sent_nation,
			residence_address,
			residence_idaddresskind,
			residence_location,
			residence_cap,
			residence_province,
			residence_nation,
			descriptioncontract,
			start,
			stop,
			authdoc,
			authdocdate,
			authneeded,
			noauthreason
FROM #outtable
ORDER BY registry, departmentname











END

