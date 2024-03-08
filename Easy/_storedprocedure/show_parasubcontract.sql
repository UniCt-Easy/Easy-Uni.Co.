
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_parasubcontract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_parasubcontract]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [show_parasubcontract]
(
	@ayear int,
	@idcon varchar(8)
)
AS BEGIN
--- show_parasubcontract 2015,133

DECLARE	@departmentname varchar(150)

SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'')



CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES(@departmentname,NULL,'H')
-- Descrizione del contratto
DECLARE @parasubcon_descr  varchar(150)
DECLARE @ycon int
DECLARE @ncon int
SET @parasubcon_descr = 'Contratto n. ' + CONVERT(varchar(6),@ncon) + '/' + CONVERT(varchar(4),@ycon)
INSERT INTO #situation VALUES(@parasubcon_descr,NULL,'H')
-- Anno Fiscale
INSERT INTO #situation VALUES('Anno Fiscale ' + CONVERT(varchar(4),@ayear),NULL,'H')
-- Compenso lordo del contratto
DECLARE @grossfee decimal(19,2)
SELECT @grossfee = grossamount,
	@ycon = ycon,
	@ncon = ncon
FROM parasubcontract 
WHERE idcon = @idcon
INSERT INTO #situation	VALUES('Compenso Lordo del Contratto',@grossfee,'S')
INSERT INTO #situation VALUES(NULL,NULL,'N')
-- Dati inerenti i cedolini calcolati nell'anno
INSERT INTO #situation VALUES('C E D O L I N I  C A L C O L A T I  N E L  ' + CONVERT(varchar(4),@ayear),NULL,'N')
	
DECLARE @totalgrossfee decimal(19,2)
DECLARE @totalfeenet decimal(19,2)
-- Calcolo Compenso Lordo e Netto dei cedolini rata calcolati
-- Il Compenso Lordo dei cedolini calcolati comprende anche l'eventuale compenso lordo del cedolino di conguaglio
-- mentre bisogna sottrarre al compenso netto, le eventuali ritenute del cedolino di conguaglio
SELECT @totalgrossfee = SUM(feegross),
	@totalfeenet = SUM(netfee)
FROM payroll
WHERE idcon = @idcon
	AND flagbalance = 'N'
	AND fiscalyear = @ayear
	AND flagcomputed = 'S'
	
SET @totalfeenet = @totalfeenet - 
	ISNULL(
		(SELECT SUM(employtax)
		FROM payroll
		JOIN payrolltax
			ON payroll.idpayroll = payrolltax.idpayroll
		WHERE payroll.flagbalance = 'S'
			AND payroll.idcon = @idcon
			AND payroll.fiscalyear = @ayear)
	,0)
	
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Calcolati',@totalgrossfee,'')
INSERT INTO #situation VALUES('Compenso Netto Cedolini Calcolati',@totalfeenet,'')
CREATE TABLE #tax
(
	taxcode varchar(20),
	employtax decimal(19,2),
	admintax decimal(19,2),
	fiscalyear int
)
-- Riempimento della tabella temporanea #tax
-- Ritenute calcolate negli anni precedenti (su cedolini rata e conguaglio)
INSERT INTO #tax
SELECT taxcode,ISNULL(SUM(employtax),0),ISNULL(SUM(admintax),0),fiscalyear
FROM payrolltax
JOIN payroll
	ON payrolltax.idpayroll = payroll.idpayroll
WHERE idcon = @idcon
	AND fiscalyear < @ayear
	AND flagcomputed = 'S'
GROUP BY taxcode,fiscalyear
-- Ritenute calcolate nell'anno corrente (su cedolini rata e conguaglio)
INSERT INTO #tax
SELECT taxcode,ISNULL(SUM(employtax),0),ISNULL(SUM(admintax),0),fiscalyear
FROM payrolltax
JOIN payroll
	ON payrolltax.idpayroll = payroll.idpayroll
WHERE idcon = @idcon
	AND fiscalyear = @ayear
	AND flagcomputed = 'S'
GROUP BY taxcode,fiscalyear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('R I T E N U T E',NULL,'N')
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C / D I P E N D E N T E',NULL,'N')
INSERT INTO #situation
SELECT 
	REPLACE(tax.description,'',''''),#tax.employtax,''
FROM #tax
JOIN tax
	ON #tax.taxcode = tax.taxcode
WHERE employtax <> 0
	AND fiscalyear = @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C / A M M I N I S T R A Z I O N E',NULL,'N')
INSERT INTO #situation
SELECT 
	REPLACE(tax.description,'',''''),#tax.admintax,''
FROM #tax
JOIN tax
	ON #tax.taxcode = tax.taxcode
WHERE admintax <> 0
	AND fiscalyear = @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('O N E R I',NULL,'N')
INSERT INTO #situation
SELECT 'Totale Oneri Deducibili', SUM(totalamount),'' FROM deductibleexpense
WHERE idcon = @idcon
	AND ayear = @ayear
INSERT INTO #situation
SELECT 'Totale Oneri Detraibili', SUM(totalamount),'' FROM abatableexpense
WHERE idcon = @idcon
	AND ayear = @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C E D O L I N I  E R O G A T I  N E L  ' + CONVERT(varchar(4),@ayear),NULL,'N')
DECLARE @linkedphase char(1)
DECLARE @descrlinkedphase varchar(50)
SET @linkedphase = (SELECT expensephase FROM config WHERE ayear = @ayear)
SET @descrlinkedphase = (SELECT description FROM expensephase WHERE nphase = @linkedphase)
DECLARE @totalgrossfeepayed decimal(19,2)
DECLARE @totalfeenetpayed decimal(19,2)
SELECT 
	@totalgrossfeepayed = SUM(expensepayrollview.amount)
FROM expensepayrollview
JOIN payroll
	ON expensepayrollview.idpayroll = payroll.idpayroll
WHERE payroll.idcon = @idcon
	AND payroll.fiscalyear = @ayear
	AND payroll.flagbalance = 'N'
	AND expensepayrollview.nphase = @linkedphase
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Erogati (' + @descrlinkedphase + ')',@totalgrossfeepayed,'')
DECLARE @lastphase char(1)
DECLARE @descrlastphase varchar(50)
SET @lastphase = (SELECT MAX(nphase) FROM expensephase)
SET @descrlastphase = (SELECT description FROM expensephase WHERE nphase = @lastphase)
	
SELECT 
	@totalgrossfeepayed = SUM(payroll.feegross),
	@totalfeenetpayed   = SUM(payroll.netfee)
FROM expensepayroll
JOIN payroll
	ON expensepayroll.idpayroll = payroll.idpayroll
JOIN expenselink
	ON expenselink.idparent = expensepayroll.idexp
	AND expenselink.nlevel  = @linkedphase
JOIN expenselast 
	ON expenselink.idchild  =  expenselast.idexp
WHERE payroll.idcon = @idcon
	AND payroll.fiscalyear = @ayear
	AND payroll.flagbalance = 'N'

SET @totalfeenetpayed = @totalfeenetpayed - 
	ISNULL(
		(SELECT SUM(employtax)
		FROM payrolltax
		JOIN payroll
		ON payrolltax.idpayroll = payroll.idpayroll
		WHERE payroll.flagbalance = 'S'
		AND payroll.fiscalyear = @ayear
		AND payroll.idcon = @idcon)
	,0)
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Erogati (' + @descrlastphase + ')',@totalgrossfeepayed,'')
INSERT INTO #situation VALUES('Compenso Netto Cedolini Erogati (' + @descrlastphase + ')',@totalfeenetpayed,'')
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C E D O L I N I  C A L C O L A T I  D A  I N I Z I O  C O N T R A T T O',NULL,'N')
	
DECLARE @totalgrossfeepastyear decimal(19,2)
DECLARE @totalfeenetpastyear decimal(19,2)
	
SELECT @totalgrossfeepastyear = SUM(feegross),
	@totalfeenetpastyear = SUM(netfee)
FROM payroll
WHERE idcon = @idcon
	AND flagbalance = 'N'
	AND fiscalyear < @ayear
	AND flagcomputed = 'S'
SET @totalfeenetpastyear = @totalfeenetpastyear -
	ISNULL(
		(SELECT SUM(employtax)
		FROM payrolltax
		JOIN payroll
		ON payrolltax.idpayroll = payroll.idpayroll
		WHERE payroll.flagbalance = 'S'
		AND payroll.fiscalyear < @ayear
		AND payroll.idcon = @idcon)
	,0)
	
DECLARE @totcomplordodainiziocontratto decimal(19,2)
DECLARE @totcompnettodainiziocontratto decimal(19,2)
	
SET @totcomplordodainiziocontratto = ISNULL(@totalgrossfeepastyear,0) + ISNULL(@totalgrossfee,0)
SET @totcompnettodainiziocontratto = ISNULL(@totalfeenetpastyear,0) + ISNULL(@totalfeenet,0)
	
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Calcolati',@totcomplordodainiziocontratto,'')
INSERT INTO #situation VALUES('Compenso Netto Cedolini Calcolati',@totcompnettodainiziocontratto,'')
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('R I T E N U T E',NULL,'N')
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C / D I P E N D E N T E',NULL,'N')
INSERT INTO #situation
SELECT 
	REPLACE(tax.description,'',''''),#tax.employtax,''
FROM #tax
JOIN tax
	ON #tax.taxcode = tax.taxcode
WHERE employtax <> 0
	AND fiscalyear <= @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C / A M M I N I S T R A Z I O N E',NULL,'N')
INSERT INTO #situation
SELECT 
REPLACE(tax.description,'',''''),#tax.admintax,''
FROM #tax
JOIN tax
	ON #tax.taxcode = tax.taxcode
WHERE admintax <> 0
	AND fiscalyear <= @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('O N E R I',NULL,'N')
INSERT INTO #situation
SELECT 'Totale Oneri Deducibili', SUM(totalamount),'' FROM deductibleexpense
WHERE idcon = @idcon
	AND ayear <= @ayear
INSERT INTO #situation
SELECT 'Totale Oneri Detraibili', SUM(totalamount),'' FROM abatableexpense
WHERE idcon = @idcon
	AND ayear <= @ayear
INSERT INTO #situation VALUES(NULL,NULL,'N')
INSERT INTO #situation VALUES('C E D O L I N I  E R O G A T I  D A  I N I Z I O  C O N T R A T T O',NULL,'N')
DECLARE @totalgrossfeepayedcontratto decimal(19,2)
DECLARE @totalfeenetpayedcontratto decimal(19,2)
SELECT 
	@totalgrossfeepayedcontratto = SUM(expensepayrollview.amount)
FROM expensepayrollview
JOIN payroll
	ON expensepayrollview.idpayroll = payroll.idpayroll
WHERE payroll.idcon = @idcon
	AND payroll.fiscalyear <= @ayear
	AND payroll.flagbalance = 'N'
	AND expensepayrollview.nphase = @linkedphase
	
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Erogati (' + @descrlinkedphase + ')',@totalgrossfeepayedcontratto,'')
SELECT 
	@totalgrossfeepayedcontratto = SUM(payroll.feegross),
	@totalfeenetpayed = SUM(payroll.netfee)
FROM expensepayrollview
JOIN payroll
	ON expensepayrollview.idpayroll = payroll.idpayroll
WHERE payroll.idcon = @idcon
	AND payroll.fiscalyear <= @ayear
	AND payroll.flagbalance = 'N'
	AND expensepayrollview.nphase = @lastphase
SET @totalfeenetpayed = @totalfeenetpayed -
	ISNULL(
		(SELECT SUM(employtax)
		FROM payrolltax
		JOIN payroll
		ON payrolltax.idpayroll = payroll.idpayroll
		WHERE payroll.flagbalance = 'S'
		AND payroll.fiscalyear <= @ayear
		AND payroll.idcon = @idcon)
	,0)
INSERT INTO #situation VALUES('Compenso Lordo Cedolini Erogati (' + @descrlastphase + ')',@totalgrossfeepayedcontratto,'')
INSERT INTO #situation VALUES('Compenso Netto Cedolini Erogati (' + @descrlastphase + ')',@totalfeenetpayedcontratto,'')

SELECT value, amount, kind FROM #situation
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

