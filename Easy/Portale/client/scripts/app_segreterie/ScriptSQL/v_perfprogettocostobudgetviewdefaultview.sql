
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


-- CREAZIONE VISTA perfprogettocostobudgetviewdefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[perfprogettocostobudgetviewdefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [perfprogettocostobudgetviewdefaultview]
GO

CREATE VIEW [perfprogettocostobudgetviewdefaultview] AS 
SELECT  perfprogettocostobudgetview.amount AS perfprogettocostobudgetview_amount, perfprogettocostobudgetview.amount2 AS perfprogettocostobudgetview_amount2, perfprogettocostobudgetview.amount3 AS perfprogettocostobudgetview_amount3, perfprogettocostobudgetview.amount4 AS perfprogettocostobudgetview_amount4, perfprogettocostobudgetview.amount5 AS perfprogettocostobudgetview_amount5, perfprogettocostobudgetview.annotation AS perfprogettocostobudgetview_annotation, perfprogettocostobudgetview.ct AS perfprogettocostobudgetview_ct, perfprogettocostobudgetview.cu AS perfprogettocostobudgetview_cu, perfprogettocostobudgetview.description, perfprogettocostobudgetview.idacc AS perfprogettocostobudgetview_idacc, perfprogettocostobudgetview.idaccmotive AS perfprogettocostobudgetview_idaccmotive, perfprogettocostobudgetview.idcostpartition AS perfprogettocostobudgetview_idcostpartition, perfprogettocostobudgetview.idinv AS perfprogettocostobudgetview_idinv, perfprogettocostobudgetview.idsor1 AS perfprogettocostobudgetview_idsor1, perfprogettocostobudgetview.idsor2 AS perfprogettocostobudgetview_idsor2, perfprogettocostobudgetview.idsor3 AS perfprogettocostobudgetview_idsor3, perfprogettocostobudgetview.idupb AS perfprogettocostobudgetview_idupb, perfprogettocostobudgetview.lt AS perfprogettocostobudgetview_lt, perfprogettocostobudgetview.lu AS perfprogettocostobudgetview_lu, perfprogettocostobudgetview.nvar, perfprogettocostobudgetview.prevcassa AS perfprogettocostobudgetview_prevcassa, perfprogettocostobudgetview.rownum,CASE WHEN perfprogettocostobudgetview.underwritingkind = 'S' THEN 'Si' WHEN perfprogettocostobudgetview.underwritingkind = 'N' THEN 'No' END AS perfprogettocostobudgetview_underwritingkind, perfprogettocostobudgetview.underwritingkind_desc AS perfprogettocostobudgetview_underwritingkind_desc, perfprogettocostobudgetview.yvar,
 isnull('Descrizione: ' + perfprogettocostobudgetview.description + '; ','') + ' ' + isnull('Annotazioni: ' + perfprogettocostobudgetview.annotation + '; ','') as dropdown_title
FROM perfprogettocostobudgetview WITH (NOLOCK) 
WHERE  perfprogettocostobudgetview.nvar IS NOT NULL  AND perfprogettocostobudgetview.rownum IS NOT NULL  AND perfprogettocostobudgetview.yvar IS NOT NULL 
GO

-- VERIFICA DI perfprogettocostobudgetviewdefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettocostobudgetviewdefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','varchar(150)','ASSISTENZA','description','150','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(581)','ASSISTENZA','dropdown_title','581','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','int','','nvar','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_amount','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_amount2','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_amount3','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_amount4','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_amount5','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','varchar(400)','ASSISTENZA','perfprogettocostobudgetview_annotation','400','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','datetime','ASSISTENZA','perfprogettocostobudgetview_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(64)','ASSISTENZA','perfprogettocostobudgetview_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(38)','','perfprogettocostobudgetview_idacc','38','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(36)','','perfprogettocostobudgetview_idaccmotive','36','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','int','','perfprogettocostobudgetview_idcostpartition','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','int','','perfprogettocostobudgetview_idinv','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','int','ASSISTENZA','perfprogettocostobudgetview_idsor1','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','int','ASSISTENZA','perfprogettocostobudgetview_idsor2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','int','ASSISTENZA','perfprogettocostobudgetview_idsor3','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(36)','','perfprogettocostobudgetview_idupb','36','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','datetime','ASSISTENZA','perfprogettocostobudgetview_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','varchar(64)','ASSISTENZA','perfprogettocostobudgetview_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','decimal(19,2)','ASSISTENZA','perfprogettocostobudgetview_prevcassa','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','varchar(2)','ASSISTENZA','perfprogettocostobudgetview_underwritingkind','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettocostobudgetviewdefaultview','varchar(69)','','perfprogettocostobudgetview_underwritingkind_desc','69','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','int','','rownum','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettocostobudgetviewdefaultview','int','','yvar','4','S','int','System.Int32','','','','','N')
GO

-- VERIFICA DI perfprogettocostobudgetviewdefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettocostobudgetviewdefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'perfprogettocostobudgetviewdefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettocostobudgetviewdefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

