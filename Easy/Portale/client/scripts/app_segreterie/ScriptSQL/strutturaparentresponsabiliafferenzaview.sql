
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


-- CREAZIONE VISTA strutturaparentresponsabiliafferenzaview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[strutturaparentresponsabiliafferenzaview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
GO






CREATE VIEW [dbo].[strutturaparentresponsabiliafferenzaview]
AS
SELECT  v.idstruttura, v.title, s.idstruttura AS idstruttura_parent, s.title AS titlestrutturaparent, r.idreg, r.title AS registry_title,
sr.start as strutturaresponsabile_start, sr.stop as strutturaresponsabile_stop,  sr.idperfruolo, a.idreg as afferente_idreg, ra.title as afferente_title, a.start, a.stop
FROM  dbo.strutturaparentview AS v INNER JOIN
dbo.struttura AS s ON v.ramo LIKE '%;' + CAST(s.idstruttura AS varchar(MAX)) + ';%' LEFT OUTER JOIN
dbo.strutturaresponsabile as sr on s.idstruttura = sr.idstruttura LEFT OUTER JOIN
dbo.registry AS r ON r.idreg = sr.idreg LEFT OUTER JOIN
dbo.afferenza as a on a.idstruttura = s.idstruttura LEFT OUTER JOIN
dbo.registry AS ra ON ra.idreg = a.idreg 





GO

-- VERIFICA DI strutturaparentresponsabiliafferenzaview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'strutturaparentresponsabiliafferenzaview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','int','prima.div.1','afferente_idreg','4','N','int','System.Int32','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','varchar(101)','prima.div.1','afferente_title','101','N','varchar','System.String','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','varchar(50)','prima.div.1','idperfruolo','50','N','varchar','System.String','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','int','prima.div.1','idreg','4','N','int','System.Int32','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','int','prima.div.1','idstruttura','4','N','int','System.Int32','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','strutturaparentresponsabiliafferenzaview','int','prima.div.1','idstruttura_parent','4','S','int','System.Int32','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','varchar(101)','prima.div.1','registry_title','101','N','varchar','System.String','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','date','prima.div.1','start','3','N','date','System.DateTime','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','date','prima.div.1','stop','3','N','date','System.DateTime','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','date','Generator','strutturaresponsabile_start','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','date','Generator','strutturaresponsabile_stop','3','N','date','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','varchar(1024)','prima.div.1','title','1024','N','varchar','System.String','','','''prima.div.1''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','strutturaparentresponsabiliafferenzaview','varchar(1024)','prima.div.1','titlestrutturaparent','1024','N','varchar','System.String','','','''prima.div.1''','','N')
GO

-- VERIFICA DI strutturaparentresponsabiliafferenzaview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'strutturaparentresponsabiliafferenzaview')
UPDATE customobject set isreal = 'N' where objectname = 'strutturaparentresponsabiliafferenzaview'
ELSE
INSERT INTO customobject (objectname, isreal) values('strutturaparentresponsabiliafferenzaview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

