
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
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettooraview','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','int','assistenza','idreg','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','int','assistenza','idrendicontattivitaprogetto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','int','assistenza','idrendicontattivitaprogettoora','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','rendicontattivitaprogettooraview','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettooraview','int','assistenza','ore','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','rendicontattivitaprogettooraview','nvarchar(max)','assistenza','titleancestor','0','N','nvarchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI rendicontattivitaprogettooraview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'rendicontattivitaprogettooraview')
UPDATE customobject set isreal = 'N' where objectname = 'rendicontattivitaprogettooraview'
ELSE
INSERT INTO customobject (objectname, isreal) values('rendicontattivitaprogettooraview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

