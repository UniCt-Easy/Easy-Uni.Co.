
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_finlink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_finlink]
GO

CREATE  PROCEDURE rebuild_finlink 
(
	@ayear int = null
)
AS BEGIN

	declare @currlev int
	declare @maxlev int 


IF (@ayear IS NULL)
BEGIN
	DELETE FROM finlink WHERE idchild in (SELECT idfin from fin)

	--1 con 1
	INSERT INTO finlink (idchild, nlevel, idparent) 	SELECT idfin, 1, idfin 	FROM fin where nlevel=1 

	select @maxlev= max(nlevel) from finlevel
	set @currlev=2

	while (@currlev <= @maxlev) 
	BEGIN
		print @currlev
		
		-- @currlev con 1..@currlev-1
		insert into finlink (idchild, nlevel, idparent)  
			SELECT E.idfin , EL.nlevel,  EL.idparent	FROM fin  E
			join finlink EL on EL.idchild=  E.paridfin
			where E.nlevel= @currlev 
		
		-- @currlev con @currlev
		INSERT INTO finlink (idchild, nlevel, idparent) 	
			SELECT idfin, @currlev, idfin 	FROM fin where nlevel=@currlev  

		set @currlev= @currlev+1
	END
END
ELSE
BEGIN
	DELETE FROM finlink WHERE idchild in (SELECT idfin from fin where ayear=@ayear)

	--1 con 1
	INSERT INTO finlink (idchild, nlevel, idparent) 	SELECT idfin, 1, idfin 	FROM fin where nlevel=1 and  ayear=@ayear

	select @maxlev= max(nlevel) from finlevel
	set @currlev=2

	while (@currlev <= @maxlev) 
	BEGIN
		print @currlev
		
		-- @currlev con 1..@currlev-1
		insert into finlink (idchild, nlevel, idparent)  
			SELECT E.idfin , EL.nlevel,  EL.idparent	FROM fin  E
			join finlink EL on EL.idchild=  E.paridfin
			where E.nlevel= @currlev and E.ayear=@ayear
		
		-- @currlev con @currlev
		INSERT INTO finlink (idchild, nlevel, idparent) 	
			SELECT idfin, @currlev, idfin 	FROM fin where nlevel=@currlev  and  ayear=@ayear

		set @currlev= @currlev+1
	END

END



END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

