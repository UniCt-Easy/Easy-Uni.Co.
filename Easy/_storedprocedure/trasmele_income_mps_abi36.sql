
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


--setuser 'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[trasmele_income_mps_abi36]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [trasmele_income_mps_abi36]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE PROCEDURE [trasmele_income_mps_abi36]
(
	@y int,
	@n int
)
AS BEGIN
DECLARE @transmissionkind char(1)
SELECT @transmissionkind      = transmissionkind
FROM   proceedstransmission 
WHERE  nproceedstransmission = @n
AND    yproceedstransmission = @y

IF (ISNULL(@transmissionkind, 'I') = 'I')
BEGIN
	EXEC trasmele_income_mps_abi36_ins @y,@n
END
IF (ISNULL(@transmissionkind, 'I') = 'V')
BEGIN
	EXEC trasmele_income_mps_abi36_var @y,@n
END


END
 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
