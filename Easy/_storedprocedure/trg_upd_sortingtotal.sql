
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[trg_upd_sortingtotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trg_upd_sortingtotal]
GO

CREATE PROCEDURE [trg_upd_sortingtotal]
(
	@idsor int,
	@idacc varchar(38),
	@updatefield varchar(255),
	@amount decimal(19,2)
)
AS BEGIN
DECLARE @sql varchar(2000)
IF @idacc IS NOT NULL
BEGIN
	WHILE((LEN(@idacc) - 2) >=4)
	BEGIN
		IF NOT EXISTS
			(SELECT * FROM sortingtotal
			WHERE idsor = @idsor
			AND idacc = @idacc)
		BEGIN
			SET @sql = 'INSERT INTO sortingtotal (idsor, idacc, ' + @updatefield + ')
			 VALUES (''' + CONVERT(varchar(10), @idsor) + ''',''' + @idacc + ''',' + STR(@amount, 20, 4) + ')'
		END
		ELSE
		BEGIN
			SET @sql = 'UPDATE sortingtotal SET ' + @updatefield + ' = ISNULL(' + @updatefield + ', 0) + ' + STR(@amount, 20, 4) +
			' WHERE idsor = ''' + CONVERT(varchar(10), @idsor) + ''' AND idacc = ''' + @idacc + ''''
		END
		EXEC (@sql)
		-- Se modifico i campi delle variazioni di bilancio
		-- DEVO PROPAGARE LE MODIFICHE FINO AL PRIMO LIVELLO!
		-- Diversamente la modifica viene effettuata SOLO sul livello di pertinenza!
		IF (@updatefield = 'previsionvariation')
		BEGIN
			SET @idacc = SUBSTRING(@idacc,1,LEN(@idacc)-4)
		END
		ELSE
		BEGIN
			SET @idacc=''
		END
	END
END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

