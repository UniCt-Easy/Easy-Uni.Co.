-- CREAZIONE VISTA finyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[finyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finyearview]
GO




CREATE                                VIEW [finyearview]
(
	ayear,
	idfin,
	codefin,
	finance,
	flag,
	finpart,
	paridfin,
	nlevel,
	leveldescr,
	idupb,
	codeupb,
	upb,
	paridupb,
	prevision,
	secondaryprev,
	previousprevision,
	previoussecondaryprev,
	currentarrears,
	previousarrears,
	limit,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	ct,
	cu,
	lt,
	lu
)
AS
SELECT
finyear.ayear,
finyear.idfin,
fin.codefin,
fin.title,
fin.flag,
CASE
	WHEN ((fin.flag&1)=0) THEN 'E'
	WHEN ((fin.flag&1)=1) THEN 'S'
END,
fin.paridfin,
fin.nlevel,
finlevel.description,
finyear.idupb,
upb.codeupb,
upb.title,
upb.paridupb,
finyear.prevision,
finyear.secondaryprev,
finyear.previousprevision,
finyear.previoussecondaryprev,
finyear.currentarrears,
finyear.previousarrears,
finyear.limit,
finyear.prevision2,
finyear.prevision3,
finyear.prevision4,
finyear.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
finyear.ct,
finyear.cu,
finyear.lt,
finyear.lu
FROM finyear
JOIN fin
ON finyear.idfin = fin.idfin
JOIN upb
ON finyear.idupb = upb.idupb
JOIN finlevel
ON finlevel.nlevel = fin.nlevel
AND finlevel.ayear = fin.ayear






GO
