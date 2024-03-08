
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mod_blacklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mod_blacklist]
GO

--setuser 'amm'

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_mod_blacklist] (
	@anno int,
	@mese int, 
	@trimestre int,
	@periodicita char(1) -- M = dichiarazione Mensile, T = dichiarazione Trimestrale
)
AS
BEGIN

-- LA PARTE POSIZIONALE DEL RECORD C VA RIEMPITA CON I DATI RELATIVI AL CONTRIBUENTE 
-- E DELLA SOFTWARE HOUSE CHE IMPLEMENTA IL FILE TELEMATICO



CREATE TABLE #Fatture
(
	idreg int,
	idinvkind int,
	yinv int,
	ninv int,
	idblacklist int,
	blcode char(3),
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
	idinvkind int,
	yinv int,
	ninv int,
	rownum int,
	idblacklist int,
	blcode char(3),
	flagbuysell char(1), -- A acquisto / V vendita 
	exchangerate float,
	idinvkind_main int,
	yinv_main int,
	ninv_main int,
	rownum_main int,
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
	idinvkind,
	yinv,
	ninv,
	idblacklist,
	blcode,
	flagbuysell, -- A acquisto / V vendita 	
	exchangerate,
	adate
)
SELECT
	I.idreg,
	I.idinvkind,
	I.yinv,
	I.ninv,
	I.idblacklist,
	I.blcode,
	I.flagbuysell, -- A acquisto / V vendita 
	I.exchangerate,
	I.adate
FROM registry as R
JOIN invoiceview as I
	ON R.idreg = I.idreg
JOIN invoicekind IK
	ON I.idinvkind = IK.idinvkind
WHERE
(
	(@periodicita = 'M' AND MONTH(I.adate) = @mese) OR
	(@periodicita = 'T' AND MONTH(I.adate) between @meseinizio and @mesefine )
)
AND YEAR(I.adate) = @anno
AND I.flagvariation = 'N'
AND idblacklist IS NOT NULL
AND ISNULL(I.flag_invoice,2) = 0 -- l'utente ha scelto di inviare la comunicazione

INSERT INTO #NoteDiCredito
(
	idreg,
	idinvkind,
	yinv,
	ninv,
	rownum,
	idblacklist,
	blcode,
	flagbuysell, -- A acquisto / V vendita 
	exchangerate,
	idinvkind_main,
	yinv_main,
	ninv_main,
	rownum_main,
	adate,
	imponibileBeni,
	ivaBeni,
	imponibileServizi,
	ivaServizi
)
SELECT
	I.idreg,
	I.idinvkind,
	I.yinv,
	I.ninv,
	ID.rownum,
	I.idblacklist,
	I.blcode,
	I.flagbuysell, -- A acquisto / V vendita 
	I.exchangerate,
	null,
	ID.yinv_main,
	ID.ninv_main,
	ID.rownum_main,
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
WHERE
(
	(@periodicita = 'M' AND MONTH(I.adate) = @mese) OR
	(@periodicita = 'T' AND MONTH(I.adate) between @meseinizio and @mesefine )
)
AND YEAR(I.adate) = @anno
AND I.flagvariation = 'S'
AND ID.yinv_main IS NOT NULL
AND idblacklist IS NOT NULL
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
			  AND IVTK.description = 'Fuori Campo'
		)

CREATE TABLE #tRecordC
(	
	iddbdepartment						varchar(50),
	adate								smalldatetime,
	idreg								int,
	-- Operazioni ATTIVE
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliCessioni				decimal(19,2),  --A1002001
	totIvaCessioni						decimal(19,2),  --A1003001
	--- Prestazioni di Servizi
	totImponibiliPrestazioni			decimal(19,2),   --A1004001
	totIvaPrestazioni					decimal(19,2),   --A1005001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliCessioni			decimal(19,2),  --A1006001
	totNonImponibiliPrestazioni			decimal(19,2),	--A1007001
	-- OPERAZIONI ESENTI
	totEsenti							decimal(19,2),	--A1008001
	totNonSoggetteCessioni				decimal(19,2),	--A1009001
	totNonSoggettePrestazioni			decimal(19,2),  --A10010001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarCessioniAnnoCorr			decimal(19,2),  --A1011001
	totIvaVarCessioniAnnoCorr			decimal(19,2),	--A1012001
	totImponVarPrestazioniAnnoCorr		decimal(19,2),	--A1013001
	totIvaVarPrestazioniAnnoCorr		decimal(19,2),	--A1014001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarCessioniAnnoPrec			decimal(19,2),	--A1015001
	totIvaVarCessioniAnnoPrec			decimal(19,2),	--A1016001
	totImponVarPrestazioniAnnoPrec		decimal(19,2),	--A1017001
	totIvaVarPrestazioniAnnoPrec		decimal(19,2),	--A1018001
	-- Operazioni PASSIVE
	-- OPERAZIONI IMPONIBILI
	-- cessioni di Beni
	totImponibiliAcquisti				decimal(19,2),	--A1019001
	totIvaAcquisti						decimal(19,2),	--A1020001
	--- Prestazioni di Servizi
	totImponibiliServizi				decimal(19,2),	--A1021001
	totIvaServizi						decimal(19,2),	--A1022001
	-- OPERAZIONI NON IMPONIBILI
	totNonImponibiliAcquisti			decimal(19,2),	--A1023001
	totNonImponibiliServizi				decimal(19,2),	--A1024001
	-- OPERAZIONI ESENTI
	totEsentiPassive					decimal(19,2),	--A1025001
	totNonSoggetteAcquisti				decimal(19,2),	--A1026001
	totNonSoggetteServizi				decimal(19,2),	--A1027001
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarAcquistiAnnoCorr			decimal(19,2),	--A1028001
	totIvaVarAcquistiAnnoCorr			decimal(19,2),	--A1029001
	totImponVarServiziAnnoCorr			decimal(19,2),	--A1030001
	totIvaVarServiziAnnoCorr			decimal(19,2),	--A1031001
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarAcquistiAnnoPrec			decimal(19,2),	--A1032001
	totIvaVarAcquistiAnnoPrec			decimal(19,2),	--A1033001
	totImponVarServiziAnnoPrec			decimal(19,2),  --A1034001
	totIvaVarServiziAnnoPrec			decimal(19,2)	--A1035001
)


--------------------------
--- Operazioni ATTIVE  ---
--------------------------

INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	totImponibiliCessioni				,	--A1002001
	totIvaCessioni						,	--A1003001
	totImponibiliPrestazioni			,	--A1004001
	totIvaPrestazioni					,	--A1005001
	totNonImponibiliCessioni			,	--A1006001
	totNonImponibiliPrestazioni			,	--A1007001
	totEsenti							,	--A1008001
	totNonSoggetteCessioni				,	--A10010001
	totNonSoggettePrestazioni
)
SELECT
	#Fatture.idreg,
	#Fatture.adate,
	#Fatture.imponibileBeni,
	#Fatture.ivaBeni,
	#Fatture.imponibileServizi,
	#Fatture.ivaServizi,
	#Fatture.nonImponibileBeni,
	#Fatture.nonImponibileServizi,
	#Fatture.ammontareEsenti,
	#Fatture.nonSoggetteBeni,
	#Fatture.nonSoggetteServizi
FROM  #Fatture
WHERE #Fatture.flagbuysell = 'V'

---------------------------
--- Operazioni PASSIVE  ---
---------------------------

INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	totImponibiliAcquisti				,	--A1019001
	totIvaAcquisti						,	--A1020001
	totImponibiliServizi				,	--A1021001
	totIvaServizi						,	--A1022001
	totNonImponibiliAcquisti			,	--A1023001
	totNonImponibiliServizi				,	--A1024001
	totEsentiPassive					,	--A1025001
	totNonSoggetteAcquisti				,	--A1026001
	totNonSoggetteServizi					--A1027001
)
SELECT
	#Fatture.idreg,
	#Fatture.adate,
	#Fatture.imponibileBeni,
	#Fatture.ivaBeni,
	#Fatture.imponibileServizi,
	#Fatture.ivaServizi,
	#Fatture.nonImponibileBeni,
	#Fatture.nonImponibileServizi,
	#Fatture.ammontareEsenti,
	#Fatture.nonSoggetteBeni,
	#Fatture.nonSoggetteServizi
FROM  #Fatture
WHERE #Fatture.flagbuysell = 'A'


----------------------------------
--- Note di Variazione ATTIVE  ---
----------------------------------

INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarCessioniAnnoCorr			,  --A1011001
	totIvaVarCessioniAnnoCorr			,  --A1012001
	totImponVarPrestazioniAnnoCorr		,  --A1013001
	totIvaVarPrestazioniAnnoCorr		   --A1014001
)
SELECT
	#NoteDiCredito.idreg,
	#NoteDiCredito.adate,
	#NoteDiCredito.imponibileBeni,
	#NoteDiCredito.ivaBeni,
	#NoteDiCredito.imponibileServizi,
	#NoteDiCredito.ivaServizi
FROM  #NoteDiCredito
WHERE #NoteDiCredito.flagbuysell = 'V'
AND	  #NoteDiCredito.yinv_main = @anno


INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarCessioniAnnoPrec			,	--A1015001
	totIvaVarCessioniAnnoPrec			,	--A1016001
	totImponVarPrestazioniAnnoPrec		,	--A1017001
	totIvaVarPrestazioniAnnoPrec			--A1018001
)
SELECT
	#NoteDiCredito.idreg,
	#NoteDiCredito.adate,
	#NoteDiCredito.imponibileBeni,
	#NoteDiCredito.ivaBeni,
	#NoteDiCredito.imponibileServizi,
	#NoteDiCredito.ivaServizi
FROM  #NoteDiCredito
WHERE #NoteDiCredito.flagbuysell = 'V'
AND	  #NoteDiCredito.yinv_main < @anno

-----------------------------------
--- Note di Variazione PASSIVE  ---
-----------------------------------
INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	-- NOTE DI VARIAZIONE ANNO CORRENTE
	totImponVarAcquistiAnnoCorr			,	--A1028001
	totIvaVarAcquistiAnnoCorr			,	--A1029001
	totImponVarServiziAnnoCorr			,	--A1030001
	totIvaVarServiziAnnoCorr				--A1031001
)
SELECT
	#NoteDiCredito.idreg,
	#NoteDiCredito.adate,
	#NoteDiCredito.imponibileBeni,
	#NoteDiCredito.ivaBeni,
	#NoteDiCredito.imponibileServizi,
	#NoteDiCredito.ivaServizi
FROM  #NoteDiCredito
WHERE #NoteDiCredito.flagbuysell = 'A'
AND	  #NoteDiCredito.yinv_main = @anno


INSERT INTO #tRecordC
(
	idreg								,
	adate								,
	-- NOTE DI VARIAZIONE ANNI PRECEDENTE
	totImponVarAcquistiAnnoPrec			,	--A1032001
	totIvaVarAcquistiAnnoPrec			,	--A1033001
	totImponVarServiziAnnoPrec			,	--A1034001
	totIvaVarServiziAnnoPrec				--A1035001
)
SELECT
	#NoteDiCredito.idreg,
	#NoteDiCredito.adate,
	#NoteDiCredito.imponibileBeni,
	#NoteDiCredito.ivaBeni,
	#NoteDiCredito.imponibileServizi,
	#NoteDiCredito.ivaServizi
FROM  #NoteDiCredito
WHERE #NoteDiCredito.flagbuysell = 'A'
AND	  #NoteDiCredito.yinv_main < @anno

UPDATE #tRecordC SET iddbdepartment = user

SELECT * FROM  #tRecordC
--SELECT * FROM  #Fatture
--SELECT * FROM  #Dettaglio_FORNITORI_CLIENTI
--SELECT * FROM  #NoteDiCredito
	
DROP TABLE #Fatture
DROP TABLE #NoteDiCredito
DROP TABLE #tRecordC

END

