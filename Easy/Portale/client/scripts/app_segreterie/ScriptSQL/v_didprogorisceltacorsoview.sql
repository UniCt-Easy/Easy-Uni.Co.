
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


--[DBO]--
-- CREAZIONE VISTA didprogorisceltacorsoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogorisceltacorsoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogorisceltacorsoview]
GO

CREATE VIEW [dbo].[didprogorisceltacorsoview] AS SELECT  didprogori.codice AS didprogori_codice, didprogori.ct AS didprogori_ct, didprogori.cu AS didprogori_cu, [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, didprogori.idcorsostudio, didprogori.iddidprog, didprogori.iddidprogcurr, didprogori.iddidprogori, didprogori.lt AS didprogori_lt, didprogori.lu AS didprogori_lu, didprogori.title AS didprogori_title, isnull('Identificativo: ' + CAST( didprogori.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( didprogori.iddidprogcurr AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( didprogori.iddidprogori AS NVARCHAR(64)) + '; ','') as dropdown_title FROM [dbo].didprogori WITH (NOLOCK)  LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON didprogori.idcorsostudio = [dbo].corsostudio.idcorsostudio WHERE  didprogori.idcorsostudio IS NOT NULL  AND didprogori.iddidprog IS NOT NULL  AND didprogori.iddidprogcurr IS NOT NULL  AND didprogori.iddidprogori IS NOT NULL 
GO

-- VERIFICA DI didprogorisceltacorsoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogorisceltacorsoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogorisceltacorsoview','int','','corsostudio_annoistituz','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogorisceltacorsoview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogorisceltacorsoview','varchar(50)','ASSISTENZA','didprogori_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','datetime','ASSISTENZA','didprogori_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','varchar(64)','ASSISTENZA','didprogori_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','datetime','ASSISTENZA','didprogori_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','varchar(64)','ASSISTENZA','didprogori_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogorisceltacorsoview','varchar(256)','ASSISTENZA','didprogori_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','nvarchar(248)','ASSISTENZA','dropdown_title','248','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogorisceltacorsoview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprogorisceltacorsoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogorisceltacorsoview')
UPDATE customobject set isreal = 'N' where objectname = 'didprogorisceltacorsoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogorisceltacorsoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

