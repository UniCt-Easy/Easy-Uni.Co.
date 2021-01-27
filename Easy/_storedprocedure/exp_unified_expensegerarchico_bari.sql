
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_expensegerarchico_bari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_expensegerarchico_bari]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE     PROCEDURE [exp_unified_expensegerarchico_bari]
(
	@ymin int,
	@ymax int,
	@ayearmin int,
	@ayearmax int,
	@registry varchar(100),
	@adatemin datetime,
	@adatemax datetime,
	@codefin varchar(50),
	@idupb varchar(36),
	@unified char(1)
)
AS BEGIN
--exp_expensegerarchico '2005', '2009',2007,2009, '%', {ts '2007-01-01 00:00:00.000'}, {ts '2007-12-31 00:00:00.000'}, '%',null, null, null,'%'
--dse.exp_expensegerarchico_bari '2005', '2009',2007,2009, '%', {ts '2007-01-01 00:00:00.000'}, {ts '2007-12-31 00:00:00.000'}, '%','%'

-- exp_unified_expensegerarchico_bari '2012', '2012',2012,2012, '%', {ts '2012-01-01 00:00:00.000'}, {ts '2012-12-31 00:00:00.000'}, '%','%','S'


IF (@unified <> 'S')
BEGIN
	 EXEC [exp_expensegerarchico_bari]  @ymin , @ymax ,@ayearmin ,@ayearmax ,@registry,@adatemin ,@adatemax ,@codefin ,@idupb  
        RETURN
END
ELSE
BEGIN

CREATE TABLE #unified (
	anno int,
	iddbdepartment  varchar(50),
    departmentname  varchar(150),
	fase_1 varchar(100),
	fase_2 varchar(100),
	fase_3 varchar(100),
	fase_4 varchar(100),
	fase_5 varchar(100),
	mandato varchar(50),
	nbill int,
	codefin varchar(50),
	finance varchar(150),
	codeupb varchar(50),
	upb varchar(150),
	registry varchar(150),
	cf varchar(50),
	p_iva varchar(50),
	class_centralizzata varchar(50),
	description varchar(150),
	curramount decimal(19,2),
	available decimal(19,2),
	service varchar(150),
	start datetime,
	stop datetime,
	tax decimal(19,2),
	clawback decimal(19,2),
	netamount decimal(19,2),
	date datetime,
	doc varchar(150),
	docdate datetime 
)


DECLARE @iddbdepartment varchar(50)

DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment FROM dbdepartment 
WHERE (start is null or start <= @ayearmax ) AND ( stop is null or stop >= @ayearmin)
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = @iddbdepartment +'.exp_expensegerarchico_bari'

declare @sqlsetuser as varchar(10)
SET @sqlsetuser = 'setuser'
declare @sqlsetuserdip  as varchar(100)
SET @sqlsetuserDIP = 'setuser ' + ''''+ @iddbdepartment + ''''

execute (@sqlsetuser)
execute (@sqlsetuserdip)
print @sqlsetuserdip
PRINT @iddbdepartment
		
INSERT INTO #unified(
                   	anno,
					fase_1,
					fase_2,
					fase_3,
					fase_4,
					fase_5,
					mandato,
					nbill,
					codefin,
					finance,
					codeupb,
					upb,
					registry,
					cf,
					p_iva,
					class_centralizzata,
					description,
					curramount,
					available,
					service,
					start,
					stop,
					tax,
					clawback,
					netamount,
					date ,
					doc,
					docdate  
		)

		EXECUTE @dip_nomesp @ymin , @ymax ,@ayearmin ,@ayearmax ,@registry,@adatemin ,@adatemax ,@codefin ,@idupb  
	
		UPDATE #unified set iddbdepartment = @iddbdepartment,  departmentname  = dbdepartment.description 
		FROM dbdepartment 
		WHERE dbdepartment.iddbdepartment=@iddbdepartment
		AND   #unified.iddbdepartment is null

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment
--execute (@sqlsetuser)
--execute (@sqlsetuserdip)

end

--- salvare i dati dentro una tabella fisica per 
-- facilitare l'esportaziine
select * from #unified
order by iddbdepartment, fase_1, fase_2,fase_3,fase_4,fase_5
END


DROP TABLE #unified
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
