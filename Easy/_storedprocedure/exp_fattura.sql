
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fattura]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fattura]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [exp_fattura]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idreg int ,
	@idinvkind int,
	@ninv_start int,
	@ninv_stop int
)
AS BEGIN
DECLARE @FATTURE TABLE(
		adate smalldatetime,
		invoicekind varchar(50),
		yinv smallint,
		ninv int,
		idreg int,
		registry varchar(100),
		cf varchar(16),
		p_iva varchar(15),	
		invoice varchar(150),
		doc varchar(35),
		docdate smalldatetime,
		detaildescription varchar(150),
		taxable_euro decimal(19,2),
		ivakind varchar(50),	
		rate decimal(19,6),
		tax decimal(19,2),
		pagato decimal(19,2),
		dapagare decimal(19,2),
		ypay_taxable smallint,
		npay_taxable int,
		ypay_tax smallint,
		npay_tax int,
		ycon smallint,
		ncon int,
		yoperationps smallint,
		noperationps int,
		idpettycash int
)


-- Fatture di ACQUISTO contabilizzate col form di spesa
INSERT INTO @FATTURE (adate ,
		invoicekind,
		yinv,
		ninv,
		idreg ,
		registry,
		cf ,
		p_iva,	
		invoice,
		doc,
		docdate ,
		detaildescription,
		taxable_euro ,
		ivakind,	
		rate ,
		tax,
		pagato ,
		dapagare ,
		ypay_taxable ,
		npay_taxable ,
		ypay_tax ,
		npay_tax ,
		ycon ,
		ncon )
	SELECT 
		invoice.adate,
		invoicekind.description,
		invoice.yinv ,
		invoice.ninv ,
		registry.idreg,
		registry.title,
		registry.cf ,
		registry.p_iva,
		invoice.description,
		invoice.doc ,
		invoice.docdate ,
		ID.detaildescription ,
		isnull(ID.taxable_euro,0) ,
		ivakind.description ,	
		ivakind.rate ,
		isnull(ID.tax,0) ,
		case	
			when ID.idexp_taxable IS NULL and  ID.idexp_iva IS  NULL then 0
			when ID.idexp_taxable IS not NULL and  ID.idexp_iva IS  not NULL then isnull(ID.taxable_euro,0) + isnull(ID.tax,0)
			when ID.idexp_taxable IS NULL and  ID.idexp_iva IS not NULL then isnull(ID.tax,0)
			when ID.idexp_taxable IS not NULL and  ID.idexp_iva IS  NULL then isnull(ID.taxable_euro,0)
		end	,
		case
			when ID.idexp_taxable IS not NULL and  ID.idexp_iva IS not NULL then 0	
			when ID.idexp_taxable IS NULL and  ID.idexp_iva IS  NULL then isnull(ID.taxable_euro,0) + isnull(ID.tax,0)
			when ID.idexp_taxable IS NULL and  ID.idexp_iva IS not NULL then isnull(ID.taxable_euro,0)
			when ID.idexp_taxable IS not NULL and  ID.idexp_iva IS  NULL then isnull(ID.tax,0)
		end	,
		P1.ypay,
		P1.npay,
		P2.ypay,
		P2.npay,
		null ,
		null 
		FROM invoice
		JOIN invoicedetailview ID
			ON invoice.idinvkind = ID.idinvkind
			AND invoice.yinv = ID.yinv
			AND invoice.ninv = ID.ninv
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = ID.idivakind
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg
		LEFT OUTER JOIN expenselast EL1
			on EL1.idexp = ID.idexp_taxable
		LEFT OUTER JOIN payment P1
			ON P1.kpay = EL1.kpay

		LEFT OUTER JOIN expenselast EL2
			on EL2.idexp = ID.idexp_iva
		LEFT OUTER JOIN payment P2
			ON P2.kpay = EL2.kpay

		WHERE invoice.yinv = @ayear
			AND (invoice.idreg = @idreg or @idreg is null)
			AND (invoice.adate BETWEEN @start AND @stop 
				or invoice.adate<= @stop and @stop is not null and @start is null
				or invoice.adate>= @start and @start is not null and @stop is null
				or @start is null and @stop is null
				)
			AND ((invoicekind.flag&1)=0)  -- Fatture di Acquisto 
			AND (invoicekind.idinvkind = @idinvkind or @idinvkind is null)
			AND (invoice.ninv BETWEEN @ninv_start AND @ninv_stop 
				or invoice.ninv<= @ninv_stop and @ninv_stop is not null and @ninv_start is null
				or invoice.ninv>= @ninv_start and @ninv_start is not null and @ninv_stop is null
				or @ninv_start is null and @ninv_stop is null 
				)
			AND NOT EXISTS (SELECT * FROM profservice 
							WHERE profservice.idinvkind=invoice.idinvkind 
								and profservice.yinv=invoice.yinv 
								and profservice.ninv=invoice.ninv)

			AND NOT EXISTS (SELECT * FROM  pettycashoperationinvoice 
				WHERE  pettycashoperationinvoice.idinvkind = invoice.idinvkind 
				and pettycashoperationinvoice.yinv = invoice.yinv 
				and pettycashoperationinvoice.ninv = invoice.ninv)

-- Fatture di ACQUISTO contabilizzate col Fondo Economale
INSERT INTO @FATTURE(adate ,
		invoicekind,
		yinv,
		ninv,
		idreg ,
		registry,
		cf ,
		p_iva,	
		invoice,
		doc,
		docdate ,
		detaildescription,
		taxable_euro ,
		ivakind,	
		rate ,
		tax,
		pagato ,
		dapagare ,
		ypay_taxable ,
		npay_taxable ,
		ypay_tax ,
		npay_tax ,
		ycon ,
		ncon ,
		yoperationps,
		noperationps,
		idpettycash
		)
	SELECT 
		invoice.adate ,
		invoicekind.description ,
		invoice.yinv ,
		invoice.ninv ,
		registry.idreg,
		registry.title,
		registry.cf ,
		registry.p_iva ,
		invoice.description ,
		invoice.doc,
		invoice.docdate,
		ID.detaildescription,
		isnull(ID.taxable_euro,0),
		ivakind.description ,	
		ivakind.rate,
		isnull(ID.tax,0) ,
		isnull(ID.taxable_euro,0) + isnull(ID.tax,0) ,
		null ,
		null ,
		null ,
		null ,
		null ,
		null ,
		null ,
		pettycashoperationinvoice.yoperation,
		pettycashoperationinvoice.noperation,
		pettycashoperationinvoice.idpettycash
		FROM invoice
		JOIN invoicedetailview ID
			ON invoice.idinvkind = ID.idinvkind
			AND invoice.yinv = ID.yinv
			AND invoice.ninv = ID.ninv
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = ID.idivakind
		JOIN  pettycashoperationinvoice 
			ON pettycashoperationinvoice.idinvkind = invoice.idinvkind 
			and pettycashoperationinvoice.yinv = invoice.yinv 
			and pettycashoperationinvoice.ninv = invoice.ninv
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg

		WHERE invoice.yinv = @ayear
			AND (invoice.idreg = @idreg or @idreg is null)
			AND (invoice.adate BETWEEN @start AND @stop 
				or invoice.adate<= @stop and @stop is not null and @start is null
				or invoice.adate>= @start and @start is not null and @stop is null
				or @start is null and @stop is null
				)
			AND ((invoicekind.flag&1)=0)  -- Fatture di Acquisto 
			AND (invoicekind.idinvkind = @idinvkind or @idinvkind is null)
			AND (invoice.ninv BETWEEN @ninv_start AND @ninv_stop 
				or invoice.ninv<= @ninv_stop and @ninv_stop is not null and @ninv_start is null
				or invoice.ninv>= @ninv_start and @ninv_start is not null and @ninv_stop is null
				or @ninv_start is null and @ninv_stop is null 
				)

-- Fatture di VENDITA
INSERT INTO @FATTURE(adate ,
		invoicekind,
		yinv,
		ninv,
		idreg ,
		registry,
		cf ,
		p_iva,	
		invoice,
		doc,
		docdate ,
		detaildescription,
		taxable_euro ,
		ivakind,	
		rate ,
		tax,
		pagato ,
		dapagare ,
		ypay_taxable ,
		npay_taxable ,
		ypay_tax ,
		npay_tax ,
		ycon ,
		ncon )
	SELECT 
		invoice.adate AS 'DataRegistrazione',
		invoicekind.description AS 'TipoDoc',
		invoice.yinv AS 'EsercDoc',
		invoice.ninv AS 'NumDoc',
		registry.idreg as 'CodiceAnagrafica',
		registry.title AS 'Denominazione',
		registry.cf AS 'CodiceFiscale',
		registry.p_iva AS 'PartitaIva',
		invoice.description AS 'DescrizioneDoc',
		invoice.doc AS 'DocumentoRif',
		invoice.docdate AS 'DataDocumentoRif',
		ID.detaildescription AS 'DescrizioneDett',
		isnull(ID.taxable_euro,0) AS 'Imponibile',
		ivakind.description AS 'TipoIVA',	
		ivakind.rate AS 'AliquotaIVA',
		isnull(ID.tax,0) AS 'IVAApplicata',
		case	
			when ID.idinc_taxable IS not NULL and  ID.idinc_iva IS  not NULL then isnull(ID.taxable_euro,0) + isnull(ID.tax,0)
			when ID.idinc_taxable IS NULL and  ID.idinc_iva IS not NULL then isnull(ID.tax,0)
			when ID.idinc_taxable IS not NULL and  ID.idinc_iva IS  NULL then isnull(ID.taxable_euro,0)
		end	as 'Pagato/Incassato',
		case	
			when ID.idinc_taxable IS NULL and  ID.idinc_iva IS  NULL then isnull(ID.taxable_euro,0) + isnull(ID.tax,0)
			when ID.idinc_taxable IS NULL and  ID.idinc_iva IS not NULL then isnull(ID.taxable_euro,0)
			when ID.idinc_taxable IS not NULL and  ID.idinc_iva IS  NULL then isnull (ID.tax,0)
		end	as 'da Pagare/da Incassare',
		P1.ypro as 'Eserc.Mandato/Reversale Imponibile',
		P1.npro as 'Num.Mandato/Reversale Imponibile',
		P2.ypro as 'Eserc.Mandato/Reversale Iva',
		P2.npro as 'Num.Mandato/Reversale Iva',
		null as 'Es.Contr.Professionale',
		null as 'N.Contr.Professionale'
		FROM invoice
		JOIN invoicedetailview ID
			ON invoice.idinvkind = ID.idinvkind
			AND invoice.yinv = ID.yinv
			AND invoice.ninv = ID.ninv
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = ID.idivakind
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg
		LEFT OUTER JOIN incomelast EL1
			on EL1.idinc = ID.idinc_taxable
		LEFT OUTER JOIN proceeds P1
			ON P1.kpro = EL1.kpro

		LEFT OUTER JOIN incomelast EL2
			on EL2.idinc = ID.idinc_iva
		LEFT OUTER JOIN proceeds P2
			ON P2.kpro = EL2.kpro

		WHERE invoice.yinv = @ayear
			AND (invoice.idreg = @idreg or @idreg is null)
			AND (invoice.adate BETWEEN @start AND @stop 
				or invoice.adate<= @stop and @stop is not null and @start is null
				or invoice.adate>= @start and @start is not null and @stop is null
				or @start is null and @stop is null
				)
			AND ((invoicekind.flag&1)<>0)  -- Fatture di Vendita
			AND (invoicekind.idinvkind = @idinvkind or @idinvkind is null)
			AND (invoice.ninv BETWEEN @ninv_start AND @ninv_stop 
				or invoice.ninv<= @ninv_stop and @ninv_stop is not null and @ninv_start is null
				or invoice.ninv>= @ninv_start and @ninv_start is not null and @ninv_stop is null
				or @ninv_start is null and @ninv_stop is null 
				)

-- Fatture legate a Prestazioni professionali(associazione con la fattura)
INSERT INTO @FATTURE(adate ,
		invoicekind,
		yinv,
		ninv,
		idreg ,
		registry,
		cf ,
		p_iva,	
		invoice,
		doc,
		docdate ,
		detaildescription,
		taxable_euro ,
		ivakind,	
		rate ,
		tax,
		pagato ,
		dapagare ,
		ypay_taxable ,
		npay_taxable ,
		ypay_tax ,
		npay_tax ,
		ycon ,
		ncon )
	SELECT 
		invoice.adate AS 'DataRegistrazione',
		invoicekind.description AS 'TipoDoc',
		invoice.yinv AS 'EsercDoc',
		invoice.ninv AS 'NumDoc',
		registry.idreg as 'CodiceAnagrafica',
		registry.title AS 'Denominazione',
		registry.cf AS 'CodiceFiscale',
		registry.p_iva AS 'PartitaIva',
		invoice.description AS 'DescrizioneDoc',
		invoice.doc AS 'DocumentoRif',
		invoice.docdate AS 'DataDocumentoRif',
		invoicedetail.detaildescription AS 'DescrizioneDett',
		profserviceresidual.taxabletotal AS 'Imponibile',
		ivakind.description AS 'TipoIVA',	
		ivakind.rate AS 'AliquotaIVA',
		profserviceresidual.ivatotal AS 'IVAApplicata',
		profserviceresidual.linkedtotal as 'Pagato/Incassato',
		profserviceresidual.residual as 'da Pagare/da Incassare',
		-- 1 tot, 2 --impos, 3-impon
		CASE WHEN expenseinvoice.movkind in (1,3) then P1.ypay else null end as 'Eserc.Mandato/Reversale Imponibile',
		CASE WHEN expenseinvoice.movkind in (1,3) then P1.npay else null end as 'Num.Mandato/Reversale Imponibile',
		CASE WHEN expenseinvoice.movkind in (1,2) then P1.ypay else null end as 'Eserc.Mandato/Reversale Iva',
		CASE WHEN expenseinvoice.movkind in (1,2) then P1.npay else null end as 'Num.Mandato/Reversale Iva',
		profservice.ycon as 'Es.Contr.Professionale',
		profservice.ncon as 'N.Contr.Professionale'
		FROM invoice
		JOIN invoicedetail
			ON invoice.idinvkind = invoicedetail.idinvkind
			AND invoice.yinv = invoicedetail.yinv
			AND invoice.ninv = invoicedetail.ninv
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = invoicedetail.idivakind
		JOIN profservice
			ON invoice.idinvkind = profservice.idinvkind
			AND invoice.yinv = profservice.yinv
			AND invoice.ninv = profservice.ninv
		JOIN profserviceresidual	
			ON profservice.ycon = profserviceresidual.ycon
			AND profservice.ncon = profserviceresidual.ncon
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg
		--LEFT OUTER JOIN	expenseprofservice 
		--	ON expenseprofservice.ycon = profservice.ycon
		--	and expenseprofservice.ncon = profservice.ncon
		--LEFT OUTER JOIN expenselink
		--	ON expenselink.idparent= expenseprofservice.idexp
		left outer join expenseinvoice
			on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
		LEFT OUTER JOIN expenselast EL1
			--ON expenselink.idchild = EL1.idexp
			on expenseinvoice.idexp = EL1.idexp
		LEFT OUTER JOIN payment P1
			ON P1.kpay = EL1.kpay

		WHERE invoicedetail.ycon is null
			and invoice.yinv = @ayear
			AND (invoice.idreg = @idreg or @idreg is null)
			AND (invoice.adate BETWEEN @start AND @stop 
				or invoice.adate<= @stop and @stop is not null and @start is null
				or invoice.adate>= @start and @start is not null and @stop is null
				or @start is null and @stop is null
				)
			AND ((invoicekind.flag&1)=0)  -- Fatture di Acquisto 
			AND (invoicekind.idinvkind = @idinvkind or @idinvkind is null)
			AND (invoice.ninv BETWEEN @ninv_start AND @ninv_stop 
				or invoice.ninv<= @ninv_stop and @ninv_stop is not null and @ninv_start is null
				or invoice.ninv>= @ninv_start and @ninv_start is not null and @ninv_stop is null
				or @ninv_start is null and @ninv_stop is null 
				)

-- Fatture legate a Prestazioni professionali(associazione col Dettaglio Fattura)
INSERT INTO @FATTURE(adate ,
		invoicekind,
		yinv,
		ninv,
		idreg ,
		registry,
		cf ,
		p_iva,	
		invoice,
		doc,
		docdate ,
		detaildescription,
		taxable_euro ,
		ivakind,	
		rate ,
		tax,
		pagato ,
		dapagare ,
		ypay_taxable ,
		npay_taxable ,
		ypay_tax ,
		npay_tax ,
		ycon ,
		ncon )
	SELECT 
		invoice.adate AS 'DataRegistrazione',
		invoicekind.description AS 'TipoDoc',
		invoice.yinv AS 'EsercDoc',
		invoice.ninv AS 'NumDoc',
		registry.idreg as 'CodiceAnagrafica',
		registry.title AS 'Denominazione',
		registry.cf AS 'CodiceFiscale',
		registry.p_iva AS 'PartitaIva',
		invoice.description AS 'DescrizioneDoc',
		invoice.doc AS 'DocumentoRif',
		invoice.docdate AS 'DataDocumentoRif',
		invoicedetail.detaildescription AS 'DescrizioneDett',
		profserviceresidual.taxabletotal AS 'Imponibile',
		ivakind.description AS 'TipoIVA',	
		ivakind.rate AS 'AliquotaIVA',
		profserviceresidual.ivatotal AS 'IVAApplicata',
		profserviceresidual.linkedtotal as 'Pagato/Incassato',
		profserviceresidual.residual as 'da Pagare/da Incassare',
		-- 1 tot, 2 --impos, 3-impon
		CASE WHEN expenseinvoice.movkind in (1,3) then P1.ypay else null end as 'Eserc.Mandato/Reversale Imponibile',
		CASE WHEN expenseinvoice.movkind in (1,3) then P1.npay else null end as 'Num.Mandato/Reversale Imponibile',
		CASE WHEN expenseinvoice.movkind in (1,2) then P1.ypay else null end as 'Eserc.Mandato/Reversale Iva',
		CASE WHEN expenseinvoice.movkind in (1,2) then P1.npay else null end as 'Num.Mandato/Reversale Iva',
		profservice.ycon as 'Es.Contr.Professionale',
		profservice.ncon as 'N.Contr.Professionale'
		FROM invoice
		JOIN invoicedetail
			ON invoice.idinvkind = invoicedetail.idinvkind
			AND invoice.yinv = invoicedetail.yinv
			AND invoice.ninv = invoicedetail.ninv
		JOIN invoicekind
			ON invoicekind.idinvkind = invoice.idinvkind
		JOIN ivakind
			ON ivakind.idivakind = invoicedetail.idivakind
		JOIN profservice
			ON invoicedetail.ycon = profservice.ycon
			AND invoicedetail.ncon = profservice.ncon
		JOIN profserviceresidual	
			ON profservice.ycon = profserviceresidual.ycon
			AND profservice.ncon = profserviceresidual.ncon
		LEFT OUTER JOIN registry
			ON invoice.idreg = registry.idreg
		--LEFT OUTER JOIN	expenseprofservice 
		--	ON expenseprofservice.ycon = profservice.ycon
		--	and expenseprofservice.ncon = profservice.ncon
		--LEFT OUTER JOIN expenselink
		--	ON expenselink.idparent= expenseprofservice.idexp
		left outer join expenseinvoice
			on profservice.idinvkind = expenseinvoice.idinvkind and profservice.yinv = expenseinvoice.yinv and profservice.ninv = expenseinvoice.ninv
		LEFT OUTER JOIN expenselast EL1
			on expenseinvoice.idexp = EL1.idexp --ON expenselink.idchild = EL1.idexp
		LEFT OUTER JOIN payment P1
			ON P1.kpay = EL1.kpay

		WHERE  invoice.yinv = @ayear
			AND (invoice.idreg = @idreg or @idreg is null)
			AND (invoice.adate BETWEEN @start AND @stop 
				or invoice.adate<= @stop and @stop is not null and @start is null
				or invoice.adate>= @start and @start is not null and @stop is null
				or @start is null and @stop is null
				)
			AND ((invoicekind.flag&1)=0)  -- Fatture di Acquisto 
			AND (invoicekind.idinvkind = @idinvkind or @idinvkind is null)
			AND (invoice.ninv BETWEEN @ninv_start AND @ninv_stop 
				or invoice.ninv<= @ninv_stop and @ninv_stop is not null and @ninv_start is null
				or invoice.ninv>= @ninv_start and @ninv_start is not null and @ninv_stop is null
				or @ninv_start is null and @ninv_stop is null 
				)


SELECT  F.adate as 'DataRegistrazione',
		F.invoicekind as 'Topodoc',
		F.yinv as 'EsercDoc',
		F.ninv as 'NumDoc',
		F.idreg as 'CodiceAnagrafica',
		F.registry as 'Denominazione',
		F.cf as 'CodiceFiscale',
		F.p_iva as 'PartitaIva',	
		F.invoice as 'DescrizioneDoc',
		F.doc as 'DocumentoRif',
		F.docdate as 'DataDocumentoRif',
		F.detaildescription as 'DescrizioneDett',
		sum(F.taxable_euro)  as 'imponibile',
		F.ivakind as 'TipoIVA',	
		F.rate as 'AliquotaIVA',
		sum(F.tax) as 'IVAApplicata',
		sum(F.pagato) as 'Pagato/Incassato',
		sum(F.dapagare) as 'da Pagare/da Incassare',
		F.ypay_taxable as 'Eserc.Mandato/Reversale Imponibile',
		F.npay_taxable as 'Num.Mandato/Reversale Imponibile',
		F.ypay_tax as 'Eserc.Mandato/Reversale Iva',
		F.npay_tax as 'Num.Mandato/Reversale Iva',
		F.ycon  as 'Es.Contr.Professionale',
		F.ncon  as 'N.Contr.Professionale',
		P.description as 'Fondo.Econ',
		F.yoperationps as 'Eserc.Op.Fondo.Econ',
		F.noperationps as 'N.Op.Fondo.Econ'
FROM @FATTURE F
LEFT OUTER JOIN pettycash P
	ON F.idpettycash = P.idpettycash
	GROUP BY F.adate,
	F.invoicekind,
	F.yinv,F.ninv,	F.idreg, F.registry,
	F.cf, F.p_iva, F.invoice,
	F.doc, F.docdate, F.detaildescription, F.ivakind, F.rate,
	F.ypay_taxable, F.npay_taxable, F.ypay_tax, F.npay_tax, F.ycon, F.ncon,
	P.description,	F.yoperationps,	F.noperationps
	order by F.registry, F.adate,F.yinv,F.ninv
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

