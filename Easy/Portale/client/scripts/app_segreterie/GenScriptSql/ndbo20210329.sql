
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


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudr' and C.name = 'impegnototaleore' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudr] ADD impegnototaleore int NULL 
END
ELSE
	ALTER TABLE [progettoudr] ALTER COLUMN impegnototaleore int NULL
GO


IF NOT exists(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'progettoudrmembro' and C.name = 'orepreventivate' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	ALTER TABLE [progettoudrmembro] ADD orepreventivate int NULL 
END
ELSE
	ALTER TABLE [progettoudrmembro] ALTER COLUMN orepreventivate int NULL
GO

IF EXISTS(select * from sysobjects where id = object_id(N'[getcontratti]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [getcontratti]
GO


CREATE VIEW [getcontratti]
AS
SELECT        
	c.idcontratto,
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
	ck.costolordoannuo,
	Cast(round(ck.costolordoannuo/isnull(oremaxtempopieno,1720),2,1) as decimal(18,2)) costoora,
	Cast(round((ck.costolordoannuo/isnull(oremaxtempopieno,1720))*isnull(oremaxgg,8)*30,2,1) as decimal(18,2)) costomese,
	CASE WHEN isnull(c.tempdef,'N') = 'S' OR isnull(c.parttime,0)<100 THEN oremaxtempoparziale ELSE oremaxtempopieno END as oremax,
	CASE WHEN isnull(c.tempdef,'N') = 'S' OR isnull(c.parttime,0)<100 THEN oremaxdidatempoparziale ELSE oremaxdidatempopieno END as oremaxdida,
	CASE WHEN isnull(c.tempdef,'N') = 'S' OR isnull(c.parttime,0)<100 THEN oremindidatempoparziale ELSE oremindidatempopieno END as oremindida
FROM dbo.contrattokind ck 
INNER JOIN dbo.contratto c ON ck.idcontrattokind = c.idcontrattokind


GO
