
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_riepilogo_ritenute_nonliquidate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_riepilogo_ritenute_nonliquidate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--	exec exp_unified_riepilogo_ritenute_nonliquidate 2015,null ,null,{ts '2015-01-01 00:00:00'} , {ts '2015-12-31 00:00:00'},null

CREATE     PROCEDURE [exp_unified_riepilogo_ritenute_nonliquidate]
	@ayear int, 
	@idreg int,
	@tax int,
	@start datetime,
	@stop datetime,
	@idser int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

AS
BEGIN

CREATE TABLE #unifiedtax
(
	employtax_liq_periodo decimal(19,2),    --A
	admintax_liq_periodo decimal(19,2),     --A
	employtax_operate_prec decimal(19,2),   --B
	admintax_operate_prec decimal(19,2),    --B
	employtax_non_liq decimal(19,2),        --C
	admintax_non_liq decimal(19,2),         --C
	employtax_liq_tot decimal(19,2),
	admintax_liq_tot decimal(19,2),
-- info relativa ala percipiente
	title varchar(100),
	cf varchar(16),
	surname varchar(50),
	forename varchar(50),
	birthdate datetime, 
	GC_title varchar(65),
	GP_province varchar(2), 
	GN_title varchar(65),
	gender varchar(1),
-- info relative al mov. si spesa servonoin caso si decida di consolidare
	nmov int,
	ymov int,
	desc_exp varchar(150),
	servicedescription varchar(50),
	servicestart datetime,
	servicestop datetime,
-- info relative all'indirizzo        
    address varchar(100),
    location varchar(65),
    province varchar(2),
    nation varchar(65),
    cap varchar(20),
-- info relative al comune e regione fiscale
    GC_tax_title varchar(65), 
    fiscal_region varchar(50),
    taxdescription varchar(50)
)

        
	INSERT INTO #unifiedtax (
                    ymov,nmov,
                    title,cf,surname,forename,birthdate, 
                    GC_title,GP_province, GN_title,
                    gender,servicedescription,desc_exp,
                    servicestart,servicestop,
                    address,location,province,nation,cap,
                    GC_tax_title, 
                    fiscal_region,
                    taxdescription,
                    employtax_liq_periodo,employtax_operate_prec,employtax_non_liq,employtax_liq_tot,
                    admintax_liq_periodo,admintax_operate_prec,admintax_non_liq,admintax_liq_tot
    	)
	EXEC exp_riepilogo_ritenute_applicate @ayear,@idreg,@tax,@start,@stop,@idser,'N',@idsor01,@idsor02,@idsor03,@idsor04,@idsor05

       

SELECT
        taxdescription as 'Ritenuta',
        ISNULL(SUM(employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
        ISNULL(SUM(admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo' --C
FROM #unifiedtax
GROUP BY taxdescription
ORDER BY taxdescription





END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

