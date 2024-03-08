
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_split_no_clawback]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_split_no_clawback]
GO 
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
  --[exp_split_no_clawback] 2015, {ts '2014-01-01 00:00:00.000'},'1'
CREATE  PROCEDURE [exp_split_no_clawback]
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
		   expenselastview.phase + ' ' + CONVERT(varchar(4),expenselastview.ymov) + '/' + CONVERT(varchar(10),expenselastview.nmov)  as 'Contabilizzazione', 
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
		   incomelastview.ymov as 'Esercizio Mov. Split',
		   incomelastview.nmov as 'Numero Mov. Split' ,
		   proceeds.ypro  as 'Eserc. Reversale Split',
		   proceeds.npro  as 'Num. Reversale Split',
		   proceedstransmission.yproceedstransmission  as 'Elenco Trasm. Split Eserc.',
		   proceedstransmission.nproceedstransmission  as 'Elenco Trasm. N° Split', 
		   proceedstransmission.transmissiondate	   as 'Trasmissione Split del'
	 FROM  invoiceview  I  
	 JOIN  expenseinvoiceview IE  
		   ON I.idinvkind = IE.idinvkind AND 
			  I.yinv = IE.yinv AND 
			  I.ninv = IE.ninv 
	 JOIN  ivaregister IR
		   ON IR.idinvkind = I.idinvkind
		   AND IR.yinv = I.yinv
		   AND IR.ninv = I.ninv
	 JOIN  ivaregisterkind IRK
		   ON IRK.idivaregisterkind = IR.idivaregisterkind
	 LEFT OUTER JOIN expenselastview   
		   ON expenselastview.idexp = IE.idexp
	 LEFT OUTER JOIN payment
		   ON payment.kpay = expenselastview.kpay
	 LEFT OUTER JOIN paymenttransmission 
		   ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission 
	 LEFT OUTER JOIN  incomelastview   
		   ON incomelastview.idpayment = IE.idexp
		   AND incomelastview.autokind = 6   -- RECUPERO
	 LEFT OUTER JOIN proceeds
		   ON incomelastview.kpro = proceeds.kpro
	 LEFT OUTER JOIN proceedstransmission 
		   ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 

	WHERE  IRK.registerclass = 'A' AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	AND    ISNULL(I.flag_enable_split_payment,'N') = 'S'
	AND    I.yinv = @ayear
	AND    (I.docdate >= @datadoc OR @datadoc IS NULL)
	AND    expenselastview.idexp IS NOT NULL
	AND    incomelastview.idinc IS NULL
	AND    IE.movkind IN (1,2)
	AND    I.tax > 0	
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
