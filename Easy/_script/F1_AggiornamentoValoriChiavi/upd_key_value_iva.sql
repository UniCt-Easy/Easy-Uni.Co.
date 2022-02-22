
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


IF NOT EXISTS(SELECT * FROM ivapayperiodicity WHERE idivapayperiodicity = 'SW_MESE')
BEGIN
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)
	-- Parte 1. Tabelle IVAPAYPERIODICITY, INVOICESETUP

	INSERT INTO #temp VALUES('MENSILE', 'SW_MESE')
	
	UPDATE ivapayperiodicity
	SET idivapayperiodicity = #temp.newvalue
	FROM #temp WHERE idivapayperiodicity = #temp.oldvalue
	
	UPDATE invoicesetup
	SET idivapayperiodicity = #temp.newvalue
	FROM #temp WHERE idivapayperiodicity = #temp.oldvalue
	
	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM ivaregisterkind WHERE idivaregisterkind IN ('ACQ','VEN'))
BEGIN
	-- Parte 4. Tabelle IVAREGISTERKIND, INVOICEKINDREGISTERKIND, IVAPAYDETAIL, IVAREGISTER,
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ACQUISTI', 'ACQ')
	INSERT INTO #temp VALUES('VENDITE', 'VEN')

	UPDATE ivaregisterkind
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue

	UPDATE ivaregisterkind
	SET idivaregisterkindunified = #temp.newvalue
	FROM #temp WHERE idivaregisterkindunified = #temp.oldvalue


	
	UPDATE invoicekindregisterkind
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue

	UPDATE ivapaydetail
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue

	UPDATE ivaregister
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue


	DROP TABLE #temp
END
GO





IF NOT EXISTS(SELECT * FROM unifiedivaregisterkind WHERE idivaregisterkind IN ('ACQ','VEN'))
BEGIN
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ACQUISTI', 'ACQ')
	INSERT INTO #temp VALUES('VENDITE', 'VEN')

	UPDATE unifiedivapaydetail
	SET idivaregisterkindunified = #temp.newvalue
	FROM #temp WHERE idivaregisterkindunified = #temp.oldvalue

	UPDATE unifiedivaregister
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue

	UPDATE unifiedivaregisterkind
	SET idivaregisterkind = #temp.newvalue
	FROM #temp WHERE idivaregisterkind = #temp.oldvalue

	DROP TABLE #temp

END
GO




IF NOT EXISTS(SELECT * FROM invoicekind WHERE idinvkind IN ('07_D_ACQ_F', '07_I_ACQ_F', '07_D_VEN_F', 
'07_I_VEN_F', '07_D_ACQ_V', '07_I_ACQ_V', '07_D_VEN_V' , '07_I_VEN_V'))
BEGIN
	-- Parte 4. Tabelle INVOICEKIND, EXPENSEINVOICE, EXPENSEVAR, INCOMEINVOICE, INCOMEVAR, INVOICE, INVOICEDEFERRED,
	-- INVOICEDETAIL, INVOICEKINDREGISTERKIND, INVOICEKINDYEAR, INVOICESORTING, IVAREGISTER, PETTYCASHOPERATIONINVOICE,
	-- PROFSERVICE, UNIFIEDIVAREGISTER

	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('FTACQDIF', '07_D_ACQ_F')
	INSERT INTO #temp VALUES('FTACQIMM', '07_I_ACQ_F')
	INSERT INTO #temp VALUES('FTVENDDIF', '07_D_VEN_F')
	INSERT INTO #temp VALUES('FTVENDIMM', '07_I_VEN_F')
	INSERT INTO #temp VALUES('NCACQDIF', '07_D_ACQ_V')
	INSERT INTO #temp VALUES('NCACQIMM', '07_I_ACQ_V')
	INSERT INTO #temp VALUES('NCVENDDIF', '07_D_VEN_V')
	INSERT INTO #temp VALUES('NCVENDIMM', '07_I_VEN_V')

	UPDATE invoicekind
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue
	
	UPDATE expenseinvoice
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE expensevar
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE incomeinvoice
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE incomevar
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoice
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoicedeferred
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoicedetail
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoicekindregisterkind
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoicekindyear
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE invoicesorting
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE ivaregister
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE pettycashoperationinvoice
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE profservice
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE unifiedivaregister
	SET idinvkind = #temp.newvalue
	FROM #temp WHERE idinvkind = #temp.oldvalue

	UPDATE entry
	SET idrelated = SUBSTRING(idrelated, 1, LEN('inv§')) +
	#temp.newvalue +
	SUBSTRING(idrelated, LEN('inv§') +
		CHARINDEX('§', SUBSTRING(idrelated, len('inv§')+1, LEN(idrelated))) , LEN(idrelated)
	)
	FROM #temp
	WHERE idrelated LIKE 'inv§%'
	AND SUBSTRING(idrelated, LEN('inv§') + 1,
	CHARINDEX('§', SUBSTRING(idrelated, LEN('inv§') + 1, LEN(idrelated))) - 1)
	= #temp.oldvalue

	DROP TABLE #temp
END
GO
