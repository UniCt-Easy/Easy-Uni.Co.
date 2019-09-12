
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_ver_contr_entrata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_ver_contr_entrata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [exp_ver_contr_entrata]
	@idclawback int,
	@esercizio smallint
AS
BEGIN

	select CB.clawbackref, CB.description AS 'Descrizione Recupero' 
	,(SELECT SUM(SpeseRec.curramount)
		FROM expenseview AS SpeseRec JOIN
             expenseyear ON SpeseRec.idexp = expenseyear.idexp JOIN
             expenselast ON SpeseRec.idexp = expenselast.idexp
		WHERE (SpeseRec.idclawback = CB.idclawback)
		and (@esercizio is null or expenseyear.ayear = @esercizio)
	) AS 'Spese Recuperi'
	
	,(SELECT sum(expenseview.amount)
		FROM expenseclawback AS RecColl JOIN
        expenseview ON RecColl.idexp = expenseview.idexp
		WHERE CB.idclawback = RecColl.idclawback
		and (@esercizio is null or expenseview.ayear=@esercizio)

	) AS 'Recuperi Collegati a Spese'
	
	,(SELECT SUM(EntrateRec.amount)
		FROM incomeview AS EntrateRec JOIN
             incomeyear ON EntrateRec.idinc = incomeyear.idinc JOIN
             incomelast ON EntrateRec.idinc = incomelast.idinc
		WHERE (EntrateRec.autokind=6 and CB.idclawback=EntrateRec.autocode)
		and (@esercizio is null or incomeyear.ayear = @esercizio)
	) AS 'Entrate Recuperi'
	

	from clawback as CB
	WHERE (CB.active = 'S')  
		and (@idclawback is null or CB.idclawback = @idclawback)


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO