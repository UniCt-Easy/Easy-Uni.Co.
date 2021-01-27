
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_account_accmotive]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_account_accmotive]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 -- [exp_account_accmotive] 2016,'ASSOCIATI' 
CREATE    PROCEDURE [exp_account_accmotive] 
(
	@ayear int,
	@kind  varchar(20) -- 'ASSOCIATI', 'CONTINONASSOC', 'CAUSALINONASSOC'
)
AS
BEGIN
IF ISNULL(@kind, 'ASSOCIATI') = 'ASSOCIATI'
BEGIN
	SELECT 
	accmotivedetail.ayear AS 'Esercizio',
	accmotive.codemotive AS 'Codice Causale', 
	accmotive.title AS 'Denominazione Causale', 
	account.codeacc as 'Codice Piano de Conti',
	account.title as 'Denominazione piano dei Conti',
	accountlevel.description AS 'Livello Conto',
	patrimony.codepatrimony AS 'Codice Stato Patrimoniale',
	patrimony.title AS 'Denominazione Stato Patrimoniale',
	placcount.codeplaccount AS 'Codice Conto Economico',
	placcount.title AS 'Denominazione Conto Economico',
	sortingkind.description as 'Tipo Classificazione',
	sorting.sortcode as 'Codice class.',
	sorting.description as 'Descr. Class'
	FROM accmotive
		JOIN accmotivedetail
			ON accmotive.idaccmotive = accmotivedetail.idaccmotive
		JOIN account 
			ON accmotivedetail.idacc = account.idacc
			AND accmotivedetail.ayear = account.ayear
		JOIN accountlevel
			ON account.nlevel = accountlevel.nlevel
			AND account.ayear = accountlevel.ayear
		LEFT OUTER JOIN patrimony
			ON account.idpatrimony = patrimony.idpatrimony
			AND account.ayear = patrimony.ayear
			AND patrimony.active = 'S'
		LEFT OUTER JOIN placcount
			on account.idplaccount = placcount.idplaccount
			and account.ayear = placcount.ayear
			AND placcount.active = 'S'
		LEFT OUTER JOIN accmotivesorting
			on accmotivesorting.idaccmotive =  accmotive.idaccmotive
		LEFT OUTER JOIN sorting
			on accmotivesorting.idsor =  sorting.idsor
		LEFT OUTER JOIN sortingkind
			on sortingkind.idsorkind =  sorting.idsorkind
	WHERE accmotivedetail.ayear = @ayear
 
	RETURN
END

IF ISNULL(@kind, 'ASSOCIATI') = 'CONTINONASSOC'
BEGIN
SELECT 
account.codeacc as 'Codice Piano de Conti',
account.title as 'Denominazione piano dei Conti',
accountlevel.description AS 'Livello Conto',
patrimony.codepatrimony AS 'Codice Stato Patrimoniale',
patrimony.title AS 'Denominazione Stato Patrimoniale',
placcount.codeplaccount AS 'Codice Conto Economico',
placcount.title AS 'Denominazione Conto Economico',
PARACC.codeacc as 'Codice Conto Padre',
PARACC.title as 'Denominazione Conto Padre'

FROM account 
	JOIN accountlevel
		ON account.nlevel = accountlevel.nlevel
		AND account.ayear = accountlevel.ayear
	LEFT OUTER JOIN patrimony
		ON account.idpatrimony = patrimony.idpatrimony
		AND account.ayear = patrimony.ayear
		AND patrimony.active = 'S'
	LEFT OUTER JOIN placcount
		on account.idplaccount = placcount.idplaccount
		and account.ayear = placcount.ayear
		AND placcount.active = 'S'
	LEFT OUTER JOIN account PARACC
		ON PARACC.idacc = account.paridacc 
		AND PARACC.ayear = account.ayear
WHERE account.ayear = @ayear
AND NOT EXISTS (SELECT * FROM accmotivedetail WHERE accmotivedetail.idacc = account.idacc
		AND accmotivedetail.ayear = account.ayear )
AND NOT EXISTS (SELECT * FROM account CHILD WHERE CHILD.paridacc = account.idacc)

RETURN
END 


IF ISNULL(@kind, 'ASSOCIATI') = 'CAUSALINONASSOC'
BEGIN
	SELECT 
	@ayear AS 'Esercizio',
	accmotive.codemotive AS 'Codice Causale', 
	accmotive.title AS 'Denominazione Causale',
	accmotive.active AS 'Attiva',
	PARACCMOTIVE.codemotive AS 'Codice Causale Padre', 
	PARACCMOTIVE.title AS 'Denominazione Causale Padre',
	sortingkind.description as 'Tipo Classificazione',
	sorting.sortcode as 'Codice class.',
	sorting.description as 'Descr. Class'
	FROM accmotive 
	LEFT OUTER JOIN accmotive PARACCMOTIVE
		ON PARACCMOTIVE.idaccmotive = accmotive.paridaccmotive 
	LEFT OUTER JOIN accmotivesorting
		on accmotivesorting.idaccmotive =  accmotive.idaccmotive
	LEFT OUTER JOIN sorting
		on accmotivesorting.idsor =  sorting.idsor
	LEFT OUTER JOIN sortingkind
		on sortingkind.idsorkind =  sorting.idsorkind
	WHERE  NOT EXISTS (SELECT * FROM accmotivedetail WHERE accmotivedetail.idaccmotive = accmotive.idaccmotive
			AND accmotivedetail.ayear = @ayear )
	AND NOT EXISTS (SELECT * FROM accmotive CHILD WHERE CHILD.paridaccmotive = accmotive.idaccmotive)
	AND accmotive.active = 'S' 
END 



END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



