if exists (select * from dbo.sysobjects where id = object_id(N'[exp_modello770_08_a]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_modello770_08_a]
GO

CREATE     PROCEDURE [exp_modello770_08_a]
AS BEGIN
	CREATE TABLE #recorda
	(
		progr int,
		quadro varchar(3),
		riga int,
		colonna varchar(3),
		stringa varchar(100),
		intero int,
		data datetime
	)
	DECLARE @cf varchar(11)
	DECLARE @departmentcode varchar(10)
	
	select @cf = isnull(cf, p_iva) from license
	if @cf is null
	begin
		SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_f'
	end
	IF (@cf IS NULL)
	BEGIN
		SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_P_Iva'	
	END

	SELECT @departmentcode = departmentcode	FROM license

	DECLARE @tipofornitore int
	SET @tipofornitore = 6
	--1 Tipo record
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '01', 'A')
	--3 Codice fornitura
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '03', '77S08')
	--4 Tipo fornitore
	INSERT INTO #recorda (progr, quadro, riga, colonna, intero) VALUES(1, 'HRA', 1, '04', @tipofornitore)
	--5 Codice fiscale del fornitore
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '05', @cf)
-- I campi 07 e 08 non vengono inseriti in quanto effettuiamo un unico invio (non superiamo la soglia di 1,38 MB compressi)
	--9 Campo utente
	INSERT INTO #recorda (progr, quadro, riga, colonna, stringa) VALUES(1, 'HRA', 1, '09', @departmentcode)
	SELECT * FROM #recorda WHERE stringa IS NOT NULL OR intero IS NOT NULL OR data IS NOT NULL
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
