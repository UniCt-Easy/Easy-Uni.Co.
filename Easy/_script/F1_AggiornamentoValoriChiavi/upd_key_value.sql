
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
IF NOT EXISTS(SELECT * FROM employment WHERE idemployment IN ('1','2','3','4'))
BEGIN
	-- Parte 3. Tabelle EMPLOYMENT, POSITION
	CREATE TABLE #temp
	(
		oldvalue char(1),
		newvalue char(1)
	)
	INSERT INTO #temp VALUES('A', '1')
	INSERT INTO #temp VALUES('D', '2')
	INSERT INTO #temp VALUES('N', '3')
	INSERT INTO #temp VALUES('P', '4')
	
	UPDATE employment
	SET idemployment = #temp.newvalue
	FROM #temp WHERE idemployment = #temp.oldvalue
	
	UPDATE position
	SET idemployment = #temp.newvalue
	FROM #temp WHERE idemployment = #temp.oldvalue
	
	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM certificationmodel WHERE idcertificationmodel = 'O')
BEGIN
	-- Parte 6. Tabelle CERTIFICATIONMODEL, SERVICE
	CREATE TABLE #temp
	(
		oldvalue char(1),
		newvalue char(1)
	)
	
	INSERT INTO #temp VALUES('A', 'O')
	INSERT INTO #temp VALUES('B', 'O')
	INSERT INTO #temp VALUES('C', 'O')
	INSERT INTO #temp VALUES('D', 'O')

	DELETE FROM certificationmodel WHERE idcertificationmodel IN ('A', 'B', 'C', 'D')
	INSERT INTO certificationmodel (idcertificationmodel, description, lt, lu)
	VALUES ('O', 'Certificazione Generica', GETDATE(), 'SA')

	UPDATE service
	SET certificatekind = #temp.newvalue
	FROM #temp WHERE certificatekind = #temp.oldvalue

	DROP TABLE #temp
END
GO

-- Parte 13. Cancellazione della Tabella REGION
IF EXISTS(select * from sysobjects where id = object_id(N'[region]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE region
	EXEC clear_table_info 'region'
END
GO

-- Non faccio il controllo su I perché esiste sia prima che dopo
IF NOT EXISTS(SELECT * FROM residence WHERE idresidence IN ('X','J'))
BEGIN
	-- Parte 3. Tabelle RESIDENCE, REGISTRY
	CREATE TABLE #temp
	(
		oldvalue char(1),
		newvalue char(1)
	)

	DELETE FROM residence WHERE idresidence IN ('C', 'E', 'F', 'R', 'T', 'U', 'A')

	INSERT INTO residence (idresidence, active, description, lt, lu)
	VALUES('X', 'S', 'Residenti fuori dall''UE',GETDATE(),'''SA''')

	INSERT INTO residence (idresidence, active, description, lt, lu)
	VALUES('J', 'S', 'Residenti in altri paesi dell''UE',GETDATE(),'''SA''')

	INSERT INTO #temp VALUES('C', 'J')
	INSERT INTO #temp VALUES('E', 'I')
	INSERT INTO #temp VALUES('F', 'X')
	INSERT INTO #temp VALUES('R', 'I')
	INSERT INTO #temp VALUES('T', 'I')
	INSERT INTO #temp VALUES('U', 'I')
	INSERT INTO #temp VALUES('A', 'I')

	UPDATE registry
	SET residence = #temp.newvalue
	FROM #temp WHERE residence = #temp.oldvalue
	
	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM workcontract WHERE idwor IN ('07_CCC','07_AUT','07_DIP','07_NRE'))
BEGIN
	-- Parte 3. Tabelle WORKCONTRACT, REGISTRYLEGALSTATUS, REGISTRYROLE
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('ASSI', '07_CCC')
	INSERT INTO #temp VALUES('AUTO', '07_AUT')
	INSERT INTO #temp VALUES('DIPE', '07_DIP')
	INSERT INTO #temp VALUES('ESTE', '07_NRE')
	
	UPDATE workcontract
	SET idwor = #temp.newvalue
	FROM #temp WHERE idwor = #temp.oldvalue
	
	UPDATE registrylegalstatus
	SET idwor = #temp.newvalue
	FROM #temp WHERE idwor = #temp.oldvalue
	
	UPDATE registryrole
	SET idwor = #temp.newvalue
	FROM #temp WHERE idwor = #temp.oldvalue

	DROP TABLE #temp
END
GO

IF NOT EXISTS(SELECT * FROM stamphandling WHERE idstamphandling IN ('07_NONESE','07_ESENTE'))
BEGIN
	-- Parte 3. Tabelle STAMPHANDLING, PAYMENT
	CREATE TABLE #temp
	(
		oldvalue varchar(20),
		newvalue varchar(20)
	)

	INSERT INTO #temp VALUES('1', '07_NONESE')
	INSERT INTO #temp VALUES('2', '07_ESENTE')
	
	UPDATE stamphandling
	SET idstamphandling = #temp.newvalue
	FROM #temp WHERE idstamphandling = #temp.oldvalue
	
	UPDATE payment
	SET idstamphandling = #temp.newvalue
	FROM #temp WHERE idstamphandling = #temp.oldvalue
	
	DROP TABLE #temp
END
GO
