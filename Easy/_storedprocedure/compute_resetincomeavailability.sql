
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

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resetincomeavailability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resetincomeavailability]
GO

CREATE          PROCEDURE compute_resetincomeavailability
(
	@ayear int,
	@idinc int
)
AS BEGIN

declare @nlevel tinyint
select @nlevel = nphase from income where idinc = @idinc 

CREATE TABLE #toreset (idinc int,nphase tinyint, amount decimal(19,2))
INSERT INTO #toreset (idinc,nphase,amount)
SELECT idparent,nlevel,0
FROM incomelink
WHERE idchild = @idinc and nlevel<@nlevel


UPDATE #toreset SET amount = 
		(SELECT - SUM (ET.available) 
		FROM incometotal ET
		JOIN incomelink EL
		ON EL.idparent = ET.idinc
		WHERE EL.idchild = @idinc  AND ET.ayear = @ayear AND EL.nlevel>=#toreset.nphase AND EL.idparent<>@idinc)


SELECT 
	#toreset.nphase ,
	incomephase.description as phase,
      	#toreset.idinc,
      	I.ymov,
	I.nmov,
	'Minore entrata' AS description,
	#toreset.amount
FROM #toreset 
LEFT OUTER JOIN income I
	ON #toreset.idinc = I.idinc 
LEFT OUTER JOIN incomephase
	ON #toreset.nphase = incomephase.nphase

ORDER BY #toreset.nphase
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

