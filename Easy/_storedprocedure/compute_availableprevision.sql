
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_availableprevision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_availableprevision]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [compute_availableprevision]
(
	@paridfin int,
	@prevision decimal(19,2) output,
	@secondaryprev decimal(19,2) output,
	@currentarrears decimal(19,2) output,
	@previousprevision decimal(19,2) output,
	@previoussecondaryprev decimal(19,2) output,
	@previousarrears decimal(19,2) output
)
AS BEGIN
DECLARE @idupb_root varchar(36)
SET @idupb_root = '0001'

DECLARE @prevlevelop smallint
SELECT @prevlevelop = flag
FROM finlevel
WHERE nlevel = (SELECT nlevel FROM fin WHERE idfin = @paridfin)

IF @prevlevelop&2 <> 0
BEGIN
	DECLARE @par_lev_prevision decimal(19,2)
	DECLARE @par_lev_previousprevision decimal(19,2)
	DECLARE @par_lev_secondaryprev decimal(19,2)
	DECLARE @par_lev_previoussecondaryprev decimal(19,2)
	DECLARE @par_lev_currentarrears decimal(19,2)
	DECLARE @par_lev_previousarrears decimal(19,2)
	SELECT 
		@par_lev_prevision = prevision, 
		@par_lev_previousprevision = previousprevision,
		@par_lev_secondaryprev = secondaryprev,
		@par_lev_previoussecondaryprev = previoussecondaryprev,
		@par_lev_currentarrears = currentarrears,
		@par_lev_previousarrears = previousarrears
	FROM finyear 
	WHERE idfin = @paridfin
		AND idupb = @idupb_root

	DECLARE @curr_lev_prevision decimal(19,2)
	DECLARE @curr_lev_previousprevision decimal(19,2)
	DECLARE @curr_lev_secondaryprev decimal(19,2)
	DECLARE @curr_lev_previoussecondaryprev decimal(19,2)
	DECLARE @curr_lev_currentarrears decimal(19,2)
	DECLARE @curr_lev_previousarrears decimal(19,2)
	SELECT 
		@curr_lev_prevision = SUM(prevision), 
		@curr_lev_previousprevision = SUM(previousprevision),
		@curr_lev_secondaryprev = SUM(secondaryprev),
		@curr_lev_previoussecondaryprev = SUM(previoussecondaryprev),
		@curr_lev_currentarrears = SUM(currentarrears),
		@curr_lev_previousarrears = SUM(previousarrears)
	FROM finyearview
	WHERE paridfin = @paridfin
		AND idupb = @idupb_root

	SELECT @prevision = ISNULL(@par_lev_prevision, 0) - ISNULL(@curr_lev_prevision, 0)
	SELECT @previousprevision = ISNULL(@par_lev_previousprevision, 0) - ISNULL(@curr_lev_previousprevision, 0)
	SELECT @secondaryprev = ISNULL(@par_lev_secondaryprev, 0) - ISNULL(@curr_lev_secondaryprev, 0)
	SELECT @previoussecondaryprev = ISNULL(@par_lev_previoussecondaryprev, 0) - ISNULL(@curr_lev_previoussecondaryprev, 0)
	SELECT @currentarrears = ISNULL(@par_lev_currentarrears, 0) - ISNULL(@curr_lev_currentarrears, 0)
	SELECT @previousarrears = ISNULL(@par_lev_previousarrears, 0) - ISNULL(@curr_lev_previousarrears, 0)
END
ELSE
BEGIN
	SELECT @prevision = NULL
	SELECT @previousprevision = NULL
	SELECT @secondaryprev = NULL
	SELECT @previoussecondaryprev = NULL
	SELECT @currentarrears = NULL
	SELECT @previousarrears = NULL
END
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

