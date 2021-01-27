
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
