-- CREAZIONE VISTA accountview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountview]
GO

-- setuser 'amm'
-- clear_table_info'accountview'
-- select * from accountview

CREATE   VIEW [accountview]
	(
		idacc,
		ayear,
		codeacc,
		paridacc,
		printingorder,
		title,
		flagtransitory,
		nlevel,
		leveldescr,
		idaccountkind,
		flagda,
		accountkinddescr,
		flagregistry,
		flagupb,
		idplaccount,
		codeplaccount,
		placcount,
		idpatrimony,
		codepatrimony,
		patrimony,
		flagcompetency,
		flagprofit,
		flagloss,
		placcount_sign,
		placcount_sign_value,
		patrimony_sign,
		patrimony_sign_value,
		ignoreregistryonepilogue,
		ignoreupbonepilogue,
		ignoremovbudgetonepilogue,
		flag_offbalance,
		flagenablebudgetprev,
		flag,
		idacc_special,
		flagaccountusage,
		rateiattivi,
		rateipassivi,
		riscontiattivi,
		riscontipassivi,
		debit,
		credit,
		cost,
		revenue,
		fixedassets,
		freeusesurplus,
		captiveusesurplus,
		reserve,
		provision,
		idsor_economicbudget,
		sortcode_economicbudget,
		economicbudget_sign,
		economicbudget_sign_value,
		idsor_investmentbudget,
		sortcode_investmentbudget,
		investmentbudget_sign,
		investmentbudget_sign_value,
		cu,
		ct,
		lu,
		lt
	)
	AS
	SELECT
		account.idacc,
		account.ayear,
		account.codeacc,
		account.paridacc,
		account.printingorder,
		account.title,
		account.flagtransitory,
		account.nlevel,
		accountlevel.description,
		account.idaccountkind,
		accountkind.flagda,
		accountkind.description,
		account.flagregistry,
		account.flagupb,
		placcount.idplaccount,
		placcount.codeplaccount,
		placcount.title,
		patrimony.idpatrimony,
		patrimony.codepatrimony,
		patrimony.title,
		account.flagcompetency,
		account.flagprofit,
		account.flagloss,
		account.placcount_sign,
		case when isnull(account.placcount_sign,'S')='S' then 1 else -1 end,
		account.patrimony_sign,
		case when isnull(account.patrimony_sign,'S')='S' then 1 else -1 end,
		CASE 			when (( account.flag & 1) = 0)  then 'N' ELSE 'S'	END, --ignoreregistryonepilogue,			
		CASE			when (( account.flag & 2) = 0)  then 'N' ELSE  'S' 	END, --ignoreupbonepilogue,
		CASE			when (( account.flag & 8) = 0)  then 'N' ELSE  'S' 	END, --ignoremovbudgetonepilogue,
		CASE			when (( account.flag & 4) = 0)  then 'N' ELSE  'S' 	END, --flag_offbalance,
		account.flagenablebudgetprev,
		account.flag,
		account.idacc_special,
		account.flagaccountusage,
		CASE 		when (( account.flagaccountusage & 1) = 0)  then 'N'  ELSE 'S' END, -- Ratei attivi
		CASE 		when (( account.flagaccountusage & 2) = 0)  then 'N'  ELSE 'S' END, -- Ratei Passivi
		CASE 		when (( account.flagaccountusage & 4) = 0)  then 'N'  ELSE 'S' END, -- Risconti Attivi
		CASE 		when (( account.flagaccountusage & 8) = 0)  then 'N'  ELSE 'S' END,  --Risconti Passivi
		CASE 		when (( account.flagaccountusage & 16) = 0)  then 'N'  ELSE 'S' END, -- Debito
		CASE 		when (( account.flagaccountusage & 32) = 0)  then 'N'  ELSE 'S' END, -- Credito
		CASE 		when (( account.flagaccountusage & 64) = 0)  then 'N'  ELSE 'S' END, -- Costi
		CASE 		when (( account.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END, -- Ricavi
		CASE 		when (( account.flagaccountusage & 256) = 0)  then 'N'  ELSE 'S' END, -- Immobilizzazioni
		CASE 		when (( account.flagaccountusage & 512) = 0)  then 'N'  ELSE 'S' END,  --Avanzo libero
		CASE 		when (( account.flagaccountusage & 1024) = 0)  then 'N'  ELSE 'S' END, -- Avanzo vincolato
		CASE 		when (( account.flagaccountusage & 2048) = 0)  then 'N'  ELSE 'S' END, -- Riserva
		CASE 		when (( account.flagaccountusage & 4096) = 0)  then 'N'  ELSE 'S' END, --Accantonamento
		SE.idsor, SE.sortcode,
		account.economicbudget_sign,
		case when isnull(account.economicbudget_sign,'S')='S' then 1 else -1 end,
		SI.idsor,SI.sortcode,
		account.investmentbudget_sign,
		case when isnull(account.investmentbudget_sign,'S')='S' then 1 else -1 end,
		account.cu,
		account.ct,
		account.lu,
		account.lt
		FROM account (NOLOCK)
		JOIN accountlevel			(NOLOCK)	ON account.nlevel = accountlevel.nlevel			AND account.ayear = accountlevel.ayear
		LEFT OUTER JOIN accountkind	(NOLOCK)	ON accountkind.idaccountkind = account.idaccountkind
		LEFT OUTER JOIN patrimony	(NOLOCK)	ON account.idpatrimony=patrimony.idpatrimony
		LEFT OUTER JOIN placcount	(NOLOCK)	ON account.idplaccount = placcount.idplaccount
		LEFT OUTER JOIN sorting SE	(NOLOCK)	ON account.idsor_economicbudget = SE.idsor
		LEFT OUTER JOIN sorting SI	(NOLOCK)	ON account.idsor_investmentbudget = SI.idsor

GO
