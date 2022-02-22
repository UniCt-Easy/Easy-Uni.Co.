
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


-- CREAZIONE VISTA pcscessazioniview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[pcscessazioniview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[pcscessazioniview]
GO


CREATE VIEW dbo.pcscessazioniview
AS
SELECT registry.title, dbo.contratto.stop AS data, ROW_NUMBER() OVER (order by idcontratto) AS idpcscessazioniview, dbo.analisiannuale.idanalisiannuale, dbo.contratto.ct, dbo.contratto.cu, dbo.contratto.lt, dbo.contratto.lu
FROM     dbo.contratto INNER JOIN
                  dbo.analisiannuale ON YEAR(dbo.contratto.stop) >= dbo.analisiannuale.year
inner join registry on registry.idreg = contratto.idreg



GO

-- VERIFICA DI pcscessazioniview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'pcscessazioniview'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','datetime','assistenza','ct','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','varchar(64)','assistenza','cu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcscessazioniview','date','assistenza','data','3','N','date','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','int','assistenza','idanalisiannuale','4','S','int','System.Int32','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','pcscessazioniview','bigint','assistenza','idpcscessazioniview','8','N','bigint','System.Int64','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','datetime','assistenza','lt','8','S','datetime','System.DateTime','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','varchar(64)','assistenza','lu','64','S','varchar','System.String','','','''assistenza''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','pcscessazioniview','varchar(101)','assistenza','title','101','S','varchar','System.String','','','''assistenza''','','N')
GO

-- VERIFICA DI pcscessazioniview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'pcscessazioniview')
UPDATE customobject set isreal = 'N' where objectname = 'pcscessazioniview'
ELSE
INSERT INTO customobject (objectname, isreal) values('pcscessazioniview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

