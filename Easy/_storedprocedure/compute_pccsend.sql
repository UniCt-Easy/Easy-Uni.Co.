
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_pccsend]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_pccsend]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- il parametro è la data contabile. Quindi prendiamo tutte le operazioni emesse alla data contabile,
-- contabilizzate alla data, pagate alla data, scadute ala data...
-- setuser 'amm'
-- exec compute_pccsend {d '2016-12-31'}, null, null, null, null, null
CREATE procedure compute_pccsend( 
	@adate datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) as
begin

declare @1luglio2014 datetime
set @1luglio2014 = {d '2014-07-01'}

create table #dati(
	nriga int identity(1,1),
	idinvkind int,  
	yinv smallint, 
	ninv int,
	rownuminv int,
	idmankind varchar(20),
	yman smallint,
	nman int,
	rownumman int,
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
	datacontabiledocumento datetime, 
	datariferimentopagamento datetime,
	giorniterminipagamento int,
	datascadenzapagamento datetime,
	importopagamento decimal(19,2),
	numprotocolloentrata varchar(50),
	dataricezione datetime,
	annotations varchar(400),
	resendingpcc char(1),

	aliquotaiva decimal(19,2),
	natura varchar(2),
	imponibile decimal(19,2),
	imposta decimal(19,2),
	cigcode varchar(15),
	cupcode varchar(15),
	ipa varchar(6),
	autoinvoice char(1),
	flag_enable_split_payment char(1)
) 
-------------------------------------------------------------------------------------------
set @1luglio2014 = {d '2014-07-01'}

create table #dettfatturacigcup(
	idinvkind int,  
	yinv int, 
	ninv int,
	rownum int,
	cigcode varchar(15),
	cupcode varchar(15)
)

-- FATTURE non collegate a C.P.
	insert into #dettfatturacigcup(idinvkind, yinv, ninv,  rownum, cigcode, cupcode )
	SELECT ID.idinvkind, ID.yinv, ID.ninv, ID.rownum, ID.cigcode, ID.cupcode
	FROM invoice I
	join invoicekind IK				on I.idinvkind = IK.idinvkind
	join invoicedetailview ID		on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv	and I.ninv = ID.ninv	
	join uniqueregister RU			on RU.idinvkind = I.idinvkind and RU.yinv = I.yinv and RU.ninv = I.ninv
	join registry R					on I.idreg = R.idreg
	join residence RR				on R.residence=RR.idresidence
	where ID.idmankind is null -- > Fatture non collegate a Ordini
		and (ID.cigcode is not null OR ID.cupcode is not null)
		and I.docdate between @1luglio2014 and @adate 
		and ( not exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			OR isnull(I.resendingpcc,'N') = 'S'		)
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
		AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(ID.flagbit,0) & 4) = 0
		AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
		and RR.coderesidence='I'

-- FATTURE collegate a C.P.
-- Contabilizzazione docum o solo imponibile.
-- Se abbiamo una fattura con un dettaglio, associato a CP, contabilizzato come imposta o come solo imponibile, su due bilanci diversi.
-- se il cig/cup non è nel dettaglio CP, e neanche nella spesa, e neanche sull'upb lo leggiamo dal bilancio che contabilizza l'imponibile
	insert into #dettfatturacigcup(idinvkind, yinv, ninv, rownum,cigcode, cupcode)
	SELECT  ID.idinvkind, ID.yinv, ID.ninv, ID.rownum,
		isnull(E1.cigcode, ISNULL(MD.cigcode, ISNULL(M.cigcode,ISNULL(U.cigcode,'')))),
		ISNULL(E1.cupcode, ISNULL(MD.cupcode, ISNULL(U.cupcode, ISNULL(F.cupcode,''))))
	FROM invoice I
	join invoicekind IK					on I.idinvkind = IK.idinvkind
	join invoicedetailview ID			on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv	 and I.ninv = ID.ninv	
	join uniqueregister RU				on RU.idinvkind = I.idinvkind and RU.yinv = I.yinv and RU.ninv = I.ninv
	join mandatedetail MD				on ID.idmankind = MD.idmankind and ID.yman = MD.yman and ID.nman = MD.nman and ID.manrownum = MD.rownum
	join mandate M						on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	left outer join expense E1			on E1.idexp = MD.idexp_taxable
	left outer join expenseyear EY1		on E1.idexp = EY1.idexp and E1.ymov = EY1.ayear
	left outer join upb U				on EY1.idupb = U.idupb
	left outer join finlast F			on EY1.idfin = F.idfin
	join registry R						on I.idreg = R.idreg
	join residence RR					on R.residence=RR.idresidence
	where I.docdate between @1luglio2014 and @adate 
		-- DOCUM, IMPON, o nessuna contabilizzazione
		and ( MD.idexp_iva = MD.idexp_taxable or MD.idexp_taxable is not null or ( MD.idexp_iva is null and  MD.idexp_taxable is null ))
		and ( not exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
		OR	isnull(I.resendingpcc,'N') = 'S'		)
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
		AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
		and RR.coderesidence='I'
		AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(ID.flagbit,0) & 4) = 0

-- contabilizzazione solo imposta
	insert into #dettfatturacigcup(idinvkind, yinv, ninv, rownum,cigcode, cupcode)
	SELECT  ID.idinvkind, ID.yinv, ID.ninv, ID.rownum,
		isnull(E1.cigcode, ISNULL(MD.cigcode, ISNULL(M.cigcode,ISNULL(U.cigcode,'')))),
		ISNULL(E1.cupcode, ISNULL(MD.cupcode, ISNULL(U.cupcode, ISNULL(F.cupcode,''))))
	FROM invoice I
	join invoicekind IK						on I.idinvkind = IK.idinvkind
	join invoicedetailview ID				on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv	 and I.ninv = ID.ninv	
	join uniqueregister RU					on RU.idinvkind = I.idinvkind and RU.yinv = I.yinv and RU.ninv = I.ninv
	join mandatedetail MD					on ID.idmankind = MD.idmankind and ID.yman = MD.yman and ID.nman = MD.nman and ID.manrownum = MD.rownum
	join mandate M							on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	left outer join expense E1				on E1.idexp = MD.idexp_iva
	left outer join expenseyear EY1			on E1.idexp = EY1.idexp and E1.ymov = EY1.ayear
	left outer join upb U					on EY1.idupb = U.idupb
	left outer join finlast F				on EY1.idfin = F.idfin
	join registry R							on I.idreg = R.idreg
	join residence RR						on R.residence=RR.idresidence
	where I.docdate between @1luglio2014 and @adate 
		-- IMPOS
		and  MD.idexp_iva is not null AND  (MD.idexp_taxable IS NULL OR MD.idexp_taxable<>MD.idexp_iva) 
		and ( not exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
		OR	isnull(I.resendingpcc,'N') = 'S'		)
		AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
		and not exists(select * from #dettfatturacigcup d2 where 
			d2.idinvkind = ID.idinvkind and d2.yinv=ID.yinv and d2.ninv=ID.ninv and  d2.rownum=ID.rownum
			and  isnull(d2.cigcode,'')=isnull(E1.cigcode, ISNULL(MD.cigcode, ISNULL(M.cigcode,ISNULL(U.cigcode,''))))
			and  isnull(d2.cupcode,'') = ISNULL(E1.cupcode, ISNULL(MD.cupcode, ISNULL(U.cupcode, ISNULL(F.cupcode,''))))
		)
		AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
		and RR.coderesidence='I'
		AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
		and (isnull(ID.flagbit,0) & 4) = 0

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- FATTURE 
insert into #dati(
	idinvkind,  yinv, ninv,rownuminv,
	idreg,	
	tipodocumento,
	dataemissione ,
	numerodocumento,
	importototaledocumento,
	causale,
	Imponibiletotaledocumento,
	ivatotaledocumento,
	datacontabiledocumento,
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
	imponibile,
	imposta,
	
	cigcode,cupcode,
	ipa,
	autoinvoice,
	flag_enable_split_payment
)

select 
	I.idinvkind, I.yinv, I.ninv,ID.rownum,
	I.idreg	,
-- tipo documento
	CASE
		WHEN P.idinvkind is not null then 'TD06' -- parcella
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
	I.taxable-I.rounding,		-- ImponibileTotaleDocumento
	--	IvaTotaleDocumento:
	case when isnull(I.flag_reverse_charge,'N')='S' then 0 else  I.tax end,
	I.adate,  --- datacontabiledocumento
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
	-- ImportoPagamento
	case 
		when	isnull(I.flag_enable_split_payment,'N') = 'N'and 	isnull(I.flag_reverse_charge,'N')='S' then I.taxable 
		when	isnull(I.flag_enable_split_payment,'N') = 'N'and 	isnull(I.flag_reverse_charge,'N')='N' then  I.total 
		when	isnull(I.flag_enable_split_payment,'N') = 'S'  then I.taxable 
		end,
	I.arrivalprotocolnum, -- NumProtocolloentrata
	I.protocoldate, -- DataRicezione
	I.annotations,
	isnull(I.resendingpcc,'N'),
	case when isnull(I.flag_reverse_charge,'N')='S' then 0 else  CONVERT(decimal(19,2),ivakind.rate*100) end,
	ivakind.idfenature,
	ID.taxable_euro,
	case when isnull(I.flag_reverse_charge,'N')='S' then 0 else  ID.iva_euro end, --> vedi task 8088
	DCG.cigcode,
	DCG.cupcode,
	isnull(I.ipa_acq, IK.ipa_fe),
	I.autoinvoice,
	I.flag_enable_split_payment
from invoiceview I 
join invoicekind IK					ON IK.idinvkind = I.idinvkind
join invoicedetailview ID			on I.ninv = ID.ninv and I.yinv = ID.yinv and I.idinvkind = ID.idinvkind
join ivakind						on ivakind.idivakind = ID.idivakind
join uniqueregister RU				on RU.idinvkind = I.idinvkind and RU.yinv = I.yinv and RU.ninv = I.ninv
left outer join profservice P		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
left outer join #dettfatturacigcup DCG			on DCG.ninv = ID.ninv and DCG.yinv = ID.yinv and DCG.idinvkind = ID.idinvkind and DCG.rownum = ID.rownum
join registry R						on I.idreg = R.idreg
join residence RR					on R.residence=RR.idresidence
where I.docdate between @1luglio2014 and @adate 
	and ( not exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
	OR 	isnull(I.resendingpcc,'N') = 'S'		)
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	and (isnull(I.total,0) > 0 )
	AND isnull(IK.enable_fe,'N')='N' --> dobbiamo escludere i tipo :  Utilizzabile nella Fattura Elettronica = S
		and RR.coderesidence='I'
	AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
	and (isnull(ID.flagbit,0) & 4) = 0
	
-- Contratti Passivi non collegabili a fattura
create table #dettmandatedetcigcup(
	idmankind varchar(20),
	yman int, 
	nman int,
	rownum int,
	cigcode varchar(15),
	cupcode varchar(15)
)
	insert into #dettmandatedetcigcup(idmankind, yman, nman, rownum, cigcode, cupcode)
	SELECT  MD.idmankind, MD.yman, MD.nman, MD.rownum, 
		isnull(E.cigcode, ISNULL(MD.cigcode, ISNULL(M.cigcode,ISNULL(U.cigcode,'')))),
		ISNULL(E.cupcode, ISNULL(MD.cupcode, ISNULL(U.cupcode, ISNULL(F.cupcode,''))))
	FROM mandatedetailview MD
	join mandate M				on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
	join mandatekind MK			on M.idmankind = MK.idmankind
	join uniqueregister RU		on RU.idmankind = M.idmankind and RU.yman = M.yman and RU.nman = M.nman
	left outer join expensemandate EM		on EM.idmankind = MD.idmankind and EM.yman = MD.yman and EM.nman = MD.nman
	left outer join expense E				on EM.idexp = E.idexp
	left outer join expenseyear EY			on E.idexp = EY.idexp and E.ymov = EY.ayear
	left outer join upb U					on EY.idupb = U.idupb
	left outer join finlast F				on EY.idfin = F.idfin
	join registry R							on isnull(M.idreg,MD.idreg) = R.idreg
	join residence RR						on R.residence=RR.idresidence
	where M.docdate between @1luglio2014 and @adate 
		and isnull(MK.linktoinvoice,'N') = 'N'
		and ( not exists (select * from pccsend P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
			OR  isnull(M.resendingpcc,'N') = 'S'	)
		AND (@idsor01 IS NULL OR M.idsor01 = @idsor01) AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
			and RR.coderesidence='I'

-- CONTRATTI PASSIVI
insert into #dati(
	idmankind,  yman, nman,rownumman,
	idreg,	
	tipodocumento,
	dataemissione ,
	numerodocumento,
	importototaledocumento,
	causale,
	Imponibiletotaledocumento,
	ivatotaledocumento,
	datacontabiledocumento,
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
	imponibile,
	imposta,
	cigcode, cupcode,
	ipa
	)

select 
	M.idmankind, M.yman, M.nman, MD.rownum,
	M.idreg	,
-- tipo documento
	'TD06', -- parcella
	M.docdate , -- dataemissione
	substring(M.doc,1,20),		-- numerodocumento
	M.total ,	-- ImportoTotaleDocumento
	M.description,		-- Causale
	M.taxable_euro,		-- ImponibileTotaleDocumento
	M.iva_euro,		--	IvaTotaleDocumento
	M.adate, --datacontabiledocumento
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
	 M.total, -- ImportoPagamento
	 M.arrivalprotocolnum, -- NumProtocolloentrata
	 M.arrivaldate, -- DataRicezione
	 M.annotations,
	 isnull(M.resendingpcc,'N'),
	CONVERT(decimal(19,2),ivakind.rate*100),
	ivakind.idfenature,
	MD.taxable_euro,
	MD.iva_euro,
	DCG.cigcode, DCG.cupcode,
	MK.ipa_fe
from mandateview M 
join mandatedetailview MD			on M.nman = MD.nman and M.yman = MD.yman and M.idmankind = MD.idmankind
join ivakind						on ivakind.idivakind = MD.idivakind
join mandatekind MK					ON MK.idmankind = M.idmankind
join uniqueregister RU				on RU.idmankind = M.idmankind	and RU.yman = M.ymanand RU.nman = M.nman
left outer join #dettmandatedetcigcup DCG	on DCG.nman = MD.nman and DCG.yman = MD.yman and DCG.idmankind = MD.idmankind and DCG.rownum = MD.rownum
join registry R						on isnull(M.idreg,MD.idreg) = R.idreg
	join residence RR  on R.residence=RR.idresidence
where M.docdate between @1luglio2014 and @adate 
	and MK.linktoinvoice = 'N'
	and ( not exists (select * from pccsend P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
	OR 	isnull(M.resendingpcc,'N') = 'S'		)
	AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
		and RR.coderesidence='I'


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
	datacontabiledocumento,
	datariferimentopagamento,
	giorniterminipagamento,
	datascadenzapagamento,
	importopagamento,
	numprotocolloentrata ,
	dataricezione ,
	annotations ,
	resendingpcc,
	natura,
	imponibile ,
	imposta ,
	cigcode, cupcode,
	ipa
	)
select 
	C.ycon, C.ncon,
	C.idreg	,
-- tipo documento
	'TD06', -- parcella
	C.adate , -- dataemissione
	convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
	C.feegross ,	-- ImportoTotaleDocumento
	C.description,		-- Causale
	C.feegross,		-- ImponibileTotaleDocumento
	0,		--	IvaTotaleDocumento
	null, --datacontabiledocumento
	null, -- DataRiferimentoPagamento
	null, -- GiorniTerminiPagamento
	C.expiration,	-- Data Scadenza Pagamento
	C.feegross, -- ImportoPagamento
	C.arrivalprotocolnum, -- NumProtocolloentrata
	C.arrivaldate, -- DataRicezione
	C.annotations,
	isnull(C.resendingpcc,'N'),
	'N2',--  non soggette
	C.feegross,
	0,
	C.cigcode, C.cupcode,
	C.ipa_fe
from casualcontractview C 
	join uniqueregister RU
		on RU.ycon = C.ycon
		and RU.ncon = C.ncon
	join registry R on C.idreg = R.idreg
	join residence RR  on R.residence=RR.idresidence
where C.adate between @1luglio2014 and @adate 
	and ( not exists (select * from pccsend P where P.ycon = C.ycon and P.ncon = C.ncon)
	OR 	isnull(C.resendingpcc,'N') = 'S'		)
	AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
		and RR.coderesidence='I'

declare @cf varchar(11)
declare @p_iva varchar(11)
select @cf = cf, 
	@p_iva = p_iva
	from license

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
	nriga,
	D.idinvkind, D.yinv ,D.ninv,D.rownuminv, IK.description as invoicekind,
	D.idmankind, D.yman, D.nman , D.rownumman, MK.description as mandatekind,
	D.ycon, D.ncon,
	@cf as 'CFAmmin',
	--@p_iva as 'PivaAmmin',
	D.ipa as 'IPA',
	IPA.agencyname as 'agencyname',	--@agencyname
	case when (isnull(D.autoinvoice,'N')='S') then @cf else	R.cf end as 'CFfornitore',	
	case when (isnull(D.autoinvoice,'N')='S') then @p_iva 
		when D.idinvkind is not null then R.IdFiscaleIvaFornitore
		when D.idmankind is not null then isnull(R.IdFiscaleIvaFornitore, R.cf)
		when D.ycon is not null then isnull(R.IdFiscaleIvaFornitore, R.cf)
		end
	as 'IdFiscaleIvaFornitore',	
	case when (isnull(D.autoinvoice,'N')='S') then '(Autofattura)' + R.title
	else R.title
	end	as 'DenominazioneFornitore',
	D.idreg ,
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
	isnull(D.natura,'NA') as natura,
	D.imponibile,
	D.imposta,

	-- Distribuzione per CIG/CUP
	isnull(D.cigcode,'') as 'codicecig',
	isnull(D.cupcode,'') as 'codicecup',
	D.datacontabiledocumento, 
--> va comunicato o Data scadenza e Giorni, oppure Data scadenza
	case when D.datascadenzapagamento is null then D.datariferimentopagamento else null end as datariferimentopagamento,
	case when D.datascadenzapagamento is null then D.giorniterminipagamento else null end as giorniterminipagamento,
	D.datascadenzapagamento ,

	D.importopagamento ,
	D.numprotocolloentrata ,
	D.dataricezione,
	case 
		when isnull(D.flag_enable_split_payment,'N') = 'N' then D.annotations 
		when isnull(D.flag_enable_split_payment,'N') = 'S' then '*SP*' + '.' + isnull(D.annotations,'') 
	end as 'note',
	D.resendingpcc,
	case when isnull(D.resendingpcc,'S')='S' then 'SO' else null end as 'forzaturaImissione',
	null as 'codicesegnalazione',
	null as 'descrizionesegnalazione'
from #dati D
join ipa --- IMPORTANTE!!! Deve essere un JOIN
	on D.ipa = ipa.ipa_fe
join Fornitore R					on R.idreg = D.idreg
left outer join invoicekind IK		on IK.idinvkind = D.idinvkind
left outer join mandatekind MK		on MK.idmankind = D.idmankind
order by D.idinvkind, D.yinv, D.ninv, D.idmankind, D.yman, D.nman, D.ycon, D.ncon

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
