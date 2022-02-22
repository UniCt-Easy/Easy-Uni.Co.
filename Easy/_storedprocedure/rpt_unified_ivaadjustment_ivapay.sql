
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_ivaadjustment_ivapay]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_ivaadjustment_ivapay]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_unified_ivaadjustment_ivapay]
	@ayear smallint,
	@unified char(1)
AS BEGIN

	--EXEC [rpt_unified_ivaadjustment_ivapay] 2011, 'S'
	--GO
	--EXEC [rpt_unified_ivaadjustment_ivapay] 2011, 'N'
	
	declare @flagpayment char(1)
	select  @flagpayment = flagpayment from config where ayear=@ayear

	declare @idivapayperiodicity varchar(50)
	select  @idivapayperiodicity = ivapayperiodicity.description
	  from  config
	  join  ivapayperiodicity
	    on  config.idivapayperiodicity = ivapayperiodicity.idivapayperiodicity
	 where  config.ayear = @ayear

	declare @saldo_iniziale decimal (19,2)
	select  @saldo_iniziale = isnull(-startivabalance,0) from config where ayear = @ayear
CREATE TABLE #ivapay
	(
		yivapay int,
		nivapay int,
		paymentkind char(1),
		start datetime,
		stop datetime,
		debitamount decimal(19,2),
		creditamount decimal(19,2),
		refundamount decimal(19,2),
		paymentamount decimal(19,2),
		balance decimal(19,2)
	)
	
	-- PARTE RELATIVA ALL'IVA VERSATA

	-- PER CHI NON USA LA MOVIMENTAZIONE FINANZIARIA METTIAMO L'IVA DEL PERIODO
	-- CONSIDERIAMO IL FLAGPAYMENT DI CONFIG
	-- TOTALDEBIT -TOTALCREDIT MESE PER MESE NON BISOGNA SOTTRARRE IL SALDO INIZIALE 

	-- PER CHI USA LA MOVIMENTAZIONE FINANZIARIA
	-- PAYMENTAMOUNT -REFUNDAMOUNT SOTTRAENDO IL SALDO INIZIALE SECONDO IL PROSPETTO DI ANTONIO
	
	IF (@unified = 'N')
	BEGIN
		INSERT INTO #ivapay
		(
			yivapay,
			nivapay,
			paymentkind,
			start,
			stop,
			debitamount,
			creditamount,
			refundamount,
			paymentamount
		)
		SELECT 
			yivapay,
			nivapay,
			paymentkind,
			start,
			stop,
			debitamount,
			creditamount,
			refundamount,
			paymentamount
		FROM ivapay 
		WHERE year(start) = @ayear
	END
	ELSE
	BEGIN
		INSERT INTO #ivapay
		(
			yivapay,
			nivapay,
			paymentkind,
			start,
			stop,
			debitamount,
			creditamount,
			refundamount,
			paymentamount
		)
		SELECT 
			yunifiedivapay,
			nunifiedivapay,
			paymentkind,
			start,
			stop,
			debitamount,
			creditamount,
			refundamount,
			paymentamount
		FROM unifiedivapay 
		WHERE year(start) = @ayear
	END

	
	IF ISNULL(@flagpayment,'N') = 'N' 
	BEGIN
		 UPDATE #ivapay SET balance = isnull(debitamount,0) - isnull(creditamount,0) 
	END
	ELSE
	BEGIN
		 UPDATE #ivapay SET balance = isnull(paymentamount,0) - isnull(refundamount,0) 
	END
	
	SELECT 
		@idivapayperiodicity as 'idivapayperiodicity',
		@saldo_iniziale as 'startivabalance',
		paymentkind,
		M1.title as start,
		M2.title as stop,
		yivapay,
		nivapay,
		CASE ISNULL(@flagpayment,'N')
				WHEN 'N' THEN isnull(debitamount,0) 
				ELSE isnull(paymentamount,0)
		END as 'debitamount',
		CASE ISNULL(@flagpayment,'N')
				WHEN 'N' THEN isnull(creditamount,0) 
				ELSE isnull(refundamount,0)
		END as 'creditamount'
	FROM #ivapay
	JOIN monthname M1 ON M1.code = month(start)
	JOIN monthname M2 ON M2.code = month(stop)
	ORDER BY yivapay,
		nivapay
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
