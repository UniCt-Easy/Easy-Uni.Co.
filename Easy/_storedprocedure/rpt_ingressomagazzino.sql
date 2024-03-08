
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_ingressomagazzino]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_ingressomagazzino]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE rpt_ingressomagazzino (
	@cf varchar(50)
)

AS BEGIN
--	exec rpt_ingressomagazzino  null
DECLARE @ayear int
SET @ayear = (select year(getdate()))


CREATE TABLE #Prenotazione (
	cf varchar(50),
	idbooking int,
	ybooking int,
	nbooking int,
	idman int,
	idlist int,
	idstore int,
	idstock int,
	richiesta decimal(19,2),
	scaricata decimal(19,2),
	dascaricata decimal(19,2),
	allocata decimal(19,2)	,
	codiceabarre varchar(30),
	codiceabarre_cod varchar(30)
)


INSERT INTO #Prenotazione(cf,idbooking, ybooking, nbooking, idman, idlist, idstore, idstock, richiesta, scaricata, dascaricata, allocata)
SELECT 
	B.cf,
	B.idbooking,
	B.ybooking, B.nbooking, B.idman,
	D.idlist,
	D.idstore,
	D.idstock,
	D.number, -- Richiesta = Q.tà prenotata
	D.number - isnull(T.number,0), -- Scaricata = Evase = q.tà prenotata - quanto mi resta da scaricare
	isnull(T.number,0),-- Da scaricare = non evasa
	isnull(T.allocated,0)
FROM booking B
JOIN bookingdetail D
	ON B.idbooking = D.idbooking
LEFT OUTER JOIN booktotal T -- c'è il LEFT perchè quando la prenotazione viene scaricata completamente la riga verrà cancellata
	ON D.idbooking = T.idbooking	
	AND D.idlist = T.idlist
	AND D.idstore = T.idstore
-- AND isnull(T.allocated,0) >0
WHERE (B.cf = @cf or (B.cf is not null and @cf is null))
	and B.ybooking = @ayear
DECLARE @idbooking int
DECLARE @name varchar(150)
declare @query nvarchar(300)

CREATE TABLE #Codice (code varchar(60))

DECLARE crsbooking INSENSITIVE CURSOR FOR
	SELECT idbooking FROM #Prenotazione
OPEN crsbooking 
FETCH NEXT FROM crsbooking INTO @idbooking
		
WHILE @@fetch_status=0 begin
		
		DECLARE @barcode varchar(100)
		DELETE FROM #Codice

		INSERT INTO #CODICE (code)
		exec calc_bookingcode @idbooking
		
		DECLARE @strbooking varchar(100)
		SET @strbooking = ( select code from #CODICE )

		execute calc_barcode @strbooking , @barcode OUTPUT
		
		UPDATE #Prenotazione SET codiceabarre = @strbooking, 
		codiceabarre_cod = @barcode
		WHERE idbooking = @idbooking

	FETCH NEXT FROM crsbooking INTO @idbooking
end
deallocate crsbooking

-- Se NON usano prenotare con disponibilità, ossia se config.booking_on_invoice = 'N'
-- forniamo l'ubicazione di uno stock qualsiasi(con giacenza) di pari idlist.
DECLARE @booking_on_invoice char
SELECT @booking_on_invoice = isnull(booking_on_invoice,'N') from config WHERE ayear = @ayear
IF (@booking_on_invoice='N')
Begin
	update #Prenotazione set idstock= (Select top 1 idstock from stockview SV
										where SV.idlist = #Prenotazione.idlist and SV.idstore= #Prenotazione.idstore
										and SV.residual >0 )
End

SELECT 
	P.codiceabarre,
	P.codiceabarre_cod,
	P.cf, 
	P.ybooking, 
	P.nbooking, 
	M.title as manager,
	P.idlist,	
	L.description as list,
	P.idstore,	
	S.description as store,
	SUM(P.richiesta) as richiesta,
	SUM(P.scaricata) as scaricata,
	SUM(P.dascaricata) as dascaricata,
	SUM(P.allocata) as allocata,
	SL1.stocklocationcode AS stocklocationcode1,
	SL1.description as stocklocation1,
	SL2.stocklocationcode AS stocklocationcode2,
	SL2.description as stocklocation2,
	SL3.stocklocationcode AS stocklocationcode3,
	SL3.description as stocklocation3,
	SL4.stocklocationcode AS stocklocationcode4,
	SL4.description as stocklocation4
FROM #Prenotazione P
JOIN list L
	ON L.idlist = P.idlist
JOIN store S
	ON S.idstore = P.idstore
JOIN manager M
	ON M.idman = P.idman 
LEFT OUTER JOIN stock ST
	ON P.idstock = ST.idstock
LEFT OUTER JOIN stocklocation SL4							
	ON SL4.idstocklocation = ST.idstocklocation 
LEFT OUTER JOIN stocklocation SL3
	ON SL3.idstocklocation = SL4.paridstocklocation 
LEFT OUTER JOIN stocklocation SL2
	ON SL2.idstocklocation = SL3.paridstocklocation 
LEFT OUTER JOIN stocklocation SL1
	ON SL1.idstocklocation = SL2.paridstocklocation 

WHERE isnull(P.allocata,0) >0 
GROUP BY 
	P.codiceabarre,
	P.codiceabarre_cod,
	P.cf, 
	P.ybooking, 
	P.nbooking, 
	M.title,
	P.idlist,	
	L.description,
	P.idstore,
	P.idstock,		
	S.description,
	SL1.stocklocationcode, SL1.description,
	SL2.stocklocationcode, SL2.description,
	SL3.stocklocationcode, SL3.description,
	SL4.stocklocationcode, SL4.description
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


