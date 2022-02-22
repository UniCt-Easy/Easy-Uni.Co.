
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_sitpatrim_totale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_sitpatrim_totale]
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_unified_sitpatrim_totale]
(
	@year int,
	@date datetime,
	@showmotive char(1),
    @unified char(1) -- consolidamento dei dati 
)
AS BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC rpt_sitpatrim_totale @year, @date, @showmotive
        RETURN
END 

CREATE TABLE #unified (
	iddbdepartment  varchar(50),
    departmentname  varchar(150),
	idsor int,
	codeinv varchar(50),
	nlevel tinyint,
	description varchar(150),
	initial_amount decimal(19,2),
	idmot int,
	motive varchar(50),
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	amortization decimal(19,2),
	date datetime	
)


DECLARE @iddbdepartment varchar(50)

DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= @year ) AND ( stop is null or stop >= @year)
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_sitpatrim_totale'
PRINT @iddbdepartment
		INSERT INTO #unified (
                   idsor,
				   codeinv,
				   nlevel,
				   idmot,
				   motive,
				   description,
				   initial_amount,
				   var_aum,
				   var_dim,
				   amortization,
				   date
		)
		EXEC @dip_nomesp @year, @date, @showmotive
		UPDATE #unified set iddbdepartment = @iddbdepartment,  departmentname  = dbdepartment.description 
		FROM dbdepartment 
		WHERE dbdepartment.iddbdepartment=#unified.iddbdepartment
		AND   #unified.iddbdepartment is null

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

DEALLOCATE crsdepartment

--SELECT * FROM #unified

SELECT
		#unified.idsor,
		#unified.codeinv AS 'codesor',
		#unified.nlevel,
		null as 'idmot',
		null as 'motive',
		#unified.description,
		ISNULL(SUM(#unified.initial_amount),0) AS 'initialamount',
		ISNULL(SUM(#unified.var_aum),0) AS 'improveamount',
		ISNULL(SUM(#unified.var_dim),0) AS 'decreaseamount',
		ISNULL(SUM(#unified.amortization),0) as 'amortization',
		@date AS 'stop'
	FROM #unified	
	GROUP BY #unified.idsor,#unified.codeinv, #unified.nlevel, #unified.description
	ORDER BY ISNULL(#unified.codeinv,#unified.idsor)


DROP TABLE #unified
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



