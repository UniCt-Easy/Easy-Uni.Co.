
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


if OBJECTPROPERTY(object_id('exp_mandati_idser_non_esitati'), 'IsProcedure') = 1
	drop procedure exp_mandati_idser_non_esitati
go
--setuser 'amministrazione'
--exec exp_mandati_idser_non_esitati 2020, {ts '2020-01-01 00:00:00.000'}, null, null, null, null, null
CREATE  PROCEDURE  [exp_mandati_idser_non_esitati]
(
	@year smallint,
	@date datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE  @gen_01 datetime
SET   @gen_01 = CONVERT(datetime, '01-01-' + CONVERT(char(4), year(@date)), 105)

select
	expensephase.description as fase,
	expense.ymov as anno,
	expense.nmov as numero,
	fin.codefin as voce_di_bilancio,
	fin.title as descrizione_voce_di_bilancio,
	upb.codeupb as codice_upb,
	upb.title as descrizione_upb,
	registry.title as anagrafica,
	payment.ypay as esercizio_mandato,
	payment.npay as numero_mandato,
	payment.adate as data_mandato,
	paymenttransmission.npaymenttransmission as numero_distinta_di_trasmissione,
	paymenttransmission.transmissiondate as data_distinta_di_trasmissione,
	expense.doc as documento,
	expense.docdate as data_documento,
	expense.description as descrizione_documento,
	expensetotal.curramount as importo_corrente,
	service.description as descrizione_tipo_prestazione,
	clawback.description as descrizione_recupero,
	expenselast.nbill as sospeso_passivo
from (
	select * from (
		SELECT expense.idexp,
			(
				SELECT SUM(curramount)
				from expensetotal I
				join expense S on I.idexp=S.idexp 
				JOIN expenselast EL ON EL.idexp = S.idexp
				WHERE EL.idexp=expenselast.idexp AND I.ayear = payment.ypay)
				-
				ISNULL((SELECT SUM(amount) from banktransaction P where P.idexp=expenselast.idexp),0
			) as mandatediff
		FROM expense (nolock)
		JOIN expenselast	(nolock)		ON expenselast.idexp = expense.idexp
		LEFT OUTER JOIN payment	(nolock)	ON payment.kpay = expenselast.kpay
		LEFT OUTER JOIN paymenttransmission on payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
		JOIN expenseyear	(nolock)		ON expenseyear.idexp = expense.idexp
		LEFT OUTER JOIN upb	(nolock)		ON upb.idupb = expenseyear.idupb
		where expenselast.idser is not null
		and expense.ymov = @year
		and (@gen_01 <= paymenttransmission.transmissiondate and paymenttransmission.transmissiondate <= @date or paymenttransmission.kpaymenttransmission is null )
	) x
	where mandatediff > 0
) non_esitati
INNER JOIN expense on expense.idexp = non_esitati.idexp
JOIN expensephase	(nolock)		ON expensephase.nphase = expense.nphase
JOIN expenseyear	(nolock)		ON expenseyear.idexp = expense.idexp
JOIN expensetotal	(nolock)		ON expensetotal.idexp = expense.idexp AND expensetotal.ayear = expenseyear.ayear
LEFT OUTER JOIN expense parentexpense (nolock)	ON parentexpense.idexp = expense.parentidexp
JOIN expenselast	(nolock)		ON expenselast.idexp = expense.idexp
LEFT OUTER JOIN fin	(nolock)		ON fin.idfin = expenseyear.idfin
LEFT OUTER JOIN upb	(nolock)		ON upb.idupb = expenseyear.idupb
LEFT OUTER JOIN registry(nolock)	ON registry.idreg = expense.idreg
LEFT OUTER JOIN service	 (nolock)	ON service.idser = expenselast.idser
LEFT OUTER JOIN payment	(nolock)	ON payment.kpay = expenselast.kpay
LEFT OUTER JOIN registry deputy	(nolock)	ON deputy.idreg = expenselast.iddeputy
LEFT OUTER JOIN clawback	(nolock)		ON clawback.idclawback = expense.idclawback
LEFT OUTER JOIN expenseyear expenseyear_starting (nolock) ON expenseyear_starting.idexp = expense.idexp AND expenseyear_starting.ayear = expense.ymov
LEFT OUTER JOIN paymenttransmission on payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission
AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
 
END

