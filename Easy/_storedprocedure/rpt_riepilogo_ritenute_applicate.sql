
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


/* Versione 1.0.1 del 09/04/2008 ultima modifica: GIUSEPPE */

if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_riepilogo_ritenute_applicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_riepilogo_ritenute_applicate]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [rpt_riepilogo_ritenute_applicate]
	@ayear                 int, 
	@registry              varchar(50), 
	@tax                   int,
	@start             	 datetime,
	@stop               	 datetime,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
AS
  BEGIN
	CREATE TABLE #tax
	(
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
INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_liq_periodo,-- A
	admintax_liq_periodo  -- A
)
/*      
A) rit. operate e liquidate del periodo : le ritenute + correzioni incluse nelle LIQUIDAZIONI RITENUTE che includono 
il periodo selezionato.
*/

SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), 
        SUM(tabella.admintax)
      FROM 
              	(select 
        	        sum(isnull(E.employtax,0))    as 'employtax',
        	        sum(isnull(E.admintax,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 JOIN taxpay
                        ON taxpay.ytaxpay = E.ytaxpay
                        AND taxpay.ntaxpay = E.ntaxpay
                        AND taxpay.taxcode = E.taxcode
                   WHERE expense.ymov = @ayear  
                        AND  -- liquidata nel periodo (prendi le liq. che hanno intersezione non nulla col periodo selezionato)
                              (  taxpay.start BETWEEN @start AND @stop
                                 OR taxpay.stop BETWEEN @start AND @stop
                                 OR @start BETWEEN taxpay.start AND taxpay.stop
                                 OR @stop BETWEEN taxpay.start AND taxpay.stop
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                        AND E.datetaxpay BETWEEN @start AND @stop --operata nel periodo
                        AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
       AS tabella
       JOIN registry 
                ON tabella.idreg = registry.idreg 
       JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_liq_periodo,-- A
	admintax_liq_periodo  -- A
)
       
SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), 
        SUM(tabella.admintax)
        FROM 
              	(select 
        	        sum(isnull(E.employamount,0))    as 'employtax',
               	        sum(isnull(E.adminamount,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxcorrigeview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 JOIN taxpay
                        ON taxpay.ytaxpay = E.ytaxpay
                        AND taxpay.ntaxpay = E.ntaxpay
                        AND taxpay.taxcode = E.taxcode
                 WHERE expense.ymov = @ayear  
                        AND  -- liquidata nel periodo (prendi le liq. che hanno intersezione non nulla col periodo selezionato)
                              (  taxpay.start BETWEEN @start AND @stop
                                 OR taxpay.stop BETWEEN @start AND @stop
                                 OR @start BETWEEN taxpay.start AND taxpay.stop
                                 OR @stop BETWEEN taxpay.start AND taxpay.stop
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                       AND E.adate BETWEEN @start AND @stop  -- operata nel periodo
                       AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
        AS tabella
        JOIN registry 
                ON tabella.idreg = registry.idreg 
        JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

/*
B) rit. operate in periodi precedenti e liquidate nel periodo
*/
INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_operate_prec, -- B
	admintax_operate_prec -- B
)
SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), --B
        SUM(tabella.admintax)--B
      FROM 
              	(select 
        	        sum(isnull(E.employtax,0))    as 'employtax',
        	        sum(isnull(E.admintax,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 JOIN taxpay
                        ON taxpay.ytaxpay = E.ytaxpay
                        AND taxpay.ntaxpay = E.ntaxpay
                        AND taxpay.taxcode = E.taxcode
                   WHERE expense.ymov = @ayear  
                        AND  -- liquidata nel periodo (prendi le liq. che hanno intersezione non nulla col periodo selezionato)
                              (  taxpay.start BETWEEN @start AND @stop
                                 OR taxpay.stop BETWEEN @start AND @stop
                                 OR @start BETWEEN taxpay.start AND taxpay.stop
                                 OR @stop BETWEEN taxpay.start AND taxpay.stop
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                        AND E.datetaxpay < @start  -- operata nel periodo precedente 
                        AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
       AS tabella
       JOIN registry 
                ON tabella.idreg = registry.idreg 
       JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_operate_prec, -- B
	admintax_operate_prec -- B
)
       
SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), 
        SUM(tabella.admintax)
        FROM 
              	(select 
        	        sum(isnull(E.employamount,0))    as 'employtax',
               	        sum(isnull(E.adminamount,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxcorrigeview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 JOIN taxpay
                        ON taxpay.ytaxpay = E.ytaxpay
                        AND taxpay.ntaxpay = E.ntaxpay
                        AND taxpay.taxcode = E.taxcode
                 WHERE expense.ymov = @ayear  
                        AND  -- liquidata nel periodo (prendi le liq. che hanno intersezione non nulla col periodo selezionato)
                              (  taxpay.start BETWEEN @start AND @stop
                                 OR taxpay.stop BETWEEN @start AND @stop
                                 OR @start BETWEEN taxpay.start AND taxpay.stop
                                 OR @stop BETWEEN taxpay.start AND taxpay.stop
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                       AND E.adate < @start  -- operata nel periodo precedente
                       AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
        AS tabella
        JOIN registry 
                ON tabella.idreg = registry.idreg 
        JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

/*
C) rit. operate nel periodo e non liquidate NEL PERIODO
*/

INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_non_liq,--C
	admintax_non_liq --C
)
SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), --C
        SUM(tabella.admintax) --C
      FROM 
              	(select 
        	        sum(isnull(E.employtax,0))    as 'employtax',
        	        sum(isnull(E.admintax,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 WHERE expense.ymov = @ayear  
                          AND NOT EXISTS-- NON liquidata nel periodo
                              ( SELECT ytaxpay FROM taxpay
                                WHERE taxpay.ytaxpay = E.ytaxpay
                                AND taxpay.ntaxpay = E.ntaxpay
                                AND taxpay.taxcode = E.taxcode
                                AND (taxpay.start BETWEEN @start AND @stop
                                       OR taxpay.stop BETWEEN @start AND @stop
                                       OR @start BETWEEN taxpay.start AND taxpay.stop
                                       OR @stop BETWEEN taxpay.start AND taxpay.stop)
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                        AND E.datetaxpay BETWEEN @start AND @stop  -- operata nel periodo 
                        AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
       AS tabella
       JOIN registry 
                ON tabella.idreg = registry.idreg 
       JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

INSERT  #tax(
	registry,
        cf,
        p_iva,
        description,
	employtax_non_liq,--C
	admintax_non_liq --C
)
       
SELECT
        registry.title,
	ISNULL(registry.cf, registry.foreigncf),
	registry.p_iva,
        tax.description,
        SUM(tabella.employtax), 
        SUM(tabella.admintax)
        FROM 
              	(select 
        	        sum(isnull(E.employamount,0))    as 'employtax',
               	        sum(isnull(E.adminamount,0))     as 'admintax',
                        E.idexp,
                        E.taxcode,
        	        expense.idreg
               	 from expensetaxcorrigeview as E
                 JOIN expense 
                        ON expense.idexp = E.idexp
				join expenseyear	
						on expense.idexp = expenseyear.idexp and expense.ymov = expenseyear.ayear
				join upb	
					on expenseyear.idupb = upb.idupb
                 WHERE expense.ymov = @ayear  
                          AND NOT EXISTS-- NON liquidata nel periodo
                              ( SELECT ytaxpay FROM taxpay
                                WHERE taxpay.ytaxpay = E.ytaxpay
                                AND taxpay.ntaxpay = E.ntaxpay
                                AND taxpay.taxcode = E.taxcode
                                AND (taxpay.start BETWEEN @start AND @stop
                                        OR taxpay.stop BETWEEN @start AND @stop
                                        OR @start BETWEEN taxpay.start AND taxpay.stop
                                        OR @stop BETWEEN taxpay.start AND taxpay.stop)
                                )
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
						AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
						AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
						AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
                       AND E.adate BETWEEN @start AND @stop  -- operata nel periodo 
                       AND (E.taxcode = @tax OR @tax IS NULL)
                 group by expense.idreg,E.idexp,E.taxcode)  
        AS tabella
        JOIN registry 
                ON tabella.idreg = registry.idreg 
        JOIN tax 
                ON tabella.taxcode = tax.taxcode
       WHERE title like @registry 
       GROUP BY registry.title, ISNULL(registry.cf, registry.foreigncf), registry.p_iva, description

SELECT
        #tax.registry,
	#tax.cf, 
	#tax.p_iva,
        #tax.description,
        ISNULL(SUM(#tax.employtax_liq_periodo),0) AS 'ritdipendente_liq_periodo',--A
        ISNULL(SUM(#tax.admintax_liq_periodo),0) AS 'ritamministrazione_liq_periodo',--A
        ISNULL(SUM(#tax.employtax_operate_prec),0) AS 'ritdipendente_operate_prec',--B
        ISNULL(SUM(#tax.admintax_operate_prec),0) AS 'ritamministrazione_operate_prec',--B
        ISNULL(SUM(#tax.employtax_non_liq),0) AS 'ritdipendente_non_liq',--C
        ISNULL(SUM(#tax.admintax_non_liq),0) AS 'ritamministrazione_non_liq'--C
FROM #tax 
GROUP BY registry,cf, p_iva, description
ORDER BY description, registry

END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
