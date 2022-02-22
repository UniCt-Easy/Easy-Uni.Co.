
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_fin_upb_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_fin_upb_available]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO
 

 --setuser 'amm'
 --setuser 'amministrazione'
-- exec [exp_csa_fin_upb_available] 2020, 2606
--select * from csa_import where yimport=2020 and nimport=24		--2606
CREATE PROCEDURE  [exp_csa_fin_upb_available]
	(
		@ayear int,
		@idcsa_import int  -- ,
		--@kind CHAR(1) -- T deve essere eseguita sia la fase Lordi che la fase Versamenti, 
		--		  -- V deve essere eseguita solo la fase Versamenti, 
		--		  -- N movimenti finanziari già generati 
	)

AS BEGIN

DECLARE @finphaseexpense tinyint
DECLARE @maxphaseexpense tinyint

SELECT @finphaseexpense = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphaseexpense IS NULL
BEGIN
	SELECT @finphaseexpense = expensefinphase FROM uniconfig
END
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase


DECLARE @finphaseincome tinyint
DECLARE @maxphaseincome tinyint

SELECT @finphaseincome = assessmentphasecode FROM config WHERE ayear = @ayear
IF @finphaseincome IS NULL 
BEGIN
	SELECT @finphaseincome = incomefinphase FROM uniconfig
END
SELECT @maxphaseincome = MAX(nphase) FROM incomephase


DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear

 DECLARE @lista_idcsa_import dbo.int_list  
DECLARE	@lista_idreg_agency dbo.int_list  

      --   + movkind 1 mov. entrata ritenute	 (fase LORDI)
      --   - movkind 8 mov. spesa ritenute  (negativi) (fase LORDI)      
      
      --   + movkind 3 mov. spesa costo  lordi (fase LORDI)
      --   - movkind 7 mov. entrata ricavo lordi (negativi) (fase LORDI)
      
      --   - movkind 15 mov. entrata recuperi diretti (fase LORDI)  
      --   - movkind 16 mov. spesa recuperi diretti (negativi) (fase LORDI) 
	  --   + movkind 4 mov. spesa contributi/ritenute (fase VERSAMENTI)  (anche versamento contributi a liq. diretta)
	  --   - movkind 10 mov. entrata di ricavo contributi (negativi) ( VERSAMENTI se liquidazione diretta)
	  --   - movkind 9 mov. entrata (dall'erario) ritenute (negative) (fase VERSAMENTI)

DECLARE @kind CHAR(1)
declare @totlordi_exp int
select @totlordi_exp = COUNT(*) FROM csa_import_expense  where idcsa_import = @idcsa_import AND movkind  in (3,16,8)

declare @totlordi_inc int
select @totlordi_inc = COUNT(*) FROM csa_import_income where idcsa_import = @idcsa_import AND movkind   in (1, 7, 15)

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
--IF (@kind = 'N') 
--	--select null as phase,
--	--null as finance,
--	--null as upb,
--	--null as registry,
--	--null as curramount,
--	--null as available_1,
--	--null as available_2,
--	--null as available_3,		
--	--null as available_4,
--	--null as flagcr,
--	--null as idexp  
--RETURN

create table #output_lordi
(
		kind varchar(20), movkind int , parentidinc int , parentidexp int ,idfin int, idupb varchar(36),			
			totcompetenza decimal(19,2), totcassa decimal(19,2)
		---amount decimal(19,2)
) 

create table #output_versamenti
(
		kind varchar(20), movkind int , parentidinc int , parentidexp int ,idfin int, idupb varchar(36),	
			totcompetenza decimal(19,2), totcassa decimal(19,2)
		---amount decimal(19,2)
) 

create table #output_versamenti_diff
(
		kind varchar(20), movkind int , parentidinc int , parentidexp int ,idfin int, idupb varchar(36),	
			totcompetenza decimal(19,2), totcassa decimal(19,2)
		---amount decimal(19,2)
) 

--select * from  #output_versamenti
--select * from  #output_versamenti_diff

IF (@kind = 'T')
BEGIN
	insert into #output_lordi (kind,idfin,idupb,totcompetenza,totcassa)			
	select LORDI.kind,LORDI.idfin,LORDI.idupb, 	sum( amount), sum(amount)
	 from f_compute_csa_lordi_partition (@ayear, @idcsa_import) LORDI
		where lordi.parentidexp is null
		group by LORDI.kind,LORDI.idfin,LORDI.idupb

	insert into #output_versamenti (kind,idfin,idupb,totcompetenza,totcassa)		
	select VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb,		sum( amount), sum(amount)
	 from f_compute_csa_versamenti_partition (@ayear, @idcsa_import,@lista_idcsa_import,@lista_idreg_agency) VERSAMENTI
		where VERSAMENTI.parentidexp is null
		group by VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb

	insert into @lista_idcsa_import (n) values (@idcsa_import)
	insert into @lista_idreg_agency (n) select distinct idreg from csa_agency where flag & 1 <> 0
	insert into #output_versamenti_diff (kind,idfin,idupb,totcompetenza,totcassa)		
	select VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb,		sum( amount), sum(amount)
	 from f_compute_csa_versamenti_partition (@ayear, null,@lista_idcsa_import,@lista_idreg_agency) VERSAMENTI
		where VERSAMENTI.parentidexp is null and VERSAMENTI.idcsa_agency in (select idcsa_agency from csa_agency where flag & 1 <> 0) --- solo posticipati
		group by VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb
END 
IF (@kind = 'V')
BEGIN
	insert into #output_versamenti (kind,idfin,idupb,totcompetenza,totcassa)		
	select VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb, sum( amount), sum(amount)
	 from f_compute_csa_versamenti_partition (@ayear, @idcsa_import,@lista_idcsa_import,@lista_idreg_agency) VERSAMENTI
		where VERSAMENTI.parentidexp is null 
	 group by VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb

	insert into @lista_idcsa_import (n) values (@idcsa_import)
	insert into @lista_idreg_agency (n) select distinct idreg from csa_agency where flag & 1 <> 0
	insert into #output_versamenti_diff (kind,idfin,idupb,totcompetenza,totcassa)		
	select VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb,		sum( amount), sum(amount)
	 from f_compute_csa_versamenti_partition (@ayear, null,@lista_idcsa_import,@lista_idreg_agency) VERSAMENTI
		where VERSAMENTI.parentidexp is null and VERSAMENTI.idcsa_agency in (select idcsa_agency from csa_agency where flag & 1 <> 0) --- solo posticipati
		group by VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb
END

IF (@kind = 'L')
BEGIN
	insert into #output_lordi (kind,idfin,idupb,totcompetenza,totcassa)			
	select LORDI.kind,LORDI.idfin,LORDI.idupb,	sum( amount), sum(amount)
	 from f_compute_csa_lordi_partition (@ayear, @idcsa_import) LORDI
		where lordi.parentidexp is null
		group by LORDI.kind,LORDI.idfin,LORDI.idupb

END

--select * from  #output_versamenti
--select * from  #output_versamenti_diff


CREATE TABLE  #FIN_UPB 
(idfin int, idupb varchar(36), kind varchar(20))

INSERT INTO #FIN_UPB  (idfin,idupb,kind)    
select distinct idfin,idupb,kind  from #output_lordi  
union 
select distinct idfin,idupb,kind  from #output_versamenti  
union 
select distinct idfin,idupb,kind  from #output_versamenti_diff 


--SELECT '#PREVISIONE_PRINCIPALE_INIZIALE',* FROM #PREVISIONE_PRINCIPALE_INIZIALE
--SELECT '#PREVISIONE_SECONDARIA_INIZIALE',* FROM  #PREVISIONE_SECONDARIA_INIZIALE
--SELECT '#VAR_PREVISIONE_PRINCIPALE',* FROM  #VAR_PREVISIONE_PRINCIPALE
--SELECT '#VAR_PREVISIONE_SECONDARIA',* FROM  #VAR_PREVISIONE_SECONDARIA
--SELECT '#ASSEGNAZIONI_CREDITI',* FROM  #ASSEGNAZIONI_CREDITI
--SELECT '#ASSEGNAZIONI_INCASSI',* FROM  #ASSEGNAZIONI_INCASSI
--SELECT '#PICCOLE_SPESE',* FROM  #PICCOLE_SPESE 
--SELECT '#IMPEGNI_COMP',* FROM  #IMPEGNI_COMP 
--SELECT '#IMPEGNI_RESIDUI',* FROM  #IMPEGNI_RESIDUI 
--SELECT '#PAGAMENTI',* FROM  #PAGAMENTI 
--SELECT '#DOT_CREDITI',* FROM  #DOT_CREDITI 
--SELECT '#DOT_INCASSI',* FROM  #DOT_INCASSI 
--SELECT '#FIN_UPB',* FROM  #FIN_UPB  

--SELECT '#output_lordi',* FROM #output_lordi
--SELECT '#output_versamenti',* FROM #output_versamenti

--> COMPETENZA E CASSA   
IF (@fin_kind = 3) 
BEGIN  --Entrate
SELECT 
fin.idfin ,
upb.idupb,
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0) as 'Previsione Disponibile di competenza attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)					
	 ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
   END
  as 'Previsione Disponibile di competenza dopo elaborazione solo Lordi',

 CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)		
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
  END 
   as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti',

    CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)		
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
  END 
   as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti e V.Posticipati',

 CASE 
	WHEN @kind = 'T'  THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	
	WHEN @kind = 'L' 	THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)	 
	WHEN @kind = 'V' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(VERSAMENTI.totcompetenza,0)		
	ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti',

CASE 
	WHEN @kind = 'T'  THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)  - isnull(VERSAMENTI_DIFF.totcompetenza,0)			 
	WHEN @kind = 'L' 	THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)	 
	WHEN @kind = 'V' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)				
	ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti e V.Posticipati',



 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
		as   'Previsione Disponibile di cassa attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(LORDI.totcassa,0)	 
	 ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)
	 END
	  as 'Previsione Disponibile di cassa dopo elaborazione solo Lordi',

 CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 
		ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti',

	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 - isnull(VERSAMENTI_DIFF.totcassa,0)	 
		ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti e V.Posticipati',


	CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	 	
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0)	  
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	 		 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti',
 
	 CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	  	- isnull(VERSAMENTI_DIFF.totcassa,0) 	
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0)	  
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	- isnull(VERSAMENTI_DIFF.totcassa,0) 		 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti e V.Posticipati'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_lordi LORDI on LORDI.idfin=UWT.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb 
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb 
	
   
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)  
				- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)
	)	 < 0
OR
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(LORDI.totcassa,0) 
				- isnull(VERSAMENTI.totcassa,0) - isnull(VERSAMENTI_DIFF.totcassa,0) 
	)	 <0

) 
UNION ALL -- Spese
SELECT 
fin.idfin as '# Bilancio',
upb.idupb as '# UPB',
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
as 'Previsione Disponibile di competenza attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
			- isnull(LORDI.totcompetenza,0)				
	 ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
	 END
	  as 'Previsione Disponibile di competenza dopo elaborazione solo Lordi',

	 CASE WHEN (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)	
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)	
	 END 
	  as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti',

	  
	 CASE WHEN  (@kind = 'V' or @kind='T')
		THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	- isnull(VERSAMENTI_DIFF.totcompetenza,0)
		WHEN @kind = 'L' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)	 		
		ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)									
	 END
	   as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti e V.Posticipati',


	CASE WHEN (@kind = 'V' or @kind='T')
		THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	
		WHEN @kind = 'L' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)	 	
		ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)									
	 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti',

	 CASE WHEN (@kind = 'V' or @kind='T')
		THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)			
		WHEN @kind = 'L' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)	 	
		ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)									
	 END
	  as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti e V.Posticipati',


	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)  
		as 'Previsione Disponibile di cassa attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	  THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(LORDI.totcassa,0)	 
	  ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)
	 END
	  as 'Previsione Disponibile di cassa dopo elaborazione solo Lordi',
 
	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	  - isnull(VERSAMENTI_DIFF.totcassa,0)	
			ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti',

	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 
			ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti e V.Posticipati',

	CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0)	 	 
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	 		 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti',

	 CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	- isnull(VERSAMENTI_DIFF.totcassa,0) 	
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0)	 	 
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	 - isnull(VERSAMENTI_DIFF.totcassa,0) 			 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	  as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti e V.Posticipati'
	 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_lordi LORDI on LORDI.idfin=UWT.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)
				- isnull(VERSAMENTI.totcompetenza,0)  - isnull(VERSAMENTI_DIFF.totcompetenza,0) 
				)<0
	 
OR
	(	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(LORDI.totcassa,0) 
				- isnull(VERSAMENTI.totcassa,0)  - isnull(VERSAMENTI_DIFF.totcassa,0)  
	 )<0
)
order by fin.codefin, upb.codeupb
END

--> SOLO COMPETENZA 
IF (@fin_kind = 1) 
BEGIN
	SELECT 
fin.idfin as '# Bilancio',
upb.idupb as '# UPB',
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) as 'Previsione Disponibile di competenza attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)					
	 ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
   END
  as 'Previsione Disponibile di competenza dopo elaborazione solo Lordi',

 CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)		
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
  END 
   as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti',

    CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)	- isnull(VERSAMENTI_DIFF.totcompetenza,0)		
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
  END 
    as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti e V.diff',

 CASE WHEN @kind = 'T'  
	THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	
	WHEN @kind = 'V' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(VERSAMENTI.totcompetenza,0)	
	WHEN @kind = 'L' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(LORDI.totcompetenza,0)
	ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)				
	 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti',

CASE WHEN @kind = 'T'  
	THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)- isnull(VERSAMENTI_DIFF.totcompetenza,0)		
	WHEN @kind = 'V' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(VERSAMENTI.totcompetenza,0)	- isnull(VERSAMENTI_DIFF.totcompetenza,0)	
	WHEN @kind = 'L' THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(LORDI.totcompetenza,0)
	ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)				
	 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti e V.diff.'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1	
	left outer join #output_lordi LORDI on LORDI.idfin=UWT.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb
   
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)  
				- isnull(VERSAMENTI.totcompetenza,0)	 
				- isnull(VERSAMENTI_DIFF.totcompetenza,0)
	)	 < 0


) 
UNION ALL -- Spese
SELECT 
fin.idfin as '# Bilancio',
upb.idupb as '# UPB',
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) as 'Previsione Disponibile di competenza attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
			- isnull(LORDI.totcompetenza,0)				
	 ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
 END
	  as 'Previsione Disponibile di competenza dopo elaborazione solo Lordi',

	 CASE WHEN (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)	
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)	
	 END 
	  as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti',

	 CASE WHEN (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
		- isnull(VERSAMENTI.totcompetenza,0)	- isnull(VERSAMENTI_DIFF.totcompetenza,0)	
	 ELSE  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)	
	 END 
	  as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti e V.diff',

	CASE WHEN @kind = 'T'  
		THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	
		WHEN @kind = 'V' THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(VERSAMENTI.totcompetenza,0)  
		WHEN @kind = 'L' THEN   isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)
		ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
	 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti',

	 CASE WHEN @kind = 'T'  
		THEN isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)		- isnull(VERSAMENTI.totcompetenza,0)	 - isnull(VERSAMENTI_DIFF.totcompetenza,0)	
		WHEN @kind = 'V' THEN  isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)		 
		WHEN @kind = 'L' THEN   isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
					- isnull(LORDI.totcompetenza,0)
		ELSE isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)			
	 END
	 as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti e V.diff.'
 	 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join #output_lordi LORDI on LORDI.idfin=UWT.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(LORDI.totcompetenza,0)  
				- isnull(VERSAMENTI.totcompetenza,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0)	 	 
	)<0	 
)
order by fin.codefin, upb.codeupb
END

--> SOLO CASSA 
IF (@fin_kind = 2) 
BEGIN
	SELECT 
fin.idfin ,
upb.idupb,
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
		as   'Previsione Disponibile di cassa attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(LORDI.totcassa,0)	 
	 ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)
	 END
	  as 'Previsione Disponibile di cassa dopo elaborazione solo Lordi',

 CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 
		ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti',

	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	- isnull(VERSAMENTI_DIFF.totcassa,0)	  
		ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti e V.differiti',



	CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	 	
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0) 
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	 			 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti',
 	 
	 CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								- isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	 - isnull(VERSAMENTI_DIFF.totcassa,0)		
		WHEN @kind = 'L'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(LORDI.totcassa,0) 
		WHEN @kind = 'V'   THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
									- isnull(VERSAMENTI.totcassa,0)	- isnull(VERSAMENTI_DIFF.totcassa,0)	 	 		 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti V.differiti'

from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb	
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_lordi LORDI on LORDI.idfin=LORDI.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb
	
   
WHERE UWT.kind = 'Entrata' 
AND
(
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(LORDI.totcassa,0) 
				- isnull(VERSAMENTI.totcassa,0)  - isnull(VERSAMENTI_DIFF.totcassa,0)  
	)	 <0

) 

UNION ALL -- Spese
SELECT 
fin.idfin as '# Bilancio',
upb.idupb as '# UPB',
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)  
		as 'Previsione Disponibile di cassa attuale' ,

 CASE WHEN (@kind = 'L' or @kind = 'T')  
	  THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(LORDI.totcassa,0)	 
	 ELSE isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)
	 END
	  as 'Previsione Disponibile di cassa dopo elaborazione solo Lordi',
 
	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 
			ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti',

	CASE WHEN  (@kind = 'V' or @kind='T')
	 THEN  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			- isnull(VERSAMENTI.totcassa,0)	 - isnull(VERSAMENTI_DIFF.totcassa,0)
			ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	 END 
	as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti e V.differiti',

	CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								  - isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	 	  
		WHEN  @kind = 'V'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								  - isnull(VERSAMENTI.totcassa,0)	 	
		WHEN  @kind = 'L'  THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								 - isnull(LORDI.totcassa,0)	 							 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti',

	 CASE WHEN @kind = 'T'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								  - isnull(LORDI.totcassa,0)	- isnull(VERSAMENTI.totcassa,0)	 	- isnull(VERSAMENTI_DIFF.totcassa,0)	 	 
		WHEN  @kind = 'V'  THEN	  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								  - isnull(VERSAMENTI.totcassa,0)	 	- isnull(VERSAMENTI_DIFF.totcassa,0)	
		WHEN  @kind = 'L'  THEN	 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
								 - isnull(LORDI.totcassa,0)	 							 
		ELSE  isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 				
	 END
	 as 'Previsione Disponibile di cassa dopo elaborazione Lordi e Versamenti V.differiti'
	 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_lordi LORDI on LORDI.idfin=LORDI.idfin and LORDI.idupb=UWT.idupb
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb 
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb 
	

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(LORDI.totcassa,0) 
				- isnull(VERSAMENTI.totcassa,0) 
				- isnull(VERSAMENTI_DIFF.totcassa,0) 
	 )<0
)
order by fin.codefin, upb.codeupb
END

--drop table #PREVISIONE_PRINCIPALE_INIZIALE
--drop table #PREVISIONE_SECONDARIA_INIZIALE
--drop table #VAR_PREVISIONE_PRINCIPALE
--drop table #VAR_PREVISIONE_SECONDARIA
--drop table #ASSEGNAZIONI_CREDITI
--drop table #ASSEGNAZIONI_INCASSI
--drop table #PICCOLE_SPESE 
--drop table #IMPEGNI_COMP 
--drop table #IMPEGNI_RESIDUI 
--drop table #PAGAMENTI 
--drop table #DOT_CREDITI 
--drop table #DOT_INCASSI 
--drop table #FIN_UPB  
END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



 
 
