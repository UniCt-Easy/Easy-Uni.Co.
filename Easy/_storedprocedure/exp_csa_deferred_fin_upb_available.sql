
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_deferred_fin_upb_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_available]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_deferred_fin_upb_available]

GO
 
SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO
 

 --setuser 'amm'
 --setuser 'amministrazione'
-- exec [exp_csa_deferred_fin_upb_available] 2020

CREATE PROCEDURE  [exp_csa_deferred_fin_upb_available]
	(
		@ayear int 
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
 
create table #output_versamenti
(
		kind varchar(20), movkind int , parentidinc int , parentidexp int ,idfin int, idupb varchar(36),	
			totcompetenza decimal(19,2), totcassa decimal(19,2)
		---amount decimal(19,2)
) 

--- riempimento dati pagamenti posticipati
 
insert into #output_versamenti (kind,idfin,idupb,totcompetenza,totcassa)		
select VERSAMENTI.kind,FINNEW.newidfin /*riattualizzo la voce di bilancio*/,VERSAMENTI.idupb, 0 /*vengono rigenerate in c/competenza solo le ultime fasi, ecco perchè 0*/, -sum(amount)
from [csa_importver_varresidualview] VERSAMENTI 
JOIN finlookup FINNEW ON FINNEW.oldidfin = VERSAMENTI.idfin
WHERE ayear = @ayear
group by VERSAMENTI.kind,FINNEW.newidfin,VERSAMENTI.idupb
 
 
CREATE TABLE  #FIN_UPB 
(idfin int, idupb varchar(36), kind varchar(20))

INSERT INTO #FIN_UPB  (idfin,idupb,kind)    
select distinct idfin,idupb,kind  from #output_versamenti  

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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)											as 'Previsione Disponibile di competenza attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)- isnull(VERSAMENTI.totcompetenza,0)		as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti',
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)    as   'Previsione Disponibile di cassa attuale' ,
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) - isnull(VERSAMENTI.totcassa,0)	 as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(VERSAMENTI.totcompetenza,0)
	)	 < 0
OR
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(VERSAMENTI.totcassa,0)  
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)											as 'Previsione Disponibile di competenza attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0) - isnull(VERSAMENTI.totcompetenza,0)	as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti', 
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)	as 'Previsione Disponibile di cassa attuale' ,
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) - isnull(VERSAMENTI.totcassa,0)	 as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITc.totalcompetency,0)
				- isnull(VERSAMENTI.totcompetenza,0) 
				)<0
	 
OR
	(	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(VERSAMENTI.totcassa,0)  
	 )<0
)
order by fin.codefin, upb.codeupb
END

--> SOLO COMPETENZA 
IF (@fin_kind = 1) 
BEGIN
	SELECT 
fin.idfin ,
upb.idupb,
UWT.kind  as 'Parte Bilancio',
fin.codefin as 'Cod. Bilancio',
fin.title as 'Bilancio',
upb.codeupb as 'Cod. UPB',
upb.title as 'UPB',
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) as 'Previsione Disponibile di competenza attuale' ,
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) - isnull(VERSAMENTI.totcompetenza,0) as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbincometotal UITC on UITC.idfin=UWT.idfin and UITC.idupb=UWT.idupb  and uitc.nphase = 1	
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
WHERE UWT.kind = 'Entrata' 
AND
(
	(
	--- PREVISIONE DISPONIBILE DI COMPETENZA NEGATIVA
		isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(VERSAMENTI.totcompetenza,0)	 
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
isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0) - isnull(VERSAMENTI.totcompetenza,0)as 'Previsione Disponibile di competenza dopo elaborazione  Versamenti'
	 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITc on UITc.idfin=UWT.idfin and UITc.idupb=UWT.idupb and UITC.nphase=1
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentprev,0) + isnull(UT.previsionvariation,0) - isnull(UITC.totalcompetency,0)
				- isnull(VERSAMENTI.totcompetenza,0)	 
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
 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)  as   'Previsione Disponibile di cassa attuale' ,
 isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)  - isnull(VERSAMENTI.totcassa,0)	 as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti' 
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb	
	left outer join upbincometotal UITS on UITS.idfin=UWT.idfin and UITS.idupb=UWT.idupb and uits.nphase = @maxphaseincome
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	WHERE UWT.kind = 'Entrata' 
AND
(
	--- PREVISIONE DISPONIBILE DI CASSA NEGATIVA
	(
		isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) 
				- isnull(VERSAMENTI.totcassa,0)  
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
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0)   as 'Previsione Disponibile di cassa attuale' ,
isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) - isnull(VERSAMENTI.totcassa,0)as 'Previsione Disponibile di cassa dopo elaborazione  Versamenti'
from #FIN_UPB   UWT
	join fin on UWT.idfin = fin.idfin 
	join upb on UWT.idupb = upb.idupb
	left outer join upbtotal UT on UT.idfin=UWT.idfin and UT.idupb=UWT.idupb
	left outer join upbexpensetotal UITS on UITs.idfin=UWT.idfin and UITs.idupb=UWT.idupb and UITS.nphase = @maxphaseexpense
	left outer join #output_versamenti VERSAMENTI on VERSAMENTI.idfin=UWT.idfin and VERSAMENTI.idupb=UWT.idupb
	

WHERE UWT.kind = 'Spesa'
AND
(
	(	isnull(UT.currentsecondaryprev,0) + isnull(UT.secondaryvariation,0) - isnull(UITS.totalcompetency,0)-isnull(UITS.totalarrears,0) - isnull(VERSAMENTI.totcassa,0) 
	 )<0
)
order by fin.codefin, upb.codeupb
END
 
END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



 
 
