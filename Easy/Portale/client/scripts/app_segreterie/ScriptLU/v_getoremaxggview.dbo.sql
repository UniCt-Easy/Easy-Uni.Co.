
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


IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[getoremaxgg]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[getoremaxgg]
GO

CREATE VIEW [dbo].[getoremaxgg]
AS
SELECT        dbo.contratto.idreg, dbo.contratto.start, dbo.contratto.stop, dbo.contrattokind.oremaxgg, dbo.contrattokind.title
FROM            dbo.contratto INNER JOIN
                         dbo.contrattokind ON dbo.contratto.idcontrattokind = dbo.contrattokind.idcontrattokind
GO
