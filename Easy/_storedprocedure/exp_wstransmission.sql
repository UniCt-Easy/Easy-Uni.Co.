
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_wstransmission]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_wstransmission]
GO
 
 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE exp_wstransmission(
	@year 			int,
	@start 			datetime,
	@stop 			datetime,
	@mode			char(1) -- T : tutti, K :  solo KO
) 
AS BEGIN
--exec exp_wstransmission 2024, null, null,'T'
	
	select 
			w.ywebpayment as 'Eserc.prenotazione web',	w.nwebpayment as 'Num.prenotazione web',	w.adate as 'Data contabile',
			isnull(t.description,cd.description) as Descrizione, 
			w.surname as Cognome,
			w.forename as Nome,
			w.CF, 
			w.idreg as 'Codice Anagrafica',
			--w.email,
						 (SELECT sum((webpaymentdetail.price * webpaymentdetail.number)+case when webpaymentdetail.tax is null then 0 else webpaymentdetail.tax end)
														FROM webpayment
														JOIN webpaymentdetail ON webpayment.idwebpayment = webpaymentdetail.idwebpayment
														WHERE webpayment.nwebpayment = w.nwebpayment and webpayment.ywebpayment=w.ywebpayment
														GROUP BY webpayment.ywebpayment, webpayment.nwebpayment) as 'Prezzo totale',

			s.description  as 'Stato pagamento web',
			w.idflussocrediti as 'N.Flusso Crediti',
			-- w.IUV as 'IUV pagamento web',
			cd.IUV as 'IUV flusso crediti',
			cd.iduniqueformcode as 'Codice bollettino',
			rt.importopagato as 'Importo pagato',
			-- 0  Pagamento eseguito, 1 Pagamento non eseguito, 2 Pagamento parzialmente eseguito, 3 Decorrenza termini, 4 Decorrenza termini parziale
			case 
				when (rt.codiceesitopagamento = 0) then 'Pagamento eseguito'
				when (rt.codiceesitopagamento = 1) then 'Pagamento non eseguito'
				when (rt.codiceesitopagamento = 2) then 'Pagamento parzialmente eseguito'
				when (rt.codiceesitopagamento = 3) then 'Decorrenza termini'
				when (rt.codiceesitopagamento = 4) then 'Decorrenza termini parziale'
				else null 
				end as 'Esito pagamento',
			rt.dataesitopagamento as 'Data esito pagamento',

			s1.description  as 'Stato trasmissione',
			t.serverresponse  as 'Server response'
			 from webpayment W
			join webpaymentstatus s
				on w.idwebpaymentstatus  = s.idwebpaymentstatus
			left outer join flussoricevutatelematica RT
				on w.iuv = rt.iuv
			left outer join flussocrediti c
				on w.idflussocrediti = c.idflusso
			left outer join flussocreditidetail cd
				on w.idflussocrediti = cd.idflusso
			left outer join wstransmission t
				on t.idflussocrediti = w.idflussocrediti
			left outer join wstransmissionstatus s1
				on t.idwstransmissionstatus = s1.idwstransmissionstatus
			where ( w.ywebpayment = @year or @year is null )
				and (w.adate >= @start or  @start is null)
				and  (w.adate <= @stop or  @stop is null)
				and (@mode = 'K' and t.serverresponse  is not null
					or	
					@mode = 'T'
					)

			
		
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


