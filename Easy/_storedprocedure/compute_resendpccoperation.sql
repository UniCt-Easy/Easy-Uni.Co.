if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resendpccoperation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resendpccoperation]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- la sp rigenera il file trasmesso, usando gli stessi dati
CREATE procedure compute_resendpccoperation( 
	@idpcc int 
	)
	as
begin
--	CO-1
--	CS-2
--	CP-3
-- setuser 'amministrazione'
-- exec compute_resendpccoperation 150
-- select * from pccexpense
create table #dati(
	opkind char(3),
	oporder int,
	idinvkind int,  
	yinv smallint, 
	ninv int,
	idmankind varchar(20),
	yman smallint,
	nman int,
	ycon int,
	ncon int,
	idreg int,	
	ipa varchar(6),
	dataemissione datetime,
	numerodocumento varchar(20),
	importototaledocumento decimal(19,2),
	numimpegno int,
	cigcode varchar(15),
	cupcode varchar(15),
	description varchar(100),
-- CONTABILIZZAZIONE
	importodelmovimento decimal(19,2),
	naturadispesa char(2),
	statodeldebito varchar(9),
	causale varchar(20),
	descrizione varchar(100),
	codefin varchar(50),
-- PAGAMENTO
	importopagato decimal(19,2),
	npay varchar(100),
	paymentdate datetime,

-- SCADENZA
	datascadenza datetime,
	importononpagallascadenza decimal(19,2)
)
-- OPERAZIONE di Scadenza Fatture
Insert into #dati(
	opkind,oporder,
	idinvkind,	yinv,	ninv,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,

	importononpagallascadenza,
	datascadenza,
	ipa
	 )
select 'CS',1,
	I.idinvkind, I.yinv, I.ninv,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	-- ImportoTotaleDocumento:
	case when isnull(I.flag_reverse_charge,'N')='S' then (I.taxable-I.rounding) else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
	sum(P.amount),
	P.expiringdate,
	I.ipa_acq
from pccexpiring P
join invoiceview I 
		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join invoicekind IK
	ON IK.idinvkind = I.idinvkind
where P.idpcc = @idpcc 
GROUP BY I.idinvkind, I.yinv, I.ninv, 	I.idreg	,	I.docdate , 	substring(I.doc,1,20),	 (I.taxable-I.rounding),(I.total-I.rounding ) ,		P.expiringdate,	I.ipa_acq,I.flag_reverse_charge

-- OPERAZIONE di Scadenza Contratti Passivi
insert into #dati(
	opkind,oporder,
	idmankind,	yman,	nman,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,

	importononpagallascadenza,
	datascadenza
	 )
select 'CS',1,
	I.idmankind, I.yman, I.nman,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	I.total ,	-- ImportoTotaleDocumento
	P.amount,
	P.expiringdate
from pccexpiring P
join mandateview I 
	on P.idmankind = I.idmankind and P.yman = I.yman and P.nman = I.nman
where P.idpcc = @idpcc

-- OPERAZIONE di Scadenza Contratti Occasionali
insert into #dati(
	opkind,oporder,
	idmankind,	yman,	nman,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,

	importononpagallascadenza,
	datascadenza
	 )
select 'CS',1,
	P.idmankind, P.yman, P.nman,
	C.idreg	,
	C.adate , -- dataemissione
	convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
	C.feegross ,	-- ImportoTotaleDocumento
	P.amount,
	P.expiringdate
from pccexpiring P
join casualcontract C 
	on P.ycon = C.ycon and P.ncon = C.ncon
where P.idpcc = @idpcc

-- Contabilizzazioni FATTURE
INSERT INTO #dati(
	opkind,oporder,
	idinvkind,	yinv,	ninv,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- CONTABILIZZAZIONE
	importodelmovimento ,
	naturadispesa,
	codefin,
	statodeldebito,
	causale,
	numimpegno ,
	cigcode ,
	cupcode ,
	description,
	ipa
	)
select 
	--'CO',
	case when (select count(*) from invoicedetail ID2 where I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv)=1 then 'CO'
			else 'COF' end,
	2,
	I.idinvkind, I.yinv, I.ninv,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	-- ImportoTotaleDocumento:
	case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	P.expensetaxkind, -- statodeldebito
	P.motive, -- causale
	E.nmov,
	P.cigcode, 
	P.cupcode , 
	P.description,
	I.ipa_acq
from pccexpense P
join invoiceview I 
		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join invoicekind IK
	ON IK.idinvkind = I.idinvkind
left outer join expense E
	on P.idexp = E.idexp
left outer join fin F
	on F.idfin = P.idfin
where P.idpcc = @idpcc

-- Contabilizzazioni CONTRATTI PASSIVI
INSERT INTO #dati(
	opkind,oporder,
	idmankind,	yman,	nman,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- CONTABILIZZAZIONE
	importodelmovimento ,
	naturadispesa,
	codefin,
	statodeldebito,
	causale,
	numimpegno ,
	cigcode ,
	cupcode ,
	description
	)
select 
	'CO',2,
	I.idmankind, I.yman, I.nman,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	I.total ,	-- ImportoTotaleDocumento
	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	P.expensetaxkind, -- statodeldebito
	P.motive, -- causale
	E.nmov,
	P.cigcode, 
	P.cupcode ,
	P.description 
from pccexpense P
join mandateview I 
	on P.idmankind = I.idmankind and P.yman = I.yman and P.nman = I.nman
left outer join expense E
	on P.idexp = E.idexp
left outer join fin F
	on F.idfin = P.idfin
where P.idpcc = @idpcc

-- Contabilizzazioni di OCCASIONALI
insert into #dati(
	opkind,oporder,
	ycon,	ncon,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- CONTABILIZZAZIONE
	importodelmovimento ,
	naturadispesa,
	codefin,
	statodeldebito,
	causale,
	numimpegno ,
	cigcode ,
	cupcode ,
	description
	)
select 'CO',2,
	P.ycon, P.ncon,
	C.idreg	,
	C.adate , -- dataemissione
	convert(varchar(4),P.ycon)+'/'+convert(varchar(10),P.ncon),		-- numerodocumento
	C.feegross ,	-- ImportoTotaleDocumento
	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	P.expensetaxkind, -- statodeldebito
	P.motive, -- causale
	E.nmov,
	P.cigcode, 
	P.cupcode,
	P.description
from pccexpense P
join casualcontract C 
	on P.ycon = C.ycon and P.ncon = C.ncon
left outer  join expense E
	on P.idexp = E.idexp
left outer  join fin F
	on F.idfin = P.idfin
where P.idpcc = @idpcc

-- PAGAMENTO di FATTURE
INSERT INTO #dati(
	opkind,oporder,
	idinvkind, yinv, ninv,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- PAGAMENTO
	importopagato,
	naturadispesa,
	codefin,
	numimpegno,
	npay,
	paymentdate,
	cigcode,
	cupcode,
	description,
	ipa
)
select 'CP',3,
	P.idinvkind, P.yinv, P.ninv,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	-- ImportoTotaleDocumento:
	case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	E.nmov,
	P.Npay, --convert(varchar(100),PY.npay) as npay, -- PY.npay, 
	PY.adate,
	P.cigcode,
	P.cupcode,
	P.description,
	I.ipa_acq
from pccpaymentview P
join invoiceview I 	on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
left outer join payment PY	on PY.kpay = P.kpay
left outer join expense E	on E.idexp = P.idexp
left outer join fin F 	on F.idfin = P.idfin
where P.idpcc = @idpcc

--- PAGAMENTI di CONTRATTI PASSIVI non Collegabili a Fattura 
INSERT INTO #dati(
	opkind,oporder,
	idmankind, yman, nman,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- PAGAMENTO
	importopagato,
	naturadispesa,
	codefin,
	numimpegno,
	npay,
	paymentdate,
	cigcode,
	cupcode,
	description
)
select 'CP',3,
	P.idmankind, P.yman, P.nman,
	I.idreg	,
	I.docdate , -- dataemissione
	substring(I.doc,1,20),	-- numerodocumento
	I.total,	-- ImportoTotaleDocumento

	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	E.nmov,
	P.npay, --convert(varchar(100),PY.npay) as npay, -- PY.npay, 
	PY.adate,
	P.cigcode,
	P.cupcode,
	P.description
from pccpaymentview P
join mandateview I 	on P.idmankind = I.idmankind and P.yman = I.yman and P.nman = I.nman
left outer join payment PY	on PY.kpay = P.kpay
left outer join expense E	on E.idexp = P.idexp
left outer join fin F	on F.idfin = P.idfin
where P.idpcc = @idpcc


	
-- PAGAMENTO OCCASIONALI
insert into #dati(
	opkind,oporder,
	 ycon, ncon,
	idreg,	
	dataemissione,
	numerodocumento,
	importototaledocumento,
-- PAGAMENTO
	importopagato,
	naturadispesa,
	codefin,
	numimpegno,
	npay,
	paymentdate,
	cigcode,
	cupcode,
	description
	)
select 'CP',3,
	C.ycon, C.ncon,
	C.idreg	,
	C.adate , -- dataemissione
	convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
	C.feegross ,	-- ImportoTotaleDocumento
	P.amount,
	P.expensekind, -- natura di spesa
	F.codefin,
	E.nmov,
	P.npay, --convert(varchar(100),PY.npay) as npay, -- PY.npay, 
	PY.adate,
	P.cigcode,
	P.cupcode,
	P.description
from pccpaymentview P 
join casualcontract C		on C.ycon = P.ycon and C.ncon = P.ncon
left outer join payment PY 	on PY.kpay = P.kpay
left outer join expense E 	on E.idexp = P.idexp
left outer join fin F	on F.idfin = P.idfin
where P.idpcc = @idpcc



declare @cf varchar(11)
select @cf = cf from license
update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null and ipa is null
update #dati set ipa = (select ipa_fe from mandatekind I where #dati.idmankind = I.idmankind) where idmankind is not null
update #dati set ipa = (select ipa_fe from casualcontract I where #dati.ycon = I.ycon and #dati.ncon = I.ncon) where ycon is not null



select 
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	R.cf as 'CFfornitore',	
	case when D.idmankind is null and D.ycon is null then 
     case when RR.coderesidence = 'I' then 'IT' + R.p_iva
       when RR.coderesidence = 'J' then R.p_iva
       when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
     else null
    end
  when D.idmankind is not null or D.ycon is not null then isnull(
     case when RR.coderesidence = 'I' then 'IT' + R.p_iva
        when RR.coderesidence = 'J' then R.p_iva
       when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
     else null
     end,
     R.cf)  
 end 
 as 'IdFiscaleIvaFornitore_co',
	D.opkind as 'azione',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,

-- RICEZIONE
	null as numeroprotocolloentrata,
	null as dataricezione,
	null as note,
--	COMUNICAZIONE RIFIUTO
	null as datarifiuto,
	null as descrizione,

-- CONTABILIZZAZIONE
	SUM(D.importodelmovimento) as importodelmovimento,
	case when D.opkind in('CO','COF') then D.naturadispesa else null end as 'naturadispesa_co',
	case when D.opkind in('CO','COF')  then D.codefin else null end as 'codefin_co',
	case when D.opkind in('CO','COF')  then D.statodeldebito else null end as 'statodeldebito',
	D.causale,
	case when D.opkind in('CO','COF')  then D.description  else null end as 'description_co',
	case when D.opkind in('CO','COF')  then D.numimpegno else null end as 'numimpegno_co', 
	case when D.opkind in('CO','COF')  then D.cigcode else null end as  'cigcode_co',
	case when D.opkind in('CO','COF')  then D.cupcode else null end as  'cupcode_co',

--	SCADENZA
	case when D.opkind='CS' then 'SI' else null end as 'comunicazionescadenza',
	SUM(D.importononpagallascadenza) as importononpagallascadenza,
	D.datascadenza as datascadenza,

-- PAGAMENTO
	SUM(D.importopagato) as importopagato,
	case when D.opkind='CP' then D.naturadispesa else null end as 'naturadispesa_cp',
	case when D.opkind='CP' then D.codefin else null end as 'codefin_cp',
	case when D.opkind='CP' then D.numimpegno else null end as 'numimpegno_cp', 
	D.npay,
	D.paymentdate,
	case when (D.opkind='CP') then
				 case when D.idmankind is null and D.ycon is null then
					case when RR.coderesidence = 'I' then 'IT' + R.p_iva
						 when RR.coderesidence = 'J' then R.p_iva
						 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
					else null
				end
				when D.idmankind is not null or D.ycon is not null then isnull(
					case when RR.coderesidence = 'I' then 'IT' + R.p_iva
							 when RR.coderesidence = 'J' then R.p_iva
							when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
					else null
					end,
					R.cf)
		
			end
	end	  	as 'IdFiscaleIvaFornitore_cp',
	case when D.opkind='CP' then D.cigcode else null end as  'cigcode_cp',
	case when D.opkind='CP' then D.cupcode else null end as  'cupcode_cp',	
	case when D.opkind='CP' then D.description  else null end as 'description_cp',

	null as 'codicesegnalazione',
	null as 'descrizionesegnalazione', 
	D.oporder 
from #dati D
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
group by D.ipa, R.cf,
RR.coderesidence, R.p_iva , R.foreigncf,
D.opkind,	D.numerodocumento, D.dataemissione,D.importototaledocumento,
D.naturadispesa, D.codefin,D.statodeldebito,D.description,D.numimpegno,D.datascadenza,
D.idmankind,D.ycon,D.ncon,D.cigcode, D.cupcode, D.causale,D.npay,D.paymentdate,D.oporder,
D.yinv,D.yman, D.nman
order by oporder,
 D.numerodocumento, R.cf,
  D.yinv, D.idmankind, D.yman, D.nman, D.ycon, D.ncon
end

GO

 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
--exec compute_resendpccoperation 150