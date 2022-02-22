
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

-- VERIFICA DI TimesheetView IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'TimesheetView'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','anno','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','datetime','assistenza','data','8','N','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','varchar(1024)','assistenza','dipartimento','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','giorno','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','idprogetto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','timesheetview','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','mese','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','ore','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','nvarchar(2048)','assistenza','progetto','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','int','assistenza','responsabile','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','timesheetview','nvarchar(2048)','assistenza','workpackage','2048','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI TimesheetView IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'TimesheetView')
UPDATE customobject set isreal = 'N' where objectname = 'TimesheetView'
ELSE
INSERT INTO customobject (objectname, isreal) values('TimesheetView', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

