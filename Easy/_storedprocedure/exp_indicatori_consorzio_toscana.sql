
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indicatori_consorzio_toscana]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indicatori_consorzio_toscana]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- exec exp_indicatori_consorzio_toscana 2023, {d '2023-01-01'}, {d '2023-07-16'}  ,'0'
 
CREATE PROCEDURE [exp_indicatori_consorzio_toscana]
(
	@ayear			int,
	@start			date ,
	@stop			date  ,
	@kind			char(1)
)
AS
BEGIN
 

/*
come da colloquio odierno con il Dot. Perna sono a richiedere le modalità per l’estrapolazione dei seguenti dati attraverso l’uso del software in uso:

su base annuale
n° risconti
n° documenti propedeutici prodotti
n° bozze predisposte
n° beni inventario
 

su base mensile:
n° impegni e accertamenti
n° liquidazioni e pagamenti
n° riscossioni/n° canali di riscossione
n° variazioni di BUDGET (accountvar)
*/


/*
contratto occasionale 
parcella
altricompensi
missione
cedolino parasubordinati
fattura 
contratto passivo
contratto attivo
fondo economale
elaborazione stipendiale ?
distinta trasmissione pagamento?
distinta trasmissione incasso ?
*/

--		1 - Risconti
--		2 - Doc. Propedeutici  [*1]
--		3 - Bozze Predisposte
--		4 - Cespiti inventariati
--		5 - Impegni di Budget
--		6 - Accertamenti di Budget
--		7 - Pagamenti
--		8 - Riscossioni
--		9 - Variazioni di Budget

if (@kind = 0)
Begin
	exec exp_indicatori_consorzio_toscana_countall @ayear , @start, @stop
	return
End
--		1 - Risconti
--if (@kind = 1)
--Begin
--	exec exp_indicatori_consorzio_toscana_risconti @ayear , @start, @stop
--	return
--End
--		2 - Doc. Propedeutici  [*1]
if (@kind = 2)
Begin
	exec exp_indicatori_consorzio_toscana_doc @ayear , @start, @stop
	return
End
--		3 - Bozze Predisposte
--if (@kind = 3)
--Begin
--	exec exp_indicatori_consorzio_toscana_bozze @ayear , @start, @stop
--	return
--End
--		4 - Cespiti inventariati
if (@kind = 4)
Begin
	exec exp_indicatori_consorzio_toscana_cespiti @ayear , @start, @stop
	return
End
--		5 - Impegni di Budget
if (@kind = 5)
Begin
	exec exp_indicatori_consorzio_toscana_epexp @ayear , @start, @stop
	return
End
--		6 - Accertamenti di Budget
if (@kind = 6)
Begin
	exec exp_indicatori_consorzio_toscana_epacc @ayear , @start, @stop
	return
End
--		7 - Pagamenti
if (@kind = 7)
Begin
	exec exp_indicatori_consorzio_toscana_pagamenti @ayear , @start, @stop
	return
End
--		8 - Riscossioni
if (@kind = 8)
Begin
	exec exp_indicatori_consorzio_toscana_incassi @ayear , @start, @stop
	return
End
--		9 - Variazioni di Budget
if (@kind = 9)
Begin
	exec exp_indicatori_consorzio_toscana_varbudget @ayear , @start, @stop
	return
End


END

GO
