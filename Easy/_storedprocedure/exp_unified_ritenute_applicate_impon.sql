
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_ritenute_applicate_impon]') and OBJECTPROPERTY(id, N'IsPROCEDURE') = 1)
drop PROCEDURE [exp_unified_ritenute_applicate_impon]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--	exec exp_unified_ritenute_applicate_impon 2015,null ,null,null,{ts '2015-01-01 00:00:00'} , {ts '2015-12-31 00:00:00'},'R','S','N', 'S'


CREATE PROCEDURE exp_unified_ritenute_applicate_impon
(
	@ayear int, 
	@idreg int, 
	@tax   int,
	@idser int,  
	@start datetime,
	@stop  datetime,
	@mode  char(1),
	@unified_mov char(1), -- consolidamento dei movimenti del percipiente
	@show_month char(1),
	@compensi_notax char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) 
as begin

CREATE TABLE #unifiedtax 
(
	monthtaxpay varchar(2),
	nmov int,
	ymov int,
    npay int,
	codefin varchar(50),
	codeupb varchar(50),
	title varchar(100),
	cf varchar(16),
	taxdescription varchar(150),
	surname varchar(50),
	forename varchar(50),
	p_iva varchar(15),
	birthdate datetime,
	GC_title varchar(65),
	GP_province varchar(2),
	GN_title varchar(65),
	gender char(1), 
	desc_exp varchar(150),
	service_description varchar(50),
	servicestart datetime,
	servicestop datetime,
	address varchar(100),
	location varchar(65),
	province varchar(2),
	nation varchar(65),
	cap varchar(20),
	GC_tax_title  varchar(65),  
	fiscale_region varchar(50),
	taxablegross decimal(19,2),
	taxablenet decimal(19,2),
	employtax decimal(19,2),
	admintax decimal(19,2),
	abatements decimal(19,2)
)


-- Chiamo la sp con @unified_mov = N, @show_department = S e @show_month = S per ricevere TUTTI i dati, in output li elaboro.
		INSERT INTO #unifiedtax (
			monthtaxpay,
			nmov,ymov,npay,
			codefin, codeupb,
			title,cf,
			taxdescription,
			surname,forename,p_iva,
			birthdate,GC_title,GP_province,GN_title,
			gender,desc_exp,
			service_description,servicestart,servicestop,
			address,location,province,nation,cap,
			GC_tax_title, fiscale_region,
			taxablegross,taxablenet,employtax,admintax,abatements
		)
		EXEC exp_riepilogo_ritenute_applicate_impon @ayear,@idreg,@tax,@idser,@start,@stop,@mode,'N','S', @idsor01,@idsor02,@idsor03,@idsor04,@idsor05
if (@compensi_notax = 'S')
Begin
		INSERT INTO #unifiedtax (
			monthtaxpay,
			nmov,ymov,npay,
			codefin, codeupb,
			title,cf,
			taxdescription,
			surname,forename,p_iva,
			birthdate,GC_title,GP_province,GN_title,
			gender,desc_exp,
			service_description,servicestart,servicestop,
			address,location,province,nation,cap,
			GC_tax_title, fiscale_region,
			taxablegross,taxablenet,employtax,admintax,abatements
		)
		EXEC exp_riepilogo_ritenute_applicate_impon_notax @ayear,@idreg,@tax,@idser,@start,@stop,@mode,'N','S', @idsor01,@idsor02,@idsor03,@idsor04,@idsor05

End

IF (@mode = 'T')
BEGIN
  IF (@unified_mov = 'S')--@unified_mov = 'S' non mostro i dettagli dei movimenti per percipiente.
  BEGIN
        IF @show_month ='S'
        BEGIN
                SELECT
                        monthtaxpay as 'Mese ',
                        title as Percipiente,
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
                		gender as 'Sesso',
                        address as 'Indirizzo',location as 'Località',province as 'Provincia',
                    	nation as 'Stato',cap as 'CAP',
                        GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        taxablegross as ' Imponibile Lordo',taxablenet as 'Imponibile Netto',
                        employtax as 'Rit.Dip.',admintax as 'Rit.Amm.',
                        abatements as 'Detrazioni Applicate'  
        	FROM #unifiedtax
        	ORDER BY title, cf,taxdescription
        END
        IF  @show_month ='N'
        BEGIN
                SELECT
                        title as Percipiente,
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
                		gender as 'Sesso',
                        address as 'Indirizzo',location as 'Località',province as 'Provincia',
                    	nation as 'Stato',cap as 'CAP',
                        GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        taxablegross as ' Imponibile Lordo',taxablenet as 'Imponibile Netto',
                        employtax as 'Rit.Dip.',admintax as 'Rit.Amm.',
                        abatements as 'Detrazioni Applicate'  
        	FROM #unifiedtax
        	ORDER BY title, cf,taxdescription
        END
  END
  ELSE -- ossia : @unified_mov = 'N' mostro anche i dettagli dei movimenti per percipiente.
  BEGIN
        IF( @show_month ='S')
        BEGIN
                SELECT
                        monthtaxpay as 'Mese ',
                        nmov as 'Num.Mov.',
                        ymov as 'Eserc.Mov.',
                        npay as 'Num.Mandato',
						codefin as'Bilancio del Pag.della prestazione',
						codeupb as'UPB del Pag.della prestazione',
                        title as 'Percipiente',
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
						gender as 'Sesso',
						desc_exp as 'Descr.Spesa',
						service_description as 'Prestazione',
						servicestart as 'Inizio Pres.',
						servicestop as 'Fine Prest',
						address as 'Indirizzo',location as 'Località',province as 'Provincia',
						nation as 'Stato',cap as 'CAP',
						GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        taxablegross as ' Imponibile Lordo',taxablenet as 'Imponibile Netto',
                        employtax as 'Rit.Dip.',admintax as 'Rit.Amm.',
                        abatements as 'Detrazioni Applicate'  
        	FROM #unifiedtax
        	ORDER BY title,cf,taxdescription
        END

        IF(  @show_month ='N')
        BEGIN
                SELECT
                        nmov as 'Num.Mov.',
                        ymov as 'Eserc.Mov.',
                        npay as 'Num.Mandato',
						codefin as'Bilancio del Pag.della prestazione',
						codeupb as'UPB del Pag.della prestazione',
						title as 'Percipiente',
						cf as 'CF',
						taxdescription as 'Ritenuta',  
						surname as 'Cognome', forename as 'Nome',
						p_iva as 'P.iva',
						birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
						GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
						gender as 'Sesso',
						desc_exp as 'Descr.Spesa',
						service_description as 'Prestazione',
						servicestart as 'Inizio Pres.',
						servicestop as 'Fine Prest',
						address as 'Indirizzo',location as 'Località',province as 'Provincia',
						nation as 'Stato',cap as 'CAP',
						GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        taxablegross as ' Imponibile Lordo',taxablenet as 'Imponibile Netto',
                        employtax as 'Rit.Dip.',admintax as 'Rit.Amm.',
                        abatements as 'Detrazioni Applicate'  
        	FROM #unifiedtax
        	ORDER BY title, cf,taxdescription
        END
   END


END --IF (@mode = 'T')
---------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------
ELSE--(@mode <> 'T')
BEGIN
  IF (@unified_mov = 'S')--@unified_mov = 'S' non mostro i dettagli dei movimenti per percipiente.
  BEGIN
        IF(  @show_month ='S')
        BEGIN
                SELECT
                        monthtaxpay as 'Mese ',
                        title as Percipiente,
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
                		gender as 'Sesso',
                        address as 'Indirizzo',location as 'Località',province as 'Provincia',
                    	nation as 'Stato',cap as 'CAP',
                        GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        isnull(sum(taxablegross),0) as ' Imponibile Lordo',
                        isnull(sum(taxablenet),0) as 'Imponibile Netto',
                        isnull(sum(employtax),0) as 'Rit.Dip.',
                        isnull(sum(admintax),0) as 'Rit.Amm.',
                        isnull(sum(abatements),0) as 'Detrazioni Applicate' 
        	FROM #unifiedtax
        	GROUP BY title,cf,taxdescription,monthtaxpay,  
                        surname,forename,
                        p_iva,
                        birthdate, GC_title,
                        GP_province,GN_title,
                		gender,address,location,province,nation,cap,GC_tax_title,fiscale_region 
        	ORDER BY title, cf,taxdescription

        END
        IF(  @show_month ='N')
        BEGIN
                SELECT
                        title as Percipiente,
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
                		gender as 'Sesso',
                        address as 'Indirizzo',location as 'Località',province as 'Provincia',
                    	nation as 'Stato',cap as 'CAP',
                        GC_tax_title as 'Comune', 
                        fiscale_region as 'Regione Fiscale',
                        isnull(sum(taxablegross),0) as ' Imponibile Lordo',
                        isnull(sum(taxablenet),0) as 'Imponibile Netto',
                        isnull(sum(employtax),0) as 'Rit.Dip.',
                        isnull(sum(admintax),0) as 'Rit.Amm.',
                        isnull(sum(abatements),0) as 'Detrazioni Applicate' 
        	FROM #unifiedtax
        	GROUP BY title,cf,taxdescription,  
                        surname,forename,
                        p_iva,
                        birthdate, GC_title,
                        GP_province,GN_title,
                		gender,
                        address,location,province,nation,cap,GC_tax_title,fiscale_region 
        	ORDER BY title, cf,taxdescription
        END
  END
  ELSE -- ossia : @unified_mov = 'N' mostro anche i dettagli dei movimenti per percipiente.
  BEGIN
        IF( @show_month ='S')
        BEGIN
                SELECT
					monthtaxpay as 'Mese ',
					nmov as 'Num.Mov.',
					ymov as 'Eserc.Mov.',
					npay as 'Num.Mandato',
					codefin as'Bilancio del Pag.della prestazione',
					codeupb as'UPB del Pag.della prestazione',
					title as 'Percipiente',
					cf as 'CF',
					taxdescription as 'Ritenuta',  
					surname as 'Cognome', forename as 'Nome',
					p_iva as 'P.iva',
					birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
					GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
					gender as 'Sesso',
					desc_exp as 'Descr.Spesa',
					service_description as 'Prestazione',
					servicestart as 'Inizio Pres.',
					servicestop as 'Fine Prest',
					address as 'Indirizzo',location as 'Località',province as 'Provincia',
					nation as 'Stato',cap as 'CAP',
					GC_tax_title as 'Comune', 
					fiscale_region as 'Regione Fiscale',
					taxablegross as ' Imponibile Lordo',taxablenet as 'Imponibile Netto',
					employtax as 'Rit.Dip.',admintax as 'Rit.Amm.',
					abatements as 'Detrazioni Applicate'  
        	FROM #unifiedtax
        	ORDER BY title,cf,taxdescription
        END

        IF(  @show_month ='N')
        BEGIN
                SELECT
                        nmov as 'Num.Mov.',
                        ymov as 'Eserc.Mov.',
                        npay as 'Num.Mandato',
						codefin as'Bilancio del Pag.della prestazione',
						codeupb as'UPB del Pag.della prestazione',
                        title as 'Percipiente',
                		cf as 'CF',
                        taxdescription as 'Ritenuta',  
                        surname as 'Cognome', forename as 'Nome',
                        p_iva as 'P.iva',
                        birthdate as 'data Nascita', GC_title as 'Luogo Nascita',
                        GP_province as 'Prov.Nascita', GN_title as 'Stato Nascita',
                		gender as 'Sesso',
						desc_exp as 'Descr.Spesa',
						service_description as 'Prestazione',
						servicestart as 'Inizio Pres.',
						servicestop as 'Fine Prest',
						address as 'Indirizzo',location as 'Località',province as 'Provincia',
						nation as 'Stato',cap as 'CAP',
						GC_tax_title as 'Comune', 
                        isnull(sum(taxablegross),0) as ' Imponibile Lordo',
                        isnull(sum(taxablenet),0) as 'Imponibile Netto',
                        isnull(sum(employtax),0) as 'Rit.Dip.',
                        isnull(sum(admintax),0) as 'Rit.Amm.',
                        isnull(sum(abatements),0) as 'Detrazioni Applicate' 
        	FROM #unifiedtax
        	GROUP BY title,cf,taxdescription,  
                        surname,forename,
                        p_iva,
                        birthdate, GC_title,
                        GP_province,GN_title,
                		gender,
                        nmov, ymov,npay,codefin,codeupb,desc_exp,service_description,servicestart,servicestop, 
                        address,location,province,nation,cap,GC_tax_title,fiscale_region 
        	ORDER BY title, cf,taxdescription
        END


   END

END---

end




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


