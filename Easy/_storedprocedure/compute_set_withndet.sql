
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



if exists (select * from dbo.sysobjects where id = object_id(N'[compute_set_withndet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_set_withndet]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE compute_set_withndet
(
	@ayear int,
	@iduser varchar(50),
	@idflowchart varchar(34),
	@ndetail int,
	@varname varchar(30)
)
AS BEGIN

CREATE TABLE #outtable
(
	res varchar(2000),
	mustquote char(1)
)

IF (@idflowchart IS NULL)
BEGIN
	INSERT INTO #outtable VALUES('AND(1=1)','N')
	SELECT res,mustquote FROM #outtable
	RETURN
END



declare @allvar varchar(30)
set @allvar=null

declare @withchilds char(1)
set @withchilds='N'

declare @all_value char(1)
set @all_value='N'

declare @idsor_value int

--fare gestione idsor01-05
if @varname = 'cond_sor01' 
BEGIN
	select @all_value = sorkind01asfilter from uniconfig 
	if isnull(@all_value,'N') = 'S' 
		begin 
			select @all_value = isnull(all_sorkind01,'S'),
				   @withchilds = isnull(sorkind01_withchilds,'N') from flowchartuser where 
					idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail			
		end
	else
		set @all_value='S'
END

if @varname = 'cond_sor02' 
BEGIN
	select @all_value = sorkind02asfilter from uniconfig 
	if isnull(@all_value,'N') = 'S' 
		begin 
			select @all_value = isnull(all_sorkind02,'S'),
				   @withchilds = isnull(sorkind02_withchilds,'N') from flowchartuser where 
					idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail			
		end
	else
		set @all_value='S'
END

if @varname = 'cond_sor03' 
BEGIN
	select @all_value = sorkind03asfilter from uniconfig 
	if isnull(@all_value,'N') = 'S' 
		begin 
			select @all_value = isnull(all_sorkind03,'S'),
				   @withchilds = isnull(sorkind03_withchilds,'N') from flowchartuser where 
					idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail			
		end
	else
		set @all_value='S'
END




if @varname = 'cond_sor04' 
BEGIN
	select @all_value = sorkind04asfilter from uniconfig 
	if isnull(@all_value,'N') = 'S' 
		begin 
			select @all_value = isnull(all_sorkind04,'S'),
				   @withchilds = isnull(sorkind04_withchilds,'N') from flowchartuser where 
					idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail			
		end
	else
		set @all_value='S'
END




if @varname = 'cond_sor05' 
BEGIN
	select @all_value = sorkind05asfilter from uniconfig 
	if isnull(@all_value,'N') = 'S' 
		begin 
			select @all_value = isnull(all_sorkind05,'S'),
				   @withchilds = isnull(sorkind05_withchilds,'N') from flowchartuser where 
					idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail			
		end
	else
		set @all_value='S'
END




if @varname='cond_man' set @allvar ='all_man'
if @varname='cond_mandatekind' set @allvar ='all_mandatekind'
if @varname='cond_estimatekind' set @allvar ='all_estimatekind'
if @varname='cond_invoicekind' set @allvar ='all_invoicekind'
if @varname='cond_fin' set @allvar ='all_fin'
if @varname='cond_upb' set @allvar ='all_upb'
if @varname='cond_pettycash' set @allvar ='all_pettycash'
if @varname='cond_authmodel' set @allvar ='all_authmodel'


if (@allvar is not null) 
BEGIN
	DECLARE @nrowfound int
	SET @nrowfound =
		(SELECT COUNT(*)
		FROM flowchartrestrictedfunction FF
		JOIN restrictedfunction RF
			ON RF.idrestrictedfunction = FF.idrestrictedfunction
		WHERE FF.idflowchart = @idflowchart
			AND RF.variablename = @allvar)

	IF (@nrowfound > 0) 	set @all_value='S'
	

END

if (@all_value='S')
BEGIN
		INSERT INTO #outtable VALUES('AND(1=1)','N')
		SELECT res,mustquote FROM #outtable		
		
		RETURN	
END


declare @cond varchar(1000)
set @cond=''


if @varname='cond_man' set @cond ='AND(idman is null OR (idman in (<%usr[list_man]%>)))'
if @varname='cond_mandatekind' set @cond ='AND(idmankind is null OR (idmankind in (<%usr[list_mandatekind]%>)))'
if @varname='cond_estimatekind' set @cond ='AND(idestimkind is null OR (idestimkind in (<%usr[list_estimatekind]%>)))'
if @varname='cond_invoicekind' set @cond ='AND(idinvkind is null OR (idinvkind in (<%usr[list_invoicekind]%>)))'
if @varname='cond_fin' set @cond ='AND(idfin is null OR (idfin in (<%usr[list_mfin]%>)))'
if @varname='cond_upb' set @cond ='AND(idupb is null OR (idupb in (<%usr[list_mupb]%>)))'
if @varname='cond_pettycash' set @cond ='AND(idpettycash is null OR (idpettycash in (<%usr[list_pettycash]%>)))'
if @varname='cond_authmodel' set @cond ='AND(idauthmodel is null OR (idauthmodel in (<%usr[list_authmodel]%>)))'

if (@cond <>'')
BEGIN
	INSERT INTO #outtable VALUES(@cond,'N')
	SELECT res,mustquote FROM #outtable		
	RETURN
END

--qui arriva solo per campi idsor01-05
IF (@ndetail IS NULL OR @ndetail = 0)
BEGIN
	INSERT INTO #outtable VALUES('AND(1=1)','N')
	SELECT res,mustquote FROM #outtable		
	RETURN
END
declare @idvar varchar(30)

declare @idlist varchar(2000)
set @idlist=''

if @varname = 'cond_sor01' 
BEGIN
	select @idsor_value = idsor01 from flowchartuser where 
		idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail
	set @idvar='idsor01'
END

if @varname = 'cond_sor02' 
BEGIN
	select @idsor_value = idsor02 from flowchartuser where 
		idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail
	set @idvar='idsor02'
END


if @varname = 'cond_sor03' 
BEGIN
	select @idsor_value = idsor03 from flowchartuser where 
		idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail
	set @idvar='idsor03'
END


if @varname = 'cond_sor04' 
BEGIN
	select @idsor_value = idsor04 from flowchartuser where 
		idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail
	set @idvar='idsor04'
END


if @varname = 'cond_sor05' 
BEGIN
	select @idsor_value = idsor05 from flowchartuser where 
		idcustomuser=@iduser and idflowchart=@idflowchart  and ndetail=@ndetail
	set @idvar='idsor05'
END

if (@idsor_value is null )
BEGIN 
	INSERT INTO #outtable VALUES(@cond,'N')
	SELECT res,mustquote FROM #outtable		
	RETURN
END

if (@withchilds='N' or (select count(*) from sortinglink where idparent=@idsor_value )<= 1 )
BEGIN
	set @cond= 'AND('+@idvar +' is null or '+@idvar+'='+convert(varchar(20),@idsor_value)+')'	
END 
ELSE
BEGIN
 select @idlist = @idlist+','+convert(varchar(30),idchild) from sortinglink where idparent=@idsor_value
 set @idlist='('+substring(@idlist,2,2000)+')'
 set @cond= 'AND('+@idvar +' is null or '+@idvar+' IN '+@idlist+')'
END



INSERT INTO #outtable VALUES(@cond,'N')
SELECT res,mustquote FROM #outtable		


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
