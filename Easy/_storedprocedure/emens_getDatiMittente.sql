
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emens_getDatiMittente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emens_getDatiMittente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE          PROCEDURE [emens_getDatiMittente]
(
	@ayear int
)
AS BEGIN
CREATE TABLE #sender
(
	cfpersonamittente varchar(16),
	ragsocmittente varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS,
	cfmittente varchar(16),
	cfsoftwarehouse varchar(16),
	flagesisteresponsabile char(1)
)
DECLARE @CFSAM varchar(16)
SET @CFSAM = '05587470724'
DECLARE @minlen_firmname int
SET @minlen_firmname = 2
DECLARE @maxlen_firmname int
SET @maxlen_firmname = 50
DECLARE @code_doc varchar(20)
SET @code_doc = 'EMENS'
DECLARE @cf_humansender varchar(16)
DECLARE @exists_manager char(1)
IF (SELECT COUNT(*) FROM trasmissionmanager
WHERE idtrasmissiondocument = @code_doc
AND ayear = @ayear) = 0
BEGIN
	SET @exists_manager = 'N'
END
ELSE
BEGIN
	SET @exists_manager = 'S'
	SELECT @cf_humansender = cf
	FROM trasmissionmanagerview
	WHERE idtrasmissiondocument = @code_doc
		AND ayear = @ayear
END
INSERT INTO #sender
(
	cfpersonamittente,
	ragsocmittente,
	cfmittente,
	cfsoftwarehouse,
	flagesisteresponsabile
)
SELECT
@cf_humansender,
CASE
	WHEN DATALENGTH(license.agencyname) BETWEEN @minlen_firmname AND @maxlen_firmname
		THEN license.agencyname
	WHEN DATALENGTH(license.agencyname) > @maxlen_firmname
		THEN SUBSTRING(license.agencyname,1,@maxlen_firmname)
	WHEN DATALENGTH(license.agencyname) < @minlen_firmname
		THEN license.agencyname + REPLICATE('.',@minlen_firmname - DATALENGTH(license.agencyname))
END,
cf,
@CFSAM,
@exists_manager
FROM license
UPDATE #sender SET ragsocmittente = 
SUBSTRING(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
ragsocmittente,
'Ç','c'),'ç','c'),'€','e'),'|',' '),'\',' '),'£',' '),'§',' '),'@',' '),'[',' '),'#',' '),'!',' '),'$',' '),
'Ö','o'),'Ü','u'),'Ñ','n'),'Ð','d'),'Ê','e'),'Ë','e'),'Î','i'),'Ï','i'),'Ô','o'),'Õ','o'),'Û','u'),'Ý','y'),
':',' '),';',' '),'<',' '),'=',' '),'>',' '),'?',' '),']',' '),'_',' '),'`',' '),'{',' '),'}',' '),'~',' '),
'ü','u'),'â','a'),'ä','a'),'å','a'),'ê','e'),'ë','e'),'ï','i'),'î','i'),'Ä','a'),'Å','a'),'ô','o'),'ö','o'),
'û','u'),'ÿ','y'),'ñ','n'),'Â','a'),'¥','y'),'ã','a'),'Ã','a'),'õ','o'),'ý','y'),
'é','e'''),'à','a'''),'è','e'''),'ì','i'''),'ò','o'''),'ù','u'''),'á','a'''),'í','i'''),'ó','o'''),'É','e'''),
'Á','a'''),'À','a'''),'È','e'''),'Í','i'''),'Ì','i'''),'Ó','o'''),'Ò','o'''),'Ú','u'''),'Ù','u'''),
1,@maxlen_firmname)
SELECT *
FROM #sender
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

