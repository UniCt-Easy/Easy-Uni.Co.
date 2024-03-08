
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_unified_riepilogo_ritenute_applicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_unified_riepilogo_ritenute_applicate]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE      PROCEDURE [rpt_unified_riepilogo_ritenute_applicate]
(
  @ayear                 int, 
  @registry              varchar(50), 
  @tax                   int,
  @start             	 datetime,
  @stop               	 datetime,
  @unified char(1)
)
AS BEGIN

CREATE TABLE #UnifiedTax	(
	departmentname  varchar(150),
	registry varchar(100),
	cf varchar(40),
	p_iva varchar(15),
	description varchar(50),
	employtax_liq_periodo decimal(19,2), --A
	admintax_liq_periodo decimal(19,2),--A
	employtax_operate_prec decimal(19,2), --B
	admintax_operate_prec decimal(19,2), --B
	employtax_non_liq decimal(19,2),--C
	admintax_non_liq decimal(19,2)--C
)

CREATE TABLE #UnifiedTaxApp	(
	registry varchar(100),
	cf varchar(40),
	p_iva varchar(15),
	description varchar(50),
	employtax_liq_periodo decimal(19,2), --A
	admintax_liq_periodo decimal(19,2),--A
	employtax_operate_prec decimal(19,2), --B
	admintax_operate_prec decimal(19,2), --B
	employtax_non_liq decimal(19,2),--C
	admintax_non_liq decimal(19,2)--C
)

IF (@unified <> 'S')
BEGIN
	INSERT INTO #UnifiedTax (
					registry,
					cf,
					p_iva,
					description,
					employtax_liq_periodo, --A
					admintax_liq_periodo,--A
					employtax_operate_prec, --B
					admintax_operate_prec, --B
					employtax_non_liq,--C
					admintax_non_liq
		)
        EXEC rpt_riepilogo_ritenute_applicate @ayear, @registry,@tax,@start, @stop     
END 
ELSE
BEGIN


	DECLARE @iddbdepartment varchar(50)
	DECLARE @departmentname varchar(150)
	
	DECLARE crsdepartment  cursor LOCAL STATIC FOR 
	SELECT  iddbdepartment, description FROM dbdepartment 
	 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	FOR READ ONLY
	
	OPEN crsdepartment
	
	FETCH NEXT FROM crsdepartment INTO @iddbdepartment,@departmentname
	WHILE @@fetch_status=0 begin
			DECLARE @dip_nomesp varchar(300)
	        	SET @dip_nomesp = '['+@iddbdepartment+']'+ '.rpt_riepilogo_ritenute_applicate'
	
			INSERT INTO #UnifiedTaxApp (
						registry,
						cf,
						p_iva,
						description,
						employtax_liq_periodo, --A
						admintax_liq_periodo,--A
						employtax_operate_prec, --B
						admintax_operate_prec, --B
						employtax_non_liq,--C
						admintax_non_liq
			)
			EXEC @dip_nomesp @ayear, @registry,@tax,@start, @stop 
			
			INSERT INTO #UnifiedTax (
						departmentname,
						registry,
						cf,
						p_iva,
						description,
						employtax_liq_periodo, --A
						admintax_liq_periodo,--A
						employtax_operate_prec, --B
						admintax_operate_prec, --B
						employtax_non_liq,--C
						admintax_non_liq
			)
			SELECT
						@departmentname,
						registry,
						cf,
						p_iva,
						description,
						employtax_liq_periodo, --A
						admintax_liq_periodo,--A
						employtax_operate_prec, --B
						admintax_operate_prec, --B
						employtax_non_liq,--C
						admintax_non_liq

			FROM #UnifiedTaxApp
			DELETE FROM #UnifiedTaxApp
		FETCH NEXT FROM crsdepartment INTO @iddbdepartment, @departmentname
	END
	
	DEALLOCATE crsdepartment
END
SELECT
        	departmentname,
		registry,
		cf,
		p_iva,
		description,
		employtax_liq_periodo as 'ritdipendente_liq_periodo', 
		admintax_liq_periodo as 'ritamministrazione_liq_periodo',
		employtax_operate_prec as 'ritdipendente_operate_prec', --B
		admintax_operate_prec as 'ritamministrazione_operate_prec', --B
		employtax_non_liq as 'ritdipendente_non_liq',--C
		admintax_non_liq as 'ritamministrazione_non_liq'
FROM #UnifiedTax
DROP TABLE #UnifiedTaxApp
DROP TABLE #UnifiedTax
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

