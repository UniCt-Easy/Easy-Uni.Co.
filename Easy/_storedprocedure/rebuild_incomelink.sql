
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_incomelink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_incomelink]
GO

CREATE PROCEDURE rebuild_incomelink
AS BEGIN
	DELETE FROM incomelink

	--1 con 1
	INSERT INTO incomelink (idchild, nlevel, idparent) 	SELECT idinc, 1, idinc 	FROM income where nphase=1

	declare @currlev int
	declare @maxlev int 
	select @maxlev= max(nphase) from incomephase
	set @currlev=2

	while (@currlev <= @maxlev) 
	BEGIN
		print @currlev
		
		-- @currlev con 1..@currlev-1
		insert into incomelink (idchild, nlevel, idparent)  
			SELECT E.idinc , EL.nlevel,  EL.idparent	FROM income E
			join incomelink EL on EL.idchild=  E.parentidinc
			where E.nphase= @currlev
		
		-- @currlev con @currlev
		INSERT INTO incomelink (idchild, nlevel, idparent) 	
			SELECT idinc, @currlev, idinc 	FROM income where nphase=@currlev

		set @currlev= @currlev+1
	END

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--rebuild_incomelink

