
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_sitpatrim_generale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_sitpatrim_generale]
GO

-- setuser 'amm'

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE     PROCEDURE [rpt_unified_sitpatrim_generale]
(
	@year int,
	@codinventoryagency int,
	@date datetime,
	@showmotive char(1),
    @unified char(1), -- consolidamento dei dati 
	@idinventory int
)
AS BEGIN


CREATE TABLE #unified (
	iddbdepartment  varchar(50),
    departmentname  varchar(150),
	codinventoryagency varchar(20),
	descinventoryagency varchar(150),
	idsor int,
	codesor varchar(50),
	nlevel int,
	idmot int,
	motive varchar(50),
	description varchar(150),
	initial_amount decimal(19,2),
	var_aum decimal(19,2),
	var_dim decimal(19,2),
	ammortization_pre_in_carico decimal(19,2),
	ammortization_pre_scaricati decimal(19,2),
	final_amount decimal(19,2),
	ammortization_post decimal(19,2),
	stop datetime,
	inventory varchar(50)
)


-- exec [rpt_unified_sitpatrim_generale] 2015, 4, '2015-31-12', 'S',  'N', null
--  exec [rpt_unified_sitpatrim_generale] 2015, 4, '2015-31-12', 'N',  'S', null
--  exec [rpt_unified_sitpatrim_generale] 2015, 4, '2015-31-12', 'S',  'S', null
IF (@unified <> 'S')
BEGIN
	print 'here1'
		INSERT INTO #unified (
                codinventoryagency,
				descinventoryagency,
				idsor,
				codesor,
				nlevel,
				idmot,
				motive,
				description,
				initial_amount,
				var_aum ,
				var_dim ,
				ammortization_pre_in_carico,
				ammortization_pre_scaricati,
				final_amount,				
				ammortization_post,
				stop,
				inventory
		)
        EXEC rpt_sitpatrim_generale @year,@codinventoryagency, @date, @showmotive, @idinventory

		--TASK 10635 aggiunto controllo @codinventoryagency is null
		if (@idinventory is  null and @codinventoryagency is null) BEGIN
			UPDATE #unified set codinventoryagency = null, descinventoryagency = null   -- consolida su tutti gli enti
		END

		SELECT 
		#unified.codinventoryagency,
		#unified.descinventoryagency,
		#unified.idsor,
		#unified.codesor,
		#unified.nlevel,
		#unified.idmot,
		#unified.motive,
		#unified.description,
		ISNULL(SUM(#unified.initial_amount),0) as 'initial_amount',
		ISNULL(SUM(#unified.var_aum),0) as 'var_aum',
		ISNULL(SUM(#unified.var_dim),0)  as 'var_dim',
		ISNULL(SUM(#unified.ammortization_pre_in_carico),0)  as 'ammortization_pre_in_carico',
		ISNULL(SUM(#unified.ammortization_pre_scaricati),0) as 'ammortization_pre_scaricati' ,
		ISNULL(SUM(#unified.final_amount),0)  as 'final_amount',
		ISNULL(SUM(#unified.ammortization_post),0) as 'ammortization_post' ,
		#unified.stop as 'stop',
		#unified.inventory
		FROM #unified	
		GROUP BY 	#unified.codinventoryagency,#unified.descinventoryagency,
				#unified.idsor,#unified.codesor, #unified.nlevel, #unified.idmot,
				#unified.motive,#unified.description,#unified.stop,#unified.inventory
		ORDER BY ISNULL(#unified.codesor,#unified.idsor)
	 


		RETURN
END 

print 'here2'



DECLARE @iddbdepartment varchar(50)
DECLARE @departmentname varchar(150)

DECLARE crsdepartment  cursor LOCAL STATIC FOR 
SELECT iddbdepartment, description FROM dbdepartment 
WHERE (start is null or start <= @year ) AND ( stop is null or stop >= @year)
FOR READ ONLY

OPEN crsdepartment

FETCH NEXT FROM crsdepartment INTO @iddbdepartment, @departmentname
WHILE @@fetch_status=0 begin
	DECLARE @dip_nomesp varchar(300)
        SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_sitpatrim_generale'
PRINT @iddbdepartment
		INSERT INTO #unified (
                 codinventoryagency,
				descinventoryagency,
				idsor,
				codesor,
				nlevel,
				idmot,
				motive,
				description,
				initial_amount,
				var_aum ,
				var_dim ,
				ammortization_pre_in_carico,
				ammortization_pre_scaricati,
				final_amount,				
				ammortization_post,
				stop,
				inventory
		)
		EXEC @dip_nomesp  @year,@codinventoryagency, @date, @showmotive, @idinventory
		UPDATE #unified set iddbdepartment = @iddbdepartment,  departmentname  = @departmentname
		WHERE #unified.iddbdepartment is null

	FETCH NEXT FROM crsdepartment INTO @iddbdepartment,@departmentname
end

DEALLOCATE crsdepartment

-- SELECT * FROM #unified
UPDATE #unified set codinventoryagency = null, descinventoryagency = null   -- consolida su tutti gli enti
  
	SELECT 
		#unified.codinventoryagency,
		#unified.descinventoryagency,
		#unified.idsor,
		#unified.codesor,
		#unified.nlevel,
		#unified.idmot,
		#unified.motive,
		#unified.description,
		ISNULL(SUM(#unified.initial_amount),0) as 'initial_amount',
		ISNULL(SUM(#unified.var_aum),0) as 'var_aum',
		ISNULL(SUM(#unified.var_dim),0)  as 'var_dim',
		ISNULL(SUM(#unified.ammortization_pre_in_carico),0)  as 'ammortization_pre_in_carico',
		ISNULL(SUM(#unified.ammortization_pre_scaricati),0) as 'ammortization_pre_scaricati' ,
		ISNULL(SUM(#unified.final_amount),0)  as 'final_amount',
		ISNULL(SUM(#unified.ammortization_post),0) as 'ammortization_post' ,
		#unified.stop as 'stop',
		#unified.inventory
		FROM #unified	
	GROUP BY 	#unified.codinventoryagency,#unified.descinventoryagency,
				#unified.idsor,#unified.codesor, #unified.nlevel, #unified.idmot,
				#unified.motive,#unified.description,#unified.stop,#unified.inventory
	ORDER BY ISNULL(#unified.codesor,#unified.idsor)
	 
DROP TABLE #unified
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
