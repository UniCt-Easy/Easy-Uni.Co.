
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


-- VERIFICA DI stipendiokinddefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'stipendiokinddefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','nvarchar(2228)','ASSISTENZA','dropdown_title','2228','S','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','int','ASSISTENZA','idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','int','ASSISTENZA','idinquadramento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','int','ASSISTENZA','idstipendiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','int','ASSISTENZA','inquadramento_idcontrattokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','varchar(2048)','ASSISTENZA','inquadramento_title','2048','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_assegnoaggiuntivo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','datetime','ASSISTENZA','stipendiokind_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','varchar(64)','ASSISTENZA','stipendiokind_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_elementoperequativo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_indennitadiateneo','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_indennitadiposizione','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_indintegrativaspeciale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_indvacancacontrattuale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_irap','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','datetime','ASSISTENZA','stipendiokind_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','stipendiokinddefaultview','varchar(64)','ASSISTENZA','stipendiokind_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_oneriprevidenzialicaricoente','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_retribuzione','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','nchar(10)','ASSISTENZA','stipendiokind_scatto','10','N','nchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','varchar(2)','ASSISTENZA','stipendiokind_tempdef','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_totaletredicesima','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','stipendiokinddefaultview','decimal(7,2)','ASSISTENZA','stipendiokind_tredicesimaindennitaintegrativaspeciale','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','7','N')
GO

-- VERIFICA DI stipendiokinddefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'stipendiokinddefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'stipendiokinddefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('stipendiokinddefaultview', 'N')
GO
