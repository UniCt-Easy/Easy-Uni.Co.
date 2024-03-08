
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_riepilogo_ritenute_applicate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_riepilogo_ritenute_applicate]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exec exp_unified_riepilogo_ritenute_nonliquidate 2015,null ,null,{ts '2015-01-01 00:00:00'} , {ts '2015-12-31 00:00:00'},null,'N','N'
CREATE      PROCEDURE [exp_unified_riepilogo_ritenute_applicate]
	@ayear int, 
	@idreg int,
	@tax int,
	@start datetime,
	@stop datetime,
	@idser int,             
	@unified_mov varchar(1),-- consolidamento dei movimenti del percipiente
	@show_registry char(1),  -- visualizza o meno le info sul percipiente
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null

AS
BEGIN

--@show_registry se vale N, scelgo di non visualizzare le info sul percipiente e di totalizzare tutto sui dipartimenti

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
-- info relative al mov. si spesa servono in caso si decida di consolidare
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
		ymov,
		nmov,
		title,
		cf,
		surname,
		forename,
		birthdate, 
		GC_title,
		GP_province, 
		GN_title,
		gender,
		servicedescription,
		desc_exp,
		servicestart,
		servicestop,
		address,
		location,
		province,
		nation,
		cap,
		GC_tax_title, 
		fiscal_region,
		taxdescription,
		employtax_liq_periodo,
		employtax_operate_prec,
		employtax_non_liq,
		employtax_liq_tot,
                        
		admintax_liq_periodo,
		admintax_operate_prec,
		admintax_non_liq,
		admintax_liq_tot
    		)
		EXEC exp_riepilogo_ritenute_applicate @ayear,@idreg,@tax,@start,@stop,@idser,'N',@idsor01,@idsor02,@idsor03,@idsor04,@idsor05

-- NON visualizza le info sul percipiente
IF (@show_registry='N')   
BEGIN
	SELECT
        taxdescription as 'Ritenuta',
        ISNULL(SUM(employtax_liq_periodo),0) AS 'Rit/Dip. applicate e liquidate nel periodo',--A
        ISNULL(SUM(employtax_operate_prec),0) AS 'Rit/Dip. applicate in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
        ISNULL(SUM(employtax_liq_tot),0) AS 'Tot. Rit/Dip. Liquidato',-- A+B
        ISNULL(SUM(admintax_liq_periodo),0) AS 'Contributi applicati e liquidati nel periodo',--A
        ISNULL(SUM(admintax_operate_prec),0) AS 'Contributi applicati in periodi prec. e liquidate nel periodo',--B
        ISNULL(SUM(admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo', --C
        ISNULL(SUM(admintax_liq_tot),0) AS 'Tot. Contributi Liquidati'-- A+B
        FROM #unifiedtax
        GROUP BY taxdescription
        ORDER BY taxdescription
	RETURN
END

-- Visualizza le INFO sul percipiente dettagliate o meno a seconda di @unified_mov

IF (@unified_mov='N') 
	BEGIN
	       SELECT
	        ymov as 'Eserc.Mov',
	        nmov as 'Num.Mov.',
	        title as 'Percipiente',
			cf 'C.F.',
	        surname as 'Cognome', forename as 'Nome',
	        birthdate as 'data Nascita', 
	        GC_title as 'Luogo Nascita',
	        GP_province as 'Prov.Nascita', 
	        GN_title as 'Stato Nascita',
	        gender as 'Sesso',
			servicedescription as 'Prestazione',
	        desc_exp as 'Descr.Spesa',
	        servicestart as 'Inizio Prest.',
	        servicestop as 'Fine Prest.',
	        address as 'Indirizzo',
	        location as 'Località',
	        province as 'Provincia',
	        nation as 'Stato',
	        cap as 'CAP',
	        GC_tax_title as 'Comune', 
	        fiscal_region as 'Regione Fiscale',
	        taxdescription as 'Ritenuta',
	        ISNULL(SUM(employtax_liq_periodo),0) AS 'Rit/Dip. applicate e liquidate nel periodo',--A
	        ISNULL(SUM(employtax_operate_prec),0) AS 'Rit/Dip. applicate in periodi prec. e liquidate nel periodo',--B
	        ISNULL(SUM(employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
	        ISNULL(SUM(employtax_liq_tot),0) AS 'Tot. Rit/Dip. Liquidato',-- A+B
	
	        ISNULL(SUM(admintax_liq_periodo),0) AS 'Contributi applicati e liquidati nel periodo',--A
	        ISNULL(SUM(admintax_operate_prec),0) AS 'Contributi applicati in periodi prec. e liquidate nel periodo',--B
	        ISNULL(SUM(admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo', --C
	        ISNULL(SUM(admintax_liq_tot),0) AS 'Tot. Contributi Liquidati'-- A+B
	      FROM #unifiedtax
		GROUP BY cf,title,taxdescription,servicedescription, GC_tax_title ,fiscal_region,
	                surname, forename,birthdate,GC_title,GP_province, 
	                GN_title, gender,address,location,province,nation,cap,
	                ymov, nmov,desc_exp,servicestart,servicestop
	        ORDER BY taxdescription, title

		RETURN
	END


IF (@unified_mov='S') 
	BEGIN
	      SELECT
	        title as 'Percipiente',
			cf 'C.F.',
	        surname as 'Cognome', forename as 'Nome',
	        birthdate as 'data Nascita', 
	        GC_title as 'Luogo Nascita',
	        GP_province as 'Prov.Nascita', 
	        GN_title as 'Stato Nascita',
	        gender as 'Sesso',
	        address as 'Indirizzo',
	        location as 'Località',
	        province as 'Provincia',
	        nation as 'Stato',
	        cap as 'CAP',
	        GC_tax_title as 'Comune', 
	        fiscal_region as 'Regione Fiscale',
	        taxdescription as 'Ritenuta',
	        ISNULL(SUM(employtax_liq_periodo),0) AS 'Rit/Dip. applicate e liquidate nel periodo',--A
	        ISNULL(SUM(employtax_operate_prec),0) AS 'Rit/Dip. applicate in periodi prec. e liquidate nel periodo',--B
	        ISNULL(SUM(employtax_non_liq),0) AS 'Rit/Dip. applicate nel periodo e non liquidate nel periodo',--C
	        ISNULL(SUM(employtax_liq_tot),0) AS 'Tot. Rit/Dip. Liquidato',-- A+B
	
	        ISNULL(SUM(admintax_liq_periodo),0) AS 'Contributi applicati e liquidati nel periodo',--A
	        ISNULL(SUM(admintax_operate_prec),0) AS 'Contributi applicati in periodi prec. e liquidate nel periodo',--B
	        ISNULL(SUM(admintax_non_liq),0) AS 'Contributi applicati nel periodo e non liquidate nel periodo', --C
	        ISNULL(SUM(admintax_liq_tot),0) AS 'Tot. Contributi Liquidati'-- A+B
	        FROM #unifiedtax
	        GROUP BY cf,title, taxdescription,GC_tax_title, fiscal_region,
	                surname, forename,birthdate,GC_title,GP_province, 
	                GN_title, gender,address,location,province,nation,cap
	        ORDER BY taxdescription, title
	RETURN
	END




END







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

