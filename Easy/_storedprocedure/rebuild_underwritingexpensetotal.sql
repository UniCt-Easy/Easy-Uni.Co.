
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_underwritingexpensetotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_underwritingexpensetotal]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE        PROCEDURE [rebuild_underwritingexpensetotal]
(
	@ayear int = null
)
AS BEGIN
DECLARE @arrearsphase tinyint
SELECT @arrearsphase = 1
SELECT @arrearsphase = expensefinphase FROM uniconfig

DECLARE @MAXphase tinyint
SELECT @MAXphase = max(nphase) FROM expensephase


IF (@ayear IS NULL) 
BEGIN
	DELETE FROM underwritingexpensetotal
	
;with sommafin(idunderwriting,idupb,idfin,totalcompetency,totalarrears) 
AS ( 				
	SELECT 
		U.idunderwriting,	EY.idupb, F.idfin,
		SUM (case when (ET.flag & 1) = 0 then U.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then U.amount else 0 end)
	FROM underwritingappropriation U
	JOIN expenseyear EY			   		ON U.idexp = EY.idexp
	JOIN expense E						ON E.idexp = EY.idexp
	JOIN expensetotal ET				ON ET.idexp = EY.idexp		AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @arrearsphase AND ((F.flag & 1) <>0)
	GROUP BY U.idunderwriting,EY.idupb, F.idfin
	UNION ALL
	SELECT 
		EV.idunderwriting,	EY.idupb, F.idfin,
		SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
	FROM expensevar EV				
	JOIN expense E						ON E.idexp = EV.idexp 
	JOIN expenseyear EY					ON EV.idexp = EY.idexp and EV.yvar=EY.ayear
	JOIN expensetotal ET				ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @arrearsphase 	AND ((F.flag & 1) <>0) and EV.idunderwriting is not null
	GROUP BY EV.idunderwriting,EY.idupb, F.idfin
)
INSERT into underwritingexpensetotal (idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears)
		select idunderwriting,idupb,idfin,@arrearsphase,sum(totalcompetency),sum(totalarrears) 
		from sommafin group by idunderwriting,idupb,idfin


;with sommafin(idunderwriting,idupb,idfin,totalcompetency,totalarrears) 
AS ( 		
	SELECT 
		U.idunderwriting,		EY.idupb, F.idfin, 
		SUM (case when (ET.flag & 1) = 0 then U.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then U.amount else 0 end)
	FROM underwritingpayment U
	JOIN expenseyear EY			   		ON U.idexp = EY.idexp
	JOIN expense E						ON E.idexp = EY.idexp
	JOIN expensetotal ET				ON ET.idexp = EY.idexp		AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @MAXphase	AND ((F.flag & 1) <>0)
	GROUP BY U.idunderwriting,EY.idupb, F.idfin
	UNION ALL
	SELECT 
		EV.idunderwriting, 	EY.idupb, F.idfin, 
		SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
	FROM expensevar EV				
	JOIN expense E						ON E.idexp = EV.idexp 
	JOIN expenseyear EY					ON EV.idexp = EY.idexp and EV.yvar=EY.ayear
	JOIN expensetotal ET				ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @MAXphase  	AND ((F.flag & 1) <>0) and EV.idunderwriting is not null
	GROUP BY EV.idunderwriting,EY.idupb, F.idfin
)
INSERT into underwritingexpensetotal (idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears)
		select idunderwriting,idupb,idfin,@MAXphase,sum(totalcompetency),sum(totalarrears) 
		from sommafin group by idunderwriting,idupb,idfin


END	
ELSE
BEGIN
	DELETE FROM underwritingexpensetotal 
	WHERE EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = underwritingexpensetotal.idfin
				AND fin.ayear = @ayear)

	
;with sommafin(idunderwriting,idupb,idfin,totalcompetency,totalarrears) 
AS ( 				
	SELECT 
		U.idunderwriting,	EY.idupb, F.idfin,
		SUM (case when (ET.flag & 1) = 0 then U.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then U.amount else 0 end)
	FROM underwritingappropriation U
	JOIN expenseyear EY			   		ON U.idexp = EY.idexp
	JOIN expense E						ON E.idexp = EY.idexp
	JOIN expensetotal ET				ON ET.idexp = EY.idexp		AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @arrearsphase AND ((F.flag & 1) <>0) AND EY.ayear=@ayear
	GROUP BY U.idunderwriting,EY.idupb, F.idfin
	UNION ALL
	SELECT 
		EV.idunderwriting,	EY.idupb, F.idfin,
		SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
	FROM expensevar EV				
	JOIN expense E						ON E.idexp = EV.idexp 
	JOIN expenseyear EY					ON EV.idexp = EY.idexp and EV.yvar=EY.ayear
	JOIN expensetotal ET				ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @arrearsphase 	AND ((F.flag & 1) <>0) AND EY.ayear=@ayear and EV.idunderwriting is not null
	GROUP BY EV.idunderwriting,EY.idupb, F.idfin
)
INSERT into underwritingexpensetotal (idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears)
		select idunderwriting,idupb,idfin,@arrearsphase,sum(totalcompetency),sum(totalarrears) 
		from sommafin group by idunderwriting,idupb,idfin


;with sommafin(idunderwriting,idupb,idfin,totalcompetency,totalarrears) 
AS ( 		
	SELECT 
		U.idunderwriting,		EY.idupb, F.idfin, 
		SUM (case when (ET.flag & 1) = 0 then U.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then U.amount else 0 end)
	FROM underwritingpayment U
	JOIN expenseyear EY			   		ON U.idexp = EY.idexp
	JOIN expense E						ON E.idexp = EY.idexp
	JOIN expensetotal ET				ON ET.idexp = EY.idexp		AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @MAXphase	AND ((F.flag & 1) <>0) AND EY.ayear=@ayear
	GROUP BY U.idunderwriting,EY.idupb, F.idfin
	UNION ALL
	SELECT 
		EV.idunderwriting, 	EY.idupb, F.idfin, 
		SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
		SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
	FROM expensevar EV				
	JOIN expense E						ON E.idexp = EV.idexp 
	JOIN expenseyear EY					ON EV.idexp = EY.idexp and EV.yvar=EY.ayear
	JOIN expensetotal ET				ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
	JOIN finlink						ON finlink.idchild = EY.idfin
	JOIN fin F							ON finlink.idparent = F.idfin
	WHERE E.nphase = @MAXphase  	AND ((F.flag & 1) <>0) AND EY.ayear=@ayear and EV.idunderwriting is not null
	GROUP BY 
EV.idunderwriting,EY.idupb, F.idfin
)
INSERT into underwritingexpensetotal (idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears)
		select idunderwriting,idupb,idfin,@MAXphase,sum(totalcompetency),sum(totalarrears) 
		from sommafin group by idunderwriting,idupb,idfin

END
	
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




