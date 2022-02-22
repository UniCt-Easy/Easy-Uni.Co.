
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_4certificazioni_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_4certificazioni_dett]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE   PROCEDURE [rpt_unified_4certificazioni_dett]
(
	@ayear smallint, 
	@start datetime,
	@stop datetime,
	@idreg int, 
	@certificatekind char(1),
    @unified char(1)
	
)
AS BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC rpt_4certificazioni_dett @ayear, @start, @stop, @idreg, @certificatekind
        RETURN
END 
 

CREATE TABLE #unified_dett (
        countidser int,
	idreg int ,
	registry varchar(100),
	taxdescription varchar(50),
	taxablenet decimal(19,2),
	taxablegross decimal(19,2),
	employtax decimal(19,2),
	taxkind int
)

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
							 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
	SET @dip_nomesp = @iddbdepartment + '.rpt_4certificazioni_dett'
PRINT @iddbdepartment
		INSERT INTO #unified_dett (
                        countidser,
                	idreg,
                	registry,
                	taxdescription,
                	taxablenet,
                	taxablegross ,
                	employtax,
                	taxkind
        		)
		EXEC @dip_nomesp @ayear, @start, @stop,@idreg, @certificatekind
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
end

SELECT countidser,
	idreg,
	registry,
	taxdescription,
	sum(isnull(taxablenet,0)) AS taxablenet,
	sum(isnull(taxablegross,0)) AS taxablegross ,
	sum(isnull(employtax,0)) as employtax,
	taxkind
FROM #unified_dett
GROUP BY idreg,registry,taxdescription,countidser,taxkind
ORDER BY registry,taxkind
END




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
