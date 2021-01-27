
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogo_ritenute_applicate_impon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogo_ritenute_applicate_impon]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [rpt_unified_riepilogo_ritenute_applicate_impon]
(
	  @ayear                 int, 
	  @idreg              	 int, 
	  @tax                   int,
	  @start             	 datetime,
	  @stop               	 datetime,
	  @mode			 char(1),
	  @suppressrow		 char(1),
	  @unified 		 char(1)
)
AS BEGIN

CREATE TABLE #UnifiedTax	(
	departmentname  varchar(150),
	registry varchar(100),
	cf varchar(40),
	p_iva varchar(15),
	taxcode int,
	description varchar(50),
	taxablegross decimal(19,2), 
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	abatements decimal(19,2),
	rowkind char(1),
	datetaxpay datetime,
	stop datetime
)

CREATE TABLE #UnifiedTaxApp	(
	registry varchar(100),
	cf varchar(40),
	p_iva varchar(15),
	taxcode int,
	description varchar(50),
	taxablegross decimal(19,2), 
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	abatements decimal(19,2),
	rowkind char(1),
	datetaxpay datetime,
	stop datetime
)

IF (@unified <> 'S')
BEGIN
	INSERT INTO #UnifiedTax (
					registry,
					cf,
					p_iva,
					taxcode,
					description,
					taxablegross, 
					taxablenet,
					employtax, 
					admintax,
					abatements,
					rowkind,
					datetaxpay,
					stop
		)
	EXEC rpt_riepilogo_ritenute_applicate_impon @ayear, @idreg,@tax,@start, @stop, @mode, @suppressrow 
END 

ELSE
BEGIN
	DECLARE @iddbdepartment varchar(50)
	DECLARE @departmentname varchar(150)
	
	DECLARE crsdepartment  cursor LOCAL STATIC FOR 
	SELECT  iddbdepartment, description FROM dbdepartment 
	WHERE (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	FOR READ ONLY

	OPEN crsdepartment
	
	FETCH NEXT FROM crsdepartment INTO @iddbdepartment, @departmentname
	WHILE @@fetch_status=0 begin
			DECLARE @dip_nomesp varchar(300)
	        	SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_riepilogo_ritenute_applicate_impon'
	
			INSERT INTO #UnifiedTaxApp (
						registry,
						cf,
						p_iva,
						taxcode,
						description,
						taxablegross, 
						taxablenet,
						employtax, 
						admintax,
						abatements,
						rowkind,
						datetaxpay,
						stop
			)
			EXEC @dip_nomesp @ayear, @idreg,@tax,@start, @stop, @mode, @suppressrow 
			
			INSERT INTO #UnifiedTax
			(
				departmentname,
				registry,
				cf,
				p_iva,
				taxcode,
				description,
				taxablegross, 
				taxablenet,
				employtax, 
				admintax,
				abatements,
				rowkind,
				datetaxpay,
				stop
			)
			SELECT 
				@departmentname,
				registry,
				cf,
				p_iva,
				taxcode,
				description,
				taxablegross, 
				taxablenet,
				employtax, 
				admintax,
				abatements,
				rowkind,
				datetaxpay,
				stop
			FROM 	#UnifiedTaxApp

		DELETE FROM #UnifiedTaxApp
		FETCH NEXT FROM crsdepartment INTO @iddbdepartment, @departmentname
	END
	
	DEALLOCATE crsdepartment
	
END

SELECT
	departmentname,
	registry as 'title',
	cf,
	p_iva,
	taxcode,
	description,
	taxablegross as 'imponibilelordo', 
	taxablenet   as 'imponibilenetto',
	employtax    as 'ritdipendente',
	admintax     as 'ritamministrazione', 
	abatements   as 'detrazioni applicate',
	rowkind,
	datetaxpay,
	stop
FROM #UnifiedTax
DROP TABLE #UnifiedTaxApp
DROP TABLE #UnifiedTax
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

