
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


-- CREAZIONE VISTA perfschedacambiostatodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfschedacambiostatodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfschedacambiostatodefaultview]
GO

CREATE VIEW [dbo].[perfschedacambiostatodefaultview] AS 
SELECT  perfschedacambiostato.idperfschedacambiostato,
 [dbo].perfschedastatus.title AS perfschedastatus_title, perfschedacambiostato.idperfschedastatus AS perfschedacambiostato_idperfschedastatus,
 perfschedastatusto.title AS perfschedastatusto_title, perfschedacambiostato.idperfschedastatus_to AS perfschedacambiostato_idperfschedastatus_to,
 [dbo].perfruolo.idperfruolo AS perfruolo_idperfruolo, perfschedacambiostato.idperfruolo, perfschedacambiostato.idperfruolo_mail AS perfschedacambiostato_idperfruolo_mail
FROM [dbo].perfschedacambiostato WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfschedastatus WITH (NOLOCK) ON perfschedacambiostato.idperfschedastatus = [dbo].perfschedastatus.idperfschedastatus
LEFT OUTER JOIN [dbo].perfschedastatus AS perfschedastatusto WITH (NOLOCK) ON perfschedacambiostato.idperfschedastatus_to = perfschedastatusto.idperfschedastatus
LEFT OUTER JOIN [dbo].perfruolo WITH (NOLOCK) ON perfschedacambiostato.idperfruolo = [dbo].perfruolo.idperfruolo
WHERE  perfschedacambiostato.idperfschedacambiostato IS NOT NULL 
GO

-- VERIFICA DI perfschedacambiostatodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfschedacambiostatodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','idperfruolo','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfschedacambiostatodefaultview','int','ASSISTENZA','idperfschedacambiostato','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','perfruolo_idperfruolo','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(50)','','perfschedacambiostato_idperfruolo_mail','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','int','ASSISTENZA','perfschedacambiostato_idperfschedastatus','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','int','ASSISTENZA','perfschedacambiostato_idperfschedastatus_to','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(1024)','ASSISTENZA','perfschedastatus_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfschedacambiostatodefaultview','varchar(1024)','','perfschedastatusto_title','1024','N','varchar','System.String','','','','','N')
GO

-- VERIFICA DI perfschedacambiostatodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfschedacambiostatodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfschedacambiostatodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfschedacambiostatodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

