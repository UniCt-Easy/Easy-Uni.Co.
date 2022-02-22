
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


-- CREAZIONE VISTA TimesheetView
IF EXISTS(select * from sysobjects where id = object_id(N'[TimesheetView]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [TimesheetView]
GO


CREATE VIEW [timesheetview]
AS
SELECT        
	progetto.idprogetto,
	rendicontattivitaprogetto.idreg, 
	YEAR(rendicontattivitaprogettoora.data) AS anno, 
	rendicontattivitaprogettoora.data, 
	rendicontattivitaprogettoora.ore, 
	progetto.titolobreve AS progetto, 
    workpackage.title AS workpackage, 
	DAY(rendicontattivitaprogettoora.data) AS giorno, 
	MONTH(rendicontattivitaprogettoora.data) AS mese,
	s.title as dipartimento,
	progetto.idreg as responsabile
FROM
	rendicontattivitaprogetto 
	INNER JOIN rendicontattivitaprogettoora ON rendicontattivitaprogetto.idrendicontattivitaprogetto = rendicontattivitaprogettoora.idrendicontattivitaprogetto 
	INNER JOIN progetto ON rendicontattivitaprogetto.idprogetto = progetto.idprogetto 
	INNER JOIN workpackage ON rendicontattivitaprogetto.idworkpackage = workpackage.idworkpackage
	LEFT OUTER JOIN Struttura s on s.idstruttura = workpackage.idstruttura
UNION
SELECT        
	99999 as idprogetto,
	dbo.lezione.idreg_docenti, 
	YEAR(dbo.lezione.start) AS anno, 
	dbo.lezione.start as data, 
	DATEDIFF(hh, dbo.lezione.start, dbo.lezione.stop) as ore, 
	'Teaching activities' AS progetto, 
    'Teaching activities' AS workpackage, 
	DAY(dbo.lezione.start) AS giorno, 
	MONTH(dbo.lezione.start) AS mese,
	s.title as dipartimento,
	null as responsabile
FROM
	dbo.lezione
	INNER JOIN corsostudio cs on cs.idcorsostudio = lezione.idcorsostudio
	LEFT OUTER JOIN Struttura s on s.idstruttura = cs.idcorsostudio



GO

