
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


-- CREAZIONE VISTA upbsegview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbsegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbsegview]
GO



CREATE VIEW [upbsegview] AS SELECT CASE WHEN upb.active = 'S' THEN 'Si' WHEN upb.active = 'N' THEN 'No' END AS upb_active,CASE WHEN upb.assured = 'S' THEN 'Si' WHEN upb.assured = 'N' THEN 'No' END AS upb_assured, upb.cigcode AS upb_cigcode, upb.codeupb, upb.cofogmpcode AS upb_cofogmpcode, upb.ct AS upb_ct, upb.cu AS upb_cu, upb.cupcode AS upb_cupcode, upb.expiration AS upb_expiration, upb.flag AS upb_flag, upb.flagactivity AS upb_flagactivity, upb.flagkind AS upb_flagkind, upb.granted AS upb_granted, upb.idepupbkind AS upb_idepupbkind, upb.idtreasurer AS upb_idtreasurer, upb.idunderwriter AS upb_idunderwriter, upb.idupb, upb.idupb_capofila AS upb_idupb_capofila, upb.lt AS upb_lt, upb.lu AS upb_lu, upb.newcodeupb AS upb_newcodeupb, upb.paridupb AS upb_paridupb, upb.previousappropriation AS upb_previousappropriation, upb.previousassessment AS upb_previousassessment, upb.printingorder AS upb_printingorder, upb.requested AS upb_requested, upb.ri_ra_quota AS upb_ri_ra_quota, upb.ri_rb_quota AS upb_ri_rb_quota, upb.ri_sa_quota AS upb_ri_sa_quota, upb.rtf AS upb_rtf, upb.start AS upb_start, upb.stop AS upb_stop, upb.title AS upb_title, upb.txt AS upb_txt, upb.uesiopecode AS upb_uesiopecode, isnull('Codice: ' + upb.codeupb + '; ','') + ' ' + isnull('Denominazione: ' + upb.title + '; ','') as dropdown_title FROM upb WITH (NOLOCK)  WHERE  upb.idupb IS NOT NULL 

GO

-- VERIFICA DI upbsegview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'upbsegview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(50)','ASSISTENZA','codeupb','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(228)','ASSISTENZA','dropdown_title','228','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(36)','ASSISTENZA','idupb','36','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(2)','ASSISTENZA','upb_active','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(2)','ASSISTENZA','upb_assured','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(10)','ASSISTENZA','upb_cigcode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(10)','ASSISTENZA','upb_cofogmpcode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','datetime','ASSISTENZA','upb_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(64)','ASSISTENZA','upb_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(15)','ASSISTENZA','upb_cupcode','15','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','date','ASSISTENZA','upb_expiration','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','int','ASSISTENZA','upb_flag','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','smallint','ASSISTENZA','upb_flagactivity','2','N','smallint','System.Int16','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','tinyint','ASSISTENZA','upb_flagkind','1','N','tinyint','System.Byte','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,2)','ASSISTENZA','upb_granted','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','int','ASSISTENZA','upb_idepupbkind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','int','ASSISTENZA','upb_idtreasurer','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','int','ASSISTENZA','upb_idunderwriter','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(36)','ASSISTENZA','upb_idupb_capofila','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','datetime','ASSISTENZA','upb_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(64)','ASSISTENZA','upb_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(50)','ASSISTENZA','upb_newcodeupb','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(36)','ASSISTENZA','upb_paridupb','36','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,2)','ASSISTENZA','upb_previousappropriation','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,2)','ASSISTENZA','upb_previousassessment','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(50)','ASSISTENZA','upb_printingorder','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,2)','ASSISTENZA','upb_requested','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,6)','ASSISTENZA','upb_ri_ra_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,6)','ASSISTENZA','upb_ri_rb_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','decimal(19,6)','ASSISTENZA','upb_ri_sa_quota','9','N','decimal','System.Decimal','','6','''ASSISTENZA''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','image','ASSISTENZA','upb_rtf','16','N','image','System.Byte[]','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','date','ASSISTENZA','upb_start','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','date','ASSISTENZA','upb_stop','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','upbsegview','varchar(150)','ASSISTENZA','upb_title','150','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','text','ASSISTENZA','upb_txt','16','N','text','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','upbsegview','varchar(10)','ASSISTENZA','upb_uesiopecode','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI upbsegview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'upbsegview')
UPDATE customobject set isreal = 'N' where objectname = 'upbsegview'
ELSE
INSERT INTO customobject (objectname, isreal) values('upbsegview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --
