
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

if exists (select * from dbo.sysobjects where id = object_id(N'[trigger_d_income]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [trigger_d_income]
GO


CREATE      TRIGGER [trigger_d_income] ON income FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	CREATE TABLE #income (idinc int, nphase tinyint, parentidinc int, idunderwriting int)

	INSERT INTO #income(idinc, nphase, parentidinc, idunderwriting)
	SELECT idinc,nphase, parentidinc, idunderwriting FROM deleted

	DELETE FROM ivapayincome
	WHERE idinc IN (SELECT idinc FROM #income)

	DELETE FROM mainivapayincome
	WHERE idinc IN (SELECT idinc FROM #income)

	DELETE FROM pettycashincome
	WHERE idinc IN (SELECT idinc FROM #income)
	
	DELETE FROM csa_import_income
	WHERE idinc IN (SELECT idinc FROM #income)

	UPDATE expensetax SET idinc = NULL
	WHERE idinc IN (SELECT idinc FROM #income)

	UPDATE expensetaxcorrige SET linkedidinc = NULL
	WHERE linkedidinc IN (SELECT idinc FROM #income)

/*	
Questa parte è stata rimossa perchè errata, nella DELETE di income, viene prima cancellate incomeyear e POI income,quindi la JOI con incomeyear
non ha senso perchè la riga nella tabella non c'è più

	IF (SELECT COUNT(*) FROM incomeyear) > 0
	BEGIN

		DECLARE @idinc int
		DECLARE @ayear int
		DECLARE @idfin int
		DECLARE @idupb varchar(36)
		DECLARE @nphase tinyint
		DECLARE @amount decimal(19,2)
		DECLARE @flagarrear char(1)
		DECLARE @parentidinc int
		DECLARE @idunderwriting int

		DECLARE #iy_crs INSENSITIVE CURSOR FOR
		SELECT IY.idinc, IY.ayear, IY.idfin, IY.idupb, I.nphase, -IT.curramount, I.parentidinc,
		CASE
			WHEN ((IT.flag&1)=0) THEN 'C'
			WHEN ((IT.flag&1)=1) THEN 'R'
		END AS flagarrear,
		 I.idunderwriting	
		FROM incomeyear IY
		JOIN #income I
			ON IY.idinc = I.idinc
		JOIN incometotal IT
			ON IT.idinc = IY.idinc
			AND IT.ayear = IY.ayear

		FOR READ ONLY
		OPEN #iy_crs

		FETCH NEXT FROM #iy_crs INTO @idinc, @ayear, @idfin, @idupb, @nphase, @amount, @parentidinc, @flagarrear, @idunderwriting
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			IF (@idfin IS NOT NULL)
			BEGIN
				EXECUTE trg_upd_upbmovtotal 
				'I', 
				@idfin, 
				@idupb,
				@flagarrear, 
				@nphase, 
				@amount
			END

			IF (@idunderwriting IS NOT NULL)
			BEGIN
				EXECUTE trg_upd_underwritingmovtotal 
				'I', 
				@idunderwriting,
				@flagarrear, 
				@nphase, 
				@amount
			END
			
			EXECUTE trg_del_amount 
			@ayear, 
			'I', 
			@idinc,
			@parentidinc,
			@nphase,
			@amount

			FETCH NEXT FROM #iy_crs INTO @idinc, @ayear, @idfin, @idupb, @nphase, @amount, @parentidinc, @flagarrear, @idunderwriting
		END
		CLOSE #iy_crs
		DEALLOCATE #iy_crs

	END
	*/
	DELETE FROM incomeyear
	WHERE idinc IN (SELECT idinc FROM #income)
	AND amount = 0

	DELETE FROM incomelink
	WHERE idchild IN (SELECT idinc FROM #income)
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

