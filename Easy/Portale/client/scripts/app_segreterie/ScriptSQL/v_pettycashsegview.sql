
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


-- CREAZIONE VISTA pettycashsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[pettycashsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pettycashsegview]
GO

CREATE VIEW [pettycashsegview] AS SELECT CASE WHEN pettycash.active = 'S' THEN 'Si' WHEN pettycash.active = 'N' THEN 'No' END AS pettycash_active, pettycash.bursarship AS pettycash_bursarship, pettycash.ct AS pettycash_ct, pettycash.cu AS pettycash_cu, pettycash.description, pettycash.idpettycash, pettycash.lt AS pettycash_lt, pettycash.lu AS pettycash_lu, pettycash.organizational_unit AS pettycash_organizational_unit, pettycash.pettycode AS pettycash_pettycode, isnull('Descrizione: ' + pettycash.description + '; ','') + ' ' + isnull('Codice: ' + pettycash.pettycode + '; ','') as dropdown_title FROM pettycash WITH (NOLOCK)  WHERE  pettycash.idpettycash IS NOT NULL 
GO

-- VERIFICA DI pettycashsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pettycashsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','varchar(50)','ASSISTENZA','description','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','varchar(96)','ASSISTENZA','dropdown_title','96','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','int','ASSISTENZA','idpettycash','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pettycashsegview','varchar(2)','ASSISTENZA','pettycash_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pettycashsegview','varchar(100)','ASSISTENZA','pettycash_bursarship','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','datetime','ASSISTENZA','pettycash_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','varchar(64)','ASSISTENZA','pettycash_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','datetime','ASSISTENZA','pettycash_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pettycashsegview','varchar(64)','ASSISTENZA','pettycash_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pettycashsegview','varchar(100)','ASSISTENZA','pettycash_organizational_unit','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pettycashsegview','varchar(20)','ASSISTENZA','pettycash_pettycode','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI pettycashsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pettycashsegview')
UPDATE customobject set isreal = 'N' where objectname = 'pettycashsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pettycashsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

