
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

