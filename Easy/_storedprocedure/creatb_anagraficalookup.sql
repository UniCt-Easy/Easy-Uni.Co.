
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


if exists (select * from dbo.sysobjects where id = object_id(N'[creatb_anagraficalookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [creatb_anagraficalookup]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [creatb_anagraficalookup]

AS BEGIN

delete from anagraficalookup

create table #anagrafiche(tempid int identity(1,1) ,	denominazione varchar(100))

insert into #anagrafiche(	denominazione)
select DISTINCT ltrim(rtrim(COGNNOME)) from GIORNALE
where ( COGNNOME is not null and COGNNOME <>'' )
order by ltrim(rtrim(COGNNOME))
insert into anagraficalookup(denominazione, newidreg)
select denominazione, tempid FROM #anagrafiche A

drop table #anagrafiche

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/*
	exec creatb_anagraficalookup
	go
	select * from anagraficalookup

*/
