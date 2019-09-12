-- CREAZIONE VISTA invoicelinked
IF EXISTS(select * from sysobjects where id = object_id(N'[invoicelinked]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [invoicelinked]
GO

CREATE                                 VIEW [invoicelinked]
	(
	idinvkind,
	codeinvkind,
	invoicekind,
	yinv,
	ninv,
	flag,
	flagbuysell,
	flagvariation,
	idreg,
	registry,
	registryreference,
	description,
	paymentexpiring,
	idexpirationkind,
	idcurrency,
	codecurrency,
	currency,
	exchangerate,
	doc,
	docdate,
	adate,
	packinglistnum,
	packinglistdate,
	--flagintra,
	officiallyprinted,
	txt,
	cu, 
	ct, 
	lu, 
	lt,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05
	)
	AS SELECT
	invoice.idinvkind,
	invoicekind.codeinvkind,
	invoicekind.description,
	invoice.yinv,
	invoice.ninv,
	invoicekind.flag,
	CASE
		WHEN ((invoicekind.flag&1)=0) THEN 'A'--flagbuysell
		WHEN ((invoicekind.flag&1)<>0) THEN 'V'
	END, 
	CASE
		WHEN ((invoicekind.flag&4)=0) THEN 'N'--flagvariation
		WHEN ((invoicekind.flag&4)<>0) THEN 'S'
	END, 
	invoice.idreg,
	registry.title,
	invoice.registryreference,
	invoice.description,
	invoice.paymentexpiring,
	invoice.idexpirationkind,
	invoice.idcurrency,
	currency.codecurrency,
	currency.description,
	invoice.exchangerate,
	invoice.doc,
	invoice.docdate,
	invoice.adate,
	invoice.packinglistnum,
	invoice.packinglistdate,
	--invoice.flagintra,
	invoice.officiallyprinted,
	invoice.txt,
	invoice.cu, 
	invoice.ct, 
	invoice.lu,
	invoice.lt ,
	invoice.idsor01,
	invoice.idsor02,
	invoice.idsor03,
	invoice.idsor04,
	invoice.idsor05 
	FROM invoice (NOLOCK)
	JOIN invoicekind(NOLOCK)
	ON invoicekind.idinvkind = invoice.idinvkind
	JOIN registry (NOLOCK)
	ON registry.idreg = invoice.idreg
	LEFT OUTER JOIN currency (NOLOCK)
	ON currency.idcurrency = invoice.idcurrency
	WHERE EXISTS
		(SELECT * FROM expenseinvoice
		WHERE expenseinvoice.idinvkind = invoice.idinvkind
		AND expenseinvoice.yinv=invoice.yinv
		AND expenseinvoice.ninv=invoice.ninv)


GO
