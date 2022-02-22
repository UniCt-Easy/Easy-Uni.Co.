
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


-- CREAZIONE VISTA perfprogettoobiettivopersonaleview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[perfprogettoobiettivopersonaleview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[perfprogettoobiettivopersonaleview]
GO




























CREATE VIEW [dbo].[perfprogettoobiettivopersonaleview]
AS
SELECT distinct dbo.perfprogettoobiettivo.idperfprogetto, dbo.perfprogettoobiettivo.idperfprogettoobiettivo, dbo.perfprogettoobiettivo.title, dbo.perfprogettoobiettivo.description, dbo.perfprogettoobiettivo.peso, 
                  dbo.perfprogettoobiettivo.completamento, dbo.strutturakind.title as perfprogetto_strutturakind_title,  dbo.struttura.title perfprogetto_struttura_title, dbo.perfprogetto.idstruttura as idstruttura_perfprogetto, dbo.perfprogetto.title AS progetto_title, dbo.perfvalutazioneuo.idperfvalutazioneuo, dbo.perfvalutazioneuo.idstruttura
FROM     dbo.perfprogettoobiettivo INNER JOIN
                  dbo.perfprogetto ON dbo.perfprogettoobiettivo.idperfprogetto = dbo.perfprogetto.idperfprogetto 
				  INNER JOIN
                  dbo.perfvalutazioneuo ON dbo.perfprogetto.idstruttura <> dbo.perfvalutazioneuo.idstruttura AND YEAR(dbo.perfprogetto.datainizioprevista) <= dbo.perfvalutazioneuo.year AND YEAR(dbo.perfprogetto.datafineprevista) 
                  <= dbo.perfvalutazioneuo.year 
				  INNER JOIN
                  dbo.afferenza ON dbo.perfvalutazioneuo.idstruttura = dbo.afferenza.idstruttura AND dbo.perfvalutazioneuo.year >= YEAR(dbo.afferenza.start) AND dbo.perfvalutazioneuo.year <= YEAR(dbo.afferenza.stop) 
				  INNER JOIN
                  dbo.perfprogettouo ON dbo.perfprogetto.idperfprogetto = dbo.perfprogettouo.idperfprogetto 
				  INNER JOIN dbo.struttura ON dbo.perfprogetto.idstruttura = dbo.struttura.idstruttura
				  INNER JOIN dbo.strutturakind ON dbo.struttura.idstrutturakind = dbo.strutturakind.idstrutturakind
				  INNER JOIN
                  dbo.perfprogettouomembro ON dbo.perfprogettouo.idperfprogetto = dbo.perfprogettouomembro.idperfprogetto AND dbo.perfprogettouo.idperfprogettouo = dbo.perfprogettouomembro.idperfprogettouo AND 
                  dbo.afferenza.idreg = dbo.perfprogettouomembro.idreg














GO

-- VERIFICA DI perfprogettoobiettivopersonaleview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'perfprogettoobiettivopersonaleview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','decimal(19,2)','assistenza','completamento','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','varchar(max)','assistenza','description','-1','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivopersonaleview','int','assistenza','idperfprogetto','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivopersonaleview','int','assistenza','idperfprogettoobiettivo','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivopersonaleview','int','assistenza','idperfvalutazioneuo','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivopersonaleview','int','assistenza','idstruttura','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','int','assistenza','idstruttura_perfprogetto','4','N','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','varchar(1024)','Generator','perfprogetto_struttura_title','1024','N','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','perfprogettoobiettivopersonaleview','varchar(50)','Generator','perfprogetto_strutturakind_title','50','S','varchar','System.String','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','decimal(19,2)','assistenza','peso','9','N','decimal','System.Decimal','','2','''assistenza''','19','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','varchar(1024)','assistenza','progetto_title','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','perfprogettoobiettivopersonaleview','varchar(1024)','assistenza','title','1024','N','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI perfprogettoobiettivopersonaleview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'perfprogettoobiettivopersonaleview')
UPDATE customobject set isreal = 'N' where objectname = 'perfprogettoobiettivopersonaleview'
ELSE
INSERT INTO customobject (objectname, isreal) values('perfprogettoobiettivopersonaleview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

