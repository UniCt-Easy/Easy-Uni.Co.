
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


-- CREAZIONE VISTA flowchartsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[flowchartsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [flowchartsegview]
GO

CREATE VIEW [flowchartsegview] AS 
SELECT  flowchart.address AS flowchart_address, flowchart.ayear AS flowchart_ayear, flowchart.cap AS flowchart_cap, flowchart.codeflowchart, flowchart.ct AS flowchart_ct, flowchart.cu AS flowchart_cu, flowchart.fax AS flowchart_fax, flowchart.idcity AS flowchart_idcity, flowchart.idflowchart, flowchart.idsor1 AS flowchart_idsor1, flowchart.idsor2 AS flowchart_idsor2, flowchart.idsor3 AS flowchart_idsor3, flowchart.location AS flowchart_location, flowchart.lt AS flowchart_lt, flowchart.lu AS flowchart_lu, flowchart.nlevel AS flowchart_nlevel,
 flowchartparent.codeflowchart AS flowchartparent_codeflowchart, flowchartparent.title AS flowchartparent_title, flowchart.paridflowchart, flowchart.phone AS flowchart_phone, flowchart.printingorder AS flowchart_printingorder, flowchart.title AS flowchart_title,
 isnull('Codice: ' + flowchart.codeflowchart + '; ','') + ' ' + isnull('Denominazione: ' + flowchart.title + '; ','') as dropdown_title
FROM flowchart WITH (NOLOCK) 
LEFT OUTER JOIN flowchart AS flowchartparent WITH (NOLOCK) ON flowchart.paridflowchart = flowchartparent.idflowchart
WHERE  flowchart.ayear = YEAR(GETDATE()) AND flowchart.idflowchart IS NOT NULL 
GO

-- VERIFICA DI flowchartsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'flowchartsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(50)','ASSISTENZA','codeflowchart','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(228)','ASSISTENZA','dropdown_title','228','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(100)','ASSISTENZA','flowchart_address','100','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','int','ASSISTENZA','flowchart_ayear','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(20)','ASSISTENZA','flowchart_cap','20','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','datetime','ASSISTENZA','flowchart_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(64)','ASSISTENZA','flowchart_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(75)','ASSISTENZA','flowchart_fax','75','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','int','ASSISTENZA','flowchart_idcity','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','int','ASSISTENZA','flowchart_idsor1','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','int','ASSISTENZA','flowchart_idsor2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','int','ASSISTENZA','flowchart_idsor3','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(50)','ASSISTENZA','flowchart_location','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','datetime','ASSISTENZA','flowchart_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(64)','ASSISTENZA','flowchart_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','int','ASSISTENZA','flowchart_nlevel','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(55)','ASSISTENZA','flowchart_phone','55','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(50)','ASSISTENZA','flowchart_printingorder','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(150)','ASSISTENZA','flowchart_title','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(50)','ASSISTENZA','flowchartparent_codeflowchart','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','flowchartsegview','varchar(150)','ASSISTENZA','flowchartparent_title','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(34)','ASSISTENZA','idflowchart','34','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','flowchartsegview','varchar(34)','ASSISTENZA','paridflowchart','34','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI flowchartsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'flowchartsegview')
UPDATE customobject set isreal = 'N' where objectname = 'flowchartsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('flowchartsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

