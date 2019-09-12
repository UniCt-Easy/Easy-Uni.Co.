-- CREAZIONE VISTA accountminusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountminusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accountminusable]
GO

CREATE VIEW [dbo].[accountminusable]
(
	idacc,
	ayear,
	codeacc,
	paridacc,
	nlevel,
	printingorder,
	title,
	idaccountkind,
	accountkind,
	flagda,
	flagregistry,
	flagupb,
	flagtransitory,
	flagenablebudgetprev,
	cu,
	ct,
	lu,
	lt
)
	AS SELECT
	account.idacc,
	account.ayear,
	account.codeacc,
	account.paridacc,
	account.nlevel,
	account.printingorder,
	account.title,
	account.idaccountkind,
	accountkind.description,
	accountkind.flagda,
	account.flagregistry,
	account.flagupb,
	account.flagtransitory,
	account.flagenablebudgetprev,
	account.cu,
	account.ct,
	account.lu,
	account.lt
	FROM account (NOLOCK)
	JOIN accountlevel (NOLOCK) 
		ON accountlevel.ayear = account.ayear
		AND accountlevel.nlevel = account.nlevel
	left outer JOIN accountkind (NOLOCK) 
		on  accountkind.idaccountkind=account.idaccountkind
	WHERE account.nlevel = (SELECT min(nlevel) from accountlevel where ayear = account.ayear and (flagusable='S'))








GO


