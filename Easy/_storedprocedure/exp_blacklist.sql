
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_blacklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_blacklist]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_blacklist] (
	@anno int,
	@mese int, 
	@trimestre int,
	@periodicita char(1) -- M = dichiarazione Mensile, T = dichiarazione Trimestrale
)
AS
BEGIN

--[exp_blacklist] 2010,null, 1, 'T'

CREATE TABLE #Fatture
(
	idreg int,
	registry varchar(100),
	idinvkind int,
	invoicekind varchar(50),
	yinv int,
	ninv int,
	rownum int,
	idblacklist int,
	blcode char(3),
	blacklist varchar(100),
	flagbuysell char(1), -- A acquisto / V vendita 
	exchangerate float,
	adate smalldatetime,
	-- sezione operazioni imponibili
	imponibileBeni decimal(19,2),
	ivaBeni decimal(19,2),
	imponibileServizi decimal(19,2),
	ivaServizi decimal(19,2),
	--sezione operazioni non imponibili
	nonImponibileBeni decimal(19,2),
	nonImponibileServizi decimal(19,2),
	--sezione operazioni esenti
	ammontareEsenti decimal(19,2),
	--sezione non soggette (Fuori Campo Iva)
	nonSoggetteBeni decimal(19,2),
	nonSoggetteServizi decimal(19,2)
)

CREATE TABLE #NoteDiCredito
(
	idreg int,
	registry varchar(100),
	idinvkind int,
	invoicekind varchar(50),
	yinv int,
	ninv int,
	rownum int,
	idblacklist int,
	blcode char(3),
	blacklist varchar(100),
	flagbuysell char(1), -- A acquisto / V vendita 
	exchangerate float,
	idinvkind_main int,
	yinv_main int,
	ninv_main int,
	-- sezione ammontare complessivo
	imponibileBeni decimal(19,2),
	ivaBeni decimal(19,2),
	imponibileServizi decimal(19,2),
	ivaServizi decimal(19,2),
	adate smalldatetime
)

DECLARE @meseinizio int
DECLARE @mesefine int

IF (@periodicita = 'T')
begin
	SELECT 
		@meseinizio= case	
			when @trimestre = 1 then 1
			when @trimestre = 2 then 4
			when @trimestre = 3 then 7 
			when @trimestre = 4 then 10
			End,
		@mesefine = case
			when @trimestre = 1 then 3
			when @trimestre = 2 then 6
			when @trimestre = 3 then 9 
			when @trimestre = 4 then 12
			End
end

 -- estrazione delle fatture (non note di credito) del periodo di riferimento
INSERT INTO #Fatture
(
	idreg,
	registry,
	idinvkind,
	invoicekind,
	yinv,
	ninv,
	rownum,
	idblacklist,
	blcode,
	blacklist,
	flagbuysell, -- A acquisto / V vendita 	
	exchangerate,
	adate
)
SELECT
	I.idreg,
	R.title,
	I.idinvkind,
	IK.description,
	I.yinv,
	I.ninv,
	ID.rownum,
	I.idblacklist,
	I.blcode,
	blacklist.description,
	I.flagbuysell, -- A acquisto / V vendita 
	I.exchangerate,
	I.adate
FROM registry as R
JOIN invoiceview as I
	ON R.idreg = I.idreg
JOIN invoicedetailview as ID
	ON I.idinvkind = ID.idinvkind
   AND I.yinv = ID.yinv
   AND I.ninv = ID.ninv
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN blacklist 
	ON I.idblacklist = blacklist.idblacklist
WHERE
(
	(@periodicita = 'M' AND MONTH(I.adate) = @mese) OR
	(@periodicita = 'T' AND MONTH(I.adate) between @meseinizio and @mesefine )
)
AND YEAR(I.adate) = @anno
AND I.flagvariation = 'N'
AND I.idblacklist IS NOT NULL
AND ISNULL(I.flag_invoice,2) = 0 -- l'utente ha scelto di inviare la comunicazione

INSERT INTO #NoteDiCredito   -- NOTE DI CREDITO
(
	idreg,
	registry,
	idinvkind,
	invoicekind,
	yinv,
	ninv,
	rownum,
	idblacklist,
	blcode,
	blacklist,
	flagbuysell, -- A acquisto / V vendita 
	exchangerate,
	idinvkind_main,
	yinv_main,
	ninv_main,
	adate,
	imponibileBeni,
	ivaBeni,
	imponibileServizi,
	ivaServizi
)
SELECT
	I.idreg,
	R.title,
	I.idinvkind,
	IK.description,
	I.yinv,
	I.ninv,
	ID.rownum,
	I.idblacklist,
	I.blcode,
	blacklist.description,
	I.flagbuysell, -- A acquisto / V vendita 
	I.exchangerate,
	null,
	ID.yinv_main,
	ID.ninv_main,
	I.adate,
	CASE 
		WHEN ID.flag_invoicedetail = 0 -- beni
		THEN ROUND(ISNULL(ID.taxable_euro,0),0)
		ELSE 0 --servizi
	END,
	CASE 
		WHEN ID.flag_invoicedetail = 0 -- beni
		THEN ROUND(ISNULL(ID.iva_euro,0),0)
		ELSE 0 
	END,
	CASE 
		WHEN ID.flag_invoicedetail = 1 --servizi
		THEN ROUND(ISNULL(ID.taxable_euro,0),0) 
		ELSE 0
	END,
	CASE 
		WHEN ID.flag_invoicedetail = 1 --servizi
		THEN ROUND(ISNULL(ID.iva_euro,0),0)
		ELSE 0
	END
FROM registry as R
JOIN invoiceview as I
	ON R.idreg = I.idreg
JOIN invoicedetailview as ID
	ON I.idinvkind = ID.idinvkind
   AND I.yinv = ID.yinv
   AND I.ninv = ID.ninv
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
JOIN blacklist 
	ON I.idblacklist = blacklist.idblacklist
WHERE
(
	(@periodicita = 'M' AND MONTH(I.adate) = @mese) OR
	(@periodicita = 'T' AND MONTH(I.adate) between @meseinizio and @mesefine )
)
AND YEAR(I.adate) = @anno
AND I.flagvariation = 'S'
AND ID.yinv_main IS NOT NULL
AND I.idblacklist IS NOT NULL
AND ISNULL(I.flag_invoice,2) = 0 -- l'utente ha scelto di inviare la comunicazione

-----------------------------------
-- sezione operazioni imponibili --
-----------------------------------

UPDATE #Fatture
   SET imponibileBeni = 
		(SELECT ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 0 -- beni
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Imponibile'
		)
					

UPDATE #Fatture
   SET ivaBeni =(SELECT  ROUND(ISNULL(SUM(ID.iva_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 0 -- beni
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Imponibile'
		)

UPDATE #Fatture
   SET imponibileServizi = (SELECT  ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 1 -- servizi
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Imponibile'
		)

UPDATE #Fatture
   SET ivaServizi =(SELECT  ROUND(ISNULL(SUM(ID.iva_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 1 -- servizi
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Imponibile'
		)
---------------------------------------
-- sezione operazioni non imponibili --
---------------------------------------
----------
-- BENI --
----------
UPDATE #Fatture
   SET nonImponibileBeni = (SELECT  ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 0 -- beni
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Non Imponibile'
		)

-------------
-- SERVIZI --
-------------

UPDATE #Fatture
   SET nonImponibileServizi = (SELECT  ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE ID.flag_invoicedetail = 1 -- servizi
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Non Imponibile'
		)

-------------------------------
-- sezione operazioni esenti --
-------------------------------
UPDATE #Fatture
   SET ammontareEsenti = (SELECT  ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE (ID.flag_invoicedetail = 0 or ID.flag_invoicedetail = 1)  -- beni o servizi
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Esenti'
		)

------------------------------------
-- sezione operazioni Fuori Campo --
------------------------------------
UPDATE #Fatture
   SET nonSoggetteBeni = (SELECT  ROUND(ISNULL(SUM(ID.iva_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE (ID.flag_invoicedetail = 0)  -- beni
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Fuori Campo'
		)


------------------------------------
-- sezione operazioni Fuori Campo --
------------------------------------
UPDATE #Fatture
   SET nonSoggetteServizi = (SELECT  ROUND(ISNULL(SUM(ID.taxable_euro),0),0)
			FROM invoicedetailview ID
			JOIN ivakind IVK 
			  ON  IVK.idivakind = ID.idivakind
			JOIN ivataxablekind IVTK
			  ON IVTK.idivataxablekind = IVK.idivataxablekind
			WHERE (ID.flag_invoicedetail = 1)  -- servizi
			  AND #Fatture.idinvkind = ID.idinvkind
			  AND #Fatture.yinv = ID.yinv 
			  AND #Fatture.ninv = ID.ninv
			  AND #Fatture.rownum = ID.rownum
			  AND IVTK.description = 'Fuori Campo'
		)

DECLARE @dbdepartment varchar(150)

SELECT @dbdepartment = description FROM dbdepartment
WHERE iddbdepartment = user

SELECT 
@dbdepartment as 'Dipartimento',
idreg as 'Cod. Anag',
registry as 'Anagrafica',
invoicekind as 'Tipo Doc. IVA',
flagbuysell as 'A/V',
yinv as 'Eserc.',
ninv as 'Num.',
rownum as 'Riga',
null as 'Esercizio Fattura Princ.',
null as 'Numero Fattura Princ.',
blcode as 'Codice BL',
blacklist as 'nazione',
adate as 'Data Cont.',
-- sezione operazioni imponibili 
imponibileBeni as 'Imponibile Beni',
ivaBeni as 'Iva Beni',
imponibileServizi as 'Imponibile Servizi',
ivaServizi as 'Iva Servizi',
--sezione operazioni non imponibili
nonImponibileBeni as 'Non Impon. Beni',
nonImponibileServizi as 'Non Impon. Servizi',
--sezione operazioni esenti
ammontareEsenti as 'Esenti',
--sezione non soggette (Fuori Campo Iva)
nonSoggetteBeni as 'Fuori Campo Iva Beni',
nonSoggetteServizi as 'Fuori Campo Iva Servizi'
FROM #Fatture
UNION ALL
SELECT
@dbdepartment as 'Dipartimento',
idreg as 'Cod. Anag',
registry as 'Anagrafica',
invoicekind as 'Tipo Doc. IVA',
flagbuysell as 'A/V',
yinv as 'Eserc.',
ninv as 'Num.',
rownum as 'Riga',
yinv_main as 'Esercizio Fattura Princ.',
ninv_main as 'Numero Fattura Princ.',
blcode as 'Codice BL',
blacklist as 'nazione',
adate as 'Data Cont.',
-- sezione operazioni imponibili 
imponibileBeni as 'Imponibile Beni',
ivaBeni as 'Iva Beni',
imponibileServizi as 'Imponibile Servizi',
ivaServizi as 'Iva Servizi',
--sezione operazioni non imponibili
0 as 'Non Impon. Beni',
0 as 'Non Impon. Servizi',
--sezione operazioni esenti
0 as 'Esenti',
--sezione non soggette (Fuori Campo Iva)
0 as 'Fuori Campo Iva Beni',
0 as 'Fuori Campo Iva Servizi'
FROM #NoteDiCredito

--SELECT * FROM  #tRecordC
--SELECT * FROM  #Fatture
--SELECT * FROM  #NoteDiCredito
	
DROP TABLE #Fatture
DROP TABLE #NoteDiCredito

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

