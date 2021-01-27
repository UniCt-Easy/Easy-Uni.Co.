
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_07]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_07]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE    PROCEDURE [exp_modello770_07]
AS BEGIN
	declare @statementyear smallint
	set @statementyear = 2007

--	DECLARE @ayear smallint
--	set @ayear = @statementyear - 1

	CREATE TABLE #modello770
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data smalldatetime
	)
	INSERT INTO #modello770 
		EXEC exp_modello770_07_a
	DECLARE @progr_raggiunto int
	INSERT INTO #modello770 
		EXEC exp_modello770_07_g '770'
	INSERT INTO #modello770 
		EXEC exp_modello770_07_h
	DECLARE @numdichquadrog int
	SET @numdichquadrog =
	ISNULL((SELECT MAX(intero) FROM #modello770 WHERE quadro='HRG' AND colonna='03'),0)
	DECLARE @numdichquadroh int
	SET @numdichquadroh =
	ISNULL((SELECT MAX(intero) FROM #modello770 WHERE quadro='HRH' AND colonna='03'),0)
	INSERT INTO #modello770 
		EXEC exp_modello770_07_b @numdichquadrog,@numdichquadroh
	
	SELECT * FROM #modello770 ORDER BY progr
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

