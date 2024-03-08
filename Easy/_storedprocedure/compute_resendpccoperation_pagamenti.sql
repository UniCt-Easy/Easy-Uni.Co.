
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resendpccoperation_pagamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resendpccoperation_pagamenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- il parametro è la data contabile.
-- Prendiamo tutte tali che:
-- FE di acquito son OPI disattivo, pagate alla data
-- Fatture cartacee(quindi non elettroniche) inviate alla PCC, ossia per cui esiste la riga in pccsend, e pagate alla data
-- per cui non esiste la riga in PCCPAYMENT

-- setuser 'amministrazione'
--exec compute_resendpccoperation_pagamenti  2
CREATE procedure compute_resendpccoperation_pagamenti( 
	@idpcc int 
	) as
begin
 
 DECLARE @31dic2018 datetime
 SET @31dic2018 = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),2018),105)

 declare @OPIattivo char  
 set @OPIattivo='S'
 if (	(select count(*) from opisiopeplus_config)=0 
		OR (select top 1 code from opisiopeplus_config)<>'opi_siopeplus' 
		)
 Begin
	set @OPIattivo = 'N'
 End
 
 

declare @1luglio2014 datetime
set @1luglio2014 = {d '2014-07-01'}

declare @1luglio2017_splitparcelle datetime
set @1luglio2017_splitparcelle = {d '2017-07-01'}


create table #dati(
	nriga int identity(1,1),
	opkind char(3),
	idinvkind int,  
	yinv smallint, 
	ninv int,
	identificativo_sdi bigint,
	ninvoice varchar(35),
	commerciale char(1),
	idreg int,	
	ipa varchar(6),
	idfin int,--li usiamo solo per la piccola spesa
	idupb varchar(36),--li usiamo solo per la piccola spesa
	
	dataemissione date,
	numerodocumento varchar(20),
	importototaledocumento decimal(19,2),
	descrizione varchar(100),	--> da usare quando il doc. non è contabilizzati
	idexpimpegno int,
	cigcode varchar(15),
	cupcode varchar(15),
	naturadispesa char(2),
	-- PAGAMENTO
	importopagato decimal(19,2),
	kpay int,
	idpettycash int,
	yoperation int,
	noperation smallint,
	piccolaspesa varchar(100),
	paymentdate date,
	idexppagamento int

)
			


declare @cf varchar(11)
select @cf = cf from license

Insert into #dati(
			idinvkind, yinv, ninv,
			idreg,
			dataemissione,
			identificativo_sdi, ninvoice,
			ipa
	 )
select     
			I.idinvkind, I.yinv, I.ninv,
			I.idreg,
			isnull(I.docdate, sdi.adate) , -- dataemissione
			ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi), 
	
			-- Se è una FE di acqsuito, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acqsuito estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when I.idsdi_acquisto is not null then sdi.ninvoice
				when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
				else I.doc
			end,
			isnull(I.ipa_acq, sdi.codice_ipa) 
from pccpayment P
join invoiceview I 
		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join invoicekind IK
	ON IK.idinvkind = I.idinvkind
left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
where P.idpcc = @idpcc


update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null AND ipa is null

SELECT distinct
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a,
	D.ninvoice as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then D.dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
   case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio
	'IP' AS azione,
	null as 'IdPagamento',
	case when (ik.enable_fe='S' or ik.enable_fe_estera='S') THEN 'C' ELSE 'NC' end as 'Tipodebito', 
	PP.amount AS importopagato,
	--PP.description as descrizione,
	PP.expensekind as naturadispesa,
	--PP.kpay,
	--null as idpettycash,
	--null as yoperation,
	--null as noperation,
	convert(varchar(20),PY.npay) as npay,
	PT.transmissiondate as 'paymentdate',
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
						 when RR.coderesidence = 'J' then R.p_iva
						 when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
					else null
	end	as 'IdFiscaleIvaFornitore',
	PP.cigcode as  codicecig, 
	PP.cupcode as codicecup,

	null as 'PagamentoOPI',
	null as 'PagamentoIVA',
	null as 'Giornidisospensioneeffettivi'

from pccpaymentview PP 
	join #dati D	on D.idinvkind = PP.idinvkind and D.yinv = PP.yinv and D.ninv = PP.ninv
	join invoicekind IK ON IK.idinvkind = D.idinvkind
	join registry R		on R.idreg = D.idreg
	join residence RR	on RR.idresidence = R.residence
	join payment PY 	on PY.kpay = PP.kpay
	join paymenttransmission PT on PY.kpaymenttransmission = PT.kpaymenttransmission
where PP.idpcc = @idpcc
--order by nriga,iK.description, D.yinv, D.ninv

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




go


--exec compute_resendpccoperation_pagamenti 5
