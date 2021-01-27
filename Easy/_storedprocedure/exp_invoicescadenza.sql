
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicescadenza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicescadenza]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amm'
 
-- exp_invoicescadenza '2020', {ts '2020-12-31 00:00:00'}, {ts '2020-12-31 00:00:00'}, {ts '2020-12-31 00:00:00'}, {ts '2020-12-31 00:00:00'}, 'N','N', NULL, NULL, NULL, NULL, NULL
CREATE  PROCEDURE [exp_invoicescadenza](
	@year 			int,  --,
	@data_pagamento	datetime, -- Per le fatture pagate con fondo economale è la data di registrazione dell'operazione
	@data_scadenza	datetime,
	@data_emissione_start	datetime,
	@data_emissione_stop	datetime,
	@flag_nascondi_pagate	varchar,	
	@flag_nascondi_noliq	varchar,	
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
) 
AS BEGIN


SELECT distinct
	--AMMINISTRAZIONE
	'                ' [Ufficio di riferimento],
	--DATI CREDITORE
	registry.title [Anagrafica],
	
	isnull(registry.cf,registry.p_iva)
	[Codice Fiscale o P.IVA],
	--DATI FINANZIARI
	invoicekind.codeinvkind+'/' + cast(invoice.yinv as varchar(4)) + '/' + cast(invoice.ninv as varchar(9)) [id debito], -- per adesso sto gestendo solo le fatture

	--residuo = totaleimponibile + totaleiva - totale movimenti
	CASE 
	-- devo fare il calcolo della fattura
	WHEN (profservice.idinvkind is null) THEN
				ISNULL(totinvoiceview.taxabletotal, 0.0) +
				ISNULL(totinvoiceview.ivatotal, 0.0) - 
				CONVERT(decimal(23,5),
				CASE 
				--pagato con mandato
				WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0)  THEN 
						ISNULL(
							(SELECT SUM(expenseyear_starting.amount)
							FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
							LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  							ON expensetotal_firstyear.idexp = s.idexp
  							AND ((expensetotal_firstyear.flag & 2) <> 0 )
 							LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
							ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  							AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
							JOIN expenselast el
							on s.idexp = el.idexp
							JOIN payment p
							ON p.kpay=el.kpay
							JOIN paymenttransmission pt
							ON  pt.kpaymenttransmission = p.kpaymenttransmission
							WHERE i.idinvkind = invoice.idinvkind
							AND i.yinv = invoice.yinv
							AND i.ninv = invoice.ninv
							AND s.idexp = i.idexp
							AND pt.transmissiondate <= @data_pagamento
							)
						,0) +
						--pagato con fondo economale
						ISNULL(
								(ISNULL(
									(SELECT SUM(p.amount)
										FROM pettycashoperationinvoice mov
										JOIN pettycashoperation p
										ON mov.idpettycash = p.idpettycash
										AND mov.yoperation = p.yoperation
										AND mov.noperation = p.noperation
										WHERE mov.idinvkind = invoice.idinvkind
										AND mov.yinv = invoice.yinv
										AND mov.ninv = invoice.ninv
										AND p.adate <= @data_pagamento)
										,0)),0)
					--nota di credito
					WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
						ISNULL(
							(SELECT ABS(SUM(s.amount)) 
							FROM expensevar s
							JOIN expenselast el 
							ON el.idexp=s.idexp
							JOIN payment p
							ON p.kpay=el.kpay
							JOIN paymenttransmission pt
							ON  pt.kpaymenttransmission = p.kpaymenttransmission
							WHERE s.idinvkind = invoice.idinvkind
							AND s.yinv = invoice.yinv
							AND s.ninv = invoice.ninv
							AND pt.transmissiondate <= @data_pagamento)
						,0)

					END)
	-- devo fare il calcolo del residuo da pagare della prestazione professionale
	WHEN (profservice.idinvkind is NOT null and invdet.ycon is null) THEN

	-- RESIDUO = importobeneficiario - totalemovimenti trasmessi alla data
	CONVERT(decimal(19,2),
		profservice.totalgross - 
			(
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseprofservice mov
					JOIN expense s
						ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
						ON expensetotal_firstyear.idexp = s.idexp
						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					JOIN expense e_figlio
						ON s.idexp = e_figlio.parentidexp
					JOIN expenselast el 
						ON el.idexp=e_figlio.idexp
					JOIN payment p
					    ON p.kpay=el.kpay
					JOIN paymenttransmission pt
						ON  pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE mov.ycon = profservice.ycon
						AND mov.ncon = profservice.ncon
						AND pt.transmissiondate <= @data_pagamento
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseprofservice mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					AND v.autokind<>4
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationprofservice mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
				,0)
			)
	)
	END  [Tot. Da trasmettere],

	CASE 
		WHEN (profservice.idinvkind is null) THEN	totinvoiceview.taxabletotal 
		WHEN (profservice.idinvkind is not null) THEN	CONVERT(decimal(19,2), ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2))
	END	 [Tot. Imponibile],
	
	CASE 
		WHEN (profservice.idinvkind is null) THEN	totinvoiceview.ivatotal 
		WHEN (profservice.idinvkind is not null) THEN	profservice.ivaamount
	END [Tot. Iva],

	CASE
		-- fattura non collegata a parcella professionale
		WHEN (profservice.idinvkind is null and invdet.ycon is null) THEN
			CONVERT(decimal(23,5),
			CASE 
			--pagato con mandato
			WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN 
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  					ON expensetotal_firstyear.idexp = s.idexp
  					AND ((expensetotal_firstyear.flag & 2) <> 0 )
 					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
					ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  					AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					JOIN expenselast el
					on s.idexp = el.idexp
					JOIN payment p
					ON p.kpay=el.kpay
					JOIN paymenttransmission pt
					ON  pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE i.idinvkind = invoice.idinvkind
					AND i.yinv = invoice.yinv
					AND i.ninv = invoice.ninv
					AND s.idexp = i.idexp 
					AND pt.transmissiondate <= @data_pagamento),0)

			-- nota di credito	
			WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
				ISNULL(
					(SELECT ABS(SUM(s.amount)) 
					FROM expensevar s
					JOIN expenselast el 
					ON el.idexp=s.idexp
					JOIN payment p
					ON p.kpay=el.kpay
					JOIN paymenttransmission pt
					ON  pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE s.idinvkind = invoice.idinvkind
					AND s.yinv = invoice.yinv
					AND s.ninv = invoice.ninv
					AND pt.transmissiondate <= @data_pagamento),0)
			END) 
		--fattura legata a parcella professionale
		WHEN (profservice.idinvkind is not null) THEN
		CONVERT(decimal(19,2),
			ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseprofservice mov
					JOIN expense s
						ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
						ON expensetotal_firstyear.idexp = s.idexp
						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					JOIN expense e_figlio
						ON s.idexp = e_figlio.parentidexp
					JOIN expenselast el 
						ON el.idexp=e_figlio.idexp
					JOIN payment p
					    ON p.kpay=el.kpay
					JOIN paymenttransmission pt
						ON  pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE mov.ycon = profservice.ycon
						AND mov.ncon = profservice.ncon
						AND pt.transmissiondate <= @data_pagamento
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseprofservice mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					AND v.autokind<>4
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationprofservice mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
				,0)
	) 
	
	END [Tot. Trasmesso],


	CONVERT(decimal(23,5),
	CASE 
	--pagato con mandato
	WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0) THEN 
				
		--pagato con fondo economale
		ISNULL(
			(SELECT SUM(p.amount)
			FROM pettycashoperationinvoice mov
			JOIN pettycashoperation p
			ON mov.idpettycash = p.idpettycash
			AND mov.yoperation = p.yoperation
			AND mov.noperation = p.noperation
			WHERE mov.idinvkind = invoice.idinvkind
			AND mov.yinv = invoice.yinv
			AND mov.ninv = invoice.ninv
			AND p.adate <= @data_pagamento) -- Per 
		,0)
	END) [Tot. Pagato con fondo economale],

	'' [Ceduto],  --"Ceduto (PT: PRO-SOLUTO / PD: PRO-SOLVENDO / NC: NON CEDUTO)"
	'' [Certificato], --Si/No
	'' [Ceritificabile], -- Si/No
	'' [GSA], --Si/No
	--RIFERIMENTI CERTIFICAZIONE 

	'' [PCC Ordinaria/altro],  
	'' [Nome procedura certificazione], 
	'' [Numero di ceritificazione], 
	'' [Data di certificazione], 

	--CLASSIFICAZIONE DI BILANCIO

	CASE
		WHEN (
			(SELECT distinct top 1 expensetotal_firstyear.flag
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			JOIN expenselast el
			on s.idexp = el.idexp
			JOIN payment p
			ON p.kpay=el.kpay
			JOIN paymenttransmission pt
			ON  pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp
			AND pt.transmissiondate <= @data_pagamento)&2)=0  THEN 'RE'
		ELSE 'CO'  
	END [Imputazione], --(CO: Competenza / RE: Residui / PE:Perenti)
			
	invdet.expensekind [Natura], -- (CO: Parte corrente / CA: Parte capitale)"		
	invoice.yinv [Esercizio],		
	'NA' [Codice Bilancio],	
		
	CASE
		--Fattura pagata con mandato o con fondo economale
		WHEN ((invoicekind.flag&1)=0) and ((invoicekind.flag&4)=0) THEN
			isnull((SELECT distinct top 1 f.codefin + ' - ' + f.title
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  			ON expensetotal_firstyear.idexp = s.idexp
  			AND ((expensetotal_firstyear.flag & 2) <> 0 )
 			LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
			ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  			AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
			JOIN expenselast el
			on s.idexp = el.idexp
			JOIN payment p
			ON p.kpay=el.kpay
			JOIN paymenttransmission pt
			ON  pt.kpaymenttransmission = p.kpaymenttransmission
			JOIN fin f
			ON f.idfin=expenseyear_starting.idfin
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND s.idexp = i.idexp
			AND pt.transmissiondate <= @data_pagamento),
			(SELECT distinct f.codefin + ' - ' + f.title
						FROM pettycashoperationinvoice mov
						JOIN pettycashoperation p
						ON mov.idpettycash = p.idpettycash
						AND mov.yoperation = p.yoperation
						AND mov.noperation = p.noperation
						JOIN fin f
						ON p.idfin = f.idfin
						WHERE mov.idinvkind = invoice.idinvkind
						AND mov.yinv = invoice.yinv
						AND mov.ninv = invoice.ninv
						AND p.adate <= @data_pagamento					
				)
			)
	
		WHEN ((invoicekind.flag&1)=0) and ((invoicekind.flag&4)<>0) THEN 
		(SELECT distinct top 1 f.codefin + ' - ' + f.title
			FROM expensevar s
			JOIN expenselast el 
			ON el.idexp=s.idexp
			LEFT OUTER JOIN expenseyear ey(NOLOCK) 
			ON el.idexp = ey.idexp
			JOIN fin f
			ON f.idfin=ey.idfin
			JOIN payment p
			ON p.kpay=el.kpay
			JOIN paymenttransmission pt
			ON  pt.kpaymenttransmission = p.kpaymenttransmission
			WHERE s.idinvkind = invoice.idinvkind
			AND s.yinv = invoice.yinv
			AND s.ninv = invoice.ninv
			AND pt.transmissiondate <= @data_pagamento)
	END [Capitolo / Conto],

	'NA' [Sottoconto],
	'NA' [N. decr. / det. di liquidazione],
	'NA' [Data decr. /det. di liquidazione],
	'NA' [Id Struttura / Ufficio],
	'NA' [Numero impegno],
	'NA' [Data impegno],

	--DETTAGLIO CONTABILE
	invoice.ninv [Numero],
	CASE
	--Fattura
	WHEN 
		isnull((select distinct top 1 ps.idinvkind
				from profservice ps
				where ps.idinvkind=invoice.idinvkind
				and ps.yinv=invoice.yinv
				and ps.ninv=invoice.ninv
			),0) <> 0 THEN 'Parcella'
	ELSE 'Fattura'
	END [Tipo documento], 
	'NA' [Desc. Tipo Documento Altro], -- Per le fatture e per le parcelle è sempre NA
	invoice.doc [Fattura],
	invoice.docdate [Data emissione],
	isnull((select distinct top 1 ep.cigcode from expense ep join expense ef on ep.idexp=ef.idexp join expenseprofservice ei on ef.idexp =  ei.idexp  where ei.ncon = profservice.ncon and ei.ycon=profservice.ycon)
		,isnull((select distinct top 1 ep.cigcode from expense ep join expense ef on ep.idexp=ef.parentidexp join expenseinvoice ei on ef.idexp =  ei.idexp  where ei.ninv = invoice.ninv and ei.yinv=invoice.yinv and ei.idinvkind=invoice.idinvkind and ei.movkind='1')
			,isnull((select distinct top 1 invdet.cigcode)
				,isnull((select distinct top 1 md.cigcode from mandatedetail md where md.idmankind = invdet.idmankind and md.nman=invdet.nman and md.yman=invdet.yman and md.rownum=invdet.manrownum)
					,isnull((select distinct top 1 u.cigcode from upb u join expenseyear ex on u.idupb = ex.idupb join expenseprofservice ei on ex.idexp =  ei.idexp where ei.ncon = profservice.ncon and ei.ycon=profservice.ycon)
						,isnull((select distinct top 1 u.cigcode from upb u join expenseyear ex on u.idupb = ex.idupb join expenseinvoice ei on ei.idexp = ex.idexp where ei.ninv = invoice.ninv and ei.yinv=invoice.yinv and ei.idinvkind=invoice.idinvkind and ei.movkind='1') ,'NA'))))))
	[Numero CIG],
	isnull((select distinct top 1 ep.cupcode from expense ep join expense ef on ep.idexp=ef.idexp join expenseprofservice ei on ef.idexp =  ei.idexp  where ei.ncon = profservice.ncon and ei.ycon=profservice.yinv)
		,isnull((select distinct top 1 ep.cupcode from expense ep join expense ef on ep.idexp=ef.parentidexp join expenseinvoice ei on ef.idexp =  ei.idexp  where ei.ninv = invoice.ninv and ei.yinv=invoice.yinv and ei.idinvkind=invoice.idinvkind and ei.movkind='1')
			,isnull((select distinct top 1 invdet.cupcode)
				,isnull((select distinct top 1 md.cupcode from mandatedetail md where md.idmankind = invdet.idmankind and md.nman=invdet.nman and md.yman=invdet.yman and md.rownum=invdet.manrownum)
					,isnull((select distinct top 1  u.cupcode from upb u join expenseyear ex on u.idupb = ex.idupb join expenseinvoice ei on ei.idexp = ex.idexp where ei.ninv = invoice.ninv and ei.yinv=invoice.yinv and ei.idinvkind=invoice.idinvkind and ei.movkind='1') 
						,isnull((select distinct top 1  u.cupcode from upb u join expenseyear ex on u.idupb = ex.idupb join expenseprofservice ei on ex.idexp =  ei.idexp where ei.ncon = profservice.ncon and ei.ycon=profservice.ycon)					
							,isnull((select distinct top 1  flast.cupcode from finlast flast join expenseyear ex on flast.idfin = ex.idfin join expenseprofservice ei on ex.idexp =  ei.idexp where ei.ncon = profservice.ncon and ei.ycon=profservice.ycon) 
								,isnull((select distinct top 1  flast.cupcode from finlast flast join expenseyear ex on flast.idfin = ex.idfin join expenseinvoice ei on ei.idexp = ex.idexp where ei.ninv = invoice.ninv and ei.yinv=invoice.yinv and ei.idinvkind=invoice.idinvkind and ei.movkind='1') 		
									,Replicate('0',15)))))))))
	[Numero CUP],

	invoice.annotations [Note],
	registry.p_iva [Partita IVA Fornitore],
	invoicekind.description [Descr. Tipo Fattura Easy],
	invoice.registryreference [Riferimento],
	invoice.description [Desc. fattura],
	invoice.paymentexpiring [Giorni scadenza],
	
	ek.description [Tipo di scadenza] ,

	invoice.adate [Data registrazione],
		
	dateadd(day,isnull(invoice.paymentexpiring,0),
	case 
		when (invoice.idexpirationkind=1) then invoice.adate
		when (invoice.idexpirationkind=2) then invoice.docdate
		when (invoice.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.docdate) ,invoice.docdate)))
		when (invoice.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.adate) ,invoice.adate)))
		when (invoice.idexpirationkind=5) then invoice.adate
		when (invoice.idexpirationkind=6) then invoice.protocoldate
	end ) [Data scadenza],

	-- numero dettaglio
	invdet.rownum [Riga di dettaglio],

	--imponibile dettaglio
	
	invdet.taxable [Imponibile dettaglio],
	
	--iva dettaglio
	invdet.tax [Iva dettaglio],
	-- numero liquidazione fattura non collegata a parcella professionale
	CASE
	WHEN (profservice.idinvkind is null and invdet.ycon is null) THEN
	isnull((SELECT distinct top 1 cast(s.ymov as varchar(4)) +'/'+cast(s.nmov as varchar(9))
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			JOIN expenselast el
			on s.idexp = el.idexp
			join invoicedetail id
			on 		id.idinvkind = invoice.idinvkind 
			AND id.yinv = invoice.yinv
			AND id.ninv = invoice.ninv
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND id.idexp_taxable = s.idexp
			AND id.rownum=invdet.rownum
			),'')
	WHEN (profservice.idinvkind is not null) THEN
		(SELECT 'Vedi Prest. Professionale ' +  cast(profservice.ycon as varchar(4)) + '/' + cast(profservice.ncon as varchar(4)))
	END [Riga di mandato],
	
	CASE
	WHEN (profservice.idinvkind is null and invdet.ycon is null) THEN
	--mandato di fattura non legata a parcella professionale
	isnull((SELECT distinct top 1 cast(p.ypay as varchar(4)) +'/'+cast(p.npay as varchar(9))
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			JOIN expenselast el
			on s.idexp = el.idexp
			JOIN payment p
			ON p.kpay=el.kpay
			--JOIN paymenttransmission pt
			--ON  pt.kpaymenttransmission = p.kpaymenttransmission
			join invoicedetail id
			on 		id.idinvkind = invoice.idinvkind 
			AND id.yinv = invoice.yinv
			AND id.ninv = invoice.ninv
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND id.idexp_taxable = s.idexp
			AND id.rownum=invdet.rownum
			--AND pt.transmissiondate <= @data_pagamento
			)
			,'') 
	END	[Mandato],

	CASE
	WHEN (profservice.idinvkind is null and invdet.ycon is null) THEN
	--distinta di fattura non legata a parcella professionale
		isnull((SELECT distinct top 1  cast(pt.ypaymenttransmission as varchar(4)) + '/' + cast(pt.npaymenttransmission as varchar(9))
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			JOIN expenselast el
			on s.idexp = el.idexp
			JOIN payment p
			ON p.kpay=el.kpay
			JOIN paymenttransmission pt
			ON  pt.kpaymenttransmission = p.kpaymenttransmission
			join invoicedetail id
			on 		id.idinvkind = invoice.idinvkind 
			AND id.yinv = invoice.yinv
			AND id.ninv = invoice.ninv
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND id.idexp_taxable = s.idexp
			AND id.rownum=invdet.rownum
			AND pt.transmissiondate <= @data_pagamento),'') 
	END [Elenco trasmissione],

	CASE
	WHEN (profservice.idinvkind is null and invdet.ycon is null) THEN
	-- data di trasmissione di fattura non legata a parcella professionale
		(SELECT distinct top 1  pt.transmissiondate
			FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
			JOIN expenselast el
			on s.idexp = el.idexp
			JOIN payment p
			ON p.kpay=el.kpay
			JOIN paymenttransmission pt
			ON  pt.kpaymenttransmission = p.kpaymenttransmission
			join invoicedetail id
			on 		id.idinvkind = invoice.idinvkind 
			AND id.yinv = invoice.yinv
			AND id.ninv = invoice.ninv
			WHERE i.idinvkind = invoice.idinvkind
			AND i.yinv = invoice.yinv
			AND i.ninv = invoice.ninv
			AND id.idexp_taxable = s.idexp
			AND id.rownum=invdet.rownum
			AND pt.transmissiondate <= @data_pagamento) 
END [Data di trasmissione]
FROM invoice (NOLOCK)
JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
LEFT OUTER JOIN profservice (NOLOCK)
ON profservice.idinvkind=invoice.idinvkind and profservice.yinv=invoice.yinv and profservice.ninv=invoice.ninv
FULL JOIN expirationkind ek
ON invoice.idexpirationkind=ek.idexpirationkind
JOIN invoicedetail invdet
ON invdet.idinvkind = invoice.idinvkind
AND invdet.ninv = invoice.ninv
AND invdet.yinv = invoice.yinv
where invoice.yinv=@year
AND ((invoicekind.flag&1)=0 or (invoicekind.flag&1)=4)

AND (	
(isnull(dateadd(day,isnull(invoice.paymentexpiring,0),
	case 
		when (invoice.idexpirationkind=1) then invoice.adate
		when (invoice.idexpirationkind=2) then invoice.docdate
		when (invoice.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.docdate) ,invoice.docdate)))
		when (invoice.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.adate) ,invoice.adate)))
		when (invoice.idexpirationkind=5) then invoice.adate
		when (invoice.idexpirationkind=6) then invoice.protocoldate
	end ),getdate()) <= @data_scadenza) 

)

AND(
	--residuo = totaleimponibile + totaleiva - totale movimenti
	CASE 
	-- devo fare il calcolo della fattura
	WHEN (profservice.idinvkind is null) THEN
				ISNULL(totinvoiceview.taxabletotal, 0.0) +
				ISNULL(totinvoiceview.ivatotal, 0.0) - 
				CONVERT(decimal(23,5),
				CASE 
				--pagato con mandato
				WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)=0)  THEN 
						ISNULL(
							(SELECT SUM(expenseyear_starting.amount)
							FROM expenseinvoice i (NOLOCK), expense s (NOLOCK)
							LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
  							ON expensetotal_firstyear.idexp = s.idexp
  							AND ((expensetotal_firstyear.flag & 2) <> 0 )
 							LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
							ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
  							AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
							JOIN expenselast el
							on s.idexp = el.idexp
							JOIN payment p
							ON p.kpay=el.kpay
							JOIN paymenttransmission pt
							ON  pt.kpaymenttransmission = p.kpaymenttransmission
							WHERE i.idinvkind = invoice.idinvkind
							AND i.yinv = invoice.yinv
							AND i.ninv = invoice.ninv
							AND s.idexp = i.idexp
							AND pt.transmissiondate <= @data_pagamento
							)
						,0) +
						--pagato con fondo economale
						ISNULL(
								(ISNULL(
									(SELECT SUM(p.amount)
										FROM pettycashoperationinvoice mov
										JOIN pettycashoperation p
										ON mov.idpettycash = p.idpettycash
										AND mov.yoperation = p.yoperation
										AND mov.noperation = p.noperation
										WHERE mov.idinvkind = invoice.idinvkind
										AND mov.yinv = invoice.yinv
										AND mov.ninv = invoice.ninv
										AND p.adate <= @data_pagamento)
										,0)),0)
					--nota di credito
					WHEN ((invoicekind.flag&1)=0) AND ((invoicekind.flag&4)<>0) THEN 
						ISNULL(
							(SELECT ABS(SUM(s.amount)) 
							FROM expensevar s
							JOIN expenselast el 
							ON el.idexp=s.idexp
							JOIN payment p
							ON p.kpay=el.kpay
							JOIN paymenttransmission pt
							ON  pt.kpaymenttransmission = p.kpaymenttransmission
							WHERE s.idinvkind = invoice.idinvkind
							AND s.yinv = invoice.yinv
							AND s.ninv = invoice.ninv
							AND pt.transmissiondate <= @data_pagamento)
						,0)

					END)
	-- devo fare il calcolo del residuo da pagare della prestazione professionale
	WHEN (profservice.idinvkind is NOT null) THEN

	-- RESIDUO = importobeneficiario - totalemovimenti trasmessi alla data
	CONVERT(decimal(19,2),
		profservice.totalgross - 
			(
				ISNULL(
					(SELECT SUM(expenseyear_starting.amount)
					FROM expenseprofservice mov
					JOIN expense s
						ON s.idexp = mov.idexp
					LEFT OUTER JOIN expensetotal expensetotal_firstyear(NOLOCK)
						ON expensetotal_firstyear.idexp = s.idexp
						AND ((expensetotal_firstyear.flag & 2) <> 0 )
					LEFT OUTER JOIN expenseyear expenseyear_starting(NOLOCK) 
						ON expenseyear_starting.idexp = expensetotal_firstyear.idexp
						AND expenseyear_starting.ayear = expensetotal_firstyear.ayear
					JOIN expense e_figlio
						ON s.idexp = e_figlio.parentidexp
					JOIN expenselast el 
						ON el.idexp=e_figlio.idexp
					JOIN payment p
					    ON p.kpay=el.kpay
					JOIN paymenttransmission pt
						ON  pt.kpaymenttransmission = p.kpaymenttransmission
					WHERE mov.ycon = profservice.ycon
						AND mov.ncon = profservice.ncon
						AND pt.transmissiondate <= @data_pagamento
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
				)
				,0) +
				ISNULL(
					(SELECT SUM(v.amount)
					FROM expenseprofservice mov
					JOIN expense s
					ON s.idexp = mov.idexp
					JOIN expensevar v
					ON v.idexp = mov.idexp
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon
					AND v.autokind<>4
					--AND s.nphase = (SELECT expensephase FROM expensesetup WHERE ayear=s.ycreation)
					)
				,0) +
				ISNULL(
					(SELECT SUM(p.amount)
					FROM pettycashoperationprofservice mov
					JOIN pettycashoperation p
					ON mov.idpettycash = p.idpettycash
					AND mov.yoperation = p.yoperation
					AND mov.noperation = p.noperation
					WHERE mov.ycon = profservice.ycon
					AND mov.ncon = profservice.ncon)
				,0)
			)
	)
	END
	)
 + 

(CASE
	WHEN @flag_nascondi_pagate='S' THEN 0
	WHEN @flag_nascondi_pagate='N' THEN 1
END)  > 0  

AND invoice.docdate between @data_emissione_start and @data_emissione_stop
AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)
AND ((@flag_nascondi_noliq = 'S' AND ISNULL(invdet.idpccdebitstatus,'N') not in ( 'NOLIQ','NLdaLIQ','NLdaSOSP') ) 
		OR (@flag_nascondi_noliq = 'N'))
order by invoice.adate
		
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
