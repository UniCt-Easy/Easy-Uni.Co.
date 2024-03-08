
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_resendpccoperation_sdi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_resendpccoperation_sdi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- la sp rigenera il file trasmesso, usando gli stessi dati
CREATE procedure compute_resendpccoperation_sdi( 
	@idpcc int 
	)
	as
begin
--	CO-1
--	CS-2
--	CP-3
-- setuser 'amministrazione'
 --exec compute_resendpccoperation_sdi 721

create table #dati(
	nriga int identity(1,1),
	opkind char(3),
	oporder int,
	idinvkind int,  
	yinv smallint, 
	ninv int,
	idsdi_acquisto int,
	invrownum int,
	identificativo_sdi bigint,
	ninvoice varchar(35),
	idreg int,	
	ipa varchar(6),
	dataemissione date,
	numerodocumento varchar(20),
	importototaledocumento decimal(19,2),
	descrizione varchar(100),	--> da usare quando il doc. non è contabilizzati
	-- SID
	idpccdebitstatusdetail int,
	importononcommerciale decimal(19,2),
	imp_sosp_contenzioso decimal(19,2),
	iva_sosp_contenzioso decimal(19,2),
	start_sosp_contenzioso date ,
	imp_sosp_contestazione decimal(19,2),
	iva_sosp_contestazione decimal(19,2),
	start_sosp_contestazione date,
	imp_sosp_regolareverifica decimal(19,2),
	iva_sosp_regolareverifica decimal(19,2),
	start_sosp_regolareverifica date,
	imp_nonliquidabile decimal(19,2),
	iva_nonliquidabile decimal(19,2),

-- MI
	flag_enable_split_payment char(1),

-- SCADENZA
	datascadenza date,
	importoscadenza decimal(19,2)
)



--select * from pccdocamountvar
-- SID
INSERT INTO #dati(
		opkind,oporder,
		idinvkind, yinv, ninv, idsdi_acquisto,dataemissione,
		idreg,
		identificativo_sdi, ninvoice,
		idpccdebitstatusdetail,
		importononcommerciale,
		imp_sosp_contenzioso,
		iva_sosp_contenzioso,
		start_sosp_contenzioso,
		imp_sosp_contestazione,
		iva_sosp_contestazione,
		start_sosp_contestazione,
		imp_sosp_regolareverifica,
		iva_sosp_regolareverifica,
		start_sosp_regolareverifica,
		imp_nonliquidabile,
		iva_nonliquidabile
	)

select 
		'SID', 	1,
		P.idinvkind, P.yinv, P.ninv, I.idsdi_acquisto,I.docdate,
		I.idreg,
		ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi), 
		-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
		-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
		case
			when I.idsdi_acquisto is not null then sdi.ninvoice
			when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
			else I.doc
		end,
		P.idpccdebitstatusdetail,
		P.importononcommerciale,
		P.imp_sosp_contenzioso,
		P.iva_sosp_contenzioso,
		P.start_sosp_contenzioso,
		P.imp_sosp_contestazione,
		P.iva_sosp_contestazione,
		P.start_sosp_contestazione,
		P.imp_sosp_regolareverifica,
		P.iva_sosp_regolareverifica,
		P.start_sosp_regolareverifica,
		P.imp_nonliquidabile,
		P.iva_nonliquidabile
		from pccdebitstatusdetail P
		join invoice I on I.idinvkind = P.idinvkind and I.yinv = P.yinv and I.ninv = P.ninv
		left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		where P.idpcc = @idpcc

-- OPERAZIONE Split Payment (MI)
Insert into #dati(
			opkind,	oporder,
			idinvkind, yinv, ninv, idsdi_acquisto,
			idreg,
			identificativo_sdi, ninvoice,
			flag_enable_split_payment
	 )
select     'MI',2,
			I.idinvkind, I.yinv, I.ninv, I.idsdi_acquisto,
			I.idreg,
			ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi), 
			-- Se è una FE di acqsuito, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acqsuito estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when I.idsdi_acquisto is not null then sdi.ninvoice
				when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
				else I.doc
			end,
			P.flag_enable_split_payment
from pccsplitpayment P
join invoiceview I 
		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join invoicekind IK
	ON IK.idinvkind = I.idinvkind
left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
where P.idpcc = @idpcc

-- OPERAZIONE di Scadenza Fatture
Insert into #dati(
			opkind,	oporder,
			idreg,
			idinvkind, yinv, ninv,
			identificativo_sdi, ninvoice,
			dataemissione,
			datascadenza
	 )
select     'CS',3,
			I.idreg,
			I.idinvkind, I.yinv, I.ninv,
			ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi), 
			-- Se è una FE di acqsuito, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acqsuito estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when I.idsdi_acquisto is not null then sdi.ninvoice
				when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
				else I.doc
			end,
			I.docdate ,	
			P.expiringdate

from pccexpiring P
 join  invoiceview I 
		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
join  invoicekind IK
	ON IK.idinvkind = I.idinvkind
left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
where P.idpcc = @idpcc 

update #dati set dataemissione = (select adate from sdi_acquisto where idsdi_acquisto = #dati.idsdi_acquisto)--(select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) 
where idsdi_acquisto is not null and dataemissione is null

update #dati set ipa = (select codice_ipa from sdi_acquisto where idsdi_acquisto = #dati.idsdi_acquisto)--(select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) 
where idsdi_acquisto is not null and ipa is null

update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null AND ipa is null


select 
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,
	D.ninvoice  as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
	case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio

	ltrim(rtrim(D.opkind)) as 'azione',
	null as imponibile, -- NON LO STRASMETTIAMO 
	null as imposta , -- NON La STRASMETTIAMO 

	isnull(importononcommerciale,0) as importononcommerciale,
	isnull(imp_sosp_contenzioso,0) + isnull(iva_sosp_contenzioso,0) as importo_sosp_contenzioso,
	start_sosp_contenzioso,

	isnull(imp_sosp_contestazione,0) + isnull(iva_sosp_contestazione,0) as importo_sosp_contestazione,
	start_sosp_contestazione,

	isnull(imp_sosp_regolareverifica,0) + isnull(iva_sosp_regolareverifica,0) as importo_sosp_regolareverifica,
	start_sosp_regolareverifica,

	isnull(imp_nonliquidabile,0) + isnull(iva_nonliquidabile,0) as importo_nonliquidabile,

	-- REGIME IVA
	D.flag_enable_split_payment as flagsplit,
	--SCADENZA
	D.datascadenza as datascadenza ,
	null as NmeroProcotolloEntrata--,

	--D.oporder 
from #dati D
join registry R		on R.idreg = D.idreg
order by oporder,
 D.numerodocumento,  D.yinv
end

GO

 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



