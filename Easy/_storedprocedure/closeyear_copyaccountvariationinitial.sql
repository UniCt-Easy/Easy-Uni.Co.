
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
 
if exists (select * from dbo.sysobjects where id = object_id(N'[compute_copy_accountvariationinitial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_copy_accountvariationinitial]
GO

CREATE PROCEDURE compute_copy_accountvariationinitial
(
	@ayear int,
	@date datetime
)
AS BEGIN

-- exec compute_copy_accountvariationinitial 2013, {ts '2013-12-31 00:00:00'}

DECLARE @levelusable tinyint
SELECT  @levelusable = MAX(nlevel) FROM accountlevel WHERE ayear = @ayear

DECLARE @minlivop tinyint
DECLARE @maxlivop tinyint

SELECT @minlivop = isnull(MIN(nlevel),1) FROM accountlevel WHERE flagusable='S' AND ayear = @ayear
SELECT @maxlivop = MAX(nlevel) FROM accountlevel WHERE ayear = @ayear


CREATE TABLE #initialvariation
(
	idacc varchar(38),
	idupb varchar(36),
	prevision decimal (19,2),
	prevision2 decimal (19,2),
	prevision3 decimal (19,2),
	prevision4 decimal (19,2),
	prevision5 decimal (19,2)
)

INSERT INTO #initialvariation(
	idupb,	idacc,	prevision,prevision2,prevision3,prevision4,prevision5
)
select  D.idupb, D.idacc, 
		sum(D.amount) , 
		sum(D.amount2) , 
		sum(D.amount3) , 
		sum(D.amount4) , 
		sum(D.amount5) 
	from accountvar V
	JOIN accountvardetail D 	ON V.yvar = D.yvar
							AND V.nvar = D.nvar	
	
WHERE  V.yvar = @ayear
		AND V.adate <= @date		
		AND V.idaccountvarstatus = 5 
		AND V.variationkind = 5		
GROUP BY D.idupb, D.idacc

 

DECLARE @curridupb varchar(36)
DECLARE @curridacc varchar(38)
DECLARE @newprevision decimal(19,2)
DECLARE @newprevision2 decimal(19,2)
DECLARE @newprevision3 decimal(19,2)
DECLARE @newprevision4 decimal(19,2)
DECLARE @newprevision5 decimal(19,2)
DECLARE @newsecondaryprev decimal(19,2)
DECLARE @newresidual decimal(19,2)
DECLARE @pa decimal(19,2)

DECLARE #crs INSENSITIVE CURSOR FOR
SELECT
	idupb,
	idacc,
	prevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5	
FROM #initialvariation 

ORDER BY LEN(idupb)

FOR READ ONLY

OPEN #crs
FETCH NEXT FROM #crs INTO @curridupb, @curridacc, @newprevision, @newprevision2,@newprevision3,@newprevision4,@newprevision5

WHILE (@@FETCH_STATUS = 0)
BEGIN

	IF (SELECT COUNT(*) FROM accountyear WHERE idupb = @curridupb AND idacc = @curridacc) > 0
	BEGIN
		
			UPDATE accountyear SET
				prevision = @newprevision,
				prevision2 = @newprevision2,
				prevision3 = @newprevision3,
				prevision4 = @newprevision4,
				prevision5 = @newprevision5,
				lt = GetDate(),
				lu = 'COPIAMANUALE'
			WHERE accountyear.idupb = @curridupb
				AND accountyear.idacc = @curridacc
	END
	ELSE
	BEGIN
		
			INSERT INTO accountyear
			(
				ayear, idupb, idacc,
				prevision, prevision2, prevision3,prevision4, prevision5 ,
				ct, cu, lt, lu
			)
			VALUES
			(
				@ayear, @curridupb, @curridacc, 
				@newprevision, @newprevision2, @newprevision3,@newprevision4,@newprevision5,
				GETDATE(), 'COPIAMANUALE', GETDATE(), 'COPIAMANUALE'
			)
		
	END
	FETCH NEXT FROM #crs INTO @curridupb, @curridacc, @newprevision, @newprevision2,@newprevision3,@newprevision4,@newprevision5
	END
CLOSE #crs
DEALLOCATE #crs


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
