
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_situazionesaldicontabili]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_situazionesaldicontabili]
GO
 
CREATE   PROCEDURE [rpt_situazionesaldicontabili]
	@ayear				int,
	@start				datetime,
	@stop				datetime,
	@nlevel 			varchar(1),
	@idupb				varchar(36),
	@showchildupb		char(1),
	@suppressifblank	char(1),
	@filtersit			varchar(1)
	AS
	BEGIN
	--	[rpt_situazionesaldicontabili]  2015, {ts '2015-01-20 00:00:00'}, {ts '2015-12-31 00:00:00'}, 4, '0001', 'S', 'N','R'
	DECLARE @idupboriginal varchar(36)
	if (@idupb= '%') BEGIN
		set @idupb= null;
	END
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S' and @idupb is not null) 
	BEGIN
		SET @idupb=@idupb+'%' 
	END

	CREATE TABLE #saldicontabili
		(
		idacc1 		varchar(38)			, 
		code1		varchar(50)			, 
		title1		varchar(150)			, 
		printingordacc1 varchar(50)			, 
		idacc2	 	varchar(38)			, 
		code2		varchar(50)			, 
		title2		varchar(150)			, 
		printingordacc2 varchar(50)			, 
		idacc3	 	varchar(38)			, 
		code3		varchar(50)			, 
		title3		varchar(150)			, 
		printingordacc3 varchar(50)			, 
		idacc4	 	varchar(38)			, 
		code4		varchar(50)			, 
		title4		varchar(150)			, 
		printingordacc4 varchar(50)			, 
		idacc5	 	varchar(38)			, 
		code5		varchar(50)			, 
		title5		varchar(150)			, 
		printingordacc5 varchar(50)			, 
		idacc6	 	varchar(38)			, 
		code6		varchar(50)			, 
		title6		varchar(150)			, 
		printingordacc6 varchar(50)			, 
		idacc 		varchar(38)			, 
		code		varchar(50)			, 
		title		varchar(150)			, 
		nlevel		varchar(1)			,
		printingordacc	varchar(50)			, 
		totaledare 	decimal(19,2) 			,
		totaleavere 	decimal(19,2)			,
		totale		decimal(19,2)			
		)
	-- Se ho scelto un livello sottostante del livello operativo utilizzo quello, 
	-- altrimenti userò il I liv.operativo
	/*DECLARE @levelusable	varchar(20)
	SELECT @levelusable = MIN(nlevel)
		FROM accountlevel
		WHERE flagusable = 'S'	AND ayear = @ayear
	IF @levelusable < @nlevel
		SELECT @levelusable = @nlevel
	
	SET @nlevel = @levelusable*/
	DECLARE @newnlevel integer
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+2  PRINT @newnlevel
	DECLARE @nlevel1 integer SET @nlevel1 = 6
	DECLARE @nlevel2 integer SET @nlevel2 = 10
	DECLARE @nlevel3 integer SET @nlevel3 = 14
	DECLARE @nlevel4 integer SET @nlevel4 = 18
	DECLARE @nlevel5 integer SET @nlevel5 = 22
	DECLARE @nlevel6 integer SET @nlevel6 = 26
	INSERT INTO #saldicontabili
	      	(
			idacc1,
			idacc2,
			idacc3,
			idacc4,
			idacc5,
			idacc6,
			idacc,
			code,
			title,
			printingordacc,
			nlevel
		)
		SELECT 
			SUBSTRING(account.idacc, 1, @nlevel1),
			SUBSTRING(account.idacc, 1, @nlevel2),
			SUBSTRING(account.idacc, 1, @nlevel3),
			SUBSTRING(account.idacc, 1, @nlevel4),
			SUBSTRING(account.idacc, 1, @nlevel5),
			SUBSTRING(account.idacc, 1, @nlevel6),
			SUBSTRING(account.idacc, 1, @newnlevel),  	
			codeacc,
			title,
			printingorder,
			nlevel		
		FROM account
		where account.ayear = @ayear AND
		((account.flag&4)= 0) --escludo i conti d'ordine
		AND EXISTS (SELECT * from account AC  
			LEFT OUTER JOIN placcount PL ON AC.idplaccount = PL.idplaccount
			LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
			WHERE  AC.idacc like (account.idacc  + '%') and 
			ISNULL(PA.patpart,PL.placcpart) = @filtersit) AND
		account.nlevel <=  @nlevel
DELETE  FROM  #saldicontabili 
WHERE EXISTS (SELECT * from #saldicontabili RR 
	       WHERE RR.idacc like (#saldicontabili.idacc + '%') AND RR.idacc <> #saldicontabili.idacc)
	
--select * from #saldicontabili
	update #saldicontabili 
	set    totaledare = (SELECT -ISNULL(SUM(amount),0) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
			     JOIN account AC
			     ON AC.idacc =  entrydetail.idacc
			     LEFT OUTER JOIN placcount PL ON AC.idplaccount = PL.idplaccount
				 LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
			     WHERE  amount < 0 AND
			     (entrydetail.idupb like @idupb OR @idupb is null)
			     AND ISNULL(PA.patpart,PL.placcpart) = @filtersit AND
			     entrydetail.idacc like (#saldicontabili.idacc  + '%') and
			     entry.yentry = @ayear 
		             and entry.adate between @start and @stop
			     )
			    
	update #saldicontabili 
	set    totaleavere = (SELECT ISNULL(SUM(amount),0) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
			      JOIN account AC
			     ON AC.idacc =  entrydetail.idacc
			     LEFT OUTER JOIN placcount PL ON AC.idplaccount = PL.idplaccount
				 LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
			     WHERE  amount > 0 AND
			     (entrydetail.idupb like @idupb OR @idupb is null)
			     AND 	ISNULL(PA.patpart,PL.placcpart)= @filtersit AND
			     entrydetail.idacc like (#saldicontabili.idacc  + '%') and
			     entry.yentry = @ayear 
			     and entry.adate between @start and @stop
			     )
			     
	IF (	Upper(@suppressifblank)='S')	
	DELETE FROM  #saldicontabili
		where (
		isnull(totaledare,0.0) 	=0 and 
		isnull(totaleavere,0.0)	=0)
	
	DECLARE @filter1 varchar(1)
   SELECT  @filter1 = CASE
    	WHEN Upper(@filtersit) = 'A' THEN 'P' 
        WHEN Upper(@filtersit) = 'P' THEN 'A' 
	WHEN Upper(@filtersit) = 'C' THEN 'R' 
        WHEN Upper(@filtersit) = 'R' THEN 'C' 
    END 
	
	
	DECLARE @totale decimal(19,2)
	
	set @totale = ISNULL((SELECT ISNULL(SUM(amount),0) 
			 FROM entrydetail  
			 JOIN entry on
			      entry.nentry = entrydetail.nentry and
			      entry.yentry = entrydetail.yentry 
				 JOIN account AC
			     ON AC.idacc =  entrydetail.idacc
			     LEFT OUTER JOIN placcount PL ON AC.idplaccount = PL.idplaccount
				 LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
			     WHERE  amount > 0 AND
			     ISNULL(PA.patpart,PL.placcpart)= @filter1 AND
			     --entrydetail.idacc like (#saldicontabili.idacc  + '%') and
			     (entrydetail.idupb like @idupb OR @idupb is null) AND
			     entry.yentry = @ayear 
			     and entry.adate between @start and @stop
			     ),0) 
			     -
			     ISNull( (SELECT -ISNULL(SUM(amount),0) 
			     FROM entrydetail  
			     JOIN entry on
			     entry.nentry = entrydetail.nentry and
			     entry.yentry = entrydetail.yentry 
				 JOIN account AC
			     ON AC.idacc =  entrydetail.idacc
			     LEFT OUTER JOIN placcount PL ON AC.idplaccount = PL.idplaccount
				 LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
			     WHERE  amount < 0 AND
			     --SUBSTRING(entrydetail.idacc,1,@levelusable*4+2) = #saldicontabili.idacc and
			     ISNULL(PA.patpart,PL.placcpart) = @filter1 AND
			     --entrydetail.idacc like (#saldicontabili.idacc  + '%') and
			     (entrydetail.idupb like @idupb OR @idupb is null) AND
			     entry.yentry = @ayear
		             and entry.adate between @start and @stop
			     ),0)	     
			
if (@filtersit = 'P' or @filtersit = 'R')
set @totale = -@totale
		
	--select  * from #saldicontabili	
	update #saldicontabili 
	set code1  = account.codeacc,
	    title1 = account.title ,
	    printingordacc1 = account.printingorder
	from account 
	where #saldicontabili.idacc1 = account.idacc 
	if (@nlevel >2)
		update #saldicontabili set code2	= account.codeacc ,
				title2	= account.title ,
				printingordacc2 = account.printingorder
				from account 
				where #saldicontabili.idacc2 = account.idacc
		else update #saldicontabili 
		set idacc2 = null
				
	if (@nlevel >3)
		update #saldicontabili set code3	= account.codeacc ,
				title3	= account.title ,
				printingordacc3 = account.printingorder
				from account 
				where #saldicontabili.idacc3 = account.idacc
		else update #saldicontabili
				set idacc3 = null
			
	if (@nlevel >4 )
		update #saldicontabili set code4	= account.codeacc ,
				title4	= account.title ,
				printingordacc4 = account.printingorder
				from account 
				where #saldicontabili.idacc4 = account.idacc
		else update #saldicontabili
				set idacc4 = null
	if (@nlevel >5 )
		update #saldicontabili set code5	= account.codeacc ,
				title5	= account.title ,
				printingordacc5 = account.printingorder
				from account 
				where #saldicontabili.idacc5 = account.idacc
		else update #saldicontabili
				set idacc5 = null 

--lettura del valore di utile/perdita esercizio se esiste un conto apposito

DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,
		@title = title
FROM	upb 
WHERE	idupb = @idupboriginal

--gestione @suppressifblank nel report
update #saldicontabili 
	set  totale = @totale
	SELECT  
	@idupboriginal as idupb,
	@codeupb as codeupb,
	@title as upb,
	idacc1, 
	code1,	
	title1,	
	printingordacc1,	
	idacc2, 
	code2,	
	title2,	
	printingordacc2,	
	idacc3, 
	code3,	
	title3,	
	printingordacc3,	
	idacc4, 
	code4,	
	title4,	
	printingordacc4,	
	idacc5, 
	code5,	
	title5,	
	printingordacc5,	
	idacc6, 
	code6,	
	title6,	
	printingordacc6,	
	idacc,
	code as 'codeaccount',	
	title as 'titleaccount',	
	printingordacc,
	nlevel,
	totaledare,
	totaleavere,
	totale
	--crpauo
	FROM #saldicontabili
--GROUP BY #saldicontabili.idacc,code,printingordacc,title,idacc,
	--idacc1,code1,title1,printingordacc1,idacc2,code2,title2,printingordacc2,idacc3,code3,title3,printingordacc3,idacc4,code4,title4,printingordacc4,idacc5,code5,title5,printingordacc5
ORDER BY printingordacc,code 
	
END
 



