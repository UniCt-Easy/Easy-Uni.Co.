
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


-- CREAZIONE VISTA accountview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountview]
GO
--setuser'amm'
-- setuser 'amministrazione'
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
		rateiattivi,	--Ratei attivi
		rateipassivi,	--Ratei Passivi
		riscontiattivi,	--Risconti Attivi
		riscontipassivi,--Risconti Passivi
		debit,			--Debito
		credit,			--Credito
		cost,			--Costi
		revenue,		--Ricavi
		fixedassets,	--Immobilizzazioni
		freeusesurplus,	--Avanzo libero
		captiveusesurplus,--Avanzo vincolato
		reserve,	   --Riserva
		provision,     --Accantonamento
		cash,		   --Disponibilità liquide
		otheritems_A,  --Altre voci dell'attivo
		otheritems_P,  --Altre voci del passivo
		amortization,  --Ammortamento
		reservecofi,   --Ex Riserve COFI
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
		CASE 		when (( account.flagaccountusage & 8) = 0)  then 'N'  ELSE 'S' END, --Risconti Passivi
		CASE 		when (( account.flagaccountusage & 16) = 0)  then 'N'  ELSE 'S' END, -- Debito
		CASE 		when (( account.flagaccountusage & 32) = 0)  then 'N'  ELSE 'S' END, -- Credito
		CASE 		when (( account.flagaccountusage & 64) = 0)  then 'N'  ELSE 'S' END, -- Costi
		CASE 		when (( account.flagaccountusage & 128) = 0)  then 'N'  ELSE 'S' END, -- Ricavi
		CASE 		when (( account.flagaccountusage & 256) = 0)  then 'N'  ELSE 'S' END, -- Immobilizzazioni
		CASE 		when (( account.flagaccountusage & 512) = 0)  then 'N'  ELSE 'S' END,  --Avanzo libero
		CASE 		when (( account.flagaccountusage & 1024) = 0)  then 'N'  ELSE 'S' END, -- Avanzo vincolato
		CASE 		when (( account.flagaccountusage & 2048) = 0)  then 'N'  ELSE 'S' END, -- Riserva
		CASE 		when (( account.flagaccountusage & 4096) = 0)  then 'N'  ELSE 'S' END, --Accantonamento
		CASE 		when (( account.flagaccountusage & 8192) = 0)  then 'N'  ELSE 'S' END, --Disponibilità liquide
		CASE 		when (( account.flagaccountusage & 16384) = 0)  then 'N'  ELSE 'S' END, --Altre voci dell'attivo
		CASE 		when (( account.flagaccountusage & 65536) = 0)  then 'N'  ELSE 'S' END, --Altre voci del passivo
		CASE 		when (( account.flagaccountusage & 131072) = 0)  then 'N'  ELSE 'S' END, --Ammortamento
		CASE 		when (( account.flagaccountusage & 262144) = 0)  then 'N'  ELSE 'S' END, --Ex Riserve COFI
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
