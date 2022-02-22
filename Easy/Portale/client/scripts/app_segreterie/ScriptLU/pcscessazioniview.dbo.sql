
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

