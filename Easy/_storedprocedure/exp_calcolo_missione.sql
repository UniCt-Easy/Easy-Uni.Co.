
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_calcolo_missione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_calcolo_missione]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- [exp_calcolo_missione] 2017, null, null
CREATE PROCEDURE [exp_calcolo_missione]
(
  @yitineration INT,
  @nitinerationstart INT,
  @nitinerationstop INT
)
AS BEGIN
 
 CREATE TABLE #itinerationrefund
 (
	 iditineration int,
	 nrefund int, 
	 itinerationrefundkind varchar(150),
	 codeitinerationrefundkind varchar(50),
	 description varchar(150),
	 extraallowance decimal(19,2),
	 amount decimal(19,2),
	 advantagepercentage decimal(19,8),
	 starttime datetime,
	 stoptime  datetime,
	 codecurrency varchar(10),
	 exchangerate float,
	 foreigncountry  varchar(150),
	 flagadvancebalance char(1)
 )

DECLARE @maxnitineration int
SET @maxnitineration = (SELECT MAX(nitineration) FROM itineration WHERE yitineration = @yitineration)
 CREATE TABLE #itinerationrefsummary
	 (
		iditineration int
	 )
 INSERT INTO #itinerationrefsummary 
 SELECT iditineration FROM itineration WHERE itineration.yitineration = @yitineration
	AND itineration.nitineration BETWEEN ISNULL(@nitinerationstart,1) AND ISNULL(@nitinerationstop,@maxnitineration)
	
 --DROP TABLE #itinerationrefund
INSERT INTO #itinerationrefund
(
	 iditineration,
	 nrefund, 
	 itinerationrefundkind,
	 codeitinerationrefundkind,
	 description,
	 extraallowance,
	 amount,
	 advantagepercentage,
	 starttime,
	 stoptime,
	 codecurrency,
	 exchangerate,
	 foreigncountry,
	 flagadvancebalance
)
SELECT
	itinerationrefund.iditineration,
	itinerationrefund.nrefund,			-- as '#spesa',
	itinerationrefundkind.description,  -- as 'Tipo',
	itinerationrefundkind.codeitinerationrefundkind,  -- as 'Tipo',
	itinerationrefund.description,      -- as 'Descrizione',
	itinerationrefund.extraallowance,   -- as 'Indenn. supplementare',
	--itinerationrefund.amount,
	CASE 
		WHEN exchangerate > 0 THEN
			ROUND(amount / exchangerate, 2)
		ELSE
 				amount 
	END,									   -- as 'Importo',
	itinerationrefund.advancepercentage*100,   -- as 'Perc. Anticipo',
	itinerationrefund.starttime,			   -- as 'Inizio Spesa', 
	itinerationrefund.stoptime,				   -- as 'Fine Spesa',
	currency.codecurrency,					   -- as 'Valuta',
	itinerationrefund.exchangerate,			   -- as 'Tasso Cambio',
	foreigncountry.description,				   -- as 'Stato Estero',
	itinerationrefund.flagadvancebalance	   -- as 'Anticipo / Saldo' 
FROM itinerationrefund
JOIN itineration on itineration.iditineration = itinerationrefund.iditineration
LEFT OUTER JOIN itinerationrefundkind
	ON itinerationrefundkind.iditinerationrefundkind = itinerationrefund.iditinerationrefundkind
LEFT OUTER JOIN currency
	ON currency.idcurrency  = itinerationrefund.idcurrency
LEFT OUTER JOIN foreigncountry
	ON foreigncountry.idforeigncountry  = itinerationrefund.idforeigncountry
WHERE itineration.yitineration = @yitineration
  AND itineration.nitineration BETWEEN ISNULL(@nitinerationstart,1) AND ISNULL(@nitinerationstop,@maxnitineration)
  
--SELECT * FROM #itinerationrefund
--SELECT DISTINCT iditineration, codeitinerationrefundkind FROM #itinerationrefund

DECLARE @itinerationrefundkind varchar(150)
DECLARE @iditineration  int
DECLARE @SQLString nvarchar(1000)
DECLARE @totamount DECIMAL(19,2)
	
-- CICLO CON CURSORE
DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT DISTINCT  itinerationrefundkind FROM #itinerationrefund
FOR READ ONLY

OPEN rowcursor
FETCH NEXT FROM rowcursor
INTO  @itinerationrefundkind
WHILE @@FETCH_STATUS = 0
BEGIN 
	DECLARE @column varchar(150)
	SET @column = @itinerationrefundkind
	SET @SQLString = ' ALTER TABLE #itinerationrefsummary ADD  ['  + @column  + '_ANTICIPO] DECIMAL(19,2)'
	PRINT @SQLString
	EXEC (@SQLString)
	SET @SQLString = ' ALTER TABLE #itinerationrefsummary ADD  ['  + @column  + '_SALDO] DECIMAL(19,2)'
	PRINT @SQLString
	EXEC (@SQLString)
FETCH NEXT FROM rowcursor
INTO  @itinerationrefundkind
END 
DEALLOCATE rowcursor


DECLARE @flagadvance CHAR(1)
-- CICLO CON CURSORE
DECLARE rowcursor2 INSENSITIVE CURSOR FOR
SELECT DISTINCT iditineration, itinerationrefundkind,flagadvancebalance FROM #itinerationrefund
FOR READ ONLY

OPEN rowcursor2
FETCH NEXT FROM rowcursor2
INTO @iditineration, @itinerationrefundkind,@flagadvance
WHILE @@FETCH_STATUS = 0
BEGIN 
	SET @totamount =  ISNULL((SELECT SUM(amount) FROM #itinerationrefund  
	WHERE itinerationrefundkind = @itinerationrefundkind  AND iditineration = @iditineration AND flagadvancebalance = @flagadvance) ,0)				 
	--SELECT @totamount
IF (@flagadvance = 'A')
	SET @SQLString = ' UPDATE #itinerationrefsummary SET ['  + @itinerationrefundkind  + '_ANTICIPO] = ' + CONVERT(VARCHAR(20),@totamount)   +
					 ' WHERE iditineration = ' +  CONVERT(VARCHAR(8),@iditineration)  
					 ELSE
	SET @SQLString = ' UPDATE #itinerationrefsummary SET ['  + @itinerationrefundkind  + '_SALDO] = ' + CONVERT(VARCHAR(20),@totamount)   +
					 ' WHERE iditineration = ' +  CONVERT(VARCHAR(8),@iditineration)
	PRINT @SQLString
	EXEC  (@SQLString)
		 
FETCH NEXT FROM rowcursor2
INTO @iditineration, @itinerationrefundkind,@flagadvance
END 
DEALLOCATE rowcursor2
--SELECT * FROM #itinerationrefsummary
SELECT 
	itineration.yitineration AS 'Eserc. Missione',
	itineration.nitineration AS 'Num. Missione',
	itineration.start as 'Inizio',
	itineration.stop as 'Fine',
	registry.title as 'Incaricato',
	registry.cf as 'Cod. fiscale',
	registry.birthdate as 'Data Nascita',
	itineration.admincarkmcost as 'Euro/Km Mezzo Ammin.',
	itineration.admincarkm as 'Km percorsi Mezzo Ammin.',
	itineration.owncarkmcost as 'Euro/Km Mezzo proprio',
	itineration.owncarkm as 'Km percorsi Mezzo proprio',
	itineration.footkmcost as 'Euro/Km a Piedi',
	itineration.footkm as 'Km percorsi a Piedi', 
	#itinerationrefsummary.*
	--ISNULL(itineration.vehicle_info,'') as vehicle_info,
	--ISNULL(itineration.vehicle_motive,'') as vehicle_motive
FROM  itineration
LEFT OUTER JOIN #itinerationrefsummary ON itineration.iditineration = #itinerationrefsummary.iditineration
join registry 
	ON registry.idreg = itineration.idreg
WHERE yitineration = @yitineration

DROP TABLE #itinerationrefund
DROP TABLE #itinerationrefsummary

END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
