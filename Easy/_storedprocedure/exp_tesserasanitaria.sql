if exists (select * from dbo.sysobjects where id = object_id(N'[exp_tesserasanitaria]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_tesserasanitaria]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure exp_tesserasanitaria(
	@ayear smallint,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) as
-- exec exp_tesserasanitaria 2016
-- ove @ayear è l'anno della dichiarazione, e non l'anno dei redditi (@ayear-1)
set @ayear = @ayear - 1
begin
	--DECLARE @pIva varchar(11)
	--SELECT	@pIva = p_iva FROM license

--Per il momento non filtro uno specifico tipo registro, poichè non l'hanno usato
--DECLARE @idivaregisterkind_ssn int
--SELECT  @idivaregisterkind_ssn = idivaregisterkind FROM ivaregisterkind WHERE codeivaregisterkind = '16TESSERASANITARIA'

--SEZIONE PROPRIETARIO
-- <proprietario>
--		codiceRegione[Obb.]: codice regione della struttura che emette il doc. fiscale(così come riportato nella lettera di assegnazione credenziali)
--		codiceAsl[Obb.]: codice ASL della struttura che emette il doc. fiscale(così come riporttao nella lettera di assegnazione credenziali)
--		codiceSSA[Obb.]: codice struttura che emette il doc. fiscale (così come riporttao nella lettera di assegnazione credenziali)
--		cfProprietario : CF del soggetto di riferimanto della struttura(Campo cifrato)
-- </proprietario>

-- SEZIONE DOCUMENTO SPESA
-- <documentoSpesa>
-- </documentoSpesa>

create table #dati(
	idinvkind int,  
	yinv smallint, 
	ninv int,
	invrownum int,
	idreg int,	
	idfin int,--li usiamo solo per la piccola spesa
	idupb varchar(36),--li usiamo solo per la piccola spesa
	descrizione varchar(100),	--> da usare quando il doc. non è contabilizzati
	idincimpegno int,
-- PAGAMENTO
	importopagato decimal(19,2),
	kpro int,
	datapagamento datetime
)
declare @finphase tinyint
SET @finphase = (SELECT incomephase FROM config where ayear = @ayear)


create table #contabilizzazioni(
	idinvkind int,  
	yinv smallint, 
	ninv int,
	invrownum int,
	amount decimal(19,2),
	idinc int
)


		-- PAGAMENTO fatture con o senza C.P. 
		insert into #contabilizzazioni  (idinvkind, yinv, ninv,  idinc, amount)
		select 
				I.idinvkind, I.yinv, I.ninv, 
				I.idinc_iva, -- pagamento
				case when isnull(IV.flag_reverse_charge,'N')='S' then sum(isnull(I.taxable_euro,0))
																else sum(isnull(I.taxable_euro,0) + isnull(I.iva_euro,0))
				end
			from invoice IV
			join invoicedetailview I 		on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			JOIN invoicekind IK
				ON I.idinvkind = IK.idinvkind
			where I.idinc_iva = I.idinc_taxable
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				AND ISNULL(I.rounding,'N') <>'S'  
				and (isnull(I.flagbit,0) & 4) = 0

				--AND EXISTS (SELECT * FROM ivaregister IRG 
				--			WHERE IRG.idinvkind = I.idinvkind
				--			AND IRG.yinv = I.yinv
				--			AND IRG.ninv = I.ninv 
				--			AND IRG.idivaregisterkind = @idivaregisterkind_ssn)  
				AND IV.ssntipospesa IS NOT NULL 

				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
				AND YEAR(I.adate) = @ayear
				AND (IK.flag & 1)<> 0 --> Vendita
				AND isnull(I.rowtotal,0) <> 0  -- saltiamo le righe di importo 0
			group by I.idinvkind, I.yinv, I.ninv, I.idinc_iva, IV.flag_reverse_charge

		insert into #contabilizzazioni  (idinvkind, yinv, ninv,  idinc, amount)
			select 
				I.idinvkind, I.yinv, I.ninv, 
				I.idinc_iva, -- pagamento
				case when isnull(IV.flag_reverse_charge,'N')='S' then 0	else sum(iva_euro)end
			from invoice IV
			join invoicedetailview I
				on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			JOIN invoicekind IK
				ON I.idinvkind = IK.idinvkind
			where I.idinc_iva is not null and  I.idinc_iva <> isnull(I.idinc_taxable,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				AND ISNULL(I.rounding,'N') <>'S' 	
				and (isnull(I.flagbit,0) & 4) = 0
				--AND EXISTS (SELECT * FROM ivaregister IRG 
				--			WHERE IRG.idinvkind = I.idinvkind
				--			AND IRG.yinv = I.yinv
				--			AND IRG.ninv = I.ninv 
				--			AND IRG.idivaregisterkind = @idivaregisterkind_ssn)  
				AND IV.ssntipospesa IS NOT NULL 
				AND YEAR(I.adate) = @ayear
				AND (IK.flag & 1)<> 0 --> Vendita
				AND isnull(I.rowtotal,0) <> 0  -- saltiamo le righe di importo 0
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
		group by I.idinvkind, I.yinv, I.ninv, I.idinc_iva, IV.flag_reverse_charge

		insert into #contabilizzazioni  (idinvkind, yinv, ninv,  idinc, amount)
			select 
				I.idinvkind, I.yinv, I.ninv, 
				I.idinc_taxable, -- pagamento
				sum(I.taxable_euro)
			from invoice IV
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			JOIN invoicekind IK
				ON I.idinvkind = IK.idinvkind
			where I.idinc_taxable is not null  and  I.idinc_taxable <> isnull(I.idinc_iva,'')
				and isnull(IV.flag_enable_split_payment,'N') = 'N'
				AND ISNULL(I.rounding,'N') <>'S'  	
				and (isnull(I.flagbit,0) & 4) = 0
				--AND EXISTS (SELECT * FROM ivaregister IRG 
				--			WHERE IRG.idinvkind = I.idinvkind
				--			AND IRG.yinv = I.yinv
				--			AND IRG.ninv = I.ninv 
				--			AND IRG.idivaregisterkind = @idivaregisterkind_ssn)  
				AND IV.ssntipospesa IS NOT NULL 
				AND YEAR(I.adate) = @ayear
				AND (IK.flag & 1)<> 0 --> Vendita
				AND isnull(I.rowtotal,0) <> 0  -- saltiamo le righe di importo 0
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			group by I.idinvkind, I.yinv, I.ninv, I.idinc_taxable
			
			
		insert into #contabilizzazioni  (idinvkind, yinv, ninv,  idinc, amount)
			select 
				I.idinvkind, I.yinv, I.ninv, 
				I.idinc_taxable, -- pagamento
				sum(I.taxable_euro)
			from invoice IV
			join invoicedetailview I 	on IV.idinvkind = I.idinvkind and IV.yinv = I.yinv and IV.ninv = I.ninv
			JOIN invoicekind IK
				ON I.idinvkind = IK.idinvkind
			where I.idinc_taxable is not null  
				and isnull(IV.flag_enable_split_payment,'N') = 'S'
				AND ISNULL(I.rounding,'N') <>'S' 			
				and (isnull(I.flagbit,0) & 4) = 0
				--AND EXISTS (SELECT * FROM ivaregister IRG 
				--			WHERE IRG.idinvkind = I.idinvkind
				--			AND IRG.yinv = I.yinv
				--			AND IRG.ninv = I.ninv 
				--			AND IRG.idivaregisterkind = @idivaregisterkind_ssn)  
				AND IV.ssntipospesa IS NOT NULL 
				AND YEAR(I.adate) = @ayear
				AND (IK.flag & 1)<> 0 --> Vendita
				AND isnull(I.rowtotal,0) <> 0  -- saltiamo le righe di importo 0
				AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
			group by I.idinvkind, I.yinv, I.ninv, I.idinc_taxable
			
		INSERT INTO #dati(
			idinvkind, yinv, ninv,
		-- PAGAMENTO
			importopagato,
			kpro,
			datapagamento
		)
		select 
			I.idinvkind, I.yinv, I.ninv,
			-- ImportoTotaleDocumento:
			sum(ID.amount),
			Elast.kpro,
			T.transmissiondate
		from invoiceview I 
		join #contabilizzazioni ID 			on ID.idinvkind = I.idinvkind and ID.yinv = I.yinv and ID.ninv = I.ninv
		join income E1			on E1.idinc = ID.idinc
		JOIN incomelink			ON incomelink.idchild = E1.idinc
		JOIN income Incfinphase		on incomelink.idparent = Incfinphase.idinc and Incfinphase.nphase = @finphase
		join incomelast Elast			on E1.idinc = Elast.idinc
		JOIN proceeds P			ON P.kpro = Elast.kpro
		JOIN proceedstransmission T		ON T.kproceedstransmission = P.kproceedstransmission
		group by I.idinvkind, I.yinv, I.ninv,I.idreg, Elast.kpro, T.transmissiondate

SELECT 
	I.idinvkind, I.yinv, I.ninv, ID.rownum,
--idSpesa : pIva + dataEmissione + numDocumentoFiscale
	--@pIva as pIva,
	I.docdate as dataEmissione, 
	--numDocumentoFiscale : dispositivo +  NumDocumento
	1 as dispositivo,
	substring(I.doc,1,20) as NumDocumento,		
-- dataPagamento
	ID2.datapagamento,
-- flagPagamentoAnticipato
	case when (ID2.datapagamento<I.docdate) then 1 else 0 end as flagPagamentoAnticipato,
-- flagoperazione
	'I' as flagOperazione, -- Inserimento
-- cfcittadino
	R.cf,
	I.ssntipospesa,-- tipospesa
	CASE I.ssnflagtipospesa --flagTipoSpesa: “1” con tipo TK (ticket di pronto soccorso); “2” con tipo SR (visita in intramoenia). ESSENDO FACOLTTIVO, LO SALTIAMO
		WHEN 'T' THEN '1'
		WHEN 'V' THEN '2'
		ELSE null
	END as ssnflagtipospesa, 
	case when isnull(I.flag_reverse_charge,'N')='S' then (ID.taxable_euro) else  (ID.rowtotal) end as importo
FROM invoice I
JOIN invoicedetailview ID
	on I.idinvkind = ID.idinvkind and I.yinv = ID.yinv and I.ninv = ID.ninv             
JOIN #dati ID2
	on I.idinvkind = ID2.idinvkind and I.yinv = ID2.yinv and I.ninv = ID2.ninv             
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN registry R
	on R.idreg = I.idreg
WhERE  YEAR(I.adate) = @ayear
	AND (IK.flag & 1)<> 0 --> Vendita
	AND isnull(ID.rowtotal,0) <> 0  -- saltiamo le righe di importo 0
	AND ISNULL(ID.rounding,'N') <>'S'  --salta i dettagli di arrotondamento
	and (isnull(ID.flagbit,0) & 4) = 0
	AND (@idsor01 IS NULL OR I.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR I.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR I.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR I.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR I.idsor05 = @idsor05)
end

GO

 
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 