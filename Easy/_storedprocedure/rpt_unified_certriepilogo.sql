
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_certriepilogo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_certriepilogo]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   PROCEDURE [rpt_unified_certriepilogo]
(
	@ayear smallint, 
	@start datetime,
	@stop datetime,
	@idreg int, 
	@idser int,
    @unified char(1),   -- consolidamento dei dati
	@showallser char(1) -- mostra le prestazioni non associate a certificazioni specifiche non CUD
	/*
	------------------------------------------------
	--------- ELENCO CERTIFICAZIONI SPECIFICHE------
	------------------------------------------------
	A	Certificazione Retribuzioni Aggiuntive	
	C	Certificazione stranieri in Convenzione	
	F	Certificazione Ritenuta d'Acconto	
	I	Certificazione INPS a gestione separata	
	P	Certificazione Premi di Studio e altri Premi	
	S	Modello Assegnisti	
	T	Certificazione a Titolo d'imposta	
	U	Modello CUD	
	------------------------------------------------
	------------------------------------------------
	------------------------------------------------
	*/
)
AS BEGIN
-- exec rpt_unified_certriepilogo 2011,{ts '2011-01-20 00:00:00'},{ts '2011-12-31 00:00:00'},null ,null,'S','S'

 
IF (@unified <> 'S')
BEGIN
        EXEC rpt_certriepilogo @ayear, @start, @stop, @idreg, @idser, @showallser
        RETURN
END

CREATE TABLE #unified_dett (
        countidser int,
	idreg int ,
	registry varchar(100),
        taxcode int,
	taxdescription varchar(50),
	taxablenet decimal(19,2),
	taxablegross decimal(19,2),
	employtax decimal(19,2),
        admintax decimal(19,2)
)

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
							 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.rpt_certriepilogo'
PRINT @iddbdepartment
		INSERT INTO #unified_dett (
                        countidser,
                        idreg,
                        registry,
                        taxcode,
                        taxdescription,
                        taxablenet,
                        taxablegross,
                        employtax,
                        admintax
        		)
		EXEC @dip_nomesp @ayear, @start, @stop,@idreg, @idser, @showallser
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end

SELECT countidser,
	idreg,
	registry,
	taxcode,   
	taxdescription,
	sum(isnull(taxablenet,0)) AS taxablenet,
	sum(isnull(taxablegross,0)) AS taxablegross ,
	sum(isnull(employtax,0)) as employtax,
	sum(isnull(admintax,0)) as admintax
FROM #unified_dett
group by idreg,registry,
	taxcode,taxdescription,countidser
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

