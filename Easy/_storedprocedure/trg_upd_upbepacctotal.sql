SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upbepacctotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_upbepacctotal]
GO


CREATE    PROCEDURE [trg_upd_upbepacctotal]
(
	@idacc varchar(38),
	@idupb varchar(36),
	@nphase tinyint,
	@amount decimal(19,2),
	@amount2 decimal(19,2),
	@amount3 decimal(19,2),
	@amount4 decimal(19,2),
	@amount5 decimal(19,2)
)
AS BEGIN
-- Gli importi di input, in caso di accertamento nota di variazione, avranno l'importo cambiato di segno.
DECLARE @countyear int

DECLARE @nlevel tinyint
SELECT @nlevel = nlevel FROM account WHERE idacc = @idacc

WHILE (@nlevel >= 1)
BEGIN
	SELECT @countyear = COUNT(*) 	FROM upbepacctotal
				WHERE idacc = @idacc	AND idupb = @idupb 		AND nphase = @nphase

	IF (@countyear = 0)
	BEGIN
		INSERT INTO upbepacctotal (idacc, idupb, nphase, total,total2,total3,total4,total5)
			VALUES (@idacc, @idupb, @nphase, @amount,@amount2,@amount3,@amount4,@amount5)
				
	END
	ELSE
	BEGIN
		UPDATE upbepacctotal SET
			total = ISNULL(total, 0) + @amount,
			total2 = ISNULL(total2, 0) + @amount2,
			total3 = ISNULL(total3, 0) + @amount3,
			total4 = ISNULL(total4, 0) + @amount4,
			total5 = ISNULL(total5, 0) + @amount5

			WHERE idacc = @idacc
				AND idupb = @idupb
				AND nphase = @nphase
				
	END
		
	SET @nlevel = @nlevel - 1
	SELECT @idacc = SUBSTRING(@idacc,1,len(@idacc)-4)
END


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


