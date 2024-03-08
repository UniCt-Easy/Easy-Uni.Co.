
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_pccoperation_sid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_pccoperation_sid]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- il parametro è la data contabile. Quindi prendiamo tutte le operazioni emesse alla data contabile,  contabilizzate alla data, pagate alla data, scadute ala data...
-- protocollate nel R.U.
--setuser'amm'
-- setuser 'amministrazione'
--exec compute_pccoperation_sid {d '2022-12-31'},null,null,null,null,null ,'S','N','N'
CREATE procedure compute_pccoperation_sid( 
	@adate datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@sid char(1),-- vale S o N
	@cs char(1),-- vale S o N
	@mi char(1) -- vale S o N
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
 
-- setuser 'amministrazione'
-- exec compute_pccoperation_sid {d '2017-10-23'},null,null,null,null,null ,'S','N','S'

declare @1luglio2014 datetime
set @1luglio2014 = {d '2014-07-01'}

declare @1luglio2017_splitparcelle datetime
set @1luglio2017_splitparcelle = {d '2017-07-01'}


create table #invoicew (
	idinvkind int, 
	yinv int,
	ninv int,
	taxable decimal(38,6),
	total decimal (38,2),
	rounding decimal(38,6),
	idreg int,
	docdate date,
	adate date,
	doc varchar(35),
	ipa_acq varchar(6),
	flag_reverse_charge char,
	idsdi_acquisto int,
	idsdi_acquistoestere int,
	identificativo_sdi bigint,
	ninvoice varchar(35), -- numero fattura FE, letto dal file e scritto in sdi_acquisto
	idsor01 int,
	idsor02 int,
	idsor03 int,
	idsor04 int,
	idsor05 int,
	flag_enable_split_payment char,
	exchangerate float,
	description varchar(150),
	flagvariation char(1)
	 CONSTRAINT xpkinvoicepcc_temppcc PRIMARY KEY (idinvkind,yinv,ninv) 
)
if(@sid='S')
Begin
	insert into #invoicew (idinvkind ,yinv ,ninv, taxable, total, rounding, idreg, docdate, adate, doc, ipa_acq, flag_reverse_charge, 
	idsdi_acquisto, idsdi_acquistoestere, identificativo_sdi, ninvoice, idsor01 ,idsor02 ,idsor03 ,idsor04 ,idsor05 ,flag_enable_split_payment ,exchangerate, description ,flagvariation
	)

	select I.idinvkind, I.yinv, I.ninv, 

	ISNULL
								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
									 FROM            invoicedetail AS D INNER JOIN
															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) AS taxable,


	ISNULL
								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
									 FROM            invoicedetail AS D INNER JOIN
															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) + ISNULL
								 ((SELECT        SUM(ROUND(D.tax, 2)) AS Expr1
									 FROM            invoicedetail AS D INNER JOIN
															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) AS total,



	ISNULL
								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
									 FROM            invoicedetail AS D INNER JOIN
															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv) AND (ISNULL(D.rounding, 'N') = 'S') OR
															  (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv) AND (ISNULL(D.flagbit, 0) & 4 <> 0)), 0) AS rounding, 
	I.idreg, isnull(I.docdate, sdi.adate), I.adate, I.doc, isnull(I.ipa_acq, sdi.codice_ipa), I.flag_reverse_charge, 
	I.idsdi_acquisto, I.idsdi_acquistoestere, isnull(sdi.identificativo_sdi,sdi_estere.identificativo_sdi ), 
	-- Se è una FE di acqsuito, prende ninvoice di sdi_acquisto.
	-- Se è una FE di acqsuito estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
	case
		when I.idsdi_acquisto is not null then sdi.ninvoice
		when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
		else I.doc
	end,
	I.idsor01, I.idsor02, I.idsor03, I.idsor04 ,I.idsor05 ,I.flag_enable_split_payment ,I.exchangerate,
	I.description,
		CASE
		WHEN ((ik.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((ik.flag&4)<>0) THEN 'S'
	END 
	from invoice I WITH (nolock)
	join invoicekind ik on I.idinvkind = IK.idinvkind
	join pccdebitstatusdetail DD  ON DD.idinvkind = I.idinvkind AND DD.yinv = I.yinv AND DD.ninv = I.ninv
	left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
	left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
	where   ((ik.flag&1)=0) -- Fatt. di acquisto
		and (exists (select * from pccsend P (nolock) where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
		OR 
		I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
		OR 
		-- Prendiamo anche le FE di acquisto estere trasmesse allo SdI senza scarto.
		exists (select * from sdi_acquistoestere sdi where sdi.idsdi_acquistoestere = I.idsdi_acquistoestere and 
		sdi.identificativo_sdi is not null and (sdi.flag_unseen&1)=0) 
		)
		AND DD.idpcc is null
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)

End

--select * from #invoicew
--if(@cs='S')
--Begin
--	insert into #invoicew (idinvkind ,yinv ,ninv, taxable, total, rounding, idreg, docdate, adate, doc, ipa_acq, flag_reverse_charge, 
--	idsdi_acquisto, idsdi_acquistoestere,identificativo_sdi, ninvoice,	idsor01 ,idsor02 ,idsor03 ,idsor04 ,idsor05 ,flag_enable_split_payment ,exchangerate, description 
--	)

--	select I.idinvkind, I.yinv, I.ninv, 

--	ISNULL
--								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
--									 FROM            invoicedetail AS D INNER JOIN
--															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
--									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) AS taxable,
--	ISNULL
--								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
--									 FROM            invoicedetail AS D INNER JOIN
--															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
--									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) + ISNULL
--								 ((SELECT        SUM(ROUND(D.tax, 2)) AS Expr1
--									 FROM            invoicedetail AS D INNER JOIN
--															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
--									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv)), 0) AS total,
--	ISNULL
--								 ((SELECT        SUM(ROUND((D.taxable * ISNULL(D.npackage, D.number) * CONVERT(decimal(19, 10), M.exchangerate)) * (1 - CONVERT(decimal(19, 6), ISNULL(D.discount, 0.0))), 2)) AS Expr1
--									 FROM            invoicedetail AS D INNER JOIN
--															  invoice AS M ON D.idinvkind = M.idinvkind AND D.yinv = M.yinv AND D.ninv = M.ninv
--									 WHERE        (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv) AND (ISNULL(D.rounding, 'N') = 'S') OR
--															  (D.idinvkind = I.idinvkind) AND (D.yinv = I.yinv) AND (D.ninv = I.ninv) AND (ISNULL(D.flagbit, 0) & 4 <> 0)), 0) AS rounding, 
--	I.idreg, I.docdate, I.adate, I.doc, I.ipa_acq, I.flag_reverse_charge, 
--	I.idsdi_acquisto, I.idsdi_acquistoestere,isnull(sdi.identificativo_sdi,sdi_estere.identificativo_sdi ), sdi.ninvoice,
--	I.idsor01, I.idsor02, I.idsor03, I.idsor04 ,I.idsor05 ,I.flag_enable_split_payment ,I.exchangerate, I.description
--	from invoice I WITH (nolock)
--	join invoicekind ik on I.idinvkind = IK.idinvkind
--	left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
--	left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere

--	where   ((ik.flag&1)=0) -- FE di acquisto
--			and exists (select * from pccexpense P 
--									where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
--			AND not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
--	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
--	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
--	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
--	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
--	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)		
--	and not exists (select * from #invoicew V 
--									where V.idinvkind = I.idinvkind and V.yinv = I.yinv and V.ninv = I.ninv)

--End



create table #dati(
	nriga int identity(1,1),
	opkind char(3),
	idinvkind int,  
	yinv smallint, 
	ninv int,
	invrownum int,
	identificativo_sdi bigint,
	doc varchar(35),
	ninvoice varchar(35),
	numero varchar(20),
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

---- CONTABILIZZAZIONE
--	importodelmovimento decimal(19,2),
--	statodeldebito varchar(9),
--	causale varchar(20),
--	datacontabiledocumento datetime, 
-- MI
	flag_enable_split_payment char(1),

-- SCADENZA
	datascadenza date,
	importoscadenza decimal(19,2)
)

 if(@sid='S')
 Begin

	INSERT INTO #dati(
		opkind,
		idreg,
		idinvkind, yinv, ninv, identificativo_sdi, dataemissione,
		doc,ninvoice,
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
					
	SELECT 
		'SID',
		I.idreg,
		DD.idinvkind, DD.yinv, DD.ninv, I.identificativo_sdi, 
		I.docdate,
		I.doc,I.ninvoice,
		DD.idpccdebitstatusdetail,
		DD.importononcommerciale,
		DD.imp_sosp_contenzioso,
		DD.iva_sosp_contenzioso,
		DD.start_sosp_contenzioso,
		DD.imp_sosp_contestazione,
		DD.iva_sosp_contestazione,
		DD.start_sosp_contestazione,
		DD.imp_sosp_regolareverifica,
		DD.iva_sosp_regolareverifica,
		DD.start_sosp_regolareverifica,
		DD.imp_nonliquidabile,
		DD.iva_nonliquidabile
		from pccdebitstatusdetail DD
		join #invoicew I on I.idinvkind = DD.idinvkind and I.yinv = DD.yinv and I.ninv = DD.ninv
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where I.docdate between @1luglio2014 and @adate 
			and DD.idpcc is null --- Tutte le righe non ancora trasmesse
			and (exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				OR 
				I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
				OR 
				I.idsdi_acquistoestere is not null -- Prendiamo anche le FE di acquisto estere
				)
			-- non è stata trasmessa la scadenza
			-- and not exists (select * from pccexpiring P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			--Dobbiamo inglobare anche le FE di acquisto estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P where P.idinvkind = DD.idinvkind and P.yinv = DD.yinv and P.ninv = DD.ninv )
			-- non ci sono dettagli che restano negativi dopo l'aggregazione, altrimenti scarta tutta la fattura
			AND isnull(I.taxable,0) >0 -- Solo fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.

				-- DA RICONSIDERARE --
				------------and (not exists (select T.idexp from expenselast T			 
				------------				where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
				------------			or  I.idsdi_acquistoestere is not null
				------------			or @OPIattivo='N')


end


if (@cs = 'S')
Begin
		INSERT INTO #dati(
			opkind,
			idreg,
			idinvkind, yinv, ninv,
			identificativo_sdi, doc,ninvoice,
			--idreg,	
			dataemissione,
			--numerodocumento,
			--importototaledocumento,
			--importoscadenza,
			datascadenza,
			ipa
			)
		select distinct 
			'CS',
			I.idreg,
			I.idinvkind, I.yinv, I.ninv,
			ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi), 
			I.doc,
		-- Se è una FE di acqsuito, prende ninvoice di sdi_acquisto.
		-- Se è una FE di acqsuito estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when I.idsdi_acquisto is not null then sdi.ninvoice
				when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
				else I.doc 
			end,
			--I.idreg,	
			isnull(I.docdate, sdi.adate) ,				-- dataemissione
			--substring(I.doc,1,20),	-- numerodocumento
			---- ImportoTotaleDocumento:
			--case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			--case	when isnull(I.flag_enable_split_payment,'N') = 'N' then ID.rowtotal
			--		when isnull(I.flag_enable_split_payment,'N') = 'S' then ID.taxable_euro
			--End,
				-- Data Scadenza Pagamento
				case 
				-- Data contabile(data registrazione)  = Numero gg D.R.F.
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, I.paymentexpiring, I.adate)
				when (I.idexpirationkind = 1 AND isnull(I.paymentexpiring,0)=0) then I.adate
				-- Data documento = Numero gg  D.F.
				when (I.idexpirationkind = 2 AND I.docdate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, I.paymentexpiring, I.docdate)
				when (I.idexpirationkind = 2 AND isnull(I.paymentexpiring,0)=0) then I.docdate
				-- Fine mese data documento = Numero gg F.M.D.F.
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)>0) then DATEADD(day, I.paymentexpiring,  DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate))) ) 
				when (I.idexpirationkind = 3 AND I.docdate is not null and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.docdate) ,I.docdate)))
				-- Fine mese data contabile = Numero gg F.M.D.R.F.
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)>0) then DATEADD(day, I.paymentexpiring,     DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate))) )
				when (I.idexpirationkind = 4  and isnull(I.paymentexpiring,0)=0) then DATEADD(day, -1, DATEADD(month, 1, DATEADD(day, 1 - DAY(I.adate) ,I.adate)))
				--	Pagamento Immediato  = data registrazione
				when I.idexpirationkind = 5 then I.adate
				-- Data ricezione
				when (I.idexpirationkind = 6 AND I.protocoldate is not null AND isnull(I.paymentexpiring,0)>0) then DATEADD(day, I.paymentexpiring, I.protocoldate)
				when (I.idexpirationkind = 6 AND isnull(I.paymentexpiring,0)=0) then I.protocoldate
			else null
			end,
			isnull(I.ipa_acq, sdi.codice_ipa)
		from invoice I
		join invoicedetailview ID
			on I.yinv = ID.yinv and I.ninv = ID.ninv and I.idinvkind = ID.idinvkind
		join invoicekind ik on I.idinvkind = IK.idinvkind
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		where I.docdate between @1luglio2014 and @adate 
			and ((ik.flag&1)=0) -- FE di acquisto
			--and exists (select * from pccexpense P 
			--						where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			AND 
			(
			not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv and P.invrownum is null)
			AND
			not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
			)
			and ID.idpccdebitstatus not in ('NOLIQ')
			AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(ID.flagbit,0) & 4) = 0
			AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
			and not exists (select * from pccpayment P 
									where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			--Dobbiamo inglobare anche le FE di acquisto estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')

		delete from #dati 
		where opkind='CS' and  datascadenza is not null and getdate() > DATEADD(day,   15 -datepart(day, DATEADD (month , 1 , datascadenza))   ,DATEADD (month , 1 , datascadenza))

END -- Fine inserimento CS
--select * from #dati
if (@mi = 'S')
Begin
		INSERT INTO #dati(
			opkind,
			idreg,
			idinvkind, yinv, ninv,
			identificativo_sdi,doc,  ninvoice,
			flag_enable_split_payment
			)
		select distinct
			'MI',
			I.idreg,
			I.idinvkind, I.yinv, I.ninv,
			sdi.identificativo_sdi,
			I.doc,sdi.ninvoice,
			I.flag_enable_split_payment
		from invoice I
		join invoicedetailview ID
			on I.yinv = ID.yinv and I.ninv = ID.ninv and I.idinvkind = ID.idinvkind
		join invoicekind ik on I.idinvkind = IK.idinvkind
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		where I.docdate between @1luglio2014 and @adate 
			and I.flag_enable_split_payment <> sdi.split_payment -->>>>>>>>>>>>>>> SOLO QUELLI CON flag DIVERSO
			and sdi.split_payment is not null
			and ((ik.flag&1)=0) -- FE di acquisto
			AND 
			(
				not exists(select * from pccsplitpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv )
			)
			and ID.idpccdebitstatus not in ('NOLIQ')
			AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(ID.flagbit,0) & 4) = 0
			AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
			and not exists (select * from pccpayment P 
									where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			--Dobbiamo inglobare anche le FE di acquisto estere
			and (RR.coderesidence='I')
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				--and (not exists (select T.idexp from expenselast T			 
				--				where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
				--			or @OPIattivo='N')
END -- Fine inserimento MI

declare @cf varchar(11)
select @cf = cf from license

------------------------------------------------------------------------------



update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null AND ipa is null
SELECT 
	nriga,
	D.idinvkind, 
	D.yinv ,D.ninv, 
	K.description as invoicekind,
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,
	-- IDENTIFICATIVO_2_b lo valorizziamo solo se esiste un identificativo Sdi
	case when D.identificativo_sdi is not null then D.ninvoice else D.doc end 	as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
	case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio

	-- SID
	D.idpccdebitstatusdetail,
	ltrim(rtrim(D.opkind)) as 'azione',
	null as imponibile, -- NON LO STRASMETTIAMO 
	null as imposta , -- NON La STRASMETTIAMO 
	isnull(importononcommerciale,0) as importononcommerciale,

	isnull(imp_sosp_contenzioso,0) as imp_sosp_contenzioso,
	isnull(iva_sosp_contenzioso,0) as iva_sosp_contenzioso,
	isnull(imp_sosp_contenzioso,0) + isnull(iva_sosp_contenzioso,0) as importo_sosp_contenzioso,
	start_sosp_contenzioso,
	
	isnull(imp_sosp_contestazione,0) as imp_sosp_contestazione,
	isnull(iva_sosp_contestazione,0) as iva_sosp_contestazione,
	isnull(imp_sosp_contestazione,0) + isnull(iva_sosp_contestazione,0) as importo_sosp_contestazione,
	start_sosp_contestazione,

	isnull(imp_sosp_regolareverifica,0) as imp_sosp_regolareverifica,
	isnull(iva_sosp_regolareverifica,0) as iva_sosp_regolareverifica,
	isnull(imp_sosp_regolareverifica,0) + isnull(iva_sosp_regolareverifica,0) as importo_sosp_regolareverifica,
	start_sosp_regolareverifica,

	isnull(imp_nonliquidabile,0) as imp_nonliquidabile,
	isnull(iva_nonliquidabile,0) as iva_nonliquidabile,
	isnull(imp_nonliquidabile,0) + isnull(iva_nonliquidabile,0) as importo_nonliquidabile,

	-- REGIME IVA
	null as flagsplit,
	--SCADENZA
	null as datascadenza,
	null as NmeroProcotolloEntrata
FROM #dati D
join invoicekind K on D.idinvkind = K.idinvkind
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
where D.opkind='SID' -- and ISNULL(D.importototaledocumento,0) <> 0
UNION ALL

select 
	nriga,
	D.idinvkind, 
	D.yinv ,D.ninv, 
	K.description as invoicekind,
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,
	-- IDENTIFICATIVO_2_b lo valorizziamo solo se esiste un identificativo Sdi
	case when D.identificativo_sdi is not null then D.ninvoice else D.doc end 	as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
	case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio
	null as idpccdebitstatusdetail,
	-- SID
	ltrim(rtrim(D.opkind)) as 'azione',
	null as imponibile, -- NON LO STRASMETTIAMO 
	null as imposta , -- NON La STRASMETTIAMO 
	null as importononcommerciale,

	null as imp_sosp_contenzioso,
	null as iva_sosp_contenzioso,
	null as importo_sosp_contenzioso,
	null as start_sosp_contenzioso,
	
	null as imp_sosp_contestazione,
	null as iva_sosp_contestazione,
	null as importo_sosp_contestazione,
	null as start_sosp_contestazione,

	null as imp_sosp_regolareverifica,
	null as iva_sosp_regolareverifica,
	null as importo_sosp_regolareverifica,
	null as start_sosp_regolareverifica,

	null as imp_nonliquidabile,
	null as iva_nonliquidabile,
	null as importo_nonliquidabile,
	-- REGIME IVA
	D.flag_enable_split_payment as flagsplit,
	--SCADENZA
	null as datascadenza ,
	null as NmeroProcotolloEntrata

from #dati D
join invoicekind K on D.idinvkind = K.idinvkind
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
where D.opkind='MI' 

UNION ALL

select 
	nriga,
	D.idinvkind, 
	D.yinv ,D.ninv, 
	K.description as invoicekind,
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,

	-- IDENTIFICATIVO_2_b lo valorizziamo solo se esiste un identificativo Sdi
	case when D.identificativo_sdi is not null then D.ninvoice else D.doc end 	as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */

	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
	case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio
	D.idpccdebitstatusdetail,
	-- SID
	ltrim(rtrim(D.opkind)) as 'azione',
	null as imponibile, -- NON LO STRASMETTIAMO 
	null as imposta , -- NON La STRASMETTIAMO 
	null as importononcommerciale,

	null as imp_sosp_contenzioso,
	null as iva_sosp_contenzioso,
	null as importo_sosp_contenzioso,
	null as start_sosp_contenzioso,
	
	null as imp_sosp_contestazione,
	null as iva_sosp_contestazione,
	null as importo_sosp_contestazione,
	null as start_sosp_contestazione,

	null as imp_sosp_regolareverifica,
	null as iva_sosp_regolareverifica,
	null as importo_sosp_regolareverifica,
	null as start_sosp_regolareverifica,

	null as imp_nonliquidabile,
	null as iva_nonliquidabile,
	null as importo_nonliquidabile,
	-- REGIME IVA
	null as flagsplit,
	--SCADENZA
	D.datascadenza as datascadenza ,
	null as NmeroProcotolloEntrata
	
from #dati D
join invoicekind K on D.idinvkind = K.idinvkind
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
where D.opkind='CS' -- and ISNULL(D.importototaledocumento,0) <> 0
and datascadenza is not null
order by nriga,K.description, D.ninv, D.yinv, ltrim(rtrim(D.opkind))


drop table #dati
drop table #invoicew
end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


