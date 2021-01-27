
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazioneupb_pluriennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazioneupb_pluriennale]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec [amministrazione].[exp_situazioneupb_pluriennale] 2015, null, 3674, null, null, null, null
CREATE    PROCEDURE exp_situazioneupb_pluriennale
(
	@ayear smallint,
	@idupb varchar(36) = null,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS
BEGIN

set @idupb = isnull(@idupb,'%')
set @idupb = @idupb + '%'

DECLARE @maxphaseexpense tinyint
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase

DECLARE @maxphaseincome tinyint
SELECT @maxphaseincome= MAX(nphase) FROM incomephase

DECLARE @firstday datetime
SET 	@firstday = CONVERT(datetime, '01-01-' + CONVERT(varchar(4),@ayear), 105)
	
	CREATE TABLE #situazione(
		idupb varchar(36),	
		payment decimal(19,2),
		proceeeds decimal(19,2),
		fattven decimal(19,2),
		fattacq decimal(19,2),
		mandateamount decimal(19,2) ,
		estimateamount decimal(19,2),
		prevdispU decimal(19,2),
		impegnato decimal(19,2),
		Accertato decimal (19,2)
		)  

--  Previsione disponibile @ayear-1
-- Ho inserito la previsione disponiile in uscita per quei casi di UPB che hanno una disponibità che non deriva da incassi registrati
	INSERT INTO #situazione( idupb,  prevdispU) 
	select  idupb,  expenseprevavailable
		from upbyearview 
		
	where  (idupb like @idupb )
			AND upbyearview.ayear = (@ayear-1)
			AND (@idsor01 IS NULL OR idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR idsor05 = @idsor05)

	INSERT INTO #situazione( idupb,  impegnato) 
	select  idupb,  SUM(appropriation)
		from upbyearview 
		
	where  (idupb like @idupb )
			AND upbyearview.ayear < @ayear
			AND (@idsor01 IS NULL OR idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR idsor05 = @idsor05)
		GROUP BY idupb

			INSERT INTO #situazione( idupb,  Accertato) 
	select  idupb,  SUM(assessment)
		from upbyearview 
		
	where  (idupb like @idupb )
			AND upbyearview.ayear < @ayear
			AND (@idsor01 IS NULL OR idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR idsor05 = @idsor05)
		GROUP BY idupb

-- Pagamenti pluriennali
	INSERT INTO #situazione( idupb,  payment) 
	select  HPV.idupb,  sum(HPV.curramount)
		from historypaymentview HPV
		join upb 
			on upb.idupb = HPV.idupb	
	where  (HPV.idupb like @idupb )
			and HPV.ymov < @ayear
			--AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	group by HPV.idupb

-- Incassi pluriennali
	INSERT INTO #situazione( idupb,  proceeeds)  
	select  HPV.idupb, sum(HPV.curramount) as amount
		from historyproceedsview HPV
		join upb 
			on upb.idupb = HPV.idupb	
	where  (HPV.idupb like @idupb )
			and HPV.ymov < @ayear
			--AND HPV.competencydate <= @date
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	group by HPV.idupb
-- Documenti attivi non incassati al 31.12.(Anno-1) :
--	A1.Fatture di vendita emesse negli anni precedenti a @ayear non incassate fino al 31.12.(@ayear-1)
--  A2.Contratti Attivi emessi negli anni precedenti a (@ayear) ma non incassati fino al 31.12.(ayear-1)) - Valore iva inclusa


--	A. Fatture di vendita a iva differita, non ancora incassate:
	-- Vengono inseriti tutti i dettagli delle fatture di vendita  (incluse note di variazione)
	-- la cui REVERSALE associata NON è stata EMESSA al 31/12/@ayear-1 
	--	e aventi data competenza del dettaglio NULL
	INSERT INTO #situazione(
		idupb,
		fattven
	)
SELECT
		IDET.idupb,
		ISNULL(IDET.tax,0)					
		+ ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) 
	FROM invoice I
	join invoicedetail IDET 		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv		AND IDET.ninv=I.ninv	
	JOIN invoicekind IK				ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind		AND IR.yinv = I.yinv		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN upb 
		on IDET.idupb = upb.idupb
	left outer JOIN proceedsemitted PE1		ON PE1.idinc = IDET.idinc_taxable 
	WHERE ((IK.flag&1) <> 0)--vendita
		and I.yinv < @ayear -- Fatture di anni precedenti
		AND ( PE1.competencydate is null or year(PE1.competencydate)>=@ayear) -- Non incassati al 31/12/@ayear-1
		AND IRK.registerclass<>'P'
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		AND (upb.idupb like @idupb )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

--	Documenti passivi non pagati al 31.12.(Anno-1) 
--	B1.Fatture di acquisto registrate negli anni precedenti a (Anno) ma non pagate fino al 31.12.(anno-1)
--	B2.Contratti Passivi registrati negli anni precedenti a (Anno) ma non pagati fino al 31.12.(anno-1)) - Valore iva inclusa

	-- Vengono inseriti tutti i dettagli delle fatture di acquisto (incluse note di variazione)
	-- il cui mandato associato NON è stato TRASMESSO al 31/12/@ayear-1 
	INSERT INTO #situazione(
		idupb,
		fattacq
	)
	SELECT
		IDET.idupb,
		ISNULL(IDET.tax,0)
		+ ROUND(IDET.taxable * IDET.npackage *  CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ) 
	FROM invoice I
	JOIN invoicedetail IDET		ON IDET.idinvkind=I.idinvkind		AND IDET.yinv=I.yinv	AND IDET.ninv=I.ninv	
	JOIN invoicekind IK 		ON IK.idinvkind = I.idinvkind
	JOIN ivaregister IR			ON IR.idinvkind = I.idinvkind 		AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK	ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN upb ON upb.idupb = IDET.idupb
	left outer 	JOIN paymentcommunicated PC1		ON PC1.idexp = IDET.idexp_taxable
	WHERE 
		 ((IK.flag&1) = 0)-- acquisti
		and I.yinv < @ayear -- Fatture di anni precedenti
		AND (PC1.competencydate is null or year(PC1.competencydate)>= @ayear)-- Non pagati al 31/12/@ayear-1
		AND IRK.registerclass<>'P'				
		AND ISNULL(IDET.rounding,'N') <>'S'
		and (isnull(IDET.flagbit,0) & 4) = 0
		-- la fattura non è contabilizzata da spesa, e non esiste neanche la contabilizzazione dcol fondo PS
		AND NOT exists (SELECT * FROM pettycashoperationinvoice PCOI
					JOIN pettycashoperation PCO			ON PCO.idpettycash = PCOI.idpettycash	AND PCO.yoperation = PCOI.yoperation	AND PCO.noperation = PCOI.noperation 
					WHERE PCOI.idinvkind = I.idinvkind
							AND PCOI.yinv = I.yinv
							AND PCOI.ninv = I.ninv
							AND year(PCO.adate) < @ayear)
		AND (upb.idupb like @idupb )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


--	B2.Contratti Passivi registrati negli anni precedenti a (Anno) ma non pagati fino al 31.12.(anno-1)) - Valore iva inclusa
	-- CONTRATTI PASSIVI : quota MAI CONTABILIZZATA E MAI PAGATA
	insert into #situazione(idupb, mandateamount)
	SELECT
	mandatedetail.idupb,
	--residuo :somma dei dett. ordine non contabilizzati
	CONVERT(DECIMAL(19,2),
		ISNULL(SUM(
		    CASE 
			WHEN  (mandatedetail.idexp_taxable IS  NULL) AND (mandate.flagintracom<>'N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)

			WHEN (mandatedetail.idexp_taxable IS  NULL) AND (mandatedetail.idexp_iva IS  NOT NULL)   AND (mandate.flagintracom='N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)

			WHEN ( mandatedetail.idexp_iva IS NULL) AND (mandatedetail.idexp_taxable IS  NOT NULL) AND (mandate.flagintracom='N')
			THEN
			    ROUND(mandatedetail.tax,2)

			WHEN ( mandatedetail.idexp_iva IS  NULL) AND (mandatedetail.idexp_taxable IS  NULL) AND (mandate.flagintracom='N')
			THEN
			     ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		     	     CONVERT(decimal(19,6),mandate.exchangerate) * 
		     	     (1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2) 
			     +
			     ROUND(mandatedetail.tax,2)
			ELSE   0

		    END
		   ),0)
		)
	FROM mandatedetail 
	JOIN mandate 
  		ON mandatedetail.idmankind = mandate.idmankind
		AND mandatedetail.yman = mandate.yman
  		AND mandatedetail.nman = mandate.nman
	JOIN mandatekind 
		ON mandatekind.idmankind = mandatedetail.idmankind
	join upb	
		on mandatedetail.idupb = upb.idupb
	WHERE mandatedetail.stop is null
		and mandatekind.linktoinvoice = 'N'
		and mandate.yman <@ayear
		and mandate.active='S'
		AND (upb.idupb like @idupb )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY 
		mandatedetail.idupb, mandate.flagintracom

-- CONTRATTI PASSIVI : quota contabilizzata e non PAGATA al 31/12/@ayear - 1
	insert into #situazione(idupb, mandateamount)
	SELECT
	mandatedetail.idupb,
	ROUND(mandatedetail.taxable * ISNULL(mandatedetail.npackage,mandatedetail.number) * 
		CONVERT(decimal(19,6),mandate.exchangerate) * 
		(1 - CONVERT(decimal(19,6),ISNULL(mandatedetail.discount, 0.0))),2)
	FROM mandatedetail 
	JOIN mandate 
  		ON mandatedetail.idmankind = mandate.idmankind
		AND mandatedetail.yman = mandate.yman
  		AND mandatedetail.nman = mandate.nman
	JOIN mandatekind 
		ON mandatekind.idmankind = mandatedetail.idmankind
	join expensemandate
		on expensemandate.idexp = mandatedetail.idexp_taxable
	JOIN expenselink
		ON expenselink.idparent = expensemandate.idexp
	join expenselast 
		on expenselink.idchild = expenselast.idexp
	join upb 
		on upb.idupb = mandatedetail.idupb	
	left outer join historypaymentview HPV
		on HPV.idexp = expenselast.idexp
	where  (upb.idupb like @idupb )
		and mandatekind.linktoinvoice = 'N'
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		and mandatedetail.stop is null
		and mandate.yman <@ayear --  Contratti Passivi registrati negli anni precedenti a (@year) ma non pagati fino al 31.12.(@ayear-1)) 
		AND ( HPV.competencydate is null or year(HPV.competencydate)>=@ayear) 
		and mandate.active='S'

	insert into #situazione(idupb, mandateamount)
		SELECT
		mandatedetail.idupb,
		ROUND(mandatedetail.tax,2)
	FROM mandatedetail 
	JOIN mandate 
  		ON mandatedetail.idmankind = mandate.idmankind
		AND mandatedetail.yman = mandate.yman
  		AND mandatedetail.nman = mandate.nman
	JOIN mandatekind 
		ON mandatekind.idmankind = mandatedetail.idmankind
	join expensemandate
		on expensemandate.idexp = mandatedetail.idexp_iva
	JOIN expenselink
		ON expenselink.idparent = expensemandate.idexp
	join expenselast 
		on expenselink.idchild = expenselast.idexp
	join upb 
		on upb.idupb = mandatedetail.idupb
	left outer join historypaymentview HPV
		on HPV.idexp = expenselast.idexp
	where  (upb.idupb like @idupb )
		and mandatekind.linktoinvoice = 'N'
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		and mandatedetail.stop is null
		and mandate.yman <@ayear --  Contratti Passivi registrati negli anni precedenti a (@year) ma non pagati fino al 31.12.(@ayear-1)) 
		AND ( HPV.competencydate is null or year(HPV.competencydate)>=@ayear) 
		and mandate.active='S'
		AND (mandate.flagintracom='N')

--  A2.Contratti Attivi emessi negli anni precedenti a (@ayear) ma non incassati fino al 31.12.(ayear-1)) - Valore iva inclusa
-- CONTRATTI ATTIVI: quota MAI CONTABILIZZATA E MAI INCASSATA
	insert into #situazione(idupb, estimateamount)
	SELECT
		estimatedetail.idupb,
		--residuo :somma dei dett. ordine non contabilizzati
		CONVERT(DECIMAL(19,2),
			ISNULL(SUM(
				CASE --taxable null iva not null -> residuo = taxable
				WHEN (estimatedetail.idinc_taxable IS  NULL) AND (estimatedetail.idinc_iva IS  NOT NULL or (registry.flag_pa='S'))
				THEN
					 ROUND(estimatedetail.taxable * estimatedetail.number * 
		     			 CONVERT(decimal(19,6),estimate.exchangerate) * 
		     			 (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)

				WHEN ( estimatedetail.idinc_iva IS NULL AND (registry.flag_pa='N' )) AND (estimatedetail.idinc_taxable IS  NOT NULL)
				THEN
					  ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)

				WHEN ( estimatedetail.idinc_iva IS  NULL AND (registry.flag_pa='N')) AND (estimatedetail.idinc_taxable IS  NULL)
				THEN
					 ROUND(estimatedetail.taxable * estimatedetail.number * 
		     			 CONVERT(decimal(19,6),estimate.exchangerate) * 
		     			 (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
					 +
					 ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
				ELSE   0

				END
			   ),0)
			)
	FROM estimatedetail 
	JOIN estimate	ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
	JOIN estimatekind
		ON estimatekind.idestimkind = estimate.idestimkind
	join upb on estimatedetail.idupb = upb.idupb
	LEFT OUTER JOIN registry ON registry.idreg = isnull(estimate.idreg,estimatedetail.idreg)
	WHERE estimatedetail.STOP is null
		AND estimatekind.linktoinvoice = 'N'
		and estimate.yestim< @ayear
		and estimate.active='S'
		AND (upb.idupb like @idupb )
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	GROUP BY estimatedetail.idupb

-- CONTRATTI ATTIVI: contabilizzati e non pagati al 31/12/@ayear - 1
	insert into #situazione(idupb, estimateamount)
	SELECT
	estimatedetail.idupb,
	ROUND(estimatedetail.taxable * estimatedetail.number * 
		     			 CONVERT(decimal(19,6),estimate.exchangerate) * 
		     			 (1 - CONVERT(decimal(19,6),ISNULL(estimatedetail.discount, 0.0))),2)
	FROM estimatedetail 
	JOIN estimate 
  		ON estimatedetail.idestimkind = estimate.idestimkind
		AND estimatedetail.yestim = estimate.yestim
  		AND estimatedetail.nestim = estimate.nestim
	JOIN estimatekind
		ON estimatekind.idestimkind = estimate.idestimkind
	join incomeestimate
		on incomeestimate.idinc = estimatedetail.idinc_taxable
	JOIN incomelink
		ON incomelink.idparent = incomeestimate.idinc
	join incomelast 
		on incomelink.idchild = incomelast.idinc
	join upb 
		on upb.idupb = estimatedetail.idupb	
	left outer join historyproceedsview HPV
		on HPV.idinc = incomelast.idinc
	where  (upb.idupb like @idupb )
		AND estimatekind.linktoinvoice = 'N'
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		and estimatedetail.stop is null
		and estimate.yestim< @ayear --  Contratti Attivi registrati negli anni precedenti a (@year) ma non pagati fino al 31.12.(@ayear-1)) 
		AND ( HPV.competencydate is null or year(HPV.competencydate)>=@ayear) 
		and estimate.active='S'

	insert into #situazione(idupb, estimateamount)
	SELECT
		isnull(estimatedetail.idupb_iva, estimatedetail.idupb),
		ROUND(estimatedetail.tax * CONVERT(decimal(19,6), estimate.exchangerate),2)
	FROM estimatedetail 
	JOIN estimate	
			ON estimatedetail.idestimkind = estimate.idestimkind
			AND estimatedetail.yestim = estimate.yestim
			AND estimatedetail.nestim = estimate.nestim
	JOIN estimatekind
		ON estimatekind.idestimkind = estimate.idestimkind
	join incomeestimate
		on incomeestimate.idinc = estimatedetail.idinc_iva
	JOIN incomelink
		ON incomelink.idparent = incomeestimate.idinc
	join incomelast 
		on incomelink.idchild = incomelast.idinc
	join upb 
		on upb.idupb = isnull(estimatedetail.idupb_iva, estimatedetail.idupb)
	left outer join historyproceedsview HPV
		on HPV.idinc = incomelast.idinc
where  (upb.idupb like @idupb )
	AND estimatekind.linktoinvoice = 'N'
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	and estimatedetail.stop is null
	and year(estimate.adate) <@ayear --  Contratti Attivi registrati negli anni precedenti a (@year) ma non pagati fino al 31.12.(@ayear-1)) 
	AND ( HPV.competencydate is null or year(HPV.competencydate)>=@ayear) 
	and estimate.active='S'

	declare @cmd varchar(4000)

set @cmd = 'select 
		upb.codeupb as ''Cod.UPB'',
		upb.title as ''Descrizione UPB'',
		upb.start as ''Data inizio'',
		upb.stop as ''Data fine'',
		sum(proceeeds) as ''Incassato'',

		sum(fattven) as ''Fatture di vendita emesse fino al 31.12.'+convert(varchar(4),@ayear-1)+' e non incassate al 31.12.'+convert(varchar(4),@ayear-1)+''',
		sum(estimateamount) as ''Contratti Attivi emessi fino al 31.12.'+convert(varchar(4),@ayear-1)+' ma non incassati al 31.12.'+convert(varchar(4),@ayear-1)+''',
		sum(payment) as ''Pagato'',
		sum(fattacq) as ''Fatture di acquisto registrate fino al 31.12.'+convert(varchar(4),@ayear-1)+' ma non pagate al 31.12.'+convert(varchar(4),@ayear-1)+''',
		sum(mandateamount) as ''Contratti Passivi registrati fino al 31.12.'+convert(varchar(4),@ayear-1)+' ma non pagati fino al 31.12.'+convert(varchar(4),@ayear-1)+''',
		ISNULL(sum(proceeeds),0)+  ISNULL(sum(fattven),0) + ISNULL(sum(estimateamount),0) as ''Ricavo Calcolato'', 
		ISNULL(sum(payment),0)+  ISNULL(sum(fattacq),0) + ISNULL(sum(mandateamount),0) as ''Costo Calcolato'', 

		epupbkind.title as ''Codice Tipo UPB'',
		epupbkind.description as ''Descrizione Tipo UPB'',
		ACC_COST.codeacc as''Codice conto Costo'',	ACC_COST.title as ''Conto Costo'',
		ACC_REVENUE.codeacc as''Codice conto Ricavo'',	ACC_REVENUE.title as''Conto Ricavo'' ,
		ACC_DEFERREDCOST.codeacc as ''Codice  Conto Risconto Passivo'',	ACC_DEFERREDCOST.title as ''Conto Risconto Passivo'',
		ACC_ACCRUALS.codeacc as ''Codice conto Rateo Attivo'',	ACC_ACCRUALS.title as ''Conto Rateo Attivo'',
		ACC_RESERVE.codeacc as''Codice conto Riserva'',	ACC_RESERVE.title as ''Conto Riserva'',
		case	when ey.adjustmentkind=''C'' then ''Commessa completata''
				when ey.adjustmentkind=''P'' then ''Percentuale di completamento metodo del costo''
				else null 
		end as ''Tipo assestamento'',
		sum(prevdispU) as ''Previsione disponibile in Uscita al 31.12.'+convert(varchar(4),@ayear-1)+''',
		sum(impegnato) as ''Impegnato (pluriennale) al 31.12.'+convert(varchar(4),@ayear-1)+''',
		sum(accertato) as ''Accertato (pluriennale) al 31.12.'+convert(varchar(4),@ayear-1)+'''

from #situazione
join upb
	on #situazione.idupb = upb.idupb			
left outer join epupbkind
	on upb.idepupbkind = epupbkind.idepupbkind
left outer JOIN epupbkindyear EY 
	on epupbkind.idepupbkind= EY.idepupbkind and EY.ayear = '+convert(varchar(4),@ayear-1)+'
left outer join  account ACC_COST 
	on EY.idacc_cost=ACC_COST.idacc
left outer join  account ACC_REVENUE 
	on EY.idacc_revenue=ACC_REVENUE.idacc
left outer join  account ACC_DEFERREDCOST 
	on EY.idacc_deferredcost=ACC_DEFERREDCOST.idacc
left outer join  account ACC_ACCRUALS 
	on EY.idacc_accruals=ACC_ACCRUALS.idacc
left outer join  account ACC_RESERVE 
	on EY.idacc_reserve=ACC_RESERVE.idacc   
GROUP BY upb.idupb, upb.codeupb,		upb.title,	upb.start,		upb.stop,
		epupbkind.title,
		epupbkind.description,
		ACC_COST.codeacc,	ACC_COST.title,
		ACC_REVENUE.codeacc,	ACC_REVENUE.title,
		ACC_DEFERREDCOST.codeacc ,	ACC_DEFERREDCOST.title,
		ACC_ACCRUALS.codeacc ,	ACC_ACCRUALS.title ,
		ACC_RESERVE.codeacc ,	ACC_RESERVE.title,ey.adjustmentkind
		ORDER BY upb.idupb'
		print @cmd
		exec (@cmd)

END

GO






SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
