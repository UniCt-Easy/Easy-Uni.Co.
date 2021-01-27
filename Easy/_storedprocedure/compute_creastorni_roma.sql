
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_creastorni_roma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_creastorni_roma]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

   
CREATE   PROCEDURE  [compute_creastorni_roma]
(
	@ayear int,
	@idupb varchar(36),
	@codefin_origine varchar(50),
	@codefin_destinazione varchar(50),
	@amount decimal(19,2),	
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null,
	@descrizione varchar(150)='.'
)
AS BEGIN

declare @idfin_origine int
select @idfin_origine = idfin from fin where codefin = @codefin_origine and ayear = @ayear and (flag & 1)<>0

declare @idfin_destinazione int
select @idfin_destinazione = idfin from fin where codefin = @codefin_destinazione and ayear = @ayear and (flag & 1)<>0

declare @codeupb varchar(50)
select @codeupb = codeupb from upb where idupb = @idupb

declare @treasurer varchar(150)
select @treasurer = isnull(T.header, T.description) from upb U
						join treasurer T
							ON T.idtreasurer = U.idtreasurer
						where U.idupb = @idupb

DECLARE @finexpensephase tinyint
SELECT @finexpensephase = expensefinphase FROM uniconfig

DECLARE @maxexpensephase tinyint
SELECT @maxexpensephase = MAX(nphase) FROM expensephase

CREATE TABLE #error (message varchar(400))
if(	@idupb is null)
Begin
	INSERT INTO #error	VALUES('Selezionare l''U.P.B. su cui eseguire lo storno.')
End

if(	@codefin_origine is null)
Begin
	INSERT INTO #error	VALUES('Non è stata indicata la voce di spesa da cui stornare.')
End

if(	@codefin_destinazione is null)
Begin
	INSERT INTO #error	VALUES('Indicare la voce di spesa in cui stornare.')
End

if(	@amount is null)
Begin
	INSERT INTO #error 	VALUES('Indicare l''importo da stornare.')
End
IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

-- Se @fin_kind = 1 ==> è stata personalizzata una previsione principale di tipo "competenza", se @fin_kind = 2
-- ==> è stata personalizzata una previsione principale di tipo "cassa", se  @fin_kind = 3 ==> è stata personalizzata una
-- previsione principale di tipo "altra previsione". 
DECLARE @fin_kind tinyint
SELECT @fin_kind = ISNULL(fin_kind,0) FROM config WHERE ayear = @ayear



CREATE TABLE #variazionieseguite (message varchar(400))

declare @previsioneORIGINE decimal (19,2)
SET @previsioneORIGINE = ( SELECT ISNULL(upbtotal.currentprev,0)+ISNULL(upbtotal.previsionvariation, 0) 
					from upbtotal 
					join upb
							on upb.idupb = upbtotal.idupb
						where upbtotal.idfin = @idfin_origine and upbtotal.idupb = @idupb 
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					) 
					- 
					ISNULL(
						(SELECT upbexpensetotal.totalcompetency
						from upbexpensetotal 
						join upb
							on upb.idupb = upbexpensetotal.idupb
						where upbexpensetotal.idfin = @idfin_origine
						and upbexpensetotal.idupb = @idupb
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
						and upbexpensetotal.nphase = @finexpensephase),0)
					-
					isnull((SELECT sum(pettycashoperation.amount)
					from pettycashoperation 
						join upb
							on upb.idupb = pettycashoperation.idupb
					where pettycashoperation.idfin = @idfin_origine
					and pettycashoperation.idupb = @idupb
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					and pettycashoperation.yrestore IS NULL AND pettycashoperation.nrestore IS NULL),0)
					- @amount	

if(@previsioneORIGINE<0)
BEGIN
	INSERT INTO #error
	VALUES('La previsione di Competenza del capitolo: '+ convert(varchar(50),@codefin_origine)+ ', da cui si sta facendo lo storno, diverrebbe negativa.')
END

declare @previsionesecondariaORIGINE decimal (19,2)
SET @previsionesecondariaORIGINE = isnull((SELECT ISNULL(upbtotal.currentsecondaryprev,0)+ISNULL(upbtotal.secondaryvariation, 0) 
					from upbtotal 
					join upb
						on upb.idupb = upbtotal.idupb
					where upbtotal.idfin = @idfin_origine 
					and upbtotal.idupb = @idupb 
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					) ,0)
					- 
					ISNULL(
						(SELECT ISNULL(upbexpensetotal.totalcompetency,0) + ISNULL(upbexpensetotal.totalarrears,0)
						from upbexpensetotal 
						join upb
							on upb.idupb = upbexpensetotal.idupb
						where upbexpensetotal.idfin = @idfin_origine
						and upbexpensetotal.idupb = @idupb
						AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
						AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
						and upbexpensetotal.nphase = @maxexpensephase),0)
					- @amount	

if((@previsionesecondariaORIGINE<0)  AND (@fin_kind = 3))
BEGIN
	INSERT INTO #error
	VALUES('La previsione di Cassa del capitolo: '+ convert(varchar(50),@codefin_origine)+ ', da cui si sta facendo lo storno, diverrebbe negativa.')
END
	
declare @creditiORIGINE decimal(19,2)
set @creditiORIGINE = isnull( (SELECT ISNULL(totcreditpart, 0) + ISNULL(creditvariation, 0) 
							from upbtotal 
							join upb
								on upb.idupb = upbtotal.idupb
							where idfin = @idfin_origine
							and	upbtotal.idupb = @idupb
							AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
							AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
							) ,0)
				- 
				ISNULL(
					(SELECT ISNULL(totalcompetency, 0) 
					from upbexpensetotal 
					join upb
						on upb.idupb = upbexpensetotal.idupb
					where idfin = @idfin_origine
					and	upbexpensetotal.idupb = @idupb
					and nphase = @finexpensephase
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					),0)
					
				-	isnull((SELECT sum(pettycashoperation.amount)
					from pettycashoperation 
					join upb
						on upb.idupb = pettycashoperation.idupb
					where pettycashoperation.idfin = @idfin_origine
					and pettycashoperation.idupb = @idupb
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					and pettycashoperation.yrestore IS NULL AND pettycashoperation.nrestore IS NULL),0)
				- @amount

if(@creditiORIGINE<0)
BEGIN
	INSERT INTO #error
	VALUES('La dotazione Crediti del capitolo: '+ convert(varchar(50),@codefin_origine)+ ', da cui si sta facendo lo storno, diverrebbe negativa.')
END

declare @incassiORIGINE decimal(19,2)
set @incassiORIGINE = isnull( (SELECT ISNULL(totproceedspart, 0) + ISNULL(proceedsvariation, 0) 
							from upbtotal 
							join upb
								on upb.idupb = upbtotal.idupb
							where idfin = @idfin_origine
							and	upbtotal.idupb = @idupb
							AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
							AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
							) ,0)
 				- 
				ISNULL(
					(SELECT ISNULL(totalcompetency, 0) + ISNULL(totalarrears,0)
					from upbexpensetotal 
					join upb
						on upb.idupb = upbexpensetotal.idupb
					where idfin = @idfin_origine
					and	upbexpensetotal.idupb = @idupb
					and nphase = @maxexpensephase
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					),0)
					
				-	isnull((SELECT sum(pettycashoperation.amount)
					from pettycashoperation 
					join upb
						on upb.idupb = pettycashoperation.idupb
					where pettycashoperation.idfin = @idfin_origine
					and pettycashoperation.idupb = @idupb
					AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
					AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
					and pettycashoperation.yrestore IS NULL AND pettycashoperation.nrestore IS NULL),0)
				- @amount

if((@incassiORIGINE<0) AND (@fin_kind = 3))
BEGIN
	INSERT INTO #error
	VALUES('La dotazione Incassi del capitolo: '+ convert(varchar(50),@codefin_origine)+ ', da cui si sta facendo lo storno, diverrebbe negativa.')
END



IF (SELECT COUNT(*) FROM #error) > 0
BEGIN
	SELECT * FROM #error
	RETURN
END

CREATE TABLE #FinvardetailTemp(
	nvar	int,
	yvar	smallint,
	rownum int identity(1,1),
	idfin	int,
	idupb	varchar(36),
	amount	decimal(19,2),
	description	varchar(150),
	ct	datetime,
	cu	varchar(64),
	lt	datetime,
	lu	varchar(64)
)

DECLARE @nvar   int 
SET 	@nvar = ISNULL((SELECT MAX(nvar) FROM finvar WHERE yvar = @ayear),0) +1

DECLARE @nofficial   int 
SET 	@nofficial = ISNULL((SELECT MAX(nofficial) FROM finvar WHERE yvar = @ayear),0) +1


 -- CREO UNA VARIAZIONE DI COMPETENZA E CASSA
INSERT INTO #FinvardetailTemp(idupb, nvar, yvar, amount, ct, cu,  description, lt, lu, idfin)
SELECT @idupb, @nvar, @ayear, @amount,	GetDate(),'assistenza', convert(varchar(150),@descrizione), GetDate(),'assistenza',@idfin_destinazione

INSERT INTO #FinvardetailTemp(idupb, nvar, yvar, amount, ct, cu,  description, lt, lu, idfin) 
SELECT @idupb, @nvar, @ayear, -@amount,	GetDate(),'assistenza', convert(varchar(150),@descrizione), GetDate(),'assistenza',@idfin_origine

IF (select count(*) from #FinvardetailTemp)>0 
BEGIN
		INSERT INTO finvar
		(nvar,yvar,adate,ct,cu,description, enactment,enactmentdate,
		flagcredit,flagprevision, flagproceeds,flagsecondaryprev,
		lt,lu,nenactment, rtf,txt,official,nofficial,variationkind,idfinvarstatus,varflag,moneytransfer,
		idsor01,idsor02,idsor03,idsor04,idsor05)
		SELECT @nvar, @ayear,getdate() ,GetDate(),'assistenza',
		convert(varchar(150),@descrizione),
		null,null,	'S','S','N','N',
		GetDate(),'assistenza',null,null,null,'S',@nofficial,4,4,0,'N',
		@idsor01,@idsor02,	@idsor03,	@idsor04,	@idsor05 
		
		INSERT INTO finvardetail (idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin,createexpense) 
		SELECT idupb, nvar, rownum, yvar, amount, ct, cu,  description, lt, lu, idfin,'N' 
		FROM #FinvardetailTemp

		insert into #variazionieseguite
		values('E'' stata creata la Variazione di tipo STORNO, N. '+convert(varchar(10),@nvar)+'.')
END

IF (SELECT COUNT(*) FROM #variazionieseguite) > 0
BEGIN
	SELECT * FROM #variazionieseguite
END

drop table #error
drop table #variazionieseguite
drop table #FinvardetailTemp
END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

