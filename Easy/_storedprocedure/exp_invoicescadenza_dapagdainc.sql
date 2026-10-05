/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

--select * from pccdebitstatus

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicescadenza_dapagdainc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicescadenza_dapagdainc]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'

-- exp_invoicescadenza_dapagdainc '2025', {ts '2025-12-31 00:00:00'}, {ts '2025-12-31 00:00:00'}, {ts '2025-01-01 00:00:00'}, {ts '2025-12-31 00:00:00'},'S'
--exp_invoicescadenza_dapagdainc 'A',  2025,  'S' 
--go
--exp_invoicescadenza_dapagdainc 'A', 2025, 'S' 

CREATE  PROCEDURE [exp_invoicescadenza_dapagdainc](
	@acquistovendita char(1),
	@year 			int,  -- Anno inizio registrazione
	--@data_emissione_stop	datetime,
	@flag_nascondi_sosp	varchar,	
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
) 
AS BEGIN

if (@acquistovendita ='A')
Begin
	SELECT 
			--'A' [Vendite/Acquisto],
			--DATI CREDITORE
			registry.title [Fornitore],
	
			isnull(registry.cf,registry.p_iva)
			[Codice Fiscale o P.IVA],
			invoicekind.description [Tipo Fattura],
			invoice.yinv [Esercizio],		
		
			--DETTAGLIO CONTABILE
			invoice.ninv [Numero],

			invoice.doc [Fattura],
			invoice.docdate [Data emissione],

			invoice.description [Desc. fattura],

			-- numero dettaglio
			invdet.rownum [Riga di dettaglio],

			--imponibile dettaglio
	
			  CONVERT(decimal(19,2),
				ROUND(invdet.taxable * ISNULL(invdet.npackage,invdet.number) * 
				  CONVERT(DECIMAL(19,10),invoice.exchangerate) *
				  (1 - CONVERT(DECIMAL(19,6),ISNULL(invdet.discount, 0.0)))
				 ,2
				)) [Imponibile dettaglio],

		--iva dettaglio
		invdet.tax [Iva dettaglio],
			CASE 
				WHEN (profservice.idinvkind is null) THEN	isnull(totinvoiceview.taxabletotal,0)   - 

						-- sottraggo i dettagli NOLIQ
						CASE @flag_nascondi_sosp 
						WHEN 'S' THEN 
						isnull((SELECT sum(taxable_euro) 
						 FROM invoicedetailview det 
						 WHERE
							det.idinvkind = totinvoiceview.idinvkind and
							det.yinv = totinvoiceview.yinv and
							det.ninv = totinvoiceview.ninv and
							ISNULL(det.idpccdebitstatus,'N') in ('SospCnst','SospContz','SospEsReg')  
						),0)
						ELSE 0
						END 
				WHEN (profservice.idinvkind is not null) THEN	CONVERT(decimal(19,2), ROUND(profservice.totalgross - ISNULL(profservice.ivaamount,0),2))
			END	 [Tot. Imponibile],

			CASE 
				WHEN (profservice.idinvkind is null) THEN	isnull(totinvoiceview.ivatotal,0)
				 - 

						-- sottraggo i dettagli NOLIQ
						CASE @flag_nascondi_sosp 
						WHEN 'S' THEN 
						isnull((SELECT sum(iva_euro) 
						 FROM invoicedetailview det 
						 WHERE
						 det.idinvkind = totinvoiceview.idinvkind and
						 det.yinv = totinvoiceview.yinv and
						 det.ninv = totinvoiceview.ninv and
						 ISNULL(det.idpccdebitstatus,'N') in ('SospCnst','SospContz','SospEsReg')  
						),0)
						ELSE 0
						END 
				WHEN (profservice.idinvkind is not null) THEN	profservice.ivaamount
			END [Tot. Iva],

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
			invoice.paymentexpiring [Giorni scadenza],
	
			ek.description [Tipo di scadenza] 

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
where (invoice.yinv >=@year or @year is null)
	and invoice.active = 'S'
	and not exists (select * FROM invoicedetail as NC
		WHERE invdet.idinvkind = nc.idinvkind_main AND invdet.yinv = nc.yinv_main	AND invdet.ninv = nc.ninv_main AND invdet.rownum = nc.rownum_main)-- il dettaglio non deve essere referenziato da una NC
	AND (invoicekind.flag&1)=0 
	and	(invoicekind.flag&4)=0  -- solo fatture, no NC
	and not exists(select PC1.idexp from paymentcommunicated PC1	/*se non esiste il pagamento trasmesso*/
					where PC1.idexp = invdet.idexp_taxable )
	and not exists(select  * from pettycashoperationinvoice PCOI 				/* la fattura non viene contabilizzata col fondo economale */
							where invoice.idinvkind = PCOI.idinvkind
								AND invoice.yinv = PCOI.yinv
								AND invoice.ninv = PCOI.ninv)

AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)
AND ((@flag_nascondi_sosp = 'S' AND ISNULL(invdet.idpccdebitstatus,'N') not in ('SospCnst','SospContz','SospEsReg') ) 
		OR (@flag_nascondi_sosp = 'N'))
order by invoicekind.description, invoice.adate

End

if (@acquistovendita ='V')
Begin
	SELECT 
			--'V' [Vendite/Acquisto],
			--DATI CREDITORE
			registry.title [Cliente],
	
			isnull(registry.cf,registry.p_iva)
			[Codice Fiscale o P.IVA],
			invoicekind.description [Tipo Fattura],
			invoice.yinv [Esercizio],		
		
			--DETTAGLIO CONTABILE
			invoice.ninv [Numero],

			invoice.doc [Fattura],
			invoice.docdate [Data emissione],

			invoice.description [Desc. fattura],

			-- numero dettaglio
			invdet.rownum [Riga di dettaglio],

			--imponibile dettaglio
	
			  CONVERT(decimal(19,2),
				ROUND(invdet.taxable * ISNULL(invdet.npackage,invdet.number) * 
				  CONVERT(DECIMAL(19,10),invoice.exchangerate) *
				  (1 - CONVERT(DECIMAL(19,6),ISNULL(invdet.discount, 0.0)))
				 ,2
				)) [Imponibile dettaglio],

		--iva dettaglio
		invdet.tax [Iva dettaglio],
		isnull(totinvoiceview.taxabletotal,0) 	 [Tot. Imponibile],

		isnull(totinvoiceview.ivatotal,0) [Tot. Iva],

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
			invoice.paymentexpiring [Giorni scadenza],
	
			ek.description [Tipo di scadenza] 

FROM invoice (NOLOCK)
JOIN invoicekind (NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
LEFT OUTER JOIN totinvoiceview (NOLOCK)
	ON totinvoiceview.idinvkind = invoice.idinvkind
	AND totinvoiceview.yinv = invoice.yinv
	AND totinvoiceview.ninv = invoice.ninv
FULL JOIN expirationkind ek
	ON invoice.idexpirationkind=ek.idexpirationkind
JOIN invoicedetail invdet
	ON invdet.idinvkind = invoice.idinvkind
	AND invdet.ninv = invoice.ninv
	AND invdet.yinv = invoice.yinv
where  (invoice.yinv >=@year or @year is null)
	and invoice.active = 'S'
	and not exists (select * FROM invoicedetail as NC
		WHERE invdet.idinvkind = nc.idinvkind_main AND invdet.yinv = nc.yinv_main	AND invdet.ninv = nc.ninv_main AND invdet.rownum = nc.rownum_main)-- il dettaglio non deve essere referenziato da una NC
	AND (invoicekind.flag&1)<> 0 -- Vendite 
	and	(invoicekind.flag&4)=0  -- solo fatture, no NC
	and not exists(select PC1.idinc from proceedscommunicated PC1	/*se non esiste l'incasso trasmesso*/
					where PC1.idinc = invdet.idinc_taxable )


AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)

order by invoicekind.description, invoice.adate

End	

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

