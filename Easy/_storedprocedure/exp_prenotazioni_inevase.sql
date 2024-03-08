
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_prenotazioni_inevase]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_prenotazioni_inevase]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [exp_prenotazioni_inevase]
(
@idstore int,
@ayear int
)
AS
BEGIN

SELECT  booktotalview.manager AS 'Responsabile', 
		booktotalview.list AS 'Voce listino',
	    convert(float,booktotalview.allocated) AS 'Quantità disponibile',
		convert(float,booktotalview.number) AS 'Quantità Inevasa,', 
	    booktotalview.store AS 'Magazzino', 
		booktotalview.ybooking AS 'Esercizio Prenotazione', 
		booktotalview.nbooking AS 'Numero Prenotazione', 
		booking.ct AS 'data della prenotazione' 
FROM booktotalview 
	JOIN booking
		ON booktotalview.idbooking = booking.idbooking
			
WHERE booktotalview.idstore=@idstore
AND booktotalview.ybooking = @ayear
AND booktotalview.allocated>'0'

END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

