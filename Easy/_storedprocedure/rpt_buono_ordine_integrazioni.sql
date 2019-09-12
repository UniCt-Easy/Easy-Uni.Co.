if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_integrazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_integrazioni]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'


CREATE     PROCEDURE [rpt_buono_ordine_integrazioni]
	@yman int,
	@nman int,
	@mandatekind varchar(20),
	@datarifer smalldatetime
AS BEGIN
CREATE TABLE #mandatedetail
(
	yman int,
	nman int,
	idmankind varchar(20),
	detaildescription varchar(150),
	annotations varchar(400),
	npackage decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime
)
INSERT INTO #mandatedetail
(
	yman,
	nman,
	idmankind ,
	detaildescription,
	annotations,
	npackage,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop 
)
SELECT 
	@yman,
	@nman,
	@mandatekind,
	detaildescription,
	annotations,
	npackage,
	sum(taxable),
	taxrate,
	sum(tax),
	discount,
	start,
	stop
FROM    mandatedetail
WHERE   mandatedetail.yman = @yman
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman = @nman
GROUP BY  detaildescription,annotations,npackage,
	taxrate,discount,start,stop,idgroup
--select * from #mandatedetail
SELECT 
	@yman,
	@nman,
	mandatekind.description as mandatekind,
	mandate.exchangerate as exchangerate,
	#mandatedetail.detaildescription + ' ' + isnull(#mandatedetail.annotations,'') as uniondescr,
	ISNULL(#mandatedetail.npackage, 0) as number ,
	ISNULL(#mandatedetail.taxable, 0.0) as taxable,
	case when (isnull(mandate.flagintracom,'N')='N') then ISNULL(#mandatedetail.taxrate, 0.0)  else 0 end  as taxrate,
	ISNULL(#mandatedetail.discount, 0.0) as discount ,
	CASE 
		WHEN ((currency.codecurrency IS NULL) OR (currency.codecurrency = 'ITL') OR (currency.codecurrency = 'EUR')) THEN 'N'
		ELSE 'S'
	END as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
-- Imponibile totale della riga di dettaglio
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.npackage*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	) as rowtaxable,
-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.npackage*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	)
	+
	case when (isnull(mandate.flagintracom,'N')='N') then ROUND(#mandatedetail.tax,2)   else 0 end
	 as totalrow,
----------------------------------------------------------------------------------------------------------
--------------------------------------- ORDINI IN VALUTA ESTERA ------------------------------------------
----------------------------------------------------------------------------------------------------------
	CONVERT(DECIMAL(19,2),
		ROUND(
			  #mandatedetail.taxable*
			  #mandatedetail.npackage*
			  (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
			 )
	) 
	AS rowtaxable_fcurrency,
	-- Il campo totaleriga in valuta estera  deve essere calcolato come la somma dell'imponibile scontato + l'iva 
	-- non considera iva
	CONVERT(DECIMAL(19,2),
		ROUND(
			  #mandatedetail.taxable*
			  #mandatedetail.npackage*
			  (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
			 )
	+
	case when (isnull(mandate.flagintracom,'N')='N') then ROUND(#mandatedetail.tax,2)   else 0 end
	
	)
 AS totalrow_fcurrency
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
FROM mandate
JOIN #mandatedetail
	ON  mandate.yman = #mandatedetail.yman
	AND mandate.nman = #mandatedetail.nman
	AND mandate.idmankind = #mandatedetail.idmankind
JOIN mandatekind 
	ON  mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN currency
	ON currency.idcurrency = mandate.idcurrency
WHERE mandate.yman = @yman
	AND mandate.nman = @nman
	AND mandate.idmankind = @mandatekind
	AND #mandatedetail.start is not  null   
	AND #mandatedetail.start <= @datarifer
ORDER BY #mandatedetail.start ASC
	
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

