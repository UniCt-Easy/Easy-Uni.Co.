
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[c]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_paydispositionrefund]
GO
--setuser 'amm'
--setuser 'amministrazione'

CREATE PROCEDURE compute_paydispositionrefund(	@idpaydisposition int)
AS 
BEGIN


declare @ayear int
select @ayear = ayear from paydisposition where idpaydisposition = @idpaydisposition

DECLARE @cf varchar(11)
select @cf = isnull(cf, p_iva) from license
if @cf is null
begin
	SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_f'
end
IF (@cf IS NULL)
BEGIN
	SELECT @cf = paramvalue FROM generalreportparameter WHERE idparam = 'License_P_Iva'	
END

	DECLARE @agencyname varchar(60) -- 60 è limite imposto per la compilazione del 770
	DECLARE @phonenumber varchar(20)
	DECLARE @fax varchar(20)
	DECLARE @email varchar(100)
	DECLARE @location varchar(40)
	DECLARE @country varchar(2)
	DECLARE @address varchar(35)
	DECLARE @cap varchar(5)
	SELECT
		@agencyname = SUBSTRING(license.agencyname, 1, 60),
		@phonenumber = license.phonenumber,
		@fax = license.fax,
		@email = license.email,
		@location = SUBSTRING(isnull(geo_city.title, license.location), 1, 40),
		@country = license.country,
		@address = SUBSTRING(license.address1, 1, 35),
		@cap = license.cap
		FROM license
		left outer join geo_city on geo_city.idcity = license.idcity

CREATE TABLE #output( riga  varchar(1800) )
	
INSERT INTO #output(riga)
SELECT 
-- tipo record 
'0'
--Codice identificativo della fornitura  
+ 'SUV00'
--Tipologia di invio(0 = Invio ordinario)
+ '0'
-- Protocollo telematico da sostituire o annullare
+ space(17)
-- Codice Fiscale dell'Università [11]
+  ISNULL(@cf,'') + SUBSTRING(SPACE(11),1, 11 - DATALENGTH(ISNULL(@cf,'')))
 --DATI ANAGRAFICI DELL'UNIVERSITA' (SOGGETTO OBBLIGATO)Denominazione [60]
+  ISNULL(@agencyname,'') + SUBSTRING(SPACE(60),1, 60 - DATALENGTH(ISNULL(@agencyname,'')))
--Comune del domicilio fiscale [40]
+  ISNULL(@location,'') + SUBSTRING(SPACE(40),1, 40 - DATALENGTH(ISNULL(@location,'')))
-- provincial del domicilio fiscale [2]
+ isnull(@country, space(2))
--TIPO UNIVERSITà: A = Università statale, B = Università non statale : ** DA RIVEDERE!! **
+ 'A'
--Anno di riferimento
+ CONVERT(varchar(4),@ayear)
-- DATI RISERVATI AL SOGGETTO CHE ASSUME L'IMPEGNO ALLA PRESENTAZIONE TELEMATICA		
-- Codice fiscale dell'intermediario che effettua la trasmissione 
+ space(16)
-- Impegno a trasmettere in via telematica la comunicazione. 1 = Comunicazione predisposta dal contribuente, 2 = Comunicazione  predisposta da chi effettua l'invio
+ space(1)
-- CARATTERI DI CONTROLLO
+ space(1638)	-- Filler 
+ 'A' --  Carattere di controllo AN Vale sempre "A" Dato obbligatorio.

DECLARE @len_amount int
SET @len_amount = 9

CREATE TABLE #record2(
	cfstudente varchar(16),
	calendaryear int,
	amount decimal(19,2)
)

insert into #record2 (cfstudente, calendaryear, amount)
select cf, calendaryear, sum(amount)
from paydispositiondetail
where idpaydisposition = @idpaydisposition
	and paydispositiondetail.calendaryear< @ayear
	and isnull(paydispositiondetail.flagtaxrefund,'N') = 'S'
group by cf, calendaryear

declare @campi varchar(1160)
declare @cfstudente varchar(16)
declare @calendaryear int
declare @amount decimal(19,2)

CREATE TABLE #outputrec2(cfstudente varchar(16), riga  varchar(1160) )
INSERT INTO #outputrec2 (cfstudente) 
SELECT DISTINCT cfstudente FROM #record2

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT cfstudente, calendaryear, amount FROM #record2
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @cfstudente, @calendaryear, @amount
	WHILE (@@fetch_status=0) BEGIN
		set @campi =  ISNULL(@cfstudente,'') + SUBSTRING(SPACE(16),1, 16 - DATALENGTH(ISNULL(@cfstudente,'')))
				-- anno solare
				+ CONVERT(varchar(4), @calendaryear)
				--solo parte intera [9]
				+ SUBSTRING(REPLICATE(' ',@len_amount),1, @len_amount - 	DATALENGTH(CONVERT(varchar(9), CONVERT(INT, @amount)))) +
					SUBSTRING(CONVERT(varchar(9), CONVERT(INT, @amount)),1,	DATALENGTH(CONVERT(varchar(9), CONVERT(INT, @amount))))

		update #outputrec2 set riga = isnull(riga,'')+@campi WHERE cfstudente = @cfstudente
	
	FETCH NEXT FROM cursore 
	INTO @cfstudente, @calendaryear, @amount
	END
CLOSE cursore
DEALLOCATE cursore


INSERT INTO #output(riga)
SELECT 
-- tipo record 
'2'
+  ISNULL(cfstudente,'') + SUBSTRING(SPACE(16),1, 16 - DATALENGTH(ISNULL(cfstudente,'')))
+ riga
/*
+  ISNULL(cf,'') + SUBSTRING(SPACE(16),1, 16 - DATALENGTH(ISNULL(cf,'')))
-- anno solare
+ CONVERT(varchar(4), calendaryear)
 --solo parte intera [9]
+ SUBSTRING(REPLICATE(' ',@len_amount),1, @len_amount - 	DATALENGTH(CONVERT(varchar(9), CONVERT(INT, amount)))) +
			SUBSTRING(CONVERT(varchar(9), CONVERT(INT, amount)),1,	DATALENGTH(CONVERT(varchar(9), CONVERT(INT, amount))))
+ space(1131)-- Filler
*/
+ space(1160 - len(riga))
+ space(620)-- Filler
--  Carattere di controllo AN Vale sempre "A" Dato obbligatorio.
+ 'A'
from #outputrec2

declare @publicagency char(1)
select @publicagency = publicagency from uniconfig
if(@publicagency = 'S')
begin 
 SET @publicagency = 'A'
End
else
begin 
 SET @publicagency = 'B'
End

INSERT INTO #output(riga)
SELECT 
-- tipo record 
'9'+ 'SUV00' 
+ '0' -- Tipologia Invio
+ space(17) -- Protocollo telematico da sostituire o annullare
-- Codice Fiscale dell'Università [11]
+  ISNULL(@cf,'') + SUBSTRING(SPACE(11),1, 11 - DATALENGTH(ISNULL(@cf,'')))
 --DATI ANAGRAFICI DELL'UNIVERSITA' (SOGGETTO OBBLIGATO)Denominazione [60]
+  ISNULL(@agencyname,'') + SUBSTRING(SPACE(60),1, 60 - DATALENGTH(ISNULL(@agencyname,'')))
--Comune del domicilio fiscale [40]
+  ISNULL(@location,'') + SUBSTRING(SPACE(40),1, 40 - DATALENGTH(ISNULL(@location,'')))
-- provincial del domicilio fiscale [2]
+ isnull(@country, space(2))
--TIPO UNIVERSITà: A = Università statale, B = Università non statale : ** DA RIVEDERE!! **
+ 'A'
--Anno di riferimento
+ CONVERT(varchar(4),@ayear)
+ space(16)
-- Impegno a trasmettere in via telematica la comunicazione. 1 = Comunicazione predisposta dal contribuente, 2 = Comunicazione  predisposta da chi effettua l'invio
+ space(1)
+ space(1638)-- Filler
--  Carattere di controllo AN Vale sempre "A" Dato obbligatorio.
+ 'A'

SELECT * FROM #output

END



