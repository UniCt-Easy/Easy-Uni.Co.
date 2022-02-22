
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_bilanciodiverifica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_bilanciodiverifica]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
CREATE  PROCEDURE [rpt_bilanciodiverifica]
	@ayear				int,
	@start				datetime,
	@stop				datetime,
	@nlevel 			varchar(1),
	@idupb				varchar(36),
	@showchildupb		char(1),
	@suppressifblank	char(1)
	AS
	BEGIN
	
	DECLARE @idupboriginal varchar(36)
	if (@idupb= '%') BEGIN
		set @idupb= null;
	END
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S' and @idupb is not null) 
	BEGIN
		SET @idupb=@idupb+'%' 
	END
--	[rpt_bilanciodiverifica] 2015, {ts '2015-01-20 00:00:00'}, {ts '2015-12-31 00:00:00'}, 4, null, 'S', 'S'
	CREATE TABLE #bilanciodiverifica
		(
		
		idacc 		varchar(38), 
		totaledare 	decimal(19,2),
		totaleavere 	decimal(19,2)
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
	SET @newnlevel = (CONVERT(int, @nlevel)*4)+2  
	PRINT @newnlevel
	DECLARE @nlevel1 integer SET @nlevel1 = 6
	DECLARE @nlevel2 integer SET @nlevel2 = 10
	DECLARE @nlevel3 integer SET @nlevel3 = 14
	DECLARE @nlevel4 integer SET @nlevel4 = 18
	DECLARE @nlevel5 integer SET @nlevel5 = 22
	DECLARE @nlevel6 integer SET @nlevel6 = 26

	INSERT INTO #bilanciodiverifica
      		(
		idacc,
		totaledare,
		totaleavere
		)
		SELECT 
			substring(entrydetail.idacc,1,@newnlevel),
			sum(case when amount<0 then -amount else 0 end),
			sum(case when amount>0 then amount else 0 end)
		FROM  entrydetail 										
		JOIN entry 			ON entry.yentry  = entrydetail.yentry 			AND entry.nentry = entrydetail.nentry 
												and (entry.adate BETWEEN @start AND @stop)
												AND entry.identrykind not in  (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
		JOIN account				ON account.idacc = entrydetail.idacc

		where  entrydetail.yentry = @ayear and (entrydetail.idupb like @idupb  OR @idupb is null )	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
		group by substring(entrydetail.idacc,1,@newnlevel)
		having (@suppressifblank='N' or isnull(sum(case when amount>0 then amount else 0 end),0)<>0   or isnull(sum(case when amount<0 then -amount else 0 end),0)<>0  )

--select * from #bilanciodiverifica

--DELETE  FROM  #bilanciodiverifica WHERE EXISTS (SELECT * from #bilanciodiverifica RR 	       WHERE RR.idacc like (#bilanciodiverifica.idacc + '%') AND RR.idacc <> #bilanciodiverifica.idacc)
--cancella i padri se ci sono i figli, inutile al momento


--Inserisce le voci non associate a scritture
if (@suppressifblank='N')
INSERT INTO #bilanciodiverifica(
		idacc,
		totaledare,
		totaleavere		)
		SELECT 
			idacc,null,null
		FROM account
		WHERE  account.ayear = @ayear   and		account.nlevel >=  @nlevel and ((flag&4)= 0)
			and (select count(*)  from account P2
					where P2.paridacc = account.idacc)=0
			and (select count(*)  from #bilanciodiverifica P
					where P.idacc = account.idacc)=0
	
		 
				
DECLARE @codeupb	varchar(50)
DECLARE @title		varchar(150)
 
SELECT	@codeupb = codeupb,		@title = title FROM	upb WHERE	idupb = @idupboriginal

--gestione @suppressifblank nel report
SELECT  
	@idupboriginal as idupb,
	@codeupb as codeupb,
	@title as upb,
	AC1.idacc as idacc1 , 
	AC1.codeacc as code1,	
	AC1.title as title1,	
	AC1.printingorder as printingordacc1,	
	case when @nlevel>2 then AC2.idacc else null end as idacc2, 
	case when @nlevel>2 then AC2.codeacc else null end as code2, 
	case when @nlevel>2 then AC2.title else null end as title2, 
	case when @nlevel>2 then AC2.printingorder else null end as printingordacc2, 
	case when @nlevel>3 then AC3.idacc else null end as idacc3,
	case when @nlevel>3 then AC3.codeacc else null end as code3, 
	case when @nlevel>3 then AC3.title else null end as title3, 
	case when @nlevel>3 then AC3.printingorder else null end as printingordacc3, 
	case when @nlevel>4 then AC4.idacc else null end as idacc4,
	case when @nlevel>4 then AC4.codeacc else null end as code4, 
	case when @nlevel>4 then AC4.title else null end as title4, 
	case when @nlevel>4 then AC4.printingorder else null end as printingordacc4, 
	case when @nlevel>5 then AC5.idacc else null end as idacc5,
	case when @nlevel>5 then AC5.codeacc else null end as code5, 
	case when @nlevel>5 then AC5.title else null end as title5, 
	case when @nlevel>5 then AC5.printingorder else null end as printingordacc5, 
	case when @nlevel>6 then AC6.idacc else null end as idacc6,
	case when @nlevel>6 then AC6.codeacc else null end as code6, 
	case when @nlevel>6 then AC6.title else null end as title6, 
	case when @nlevel>6 then AC6.printingorder else null end as printingordacc6, 
	AC.idacc,
	AC.codeacc 	as 'codeaccount',	
	AC.title 	as 'titleaccount',	
	AC.printingorder as 'printingordacc',
	AC.nlevel,
	B.totaledare,
	B.totaleavere,
	ISNULL(PA.patpart,PL.placcpart),
	AC.placcount_sign,
	AC.patrimony_sign
	FROM #bilanciodiverifica B
	left outer join account AC on B.idacc=AC.idacc
	left outer join placcount PL ON AC.idplaccount = PL.idplaccount
	 LEFT OUTER JOIN patrimony PA ON AC.idpatrimony = PA.idpatrimony
	 left outer join account AC1 on AC1.idacc=SUBSTRING(AC.idacc, 1, @nlevel1)
	 left outer join account AC2 on AC2.idacc=SUBSTRING(AC.idacc, 1, @nlevel2)
	 left outer join account AC3 on AC3.idacc=SUBSTRING(AC.idacc, 1, @nlevel3)
	 left outer join account AC4 on AC4.idacc=SUBSTRING(AC.idacc, 1, @nlevel4)
	 left outer join account AC5 on AC5.idacc=SUBSTRING(AC.idacc, 1, @nlevel5)
	 left outer join account AC6 on AC6.idacc=SUBSTRING(AC.idacc, 1, @nlevel6)

ORDER BY AC.printingorder,AC.codeacc 
	
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
