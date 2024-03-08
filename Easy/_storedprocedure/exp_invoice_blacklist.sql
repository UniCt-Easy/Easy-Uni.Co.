
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice_blacklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoice_blacklist]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_invoice_blacklist]
(	@anno int,
	@start smalldatetime,
	@stop smalldatetime
)
AS
BEGIN
CREATE TABLE #invoice
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
		blcode char(3)
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
AND I.idblacklist IS NULL
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
		INSERT INTO #invoice
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
				blcode
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
			@blcode
		FROM registry as R
		JOIN invoice as I
			ON R.idreg = I.idreg
		JOIN invoicekind IK
			ON I.idinvkind = IK.idinvkind
		JOIN blacklist
			ON blacklist.idblacklist = @idblacklist
		WHERE I.idinvkind = @idinvkind
		AND I.yinv = @yinv
		AND I.ninv = @ninv
	END	
	ELSE
	BEGIN 
		IF ((SELECT COUNT(*) from registryaddress 
			 WHERE registryaddress.idreg  = @idreg 
			   AND stop is null OR stop > @stop ) = 0)
		INSERT INTO #invoice
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
				blcode
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
			null
		FROM registry as R
		JOIN invoice as I
			ON R.idreg = I.idreg
		JOIN invoicekind IK
			ON I.idinvkind = IK.idinvkind
		WHERE I.idinvkind = @idinvkind
		AND I.yinv = @yinv
		AND I.ninv = @ninv
	
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
		description as 'Descrizione',
		doc as 'Doc. collegato',
		docdate as 'Data doc. collegato',
		idreg as 'Codice Anagrafica',
		registry as 'Anagrafica',
		blnation as 'Nazione',
		blcode as 'Codice Nazione Black List'
FROM #invoice WHERE blnation is not null
ORDER BY MONTH(adate), invoicekind, yinv, ninv

END
GO


 
