SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_upbunderwritingtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_upbunderwritingtotal]
GO


CREATE  PROCEDURE [trg_upd_upbunderwritingtotal]
(
	@idfin int,
	@idupb varchar(36),
	@idunderwriting int,
	@updatefield varchar(255),
	@amount decimal(19,2)
)
AS BEGIN
	DECLARE @cmd1 varchar(255)
	DECLARE @cmd2 varchar(255)
	DECLARE @cmd3 varchar(255)
	IF @idfin IS NOT NULL
	BEGIN
		DECLARE @nlevel tinyint
		SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin
		WHILE(@nlevel > 0)
		BEGIN
			IF NOT EXISTS (SELECT * FROM upbunderwritingtotal WHERE idfin = @idfin AND idupb = @idupb and idunderwriting = @idunderwriting)
			BEGIN
				SELECT @cmd1 = 'INSERT INTO upbunderwritingtotal'
				SELECT @cmd2 = '(idfin, idupb, idunderwriting, ' + @updatefield + ')'
				SELECT @cmd3 = 'VALUES (' + CONVERT(varchar(10),@idfin) + ', ''' + @idupb + ''','  + 
				CONVERT(varchar(10),@idunderwriting) + ','  + STR(@amount, 20, 4) + ')'
			END
			ELSE
			BEGIN
				SELECT @cmd1 = 'UPDATE upbunderwritingtotal SET '
				SELECT @cmd2 = @updatefield + ' = ISNULL(' + @updatefield + ', 0) + ' + STR(@amount, 20, 4)
				SELECT @cmd3 = ' WHERE idfin = ' + CONVERT(varchar(10),@idfin)
				SELECT @cmd3 = @cmd3 + ' AND idupb = ''' + @idupb + ''''
				SELECT @cmd3 = @cmd3 + ' AND idunderwriting = ' + CONVERT(varchar(10),@idunderwriting)
			END

			print @cmd1
			print @cmd2
			print @cmd3
			print @cmd1 + @cmd2 + @cmd3
			EXEC (@cmd1 + @cmd2 + @cmd3)
			-- Se modifico i campi delle variazioni di bilancio
			-- DEVO PROPAGARE LE MODIFICHE FINO AL TITOLO!
			-- Diversamente la modifica viene effettuata SOLO sul livello di pertinenza!
			IF (@updatefield = 'previsionvariation' OR @updatefield = 'secondaryvariation' OR 
				@updatefield = 'currentprev' OR @updatefield = 'currentsecondaryprev')
			BEGIN
				SET @nlevel = @nlevel - 1
				SELECT @idfin = idparent FROM finlink WHERE idchild = @idfin AND nlevel = @nlevel
			END
			ELSE
			BEGIN
				SET @nlevel = 0
			END
		END
	END
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

