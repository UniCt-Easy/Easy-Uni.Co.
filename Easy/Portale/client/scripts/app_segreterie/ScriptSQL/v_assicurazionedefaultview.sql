
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
-- CREAZIONE VISTA assicurazionedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[assicurazionedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[assicurazionedefaultview]
GO

CREATE VIEW [dbo].[assicurazionedefaultview] AS SELECT  assicurazione.ct AS assicurazione_ct, assicurazione.cu AS assicurazione_cu, assicurazione.datarilascio AS assicurazione_datarilascio, assicurazione.datascadenza AS assicurazione_datascadenza, assicurazione.idassicurazione, [dbo].attach.filename AS attach_filename, assicurazione.idattach,CASE WHEN assicurazione.infortunisullavoro = 'S' THEN 'Si' WHEN assicurazione.infortunisullavoro = 'N' THEN 'No' END AS assicurazione_infortunisullavoro, assicurazione.lt AS assicurazione_lt, assicurazione.lu AS assicurazione_lu, assicurazione.numeropolizza AS assicurazione_numeropolizza,CASE WHEN assicurazione.rca = 'S' THEN 'Si' WHEN assicurazione.rca = 'N' THEN 'No' END AS assicurazione_rca, assicurazione.societaassicura,CASE WHEN assicurazione.spostamenti = 'S' THEN 'Si' WHEN assicurazione.spostamenti = 'N' THEN 'No' END AS assicurazione_spostamenti,CASE WHEN assicurazione.viaggi = 'S' THEN 'Si' WHEN assicurazione.viaggi = 'N' THEN 'No' END AS assicurazione_viaggi, isnull('Società assicurativa: ' + assicurazione.societaassicura + '; ','') + ' ' + isnull('scadenza ' + CONVERT(VARCHAR, assicurazione.datascadenza, 103),'') as dropdown_title FROM [dbo].assicurazione WITH (NOLOCK)  LEFT OUTER JOIN [dbo].attach WITH (NOLOCK) ON assicurazione.idattach = [dbo].attach.idattach WHERE  assicurazione.idassicurazione IS NOT NULL 
GO

-- VERIFICA DI assicurazionedefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'assicurazionedefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','datetime','ASSISTENZA','assicurazione_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','varchar(64)','ASSISTENZA','assicurazione_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','date','ASSISTENZA','assicurazione_datarilascio','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','date','ASSISTENZA','assicurazione_datascadenza','3','N','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(2)','ASSISTENZA','assicurazione_infortunisullavoro','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','datetime','ASSISTENZA','assicurazione_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','varchar(64)','ASSISTENZA','assicurazione_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(50)','ASSISTENZA','assicurazione_numeropolizza','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(2)','ASSISTENZA','assicurazione_rca','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(2)','ASSISTENZA','assicurazione_spostamenti','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(2)','ASSISTENZA','assicurazione_viaggi','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(512)','ASSISTENZA','attach_filename','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','varchar(1088)','ASSISTENZA','dropdown_title','1088','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','assicurazionedefaultview','int','ASSISTENZA','idassicurazione','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','int','ASSISTENZA','idattach','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','assicurazionedefaultview','varchar(1024)','ASSISTENZA','societaassicura','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI assicurazionedefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'assicurazionedefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'assicurazionedefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('assicurazionedefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

