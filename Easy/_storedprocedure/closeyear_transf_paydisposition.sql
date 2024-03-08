
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_transf_paydisposition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure  [closeyear_transf_paydisposition]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- EXEC  [closeyear_transf_paydisposition] 2014
--UPDATE paydisposition SET ayear =  2014, 
--lt = GetDate(), lu = 'transf_paydisposition_' + convert(varchar(4),2014)
--WHERE  ayear = 2015 and kpay is null 
CREATE PROCEDURE [closeyear_transf_paydisposition]
(
	@ayear int  -- esercizio da trasferire
)
AS BEGIN
	-----------------------------------------------------------------------------------------
	---------------- QUESTA PROCEDURA TRASFERISCE LE DISPOSIZIONI DI PAGAMENTO --------------
	---------- NON ASSOCIATE A MANDATO DAL VECCHIO AL NUOVO ESERCIZIO -----------------------
	-----------------------------------------------------------------------------------------
	IF EXISTS (SELECT * FROM paydisposition WHERE ayear = @ayear and kpay is null)
	BEGIN
		UPDATE paydisposition SET ayear = @ayear +1, 
		lt = GetDate(), lu = 'transf_paydisposition_' + convert(varchar(4),@ayear)
		WHERE  ayear = @ayear and kpay is null 
		SELECT idpaydisposition as '#id',
		ayear as 'Esercizio',
		description as 'Descrizione',
		motive as 'Causale',
		total as 'Totale'
		FROM paydispositionview 
		WHERE ayear = @ayear + 1  
		AND kpay IS NULL 
		AND lu = 'transf_paydisposition_'+ convert(varchar(4),@ayear) 
	END
	ELSE
	BEGIN
		SELECT   null as '#id',
		null as 'Esercizio',
		null as 'Descrizione',
		null as 'Causale',
		null as 'Totale'
	END

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
