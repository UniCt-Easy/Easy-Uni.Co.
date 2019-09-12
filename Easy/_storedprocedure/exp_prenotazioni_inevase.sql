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

