
/*
Easy
Copyright (C) 2021 UniversitÓ degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA pccexpenseview
IF EXISTS(select * from sysobjects where id = object_id(N'[pccexpenseview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pccexpenseview]
GO
-- setuser 'amm'
CREATE   VIEW [pccexpenseview]
	(
	idpcc,
	idpccexpense,
	yinv,
	ninv,
	invrownum,
	idinvkind,
	invoicekind,
	ycon,
	ncon,
	yman,
	nman,
	manrownum,
	idmankind,
	mandatekind,
	amount,
	expensekind,
	idfin,
	codefin,
	expensetaxkind,
	pccdebitstatus,
	motive,
	pccdebitmotive,
	description,
	idexp,
	expensephase,
	nmov,
	ymov,
	cigcode,
	cupcode,
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
	pccexpense.idpcc,
	pccexpense.idpccexpense,
	pccexpense.yinv,
	pccexpense.ninv,
	pccexpense.invrownum,
	pccexpense.idinvkind,
	I.invoicekind,
	pccexpense.ycon,
	pccexpense.ncon,
	pccexpense.yman,
	pccexpense.nman,
	pccexpense.manrownum,
	pccexpense.idmankind,
	M.mankind,
	pccexpense.amount,
	pccexpense.expensekind,
	pccexpense.idfin,
	fin.codefin,
	pccexpense.expensetaxkind,
	pccdebitstatus.description,
	pccexpense.motive,
	pccdebitmotive.description,
	pccexpense.description,
	pccexpense.idexp,
	expensephase.description,
	expense.nmov,
	expense.ymov,
	pccexpense.cigcode,
	pccexpense.cupcode,
	pccexpense.ct,
	pccexpense.cu,
	pccexpense.lt,
	pccexpense.lu,
	R.title,
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		 else null
	end,
	R.cf,
	case when pccexpense.idmankind is not null  then  M.total
		 when pccexpense.idinvkind is not null  then  I.total
		 when pccexpense.ycon is not null  then  C.feegross
		 else null
	end,
	CASE
			when pccexpense.idmankind is not null  then M.docdate  -- dataemissione
			when pccexpense.idinvkind is not null  then I.docdate  -- dataemissione
			when pccexpense.ycon is not null  then C.adate  -- dataemissione
	END,
	CASE
			when pccexpense.idmankind is not null  then substring(M.doc,1,20)  -- numerodocumento
			when pccexpense.idinvkind is not null  then substring(I.doc,1,20)  -- numerodocumento
			when pccexpense.ycon is not null  then convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon)		-- numerodocumento
	END
from pccexpense
left outer join fin			on pccexpense.idfin = fin.idfin
left outer join expense		on pccexpense.idexp = expense.idexp
left outer join expensephase	on expense.nphase =expensephase.nphase
left outer join pccdebitstatus	on pccexpense.expensetaxkind = pccdebitstatus.idpccdebitstatus
left outer join pccdebitmotive	on pccexpense.motive = pccdebitmotive.idpccdebitmotive
left outer join casualcontract C	on pccexpense.ycon = C.ycon and pccexpense.ncon = C.ncon
left outer join invoiceview I		on pccexpense.idinvkind = I.idinvkind and pccexpense.yinv = I.yinv and pccexpense.ninv = I.ninv
left outer join mandateview M		on pccexpense.idmankind = M.idmankind and pccexpense.yman = M.yman and pccexpense.nman = M.nman
left outer join registry R		on R.idreg = coalesce(expense.idreg,C.idreg,I.idreg,M.idreg)
left outer join residence RR	on RR.idresidence = R.residence

GO

 


