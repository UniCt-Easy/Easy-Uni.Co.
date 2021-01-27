
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_split_incassipagamentiinrangediverso]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_split_incassipagamentiinrangediverso]
GO

CREATE  PROCEDURE [exp_split_incassipagamentiinrangediverso]
(
	@ayear 	int,
	@start datetime,
	@stop datetime,
	@idclawback int
)
AS BEGIN
-- exec exp_split_incassipagamentiinrangediverso 2015, {ts '2015-04-01 00:00:00.000'}, {ts '2015-04-10 00:00:00.000'}, null
/*
*	La sp ha lo scopo di evidenziare quelle fatture soggette a split-payment e quindi a recupero, per cui, fissato un periodo di riferimento start e stop, si verifica che :
*	la data Tx Incasso (= recupero) appartiene al periodo e la data Tx Mandato NON appartiene o viceversa, ossia la data Tx Incasso (= recupero) NON appartiene al periodo e la data Tx Mandato appartiene
*/
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
		   I.flagdeferred as 'Differita',
		   I.flagvariation as 'Nota di Credito',
		   I.taxable as 'Imponibile', I.tax as 'IVA', I.unabatable as 'Iva indetraibile',I.total as 'Totale',    
		   I.registry as 'Fornitore', I.cf as 'CF', I.p_iva as 'P.IVA',
		   expenselastview.phase + ' ' + CONVERT(varchar(4),expenselastview.ymov) + '/' + CONVERT(varchar(10),expenselastview.nmov)  as 'Contabilizzazione', 
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
	FROM  expenseinvoiceview IE  
	JOIN  invoiceview  I
		ON I.idinvkind = IE.idinvkind AND I.yinv = IE.yinv AND I.ninv = IE.ninv 
	JOIN  ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN  ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN expenselastview   
		ON expenselastview.idexp = IE.idexp
	join expenseclawback
		on IE.idexp = expenseclawback.idexp
	join clawback
		on clawback.idclawback = expenseclawback.idclawback
	 JOIN payment
		   ON payment.kpay = expenselastview.kpay
	 JOIN paymenttransmission 
		   ON payment.kpaymenttransmission = paymenttransmission.kpaymenttransmission 
	 JOIN  incomelastview   
		   ON incomelastview.idpayment = IE.idexp
	 JOIN proceeds
		   ON incomelastview.kpro = proceeds.kpro
	 JOIN proceedstransmission 
		   ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 
	WHERE  IRK.registerclass = 'A' 
			AND incomelastview.autokind = 6   -- RECUPERO
			AND ISNULL(I.flag_enable_split_payment,'N') = 'S'
			AND I.yinv = @ayear
			AND ( expenseclawback.idclawback = @idclawback OR @idclawback is null )
			AND	IE.movkind IN (1,2)-- Totake o solo IVA
			-- la data Tx Incasso appartiene al periodo e la data Tx Mandato NON appartiene OR  la data Tx Incasso NON appartiene al periodo e la data Tx Mandato appartiene
			AND	(
				( proceedstransmission.transmissiondate between @start and @stop AND paymenttransmission.transmissiondate NOT between @start and @stop)
				OR
				( proceedstransmission.transmissiondate NOT between @start and @stop AND paymenttransmission.transmissiondate  between @start and @stop)
				)
			AND clawback.clawbackref in ('15_SPLIT_PAYMENT','16_SPLIT_PAYMENT_C')		
END

GO



