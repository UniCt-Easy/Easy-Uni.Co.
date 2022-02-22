
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


-- CREAZIONE VISTA getcostididatticadefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[getcostididatticadefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcostididatticadefaultview]
GO

CREATE VIEW [getcostididatticadefaultview] AS 
SELECT  getcostididattica.aa, getcostididattica.aaprogrammata, getcostididattica.affidamento AS getcostididattica_affidamento, getcostididattica.corsostudio AS getcostididattica_corsostudio, getcostididattica.costo AS getcostididattica_costo, getcostididattica.costoorariodacontratto AS getcostididattica_costoorariodacontratto, getcostididattica.curriculum AS getcostididattica_curriculum, getcostididattica.docente AS getcostididattica_docente, getcostididattica.idaffidamento,
 [dbo].affidamentokind.title AS affidamentokind_title, getcostididattica.idaffidamentokind AS getcostididattica_idaffidamentokind,
 [dbo].contrattokind.title AS contrattokind_title, getcostididattica.idcontrattokind,
 [dbo].corsostudio.title AS corsostudio_title, [dbo].corsostudio.annoistituz AS corsostudio_annoistituz, getcostididattica.idcorsostudio,
 [dbo].didprog.title AS didprog_title, [dbo].didprog.aa AS didprog_aa, [dbo].sede.title AS sede_title, [dbo].didprog.idsede AS didprog_idsede, getcostididattica.iddidprog,
 [dbo].didprogcurr.title AS didprogcurr_title, getcostididattica.iddidprogcurr,
 [dbo].insegn.denominazione AS insegn_denominazione, [dbo].insegn.codice AS insegn_codice, getcostididattica.idinsegn,
 [dbo].insegninteg.denominazione AS insegninteg_denominazione, [dbo].insegninteg.codice AS insegninteg_codice, getcostididattica.idinsegninteg,
 registrydocenti.title AS registrydocenti_title, getcostididattica.idreg_docenti,
 sede_getcostididattica.title AS sede_getcostididattica_title, getcostididattica.idsede, getcostididattica.insegnamento AS getcostididattica_insegnamento, getcostididattica.modulo AS getcostididattica_modulo, getcostididattica.ruolo AS getcostididattica_ruolo, getcostididattica.sede AS getcostididattica_sede
FROM getcostididattica WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].affidamentokind WITH (NOLOCK) ON getcostididattica.idaffidamentokind = [dbo].affidamentokind.idaffidamentokind
LEFT OUTER JOIN [dbo].contrattokind WITH (NOLOCK) ON getcostididattica.idcontrattokind = [dbo].contrattokind.idcontrattokind
LEFT OUTER JOIN [dbo].corsostudio WITH (NOLOCK) ON getcostididattica.idcorsostudio = [dbo].corsostudio.idcorsostudio
LEFT OUTER JOIN [dbo].didprog WITH (NOLOCK) ON getcostididattica.iddidprog = [dbo].didprog.iddidprog
LEFT OUTER JOIN [dbo].sede WITH (NOLOCK) ON [dbo].didprog.idsede = [dbo].sede.idsede
LEFT OUTER JOIN [dbo].didprogcurr WITH (NOLOCK) ON getcostididattica.iddidprogcurr = [dbo].didprogcurr.iddidprogcurr
LEFT OUTER JOIN [dbo].insegn WITH (NOLOCK) ON getcostididattica.idinsegn = [dbo].insegn.idinsegn
LEFT OUTER JOIN [dbo].insegninteg WITH (NOLOCK) ON getcostididattica.idinsegninteg = [dbo].insegninteg.idinsegninteg
LEFT OUTER JOIN [dbo].registry_docenti AS registry_docentidocenti WITH (NOLOCK) ON getcostididattica.idreg_docenti = registry_docentidocenti.idreg
LEFT OUTER JOIN [dbo].registry AS registrydocenti WITH (NOLOCK) ON registry_docentidocenti.idreg = registrydocenti.idreg
LEFT OUTER JOIN [dbo].sede AS sede_getcostididattica WITH (NOLOCK) ON getcostididattica.idsede = sede_getcostididattica.idsede
WHERE  getcostididattica.aa IS NOT NULL  AND getcostididattica.idaffidamento IS NOT NULL  AND getcostididattica.idcontrattokind IS NOT NULL  AND getcostididattica.idcorsostudio IS NOT NULL  AND getcostididattica.iddidprog IS NOT NULL  AND getcostididattica.iddidprogcurr IS NOT NULL  AND getcostididattica.idsede IS NOT NULL 
GO

-- VERIFICA DI getcostididatticadefaultview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcostididatticadefaultview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','nvarchar(9)','ASSISTENZA','aaprogrammata','9','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(50)','ASSISTENZA','affidamentokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(50)','ASSISTENZA','contrattokind_title','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','int','ASSISTENZA','corsostudio_annoistituz','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(1024)','ASSISTENZA','corsostudio_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','nvarchar(9)','','didprog_aa','9','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','int','','didprog_idsede','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(1024)','ASSISTENZA','didprog_title','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','didprogcurr_title','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','nvarchar(1075)','ASSISTENZA','getcostididattica_affidamento','1075','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(1024)','ASSISTENZA','getcostididattica_corsostudio','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','decimal(38,2)','ASSISTENZA','getcostididattica_costo','17','N','decimal','System.Decimal','','2','''ASSISTENZA''','38','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','varchar(2)','ASSISTENZA','getcostididattica_costoorariodacontratto','2','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','getcostididattica_curriculum','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(101)','ASSISTENZA','getcostididattica_docente','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','getcostididattica_idaffidamentokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','getcostididattica_insegnamento','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','getcostididattica_modulo','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','varchar(50)','ASSISTENZA','getcostididattica_ruolo','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','nvarchar(1024)','ASSISTENZA','getcostididattica_sede','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','idaffidamento','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','idcontrattokind','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','idcorsostudio','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','iddidprog','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','iddidprogcurr','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','idinsegn','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','int','ASSISTENZA','idinsegninteg','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','int','ASSISTENZA','idreg_docenti','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcostididatticadefaultview','int','ASSISTENZA','idsede','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(50)','ASSISTENZA','insegn_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','insegn_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(50)','ASSISTENZA','insegninteg_codice','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(256)','ASSISTENZA','insegninteg_denominazione','256','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','varchar(101)','ASSISTENZA','registrydocenti_title','101','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','nvarchar(1024)','','sede_getcostididattica_title','1024','N','nvarchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcostididatticadefaultview','nvarchar(1024)','ASSISTENZA','sede_title','1024','N','nvarchar','System.String','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getcostididatticadefaultview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcostididatticadefaultview')
UPDATE customobject set isreal = 'N' where objectname = 'getcostididatticadefaultview'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcostididatticadefaultview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

