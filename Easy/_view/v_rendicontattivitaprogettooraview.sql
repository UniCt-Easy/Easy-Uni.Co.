
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


-- CREAZIONE VISTA rendicontattivitaprogettooraview
IF EXISTS(select * from sysobjects where id = object_id(N'[rendicontattivitaprogettooraview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [rendicontattivitaprogettooraview]
GO



CREATE VIEW [rendicontattivitaprogettooraview]
AS
SELECT			rendicontattivitaprogettoora.idrendicontattivitaprogettoora, rendicontattivitaprogettoora.idrendicontattivitaprogetto, rendicontattivitaprogettoora.data, 
				rendicontattivitaprogettoora.ore, rendicontattivitaprogettoora.ct, rendicontattivitaprogettoora.cu, rendicontattivitaprogettoora.lt, rendicontattivitaprogettoora.lu, 
				'<b>Progetto:</b> ' + isnull(progetto.title,'') + 
				'; <b>Workpackage:</b> ' + isnull(workpackage.title,'') + 
				'; <b>Attività:</b> ' + isnull(rendicontattivitaprogetto.description,'') + 
				'; <b>Ore:</b> ' +CAST(rendicontattivitaprogettoora.ore AS nvarchar(10)) AS titleancestor, 
                         rendicontattivitaprogetto.idreg
FROM            rendicontattivitaprogettoora 
INNER JOIN		rendicontattivitaprogetto ON rendicontattivitaprogettoora.idrendicontattivitaprogetto = rendicontattivitaprogetto.idrendicontattivitaprogetto
INNER JOIN		workpackage ON workpackage.idworkpackage = rendicontattivitaprogetto.idworkpackage
INNER JOIN		progetto ON progetto.idprogetto = workpackage.idprogetto

GO

-- VERIFICA DI rendicontattivitaprogettooraview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'rendicontattivitaprogettooraview'
INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','ct','8','''assistenza''','datetime','rendicontattivitaprogettooraview','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','cu','64','''assistenza''','varchar(64)','rendicontattivitaprogettooraview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','data','3','''assistenza''','date','rendicontattivitaprogettooraview','','','','','S','N','date','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idreg','4','''assistenza''','int','rendicontattivitaprogettooraview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogetto','4','''assistenza''','int','rendicontattivitaprogettooraview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','idrendicontattivitaprogettoora','4','''assistenza''','int','rendicontattivitaprogettooraview','','','','','N','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lt','8','''assistenza''','datetime','rendicontattivitaprogettooraview','','','','','N','N','datetime','assistenza','System.DateTime')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('S','lu','64','''assistenza''','varchar(64)','rendicontattivitaprogettooraview','','','','','N','N','varchar','assistenza','System.String')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','ore','4','''assistenza''','int','rendicontattivitaprogettooraview','','','','','S','N','int','assistenza','System.Int32')
GO

INSERT INTO columntypes (denynull,field,col_len,lastmoduser,sqldeclaration,tablename,format,col_precision,defaultvalue,col_scale,allownull,iskey,sqltype,createuser,systemtype) VALUES('N','titleancestor','0','''assistenza''','nvarchar(max)','rendicontattivitaprogettooraview','','','','','S','N','nvarchar','assistenza','System.String')
GO

-- VERIFICA DI rendicontattivitaprogettooraview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettooraview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettooraview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettooraview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

