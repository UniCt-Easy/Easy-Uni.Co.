if exists (select * from dbo.sysobjects where id = object_id(N'[exp_split_clawback_errors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure exp_split_clawback_errors
GO 
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--[exp_split_clawback_errors] 2015, {ts '2014-01-01 00:00:00.000'},'2'
CREATE  PROCEDURE exp_split_clawback_errors
(
	@ayear 	int,
	@datadoc datetime,
	@flagactivity int
)
AS BEGIN
SELECT IRK.description as 'Tipo Registro',
		   CASE IRK.flagactivity
				WHEN 1 THEN 'Istituzionale'
				WHEN 2 THEN 'Commerciale'
				WHEN 3 THEN 'Promiscua'
				WHEN 4 THEN 'Altro'
		   END as 'Tipo attività',
		   IRK.registerclass as 'Classe registro',
		   I.invoicekind + ' n°' + CONVERT(varchar(10), I.ninv) +'/' + CONVERT( varchar(4),I.yinv)  as 'Fattura',
		   CASE I.flagintracom
				WHEN 'S' THEN 'Intra - UE'
				WHEN 'N' THEN 'Italia'
				WHEN 'X' THEN 'Extra - UE'
		   END as 'Tipo Fattura' ,
		   I.flag_enable_split_payment as 'Soggetta a Split' ,
		   I.flagdeferred as 'Differita',I.flagvariation as 'Nota di Credito',
		   I.taxable as 'Imponibile', I.tax as 'IVA', I.unabatable as 'Iva indetraibile',I.total as 'Totale',    
		   I.registry as 'Fornitore', I.cf as 'CF', I.p_iva as 'P.IVA',
		   expenselastview.phase as 'Fase',
		   expenselastview.ymov as 'Esercizio',
		   expenselastview.nmov as 'Numero', 
		   expenselastview.description  as 'Descrizione', 
		   CASE IE.movkind 
				WHEN 1 THEN 'Totale'
				WHEN 2 THEN 'Iva'
				WHEN 3 THEN 'Imponibile'
		   END as 'Tipo Contabilizzazione', 
		   expenselastview.ypay as 'Eserc. Mandato',
		   expenselastview.npay as 'Num. Mandato',
		   expenselastview.paymentadate as  'Emesso il', 
		   paymenttransmission.ypaymenttransmission as 'Elenco Trasm. Eserc.',
		   paymenttransmission.npaymenttransmission as 'Elenco Trasm. n°', 
		   paymenttransmission.transmissiondate as 'Trasmissione del',
		   incomelastview.curramount as 'Importo Iva Split Payment',
	       incomelastview.phase as 'Fase',
	       incomelastview.description  as 'Split', 
		   incomelastview.ymov as 'Esercizio Mov. Split',
		   incomelastview.nmov as 'Numero Mov. Split' ,
		   proceeds.ypro  as 'Eserc. Reversale Split',
		   proceeds.npro  as 'Num. Reversale Split',
		   proceedstransmission.yproceedstransmission  as 'Elenco Trasm. Split Eserc.',
		   proceedstransmission.nproceedstransmission  as 'Elenco Trasm. N° Split', 
		   proceedstransmission.transmissiondate	   as 'Trasmissione Split del'
	 FROM  expenseinvoiceview IE
	 JOIN  invoiceview  I
		   ON I.idinvkind = IE.idinvkind AND 
			  I.yinv = IE.yinv AND 
			  I.ninv = IE.ninv 
	 JOIN  ivaregister IR
		   ON IR.idinvkind = I.idinvkind
		   AND IR.yinv = I.yinv
		   AND IR.ninv = I.ninv
	 JOIN  ivaregisterkind IRK
		   ON IRK.idivaregisterkind = IR.idivaregisterkind
	 JOIN  incomelastview   
		   ON incomelastview.idpayment = IE.idexp
		   AND incomelastview.autokind = 6   -- RECUPERO
	 JOIN  expenseclawbackview 
		   ON expenseclawbackview.idexp = incomelastview.idpayment 
	       AND  expenseclawbackview.clawbackref in ('15_SPLIT_PAYMENT','16_SPLIT_PAYMENT_C')
	 LEFT OUTER JOIN proceeds
		   ON incomelastview.kpro = proceeds.kpro
	 LEFT OUTER JOIN proceedstransmission 
		   ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 
	 JOIN expenselastview   
		   ON expenselastview.idexp = incomelastview.idpayment
	 LEFT OUTER JOIN payment
		   ON payment.kpay = expenselastview.kpay
	 LEFT OUTER JOIN paymenttransmission 
		   ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission 

	WHERE  IRK.registerclass = 'A' AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	AND    ISNULL(I.flag_enable_split_payment,'N') = 'S'
	AND    I.yinv = @ayear
	AND    (I.docdate >= @datadoc OR @datadoc IS NULL)
	AND    expenselastview.idexp IS NOT NULL
	AND    incomelastview.idinc IS NOT NULL
	AND    IE.movkind IN (1,2)
	
	AND    ISNULL((SELECT SUM(curramount) FROM incomelastview  
		   JOIN expenseclawback ON expenseclawback.idexp = incomelastview.idpayment
		   JOIN clawback ON clawback.idclawback = expenseclawback.idclawback 
		   AND  clawback.clawbackref in ('15_SPLIT_PAYMENT','16_SPLIT_PAYMENT_C')
		   WHERE incomelastview.idpayment IN 
		   (SELECT  idexp FROM expenseinvoiceview IE1 
		     WHERE  I.idinvkind = IE1.idinvkind AND 
				    I.yinv = IE1.yinv AND 
			        I.ninv = IE1.ninv)
		   AND incomelastview.autokind = 6 ),0) 
		   <>  
		   ISNULL((SELECT SUM(tax) FROM invoicedetail   
		   WHERE invoicedetail.idexp_iva IN 
		   (SELECT  idexp FROM expenseinvoiceview IE1 
		     WHERE  I.idinvkind = IE1.idinvkind AND 
				    I.yinv = IE1.yinv AND 
			        I.ninv = IE1.ninv)),0)
			
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO