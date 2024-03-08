
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


if exists (select * from dbo.sysobjects where id = object_id(N'[stampa_logo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [stampa_logo]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Pino Rana, elaborazione del 10/08/2005 15:27:23


CREATE           PROCEDURE [stampa_logo]
	@codicelogo varchar(10)
AS						      
	BEGIN	
	IF isnull(@codicelogo,'') = ''  SET @codicelogo = 'UNIV'
		SELECT 
		logo,
		idlogo 
		FROM logo	
		WHERE idlogo = @codicelogo
	END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

