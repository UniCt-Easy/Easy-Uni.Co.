if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_booktotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE[rebuild_booktotal]
GO

CREATE PROCEDURE [rebuild_booktotal]
AS 
BEGIN
	DELETE FROM booktotal

	INSERT INTO booktotal
	(
		idstore,
		idlist,
		idbooking,
		number,
		allocated
	)
	SELECT 
		idstore,
		idlist,
		idbooking,
		sum(number),
		0
	FROM bookingdetail
	where authorized='S'
	group by idstore, idlist,idbooking

	UPDATE booktotal 
	SET number = number - ISNULL((SELECT SUM(storeunloaddetail.number) 
						  FROM storeunloaddetail 
						  JOIN bookingdetail
							ON storeunloaddetail.idbooking = bookingdetail.idbooking
						AND  booktotal.idlist  = bookingdetail.idlist
						  JOIN stock
							ON storeunloaddetail.idstock = stock.idstock
						WHERE  stock.idstore = booktotal.idstore
						  AND  stock.idlist  = booktotal.idlist
						  AND  storeunloaddetail.idbooking  = booktotal.idbooking
						   ),0)

	DECLARE  @idlist	int
	DECLARE  @idstore	int
	DECLARE  @booked	decimal(19,2)

	DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT  idlist, idstore, number 	FROM    stocktotal	WHERE  booked>0
	FOR READ ONLY

	OPEN rowcursor
	FETCH NEXT FROM rowcursor
	INTO @idlist, @idstore, @booked
	WHILE @@FETCH_STATUS = 0
	BEGIN 
			DECLARE @to_assign int
			SET @to_assign = @booked
				
			DECLARE  @idbooking	int
			DECLARE  @number	int
			
			DECLARE bookcursor INSENSITIVE CURSOR FOR
				SELECT  idbooking, number		FROM    booktotal		WHERE   number > 0
							AND		idstore = @idstore 
							AND  idlist = @idlist 
							ORDER BY idbooking ASC
			FOR READ ONLY

			OPEN bookcursor
			FETCH NEXT FROM bookcursor 	INTO @idbooking, @number
			WHILE @@FETCH_STATUS = 0 and @to_assign>0
			BEGIN				
					IF 	(@number > @to_assign) 
						BEGIN
							UPDATE booktotal SET allocated = @to_assign
							WHERE  idstore = @idstore 
							  AND  idlist = @idlist 
							  AND  idbooking = @idbooking
							SET @to_assign=0
						END
					ELSE
						BEGIN
							UPDATE booktotal SET allocated = @number
							WHERE  idstore = @idstore 
							  AND  idlist = @idlist 
							  AND  idbooking = @idbooking
						SET @to_assign=@to_assign - @number
						FETCH NEXT FROM bookcursor 	INTO @idbooking, @number						
						END
			END

			DEALLOCATE bookcursor

		FETCH NEXT FROM rowcursor
		INTO @idlist, @idstore, @booked
	END 
	DEALLOCATE rowcursor

	DELETE FROM booktotal WHERE number = 0 AND allocated = 0

END

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
