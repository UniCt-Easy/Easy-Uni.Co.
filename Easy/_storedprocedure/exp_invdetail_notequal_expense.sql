
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



if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invdetail_notequal_expense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invdetail_notequal_expense]
GO 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
  
CREATE  PROCEDURE [exp_invdetail_notequal_expense]
(
	@ayear 	int,
	@datebegin datetime,
	@dateend datetime,
	@flagactivity int
)
AS BEGIN
--fatture con pagamenti incoerenti
--[exp_invdetail_notequal_expense] 2017, {ts '2017-01-01 00:00:00.000'}, {ts '2017-12-31 00:00:00.000'}, null

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
		   I.taxable as 'Imponibile Fattura', 
		   I.tax as 'IVA Fattura', 
		   I.unabatable as 'Iva indetraibile',
		   I.total as 'Totale Fattura',    
		   I.registry as 'Fornitore', I.cf as 'CF', I.p_iva as 'P.IVA',
		   E.phase + ' ' + CONVERT(varchar(4),E.ymov) + '/' + CONVERT(varchar(10),E.nmov)  as 'Contabilizzazione', 
		   E.amount  as 'Importo movimento',
		   CASE IE.movkind 
				WHEN 1 THEN 'Totale'
				WHEN 2 THEN 'Iva'
				WHEN 3 THEN 'Imponibile'
		   END as 'Tipo Contabilizzazione', 
		   incomelastview.curramount as 'Importo Iva Split Payment',
	       incomelastview.phase as 'Fase',
		   incomelastview.ymov as 'Esercizio Mov. Split',
		   incomelastview.nmov as 'Numero Mov. Split' 
	 FROM  invoiceview  I  
	 JOIN  expenseinvoiceview IE  
		   ON I.idinvkind = IE.idinvkind AND 
			  I.yinv = IE.yinv AND 
			  I.ninv = IE.ninv 
	join expenseview E
			on E.idexp = IE.idexp
	 JOIN  ivaregister IR
		   ON IR.idinvkind = I.idinvkind
		   AND IR.yinv = I.yinv
		   AND IR.ninv = I.ninv
	 JOIN  ivaregisterkind IRK
		   ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN paymentcommunicated PC1		
		ON PC1.idexp = E.idexp
	 LEFT OUTER JOIN  incomelastview   
		   ON incomelastview.idpayment = IE.idexp
		   AND incomelastview.autokind = 6   -- RECUPERO
	 LEFT OUTER JOIN proceeds
		   ON incomelastview.kpro = proceeds.kpro
	 LEFT OUTER JOIN proceedstransmission 
		   ON proceeds.kproceedstransmission = proceedstransmission.kproceedstransmission 
	WHERE  IRK.registerclass = 'A' AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	AND    I.yinv = @ayear
	AND    IE.movkind IN (1,2)
	AND I.flagdeferred = 'S'
	AND PC1.competencydate BETWEEN @datebegin AND @dateend
	 -- il pagamento ha importo originale incoerente con il totale dei dettagli fattura collegati
	AND ( E.amount <> isnull(( 
					isnull((select sum(I2.taxable_euro) from invoicedetailview I2 where I2.flagvariation ='N' and I2.idexp_taxable = E.idexp),0) 
					+  isnull(( select sum(I2.iva_euro) from invoicedetailview I2 where I2.flagvariation ='N' and I2.idexp_iva = E.idexp),0) 
						),0)
		OR
			--il pagamento è collegato alla fattura soltanto attraverso expenseinvoice, ma non attraverso invoicedetail.idexp_iva 
			(select count(*) from invoicedetailview I3 where I3.flagvariation ='N'and I3.idexp_iva = E.idexp)=0
		)

							
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


