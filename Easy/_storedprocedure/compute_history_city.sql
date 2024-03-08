
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_history_city]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_history_city]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE                                         PROCEDURE [compute_history_city]
	@idcity int,
	@flagusable char(1)
AS BEGIN
 create table #next (keyfield int, idcity int)
 insert into #next values(0, @idcity)
 declare @examinedCounter int
 Set @examinedCounter = 0
 declare @insertedCounter int
 set @insertedCounter = 1
 while @examinedCounter < @insertedCounter
  begin
	select @idcity = idcity from #next where keyfield = @examinedCounter
	declare @newcity int
	
	select @newcity=newcity from geo_city where idcity=@idcity
	if @newcity is not null and (select count(*) from #next where idcity=@newcity)=0
	 begin
		insert into #next values (@insertedCounter, @newcity)
		set @insertedCounter = @insertedCounter + 1
	 end
	
	declare @cursore cursor
	set @cursore=cursor for select idcity from geo_city where oldcity=@idcity
	open @cursore
	fetch next from @cursore into @newcity
	while @@fetch_status=0 begin
		if @newcity is not null and (select count(*) from #next where idcity=@newcity)=0  begin
			insert into #next values (@insertedCounter, @newcity)
			set @insertedCounter = @insertedCounter + 1
		end
		fetch next from @cursore into @newcity
	end
	close @cursore
	set @examinedCounter = @examinedCounter + 1
 end
	
 if (UPPER(@flagusable)='S')
  BEGIN
	select s.idcity, c.title, c.provincecode
	from #next s inner join geo_cityview c on s.idcity=c.idcity
	INNER JOIN geo_cityusable g on s.idcity = g.idcity
	order by s.idcity, s.keyfield
  END
 ELSE
  BEGIN
	select s.idcity, c.title, c.provincecode
	from #next s inner join geo_cityview c on s.idcity=c.idcity
	order by s.idcity, s.keyfield
  END
end


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

