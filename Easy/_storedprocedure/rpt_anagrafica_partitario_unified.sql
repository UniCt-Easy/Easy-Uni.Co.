
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_anagrafica_partitario_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_anagrafica_partitario_unified]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE        PROCEDURE [rpt_anagrafica_partitario_unified]
	@ayear int,
	@title varchar(100), 
	@start datetime,
	@stop datetime,
    @unified char(1) -- consolidamento dei dati 
AS
BEGIN
IF (@unified <> 'S')
BEGIN
        EXEC rpt_anagrafica_partitario @ayear, @title, @start, @stop
        RETURN
END 

CREATE TABLE #unified (
    departmentname  varchar(150),
	idreg int,
	title varchar(100),
	cf varchar(16),  
	p_iva varchar(15),
	rowkind int,
	competencydate datetime,
	operationkind varchar(55),
	ymov int,
	nmov int,
	nvar int,
	npro_npay int,
	description varchar(150),
 	doc varchar(35),
	docdate datetime,
	proceeds float,
	payment	float	
)

DECLARE @iddbdepartment varchar(50)
DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_anagrafica_partitario'
PRINT @iddbdepartment
		INSERT INTO #unified (
                departmentname,
				idreg,
				title,
				cf, 
				p_iva,
				rowkind,
				competencydate,
				operationkind ,
				ymov ,
				nmov ,
				nvar ,
				npro_npay ,
				description,
 				doc,
				docdate,
				proceeds,
				payment	
)
		EXEC @dip_nomesp @ayear, @title, @start, @stop

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
end

DEALLOCATE crsdepartment

SELECT
        departmentname,
		idreg,
		title,
		cf, 
		p_iva,
		rowkind,
		competencydate,
		operationkind ,
		ymov ,
		nmov ,
		nvar ,
		npro_npay ,
		description,
		doc,
		docdate,
		proceeds,
		payment	
FROM #unified
ORDER BY title ASC, 
	competencydate ASC, 
	rowkind ASC,
	ymov ASC,
	nmov ASC,
	nvar ASC

DROP TABLE #unified
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

