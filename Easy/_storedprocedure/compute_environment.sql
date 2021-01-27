
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_environment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_environment]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--compute_environment 2017,'bianco','1700010012',1
--compute_environment 2017,'nino'
--setuser 'amm'

CREATE  PROCEDURE compute_environment
(
	@ayear int,
	@idcustomuser varchar(50),
	@idflowchart varchar(34)= null,
	@ndetail int = null
)
AS BEGIN

	if (@idflowchart is null) begin
		select top (1) @idflowchart=  FU.idflowchart, 
					@ndetail=FU.ndetail
				from flowchart F 
				join flowchartuser FU ON F.idflowchart=FU.idflowchart
				where FU.idcustomuser = @idcustomuser and
				    (FU.start is null or FU.start <= getdate()) and
					(FU.stop is null or FU.stop >= getdate()) and
					(F.ayear = @ayear)
				ORDER BY FU.flagdefault DESC
		print @idflowchart
		print @ndetail
	end

   if (@idflowchart is not null and @ndetail is null) begin
		select top (1) @ndetail=FU.ndetail
				from flowchart F 
				join flowchartuser FU ON F.idflowchart=@idflowchart
				where FU.idcustomuser = @idcustomuser and
				    (FU.start is null or FU.start <= getdate()) and
					(FU.stop is null or FU.stop >= getdate()) and
					(F.ayear = @ayear)
				ORDER BY FU.flagdefault DESC
		print @idflowchart
		print @ndetail
	end

declare @codeflowchart varchar(100)
select  @codeflowchart= codeflowchart from flowchart where idflowchart=@idflowchart

declare @fin_kind tinyint
declare @incomephase tinyint
declare @itinerationphase tinyint
declare @deferredexpensephase char(1)
declare @deferredincomephase  char(1)
declare @appropriationphase tinyint
declare @assessmentphase tinyint
declare @flagcredit char(1)
declare @idsortingkind1 int
declare @idsortingkind2 int
declare @idsortingkind3 int
declare @titlesortingkind1 varchar(200)
declare @titlesortingkind2 varchar(200)
declare @titlesortingkind3 varchar(200)
declare @codesorkind_siopespese varchar(20)
declare @codesorkind_siopeentrate varchar(20)


declare @flagproceeds char(1)

select  @fin_kind= fin_kind, @flagcredit=upper(flagcredit), @flagproceeds=upper(flagproceeds),
		@incomephase=incomephase,@itinerationphase= config.expensephase,
		@deferredexpensephase=deferredexpensephase,	@deferredincomephase =deferredincomephase,
		@appropriationphase=appropriationphasecode,@assessmentphase =assessmentphasecode,
		@idsortingkind1=idsortingkind1,@idsortingkind2=idsortingkind2,@idsortingkind3=idsortingkind3,
		@titlesortingkind1=sortingkind1.description, 
		@titlesortingkind2=sortingkind2.description,
		@titlesortingkind3=sortingkind3.description
	from config 
	left outer join sortingkind sortingkind1 on sortingkind1.idsorkind=config.idsortingkind1
	left outer join sortingkind sortingkind2 on sortingkind2.idsorkind=config.idsortingkind2
	left outer join sortingkind sortingkind3 on sortingkind3.idsorkind=config.idsortingkind3
	where ayear=@ayear

select	@codesorkind_siopespese = codesorkind_siopespese,
		@codesorkind_siopeentrate = codesorkind_siopeentrate
from siopekind
where ayear = @ayear


SET @codesorkind_siopespese = isnull(@codesorkind_siopespese,'07U_SIOPE')
set @codesorkind_siopeentrate = isnull(@codesorkind_siopeentrate, '07E_SIOPE')

declare @filterrule varchar(200)
set @filterrule = case 
						when @fin_kind=1 then '(flag_comp=''S'')' 
						when @fin_kind=2 then '(flag_cash=''S'')'
						when @fin_kind=3 then '(flag_both=''S'')'
					end
if (@flagcredit='N') begin
	set @filterrule= @filterrule+'AND(flag_credit=''N'')'
end 
if (@flagproceeds='N') begin
	set @filterrule= @filterrule+'AND(flag_proceeds=''N'')'
end 

declare @maxincomephase tinyint
select @maxincomephase = max(nphase) from incomephase
declare @maxexpensephase tinyint
select @maxexpensephase = max(nphase) from expensephase

declare @upb_with_description char(1)
declare @account_with_description char(1)
declare @fin_with_description char(1)
declare @inv_with_description char(1)

declare @expensefinphase tinyint
declare @expenseregphase tinyint
declare @incomefinphase tinyint
declare @incomeregphase tinyint

declare @idsortingkind01 int
declare @idsortingkind02 int
declare @idsortingkind03 int
declare @idsortingkind04 int
declare @idsortingkind05 int
declare @titlesortingkind01 varchar(200)
declare @titlesortingkind02 varchar(200)
declare @titlesortingkind03 varchar(200)
declare @titlesortingkind04 varchar(200)
declare @titlesortingkind05 varchar(200)

declare @asFilter01 char(1)
declare @asFilter02 char(1)
declare @asFilter03 char(1)
declare @asFilter04 char(1)
declare @asFilter05 char(1)

declare @all_value01 char(1)
declare @all_value02 char(1)
declare @all_value03 char(1)
declare @all_value04 char(1)
declare @all_value05 char(1)

declare @withchilds_01 char(1)
declare @withchilds_02 char(1)
declare @withchilds_03 char(1)
declare @withchilds_04 char(1)
declare @withchilds_05 char(1)


select @expensefinphase=expensefinphase,
		@expenseregphase=expenseregphase,
		@incomefinphase=incomefinphase,
		@incomeregphase=incomeregphase,
		@upb_with_description= UPPER(ISNULL(tree_upb_withdescr,'N')),
		@account_with_description = 'N', --UPPER(ISNULL(tree_account_withdescr,'N')),
		@fin_with_description = 'N', --UPPER(ISNULL(tree_fin_withdescr,'N')),
		@inv_with_description= 'N', --UPPER(ISNULL(tree_inv_withdescr,'N')),
		@idsortingkind01=uniconfig.idsorkind01, @idsortingkind02=uniconfig.idsorkind02, @idsortingkind03=uniconfig.idsorkind03, 
				@idsortingkind04=uniconfig.idsorkind04,@idsortingkind05=uniconfig.idsorkind05,	
				@titlesortingkind01=sortingkind1.description, 
		@titlesortingkind02=sortingkind2.description,
		@titlesortingkind03=sortingkind3.description,
		@titlesortingkind04=sortingkind4.description, 
		@titlesortingkind05=sortingkind5.description,
		@asFilter01 = isnull(uniconfig.sorkind01asfilter,'N'),	
		@asFilter02 = isnull(uniconfig.sorkind02asfilter,'N'),	
		@asFilter03 = isnull(uniconfig.sorkind03asfilter,'N'),	
		@asFilter04 = isnull(uniconfig.sorkind04asfilter,'N'),	
		@asFilter05 = isnull(uniconfig.sorkind05asfilter,'N')	
		from uniconfig
		left outer join sortingkind sortingkind1 on sortingkind1.idsorkind=uniconfig.idsorkind01
		left outer join sortingkind sortingkind2 on sortingkind2.idsorkind=uniconfig.idsorkind02
		left outer join sortingkind sortingkind3 on sortingkind3.idsorkind=uniconfig.idsorkind03
		left outer join sortingkind sortingkind4 on sortingkind4.idsorkind=uniconfig.idsorkind04
		left outer join sortingkind sortingkind5 on sortingkind5.idsorkind=uniconfig.idsorkind05

declare @finusablelevel tinyint
select @finusablelevel=MIN(nlevel) from finlevel where ayear=@ayear and ((flag & 2)<>0)

declare @accountusablelevel  char(1)
select @accountusablelevel=MIN(nlevel) from accountlevel where ayear=@ayear and (flagusable='S')

declare @idsor01 int
declare @idsor02 int
declare @idsor03 int
declare @idsor04 int
declare @idsor05 int

select	@idsor01=idsor01, @all_value01=all_sorkind01, @withchilds_01= sorkind01_withchilds,
		@idsor02=idsor02, @all_value02=all_sorkind02, @withchilds_02= sorkind02_withchilds,
		@idsor03=idsor03, @all_value03=all_sorkind03, @withchilds_03= sorkind03_withchilds,
		@idsor04=idsor04, @all_value04=all_sorkind04, @withchilds_04= sorkind04_withchilds,
		@idsor05=idsor05, @all_value05=all_sorkind05, @withchilds_05= sorkind05_withchilds
	from flowchartuser where idflowchart=@idflowchart and ndetail=@ndetail and idcustomuser= @idcustomuser

declare  @defaultdepmail varchar(300)

 select @defaultdepmail =coalesce(  (select email from sorting where idsor = @idsor01), 
						  (select email from sorting where idsor = @idsor02),
                      (select email from sorting where idsor = @idsor03),
                      (select email from sorting where idsor = @idsor04), 
                      (select email from sorting where idsor = @idsor05) 
                     )


select  @idflowchart as idflowchart, @ndetail as ndetail,
		@codeflowchart as codeflowchart, @fin_kind as fin_kind, @flagcredit as flagcredit, @flagproceeds as flagproceeds,
		@filterrule as filterrule,@filterrule as Cfilterrule, @incomephase as incomephase,@itinerationphase as itinerationphase,
			@deferredexpensephase as deferredexpensephase,@deferredincomephase  as deferredincomephase,
			@appropriationphase as appropriationphase, @assessmentphase as assessmentphase ,
			@idsortingkind1 as idsortingkind1, @idsortingkind2 as idsortingkind2, @idsortingkind3 as idsortingkind3,
			@titlesortingkind1 as titlesortingkind1, @titlesortingkind2 as titlesortingkind2, @titlesortingkind3 as titlesortingkind3,
			@maxincomephase as maxincomephase,@maxexpensephase as maxexpensephase,
			@expensefinphase as expensefinphase, @expenseregphase as expenseregphase,
			@incomefinphase as incomefinphase, @incomeregphase as incomeregphase,
			@finusablelevel as finusablelevel, @accountusablelevel as accountusablelevel,
			@idsortingkind01 as idsortingkind01, @idsortingkind02 as idsortingkind02, @idsortingkind03 as idsortingkind03,
			 @idsortingkind04 as idsortingkind04, @idsortingkind05 as idsortingkind05,
			@titlesortingkind01 as titlesortingkind01, @titlesortingkind02 as titlesortingkind02, @titlesortingkind03 as titlesortingkind03,
			 @titlesortingkind04 as titlesortingkind04, @titlesortingkind05 as titlesortingkind05,
			 @itinerationphase as mandatephase, @incomephase as estimatephase,
			 @maxexpensephase as invoiceexpensephase, @maxincomephase as invoiceincomephase,
			 isnull(@idsor01,0) as idsor01, isnull(@idsor02,0) as idsor02, isnull(@idsor03,0) as idsor03,
					 isnull(@idsor04,0) as idsor04, isnull(@idsor05,0) as idsor05,
			@defaultdepmail as defaultdepmail,
			@codesorkind_siopespese as codesorkind_siopespese ,	@codesorkind_siopeentrate as codesorkind_siopeentrate
			









declare @allvar varchar(30)
set @allvar=null

declare @withchilds char(1)
set @withchilds='N'

declare @all_value char(1)
set @all_value='N'

declare @idsor_value int
declare @varname varchar(30)



declare @cond varchar(1000)
set @cond=''

declare @idvar varchar(30)

declare @idlist varchar(max)
set @idlist=''


CREATE TABLE #myouttable
(	variablename varchar(200),
	kind char(1),
	mustquote char(1),
	value text
)

declare @noflowchart char (1)
set @noflowchart='N'
IF (@ndetail IS NULL OR @ndetail = 0) SET @noflowchart='S'

if (@noflowchart='S') begin
	select * from #myouttable
	drop table #myouttable
	return 
end

insert into #myouttable (variablename, kind, value) select variablename, kind, value	
	 from userenvironment where idcustomuser=@idcustomuser and kind='K'
--le costanti sono già a posto (kind=K)

--kind=S sono le stored procedures, distinguiamo le compute_set dalla compute_set_withndet
insert into #myouttable (variablename, kind, value,mustquote) 
	select variablename, kind,  
		case when (exists (SELECT *
						FROM flowchartrestrictedfunction FF
						JOIN restrictedfunction RF		ON RF.idrestrictedfunction = FF.idrestrictedfunction
						WHERE FF.idflowchart = @idflowchart	AND RF.variablename = userenvironment.variablename)) 
					then 'S' 
					else 'N' 
		end,'S'
	from userenvironment 
	where idcustomuser=@idcustomuser and kind='S' and value like 'compute_set'




DECLARE @nrowfound int

--fare gestione idsor01-05
set @allvar=null
set @all_value='N'
set @withchilds='N'

--cond_man  
set @varname='cond_man'
set @allvar ='all_man'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename = @allvar)
end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')					
	end
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idman is null OR (idman in (<%usr[list_man]%>)))','N')
				
	end

set @varname='cond_mandatekind'
set @allvar ='all_mandatekind'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
			(SELECT COUNT(*)
			FROM flowchartrestrictedfunction FF
			JOIN restrictedfunction RF
				ON RF.idrestrictedfunction = FF.idrestrictedfunction
			WHERE FF.idflowchart = @idflowchart
				AND RF.variablename = @allvar)
end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')	
		end					
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idmankind is null OR (idmankind in (<%usr[list_mandatekind]%>)))','N')				
	end


set @varname='cond_estimatekind'
set @allvar ='all_estimatekind'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
			(SELECT COUNT(*)
			FROM flowchartrestrictedfunction FF
			JOIN restrictedfunction RF
				ON RF.idrestrictedfunction = FF.idrestrictedfunction
			WHERE FF.idflowchart = @idflowchart
				AND RF.variablename = @allvar)
end

IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
		end		
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idestimkind is null OR (idestimkind in (<%usr[list_estimatekind]%>)))','N')
					
	end


set @varname='cond_invoicekind'
set @allvar ='all_invoicekind'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
			(SELECT COUNT(*)
			FROM flowchartrestrictedfunction FF
			JOIN restrictedfunction RF
				ON RF.idrestrictedfunction = FF.idrestrictedfunction
			WHERE FF.idflowchart = @idflowchart
				AND RF.variablename = @allvar)
end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
		end		
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idinvkind is null OR (idinvkind in (<%usr[list_invoicekind]%>)))','N')				
	end



set @varname='cond_fin'
set @allvar ='all_fin'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
			(SELECT COUNT(*)
			FROM flowchartrestrictedfunction FF
			JOIN restrictedfunction RF
				ON RF.idrestrictedfunction = FF.idrestrictedfunction
			WHERE FF.idflowchart = @idflowchart
				AND RF.variablename = @allvar)
end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
	end
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idfin is null OR (idfin in (<%usr[list_mfin]%>)))','N')		
	end

set @varname='cond_upb'
set @allvar ='all_upb'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename = @allvar)
end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
		end
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idupb is null OR (idupb in (<%usr[list_mupb]%>)))','N')					
	end

set @varname='cond_pettycash'
set @allvar ='all_pettycash'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename = @allvar)
	end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
		end				
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idpettycash is null OR (idpettycash in (<%usr[list_pettycash]%>)))','N')				
	end


set @varname='cond_authmodel'
set @allvar ='all_authmodel'
if (@noflowchart = 'S')
  set @nrowfound=1
else begin
	SET @nrowfound =
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename = @allvar)
	end
	IF (@nrowfound > 0) begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')
		END	
	else begin
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(idauthmodel is null OR (idauthmodel in (<%usr[list_authmodel]%>)))','N')					
	end



declare @asFilter char(1)

set @varname = 'cond_sor01' 
BEGIN	
	set @idlist=''
	set @idvar='idsor01'
	set @idsor_value = @idsor01
	set @all_value	 = @all_value01
	set @asFilter	 = @asFilter01
	set @withchilds  = @withchilds_01
	IF (@ndetail IS NULL OR @ndetail = 0)BEGIN
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')			
	END
	ELSE BEGIN				
		if (@idsor_value is null or @all_value='S' or @asFilter='N') BEGIN 
			INSERT INTO  #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S','AND(1=1)','N')					
		END
		ELSE BEGIN
				if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 ) BEGIN
					set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
				END  
				ELSE BEGIN
					select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
					set @idlist='('+substring(@idlist,2,20000)+')'
					set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
				END
				INSERT INTO #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S',@cond,'N')				
		END
	END	
END

set @varname = 'cond_sor02' 
BEGIN	
	set @idlist=''
	set @idvar='idsor02'
	set @idsor_value = @idsor02
	set @all_value	 = @all_value02
	set @asFilter	 = @asFilter02
	set @withchilds  = @withchilds_02
	IF (@ndetail IS NULL OR @ndetail = 0)BEGIN
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')			
	END
	ELSE BEGIN				
		if (@idsor_value is null or @all_value='S' or @asFilter='N') BEGIN 
			INSERT INTO  #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S','AND(1=1)','N')					
		END
		ELSE BEGIN
				if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 ) BEGIN
					set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
				END  
				ELSE BEGIN
					select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
					set @idlist='('+substring(@idlist,2,20000)+')'
					set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
				END
				INSERT INTO #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S',@cond,'N')				
		END
	END	
END

set @varname = 'cond_sor03' 
BEGIN	
	set @idlist=''
	set @idvar='idsor03'
	set @idsor_value = @idsor03
	set @all_value	 = @all_value03
	set @asFilter	 = @asFilter03
	set @withchilds  = @withchilds_03
	IF (@ndetail IS NULL OR @ndetail = 0)BEGIN
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')			
	END
	ELSE BEGIN				
		if (@idsor_value is null or @all_value='S' or @asFilter='N') BEGIN 
			INSERT INTO  #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S','AND(1=1)','N')					
		END
		ELSE BEGIN
				if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 ) BEGIN
					set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
				END  
				ELSE BEGIN
					select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
					set @idlist='('+substring(@idlist,2,20000)+')'
					set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
				END
				INSERT INTO #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S',@cond,'N')				
		END
	END	
END


set @varname = 'cond_sor04' 
BEGIN	
	set @idlist=''
	set @idvar='idsor04'
	set @idsor_value = @idsor04
	set @all_value	 = @all_value04
	set @asFilter	 = @asFilter04
	set @withchilds  = @withchilds_04
	IF (@ndetail IS NULL OR @ndetail = 0)BEGIN
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')			
	END
	ELSE BEGIN				
		if (@idsor_value is null or @all_value='S' or @asFilter='N') BEGIN 
			INSERT INTO  #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S','AND(1=1)','N')					
		END
		ELSE BEGIN
				if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 ) BEGIN
					set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
				END  
				ELSE BEGIN
					select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
					set @idlist='('+substring(@idlist,2,20000)+')'
					set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
				END
				INSERT INTO #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S',@cond,'N')				
		END
	END	
END


set @varname = 'cond_sor05' 
BEGIN	
	set @idlist=''
	set @idvar='idsor05'
	set @idsor_value = @idsor05
	set @all_value	 = @all_value05
	set @asFilter	 = @asFilter05
	set @withchilds  = @withchilds_05
	IF (@ndetail IS NULL OR @ndetail = 0)BEGIN
		INSERT INTO #myouttable(variablename, kind, value,mustquote)
			 VALUES(@varname,'S','AND(1=1)','N')			
	END
	ELSE BEGIN				
		if (@idsor_value is null or @all_value='S' or @asFilter='N') BEGIN 
			INSERT INTO  #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S','AND(1=1)','N')					
		END
		ELSE BEGIN
				if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 ) BEGIN
					set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
				END  
				ELSE BEGIN
					select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
					set @idlist='('+substring(@idlist,2,20000)+')'
					set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
				END
				INSERT INTO #myouttable(variablename, kind, value,mustquote)
				 VALUES(@varname,'S',@cond,'N')				
		END
	END	
END

--kind = C sono l'sql dinamico
	--list_authmodel
	--( SELECT idauthmodel FROM flowchartauthmodel WHERE idflowchart IN ('<%sys[idflowchart]%>') UNION  SELECT '0')
	set @idlist='''0'''
	select @idlist = @idlist+','''+replace(convert(varchar(30),idauthmodel),'''','''''')+'''' from flowchartauthmodel where idflowchart=@idflowchart
	INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_authmodel','S',@idlist,'N')	

	--list_estimatekind
	--(SELECT idestimkind  FROM flowchartestimatekind WHERE idflowchart = '<%sys[idflowchart]%>' UNION SELECT '') 
	set @idlist=''''''
	select @idlist = @idlist+','+''''+replace(
		convert(varchar(30),idestimkind),'''','''''' )+'''' from flowchartestimatekind where idflowchart=@idflowchart
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_estimatekind','S',@idlist,'N')	

	--list_invoicekind
	--(SELECT idinvkind  FROM flowchartinvoicekind WHERE idflowchart = '<%sys[idflowchart]%>' UNION SELECT 0) 
	declare @list_invoicekind varchar(max)
	set @list_invoicekind='0'
	select @list_invoicekind = @list_invoicekind+','+replace(
		convert(varchar(30),idinvkind),'''','''''' ) from flowchartinvoicekind where idflowchart=@idflowchart
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_invoicekind','S',@list_invoicekind,'N')	


	--list_man
	declare @list_man varchar(max)
	set @list_man='0'
		

	select @list_man = @list_man+','+ convert(varchar(30),q.idman)
			FROM (select distinct T.idman from
			(SELECT idman FROM flowchartmanager WHERE idflowchart = @idflowchart
				UNION
			 SELECT MS.idman from managersorting MS  
					join flowchartuser FU on MS.idsor in (FU.idsor01,FU.idsor02,FU.idsor03,FU.idsor04,FU.idsor05)
					where FU.idflowchart= @idflowchart AND FU.ndetail = @ndetail AND FU.idcustomuser = @idcustomuser
				UNION
			SELECT M.idman from manager M
				join flowchartuser FU on (M.idsor01=FU.idsor01)
                                OR (M.idsor02=FU.idsor02)
                                OR (M.idsor03=FU.idsor03)
                                OR (M.idsor04=FU.idsor04)
                                OR (M.idsor05=FU.idsor05)
				where FU.idflowchart= @idflowchart
                        AND FU.ndetail = @ndetail
						AND FU.idcustomuser = @idcustomuser
			) as t) as q
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_man','S',@list_man,'N')	


	--list_mandatekind
	--(SELECT idmankind FROM flowchartmandatekind WHERE idflowchart = '<%sys[idflowchart]%>' UNION SELECT '') 
	set @idlist=''''''
	select @idlist = @idlist+','+''''+replace(
		convert(varchar(30),idmankind),'''','''''' )+'''' from flowchartmandatekind where idflowchart=@idflowchart
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_mandatekind','S',@idlist,'N')	
	
	--list_pettycash
	--(SELECT idpettycash FROM flowchartpettycash WHERE idflowchart = '<%sys[idflowchart]%>' UNION SELECT 0) 
	set @idlist='0'
	select @idlist = @idlist+','+convert(varchar(30),idpettycash)  from flowchartpettycash where idflowchart=@idflowchart
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_pettycash','S',@idlist,'N')	


	--list_ivaregisterkind
	declare @subq nvarchar(max)
	declare @cmd nvarchar(max)
	--( SELECT idivaregisterkind FROM invoicekindregisterkind WHERE idinvkind IN (<%usr[list_invoicekind]%>) UNION SELECT '0')
	set @subq = '( SELECT idivaregisterkind FROM invoicekindregisterkind WHERE idinvkind IN ('+@list_invoicekind+') )'
	set @cmd = 'set @idlist=''0''; select @idlist = @idlist+'',''+ convert(varchar(30),T.idivaregisterkind)  from ( '+
		' select distinct idivaregisterkind from invoicekindregisterkind where idinvkind IN '+@subq+') as T'
	exec SP_EXECUTESQL  @cmd, @Params = N'@idlist varchar(max) OUTPUT',@idlist=@idlist OUTPUT
	INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_ivaregisterkind','S',@idlist,'N')	

	--list_mfin
	set @subq = '(SELECT idchild as idfin
					FROM flowchartfin 
					JOIN finlink	ON finlink.idparent = flowchartfin.idfin
					WHERE idflowchart = @idflowchart
				UNION
					SELECT idparent as idfin
					FROM flowchartfin 
					JOIN finlink	ON finlink.idchild = flowchartfin.idfin
					WHERE idflowchart = @idflowchart
				UNION
					SELECT idfin FROM finusable 
						WHERE finusable.idman IN ('+@list_man+')
						AND  ayear = @ayear
				UNION 
					SELECT idparent  as idfin
					FROM finusable
					JOIN finlink ON finlink.idchild = finusable.idfin 
					WHERE finusable.idman IN ('+@list_man+')
					AND  finusable.ayear = @ayear			
			)'
	set @cmd = 'set @idlist=''0''; select @idlist = @idlist+'',''+ convert(varchar(30),Q.idfin)  from  '+
			' (select distinct T.idfin from '+@subq+' as T) as Q'
	exec SP_EXECUTESQL  @cmd, @Params = N'@ayear int ,@idflowchart varchar(34), @idlist varchar(max) OUTPUT',
								@ayear=@ayear , @idflowchart=@idflowchart , @idlist=@idlist OUTPUT
	INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_mfin','S',@idlist,'N')	


	--list_mupb
	set @subq = '(select distinct U.idupb from flowchartupb F 
						join upb U ON U.idupb like F.idupb+''%'' 
						WHERE F.idflowchart = @idflowchart
					UNION
				SELECT idupb FROM upb WHERE idman IN ('+@list_man+')
				)'
	set @cmd = 'set @idlist=''''''0''''''; select @idlist = @idlist+'',''''''+ replace(convert(varchar(30),Q.idupb),'''''''','''''''''''')+''''''''  from  '+
			' (select distinct T.idupb from '+@subq+' as T) as Q'
	exec SP_EXECUTESQL  @cmd, @Params = N'@idflowchart varchar(34), @idlist varchar(max) OUTPUT',
								@idflowchart=@idflowchart , @idlist=@idlist OUTPUT
	INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('list_mupb','S',@idlist,'N')	

CREATE TABLE #tab_allowform(	tablename varchar(100))

	INSERT  #tab_allowform EXEC compute_allowform @ayear,@idcustomuser,@idflowchart,'menu'
	

	--menu  compute_allowform
	set @idlist=''
	select @idlist = @idlist+','''+convert(varchar(50),tablename)+''''  from #tab_allowform 
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('menu','S',substring(@idlist,2,len(@idlist)),'N')	
	drop table #tab_allowform

	--notable   compute_notable
	set @idlist=''
	CREATE TABLE #tab_notable(	edittype varchar(100))
	INSERT  #tab_notable EXEC compute_notable @ayear,@idcustomuser,@idflowchart,'notable'
	select @idlist = @idlist+','''+convert(varchar(30),edittype)+''''  from #tab_notable 
    INSERT INTO #myouttable(variablename, kind, value,mustquote)	 VALUES('notable','S',substring(@idlist,2,len(@idlist)),'N')	
	drop table #tab_notable

	select * from #myouttable

	drop table #myouttable
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
