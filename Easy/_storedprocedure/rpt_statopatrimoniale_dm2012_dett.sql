
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_statopatrimoniale_dm2012_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_statopatrimoniale_dm2012_dett]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser'amm'
--setuser 'amministrazione'
CREATE  PROCEDURE [rpt_statopatrimoniale_dm2012_dett]

	@ayear			int,
	@start			datetime,
	@stop			datetime,
	--@nlevel 		varchar(1),
	@filterpatrimony 		varchar(50),
	@idsor1 int,
	@idsor2 int,
	@idsor3 int,
	@suppressifblank 	char(1) ,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@flagactivity int,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	AS

	BEGIN
	declare @nlevel 		varchar(1)
	set @nlevel = (select MAX(nlevel) FROM patrimonylevel  WHERE ayear = @ayear)
	
	-- exec  rpt_statopatrimoniale_dm2012_dett 2019, {ts '2019-01-01 00:00:00'}, {ts '2019-05-10 00:00:00'},  NULL, NULL, NULL, NULL, 'S', null, 'N', NULL, NULL, NULL, NULL, NULL
	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb

	if (@idupb is null) set @idupb='%'

	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	CREATE TABLE #bilanciostatopatrimoniale(
		idpatrimony1 		varchar(38), 
		code1		varchar(50), 
		title1		varchar(200), 
		printingordpatr1 varchar(50), 
		idpatrimony2	 	varchar(38), 
		code2		varchar(50), 
		title2		varchar(200), 
		printingordpatr2 varchar(50), 
		idpatrimony3	 	varchar(38), 
		code3		varchar(50), 
		title3		varchar(200), 
		printingordpatr3 varchar(50), 
		idpatrimony4	 	varchar(38), 
		code4		varchar(50), 
		title4		varchar(200), 
		printingordpatr4 varchar(50), 
		idpatrimony5	 	varchar(38), 
		code5		varchar(50), 
		title5		varchar(200), 
		printingordpatr5 varchar(50), 
		idpatrimony	 	varchar(38), 
		amount 		decimal(19,2) ,
		idacc varchar(38),
		codeacc varchar(50),
		account varchar(150), 
		nlevel char(1)
	)


-- Se ho scelto un livello sottostante del livello operativo utilizzo quello, 
-- altrimenti userò il I liv.operativo
/*	DECLARE @levelusable	varchar(20)
	SELECT @levelusable = MIN(nlevel)
		FROM patrimonylevel
		WHERE flagusable = 'S'	AND ayear = @ayear
*/
	DECLARE @levelusable	varchar(20)
	SELECT @levelusable = MAX(nlevel)
		FROM patrimonylevel
		WHERE ayear = @ayear

	IF @levelusable < @nlevel
		SELECT @levelusable = @nlevel
	
-- Calcola la lunghezza del filtro in base ad nlevel		
	SET @filterpatrimony = RTRIM(@filterpatrimony)
	PRINT @filterpatrimony
	IF @filterpatrimony = ''
		SELECT @filterpatrimony = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filterpatrimony,''))) PRINT @lenfilter
	
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+3  PRINT @newnlevel
	DECLARE @nlevel1 integer SET @nlevel1 = 7
	DECLARE @nlevel2 integer SET @nlevel2 = 11
	DECLARE @nlevel3 integer SET @nlevel3 = 15
	DECLARE @nlevel4 integer SET @nlevel4 = 19
	DECLARE @nlevel5 integer SET @nlevel5 = 23
	INSERT INTO #bilanciostatopatrimoniale(
		idpatrimony1,
		idpatrimony2,
		idpatrimony3,
		idpatrimony4,
		idpatrimony5,
		idpatrimony,
		amount,
		idacc,
		codeacc,
		account,
		nlevel
		)
		SELECT 
			SUBSTRING(patrimony.idpatrimony, 1, @nlevel1),
			case when patrimony.nlevel >=2 then  SUBSTRING(patrimony.idpatrimony, 1, @nlevel2)  else null end,
			case when patrimony.nlevel >=3 then  SUBSTRING(patrimony.idpatrimony, 1, @nlevel3)  else null end,
			case when patrimony.nlevel >=4 then  SUBSTRING(patrimony.idpatrimony, 1, @nlevel4) else null end,
			case when patrimony.nlevel >=5 then  SUBSTRING(patrimony.idpatrimony, 1, @nlevel5)  else null end,
			SUBSTRING(patrimony.idpatrimony, 1, @newnlevel),  			
			entrydetail.amount,
			account.idacc,
			account.codeacc,
			account.title,
			patrimony.nlevel
		FROM entry
		
		JOIN entrydetail				ON entry.yentry  = entrydetail.yentry 		AND entry.nentry = entrydetail.nentry
		left outer JOIN upb				ON upb.idupb  = entrydetail.idupb 
		JOIN account					ON account.idacc = entrydetail.idacc
		JOIN patrimony					ON patrimony.idpatrimony = account.idpatrimony
		WHERE entry.yentry = @ayear		
			and account.ayear = @ayear		
			and (entry.adate BETWEEN @start AND @stop)
			AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
			and (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
			AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			and (  @flagactivity = 0 -- tutte, senza distinzione
				or @flagactivity = 4 and isnull(upb.flagactivity,4) = @flagactivity 
				or @flagactivity in (1,2) and upb.flagactivity = @flagactivity 
				 )
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
			 
if (@suppressifblank = 'N')
BEGIN
	INSERT INTO #bilanciostatopatrimoniale(
			idpatrimony1,
			idpatrimony2,
			idpatrimony3,
			idpatrimony4,
			idpatrimony5,
			idpatrimony,
			nlevel,
			amount,
			idacc,
			codeacc,
			account
			)
			SELECT 
				SUBSTRING(patrimony.idpatrimony, 1, @nlevel1),
				case when patrimony.nlevel >= 2 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel2) else null end ,
				case when patrimony.nlevel >= 3 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel3) else null end ,
				case when patrimony.nlevel >= 4 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel4) else null end ,
				case when patrimony.nlevel >= 5 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel5) else null end ,
				SUBSTRING(patrimony.idpatrimony, 1, @newnlevel),
				patrimony.nlevel,
				0,
				account.idacc,
				account.codeacc,
				account.title
			FROM patrimony
			JOIN account				ON patrimony.idpatrimony = account.idpatrimony
			WHERE (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
				and patrimony.ayear = @ayear
				and account.ayear = @ayear
				and (select count(*)  from #bilanciostatopatrimoniale P
						where P.idpatrimony = patrimony.idpatrimony
						and P.idacc = account.idacc)=0
END


--Inserisce le voci non associate a Conti EP
INSERT INTO #bilanciostatopatrimoniale(
		idpatrimony1,
		idpatrimony2,
		idpatrimony3,
		idpatrimony4,
		idpatrimony5,
		idpatrimony,
		nlevel
		)
		SELECT 
			SUBSTRING(patrimony.idpatrimony, 1, @nlevel1),
			case when patrimony.nlevel >= 2 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel2) else null end ,
			case when patrimony.nlevel >= 3 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel3) else null end ,
			case when patrimony.nlevel >= 4 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel4) else null end ,
			case when patrimony.nlevel >= 5 then SUBSTRING(patrimony.idpatrimony, 1, @nlevel5) else null end ,
			SUBSTRING(patrimony.idpatrimony, 1, @newnlevel),
			patrimony.nlevel
		FROM patrimony
		WHERE (@filterpatrimony IS NULL OR SUBSTRING(patrimony.codepatrimony, 1,@lenfilter) = @filterpatrimony)
			and patrimony.ayear = @ayear
			and (select count(*)  from patrimony P2
					where P2.paridpatrimony = patrimony.idpatrimony)=0
			and (select count(*)  from #bilanciostatopatrimoniale P
					where P.idpatrimony = patrimony.idpatrimony)=0
 
	update #bilanciostatopatrimoniale set code1	= codepatrimony ,
				title1	= title ,
				printingordpatr1 = printingorder
				from patrimony 
				where #bilanciostatopatrimoniale.idpatrimony1 = patrimony.idpatrimony 
	if (@nlevel >=2)
		update #bilanciostatopatrimoniale set code2	= codepatrimony ,
				title2	= title ,
				printingordpatr2 = printingorder
				from patrimony 
				where #bilanciostatopatrimoniale.idpatrimony2 = patrimony.idpatrimony
		else update #bilanciostatopatrimoniale 
				set idpatrimony2 = null
				
	if (@nlevel >=3)
		update #bilanciostatopatrimoniale set code3	= codepatrimony ,
				title3	= title ,
				printingordpatr3 = printingorder
				from patrimony 
				where #bilanciostatopatrimoniale.idpatrimony3 = patrimony.idpatrimony
		else update #bilanciostatopatrimoniale
				set idpatrimony3 = null
			
	if (@nlevel >=4 )
		update #bilanciostatopatrimoniale set code4	= codepatrimony ,
				title4	= title ,
				printingordpatr4 = printingorder
				from patrimony 
				where #bilanciostatopatrimoniale.idpatrimony4 = patrimony.idpatrimony
		else update #bilanciostatopatrimoniale
				set idpatrimony4 = null
	if (@nlevel >=5 )
		update #bilanciostatopatrimoniale set code5	= codepatrimony ,
				title5	= title ,
				printingordpatr5 = printingorder
				from patrimony 
				where #bilanciostatopatrimoniale.idpatrimony5 = patrimony.idpatrimony
		else update #bilanciostatopatrimoniale
				set idpatrimony5 = null

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

	SELECT  
	@nlevel as 'nlevel',
	substring(idpatrimony1,3,1) as patpart,
	@idupboriginal	as   idupb          ,
	@codeupb	    as	 codeupb	    ,
	@title		    as	 upb		    ,
	idpatrimony1, 
	code1,	
	title1,	
	printingordpatr1,	
	idpatrimony2, 
	code2,	
	title2,	
	printingordpatr2,	
	idpatrimony3, 
	code3,	
	title3,	
	printingordpatr3,	
	idpatrimony4, 
	code4,	
	title4,	
	printingordpatr4,	
	idpatrimony5, 
	code5,	
	title5,	
	printingordpatr5,	
	null as 'codepatrimony', --patrimony.codepatrimony   as 'codepatrimony' 	,
	#bilanciostatopatrimoniale.idpatrimony	 		,
	null as 'titlepatrimony', --patrimony.title  as 'titlepatrimony'  	,
	null as 'printingorder',--patrimony.printingorder  as 'printingorder',	
	CASE substring(idpatrimony1,3,1)
			 WHEN 'A' THEN sum(isnull(-amount,0.0))-- A ATTIVITA'
			 ELSE  sum(isnull(amount,0.0)) -- P PASSIVITA'
			END as amount,
	idacc,
	codeacc,
	account	 
	---FROM patrimony 
	from #bilanciostatopatrimoniale 
	GROUP BY #bilanciostatopatrimoniale.idpatrimony,
	idpatrimony1,code1,title1,printingordpatr1,idpatrimony2,code2,title2,printingordpatr2,idpatrimony3,code3,title3,printingordpatr3,idpatrimony4,code4,title4,printingordpatr4,idpatrimony5,code5,title5,printingordpatr5,
		idacc,	codeacc,	account
		ORDER BY 		substring(idpatrimony1,3,1),printingordpatr1,printingordpatr2,printingordpatr3,printingordpatr4,printingordpatr5,codeacc
--ORDER BY substring(idpatrimony1,3,1) 
	
END
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

 --EXEC rpt_statopatrimoniale_dm2012_dett 2015, {ts '2015-01-01 00:00:00'}, {ts '2015-12-31 00:00:00'}, '4', NULL, null, null, null ,'N','%','S'

 




