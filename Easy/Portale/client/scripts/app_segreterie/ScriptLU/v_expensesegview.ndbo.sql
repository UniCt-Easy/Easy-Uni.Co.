
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


-- CREAZIONE VISTA expensesegview
IF EXISTS(select * from sysobjects where id = object_id(N'[expensesegview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [expensesegview]
GO

CREATE VIEW [expensesegview] AS 
SELECT  expense.adate AS expense_adate, expense.autocode AS expense_autocode, expense.autokind AS expense_autokind, expense.cigcode AS expense_cigcode, expense.ct AS expense_ct, expense.cu AS expense_cu, expense.cupcode AS expense_cupcode, expense.description, expense.doc AS expense_doc, expense.docdate AS expense_docdate, expense.expiration AS expense_expiration, expense.external_reference AS expense_external_reference, expense.flag AS expense_flag,
 clawback.description AS clawback_description, expense.idclawback, expense.idexp, expense.idformerexpense AS expense_idformerexpense,
 incomelinked.description AS incomelinked_description, incomelinked.ymov AS incomelinked_ymov, incomelinked.nmov AS incomelinked_nmov, expense.idinc_linked, expense.idpayment AS expense_idpayment,
 [dbo].registry.title AS registry_title, expense.idreg, expense.lt AS expense_lt, expense.lu AS expense_lu, expense.nmov AS expense_nmov, expense.nphase AS expense_nphase, expense.parentidexp AS expense_parentidexp, expense.rtf AS expense_rtf, expense.txt AS expense_txt, expense.ymov AS expense_ymov,
 isnull('Descrizione: ' + expense.description + '; ','') + ' ' + isnull('Esercizio : ' + CAST( expense.ymov AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Numero movimento : ' + CAST( expense.nmov AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM expense WITH (NOLOCK) 
LEFT OUTER JOIN clawback WITH (NOLOCK) ON expense.idclawback = clawback.idclawback
LEFT OUTER JOIN income AS incomelinked WITH (NOLOCK) ON expense.idinc_linked = incomelinked.idinc
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON expense.idreg = [dbo].registry.idreg
WHERE  expense.idexp IS NOT NULL 
GO

