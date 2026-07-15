/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_fin_upb_available_posticipati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_fin_upb_available_posticipati]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO
 

 --setuser 'amm'
 --setuser 'amministrazione'
-- exec [exp_csa_fin_upb_available_posticipati] 2020, 2606
--select * from csa_import where yimport=2020 and nimport=24		--2606
CREATE PROCEDURE  [exp_csa_fin_upb_available_posticipati]
	(
		@ayear int,
		@idcsa_import int,
		@lista_idcsa_import dbo.int_list  READONLY, -- @idcsa_import int,
		@lista_idreg_agency dbo.int_list  READONLY   --@idcsa_agency int
	 
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

DECLARE @lista_idcsa_import_posticipati dbo.int_list  
DECLARE	@lista_idreg_agency_posticipati dbo.int_list  


create table #output_versamenti_diff
(
		kind varchar(20), movkind int , parentidinc int , parentidexp int ,idfin int, idupb varchar(36),	
			totcompetenza decimal(19,2), totcassa decimal(19,2)
		---amount decimal(19,2)
) 



 
if (select count(*) from  @lista_idcsa_import ) = 0
begin 
	insert into @lista_idcsa_import_posticipati (n) values (@idcsa_import)
	insert into @lista_idreg_agency_posticipati (n) select distinct idreg from csa_agency where flag & 1 <> 0
end
else
begin 
		insert into  @lista_idcsa_import_posticipati(n)    select * from  @lista_idcsa_import 
		insert into  @lista_idreg_agency_posticipati (n)  select * from  @lista_idreg_agency 
end

insert into #output_versamenti_diff (kind,idfin,idupb,totcompetenza,totcassa)		
select VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb,		sum( amount), sum(amount)
	from f_compute_csa_versamenti_partition (@ayear, null,@lista_idcsa_import_posticipati,@lista_idreg_agency_posticipati) VERSAMENTI
	where VERSAMENTI.parentidexp is null and VERSAMENTI.idcsa_agency in (select idcsa_agency from csa_agency where flag & 1 <> 0) --- solo posticipati
	group by VERSAMENTI.kind,VERSAMENTI.idfin,VERSAMENTI.idupb
 


CREATE TABLE  #FIN_UPB 
(idfin int, idupb varchar(36), kind varchar(20))

INSERT INTO #FIN_UPB  (idfin,idupb,kind)    
 
select distinct idfin,idupb,kind  from #output_versamenti_diff 

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
	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
						- isnull(VERSAMENTI_DIFF.totcompetenza,0)				
 	 as 'Previsione Disponibile di competenza dopo elaborazione V.Posticipati'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb 
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(VERSAMENTI_DIFF.totcompetenza,0)
	)	 < 0
OR
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				  - isnull(VERSAMENTI_DIFF.totcassa,0) 
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)   as 'Previsione Disponibile di competenza attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)  -  isnull(VERSAMENTI_DIFF.totcompetenza,0)  as 'Previsione Disponibile di competenza dopo elaborazione Lordi e Versamenti e V.Posticipati'

from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(VERSAMENTI_DIFF.totcompetenza,0) 
				)<0
	 
OR
	(	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
	   - isnull(VERSAMENTI_DIFF.totcassa,0)  
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) - isnull(VERSAMENTI_DIFF.totcompetenza,0) as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti diff.'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1	
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb
   
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)	 - isnull(VERSAMENTI_DIFF.totcompetenza,0)	 as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti .diff'
 
 	 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)  - isnull(VERSAMENTI_DIFF.totcompetenza,0)	 	 
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
 isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
		as   'Previsione Disponibile di cassa attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
		 	- isnull(VERSAMENTI_DIFF.totcassa,0)
		as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti e V.differiti' 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb	
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb
	
   
WHERE UWT.kind = 'Entrata' 
AND
(
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
		 - isnull(VERSAMENTI_DIFF.totcassa,0)  
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)    as 'Previsione Disponibile di cassa attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
			  - isnull(VERSAMENTI_DIFF.totcassa,0)   as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti differiti'  
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_versamenti_diff VERSAMENTI_DIFF on VERSAMENTI_DIFF.idfin=UWT.idfin and VERSAMENTI_DIFF.idupb=UWT.idupb 
	

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(VERSAMENTI_DIFF.totcassa,0) 
	 )<0
)
order by fin.codefin, upb.codeupb
END


END

GO


