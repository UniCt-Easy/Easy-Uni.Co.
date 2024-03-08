
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


if OBJECTPROPERTY(object_id('exp_pagamenti_non_esitati'), 'IsProcedure') = 1
	drop procedure [exp_pagamenti_non_esitati]
go
--setuser 'amministrazione'
--exec exp_pagamenti_non_esitati 2022, {ts '2022-01-14 00:00:00.000'}, null, null, null, null, null,15
CREATE  PROCEDURE  [exp_pagamenti_non_esitati]
(
	@year	 smallint,
	@date	 datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@ndays   int
)
AS BEGIN

DECLARE  @gen_01 datetime
SET   @gen_01 = CONVERT(datetime, '01-01-' + CONVERT(char(4), year(@date)), 105)

select
	e.phase as fase,
	e.ymov as anno,
	e.nmov as numero,
	e.codefin as voce_di_bilancio,
	e.finance as descrizione_voce_di_bilancio,
	e.codeupb as codice_upb,
	e.upb as descrizione_upb,
	e.registry as anagrafica,
	e.ypay as esercizio_mandato,
	e.npay as numero_mandato,
	e.paymentadate as data_mandato,
	e.npaymenttransmission as numero_distinta_di_trasmissione,
	e.transmissiondate as data_distinta_di_trasmissione,
	e.doc as documento,
	e.docdate as data_documento,
	e.description as descrizione_documento,
	e.curramount as importo_corrente,
	e.notperformed as importo_non_esitato
from expenselastview e 
join upb on e.idupb = upb.idupb
where (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
and datediff(day, e.transmissiondate, @date) >= isnull(@ndays, 0)
and (e.ypay = @year or year(e.ypay ) < @year)
and (
	(@gen_01 <= e.transmissiondate or year(e.transmissiondate) < @year) 
	and e.transmissiondate <= @date
	)
and e.transmissiondate is not null
and e.notperformed > 0
END


