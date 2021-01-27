
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_uscitamagazzino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_uscitamagazzino]
GO

-- Articolo / Magazzino / Responsabile / Num.Prenotazione (eventuale) / Q.tà scaricata / Descrizione / Causale

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE       PROCEDURE rpt_uscitamagazzino(
	@idstoreunload int
)

AS BEGIN
--	 exec rpt_uscitamagazzino null

SELECT
	L.idlist, -- codice articolo
	L.description as 'list', --- descrizione  articolo
	L.intcode,
	U.description as 'unit', -- unita di carico/scarico
	S.idstore,
	M.description as 'store',
	SUM(SUD.number) as 'number',
	SU.adate,
	SU.description AS 'storeunload',
	SUD.idman,
	manager.title as 'manager',
	B.ybooking,
	B.nbooking
FROM storeunload SU
jOIN storeunloaddetail SUD
	ON SU.idstoreunload = SUD.idstoreunload
JOIN stock S
	ON SUD.idstock = S.idstock 
JOIN list L
	ON L.idlist = S.idlist
JOIN unit U
	ON U.idunit = L.idunit
JOIN store M
	ON SU.idstore = M.idstore
LEFT OUTER JOIN booking B
	ON 	SUD.idbooking = B.idbooking
LEFT OUTER JOIN manager 
	ON manager.idman = SUD.idman
WHERE  ( SU.idstoreunload = @idstoreunload OR @idstoreunload IS NULL)
GROUP BY  L.idlist, L.description, L.intcode,
	U.description, 	S.idstore,
	M.description,  SU.adate,
	SU.description, SUD.idman,
	manager.title,
	B.ybooking,
	B.nbooking

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





