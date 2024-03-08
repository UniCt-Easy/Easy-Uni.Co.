
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_buono_ordine_annullamenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_buono_ordine_annullamenti]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--setuser 'amm'

CREATE      PROCEDURE [rpt_buono_ordine_annullamenti]
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
	mandatedetail.annotations,
	npackage,
	sum(taxable),
	case when isnull(m.flagintracom,'N')='N' then taxrate else 0 end,
	case when isnull(m.flagintracom,'N')='N' then sum(tax) else 0 end,
	discount,
	start,
	stop
FROM    mandatedetail
	join mandate m on mandatedetail.idmankind = m.idmankind 
				and mandatedetail.yman = m.yman 
				and mandatedetail.nman = m.nman 
WHERE   mandatedetail.yman = @yman
	AND mandatedetail.idmankind= @mandatekind
	AND mandatedetail.nman = @nman
GROUP BY  mandatedetail.detaildescription,mandatedetail.annotations,npackage,
	taxrate,discount,start,stop,idgroup,isnull(m.flagintracom,'N')

SELECT 
	@yman,
	@nman,
	mandatekind.description as mandatekind,
	mandate.exchangerate ,
	#mandatedetail.detaildescription + ' ' + isnull( #mandatedetail.annotations,'') as uniondescr,
	ISNULL(#mandatedetail.npackage, 0) as number,
	ISNULL(#mandatedetail.taxable, 0.0) as taxable,
	ISNULL(#mandatedetail.taxrate, 0.0) as taxrate,
	ISNULL(#mandatedetail.discount, 0.0)as discount ,
	CASE 
		WHEN ((currency.codecurrency IS NULL) OR (currency.codecurrency = 'ITL') OR (currency.codecurrency = 'EUR')) THEN 'N'
		ELSE 'S'
	END as is_english,
	#mandatedetail.start,
	#mandatedetail.stop,
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
	)+
	ROUND(#mandatedetail.tax,2) as rowtotal,
----------------------------------------------------------------------------------------------------------
--------------------------------------- ORDINI IN VALUTA ESTERA ------------------------------------------
----------------------------------------------------------------------------------------------------------
	CONVERT(DECIMAL(19,2),
		ROUND(
			  #mandatedetail.taxable*
			  #mandatedetail.npackage*
			  (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
			 )
	) AS rowtaxable_fcurrency,
	-- Il campo totaleriga in valuta estera  deve essere calcolato come la somma dell'imponibile scontato + l'iva  
	-- non considera iva
	CONVERT(DECIMAL(19,2),
		ROUND(
			  #mandatedetail.taxable*
			  #mandatedetail.npackage*
			  (1-CONVERT(DECIMAL(19,6),ISNULL(#mandatedetail.discount,0))),2
			 )
	+
	ROUND(#mandatedetail.tax,2) )
 AS totalrow_fcurrency
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------
FROM mandate
JOIN #mandatedetail
	ON mandate.yman = #mandatedetail.yman
	AND mandate.nman = #mandatedetail.nman
	AND mandate.idmankind = #mandatedetail.idmankind
JOIN mandatekind
	ON mandatekind.idmankind = mandate.idmankind
LEFT OUTER JOIN currency
	ON currency.idcurrency = mandate.idcurrency
WHERE mandate.yman = @yman
	AND   mandate.idmankind = @mandatekind
	AND mandate.nman = @nman
	AND #mandatedetail.stop is not  null      
	AND #mandatedetail.stop <= @datarifer 
ORDER BY #mandatedetail.stop ASC
	
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

