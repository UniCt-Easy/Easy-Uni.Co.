
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available_partition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_expense_available_partition]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO

--setuser 'amm'
-- exec [exp_csa_expense_available_partition] 2020,654

CREATE PROCEDURE  [exp_csa_expense_available_partition]
	(
		@ayear int,
		@idcsa_import int  -- ,

	)
--setuser 'amministrazione'
--setuser 'amm'

AS BEGIN

DECLARE @kind CHAR(1)
-- T deve essere eseguita sia la fase Lordi che la fase Versamenti, 
-- L deve essere eseguita solo la fase Lordi, 
-- V deve essere eseguita solo la fase Versamenti, 
-- N movimenti finanziari gi� generati 

 
      --   + movkind 1 mov. entrata ritenute	 (fase LORDI)
      --   - movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)      
      
      --   + movkind 3 mov. spesa costo  lordi (fase LORDI)
      --   - movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)
      
      --   - movkind 15 mov. entrata recuperi diretti (fase LORDI)  
      --   - movkind 16 mov. spesa recuperi diretti (negativi) (fase LORDI)
	  --   + movkind 4 mov. spesa contributi/ritenute (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
	  --   - movkind 10 mov. entrata di ricavo contributi (negativi) ( VERSAMENTI se liquidazione diretta)
	  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)

declare @totlordi_exp int
select @totlordi_exp = COUNT(*) FROM csa_import_expense  where idcsa_import = @idcsa_import AND movkind  in (3,16,8)

declare @totlordi_inc int
select @totlordi_inc = COUNT(*) FROM csa_import_income where idcsa_import = @idcsa_import AND movkind   in (7,1,15)

declare @totversamenti_exp int
select @totversamenti_exp= COUNT(*) FROM csa_import_expense   where idcsa_import = @idcsa_import AND   movkind in (4)

declare @totversamenti_inc int
select @totversamenti_inc=  COUNT(*) FROM csa_import_income  where idcsa_import = @idcsa_import AND movkind  in (9,10)



--- SONO STATE GENERATE TUTTE E DUE LE FASI
IF ((@totlordi_exp	+	@totlordi_inc)> 0 AND (@totversamenti_exp +	@totversamenti_inc) > 0)  	
BEGIN
	SET @kind = 'N'
END
ELSE
	BEGIN
	--- IPOTESI: DEVONO ESSERE GENERATE TUTTE E DUE LE FASI
	SET @kind = 'T'   
	-- SONO STATI GENERATI SOLO I LORDI, DEVONO ESSERE GENERATI ANCORA I VERSAMENTI
		IF ((@totlordi_exp	+	@totlordi_inc)> 0 AND (@totversamenti_exp +	@totversamenti_inc) = 0)  	  BEGIN
				BEGIN
					SET @kind = 'V' 
				END
		END
		ELSE
		-- SONO STATI GENERATI SOLO I VERSAMENTI, DEVONO ESSERE GENERATI ANCORA I LORDI 
		IF ((@totlordi_exp	+	@totlordi_inc)= 0 AND (@totversamenti_exp +	@totversamenti_inc) > 0)  	 
		BEGIN
					SET @kind = 'L' 
		END
	END
	PRINT @kind
	IF (@kind = 'N' )
	--select null as phase,
	--null as finance,
	--null as upb,
	--null as registry,
	--null as curramount,
	--null as available_1,
	--null as available_2,
	--null as available_3,		
	--null as available_4,
	--null as flagcr,
	--null as idexp  

RETURN

create table #output_lordi
(
idcsa_import int,idriep int , idver int ,ndetail int, kind varchar(20), movkind int , parentidinc int, parentidexp int , 	parent_phase int,
 idman int, idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)
) 

create table #output_versamenti
(
idcsa_import int,idriep int,  idver int, ndetail int, kind varchar(20), movkind int , parentidinc int, parentidexp int , 	parent_phase int,
idman int,  idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2),amount_diff decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)
) 


create table #output_versamenti_posticipati
(
idcsa_import int,idriep int,  idver int, ndetail int, kind varchar(20), movkind int , parentidinc int, parentidexp int , 	parent_phase int,
idman int,  idreg int , registry varchar(200), idcsa_agency int , idcsa_agencypaymethod int , idfin int, 
codefin varchar(20), idsor int, sortcode varchar(50), parentidsor int , parentsortcode varchar(20),idupb varchar(36), 
codeupb varchar(50), description varchar(200), idacc varchar(38), codeacc varchar(50), amount decimal(19,2),amount_diff decimal(19,2), idcsa_contractkind int,
idcsa_contract int, idunderwriting int, codeunderwriting varchar(50),vocecsa varchar(200)
) 


DECLARE @lista_idcsa_import dbo.int_list  
DECLARE	@lista_idreg_agency dbo.int_list  

IF (@kind = 'T')
BEGIN
	insert into #output_lordi
	select * from f_compute_csa_lordi_partition (@ayear, @idcsa_import)

	insert into #output_versamenti (idcsa_import ,idriep ,  idver , ndetail , kind , movkind , parentidinc , parentidexp , 	parent_phase ,
					idman ,  idreg , registry , idcsa_agency , idcsa_agencypaymethod , idfin , 
					codefin , idsor, sortcode , parentidsor, parentsortcode,idupb , 
					codeupb , description , idacc , codeacc , amount , idcsa_contractkind ,
					idcsa_contract , idunderwriting , codeunderwriting ,vocecsa )
	select * from f_compute_csa_versamenti_partition (@ayear, @idcsa_import,@lista_idcsa_import,@lista_idreg_agency)
	-- versamenti posticipati sugli enti che lo consentono
	insert into @lista_idcsa_import (n) values (@idcsa_import)
	insert into @lista_idreg_agency (n) select distinct idreg from csa_agency where flag & 1 <> 0

	insert into #output_versamenti_posticipati (idcsa_import ,idriep ,  idver , ndetail , kind , movkind , parentidinc , parentidexp , 	parent_phase ,
					idman ,  idreg , registry , idcsa_agency , idcsa_agencypaymethod , idfin , 
					codefin , idsor, sortcode , parentidsor, parentsortcode,idupb , 
					codeupb , description , idacc , codeacc , amount_diff , idcsa_contractkind ,
					idcsa_contract , idunderwriting , codeunderwriting ,vocecsa )	
	select * from f_compute_csa_versamenti_partition (@ayear, null,@lista_idcsa_import,@lista_idreg_agency)
	where idcsa_agency in (select idcsa_agency from csa_agency where flag & 1 <> 0)  -- esamino solo quelli posticipati
END 
IF (@kind = 'V')
BEGIN
	insert into #output_versamenti (idcsa_import ,idriep ,  idver , ndetail , kind , movkind , parentidinc , parentidexp , 	parent_phase ,
					idman ,  idreg , registry , idcsa_agency , idcsa_agencypaymethod , idfin , 
					codefin , idsor, sortcode , parentidsor, parentsortcode,idupb , 
					codeupb , description , idacc , codeacc , amount , idcsa_contractkind ,
					idcsa_contract , idunderwriting , codeunderwriting ,vocecsa )
	select * from f_compute_csa_versamenti_partition (@ayear, @idcsa_import,@lista_idcsa_import,@lista_idreg_agency)

	insert into @lista_idcsa_import (n) values (@idcsa_import)
	insert into @lista_idreg_agency (n) select distinct idreg from csa_agency where flag & 1 <> 0
		-- versamenti posticipati sugli enti che lo consentono
	insert into #output_versamenti_posticipati (idcsa_import ,idriep ,  idver , ndetail , kind , movkind , parentidinc , parentidexp , 	parent_phase ,
					idman ,  idreg , registry , idcsa_agency , idcsa_agencypaymethod , idfin , 
					codefin , idsor, sortcode , parentidsor, parentsortcode,idupb , 
					codeupb , description , idacc , codeacc , amount_diff , idcsa_contractkind ,
					idcsa_contract , idunderwriting , codeunderwriting ,vocecsa )	
	select * from f_compute_csa_versamenti_partition (@ayear, @idcsa_import,@lista_idcsa_import,@lista_idreg_agency)
 	where idcsa_agency in (select idcsa_agency from csa_agency where flag & 1 <> 0)  -- esamino solo quelli posticipati
END

IF (@kind = 'L')
BEGIN
	insert into #output_lordi
	select * from f_compute_csa_lordi_partition (@ayear, @idcsa_import)

END


;with padri (idexp) as (
select distinct csa_importver_partition.idexp from   csa_importver
		JOIN csa_importver_partition
		ON csa_importver.idcsa_import = csa_importver_partition.idcsa_import
		AND csa_importver.idver = csa_importver_partition.idver
where csa_importver.idcsa_import =  @idcsa_import

union 

select distinct csa_importriep_partition.idexp from   csa_importriep
		JOIN csa_importriep_partition
		ON csa_importriep.idcsa_import = csa_importriep_partition.idcsa_import
		AND csa_importriep.idriep = csa_importriep_partition.idriep
		where csa_importriep.idcsa_import =  @idcsa_import
)


  
select --   FASE LORDI E VERSAMENTI
	phase + ' n ' + convert(varchar(10),nmov) + '/' +
	convert(varchar(4),ymov) as 'Movimento',

	codefin + '-' + finance as 'Bilancio',

	 codeupb + '-' + upb as 'UPB',

	 registry as 'Anagrafica',

	 curramount  as 'Importo Corrente',
	 available as 'Importo Disponibile Attuale',
	 CASE WHEN ( @kind IN ('L','T'))  
	 THEN  available	 - isnull((SELECT SUM(amount) FROM #output_lordi	 WHERE  #output_lordi.parentidexp = padri.idexp),0)
	 ELSE available
	 END
	  as 'Disponibile dopo elaborazione solo Lordi',

	 CASE WHEN  (@kind IN ('V','T'))
	 THEN available	 - isnull((SELECT SUM(amount) FROM #output_versamenti  WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 ELSE  available
	 END 
	  as 'Disponibile dopo elaborazione solo  Versamenti',

	 CASE WHEN  (@kind IN ('V','T'))
	 THEN available	 - isnull((SELECT SUM(amount) FROM #output_versamenti_posticipati  WHERE  #output_versamenti_posticipati.parentidexp = padri.idexp),0)
	 ELSE  available
	 END 
	  as 'Disponibile dopo elaborazione solo Versamenti posticipati',
	
	CASE WHEN  (@kind IN ('V','T'))
	 THEN available	 - isnull((SELECT SUM(isnull(amount,0)+isnull(amount_diff,0)) FROM #output_versamenti  WHERE  #output_versamenti.parentidexp = padri.idexp),0)
					 - isnull((SELECT SUM(isnull(amount,0)+isnull(amount_diff,0)) FROM #output_versamenti_posticipati  WHERE  #output_versamenti_posticipati.parentidexp = padri.idexp),0)
	 ELSE  available
	 END 
	  as 'Disponibile dopo elaborazione  Versamenti e V.Posticipati',     

	CASE WHEN @kind = 'T'  THEN
	 available - isnull((SELECT SUM(amount) FROM #output_lordi  WHERE  #output_lordi.parentidexp = padri.idexp),0) 
			   - isnull((SELECT SUM(amount) FROM #output_versamenti WHERE  #output_versamenti.parentidexp = padri.idexp),0)
			   
	 WHEN @kind = 'L'  THEN	 available - isnull((SELECT SUM(amount) FROM #output_lordi	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 	 
	 WHEN @kind = 'V' THEN   available - isnull((SELECT SUM(amount) FROM #output_versamenti	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	 ELSE available
	 END
	 as 'Disponibile dopo elaborazione Lordi e Versamenti',

	 CASE WHEN @kind = 'T'  THEN
	 available  - isnull((SELECT SUM(amount) FROM #output_lordi  WHERE  #output_lordi.parentidexp = padri.idexp),0) 
				- isnull((SELECT SUM(amount) FROM #output_versamenti WHERE  #output_versamenti.parentidexp = padri.idexp),0)	
				- isnull((SELECT SUM(isnull(amount,0)+isnull(amount_diff,0)) FROM #output_versamenti_posticipati  WHERE  #output_versamenti_posticipati.parentidexp = padri.idexp),0)	  
	 WHEN @kind = 'L'  THEN	 available - isnull((SELECT SUM(amount) FROM #output_lordi	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 	 
	 WHEN @kind = 'V' THEN   available - isnull((SELECT SUM(isnull(amount,0)+isnull(amount_diff,0)) FROM #output_versamenti	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
									   - isnull((SELECT SUM(isnull(amount,0)+isnull(amount_diff,0)) FROM #output_versamenti_posticipati  WHERE  #output_versamenti_posticipati.parentidexp = padri.idexp),0)	 
	 ELSE available
	 END
	 as 'Disponibile dopo elaborazione Lordi e Versamenti e V.Posticipati',

	 
	flagarrear as 'C/R' ,
	expenseview.idexp as 'idexp'
 from padri
 
join expenseview
	on expenseview.idexp = padri.idexp
	and expenseview.ayear = @ayear	
	and ( available - isnull((SELECT SUM(amount) FROM #output_lordi
	 WHERE  #output_lordi.parentidexp = padri.idexp),0) 
	 - isnull((SELECT SUM(amount) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0)
	  
	 - isnull((SELECT SUM(amount_diff) FROM #output_versamenti
	 WHERE  #output_versamenti.parentidexp = padri.idexp),0) 

	 - isnull((SELECT SUM(amount_diff) FROM #output_versamenti_posticipati
	 WHERE  #output_versamenti_posticipati.parentidexp = padri.idexp),0) 
	 <0)

END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 
