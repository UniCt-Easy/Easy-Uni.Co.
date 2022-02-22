
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


-- CREAZIONE VISTA perfsogliadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfsogliadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfsogliadefaultview]
GO

CREATE VIEW [dbo].[perfsogliadefaultview] AS 
SELECT  perfsoglia.ct AS perfsoglia_ct, perfsoglia.cu AS perfsoglia_cu, perfsoglia.idperfsoglia,
 [dbo].perfsogliakind.idperfsogliakind AS perfsogliakind_idperfsogliakind, perfsoglia.idperfsogliakind, perfsoglia.lt AS perfsoglia_lt, perfsoglia.lu AS perfsoglia_lu, perfsoglia.valore AS perfsoglia_valore,
 [dbo].year.year AS year_year, perfsoglia.year AS perfsoglia_year
FROM [dbo].perfsoglia WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfsogliakind WITH (NOLOCK) ON perfsoglia.idperfsogliakind = [dbo].perfsogliakind.idperfsogliakind
LEFT OUTER JOIN [dbo].year WITH (NOLOCK) ON perfsoglia.year = [dbo].year.year
WHERE  perfsoglia.idperfsoglia IS NOT NULL 
GO

-- VERIFICA DI perfsogliadefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfsogliadefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','int','ASSISTENZA','idperfsoglia','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfsogliadefaultview','varchar(50)','','idperfsogliakind','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','datetime','ASSISTENZA','perfsoglia_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','varchar(64)','ASSISTENZA','perfsoglia_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','datetime','ASSISTENZA','perfsoglia_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','varchar(64)','ASSISTENZA','perfsoglia_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfsogliadefaultview','decimal(19,2)','ASSISTENZA','perfsoglia_valore','9','S','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfsogliadefaultview','int','','perfsoglia_year','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfsogliadefaultview','varchar(50)','','perfsogliakind_idperfsogliakind','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfsogliadefaultview','int','ASSISTENZA','year_year','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI perfsogliadefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfsogliadefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfsogliadefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfsogliadefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

