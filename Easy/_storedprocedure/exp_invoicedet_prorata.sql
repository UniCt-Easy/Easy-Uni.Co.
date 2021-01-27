
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicedet_prorata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicedet_prorata]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_invoicedet_prorata] 
(
		@year int 
)
AS
BEGIN

-- [exp_invoicedet_prorata] 2012
CREATE TABLE #invoicedet
	(
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagdeferred char(1),
		collected char(1),
		flagvariation char(1),
		flagintracom char(1),
		taxabletotal decimal(19,2),
		idivaregisterkindunified int, 
		codeivaregisterkind varchar(20),
		codeivakind varchar(20)
	)

INSERT INTO #invoicedet
	(
		idinvkind, yinv, ninv, rownum,
		registerclass,kind,flagdeferred, collected,flagvariation,flagintracom,
		taxabletotal,codeivakind,
		idivaregisterkindunified,codeivaregisterkind,adate
	)
	(SELECT
		I.idinvkind,I.yinv,I.ninv, IDET.rownum, 
		IRK.registerclass,		--tipo registro (A/V)
		CASE WHEN (IK.flag & 1)=0 THEN 'A'
		     ELSE 'V'
		END, 		--tipo fattura (A/V)
		I.flagdeferred,
		CASE 
			WHEN  	(I.flagdeferred = 'S') AND (Year(IDET.paymentcompetency) = @year OR Year(P.competencydate) = @year) THEN 'S'
			ELSE 'N'
		END,
		CASE
			WHEN (IK.flag & 4) = 0 THEN 'N'
			ELSE 'S'
		END, 	
		I.flagintracom,
		ROUND(IDET.taxable * IDET.npackage * 
		 CONVERT(decimal(19,10),I.exchangerate) *
		  (1 - CONVERT(decimal(19,6),ISNULL(IDET.discount, 0.0))),2
		 ), 
		IVK.codeivakind,
		IRK.idivaregisterkindunified,
		IRK.codeivaregisterkind,
		I.adate
	FROM invoice I
	join invoicedetail IDET
		ON IDET.idinvkind=I.idinvkind
		AND IDET.yinv=I.yinv
		AND IDET.ninv=I.ninv
	JOIN invoicekind IK
		ON I.idinvkind = IK.idinvkind
	JOIN ivaregister IR
		ON IR.idinvkind = I.idinvkind
		AND IR.yinv = I.yinv
		AND IR.ninv = I.ninv
	JOIN ivaregisterkind IRK
		ON IRK.idivaregisterkind = IR.idivaregisterkind
	JOIN ivakind IVK
		ON IDET.idivakind = IVK.idivakind
	LEFT OUTER JOIN proceedsemitted P
		ON P.idinc = IDET.idinc_taxable
	WHERE 	
		YEAR(I.adate) = @year 
		AND IRK.registerclass = 'V'
		and IRK.flagactivity = '2' -- 11961 vanno considerati solo i registri commerciali
		-- con la condizione seguente intendiamo escludere le fatture che 
		-- sono soggette a doppia registrazione sia nel registro acquisti 
		-- che nel registro vendite (INTRACOM), infatti sono fatture di acquisto
		AND (SELECT COUNT(*) FROM ivaregister RA 
			 JOIN ivaregisterkind RAK
				ON RAK.idivaregisterkind = RA.idivaregisterkind
			 WHERE RA.idinvkind = I.idinvkind
			   AND RA.yinv = I.yinv
			   AND RA.ninv = I.ninv
			   AND RAK.registerclass = 'A'
			   ) = 0
		)

		
DECLARE @iddbdepartment varchar(50)
DECLARE @dbdepartment varchar(150)

--SELECT @iddbdepartment = iddbdepartment, @dbdepartment = description FROM dbdepartment
--WHERE iddbdepartment = user

SELECT 
@iddbdepartment,
@dbdepartment,
idinvkind,
yinv,
ninv,
rownum,
adate,
registerclass, --tipo registro A/V
kind, --tipo fattura A/V
flagdeferred,
collected, 
flagvariation,
flagintracom,
taxabletotal,
idivaregisterkindunified, 
codeivaregisterkind,
codeivakind
FROM #invoicedet




DROP TABLE #invoicedet
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
