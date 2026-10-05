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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_commercialista]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_commercialista]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser setuser 'amministrazione'
--  sp_help bill
--  sp_help mandatedetailview
--  sp_help invoiceview
-- EXEC exp_commercialista 2025
-- print CONVERT(Date, '01/01/'+CONVERT(varchar(4),2023) )

CREATE PROCEDURE [exp_commercialista] 
	@year 	int
AS BEGIN

	Create table #Work
	(
	Esercizio int,
	Num_Sospeso int,
	Banca  Varchar(200),
	DataContabile datetime,
	Causale_EstrattoCC Varchar(200),
	Credito_Debito Varchar(20),
	ImportoCC decimal(19,2),
	Tipo_Documento varchar(150),
	Num_Documento varchar(50),
	Data_Documento date, 
	cupcode varchar(20),
	Cliente_Fornitore varchar(150),
	CodiceFiscale varchar(50),
	Partita_Iva varchar(50),
	Imponibile decimal(19,2),
	Iva decimal(19,2),
	IvaInclusa decimal(19,2),
	Intracomunitaria varchar(1),
	Autofattura varchar(1),
	Split_payment varchar(1),
	Identificativo_Sdi bigint,
	Data_ricezione_sdi date, 
	Ulteriore_Descrizione varchar(250)

	)
	-- Incassi di fatture di vendita con bollette
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, IV.invoicekind, IV.doc, IV.docdate, 
			(SELECT TOP 1 cupcode FROM invoicedetail ID WHERE ID.idinvkind = IV.idinvkind AND ID.yinv = ID.yinv AND ID.ninv = IV.ninv  ),
		IV.registry, IV.cf, IV.p_iva, IV.taxable, IV.tax, IV.total, IV.flagintracom, IV.autoinvoice, IV.flag_auto_split_payment, IV.identificativo_sdi,NULL, I.description   from bill B
	 JOIN incomeview I ON I.nbill = B.nbill and I.ymov = B.ybill
	 JOIN incomeinvoice II ON II.idinc = I.idinc
	 JOIN invoiceview IV ON II.idinvkind = IV.idinvkind AND II.yinv = IV.yinv AND II.ninv = IV.ninv  
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	WHERE B.billkind = 'C'
	AND B.ybill =  @year
 
	-- Incassi senza bollette
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, NULL,NULL,NULL, 
			 NULL,NULL,NULL,  NULL,NULL,NULL, NULL,NULL,NULL, NULL,NULL,NULL, NULL
	from bill B
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	 LEFT JOIN incomeview I ON I.nbill = B.nbill and I.ymov = B.ybill
	WHERE B.billkind = 'C'
	AND B.ybill =  @year
	AND I.nbill IS NULL
 
	-- Incassi di contratti attivi con bollette N.B. Togliere quelli collegabili a fattura!!!!!!!!!!!!!!
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, MD.estimkind, CONVERT(varchar(4),MD.yestim)+'/'+CONVERT(varchar(4),MD.nestim), M.adate, MD.cupcode,
		MD.registry,NULL, NULL, MD.taxable_euro, MD.iva_euro, MD.rowtotal, MD.flagintracom, NULL, NULL, NULL,  NULL, I.description    from bill B
	 JOIN incomeview I ON I.nbill = B.nbill and I.ymov = B.ybill
	 JOIN estimatedetailview MD ON MD.idinc_taxable = I.idinc 
	 JOIN estimate M ON MD.idestimkind = M.idestimkind AND MD.yestim = M.yestim AND MD.nestim = M.nestim
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	WHERE B.billkind = 'C'
	AND B.ybill =  @year

	-- Pagamento di fatture di acquisto con bollette
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, IV.invoicekind, IV.doc, IV.docdate, 
			(SELECT TOP 1 cupcode FROM invoicedetail ID WHERE ID.idinvkind = IV.idinvkind AND ID.yinv = ID.yinv AND ID.ninv = IV.ninv  ),
		IV.registry, IV.cf, IV.p_iva, IV.taxable, IV.tax, IV.total, IV.flagintracom, IV.autoinvoice, IV.flag_auto_split_payment, IV.identificativo_sdi,NULL,I.description    from bill B
	 JOIN expenseview I ON I.nbill = B.nbill and I.ymov = B.ybill
	 JOIN expenseinvoice II ON II.idexp = I.idexp
	 JOIN invoiceview IV ON II.idinvkind = IV.idinvkind AND II.yinv = IV.yinv AND II.ninv = IV.ninv  
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	WHERE B.billkind = 'D'
	AND B.ybill =  @year

	-- Pagamento di contratti passivi con bollette N.B. Togliere quelli collegabili a fattura!!!!!!!!!!!!!!
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, MD.mankind, CONVERT(varchar(4),MD.yman)+'/'+CONVERT(varchar(4),MD.nman), M.adate, MD.cupcode,
		MD.registry,NULL, NULL, MD.taxable_euro, MD.iva_euro, MD.rowtotal, MD.flagintracom, NULL, NULL, NULL, NULL,E.description    from bill B
	 JOIN expenseview E ON E.nbill = B.nbill and E.ymov = B.ybill
	 JOIN expenseview E2 ON E.parentidexp = E2.idexp and E2.ayear = E.ymov
	 JOIN mandatedetailview MD ON MD.idexp_taxable = E2.idexp
	 JOIN mandate M ON MD.idmankind = M.idmankind AND MD.yman = M.yman AND MD.nman = M.nman
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	WHERE B.billkind = 'D'
	AND B.ybill =  @year	

	--INSERT INTO #Work
	--SELECT E.ymov, NULL, T.description, P.transmissiondate, E.description, 'D', -E.Curramount, IV.invoicekind, IV.doc, IV.docdate, 
	--		(SELECT TOP 1 cupcode FROM invoicedetail ID WHERE ID.idinvkind = II.idinvkind AND ID.yinv = II.yinv AND ID.ninv = II.ninv  ),
	--	IV.registry, IV.cf, IV.p_iva, IV.taxable, IV.tax, IV.total, IV.flagintracom, IV.autoinvoice, IV.flag_auto_split_payment, IV.identificativo_sdi, NULL,E.description 
	-- FROM expenseview E 
	-- JOIN paymentview P ON E.kpay = P.kpay
	-- JOIN expenseinvoice II ON II.idexp = E.idexp
	-- JOIN invoiceview IV ON II.idinvkind = IV.idinvkind AND II.yinv = IV.yinv AND II.ninv = IV.ninv  
	-- JOIN treasurer T ON T.idtreasurer = P.idtreasurer
	-- LEFT JOIN Bill B ON  E.nbill = B.nbill and E.ymov = B.ybill
	--WHERE B.nbill is null
	--AND E.ymov =  @year	

	--INSERT INTO #Work
	--SELECT E.ymov, NULL, T.description, P.transmissiondate, E.description, 'D', -E.Curramount,  MD.mankind, CONVERT(varchar(4),MD.yman)+'/'+CONVERT(varchar(4),MD.nman), M.adate, MD.cupcode,
	--	MD.registry,NULL, NULL, MD.taxable_euro, MD.iva_euro, MD.rowtotal, MD.flagintracom, NULL, NULL, NULL, NULL,E.description 
	-- FROM expenseview E 
	-- JOIN paymentview P ON E.kpay = P.kpay
	-- JOIN expenseview E2 ON E.parentidexp = E2.idexp
	-- JOIN mandatedetailview MD ON MD.idexp_taxable = E2.idexp
	-- JOIN mandate M ON MD.idmankind = M.idmankind AND MD.yman = M.yman AND MD.nman = M.nman
	-- JOIN treasurer T ON T.idtreasurer = P.idtreasurer
	-- LEFT JOIN Bill B ON  E.nbill = B.nbill and E.ymov = B.ybill
	--WHERE B.nbill is null
	--AND E.ymov =  @year	

	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, NULL,NULL,NULL, 
			 NULL,NULL,NULL,  NULL,NULL,NULL, NULL,NULL,NULL, NULL,NULL,NULL, NULL
	from bill B
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	 LEFT JOIN expenseview I ON I.nbill = B.nbill and I.ymov = B.ybill
	WHERE B.billkind = 'D'
	AND B.ybill =  @year
	AND I.nbill IS NULL

	-- Pagamenti con bolletta non associati a documenti
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, 'Pagamento diretto',NULL,I.adate, 
			 NULL,I.registry,I.CF,  I.p_iva,I.curramount,NULL, I.curramount,NULL,NULL, NULL,NULL,NULL, I.description
	from bill B
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	 JOIN expenseview I ON I.nbill = B.nbill and I.ymov = B.ybill
	WHERE B.billkind = 'D'
	AND B.ybill =  @year
	AND I.nbill  IS NOT NULL
	AND I.idexp not in (Select idexp from expenseinvoice)
	AND I.idexp not in (Select e3.idexp from expense E3 join expense E2 ON E2.idexp = E3.parentidexp JOIN expensemandate EM on EM.idexp = E2.idexp ) -- Andare alla fase precedente

	-- incassi con bolletta non associati a documenti
	INSERT INTO #Work
	SELECT B.ybill, B.nbill, T.description, B.adate, B.motive, B.billkind, CASE WHEN B.billkind = 'C' THEN B.total ELSE -B.total END, 'Incasso diretto',NULL,I.adate, 
			 NULL,I.registry,I.CF,  I.p_iva,I.curramount,NULL, I.curramount,NULL,NULL, NULL,NULL,NULL, I.description
	from bill B
	 JOIN treasurer T ON T.idtreasurer = B.idtreasurer
	 JOIN Incomeview I ON I.nbill = B.nbill and I.ymov = B.ybill
	WHERE B.billkind = 'C'
	AND B.ybill =  @year
	AND I.nbill  IS NOT NULL
	AND I.idinc not in (Select idinc from incomeinvoice)
	AND I.idinc not in (Select idinc from incomeestimate)

	INSERT INTO #Work
	SELECT TS.ayear, NULL, T.description, CONVERT(Date, '01/01/'+CONVERT(varchar(4),@year) ), 'Saldo al 01/01/'+CONVERT(varchar(4),@year), 'C', TS.amount,  
		NULL, NULL,NULL, NULL,NULL, NULL,NULL, NULL,NULL, NULL,NULL, NULL,NULL, NULL,NULL,NULL
 
	 FROM treasurerstart TS 
	 JOIN treasurer  T ON TS.idtreasurer = T.idtreasurer and TS.ayear =  @year	
	 WHERE T.active = 'S' and TS.ayear =  @year	
	
	--- aGGIUNGERE INCASSI E PAGAMENTI CHE NON HANNO bill
	SELECT Esercizio,
	Num_Sospeso,
	Banca,
	DataContabile,
	Causale_EstrattoCC,
	Credito_Debito,
	ImportoCC 'Importo sul C/C',
	IvaInclusa 'Importo documento',
	Tipo_Documento,
	Num_Documento,
	Data_Documento , 
	cupcode ,
	Cliente_Fornitore ,
	CodiceFiscale,
	Partita_Iva,
	Imponibile ,
	Iva ,

	Intracomunitaria ,
	Autofattura ,
	Split_payment ,
	Identificativo_Sdi ,
	Data_ricezione_sdi , 
	Ulteriore_Descrizione FROM #Work
	ORDER BY 4,2,3
END
GO


