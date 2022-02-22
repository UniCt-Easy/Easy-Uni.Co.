
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


-- CREAZIONE VISTA [dbo].[getcontrattikindview]
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getcontrattikindview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getcontrattikindview]
GO

CREATE VIEW [dbo].[getcontrattikindview]
AS
SELECT        
	ck.idcontrattokind, 
	ck.title, 
	ck.oremaxgg, 
	ck.parttime, 
	ck.tempdef, 
	ck.costolordoannuo as costolordoannuo_ck,
	ck.costolordoannuo_inq,
	ck.costolordoannuo_stip,
	isnull(ck.costolordoannuo_stip,isnull(ck.costolordoannuo_inq,ck.costolordoannuo)) as costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((ck.costolordoannuo/12),2,1) as decimal(18,2)) costomese,
	oremaxtempoparziale, oremaxtempopieno,
	oremaxdidatempoparziale, oremaxdidatempopieno,
	oremindidatempoparziale, oremindidatempopieno
FROM (
	SELECT cckk.*, 
	(select min(costolordoannuo) from inquadramento i WHERE i.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_inq,
	(select min(totale) from stipendio s WHERE s.idcontrattokind = cckk.idcontrattokind) as costolordoannuo_stip
	FROM dbo.contrattokind cckk
) ck 

GO


