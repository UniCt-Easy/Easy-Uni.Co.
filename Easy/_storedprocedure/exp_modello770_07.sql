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

