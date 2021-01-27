
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_sortingexpensetotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_sortingexpensetotal]
GO

/*
CREATE PROCEDURE [rebuild_sortingexpensetotal]
(
	@ayear int = null
)
AS BEGIN

	if (@ayear is null) 
	BEGIN
		DELETE FROM sortingexpensetotal

		INSERT INTO sortingexpensetotal
		(
			idsorkind,
			idsor,
			idacc,
			total
		)
		SELECT epexpsorting.idsorkind, epexpsorting.idsor, epexpsorting.idacc, 
		ISNULL(SUM(epexpsorting.amount),0)
		FROM epexpsorting
		LEFT OUTER JOIN account A
		ON epexpsorting.idacc LIKE A.idacc + '%'
		GROUP BY epexpsorting.idsorkind, epexpsorting.idsor, epexpsorting.idacc



	END
	ELSE
	BEGIN
		DELETE FROM sortingexpensetotal WHERE idacc LIKE
				substring(convert(varchar,@ayear,4),3,2)+'%'
		INSERT INTO sortingexpensetotal 
		(
			idsorkind,
			idsor,
			idacc,
			total
		)
		SELECT epexpsorting.idsorkind, epexpsorting.idsor, epexpsorting.idacc, 
		ISNULL(SUM(epexpsorting.amount),0)
		FROM epexpsorting
		LEFT OUTER JOIN account A
		ON epexpsorting.idacc LIKE A.idacc + '%'
		WHERE A.ayear = @ayear
		AND epexpsorting.idacc LIKE A.idacc + '%'
		GROUP BY epexpsorting.idsorkind, epexpsorting.idsor, epexpsorting.idacc
	END	

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

*/
