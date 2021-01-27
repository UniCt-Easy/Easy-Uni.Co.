
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


-- CREAZIONE VISTA pccsendview
IF EXISTS(select * from sysobjects where id = object_id(N'[pccsendview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [pccsendview]
GO

CREATE   VIEW [pccsendview]
	(
	idpcc,
	idpccsend,
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
	idreg,
	taxabletotal,
	taxtotal,
	rate,
	idfenature,
	taxabletotalbyiva,
	taxtotalbyiva,
	amountcigcup,
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
	numerodocumento,
	causale
	)
	AS
	SELECT
	pccsend.idpcc,
	pccsend.idpccsend,
	pccsend.yinv,
	pccsend.ninv,
	pccsend.idinvkind,
	I.invoicekind,
	pccsend.ycon,
	pccsend.ncon,
	pccsend.yman,
	pccsend.nman,
	pccsend.idmankind,
	M.mankind,
	pccsend.idreg,
	pccsend.taxabletotal,
	pccsend.taxtotal,
	pccsend.rate,
	pccsend.idfenature,
	pccsend.taxabletotalbyiva,
	pccsend.taxtotalbyiva,
	pccsend.amountcigcup,
	pccsend.cigcode,
	pccsend.cupcode,
	pccsend.ct,
	pccsend.cu,
	pccsend.lt,
	pccsend.lu,
	R.title,
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
		 when RR.coderesidence = 'J' then R.p_iva
		 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		 else null
	end,
	R.cf,
	case when pccsend.idmankind is not null  then  M.total
		 when pccsend.idinvkind is not null  then  I.total
		 when pccsend.ycon is not null  then  C.feegross
		 else null
	end,
	CASE
			when pccsend.idmankind is not null  then M.docdate  -- dataemissione
			when pccsend.idinvkind is not null  then I.docdate  -- dataemissione
			when pccsend.ycon is not null  then C.adate  -- dataemissione
	END,
	CASE
			when pccsend.idmankind is not null  then substring(M.doc,1,20)  -- numerodocumento
			when pccsend.idinvkind is not null  then substring(I.doc,1,20)  -- numerodocumento
			when pccsend.ycon is not null  then convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon)		-- numerodocumento
	END,
	CASE
			when pccsend.idmankind is not null  then M.description  -- causale
			when pccsend.idinvkind is not null  then I.description  -- causale
			when pccsend.ycon is not null  then C.description		-- causale
	END
from pccsend
left outer join registry R
	on R.idreg = pccsend.idreg
left outer join residence RR
	on RR.idresidence = R.residence
left outer join casualcontract C
		on pccsend.ycon = C.ycon and pccsend.ncon = C.ncon
left outer join invoiceview I
		on pccsend.idinvkind = I.idinvkind and pccsend.yinv = I.yinv and pccsend.ninv = I.ninv
left outer join mandateview M
		on pccsend.idmankind = M.idmankind and pccsend.yman = M.yman and pccsend.nman = M.nman
GO

 


 
