-- CREAZIONE VISTA pccpaymentview
IF EXISTS(select * from sysobjects where id = object_id(N'[pccpaymentview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pccpaymentview]
GO
--setuser 'amm' 
-- select * from pccpaymentview
-- clear_table_info 'pccpaymentview'
CREATE   VIEW [pccpaymentview]
	(
	idpcc,
	idpccpayment,
	yinv,
	ninv,
	idinvkind,
	invoicekind,
	ycon,
	ncon,
	yman,
	nman,
	idmankind,
	mandatekind,
	amount,
	expensekind,
	idfin,
	codefin,
	kpay,
	npay,
	description,
	idexp,
	expensephase,
	nmov,
	ymov,
	cigcode,
	cupcode,
	idpettycash,
	pettycash,
	yoperation,
	noperation,
	ct,
	cu,
	lt,
	lu,
	registry,
	IdFiscaleIvaFornitore,
	CFfornitore,
	ImportoTotaleDocumento,
	dataemissione ,
	numerodocumento
	)
	AS
	SELECT
	pccpayment.idpcc,
	pccpayment.idpccpayment,
	pccpayment.yinv,
	pccpayment.ninv,
	pccpayment.idinvkind,
	I.invoicekind,
	pccpayment.ycon,
	pccpayment.ncon,
	pccpayment.yman,
	pccpayment.nman,
	pccpayment.idmankind,
	M.mankind,
	pccpayment.amount,
	pccpayment.expensekind,
	pccpayment.idfin,
	fin.codefin,
	pccpayment.kpay,
	convert(varchar(100),payment.npay),
	pccpayment.description,
	pccpayment.idexp,
	expensephase.description,
	expense.nmov,
	expense.ymov,
	pccpayment.cigcode,
	pccpayment.cupcode,
	null, -- pccpayment.idpettycash,
	null, -- pettycash.descrition,
	null, -- pccpayment.yoperation,
	null, -- pccpayment.noperation,
	pccpayment.ct,
	pccpayment.cu,
	pccpayment.lt,
	pccpayment.lu,
	R.title,
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		 else null
	end,
	R.cf,
	case when pccpayment.idmankind is not null  then  M.total
		 when pccpayment.idinvkind is not null  then  I.total
		 when pccpayment.ycon is not null  then  C.feegross
		 else null
	end,
	CASE
			when pccpayment.idmankind is not null  then M.docdate  -- dataemissione
			when pccpayment.idinvkind is not null  then I.docdate  -- dataemissione
			when pccpayment.ycon is not null  then C.adate  -- dataemissione
	END,
	CASE
			when pccpayment.idmankind is not null  then substring(M.doc,1,20)  -- numerodocumento
			when pccpayment.idinvkind is not null  then substring(I.doc,1,20)  -- numerodocumento
			when pccpayment.ycon is not null  then convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon)		-- numerodocumento
	END
from pccpayment
join fin 	on pccpayment.idfin = fin.idfin
join payment 	on payment.kpay = pccpayment.kpay
left outer join expense 	on pccpayment.idexp = expense.idexp
left outer join expensephase 	on expense.nphase =expensephase.nphase
left outer join registry R 	on R.idreg = expense.idreg
left outer join residence RR 	on RR.idresidence = R.residence
left outer join casualcontract C 		on pccpayment.ycon = C.ycon and pccpayment.ncon = C.ncon
left outer join invoiceview I 		on pccpayment.idinvkind = I.idinvkind and pccpayment.yinv = I.yinv and pccpayment.ninv = I.ninv
left outer join mandateview M 		on pccpayment.idmankind = M.idmankind and pccpayment.yman = M.yman and pccpayment.nman = M.nman
UNION
-- Pagamenti con la piccola spesa
	SELECT
	pccpayment.idpcc,
	pccpayment.idpccpayment,
	pccpayment.yinv,
	pccpayment.ninv,
	pccpayment.idinvkind,
	I.invoicekind,
	pccpayment.ycon,
	pccpayment.ncon,
	pccpayment.yman,
	pccpayment.nman,
	pccpayment.idmankind,
	M.mankind,
	pccpayment.amount,
	pccpayment.expensekind,
	pccpayment.idfin,
	fin.codefin,
	pccpayment.kpay,
	--substring('F.E.:' + pettycash.description + ' Op.Num.' + 
	--		convert(varchar(20), pettycashoperation.noperation) + ' del ' + convert(varchar(10), pettycashoperation.yoperation),1,100), 
	substring(
				'F.E.:' + PK.pettycode + ' Op.' + convert(varchar(10), pettycashoperation.noperation) + '/' + convert(varchar(4), pettycashoperation.yoperation),		--	piccolaspesa
				1,50), --massimo 50 caratteri		
			-- payment.npay,
	pccpayment.description,
	pccpayment.idexp,
	null, --expensephase.description,
	null, -- expense.nmov,
	null, -- expense.ymov,
	pccpayment.cigcode,
	pccpayment.cupcode,
	pccpayment.idpettycash,
	pettycash.description,
	pccpayment.yoperation,
	pccpayment.noperation,
	pccpayment.ct,
	pccpayment.cu,
	pccpayment.lt,
	pccpayment.lu,
	R.title,
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		 else null
	end,
	R.cf,
	case when pccpayment.idmankind is not null  then  M.total
		 when pccpayment.idinvkind is not null  then  I.total
		 when pccpayment.ycon is not null  then  C.feegross
		 else null
	end,
	CASE
			when pccpayment.idmankind is not null  then M.docdate  -- dataemissione
			when pccpayment.idinvkind is not null  then I.docdate  -- dataemissione
			when pccpayment.ycon is not null  then C.adate  -- dataemissione
	END,
	CASE
			when pccpayment.idmankind is not null  then substring(M.doc,1,20)  -- numerodocumento
			when pccpayment.idinvkind is not null  then substring(I.doc,1,20)  -- numerodocumento
			when pccpayment.ycon is not null  then convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon)		-- numerodocumento
	END
from pccpayment
join pettycash  	on pettycash.idpettycash = pccpayment.idpettycash
join pettycashoperation  	on pettycashoperation.idpettycash = pccpayment.idpettycash and pettycashoperation.noperation = pccpayment.noperation and pettycashoperation.yoperation = pccpayment.yoperation
join pettycash PK 						on PK.idpettycash = pettycash.idpettycash
left outer join fin 	on pccpayment.idfin = fin.idfin
left outer join casualcontract C 		on pccpayment.ycon = C.ycon and pccpayment.ncon = C.ncon
left outer join invoiceview I 		on pccpayment.idinvkind = I.idinvkind and pccpayment.yinv = I.yinv and pccpayment.ninv = I.ninv
left outer join mandateview M 		on pccpayment.idmankind = M.idmankind and pccpayment.yman = M.yman and pccpayment.nman = M.nman
left outer join registry R 	on R.idreg = coalesce(pettycashoperation.idreg,C.idreg,I.idreg,M.idreg)
left outer join residence RR 	on RR.idresidence = R.residence
GO




