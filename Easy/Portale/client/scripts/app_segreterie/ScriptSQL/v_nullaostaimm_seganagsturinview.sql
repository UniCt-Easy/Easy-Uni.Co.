
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


-- CREAZIONE VISTA nullaostaimm_seganagsturinview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[nullaostaimm_seganagsturinview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[nullaostaimm_seganagsturinview]
GO

CREATE VIEW [dbo].[nullaostaimm_seganagsturinview] AS 
SELECT  nullaosta.ct AS nullaosta_ct, nullaosta.cu AS nullaosta_cu, nullaosta.data, nullaosta.extension AS nullaosta_extension, nullaosta.idcorsostudio, nullaosta.iddidprog, nullaosta.idiscrizione AS nullaosta_idiscrizione, nullaosta.idistanza, nullaosta.idistanzakind, nullaosta.idnullaosta, nullaosta.idreg, nullaosta.lt AS nullaosta_lt, nullaosta.lu AS nullaosta_lu, nullaosta.protanno AS nullaosta_protanno, nullaosta.protnumero AS nullaosta_protnumero, nullaosta_imm.annoimm AS nullaosta_imm_annoimm, nullaosta_imm.ct AS nullaosta_imm_ct, nullaosta_imm.cu AS nullaosta_imm_cu, nullaosta_imm.idcorsostudio AS nullaosta_imm_idcorsostudio, nullaosta_imm.iddidprog AS nullaosta_imm_iddidprog,
 [dbo].didprogcurr.title AS didprogcurr_title, nullaosta_imm.iddidprogcurr AS nullaosta_imm_iddidprogcurr,
 [dbo].didprogori.title AS didprogori_title, nullaosta_imm.iddidprogori AS nullaosta_imm_iddidprogori, nullaosta_imm.idistanza AS nullaosta_imm_idistanza, nullaosta_imm.idistanzakind AS nullaosta_imm_idistanzakind, nullaosta_imm.idnullaosta AS nullaosta_imm_idnullaosta, nullaosta_imm.idreg AS nullaosta_imm_idreg, nullaosta_imm.lt AS nullaosta_imm_lt, nullaosta_imm.lu AS nullaosta_imm_lu,CASE WHEN nullaosta_imm.parttime = 'S' THEN 'Si' WHEN nullaosta_imm.parttime = 'N' THEN 'No' END AS nullaosta_imm_parttime,
 isnull('del ' + CONVERT(VARCHAR, nullaosta.data, 103),'') + ' ' + isnull('all''anno di corso : ' + CAST( nullaosta_imm.annoimm AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM [dbo].nullaosta WITH (NOLOCK) 
INNER JOIN nullaosta_imm WITH (NOLOCK) ON nullaosta.idistanza = nullaosta_imm.idistanza AND nullaosta.idistanzakind = nullaosta_imm.idistanzakind AND nullaosta.idnullaosta = nullaosta_imm.idnullaosta AND nullaosta.idreg = nullaosta_imm.idreg
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON nullaosta_imm.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].didprogori WITH (NOLOCK) ON nullaosta_imm.iddidprogori = [dbo].didprogori.iddidprogori
WHERE  nullaosta.idcorsostudio IS NOT NULL  AND nullaosta.iddidprog IS NOT NULL  AND nullaosta.idistanza IS NOT NULL  AND nullaosta.idistanzakind IS NOT NULL  AND nullaosta.idnullaosta IS NOT NULL  AND nullaosta.idreg IS NOT NULL  AND nullaosta_imm.idcorsostudio IS NOT NULL  AND nullaosta_imm.iddidprog IS NOT NULL  AND nullaosta_imm.idistanza IS NOT NULL  AND nullaosta_imm.idistanzakind IS NOT NULL  AND nullaosta_imm.idnullaosta IS NOT NULL  AND nullaosta_imm.idreg IS NOT NULL 
GO

-- VERIFICA DI nullaostaimm_seganagsturinview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'nullaostaimm_seganagsturinview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','datetime','ASSISTENZA','data','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','varchar(256)','ASSISTENZA','didprogcurr_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','varchar(256)','ASSISTENZA','didprogori_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','nvarchar(121)','ASSISTENZA','dropdown_title','121','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','idnullaosta','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','datetime','ASSISTENZA','nullaosta_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','varchar(64)','ASSISTENZA','nullaosta_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','varchar(200)','ASSISTENZA','nullaosta_extension','200','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_idiscrizione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_annoimm','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','datetime','ASSISTENZA','nullaosta_imm_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','varchar(64)','ASSISTENZA','nullaosta_imm_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_idcorsostudio','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_iddidprog','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_iddidprogcurr','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_iddidprogori','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_idistanza','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_idistanzakind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_idnullaosta','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_imm_idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','datetime','ASSISTENZA','nullaosta_imm_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','varchar(64)','ASSISTENZA','nullaosta_imm_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','varchar(2)','ASSISTENZA','nullaosta_imm_parttime','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','datetime','ASSISTENZA','nullaosta_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','nullaostaimm_seganagsturinview','varchar(64)','ASSISTENZA','nullaosta_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_protanno','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','nullaostaimm_seganagsturinview','int','ASSISTENZA','nullaosta_protnumero','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI nullaostaimm_seganagsturinview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'nullaostaimm_seganagsturinview')
UPDATE customobject set isreal = 'N' where objectname = 'nullaostaimm_seganagsturinview'
ELSE
INSERT INTO customobject (objectname, isreal) values('nullaostaimm_seganagsturinview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

