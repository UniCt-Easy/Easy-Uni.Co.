
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_history_nation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_history_nation]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                                       PROCEDURE [compute_history_nation]
	@idnation int,
	@flagusable char(1)
as begin
	create table #next (keyfield int, idnation int)
	insert into #next values(0, @idnation)
	declare @examinedCounter int
	set @examinedCounter = 0
	declare @insertedCounter int
	set @insertedCounter = 1
	while @examinedCounter < @insertedCounter begin
		select @idnation=idnation from #next where keyfield=@examinedCounter
	
		declare @newnation int
	
		select @newnation=newnation from geo_nation where idnation=@idnation
		if @newnation is not null and (select count(*) from #next where idnation=@newnation)=0  begin
			insert into #next values (@insertedCounter, @newnation)
			set @insertedCounter = @insertedCounter + 1
		end
	
		declare @cursore cursor
		set @cursore=cursor for select idnation from geo_nation where oldnation=@idnation
		open @cursore
		fetch next from @cursore into @newnation
		while @@fetch_status=0 begin
			if @newnation is not null and (select count(*) from #next where idnation=@newnation)=0  begin
				insert into #next values (@insertedCounter, @newnation)
				set @insertedCounter = @insertedCounter + 1
			end
			fetch next from @cursore into @newnation
		end
		close @cursore
		set @examinedCounter = @examinedCounter + 1
	end
	
	if (UPPER(@flagusable)='S') BEGIN
		select s.idnation, c.title, c.start, c.stop
		from #next s inner join geo_nation c on s.idnation=c.idnation
		INNER JOIN geo_nationusable g on s.idnation = g.idnation
		order by s.keyfield
	END
	ELSE BEGIN
		select s.idnation, c.title, c.start, c.stop
		from #next s inner join geo_nation c on s.idnation=c.idnation
		order by s.keyfield
	END
end



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

