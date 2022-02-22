
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_situazionebudget_new]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_situazionebudget_new]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
/*
-Esercizio
-Data Fine
-UPB
-Visualizza UPB nella stampa
-Includi UPB sottostanti nel calcolo di stampa
-Codice conto di Minimo livello operativo
*/
--setuser'amm'
--setuser 'amministrazione'
--exec [rpt_situazionebudget_new] 2019, '2019-31-12','S'
CREATE PROCEDURE [rpt_situazionebudget_new]
	@ayear	    	int,
	@stop    	datetime,
	@showupb char(1)='N',
	@idupb varchar(36)='%',
	@showchildupb char(1)='S',
	@codeacc varchar(50) = '%',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	AS
	BEGIN


	declare @idacc varchar(38)
	if (@codeacc = '%')
	begin
		set @idacc = '%'
	end
	else
	Begin
		set @idacc = (select idacc from account where codeacc = @codeacc and ayear = @ayear)
	End
	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	declare @fixedidupb varchar(36)
	set @fixedidupb= null
	if (@showupb='N') 
	Begin
		set @fixedidupb='0001'
	End

	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	--select * from #budgetsituation  
	declare @nlevel int
	set @nlevel = (select MIN(nlevel) from accountlevel where ayear = @ayear and flagusable = 'S')

	declare @lenminlevel int
	set @lenminlevel = 2 + 4*@nlevel


	CREATE TABLE #budgetsituation
		(
		idepexp			int,
		paridepexp      int,
		idepacc			int, 
		paridepacc		int,
		idacc 			varchar(38), 
		accountkind		char(1),
		idupb			varchar(36),
		rowkind			int,
		operationdate		datetime,
		operationkind		varchar(100),
		descroperation		varchar(200),
		ymov			int,
		nmov			int,	
		parentymov		int,
		parentnmov      int,
		ymovprinc		int,-- in presenza di variazioni, denotano il movimento principale
		nmovprinc		int,	
		amount			decimal(19,2),
		amount2			decimal(19,2),
		amount3			decimal(19,2),
		amount4			decimal(19,2),
		amount5			decimal(19,2),
		curramount		decimal(19,2),
		curramount2		decimal(19,2),
		curramount3		decimal(19,2),
		curramount4		decimal(19,2),
		curramount5		decimal(19,2),
		availableamount			decimal(19,2),
		availableamount2		decimal(19,2),
		availableamount3		decimal(19,2),
		availableamount4		decimal(19,2),
		availableamount5		decimal(19,2),
		docrelated				varchar(200),
		datedocrelated			datetime,
		idreg				int,
		initialprevision 	decimal(19,2),
		initialprevision2 	decimal(19,2),
		initialprevision3 	decimal(19,2),
		initialprevision4 	decimal(19,2),
		initialprevision5 	decimal(19,2),
		availableprevision	decimal(19,2),
		availableprevision2	decimal(19,2),
		availableprevision3	decimal(19,2),
		availableprevision4	decimal(19,2),
		availableprevision5	decimal(19,2) 			
		)
PRINT '0---------------'
--previsioni iniziali per l'esercizio corrente
	INSERT INTO #budgetsituation
	      (
		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		initialprevision,
		initialprevision2, 	
		initialprevision3, 	
		initialprevision4, 	
		initialprevision5 	 	
		)
	SELECT 
		AU.idacc, 	
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,U.idupb),
		1,		/* rowkind  = 1				Prev. iniziale Conti di COSTO */
		null,
		'Prev. iniziale Budget Costi',	
		isnull(prevision,0),
		isnull(prevision2,0), 	
		isnull(prevision3,0) ,	
		isnull(prevision4,0) ,	
		isnull(prevision5,0) 	 		
	from accountyear AY
	join accountminusable AU
		on AY.idacc = AU.idacc
		and AY.ayear = AU.ayear
	join upb U			
		on  AY.idupb = U.idupb
	join account A
		on AY.idacc = A.idacc
	join account PARENT 
		on PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	WHERE AY.ayear = @ayear
		AND ((A.flagaccountusage & 320)<> 0)  	 -- conti di Costo
		AND U.idupb like @idupb		AND PARENT.idacc like @idacc		
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			
PRINT '1---------------'
	INSERT INTO #budgetsituation
	      (
		idacc, 	accountkind,	idupb,	rowkind,		operationdate,	operationkind,	descroperation,	docrelated,		
		datedocrelated,
		ymov,		nmov,		
		amount, amount2, amount3, amount4, amount5, 
		initialprevision,initialprevision2, initialprevision3, 	initialprevision4, 	initialprevision5 
		)
	SELECT 
		accountvardetail.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,	
		isnull(@fixedidupb,U.idupb),			
		2,		/* rowkind  = 2			Var. Prev. iniziale Conti di COSTO */
		accountvar.adate,
		'Var. prev. Budget Costi',	
		accountvar.description,
		isnull(accountvar.enactment,'') + space(1) + isnull(accountvar.nenactment,''),
		accountvar.enactmentdate, 
		accountvar.yvar,		accountvar.nvar,	
		isnull(accountvardetail.amount,0),
		isnull(accountvardetail.amount2,0),
		isnull(accountvardetail.amount3,0),
		isnull(accountvardetail.amount4,0),
		isnull(accountvardetail.amount5,0),
		0,0,0,0,0 		
	from accountvar
 	join accountvardetail			
		ON accountvar.yvar = accountvardetail.yvar
		AND accountvar.nvar = accountvardetail.nvar
	join upb U
		ON U.idupb = accountvardetail.idupb
	join account A
	  	on accountvardetail.idacc = A.idacc
	join account PARENT 
		on PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where accountvar.adate <= @stop
		AND ((A.flagaccountusage & 320)<> 0)  	 -- conti di Costo
		and accountvar.yvar = @ayear
		AND U.idupb like @idupb		AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and accountvar.idaccountvarstatus=5 
		and accountvar.variationkind <> 5
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

PRINT '2---------------'
	INSERT INTO #budgetsituation
	      (
		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		initialprevision,
		initialprevision2, 	
		initialprevision3, 	
		initialprevision4, 	
		initialprevision5  	
		)
	SELECT 
		AU.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,	
		isnull(@fixedidupb,U.idupb),
		10,		/* rowkind  = 10			Prev. iniziale Conti di RICAVO*/
		null,
		'Prev. iniziale Budget Ricavi',	
		isnull(prevision,0),
		isnull(prevision2,0), 	
		isnull(prevision3,0),	
		isnull(prevision4,0),	
		isnull(prevision5,0)  		
	from accountyear AY
	join accountminusable AU
		on AY.idacc = AU.idacc
		and AY.ayear = AU.ayear
	join upb U			
		on  AY.idupb = U.idupb
	join account A
		on AY.idacc = A.idacc
	join account PARENT 
		on PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	WHERE AY.ayear = @ayear
		AND ((A.flagaccountusage & 128)<> 0)  	 -- conti di Ricavo
		AND U.idupb like @idupb			AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)			

INSERT INTO #budgetsituation
	      (
		idacc,accountkind,idupb,	rowkind,		operationdate,	operationkind,	descroperation,	docrelated,		datedocrelated,
		ymov,		nmov,				
		amount, amount2, amount3, amount4, amount5, 
		initialprevision,initialprevision2, initialprevision3, 	initialprevision4, 	initialprevision5 
		)
	SELECT 
		accountvardetail.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,	
		isnull(@fixedidupb,U.idupb),			
		20,		/* rowkind  = 20			Var. Prev. iniziale Conti di RICAVO*/
		accountvar.adate,
		'Var. prev. Budget Ricavi',	
		accountvar.description,
		isnull(accountvar.enactment,'') + space(1) + isnull(accountvar.nenactment,''),
		accountvar.enactmentdate, 
		accountvar.yvar,		accountvar.nvar,	
		isnull(accountvardetail.amount,0),
		isnull(accountvardetail.amount2,0),
		isnull(accountvardetail.amount3,0),
		isnull(accountvardetail.amount4,0),
		isnull(accountvardetail.amount5,0),
		0,0,0,0,0 		
	from accountvar
 	join accountvardetail			
		ON accountvar.yvar = accountvardetail.yvar
		AND accountvar.nvar = accountvardetail.nvar
	join upb U
		ON U.idupb = accountvardetail.idupb
	join account A
	  	on accountvardetail.idacc = A.idacc
	join account PARENT 
		on PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where accountvar.adate <= @stop
		AND ((A.flagaccountusage & 128)<> 0)  	 -- conti di Ricavo
		and accountvar.yvar = @ayear
		AND U.idupb like @idupb		AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and accountvar.idaccountvarstatus=5 
		and accountvar.variationkind <> 5
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

INSERT INTO #budgetsituation
	      (	idepexp,paridepexp,	idacc, accountkind,		idupb,	rowkind,	operationdate,	operationkind,	descroperation,	docrelated,	datedocrelated,
			ymov,	nmov, parentymov,     parentnmov,  idreg,	
			amount,	amount2,amount3,amount4,amount5,
			curramount,curramount2, curramount3, curramount4, curramount5,  
			availableamount,availableamount2, availableamount3, availableamount4, availableamount5,  
			initialprevision, initialprevision2, initialprevision3,  	initialprevision4,  	initialprevision5  	 		
			)
	SELECT 
		epexpview.idepexp,	isnull(epexpview.paridepexp,epexpview.idepexp), epexpview.idacc, case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,	isnull(@fixedidupb,epexpview.idupb),	
		5,		/* rowkind  = 5		*/
		epexpview.adate,	'Impegno di Budget',	
		epexpview.description,	epexpview.doc,		epexpview.docdate,
		epexpview.yepexp,	epexpview.nepexp,  epexpview.parentyepexp, epexpview.parentnepexp,
		epexpview.idreg,	
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount ELSE - epexpview.amount END ,0),	
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount2 ELSE - epexpview.amount2 END ,0),	
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount3 ELSE - epexpview.amount3 END ,0),	
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount4 ELSE - epexpview.amount4 END ,0),	
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount5 ELSE - epexpview.amount5 END ,0),	
		0,0,0,0,0,	
		0,0,0,0,0,	
		0,0,0,0,0
	from epexpview
	join upb U		  ON U.idupb = epexpview.idupb
	join account A    ON epexpview.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epexpview.adate <= @stop
		and epexpview.ayear = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epexpview.nphase = 2
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

--select '3',* from #budgetsituation where rowkind = 3
INSERT INTO #budgetsituation
	    (idepexp, paridepexp,	idacc, accountkind,	idupb,	rowkind,operationdate,	operationkind,	descroperation,	docrelated,	datedocrelated,
		ymov,nmov,	idreg,	
		amount,amount2,amount3,amount4,amount5,
		curramount, curramount2, curramount3, curramount4, curramount5,    
		availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
		initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5,
		ymovprinc, nmovprinc
		)
	SELECT 
		epexp.idepexp,isnull(epexp.paridepexp,epexp.idepexp), epexpyear.idacc, 	
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epexpyear.idupb),	
		6,	/* rowkind  = 6		*/
		epexpvar.adate,	'Var.Impegno di Budget',	--Impegno
		epexp.description,	epexp.doc,	epexp.docdate,	epexpvar.yvar,	epexpvar.nvar,	epexp.idreg,
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount ELSE - epexpvar.amount END ,0),	
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount2 ELSE - epexpvar.amount2 END ,0),
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount3 ELSE - epexpvar.amount3 END ,0),
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount4 ELSE - epexpvar.amount4 END ,0),
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount5 ELSE - epexpvar.amount5 END ,0),
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0,
		epexp.yepexp,epexp.nepexp
	from epexp
	join epexpyear				ON  epexp.idepexp = epexpyear.idepexp
	join epexpvar				on epexpvar.idepexp = epexp.idepexp 
									and epexpvar.yvar = epexpyear.ayear 
	join upb U					ON U.idupb = epexpyear.idupb
	join account A    ON epexpyear.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epexpvar.adate <= @stop
		and epexpvar.yvar = @ayear
		and epexpyear.ayear = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epexp.nphase = 2
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
--select '4',* from #budgetsituation where rowkind = 4
INSERT INTO #budgetsituation
	      (	idepexp, paridepexp,idacc, accountkind,	idupb,	rowkind, operationdate, operationkind,	descroperation,	docrelated,	datedocrelated,
		ymov,nmov,parentymov,parentnmov,	idreg,	
		amount,amount2,amount3,amount4,amount5,
		curramount, curramount2, curramount3, curramount4, curramount5,    
		availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
		initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5
		)
	SELECT 
		epexpview.idepexp ,	isnull(epexpview.paridepexp,epexpview.idepexp) , epexpview.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epexpview.idupb),	
		3,	/* rowkind  = 3		*/
		epexpview.adate,'Preimpegno di Budget',	
		epexpview.description,	epexpview.doc,	epexpview.docdate,	epexpview.yepexp,	epexpview.nepexp,	
		epexpview.yepexp, epexpview.nepexp,
		epexpview.idreg, 
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount ELSE - epexpview.amount END ,0), 
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount2 ELSE - epexpview.amount2 END ,0),
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount3 ELSE - epexpview.amount3 END ,0),  
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount4 ELSE - epexpview.amount4 END ,0),  
		isnull(case when epexpview.flagvariation='N' THEN epexpview.amount5 ELSE - epexpview.amount5 END ,0),
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0	
	from epexpview
 
	join upb U						ON U.idupb = epexpview.idupb

	join account A    ON epexpview.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epexpview.adate <= @stop
		and epexpview.ayear = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epexpview.nphase = 1
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

--select '3',* from #budgetsituation where rowkind = 3
INSERT INTO #budgetsituation
	      (idepexp, paridepexp, idacc, accountkind,	idupb,		rowkind,	operationdate,	operationkind,		descroperation,	docrelated,	datedocrelated,
		ymov,	nmov,	idreg,	
		amount,amount2,amount3,amount4,amount5,
		curramount, curramount2, curramount3, curramount4, curramount5,    
		availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
		initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5,
		ymovprinc, nmovprinc
		)
	SELECT 
		epexp.idepexp, isnull(epexp.paridepexp,epexp.idepexp), epexpyear.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epexpyear.idupb),	
		4,	/* rowkind  = 4		*/
		epexpvar.adate,	'Var. Preimpegno di Budget',	-- Preimpegno di Budget
		epexp.description, 	epexp.doc, 	epexp.docdate,	epexpvar.yvar,	epexpvar.nvar, 	epexp.idreg,
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount ELSE - epexpvar.amount END ,0),	
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount2 ELSE - epexpvar.amount2 END ,0),	
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount3 ELSE - epexpvar.amount3 END ,0),	
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount4 ELSE - epexpvar.amount4 END ,0),	
		isnull(case when epexp.flagvariation='N' THEN epexpvar.amount5 ELSE - epexpvar.amount5 END ,0),	
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0,	
		epexp.yepexp,epexp.nepexp
	from epexp
	join epexpyear					ON epexp.idepexp = epexpyear.idepexp
	join epexpvar					ON epexpvar.idepexp = epexp.idepexp 
										and epexpvar.yvar = epexpyear.ayear 
	join upb U						ON U.idupb = epexpyear.idupb
	join account A					ON epexpyear.idacc = A.idacc
	join account PARENT				ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epexpvar.adate <= @stop
		and epexpyear.ayear = @ayear
		and epexpvar.yvar = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epexp.nphase = 1
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
 

 
INSERT INTO #budgetsituation
	      (	idepacc,paridepacc,	idacc,accountkind, 		idupb,	rowkind,	operationdate,	operationkind,	descroperation,	docrelated,	datedocrelated,
			ymov,	nmov, parentymov,     parentnmov,  idreg,	
			amount,amount2,amount3,amount4,amount5,
			curramount, curramount2, curramount3, curramount4, curramount5,    
			availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
			initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5	
		   )
	SELECT 
		epaccview.idepacc,	isnull(epaccview.paridepacc,epaccview.idepacc), epaccview.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epaccview.idupb),	
		50,		/* rowkind  = 5		*/
		epaccview.adate,	'Accertamento di Budget',	
		epaccview.description,	epaccview.doc,		epaccview.docdate,
		epaccview.yepacc,	epaccview.nepacc,  epaccview.parentyepacc, epaccview.parentnepacc,
		epaccview.idreg,	
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount ELSE - epaccview.amount END ,0),	
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount2 ELSE - epaccview.amount2 END ,0),	
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount3 ELSE - epaccview.amount3 END ,0),	
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount4 ELSE - epaccview.amount4 END ,0),	
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount5 ELSE - epaccview.amount5 END ,0),	
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0
	from epaccview
	join upb U ON U.idupb = epaccview.idupb
	join account A    ON epaccview.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epaccview.adate <= @stop
		and epaccview.ayear = @ayear
		AND U.idupb like @idupb	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epaccview.nphase = 2
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


INSERT INTO #budgetsituation
	      (idepacc, paridepacc,	idacc, accountkind,	idupb,	rowkind,operationdate,	operationkind,	descroperation,	docrelated,	datedocrelated,
			ymov,nmov,	idreg,	
			amount,amount2,amount3,amount4,amount5,
			curramount, curramount2, curramount3, curramount4, curramount5,    
			availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
			initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5,
			ymovprinc, nmovprinc
		)
	SELECT 
		epacc.idepacc,isnull(epacc.paridepacc,epacc.idepacc), epaccyear.idacc, 
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epaccyear.idupb),	
		60,	/* rowkind  = 6		*/
		epaccvar.adate,	'Var. Accertamento di Budget',	--Accertamento
		epacc.description,	epacc.doc,	epacc.docdate,	epaccvar.yvar,	epaccvar.nvar,	epacc.idreg,
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount ELSE - epaccvar.amount END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount2 ELSE - epaccvar.amount2 END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount3 ELSE - epaccvar.amount3 END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount4 ELSE - epaccvar.amount4 END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount5 ELSE - epaccvar.amount5 END ,0),	
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0,
		epacc.yepacc,epacc.nepacc
	from epacc
	join epaccyear				ON  epacc.idepacc = epaccyear.idepacc
	join epaccvar				ON  epaccvar.idepacc = epacc.idepacc 
									and epaccvar.yvar = epaccyear.ayear 
	join upb U					ON U.idupb = epaccyear.idupb	
	join account A    ON epaccyear.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epaccvar.adate <= @stop
		and epaccvar.yvar = @ayear
		and epaccyear.ayear = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)		
		and epacc.nphase = 2
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)

INSERT INTO #budgetsituation
	      (	idepacc, paridepacc,idacc, 	accountkind,
			idupb,	rowkind, operationdate, operationkind,	descroperation,	docrelated,	datedocrelated,
			ymov,nmov,parentymov,parentnmov,	idreg,	
			amount,amount2,amount3,amount4,amount5,
			curramount, curramount2, curramount3, curramount4, curramount5,    
			availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
			initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5
		)
	SELECT 
		epaccview.idepacc ,	isnull(epaccview.paridepacc,epaccview.idepacc) , epaccview.idacc,
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epaccview.idupb),	
		30,	/* rowkind  = 3		*/
		epaccview.adate,'Preaccertamento di Budget',	
		epaccview.description,	epaccview.doc,	epaccview.docdate,	epaccview.yepacc,	epaccview.nepacc,	
		epaccview.yepacc, epaccview.nepacc,
		epaccview.idreg, 
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount ELSE - epaccview.amount END ,0),
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount2 ELSE - epaccview.amount2 END ,0),
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount3 ELSE - epaccview.amount3 END ,0),
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount4 ELSE - epaccview.amount4 END ,0),
		isnull(case when epaccview.flagvariation='N' THEN epaccview.amount5 ELSE - epaccview.amount5 END ,0),
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0
	from epaccview
	join upb U	ON U.idupb = epaccview.idupb
	join account A    ON epaccview.idacc = A.idacc
	join account PARENT ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epaccview.adate <= @stop
		and epaccview.ayear = @ayear
		AND U.idupb like @idupb 	AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epaccview.nphase = 1
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)


INSERT INTO #budgetsituation
	      (	idepacc, paridepacc, idacc, accountkind,	idupb,		rowkind,	operationdate,	operationkind,		descroperation,	docrelated,	datedocrelated,
			ymov,	nmov,	idreg,	
			amount,amount2,amount3,amount4,amount5,
			curramount, curramount2, curramount3, curramount4, curramount5,    
			availableamount, availableamount2, availableamount3, availableamount4, availableamount5,
			initialprevision, initialprevision2,initialprevision3,initialprevision4,initialprevision5,
			ymovprinc, nmovprinc
		)
	SELECT 
		epacc.idepacc, isnull(epacc.paridepacc,epacc.idepacc), epaccyear.idacc,
		case	when ((A.flagaccountusage & 128)<> 0) then 'R'  	 -- conti di Ricavo
					when ((A.flagaccountusage & 320)<> 0) then 'C'		-- conti di costo o Immobilizzazioni
					else 'X'
		end ,
		isnull(@fixedidupb,epaccyear.idupb),	
		40,	/* rowkind  = 4		*/
		epaccvar.adate,	'Var. Preaccertamento di Budget',	-- Preaccertamento di Budget
		epacc.description, 	epacc.doc, 	epacc.docdate,	epaccvar.yvar,	epaccvar.nvar, 	epacc.idreg,
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount ELSE - epaccvar.amount END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount2 ELSE - epaccvar.amount2 END ,0),	
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount3 ELSE - epaccvar.amount3 END ,0),
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount4 ELSE - epaccvar.amount4 END ,0),
		isnull(case when epacc.flagvariation='N' THEN epaccvar.amount5 ELSE - epaccvar.amount5 END ,0),
		0,0,0,0,0,
		0,0,0,0,0,
		0,0,0,0,0,
		epacc.yepacc,epacc.nepacc
	from epacc
	join epaccyear					ON epacc.idepacc = epaccyear.idepacc
	join epaccvar					ON epaccvar.idepacc = epacc.idepacc 
									AND epaccvar.yvar = epaccyear.ayear 
	join upb U						ON U.idupb = epaccyear.idupb
	join account A					ON epaccyear.idacc = A.idacc
	join account PARENT				ON PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	where epaccvar.adate <= @stop
		and epaccyear.ayear = @ayear
		and epaccvar.yvar = @ayear
		AND U.idupb like @idupb AND (PARENT.idacc like @idacc	OR PARENT.idacc IS NULL)	
		and epacc.nphase = 1
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
 
 UPDATE #budgetsituation SET curramount = amount +  ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepexp = #budgetsituation.idepexp AND rowkind IN (4,6)),0)
 WHERE rowkind IN (3,5)


 UPDATE #budgetsituation SET curramount2 = amount2 +  ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepexp = #budgetsituation.idepexp AND rowkind IN (4,6)),0)
 WHERE rowkind IN (3,5)

 UPDATE #budgetsituation SET curramount3 = amount3 +  ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepexp = #budgetsituation.idepexp AND rowkind IN (4,6)),0)
 WHERE rowkind IN (3,5)

 UPDATE #budgetsituation SET curramount4 = amount4 +  ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepexp = #budgetsituation.idepexp AND rowkind IN (4,6)),0)
 WHERE rowkind IN (3,5)

 UPDATE #budgetsituation SET curramount5 = amount5 +  ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepexp = #budgetsituation.idepexp AND rowkind IN (4,6)),0)
 WHERE rowkind IN (3,5)




 UPDATE #budgetsituation SET curramount = amount +  ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepacc = #budgetsituation.idepacc AND rowkind IN (40,60)),0)
 WHERE rowkind IN (30,50)

  UPDATE #budgetsituation SET curramount2 = amount2 +  ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepacc = #budgetsituation.idepacc AND rowkind IN (40,60)),0)
 WHERE rowkind IN (30,50)

  UPDATE #budgetsituation SET curramount3 = amount3 +  ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepacc = #budgetsituation.idepacc AND rowkind IN (40,60)),0)
 WHERE rowkind IN (30,50)

  UPDATE #budgetsituation SET curramount4 = amount4 +  ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepacc = #budgetsituation.idepacc AND rowkind IN (40,60)),0)
 WHERE rowkind IN (30,50)

  UPDATE #budgetsituation SET curramount5 = amount5 +  ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idepacc = #budgetsituation.idepacc AND rowkind IN (40,60)),0)
 WHERE rowkind IN (30,50)

 -- Se si richiede la stampa nella modalità sintetica non vogliamo vedere tutte le foglie ma
 -- la voce del piano dei conti deve essere il padre di minimo livello operativo
 
-- IMPOSTO SULLE VOCI ESTRATTE IL CODICE DEL CONTO PADRE DI MINIMO LIVELLO OPERATIVO
-- select @nlevel,  @lenminlevel
update #budgetsituation set idacc =  (select idacc  from account PARENT where PARENT.idacc = SUBSTRING(#budgetsituation.idacc, 1, @lenminlevel))
 
INSERT INTO #budgetsituation
	      (
		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		initialprevision,
		initialprevision2,
		initialprevision3,
		initialprevision4,
		initialprevision5
		)
	SELECT 
		DISTINCT
		accountminusable.idacc, 
		'C' ,	
		isnull(@fixedidupb, U.idupb),			
		1,
		null,
		'Prev. iniziale Budget Costi',	
		0,
		0,
		0,
		0,
		0	
	    FROM #budgetsituation R
		JOIN accountminusable 
			ON accountminusable.idacc = R.idacc
		join upb U
			ON U.idupb = R.idupb
	   WHERE  U.idupb like @idupb
			AND EXISTS (select * from  #budgetsituation i
				  where R.idacc=i.idacc AND R.idupb=i.idupb AND i.rowkind in (2 /*var previsione costi*/,3 /*preimpegni*/,5/*impegni*/)) 
			AND	NOT EXISTS (select * from  #budgetsituation j
				  where R.idacc=j.idacc AND R.idupb=j.idupb AND j.rowkind=1) 
			AND accountminusable.ayear = @ayear 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)



--- INSERISCO LE PREVISIONI INIZIALI A ZERO PER QUELLE COPPIE UPB CONTO MINIMO LIVELLO OPERATIVO CHE NON CE L'HANNO EPPURE SONO MOVIMENTATE
	INSERT INTO #budgetsituation
	      (
		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		initialprevision,
		initialprevision2,
		initialprevision3,
		initialprevision4,
		initialprevision5
		)
	SELECT 
		DISTINCT
		accountminusable.idacc, 
		'R'	,
		isnull(@fixedidupb, U.idupb),			
		10,
		null,
		'Prev. iniziale Budget Ricavi',	
		0,
		0,
		0,
		0,
		0	
	    FROM #budgetsituation R
		JOIN accountminusable 
			ON accountminusable.idacc = R.idacc
		join upb U
			ON U.idupb = R.idupb
	   WHERE  U.idupb like @idupb
			AND EXISTS (select * from  #budgetsituation i
				  where R.idacc=i.idacc AND R.idupb=i.idupb AND i.rowkind in (20 /*var previsione ricavi*/,30 /*preaccertamenti*/,50/*accertamenti*/)) 
			AND	NOT EXISTS (select * from  #budgetsituation j
				  where R.idacc=j.idacc AND R.idupb=j.idupb AND j.rowkind=10) 
			AND accountminusable.ayear = @ayear 
		AND (@idsor01 IS NULL OR U.idsor01 = @idsor01)	AND (@idsor02 IS NULL OR U.idsor02 = @idsor02)	AND (@idsor03 IS NULL OR U.idsor03 = @idsor03)	
		AND (@idsor04 IS NULL OR U.idsor04 = @idsor04)	AND (@idsor05 IS NULL OR U.idsor05 = @idsor05)
 
 
--- calcolo previsione disponibile costi
 IF (@showupb ='S')
begin
 INSERT INTO #budgetsituation
 (
 		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		availableprevision,
		availableprevision2,
		availableprevision3,
		availableprevision4,
		availableprevision5
 )
 SELECT
  
		#budgetsituation.idacc, 
		#budgetsituation.accountkind, 
		#budgetsituation.idupb,			
		7,
		null,
		'Prev. disponibile Budget Costi',	
		 ISNULL(initialprevision,0) +   ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 2 ),0) 
																	-	ISNULL((SELECT SUM(curramount) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (3)),0),
		ISNULL(initialprevision2,0) +   ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount2) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND  rowkind IN (3)),0),
		ISNULL(initialprevision3,0) +   ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount3) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (3)),0),
		ISNULL(initialprevision4,0) +   ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount4) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (3)),0),
		ISNULL(initialprevision5,0) +   ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 2 ),0) 
																-  ISNULL((SELECT SUM(curramount5) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc  AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (3)),0)	
	    FROM #budgetsituation 
		WHERE rowkind = 1 and accountkind= 'C'

  

--- calcolo previsione disponibile ricavi
 
 INSERT INTO #budgetsituation
 (
 		idacc, 	
		accountkind,
		idupb,			
		rowkind,
		operationdate,
		operationkind,	
		availableprevision,
		availableprevision2,
		availableprevision3,
		availableprevision4,
		availableprevision5
 )
 SELECT
  
		#budgetsituation.idacc, 
		#budgetsituation.accountkind, 
		#budgetsituation.idupb,			
		70,
		null,
		'Prev. disponibile Budget Ricavi',	
		 ISNULL(initialprevision,0) +   ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 20 ),0) 
																	-	ISNULL((SELECT SUM(curramount) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (30)),0),
		ISNULL(initialprevision2,0) +   ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount2) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND  rowkind IN (30)),0),
		ISNULL(initialprevision3,0) +   ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount3) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (30)),0),
		ISNULL(initialprevision4,0) +   ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount4) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (30)),0),
		ISNULL(initialprevision5,0) +   ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation.idacc AND VARIAZ.idupb = #budgetsituation.idupb AND rowkind = 20 ),0) 
																-  ISNULL((SELECT SUM(curramount5) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation.idacc  AND PREIMP.idupb = #budgetsituation.idupb AND rowkind IN (30)),0)	
	    FROM #budgetsituation 
		WHERE rowkind = 10 	   and accountkind <> 'C'
 end
 
--select * from #budgetsituation where rowkind in (1,2,7)
 
--select * from #budgetsituation where rowkind in(0, 1, 2)
delete from #budgetsituation where isnull(amount,0) =0 and isnull(amount2,0) =0  and isnull(amount3,0) =0  and isnull(amount4,0) =0  and isnull(amount5,0) =0 
			and isnull(initialprevision,0) =0 and isnull(initialprevision2,0) =0 and isnull(initialprevision3,0) =0 and isnull(initialprevision4,0) =0 and isnull(initialprevision5,0) =0 
			and isnull(availableprevision,0) =0 and isnull(availableprevision2,0) =0 and isnull(availableprevision3,0) =0 and isnull(availableprevision4,0) =0 and isnull(availableprevision5,0) =0 

CREATE TABLE #budgetsituation_compact
		(
 
		idacc 			varchar(38), 
		codeacc			varchar(50),
		accprintingorder varchar(50),
		account			varchar(150),
		codeupb			varchar(50),
		upbprintingorder varchar(50),
		upb				varchar(150),
		accountkind		char(1),
		idupb			varchar(36),
		rowkind			int,
		operationdate		datetime,
		operationkind		varchar(100),
		amount			decimal(19,2),
		amount2			decimal(19,2),
		amount3			decimal(19,2),
		amount4			decimal(19,2),
		amount5			decimal(19,2),
		curramount		decimal(19,2),
		curramount2		decimal(19,2),
		curramount3		decimal(19,2),
		curramount4		decimal(19,2),
		curramount5		decimal(19,2),
		initialprevision 	decimal(19,2),
		initialprevision2 	decimal(19,2),
		initialprevision3 	decimal(19,2),
		initialprevision4 	decimal(19,2),
		initialprevision5 	decimal(19,2),
		availableprevision	decimal(19,2),
		availableprevision2	decimal(19,2),
		availableprevision3	decimal(19,2),
		availableprevision4	decimal(19,2),
		availableprevision5	decimal(19,2) 			
		)

IF (@showupb ='S')
begin
	INSERT INTO #budgetsituation_compact
	(
	 
		idacc 			, 
		codeacc			,
		accprintingorder,
		account			,
		idupb			,
		codeupb			,
		upbprintingorder,
		upb				,
		rowkind			,
		operationkind	,
		amount			,
		amount2			,
		amount3			,
		amount4			,
		amount5			,
		curramount		,
		curramount2		,
		curramount3		,
		curramount4		,
		curramount5			,
		initialprevision 	,
		initialprevision2 	,
		initialprevision3 	,
		initialprevision4 	,
		initialprevision5 	,
		availableprevision	,
		availableprevision2	,
		availableprevision3	,
		availableprevision4	,
		availableprevision5	,
		accountkind		 	
	)
	select 
			B.idacc, 
			A.codeacc,	
			A.printingorder as accprintingorder,	
			A.title as account,
			B.idupb,
			U.codeupb,	U.printingorder as upbprintingorder,	U.title as upb,
			B.rowkind,B.operationkind,
			sum(B.amount) as amount,sum(B.amount2) as amount2,sum(B.amount3) as amount3,sum(B.amount4) as amount4,sum(B.amount5) as amount5,
			sum(B.curramount) as curramount,sum(B.curramount2) as curramount2,sum(B.curramount3) as curramount3,sum(B.curramount4) as curramount4,sum(B.curramount5) as curramount5,
			sum(B.initialprevision) as initialprevision,sum(B.initialprevision2) as initialprevision2,sum(B.initialprevision3) as initialprevision3,sum(B.initialprevision4) as initialprevision4,sum(B.initialprevision5) as initialprevision5,
			sum(B.availableprevision) as availableprevision,sum(B.availableprevision2) as availableprevision2,sum(B.availableprevision3) as availableprevision3,sum(B.availableprevision4) as availableprevision4,sum(B.availableprevision5) as availableprevision5,
			B.accountkind
	 from #budgetsituation B
	 join account A
		on B.idacc = A.idacc
	join upb U
		on U.idupb = B.idupb
	group by 
		B.idupb, 	U.codeupb, U.title,
		B.idacc,  
		A.codeacc,	
		A.printingorder,	
		A.title ,
		U.printingorder,
		B.rowkind,B.operationkind,B.accountkind
order by U.printingorder,		B.accountkind,  A.printingorder ,  B.rowkind
End


IF (@showupb ='N')
BEGIN
	declare 	@codeupb varchar(50)
	declare		@upb varchar(150)
	declare		@upbprintingorder varchar(50)
	declare		@ext_idupb varchar(50)

	if (@idupboriginal='%')
	begin
		set @codeupb= null
		set @upb= null
		set @upbprintingorder= null
		set @ext_idupb= null
	end
	else
	begin
		SET @upbprintingorder =
			(SELECT TOP 1 printingorder
			FROM upb
			WHERE idupb = @idupboriginal)
		SET  @upb =
			(SELECT TOP 1 title
			FROM upb
			WHERE idupb = @idupboriginal)
		SET  @ext_idupb =	@idupboriginal
		SET  @codeupb =
			(SELECT TOP 1 codeupb
			FROM upb	
			WHERE idupb = @idupboriginal)
	end
	INSERT INTO #budgetsituation_compact
	(
	 
		idacc 			, 
		codeacc			,
		accprintingorder,
		account			,
		idupb			,
		codeupb			,
		upbprintingorder,
		upb				,
		rowkind			,
		operationkind	,
		amount			,
		amount2			,
		amount3			,
		amount4			,
		amount5			,
		curramount		,
		curramount2		,
		curramount3		,
		curramount4		,
		curramount5			,
		initialprevision 	,
		initialprevision2 	,
		initialprevision3 	,
		initialprevision4 	,
		initialprevision5 	,
		availableprevision	,
		availableprevision2	,
		availableprevision3	,
		availableprevision4	,
		availableprevision5	,
		accountkind		 	
	)
	select 
			B.idacc, 
			A.codeacc,	
			A.printingorder as accprintingorder,	
			A.title as account,
			@ext_idupb as idupb,
			@codeupb as codeupb,	@upbprintingorder as upbprintingorder,	@upb as upb,
			B.rowkind,	B.operationkind,
			sum(B.amount) as amount,sum(B.amount2) as amount2,sum(B.amount3) as amount3,sum(B.amount4) as amount4,sum(B.amount5) as amount5,
			sum(B.curramount) as curramount,sum(B.curramount2) as curramount2,sum(B.curramount3) as curramount3,sum(B.curramount4) as curramount4,sum(B.curramount5) as curramount5,
			sum(B.initialprevision) as initialprevision,sum(B.initialprevision2) as initialprevision2,sum(B.initialprevision3) as initialprevision3,sum(B.initialprevision4) as initialprevision4,sum(B.initialprevision5) as initialprevision5,
			sum(B.availableprevision) as availableprevision,sum(B.availableprevision2) as availableprevision2,sum(B.availableprevision3) as availableprevision3,sum(B.availableprevision4) as availableprevision4,sum(B.availableprevision5) as availableprevision5,
			B.accountkind
	 from #budgetsituation B
	 join account A
		on B.idacc = A.idacc
	left outer join account PARENT 
		on PARENT.idacc = SUBSTRING(A.idacc, 1, @lenminlevel)
	group by 
		B.idacc, 
		A.codeacc,	
		A.printingorder,	
		A.title ,
		--U.printingorder,
		B.rowkind,B.operationkind,B.accountkind
	order by /*U.printingorder,*/		B.accountkind,  A.printingorder ,  B.rowkind

INSERT INTO #budgetsituation_compact
 (
 		idacc 			, 
		codeacc			,
		accprintingorder,
		account			,
		idupb			,
		codeupb			,
		upbprintingorder,
		upb				,
		rowkind			,
		operationkind	,
		amount			,
		amount2			,
		amount3			,
		amount4			,
		amount5			,
		curramount		,
		curramount2		,
		curramount3		,
		curramount4		,
		curramount5			,
		initialprevision 	,
		initialprevision2 	,
		initialprevision3 	,
		initialprevision4 	,
		initialprevision5 	,
		availableprevision	,
		availableprevision2	,
		availableprevision3	,
		availableprevision4	,
		availableprevision5	,
		accountkind		 	
 )
 SELECT
  
		#budgetsituation_compact.idacc, 
		#budgetsituation_compact.codeacc,	
		#budgetsituation_compact.accprintingorder,	
		#budgetsituation_compact.account,
		@ext_idupb as idupb,
		@codeupb as codeupb,	@upbprintingorder as upbprintingorder,	@upb as upb,
		7,	'Prev. disponibile Budget Costi',	

		0 as amount,0 as amount2,0 as amount3, 0 as amount4, 0 as amount5,
		0 as curramount, 0 as curramount2, 0 as curramount3,0 as curramount4, 0 as curramount5,
		0 as initialprevision, 0 as initialprevision2, 0 as initialprevision3,0 as initialprevision4, 0 as initialprevision5,
		
		ISNULL(initialprevision,0) +   ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 2 ),0) 
																	-	ISNULL((SELECT SUM(curramount) 
													FROM #budgetsituation PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind IN (3)),0),
		ISNULL(initialprevision2,0) +   ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount2) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND  rowkind IN (3)),0),
		ISNULL(initialprevision3,0) +   ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount3) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind IN (3)),0),
		ISNULL(initialprevision4,0) +   ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 2 ),0) 
																	-  ISNULL((SELECT SUM(curramount4) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind IN (3)),0),
		ISNULL(initialprevision5,0) +   ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 2 ),0) 
																-  ISNULL((SELECT SUM(curramount5) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind IN (3)),0),
		#budgetsituation_compact.accountkind	
	    
		FROM #budgetsituation_compact 
		WHERE #budgetsituation_compact.rowkind = 1 and #budgetsituation_compact.accountkind= 'C'
 


--- calcolo previsione disponibile ricavi
 
INSERT INTO #budgetsituation_compact
 (
 		idacc 			, 
		codeacc			,
		accprintingorder,
		account			,
		idupb			,
		codeupb			,
		upbprintingorder,
		upb				,
		rowkind			,
		operationkind	,
		amount			,
		amount2			,
		amount3			,
		amount4			,
		amount5			,
		curramount		,
		curramount2		,
		curramount3		,
		curramount4		,
		curramount5			,
		initialprevision 	,
		initialprevision2 	,
		initialprevision3 	,
		initialprevision4 	,
		initialprevision5 	,
		availableprevision	,
		availableprevision2	,
		availableprevision3	,
		availableprevision4	,
		availableprevision5	,
		accountkind		 	
 )
 SELECT
  
		#budgetsituation_compact.idacc, 
		#budgetsituation_compact.codeacc,	
		#budgetsituation_compact.accprintingorder,	
		#budgetsituation_compact.account,
		@ext_idupb as idupb,
		@codeupb as codeupb,	@upbprintingorder as upbprintingorder,	@upb as upb,
		70,	'Prev. disponibile Budget Ricavi',	

		0 as amount,0 as amount2,0 as amount3, 0 as amount4, 0 as amount5,
		0 as curramount, 0 as curramount2, 0 as curramount3,0 as curramount4, 0 as curramount5,
		0 as initialprevision, 0 as initialprevision2, 0 as initialprevision3,0 as initialprevision4, 0 as initialprevision5,
		ISNULL(initialprevision,0) +   ISNULL((SELECT SUM(amount) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind = 20 ),0) 
																	-	ISNULL((SELECT SUM(curramount) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind IN (30)),0),
		ISNULL(initialprevision2,0) +   ISNULL((SELECT SUM(amount2) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount2) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND  rowkind IN (30)),0),
		ISNULL(initialprevision3,0) +   ISNULL((SELECT SUM(amount3) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount3) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind IN (30)),0),
		ISNULL(initialprevision4,0) +   ISNULL((SELECT SUM(amount4) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind = 20 ),0) 
																	-  ISNULL((SELECT SUM(curramount4) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind IN (30)),0),
		ISNULL(initialprevision5,0) +   ISNULL((SELECT SUM(amount5) 
													FROM #budgetsituation_compact VARIAZ 
													WHERE VARIAZ.idacc = #budgetsituation_compact.idacc AND ISNULL(VARIAZ.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb)  AND rowkind = 20 ),0) 
																-  ISNULL((SELECT SUM(curramount5) 
													FROM #budgetsituation_compact PREIMP 
													WHERE PREIMP.idacc = #budgetsituation_compact.idacc AND ISNULL(PREIMP.idupb,@fixedidupb) = ISNULL(#budgetsituation_compact.idupb,@fixedidupb) AND rowkind IN (30)),0),
		#budgetsituation_compact.accountkind		
	    FROM #budgetsituation_compact 
		WHERE #budgetsituation_compact.rowkind = 10 	   and #budgetsituation_compact.accountkind <> 'C'

END

-- select * from #budgetsituation_compact

CREATE TABLE #output
		(
		ayear				int,
		idacc 				varchar(38), 
		codeacc				varchar(50),
		accprintingorder	varchar(50),
		account				varchar(150),
		codeupb				varchar(50),
		upbprintingorder	varchar(50),
		upb					varchar(150),
		idupb				varchar(36),
		accountkind			char(1),
		init_amount			decimal(19,2),
		init_amount2		decimal(19,2),
		init_amount3		decimal(19,2),
		init_amount4		decimal(19,2),
		init_amount5		decimal(19,2),
		var_amount			decimal(19,2),
		var_amount2			decimal(19,2),
		var_amount3			decimal(19,2),
		var_amount4			decimal(19,2),
		var_amount5			decimal(19,2),
		fase1_amount		decimal(19,2),
		fase1_amount2		decimal(19,2),
		fase1_amount3		decimal(19,2),
		fase1_amount4		decimal(19,2),
		fase1_amount5		decimal(19,2),
		fase2_amount		decimal(19,2),
		fase2_amount2		decimal(19,2),
		fase2_amount3		decimal(19,2),
		fase2_amount4		decimal(19,2),
		fase2_amount5		decimal(19,2),
		available_amount	decimal(19,2),
		available_amount2	decimal(19,2),
		available_amount3	decimal(19,2),
		available_amount4	decimal(19,2),
		available_amount5	decimal(19,2) 			
		)
INSERT INTO #output
(		ayear				,
		idacc 				, 
		codeacc				,
		accprintingorder	,
		account				,
		idupb				,
		codeupb				,
		upbprintingorder	,
		upb					,
		accountkind			,
		init_amount			,
		var_amount			,
		fase1_amount		,
		fase2_amount		,
		available_amount	
		)
SELECT 
			@ayear,
			B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind,
			SUM(CASE  WHEN B.rowkind IN (1,10) THEN B.initialprevision ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (2,20) THEN B.amount ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (3,30) THEN B.curramount ELSE 0  END),
			SUM(CASE  WHEN B.rowkind IN (5,50) THEN B.curramount ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (7,70) THEN B.availableprevision ELSE 0 END)
FROM #budgetsituation_compact B
GROUP BY 	B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind

INSERT INTO #output
(		ayear				,
		idacc 				, 
		codeacc				,
		accprintingorder	,
		account				,
		idupb				,
		codeupb				,
		upbprintingorder	,
		upb					,
		accountkind			,
		init_amount2		,
		var_amount2			,
		fase1_amount2		,
		fase2_amount2		,
		available_amount2	
		)
SELECT 
			@ayear +1,
			B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind,
			SUM(CASE  WHEN B.rowkind IN (1,10) THEN B.initialprevision2 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (2,20) THEN B.amount2 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (3,30) THEN B.curramount2 ELSE 0  END),
			SUM(CASE  WHEN B.rowkind IN (5,50) THEN B.curramount2 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (7,70) THEN B.availableprevision2 ELSE 0 END)
FROM #budgetsituation_compact B
GROUP BY 	B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind


INSERT INTO #output
(		ayear				,
		idacc 				, 
		codeacc				,
		accprintingorder	,
		account				,
		idupb				,
		codeupb				,
		upbprintingorder	,
		upb					,
		accountkind			,
		init_amount3		,
		var_amount3			,
		fase1_amount3		,
		fase2_amount3		,
		available_amount3	
		)
SELECT 
			@ayear +2,
			B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind,
			SUM(CASE  WHEN B.rowkind IN (1,10) THEN B.initialprevision3 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (2,20) THEN B.amount3 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (3,30) THEN B.curramount3 ELSE 0  END),
			SUM(CASE  WHEN B.rowkind IN (5,50) THEN B.curramount3 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (7,70) THEN B.availableprevision3 ELSE 0 END)
FROM #budgetsituation_compact B
GROUP BY 	B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind


INSERT INTO #output
(		ayear				,
		idacc 				, 
		codeacc				,
		accprintingorder	,
		account				,
		idupb				,
		codeupb				,
		upbprintingorder	,
		upb					,
		accountkind			,
		init_amount4		,
		var_amount4			,
		fase1_amount4		,
		fase2_amount4		,
		available_amount4	
		)
SELECT 
			@ayear +3,
			B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind,
			SUM(CASE  WHEN B.rowkind IN (1,10) THEN B.initialprevision4 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (2,20) THEN B.amount4 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (3,30) THEN B.curramount4 ELSE 0  END),
			SUM(CASE  WHEN B.rowkind IN (5,50) THEN B.curramount4 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (7,70) THEN B.availableprevision4 ELSE 0 END)
FROM #budgetsituation_compact B
GROUP BY 	B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind



INSERT INTO #output
(		ayear				,
		idacc 				, 
		codeacc				,
		accprintingorder	,
		account				,
		idupb				,
		codeupb				,
		upbprintingorder	,
		upb					,
		accountkind			,
		init_amount5		,
		var_amount5			,
		fase1_amount5		,
		fase2_amount5		,
		available_amount5	
		)
SELECT 
			@ayear +4,
			B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind,
			SUM(CASE  WHEN B.rowkind IN (1,10) THEN B.initialprevision5 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (2,20) THEN B.amount5 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (3,30) THEN B.curramount5 ELSE 0  END),
			SUM(CASE  WHEN B.rowkind IN (5,50) THEN B.curramount5 ELSE 0 END),
			SUM(CASE  WHEN B.rowkind IN (7,70) THEN B.availableprevision5 ELSE 0 END)
FROM #budgetsituation_compact B
GROUP BY 	B.idacc, 
			B.codeacc,	
			B.accprintingorder,	
			B.account,
			B.idupb,
			B.codeupb,	B.upbprintingorder,	B.upb,
			B.accountkind

select * from #output ORDER BY upbprintingorder, accountkind,  accprintingorder,  ayear
END
go

 
