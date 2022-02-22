
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
-- CREAZIONE VISTA didprogporzannodefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[didprogporzannodefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[didprogporzannodefaultview]
GO

CREATE VIEW [dbo].[didprogporzannodefaultview] AS SELECT  didprogporzanno.aa, didprogporzanno.ct AS didprogporzanno_ct, didprogporzanno.cu AS didprogporzanno_cu, didprogporzanno.idcorsostudio, didprogporzanno.iddidprog, didprogporzanno.iddidproganno, didprogporzanno.iddidprogcurr, didprogporzanno.iddidprogori, didprogporzanno.iddidprogporzanno, [dbo].didprogporzannokind.title AS didprogporzannokind_title, didprogporzanno.iddidprogporzannokind AS didprogporzanno_iddidprogporzannokind, didprogporzanno.indice AS didprogporzanno_indice, didprogporzanno.lt AS didprogporzanno_lt, didprogporzanno.lu AS didprogporzanno_lu, didprogporzanno.start AS didprogporzanno_start, didprogporzanno.stop AS didprogporzanno_stop, didprogporzanno.title, isnull('Porzione d''anno: ' + didprogporzanno.title + '; ','') as dropdown_title FROM [dbo].didprogporzanno WITH (NOLOCK)  LEFT OUTER JOIN [dbo].didprogporzannokind WITH (NOLOCK) ON didprogporzanno.iddidprogporzannokind = [dbo].didprogporzannokind.iddidprogporzannokind WHERE  didprogporzanno.aa IS NOT NULL  AND didprogporzanno.idcorsostudio IS NOT NULL  AND didprogporzanno.iddidprog IS NOT NULL  AND didprogporzanno.iddidproganno IS NOT NULL  AND didprogporzanno.iddidprogcurr IS NOT NULL  AND didprogporzanno.iddidprogori IS NOT NULL  AND didprogporzanno.iddidprogporzanno IS NOT NULL 
GO

-- VERIFICA DI didprogporzannodefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'didprogporzannodefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','datetime','ASSISTENZA','didprogporzanno_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','varchar(64)','ASSISTENZA','didprogporzanno_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','int','ASSISTENZA','didprogporzanno_iddidprogporzannokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','int','ASSISTENZA','didprogporzanno_indice','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','datetime','ASSISTENZA','didprogporzanno_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','varchar(64)','ASSISTENZA','didprogporzanno_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','date','ASSISTENZA','didprogporzanno_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','date','ASSISTENZA','didprogporzanno_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','varchar(50)','ASSISTENZA','didprogporzannokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','varchar(2067)','ASSISTENZA','dropdown_title','2067','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','iddidproganno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','iddidprogori','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','didprogporzannodefaultview','int','ASSISTENZA','iddidprogporzanno','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','didprogporzannodefaultview','varchar(2048)','ASSISTENZA','title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI didprogporzannodefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'didprogporzannodefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'didprogporzannodefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('didprogporzannodefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

