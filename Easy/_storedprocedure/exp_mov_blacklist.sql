
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_mov_blacklist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_mov_blacklist]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_mov_blacklist]
(	@anno int,
	@start smalldatetime,
	@stop smalldatetime
)
AS
BEGIN
--sp_help EXPENSEmov
CREATE TABLE #movfin
	(
		idexp int, 
		phase varchar(50), 
		adate smalldatetime,
		ymov  int,
		nmov  int, 
		codefin varchar(50), 
		finance varchar(150), 
		codeupb varchar(50), 
		upb varchar(150), 
		idreg int, 
		registry varchar(100),
		ypay int,
		npay int, 
		description varchar(150),
		curramount decimal(19,2),
		idblacklist int,
		blnation varchar(100),
		blcode char(3)
	)
INSERT INTO #movfin
		(
		idexp, 
		phase, 
		adate,
		ymov,
		nmov, 
		codefin, 
		finance, 
		codeupb, 
		upb, 
		idreg, 
		registry,
		ypay,
		npay, 
		description,
		curramount,
		idblacklist,
		blnation,
		blcode
)
SELECT 
		E.idexp, 
		E.phase, 
		E.adate,
		E.ymov,
		E.nmov, 
		E.codefin, 
		E.finance, 
		E.codeupb, 
		E.upb, 
		E.idreg, 
		R.title,
		E.ypay,
		E.npay, 
		E.description,
		E.curramount,
		null,
		null,
		null
FROM registry as R
JOIN expenselastview as E
	ON R.idreg = E.idreg
AND YEAR(E.adate) = @anno
AND E.adate BETWEEN @start AND @stop
AND NOT EXISTS (SELECT * FROM expenseinvoice EI WHERE EI.idexp = E.idexp )
ORDER BY MONTH(E.adate), E.ymov, E.nmov 

DECLARE @idexp INT
DECLARE @adate SMALLDATETIME
DECLARE @idreg INT


DECLARE @idblacklist int
DECLARE @blcode char(3)

-- CICLO CON CURSORE PER DETERMINARE IL PAESE DI RESIDENZA DEL CLIENTE/FORNITORE
DECLARE rowcursor INSENSITIVE CURSOR FOR
SELECT idexp,
	   adate,
       idreg
FROM #movfin
FOR READ ONLY
OPEN rowcursor

FETCH NEXT FROM rowcursor
INTO  @idexp,
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
		UPDATE #movfin
		SET idblacklist = @idblacklist, blcode = @blcode, blnation = blacklist.description
		FROM blacklist 
		WHERE #movfin.idexp = @idexp
		AND blacklist.idblacklist = @idblacklist
	END	
		
	FETCH NEXT FROM rowcursor
	INTO  @idexp,
		  @adate,
		  @idreg
END 
DEALLOCATE rowcursor

SELECT 
		phase as 'Fase',
		ymov as 'Eserc.',
		nmov as 'Numero',
		adate as 'Data Contabile',
		description as 'Descrizione',
		curramount as 'Importo',
		ypay as 'Eserc. Mandato',
		npay as 'Num. Mandato',
		idreg as 'Codice Anagrafica',
		registry as 'Anagrafica',
		blnation as 'Nazione',
		blcode as 'Codice Nazione Black List'
FROM #movfin WHERE blnation is not null
ORDER BY MONTH(adate),ymov,nmov

END
GO

--[exp_mov_blacklist] 2010, {D '2010-01-01'}, {D '2010-10-19'}
--[exp_mov_blacklistunified] 2010, {D '2010-01-01'}, {D '2010-10-19'},'S'
