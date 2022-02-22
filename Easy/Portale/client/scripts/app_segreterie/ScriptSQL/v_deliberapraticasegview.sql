
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


-- CREAZIONE VISTA deliberapraticasegview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[deliberapraticasegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[deliberapraticasegview]
GO

CREATE VIEW [dbo].[deliberapraticasegview] AS 
SELECT  deliberapratica.ct AS deliberapratica_ct, deliberapratica.cu AS deliberapratica_cu, deliberapratica.idcorsostudio, deliberapratica.iddelibera, deliberapratica.iddidprog, deliberapratica.idiscrizione, deliberapratica.idistanza, deliberapratica.idistanzakind,
 [dbo].pratica.ct AS pratica_ct, [dbo].pratica.cu AS pratica_cu, [dbo].pratica.idcorsostudio AS pratica_idcorsostudio, [dbo].pratica.iddichiar AS pratica_iddichiar, [dbo].pratica.iddidprog AS pratica_iddidprog, [dbo].pratica.idiscrizione AS pratica_idiscrizione, [dbo].pratica.idiscrizione_from AS pratica_idiscrizione_from, [dbo].pratica.idistanza AS pratica_idistanza, [dbo].pratica.idistanzakind AS pratica_idistanzakind, [dbo].pratica.idpratica AS pratica_idpratica, [dbo].pratica.idreg AS pratica_idreg, [dbo].pratica.idstatuskind AS pratica_idstatuskind, [dbo].pratica.idtitolostudio AS pratica_idtitolostudio, [dbo].pratica.lt AS pratica_lt, [dbo].pratica.lu AS pratica_lu, [dbo].pratica.protanno AS pratica_protanno, [dbo].pratica.protnumero AS pratica_protnumero, deliberapratica.idpratica, deliberapratica.idreg, deliberapratica.lt AS deliberapratica_lt, deliberapratica.lu AS deliberapratica_lu,
 isnull('Studente: ' + CAST( deliberapratica.idreg AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Studente: ' + CAST( [dbo].pratica.idreg AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Didattica programmata: ' + CAST( [dbo].pratica.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Istanza: ' + CAST( deliberapratica.idistanza AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.iddidprog AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Iscrizione: ' + CAST( deliberapratica.idiscrizione AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.idistanzakind AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Identificativo: ' + CAST( deliberapratica.idcorsostudio AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].deliberapratica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].pratica WITH (NOLOCK) ON deliberapratica.idpratica = [dbo].pratica.idpratica
WHERE  deliberapratica.idcorsostudio IS NOT NULL  AND deliberapratica.iddelibera IS NOT NULL  AND deliberapratica.iddidprog IS NOT NULL  AND deliberapratica.idiscrizione IS NOT NULL  AND deliberapratica.idistanza IS NOT NULL  AND deliberapratica.idistanzakind <> 9 AND deliberapratica.idistanzakind IS NOT NULL  AND deliberapratica.idpratica IS NOT NULL  AND deliberapratica.idreg IS NOT NULL 
GO

-- VERIFICA DI deliberapraticasegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'deliberapraticasegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','datetime','ASSISTENZA','deliberapratica_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','varchar(64)','ASSISTENZA','deliberapratica_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','datetime','ASSISTENZA','deliberapratica_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','varchar(64)','ASSISTENZA','deliberapratica_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','nvarchar(647)','ASSISTENZA','dropdown_title','647','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','iddelibera','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idiscrizione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idpratica','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','deliberapraticasegview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','datetime','','pratica_ct','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','varchar(64)','','pratica_cu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idcorsostudio','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_iddichiar','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_iddidprog','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idiscrizione','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idiscrizione_from','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idistanza','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idistanzakind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idpratica','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idreg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idstatuskind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_idtitolostudio','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','datetime','','pratica_lt','8','N','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','varchar(64)','','pratica_lu','64','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_protanno','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','deliberapraticasegview','int','','pratica_protnumero','4','N','int','System.Int32','','','','','N')
GO

-- VERIFICA DI deliberapraticasegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'deliberapraticasegview')
UPDATE customobject set isreal = 'N' where objectname = 'deliberapraticasegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('deliberapraticasegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

