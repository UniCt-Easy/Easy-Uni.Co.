
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_intra12]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_intra12]
GO

/*

EXEC exp_mod_intra12 2010, 10, {d '2010-10-10'}
setuser 'amm'
*/
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_intra12] (
	@ayear smallint,
	@mese smallint, -- Mese della dichiarazione
	@dataversamento datetime -- Data versamento @TR012014
)
AS
BEGIN

DECLARE @TR012001 decimal(19,5) -- Acquisti Intra - Imponibile
SET @TR012001 = isnull((
			SELECT
			round(
				ISNULL(
 					SUM(
					    (case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'B'--> Beni
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.move12, 'N') = 'N'
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
				and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012002 decimal(19,2) -- Acquisti Intra - Imposta
SET @TR012002 =  isnull((
			SELECT SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) * ROUND(InvDet.tax,2))
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'B'--> Beni
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.move12, 'N') = 'N'
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
),0)

DECLARE @TR012003 decimal(19,5) -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imponibile Beni
SET @TR012003 =  isnull((
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'B'--> Beni
			AND MONTH(I.adate) = @mese
			AND isnull(InvDet.tax,0) >0
			AND ISNULL(InvDet.move12, 'N') = 'S'
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012004 decimal(19,2) -- Acquisti da soggetti stabiliti in altri Stati appartenenti all''Unione Europea- Imposta Beni
SET @TR012004 =  isnull((
			SELECT SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) * ROUND(InvDet.tax,2))
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv  AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'B'--> Beni
			AND MONTH(I.adate) = @mese
			AND isnull(InvDet.tax,0) >0
			AND ISNULL(InvDet.move12, 'N') = 'S'
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012005 decimal(19,5) -- Acquisti - Imponibile Servizi
SET @TR012005 =  isnull((
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet		ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'S'--> Servizi
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012006 decimal(19,5) -- Acquisti - Imponibile Servizi art.7
SET @TR012006 =  isnull(( 
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'S'--> Servizi
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND ISNULL(InvDet.exception12, 'N') = 'S'
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012007 decimal(19,2) -- Acquisti - Imposta Servizi
SET @TR012007 =  isnull((
			SELECT SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) * ROUND(InvDet.tax,2))
			FROM invoice as I
			JOIN invoicekind IK						ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 			ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR						ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK				ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'S'
			AND YEAR(I.adate) = @ayear
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND InvDet.intra12operationkind = 'S'--> Servizi
			AND MONTH(I.adate) = @mese
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012008 decimal(19,5) -- Acquisti Entra-UE - Imponibile Beni
SET @TR012008 =  isnull((
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet		ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'X'-->Extra-UE
			AND YEAR(I.adate) = @ayear
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND InvDet.intra12operationkind = 'B'--> Beni
			AND MONTH(I.adate) = @mese
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012009 decimal(19,2) -- Acquisti Entra-UE - Imposta Beni
SET @TR012009 =  isnull((
			SELECT SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *ROUND(InvDet.tax,2))
			FROM invoice as I
			JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet		ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'X'	--> Extra-UE
			AND YEAR(I.adate) = @ayear
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND InvDet.intra12operationkind = 'B'	--> Beni
			AND MONTH(I.adate) = @mese
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012010 decimal(19,5) -- Acquisti Entra-UE - Imponibile Servizi
SET @TR012010 =  isnull((
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK				ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 	ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR				ON IR.idinvkind = I.idinvkind AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK		ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'X'	-->Extra-UE
			AND YEAR(I.adate) = @ayear
			AND isnull(InvDet.tax,0) >0
			AND InvDet.intra12operationkind = 'S'	--> Servizi
			--AND ISNULL(InvDet.exception12, 'N') = 'N'
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012011 decimal(19,5) -- Acquisti Entra-UE - Imponibile Servizi art.7
SET @TR012011 =  isnull((
			SELECT
			round(
				ISNULL(
 					SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *
						ROUND(InvDet.taxable * InvDet.npackage * CONVERT(decimal(19,10),I.exchangerate) *
							(1 - CONVERT(decimal(19,6),ISNULL(InvDet.discount, 0.0)))
						,2)
					)
				, 0) 
				,2)
			FROM invoice as I
			JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet		ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv	AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'X'-->Extra-UE
			AND YEAR(I.adate) = @ayear
			AND InvDet.intra12operationkind = 'S'--> Servizi
			AND ISNULL(InvDet.exception12, 'N') = 'S'
			AND MONTH(I.adate) = @mese
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012012 decimal(19,2) -- Acquisti Entra-UE - Imposta Servizi
SET @TR012012 =  isnull((
			SELECT SUM((case when (IK.flag & 4) = 0 then 1 else -1 end) *ROUND(InvDet.tax,2))
			FROM invoice as I
			JOIN invoicekind IK					ON I.idinvkind = IK.idinvkind
			JOIN invoicedetail as InvDet 		ON I.idinvkind = InvDet.idinvkind AND I.yinv = InvDet.yinv AND I.ninv = InvDet.ninv
			JOIN ivaregister IR					ON IR.idinvkind = I.idinvkind	AND IR.yinv = I.yinv AND IR.ninv = I.ninv
			JOIN ivaregisterkind IRK			ON IRK.idivaregisterkind = IR.idivaregisterkind
			WHERE I.flagintracom = 'X'--> Extra-UE
			AND YEAR(I.adate) = @ayear
			AND ISNULL(InvDet.rounding,'N') <>'S'  --salta i dettagli di arrotondamento, task 7360
			and (isnull(InvDet.flagbit,0) & 4) = 0
			AND isnull(InvDet.tax,0) >0
			AND InvDet.intra12operationkind = 'S'--> Servizi
			AND MONTH(I.adate) = @mese
			AND (IK.flag & 1)= 0 --> Acquisti
			AND IRK.flagactivity = 1 -- prende le fattura associate a registri Istituzionali
			),0)

DECLARE @TR012013 decimal(19,2) -- Totale Imposta  
SET @TR012013 =  isnull(@TR012002,0) + isnull(@TR012004,0) +  isnull(@TR012007,0)+ isnull(@TR012009,0) + isnull(@TR012012,0)

DECLARE @TR012014 datetime
SET @TR012014 = @dataversamento

SELECT 
	@TR012001 as TR012001,
	@TR012002 as TR012002,
	@TR012003 as TR012003,
	@TR012004 as TR012004,
	@TR012005 as TR012005,
	@TR012006 as TR012006,
	@TR012007 as TR012007,
	@TR012008 as TR012008,
	@TR012009 as TR012009,
	@TR012010 as TR012010,
	@TR012011 as TR012011,
	@TR012012 as TR012012,
	@TR012013 as TR012013,
	@TR012014 as TR012014
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



