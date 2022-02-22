
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
-- CREAZIONE VISTA canaleerogataview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[canaleerogataview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[canaleerogataview]
GO

CREATE VIEW [dbo].[canaleerogataview] AS SELECT  canale.aa, canale.ct AS canale_ct, canale.cu AS canale_cu, canale.CUIN AS canale_CUIN, [dbo].attivform.title AS attivform_title, canale.idattivform, canale.idcanale, canale.idcorsostudio, canale.iddidprog, [dbo].didproganno.title AS didproganno_title, canale.iddidproganno, [dbo].didprogcurr.title AS didprogcurr_title, canale.iddidprogcurr, [dbo].didprogori.title AS didprogori_title, canale.iddidprogori, [dbo].didprogporzanno.title AS didprogporzanno_title, canale.iddidprogporzanno, canale.idsede AS canale_idsede, canale.lt AS canale_lt, canale.lu AS canale_lu, canale.numerostud AS canale_numerostud, canale.sortcode AS canale_sortcode, canale.title, isnull('Denominazione: ' + canale.title + '; ','') as dropdown_title FROM [dbo].canale WITH (NOLOCK)  LEFT OUTER JOIN [dbo].attivform WITH (NOLOCK) ON canale.idattivform = [dbo].attivform.idattivform LEFT OUTER JOIN [dbo].didproganno WITH (NOLOCK) ON canale.iddidproganno = [dbo].didproganno.iddidproganno LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON canale.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON canale.iddidprogori = [dbo].didprogori.iddidprogori LEFT OUTER JOIN [dbo].didprogporzanno WITH (NOLOCK) ON canale.iddidprogporzanno = [dbo].didprogporzanno.iddidprogporzanno WHERE  canale.aa IS NOT NULL  AND canale.idattivform IS NOT NULL  AND canale.idcanale IS NOT NULL  AND canale.idcorsostudio IS NOT NULL  AND canale.iddidprog IS NOT NULL  AND canale.iddidproganno IS NOT NULL  AND canale.iddidprogcurr IS NOT NULL  AND canale.iddidprogori IS NOT NULL  AND canale.iddidprogporzanno IS NOT NULL 
GO

-- VERIFICA DI canaleerogataview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'canaleerogataview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','nvarchar(max)','ASSISTENZA','attivform_title','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','datetime','ASSISTENZA','canale_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(64)','ASSISTENZA','canale_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(9)','ASSISTENZA','canale_CUIN','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','','canale_idsede','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','datetime','ASSISTENZA','canale_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(64)','ASSISTENZA','canale_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','int','ASSISTENZA','canale_numerostud','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','int','ASSISTENZA','canale_sortcode','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(2048)','ASSISTENZA','didproganno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','didprogcurr_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','didprogori_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(2048)','ASSISTENZA','didprogporzanno_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','varchar(273)','ASSISTENZA','dropdown_title','273','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idattivform','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idcanale','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','canaleerogataview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','canaleerogataview','varchar(256)','ASSISTENZA','title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI canaleerogataview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'canaleerogataview')
UPDATE customobject set isreal = 'N' where objectname = 'canaleerogataview'
ELSE
INSERT INTO customobject (objectname, isreal) values('canaleerogataview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

