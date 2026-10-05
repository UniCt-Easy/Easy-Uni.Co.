/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

/*--------------------------------------------------------------------------------------------------------------------------

			Questa stored procedure legge dal DB utente e scrive nella tabella  "account_td" del db  >> DataWareHouse_ENTE <<				 

---------------------------------------------------------------------------------------------------------------------------*/

-- setuser'amministrazione'
--exec compute_dw_account_td
if exists (select * from dbo.sysobjects where id = object_id(N'compute_dw_account_td') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure compute_dw_account_td
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--- exec compute_dw_account_td
-- select * from DataWareHouse_ENTE.dbo.account_td
Create PROCEDURE [compute_dw_account_td]
AS
BEGIN
	DELETE DataWareHouse_ENTE.dbo.account_td

	DECLARE @dtelab date

	SET @dtelab = GETDATE()

	INSERT INTO DataWareHouse_ENTE.dbo.account_td( 
			ayear, idacc, paridacc,
			codicecontoeconomico,
			codicestaopatrimoniale,
			codeacc,
			accounttitle,
 			tipoconto,
			actual_codicecontoeconomico
			  )
	SELECT accountview.ayear,idacc ,paridacc,
		case when accountview.codeplaccount is not null then 'CE - '+ trim(accountview.codeplaccount)+': '+ trim(accountview.placcount)
			else null
		end,

		case when accountview.codepatrimony is not null then 'SP.'+patrimony.patpart +' - '+ trim(accountview.codepatrimony)+': '+trim(accountview.patrimony)
				else null
		end,
		codeacc,
		codeacc+' - '+accountview.title , 
		accountkind.description as tipoconto,

		(SELECT 'CE - ' + trim(LK.codeplaccount_new) + ': '+ trim(LK.title)
			from lookupprintedplaccount LK
			where accountview.codeplaccount = LK.codeplaccount_old
			and accountview.ayear <= LK.ayear_old)

		FROM accountview
			LEFT OUTER JOIN accountkind	(NOLOCK)	ON accountkind.idaccountkind = accountview.idaccountkind
			LEFT OUTER JOIN patrimony	(NOLOCK)	ON accountview.idpatrimony=patrimony.idpatrimony
		WHERE accountview.ayear >= YEAR(GETDATE())-6
	


	update	DataWareHouse_ENTE.dbo.account_td set actual_codicecontoeconomico = codicecontoeconomico
						where actual_codicecontoeconomico is null
 
	UPDATE DataWareHouse_ENTE.dbo.account_td set tipoconto = 'Costi' 
						where tipoconto = 'Amm.to e Svalut.ne'

-- valorizziamo il campo "actual_codicecontoeconomico" perch  dal 2024 al 2025 il conto economico   cambiato, per cui se ci posizioniamo nel 2025, non potremo avere una corrispondeza con gli es. pecedenti,
-- se domani ci posizioniam nel 2026 , non potremo avere la corrispondenza lioneare col 2024, 2023...
-- i dati della matrice vengono calcolati dalla sp, nel report possiamo solo visualizzarli opportunamente
-- Al momento dal 2024, a decrescere funziona bene, ma dal 2024 in poi c'   il problema

-- Per risolvere la situazione ho pensato di attualizzare i conti del CE all'ultimo esercizio, ossia all' YEAR(GETDATE()), 
-- e quindi usare il campo "actual_codicecontoeconomico"


END


GO

-- select * from DataWareHouse_ENTE.dbo.account_td
