
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rebuild_underwritingincometotal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rebuild_underwritingincometotal]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE        PROCEDURE [rebuild_underwritingincometotal]
(
	@ayear int = null
)
AS BEGIN
DECLARE @arrearsphase tinyint
SELECT @arrearsphase = 1
SELECT @arrearsphase = incomefinphase FROM uniconfig

DECLARE @MAXphase tinyint
SELECT @MAXphase = max(nphase) FROM incomephase

IF (@ayear IS NULL) 
BEGIN
	DELETE FROM underwritingincometotal

;with sommafin(idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears) 
AS ( 				
	SELECT 
		I.idunderwriting,	IY.idupb, F.idfin, I.nphase,
		SUM (case when (IT.flag & 1) = 0 then IY.amount else 0 end),
		SUM (case when (IT.flag & 1) <> 0 then IY.amount else 0 end)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	LEFT OUTER JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink 
		ON finlink.idchild = IY.idfin
	JOIN fin F
		ON finlink.idparent = F.idfin
	WHERE (I.nphase = @arrearsphase or I.nphase = @MAXphase)
		AND ((F.flag & 1) = 0)
		AND I.idunderwriting IS NOT NULL
	GROUP BY I.idunderwriting,IY.idupb, F.idfin, I.nphase
	
	UNION ALL
		 SELECT 
		  E.idunderwriting,  EY.idupb, F.idfin, E.nphase,
		  SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
		  SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
		 FROM incomevar EV    
		 JOIN income E      ON E.idinc = EV.idinc 
		 JOIN incomeyear EY     ON EV.idinc = EY.idinc and EV.yvar=EY.ayear
		 JOIN incometotal ET    ON ET.idinc = EY.idinc AND ET.ayear = EY.ayear
		 JOIN finlink      ON finlink.idchild = EY.idfin
		 JOIN fin F       ON finlink.idparent = F.idfin
		 WHERE (E.nphase = @arrearsphase or E.nphase = @MAXphase)  AND ((F.flag & 1) = 0) and E.idunderwriting is not null
		 GROUP BY E.idunderwriting,EY.idupb, F.idfin,E.nphase
 
	)
	
	INSERT INTO underwritingincometotal (
		idunderwriting, idupb, idfin, nphase,
		totalcompetency,
		totalarrears
	)
	SELECT idunderwriting,idupb,idfin,nphase,sum(totalcompetency),sum(totalarrears) 
	FROM sommafin  group by idunderwriting,idupb,idfin,nphase
		
END	
ELSE
BEGIN
	DELETE FROM underwritingincometotal WHERE EXISTS(SELECT fin.idfin FROM fin WHERE fin.idfin = underwritingincometotal.idfin
		AND fin.ayear = @ayear)

;with sommafin(idunderwriting,idupb,idfin,nphase,totalcompetency,totalarrears) 
AS ( 				
	SELECT 
		I.idunderwriting,	IY.idupb, F.idfin,I.nphase,
		SUM (case when (IT.flag & 1) = 0 then IY.amount else 0 end),
		SUM (case when (IT.flag & 1) <> 0 then IY.amount else 0 end)
	FROM incomeyear IY
	JOIN income I
		ON I.idinc = IY.idinc
	LEFT OUTER JOIN incometotal IT
		ON IT.idinc = IY.idinc
		AND IT.ayear = IY.ayear
	JOIN finlink 
		ON finlink.idchild = IY.idfin
	JOIN fin F
		ON finlink.idparent = F.idfin
	WHERE (I.nphase = @arrearsphase or I.nphase = @MAXphase)
		AND F.ayear = @ayear
		AND IY.ayear = @ayear
		AND ((F.flag & 1) = 0)
		AND I.idunderwriting IS NOT NULL
	GROUP BY I.idunderwriting, IY.idupb, F.idfin, I.nphase
	UNION ALL
	 SELECT 
	  E.idunderwriting,  EY.idupb, F.idfin, E.nphase,
	  SUM (case when (ET.flag & 1) = 0 then EV.amount else 0 end),
	  SUM (case when (ET.flag & 1) <> 0 then EV.amount else 0 end)
	 FROM incomevar EV    
	 JOIN income E      ON E.idinc = EV.idinc 
	 JOIN incomeyear EY     ON EV.idinc = EY.idinc and EV.yvar=EY.ayear
	 JOIN incometotal ET    ON ET.idinc = EY.idinc AND ET.ayear = EY.ayear
	 JOIN finlink      ON finlink.idchild = EY.idfin
	 JOIN fin F       ON finlink.idparent = F.idfin
	 WHERE (E.nphase = @arrearsphase or E.nphase = @MAXphase)  AND ((F.flag & 1) = 0) and E.idunderwriting is not null
	 AND F.ayear = @ayear
	 AND EY.ayear = @ayear
	 GROUP BY E.idunderwriting,EY.idupb, F.idfin,E.nphase
	)
	
	INSERT INTO underwritingincometotal (
		idunderwriting, idupb, idfin, nphase,
		totalcompetency,
		totalarrears
	)
	SELECT idunderwriting,idupb,idfin,nphase,sum(totalcompetency),sum(totalarrears) 
	FROM sommafin group by idunderwriting,idupb,idfin,nphase

END
	
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
