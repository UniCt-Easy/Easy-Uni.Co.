
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_registroiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_registroiva]
GO
 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  procedure rpt_unified_registroiva (	
	@idivaregisterkind varchar(20),
	@year int,
	@month int,
	@official char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
) as begin
	create table #ivaregister (
		iddbdepartment varchar(50),
		department varchar(50),	
		ivaregisterdescr varchar(50),
		monthname varchar(20),
		ayear int ,
		nivaregister int,
		flagdeferred char,
		registrationdate smalldatetime,
		idinvkinddescr varchar(50),
		doc varchar(35),
		docdate smalldatetime,
		registry varchar(100),
		idcurrency varchar(20),
		exchangerate float(8),
		total dec(19,2),
		taxabletotal dec(19,2),
		ivagross dec(19,2),
		ivaabatable dec(19,2),
		ivaunabatable dec(19,2),
		idivakind varchar(50),
		unifiedivaregisterkind varchar(50),
		unifiedninv int
	)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		set @s = @iddbdepartment + '.rpt_registroiva'
		insert into #ivaregister 
			(ivaregisterdescr, monthname, ayear, nivaregister,
			flagdeferred, registrationdate, idinvkinddescr,
			doc, docdate, registry, idcurrency, exchangerate,
			total, taxabletotal, ivagross, ivaabatable, ivaunabatable, idivakind,
			unifiedivaregisterkind, unifiedninv)
			exec @s @idivaregisterkind, @year, @month, @official,
	        @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
		update #ivaregister set iddbdepartment = @iddbdepartment WHERE iddbdepartment is null
		fetch next from @crsdepartment into @iddbdepartment
	end
	update #ivaregister set department=description 
		from dbdepartment 
		where dbdepartment.iddbdepartment=#ivaregister.iddbdepartment
	select * from #ivaregister
end


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
