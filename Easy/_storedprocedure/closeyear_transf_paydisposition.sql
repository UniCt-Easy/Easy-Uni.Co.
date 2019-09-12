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


 