
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_ritenute_impon_saldo]') and OBJECTPROPERTY(id, N'IsPROCEDURE') = 1)
drop PROCEDURE [exp_unified_ritenute_impon_saldo]
GO

SET QUOTED_IDENTIFIER ON 
GO

SET ANSI_NULLS ON 
GO
-- exec exp_unified_ritenute_impon_saldo 2015,null ,null,null,{ts '2015-01-01 00:00:00'} , {ts '2015-12-31 00:00:00'},'N'

CREATE PROCEDURE exp_unified_ritenute_impon_saldo
(
	@ayear int, 
	@idreg int, 
	@tax   int,
	@idser int,  
	@start datetime,
	@stop  datetime,
	@show_month char(1),
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
) 
AS
Begin
-- Questa sp è praticamente la exp_riepilogo_ritenute_applicate_impon
-- eseguita con:
-- @mode = Saldo
-- @unified_mov = S consolida dei movimenti del percipiente
-- Ha lo scopo di visualizzare il saldo per Tipo Ritenuta

CREATE TABLE #unifiedtax 
(
	monthtaxpay varchar(2),
	nmov int,
	ymov int,
	title varchar(100),
	cf varchar(16),
	taxdescription varchar(50),
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

       
INSERT INTO #unifiedtax (
	monthtaxpay,
	title,cf,
	taxdescription,
	surname,forename,p_iva,
	birthdate,GC_title,GP_province,GN_title,
	gender,
	address,location,province,nation,cap,
	GC_tax_title, fiscale_region,
	taxablegross,taxablenet,employtax,admintax,abatements
)
EXEC exp_riepilogo_ritenute_applicate_impon @ayear,@idreg,@tax,@idser,@start,@stop,'S','S','S',@idsor01,@idsor02,@idsor03,@idsor04,	@idsor05
       



--------------- ELABORAZIONE DELL'OUTPUT FINALE --------------------------------------------

IF (@show_month = 'S')
        SELECT
                monthtaxpay as 'Mese ',
                taxdescription as 'Ritenuta',  
                isnull(sum(taxablegross),0) as ' Imponibile Lordo',
                isnull(sum(taxablenet),0) as 'Imponibile Netto',
                isnull(sum(employtax),0) as 'Rit.Dip.',
                isnull(sum(admintax),0) as 'Rit.Amm.',
                isnull(sum(abatements),0) as 'Detrazioni Applicate' 
        FROM #unifiedtax
        GROUP BY taxdescription,monthtaxpay
        ORDER BY taxdescription

IF (@show_month = 'N') 
        SELECT
                taxdescription as 'Ritenuta',  
                isnull(sum(taxablegross),0) as ' Imponibile Lordo',
                isnull(sum(taxablenet),0) as 'Imponibile Netto',
                isnull(sum(employtax),0) as 'Rit.Dip.',
                isnull(sum(admintax),0) as 'Rit.Amm.',
                isnull(sum(abatements),0) as 'Detrazioni Applicate' 
        FROM #unifiedtax
        GROUP BY taxdescription
        ORDER BY taxdescription


end






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

