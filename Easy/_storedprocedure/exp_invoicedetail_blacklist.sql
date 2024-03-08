
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoicedetail_blacklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoicedetail_blacklist]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_invoicedetail_blacklist]
(	@anno int,
	@start smalldatetime,
	@stop smalldatetime
)
AS
BEGIN
CREATE TABLE #invoicedetail
	(
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		adate smalldatetime,
		description varchar(150),
		doc varchar(35),
		docdate smalldatetime,
		idreg int,
		registry varchar(100),
		idblacklist int,
		blnation varchar(100),
		blcode char(3),
		ivaregisterkind varchar(50),
		registerclass char(1),
		flagactivity int,
		rownum int,
		detaildescription varchar(150),
		taxable_euro decimal(19,2),
		iva_euro decimal(19,2),
		unabatable_euro decimal(19,2),
		rowtotal decimal(19,2),
		flagdetail int,
		idivakind int,
		ivakind varchar(50),
		rate decimal(19,6),
		unabatabilitypercentage decimal(19,6),
		idivataxablekind int,
		ivakindflag int
	)


DECLARE @idinvkind INT
DECLARE @yinv INT
DECLARE @ninv INT 
DECLARE @adate SMALLDATETIME
DECLARE @idreg INT


DECLARE @idblacklist int
DECLARE @blcode char(3)

-- CICLO CON CURSORE PER DETERMINARE IL PAESE DI RESIDENZA DEL CLIENTE/FORNITORE
DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT I.idinvkind,
	   I.yinv,
       I.ninv,
       I.adate,
	   I.idreg
FROM invoice I
JOIN invoicekind IK 
ON I.idinvkind = IK.idinvkind
WHERE YEAR(I.adate) = @anno
AND I.adate BETWEEN @start AND @stop
--AND I.idblacklist IS NULL
AND EXISTS (SELECT * FROM ivaregister IR 
JOIN ivaregisterkind IRK 
ON IRK.idivaregisterkind = IR.idivaregisterkind 
WHERE  IR.idinvkind = I.idinvkind 
AND IR.yinv = I.yinv 
AND IR.ninv = I.ninv 
AND IRK.flagactivity IN (2,3))
FOR READ ONLY
OPEN rowcursor


FETCH NEXT FROM rowcursor
INTO  @idinvkind,
	  @yinv,
      @ninv,
      @adate,
	  @idreg
WHILE @@FETCH_STATUS = 0
BEGIN 
SET @idblacklist  = NULL
set @blcode  = NULL

EXECUTE [get_address] 
   @idreg
  ,@adate
  ,@idblacklist OUTPUT
  ,@blcode OUTPUT
	
 print @idblacklist
	IF (@idblacklist) IS NOT NULL
	BEGIN
		INSERT INTO #invoicedetail
			(
				idinvkind,
				invoicekind,
				yinv,
				ninv,
				adate,
				description,
				doc,
				docdate,
				idreg,
				registry,
				idblacklist,
				blnation,
				blcode,
				rownum,
				detaildescription,
				taxable_euro,
				iva_euro,
				unabatable_euro,
				rowtotal,
				flagdetail,
				idivakind,
				ivakind,
				rate,
				unabatabilitypercentage,
				idivataxablekind,
				ivakindflag
			)
		SELECT 
			I.idinvkind,
			IK.description,
			I.yinv,
			I.ninv,
			I.adate,
			I.description,
			I.doc,
			I.docdate,
			I.idreg,
			R.title,
			@idblacklist,
			blacklist.description,
			@blcode,
			IDET.rownum,
			IDET.detaildescription,
			CONVERT(decimal(19,2),
			ROUND(IDET.taxable * ISNULL(IDET.npackage,IDET.number) * 
			  CONVERT(DECIMAL(19,10),I.exchangerate) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
			 ,2
			)),
			CONVERT(decimal(19,2),ROUND(IDET.tax
						,2)
					),
			CONVERT(decimal(19,2), ROUND(IDET.unabatable 
							
						   ,2)
					),
			CONVERT(decimal(19,2), ROUND(IDET.taxable * ISNULL(IDET.npackage,IDET.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))),2
				))+
			CONVERT(decimal(19,2),ROUND(ISNULL(IDET.tax,0),2)),
			IDET.flag,
			IDET.idivakind,
			IVK.description,
			IVK.rate,
			IVK.unabatabilitypercentage,
			IVK.idivataxablekind,
			IVK.flag
		FROM registry as R
		JOIN invoice as I
			ON R.idreg = I.idreg
		JOIN invoicedetail as IDET
			ON IDET.idinvkind = I.idinvkind AND
			   IDET.yinv = I.yinv AND
			   IDET.ninv = I.ninv 
		JOIN ivakind IVK
			ON IVK.idivakind = IDET.idivakind
		JOIN invoicekind IK
			ON I.idinvkind = IK.idinvkind 
		JOIN blacklist
			ON blacklist.idblacklist = @idblacklist
		WHERE I.idinvkind = @idinvkind
		AND I.yinv = @yinv
		AND I.ninv = @ninv
		AND ((ISNULL(IVK.flag,0)&1) <> 0)  -- aliquota anche istituzionale
	END	
	ELSE
	BEGIN 
		IF ((SELECT COUNT(*) from registryaddress 
			 WHERE registryaddress.idreg  = @idreg 
			   AND stop is null  OR stop > @stop) = 0)
		INSERT INTO #invoicedetail
			(
				idinvkind,
				invoicekind,
				yinv,
				ninv,
				adate,
				description,
				doc,
				docdate,
				idreg,
				registry,
				idblacklist,
				blnation,
				blcode,
				rownum,
				detaildescription,
				taxable_euro,
				iva_euro,
				unabatable_euro,
				rowtotal,
				flagdetail,
				idivakind,
				ivakind,
				rate,
				unabatabilitypercentage,
				idivataxablekind,
				ivakindflag
			)
		SELECT 
			I.idinvkind,
			IK.description,
			I.yinv,
			I.ninv,
			I.adate,
			I.description,
			I.doc,
			I.docdate,
			I.idreg,
			R.title,
			null,
			'NON SPECIFICATA',
			null,
			IDET.rownum,
			IDET.detaildescription,
			CONVERT(decimal(19,2),
			ROUND(IDET.taxable * ISNULL(IDET.npackage,IDET.number) * 
			  CONVERT(DECIMAL(19,10),I.exchangerate) *
			  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0)))
			 ,2
			)),
			CONVERT(decimal(19,2),ROUND(IDET.tax
						,2)
					),
			CONVERT(decimal(19,2), ROUND(IDET.unabatable 
							
						   ,2)
					),
			CONVERT(decimal(19,2), ROUND(IDET.taxable * ISNULL(IDET.npackage,IDET.number) * 
					  CONVERT(DECIMAL(19,10),ISNULL(I.exchangerate,1)) *
					  (1 - CONVERT(DECIMAL(19,6),ISNULL(IDET.discount, 0.0))),2
				))+
			CONVERT(decimal(19,2),ROUND(ISNULL(IDET.tax,0),2)),
			IDET.flag,
			IDET.idivakind,
			IVK.description,
			IVK.rate,
			IVK.unabatabilitypercentage,
			IVK.idivataxablekind,
			IVK.flag
		FROM registry as R
		JOIN invoice as I
			ON R.idreg = I.idreg
		JOIN invoicedetail as IDET
			ON IDET.idinvkind = I.idinvkind AND
			   IDET.yinv = I.yinv AND
			   IDET.ninv = I.ninv 
		JOIN ivakind IVK
			ON IVK.idivakind = IDET.idivakind
		JOIN invoicekind IK
			ON I.idinvkind = IK.idinvkind
		WHERE I.idinvkind = @idinvkind
		AND I.yinv = @yinv
		AND I.ninv = @ninv
		AND ((ISNULL(IVK.flag,0)&1) <> 0)  -- aliquota anche istituzionale
	END
		
	FETCH NEXT FROM rowcursor
	INTO @idinvkind,
		 @yinv,
         @ninv,
         @adate,
	     @idreg
END 
DEALLOCATE rowcursor

SELECT 
		invoicekind as 'Tipo documento',
		yinv as 'Eserc.',
		ninv as 'Numero',
		adate as 'Data Registrazione',
		#invoicedetail.description as 'Descr. Fatt.',
		doc as 'Doc. collegato',
		docdate as 'Data doc. collegato',
		idreg as 'Codice Anagrafica',
		registry as 'Anagrafica',
		blnation as 'Nazione',
		blcode as 'Codice Nazione Black List',
		rownum as '#',
		detaildescription as 'Descr. Dett.',
		taxable_euro as 'Impon. EUR',
		iva_euro as 'IVA EUR',
		unabatable_euro as 'IVA indetr. EUR',
		rowtotal 'Tot. Dett.',
		CASE flagdetail
			WHEN 0 THEN 'Bene.'
			WHEN 1 THEN 'Servizio.'
			WHEN 2 THEN 'Non Spec.'
		END as 'Bene/Servizio',
		ivakind as 'Tipo IVA',
		rate * 100 as 'Aliq.',
		unabatabilitypercentage * 100 as '% Indetr.',
		ivataxablekind.description as 'Tipo Impos. Aliquota'
FROM #invoicedetail 
	join ivataxablekind  on ivataxablekind.idivataxablekind = #invoicedetail.idivataxablekind
	WHERE blnation is not null
ORDER BY MONTH(adate), invoicekind, yinv, ninv, rownum

END
GO


