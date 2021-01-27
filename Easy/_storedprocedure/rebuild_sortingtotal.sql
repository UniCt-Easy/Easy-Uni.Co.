
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

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_sortingtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_sortingtotal]
GO

CREATE  PROCEDURE [rebuild_sortingtotal]
(
	@ayear int = null
)
AS BEGIN
	if (@ayear is null) 
	BEGIN
		DELETE FROM sortingtotal
		INSERT INTO sortingtotal (idsor, idacc, previsionvariation) 
		SELECT S.idsor, A.idacc, SUM(accountvardetail.amount)
		FROM account A
		CROSS JOIN sorting S
		LEFT OUTER JOIN accountvardetail
			ON accountvardetail.idacc LIKE A.idacc + '%'
			AND accountvardetail.idsor = S.idsor
		LEFT OUTER JOIN accountvar
		ON accountvar.yvar = accountvardetail.yvar
		AND accountvar.nvar = accountvardetail.nvar
		WHERE
		  ( 
			EXISTS (select * from accountvardetail AD where AD.idacc LIKE A.idacc+'%'
					AND AD.idsor = S.idsor) 
			OR EXISTS(SELECT * FROM accountyear AY where AY.idacc like A.idacc+'%'
					AND AY.idsor = S.idsor
					AND AY.ayear = A.ayear and
					(ISNULL(AY.previousprevision,0) <> 0 OR
					 ISNULL(AY.prevision,0) <> 0)
				 )
		)
		GROUP BY A.idacc, S.idsor
	
	END
	ELSE
	BEGIN 
		DELETE FROM sortingtotal where idacc like
				substring(convert(varchar,@ayear,4),3,2)+'%'

		INSERT INTO sortingtotal 
		(
			idsor,
			idacc,
			previsionvariation
		) 
		SELECT S.idsor, A.idacc,
		SUM(accountvardetail.amount)
		FROM account A
		CROSS JOIN sorting S 
		LEFT OUTER JOIN accountvardetail
		ON accountvardetail.idacc LIKE A.idacc+'%'
		AND accountvardetail.idsor = S.idsor
		LEFT OUTER JOIN accountvar
		ON accountvar.yvar = accountvardetail.yvar
		AND accountvar.nvar = accountvardetail.nvar
		WHERE
		  A.idacc like substring(convert(varchar,@ayear,4),3,2)+'%' 
		  AND
		  ( 
			EXISTS (select * from accountvardetail AD where AD.idacc LIKE A.idacc+'%'
					AND AD.idsor = S.idsor) 
			OR 
			EXISTS(SELECT * FROM accountyear AY where AY.idacc like A.idacc+'%'
					AND AY.idsor = S.idsor
					AND AY.ayear = A.ayear
					AND
					(isnull(AY.previousprevision,0) <> 0 OR
					 isnull(AY.prevision,0) <> 0)
				 )
		)
		GROUP BY A.idacc, S.idsor
	END
	
	UPDATE sortingtotal SET 
	previousprev= 
		(SELECT t2.previousprevision from accountyear t2 where t2.idacc=sortingtotal.idacc
		and t2.idsor = sortingtotal.idsor and t2.previousprevision is not null)
	WHERE (@ayear is null) OR sortingtotal.idacc LIKE substring(convert(varchar,@ayear,4),3,2)+'%'
	
	UPDATE sortingtotal SET 
	currentprev= 
		(SELECT t2.prevision from accountyear t2 where t2.idacc = sortingtotal.idacc
		and t2.idsor = sortingtotal.idsor and t2.prevision is not null)  
	WHERE (@ayear is null) OR sortingtotal.idacc LIKE substring(convert(varchar,@ayear,4),3,2)+'%'
	DECLARE @nlevel int
	SELECT @nlevel = MAX(CONVERT(int,nlevel)) FROM accountlevel
	WHILE (@nlevel>0)
	BEGIN
		UPDATE sortingtotal SET 
			previousprev =
				(SELECT SUM(t2.previousprev) from sortingtotal t2
				where t2.previousprev is not null
				and t2.idacc like sortingtotal.idacc+'____'
				and t2.idsor = sortingtotal.idsor) 
			where previousprev is null and len(sortingtotal.idacc)=2+@nlevel*4
			AND ((@ayear is null) OR sortingtotal.idacc LIKE substring(convert(varchar,@ayear,4),3,2)+'%')
		UPDATE sortingtotal SET 
			currentprev =
				(SELECT SUM(t2.currentprev) from sortingtotal t2
				where t2.currentprev is not null
				and t2.idacc like sortingtotal.idacc+'____'
				and t2.idsor = sortingtotal.idsor) 
			where currentprev is null and len(sortingtotal.idacc)=2+@nlevel*4
			AND ((@ayear is null) OR sortingtotal.idacc LIKE substring(convert(varchar,@ayear,4),3,2)+'%')
		print 'iterazione '+convert(varchar(20),@nlevel)
		SET @nlevel=@nlevel-1
	END
	
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

