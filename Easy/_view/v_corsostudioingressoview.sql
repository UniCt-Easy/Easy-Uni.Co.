
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
-- CREAZIONE VISTA corsostudioingressoview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[corsostudioingressoview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[corsostudioingressoview]
GO

CREATE VIEW [dbo].[corsostudioingressoview] AS SELECT CASE WHEN corsostudio.almalaureasurvey = 'S' THEN 'Si' WHEN corsostudio.almalaureasurvey = 'N' THEN 'No' END AS corsostudio_almalaureasurvey, corsostudio.annoistituz AS corsostudio_annoistituz, corsostudio.basevoto AS corsostudio_basevoto, corsostudio.codice AS corsostudio_codice, corsostudio.codicemiur AS corsostudio_codicemiur, corsostudio.codicemiurlungo AS corsostudio_codicemiurlungo, corsostudio.crediti AS corsostudio_crediti, corsostudio.ct AS corsostudio_ct, corsostudio.cu AS corsostudio_cu, corsostudio.durata AS corsostudio_durata, corsostudio.idcorsostudio, corsostudio.idcorsostudiokind AS corsostudio_idcorsostudiokind, corsostudio.idcorsostudiolivello AS corsostudio_idcorsostudiolivello, corsostudio.idcorsostudionorma AS corsostudio_idcorsostudionorma, corsostudio.idduratakind AS corsostudio_idduratakind, [dbo].struttura.title AS struttura_title, [dbo].strutturakind.title AS strutturakind_title, corsostudio.idstruttura, corsostudio.lt AS corsostudio_lt, corsostudio.lu AS corsostudio_lu, corsostudio.obbform AS corsostudio_obbform, corsostudio.sboccocc AS corsostudio_sboccocc, corsostudio.title, corsostudio.title_en AS corsostudio_title_en,(select top 1 aa 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_aa,
						(select top 1 iddidprognumchiusokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprognumchiusokind,
						(select top 1 iddidprogsuddannokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_iddidprogsuddannokind,
						(select top 1 idgraduatoria 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idgraduatoria,
						(select top 1 idnation_lang 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang,
						(select top 1 idnation_lang2 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_lang2,
						(select top 1 idnation_langvis 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idnation_langvis,
						(select top 1 idsede 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsede,
						(select top 1 idsessione 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as idsessione,
						(select top 1 idtitolokind 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_idtitolokind,
						(select top 1 CASE WHEN didprog.immatoltreauth = 'S' THEN 'Si' WHEN didprog.immatoltreauth = 'N' THEN 'No' END AS didprog_immatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_immatoltreauth,
						(select top 1 modaccesso 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso,
						(select top 1 modaccesso_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_modaccesso_en,
						(select top 1 CASE WHEN didprog.preimmatoltreauth = 'S' THEN 'Si' WHEN didprog.preimmatoltreauth = 'N' THEN 'No' END AS didprog_preimmatoltreauth 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_preimmatoltreauth,
						(select top 1 progesamamm 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_progesamamm,
						(select top 1 provafinaledesc 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_provafinaledesc,
						(select top 1 regolamentotax 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotax,
						(select top 1 regolamentotaxurl 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_regolamentotaxurl,
						(select top 1 startiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_startiscrizioni,
						(select top 1 stopiscrizioni 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_stopiscrizioni,
						(select top 1 title 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title,
						(select top 1 title_en 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_title_en,
						(select top 1 utenzasost 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_utenzasost,
						(select top 1 website 
						from dbo.didprog 
						where dbo.didprog.idcorsostudio = corsostudio.idcorsostudio
						 order by didprog.title asc ) as didprog_website, isnull('Denominazione: ' + corsostudio.title + '; ','') + ' ' + isnull('Tipologia Tipologia: ' + [dbo].strutturakind.title + '; ','') as dropdown_title FROM [dbo].corsostudio WITH (NOLOCK)  LEFT OUTER JOIN [dbo].struttura WITH (NOLOCK) ON corsostudio.idstruttura = [dbo].struttura.idstruttura LEFT OUTER JOIN [dbo].strutturakind WITH (NOLOCK) ON struttura.idstrutturakind = [dbo].strutturakind.idstrutturakind WHERE  corsostudio.idcorsostudio IS NOT NULL  AND corsostudio.idcorsostudiokind = 12
GO

-- VERIFICA DI corsostudioingressoview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'corsostudioingressoview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(2)','ASSISTENZA','corsostudio_almalaureasurvey','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_basevoto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(50)','ASSISTENZA','corsostudio_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(10)','ASSISTENZA','corsostudio_codicemiur','10','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(50)','ASSISTENZA','corsostudio_codicemiurlungo','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_crediti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','datetime','ASSISTENZA','corsostudio_ct','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','varchar(64)','ASSISTENZA','corsostudio_cu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_durata','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','int','ASSISTENZA','corsostudio_idcorsostudiokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_idcorsostudiolivello','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_idcorsostudionorma','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','corsostudio_idduratakind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','datetime','ASSISTENZA','corsostudio_lt','8','S','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','varchar(64)','ASSISTENZA','corsostudio_lu','64','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','corsostudio_obbform','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','corsostudio_sboccocc','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(1024)','ASSISTENZA','corsostudio_title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(9)','ASSISTENZA','didprog_aa','9','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','didprog_iddidprognumchiusokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','didprog_iddidprogsuddannokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','didprog_idtitolokind','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(2)','ASSISTENZA','didprog_immatoltreauth','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','didprog_modaccesso','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','didprog_modaccesso_en','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(2)','ASSISTENZA','didprog_preimmatoltreauth','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','didprog_progesamamm','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','didprog_provafinaledesc','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','nvarchar(max)','ASSISTENZA','didprog_regolamentotax','0','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(512)','ASSISTENZA','didprog_regolamentotaxurl','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','datetime','ASSISTENZA','didprog_startiscrizioni','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','datetime','ASSISTENZA','didprog_stopiscrizioni','8','N','datetime','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(1024)','ASSISTENZA','didprog_title_en','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','didprog_utenzasost','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(512)','ASSISTENZA','didprog_website','512','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','varchar(1115)','ASSISTENZA','dropdown_title','1115','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','corsostudioingressoview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idgraduatoria','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idnation_lang','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idnation_lang2','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idnation_langvis','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idsede','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idsessione','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','int','ASSISTENZA','idstruttura','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(1024)','ASSISTENZA','struttura_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(50)','','strutturakind_title','50','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','corsostudioingressoview','varchar(1024)','ASSISTENZA','title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI corsostudioingressoview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'corsostudioingressoview')
UPDATE customobject set isreal = 'N' where objectname = 'corsostudioingressoview'
ELSE
INSERT INTO customobject (objectname, isreal) values('corsostudioingressoview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

