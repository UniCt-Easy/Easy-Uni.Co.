
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mandatedetail_epexp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mandatedetail_epexp]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amm'
--exec exp_mandatedetail_epexp 2016
CREATE   PROCEDURE [exp_mandatedetail_epexp]
(
	@ayear int
)
AS BEGIN
DECLARE  @gen_01 datetime
SELECT   @gen_01 = CONVERT(datetime, '01-01-' + CONVERT(char(4), @ayear), 105)
 
DECLARE  @dec_31 datetime
SELECT   @dec_31 = CONVERT(datetime, '31-12-' + CONVERT(char(4), @ayear), 105)
 
DECLARE  @proRataPerc decimal(19,6)
SELECT   @proRataPerc = prorata FROM iva_prorata WHERE ayear = @ayear

DECLARE  @promiscuoPerc decimal(19,2)
SELECT   @proRataPerc = mixed FROM iva_mixed WHERE ayear = @ayear
 
CREATE TABLE #mandatedetail
(
	idmankind varchar(20),
	yman smallint,
	nman int,
	rownum int,
	idgroup int,
	mankind varchar(150),
	registry varchar(100),
	detaildescription varchar(150),
	number decimal(19,2),
	taxable decimal(19,5),
	taxrate float,
	tax decimal(19,2),
	discount float,
	start datetime,
	stop datetime,
	taxable_euro decimal(19,2),
	iva_euro decimal(19,2),
	unabatable decimal(19,2),
	flagmixed char(1),
	abatablerate decimal(19,6), 
	ivadetraibile decimal(19,2),
	importo decimal(19,2),
	yepexp smallint,
	nepexp int, 
	importo_impegno decimal(19,2)
)

INSERT INTO #mandatedetail
(
	idmankind,
	yman,
	nman,
	rownum,
	idgroup,
	mankind,
	registry,
	detaildescription,
	number,
	taxable,
	taxrate,
	tax,
	discount,
	start,
	stop,
	taxable_euro,
	iva_euro,
	unabatable,
	flagmixed,
	abatablerate,
	ivadetraibile,
	importo,
	yepexp,
	nepexp, 
	importo_impegno
)
SELECT 
	mandatedetailview.idmankind,
	mandatedetailview.yman,
	mandatedetailview.nman,
	mandatedetailview.rownum,
	mandatedetailview.idgroup,
	mandatedetailview.mankind,
	mandatedetailview.registry,
	mandatedetailview.detaildescription,
	mandatedetailview.number,
	mandatedetailview.taxable,
	mandatedetailview.taxrate,
	mandatedetailview.tax,
	mandatedetailview.discount,
	mandatedetailview.start,
	mandatedetailview.stop,
	mandatedetailview.taxable_euro,
	mandatedetailview.iva_euro,
	mandatedetailview.unabatable,
	mandatedetailview.flagmixed,

	--double abatablerate = proRataPerc;
 --   if (rDettaglio["flagmixed"].ToString().ToUpper() == "S") abatablerate *= promiscuoPerc;
 --   double scontoPerc = CfgFn.GetNoNullDouble(rDettaglio["discount"]);

 --   var rImponibile = CfgFn.GetNoNullDouble(rDettaglio["taxable"]);
 --   var iva = CfgFn.GetNoNullDouble(rDettaglio["tax"]);
 --   var quantitaConfezioni = CfgFn.GetNoNullDouble(rDettaglio["npackage"]);
 --   var imponibileNonScontato = CfgFn.RoundValuta(rImponibile*quantitaConfezioni*tassocambio);
 --   var imponibile = CfgFn.RoundValuta(rImponibile * quantitaConfezioni * tassocambio*(1- scontoPerc));

 --   var ivaindetraibile = CfgFn.GetNoNullDouble(rDettaglio["unabatable"]);
 --   var ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile)); //iva già in EURO
 --   var ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda*abatablerate);
 --   var valoreIvaTotale = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDettaglio["tax"]));
 --   var valoreIvaDetraibile = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(ivadetraibile));
 --   var ivaIndetraibile = valoreIvaTotale - valoreIvaDetraibile;
 --   var ivaIndetraibileNoProrata = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(ivaindetraibile));
 --   var ivaIndetraibileDovutaAProrata = ivaIndetraibile - ivaIndetraibileNoProrata;                
 --   var amount = CfgFn.RoundValuta((decimal) (imponibile + iva - ivadetraibile));


	CASE 
		WHEN mandatedetailview.flagmixed = 'S' THEN @proRataPerc*@promiscuoPerc
		ELSE @proRataPerc
	END, 
	ROUND(( isnull(tax,0) - isnull(unabatable,0) ) * 
		CASE 
			WHEN mandatedetailview.flagmixed = 'S' THEN @proRataPerc*@promiscuoPerc
			ELSE @proRataPerc
		END
	,2), 
	ROUND(isnull(taxable_euro,0) + isnull(tax,0) - ROUND(( isnull(tax,0) - isnull(unabatable,0) ) * 
		CASE 
			WHEN mandatedetailview.flagmixed = 'S' THEN @proRataPerc*@promiscuoPerc
			ELSE @proRataPerc
		END
	,2),2),
	epexpview.yepexp,
	epexpview.nepexp,
	epexpview.curramount
FROM mandatedetailview
LEFT OUTER JOIN epexpview  ON mandatedetailview.idepexp = epexpview.idepexp and epexpview.ayear=@ayear
WHERE ((mandatedetailview.yman = @ayear AND 
	  mandatedetailview.start IS NULL) 
	   OR (mandatedetailview.start BETWEEN @gen_01 AND @dec_31)	   
	  )

select 
	idmankind as 'Cod. Tipo contratto passivo',
	mankind as  'Tipo contratto passivo',
	yman as 'Esercizio',
	nman as 'Numero',
	rownum as '#Riga',
	idgroup as '#Gruppo',
	registry as 'Anagrafica',
	detaildescription as 'Descr. Dettaglio',
	number as 'Quantità',
	taxable as 'Imponibile',
	taxrate as 'Aliquota',
	tax as 'Iva',
	discount as 'Sconto',
	start as 'Inizio',
	stop as 'Fine',
	taxable_euro as 'Imponibile (Euro)',
	iva_euro as 'IVA',
	unabatable as 'Iva indetraibile',
	flagmixed as 'Promiscuo',
	abatablerate as 'Perc. Iva Detraibile',
	ivadetraibile as 'Iva Detraibile',
	importo as 'Importo',
	yepexp as 'Eserc. Imp. Budget',
	nepexp as 'Num. Imp. Budget', 
	importo_impegno as 'Importo Imp. Budget'
 from #mandatedetail where 
	(stop is null and isnull(importo,0) <> isnull(importo_impegno,0))
	or 
	(stop is not null and isnull(importo_impegno,0)<>0)
 
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

