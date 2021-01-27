
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



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[compute_transf_prevision_in_budget]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_transf_prevision_in_budget]
GO

CREATE PROCEDURE compute_transf_prevision_in_budget
(
	@ayear int,
	@idsorkind int
)
AS BEGIN
-- Noi prendiamo in considerazione la previsione principale
-- compute_transf_prevision_in_budget 2013, 21
CREATE TABLE #budgetprevision
(
	finpart char (1),
	idupb varchar(36),
	idfin int,
	nlevel tinyint,
	prevision decimal (19,2),
	previousprevision decimal (19,2),
	prevision2 decimal (19,2),
	prevision3 decimal (19,2),
	prevision4 decimal (19,2),
	prevision5 decimal (19,2),
	idsor int
)

INSERT INTO #budgetprevision
(
	finpart,
	idfin,
	idupb,
	nlevel,
	prevision,
	previousprevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor
)

SELECT 
	CASE
		WHEN ((f.flag&1)=0) THEN 'E'
		WHEN ((f.flag&1)=1) THEN 'S'
	END,
	f.idfin,
	u.idupb,
	f.nlevel,
	ISNULL(SUM(finyear.prevision),0) * fs.quota,
	ISNULL(SUM(finyear.previousprevision),0) * fs.quota ,
	ISNULL(SUM(finyear.prevision2),0) * fs.quota,
	ISNULL(SUM(finyear.prevision3),0) * fs.quota,
	ISNULL(SUM(finyear.prevision4),0) * fs.quota,
	ISNULL(SUM(finyear.prevision5),0) * fs.quota,
	fs.idsor
FROM finyear 
JOIN fin f 
        ON f.idfin = finyear.idfin
JOIN finlast fl 
        ON f.idfin = fl.idfin
JOIN upb u 
        ON u.idupb = finyear.idupb
JOIN finsorting fs
		ON f.idfin = fs.idfin
JOIN sorting s
		ON  s.idsor = fs.idsor
WHERE f.ayear = @ayear
  AND s.idsorkind = @idsorkind
GROUP BY f.idfin, u.idupb,s.idsor,fs.idsor, fs.quota,
        f.paridfin, f.flag,f.nlevel

delete from budgetprevision where ayear = @ayear and idsor in
(select idsor from sorting where idsorkind = @idsorkind)

print 'cancellazione previsioni'

INSERT INTO budgetprevision
(
	idupb,
	idsor,
	ayear,
	prevision,
	previousprevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	ct,
	cu,
	lt,
	lu
)
SELECT 
	#budgetprevision.idupb,
	#budgetprevision.idsor,
	@ayear,
	SUM(#budgetprevision.prevision),
	SUM(#budgetprevision.previousprevision),
	SUM(#budgetprevision.prevision2),
	SUM(#budgetprevision.prevision3),
	SUM(#budgetprevision.prevision4),
	SUM(#budgetprevision.prevision5),
	GetDate(),
	'trasf_previsioni',
	GetDate(),
	'trasf_previsioni'
FROM  #budgetprevision
GROUP BY #budgetprevision.idupb,
	#budgetprevision.idsor

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
