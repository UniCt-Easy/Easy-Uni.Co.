
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


-- CREAZIONE VISTA perfindicatoredefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfindicatoredefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfindicatoredefaultview]
GO

CREATE VIEW [dbo].[perfindicatoredefaultview] AS 
SELECT  perfindicatore.ct AS perfindicatore_ct, perfindicatore.cu AS perfindicatore_cu, perfindicatore.description AS perfindicatore_description, perfindicatore.idperfindicatore,
 [dbo].perfindicatorekind.title AS perfindicatorekind_title, perfindicatore.idperfindicatorekind AS perfindicatore_idperfindicatorekind,CASE WHEN perfindicatore.inverso = 'S' THEN 'Si' WHEN perfindicatore.inverso = 'N' THEN 'No' END AS perfindicatore_inverso, perfindicatore.lt AS perfindicatore_lt, perfindicatore.lu AS perfindicatore_lu, perfindicatore.title,
 isnull('Titolo: ' + perfindicatore.title + '; ','') as dropdown_title
FROM [dbo].perfindicatore WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].perfindicatorekind WITH (NOLOCK) ON perfindicatore.idperfindicatorekind = [dbo].perfindicatorekind.idperfindicatorekind
WHERE  perfindicatore.idperfindicatore IS NOT NULL 
GO

-- VERIFICA DI perfindicatoredefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfindicatoredefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','varchar(2058)','ASSISTENZA','dropdown_title','2058','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','int','ASSISTENZA','idperfindicatore','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','datetime','ASSISTENZA','perfindicatore_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','varchar(64)','ASSISTENZA','perfindicatore_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','varchar(max)','ASSISTENZA','perfindicatore_description','-1','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfindicatoredefaultview','int','','perfindicatore_idperfindicatorekind','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfindicatoredefaultview','varchar(2)','','perfindicatore_inverso','2','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','datetime','ASSISTENZA','perfindicatore_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfindicatoredefaultview','varchar(64)','ASSISTENZA','perfindicatore_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfindicatoredefaultview','varchar(1024)','','perfindicatorekind_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfindicatoredefaultview','varchar(2048)','ASSISTENZA','title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI perfindicatoredefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfindicatoredefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfindicatoredefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfindicatoredefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

