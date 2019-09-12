-- CREAZIONE VISTA accountusable
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[accountusable]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[accountusable]
GO


CREATE VIEW [dbo].[accountusable]
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
	flagaccountusage,
	idpatrimony,
	idplaccount,
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
	account.flagaccountusage,
	account.idpatrimony,
	account.idplaccount,
	account.cu,
	account.ct,
	account.lu,
	account.lt
	FROM account (NOLOCK)
	JOIN accountlevel (NOLOCK) 	ON accountlevel.ayear = account.ayear	AND accountlevel.nlevel = account.nlevel
	JOIN accountkind (NOLOCK) 	on  accountkind.idaccountkind=account.idaccountkind
	WHERE accountlevel.flagusable = 'S'	and
			(SELECT count(*) FROM account b1 WHERE b1.paridacc = account.idacc )=0

GO
