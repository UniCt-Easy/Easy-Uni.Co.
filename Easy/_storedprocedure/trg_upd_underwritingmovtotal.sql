if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_underwritingmovtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_underwritingmovtotal]
GO
 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
	
CREATE     PROCEDURE [trg_upd_underwritingmovtotal](
	@movkind char(1),
	@idunderwriting int,
	@idupb varchar(36),
	@idfin int,
	@flagarrear char(1),
	@nphase tinyint,
	@amount decimal(19,2)
)
AS BEGIN
DECLARE @countyear int
IF (ISNULL(@idunderwriting,0) <>0)
BEGIN
	DECLARE @nlevel tinyint
	SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin

	WHILE (@nlevel >= 1)
	BEGIN
		IF (@movkind = 'I')
		BEGIN
			SELECT @countyear = COUNT(*) 
			FROM underwritingincometotal
			WHERE idunderwriting = @idunderwriting
					AND idupb = @idupb
					AND idfin = @idfin
					AND nphase = @nphase
			IF (@countyear = 0)
			BEGIN
				IF (@flagarrear = 'C')
				BEGIN
					INSERT INTO underwritingincometotal (idunderwriting, idupb, idfin, nphase, totalcompetency)
					VALUES (@idunderwriting,@idupb, @idfin, @nphase, @amount)
				END
				ELSE
				BEGIN
					INSERT INTO underwritingincometotal (idunderwriting, idupb, idfin, nphase, totalarrears)
					VALUES (@idunderwriting, @idupb, @idfin, @nphase, @amount)
				END
			END
			ELSE
			BEGIN
				IF (@flagarrear = 'C')
				BEGIN
					UPDATE underwritingincometotal SET	totalcompetency = ISNULL(totalcompetency, 0) + @amount
					WHERE idunderwriting = @idunderwriting
						AND idupb = @idupb
						AND idfin = @idfin
						AND nphase = @nphase
				END
				ELSE
				BEGIN
					UPDATE underwritingincometotal SET
					totalarrears = ISNULL(totalarrears, 0) + @amount
					WHERE idunderwriting = @idunderwriting
						AND idupb = @idupb
						AND idfin = @idfin
						AND nphase = @nphase
				END
			END
		END
		IF (@movkind = 'E')
		BEGIN
			SELECT @countyear = COUNT(*) 
			FROM underwritingexpensetotal
			WHERE idunderwriting = @idunderwriting
					AND idupb = @idupb
					AND idfin = @idfin
					AND nphase = @nphase
			IF (@countyear = 0)
			BEGIN
				IF (@flagarrear = 'C')
				BEGIN
					INSERT INTO underwritingexpensetotal (idunderwriting, idupb, idfin, nphase, totalcompetency)
					VALUES (@idunderwriting,@idupb, @idfin, @nphase, @amount)
				END
				ELSE
				BEGIN
					INSERT INTO underwritingexpensetotal (idunderwriting, idupb, idfin, nphase, totalarrears)
					VALUES (@idunderwriting, @idupb, @idfin, @nphase, @amount)
				END
			END
			ELSE
			BEGIN
				IF (@flagarrear = 'C')
				BEGIN
					UPDATE underwritingexpensetotal SET	totalcompetency = ISNULL(totalcompetency, 0) + @amount
					WHERE idunderwriting = @idunderwriting
						AND idupb = @idupb
						AND idfin = @idfin
						AND nphase = @nphase
				END
				ELSE
				BEGIN
					UPDATE underwritingexpensetotal SET
						totalarrears = ISNULL(totalarrears, 0) + @amount
					WHERE idunderwriting = @idunderwriting
						AND idupb = @idupb
						AND idfin = @idfin
						AND nphase = @nphase
				END
			END
		END
		
		
		SET @nlevel = @nlevel - 1
		SELECT @idfin = idparent FROM finlink WHERE idchild = @idfin AND nlevel = @nlevel
		END

	
END 
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

