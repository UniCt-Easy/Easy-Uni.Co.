
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_i_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_i_income]
GO


CREATE   TRIGGER [trigger_i_income] ON [income] FOR INSERT
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN
DECLARE @nrowinserted int
SET @nrowinserted = ISNULL((SELECT COUNT(*) FROM inserted),0)

IF (@nrowinserted > 1)
BEGIN
	CREATE TABLE #income (idinc int, nphase tinyint)
	
	INSERT INTO #income (idinc, nphase)
	SELECT idinc, nphase FROM inserted
	
	INSERT INTO incomelink (idchild, nlevel, idparent)
	SELECT idinc, nphase, idinc
	FROM #income
	
	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO incomelink (idchild, nlevel, idparent)
		SELECT IL.idchild, (nlevel - 1), I.parentidinc
		FROM incomelink IL
		JOIN income I
		ON IL.idparent = I.idinc
		WHERE IL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM incomelink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
		AND EXISTS(SELECT * FROM #income WHERE #income.idinc = IL.idchild)
	END
END
ELSE
BEGIN
	DECLARE @idinc int
	DECLARE @nphase tinyint
	DECLARE @parentidinc int
	SELECT @idinc = idinc, @nphase = nphase, @parentidinc = parentidinc FROM inserted

	INSERT INTO incomelink (idchild, nlevel, idparent)
	VALUES(@idinc, @nphase, @idinc)

	while (@nphase>1)
	begin
	  set @nphase=@nphase-1
		INSERT INTO incomelink (idchild, nlevel, idparent)
		VALUES(@idinc,@nphase, @parentidinc)
		if (@nphase>1) select @parentidinc=parentidinc from income where idinc = @parentidinc	
	
	end
	
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

