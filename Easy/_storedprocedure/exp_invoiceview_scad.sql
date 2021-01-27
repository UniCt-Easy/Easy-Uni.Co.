
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoiceview_scad]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoiceview_scad]
GO

CREATE   PROCEDURE [exp_invoiceview_scad](
	@year 			int,
	@start 			smalldatetime,
	@stop 			smalldatetime,
	@idinvkind 		int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) 
AS BEGIN

SELECT
	  [codeinvkind] as Codice,
	  [invoicekind] as [Tipo Documento],
      [yinv] as Esercizio,
      [ninv] as Numero,
      [flagbuysell] as [Vendita/Acquisto],
      [registry] as [Anagrafica],
      [ipa_fe] as [Codice IPA],
      [description] as [Descrizione],
	case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when  idexpirationkind = 1 then 'D.R.F.'
		-- Data documento = Numero gg  D.F.
		when  idexpirationkind = 2 then 'D.F.'
		-- Fine mese data documento = Numero gg F.M.D.F.
		when  idexpirationkind = 3 then 'F.M.D.F.'
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when  idexpirationkind = 4 then 'F.M.D.R.F.'
		--	Pagamento Immediato  = data registrazione
		when  idexpirationkind = 5 then 'Pagamento Immediato'
		-- Data ricezione
		when  idexpirationkind = 6 then '% D.Ric.F.'
	else null
	end as 'Tipo scadenza',
	case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when  idexpirationkind = 1 then  adate
		-- Data documento = Numero gg  D.F.
		when  idexpirationkind = 2 then  docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when  idexpirationkind = 3 then  docdate
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when  idexpirationkind = 4 then  adate
		--	Pagamento Immediato  = data registrazione
		when  idexpirationkind = 5 then  adate
		-- Data ricezione
		when  idexpirationkind = 6 then  protocoldate
	else null
	end as 'Data Riferimento',
	 paymentexpiring as 'Giorni',
		case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when ( idexpirationkind = 1 AND isnull( paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  adate)
		when ( idexpirationkind = 1 AND isnull( paymentexpiring,0)=0) then  adate
		-- Data documento = Numero gg  D.F.
		when ( idexpirationkind = 2 AND  docdate is not null AND isnull( paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  docdate)
		when ( idexpirationkind = 2 AND isnull( paymentexpiring,0)=0) then  docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when ( idexpirationkind = 3 AND  docdate is not null and isnull( paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY( docdate) , docdate))) ) 
		when ( idexpirationkind = 3 AND  docdate is not null and isnull( paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY( docdate) , docdate)))
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when ( idexpirationkind = 4  and isnull( paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY( adate) , adate))) )
		when ( idexpirationkind = 4  and isnull( paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY( adate) , adate)))
		--	Pagamento Immediato  = data registrazione
		when  idexpirationkind = 5 then  adate
		-- Data ricezione
		when ( idexpirationkind = 6 AND  protocoldate is not null AND isnull( paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  protocoldate)
		when ( idexpirationkind = 6 AND isnull( paymentexpiring,0)=0) then  protocoldate
	else null
	end as 'Data Scadenza',
	
    [currency] as Valuta,
    [exchangerate] as [Cambio],
    [doc] as Documento ,
    [docdate] as [Data documento],
    [adate] as [Data Registrazione],
    [protocoldate] as [Data Ricezione],
    [flagdeferred] as [Iva differita],
    [taxable] as [Imponibile],
    [tax] as [Iva],
    [unabatable] as [Iva indetraibile],
    [total] as [Totale],
    [nelectronicinvoice] as [N. Fatt. Elettr.],
    [yelectronicinvoice] as [Eserc. Fatt. Elettr.],
    [iduniqueregister] as [N. Registro unico],
    [arrivalprotocolnum] as [N. Prot. Arrivo]
  FROM [invoiceview]		
  WHERE  yinv=@year
	AND ((@start is null) OR (adate >= @start))
	AND ((@stop is null) OR (adate <= @stop))
	AND ((@idinvkind is null) OR (idinvkind = @idinvkind))
	AND (@idsor01 IS NULL OR idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR idsor05 = @idsor05)

END






GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
