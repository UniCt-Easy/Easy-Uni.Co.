
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_pettycash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_pettycash]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--  exec show_pettycash  {ts '2012-12-31 00:00:00'},2012,5

CREATE                  PROCEDURE [show_pettycash]
	@date datetime,
	@ayear smallint,
	@idpettycash int
AS BEGIN

DECLARE	@departmentname varchar(150)
SET  @departmentname = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and (start is null or start <= @date) 
				and (stop is null or stop >= @date)
				),'')

CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))

INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
INSERT INTO #situation VALUES ('Situazione al ' + CONVERT(char(8), @date, 3), NULL, 'H')

DECLARE @pettycash varchar(50)
SELECT @pettycash = description 
FROM pettycash
WHERE idpettycash = @idpettycash

INSERT INTO #situation VALUES ('Fondo ' + @pettycash, NULL, 'H')
INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear), NULL, 'H')
INSERT INTO #situation VALUES ('', NULL, 'N')
-- Apertura
DECLARE @O_amount decimal(19,2)
SELECT @O_amount = SUM(amount)
FROM pettycashoperation
WHERE yoperation = @ayear AND 
	( (flag& 1)<>0 ) AND 
	adate <= @date AND 
	idpettycash = @idpettycash
	
DECLARE @O_amount_emitted decimal(19,2)
SELECT @O_amount_emitted =  SUM(curramount) 
FROM expenselastview
join payment 
  on expenselastview.kpay = payment.kpay
join pettycashexpense 
  on pettycashexpense.idexp = expenselastview.idexp
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashexpense.yoperation
  and pettycashoperation.noperation = pettycashexpense.noperation
  and pettycashoperation.idpettycash = pettycashexpense.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 1)<>0 ) AND 
	payment.adate <= @date AND  --- mandati emessi entro la data
	pettycashoperation.idpettycash = @idpettycash  


DECLARE @O_amount_transmitted decimal(19,2)
SELECT @O_amount_transmitted =  SUM(curramount) 
FROM expenselastview
join payment 
  on expenselastview.kpay = payment.kpay
join paymenttransmission 
  on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
join pettycashexpense 
  on pettycashexpense.idexp = expenselastview.idexp
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashexpense.yoperation
  and pettycashoperation.noperation = pettycashexpense.noperation
  and pettycashoperation.idpettycash = pettycashexpense.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 1)<>0 ) AND 
	paymenttransmission.transmissiondate <= @date AND  --- mandati trasmessi entro la data
	pettycashoperation.idpettycash = @idpettycash   	


-- Reintegro
DECLARE @R_amount decimal(19,2)
SELECT @R_amount = SUM(amount)
FROM pettycashoperation
WHERE yoperation = @ayear AND 
	( (flag& 2)<>0 ) AND 
	adate <= @date AND 
	idpettycash = @idpettycash

INSERT INTO #situation VALUES ('TOTALE ENTRATE', 
	ISNULL(@O_amount, 0) + ISNULL(@R_amount, 0), 'S')
INSERT INTO #situation VALUES ('di cui: ', NULL, 'N')
INSERT INTO #situation VALUES ('Apertura', @O_amount, '')
INSERT INTO #situation VALUES ('Reintegri', @R_amount, '')
INSERT INTO #situation VALUES('',NULL,'H')

-- Spese non attribuite
DECLARE @exp_notassign decimal(19,2)
	SELECT @exp_notassign = SUM(amount)
	FROM pettycashoperation
	WHERE yoperation = @ayear
		AND ( (flag& 8)<>0 )
		AND yrestore IS NULL
		AND nrestore IS NULL
		AND idfin IS NULL
		AND idexp IS NULL
		AND adate <= @date 
		AND idpettycash = @idpettycash

-- Spese non reintegrate
DECLARE @exp_notsheet decimal(19,2)
SELECT @exp_notsheet = SUM(amount)
FROM pettycashoperation
WHERE yoperation = @ayear
	AND ( (flag& 8)<>0 )
	AND yrestore IS NULL
	AND nrestore IS NULL
	AND (idfin IS NOT NULL	OR idexp IS NOT NULL)
	AND adate <= @date
	AND idpettycash = @idpettycash

-- Spese reintegrate
DECLARE @exp_sheet decimal(19,2)
SELECT @exp_sheet = SUM(amount)
FROM pettycashoperation
WHERE yoperation = @ayear 
	AND ( (flag& 8)<>0 )
	AND yrestore IS NOT NULL
	AND nrestore IS NOT NULL
	AND (idfin IS NOT NULL OR idexp IS NOT NULL)
	AND adate <= @date
	AND idpettycash = @idpettycash
	
DECLARE @emitted_payment_sheet decimal(19,2)
SELECT  @emitted_payment_sheet =  SUM(curramount) 
FROM expenselastview
join payment 
  on expenselastview.kpay = payment.kpay
join pettycashexpense 
  on pettycashexpense.idexp = expenselastview.idexp
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashexpense.yoperation
  and pettycashoperation.noperation = pettycashexpense.noperation
  and pettycashoperation.idpettycash = pettycashexpense.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 2)<>0 ) AND 
	payment.adate <= @date AND  --- mandati emessi entro la data
	pettycashoperation.idpettycash = @idpettycash   	
	
DECLARE @transmitted_payment_sheet decimal(19,2)
SELECT  @transmitted_payment_sheet =  SUM(curramount) 
FROM expenselastview
join payment 
  on expenselastview.kpay = payment.kpay
join paymenttransmission 
  on paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
join pettycashexpense 
  on pettycashexpense.idexp = expenselastview.idexp
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashexpense.yoperation
  and pettycashoperation.noperation = pettycashexpense.noperation
  and pettycashoperation.idpettycash = pettycashexpense.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 2)<>0 ) AND 
	paymenttransmission.transmissiondate <= @date AND  --- mandati trasmessi entro la data
	pettycashoperation.idpettycash = @idpettycash   	
	
-- Chiusura
DECLARE @C_amount decimal(19,2)
SELECT @C_amount = SUM(amount) 
FROM pettycashoperation
WHERE yoperation = @ayear AND 
	( (flag& 4)<>0 ) AND 
	adate <= @date AND 
	idpettycash = @idpettycash
	
DECLARE @C_amount_emitted decimal(19,2)
SELECT @C_amount_emitted =  SUM(curramount) 
FROM incomelastview
join proceeds 
  on incomelastview.kpro = proceeds.kpro
join pettycashincome
  on pettycashincome.idinc = incomelastview.idinc
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashincome.yoperation
  and pettycashoperation.noperation = pettycashincome.noperation
  and pettycashoperation.idpettycash = pettycashincome.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 4)<>0 ) AND 
	proceeds.adate <= @date AND  --- reversali emesse entro la data
	pettycashoperation.idpettycash = @idpettycash   
	
	
DECLARE @C_amount_transmitted decimal(19,2)
SELECT @C_amount_transmitted =  SUM(curramount) 
FROM incomelastview
join proceeds 
  on incomelastview.kpro = proceeds.kpro
join proceedstransmission 
  on proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
join pettycashincome
  on pettycashincome.idinc = incomelastview.idinc
join pettycashoperation 
  on pettycashoperation.yoperation = pettycashincome.yoperation
  and pettycashoperation.noperation = pettycashincome.noperation
  and pettycashoperation.idpettycash = pettycashincome.idpettycash
WHERE pettycashoperation.yoperation = @ayear AND 
	( (pettycashoperation.flag& 4)<>0 ) AND 
	proceedstransmission.transmissiondate <= @date AND  --- reversali emesse entro la data
	pettycashoperation.idpettycash = @idpettycash   



INSERT INTO #situation VALUES ('TOTALE USCITE', 
	ISNULL(@exp_notassign, 0) + 
	ISNULL(@exp_notsheet, 0) + 
	ISNULL(@exp_sheet, 0) + 
	ISNULL(@C_amount, 0), 'S')
INSERT INTO #situation VALUES ('di cui: ', NULL, 'N')
INSERT INTO #situation VALUES ('Spese non attribuite', @exp_notassign, '')

INSERT INTO #situation VALUES ('Spese attribuite e non reintegrate', @exp_notsheet, '')

INSERT INTO #situation VALUES ('Spese attribuite e reintegrate', @exp_sheet, '')
INSERT INTO #situation VALUES ('di cui: ', NULL, 'N')
INSERT INTO #situation VALUES ('............Mandati emessi', @emitted_payment_sheet, '')
INSERT INTO #situation VALUES ('............Mandati trasmessi', @transmitted_payment_sheet, '')

INSERT INTO #situation VALUES ('Chiusura', @C_amount, '')
INSERT INTO #situation VALUES('',NULL,'H')

INSERT INTO #situation VALUES ('SALDO', 
	ISNULL(@O_amount, 0) - 
	ISNULL(@exp_notassign, 0) - 
	ISNULL(@exp_notsheet, 0) - 
	ISNULL(@exp_sheet, 0) + 
	ISNULL(@R_amount, 0) - 
	ISNULL(@C_amount, 0), 'S')
	
INSERT INTO #situation VALUES ('SALDO FINANZIARIO (Mandati emessi alla data)', 
	-- apertura
	ISNULL(@O_amount_emitted, 0) - 
	-- totale uscite
	ISNULL(@exp_notassign, 0) - 
	ISNULL(@exp_notsheet, 0) - 
	ISNULL(@exp_sheet, 0) + 
	-- reintegri emessi
	ISNULL(@emitted_payment_sheet, 0) - 
	--chiusura
	ISNULL(@C_amount_emitted, 0), 'S')
	
INSERT INTO #situation VALUES ('SALDO FINANZIARIO (Mandati trasmessi alla data)', 
	--apertura 
	ISNULL(@O_amount_transmitted, 0) -
	--totale uscite 
	ISNULL(@exp_notassign, 0) - 
	ISNULL(@exp_notsheet, 0) - 
	ISNULL(@exp_sheet, 0) + 
	--reintegri trasmessi
	ISNULL(@transmitted_payment_sheet, 0) - 
	--chiusura
	ISNULL(@C_amount_transmitted, 0), 'S')
	
SELECT value, amount, kind FROM #situation
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




