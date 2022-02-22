
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resendpccsend]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resendpccsend]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- la sp rigenera il file trasmesso, usando gli stessi dati
-- setuser 'amm'
-- compute_resendpccsend 63
CREATE procedure compute_resendpccsend( 
	@idpcc int
) as
begin

create table #dati(
	nriga int identity(1,1),
	idinvkind int,  
	yinv smallint, 
	ninv int,
	idmankind varchar(20),
	yman smallint,
	nman int,
	ycon int,
	ncon int,
	idreg int,	
	tipodocumento varchar(4),
	dataemissione datetime,
	numerodocumento varchar(20),
	importototaledocumento decimal(19,2),
	causale varchar(200),
	Imponibiletotaledocumento  decimal(19,2),
	ivatotaledocumento  decimal(19,2),
--	Pagamento	
	datariferimentopagamento datetime,
	giorniterminipagamento int,
	datascadenzapagamento datetime,
	importopagamento decimal(19,2),
--	Ricezione
	numprotocolloentrata varchar(50),
	dataricezione datetime,
	annotations varchar(400),
	resendingpcc char(1),

	aliquotaiva decimal(19,2),
	natura varchar(2),
	imponibile_peraliquota decimal(19,2),
	imposta_peraliquota decimal(19,2),
	importo_percigcup decimal(19,2),
	cigcode varchar(15),
	cupcode varchar(15),
	ipa varchar(6),
	flag_enable_split_payment char(1)
) 
-- FATTURE 
insert into #dati(
	idinvkind,  yinv, ninv,
	idreg,	
	tipodocumento,
	dataemissione ,
	numerodocumento,
	importototaledocumento,
	causale,
	Imponibiletotaledocumento,
	ivatotaledocumento,
	datariferimentopagamento,
	giorniterminipagamento,
	datascadenzapagamento,
	importopagamento,
	numprotocolloentrata ,
	dataricezione ,
	annotations ,
	resendingpcc,

	aliquotaiva,
	natura,
	imponibile_peraliquota,
	imposta_peraliquota,
	importo_percigcup,
	cigcode,
	cupcode,
	ipa,
	flag_enable_split_payment
)
select 
	I.idinvkind, I.yinv, I.ninv,
	I.idreg	,
-- tipo documento
	CASE
		WHEN PF.idinvkind is not null then 'TD06' -- parcella
		WHEN ((IK.flag&4)=0) THEN 'TD01'--fattura
		WHEN ((IK.flag&4)<>0) THEN 'TD04'-- nota di credito
	END,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),		-- numerodocumento
	-- ImportoTotaleDocumento:
	case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
	case 
		when isnull(I.flag_enable_split_payment,'N') = 'N' then I.description 
		when isnull(I.flag_enable_split_payment,'N') = 'S' then '*SP*' + '.' + isnull(I.description,'') 
	end, -- Causale	
	P.taxabletotal,		-- ImponibileTotaleDocumento
	P.taxtotal,		--	IvaTotaleDocumento
		case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when I.idexpirationkind = 1 then I.adate
		-- Data documento = Numero gg  D.F.
		when I.idexpirationkind = 2 then I.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when I.idexpirationkind = 3 then I.docdate
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when I.idexpirationkind = 4 then I.adate
		--	Pagamento Immediato  = data registrazione
		when I.idexpirationkind = 5 then I.adate
		-- Data ricezione
		when I.idexpirationkind = 6 then I.protocoldate
	else null
	end, -- DataRiferimentoPagamento
	I.paymentexpiring, -- GiorniTerminiPagamento
	-- Data Scadenza Pagamento
		case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.adate)
		when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
		-- Data documento = Numero gg  D.F.
		when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.docdate)
		when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
		when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
		when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
		--	Pagamento Immediato  = data registrazione
		when I.idexpirationkind = 5 then I.adate
		-- Data ricezione
		when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, I.protocoldate)
		when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
	else null
	end , -- DataScadenzaPagamento
	isnull(P.taxabletotal,0) + isnull(P.taxtotal,0) , -- ImportoPagamento
	I.arrivalprotocolnum, -- NumProtocolloentrata
	I.protocoldate, -- DataRicezione
	I.annotations,
	isnull(I.resendingpcc,'N'),

	P.rate,
	P.idfenature,
	P.taxabletotalbyiva,
	P.taxtotalbyiva,
	P.amountcigcup,
	P.cigcode,
	P.cupcode,
	ISNULL(I.ipa_acq,IK.ipa_fe),
	I.flag_enable_split_payment
from pccsend P
join invoiceview I 
	on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join invoicekind IK
	ON IK.idinvkind = I.idinvkind
left outer join profservice PF
	on PF.idinvkind = I.idinvkind and PF.yinv = I.yinv and PF.ninv = I.ninv
where P.idpcc = @idpcc

-- CONTRATTI PASSIVI
insert into #dati(
	idmankind,  yman, nman,
	idreg,	
	tipodocumento,
	dataemissione ,
	numerodocumento,
	importototaledocumento,
	causale,
	Imponibiletotaledocumento,
	ivatotaledocumento,
	datariferimentopagamento,
	giorniterminipagamento,
	datascadenzapagamento,
	importopagamento,
	numprotocolloentrata ,
	dataricezione ,
	annotations ,
	resendingpcc,

	aliquotaiva,
	natura,
	imponibile_peraliquota,
	imposta_peraliquota,
	importo_percigcup,
	cigcode,
	cupcode,
	ipa
	)

select 
	M.idmankind, M.yman, M.nman, 
	M.idreg	,
-- tipo documento
	'TD06', -- parcella
	M.docdate , -- dataemissione
	substring(M.doc,1,20),		-- numerodocumento
	isnull(P.taxabletotal,0) + isnull(P.taxtotal,0) ,	-- ImportoTotaleDocumento
	M.description,		-- Causale
	P.taxabletotal,		-- ImponibileTotaleDocumento
	P.taxtotal,		--	IvaTotaleDocumento
	case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when M.idexpirationkind = 1 then M.adate
		-- Data documento = Numero gg  D.F.
		when M.idexpirationkind = 2 then M.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when M.idexpirationkind = 3 then M.docdate
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when M.idexpirationkind = 4 then M.adate
		--	Pagamento Immediato  = data registrazione
		when M.idexpirationkind = 5 then M.adate
	else null
	end, -- DataRiferimentoPagamento
	M.paymentexpiring, -- GiorniTerminiPagamento
	-- Data Scadenza Pagamento
	case 
		-- Data contabile(data registrazione)  = Numero gg D.R.F.
		when (M.idexpirationkind = 1 AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, M.adate)
		when (M.idexpirationkind = 1 AND isnull(M.paymentexpiring,0)=0) then M.adate
		-- Data documento = Numero gg  D.F.
		when (M.idexpirationkind = 2 AND M.docdate is not null AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, M.docdate)
		when (M.idexpirationkind = 2 AND isnull(M.paymentexpiring,0)=0) then M.docdate
		-- Fine mese data documento = Numero gg F.M.D.F.
		when (M.idexpirationkind = 3 AND M.docdate is not null and isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.docdate) ,M.docdate))) ) 
		when (M.idexpirationkind = 3 AND M.docdate is not null and isnull(M.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.docdate) ,M.docdate)))
		-- Fine mese data contabile = Numero gg F.M.D.R.F.
		when (M.idexpirationkind = 4  and isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.adate) ,M.adate))) )
		when (M.idexpirationkind = 4  and isnull(M.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(M.adate) ,M.adate)))
		--	Pagamento Immediato  = data registrazione
		when M.idexpirationkind = 5 then M.adate
		-- Data ricezione
		when (M.idexpirationkind = 6 AND M.arrivaldate is not null AND isnull(M.paymentexpiring,0)>0) then DATEADD(day, paymentexpiring, M.arrivaldate)
		when (M.idexpirationkind = 6 AND isnull(M.paymentexpiring,0)=0) then M.arrivaldate
			else null
	end , -- DataScadenzaPagamento
	 isnull(P.taxabletotal,0) + isnull(P.taxtotal,0) , -- ImportoPagamento
	 M.arrivalprotocolnum, -- NumProtocolloentrata
	 M.arrivaldate, -- DataRicezione
	 M.annotations,
	 isnull(M.resendingpcc,'N'),
	P.rate,
	P.idfenature,
	P.taxabletotalbyiva,
	P.taxtotalbyiva,
	P.amountcigcup,
	P.cigcode,
	P.cupcode,
	MK.ipa_fe
from pccsend P
join mandate M
	on M.nman = P.nman and M.yman = P.yman and M.idmankind = P.idmankind
join mandatekind MK
	ON MK.idmankind = M.idmankind
where P.idpcc = @idpcc

-- OCCASIONALI
insert into #dati(
	ycon, ncon,
	idreg,	
	tipodocumento,
	dataemissione ,
	numerodocumento,
	importototaledocumento,
	causale,
	Imponibiletotaledocumento,
	ivatotaledocumento,
	datariferimentopagamento,
	giorniterminipagamento,
	datascadenzapagamento,
	importopagamento,
	numprotocolloentrata ,
	dataricezione ,
	annotations ,
	resendingpcc,
	aliquotaiva,
	natura,
	imponibile_peraliquota,
	imposta_peraliquota,
	importo_percigcup,
	cigcode,
	cupcode,
	ipa
	)
select 
	C.ycon, C.ncon,
	C.idreg	,
-- tipo documento
	'TD06', -- parcella
	C.adate , -- dataemissione
	convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
	isnull(P.taxabletotal,0) + isnull(P.taxtotal,0) , -- ImportoTotaleDocumento
	C.description,		-- Causale
	C.feegross,		-- ImponibileTotaleDocumento
	0,		--	IvaTotaleDocumento
	null, -- DataRiferimentoPagamento
	null, -- GiorniTerminiPagamento
	C.expiration,	-- Data Scadenza Pagamento
	C.feegross, -- ImportoPagamento
	C.arrivalprotocolnum, -- NumProtocolloentrata
	C.arrivaldate, -- DataRicezione
	C.annotations,
	isnull(C.resendingpcc,'N'),
	P.rate,
	P.idfenature,
	P.taxabletotalbyiva,
	P.taxtotalbyiva,
	P.amountcigcup,
	P.cigcode,
	P.cupcode,
	C.ipa_fe
from pccsend P
join casualcontract C 
		on P.ycon = C.ycon and P.ncon = C.ncon
where P.idpcc = @idpcc
		
declare @cf varchar(11)
declare @p_iva varchar(11)
select @cf = cf, 
	@p_iva = p_iva
	from license

-- la sezione del pagamento va compilata una sola volta.
-- la fattura porebbe avere due righe, se magari avesse due aliquote, in quel caso il blocco del pagamento andrebbe scritto solo una volta e nella prima riga
update #dati set 
		datariferimentopagamento = null,
		giorniterminipagamento = null,
		datascadenzapagamento = null,
		importopagamento = null,
		-- idem per le info del blocco ricezione
		numprotocolloentrata = null,
		dataricezione = null,
		annotations = null
where exists (select * from #dati D2
				where D2.idinvkind = #dati.idinvkind and D2.yinv = #dati.yinv  and D2.ninv = #dati.ninv
				and #dati.nriga > D2.nriga)

update #dati set 
		datariferimentopagamento = null,
		giorniterminipagamento = null,
		datascadenzapagamento = null,
		importopagamento = null,
		-- idem per le info del blocco ricezione
		numprotocolloentrata = null,
		dataricezione = null,
		annotations = null
where exists (select * from #dati D2
				where D2.idmankind = #dati.idmankind and D2.yman = #dati.yman  and D2.nman = #dati.nman
				and #dati.nriga > D2.nriga)

;with Fornitore(idreg, title, cf, IdFiscaleIvaFornitore)
as (
select distinct 
R.idreg, R.title, R.cf,
-- Se I-Italia, leggiamo la piva
-- Se J-UE, leggiamo la p.iva, che sarà valorizzata con la p.iva estera
-- Se X-Extra UE, leggiamo foreigncf, che sarà valorizzato con il codice identificativo estero
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		 else null
	end
from #dati D
join registry R
	on R.idreg = D.idreg
join residence RR
	on RR.idresidence = R.residence
)
select 
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	IPA.agencyname as 'agencyname',--@agencyname
	R.cf as 'CFfornitore',	
	case when D.idinvkind is not null then R.IdFiscaleIvaFornitore
		when D.idmankind is not null then isnull(R.IdFiscaleIvaFornitore, R.cf)
		when D.ycon is not null then isnull(R.IdFiscaleIvaFornitore, R.cf)
		end
	as 'IdFiscaleIvaFornitore',	
	R.title	as 'DenominazioneFornitore',
	@idpcc as 'lotto',  -- CONTROLLARE LA GESTIONE NEL FORM
	D.tipodocumento ,
	D.numerodocumento ,
	D.dataemissione ,
	D.importototaledocumento ,
	D.causale,
	null as 'Art73',
	D.Imponibiletotaledocumento ,
	D.ivatotaledocumento  ,

	-- Riepilogo per Aliquota/Natura
	D.aliquotaiva,
	D.natura as natura,
	SUM(imponibile_peraliquota) as 'totaleimponibileperaliquota',
	SUM(imposta_peraliquota) as 'totaleimpostaperaliquota',

	-- Distribuzione per CIG/CUP
	SUM(importo_percigcup),
	cigcode,
	cupcode,

--	PAGAMENTO
--> va comunicato o Data scadenza e Giorni, oppure Data scadenza
	case when D.datascadenzapagamento is null then D.datariferimentopagamento else null end as datariferimentopagamento,
	case when D.datascadenzapagamento is null then D.giorniterminipagamento else null end as giorniterminipagamento,
	D.datascadenzapagamento ,

-- RICEZIONE
	SUM(D.importopagamento) ,
	D.numprotocolloentrata ,
	D.dataricezione ,
	case 
		when isnull(D.flag_enable_split_payment,'N') = 'N' then D.annotations 
		when isnull(D.flag_enable_split_payment,'N') = 'S' then '*SP*' + '.' + isnull(D.annotations,'') 
	end as 'note',
	case when isnull(D.resendingpcc,'S')='S' then 'SO' else null end as 'forzaturaImissione',
	null as 'codicesegnalazione',
	null as 'descrizionesegnalazione'
from #dati D
join ipa --- IMPORTANTE!!! Deve essere un JOIN
	on D.ipa = ipa.ipa_fe
join Fornitore R
	on R.idreg = D.idreg
	group by D.ipa, IPA.agencyname,R.cf,D.idinvkind, D.yinv, D.ninv, D.idmankind, D.yman, D.nman, D.ycon, D.ncon,
		R.IdFiscaleIvaFornitore,R.title,D.tipodocumento ,
		D.numerodocumento ,	D.dataemissione ,	D.importototaledocumento ,	D.causale,D.Imponibiletotaledocumento ,
		D.ivatotaledocumento,	D.aliquotaiva,D.natura,cigcode,	cupcode,	D.datascadenzapagamento , 
		D.datariferimentopagamento ,D.giorniterminipagamento,	D.numprotocolloentrata ,	D.dataricezione ,
		D.annotations,D.resendingpcc, D.flag_enable_split_payment
	order by D.idinvkind, D.yinv, D.ninv, D.idmankind, D.yman, D.nman, D.ycon, D.ncon

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
