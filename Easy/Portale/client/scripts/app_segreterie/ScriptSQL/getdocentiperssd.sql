
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


-- CREAZIONE VISTA getdocentiperssd
IF EXISTS(select * from sysobjects where id = object_id(N'[getdocentiperssd]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getdocentiperssd]
GO


CREATE VIEW [Amministrazione].[getdocentiperssd]
AS
SELECT
	dbo.registry.idreg, 
	dbo.registry.surname AS cognome, 
	dbo.registry.forename AS nome, 
	dbo.registry_docenti.matricola AS matricola, 
	dbo.sasd.idsasd, 
	dbo.sasd.codice AS ssd, 
	dbo.struttura.title AS struttura,
	c.title as contratto,
	c.costoora  as costoorario,
	c.start  as iniziocontratto,
	isnull(c.stop,'20400101')  as terminecontratto,
	c.tempdef  as tempodefinito,
	c.parttime,
	oremaxdida,
	oremindida,
	o.aa,
	oreperaacontratto,
	oreperaaaffidamento
FROM dbo.registry 
INNER JOIN dbo.registry_docenti ON dbo.registry.idreg = dbo.registry_docenti.idreg 
INNER JOIN dbo.sasd ON dbo.registry_docenti.idsasd = dbo.sasd.idsasd
INNER JOIN dbo.struttura ON dbo.registry_docenti.idstruttura = dbo.struttura.idstruttura
inner join [Amministrazione].[GetOreAffidamentoPerAnno] o on o.idreg_docenti = dbo.registry.idreg
inner join [Amministrazione].[GetContratti] c on c.idreg = dbo.registry.idreg and c.start < SUBSTRING(o.aa,1,4) + '0831' AND isnull(c.stop,'20400101') > SUBSTRING(o.aa,6,4) + '0801' 
--order by Cognome, Nome, Matricola




GO

-- VERIFICA DI getdocentiperssd IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getdocentiperssd'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','varchar(9)','ASSISTENZA','aa','9','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','varchar(50)','ASSISTENZA','cognome','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','varchar(50)','ASSISTENZA','contratto','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','decimal(18,2)','ASSISTENZA','costoorario','9','N','decimal','System.Decimal','','2','''ASSISTENZA''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','int','ASSISTENZA','idreg','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','int','ASSISTENZA','idsasd','4','S','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','date','ASSISTENZA','iniziocontratto','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','varchar(50)','ASSISTENZA','matricola','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','varchar(50)','ASSISTENZA','nome','50','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','int','ASSISTENZA','oremaxdida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','int','ASSISTENZA','oremindida','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','int','ASSISTENZA','oreperaaaffidamento','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','int','ASSISTENZA','oreperaacontratto','4','N','int','System.Int32','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','decimal(5,2)','ASSISTENZA','parttime','5','N','decimal','System.Decimal','','2','''ASSISTENZA''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','varchar(50)','ASSISTENZA','ssd','50','S','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getdocentiperssd','varchar(1024)','ASSISTENZA','struttura','1024','N','varchar','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','char(1)','ASSISTENZA','tempodefinito','1','S','char','System.String','','','''ASSISTENZA''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getdocentiperssd','date','ASSISTENZA','terminecontratto','3','S','date','System.DateTime','','','''ASSISTENZA''','','N')
GO

-- VERIFICA DI getdocentiperssd IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getdocentiperssd')
UPDATE customobject set isreal = 'N' where objectname = 'getdocentiperssd'
ELSE
INSERT INTO customobject (objectname, isreal) values('getdocentiperssd', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

