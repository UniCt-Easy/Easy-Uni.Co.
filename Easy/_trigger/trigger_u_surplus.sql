
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_surplus]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_surplus]
GO

CREATE TRIGGER [trigger_u_surplus] ON [surplus] FOR UPDATE
AS BEGIN
	DECLARE @ayear int
	DECLARE @newayear int
	
	SELECT @ayear = ayear FROM inserted
	SET @newayear = @ayear + 1
/*
Il campo idfinincomesurplus è stato rimosso dal form, per cui vale sempre null.
In un primo momento era stato aggiunto il RETURN, perchè si voleva che il fondo cassa al 01/01 fosse inserito a mano dall'utente
in virtù delle varie importazioni di movimenti pregressi che potevano sfalsare il valore, se magari si stava lavorando nel nuovo esercizio, col giusto startfloatfund
e nel mentre si continuava ad inserire movimentazione pregressi
Invece sembra che la valorizzazione debba avvenire in maniera automatica, per cui è stato rimosso il primo IF perchè ridondante dato che idfinincomesurplus vale sempre null,
per cui il primo IF si sarebbe limitato ad eseguire il rebuild_currentfloatfund
e lasciato solo il secondo.

	DECLARE @idfinincomesurplus int
	SELECT @idfinincomesurplus = idfinincomesurplus FROM config WHERE ayear = @newayear
	IF EXISTS(SELECT * FROM accountingyear WHERE ayear = @newayear) AND (@idfinincomesurplus IS NULL)
	BEGIN
		EXEC rebuild_currentfloatfund @newayear
		RETURN
	END
*/
	DECLARE @startfloatfund decimal(19,2)	
	IF EXISTS(SELECT * FROM accountingyear WHERE ayear = @newayear) 
	BEGIN
		SELECT @startfloatfund = 
		ISNULL(startfloatfund,0) +
		ISNULL(competencyproceeds,0) +
		ISNULL(residualproceeds,0) - 
		ISNULL(competencypayments,0) -
		ISNULL(residualpayments,0)
		FROM inserted
		IF EXISTS(SELECT * FROM surplus WHERE ayear = @newayear)  
			BEGIN
				--Aggiorna il fondo cassa al 01/01/@newayear
				UPDATE surplus SET startfloatfund = @startfloatfund WHERE ayear = @newayear 
			END
		ELSE
			BEGIN
				-- Crea la riga nell'anno @newayear
				INSERT INTO surplus(ayear,startfloatfund,
							competencypayments,competencyproceeds,currentexpenditure,currentrevenue,paymentstilldate,
							paymentstoendofyear,previousexpenditure,previousrevenue,previsiondate,proceedstilldate,proceedstoendofyear,
							residualpayments,residualproceeds,supposedcurrentexpenditure,supposedcurrentrevenue,
							supposedpreviousexpenditure,supposedpreviousrevenue,locked,ct,cu,lt,lu)
				VALUES(@newayear, @startfloatfund,
						NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'01-01-'+ convert(varchar(4),@newayear),NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,
						'N',getdate(),'trigger_u_surplus',getdate(),'trigger_u_surplus')
			END


		EXEC rebuild_currentfloatfund @newayear
	END


END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

