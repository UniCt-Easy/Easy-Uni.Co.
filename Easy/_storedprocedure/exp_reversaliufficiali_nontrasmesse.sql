
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_reversaliufficiali_nontrasmesse]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_reversaliufficiali_nontrasmesse]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE  PROCEDURE [exp_reversaliufficiali_nontrasmesse] 
@ayear	int
AS
BEGIN


	SELECT 
		ypro AS 'Esercizio',
		npro AS 'Numero Reversale',
		printdate AS 'Data di Stampa',
		adate AS 'Data Contabile'
	FROM proceeds WHERE printdate IS NOT NULL
	AND kproceedstransmission IS NULL
	AND ((ypro = @ayear) OR (@ayear is null))
	
END


SET QUOTED_IDENTIFIER ON 


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
