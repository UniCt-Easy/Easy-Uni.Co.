
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


-- CREAZIONE VISTA pccexpiringview
IF EXISTS(select * from sysobjects where id = object_id(N'[pccexpiringview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pccexpiringview]
GO


CREATE   VIEW [pccexpiringview]
	(
	idpcc,
	idpccexpiring,
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
	expiringdate,
	ct,
	cu,
	lt,
	lu,
	idreg,
	registry,
	IdFiscaleIvaFornitore,
	CFfornitore,
	ImportoTotaleDocumento,
	dataemissione ,
	numerodocumento
	
	)
	AS
	SELECT
	pccexpiring.idpcc,
	pccexpiring.idpccexpiring,
	pccexpiring.yinv,
	pccexpiring.ninv,
	pccexpiring.invrownum,
	pccexpiring.idinvkind,
	I.invoicekind,
	pccexpiring.ycon,
	pccexpiring.ncon,
	pccexpiring.yman,
	pccexpiring.nman,
	pccexpiring.manrownum,
	pccexpiring.idmankind,
	M.mankind,
	pccexpiring.amount,
	pccexpiring.expiringdate,
	pccexpiring.ct,
	pccexpiring.cu,
	pccexpiring.lt,
	pccexpiring.lu,
	coalesce(R1.idreg,R2.idreg,R3.idreg),
	coalesce(R1.title,R2.title,R3.title),
	case when coalesce(RR1.coderesidence,RR2.coderesidence,RR3.coderesidence) = 'I' 
			then 'IT' + coalesce (R1.p_iva,R2.p_iva,R3.p_iva)
		 when coalesce(RR1.coderesidence,RR2.coderesidence,RR3.coderesidence)  = 'J' 
			then coalesce (R1.p_iva,R2.p_iva,R3.p_iva)
		 when coalesce(RR1.coderesidence,RR2.coderesidence,RR3.coderesidence)  = 'X' 
			then substring(coalesce (R1.foreigncf,R2.foreigncf,R3.foreigncf),1,16)
		 else null
	end,
	coalesce (R1.cf,R2.cf,R3.cf),
	case when pccexpiring.idmankind is not null  then  M.total
		 when pccexpiring.idinvkind is not null  then  I.total
		 when pccexpiring.ycon is not null  then  C.feegross
		 else null
	end,
	CASE
			when pccexpiring.idmankind is not null  then M.docdate  -- dataemissione
			when pccexpiring.idinvkind is not null  then I.docdate  -- dataemissione
			when pccexpiring.ycon is not null  then C.adate  -- dataemissione
	END,
	CASE
			when pccexpiring.idmankind is not null  then substring(M.doc,1,20)  -- numerodocumento
			when pccexpiring.idinvkind is not null  then substring(I.doc,1,20)  -- numerodocumento
			when pccexpiring.ycon is not null  then convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon)		-- numerodocumento
	END
from pccexpiring
left outer join casualcontract C
		on pccexpiring.ycon = C.ycon and pccexpiring.ncon = C.ncon
left outer join invoiceview I
		on pccexpiring.idinvkind = I.idinvkind and pccexpiring.yinv = I.yinv and pccexpiring.ninv = I.ninv
left outer join mandateview M
		on pccexpiring.idmankind = M.idmankind and pccexpiring.yman = M.yman and pccexpiring.nman = M.nman
left outer join registry R1
	on R1.idreg = I.idreg
left outer join residence RR1
	on RR1.idresidence = R1.residence
left outer join registry R2
	on R2.idreg = M.idreg
left outer join residence RR2
	on RR2.idresidence = R2.residence
left outer join registry R3
	on R2.idreg = C.idreg
left outer join residence RR3
	on RR3.idresidence = R3.residence

	
	
GO
 
 

