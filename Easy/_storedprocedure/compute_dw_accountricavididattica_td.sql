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

			Questa stored procedure legge dal DB utente e scrive nella tabella  "accountricavididattica_td" del db  >> DataWareHouse <<				 

---------------------------------------------------------------------------------------------------------------------------*/

-- setuser'amministrazione'

if exists (select * from dbo.sysobjects where id = object_id(N'compute_dw_accountricavididattica_td') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure compute_dw_accountricavididattica_td
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- exec compute_dw_accountricavididattica_td
-- select * from DataWareHouse_ENTE.dbo.accountricavididattica_td
Create PROCEDURE [compute_dw_accountricavididattica_td]
AS
BEGIN
	DELETE DataWareHouse_ENTE.dbo.accountricavididattica_td

	DECLARE @dtelab date

	SET @dtelab = GETDATE()

	INSERT INTO DataWareHouse_ENTE.dbo.accountricavididattica_td( 
			ayear, idacc, 
			codicecontoeconomico,
			codeacc,
			accounttitle,
			actual_codicecontoeconomico
			  )
	SELECT 
		A.ayear,idacc ,
		case when A.codeplaccount is not null then 'CE - '+A.codeplaccount+': '+A.placcount
			else null
		end,

		A.codeacc,
		A.codeacc+' - '+ A.title , 
		(SELECT 'CE - ' + LK.codeplaccount_new + ': '+ LK.title
			from lookupprintedplaccount LK
			where A.codeplaccount = LK.codeplaccount_old
			and A.ayear <= LK.ayear_old)

		FROM accountview	 A
		JOIN accountlevel (NOLOCK) 	ON accountlevel.ayear = A.ayear	AND accountlevel.nlevel = A.nlevel
		JOIN accountkind (NOLOCK) 	on  accountkind.idaccountkind = A.idaccountkind
		WHERE accountlevel.flagusable = 'S'	and
			(SELECT count(*) FROM account b1 WHERE b1.paridacc = A.idacc )=0
		AND A.ayear >= YEAR(GETDATE())-6
		and ( substring(A.codeplaccount,1,6)= 'a) i 1' or substring(A.codeplaccount,1,7)= 'a) ii 1' )
		and accountkind.description = 'ricavi'


	update	DataWareHouse_ENTE.dbo.accountricavididattica_td set actual_codicecontoeconomico = codicecontoeconomico
				where actual_codicecontoeconomico is null

	
--	;WITH somma_ricavi AS (
--    SELECT
--        idacc,
--        SUM(amount) AS totale_ricavi
--    FROM DataWareHouse_ENTE.dbo.entrydetailfact
--    WHERE rowkind = 'ricavi'
--    GROUP BY idacc
--)
--UPDATE DataWareHouse_ENTE.dbo.accountricavididattica_td 
--	SET amount = s.totale_ricavi
--	FROM somma_ricavi s
--	WHERE DataWareHouse_ENTE.dbo.accountricavididattica_td.idacc = s.idacc;


-- valorizziamo il campo "actual_codicecontoeconomico" perchè dal 2024 al 2025 il conto economico è cambiato, per cui se ci posizioniamo nel 2025, non potremo avere una corrispondeza con gli es. pecedenti,
-- se domani ci posizioniam nel 2026 , non potremo avere la corrispondenza lioneare col 2024, 2023...
-- i dati della matrice vengono calcolati dalla sp, nel report possiamo solo visualizzarli opportunamente
-- Al momento dal 2024, a decrescere funziona bene, ma dal 2024 in poi c'èì il problema

-- Per risolvere la situazione ho pensato di attualizzare i conti del CE all'ultimo esercizio, ossia all' YEAR(GETDATE()), 
-- e quindi usare il campo "actual_codicecontoeconomico"


END


GO

-- select * from DataWareHouse_ENTE.dbo.accountricavididattica_td
