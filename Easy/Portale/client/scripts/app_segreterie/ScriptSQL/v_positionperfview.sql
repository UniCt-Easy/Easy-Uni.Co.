
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA positionperfview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[positionperfview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[positionperfview]
GO

CREATE VIEW [dbo].[positionperfview] AS 
SELECT CASE WHEN position.active = 'S' THEN 'Si' WHEN position.active = 'N' THEN 'No' END AS position_active, position.codeposition AS position_codeposition, position.ct AS position_ct, position.cu AS position_cu, position.description,CASE WHEN position.foreignclass = 'S' THEN 'Si' WHEN position.foreignclass = 'N' THEN 'No' END AS position_foreignclass, position.idposition, position.lt AS position_lt, position.lu AS position_lu, position.maxincomeclass AS position_maxincomeclass, position_perf.ct AS position_perf_ct, position_perf.cu AS position_perf_cu, position_perf.idposition AS position_perf_idposition, position_perf.lt AS position_perf_lt, position_perf.lu AS position_perf_lu, position_perf.pesoateneo AS position_perf_pesoateneo, position_perf.pesoindividuale AS position_perf_pesoindividuale, position_perf.pesouo AS position_perf_pesouo,
 isnull('Descrizione: ' + position.description + '; ','') + ' ' + isnull('Codice: ' + position.codeposition + '; ','') as dropdown_title
FROM [dbo].position WITH (NOLOCK) 
INNER JOIN position_perf WITH (NOLOCK) ON position.idposition = position_perf.idposition
WHERE  position.idposition IS NOT NULL  AND position_perf.idposition IS NOT NULL 
GO

-- VERIFICA DI positionperfview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'positionperfview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(50)','ASSISTENZA','description','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(96)','','dropdown_title','96','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','int','ASSISTENZA','idposition','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','varchar(2)','ASSISTENZA','position_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(20)','ASSISTENZA','position_codeposition','20','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','datetime','ASSISTENZA','position_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(64)','ASSISTENZA','position_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','varchar(2)','ASSISTENZA','position_foreignclass','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','datetime','ASSISTENZA','position_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(64)','ASSISTENZA','position_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','smallint','ASSISTENZA','position_maxincomeclass','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','datetime','','position_perf_ct','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(64)','','position_perf_cu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','int','','position_perf_idposition','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','datetime','','position_perf_lt','8','S','datetime','System.DateTime','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','positionperfview','varchar(64)','','position_perf_lu','64','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','decimal(19,2)','','position_perf_pesoateneo','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','decimal(19,2)','','position_perf_pesoindividuale','9','N','decimal','System.Decimal','','2','','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','positionperfview','decimal(19,2)','','position_perf_pesouo','9','N','decimal','System.Decimal','','2','','19','N')
GO

-- VERIFICA DI positionperfview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'positionperfview')
UPDATE customobject set isreal = 'N' where objectname = 'positionperfview'
ELSE
INSERT INTO customobject (objectname, isreal) values('positionperfview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
