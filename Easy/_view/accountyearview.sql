-- CREAZIONE VISTA accountyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountyearview]
GO




CREATE  VIEW accountyearview
(
	ayear,
	idacc,
	codeacc,
	account,
	idupb,
	codeupb,
	upb,
	paridacc,
	paridupb,
	nlevel,
	leveldescr,
	prevision,
	prevision2,
	prevision3,
	prevision4,
	prevision5,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,	
	flagaccountusage,
	ct,
	cu,
	lt,
	lu
)
AS SELECT 
accountyear.ayear,
accountyear.idacc,
account.codeacc,
account.title,
upb.idupb,
upb.codeupb,
upb.title,
account.paridacc,
upb.paridupb,
account.nlevel,
accountlevel.description,
accountyear.prevision,
accountyear.prevision2,
	accountyear.prevision3,
	accountyear.prevision4,
	accountyear.prevision5,
upb.idsor01,
upb.idsor02,
upb.idsor03,
upb.idsor04,
upb.idsor05,	
account.flagaccountusage,
accountyear.ct,
accountyear.cu,
accountyear.lt,
accountyear.lu
FROM accountyear
JOIN account
	ON accountyear.idacc = account.idacc
JOIN upb
	ON upb.idupb = accountyear.idupb
JOIN accountlevel
	ON accountlevel.nlevel = account.nlevel
	AND accountlevel.ayear = account.ayear





GO
