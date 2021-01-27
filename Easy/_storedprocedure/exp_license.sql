
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_license]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_license]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE      PROCEDURE [exp_license]
 @forced char(1)
AS BEGIN
DECLARE @flagsent char(1)
DECLARE @fieldname varchar(256)
DECLARE @sent_string varchar(1000)
DECLARE @SQL_string nvarchar(150)
DECLARE @idreg int
DECLARE @flagswmore int
SELECT @flagsent = ISNULL(sent,'N') FROM license
if (@forced='1') SET @flagsent='N'

CREATE TABLE #temp
(
	sentstring varchar(2000)
)

IF (@flagsent = 'N')
BEGIN
	SELECT @idreg = ISNULL(idreg,0),
	       @flagswmore= ISNULL(swmoreflag,-1) FROM license
	SET @sent_string = 'CAP=''' + REPLACE((SELECT ISNULL(cap,'NULL') FROM license),'','''') + ''';'
	SET @sent_string = @sent_string + 'CODICECREDDEB=''';
	IF (@idreg = 0) SET @sent_string = @sent_string + 'NULL'';'
	ELSE SET @sent_string = @sent_string + CONVERT(varchar(20),@idreg) + ''';'
	SET @sent_string = @sent_string + 'codiceente=''' + REPLACE((SELECT ISNULL(agencycode,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'CF=''' + REPLACE((SELECT ISNULL(cf,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'indirizzo_1=''' + REPLACE((SELECT ISNULL(address1,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'indirizzo_2=''' + REPLACE((SELECT ISNULL(address2,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'localita=''' + REPLACE((SELECT ISNULL(location,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'ente=''' + REPLACE((SELECT ISNULL(departmentname,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'univ=''' + REPLACE((SELECT ISNULL(agencyname,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'partitaiva=''' + REPLACE((SELECT ISNULL(p_iva,'NULL') FROM license),'''','''''') + ''';'
	SET @sent_string = @sent_string + 'provincia=''' + REPLACE((SELECT ISNULL(country,'NULL') FROM license),'''','''''')+''';';
	print @flagswmore
	if (@flagswmore =-1) BEGIN
		SET @sent_string = @sent_string + 'codiceswmore=''NULL'''
	END
	ELSE BEGIN
        SET @sent_string = @sent_string + 'codiceswmore='''+
			CONVERT(varchar(20),@flagswmore) + ''''
	END

	INSERT INTO #temp VALUES(@sent_string)
END

SELECT * FROM #temp
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

