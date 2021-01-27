
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_situazioneattualefinupbbilancio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_situazioneattualefinupbbilancio]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- exp_situazioneattualefinupbbilancio 2015
CREATE    PROCEDURE [exp_situazioneattualefinupbbilancio]
(
	@ayear smallint,
	@idunderwriting int = null,
	@idupb varchar(36) = null,
	@idfin int = null,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS
BEGIN

DECLARE @levelusable tinyint -- Livello operativo per le voci di bilancio
SELECT @levelusable = MIN(nlevel) FROM finlevel WHERE (flag & 2)<>0 AND ayear = @ayear

DECLARE	@nlevel tinyint -- Livello della voce di bilancio
SELECT @nlevel = nlevel FROM fin WHERE idfin = @idfin

DECLARE @finphaseincome tinyint
DECLARE @finphaseexpense tinyint
DECLARE @maxphaseincome tinyint
DECLARE @maxphaseexpense tinyint

SELECT @finphaseincome = assessmentphasecode FROM config WHERE ayear = @ayear
IF @finphaseincome IS NULL
BEGIN
	SELECT @finphaseincome = incomefinphase FROM uniconfig
END
SELECT @maxphaseincome = MAX(nphase) FROM incomephase

SELECT @finphaseexpense = appropriationphasecode FROM config WHERE ayear = @ayear
IF @finphaseexpense IS NULL
BEGIN
	SELECT @finphaseexpense = expensefinphase FROM uniconfig
END
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase


declare @idsorkind01 int
declare @idsorkind02 int
declare @idsorkind03 int
declare @idsorkind04 int
declare @idsorkind05 int

declare @sortingkind01 varchar(50)
declare @sortingkind02 varchar(50)
declare @sortingkind03 varchar(50)
declare @sortingkind04 varchar(50)
declare @sortingkind05 varchar(50)

declare @codesorkind01 varchar(50)
declare @codesorkind02 varchar(50)
declare @codesorkind03 varchar(50)
declare @codesorkind04 varchar(50)
declare @codesorkind05 varchar(50)

select @idsorkind01  = idsorkind01 from uniconfig
select @idsorkind02  = idsorkind02 from uniconfig
select @idsorkind03  = idsorkind03 from uniconfig
select @idsorkind04  = idsorkind04 from uniconfig
select @idsorkind05  = idsorkind05 from uniconfig

select @sortingkind01  = description  from sortingkind where idsorkind = @idsorkind01
select @sortingkind02  = description  from sortingkind where idsorkind = @idsorkind02
select @sortingkind03  = description  from sortingkind where idsorkind = @idsorkind03
select @sortingkind04  = description  from sortingkind where idsorkind = @idsorkind04
select @sortingkind05  = description  from sortingkind where idsorkind = @idsorkind05

select @codesorkind01  = codesorkind  from sortingkind where idsorkind = @idsorkind01
select @codesorkind02  = codesorkind  from sortingkind where idsorkind = @idsorkind02
select @codesorkind03  = codesorkind  from sortingkind where idsorkind = @idsorkind03
select @codesorkind04  = codesorkind  from sortingkind where idsorkind = @idsorkind04
select @codesorkind05  = codesorkind  from sortingkind where idsorkind = @idsorkind05


--DECLARE
-- @sql AS Nvarchar(4000), -- Stringa contenente la query da eseguire
-- --@supporto_sql AS varchar(8000), -- Stringa di supporto se la prima stringa è corta
-- @NEWLINE AS char(1) -- Ritorno a capo (usato solo per leggibilità)
--SET @NEWLINE = CHAR(10)
--IF (@sortingkind01) IS NOT NULL
--BEGIN 
--	SET @sql = 'CREATE TABLE #ATTRIBUTI(' + ''+ @codesorkind01 + '' +  ' varchar(100))'
--	SET @sql = @sql + @NEWLINE
--END 
--ELSE
--BEGIN
--	SET @sql = @sql + 'ALTER TABLE #ATTRIBUTI ADD ATTR01 varchar(100)'
--	SET @sql = @sql + @NEWLINE
--END
--IF (@sortingkind02 IS NOT NULL)
--BEGIN 
--	SET @sql = 'CREATE TABLE #ATTRIBUTI(' + ''+ @codesorkind02 + '' +  ' varchar(100))'
--	SET @sql = @sql + @NEWLINE
--END 
--ELSE
--BEGIN
--	SET @sql = @sql + 'ALTER TABLE #ATTRIBUTI ADD ATTR02 varchar(100)'
--	SET @sql = @sql + @NEWLINE
--END

--IF (@sortingkind03 IS NOT NULL)
--BEGIN 
--	SET @sql = 'CREATE TABLE #ATTRIBUTI(' + ''+ @codesorkind03 + '' +  ' varchar(100))'
--	SET @sql = @sql + @NEWLINE
--END 
--ELSE
--BEGIN
--	SET @sql = @sql + 'ALTER TABLE #ATTRIBUTI ADD ATTR03 varchar(100)'
--	SET @sql = @sql + @NEWLINE
--END

--IF (@sortingkind04 IS NOT NULL)
--BEGIN 
--	SET @sql = 'CREATE TABLE #ATTRIBUTI(' + ''+ @codesorkind04 + '' +  ' varchar(100))'
--	SET @sql = @sql + @NEWLINE
--END 
--ELSE
--BEGIN
--	SET @sql = @sql + 'ALTER TABLE #ATTRIBUTI ADD ATTR04 varchar(100)'
--	SET @sql = @sql + @NEWLINE
--END
--IF (@sortingkind05 IS NOT NULL)
--BEGIN 
--	SET @sql = 'CREATE TABLE #ATTRIBUTI(' + ''+ @codesorkind05 + '' +  ' varchar(100))'
--	SET @sql = @sql + @NEWLINE
--END 
--ELSE
--BEGIN
--	SET @sql = @sql + 'ALTER TABLE #ATTRIBUTI ADD ATTR05 varchar(100)'
--	SET @sql = @sql + @NEWLINE
--END

--PRINT @sql
--EXECUTE sp_executesql @sql

DECLARE @fin_kind tinyint
SELECT @fin_kind = fin_kind FROM config WHERE ayear = @ayear


CREATE TABLE #PREVISIONE_PRINCIPALE_INIZIALE(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

INSERT INTO #PREVISIONE_PRINCIPALE_INIZIALE(idunderwriting, idupb, idfin, amount)  
select U.idunderwriting, U.idupb, U.idfin, isnull(U.currentprev,0)
	from upbunderwritingtotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
	and (U.idupb= @idupb or @idupb is null)
	and (U.idfin = @idfin or @idfin is null)
	and fin.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)



CREATE TABLE #PREVISIONE_PRINCIPALE_ATTUALE(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

INSERT INTO #PREVISIONE_PRINCIPALE_ATTUALE(idunderwriting, idupb, idfin, amount)  
select U.idunderwriting, U.idupb, U.idfin, isnull(U.currentprev,0)+ISNULL(U.previsionvariation, 0)
	from upbunderwritingtotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
	and (U.idupb= @idupb or @idupb is null)
	and (U.idfin = @idfin or @idfin is null)
	and fin.ayear = @ayear
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)



CREATE TABLE #PICCOLE_SPESE(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

--Il SUM lo mettiamo perchè potrebbero esserci n righe in pettycashoperationunderwriting, ossia n op.imputate alla terna.
INSERT INTO #PICCOLE_SPESE(idunderwriting, idupb, idfin, amount)  
	
select U.idunderwriting, operation.idupb, operation.idfin, SUM(U.amount)
	from pettycashoperationunderwriting U
	join pettycashoperation operation
		ON U.yoperation = operation.yoperation
		AND U.noperation = operation.noperation
		AND U.idpettycash = operation.idpettycash
	join upb 
		on upb.idupb = operation.idupb	
	join fin
		on fin.idfin = operation.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (operation.idupb= @idupb or @idupb is null)
		and (operation.idfin = @idfin or @idfin is null)
		and fin.ayear = @ayear
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
		AND NOT	EXISTS (SELECT * FROM pettycashoperation restoreop
							WHERE restoreop.yrestore = operation.yrestore
								AND restoreop.nrestore = operation.nrestore
								AND restoreop.idpettycash = operation.idpettycash)
group by U.idunderwriting, operation.idupb, operation.idfin
	
CREATE TABLE #IMPEGNI_COMP(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

INSERT INTO #IMPEGNI_COMP(idunderwriting, idupb, idfin, amount) 
select U.idunderwriting, U.idupb, U.idfin, U.totalcompetency
FROM underwritingexpensetotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)
		and fin.ayear = @ayear
		and U.nphase = @finphaseexpense	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


		
CREATE TABLE #IMPEGNI_RESIDUI(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

--> Con Finanziamento	
INSERT INTO #IMPEGNI_RESIDUI(idunderwriting, idupb, idfin, amount) 
select U.idunderwriting, U.idupb, U.idfin, U.totalarrears
FROM underwritingexpensetotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)
		and U.nphase = @finphaseexpense	
		and fin.ayear = @ayear
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

		
CREATE TABLE #ACCERTAMENTI_COMP(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  
	
--> Con Finanziamento		
INSERT INTO #ACCERTAMENTI_COMP(idunderwriting, idupb, idfin, amount) 
select U.idunderwriting, U.idupb, U.idfin, U.totalcompetency
	from underwritingincometotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)
		and fin.ayear = @ayear
		and U.nphase = @finphaseincome
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


		
CREATE TABLE #ACCERTAMENTI_RESIDUI(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  
	
--> Con Finanziamento		
INSERT INTO #ACCERTAMENTI_RESIDUI(idunderwriting, idupb, idfin, amount) 
select U.idunderwriting, U.idupb, U.idfin, U.totalarrears
from underwritingincometotal U
	join upb 
		on upb.idupb = U.idupb		
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)
		and fin.ayear = @ayear
		and U.nphase = @finphaseincome
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)



		
CREATE TABLE #DOT_CREDITI(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	) 
	
--> Con Finanziamento		
INSERT INTO #DOT_CREDITI(idunderwriting, idupb, idfin, amount) 
select U.idunderwriting, U.idupb, U.idfin, isnull(U.totcreditpart,0)+ISNULL(U.creditvariation, 0)
	from upbunderwritingtotal U
	join upb 
		on upb.idupb = U.idupb			
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)	
		and fin.ayear = @ayear	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

CREATE TABLE #DOT_INCASSI(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	) 

--> Con Finanziamento	
INSERT INTO	#DOT_INCASSI(idunderwriting, idupb, idfin, amount)  
select U.idunderwriting, U.idupb, U.idfin, isnull(U.totproceedspart,0)+ISNULL(U.proceedsvariation, 0)
from upbunderwritingtotal U
join upb 
	on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)	
		and fin.ayear = @ayear	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)

CREATE TABLE #PAGAMENTI(
	idunderwriting int, 
	idupb varchar(36),	
	idfin int, 
	amount decimal(19,2)
	)  

--> Con Finanziamento	
INSERT INTO #PAGAMENTI(idunderwriting, idupb, idfin, amount)  
select U.idunderwriting, U.idupb, U.idfin, (isnull(U.totalcompetency,0)+isnull(totalarrears,0)) 
	from underwritingexpensetotal U
	join upb 
		on upb.idupb = U.idupb	
	join fin
		on U.idfin = fin.idfin	
where (U.idunderwriting = @idunderwriting or @idunderwriting is null)
		and (U.idupb= @idupb or @idupb is null)
		and (U.idfin = @idfin or @idfin is null)	
		and fin.ayear = @ayear	
		and U.nphase = @maxphaseexpense	
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)


--> COMPETENZA E CASSA 
IF (@fin_kind = 3) 
BEGIN
	;with UWT(idfin,idupb,idunderwriting) 
	 as 
	(select myUWT.idfin,myUWT.idupb,myUWT.idunderwriting 
			from 	upbunderwritingtotal myUWT 
				join fin F		on myUWT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on myUWT.idupb = U.idupb
		  where (myUWT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (myUWT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
	union all
		select UET.idfin,UET.idupb,UET.idunderwriting 
			from 	underwritingexpensetotal UET 
				join fin F		on UET.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UET.idupb = U.idupb
				left outer join upbunderwritingtotal UT on UT.idfin= UET.idfin and UT.idupb=UET.idupb and UT.idunderwriting=UET.idunderwriting
		  where (UET.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UET.idupb= @idupb or @idupb is null)
				--and (UET.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null
				and UET.nphase = @finphaseexpense
	union all
		select UIT.idfin,UIT.idupb,UIT.idunderwriting 
			from 	underwritingincometotal UIT 
				join fin F		on UIT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UIT.idupb = U.idupb
				left outer join upbunderwritingtotal UT on UT.idfin= UIT.idfin and UT.idupb=UIT.idupb and UT.idunderwriting=UIT.idunderwriting
		  where (UIT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UIT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null	
				and UIT.nphase = @finphaseincome	
)	
		select  
			S01.sortcode as 'Cod. Attrib. 1',
			S01.description  as 'Attrib. 1',
			S02.sortcode as 'Cod. Attrib. 2',
			S02.description  as 'Attrib. 2',
			S03.sortcode as 'Cod. Attrib. 3',
			S03.description as 'Attrib. 3',
			S04.sortcode as 'Cod. Attrib. 4',
			S04.description as 'Attrib. 4',
			S05.sortcode as 'Cod. Attrib. 5',
			S05.description as 'Attrib. 5',
			CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)=1) then 'S'
			End as 'E/S',
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
			M.title as 'Responsabile',
			CASE U.flagkind 
				WHEN 0 THEN 'Didattica' 
				WHEN 1 THEN 'Ricerca' 
			END as 'Funzione' , --- Funzione dell’upb (didattica/ricerca)	
			CASE U.flagactivity 
				WHEN 4 THEN 'Qualsiasi/Non Spec.' 
				WHEN 1 THEN 'Istituzionale' 
				WHEN 2 THEN 'Commerciale' 
			END as 'Attività' ,		--- Attività dell’upb (istituz/commerciale/qualsiasi)
			F.codefin as 'Bilancio',
			isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
			isnull(PPA.amount,0) as 'Prev.Competenza attuale',
			CASE
				when (( F.flag & 1)=0)  /* E */
					then isnull(PPA.amount,0)- (isnull(AccComp.amount,0) + isnull(AccRes.amount,0))
				when (( F.flag & 1)=1) /* S */
					then isnull(PPA.amount,0)- (isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0)) -isnull(OPS.amount,0) 
			End 
			as 'Prev.Competenza.Disponibile',
			CASE 
				when (( F.flag & 1)<>0) /* S */
				then
				isnull(Cred.amount,0) 
				else null
			End	
			as 'Crediti',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then isnull(Cred.amount,0) - isnull(ImpComp.amount,0) -isnull(OPS.amount,0) 
				else null		
			End
			as 'Crediti Disponibili',
			CASE
				when (( F.flag & 1)=0) /*E*/then (isnull(AccComp.amount,0) + isnull(AccRes.amount,0))
			End as 'Accertato',
			CASE
				when (( F.flag & 1)<>0) /*S*/then (isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0)) +isnull(OPS.amount,0) 
			End as 'Impegnato'
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			join upb U
				on UWT.idupb = U.idupb
				left outer join manager M
				on M.idman = U.idman
				left outer join sorting as S01
					on S01.idsor = U.idsor01
				left outer join sorting as S02
					on S02.idsor = U.idsor02
				left outer join sorting as S03
					on S03.idsor = U.idsor03
				left outer join sorting as S04
					on S04.idsor = U.idsor04
				left outer join sorting as S05
					on S05.idsor = U.idsor05
			join underwriting W
				on UWT.idunderwriting = W.idunderwriting
		   left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON PPI.idunderwriting = UWT.idunderwriting and PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
		   left outer join #PREVISIONE_PRINCIPALE_ATTUALE PPA
   				ON PPA.idunderwriting = UWT.idunderwriting and PPA.idupb = UWT.idupb and PPA.idfin = UWT.idfin 
		   left outer join #PICCOLE_SPESE OPS	
   				ON OPS.idunderwriting  = UWT.idunderwriting and OPS.idupb = UWT.idupb and OPS.idfin = UWT.idfin 
		   left outer join #IMPEGNI_COMP ImpComp
   				ON ImpComp.idunderwriting  = UWT.idunderwriting and ImpComp.idupb = UWT.idupb and ImpComp.idfin = UWT.idfin 
		   left outer join #IMPEGNI_RESIDUI ImpRes
   				ON ImpRes.idunderwriting  = UWT.idunderwriting and ImpRes.idupb = UWT.idupb and ImpRes.idfin = UWT.idfin 
		   left outer join #ACCERTAMENTI_COMP AccComp
   				ON AccComp.idunderwriting  = UWT.idunderwriting and AccComp.idupb = UWT.idupb and AccComp.idfin = UWT.idfin 
		   left outer join #ACCERTAMENTI_RESIDUI AccRes
   				ON AccRes.idunderwriting = UWT.idunderwriting and AccRes.idupb = UWT.idupb and AccRes.idfin = UWT.idfin
		   left outer join #DOT_CREDITI Cred
   				ON Cred.idunderwriting  = UWT.idunderwriting and Cred.idupb = UWT.idupb and Cred.idfin = UWT.idfin 		 
		  order by  W.title,U.codeupb,F.codefin

END   


--> SOLO COMPETENZA 
IF (@fin_kind = 1) 
BEGIN
	;with UWT(idfin,idupb,idunderwriting) 
	 as 
	(select myUWT.idfin,myUWT.idupb,myUWT.idunderwriting 
			from 	upbunderwritingtotal myUWT 
				join fin F		on myUWT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on myUWT.idupb = U.idupb
					 
		  where (myUWT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (myUWT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
	union all
		select UET.idfin,UET.idupb,UET.idunderwriting 
			from 	underwritingexpensetotal UET 
				join fin F		on UET.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UET.idupb = U.idupb
		

				left outer join upbunderwritingtotal UT on UT.idfin= UET.idfin and UT.idupb=UET.idupb and UT.idunderwriting=UET.idunderwriting
		  where (UET.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UET.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null
				and UET.nphase = @finphaseexpense
	union all
		select UIT.idfin,UIT.idupb,UIT.idunderwriting 
			from 	underwritingincometotal UIT 
				join fin F		on UIT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UIT.idupb = U.idupb
				left outer join upbunderwritingtotal UT on UT.idfin= UIT.idfin and UT.idupb=UIT.idupb and UT.idunderwriting=UIT.idunderwriting
		  where (UIT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UIT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null	
				and UIT.nphase = @finphaseincome	
)	
		select 
			S01.sortcode as 'Cod. Attrib. 1',
			S01.description  as 'Attrib. 1',
			S02.sortcode as 'Cod. Attrib. 2',
			S02.description  as 'Attrib. 2',
			S03.sortcode as 'Cod. Attrib. 3',
			S03.description as 'Attrib. 3',
			S04.sortcode as 'Cod. Attrib. 4',
			S04.description as 'Attrib. 4',
			S05.sortcode as 'Cod. Attrib. 5',
			S05.description as 'Attrib. 5',
		   	CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)<>0) then 'S'
			End as 'E/S',	
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
				M.title as 'Responsabile',
			CASE U.flagkind 
				WHEN 0 THEN 'Didattica' 
				WHEN 1 THEN 'Ricerca' 
			END as 'Funzione' , --- Funzione dell’upb (didattica/ricerca)	
			CASE U.flagactivity 
				WHEN 4 THEN 'Qualsiasi/Non Spec.' 
				WHEN 1 THEN 'Istituzionale' 
				WHEN 2 THEN 'Commerciale' 
			END as 'Attività' ,		--- Attività dell’upb (istituz/commerciale/qualsiasi)
			F.codefin as 'Bilancio',
			isnull(PPI.amount,0) as 'Prev.Competenza iniziale',
			isnull(PPA.amount,0) as 'Prev.Competenza attuale',
			CASE
				when (( F.flag & 1)=0)  /* E */
					then isnull(PPA.amount,0)- isnull(AccComp.amount,0) 
				when (( F.flag & 1)<>0) /* S */
					then isnull(PPA.amount,0)- isnull(ImpComp.amount,0) -isnull(OPS.amount,0) 
			End 
			as 'Prev.Competenza.Disponibile',
			CASE 
				when (( F.flag & 1)<>0) /* S */
				then
				isnull(Cred.amount,0) 
				else null
			End	
			as 'Crediti',
			CASE 
				when (( F.flag & 1)=1) /* S */
				then isnull(Cred.amount,0) - isnull(ImpComp.amount,0) -isnull(OPS.amount,0) 
				else null		
			End
			as 'Crediti Disponibili',
			CASE
				when (( F.flag & 1)=0) /*E*/then (isnull(AccComp.amount,0) )
			End as 'Accertato c/competenza',
			CASE
				when (( F.flag & 1)=0) /*E*/then (isnull(AccRes.amount,0))
			End as 'Accertato c/residuo',
			CASE
				when (( F.flag & 1)=1) /*S*/then isnull(ImpComp.amount,0) + isnull(OPS.amount,0) 
			End as 'Impegnato c/competenza',
			CASE
				when (( F.flag & 1)=1) /*S*/then isnull(ImpRes.amount,0)
			End as 'Impegnato c/residuo'

			from  UWT 
				join fin F		on UWT.idfin = F.idfin
				join upb U		on UWT.idupb = U.idupb
					left outer join manager M
				on M.idman = U.idman
				left outer join sorting as S01
					on S01.idsor = U.idsor01
				left outer join sorting as S02
					on S02.idsor = U.idsor02
				left outer join sorting as S03
					on S03.idsor = U.idsor03
				left outer join sorting as S04
					on S04.idsor = U.idsor04
				left outer join sorting as S05
					on S05.idsor = U.idsor05
				left outer join underwriting W	on UWT.idunderwriting = W.idunderwriting
		   left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON isnull(PPI.idunderwriting,0) = isnull(UWT.idunderwriting,0) and PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
		   left outer join #PREVISIONE_PRINCIPALE_ATTUALE PPA
   				ON isnull(PPA.idunderwriting,0) = isnull(UWT.idunderwriting,0) and PPA.idupb = UWT.idupb and PPA.idfin = UWT.idfin
		   left outer join #PICCOLE_SPESE OPS	
   				ON isnull(OPS.idunderwriting,0) = isnull(UWT.idunderwriting,0) and OPS.idupb = UWT.idupb and OPS.idfin = UWT.idfin
		   left outer join #IMPEGNI_COMP ImpComp
   				ON isnull(ImpComp.idunderwriting,0) = isnull(UWT.idunderwriting,0) and ImpComp.idupb = UWT.idupb and ImpComp.idfin = UWT.idfin
		   left outer join #IMPEGNI_RESIDUI ImpRes
   				ON isnull(ImpRes.idunderwriting,0) = isnull(UWT.idunderwriting,0) and ImpRes.idupb = UWT.idupb and ImpRes.idfin = UWT.idfin
		   left outer join #ACCERTAMENTI_COMP AccComp
   				ON isnull(AccComp.idunderwriting,0) = isnull(UWT.idunderwriting,0) and AccComp.idupb = UWT.idupb and AccComp.idfin = UWT.idfin
		   left outer join #ACCERTAMENTI_RESIDUI AccRes
   				ON isnull(AccRes.idunderwriting,0) = isnull(UWT.idunderwriting,0) and AccRes.idupb = UWT.idupb and AccRes.idfin = UWT.idfin
		   left outer join #DOT_CREDITI Cred
   				ON isnull(Cred.idunderwriting,0) = isnull(UWT.idunderwriting,0) and Cred.idupb = UWT.idupb and Cred.idfin = UWT.idfin
		  order by  W.title,U.codeupb,F.codefin
END   


--> SOLO CASSA 
IF (@fin_kind = 2) 
BEGIN
	
				;with UWT(idfin,idupb,idunderwriting) 
	 as 
	(select myUWT.idfin,myUWT.idupb,myUWT.idunderwriting 
			from 	upbunderwritingtotal myUWT 
				join fin F		on myUWT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on myUWT.idupb = U.idupb
		  where (myUWT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (myUWT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)		  
	union all
		select UET.idfin,UET.idupb,UET.idunderwriting 
			from 	underwritingexpensetotal UET 
				join fin F		on UET.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UET.idupb = U.idupb
				left outer join upbunderwritingtotal UT on UT.idfin= UET.idfin and UT.idupb=UET.idupb and UT.idunderwriting=UET.idunderwriting
		  where (UET.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UET.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null
				and UET.nphase = @finphaseexpense
	union all
		select UIT.idfin,UIT.idupb,UIT.idunderwriting 
			from 	underwritingincometotal UIT 
				join fin F		on UIT.idfin = F.idfin
				JOIN finlink	ON finlink.idchild = F.idfin
				join upb U		on UIT.idupb = U.idupb
				left outer join upbunderwritingtotal UT on UT.idfin= UIT.idfin and UT.idupb=UIT.idupb and UT.idunderwriting=UIT.idunderwriting
		  where (UIT.idunderwriting = @idunderwriting or @idunderwriting is null)
				and (UIT.idupb= @idupb or @idupb is null)
				--and (UWT.idfin = @idfin or @idfin is null)
				AND (
					( @idfin is null AND finlink.nlevel = @levelusable)
					OR 
					(finlink.idparent = @idfin AND finlink.nlevel = @nlevel) 
					)
				and F.ayear = @ayear
				AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)
				AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)
				AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)
				AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)
				AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)	
				AND UT.idfin is null		
				and UIT.nphase = @finphaseincome
)	
		select 
			S01.sortcode as 'Cod. Attrib. 1',
			S01.description  as 'Attrib. 1',
			S02.sortcode as 'Cod. Attrib. 2',
			S02.description  as 'Attrib. 2',
			S03.sortcode as 'Cod. Attrib. 3',
			S03.description as 'Attrib. 3',
			S04.sortcode as 'Cod. Attrib. 4',
			S04.description as 'Attrib. 4',
			S05.sortcode as 'Cod. Attrib. 5',
			S05.description as 'Attrib. 5',
		   	CASE
				when (( F.flag & 1)=0) then 'E'
				when (( F.flag & 1)<>0) then 'S'
			End as 'E/S',	
			W.title as 'Finanziamento',
			U.codeupb as 'UPB',
			M.title as 'Responsabile',
			CASE U.flagkind 
				WHEN 0 THEN 'Didattica' 
				WHEN 1 THEN 'Ricerca' 
			END as 'Funzione' , --- Funzione dell’upb (didattica/ricerca)	
			CASE U.flagactivity 
				WHEN 4 THEN 'Qualsiasi/Non Spec.' 
				WHEN 1 THEN 'Istituzionale' 
				WHEN 2 THEN 'Commerciale' 
			END as 'Attività' ,		--- Attività dell’upb (istituz/commerciale/qualsiasi)
			F.codefin as 'Bilancio',
			isnull(PPI.amount,0) as 'Prev.Cassa iniziale',			
			isnull(PPA.amount,0) as 'Prev.Cassa attuale',
			CASE
				when (( F.flag & 1)=0)  /* E */
					then isnull(PPA.amount,0)- (isnull(AccComp.amount,0) + isnull(AccRes.amount,0))
				when (( F.flag & 1)=1) /* S */
					then isnull(PPA.amount,0)- (isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0)) -isnull(OPS.amount,0) 
			End 
			as 'Prev.Cassa.Disponibile',
			CASE
				when (( F.flag & 1)=1) /* S */
				then isnull(Incas.amount,0) 
				else null		
			End
			as 'Incassi',
			CASE
				when (( F.flag & 1)=1) /* S */
				then isnull(Incas.amount,0)- isnull(P.amount,0)- isnull(OPS.amount,0)  
				else null		
			End
			as 'Incassi Disponibili',
			CASE
				when (( F.flag & 1)=0) /*E*/then (isnull(AccComp.amount,0) + isnull(AccRes.amount,0))
			End as 'Accertato',
			CASE
				when (( F.flag & 1)=1) /*S*/then (isnull(ImpComp.amount,0) + isnull(ImpRes.amount,0)) +isnull(OPS.amount,0) 
			End as 'Impegnato'			
			from  UWT 
			join fin F
				on UWT.idfin = F.idfin
			JOIN finlink
				ON finlink.idchild = F.idfin
			join upb U
				on UWT.idupb = U.idupb
			left outer join manager M
				on M.idman = U.idman
			left outer join sorting as S01
				on S01.idsor = U.idsor01
			left outer join sorting as S02
				on S02.idsor = U.idsor02
			left outer join sorting as S03
				on S03.idsor = U.idsor03
			left outer join sorting as S04
				on S04.idsor = U.idsor04
			left outer join sorting as S05
				on S05.idsor = U.idsor05
			left outer join underwriting W
				on UWT.idunderwriting = W.idunderwriting
		   left outer join #PREVISIONE_PRINCIPALE_INIZIALE PPI
   				ON isnull(PPI.idunderwriting,0) = isnull(UWT.idunderwriting,0) and PPI.idupb = UWT.idupb and PPI.idfin = UWT.idfin 
		   left outer join #PREVISIONE_PRINCIPALE_ATTUALE PPA
   				ON isnull(PPA.idunderwriting,0) = isnull(UWT.idunderwriting,0) and PPA.idupb = UWT.idupb and PPA.idfin = UWT.idfin
		   left outer join #PICCOLE_SPESE OPS	
   				ON isnull(OPS.idunderwriting,0) = isnull(UWT.idunderwriting,0) and OPS.idupb = UWT.idupb and OPS.idfin = UWT.idfin
		   left outer join #IMPEGNI_COMP ImpComp
   				ON isnull(ImpComp.idunderwriting,0) = isnull(UWT.idunderwriting,0) and ImpComp.idupb = UWT.idupb and ImpComp.idfin = UWT.idfin
		   left outer join #IMPEGNI_RESIDUI ImpRes
   				ON isnull(ImpRes.idunderwriting,0) = isnull(UWT.idunderwriting,0) and ImpRes.idupb = UWT.idupb and ImpRes.idfin = UWT.idfin
		   left outer join #PAGAMENTI P
   				ON isnull(P.idunderwriting,0) = isnull(UWT.idunderwriting,0) and P.idupb = UWT.idupb and P.idfin = UWT.idfin
		   left outer join #ACCERTAMENTI_COMP AccComp
   				ON isnull(AccComp.idunderwriting,0) = isnull(UWT.idunderwriting,0) and AccComp.idupb = UWT.idupb and AccComp.idfin = UWT.idfin
		   left outer join #ACCERTAMENTI_RESIDUI AccRes
   				ON isnull(AccRes.idunderwriting,0) = isnull(UWT.idunderwriting,0) and AccRes.idupb = UWT.idupb and AccRes.idfin = UWT.idfin
		   left outer join #DOT_INCASSI Incas
   				ON isnull(incas.idunderwriting,0) = isnull(UWT.idunderwriting,0) and incas.idupb = UWT.idupb and incas.idfin = UWT.idfin
		   
		  order by  W.title,U.codeupb,F.codefin
		 
END   



drop table #PREVISIONE_PRINCIPALE_ATTUALE 
drop table #PICCOLE_SPESE 
drop table #IMPEGNI_COMP 
drop table #IMPEGNI_RESIDUI 
drop table #PAGAMENTI 
drop table #ACCERTAMENTI_COMP 
drop table #ACCERTAMENTI_RESIDUI 
drop table #DOT_CREDITI 
drop table #DOT_INCASSI 

END

GO








SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



 
