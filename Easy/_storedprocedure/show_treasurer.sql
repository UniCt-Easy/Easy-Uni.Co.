
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_treasurer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_treasurer]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

		      
CREATE 	PROCEDURE show_treasurer
	@ayear 	int,
	@date 	datetime,
	@idtreasurer int
AS
	BEGIN
-- show_treasurer '2012', {ts '2012-11-12 00:00:00.000'}, '10'			
		DECLARE @treasurer_start 	decimal(19,2)
		SELECT @treasurer_start = ISNULL(amount, 0.0)
			FROM treasurerstart
			WHERE ayear = @ayear
				AND idtreasurer = @idtreasurer

		DECLARE @proc_emitted decimal(19,2)
		-- Reversali emesse
		SELECT 	@proc_emitted = SUM(et.curramount) 
			FROM incometotal et 
			JOIN income e 
				ON et.idinc=e.idinc and et.ayear=@ayear
			JOIN incomelast el 
				ON el.idinc = e.idinc 
			JOIN proceeds p 
				ON el.kpro = p.kpro
			WHERE p.adate <= @date
					AND p.ypro = @ayear
					AND p.idtreasurer = @idtreasurer
				
		DECLARE @pay_emitted decimal(19,2)
		-- Mandati Emessi
		SELECT 	@pay_emitted = SUM(et.curramount) 
			FROM expensetotal et 
			JOIN expense e 
				ON et.idexp=e.idexp  and et.ayear=@ayear
			JOIN expenselast el 
				ON el.idexp = e.idexp 
			JOIN payment p
				ON el.kpay = p.kpay
			WHERE 	p.ypay = @ayear 
				AND p.adate <= @date
				AND P.idtreasurer = @idtreasurer
	
		-- Girofondi -
		DECLARE @moneytransferDim decimal(19,2)
		SELECT @moneytransferDim = SUM(amount)
			FROM moneytransfer
			WHERE ytransfer = @ayear
				AND adate <=adate
				AND idtreasurersource = @idtreasurer

		-- Girofondi +
		DECLARE @moneytransferAum decimal(19,2)
		SELECT @moneytransferAum = SUM(amount)
			FROM moneytransfer
			WHERE ytransfer = @ayear
				AND adate <=adate
				AND idtreasurerdest = @idtreasurer
				
		-- Saldo finale
		DECLARE  @treasurer_end decimal(19,2)
		SET @treasurer_end = isnull(@treasurer_start,0) + isnull(@proc_emitted,0) - isnull(@pay_emitted,0)-isnull(@moneytransferDim,0) + isnull(@moneytransferAum,0)

CREATE TABLE #situation	(value varchar(200), amount decimal(19,2), kind char(1))
DECLARE	@departmentname varchar(150) -- Nome del Dipartimento

SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

DECLARE @treasurer varchar(150)
SELECT @treasurer = description FROM treasurer where idtreasurer = @idtreasurer
				
INSERT INTO #situation	
	VALUES (@departmentname, NULL, 'H')

INSERT INTO #situation	
	VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')
INSERT INTO #situation
	VALUES (@treasurer, NULL, 'H')
INSERT INTO #situation	
	VALUES ('Esercizio ' + CONVERT(char(4),	@ayear), NULL, 'H')
INSERT INTO #situation	
	VALUES ('', NULL, 'N')

INSERT INTO #situation VALUES ('Saldo Iniziale',@treasurer_start,'S')	
INSERT INTO #situation VALUES ('Incassi',@proc_emitted,'')	
INSERT INTO #situation VALUES ('Pagamenti',@pay_emitted,'')	
INSERT INTO #situation VALUES ('Girofondi in Entrata',@moneytransferAum,'')	
INSERT INTO #situation VALUES ('Girofondi in Uscita',@moneytransferDim,'')	
INSERT INTO #situation VALUES ('Saldo Finale',@treasurer_end,'S')	

SELECT value, amount, kind FROM #situation
	END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


