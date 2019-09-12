if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_stocktotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_stocktotal]
GO

CREATE PROCEDURE [rebuild_stocktotal]
AS 
BEGIN

DELETE FROM stocktotal

INSERT INTO 
stocktotal
(idstore,
idlist,
number,
ordered,
booked
)
SELECT 
idstore,
idlist,
sum(number),
0,
0
FROM stock
group by idstore, idlist

UPDATE stocktotal
SET number = number - 
			ISNULL((SELECT SUM(storeunloaddetail.number) 
					  FROM storeunloaddetail 
					  JOIN stock
						ON storeunloaddetail.idstock = stock.idstock
			WHERE stock.idstock = storeunloaddetail.idstock
			  AND stock.idstore = stocktotal.idstore
			  AND stock.idlist  = stocktotal.idlist),0)

UPDATE stocktotal 
SET ordered = ISNULL((SELECT SUM(number) 
				 FROM stock 
				WHERE idmankind is not null 
				  AND stocktotal.idstore = stock.idstore
				  AND stocktotal.idlist = stock.idlist),0)

UPDATE stocktotal 
SET booked = ISNULL((SELECT SUM(number) 
				 FROM bookingdetail 
				WHERE stocktotal.idstore = bookingdetail.idstore
				  AND stocktotal.idlist = bookingdetail.idlist
					AND authorized='S'
					),0)

UPDATE stocktotal 
SET booked = booked - ISNULL((SELECT SUM(storeunloaddetail.number) 
					  FROM storeunloaddetail 
					  JOIN stock
						ON storeunloaddetail.idstock = stock.idstock
					WHERE stock.idstock = storeunloaddetail.idstock
					  AND stock.idstore = stocktotal.idstore
					  AND stock.idlist  = stocktotal.idlist
					  AND storeunloaddetail.idbooking is not null					
						),0)
END


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
