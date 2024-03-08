
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_pccoperation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_pccoperation]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
-- il parametro è la data contabile. Quindi prendiamo tutte le operazioni emesse alla data contabile,  contabilizzate alla data, pagate alla data, scadute ala data...
-- protocollate nel R.U.
--setuser'amm'
-- setuser 'amministrazione'
--exec compute_pccoperation {d '2022-10-20'},null,null,null,null,null ,'S','N','N'
CREATE procedure compute_pccoperation( 
	@adate datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@co char(1),-- vale S o N
	@cs char(1),-- vale S o N
	@cp char(1) -- vale S o N
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
-- exec compute_pccoperation {d '2017-10-23'},null,null,null,null,null ,'S','N','S'

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
	docdate smalldatetime,
	adate smalldatetime,
	doc varchar(45),
	ipa_acq varchar(6),
	flag_reverse_charge char,
	idsdi_acquisto int,
	idsdi_acquistoestere int,
	identificativo_sdi bigint,
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
if(@co='S')
Begin
	insert into #invoicew (idinvkind ,yinv ,ninv, taxable, total, rounding, idreg, docdate, adate, doc, ipa_acq, flag_reverse_charge, 
	idsdi_acquisto, idsdi_acquistoestere,identificativo_sdi,idsor01 ,idsor02 ,idsor03 ,idsor04 ,idsor05 ,flag_enable_split_payment ,exchangerate, description ,flagvariation
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
	I.idreg, I.docdate, I.adate, I.doc, I.ipa_acq, I.flag_reverse_charge, 
	I.idsdi_acquisto, I.idsdi_acquistoestere, isnull(sdi.identificativo_sdi,sdi_estere.identificativo_sdi ),I.idsor01, I.idsor02, I.idsor03, I.idsor04 ,I.idsor05 ,I.flag_enable_split_payment ,I.exchangerate,
	I.description,
		CASE
		WHEN ((ik.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((ik.flag&4)<>0) THEN 'S'
	END 
	from invoice I WITH (nolock)
	join invoicekind ik on I.idinvkind = IK.idinvkind
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
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)

End


if(@cs='S')
Begin
	insert into #invoicew (idinvkind ,yinv ,ninv, taxable, total, rounding, idreg, docdate, adate, doc, ipa_acq, flag_reverse_charge, 
	idsdi_acquisto, idsdi_acquistoestere,identificativo_sdi,	idsor01 ,idsor02 ,idsor03 ,idsor04 ,idsor05 ,flag_enable_split_payment ,exchangerate, description 
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
	I.idreg, I.docdate, I.adate, I.doc, I.ipa_acq, I.flag_reverse_charge, 
	I.idsdi_acquisto, I.idsdi_acquistoestere,isnull(sdi.identificativo_sdi,sdi_estere.identificativo_sdi ), I.idsor01, I.idsor02, I.idsor03, I.idsor04 ,I.idsor05 ,I.flag_enable_split_payment ,I.exchangerate, I.description
	from invoice I WITH (nolock)
	join invoicekind ik on I.idinvkind = IK.idinvkind
	left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
	left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere

	where   ((ik.flag&1)=0) -- FE di acquisto
			and exists (select * from pccexpense P 
									where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			AND not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)		
	and not exists (select * from #invoicew V 
									where V.idinvkind = I.idinvkind and V.yinv = I.yinv and V.ninv = I.ninv)
	--and ((I.idinvkind = 283 and I.yinv = 2016 and I.ninv = 20) 
	--or 
	--(I.idinvkind = 60 and I.yinv = 2015 and I.ninv = 512) )
End

if(@CP='S')
Begin
	-- Per le comunicazioni di pagamento le FE di acquisto estere vanno escluse.
	insert into #invoicew (idinvkind ,yinv ,ninv, taxable, total, rounding, idreg, docdate, adate, doc, ipa_acq, flag_reverse_charge, 
	idsdi_acquisto, 	identificativo_sdi, idsor01 ,idsor02 ,idsor03 ,idsor04 ,idsor05 ,flag_enable_split_payment ,exchangerate, description 
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
	I.idreg, I.docdate, I.adate, I.doc, I.ipa_acq, I.flag_reverse_charge, 
	I.idsdi_acquisto, sdi.identificativo_sdi, I.idsor01, I.idsor02, I.idsor03, I.idsor04 ,I.idsor05 ,I.flag_enable_split_payment ,I.exchangerate, I.description
	from invoice I WITH (nolock)
	join invoicekind ik on I.idinvkind = IK.idinvkind
	left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
	where   ((ik.flag&1)=0) -- FE di acquisto
	and not exists(select * from pccpayment P (nolock) where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
	and I.idsdi_acquistoestere is null -- Dobbiamo escludere le FE di acquisto estere.
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
	and not exists (select * from #invoicew V 
									where V.idinvkind = I.idinvkind and V.yinv = I.yinv and V.ninv = I.ninv)
	 
End



create table #dati(
	nriga int identity(1,1),
	opkind char(3),
	idinvkind int,  
	yinv smallint, 
	ninv int,
	invrownum int,
	identificativo_sdi bigint,
	idmankind varchar(20),
	yman smallint,
	nman int,
	manrownum int,
	ycon int,
	ncon int,
	idreg int,	
	idfin int,--li usiamo solo per la piccola spesa
	idupb varchar(36),--li usiamo solo per la piccola spesa
	ipa varchar(6),
	dataemissione datetime,
	numerodocumento varchar(20),
	importototaledocumento decimal(19,2),
	descrizione varchar(100),	--> da usare quando il doc. non è contabilizzati
	idexpimpegno int,
	cigcode varchar(15),
	cupcode varchar(15),
	naturadispesa char(2),
-- CONTABILIZZAZIONE
	importodelmovimento decimal(19,2),
	statodeldebito varchar(9),
	causale varchar(20),
	datacontabiledocumento datetime, 
-- PAGAMENTO
	importopagato decimal(19,2),
	kpay int,
	idpettycash int,
	yoperation int,
	noperation smallint,
	piccolaspesa varchar(100),
	paymentdate datetime,
	idexppagamento int,

-- SCADENZA
	datascadenza datetime,
	importoscadenza decimal(19,2)
)
declare @finphase tinyint
SET @finphase = (SELECT expensephase FROM config where ayear = year(@adate))

DECLARE @maxphase tinyint 
SELECT  @maxphase = MAX(nphase) FROM 	expensephase

create table #contabilizzazioni(
	idinvkind int,  
	yinv smallint, 
	ninv int,
	invrownum int,
	identificativo_sdi bigint,
	idmankind varchar(20),
	yman smallint,
	nman int,
	manrownum int,
	ycon int,
	ncon int,
	amount decimal(19,2),
	idexp int,
	cigcode varchar(15),
	cupcode varchar(15),
	expensekind varchar(2),
	ipa varchar(6)
)


IF(@co = 'S')	
Begin
		-- CONTABILIZZAZIONI Fatture Collegate a C.P.
		INSERT INTO #dati(
			opkind,
			idinvkind, yinv, ninv, invrownum, identificativo_sdi,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento, 
			importodelmovimento ,
			naturadispesa,
			statodeldebito,
			causale ,
			idexpimpegno ,
			cigcode ,
			cupcode,
			ipa 
			)

		select 
			case when (select count(*) from invoicedetail ID2 (nolock) where I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv)=1 then 'CO'else 'COF' end,
			I.idinvkind, I.yinv, I.ninv, ID.rownum, I.identificativo_sdi,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then (I.taxable - I.rounding) else  (I.total - I.rounding) end,--vedi task 7360 per il rounding
			I.adate,
			--> importodelmovimento
			case	-- Esamina isnull(I.flag_reverse_charge,'N')='S', non deve considerare l'iva
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S' and (MD.idexp_iva = MD.idexp_taxable) 
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S' and (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'')) 
						then 0
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S' and (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'')) 
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S' and (MD.idexp_iva is null and MD.idexp_taxable is null) 
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0) -- Se non è contabilizzato prende il tot. riga
					when isnull(I.flag_enable_split_payment,'N') = 'S' and isnull(I.flag_reverse_charge,'N')='S'
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					-- Esamina isnull(I.flag_reverse_charge,'N')='N', considera anche l'iva
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='N' and (MD.idexp_iva = MD.idexp_taxable) 
						then CONVERT(decimal(19,2),ROUND(ID.tax,2)) + isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when isnull(I.flag_enable_split_payment,'N') = 'N'and isnull(I.flag_reverse_charge,'N')='N'  and (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'')) 
						then CONVERT(decimal(19,2),ROUND(ID.tax,2)) 
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='N' and (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'')) 
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when isnull(I.flag_enable_split_payment,'N') = 'N'  and isnull(I.flag_reverse_charge,'N')='N' and (MD.idexp_iva is null and MD.idexp_taxable is null) 
						then CONVERT(decimal(19,2),ROUND(ID.tax,2))  + isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0) -- Se non è contabilizzato prende il tot. riga
					when isnull(I.flag_enable_split_payment,'N') = 'S'  and isnull(I.flag_reverse_charge,'N')='N'
						then isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
			end,
			case	when ID.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then ID.expensekind
					else 'NA'
			end, -- natura di spesa
			ID.idpccdebitstatus, -- statodeldebito
			ID.idpccdebitmotive, -- causale
			-- idexpimpegno:
			case	when (MD.idexp_iva = MD.idexp_taxable) then MD.idexp_iva
					when (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'') ) then MD.idexp_iva
					when (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'') ) then MD.idexp_taxable
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(MD.cigcode,ID.cigcode) -- CIG
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(MD.cupcode, ID.cupcode) -- CUP
			end,
			I.ipa_acq
		from #invoicew I  
		join invoicedetail ID 	(nolock)		on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join mandatedetail MD	(nolock)			on ID.idmankind = MD.idmankind and ID.yman = MD.yman and ID.nman = MD.nman and ID.manrownum = MD.rownum
		join registry R on I.idreg = R.idreg		join residence RR  on R.residence=RR.idresidence
		where  I.docdate between @1luglio2014 and @adate 
				and (
					exists (select * from pccsend P (nolock) where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv)
					OR 
					I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
					OR 
					I.idsdi_acquistoestere is not null -- Prendiamo anche le Fe di acqsuito estere
					)
				and (
					-- se non esiste
					(
					not exists(select * from pccexpense P (nolock) where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum is null)
					AND
					not exists(select * from pccexpense P (nolock) where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
					)
					OR -- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
					ID.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum = ID.rownum
											order by idpcc desc)
				)
				-- task 7247 se pccexpense non esiste un suo fratello trasmesso	con l'operazione di CO.
				and not exists(select * from pccexpense P
								join invoicedetail ID2
									on P.idinvkind = ID2.idinvkind and P.yinv = ID2.yinv and P.ninv = ID2.ninv and P.invrownum  = ID2.rownum
								where ID2.idinvkind = ID.idinvkind and ID2.yinv = ID.yinv and ID2.ninv = ID.ninv and ID2.idgroup  = ID.idgroup and ID2.rownum  <> ID.rownum)
				-- non è stata trasmessa la scadenza
				-- and not exists (select * from pccexpiring P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
				AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
				and (isnull(ID.flagbit,0) & 4) = 0
				--Dobbiamo inglobare anche le FE di acqsuito estere
				and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
				-- non è stata trasmesso alcun pagamento, task 7277 
				AND not exists (select TOP 1 idpcc from pccpayment P (nolock) where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
				-- non ci sono dettagli che restano negativi dopo l'aggregazione, altrimenti scarta tutta la fattura
				AND (
					(select count(*) from invoiceresidualmandate IR
								where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0 ) = 0 
					or
					(	flagvariation='S' -- il problema dei dettagli negativi non deve valere per le NC, se i looro dettagli si compensando e non danno un importo negativo
						and 
						(select sum(IR.taxabletotal + IR.ivatotal) from invoiceresidualmandate IR
									where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv )>=0
						)
					)
				AND isnull(I.taxable,0) >0 -- Solo fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')


		-- CONTABILIZZAZIONI Fatture non collegate a C.P.
		-- Tipo contabilizzazione:  totale e solo iva, considera solo le fatture NO Split-payment
		INSERT INTO #dati(
			opkind,
			idinvkind,  yinv, ninv, invrownum, identificativo_sdi,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
			statodeldebito,
			causale ,
			descrizione,
			idexpimpegno ,
			cigcode ,
			cupcode,
			ipa 
			)
		select 
			case when (select count(*) from invoicedetail ID2 where I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv)=1 then 'CO'
			else 'COF' end,
			I.idinvkind, I.yinv, I.ninv, ID.rownum, I.identificativo_sdi,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then (I.taxable -I.rounding) else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			I.adate,
			--importodelmovimento:
			case	-- considera I.flag_reverse_charge ='S' 
					when (ID.idexp_iva = ID.idexp_taxable) and isnull(I.flag_reverse_charge,'N')='S' then 
							isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when  (ID.idexp_iva IS NOT NULL and  ID.idexp_iva <> isnull(ID.idexp_taxable,'')) and isnull(I.flag_reverse_charge,'N')='S' then 0
					-- considera I.flag_reverse_charge ='N' 
					when (ID.idexp_iva = ID.idexp_taxable) and isnull(I.flag_reverse_charge,'N')='N' then 
							isnull(CONVERT(decimal(19,2),ROUND(ID.tax,2)),0)+
							isnull(CONVERT(decimal(19,2),ROUND(ID.taxable * ISNULL(ID.npackage,ID.number) * 
								CONVERT(DECIMAL(19,10),I.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(ID.discount, 0.0)))
										,2
								)),0)
					when  (ID.idexp_iva IS NOT NULL and  ID.idexp_iva <> isnull(ID.idexp_taxable,'')) and isnull(I.flag_reverse_charge,'N')='N' then 
							isnull(CONVERT(decimal(19,2),ROUND(ID.tax,2)),0)
			end,
			case	when ID.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then ID.expensekind
					else 'NA'
			end, -- natura di spesa
			ID.idpccdebitstatus, -- statodeldebito
			ID.idpccdebitmotive, -- causale
			substring(E.description,1,100),
			case	when (ID.idexp_iva = ID.idexp_taxable) then ID.idexp_iva
					when (ID.idexp_iva IS NOT NULL and  ID.idexp_iva <> isnull(ID.idexp_taxable,'') ) then ID.idexp_iva
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cigcode,ID.cigcode) -- CIG
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cupcode, ID.cupcode) 
			end,
			I.ipa_acq
		from #invoicew I  
		join invoicedetail ID				on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join expense E1							on E1.idexp = ID.idexp_iva
		JOIN expenselink						ON expenselink.idchild = E1.idexp
		JOIN expense E							on expenselink.idparent = E.idexp and E.nphase = @finphase
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where ID.idmankind is null-------------->>> NON COLLEGATE A CP. Prende le fatture indipendentemente dall'associazione con la parcella. IMPORTANTE!!!
			and I.docdate between @1luglio2014 and @adate 
			and isnull(I.flag_enable_split_payment,'N') = 'N'  
			and ((ID.idexp_iva = ID.idexp_taxable)
				or 	ID.idexp_iva IS NOT NULL and  ID.idexp_iva <> isnull(ID.idexp_taxable,''))  -- contab. totale e solo iva
			and (exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				OR 
				I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
					OR 
				I.idsdi_acquistoestere is not null -- Prendiamo anche le Fe di acqsuito estere
				)
			and (
				-- se non esiste
					(
					not exists(select * from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum is null)
					AND
					not exists(select * from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
					)
				or
				-- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
				ID.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum = ID.rownum
										order by idpcc desc)
			)
			-- task 7247 se pccexpense non esiste un suo fratello trasmesso	con l'operazione di CO.
			and not exists(select * from pccexpense P
								join invoicedetail ID2
									on P.idinvkind = ID2.idinvkind and P.yinv = ID2.yinv and P.ninv = ID2.ninv and P.invrownum  = ID2.rownum
								where ID2.idinvkind = ID.idinvkind and ID2.yinv = ID.yinv and ID2.ninv = ID.ninv and ID2.idgroup  = ID.idgroup and ID2.rownum  <> ID.rownum)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
			AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(ID.flagbit,0) & 4) = 0
			--Dobbiamo inglobare anche le FE di acqsuito estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			---AND not exists (select * from profservice P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )	--	RIMOSSO
				-- non ci sono dettagli che restano negativi dopo l'aggregazione, altrimenti scarta tutta la fattura
			AND (
				(select count(*) from invoiceresidualmandate IR
					where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) = 0 
					or
					(	I.flagvariation='S' -- il problema dei dettagli negativi non deve valere per le NC, se i looro dettagli si compensando e non danno un importo negativo
						and 
						(select sum(IR.taxabletotal + IR.ivatotal) from invoiceresidualmandate IR
									where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv )>=0
						)
					)
			AND isnull(I.taxable,0) >0 -- Solo fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')

-- Topo contabilizzazione:  solo imponibile, considera sia le fatture Split-payment, che quelle NO split-payment
		INSERT INTO #dati(
			opkind,
			idinvkind,  yinv, ninv, invrownum, identificativo_sdi,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
			statodeldebito,
			causale ,
			descrizione,
			idexpimpegno ,
			cigcode ,
			cupcode,
			ipa 
			)
		select 
			case when (select count(*) from invoicedetail ID2 where I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv)=1 then 'CO'
			else 'COF' end,
			I.idinvkind, I.yinv, I.ninv, ID.rownum, I.identificativo_sdi,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable -I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			I.adate,
			isnull(ID.taxable_euro,0),
			case	when ID.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then ID.expensekind
					else 'NA'
			end, -- natura di spesa
			ID.idpccdebitstatus, -- statodeldebito
			ID.idpccdebitmotive, -- causale
			substring(E.description,1,100),
			ID.idexp_taxable,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cigcode,ID.cigcode) -- CIG
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cupcode, ID.cupcode) 
			end,
			I.ipa_acq
		from #invoicew I 
		join invoicedetailview ID				on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join expense E1							on E1.idexp = ID.idexp_taxable
		JOIN expenselink						ON expenselink.idchild = E1.idexp
		JOIN expense E							on expenselink.idparent = E.idexp and E.nphase = @finphase
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where ID.idmankind is null-------------->>> NON COLLEGATE A CP. Prende le fatture indipendentemente dall'associazione con la parcella. IMPORTANTE!!!
		-- SOLO contab. Imponibile
			and (
				(	isnull(I.flag_enable_split_payment,'N') = 'N'  and ID.idexp_taxable is not null  and  ID.idexp_taxable <> isnull(ID.idexp_iva,'')	) 
				OR
				(	isnull(I.flag_enable_split_payment,'N') = 'S' and ID.idexp_taxable is not null	)
				) 
			and I.docdate between @1luglio2014 and @adate 
			and (exists (select TOP 1 idpcc from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				OR 
				I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
					OR 
				I.idsdi_acquistoestere is not null -- Prendiamo anche le Fe di acqsuito estere
				)
			and (
				-- se non esiste
					(
					not exists(select TOP 1 idpcc from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum is null)
					AND
					not exists(select TOP 1 idpcc from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
					)
				or
				-- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
				ID.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum = ID.rownum
										order by idpcc desc)
			)
			-- task 7247 se pccexpense non esiste un suo fratello trasmesso	con l'operazione di CO.
			and not exists(select * from pccexpense P
								join invoicedetail ID2
									on P.idinvkind = ID2.idinvkind and P.yinv = ID2.yinv and P.ninv = ID2.ninv and P.invrownum  = ID2.rownum
								where ID2.idinvkind = ID.idinvkind and ID2.yinv = ID.yinv and ID2.ninv = ID.ninv and ID2.idgroup  = ID.idgroup and ID2.rownum  <> ID.rownum)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			AND isnull(ID.rowtotal,0) <> 0  --non inserire righe di importo 0, task 6213.
			AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
			AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(ID.flagbit,0) & 4) = 0
			--Dobbiamo inglobare anche le FE di acqsuito estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
			-- non è stata trasmesso alcun pagamento, task 7277 
			---AND not exists (select * from profservice P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )--	RIMOSSO
			AND not exists (select * from pccpayment P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			-- non ci sono dettagli che restano negativi dopo l'aggregazione, altrimenti scarta tutta la fattura
			AND (
				(select count(*) from invoiceresidualmandate IR
							where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) = 0 
					or
					(	I.flagvariation='S' -- il problema dei dettagli negativi non deve valere per le NC, se i looro dettagli si compensando e non danno un importo negativo
						and 
						(select sum(IR.taxabletotal + IR.ivatotal) from invoiceresidualmandate IR
									where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv )>=0
						)
				)
			AND isnull(I.taxable,0) >0 -- Solo fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')




		-- CONTABILIZZAZIONI Fatture NON contabilizzate 
		INSERT INTO #dati(
			opkind,
			idinvkind, yinv, ninv,invrownum, identificativo_sdi,
			descrizione,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
			statodeldebito,-- stato del debito
			causale ,
			idexpimpegno,
			cigcode ,
			cupcode ,
			ipa 
			)
	
		select 
			case when (select count(*) from invoicedetail ID2 where I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv)=1 then 'CO'
			else 'COF' end,
			I.idinvkind, I.yinv, I.ninv,ID.rownum, I.identificativo_sdi,
			substring(I.description, 1,100),
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			I.adate,
			--> Importodelmovimento 
			case	
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S' then ID.taxable_euro
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='N' then ID.rowtotal
					when isnull(I.flag_enable_split_payment,'N') = 'S' then isnull(ID.taxable_euro,0)
			end,
			case	when ID.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then ID.expensekind
					else 'NA'
			end, -- natura di spesa
			ID.idpccdebitstatus,-- stato del debito
			ID.idpccdebitmotive, -- causale
			null,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else ID.cigcode -- CIG
			end,
			case	when ID.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else ID.cupcode 
			end,
			I.ipa_acq
		from invoicedetailview ID
		join #invoicew I				on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where I.docdate between @1luglio2014 and @adate 
			and NOT exists (select * from #dati D where D.idinvkind = ID.idinvkind and D.yinv = ID.yinv and D.ninv = ID.ninv and D.invrownum = ID.rownum and D.opkind in ('CO','COF'))
			and (exists (select * from pccsend P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				OR 
				I.idsdi_acquisto is not null -- Le FE non sono presenti in pccsend, perchè è il SdI che le invia alla PCC e non più noi.
				OR 
				I.idsdi_acquistoestere is not null -- Prendiamo anche le FE di acquisto estere
				)
			and (
				-- se non esiste
				(
				not exists(select * from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum is null)
				AND
				not exists(select * from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
				)
				OR
				-- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
				ID.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv and P.invrownum = ID.rownum
										order by idpcc desc)
			)
			-- task 7247 se pccexpense non esiste un suo fratello trasmesso	con l'operazione di CO.
			and not exists(select * from pccexpense P
								join invoicedetail ID2
									on P.idinvkind = ID2.idinvkind and P.yinv = ID2.yinv and P.ninv = ID2.ninv and P.invrownum  = ID2.rownum
								where ID2.idinvkind = ID.idinvkind and ID2.yinv = ID.yinv and ID2.ninv = ID.ninv and ID2.idgroup  = ID.idgroup and ID2.rownum  <> ID.rownum)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			AND isnull(ID.rowtotal,0) <> 0  --non inserire righe di importo 0, task 6213
			AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(ID.flagbit,0) & 4) = 0
			AND (isnull(ID.taxable,0) <> 0  )-- le righe con imponibile a 0 vengono rifiutate
			--Dobbiamo inglobare anche le FE di acqsuito estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P where P.idinvkind = ID.idinvkind and P.yinv = ID.yinv and P.ninv = ID.ninv )
			-- non ci sono dettagli che restano negativi dopo l'aggregazione, altrimenti scarta tutta la fattura
			AND (
				(select count(*) from invoiceresidualmandate IR
							where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) = 0 		
					or
					(	I.flagvariation='S' -- il problema dei dettagli negativi non deve valere per le NC, se i looro dettagli si compensando e non danno un importo negativo
						and 
						(select sum(IR.taxabletotal + IR.ivatotal) from invoiceresidualmandate IR
									where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv )>=0
						)
			)
			AND isnull(I.taxable,0) >0 -- Solo fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')



-- Contabilizzazione COTRATTI PASSIVI non collegabili a Fattura
		INSERT INTO #dati(
			opkind,
			idmankind, yman, nman,manrownum, 
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
			statodeldebito,
			causale ,
			idexpimpegno ,
			cigcode,
			cupcode 
			)
		select 
			case when (select count(*) from mandatedetail MD2 where M.idmankind = MD2.idmankind and M.yman = MD2.yman and M.nman = MD2.nman)=1 then 'CO'
			else 'COF' end,
			M.idmankind, M.yman, M.nman, MD.rownum, 
			M.idreg	,
			M.docdate , -- dataemissione
			substring(M.doc,1,20),		-- numerodocumento
			M.total ,	-- ImportoTotaleDocumento
			M.adate,
			--> ImportodelMovimento
			case	when (MD.idexp_iva = MD.idexp_taxable) then isnull(MD.iva_euro,0) + isnull(MD.taxable_euro,0)
					when (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'')) then isnull(MD.iva_euro,0)
					when (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'')) then isnull(MD.taxable_euro,0)
					when (MD.idexp_iva is null and MD.idexp_taxable is null) then isnull(MD.iva_euro,0) + isnull(MD.taxable_euro,0) --> se non è contabilizzato prende il totale riga
			end,
			case	when MD.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then MD.expensekind
					else 'NA'
			end, -- natura di spesa

			MD.idpccdebitstatus,
			MD.idpccdebitmotive, -- causale
			case	when (MD.idexp_iva = MD.idexp_taxable) then MD.idexp_iva
					when (MD.idexp_iva IS NOT NULL and  MD.idexp_iva <> isnull(MD.idexp_taxable,'') ) then MD.idexp_iva
					when (MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'') ) then MD.idexp_taxable
			end,
			case	when MD.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else ISNULL(MD.cigcode, M.cigcode) -- CIG
			end,
			case	when MD.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else MD.cupcode  
			end
		from mandateview M
		join mandatekind MK				on M.idmankind = MK.idmankind
		join mandatedetailview MD		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
		join registry R on isnull(M.idreg,MD.idreg) = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where M.docdate between @1luglio2014 and @adate 
				and MK.linktoinvoice = 'N'
				and exists (select * from pccsend  P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman )
				and (
					-- se non esiste
				(
				not exists(select * from pccexpense P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman and P.manrownum is null)
				AND
				not exists(select * from pccexpense P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman and P.manrownum = MD.rownum)
				)
				or
				-- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
				MD.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman and P.manrownum = MD.rownum
											order by idpcc desc)
				)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman )
				AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
				AND isnull(MD.rowtotal,0) <> 0  --non inserire righe di importo 0, task 6213
			    and RR.coderesidence='I' 
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P  where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman )
			-- task 7247 se pccexpense non esiste un suo fratello trasmesso	con l'operazione di CO.
			and not exists(select * from pccexpense P
								join mandatedetail MD2
									on P.idmankind = MD2.idmankind and P.yman = MD2.yman and P.nman = MD2.nman and P.manrownum  = MD2.rownum
								where MD2.idmankind = MD.idmankind and MD2.yman = MD.yman and MD2.nman = MD.nman and MD2.idgroup  = MD.idgroup and MD2.rownum  <> MD.rownum)

		-- Contabilizzazioni di OCCASIONALI contabilizzati
		insert into #dati(
			opkind,
			ycon, 
			ncon,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
		--	idfin_co,
			statodeldebito,
			causale ,
			descrizione,
			idexpimpegno ,
			cigcode ,
			cupcode 
			)
		select 'CO',
			C.ycon, C.ncon, 
			C.idreg	,
			C.adate , -- dataemissione
			convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
			C.feegross ,	-- ImportoTotaleDocumento
			C.adate,
			case	when C.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then C.expensekind
					else 'NA'
			end, -- natura di spesa
			E.curramount,
			--E.idfin,
			C.idpccdebitstatus,-- Stato del debito
			C.idpccdebitmotive, -- causale
			substring(E.description,1,100),
			E.idexp,
			case	when C.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cigcode, C.cigcode) -- CIG
			end,
			case	when C.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else isnull(E.cupcode, C.cupcode)  
			end
		from casualcontract C 
		join expensecasualcontract ECC			on C.ycon = ECC.ycon and C.ncon = ECC.ncon
		join expenseview E			on E.idexp = ECC.idexp
		join registry R on C.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where C.adate between @1luglio2014 and @adate 
			and exists (select * from pccsend P where P.ycon = C.ycon and P.ncon = C.ncon)
			and (
				-- se non esiste
				not exists(select * from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon)
				or
				-- oppure esiste ma lo stato è diverso da quello della ultima trasmissione del dettaglio in oggetto
				C.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon
										order by idpcc desc)
			)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.ycon = C.ycon and P.ncon = C.ncon )			
			AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
			AND isnull(E.curramount,0) <> 0  --non inserire righe di importo 0, task 6213
			and RR.coderesidence='I'
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P  where  P.ycon = C.ycon and P.ncon = C.ncon )

		-- Contabilizzazioni di OCCASIONALI NON CONTABILIZZATI
		insert into #dati(
			opkind,
			ycon, ncon,
			descrizione,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- CONTABILIZZAZIONE
			datacontabiledocumento,
			importodelmovimento ,
			naturadispesa,
			statodeldebito,
			causale ,
			idexpimpegno ,
			cigcode ,
			cupcode 
			)
		select 'CO',
			C.ycon, C.ncon, 
			substring(C.description, 1,100),
			C.idreg	,
			C.adate , -- dataemissione
			convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
			C.feegross ,	-- ImportoTotaleDocumento
			C.adate,
			C.feegross ,	--> ImportodelMovimento
			case	when C.idpccdebitstatus in ('LIQ','LIQdaSOSP', 'LIQdaNL', 'SOSPdaLIQ','NLdaLIQ') then C.expensekind
					else 'NA'
			end, -- natura di spesa
			C.idpccdebitstatus, -- statodeldebito
			C.idpccdebitmotive, -- causale
			null,
			case	when C.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else C.cigcode -- CIG
			end,
			case	when C.idpccdebitstatus in ('SOSP','NOLIQ') then 'NA'
					else C.cupcode  
			end
		from casualcontract C 
		join registry R on C.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where C.adate between @1luglio2014 and @adate 
			and NOT exists (select * from #dati D where D.ycon = C.ycon and D.ncon = C.ncon and D.opkind='CO')
			and exists (select * from pccsend P where P.ycon = C.ycon and P.ncon = C.ncon)
			and (
				-- se non esiste
				not exists(select * from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon)
				or
				C.idpccdebitstatus <>(select top 1 expensetaxkind from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon
										order by idpcc desc)
			)
			-- non è stata trasmessa la scadenza
			--and not exists (select * from pccexpiring P where P.ycon = C.ycon and P.ncon = C.ncon )	
			AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
			AND isnull(C.feegross,0) <> 0  --non inserire righe di importo 0, task 6213
			and RR.coderesidence='I'
			-- non è stata trasmesso alcun pagamento, task 7277 
			AND not exists (select * from pccpayment P  where  P.ycon = C.ycon and P.ncon = C.ncon )

END -- Fine inserimento CO

if (@cs = 'S')
Begin
		INSERT INTO #dati(
			opkind,
			idinvkind, yinv, ninv,invrownum,identificativo_sdi,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
			importoscadenza,
			datascadenza,
			ipa
			)
		select 
			'CS',
			I.idinvkind, I.yinv, I.ninv,ID.rownum,ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idreg,	
			I.docdate ,				-- dataemissione
			substring(I.doc,1,20),	-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			case	when isnull(I.flag_enable_split_payment,'N') = 'N' then ID.rowtotal
					when isnull(I.flag_enable_split_payment,'N') = 'S' then ID.taxable_euro
			End,
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
			end,
			I.ipa_acq
		from invoiceview I
		join invoicedetailview ID
			on I.yinv = ID.yinv and I.ninv = ID.ninv and I.idinvkind = ID.idinvkind
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		where I.docdate between @1luglio2014 and @adate 
			and exists (select * from pccexpense P 
									where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
			--and not exists (select * from pccexpiring P 
			--						where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
		-- se non esiste
			AND 
			(
			not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv and P.invrownum is null)
			AND
			not exists(select * from pccexpiring P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = ID.ninv and P.invrownum  = ID.rownum)
			)
			and ID.idpccdebitstatus not in ('NOLIQ','NLdaLIQ','NLdaSOSP')
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
			--Dobbiamo inglobare anche le FE di acqsuito estere
			and (RR.coderesidence='I' or RR.coderesidence<>'I' and I.idsdi_acquistoestere is not null)
				-- Qualora sia già stato eseguito il pagamento tramite opi, non dovranno essere trasmesse operazioni di contabilizzazione e scadenza,
				-- Questo però non vale per gli enti che usando ancora OIL, essi dovranno continuare a inviare il pagamento.
				-- Dobbiamo inglobare anche le FE di acquisto estere ma per esse non sarà inviato il pagamento CP, per cui evitiamo di controllare che vi sia.
				and (not exists (select T.idexp from expenselast T			 
								where T.idexp = ID.idexp_taxable OR T.idexp = ID.idexp_iva )
							or  I.idsdi_acquistoestere is not null
							or @OPIattivo='N')



		
		-- inserisce i contratti passivi
		INSERT INTO #dati(
			opkind,
			idmankind, yman, nman,manrownum,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
			importoscadenza,
			datascadenza
			)
		select 
			'CS',
			M.idmankind, M.yman, M.nman, MD.rownum,
			M.idreg,	
			M.docdate , -- dataemissione
			substring(M.doc,1,20),		-- numerodocumento
			M.total ,	-- ImportoTotaleDocumento
			M.total ,	-- ImportoTotaleDocumento
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
			end
		from mandateview M
		join mandatedetailview MD				ON M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
		where M.docdate between @1luglio2014 and @adate 
			and exists (select * from pccexpense P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
			--and not exists (select * from pccexpiring P 
			--						where P.idmankind= M.idmankind and P.yman = M.yman and P.nman = M.nman)
			AND 
			(
			not exists(select * from pccexpiring P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman and P.manrownum is null)
			AND
			not exists(select * from pccexpiring P where P.idmankind = MD.idmankind and P.yman = MD.yman and P.nman = MD.nman and P.manrownum  = MD.rownum)
			)
			and MD.idpccdebitstatus  not in ('NOLIQ','NLdaLIQ','NLdaSOSP')

			and not exists (select * from pccpayment P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
			AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)

		-- inserisce i contratti occasionali

		INSERT INTO #dati(
			opkind,
			ycon, ncon,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
			importoscadenza,
			datascadenza
			)
		select 
			'CS',
			C.ycon, C.ncon,
			C.idreg,	
			C.adate , -- dataemissione
			convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
			C.feegross ,	-- ImportoTotaleDocumento
			C.feegross ,	-- Importoscadenza
			C.expiration
		from casualcontract C
		where C.adate between @1luglio2014 and @adate 
		and exists (select * from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon)
		and not exists (select * from pccexpiring P where P.ycon = C.ycon and P.ncon = C.ncon)
		and not exists (select * from pccpayment P where P.ycon = C.ycon and P.ncon = C.ncon)
		AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
		and C.idpccdebitstatus not in ('NOLIQ','NLdaLIQ','NLdaSOSP')
		/* Vedi task n.6098
		CS va comunicato massimo entro il 15 del mese successivo alla data scadenza fattura, e cioè:
		se data scadenza è 10 novembre, la CS va comunicata entro il 15 dicembre
		quindi se data attuale >15 dicembre, fa la DELETE
		perchè non possiamo più comunicare la CS, i termini sono stati superati, e se CS fosse trasmesso il sistema darebbe errore.
		*/

		delete from #dati 
		where opkind='CS' and  datascadenza is not null and getdate() > DATEADD(day,   15 -datepart(day, DATEADD (month , 1 , datascadenza))   ,DATEADD (month , 1 , datascadenza))

END -- Fine inserimento CS

if (@cp='S')
Begin
		-- Contabilizzazioni CONTRATTI PASSIVI non collegabili a Fattura
		insert into #contabilizzazioni  (idmankind, yman, nman, manrownum,  idexp, amount, cigcode, cupcode, expensekind)  
			select 
				MD.idmankind, MD.yman, MD.nman, MD.rownum,
				MD.idexp_iva, 
				isnull(MD.taxable_euro,0) + isnull(MD.iva_euro,0),
				MD.cigcode, MD.cupcode,
				MD.expensekind
			from mandate M
			join mandatedetailview MD 		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
			join mandatekind MK				on MK.idmankind = MD.idmankind
			join registry R on isnull(M.idreg,MD.idreg) = R.idreg
			join residence RR  on R.residence=RR.idresidence
			where M.docdate between @1luglio2014 and @adate 
				and MD.idexp_iva = MD.idexp_taxable
				and MK.linktoinvoice = 'N'
				and (
					exists(select * from pccexpense P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
					or
					exists(select * from #dati D where D.opkind IN ('CO','COF') and D.idmankind = M.idmankind and D.yman = M.yman and D.nman = M.nman)
					)
				and not exists(select * from pccpayment P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
				AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
					and RR.coderesidence='I'

		insert into #contabilizzazioni  (idmankind, yman, nman, manrownum,  idexp, amount, cigcode, cupcode, expensekind) 
			select 
				MD.idmankind, MD.yman, MD.nman, MD.rownum,
				MD.idexp_iva, 
				isnull(MD.iva_euro,0),
				MD.cigcode, MD.cupcode,
				MD.expensekind
			from mandate M
			join mandatedetailview MD on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
			join mandatekind MK	on MK.idmankind = M.idmankind
			join registry R on isnull(M.idreg,MD.idreg) = R.idreg
			join residence RR  on R.residence=RR.idresidence
			where MD.idexp_iva is not null and  MD.idexp_iva <> isnull(MD.idexp_taxable,'')
				and M.docdate between @1luglio2014 and @adate 
				and MK.linktoinvoice = 'N'
				and (
					exists(select * from pccexpense P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
					or
					exists(select * from #dati D where D.opkind IN ('CO','COF')and D.idmankind = M.idmankind and D.yman = M.yman and D.nman = M.nman)
					)
				and not exists(select * from pccpayment P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
				AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
				and RR.coderesidence='I'

		insert into #contabilizzazioni  (idmankind, yman, nman,  manrownum,  idexp, amount, cigcode, cupcode, expensekind)  
			select 
				MD.idmankind, MD.yman, MD.nman, MD.rownum, 
				MD.idexp_taxable, 
				isnull(MD.taxable_euro,0),
				MD.cigcode, MD.cupcode,
				MD.expensekind
			from mandate M
			join mandatedetailview MD 		on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
			join mandatekind MK 			on MK.idmankind = M.idmankind
			join registry R on isnull(M.idreg,MD.idreg) = R.idreg
			join residence RR  on R.residence=RR.idresidence
			where MD.idexp_taxable is not null  and  MD.idexp_taxable <> isnull(MD.idexp_iva,'')
				AND M.docdate between @1luglio2014 and @adate 
				and MK.linktoinvoice = 'N'
				and (
					exists(select * from pccexpense P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
					or
					exists(select * from #dati D where D.opkind IN ('CO','COF') and D.idmankind = M.idmankind and D.yman = M.yman and D.nman = M.nman)
					)
				and not exists(select * from pccpayment P where P.idmankind = M.idmankind and P.yman = M.yman and P.nman = M.nman)
				AND (@idsor01 IS NULL OR M.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR M.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR M.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR M.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR M.idsor05 = @idsor05)
				and RR.coderesidence='I'

		--- Inseriamo i PAGAMENTI di CONTRATTI PASSIVI non Collegabili a Fattura 
		INSERT INTO #dati(
			opkind,
			idmankind,  
			yman, 
			nman,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			idexpimpegno,
			kpay,
			cigcode,
			cupcode,
			idexppagamento
			)

		select 'CP',
			M.idmankind, M.yman, M.nman,
			M.idreg	,
			M.docdate , -- dataemissione
			substring(M.doc,1,20),		-- numerodocumento
			M.total ,	-- ImportoTotaleDocumento
			sum(E.curramount),
			MD.expensekind, -- natura di spesa
			Expfinphase.idexp,
			Elast.kpay,
			isnull(Expfinphase.cigcode, MD.cigcode), 
			isnull(Expfinphase.cupcode, MD.cupcode),
			Elast.idexp  
		from mandateview M
		join #contabilizzazioni MD
				on M.idmankind = MD.idmankind and M.yman = MD.yman and M.nman = MD.nman
		JOIN expense Expfinphase
				on MD.idexp = Expfinphase.idexp
		JOIN expenselink
			ON expenselink.idparent = Expfinphase.idexp
		JOIN expenselast Elast
			on expenselink.idchild = Elast.idexp 
		join expenseview E
			on Elast.idexp = E.idexp
		where M.docdate between @1luglio2014 and @adate 
			and E.transmissiondate <= @adate AND (E.transmissiondate <= @31dic2018 OR @OPIattivo='N')
		group by M.idmankind, M.yman, M.nman,
			M.idreg,M.docdate,substring(M.doc,1,20),M.total,
			Expfinphase.idexp,Elast.kpay,Elast.idexp ,isnull(Expfinphase.cigcode, MD.cigcode), isnull(Expfinphase.cupcode, MD.cupcode),MD.expensekind

		-- PAGAMENTO OCCASIONALI
		insert into #dati(
			opkind,
			ycon, 
			ncon,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			idexpimpegno,
			kpay,
			cigcode,
			cupcode,
			idexppagamento
			)
		select 'CP',
			C.ycon, C.ncon,
			C.idreg	,
			C.adate , -- dataemissione
			convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
			C.feegross ,	-- ImportoTotaleDocumento
			E.curramount,-- importo pagato
			C.expensekind, -- natura di spesa
			ECC.idexp, -- idexp impegno 
			Elast.kpay,
			isnull(Expfinphase.cigcode, C.cigcode), 
			isnull(Expfinphase.cupcode, C.cupcode),
			Elast.idexp
		from casualcontract C 
		join expensecasualcontract ECC			on C.ycon = ECC.ycon and C.ncon = ECC.ncon
		JOIN expense Expfinphase				on ECC.idexp = Expfinphase.idexp
		JOIN expenselink						ON expenselink.idparent = ECC.idexp
		JOIN expenselast Elast					on expenselink.idchild = Elast.idexp 
		join expenseview E					on Elast.idexp = E.idexp
		join registry R on C.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where C.adate between @1luglio2014 and @adate 
			--and Elast.kpay is not null
			and E.transmissiondate <= @adate AND (E.transmissiondate <= @31dic2018 OR @OPIattivo='N')
			and (exists (select * from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon)
				or
				exists (select * from #dati D where D.opkind IN ('CO','COF') and D.ycon = C.ycon and D.ncon = C.ncon)
			)
			and not exists(select * from pccpayment P where P.ycon = C.ycon and P.ncon = C.ncon)
			AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
			and RR.coderesidence='I'

	-- Pagamento Contratti Occasionali con FONDO ECONOMALE

		INSERT INTO #dati(
			opkind,
			ycon, ncon,
			idpettycash, yoperation, noperation,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
			descrizione,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			piccolaspesa,
			cigcode,
			cupcode,
			idfin,
			idupb,
			paymentdate
			)
		select 'CP',
			C.ycon, C.ncon,
			PO.idpettycash, PO.yoperation, PO.noperation,
			C.idreg	,
			C.adate , -- dataemissione
			convert(varchar(4),C.ycon)+'/'+convert(varchar(10),C.ncon),		-- numerodocumento
			C.feegross ,	-- ImportoTotaleDocumento
			substring(PO.description,1,100),
			C.feegross ,	-- Importopagato
			C.expensekind, -- natura di spesa
			substring(
				'F.E.:' + PK.pettycode + ' Op.' + convert(varchar(10), P.noperation) + '/' + convert(varchar(4), P.yoperation),		--	piccolaspesa
				1,50), --massimo 100 caratteri
			C.cigcode,
			C.cupcode,
			PO.idfin,
			PO.idupb,
			PO.adate
		from casualcontract C
		join pettycashoperationcasualcontract P 				on C.ycon = P.ycon and C.ncon = P.ncon
		join pettycash PK			on PK.idpettycash = P.idpettycash
		join pettycashoperation PO		on PO.idpettycash = P.idpettycash and PO.noperation = P.noperation and PO.yoperation = P.yoperation
		join registry R on C.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where C.adate between @1luglio2014 and @adate 
			and PO.adate <= @adate AND (PO.adate <= @31dic2018 OR @OPIattivo='N')
			and (
				exists (select * from pccexpense P where P.ycon = C.ycon and P.ncon = C.ncon)
				or
				exists (select * from #dati D where D.opkind IN ('CO','COF') and D.ycon = C.ycon and D.ncon = C.ncon)
				)
			and not exists(select * from pccpayment P where P.ycon = C.ycon and P.ncon = C.ncon)
			AND (@idsor01 IS NULL OR C.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR C.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR C.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR C.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR C.idsor05 = @idsor05)
			and RR.coderesidence='I'

		delete from #contabilizzazioni

		-- PAGAMENTO fatture con o senza C.P. 
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode, expensekind,ipa)
		select 
				I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_iva, -- pagamento
				case when isnull(IV.flag_reverse_charge,'N')='S' then sum(  
						isnull(CONVERT(decimal(19,2),ROUND(I.taxable * ISNULL(I.npackage,I.number) * 
								CONVERT(DECIMAL(19,10),IV.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(I.discount, 0.0)))
										,2
								)),0)
						 )
						else sum(
							isnull(CONVERT(decimal(19,2),ROUND(I.taxable * ISNULL(I.npackage,I.number) * 
								CONVERT(DECIMAL(19,10),IV.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(I.discount, 0.0)))
										,2
								)),0)
							 + 
							isnull(CONVERT(decimal(19,2),ROUND(I.tax,2)),0)
						)
				end,
				I.cigcode, I.cupcode,
				I.expensekind,
				IV.ipa_acq
			from invoice IV (nolock)
			join invoicekind IK on iv.idinvkind=ik.idinvkind
			join invoicedetail I 	(nolock)	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R (nolock)				on IV.idreg = R.idreg
			join residence RR  (nolock)				on R.residence=RR.idresidence
			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_iva = I.idexp_taxable
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (
					exists (select * from pccexpense P (nolock) where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
					or
					exists (select * from #dati D where D.opkind  IN ('CO','COF') and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
					-- ci sono dettagli che restano negativi dopo l'aggregazione, per cui la fattura non verrà trasmessa in termini di CO ma direttamente CP
					OR (select count(*) from invoiceresidualmandate IR
								where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) > 0 
					-- Sono fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
					OR (select count(*) from invoiceview I2
								where I.idinvkind = I2.idinvkind and I.yinv = I2.yinv and I.ninv = I2.ninv 
									and isnull(I.taxable,0) = 0 and isnull(I.tax,0) >0)  > 0 
					)
				and not exists(select * from pccpayment P (nolock) where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				--and (isnull(I.flagbit,0) & 4) = 0
				AND (@idsor01 IS NULL OR isnull(iv.idsor01,ik.idsor01) = @idsor01)
				AND (@idsor02 IS NULL OR isnull(iv.idsor02,ik.idsor02) = @idsor02)
				AND (@idsor03 IS NULL OR isnull(iv.idsor03,ik.idsor03) = @idsor03)
				AND (@idsor04 IS NULL OR isnull(iv.idsor04,ik.idsor04) = @idsor04)
				AND (@idsor05 IS NULL OR isnull(iv.idsor05,ik.idsor05) = @idsor05)
				and RR.coderesidence='I'
			group by I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),I.idexp_iva,I.cigcode, I.cupcode, I.expensekind,IV.ipa_acq, IV.flag_reverse_charge

		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode, expensekind, ipa)
			select 
				I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_iva, -- pagamento
				case when isnull(IV.flag_reverse_charge,'N')='S' then 0	else sum(iva_euro)end,
				I.cigcode, I.cupcode,
				I.expensekind,
				IV.ipa_acq
			from invoice IV
			join invoicedetailview I
				on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R on IV.idreg = R.idreg
			join residence RR  on R.residence=RR.idresidence
			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_iva is not null and  I.idexp_iva <> isnull(I.idexp_taxable,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (
					exists (select * from pccexpense P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
					or
					exists (select * from #dati D where D.opkind  IN ('CO','COF') and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
					-- ci sono dettagli che restano negativi dopo l'aggregazione, per cui la fattura non verrà trasmessa in termini di CO ma direttamente CP
					OR (select count(*) from invoiceresidualmandate IR
								where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) > 0 
					-- Sono fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
					OR (select count(*) from invoiceview I2
								where I.idinvkind = I2.idinvkind and I.yinv = I2.yinv and I.ninv = I2.ninv 
									and isnull(I.taxable,0) = 0 and isnull(I.tax,0) >0)  > 0 
					)
				and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)		
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
				--and (isnull(I.flagbit,0) & 4) = 0
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_iva,I.cigcode, I.cupcode,I.expensekind,IV.ipa_acq, IV.flag_reverse_charge

		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode,expensekind, ipa)
			select 
				I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_taxable, -- pagamento
				sum(I.taxable_euro),
				I.cigcode, I.cupcode, I.expensekind,
				IV.ipa_acq
			from invoice IV
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R on IV.idreg = R.idreg
			join residence RR  on R.residence=RR.idresidence
			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_taxable is not null  and  I.idexp_taxable <> isnull(I.idexp_iva,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (
					exists (select * from pccexpense P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
					or
					exists (select * from #dati D where D.opkind  IN ('CO','COF') and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
					-- ci sono dettagli che restano negativi dopo l'aggregazione, per cui la fattura non verrà trasmessa in termini di CO ma direttamente CP
					OR (select count(*) from invoiceresidualmandate IR
								where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) > 0 
					-- Sono fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
					OR (select count(*) from invoiceview I2
								where I.idinvkind = I2.idinvkind and I.yinv = I2.yinv and I.ninv = I2.ninv 
									and isnull(I.taxable,0) = 0 and isnull(I.tax,0) >0)  > 0 
					)
				and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)		
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
			AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				--and (isnull(I.flagbit,0) & 4) = 0
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by I.idinvkind, I.yinv, I.ninv,ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_taxable, I.cigcode, I.cupcode, I.expensekind, IV.ipa_acq
			
						
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode,expensekind, ipa)
			select 
				I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_taxable, -- pagamento
				sum(I.taxable_euro),
				I.cigcode, I.cupcode, I.expensekind,
				IV.ipa_acq
			from invoice IV
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R on IV.idreg = R.idreg
			join residence RR  on R.residence=RR.idresidence
			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_taxable is not null  
				and isnull(IV.flag_enable_split_payment,'N') = 'S'
				and IV.docdate between @1luglio2014 and @adate 
				and (
					exists (select * from pccexpense P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
					or
					exists (select * from #dati D where D.opkind  IN ('CO','COF') and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
					-- ci sono dettagli che restano negativi dopo l'aggregazione, per cui la fattura non verrà trasmessa in termini di CO ma direttamente CP
					OR (select count(*) from invoiceresidualmandate IR
								where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) > 0 
					-- Sono fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
					OR (select count(*) from invoiceview I2
								where I.idinvkind = I2.idinvkind and I.yinv = I2.yinv and I.ninv = I2.ninv 
									and isnull(I.taxable,0) = 0 and isnull(I.tax,0) >0)  > 0 
					)
				and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)		
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322						
				--and (isnull(I.flagbit,0) & 4) = 0
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by I.idinvkind, I.yinv, I.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_taxable, I.cigcode, I.cupcode, I.expensekind, IV.ipa_acq

		INSERT INTO #dati(
			opkind,
			idinvkind, yinv, ninv,identificativo_sdi,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			idexpimpegno,
			kpay,
			cigcode,
			cupcode,
			ipa,
			idexppagamento
		)
		select 'CP',
			I.idinvkind, I.yinv, I.ninv,I.identificativo_sdi,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then (I.taxable-I.rounding) else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			sum(ID.amount),
			ID.expensekind, -- natura di spesa
			Expfinphase.idexp,
			Elast.kpay,
			isnull(Expfinphase.cigcode, ID.cigcode), 
			isnull(Expfinphase.cupcode, ID.cupcode) ,
			ID.ipa,
			Elast.idexp 
		from #invoicew I 
		join #contabilizzazioni ID 			on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join expense E1			on E1.idexp = ID.idexp
		JOIN expenselink			ON expenselink.idchild = E1.idexp
		JOIN expense Expfinphase		on expenselink.idparent = Expfinphase.idexp and Expfinphase.nphase = @finphase
		join expenselast Elast			on E1.idexp = Elast.idexp
		JOIN payment P			ON P.kpay = Elast.kpay
		JOIN paymenttransmission T			ON T.kpaymenttransmission = P.kpaymenttransmission
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where I.docdate between @1luglio2014 and @adate 
			--and Elast.kpay is not null
			and T.transmissiondate <= @adate AND (T.transmissiondate <=@31dic2018  OR @OPIattivo='N')
			and RR.coderesidence='I'
		group by I.idinvkind, I.yinv, I.ninv, I.identificativo_sdi,I.idreg	,
			I.docdate , substring(I.doc,1,20),	I.total-I.rounding ,	I.taxable-I.rounding,I.flag_reverse_charge,
			Expfinphase.idexp,Elast.kpay,Elast.idexp ,
			isnull(Expfinphase.cigcode, ID.cigcode), isnull(Expfinphase.cupcode, ID.cupcode),ID.expensekind,ID.ipa

		delete from #contabilizzazioni

		-- PAGAMENTO FATTURE associate a Professionale
/*		INSERT INTO #dati(
			opkind,
			idinvkind,  
			yinv, 
			ninv,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			idexpimpegno,
			kpay,
			cigcode,
			cupcode,
			ipa,
			idexppagamento
			)
		select 'CP',
			I.idinvkind, I.yinv, I.ninv,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			I.total-I.rounding,--vedi task 7360 per il rounding
			E.curramount,-- importo pagato
			(select top 1 ID.expensekind from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv), -- natura di spesa,
			EPS.idexp, -- idexp impegno 
			Elast.kpay,
			isnull(Expfinphase.cigcode,(select top 1 ID.cigcode from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv)),
			isnull(Expfinphase.cupcode,(select top 1 ID.cupcode from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv)),
			I.ipa_acq,
			Elast.idexp
		from #invoicew I 
		join profservice P 				on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
		join expenseprofservice EPS			on EPS.ycon = P.ycon		and EPS.ncon = P.ncon
		JOIN expense Expfinphase			on EPS.idexp = Expfinphase.idexp
		JOIN expenselink			ON expenselink.idparent = EPS.idexp
		JOIN expenselast Elast		on expenselink.idchild = Elast.idexp 
		join expenseview E			on Elast.idexp = E.idexp
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		where I.docdate between @1luglio2014 and @adate 
			and (select count(*) from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv and ID.ycon is not null)=0-- I dettagli fattura non devono essere associati al Contratto Prof.
			and E.transmissiondate <= @adate AND E.transmissiondate <= @31dic2018
			and (
				exists (select * from pccexpense P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				or
				exists (select * from #dati D where D.opkind  IN ('CO','COF') and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
				)
			and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)			
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			and RR.coderesidence='I'
*/
--  Pagamenti di fatture con fondo Economale
		INSERT INTO #dati(
			opkind,
			idinvkind,  
			yinv, 
			ninv,
			identificativo_sdi,
			idpettycash, yoperation, noperation,
			idreg,	
			dataemissione,
			numerodocumento,
			importototaledocumento,
			descrizione,
		-- PAGAMENTO
			importopagato,
			naturadispesa,
			piccolaspesa,
			cigcode,
			cupcode,
			idfin,
			idupb,
			paymentdate,
			ipa
			)
		select 'CP',
			I.idinvkind, I.yinv, I.ninv,I.identificativo_sdi,
			PO.idpettycash,
			PO.yoperation,
			PO.noperation,
			I.idreg	,
			I.docdate , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then I.taxable-I.rounding else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			substring(PO.description,1,100),
			-- importo pagato
			case	-- esamina I.flag_reverse_charge='S'
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='S'then I.taxable-I.rounding
					when isnull(I.flag_enable_split_payment,'N') = 'S' and isnull(I.flag_reverse_charge,'N')='S'then I.taxable-I.rounding
					-- esamina I.flag_reverse_charge='N'
					when isnull(I.flag_enable_split_payment,'N') = 'N' and isnull(I.flag_reverse_charge,'N')='N' then I.total-I.rounding
					when isnull(I.flag_enable_split_payment,'N') = 'S' and isnull(I.flag_reverse_charge,'N')='N' then I.taxable-I.rounding
			End,
			(select top 1 ID.expensekind from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv),
			'F.E.:' + PK.pettycode + ' Op.' + convert(varchar(10), P.noperation) + '/' + convert(varchar(4), P.yoperation),		--	piccolaspesa
			(select top 1 ID.cigcode from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv),
			(select top 1 ID.cupcode from invoicedetail ID where ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv),
			PO.idfin,
			PO.idupb,
			PO.adate,
			I.ipa_acq 
		from #invoicew I 
		join pettycashoperationinvoice P		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
		join pettycash PK 						on PK.idpettycash = P.idpettycash
		join pettycashoperation PO		on PO.idpettycash = P.idpettycash and PO.noperation = P.noperation and PO.yoperation = P.yoperation
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence		
		where I.docdate between @1luglio2014 and @adate 
			and PO.adate <= @adate AND (PO.adate <=@31dic2018  OR @OPIattivo='N')
			and (
				exists (select * from pccexpense P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)
				or
				exists (select * from #dati D where D.opkind IN ('CO','COF')  and D.idinvkind = I.idinvkind and D.yinv = I.yinv and D.ninv = I.ninv)
					-- ci sono dettagli che restano negativi dopo l'aggregazione, per cui la fattura non verrà trasmessa in termini di CO ma direttamente CP
				OR (select count(*) from invoiceresidualmandate IR
						where I.idinvkind = IR.idinvkind and I.yinv = IR.yinv and I.ninv = IR.ninv and (IR.taxabletotal + IR.ivatotal) <0) > 0 
					-- Sono fatture con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0
				OR (isnull(I.taxable,0) = 0 and isnull(I.total, 0) =0)  
				)
			and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)			
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			and RR.coderesidence='I'
End		-- Fine inserimento CP

declare @cf varchar(11)
select @cf = cf from license
/*		cancella i dettagli negavitivi che aggretati non verrebbero compensati */
/* non lo fa sempre, altrimenti sarebbe troppo lenta, lo fa solo se ci delle righe negative	*/
			create table #raggruppoCO(
				idinvkind int,  yinv smallint, 	ninv int,
				identificativo_sdi bigint,
				idexpimpegno int,
				descrizione varchar(100),
				cigcode varchar(15),
				cupcode varchar(15),
				naturadispesa char(2),
				importodelmovimento decimal(19,2),
				statodeldebito varchar(9),
				causale varchar(20),
				idfin int
			)
if (select count(nriga) from #dati where opkind in ('CO','COF') and ISNULL(importodelmovimento,0) < 0 )>0
Begin

			insert into #raggruppoCO(
				idinvkind, 	yinv, 	ninv, identificativo_sdi,idexpimpegno,descrizione, naturadispesa,cigcode,cupcode,
				importodelmovimento, 				statodeldebito,	causale,idfin
				)
			select 
				D.idinvkind, D.yinv ,D.ninv, D.identificativo_sdi,E.idexp,	substring(E.description,1, 100) as descrizione,
				D.naturadispesa,		isnull(D.cigcode, ISNULL(E.cigcode,isnull(U.cigcode,'NA'))) as codicecig, 
				ISNULL(D.cupcode, ISNULL(E.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))) as codicecup,
				isnull(sum(D.importodelmovimento),0),  			D.statodeldebito,	D.causale, EY.idfin
			from #dati D
			join expense E		on D.idexpimpegno = E.idexp
			join expenseyear EY 	on E.idexp = EY.idexp 	and E.ymov = EY.ayear
			join finlast Flast	 	on EY.idfin = Flast.idfin
			join upb U				on EY.idupb = U.idupb
			where opkind in ('CO','COF') and ISNULL(D.importototaledocumento,0) <> 0
			group by D.idinvkind, D.yinv ,D.ninv, D.identificativo_sdi,
				E.idexp,	substring(E.description,1, 100),	D.naturadispesa,
				isnull(D.cigcode, ISNULL(E.cigcode,isnull(U.cigcode,'NA'))), 
				ISNULL(D.cupcode, ISNULL(E.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))),
				D.statodeldebito,	D.causale, EY.idfin
			UNION ALL
			select 
				D.idinvkind, D.yinv ,D.ninv,D.identificativo_sdi,  null,null, D.naturadispesa,	isnull(D.cigcode,'NA') as codicecig, 
				ISNULL(D.cupcode, 'NA') as codicecup,
				isnull(sum(D.importodelmovimento),0), 	D.statodeldebito,	D.causale,null
			from #dati D
			where opkind in('CO','COF') and D.idexpimpegno is null  and ISNULL(D.importototaledocumento,0) <> 0
			group by 	D.idinvkind, D.yinv ,D.ninv,D.identificativo_sdi,
				D.naturadispesa,	isnull(D.cigcode,'NA'), 	ISNULL(D.cupcode, 'NA'),
				D.statodeldebito,	D.causale

			DELETE #dati FROM #dati 
			join #raggruppoCO
				on #dati.idinvkind = #raggruppoCO.idinvkind and #dati.yinv = #raggruppoCO.yinv 	and #dati.ninv = #raggruppoCO.ninv
			where #raggruppoCO.importodelmovimento<0
END
--------------------------------------------------------------------------------

update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null AND ipa is null
update #dati set ipa = (select ipa_fe from mandatekind I where #dati.idmankind = I.idmankind) where idmankind is not null
update #dati set ipa = (select ipa_fe from casualcontract I where #dati.ycon = I.ycon and #dati.ncon = I.ncon) where ycon is not null

select 
	nriga,
	D.idinvkind, D.yinv ,D.ninv, D.invrownum, D.identificativo_sdi,
	IK.description as invoicekind,
	D.idmankind, D.yman, D.nman ,D.manrownum,
	MK.description as mandatekind,
	D.ycon, D.ncon,
	ltrim(rtrim(D.opkind)) as 'azione',
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	R.cf as 'CFfornitore',	
	case when D.idinvkind is not null then 
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
	as 'IdFiscaleIvaFornitore',
	R.title	as 'DenominazioneFornitore',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,

-- Dati Finanziario	
	F.idfin,
	F.codefin as 'bilancio',
	E.idexp,
	E.nmov as 'impegno',
	substring(E.description,1, 100) as descrizione,
	D.naturadispesa,
	isnull(D.cigcode, ISNULL(E.cigcode,isnull(U.cigcode,'NA'))) as codicecig, 
	ISNULL(D.cupcode, ISNULL(E.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))) as codicecup,

-- CONTABILIZZAZIONE
	D.importodelmovimento,
	D.datacontabiledocumento,
	D.statodeldebito,
	D.causale,
	-- PAGAMENTO
	null as kpay,
	null as idpettycash,
	null as yoperation,
	null as noperation,
	null as importopagato,
	null as npay,
	null as 'paymentdate',
	-- SCADENZA
	'SI' as 'comunicazionescadenza',
	D.importoscadenza as importoscadenza,	
	D.datascadenza as datascadenza 
from #dati D
join expense E		on D.idexpimpegno = E.idexp
join expenseyear EY 	on E.idexp = EY.idexp 	and E.ymov = EY.ayear
join finlast Flast	 	on EY.idfin = Flast.idfin
join fin F				on F.idfin = Flast.idfin
join upb U				on EY.idupb = U.idupb
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join invoicekind IK		on IK.idinvkind = D.idinvkind
left outer join mandatekind MK		on MK.idmankind = D.idmankind
where opkind in ('CO','COF') and ISNULL(D.importototaledocumento,0) <> 0

UNION ALL
-- Contabilizzazione di DOCUMENTI NON CONTABILIZZATI

select 
	nriga,
	D.idinvkind, D.yinv ,D.ninv, D.invrownum, D.identificativo_sdi,
	IK.description as invoicekind,
	D.idmankind, D.yman, D.nman ,D.manrownum,
	MK.description as mandatekind,
	D.ycon, D.ncon,
	ltrim(rtrim(D.opkind)) as 'azione',
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	R.cf as 'CFfornitore',	
		case when D.idinvkind is not null then 
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
	as 'IdFiscaleIvaFornitore',
	R.title	as 'DenominazioneFornitore',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,
-- Dati Finanziario	
	null as idfin,
	null as 'bilancio',
	null as idexp,
	null as 'impegno',
	substring(D.descrizione,1, 100) as descrizione,
	D.naturadispesa,
	isnull(D.cigcode,'NA') as codicecig, 
	ISNULL(D.cupcode, 'NA') as codicecup,
-- CONTABILIZZAZIONE
	D.importodelmovimento,
	D.datacontabiledocumento,
	D.statodeldebito,
	D.causale,
	-- PAGAMENTO
	null as kpay,
	null as idpettycash,
	null as yoperation,
	null as noperation,
	null as importopagato,
	null as  npay,
	null as   'paymentdate',
	-- SCADENZA
	'SI' as 'comunicazionescadenza',
	D.importoscadenza as importoscadenza,	
	D.datascadenza as datascadenza 
from #dati D
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join invoicekind IK		on IK.idinvkind = D.idinvkind
left outer join mandatekind MK		on MK.idmankind = D.idmankind
where opkind in('CO','COF') and D.idexpimpegno is null  and ISNULL(D.importototaledocumento,0) <> 0

UNION ALL

select 
	nriga,
	D.idinvkind, D.yinv ,D.ninv, D.invrownum, D.identificativo_sdi,
	IK.description as invoicekind,
	D.idmankind, D.yman, D.nman ,D.manrownum,
	MK.description as mandatekind,
	D.ycon, D.ncon,
	ltrim(rtrim(D.opkind)) as 'azione',
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	R.cf as 'CFfornitore',	
	case when D.idinvkind is not null then 
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
	as 'IdFiscaleIvaFornitore',
	R.title	as 'DenominazioneFornitore',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,

-- Dati Finanziario	
	F.idfin,
	F.codefin as 'bilancio',
	ExpImp.idexp,
	ExpImp.nmov as 'impegno',
	substring(ExpPag.description,1, 100) as descrizione,
	D.naturadispesa,
	isnull(D.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA'))) as codicecig, 
	ISNULL(D.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))) as codicecup,

-- CONTABILIZZAZIONE
	null as importodelmovimento,
	null as datacontabiledocumento,
	null as statodeldebito,
	null as causale,
	-- PAGAMENTO
	P.kpay,
	null as idpettycash,
	null as yoperation,
	null as noperation,
	importopagato,
	convert(varchar(20),P.npay) as npay,
	-- P.adate as   'paymentdate',
	PT.transmissiondate as 'paymentdate',
	-- SCADENZA
	'SI' as 'comunicazionescadenza',
	D.importoscadenza as importoscadenza,	
	D.datascadenza as datascadenza 
from #dati D
join expense ExpPag			on ExpPag.idexp = D.idexppagamento
join expenseyear EY			on ExpPag.idexp = EY.idexp 	and ExpPag.ymov = EY.ayear
join finlast Flast			on EY.idfin = Flast.idfin
join fin F					on F.idfin = Flast.idfin
join upb U					on EY.idupb = U.idupb
join payment P				on D.kpay = P.kpay
join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join expense ExpImp			on D.idexpimpegno = ExpImp.idexp
left outer join invoicekind IK		on IK.idinvkind = D.idinvkind
left outer join mandatekind MK		on MK.idmankind = D.idmankind
where opkind='CP' and piccolaspesa is null  and ISNULL(D.importototaledocumento,0) <> 0

UNION ALL
-- FATTURE PAGATE COL FONDO ECONOMALE
select 
	nriga,
	D.idinvkind, D.yinv ,D.ninv, D.invrownum, D.identificativo_sdi,
	IK.description as invoicekind,
	D.idmankind, D.yman, D.nman ,D.manrownum,
	MK.description as mandatekind,
	D.ycon, D.ncon,
	ltrim(rtrim(D.opkind)) as 'azione',
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	--IPA.agencyname as 'agencyname',
	R.cf as 'CFfornitore',	
		case when D.idinvkind is not null then 
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
	as 'IdFiscaleIvaFornitore',
	R.title	as 'DenominazioneFornitore',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,

-- Dati Finanziario	
	F.idfin,
	F.codefin as 'bilancio',
	null as idexp,
	null as 'impegno',
	substring(D.descrizione,1, 100) as descrizione,
	D.naturadispesa,
	isnull(D.cigcode,isnull(U.cigcode,'NA')) as codicecig,
	isnull(D.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))) as codicecup,

-- CONTABILIZZAZIONE
	null as importodelmovimento,
	null as datacontabiledocumento,
	null as statodeldebito,
	null as causale,
	-- PAGAMENTO
	null as kpay,
	D.idpettycash as idpettycash,
	D.yoperation as yoperation,
	D.noperation as noperation,
	D.importopagato,
	D.piccolaspesa as npay,
	D.paymentdate as   'paymentdate',

	-- SCADENZA
	'SI' as 'comunicazionescadenza',
	D.importoscadenza as importoscadenza,	
	D.datascadenza as datascadenza 
from #dati D
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join fin F		on D.idfin = F.idfin
left outer join finlast Flast			on D.idfin = Flast.idfin
left outer join upb U					on D.idupb = U.idupb
left outer join invoicekind IK			on IK.idinvkind = D.idinvkind
left outer join mandatekind MK			on MK.idmankind = D.idmankind
where opkind='CP' and piccolaspesa IS NOT NULL  and ISNULL(D.importototaledocumento,0) <> 0

UNION ALL
select 
	nriga,
	D.idinvkind, D.yinv ,D.ninv, D.invrownum, D.identificativo_sdi,
	IK.description as invoicekind,
	D.idmankind, D.yman, D.nman ,D.manrownum,
	MK.description as mandatekind,
	D.ycon, D.ncon,
	ltrim(rtrim(D.opkind)) as 'azione',
	@cf as 'CFAmmin',
	D.ipa as 'IPA',
	--IPA.agencyname as 'agencyname',
	R.cf as 'CFfornitore',	
		case when D.idinvkind is not null then 
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
	as 'IdFiscaleIvaFornitore',
	R.title	as 'DenominazioneFornitore',
	-- Dati identificativi Documento
	null as 'progressivoregistrazione',
	D.numerodocumento,
	D.dataemissione,
	D.importototaledocumento,
	
-- Dati Finanziario	
	null as idfin,
	null as 'bilancio',
	null as idexp,
	null as 'impegno',
	null as descrizione,
	null as naturadispesa,
	null as codicecig, 
	replicate ('0',15) as codicecup,

-- CONTABILIZZAZIONE
	null as importodelmovimento,
	null as datacontabiledocumento,
	null as statodeldebito,
	null as causale,
	-- PAGAMENTO
	null as kpay,
	null as idpettycash,
	null as yoperation,
	null as noperation,
	null as importopagato,
	null as npay,
	null as   'paymentdate',

	-- SCADENZA
	'SI' as 'comunicazionescadenza',
	D.importoscadenza as importoscadenza,	
	D.datascadenza as datascadenza 
from #dati D
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join invoicekind IK		on IK.idinvkind = D.idinvkind
left outer join mandatekind MK		on MK.idmankind = D.idmankind
where D.opkind='CS'  and ISNULL(D.importototaledocumento,0) <> 0
order by nriga,IK.description, D.ninv, D.yinv, MK.description, D.yman, D.nman, D.ycon, D.ncon, ltrim(rtrim(D.opkind))

drop table #raggruppoCO
drop table #dati
drop table #invoicew
end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


