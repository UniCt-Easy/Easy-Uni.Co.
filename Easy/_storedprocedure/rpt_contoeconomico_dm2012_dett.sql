
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico_dm2012_dett]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico_dm2012_dett]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--setuser 'amm'
--exec rpt_contoeconomico_dm2012_dett 2017, {d '2017-01-01'}, {d '2017-12-31'}, null,null,null,null,null,'%','N',2

CREATE  PROCEDURE [rpt_contoeconomico_dm2012_dett]

	@ayear			int,
	@start			datetime,
	@stop			datetime,
	--@nlevel 		varchar(1),
	@filterplaccount 		varchar(50),
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
	set @nlevel = (select MAX(nlevel) FROM placcountlevel  WHERE ayear = @ayear )

	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	
	if (@idupb is null) set @idupb='%'

	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
		SET @idupb=@idupb+'%' 
	END
	CREATE TABLE #bilanciocontoeconomico(
		idplaccount1 		varchar(38), 
		code1		varchar(50), 
		title1		varchar(200), 
		printingordpatr1 varchar(50), 
		idplaccount2	 	varchar(38), 
		code2		varchar(50), 
		title2		varchar(200), 
		printingordpatr2 varchar(50), 
		idplaccount3	 	varchar(38), 
		code3		varchar(50), 
		title3		varchar(200), 
		printingordpatr3 varchar(50), 
		idplaccount4	 	varchar(38), 
		code4		varchar(50), 
		title4		varchar(200), 
		printingordpatr4 varchar(50), 
		idplaccount5	 	varchar(38), 
		code5		varchar(50), 
		title5		varchar(200), 
		printingordpatr5 varchar(50), 
		idplaccount	 	varchar(38), 
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
		FROM placcountlevel
		WHERE flagusable = 'S'	AND ayear = @ayear
*/
	DECLARE @levelusable	varchar(20)
	SELECT @levelusable = MAX(nlevel)
		FROM placcountlevel
		WHERE ayear = @ayear

	IF @levelusable < @nlevel
		SELECT @levelusable = @nlevel
	
-- Calcola la lunghezza del filtro in base ad nlevel		
	SET @filterplaccount = RTRIM(@filterplaccount) PRINT @filterplaccount
	IF @filterplaccount = ''
		SELECT @filterplaccount = NULL
	
	DECLARE @lenfilter integer
	SET @lenfilter = DATALENGTH(RTRIM(ISNULL(@filterplaccount,''))) PRINT @lenfilter
	
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+3  PRINT @newnlevel
	DECLARE @nlevel1 integer SET @nlevel1 = 7
	DECLARE @nlevel2 integer SET @nlevel2 = 11
	DECLARE @nlevel3 integer SET @nlevel3 = 15
	DECLARE @nlevel4 integer SET @nlevel4 = 19
	DECLARE @nlevel5 integer SET @nlevel5 = 23
	INSERT INTO #bilanciocontoeconomico(
		idplaccount1,
		idplaccount2,
		idplaccount3,
		idplaccount4,
		idplaccount5,
		idplaccount,
		amount,
		idacc,
		codeacc,
		account,
		nlevel
		)
		SELECT 
			SUBSTRING(placcount.idplaccount, 1, @nlevel1),
			case when placcount.nlevel >=2 then  SUBSTRING(placcount.idplaccount, 1, @nlevel2)  else null end,
			case when placcount.nlevel >=3 then  SUBSTRING(placcount.idplaccount, 1, @nlevel3)  else null end,
			case when placcount.nlevel >=4 then  SUBSTRING(placcount.idplaccount, 1, @nlevel4) else null end,
			case when placcount.nlevel >=5 then  SUBSTRING(placcount.idplaccount, 1, @nlevel5)  else null end,
			SUBSTRING(placcount.idplaccount, 1, @newnlevel),  			
			entrydetail.amount,
			account.idacc,
			account.codeacc,
			account.title,
			placcount.nlevel
		FROM entry
		JOIN entrydetail 			ON entry.yentry  = entrydetail.yentry 			AND entry.nentry = entrydetail.nentry 
		JOIN account				ON account.idacc = entrydetail.idacc
		JOIN placcount				ON placcount.idplaccount = account.idplaccount
		left outer JOIN upb			on upb.idupb = entrydetail.idupb
		WHERE entry.yentry = @ayear				
			and (entry.adate BETWEEN @start AND @stop)
			AND  (entrydetail.idupb like @idupb  OR @idupb = '%' )
			and (  @flagactivity = 0 -- tutte, senza distinzione
				or @flagactivity = 4 and isnull(upb.flagactivity,4) = @flagactivity 
				or @flagactivity in (1,2) and upb.flagactivity = @flagactivity 
				 )
			and (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			AND (@idsor1 IS NULL OR entrydetail.idsor1 = @idsor1)AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3) 
			AND entry.identrykind not in  (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
			AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
			AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
			AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
			AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
			AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
			AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 

if (@suppressifblank = 'N')
BEGIN
INSERT INTO #bilanciocontoeconomico(
		idplaccount1,
		idplaccount2,
		idplaccount3,
		idplaccount4,
		idplaccount5,
		idplaccount,
		nlevel,
		amount,
		idacc,
		codeacc,
		account
		)
		SELECT 
			SUBSTRING(placcount.idplaccount, 1, @nlevel1),
			case when placcount.nlevel >= 2 then SUBSTRING(placcount.idplaccount, 1, @nlevel2) else null end ,
			case when placcount.nlevel >= 3 then SUBSTRING(placcount.idplaccount, 1, @nlevel3) else null end ,
			case when placcount.nlevel >= 4 then SUBSTRING(placcount.idplaccount, 1, @nlevel4) else null end ,
			case when placcount.nlevel >= 5 then SUBSTRING(placcount.idplaccount, 1, @nlevel5) else null end ,
			SUBSTRING(placcount.idplaccount, 1, @newnlevel),
			placcount.nlevel,
			0,
			account.idacc,
			account.codeacc,
			account.title
		FROM placcount
		JOIN account 			ON placcount.idplaccount = account.idplaccount
		WHERE (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			and placcount.ayear = @ayear
			-- coppie C.E.- Piano dei Conti non precedentemente estratte
			and (select count(*)  from #bilanciocontoeconomico P
					where P.idplaccount = placcount.idplaccount
					and P.idacc = account.idacc)=0

END

 
--Inserisce le voci non associate a scritture
INSERT INTO #bilanciocontoeconomico(
		idplaccount1,
		idplaccount2,
		idplaccount3,
		idplaccount4,
		idplaccount5,
		idplaccount,
		nlevel
		)
		SELECT 
			SUBSTRING(placcount.idplaccount, 1, @nlevel1),
			case when placcount.nlevel >= 2 then SUBSTRING(placcount.idplaccount, 1, @nlevel2) else null end ,
			case when placcount.nlevel >= 3 then SUBSTRING(placcount.idplaccount, 1, @nlevel3) else null end ,
			case when placcount.nlevel >= 4 then SUBSTRING(placcount.idplaccount, 1, @nlevel4) else null end ,
			case when placcount.nlevel >= 5 then SUBSTRING(placcount.idplaccount, 1, @nlevel5) else null end ,
			SUBSTRING(placcount.idplaccount, 1, @newnlevel),
			placcount.nlevel
		FROM placcount
		WHERE (@filterplaccount IS NULL OR SUBSTRING(placcount.codeplaccount, 1,@lenfilter) = @filterplaccount)
			and placcount.ayear = @ayear
			and (select count(*)  from placcount P2
					where P2.paridplaccount = placcount.idplaccount)=0
			and (select count(*)  from #bilanciocontoeconomico P
					where P.idplaccount = placcount.idplaccount)=0

	update #bilanciocontoeconomico set code1	= codeplaccount ,
				title1	= title ,
				printingordpatr1 = printingorder
				from placcount 
				where #bilanciocontoeconomico.idplaccount1 = placcount.idplaccount 
	if (@nlevel >=2)
		update #bilanciocontoeconomico set code2	= codeplaccount ,
				title2	= title ,
				printingordpatr2 = printingorder
				from placcount 
				where #bilanciocontoeconomico.idplaccount2 = placcount.idplaccount
		else update #bilanciocontoeconomico 
				set idplaccount2 = null
				
	if (@nlevel >=3)
		update #bilanciocontoeconomico set code3	= codeplaccount ,
				title3	= title ,
				printingordpatr3 = printingorder
				from placcount 
				where #bilanciocontoeconomico.idplaccount3 = placcount.idplaccount
		else update #bilanciocontoeconomico
				set idplaccount3 = null
			
	if (@nlevel >=4 )
		update #bilanciocontoeconomico set code4	= codeplaccount ,
				title4	= title ,
				printingordpatr4 = printingorder
				from placcount 
				where #bilanciocontoeconomico.idplaccount4 = placcount.idplaccount
		else update #bilanciocontoeconomico
				set idplaccount4 = null
	if (@nlevel >=5 )
		update #bilanciocontoeconomico set code5	= codeplaccount ,
				title5	= title ,
				printingordpatr5 = printingorder
				from placcount 
				where #bilanciocontoeconomico.idplaccount5 = placcount.idplaccount
		else update #bilanciocontoeconomico
				set idplaccount5 = null

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

	SELECT  
	@nlevel as 'nlevel',
	null as patpart,
	@idupboriginal	as   idupb          ,
	@codeupb	    as	 codeupb	    ,
	@title		    as	 upb		    ,
	code1 as idplaccount1, 
	code1,	
	title1,	
	printingordpatr1,	
	code2 as idplaccount2, 
	code2,	
	title2,	
	printingordpatr2,	
	code3 as idplaccount3, 
	code3,	
	title3,	
	printingordpatr3,	
	code4 as idplaccount4, 
	code4,	
	title4,	
	printingordpatr4,	
	code5 as idplaccount5, 
	code5,	
	title5,	
	printingordpatr5,	
	null as 'codeplaccount', --placcount.codeplaccount   as 'codeplaccount' 	,
	null as 'idplaccount',
	null as 'titleplaccount', --placcount.title  as 'titleplaccount'  	,
	null as 'printingorder',--placcount.printingorder  as 'printingorder',	
	sum(isnull(amount,0.0)) as amount,
	idacc,
	codeacc,
	account	,
	@flagactivity as 'flagactivity'
	FROM placcount		
	join #bilanciocontoeconomico 		on #bilanciocontoeconomico.idplaccount = placcount.idplaccount
	where placcount.ayear = @ayear
	GROUP BY #bilanciocontoeconomico.idplaccount,
	idplaccount1,code1,title1,printingordpatr1,idplaccount2,code2,title2,printingordpatr2,idplaccount3,code3,title3,printingordpatr3,idplaccount4,code4,title4,printingordpatr4,idplaccount5,code5,title5,printingordpatr5,
		idacc,	codeacc,	account 
ORDER BY 	printingordpatr1,printingordpatr2,printingordpatr3,printingordpatr4,printingordpatr5,codeacc
END


 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




 
