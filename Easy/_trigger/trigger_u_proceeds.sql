
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_u_proceeds]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_u_proceeds]
GO

CREATE TRIGGER [trigger_u_proceeds] ON proceeds FOR UPDATE
AS BEGIN
	IF
	UPDATE(kproceedstransmission)
  	BEGIN
		DECLARE @newamount decimal(19,2)
		DECLARE @ypro int
		DECLARE @kpro int
		DECLARE @oldkproceedstransmission int
		DECLARE @newkproceedstransmission int
	
		SELECT 
			@ypro = ypro,
			@kpro = kpro,
			@newkproceedstransmission = kproceedstransmission
		FROM inserted
	
		SELECT @oldkproceedstransmission = kproceedstransmission FROM deleted

		DECLARE @ayear int
		SET @ayear = @ypro
-- Considero la somma degli'importi correnti dei movimenti di entrata inseriti nella reversale di incasso considerata
		SELECT @newamount = ISNULL(SUM(curramount),0)
		FROM incometotal
		JOIN incomelast
			ON incometotal.idinc = incomelast.idinc
		WHERE incometotal.ayear = @ayear
			AND incomelast.kpro = @kpro
	
-- La SP viene chiamata solo quando inserisco o rimuovo una reversale da una distinta di trasmissione
-- A priori sono escluse tutte le modifiche sui movimenti di entrata in quanto tutti i mov. appartenenti alle fase precedente all'ultima
-- hanno sempre il campo yban impostato a NULL. Nel caso di mov. modificati inseriti gi√† in un mov. bancario, essi 
-- vengono bloccati all'interno di trg_upd_curr_floatfund	
   		IF (@newkproceedstransmission IS NULL
		 AND @oldkproceedstransmission IS NOT NULL)
		BEGIN
			EXECUTE trg_del_curr_floatfund
			@ayear,
			'I',
			NULL,
			@newamount
		END
   		IF (@oldkproceedstransmission IS NULL
		 AND @newkproceedstransmission IS NOT NULL)
		BEGIN
			EXECUTE trg_ins_curr_floatfund
			@ayear,
			'I',
			NULL,
			@newamount
		END
	END
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

