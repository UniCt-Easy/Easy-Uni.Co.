
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
