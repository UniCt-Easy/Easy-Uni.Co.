
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


-- CREAZIONE VISTA incomedefaultview
IF EXISTS(select * from sysobjects where id = object_id(N'[incomedefaultview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [incomedefaultview]
GO

CREATE VIEW [incomedefaultview] AS 
SELECT  income.adate AS income_adate, income.autocode AS income_autocode, income.autokind AS income_autokind, income.ct AS income_ct, income.cu AS income_cu, income.cupcode AS income_cupcode, income.description, income.doc AS income_doc, income.docdate AS income_docdate, income.expiration AS income_expiration, income.external_reference AS income_external_reference, income.flag AS income_flag, income.idinc, income.idpayment AS income_idpayment,
 [dbo].registry.title AS registry_title, income.idreg,
 underwriting.title AS underwriting_title, income.idunderwriting, income.lt AS income_lt, income.lu AS income_lu, income.nmov AS income_nmov, income.nphase AS income_nphase, income.parentidinc AS income_parentidinc, income.rtf AS income_rtf, income.txt AS income_txt, income.ymov AS income_ymov,
 isnull('Descrizione: ' + income.description + '; ','') + ' ' + isnull('Esercizio : ' + CAST( income.ymov AS NVARCHAR(64)) + '; ','') + ' ' + isnull('Numero movimento : ' + CAST( income.nmov AS NVARCHAR(64)) + '; ','') as dropdown_title
FROM income WITH (NOLOCK) 
LEFT OUTER JOIN [dbo].registry WITH (NOLOCK) ON income.idreg = [dbo].registry.idreg
LEFT OUTER JOIN underwriting WITH (NOLOCK) ON income.idunderwriting = underwriting.idunderwriting
WHERE  income.idinc IS NOT NULL 
GO

