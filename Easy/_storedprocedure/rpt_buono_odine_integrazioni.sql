if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_integrazioni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_integrazioni]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'

CREATE  PROCEDURE [rpt_buono_ordine_integrazioni]
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
	number decimal(19,2),
	taxable decimal(19,2),
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
	number,
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
	mandatedetail.detaildescription,
	mandatedetail.annotations,
	mandatedetail.number,
	sum(mandatedetail.taxable),
	case when (isnull(m.flagintracom,'N')='N') then taxrate else 0 end,
	case when (isnull(m.flagintracom,'N')='N') then sum(mandatedetail.tax) else 0 end,
	discount,
	start,
	stop
FROM    mandatedetail
		join mandate m on mandatedetail.idmankind=m.idmankind 
						and mandatedetail.yman=m.yman 
						and mandatedetail.nman=m.nman 
WHERE   mandatedetail.yman = @yman
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman = @nman
GROUP BY  detaildescription,mandatedetail.annotations,number,
	taxrate,discount,start,stop,idgroup,isnull(m.flagintracom,'N')

--select * from #mandatedetail
SELECT 
	mandate.yman ,
	mandate.nman,
	mandatekind.description as mandatekind,
	mandate.exchangerate as exchangerate,
	#mandatedetail.detaildescription + ' ' + isnull(#mandatedetail.annotations,'') as uniondescr,
	ISNULL(#mandatedetail.number, 0) as number ,
	ISNULL(#mandatedetail.taxable, 0.0) as taxable,
	ISNULL(#mandatedetail.taxrate, 0.0)  as taxrate,
	ISNULL(#mandatedetail.discount, 0.0) as discount ,
	CASE 
		WHEN ((mandate.idcurrency IS NULL) OR (mandate.idcurrency = 'ITL') OR (mandate.idcurrency = 'EUR')) THEN 'N'
		ELSE 'S'
	END as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
-- Imponibile totale della riga di dettaglio
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	) as rowtaxable,
-- Per evitare perdita di informazione, da cui conseguono errori di arrotondamento, il campo totaleriga 
-- deve essere calcolato come la somma dell'imponibile scontato + il calcolo dell'aliquota
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	)+
	CONVERT(DECIMAL(19,2),
		ROUND(
		      #mandatedetail.taxable*
		      #mandatedetail.number*
		      CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.taxrate,0.0))*
		      CONVERT(DECIMAL(19,6),mandate.exchangerate)*
		      (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0.0))),2
  		     )
	) as totalrow
FROM mandate
JOIN #mandatedetail
	ON  mandate.yman = #mandatedetail.yman
	AND mandate.nman = #mandatedetail.nman
	AND mandate.idmankind = #mandatedetail.idmankind
JOIN mandatekind 
	ON  mandatekind.idmankind = mandate.idmankind
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

