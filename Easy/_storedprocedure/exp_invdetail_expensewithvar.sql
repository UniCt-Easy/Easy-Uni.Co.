if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invdetail_expensewithvar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invdetail_expensewithvar]
GO 

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
  
CREATE  PROCEDURE [exp_invdetail_expensewithvar]
(
	@ayear 	int,
	@datebegin datetime,
	@dateend datetime,
	@flagactivity int
)
AS BEGIN
-- pagamenti di fatture con variazioni che non contabilizzano documenti
--[exp_invdetail_expensewithvar] 2017, {ts '2017-01-01 00:00:00.000'}, {ts '2017-12-31 00:00:00.000'}, null

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
		   END as 'Tipo Contabilizzazione'
 FROM  invoiceview  I  
	 JOIN  expenseinvoiceview IE  			ON I.idinvkind = IE.idinvkind AND   I.yinv = IE.yinv AND   I.ninv = IE.ninv 
	join expenseview E			   			on E.idexp = IE.idexp
	 JOIN  ivaregister IR					ON IR.idinvkind = I.idinvkind   AND IR.yinv = I.yinv  AND IR.ninv = I.ninv
	 JOIN  ivaregisterkind IRK				ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN paymentcommunicated PC1			ON PC1.idexp = E.idexp
	join expensevar EV			   			on EV.idexp = IE.idexp
	WHERE  IRK.registerclass = 'A' AND (IRK.flagactivity = @flagactivity OR @flagactivity IS NULL)
	AND    I.yinv = @ayear
	AND    IE.movkind IN (1,2)
	AND		EV.movkind is null -- I pagamento che contabilizzano fatture non devono avere variazioni semplici
	AND I.flagdeferred = 'S'
	AND PC1.competencydate BETWEEN @datebegin AND @dateend
	AND isnull(EV.autokind,0)<>22 --non considera le autokind "Modifica Dati di Pagamenti Trasmessi", task 12275 
	AND isnull(EV.autokind,0)<>10 --non considera le autokind "Annullo totale", task 12359
	AND isnull(EV.autokind,0)<>11 --non considera le autokind "Annullp parziale", task 12359							
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

