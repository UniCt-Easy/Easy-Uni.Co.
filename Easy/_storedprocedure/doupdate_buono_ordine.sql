
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

if exists (select * from dbo.sysobjects where id = object_id(N'[doupdate_buono_ordine]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [doupdate_buono_ordine]
GO

CREATE PROCEDURE [doupdate_buono_ordine]
(
	@ayear int,
	@printkind char(1),
	@mandatekind varchar(20),
	@startnman int,
	@stopnman int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)

AS BEGIN
CREATE TABLE #printingdoc (num int)
IF @printkind = 'A' 
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT M.nman FROM mandate M
	join mandatekind  K 
		ON K.idmankind = M.idmankind  
	WHERE M.yman = @ayear
		AND M.officiallyprinted <>'S'
		AND M.idmankind = @mandatekind
		AND (isnull(M.idsor01,K.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (isnull(M.idsor02,K.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (isnull(M.idsor03,K.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (isnull(M.idsor04,K.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (isnull(M.idsor05,K.idsor05) = @idsor05 OR @idsor05 IS NULL)

END
IF @printkind <> 'A'
BEGIN
	INSERT INTO #printingdoc (num) 
	SELECT M.nman 
	FROM mandate M
	join mandatekind  K 
		ON K.idmankind = M.idmankind  
	WHERE M.yman = @ayear
		AND M.nman BETWEEN @startnman AND @stopnman
		AND M.idmankind = @mandatekind
		AND (isnull(M.idsor01,K.idsor01) = @idsor01 OR @idsor01 IS NULL)
		AND (isnull(M.idsor02,K.idsor02) = @idsor02 OR @idsor02 IS NULL)
		AND (isnull(M.idsor03,K.idsor03) = @idsor03 OR @idsor03 IS NULL)
		AND (isnull(M.idsor04,K.idsor04) = @idsor04 OR @idsor04 IS NULL)
		AND (isnull(M.idsor05,K.idsor05) = @idsor05 OR @idsor05 IS NULL)
END
UPDATE mandate SET officiallyprinted = 'S'
WHERE yman = @ayear 
	AND idmankind = @mandatekind
	AND nman IN (SELECT num FROM #printingdoc)
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

