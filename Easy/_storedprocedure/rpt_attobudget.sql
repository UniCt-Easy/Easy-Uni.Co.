
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_attobudget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_attobudget]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--setuser'amministrazione'
--exec rpt_attobudget  2023, 2, 'S','S', null,null,null,null,null
--GO
--exec rpt_attobudget  2023, 2, 'N','S', null,null,null,null,null
--GO
--exec rpt_attobudget 2023, 3, 'S','S', null,null,null,null,null
CREATE   PROCEDURE rpt_attobudget
	@yvar          	int, 
	@nenactment		int,
	@showupb char(1),
	@showanalyticalaccounts char(1),  --- mostra le coordinate analitiche e le riallocazioni di contabilità analitica
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int 
	AS
	BEGIN
	
	DECLARE @yenactment   	int
	DECLARE @idenactment	int
	DECLARE @enactdescription    varchar(150)

	SET 	@yenactment = @yvar
	SELECT     @idenactment =  idenactment, @enactdescription = description
			    FROM accountenactment 
			   WHERE accountenactment.yenactment = @yenactment
	   		     AND accountenactment.nenactment = @nenactment
	
	declare @idsorkind1 int
	declare @idsorkind2 int
	declare @idsorkind3 int

	select 
		@idsorkind1 = idsortingkind1,
		@idsorkind2 = idsortingkind2,
		@idsorkind3 = idsortingkind3
	from config where ayear = @yvar

	DECLARE @sortingkind1 varchar(100)
	DECLARE @sortingkind2 varchar(100)
	DECLARE @sortingkind3 varchar(100)

	 
	SET	@sortingkind1 = (SELECT description FROM sortingkind WHERE idsorkind =  @idsorkind1) 
	SET	@sortingkind2 = (SELECT description FROM sortingkind WHERE idsorkind =  @idsorkind2)
	SET	@sortingkind3 = (SELECT description FROM sortingkind WHERE idsorkind =  @idsorkind3) 
 
 -- SELECT @sortingkind1, @sortingkind2, @sortingkind3

	CREATE TABLE #detail
	(
		idacc varchar(38),
		codeacc varchar(50),
		flagaccountusage int,
		title varchar(150),
		idupb varchar(36),
		codeupb varchar(50),	
		upb varchar(150),
		descriptionvar varchar(150),
		description varchar(8000),
		amount decimal(19,8),amount2 decimal(19,8),amount3 decimal(19,8),amount4 decimal(19,8),amount5 decimal(19,8),
		nvar int,
		rownum int, 
		idsor1	int,
		idsor2	int,
		idsor3	int,
		sortcode1	varchar(50),
		sorting1	varchar(200),
		sortcode2	varchar(50),
		sorting2	varchar(200),
		sortcode3	varchar(50),
		sorting3	varchar(200),
		idcostpartition	int 
	)
 
	insert into #detail(
		idacc,
		codeacc ,
		title ,
		flagaccountusage,
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		amount ,amount2 ,amount3 ,amount4 ,amount5,
		idsor1,
		sortcode1,
		sorting1,
		idsor2,
		sortcode2,
		sorting2,
		idsor3,
		sortcode3,
		sorting3,
		idcostpartition, 
		nvar,
		rownum 
	)
	SELECT   	
		account.idacc,
		account.codeacc,
		account.title,
		account.flagaccountusage,
		upb.idupb,
		upb.codeupb,
		upb.title,
		accountvar.description,
		accountvardetail.description,
		accountvardetail.amount ,
		accountvardetail.amount2 ,
		accountvardetail.amount3 ,
		accountvardetail.amount4 ,
		accountvardetail.amount5 ,
		accountvardetail.idsor1,
		sorting1.sortcode,
		sorting1.description,
		accountvardetail.idsor2,
		sorting2.sortcode,
		sorting2.description,
		accountvardetail.idsor3,
		sorting3.sortcode,
		sorting3.description,
		accountvardetail.idcostpartition, 
		accountvar.nvar,
		accountvardetail.rownum 
		--ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount, 2),
		--ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount2, 2),
		--ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount3, 2),
		--ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount4, 2),
		--ROUND(isnull(costpartitiondetail.rate, 1) * accountvardetail.amount5, 2),
		--accountvar.nvar
	FROM accountvardetail
	JOIN accountvar 
		ON accountvardetail.yvar = accountvar.yvar AND accountvardetail.nvar = accountvar.nvar
	JOIN account
		ON account.idacc = accountvardetail.idacc
	JOIN upb
		ON upb.idupb = accountvardetail.idupb 
	LEFT OUTER JOIN sorting as sorting1 ON accountvardetail.idsor1 = sorting1.idsor
	LEFT OUTER JOIN sorting as sorting2 ON accountvardetail.idsor2 = sorting2.idsor
	LEFT OUTER JOIN sorting as sorting3 ON accountvardetail.idsor3 = sorting3.idsor
	WHERE accountvardetail.yvar = @yvar
		AND (accountvar.idenactment = @idenactment)
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	ORDER BY accountvardetail.nvar, account.flag, account.codeacc,upb.codeupb
	 

	


--SELECT * FROM #detail
--select @showupb, select @showanalyticalaccounts
CREATE TABLE #costpartitiondetail 
	(
		idcostpartition int,
		costpartitioncode varchar(50),
		description varchar(800), 
		title varchar(200), 
		iddetail int ,
		amount decimal(19,2),
		idsor1 int,
		idsor2 int,
		idsor3 int,
		sortcode1	varchar(50),
		sorting1	varchar(200),
		sortcode2	varchar(50),
		sorting2	varchar(200),
		sortcode3	varchar(50),
		sorting3	varchar(200),
		rate decimal(19,6)
	)
	
IF (ISNULL(@showanalyticalaccounts, 'N')  = 'S')
BEGIN
	INSERT INTO #costpartitiondetail
	(	idcostpartition,costpartitioncode, description, title, iddetail,amount, 	
		idsor1,sortcode1,sorting1,
		idsor2,sortcode2,sorting2,
		idsor3, sortcode3,sorting3, rate)
	SELECT costpartitiondetail.idcostpartition,costpartition.costpartitioncode, costpartition.description,costpartition.title,
	iddetail,amount, 
	idsor1,sorting1.sortcode, sorting1.description,
	idsor2,sorting2.sortcode, sorting2.description,
	idsor3, sorting3.sortcode,sorting3.description, 
	rate   
    FROM costpartitiondetail 
	JOIN costpartition ON costpartitiondetail.idcostpartition = costpartition.idcostpartition
	LEFT OUTER JOIN sorting as sorting1 ON costpartitiondetail.idsor1 = sorting1.idsor
	LEFT OUTER JOIN sorting as sorting2 ON costpartitiondetail.idsor2 = sorting2.idsor
	LEFT OUTER JOIN sorting as sorting3 ON costpartitiondetail.idsor3 = sorting3.idsor
	WHERE costpartitiondetail.idcostpartition IN(SELECT DISTINCT idcostpartition FROM #detail)
	--SELECT * FROM #costpartitiondetail
 END
--4) visualizzando l'UPB
--4a) visualizzare l’Upb e le coordinate analitiche, quindi con l’importo dettagliato
--4b) visualizzare l’Upb senza le coordinate analitiche quindi raggruppando per Upb/conto?
--5) senza visualizzare l' UPB
--5a) Non ha senso visualizzare l'UPB senza visualizzare le coordinate analitiche
--5b) Non visualizzare le coordinate analitiche se si chiama raggruppando solo per conto 
--In tal caso mostrare i conti e le descrizioni dei dettagli della variazione, quelli non vanno mai nascosti

/*
	bool costo = (flag & 64) != 0;
    bool ricavo = (flag & 128) != 0;
    bool immobilizzazione = (flag & 256) != 0;
*/

IF ( (ISNULL(@showupb, 'N')='S')  AND  (ISNULL(@showanalyticalaccounts, 'N')  = 'N')) 
--> Mostra l'UPB, non mostra le coordinate analitiche e non ripartisce sui centri di costo/ricavo
  Begin

	SELECT 
	   -- @showupb,  @showanalyticalaccounts,
		#detail.codeacc,
		#detail.title,
		CASE
			WHEN ((#detail.flagaccountusage & 64))  <> 0 THEN 'C'
			WHEN ((#detail.flagaccountusage & 128)) <> 0 THEN 'R'
			WHEN ((#detail.flagaccountusage & 256)) <> 0 THEN 'I'
			ELSE null
		END as flagaccountusage, 
		idupb ,
		codeupb,	
		upb ,
		descriptionvar,
		description ,
		--#detail.amount as orig1 ,#detail.amount2 as orig2 ,#detail.amount3 as orig3 ,#detail.amount4 as orig4 ,#detail.amount5 as orig5,
		amount ,amount2 ,amount3 ,amount4 ,amount5,
		nvar,
		@enactdescription as enactdescription,
		null costpartitioncode, null as costpartition,
		null as sortcode1, null as sorting1,
		null as sortcode2, null as sorting2,
		null as sortcode3, null as sorting3,
		null as rate
	FROM #detail
	ORDER BY nvar,#detail.codeacc
	RETURN
  End
   
  IF ( (ISNULL(@showupb, 'N')='S')  AND  (ISNULL(@showanalyticalaccounts, 'N')  = 'S')) -->    
  -->  Mostra UPB, mostra le coordinate analitiche e ripartisce sui centri di costo/ricavo
  Begin
	SELECT 
		-- @showupb,  @showanalyticalaccounts,
		#detail.codeacc,
		#detail.title,
		CASE
			WHEN ((#detail.flagaccountusage & 64))  <> 0 THEN 'C'
			WHEN ((#detail.flagaccountusage & 128)) <> 0 THEN 'R'
			WHEN ((#detail.flagaccountusage & 256)) <> 0 THEN 'I'
			ELSE null
		END as flagaccountusage, 
		#detail.idupb ,
		#detail.codeupb,	
		#detail.upb ,
		#detail.descriptionvar,
		#detail.description,
		--#detail.amount as orig1 ,#detail.amount2 as orig2 ,#detail.amount3 as orig3 ,#detail.amount4 as orig4 ,#detail.amount5 as orig5,
		ROUND(isnull(RIP.rate, 1) * #detail.amount, 8)  as amount,
		ROUND(isnull(RIP.rate, 1) * #detail.amount2, 8) as amount2, 
		ROUND(isnull(RIP.rate, 1) * #detail.amount3, 8) as amount3,
		ROUND(isnull(RIP.rate, 1) * #detail.amount4, 8) as amount4,
		ROUND(isnull(RIP.rate, 1) * #detail.amount5, 8) as amount5,

		#detail.nvar,
		@enactdescription as enactdescription,
		RIP.costpartitioncode, RIP.title as costpartition,
		ISNULL(RIP.sortcode1,#detail.sortcode1)  as sortcode1, ISNULL(RIP.sorting1,#detail.sorting1)  as sorting1,
		ISNULL(RIP.sortcode2,#detail.sortcode2)  as sortcode2, ISNULL(RIP.sorting2,#detail.sorting2)  as sorting2,
		ISNULL(RIP.sortcode3,#detail.sortcode3)  as sortcode3, ISNULL(RIP.sorting3,#detail.sorting3)  as sorting3,
		RIP.rate
	FROM #detail
	LEFT OUTER JOIN #costpartitiondetail RIP ON RIP.idcostpartition = #detail.idcostpartition
	ORDER BY #detail.nvar,#detail.codeupb,	#detail.codeacc
	RETURN
  End


--IF ( (ISNULL(@showupb, 'N')='N')  AND  (ISNULL(@showanalyticalaccounts, 'N')  = 'N')) 
  -->  Mostra UPB, e non mostra le coordinate analitiche e ripartisce sui centri di costo/ricavo
  --Begin
		CREATE TABLE #detailcompact
		(
			idacc varchar(38) ,
			codeacc varchar(50),
			title varchar(150),
			flagaccountusage int, 
			descriptionvar varchar(150),
			description varchar(8000),
			amount decimal(19,8),amount2 decimal(19,8),amount3 decimal(19,8),amount4 decimal(19,8),amount5 decimal(19,8),
			nvar int	
		)
		INSERT INTO #detailcompact(idacc,codeacc,title,flagaccountusage, descriptionvar,amount ,amount2 ,amount3 ,amount4 ,amount5, nvar)
		SELECT 
			idacc, 
			codeacc ,
			title ,
			flagaccountusage,
			descriptionvar,
			isnull(sum(amount),0),isnull(sum(amount2),0),isnull(sum(amount3),0),isnull(sum(amount4),0),isnull(sum(amount5),0),
			nvar 
		FROM #detail
		GROUP BY nvar,idacc, codeacc,title,flagaccountusage, descriptionvar

		DECLARE @idacc varchar(38)
		DECLARE @nvar int
		DECLARE @description varchar(200)
		DECLARE @descriptioncompact varchar(8000) 

		DECLARE rowcursor INSENSITIVE CURSOR FOR
			SELECT DISTINCT idacc,description,nvar
			FROM #detail
			FOR READ ONLY
		OPEN rowcursor FETCH  NEXT FROM rowcursor INTO @idacc,@description, @nvar 
		WHILE @@FETCH_STATUS = 0
		BEGIN 
			UPDATE #detailcompact 
			SET description = 
			CASE 
				WHEN ((len(isnull(#detailcompact.description,'')) + len(@description)) < 8000 )
				   THEN ISNULL(#detailcompact.description,'') + @description + ';'
				ELSE  ISNULL(#detailcompact.description,'') + '...;'
			END
			WHERE (idacc = @idacc  and nvar = @nvar)
		
			FETCH NEXT FROM rowcursor INTO  @idacc,@description,@nvar 
		END 
		DEALLOCATE rowcursor
		

		SELECT 	
			 --   @showupb,  @showanalyticalaccounts,
			#detailcompact.codeacc,
			#detailcompact.title,
			CASE
			WHEN ((#detailcompact.flagaccountusage & 64))  <> 0 THEN 'C'
			WHEN ((#detailcompact.flagaccountusage & 128)) <> 0 THEN 'R'
			WHEN ((#detailcompact.flagaccountusage & 256)) <> 0 THEN 'I'
			ELSE null
		END as flagaccountusage, 
			null as idupb ,
			null as codeupb,	
			null as upb ,
			descriptionvar, 
			substring(description,1,len(description)-1) as description,    
		 --	isnull(amount,0)  as orig,
			--isnull(amount2,0) as orig2,
			--isnull(amount3,0) as orig3,
			--isnull(amount4,0) as orig4,
			--isnull(amount5,0) as orig5,
			isnull(amount,0)  as amount,
			isnull(amount2,0) as amount2,
			isnull(amount3,0) as amount3,
			isnull(amount4,0) as amount4,
			isnull(amount5,0) as amount5,
			#detailcompact.nvar,
			@enactdescription as 'enactdescription',
			null costpartitioncode, null as costpartition,
			null as sortcode1, null as sorting1,
			null as sortcode2, null as sorting2,
			null as sortcode3, null as sorting3,
			null as rate
		FROM #detailcompact
		ORDER BY nvar, #detailcompact.codeacc

	 

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
