
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


--setuser 'amministrazione'
-- CREAZIONE VISTA getcontratti
IF EXISTS(select * from sysobjects where id = object_id(N'[getcontratti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcontratti]
GO


CREATE VIEW [getcontratti]
AS
SELECT        
	idcontratto,
	idreg, 
	idcontrattokind, 
	title, 
	oremaxgg, 
	parttime, 
	tempdef, 
	start, 
	stop,
	idinquadramento, 
	scatto,
	isnull(totale_stipendioannuo , isnull (totale_tabellastipendiale,isnull(totale_inquadramento,isnull(totale_tipologiacontrattuale,0)))) as costolordoannuo, 
	totale_tipologiacontrattuale,
	totale_inquadramento,
	totale_tabellastipendiale,
	totale_stipendioannuo,
	Cast(round(isnull(totale_stipendioannuo , isnull (totale_tabellastipendiale,isnull(totale_inquadramento,isnull(totale_tipologiacontrattuale,0))))/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((isnull(totale_stipendioannuo , isnull (totale_tabellastipendiale,isnull(totale_inquadramento,isnull(totale_tipologiacontrattuale,0))))/12),2,1) as decimal(18,2)) costomese,
	CASE WHEN isnull(tempdef,'N') = 'S' OR isnull(parttime,0)<100 THEN oremaxtempoparziale ELSE oremaxtempopieno END as oremax,
	CASE WHEN isnull(tempdef,'N') = 'S' OR isnull(parttime,0)<100 THEN oremaxdidatempoparziale ELSE oremaxdidatempopieno END as oremaxdida,
	CASE WHEN isnull(tempdef,'N') = 'S' OR isnull(parttime,0)<100 THEN oremindidatempoparziale ELSE oremindidatempopieno END as oremindida

FROM 
(SELECT 	c.idcontratto,
	c.idreg, 
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	c.parttime, 
	c.tempdef, 
	c.start, 
	c.stop,
	c.idinquadramento, 
	c.scatto,
	ck.costolordoannuo as totale_tipologiacontrattuale
	,ck.oremaxtempopieno
	,ck.oremaxtempoparziale
	,ck.oremaxdidatempoparziale 
	,ck.oremindidatempoparziale 
	,ck.oremaxdidatempopieno
	,ck.oremindidatempopieno
	,i.costolordoannuooneri as totale_inquadramento
	,s.totale as totale_tabellastipendiale 
	,(SELECT top 1 totale from stipendioannuo sa WHERE sa.idcontratto = c.idcontratto order by year desc) as totale_stipendioannuo 
FROM dbo.contrattokind ck 
INNER JOIN dbo.contratto c ON ck.idcontrattokind = c.idcontrattokind
left outer join inquadramento i on i.idinquadramento = c.idinquadramento AND i.idcontrattokind = c.idcontrattokind
left outer join stipendio s on s.idinquadramento = i.idinquadramento and (c.scatto = s.scatto OR c.classe = s.classe)
) j


GO


-- VERIFICA DI getcontratti IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'getcontratti'
INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','decimal(9,2)','','costolordoannuo','5','N','decimal','System.Decimal','','2','','9','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','decimal(18,2)','riccardotest','costomese','9','N','decimal','System.Decimal','','2','''riccardotest''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','decimal(18,2)','riccardotest','costoora','9','N','decimal','System.Decimal','','2','''riccardotest''','18','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','int','','idcontratto','4','S','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','int','riccardotest','idcontrattokind','4','S','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','riccardotest','idinquadramento','4','N','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','int','riccardotest','idreg','4','S','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','riccardotest','oremaxdida','4','N','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','','oremaxgg','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','','oremax','4','N','int','System.Int32','','','','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','riccardotest','oremindida','4','N','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','decimal(5,2)','riccardotest','parttime','5','N','decimal','System.Decimal','','2','''riccardotest''','5','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','int','riccardotest','scatto','4','N','int','System.Int32','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','date','riccardotest','start','3','S','date','System.DateTime','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','S','getcontratti','date','riccardotest','stop','3','N','date','System.DateTime','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','char(1)','riccardotest','tempdef','1','S','char','System.String','','','''riccardotest''','','N')
GO

INSERT INTO columntypes (format,allownull,tablename,sqldeclaration,createuser,field,col_len,denynull,sqltype,systemtype,defaultvalue,col_scale,lastmoduser,col_precision,iskey) VALUES('','N','getcontratti','varchar(50)','riccardotest','title','50','S','varchar','System.String','','','''riccardotest''','','N')
GO

-- VERIFICA DI getcontratti IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'getcontratti')
UPDATE customobject set isreal = 'N' where objectname = 'getcontratti'
ELSE
INSERT INTO customobject (objectname, isreal) values('getcontratti', 'N')
GO
-- FINE GENERAZIONE SCRIPT --

