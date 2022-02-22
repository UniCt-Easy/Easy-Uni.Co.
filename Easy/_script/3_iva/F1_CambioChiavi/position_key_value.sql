
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


-- Script che aggiorna le chiavi primarie delle tabelle di configurazione e le chiavi esterne delle tabelle
IF NOT EXISTS(SELECT * FROM position WHERE codeposition IN ('07_SW_AORD', '07_SW_ND02', '07_SW_ND03', '07_SW_ND04', '07_SW_ND05', '07_SW_ND06', '07_SW_ND07',
'07_SW_ND08', '07_SW_ND09', '07_SW_ND10', '07_SW_DAM2', '07_SW_DAM1', '07_SW_DGEN', '07_SW_DSUP', '07_SW_BORS', '07_SW_EDIP', '07_SW_ELAU', '07_SW_IGE2',
'07_SW_IGE1', '07_SW_PDI1', '07_SW_PDI2', '07_SW_PASC', '07_SW_PASN', '07_SW_PINC', '07_SW_PORD', '07_SW_PSTR', '07_SW_RICC', '07_SW_RICN'))
BEGIN
	-- Parte 3. Tabelle POSITION
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ASS ORD', '07_SW_AORD')
	INSERT INTO #temp VALUES('NON DOC 2', '07_SW_ND02')
	INSERT INTO #temp VALUES('NON DOC 3', '07_SW_ND03')
	INSERT INTO #temp VALUES('NON DOC 4', '07_SW_ND04')
	INSERT INTO #temp VALUES('NON DOC 5', '07_SW_ND05')
	INSERT INTO #temp VALUES('NON DOC 6', '07_SW_ND06')
	INSERT INTO #temp VALUES('NON DOC 7', '07_SW_ND07')
	INSERT INTO #temp VALUES('NON DOC 8', '07_SW_ND08')
	INSERT INTO #temp VALUES('NON DOC 9', '07_SW_ND09')
	INSERT INTO #temp VALUES('NON DOC 10', '07_SW_ND10')
	INSERT INTO #temp VALUES('DIR AMM 2', '07_SW_DAM2')
	INSERT INTO #temp VALUES('DIR AMM', '07_SW_DAM1')
	INSERT INTO #temp VALUES('DIR GEN', '07_SW_DGEN')
	INSERT INTO #temp VALUES('DIR SUP', '07_SW_DSUP')
	INSERT INTO #temp VALUES('BORSISTA', '07_SW_BORS')
	INSERT INTO #temp VALUES('EST DIP', '07_SW_EDIP')
	INSERT INTO #temp VALUES('EST LAU', '07_SW_ELAU')
	INSERT INTO #temp VALUES('ISP GEN 2', '07_SW_IGE2')
	INSERT INTO #temp VALUES('ISP GEN', '07_SW_IGE1')
	INSERT INTO #temp VALUES('PR DIR', '07_SW_PDI1')
	INSERT INTO #temp VALUES('PR DIR 2', '07_SW_PDI2')
	INSERT INTO #temp VALUES('P ASS C', '07_SW_PASC')
	INSERT INTO #temp VALUES('P ASS NC', '07_SW_PASN')
	INSERT INTO #temp VALUES('P INCAR', '07_SW_PINC')
	INSERT INTO #temp VALUES('P ORD', '07_SW_PORD')
	INSERT INTO #temp VALUES('P STRAORD', '07_SW_PSTR')
	INSERT INTO #temp VALUES('RIC C', '07_SW_RICC')
	INSERT INTO #temp VALUES('RIC NC', '07_SW_RICN')

	UPDATE position
	SET codeposition = #temp.newvalue
	FROM #temp WHERE codeposition = #temp.oldvalue

	DROP TABLE #temp
END
GO
