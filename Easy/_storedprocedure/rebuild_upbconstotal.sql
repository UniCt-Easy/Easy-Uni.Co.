
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_upbconstotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_upbconstotal]
GO

CREATE     PROCEDURE [rebuild_upbconstotal]
(
	@ayear int = null
)
AS BEGIN

--setuser 'amm'

IF (@ayear IS NULL) 
BEGIN
	DELETE FROM upbconstotal

	insert into upbconstotal (idfin,idupb,totprev,totprev_inserted)
	select UT.idfin,u.idupb, 
				isnull(sum(currentprev),0)+isnull(sum(previsionvariation),0),
				isnull(sum(currentprev),0)+isnull(sum(previsionvariation_inserted),0)
	from upbtotal ut
		join upb u on ut.idupb like u.idupb+'%' 
	group by UT.idfin,u.idupb
END
ELSE -- @ayear specificato
BEGIN 
	DELETE FROM upbconstotal 
		WHERE EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = upbconstotal.idfin
					 AND fin.ayear = @ayear)

	insert into upbconstotal (idfin,idupb,totprev,totprev_inserted)
	select UT.idfin,u.idupb, 
				isnull(sum(currentprev),0)+isnull(sum(previsionvariation),0),
				isnull(sum(currentprev),0)+isnull(sum(previsionvariation_inserted),0)
	from upbtotal ut
		join upb u on ut.idupb like u.idupb+'%' 
		join fin f on ut.idfin = f.idfin and f.ayear =@ayear
	group by UT.idfin,u.idupb
END
	
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

