
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_indicatori_consorzio_toscana_doc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_indicatori_consorzio_toscana_doc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- setuser 'amministrazione'
--	exec exp_indicatori_consorzio_toscana_doc 2023, {d '2023-01-01'}, {d '2023-12-31'}  
 
CREATE PROCEDURE [exp_indicatori_consorzio_toscana_doc]
(
	@ayear			int,
	@start			date ,
	@stop			date  
)
AS
BEGIN


--  7 - Variazioni di Budget

SELECT 
	'Autonomi Occasionali' as 'Oggetto' ,
	casualcontract.ycon as 'Eserc.',
	convert(varchar(20),casualcontract.ncon) as 'Num.',
	null  as 'Tipo documento',
	convert(varchar, casualcontract.ct, 105) + ' ' + convert(varchar, casualcontract.ct, 108) as 'Creazione', --114
	casualcontract.cu as 'Utente creazione', 
	convert(varchar, casualcontract.lt, 105) + ' ' + convert(varchar, casualcontract.lt, 108) as 'Ultima modifica', 
	casualcontract.lu as 'Ultimo utente'
FROM casualcontract 
where ycon = @ayear and adate between @start and @stop

union

SELECT 
	'Autonomi Professionali' as 'Oggetto' ,
	profservice.ycon as 'Eserc.',
	convert(varchar(20),profservice.ncon) as 'Num.',
	null  as 'Tipo documento',
	convert(varchar, profservice.ct, 105) + ' ' + convert(varchar, profservice.ct, 108) as 'Creazione', --114
	profservice.cu as 'Utente creazione', 
	convert(varchar, profservice.lt, 105) + ' ' + convert(varchar, profservice.lt, 108) as 'Ultima modifica', 
	profservice.lu as 'Ultimo utente'
FROM profservice 
where ycon = @ayear and adate between @start and @stop

union

SELECT 
	'Dipendenti' as 'Oggetto' ,
	wageaddition.ycon as 'Eserc.',
	convert(varchar(20),wageaddition.ncon) as 'Num.',
	null  as 'Tipo documento',
	convert(varchar, wageaddition.ct, 105) + ' ' + convert(varchar, wageaddition.ct, 108) as 'Creazione', --114
	wageaddition.cu as 'Utente creazione', 
	convert(varchar, wageaddition.lt, 105) + ' ' + convert(varchar, wageaddition.lt, 108) as 'Ultima modifica', 
	wageaddition.lu as 'Ultimo utente'
FROM wageaddition 
where ycon = @ayear and adate between @start and @stop

union

SELECT 
	'Missione' as 'Oggetto' ,
	itineration.yitineration as 'Eserc.',
	convert(varchar(20),itineration.nitineration) as 'Num.',
	null  as 'Tipo documento',
	convert(varchar, itineration.ct, 105) + ' ' + convert(varchar, itineration.ct, 108) as 'Creazione', --114
	itineration.cu as 'Utente creazione', 
	convert(varchar, itineration.lt, 105) + ' ' + convert(varchar, itineration.lt, 108) as 'Ultima modifica', 
	itineration.lu as 'Ultimo utente'
FROM itineration 
where yitineration = @ayear and adate between @start and @stop

union

SELECT 
	'Cedolino parasubordinati' as 'Oggetto' ,
	payroll.fiscalyear as 'Eserc.',
	convert(varchar(20),payroll.npayroll) 
	+ ' ('
	+ 'Contratto ' + convert(varchar(20),parasubcontract.ncon) +'/'	+ convert(varchar(20),parasubcontract.ycon) 
	+ ')'
	as 'Num.',
	null  as 'Tipo documento',
	convert(varchar, payroll.ct, 105) + ' ' + convert(varchar, payroll.ct, 108) as 'Creazione', --114
	payroll.cu as 'Utente creazione', 
	convert(varchar, payroll.lt, 105) + ' ' + convert(varchar, payroll.lt, 108) as 'Ultima modifica', 
	payroll.lu as 'Ultimo utente'
FROM payroll 
join parasubcontract
	ON payroll.idcon=parasubcontract.idcon
where payroll.fiscalyear = @ayear and payroll.ct between @start and @stop


union

SELECT 
	'Fattura' as 'Oggetto' ,
	invoice.yinv as 'Eserc.',
	convert(varchar(20),invoice.ninv) as 'Num.',
	convert(varchar(50),invoicekind.description)  as 'Tipo documento',
	convert(varchar, invoice.ct, 105) + ' ' + convert(varchar, invoice.ct, 108) as 'Creazione', --114
	invoice.cu as 'Utente creazione', 
	convert(varchar, invoice.lt, 105) + ' ' + convert(varchar, invoice.lt, 108) as 'Ultima modifica', 
	invoice.lu as 'Ultimo utente'
FROM invoice 
join invoicekind
	on invoice.idinvkind = invoicekind.idinvkind
where  invoice.yinv = @ayear and invoice.adate between @start and @stop

union

SELECT 
	'Contratto Attivo' as 'Oggetto' ,
	estimate.yestim as 'Eserc.',
	convert(varchar(20),estimate.nestim) as 'Num.',
	convert(varchar(50),estimatekind.description)  as 'Tipo documento',
	convert(varchar, estimate.ct, 105) + ' ' + convert(varchar, estimate.ct, 108) as 'Creazione', --114
	estimate.cu as 'Utente creazione', 
	convert(varchar, estimate.lt, 105) + ' ' + convert(varchar, estimate.lt, 108) as 'Ultima modifica', 
	estimate.lu as 'Ultimo utente'
FROM estimate 
join estimatekind
	on estimate.idestimkind = estimatekind.idestimkind
where  estimate.yestim = @ayear and estimate.adate between @start and @stop

union

SELECT 
	'Contratto Passivo' as 'Oggetto' ,
	mandate.yman as 'Eserc.',
	convert(varchar(20),mandate.nman) as 'Num.',
	convert(varchar(50),mandatekind.description)  as 'Tipo documento',
	convert(varchar, mandate.ct, 105) + ' ' + convert(varchar, mandate.ct, 108) as 'Creazione', --114
	mandate.cu as 'Utente creazione', 
	convert(varchar, mandate.lt, 105) + ' ' + convert(varchar, mandate.lt, 108) as 'Ultima modifica', 
	mandate.lu as 'Ultimo utente'
FROM mandate 
join mandatekind
	on mandate.idmankind = mandatekind.idmankind
where  mandate.yman = @ayear and mandate.adate between @start and @stop

union

SELECT 
	'Fondo economale' as 'Oggetto' ,
	pettycashoperation.yoperation as 'Eserc.',
	convert(varchar(20),pettycashoperation.noperation) as 'Num.',
	convert(varchar(50),pettycash.description)  as 'Tipo documento',
	convert(varchar, pettycashoperation.ct, 105) + ' ' + convert(varchar, pettycashoperation.ct, 108) as 'Creazione', --114
	pettycashoperation.cu as 'Utente creazione', 
	convert(varchar, pettycashoperation.lt, 105) + ' ' + convert(varchar, pettycashoperation.lt, 108) as 'Ultima modifica', 
	pettycashoperation.lu as 'Ultimo utente'
FROM pettycashoperation 
join pettycash
	on pettycashoperation.idpettycash = pettycash.idpettycash
where  pettycashoperation.yoperation = @ayear and pettycashoperation.adate between @start and @stop

END

GO

