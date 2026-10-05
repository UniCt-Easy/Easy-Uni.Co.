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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_documents_partially_proceeds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_documents_partially_proceeds]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--SETUSER 'amministrazione'
 
CREATE    PROCEDURE [exp_documents_partially_proceeds] 
(
	@kind			char(1),		 --- Tipo Visualizzazione --All [A], Fatture [F], Contratto attivo [C]
	@ayear 			int = null,      --- esercizio di creazione del documento, può essere anche assente
	@idestimkind	varchar(50) = null,
	@idinvkind		int = null,
	@idreg			int = null,	     --- codice Anagrafica
	@idsor01		int = null,
	@idsor02		int = null,
	@idsor03		int = null,
	@idsor04		int = null,
	@idsor05		int = null
)

AS BEGIN
 -- EXEC [exp_documents_partially_proceeds] 'C', NULL, NULL, NULL,NULL
	-- EXEC [exp_documents_partially_proceeds] 'A', NULL, NULL, NULL,NULL
	DECLARE @maxincomephase tinyint
	SELECT  @maxincomephase = MAX(nphase) FROM   incomephase 
	DECLARE @nfinphase tinyint -- fase bilancio
	SELECT  @nfinphase = incomeregphase FROM uniconfig
	DECLARE @monofase   char(1) = 'N'
	IF ((SELECT COUNT(*) FROM incomephase)) = 1 SET @monofase = 'S'
	--- definisco esercizio di riferimento Piano dei Conti 
	--- (pari all'esercizio creazione documento se presente, o esercizio corrente) 
	--- per individuare il conto EP associato a causale credito 
	--- DECLARE @ayear_ep int 
	--- SET @ayear_ep = isnull (@ayear,Year(GetDate()))

	--select '@ayear_ep',@ayear_ep
	CREATE TABLE #estimate 
	(
		idestimkind varchar(20),
		estimatekind varchar(150), 
		yestim int, 
		nestim int, 
		description varchar(200),
		expirationkind	varchar(40),
		paymentexpiring	smallint,
		expiring	date,
		idreg  int,
		registry  varchar(150),
		idaccmotivecredit varchar(50),
		taxabletotal  decimal(19,2), --  'Imponibile Totale',
		ivatotal decimal(19,2),	   -- 'Iva Totale',
		linkedimpon decimal(19,2), --'Contab. Imponibile',
		linkedimpos decimal(19,2), --'Contab. IVA',
		linkedestim decimal(19,2), --'Contab. Totale',
		residual  decimal(19,2)  --'Importo non Contabilizzato',
		--collected_amount decimal(19,2),
		--cashed_registered decimal(19,2)
	)

	CREATE TABLE #invoice 
	(
		idinvkind int,
		codeinvkind varchar(20),
		invoicekind varchar(150), 
		yinv int, 
		ninv int, 
		flagsplit char(1),
		description varchar(200),
		expirationkind	varchar(40),
		paymentexpiring	smallint,
		expiring	date,
		idreg  int,
		registry  varchar(150),
		idaccmotivecredit varchar(50),
		taxabletotal  decimal(19,2), --  'Imponibile Totale',
		ivatotal decimal(19,2),		 -- 'Iva Totale',
		linkedimpon decimal(19,2), --'Contab. Imponibile',
		linkedimpos decimal(19,2), --'Contab. IVA',
		linkedestim decimal(19,2), --'Contab. Totale',
		residual decimal(19,2),   --'Importo non Contabilizzato',
		flagvariation char(1)  -- Flag Nota di credito
	)

	CREATE TABLE #estimate_collected
	(
		idestimkind varchar(20),
		yestim int, 
		nestim int, 
		idreg int,
		collected_amount decimal(19,2) 
	)

	CREATE TABLE #invoice_collected
	(
		idinvkind int,
		yinv int, 
		ninv int, 
		collected_amount decimal(19,2) 
	)

	INSERT INTO  #estimate 
	(
		idestimkind,
		estimatekind, 
		yestim, 
		nestim, 
		description,
		expirationkind,
		paymentexpiring,
		expiring,
		idreg,
		registry,
		idaccmotivecredit, 
		taxabletotal, --  'Imponibile Totale',
		ivatotal,	 -- 'Iva Totale',
		linkedimpon, --'Contab. Imponibile',
		linkedimpos, --'Contab. IVA',
		linkedestim, --'Contab. Totale',
		residual  --'Importo non Contabilizzato',
		--collected_amount decimal(19,2),
		--cashed_registered decimal(19,2)
	)
	 SELECT
	 estimateresidual.idestimkind as '#Cod. Tipo contratto attivo',
	 estimateresidual.estimkind as 'Tipo Contratto Attivo',
	 estimateresidual.yestim as 'Eserc. Contratto Attivo',
	 estimateresidual.nestim as 'Num. Contratto Attivo',
	 estimateresidual.description as 'Descrizione',
		expirationkind.description,
		estimate.paymentexpiring, 
		dateadd(day,isnull(estimate.paymentexpiring,0),
		case 
				when (estimate.idexpirationkind=1) then estimate.adate
				when (estimate.idexpirationkind=2) then estimate.docdate
				when (estimate.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(estimate.docdate) ,estimate.docdate)))
				when (estimate.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(estimate.adate) ,estimate.adate)))
				when (estimate.idexpirationkind=5) then estimate.adate
			end
			),
	 estimateresidual.idreg as '#ID Anagrafica',
	 estimateresidual.registry as 'Anagrafica',
	 estimate.idaccmotivecredit as '#ID Causale credito',
	 sum(estimateresidual.taxabletotal) as 'Imponibile Totale',
	 sum(estimateresidual.ivatotal) as 'Iva Totale',
	 sum(estimateresidual.linkedimpon) 'Contab. Imponibile',
	 sum(estimateresidual.linkedimpos) 'Contab. IVA',
	 sum(estimateresidual.linkedestim) 'Contab. Totale',
	 sum(estimateresidual.residual) as 'Importo non Contabilizzato' 
 FROM estimateresidual 
 join estimate on estimateresidual.idestimkind = estimate.idestimkind and estimateresidual.yestim = estimate.yestim and estimateresidual.nestim = estimate.nestim
 left outer join expirationkind	ON estimate.idexpirationkind = expirationkind.idexpirationkind
	WHERE estimateresidual.linktoinvoice = 'N' and estimateresidual.active = 'S'
 AND (estimateresidual.idestimkind = @idestimkind OR @idestimkind is null)
 AND (estimateresidual.idreg = @idreg OR @idreg is null)
 AND (estimateresidual.yestim = @ayear OR @ayear is null)
 AND (@kind = 'C' OR @kind = 'A')  -- Contratti Attivi non Collegabili a fattura
 AND (estimateresidual.idsor01 = @idsor01 OR @idsor01 is null)
 AND (estimateresidual.idsor02 = @idsor02 OR @idsor02 is null)
 AND (estimateresidual.idsor03 = @idsor03 OR @idsor03 is null)
 AND (estimateresidual.idsor04 = @idsor04 OR @idsor04 is null)
 AND (estimateresidual.idsor05 = @idsor05 OR @idsor05 is null)
 GROUP BY 
 	 estimateresidual.idestimkind,
	 estimateresidual.estimkind,
	 estimateresidual.yestim,
	 estimateresidual.nestim,
	 estimateresidual.description,
	 estimateresidual.idreg,
	 estimateresidual.registry,
	 estimate.idaccmotivecredit,
		estimate.idexpirationkind, 
		estimate.adate,
		estimate.docdate,
	 expirationkind.description,
	 estimate.paymentexpiring

 INSERT INTO #invoice 
	(
		idinvkind,
		codeinvkind,
		invoicekind, 
		yinv, 
		ninv, 
		flagsplit,
		description,
		expirationkind,
		paymentexpiring,
		expiring,
		idreg,
		registry,
		idaccmotivecredit,
		taxabletotal,  --'Imponibile Totale',
		ivatotal,	   --'Iva Totale',
		linkedimpon,   --'Contab. Imponibile',
		linkedimpos,   --'Contab. IVA',
		linkedestim,   --'Contab. Totale',
		residual,      --'Importo non Contabilizzato',
		flagvariation  -- 'Flag Nota di credito'
	)
SELECT
	 invoicekind.idinvkind as '#ID Tipo Fattura',
	 invoicekind.codeinvkind as '#Cod. Tipo Fattura',
	 invoicekind.description as 'Tipo Fattura',
	 invoiceincomeresidual.yinv as 'Eserc. Fattura',
	 invoiceincomeresidual.ninv as 'Num. Fattura',
		CASE
								WHEN ISNULL(invoice.flag_enable_split_payment, 'N') = 'S' then 'S' else 'N'
		END,
	 invoiceincomeresidual.description as 'Descrizione',
		expirationkind.description,
		invoice.paymentexpiring, 
				dateadd(day,isnull(invoice.paymentexpiring,0),
				case 
					when (invoice.idexpirationkind=1) then invoice.adate
					when (invoice.idexpirationkind=2) then invoice.docdate
					when (invoice.idexpirationkind=3) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.docdate) ,invoice.docdate)))
					when (invoice.idexpirationkind=4) then DATEADD(day,-1,DATEADD(month,1,DATEADD(day,1-DAY(invoice.adate) ,invoice.adate)))
					when (invoice.idexpirationkind=5) then invoice.adate
					when (invoice.idexpirationkind=6) then invoice.protocoldate
				end
				),
	 invoiceincomeresidual.idreg as '#ID Anagrafica',
	 invoiceincomeresidual.registry as 'Anagrafica',
	 invoice.idaccmotivedebit as '#ID Causale credito',
	 SUM(invoiceincomeresidual.taxabletotal) as 'Imponibile Totale',
	 SUM(invoiceincomeresidual.ivatotal)  as 'Iva Totale',
	 SUM(invoiceincomeresidual.linkedimpon)  'Contab. Imponibile',
	 SUM(invoiceincomeresidual.linkedimpos)  'Contab. IVA',
	 SUM(invoiceincomeresidual.linkeddocum)  'Contab. Totale',
	 SUM(invoiceincomeresidual.residual)  as 'Importo non Incassato',
	 invoiceincomeresidual.flagvariation   as 'Nota di Variazione'
FROM invoiceincomeresidual 
join invoicekind on invoiceincomeresidual.idinvkind = invoicekind.idinvkind
join invoice on invoiceincomeresidual.idinvkind = invoice.idinvkind and invoiceincomeresidual.yinv = invoice.yinv and invoiceincomeresidual.ninv = invoice.ninv
left outer join expirationkind										ON invoice.idexpirationkind = expirationkind.idexpirationkind
WHERE invoiceincomeresidual.residual <> 0 and invoiceincomeresidual.flagbuysell = 'V' and invoiceincomeresidual.active = 'S' and invoiceincomeresidual.flagvariation = 'N'
AND (invoiceincomeresidual.idinvkind = @idinvkind OR @idinvkind is null)
AND (invoiceincomeresidual.idreg = @idreg OR @idreg is null)
AND (invoiceincomeresidual.yinv = @ayear OR @ayear is null)
 AND (@kind = 'I'  OR @kind = 'A')  -- Fattura o tutti
 AND (invoiceincomeresidual.idsor01 = @idsor01 OR @idsor01 is null)
 AND (invoiceincomeresidual.idsor02 = @idsor02 OR @idsor02 is null)
 AND (invoiceincomeresidual.idsor03 = @idsor03 OR @idsor03 is null)
 AND (invoiceincomeresidual.idsor04 = @idsor04 OR @idsor04 is null)
 AND (invoiceincomeresidual.idsor05 = @idsor05 OR @idsor05 is null)
 GROUP BY  invoicekind.idinvkind,
	 invoicekind.codeinvkind,
	 invoicekind.description,
	 invoiceincomeresidual.yinv,
	 invoiceincomeresidual.ninv,
	 invoiceincomeresidual.description,
	 invoiceincomeresidual.idreg,
	 invoiceincomeresidual.registry,
	 invoice.idaccmotivedebit,
	 invoiceincomeresidual.flagvariation,
		expirationkind.description,
		invoice.paymentexpiring, invoice.idexpirationkind,
		invoice.adate, invoice.docdate, invoice.protocoldate,
		invoice.flag_enable_split_payment
 ;
 

 WITH CONTRATTI_NON_CONTABILIZZATI AS
	(
		SELECT  
			idestimkind,
			yestim, 
			nestim, 
			idreg
		FROM #estimate
		WHERE 	
		(linkedimpon +		 --'Contab. Imponibile',
		linkedimpos +		 --'Contab. IVA',
		linkedestim) = 0     --'Contab. Totale',
	)
 	INSERT INTO #estimate_collected
	(
		idestimkind,
		yestim, 
		nestim, 
		idreg,
		collected_amount
	)
	SELECT 
		idestimkind,
		yestim, 
		nestim,
		idreg,
		0 AS  'Importo Incasso' 
	FROM CONTRATTI_NON_CONTABILIZZATI C
	;

	WITH CONTRATTI_CONTABILIZZATI AS
	(
		SELECT  
			idestimkind,
			yestim, 
			nestim, 
			idreg
		FROM #estimate
		WHERE 	
		(linkedimpon +		 --'Contab. Imponibile',
		linkedimpos +		 --'Contab. IVA',
		linkedestim) > 0     --'Contab. Totale',
	)
 	INSERT INTO #estimate_collected
	(
		idestimkind,
		yestim, 
		nestim, 
		idreg,
		collected_amount
	)
	SELECT 
		idestimkind,
		yestim, 
		nestim,
		idreg,
		ISNULL((select  sum(incometotal.curramount)
			FROM incomeyear
			JOIN income
				ON incomeyear.idinc = income.idinc 
			JOIN incometotal
				ON  incomeyear.idinc = incometotal.idinc
				AND incomeyear.ayear = incometotal.ayear		
			JOIN incomelink EL2
				ON EL2.idchild = income.idinc  AND EL2.nlevel = @nfinphase
			JOIN incomeestimate IES
				ON IES.idestimkind = C.idestimkind
				AND IES.yestim = C.yestim
				AND IES.nestim = C.nestim
			where EL2.idparent = IES.idinc
			and income.nphase = @maxincomephase
			and income.idreg = C.idreg
			),0)AS  'Importo Incasso' 
	FROM CONTRATTI_CONTABILIZZATI C
	WHERE @monofase  = 'N'

	UNION ALL 

	SELECT 
		C.idestimkind,
		C.yestim, 
		C.nestim,
		C.idreg,
		(ER.linkedimpon +		 --'Contab. Imponibile',
		ER.linkedimpos +		 --'Contab. IVA',
		ER.linkedestim) AS  'Importo Incasso' 
	FROM CONTRATTI_CONTABILIZZATI C
	JOIN estimateresidual ER ON ER.idestimkind = C.idestimkind AND ER.yestim = C.yestim  AND ER.nestim = C.nestim 
	WHERE @monofase  = 'S'
	;

--SELECT * FROM #invoice	WHERE residual < taxabletotal + ivatotal
--SELECT * FROM #estimate WHERE residual < taxabletotal + ivatotal
--SELECT * FROM #estimate  where idestimkind = 'ContrattiStudenti2' and yestim = 2024 and nestim = 333  and idreg =  141734
--SELECT * FROM #estimate_collected where idestimkind = 'ContrattiStudenti2' and yestim = 2024 and nestim = 333  and idreg =  141734
SELECT  'Fattura' as 'Documento', 
		#invoice.codeinvkind as 'Cod. Tipo Documento',
		#invoice.invoicekind as 'Tipo Documento',
		#invoice.yinv  as 'Esercizio', #invoice.ninv as 'Numero',
		#invoice.idreg as 'Codice Anagrafica',
		#invoice.registry as 'Anagrafica',
		#invoice.description as 'Descrizione',
		#invoice.expirationkind as 'Tipo scad.',
		#invoice.paymentexpiring as 'Giorni Scad.',
		#invoice.expiring as 'Scad.',
		A.codeacc as 'Conto di Credito',
		(#invoice.taxabletotal) as 'Totale Imponibile',
		(#invoice.ivatotal) as 'Totale IVA',
		(#invoice.taxabletotal + 	
						CASE WHEN 
													(ISNULL(#invoice.flagsplit, 'N') = 'S')
						THEN 0 ELSE #invoice.ivatotal 
				  END) as 'Importo incassabile documento',

		(CASE WHEN #invoice.flagvariation = 'S' then -1 else 1 END)*residual  as 'Importo non incassato'  
FROM #invoice 
LEFT OUTER JOIN accmotive AD WITH (NOLOCK)							
ON AD.idaccmotive = #invoice.idaccmotivecredit
LEFT OUTER JOIN accmotivedetail ADT WITH (NOLOCK)							
ON AD.idaccmotive = ADT.idaccmotive AND ADT.ayear = #invoice.yinv
LEFT OUTER JOIN account A  WITH (NOLOCK)							
ON A.idacc  = ADT.idacc  AND A.ayear = #invoice.yinv
WHERE (CASE WHEN #invoice.flagvariation = 'S' then -1 else 1 END)*residual   > 0 
UNION ALL
SELECT
'Contratto attivo' as 'Documento', 
#estimate.idestimkind as 'Cod. Tipo Documento',
#estimate.estimatekind as 'Tipo Documento',
#estimate.yestim  as 'Esercizio', #estimate.nestim as 'Numero',
#estimate.idreg as 'Codice Anagrafica',
#estimate.registry as 'Anagrafica',
#estimate.description as 'Descrizione',
#estimate.expirationkind as 'Tipo scad.',
#estimate.paymentexpiring as 'Giorni Scad.',
#estimate.expiring as 'Scad.',
A.codeacc as 'Conto di Credito',
(#estimate.taxabletotal) as 'Totale Imponibile',
(#estimate.ivatotal) as 'Totale IVA',
(#estimate.taxabletotal + #estimate.ivatotal) as 'Importo incassabile documento',
(#estimate.taxabletotal + #estimate.ivatotal - #estimate_collected.collected_amount) as 'Importo non incassato'  

FROM #estimate_collected 
join #estimate 
	on #estimate_collected.idestimkind = #estimate.idestimkind 
	and #estimate_collected.yestim = #estimate.yestim 
	and #estimate_collected.nestim = #estimate.nestim 
	and #estimate_collected.idreg = #estimate.idreg 
LEFT OUTER JOIN accmotive AD WITH (NOLOCK)							
ON AD.idaccmotive = #estimate.idaccmotivecredit
LEFT OUTER JOIN accmotivedetail ADT WITH (NOLOCK)							
ON AD.idaccmotive = ADT.idaccmotive AND ADT.ayear = #estimate.yestim 
LEFT OUTER JOIN account A  WITH (NOLOCK)							
ON A.idacc  = ADT.idacc  AND A.ayear = #estimate.yestim 
WHERE (#estimate.taxabletotal + #estimate.ivatotal - #estimate_collected.collected_amount) > 0 
ORDER BY 1,3,4,5
drop table #estimate_collected
drop table #estimate
drop table #invoice



END
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
-- EXEC [exp_documents_partially_proceeds] 'C', NULL, NULL, NULL,NULL
-- EXEC [exp_documents_partially_proceeds] 'A', NULL, NULL, NULL,NULL
-- EXEC [exp_documents_partially_proceeds] 'I', NULL, NULL, NULL,NULL

 