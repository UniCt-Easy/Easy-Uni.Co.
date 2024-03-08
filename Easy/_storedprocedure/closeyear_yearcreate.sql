
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


if exists (select * from dbo.sysobjects where id = object_id(N'[closeyear_yearcreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [closeyear_yearcreate]
GO
--setuser 'amm'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
CREATE          PROCEDURE [closeyear_yearcreate]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #log (message varchar(255))
	
DECLARE @nextayear int
SET @nextayear = @ayear + 1
DECLARE @nextayearstr varchar(4)
SET @nextayearstr = CONVERT(varchar(4), @nextayear)
IF NOT EXISTS (SELECT * FROM accountingyear WHERE ayear = @nextayear)
BEGIN
	INSERT INTO accountingyear
	(
		ayear, flag
	)
	VALUES
	(
		@nextayear, 0
	)
		
		
	INSERT INTO #log VALUES('Creato esercizio ' + @nextayearstr)
END


IF NOT EXISTS (SELECT * FROM config WHERE ayear = @nextayear)
BEGIN
	INSERT INTO config
	(
		ayear,
		asset_flagnumbering,
		assetload_flag,
		asset_flagrestart,
		flag_autodocnumbering,
		linktoinvoice,
		casualcontract_flagrestart,
		automanagekind,
		expensephase,
		expense_expiringdays,
		flag_paymentamount,
		flagautopayment,
		payment_flagautoprintdate,
		payment_flag,
		taxvaliditykind,
		idsortingkind1,
		idsortingkind2,
		idsortingkind3,
		payment_finlevel,
		idregauto,
		appropriationphasecode,
		assessmentphasecode,
		boxpartitiontitle,
		cashvaliditykind,
		currpartitiontitle,
		fin_kind,
		prevpartitiontitle,
		flagcredit,
		flagproceeds,
		incomephase,
		income_expiringdays,
		proceeds_flagautoprintdate,
		flagautoproceeds,
		flagfruitful,
		proceeds_flag,
		proceeds_finlevel,
		profservice_flagrestart,
		wageaddition_flagrestart,
		balancekind,
		wageimportappname,
		ct,
		cu,
		lt,
		lu,
		invoice_flagregister,
		default_idfinvarstatus,
		flagivaregphase,
		mainflagivaregphase,
		flagva3,
		iban_f24,
		email_f24,
		idreg_csa,
		flagdirectcsaclawback,
		flagpcashautopayment,
		flagpcashautoproceeds,
		email,
		booking_on_invoice,
		csa_flaggroupby_income,
		csa_flaggroupby_expense,
		csa_flaglinktoexp,
		csa_flagtransmissionlinking,
		csa_flag,
		csa_idchargehandling,
		csa_nominativo,
		flagbalance_csa,
		flagiva_immediate_or_deferred,
		flagenabletransmission ,
		idpccdebitstatus,
		flag,
		flagsplitpayment,
		risconta_ammortamenti_futuri ,
		flagpcc
	)
	SELECT 
		@nextayear,
		asset_flagnumbering,
		assetload_flag,
		asset_flagrestart,
		flag_autodocnumbering,
		linktoinvoice,
		casualcontract_flagrestart,
		automanagekind,
		expensephase,
		expense_expiringdays,
		flag_paymentamount,
		flagautopayment,
		payment_flagautoprintdate,
		payment_flag,
		taxvaliditykind,
		idsortingkind1,
		idsortingkind2,
		idsortingkind3,
		payment_finlevel,
		idregauto,
		appropriationphasecode,
		assessmentphasecode,
		boxpartitiontitle,
		cashvaliditykind,
		currpartitiontitle,
		fin_kind,
		prevpartitiontitle,
		flagcredit,
		flagproceeds,
		incomephase,
		income_expiringdays,
		proceeds_flagautoprintdate,
		flagautoproceeds,
		flagfruitful,
		proceeds_flag,
		proceeds_finlevel,
		profservice_flagrestart,
		wageaddition_flagrestart,
		balancekind,
		wageimportappname,
		GETDATE(),
		cu,
		GETDATE(),
		lu,
		invoice_flagregister,
		default_idfinvarstatus,
		flagivaregphase,
		mainflagivaregphase,
		flagva3,
		iban_f24,
		email_f24,
		idreg_csa,
		flagdirectcsaclawback,
		flagpcashautopayment,
		flagpcashautoproceeds,
		email,
		booking_on_invoice,
		csa_flaggroupby_income,
		csa_flaggroupby_expense,
		csa_flaglinktoexp,
		csa_flagtransmissionlinking,
		csa_flag,
		csa_idchargehandling,
		csa_nominativo,
		flagbalance_csa,
		flagiva_immediate_or_deferred,
		flagenabletransmission ,
		idpccdebitstatus,
		flag,
		flagsplitpayment,  --- gestisci recupero split payment
		risconta_ammortamenti_futuri,
		flagpcc
	FROM config
	WHERE ayear = @ayear

	INSERT INTO #log
	VALUES('Trasferita configurazione Generale per esercizio ' + @nextayearstr)

END

	
IF NOT EXISTS (SELECT * FROM trasmissionmanager WHERE ayear = @nextayear)
BEGIN
	INSERT INTO trasmissionmanager
	(
		ayear, idtrasmissiondocument, annotations, idreg,
		cu, ct, lu, lt
	)
	SELECT 
		@nextayear, idtrasmissiondocument, annotations, idreg,
		'closeyear_create', GETDATE(), 'closeyear_create', GETDATE()
	FROM trasmissionmanager
	WHERE ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione Responsabile della Trasmissione per esercizio ' + @nextayearstr)
END


IF NOT EXISTS (SELECT * FROM siopekind WHERE ayear = @nextayear)
BEGIN
	INSERT INTO siopekind
	(
		ayear, codesorkind_siopespese, codesorkind_siopeentrate, newcomputesorting,
		cu, ct, lu, lt
	)
	SELECT 
		@nextayear, codesorkind_siopespese, codesorkind_siopeentrate, newcomputesorting,
		'closeyear_create', GETDATE(), 'closeyear_create', GETDATE()
	FROM siopekind
	WHERE ayear = @ayear
	
	INSERT INTO #log
	VALUES('Trasferita configurazione classificazione siope ' + @nextayearstr)
END


-- trasferisco i dati relativi all'organigramma annuale
EXEC closeyear_flowchartcopy @ayear, @nextayear

--azzero i bit da 0 a 3 e poi imposto il valore 1 su questi flag
UPDATE accountingyear SET flag = flag&0xF0 WHERE ayear = @ayear
UPDATE accountingyear SET flag = flag|0x01 WHERE ayear = @ayear

SELECT * FROM #log
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
