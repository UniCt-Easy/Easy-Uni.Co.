SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_epacctotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_epacctotal]
GO
--setuser 'amm'
-- rebuild_epacctotal 2015
CREATE PROCEDURE rebuild_epacctotal (
	@ayear int =  NULL
)
AS BEGIN
	/*
	Nei calcoli ESCLUDO le scritture di tipo
	6	Epilogo
	10	Rilevazione Risultato Economico
	11	Epilogo conto economico
	12	Epilogo stato patrimoniale
	*/
	DECLARE @curryear int
	DELETE from epacctotal where (@ayear is null)  OR ayear=@ayear
	
	INSERT INTO epacctotal 
		(idepacc,ayear,curramount,curramount2,curramount3,curramount4,curramount5,revenue,credit,rateo		)
		SELECT
			epaccyear.idepacc,	epaccyear.ayear,epaccyear.amount,	epaccyear.amount2,	epaccyear.amount3,
			epaccyear.amount4,	epaccyear.amount5,0,0,0
		FROM epaccyear
		WHERE  (@ayear is null)  OR ayear=@ayear;

		with sumvar(idepacc,yvar,amount,amount2,amount3,amount4,amount5) as 
		(select idepacc,yvar,sum(amount),sum(amount2),sum(amount3),
					sum(amount4),sum(amount5) from epaccvar group by idepacc,yvar)
		update epacctotal set curramount = isnull(curramount,0) + isnull(sumvar.amount,0),
					 curramount2 = isnull(curramount2,0) + isnull(sumvar.amount2,0),
					  curramount3 = isnull(curramount3,0) + isnull(sumvar.amount3,0),
					   curramount4 = isnull(curramount4,0) + isnull(sumvar.amount4,0),
					    curramount5 = isnull(curramount5,0) + isnull(sumvar.amount5,0)
		from epacctotal
		join sumvar on epacctotal.idepacc=sumvar.idepacc 
					and epacctotal.ayear=sumvar.yvar
					and ((@ayear is null)  OR epacctotal.ayear =@ayear)
	;
		with sumexptot(idepacc,ayear,amount,amount2,amount3,amount4,amount5) as
		(select E.paridepacc, ET.ayear, SUM(ET.curramount),SUM(ET.curramount2),SUM(ET.curramount3),
						SUM(ET.curramount4),SUM(ET.curramount5) from 
				epacctotal ET
				join epacc e on e.idepacc=ET.idepacc 
				WHERE  (@ayear is null) OR ET.ayear=@ayear
				group by E.paridepacc, ET.ayear
		)
		UPDATE epacctotal
		SET available = ISNULL(ET.curramount, 0) - isnull(SE.amount,0),
			available2 = ISNULL(ET.curramount2, 0) - isnull(SE.amount2,0),
			available3 = ISNULL(ET.curramount3, 0) - isnull(SE.amount3,0),
			available4 = ISNULL(ET.curramount4, 0) - isnull(SE.amount4,0),
			available5 = ISNULL(ET.curramount5, 0) - isnull(SE.amount5,0)
		from epacctotal ET
		left outer join sumexptot SE on ET.idepacc=SE.idepacc and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

	with sumcosttot(idepacc,ayear,amount) as
		(select ED.idepacc, ED.yentry, SUM(ED.amount) from 
			entrydetail ED  JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 128 <>0) and ED.idepacc is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepacc, ED.yentry
		)
		UPDATE epacctotal
		SET revenue = SE.amount
		from epacctotal ET
			join sumcosttot SE on ET.idepacc=SE.idepacc and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;


	with sumcredittot(idepacc,ayear,amount) as
		(select ED.idepacc, ED.yentry, SUM(amount) from 
			entrydetail ED  JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc 
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 32 <>0) and ED.idepacc is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepacc, ED.yentry
		)
		UPDATE epacctotal
		SET credit = -SE.amount
		from epacctotal ET
			join sumcredittot SE on ET.idepacc=SE.idepacc and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;
	--opposto rispetto al prec.
	with sumdebittot(idepacc,ayear,amount) as
		(select ED.idepacc, ED.yentry, SUM(amount) from 
			entrydetail ED  JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc 
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 16 <>0) and ED.idepacc is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepacc, ED.yentry
		)
		UPDATE epacctotal
		SET credit = isnull(credit,0)+SE.amount
		from epacctotal ET
			join sumdebittot SE on ET.idepacc=SE.idepacc and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

with sumrateotot(idepacc,ayear,amount) as
		(select ED.idepacc, ED.yentry, SUM(ED.amount) from 
			entrydetail ED  JOIN entry E on ED.yentry = E.yentry AND ED.nentry = E.nentry 
			join account A on ED.idacc=A.idacc
				WHERE     ((@ayear is null) OR ED.yentry=@ayear) and (A.flagaccountusage & 1 <>0) and ED.idepacc is not null
				and E.identrykind NOT IN (6,10,11,12)
				group by ED.idepacc, ED.yentry
		)
		UPDATE epacctotal
		SET rateo = SE.amount
		from epacctotal ET
			join sumrateotot SE on ET.idepacc=SE.idepacc and ET.ayear=SE.ayear 
			where ((@ayear is null)  OR ET.ayear=@ayear)
;

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 