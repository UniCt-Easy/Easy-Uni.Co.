
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_pccoperation_pagamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_pccoperation_pagamenti]
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
--	exec compute_pccoperation_pagamenti 2023, {d '2023-06-26'},null,null,null,null,null
CREATE procedure compute_pccoperation_pagamenti( 
	@ayearstart int = null, -- Esercizio a partire dal quale andranno considerati i pagamenti di fatture
	@adate datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
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
	amount decimal(19,2),
	idexp int,
	kpay int,
	cigcode varchar(15),
	cupcode varchar(15),
	expensekind varchar(2),
	ipa varchar(7),
	--doc varchar(35)
	ninvoice varchar(35), -- numero fattura FE, letto dal file e scritto in sdi_acquisto
	commerciale char(1) -- S/N

)

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
	commerciale char(1),
	idreg int,	
	ipa varchar(7),
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


		-- PAGAMENTO fatture CONTAB. TOTALE
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode, expensekind,ipa,
		 ninvoice,	commerciale,  kpay )
		select 
				IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_taxable, -- pagamento
				case when isnull(IV.flag_reverse_charge,'N')='S' then sum(  
						isnull(CONVERT(decimal(19,2),ROUND(I.taxable * ISNULL(I.npackage,I.number) * 
								CONVERT(DECIMAL(19,10),IV.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(I.discount, 0.0)))
										,2
								)),0)
						 ) - isnull((select sum(taxable_euro) from invoicedetailview NC	
										where NC.idexp_taxable = Elast.idexp
											and NC.idinvkind_main = IV.idinvkind and NC.yinv_main = IV.yinv and NC.ninv_main = IV.ninv 
											and isnull(NC.cigcode,'na') = isnull(I.cigcode,'na')
											and isnull(NC.cupcode,'na') = isnull(I.cupcode,'na') ),0)
						else sum(
							isnull(CONVERT(decimal(19,2),ROUND(I.taxable * ISNULL(I.npackage,I.number) * 
								CONVERT(DECIMAL(19,10),IV.exchangerate) *
									(1 - CONVERT(DECIMAL(19,6),ISNULL(I.discount, 0.0)))
										,2
								)),0)
							 + 
							isnull(CONVERT(decimal(19,2),ROUND(I.tax,2)),0)
						)
						- isnull((select sum(iva_euro)+ sum(taxable_euro) from invoicedetailview NC	
										where NC.idexp_taxable = Elast.idexp
											and NC.idinvkind_main = IV.idinvkind and NC.yinv_main = IV.yinv and NC.ninv_main = IV.ninv 
											and isnull(NC.cigcode,'na') = isnull(I.cigcode,'na')
											and isnull(NC.cupcode,'na') = isnull(I.cupcode,'na') ),0)
				end,
			isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA'))), 
			ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))),
			I.expensekind,
			IV.ipa_acq,
			-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when IV.idsdi_acquisto is not null then sdi.ninvoice
				when IV.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),IV.idinvkind ))) + convert(varchar(5),IV.idinvkind )+substring(IV.doc,1, 15))
				else IV.doc
			end,
			case when (IK.enable_fe='S' or IK.enable_fe_estera='S') THEN 'S' ELSE 'N' end,
			P.kpay
			from invoice IV (nolock)
			join invoicekind IK on iv.idinvkind=ik.idinvkind
			join invoicedetail I 	(nolock)	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R (nolock)				on IV.idreg = R.idreg
			join residence RR  (nolock)				on R.residence=RR.idresidence
			join expenselast Elast			on Elast.idexp = I.idexp_taxable		
			JOIN payment P			ON P.kpay = Elast.kpay
			JOIN paymenttransmission T			ON T.kpaymenttransmission = P.kpaymenttransmission
			-- queste join ci servono per leggere cig e cup da spesa/upb/fin
			join expenseyear EY			on Elast.idexp = EY.idexp 	and P.ypay = EY.ayear
			join finlast Flast			on EY.idfin = Flast.idfin
			join upb U					on EY.idupb = U.idupb
			join expense ExpPag			on I.idexp_taxable = ExpPag.idexp
			JOIN expenselink			ON expenselink.idchild = ExpPag.idexp
			JOIN expense ExpImp			on expenselink.idparent = ExpImp.idexp and ExpImp.nphase = @finphase

			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_iva = I.idexp_taxable		
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (@ayearstart is null OR  year(T.transmissiondate)>= @ayearstart )-- Se è stato impostato un filtro sull'esercizio, lo applica, diversamente mostra tutto.
				and T.transmissiondate <= @adate AND (T.transmissiondate <=@31dic2018  OR @OPIattivo='N')
				and exists (select * from banktransaction B (nolock) where B.idexp = I.idexp_taxable		) -- Prendiamo le fatture solo se c'è l'esitazione
				and not exists(select * from pccpayment PC (nolock) where PC.idinvkind = I.idinvkind and PC.yinv = I.yinv and PC.ninv = I.ninv
												and PC.kpay = P.kpay and PC.cigcode = isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')))
												and PC.cupcode = ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))))
												)
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				and (isnull(IK.flag,0) & 4) = 0 -- solo Fatt, no NC
				AND (@idsor01 IS NULL OR isnull(iv.idsor01,ik.idsor01) = @idsor01)
				AND (@idsor02 IS NULL OR isnull(iv.idsor02,ik.idsor02) = @idsor02)
				AND (@idsor03 IS NULL OR isnull(iv.idsor03,ik.idsor03) = @idsor03)
				AND (@idsor04 IS NULL OR isnull(iv.idsor04,ik.idsor04) = @idsor04)
				AND (@idsor05 IS NULL OR isnull(iv.idsor05,ik.idsor05) = @idsor05)
				and RR.coderesidence='I'
			group by IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),I.idexp_taxable,I.cigcode, I.cupcode, I.expensekind,IV.ipa_acq, IV.flag_reverse_charge,
				sdi.ninvoice, IV.idsdi_acquisto,IV.idsdi_acquistoestere, IV.doc, IK.enable_fe, IK.enable_fe_estera, P.kpay,Elast.idexp,
				 ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')), IV.doc,
				ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))


		-- PAGAMENTO fatture CONTAB. Solo IVA
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode, expensekind, ipa,
				 ninvoice,	commerciale,  kpay )
		select 
			IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_iva, -- pagamento		IVA IVA IVA
			case when isnull(IV.flag_reverse_charge,'N')='S' then 0	
						else sum(iva_euro) - isnull((select sum(iva_euro) from invoicedetailview NC	
										where NC.idexp_taxable = Elast.idexp
											and NC.idinvkind_main = IV.idinvkind and NC.yinv_main = IV.yinv and NC.ninv_main = IV.ninv 
											and isnull(NC.cigcode,'na') = isnull(I.cigcode,'na')
											and isnull(NC.cupcode,'na') = isnull(I.cupcode,'na') ),0)
						end,
			isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA'))), 
			ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))),
			I.expensekind,
			IV.ipa_acq,
			-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
		case
			when IV.idsdi_acquisto is not null then sdi.ninvoice
			when IV.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),IV.idinvkind ))) + convert(varchar(5),IV.idinvkind )+substring(IV.doc,1, 15))
			else IV.doc
		end,
		case when (ik.enable_fe='S' or ik.enable_fe_estera='S') THEN 'S' ELSE 'N' end,
		P.kpay
		from invoice IV
		join invoicekind IK on iv.idinvkind=ik.idinvkind
		join invoicedetailview I
			on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
		join registry R on IV.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence
		join expenselast Elast			on Elast.idexp = I.idexp_iva
		JOIN payment P			ON P.kpay = Elast.kpay
		JOIN paymenttransmission T			ON T.kpaymenttransmission = P.kpaymenttransmission
		-- queste join ci servono per leggere cig e cup da spesa/upb/fin
		join expenseyear EY			on Elast.idexp = EY.idexp 	and P.ypay = EY.ayear
		join finlast Flast			on EY.idfin = Flast.idfin
		join upb U					on EY.idupb = U.idupb
		join expense ExpPag			on I.idexp_taxable = ExpPag.idexp
		JOIN expenselink			ON expenselink.idchild = ExpPag.idexp
		JOIN expense ExpImp			on expenselink.idparent = ExpImp.idexp and ExpImp.nphase = @finphase

		left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		where I.idexp_iva is not null and  I.idexp_iva <> isnull(I.idexp_taxable,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (@ayearstart is null OR  year(T.transmissiondate)>= @ayearstart )-- Se è stato impostato un filtro sull'esercizio, lo applica, diversamente mostra tutto.
				and T.transmissiondate <= @adate AND (T.transmissiondate <=@31dic2018  OR @OPIattivo='N')
				and exists (select * from banktransaction B where B.idexp = I.idexp_iva	) -- Prendiamo le fatture solo se c'è l'esitazione

				and not exists(select * from pccpayment PC (nolock) where PC.idinvkind = I.idinvkind and PC.yinv = I.yinv and PC.ninv = I.ninv
												and PC.kpay = P.kpay and PC.cigcode = isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')))
												and PC.cupcode = ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))))
												)
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
				and (isnull(IK.flag,0) & 4) = 0 -- solo Fatt, no NC
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_iva,I.cigcode, I.cupcode,I.expensekind,IV.ipa_acq, IV.flag_reverse_charge,IV.doc,
			sdi.ninvoice, IV.idsdi_acquisto,IV.idsdi_acquistoestere, IV.doc, IK.enable_fe, IK.enable_fe_estera, P.kpay,Elast.idexp,
			ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')), 
				ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))

	-- PAGAMENTO fatture CONTAB. Solo IMPONIBILE - No Split
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode,expensekind, ipa,
			 ninvoice,	commerciale,  kpay )
			select 
				IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_taxable, -- pagamento IMPONIBILE	IMPONIBILE	IMPONIBILE	IMPONIBILE	
				sum(I.taxable_euro) - isnull((select sum(taxable_euro) from invoicedetailview NC	
										where NC.idexp_taxable = Elast.idexp
											and NC.idinvkind_main = IV.idinvkind and NC.yinv_main = IV.yinv and NC.ninv_main = IV.ninv 
											and isnull(NC.cigcode,'na') = isnull(I.cigcode,'na')
											and isnull(NC.cupcode,'na') = isnull(I.cupcode,'na') ),0),
				isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA'))), 
				ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))),
				I.expensekind,
				IV.ipa_acq,
			-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql

			case
				when IV.idsdi_acquisto is not null then sdi.ninvoice
				when IV.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),IV.idinvkind ))) + convert(varchar(5),IV.idinvkind )+substring(IV.doc,1, 15))
				else IV.doc
			end,
			case when (ik.enable_fe='S' or ik.enable_fe_estera='S') THEN 'S' ELSE 'N' end,
			P.kpay
			from invoice IV
			join invoicekind IK on iv.idinvkind=ik.idinvkind
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R on IV.idreg = R.idreg
			join residence RR  on R.residence=RR.idresidence
			join expenselast Elast			on Elast.idexp = I.idexp_taxable
			JOIN payment P			ON P.kpay = Elast.kpay
			JOIN paymenttransmission T			ON T.kpaymenttransmission = P.kpaymenttransmission
			-- queste join ci servono per leggere cig e cup da spesa/upb/fin
			join expenseyear EY			on Elast.idexp = EY.idexp 	and P.ypay = EY.ayear
			join finlast Flast			on EY.idfin = Flast.idfin
			join upb U					on EY.idupb = U.idupb
			join expense ExpPag			on I.idexp_taxable = ExpPag.idexp
			JOIN expenselink			ON expenselink.idchild = ExpPag.idexp
			JOIN expense ExpImp			on expenselink.idparent = ExpImp.idexp and ExpImp.nphase = @finphase

			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_taxable is not null  and  I.idexp_taxable <> isnull(I.idexp_iva,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				and IV.docdate between @1luglio2014 and @adate 
				and (@ayearstart is null OR  year(T.transmissiondate)>= @ayearstart )-- Se è stato impostato un filtro sull'esercizio, lo applica, diversamente mostra tutto.
				and T.transmissiondate <= @adate AND (T.transmissiondate <=@31dic2018  OR @OPIattivo='N')
				and exists (select * from banktransaction B (nolock) where B.idexp = I.idexp_taxable	) -- Prendiamo le fatture solo se c'è l'esitazione
				and not exists(select * from pccpayment PC (nolock) where PC.idinvkind = I.idinvkind and PC.yinv = I.yinv and PC.ninv = I.ninv
												and PC.kpay = P.kpay and PC.cigcode = isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')))
												and PC.cupcode = ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))))
												)
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322
				and (isnull(IK.flag,0) & 4) = 0 -- solo Fatt, no NC
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by IV.idinvkind, IV.yinv, IV.ninv,ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_taxable, I.cigcode, I.cupcode, I.expensekind, IV.ipa_acq,IV.doc,
			sdi.ninvoice, IV.idsdi_acquisto,IV.idsdi_acquistoestere, IV.doc, IK.enable_fe, IK.enable_fe_estera, P.kpay,Elast.idexp,
			ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')), 
				ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))

					
		-- PAGAMENTO fatture CONTAB. Solo IMPONIBILE -  Split
		insert into #contabilizzazioni  (idinvkind, yinv, ninv, identificativo_sdi, idexp, amount, cigcode, cupcode,expensekind, ipa,
			 ninvoice,	commerciale,  kpay )
			select 
				IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
				I.idexp_taxable, -- pagamento
				
				sum(I.taxable_euro) - isnull((select sum(taxable_euro) from invoicedetailview NC	
										where NC.idexp_taxable = Elast.idexp
											and NC.idinvkind_main = IV.idinvkind and NC.yinv_main = IV.yinv and NC.ninv_main = IV.ninv 
											and isnull(NC.cigcode,'na') = isnull(I.cigcode,'na')
											and isnull(NC.cupcode,'na') = isnull(I.cupcode,'na') ),0),
				isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA'))), 
				ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))),
				I.expensekind,
				IV.ipa_acq,
			-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when IV.idsdi_acquisto is not null then sdi.ninvoice
				when IV.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),IV.idinvkind ))) + convert(varchar(5),IV.idinvkind )+substring(IV.doc,1, 15))
				else IV.doc
			end,
			case when (ik.enable_fe='S' or ik.enable_fe_estera='S') THEN 'S' ELSE 'N' end,
			P.kpay
			from invoice IV
			join invoicekind IK on iv.idinvkind=ik.idinvkind
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			join registry R on IV.idreg = R.idreg
			join residence RR  on R.residence=RR.idresidence
			join expenselast Elast			on Elast.idexp = I.idexp_taxable
			JOIN payment P			ON P.kpay = Elast.kpay
			JOIN paymenttransmission T			ON T.kpaymenttransmission = P.kpaymenttransmission
			-- queste join ci servono per leggere cig e cup da spesa/upb/fin
			join expenseyear EY			on Elast.idexp = EY.idexp 	and P.ypay = EY.ayear
			join finlast Flast			on EY.idfin = Flast.idfin
			join upb U					on EY.idupb = U.idupb
			join expense ExpPag			on I.idexp_taxable = ExpPag.idexp
			JOIN expenselink			ON expenselink.idchild = ExpPag.idexp
			JOIN expense ExpImp			on expenselink.idparent = ExpImp.idexp and ExpImp.nphase = @finphase

			left outer join sdi_acquisto sdi on IV.idsdi_acquisto = sdi.idsdi_acquisto
			left outer join sdi_acquistoestere sdi_estere on IV.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
			where I.idexp_taxable is not null	
				and isnull(IV.flag_enable_split_payment,'N') = 'S'
				and (@ayearstart is null OR  year(T.transmissiondate)>= @ayearstart )-- Se è stato impostato un filtro sull'esercizio, lo applica, diversamente mostra tutto.
				and T.transmissiondate <= @adate AND (T.transmissiondate <=@31dic2018  OR @OPIattivo='N')
				and exists (select * from banktransaction B (nolock) where B.idexp = I.idexp_taxable	) -- Prendiamo le fatture solo se c'è l'esitazione
				and IV.docdate between @1luglio2014 and @adate 
				and not exists(select * from pccpayment PC (nolock) where PC.idinvkind = I.idinvkind and PC.yinv = I.yinv and PC.ninv = I.ninv
												and PC.kpay = P.kpay and PC.cigcode = isnull(I.cigcode, ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')))
												and PC.cupcode = ISNULL(I.cupcode, ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))))
												)
				AND ISNULL(I.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360		
				AND isnull(I.taxable,0) <>0 -- Solo dettagli fattura con imponibile maggiore di zero. Vi possono essere fatture con impon. 0 e iva >0.12322						
				and (isnull(IK.flag, 0) & 4) = 0 -- solo Fatt, no NC
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				and RR.coderesidence='I'
			group by IV.idinvkind, IV.yinv, IV.ninv, ISNULL(sdi.identificativo_sdi,sdi_estere.identificativo_sdi),
			I.idexp_taxable, I.cigcode, I.cupcode, I.expensekind, IV.ipa_acq,IV.doc,
			sdi.ninvoice, IV.idsdi_acquisto,IV.idsdi_acquistoestere, IV.doc, IK.enable_fe, IK.enable_fe_estera, P.kpay,Elast.idexp,
			ISNULL(ExpImp.cigcode,isnull(U.cigcode,'NA')), 
				ISNULL(ExpImp.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA')))

--select cigcode, cupcode,* from pccpayment where yinv = 2022 and ninv = 464 and idinvkind = 105
--select cigcode, cupcode,* from invoicedetailview where yinv = 2022 and ninv = 464 and idinvkind = 105
--select cigcode, cupcode,* from #contabilizzazioni-- where yinv = 2022 and ninv = 464 and idinvkind = 105

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
			kpay,
			cigcode,
			cupcode,
			ipa,
			idexppagamento,
			commerciale,
			ninvoice
		)
		select 'IP',
			I.idinvkind, I.yinv, I.ninv,I.identificativo_sdi,
			I.idreg	,
			isnull(I.docdate, sdi.adate) , -- dataemissione
			substring(I.doc,1,20),		-- numerodocumento
			-- ImportoTotaleDocumento:
			case when isnull(I.flag_reverse_charge,'N')='S' then (I.taxable-I.rounding) else  (I.total-I.rounding) end,--vedi task 7360 per il rounding
			--- Pagamento
			sum(CC.amount),
			CC.expensekind, -- natura di spesa
			CC.kpay,
			CC.cigcode, 
			CC.cupcode ,
			isnull(CC.ipa, sdi.codice_ipa),
			CC.idexp,
			CC.commerciale,
			CC.ninvoice
		from invoiceview I 
		join #contabilizzazioni CC 			on CC.idinvkind = I.idinvkind and CC.yinv = I.yinv and CC.ninv = I.ninv
		left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		group by I.idinvkind, I.yinv, I.ninv, I.identificativo_sdi,I.idreg	,
			isnull(I.docdate, sdi.adate) , substring(I.doc,1,20),	I.total-I.rounding ,	I.taxable-I.rounding ,I.flag_reverse_charge,
			CC.kpay, CC.idexp , 
			CC.cigcode, CC.cupcode, CC.expensekind, isnull(CC.ipa, sdi.codice_ipa), CC.commerciale, CC.ninvoice

	delete from #contabilizzazioni

	
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
			ipa,
			ninvoice,
			commerciale 
			)
		select 'IP',
			I.idinvkind, I.yinv, I.ninv,I.identificativo_sdi,
			PO.idpettycash,
			PO.yoperation,
			PO.noperation,
			I.idreg	,
			isnull(I.docdate, sdi.adate) , -- dataemissione
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
			isnull(I.ipa_acq, sdi.codice_ipa) ,
			-- Se è una FE di acquisto, prende ninvoice di sdi_acquisto.
			-- Se è una FE di acquisto estera, costruisce il campo 'ninvoice' come viene fatto nella exp_electronicinvoice_estere.sql
			case
				when I.idsdi_acquisto is not null then sdi.ninvoice
				when I.idsdi_acquistoestere is not null then (replicate('0',5-len(convert(varchar(5),I.idinvkind ))) + convert(varchar(5),I.idinvkind )+substring(I.doc,1, 30))
				else I.doc
			end,
			case when (ik.enable_fe='S' or ik.enable_fe_estera='S') THEN 'S' ELSE 'N' end
		from invoiceview I 
		join invoicekind IK on I.idinvkind=ik.idinvkind
		join pettycashoperationinvoice P		on P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv
		join pettycash PK 						on PK.idpettycash = P.idpettycash
		join pettycashoperation PO		on PO.idpettycash = P.idpettycash and PO.noperation = P.noperation and PO.yoperation = P.yoperation
		join registry R on I.idreg = R.idreg
		join residence RR  on R.residence=RR.idresidence		
		left outer join sdi_acquisto sdi on I.idsdi_acquisto = sdi.idsdi_acquisto
		left outer join sdi_acquistoestere sdi_estere on I.idsdi_acquistoestere = sdi_estere.idsdi_acquistoestere
		where I.docdate between @1luglio2014 and @adate 
			and (@ayearstart is null OR  year(PO.adate) >= @ayearstart )-- Se è stato impostato un filtro sull'esercizio, lo applica, diversamente mostra tutto.
			and PO.adate <= @adate AND (PO.adate <=@31dic2018  OR @OPIattivo='N')
			and not exists(select * from pccpayment P where P.idinvkind = I.idinvkind and P.yinv = I.yinv and P.ninv = I.ninv)			
			AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			and RR.coderesidence='I'
		-- Fine inserimento IP

declare @cf varchar(11)
select @cf = cf from license

------------------------------------------------------------------------------



update #dati set ipa = (select ipa_fe from invoicekind I where #dati.idinvkind = I.idinvkind) where idinvkind is not null AND ipa is null

SELECT 
	nriga,
	D.idinvkind, 
	D.yinv ,D.ninv, 
	IK.description as invoicekind,
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,
	-- IDENTIFICATIVO_2_b lo valorizziamo solo se esiste un identificativo Sdi
	D.ninvoice  as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
   case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio
	-- IP
	ltrim(rtrim(D.opkind)) as 'azione',
	null as 'IdPagamento',
	case when commerciale='S' then'C'else 'NC'end as 'Tipodebito', 
	importopagato,
	substring(ExpPag.description,1, 100) as descrizione,
	D.naturadispesa,
	P.kpay,
	null as idpettycash,
	null as yoperation,
	null as noperation,
	convert(varchar(20),P.npay) as npay,
	PT.transmissiondate as 'paymentdate',
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
				when RR.coderesidence = 'J' then R.p_iva
				when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		else null
	end
	as 'IdFiscaleIvaFornitore',
	isnull(D.cigcode,'NA') as codicecig, 
	ISNULL(D.cupcode,'NA') as codicecup,

	null as 'PagamentoOPI',
	null as 'PagamentoIVA',
	null as 'Giornidisospensioneeffettivi'

from #dati D
join expense ExpPag			on ExpPag.idexp = D.idexppagamento
join payment P				on D.kpay = P.kpay
join paymenttransmission PT on P.kpaymenttransmission = PT.kpaymenttransmission
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
join invoicekind IK		on IK.idinvkind = D.idinvkind
where opkind='IP' and piccolaspesa is null  and ISNULL(D.importototaledocumento,0) <> 0
--and d.yinv=2022 and d.ninv=597 and d.idinvkind = 154
--and  P.npay = 1
UNION ALL

-- FATTURE PAGATE COL FONDO ECONOMALE
select 
	nriga,
	D.idinvkind, 
	D.yinv ,D.ninv, 
	IK.description as invoicekind,
	-- IDENTIFICATIVO 1
	null as IDENTIFICATIVO_1,
	-- IDENTIFICATIVO 2
	D.identificativo_sdi as IDENTIFICATIVO_2_a 	,
	D.ninvoice as IDENTIFICATIVO_2_b , /*2.1.1.4   <Numero> */
	-- IDENTIFICATIVO 3
	case when D.identificativo_sdi is null then dataemissione else null end as IDENTIFICATIVO_3_a 	, --Data documento (SDI 2.1.1.3 Data)
	case when D.identificativo_sdi is null then R.cf else null end  	as IDENTIFICATIVO_3_b 	,	--Codice fiscale fornitore
    case when D.identificativo_sdi is null then D.ipa else null end  	as IDENTIFICATIVO_3_c 	,--	Codice ufficio
	-- IP
	ltrim(rtrim(D.opkind)) as 'azione',
	null as 'IdPagamento',
	case when commerciale='S' then'C'else 'NC'end as 'Tipodebito', 
	D.importopagato,
	substring(D.descrizione,1, 100) as descrizione,
	D.naturadispesa,
	null as kpay,
	D.idpettycash as idpettycash,
	D.yoperation as yoperation,
	D.noperation as noperation,
	D.piccolaspesa as npay,
	D.paymentdate as   'paymentdate',
	case when RR.coderesidence = 'I' then 'IT' + R.p_iva
				when RR.coderesidence = 'J' then R.p_iva
				when RR.coderesidence = 'X' then substring(R.foreigncf,1,16)
		else null
	end
	as 'IdFiscaleIvaFornitore',
	isnull(D.cigcode,isnull(U.cigcode,'NA')) as codicecig,
	isnull(D.cupcode, ISNULL(U.cupcode, ISNULL(Flast.cupcode, 'NA'))) as codicecup,

	null as 'PagamentoOPI',
	null as 'PagamentoIVA',
	null as 'Giornidisospensioneeffettivi'
from #dati D
join registry R		on R.idreg = D.idreg
join residence RR	on RR.idresidence = R.residence
left outer join fin F		on D.idfin = F.idfin
left outer join finlast Flast			on D.idfin = Flast.idfin
left outer join upb U					on D.idupb = U.idupb
left outer join invoicekind IK			on IK.idinvkind = D.idinvkind
where opkind='IP' and piccolaspesa IS NOT NULL  and ISNULL(D.importototaledocumento,0) <> 0

order by nriga,iK.description, D.yinv, D.ninv


drop table #dati

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--exec compute_pccoperation_pagamenti 2023, {d '2023-06-26'},null,null,null,null,null
