
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


-- CREAZIONE VISTA accountsortingbudgetview
IF EXISTS(select * from sysobjects where id = object_id(N'[accountsortingbudgetview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [accountsortingbudgetview]
GO
--setuser'amm'
-- setuser 'amministrazione'
-- clear_table_info'accountsortingbudgetview'
-- select * from accountsortingbudgetview where ayear = 2020 and idacc <> paridacc

CREATE   VIEW [accountsortingbudgetview]
	(
		idacc,
		ayear,
		codeacc,
		printingorder,
		title,
		nlevel,
		accountlevel,
		paridacc,
		parentayear,
		parentcodeacc,
		parentprintingorder,
		parenttitle,
		parentnlevel,
		minlevop,
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
		account.printingorder,
		account.title,
		account.nlevel,
		accountlevel.description,
		parent.idacc,
		parent.ayear,
		parent.codeacc,
		parent.printingorder,
		parent.title,
		parent.nlevel,
		minlevop.description,
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
		parent.economicbudget_sign,
		case when isnull(parent.economicbudget_sign,'S')='S' then 1 else -1 end,
		SI.idsor,SI.sortcode,
		parent.investmentbudget_sign,
		case when isnull(parent.investmentbudget_sign,'S')='S' then 1 else -1 end,
		account.cu,
		account.ct,
		account.lu,
		account.lt
		FROM account (NOLOCK)
		JOIN accountlevel			(NOLOCK)	ON account.nlevel = accountlevel.nlevel	AND account.ayear = accountlevel.ayear
		JOIN accountlevel	 minlevop		(NOLOCK) on	 minlevop.nlevel = (select min(nlevel) from accountlevel 
																			where ayear = account.ayear and flagusable = 'S')	
																			AND account.ayear = minlevop.ayear
		JOIN account parent	(NOLOCK)	ON parent.idacc  =  substring(account.idacc, 1, 2 + 4*minlevop.nlevel) AND minlevop.nlevel =parent.nlevel
		

		LEFT OUTER JOIN sorting SE	(NOLOCK)	ON parent.idsor_economicbudget = SE.idsor
		LEFT OUTER JOIN sorting SI	(NOLOCK)	ON parent.idsor_investmentbudget = SI.idsor

GO
