
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_elenco_registroiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_elenco_registroiva]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 

CREATE  PROCEDURE rpt_elenco_registroiva
	@idivaregisterkind int,
	@year int,
	@month int,
	@official char(1),
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int = null
AS BEGIN
--	exec rpt_elenco_registroiva 5, 2009, 10, 'N' -- Vendite 
--	exec rpt_elenco_registroiva 1, 2009, 11, 'N' -- Acquisti
--	exec rpt_elenco_registroiva 1, 2011, 3, 'N' 

declare @DenominazioneUniversita varchar(50)
select @DenominazioneUniversita = paramvalue from generalreportparameter where idparam='DenominazioneUniversita'


IF @month IS NULL OR @month < 1
BEGIN
	SET @month = 1
END
IF @month > 12
BEGIN
	SET @month = 12
END
DECLARE @registerclass char(1)
SELECT @registerclass = registerclass
FROM ivaregisterkind
WHERE idivaregisterkind = @idivaregisterkind
DECLARE @monthname varchar(20)
SELECT @monthname = title FROM monthname WHERE code = @month
CREATE TABLE #invoicedet
(
	idinvkind int,		
	yinv int,
	ninv int,

	ivaregisterdescr varchar(50),
	nivaregister int,
	registry varchar(100),
	totaldoc decimal(19,2),

	idinvkinddescr varchar(50),
	doc varchar(50),
	docdate smalldatetime,
	registrationdate smalldatetime,
	unifiedivaregisterkind varchar(50),
	unifiedninv int, 

	flagintracom char(1),
	registerclass char(1),	--tipo registro A/V
	kind char(1),			--tipo fattura A/V
	flagvariation char(1),
	flag_enable_split_payment char(1)
)
-- Fatture di Acquisto / Vendita
INSERT INTO #invoicedet
(
	idinvkind,		
	yinv,
	ninv,

	ivaregisterdescr,
	nivaregister,
	registry,
	totaldoc,

	idinvkinddescr,
	doc,
	docdate,
	registrationdate,
	unifiedivaregisterkind ,
	unifiedninv, 

	flagintracom, 
	registerclass ,	--tipo registro A/V
	kind ,			--tipo fattura A/V
	flagvariation,
	flag_enable_split_payment
)
	SELECT
		invoice.idinvkind,		
		invoice.yinv,
		invoice.ninv,
		ivaregisterkind.description,
		ivaregister.nivaregister,
		case when isnull(invoice.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end, 
			CONVERT(decimal(19,2),
				SUM(
					ROUND(invoicedetail.taxable * invoicedetail.npackage * 
					  CONVERT(decimal(19,10),invoice.exchangerate) *
					  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
					 )
				   )
				) +
			ISNULL(SUM(invoicedetail.tax),0),
		invoicekind.description AS idinvkinddescr,
		invoice.doc,
		invoice.docdate,
		invoice.adate AS registrationdate,
		unifiedivaregisterkind.description as unifiedivaregisterkind,
		unifiedivaregister.unifiedninv,
		invoice.flagintracom,
		ivaregisterkind.registerclass,		--tipo registro (A/V)
		CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
			 ELSE 'V'
		END ,		--tipo fattura (A/V)
		CASE
			WHEN (invoicekind.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END,
		invoice.flag_enable_split_payment 	
	FROM ivaregister
	JOIN invoice
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind 
	JOIN registry
		ON invoice.idreg = registry.idreg
	JOIN invoicedetail
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	left outer join unifiedivaregister
		ON unifiedivaregister.idinvkind = invoice.idinvkind
		AND unifiedivaregister.yinv = invoice.yinv
		AND unifiedivaregister.ninv = invoice.ninv
	left outer join unifiedivaregisterkind
		ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND ivaregister.yivaregister = @year
		AND ivaregisterkind.registerclass = @registerclass
		AND MONTH(invoice.adate) = @month
		AND YEAR(invoice.adate) = @year
		AND @registerclass IN ('V','A')
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)	
	GROUP BY ivaregisterkind.description, ivaregister.yivaregister, ivaregister.nivaregister,invoice.flagintracom,ivaregisterkind.registerclass, 
	(invoicekind.flag & 1), registry.title,
	invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.doc, invoice.docdate, invoice.adate,
	invoicekind.description, (invoicekind.flag&4), 
	unifiedivaregisterkind.description, unifiedivaregister.unifiedninv, invoice.flag_enable_split_payment ,
	invoice.idsor01,invoice.idsor02, invoice.idsor03, invoice.idsor04, invoice.idsor05, isnull(invoice.autoinvoice,'N')	

-- Stessa INSERT precedente ma interroga SOLO le autofatture senza dettagli:
-- Fatture di Acquisto / Vendita
INSERT INTO #invoicedet
(
	ivaregisterdescr,
	nivaregister,
	registry,
	totaldoc,

	idinvkinddescr,
	doc,
	docdate,
	registrationdate,
	unifiedivaregisterkind ,
	unifiedninv, 

	flagintracom, 
	registerclass ,	--tipo registro A/V
	kind ,			--tipo fattura A/V
	flagvariation,
	flag_enable_split_payment 	
)
	SELECT
		ivaregisterkind.description,
		ivaregister.nivaregister,
		case when isnull(M.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end,
			CONVERT(decimal(19,2),
				SUM(
					ROUND(invoicedetail.taxable * invoicedetail.npackage * 
					  CONVERT(decimal(19,10),invoice.exchangerate) *
					  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
					 )
				   )
				) +
			ISNULL(SUM(invoicedetail.tax),0),
		invoicekind.description AS idinvkinddescr,
		invoice.doc,
		invoice.docdate,
		M.adate AS registrationdate,
		unifiedivaregisterkind.description as unifiedivaregisterkind,
		unifiedivaregister.unifiedninv,
		M.flagintracom,
		ivaregisterkind.registerclass,		--tipo registro (A/V)
		CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
			 ELSE 'V'
		END ,		--tipo fattura (A/V)
		CASE
			WHEN (invoicekind.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END ,
		invoice.flag_enable_split_payment 		
	FROM invoice
	JOIN invoice M --> fattura Madre
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind 
	JOIN registry
		ON M.idreg = registry.idreg
	left outer join unifiedivaregister
		ON unifiedivaregister.idinvkind = invoice.idinvkind
		AND unifiedivaregister.yinv = invoice.yinv
		AND unifiedivaregister.ninv = invoice.ninv
	left outer join unifiedivaregisterkind
		ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND ivaregister.yivaregister = @year
		AND ivaregisterkind.registerclass = @registerclass
		AND MONTH(invoice.adate) = @month
		AND YEAR(invoice.adate) = @year
		AND @registerclass IN ('V','A')
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)
	GROUP BY ivaregisterkind.description, ivaregister.yivaregister, ivaregister.nivaregister, M.flagintracom, ivaregisterkind.registerclass, 
	(invoicekind.flag & 1), registry.title,
	invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.doc, invoice.docdate, M.adate,
	invoicekind.description, (invoicekind.flag&4),
	unifiedivaregisterkind.description, unifiedivaregister.unifiedninv, invoice.flag_enable_split_payment,
	invoice.idsor01,invoice.idsor02, invoice.idsor03, invoice.idsor04, invoice.idsor05, isnull(M.autoinvoice,'N')	

-- Protocollo Generale - Fatture
INSERT INTO #invoicedet
(
	ivaregisterdescr,
	nivaregister,
	registry,
	totaldoc,

	idinvkinddescr,
	doc,
	docdate,
	registrationdate,
	unifiedivaregisterkind ,
	unifiedninv, 

	flagintracom,
	registerclass ,	--tipo registro P
	kind, 			--tipo fattura A/V
	flagvariation,
	flag_enable_split_payment 	
)

	SELECT
	ivaregisterkind.description,
	ivaregister.nivaregister,
	case when isnull(invoice.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end,
			CONVERT(decimal(19,2),
				SUM(
				    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
					  CONVERT(decimal(19,10),invoice.exchangerate) *
					  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
					 )
				   )
				) 
			+ ISNULL(SUM(invoicedetail.tax),0)	,
	invoicekind.description,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	unifiedivaregisterkind.description,
	unifiedivaregister.unifiedninv,
	invoice.flagintracom,
	ivaregisterkind.registerclass,		--tipo registro 
	CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
		 ELSE 'V'
	END ,	--tipo fattura (A/V)
	CASE
		WHEN (invoicekind.flag & 4) = 0 THEN 'N'
		ELSE 'S'
	END,
	invoice.flag_enable_split_payment 	
	FROM ivaregister
	JOIN invoice
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind 
	JOIN registry
		ON invoice.idreg = registry.idreg
	JOIN invoicedetail
		ON invoice.idinvkind = invoicedetail.idinvkind
		AND invoice.yinv = invoicedetail.yinv
		AND invoice.ninv = invoicedetail.ninv
	left outer join unifiedivaregister
		ON unifiedivaregister.idinvkind = invoice.idinvkind
		AND unifiedivaregister.yinv = invoice.yinv
		AND unifiedivaregister.ninv = invoice.ninv
	left outer join unifiedivaregisterkind
		ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND ivaregister.yivaregister = @year
		AND ivaregisterkind.registerclass = @registerclass
		AND MONTH(invoice.adate) = @month
		AND YEAR(invoice.adate) = @year
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)
AND @registerclass IN ('P')
	GROUP BY ivaregisterkind.description, ivaregisterkind.registerclass,ivaregister.yivaregister, ivaregister.nivaregister,invoice.flagintracom, registry.title,
	invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.doc, invoice.docdate, invoice.adate,
	invoicekind.description, (invoicekind.flag&4),
	(invoicekind.flag&1),
	unifiedivaregisterkind.description, unifiedivaregister.unifiedninv, invoice.flag_enable_split_payment 	,
	invoice.idsor01,invoice.idsor02, invoice.idsor03, invoice.idsor04, invoice.idsor05, isnull(invoice.autoinvoice,'N')	

-- Stessa INSERT precedente ma interroga SOLO le autofatture senza dettagli

-- Protocollo Generale - Fatture
INSERT INTO #invoicedet
(
	ivaregisterdescr,
	nivaregister,
	registry,
	totaldoc,

	idinvkinddescr,
	doc,
	docdate,
	registrationdate,
	unifiedivaregisterkind ,
	unifiedninv, 

	flagintracom,
	registerclass ,	--tipo registro P
	kind, 			--tipo fattura A/V
	flagvariation,
	flag_enable_split_payment 	
)

	SELECT
	ivaregisterkind.description,
	ivaregister.nivaregister,
	case when isnull(M.autoinvoice,'N')='S' then @DenominazioneUniversita else registry.title end,
			CONVERT(decimal(19,2),
				SUM(
				    ROUND(invoicedetail.taxable * invoicedetail.npackage * 
					  CONVERT(decimal(19,10),invoice.exchangerate) *
					  (1 - CONVERT(decimal(19,6),ISNULL(invoicedetail.discount, 0))),2
					 )
				   )
				) 
			+ ISNULL(SUM(invoicedetail.tax),0)	,
	invoicekind.description,
	invoice.doc,
	invoice.docdate,
	M.adate,
	unifiedivaregisterkind.description,
	unifiedivaregister.unifiedninv,
	M.flagintracom,
	ivaregisterkind.registerclass,		--tipo registro 
	CASE WHEN (invoicekind.flag & 1)=0 THEN 'A'
		 ELSE 'V'
	END ,	--tipo fattura (A/V)
	CASE
		WHEN (invoicekind.flag & 4) = 0 THEN 'N'
		ELSE 'S'
	END,
	invoice.flag_enable_split_payment 	
	FROM invoice
	JOIN invoice M --> fattura Madre
		ON invoice.idinvkind_real = M.idinvkind
		AND invoice.yinv_real = M.yinv
		AND invoice.ninv_real = M.ninv
	join invoicedetail 
		ON invoicedetail.idinvkind = M.idinvkind
		AND invoicedetail.yinv = M.yinv
		AND invoicedetail.ninv = M.ninv
	JOIN ivaregister
		ON invoice.idinvkind = ivaregister.idinvkind
		AND invoice.yinv = ivaregister.yinv
		AND invoice.ninv = ivaregister.ninv
	JOIN invoicekind
		ON invoicekind.idinvkind = invoice.idinvkind
	JOIN ivaregisterkind
		ON ivaregisterkind.idivaregisterkind = ivaregister.idivaregisterkind 
	JOIN registry
		ON M.idreg = registry.idreg
	left outer join unifiedivaregister
		ON unifiedivaregister.idinvkind = invoice.idinvkind
		AND unifiedivaregister.yinv = invoice.yinv
		AND unifiedivaregister.ninv = invoice.ninv
	left outer join unifiedivaregisterkind
		ON unifiedivaregisterkind.idivaregisterkind=unifiedivaregister.idivaregisterkind
	WHERE ivaregisterkind.idivaregisterkind = @idivaregisterkind
		AND ivaregister.yivaregister = @year
		AND ivaregisterkind.registerclass = @registerclass
		AND MONTH(invoice.adate) = @month
		AND YEAR(invoice.adate) = @year
		AND @registerclass IN ('P')
		AND (@idsor01 IS NULL OR invoice.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR invoice.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR invoice.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR invoice.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR invoice.idsor05 = @idsor05)
	GROUP BY ivaregisterkind.description, ivaregisterkind.registerclass,ivaregister.yivaregister, ivaregister.nivaregister,M.flagintracom, registry.title,
	invoice.idinvkind, invoice.yinv, invoice.ninv, invoice.doc, invoice.docdate, M.adate,
	invoicekind.description, (invoicekind.flag&4),
	(invoicekind.flag&1),
	unifiedivaregisterkind.description, unifiedivaregister.unifiedninv, invoice.flag_enable_split_payment 	,
	invoice.idsor01,invoice.idsor02, invoice.idsor03, invoice.idsor04, invoice.idsor05, isnull(M.autoinvoice,'N')	


--aggiusta il segno di totaldoc in base a registerclass/kind/flagvariation
-- Se registerclass = P non fa nulla, considera tutto positivio

	update #invoicedet set kind = registerclass,
						totaldoc = - totaldoc
		 where registerclass<>kind 
		AND (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
			) = 1
			AND @registerclass in ('A','V')

			
UPDATE #invoicedet Set totaldoc = - totaldoc
		where flagvariation='S'
			AND @registerclass in ('A','V')

	--Imposta come "acquisti" e cambia il segno le fatture contabilizzate in entrata ove ci siano due registri collegati. 
	-- Infatti queste vanno trattate come se fossero note di variazione
	update #invoicedet set kind = 'A',
		  totaldoc = - totaldoc
		 where 
				 (select count(*) from invoicekindregisterkind  IRK
				join ivaregisterkind RK on RK.idivaregisterkind=IRK.idivaregisterkind
				 where  IRK.idinvkind = #invoicedet.idinvkind
					and RK.registerclass<>'P'
				) = 2
			and kind<>'A'
			AND @registerclass in ('A','V')

-- Controllare se nella SELECT finale vada fatto il SUM, mi sa che male non fa
SELECT
	ivaregisterdescr,
	@monthname AS monthname,
	@year AS ayear,
	nivaregister,
	registry,
	totaldoc,

	idinvkinddescr,
	doc,
	docdate,
	registrationdate,
	unifiedivaregisterkind,
	unifiedninv,
	flag_enable_split_payment 		 
FROM #invoicedet
ORDER BY ivaregisterdescr,nivaregister
END
GO
