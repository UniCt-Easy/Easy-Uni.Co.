if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_08]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_08]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE    PROCEDURE [exp_modello770_08] (@recordGH varchar(2)='GH')
AS BEGIN
	declare @statementyear smallint
	set @statementyear = 2008

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

	INSERT INTO #modello770 EXEC exp_modello770_08_a

	DECLARE @progr_raggiunto int

	if @recordGH = 'GH'
	begin
		INSERT INTO #modello770 EXEC exp_modello770_08_g '770'
	end

	INSERT INTO #modello770 EXEC exp_modello770_08_h

	DECLARE @numdichquadrog int
	SELECT @numdichquadrog = MAX(intero) FROM #modello770 WHERE quadro='HRG' AND colonna='03'
	set @numdichquadrog = isnull(@numdichquadrog, 0)

	DECLARE @numdichquadroh int
	SELECT @numdichquadroh = MAX(intero) FROM #modello770 WHERE quadro='HRH' AND colonna='03'
	set @numdichquadroh = isnull(@numdichquadroh, 0)

	INSERT INTO #modello770 EXEC exp_modello770_08_b @numdichquadrog, @numdichquadroh
	
-- Tipo record  
	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '1', 'J')

-- Codice fiscale del soggetto dichiarante  
	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) select 1, 'HRJ', 1, '2', cf from license

-- Progressivo modulo  
	INSERT INTO #modello770 (progr, quadro, riga, colonna, intero) VALUES(1, 'HRJ', 1, '3', 1)

-- Spazio a disposizione dell'utente  
--	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '4', 'Spazio a disposizione dell'utente')

-- Tipo operazione  
--	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '5', 'j')

-- Filler  
--	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '6', 'j')

-- Spazio a disposizione dell'utente per l'identificazione della dichiarazione  
--	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '7', 'j')

-- Identificativo del produttore del software (codice fiscale)  
	INSERT INTO #modello770 (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRJ', 1, '8', '05587470724')

	SELECT * FROM #modello770 ORDER BY progr
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
