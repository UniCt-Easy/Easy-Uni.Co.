
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_certfiscale_assegnisti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_certfiscale_assegnisti]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_unified_certfiscale_assegnisti]
	@ayear int,
	@idreg int,
        @unified char(1) -- consolidamento dei dati 
AS BEGIN	
	
IF (@unified <> 'S')
BEGIN
        EXEC rpt_certfiscale_assegnisti @ayear, @idreg 
        RETURN
END 

CREATE TABLE #unified(
        departmentname  varchar(150),
	idreg int,
	registry varchar(100),
	causale varchar(250),
	birthdate smalldatetime,
	b_place varchar(120),
	b_province varchar(2),
	b_nation varchar(65),
	cf varchar(16),
	cfestero varchar(40),
	taxable  decimal(19,2),
	taxableass decimal(19,2),
	adminretension decimal(19,2),
	employretension decimal(19,2),
	adminretensionass decimal(19,2),
	employretensionass decimal(19,2),
	amountgross decimal(19,2),
	officename varchar(50),
	sendaddress varchar(100),
	sendlocation varchar(120),
	sendcap varchar(20),
	sendprovince varchar(2),
	sendnation varchar(65)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
								where (start is null or start <= @ayear ) AND 
									  (stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.rpt_certfiscale_assegnisti'
PRINT @iddbdepartment
		INSERT INTO #unified (
                        departmentname,
                	idreg,
                	registry,
                	causale,
                	birthdate,
                	b_place,
                	b_province,
                	b_nation,
                	cf,
                	cfestero,
                	taxable,
                	taxableass,
                	adminretension,
                	employretension,
                	adminretensionass,
                	employretensionass,
                	amountgross,
                	officename,
                	sendaddress,
                	sendlocation,
                	sendcap,
                	sendprovince,
                	sendnation
		)
		EXEC @dip_nomesp @ayear, @idreg
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END

SELECT  
        departmentname,
	idreg,
	registry,
	causale,
	birthdate,
	b_place,
	b_province,
	b_nation,
	cf,
	cfestero,
	ISNULL(SUM(taxable),0) AS taxable    ,
	ISNULL(SUM(taxableass),0) AS taxableass,
	ISNULL(SUM(adminretension),0) AS adminretension,
	ISNULL(SUM(employretension),0) AS employretension,
	ISNULL(SUM(adminretensionass),0) AS adminretensionass,
	ISNULL(SUM(employretensionass),0) AS employretensionass,
	ISNULL(SUM(amountgross),0) AS amountgross,
	officename,
	sendaddress 	as 'spedaddress',
	sendlocation 	as 'spedlocation',
	sendcap		as 'spedcap',
	sendprovince 	as 'spedprovince',
	sendnation 	as 'spednation'
FROM #unified
--GROUP BY inserita pechè la sp interna per ogni percipiente calcola il SUM, quindi in out fornisce solo una riga con i totali.
GROUP BY idreg, registry, cf,cfestero,departmentname,
	birthdate,b_place,
	b_province,b_nation,
        causale,
	officename,sendaddress,sendlocation,sendcap,sendprovince,sendnation
ORDER BY registry ASC
	
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

