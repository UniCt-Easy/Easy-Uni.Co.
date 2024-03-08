
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_variationunderwritingupbfin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_variationunderwritingupbfin]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_variationunderwritingupbfin]
(
	@yvar smallint,
	@nvar int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS
BEGIN

DECLARE @finphaseincome tinyint
DECLARE @finphaseexpense tinyint
DECLARE @maxphaseincome tinyint
DECLARE @maxphaseexpense tinyint

SELECT @finphaseincome = assessmentphasecode FROM config WHERE ayear = @yvar
IF @finphaseincome IS NULL
BEGIN
	SELECT @finphaseincome = incomefinphase FROM uniconfig
END
SELECT @maxphaseincome = MAX(nphase) FROM incomephase

SELECT @finphaseexpense = appropriationphasecode FROM config WHERE ayear = @yvar
IF @finphaseexpense IS NULL
BEGIN
	SELECT @finphaseexpense = expensefinphase FROM uniconfig
END
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase


declare @approvata char(1)
if ((select idfinvarstatus from finvar where yvar = @yvar and nvar = @nvar) = '5')
begin
	set @approvata = 'S'
end	
else
begin
	set @approvata = 'N'
end

DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @yvar

CREATE TABLE #DETTAGLIO_VARIAZIONE(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	previsionvariation decimal(19,2),
	secondaryvariation decimal(19,2),
	creditvariation decimal(19,2),
	proceedsvariation decimal(19,2)
	)  

INSERT INTO #DETTAGLIO_VARIAZIONE(idunderwriting, idupb, idfin,
		previsionvariation,secondaryvariation,creditvariation,proceedsvariation)
select D.idunderwriting, D.idupb, D.idfin, 
		sum( case when V.flagprevision='S' and idfinvarstatus<>5 then amount else 0 end ),
		sum( case when V.flagsecondaryprev='S' and idfinvarstatus<>5  then amount else 0 end ),
		sum( case when V.flagcredit='S' and (F.flag&1<>0 ) and idfinvarstatus<>5 and V.variationkind <> 5 then amount else 0 end ),
		sum( case when V.flagproceeds='S' and (F.flag&1<>0 ) and idfinvarstatus<>5  and V.variationkind <> 5 then amount else 0 end )	
from finvar V
join finvardetail D
	on V.yvar = D.yvar and V.nvar= D.nvar
join upb U
	on U.idupb = D.idupb	
join fin F
	on F.idfin= D.idfin
where V.yvar = @yvar and V.nvar = @nvar
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
group by D.idunderwriting, D.idupb, D.idfin



CREATE TABLE #PICCOLE_SPESE(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

--Il SUM lo mettiamo perchè potrebbero esserci n righe in pettycashoperationunderwriting, ossia n op.imputate alla terna.
INSERT INTO #PICCOLE_SPESE(idunderwriting, idupb, idfin, amount)  
--> Con Finanziamento	
select FV.idunderwriting, FV.idupb, FV.idfin, SUM(U.amount)
	from #DETTAGLIO_VARIAZIONE FV
	join pettycashoperationunderwriting U
		on U.idunderwriting = FV.idunderwriting 
	join pettycashoperation operation
		ON U.yoperation = operation.yoperation
		AND U.noperation = operation.noperation
		AND U.idpettycash = operation.idpettycash
		AND FV.idfin=operation.idfin and FV.idupb=operation.idupb
	join upb 
		on upb.idupb = FV.idupb	
where  (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
							WHERE restoreop.yrestore = operation.yrestore
								AND restoreop.nrestore = operation.nrestore
								AND restoreop.idpettycash = operation.idpettycash)
group by FV.idunderwriting, FV.idupb, FV.idfin

--> Senza Finanziamento	
INSERT INTO #PICCOLE_SPESE(idupb, idfin, amount)  
select FV.idupb, FV.idfin, SUM(operation.amount)
	from #DETTAGLIO_VARIAZIONE FV
	join pettycashoperation operation
		ON FV.idupb = operation.idupb
		AND FV.idfin = operation.idfin
	join upb 
		on upb.idupb = FV.idupb	
where (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
							WHERE restoreop.yrestore = operation.yrestore
								AND restoreop.nrestore = operation.nrestore
								AND restoreop.idpettycash = operation.idpettycash)		
group by FV.idupb, FV.idfin
	

--> COMPETENZA E CASSA 
IF (@fin_kind = 3)
BEGIN
		select   
			CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)=1) then 'S'
			End as 'E/S',
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
			F.codefin as 'Bilancio',
			isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
		   as 'Prev.Competenza',
				isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
					- (isnull(ACC.totalcompetency,0) + isnull(IMP.totalcompetency,0) 
						+isnull(ACC_.totalcompetency,0) + isnull(IMP_.totalcompetency,0) 
						+ isnull(OPS.amount,0)
					  )
			as 'Prev.Competenza.Disponibile',
			isnull(UUT.currentsecondaryprev,0)+ISNULL(UUT.secondaryvariation, 0)+ 
				isnull(UT.currentsecondaryprev,0)+ISNULL(UT.secondaryvariation, 0)+ 
					isnull(FV.secondaryvariation,0)
				 as 'Prev.Cassa',
			isnull(UUT.currentsecondaryprev,0)+ISNULL(UUT.secondaryvariation, 0)+ 
				isnull(UT.currentsecondaryprev,0)+ISNULL(UT.secondaryvariation, 0)+ 
					isnull(FV.secondaryvariation,0)
					- (isnull(PAG.totalcompetency,0) + isnull(INC.totalcompetency,0) 
						+isnull(PAG_.totalcompetency,0) + isnull(INC_.totalcompetency,0) 
						+isnull(PAG.totalarrears,0) + isnull(INC.totalarrears,0) 
						+isnull(PAG_.totalarrears,0) + isnull(INC_.totalarrears,0) 
						+ isnull(OPS.amount,0)
					  )
			as 'Prev.Cassa.Disponibile',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then
				isnull(UUT.totcreditpart,0)+ISNULL(UUT.creditvariation, 0)+
				isnull(UT.totcreditpart,0)+ISNULL(UT.creditvariation, 0)+
				isnull(FV.creditvariation,0)
				else null
			End	
			as 'Crediti',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then		isnull(UUT.totcreditpart,0)+ISNULL(UUT.creditvariation, 0)+
							isnull(UT.totcreditpart,0)+ISNULL(UT.creditvariation, 0)+
							isnull(FV.creditvariation,0)
							 - (isnull(IMP.totalcompetency,0) +isnull(IMP_.totalcompetency,0) +isnull(OPS.amount,0) )
				else null		
			End
			as 'Crediti Disponibili',
			CASE
				when (( F.flag & 1)=1) /* S */
				then 
					isnull(UUT.totproceedspart,0)+ISNULL(UUT.proceedsvariation, 0)+
					isnull(UT.totproceedspart,0)+ISNULL(UT.proceedsvariation, 0)+
					isnull(FV.proceedsvariation,0)
				else null		
			End
			as 'Incassi',
			CASE
				when (( F.flag & 1)=1) /* S */
				then isnull(UUT.totproceedspart,0)+ISNULL(UUT.proceedsvariation, 0)+
					isnull(UT.totproceedspart,0)+ISNULL(UT.proceedsvariation, 0)+
					isnull(FV.proceedsvariation,0)
					- ( isnull(PAG.totalcompetency,0) +isnull(PAG_.totalcompetency,0)+ isnull(PAG.totalarrears,0) +isnull(PAG_.totalarrears,0)
						+ isnull(OPS.amount,0)  
						)
				else null		
			End
			as 'Incassi Disponibili'			
			from #DETTAGLIO_VARIAZIONE FV 
			join fin F
				on FV.idfin = F.idfin
			join upb U
				on FV.idupb = U.idupb
			left outer join underwriting W
				on FV.idunderwriting = W.idunderwriting
				
		   left outer join upbunderwritingtotal   UUT
   				ON UUT.idunderwriting = FV.idunderwriting and UUT.idupb = FV.idupb and UUT.idfin = FV.idfin 
		   left outer join upbtotal   UT
   				ON UT.idupb = FV.idupb and UT.idfin = FV.idfin AND FV.idunderwriting is null
		   left outer join #PICCOLE_SPESE OPS	
   				ON isnull(OPS.idunderwriting,0)  = isnull(FV.idunderwriting,0) and OPS.idupb = FV.idupb and OPS.idfin = FV.idfin 

		   left outer join underwritingexpensetotal IMP
   				ON IMP.idunderwriting = FV.idunderwriting and IMP.idupb = FV.idupb and IMP.idfin = FV.idfin  and IMP.nphase = @finphaseexpense	
		   left outer join underwritingexpensetotal PAG
   				ON PAG.idunderwriting = FV.idunderwriting and PAG.idupb = FV.idupb and PAG.idfin = FV.idfin  and PAG.nphase = @maxphaseexpense	

		   left outer join upbexpensetotal IMP_
   				ON IMP_.idupb = FV.idupb and IMP_.idfin = FV.idfin  and IMP_.nphase = @finphaseexpense	AND FV.idunderwriting is null
		   left outer join upbexpensetotal PAG_
   				ON PAG_.idupb = FV.idupb and PAG_.idfin = FV.idfin  and PAG_.nphase = @maxphaseexpense	AND FV.idunderwriting is null

		   left outer join underwritingincometotal  ACC
   				ON ACC.idunderwriting = FV.idunderwriting and ACC.idupb = FV.idupb and ACC.idfin = FV.idfin  and IMP.nphase = @finphaseincome	
		   left outer join underwritingincometotal  INC 
   				ON FV.idunderwriting is null and INC.idupb = FV.idupb and INC.idfin = FV.idfin  and INC.nphase = @maxphaseincome	
		   
		   left outer join upbincometotal  ACC_
   				ON ACC_.idupb = FV.idupb and ACC_.idfin = FV.idfin  and ACC_.nphase = @finphaseincome	AND FV.idunderwriting is null
		   left outer join upbincometotal  INC_ 
   				ON INC_.idupb = FV.idupb and INC_.idfin = FV.idfin  and INC_.nphase = @maxphaseincome	AND FV.idunderwriting is null
		  
		  order by  W.title,U.codeupb,F.codefin
END   



--> SOLO COMPETENZA 
IF (@fin_kind = 1) 
BEGIN
		select   
			CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)=1) then 'S'
			End as 'E/S',
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
			F.codefin as 'Bilancio',
			isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
		   as 'Prev.Competenza',
				isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
					- (isnull(ACC.totalcompetency,0) + isnull(IMP.totalcompetency,0) 
						+isnull(ACC_.totalcompetency,0) + isnull(IMP_.totalcompetency,0) 
						+ isnull(OPS.amount,0)
					  )
			as 'Prev.Competenza.Disponibile',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then
				isnull(UUT.totcreditpart,0)+ISNULL(UUT.creditvariation, 0)+
				isnull(UT.totcreditpart,0)+ISNULL(UT.creditvariation, 0)+
				isnull(FV.creditvariation,0)
				else null
			End	
			as 'Crediti',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then		isnull(UUT.totcreditpart,0)+ISNULL(UUT.creditvariation, 0)+
							isnull(UT.totcreditpart,0)+ISNULL(UT.creditvariation, 0)+
							isnull(FV.creditvariation,0)
							 - (isnull(IMP.totalcompetency,0) +isnull(IMP_.totalcompetency,0) +isnull(OPS.amount,0) )
				else null		
			End
			as 'Crediti Disponibili'			
			from #DETTAGLIO_VARIAZIONE FV 
			join fin F
				on FV.idfin = F.idfin
			join upb U
				on FV.idupb = U.idupb
			left outer join underwriting W
				on FV.idunderwriting = W.idunderwriting
				
		   left outer join upbunderwritingtotal   UUT
   				ON UUT.idunderwriting = FV.idunderwriting and UUT.idupb = FV.idupb and UUT.idfin = FV.idfin 
		   left outer join upbtotal   UT
   				ON UT.idupb = FV.idupb and UT.idfin = FV.idfin AND FV.idunderwriting is null
		   left outer join #PICCOLE_SPESE OPS	
   				ON isnull(OPS.idunderwriting,0)  = isnull(FV.idunderwriting,0) and OPS.idupb = FV.idupb and OPS.idfin = FV.idfin 

		   left outer join underwritingexpensetotal IMP
   				ON IMP.idunderwriting = FV.idunderwriting and IMP.idupb = FV.idupb and IMP.idfin = FV.idfin  and IMP.nphase = @finphaseexpense	
--		   left outer join underwritingexpensetotal PAG
--   				ON PAG.idunderwriting = FV.idunderwriting and PAG.idupb = FV.idupb and PAG.idfin = FV.idfin  and PAG.nphase = @maxphaseexpense	

		   left outer join upbexpensetotal IMP_
   				ON IMP_.idupb = FV.idupb and IMP_.idfin = FV.idfin  and IMP_.nphase = @finphaseexpense	AND FV.idunderwriting is null
--		   left outer join upbexpensetotal PAG_
--   				ON PAG_.idupb = FV.idupb and PAG_.idfin = FV.idfin  and PAG_.nphase = @maxphaseexpense	AND FV.idunderwriting is null

		   left outer join underwritingincometotal  ACC
   				ON ACC.idunderwriting = FV.idunderwriting and ACC.idupb = FV.idupb and ACC.idfin = FV.idfin  and IMP.nphase = @finphaseincome	
--		   left outer join underwritingincometotal  INC 
--   				ON FV.idunderwriting is null and INC.idupb = FV.idupb and INC.idfin = FV.idfin  and INC.nphase = @maxphaseincome	
		   
		   left outer join upbincometotal  ACC_
   				ON ACC_.idupb = FV.idupb and ACC_.idfin = FV.idfin  and ACC_.nphase = @finphaseincome	AND FV.idunderwriting is null
--		   left outer join upbincometotal  INC_ 
--  				ON INC_.idupb = FV.idupb and INC_.idfin = FV.idfin  and INC_.nphase = @maxphaseincome	AND FV.idunderwriting is null
		  
		  order by  W.title,U.codeupb,F.codefin


END   


--> SOLO CASSA 
IF (@fin_kind = 2) 
BEGIN
		select   
			CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)=1) then 'S'
			End as 'E/S',
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
			F.codefin as 'Bilancio',
			isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
		   as 'Prev.Cassa',
				isnull(UUT.currentprev,0)+ISNULL(UUT.previsionvariation, 0)+ 
				isnull(UT.currentprev,0)+ISNULL(UT.previsionvariation, 0)+ 
					isnull(FV.previsionvariation,0)
					- (isnull(ACC.totalcompetency,0) + isnull(IMP.totalcompetency,0) 
					    + isnull(ACC.totalarrears,0) + isnull(IMP.totalarrears,0) 
						+ isnull(ACC_.totalcompetency,0) + isnull(IMP_.totalcompetency,0) 
						+ isnull(ACC_.totalarrears,0) + isnull(IMP_.totalarrears,0) 
						+ isnull(OPS.amount,0)
					  )
			as 'Prev.Cassa.Disponibile',
			CASE
				when (( F.flag & 1)=1) /* S */
				then 
					isnull(UUT.totproceedspart,0)+ISNULL(UUT.proceedsvariation, 0)+
					isnull(UT.totproceedspart,0)+ISNULL(UT.proceedsvariation, 0)+
					isnull(FV.proceedsvariation,0)
				else null		
			End
			as 'Incassi',
			CASE
				when (( F.flag & 1)=1) /* S */
				then isnull(UUT.totproceedspart,0)+ISNULL(UUT.proceedsvariation, 0)+
					isnull(UT.totproceedspart,0)+ISNULL(UT.proceedsvariation, 0)+
					isnull(FV.proceedsvariation,0)
					- ( isnull(PAG.totalcompetency,0) +isnull(PAG_.totalcompetency,0)+ isnull(PAG.totalarrears,0) +isnull(PAG_.totalarrears,0)
						+ isnull(OPS.amount,0)  
						)
				else null		
			End
			as 'Incassi Disponibili'			
			from #DETTAGLIO_VARIAZIONE FV 
			join fin F
				on FV.idfin = F.idfin
			join upb U
				on FV.idupb = U.idupb
			left outer join underwriting W
				on FV.idunderwriting = W.idunderwriting
				
		   left outer join upbunderwritingtotal   UUT
   				ON UUT.idunderwriting = FV.idunderwriting and UUT.idupb = FV.idupb and UUT.idfin = FV.idfin 
		   left outer join upbtotal   UT
   				ON UT.idupb = FV.idupb and UT.idfin = FV.idfin AND FV.idunderwriting is null
		   left outer join #PICCOLE_SPESE OPS	
   				ON isnull(OPS.idunderwriting,0)  = isnull(FV.idunderwriting,0) and OPS.idupb = FV.idupb and OPS.idfin = FV.idfin 

		   left outer join underwritingexpensetotal IMP
   				ON IMP.idunderwriting = FV.idunderwriting and IMP.idupb = FV.idupb and IMP.idfin = FV.idfin  and IMP.nphase = @finphaseexpense	
		   left outer join underwritingexpensetotal PAG
   				ON PAG.idunderwriting = FV.idunderwriting and PAG.idupb = FV.idupb and PAG.idfin = FV.idfin  and PAG.nphase = @maxphaseexpense	

		   left outer join upbexpensetotal IMP_
   				ON IMP_.idupb = FV.idupb and IMP_.idfin = FV.idfin  and IMP_.nphase = @finphaseexpense	AND FV.idunderwriting is null
		   left outer join upbexpensetotal PAG_
   				ON PAG_.idupb = FV.idupb and PAG_.idfin = FV.idfin  and PAG_.nphase = @maxphaseexpense	AND FV.idunderwriting is null

		   left outer join underwritingincometotal  ACC
   				ON ACC.idunderwriting = FV.idunderwriting and ACC.idupb = FV.idupb and ACC.idfin = FV.idfin  and IMP.nphase = @finphaseincome	
		   left outer join underwritingincometotal  INC 
   				ON FV.idunderwriting is null and INC.idupb = FV.idupb and INC.idfin = FV.idfin  and INC.nphase = @maxphaseincome	
		   
		   left outer join upbincometotal  ACC_
   				ON ACC_.idupb = FV.idupb and ACC_.idfin = FV.idfin  and ACC_.nphase = @finphaseincome	AND FV.idunderwriting is null
		   left outer join upbincometotal  INC_ 
   				ON INC_.idupb = FV.idupb and INC_.idfin = FV.idfin  and INC_.nphase = @maxphaseincome	AND FV.idunderwriting is null
		  
		  order by  W.title,U.codeupb,F.codefin


END   


drop table #DETTAGLIO_VARIAZIONE
drop table #PICCOLE_SPESE 

END

GO








SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



