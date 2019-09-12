-- Script che aggiorna le chiavi primarie delle tabelle di configurazione e le chiavi esterne delle tabelle
IF NOT EXISTS(SELECT * FROM address WHERE codeaddress IN ('07_SW_ANP', '07_SW_AVV', '07_SW_CER', '07_SW_DOM', '07_SW_FAT', '07_SW_ORD', '07_SW_DEF'))
BEGIN
	-- Parte 3. Tabelle ADDRESS, REGISTRYADDRESS
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)
	INSERT INTO #temp VALUES('ANPRE', '07_SW_ANP')
	INSERT INTO #temp VALUES('AVPAG', '07_SW_AVV')
	INSERT INTO #temp VALUES('CERRA', '07_SW_CER')
	INSERT INTO #temp VALUES('DOMFI', '07_SW_DOM')
	INSERT INTO #temp VALUES('FATVE', '07_SW_FAT')
	INSERT INTO #temp VALUES('ORDIN', '07_SW_ORD')
	INSERT INTO #temp VALUES('STAND', '07_SW_DEF')

	UPDATE address
	SET codeaddress = #temp.newvalue
	FROM #temp WHERE codeaddress = #temp.oldvalue

	DROP TABLE #temp
END
GO
